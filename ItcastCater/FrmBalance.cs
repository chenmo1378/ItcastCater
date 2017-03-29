using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItcastCater.BLL;
using ItcastCater.Model;

namespace ItcastCater
{
    public partial class FrmBalance : Form
    {
        public FrmBalance()
        {
            InitializeComponent();
        }
        private int Id;//存餐桌的id
        public void SetTxt(object sender, EventArgs e)
        {
            FrmEventArgs fea = e as FrmEventArgs;

            this.Id = fea.DkIdZ;//获取餐桌的id
            labDeskName.Text = fea.Name;//餐桌的编号
            labOrderId.Text = fea.Temp.ToString();//订单的id

            //根据订单的id查询这个订单消费了多少钱
            OrderInfoBLL bll = new OrderInfoBLL();
            labMoney.Text = bll.GetOrderMoney(fea.Temp).ToString();
            lblMoney.Text = labMoney.Text;//结账金额和消费金额一样------坑
        }
        //加载会员级别
        public void LoadMember(int p)
        {
            MemmberInfoBLL bll = new MemmberInfoBLL();
            List<MemmberInfo> list = bll.GetAllMemmberInfoByDelFlag(p);
            list.Insert(0, new MemmberInfo { MemmberId = -1, MemName = "请选择" });
            cmbMemmber.DataSource = list;
            cmbMemmber.DisplayMember = "MemName";
            cmbMemmber.ValueMember = "MemmberId";
        }

        private void FrmBalance_Load(object sender, EventArgs e)
        {
            LoadMember(0);
        }
        //会员是否选中计算花费多少钱
        private void cmbMemmber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMemmber.SelectedIndex != 0)
            {
                int memId = Convert.ToInt32(cmbMemmber.SelectedValue);
                MemmberInfoBLL bll = new MemmberInfoBLL();
                MemmberInfo mem = bll.GetMemMoneyAndDisCountAndTypeNameByMemId(memId);
                labyeMoney.Text = mem.MemMoney.ToString();//会员的余额
                lblDis.Text = mem.MemDiscount.ToString();//折扣
                labTp.Text = mem.MemTpName;
                lblMoney.Text = (Convert.ToDecimal(labMoney.Text) * mem.MemDiscount / 10).ToString();
            }
            else
            {
                labyeMoney.Text = "";
                lblDis.Text = "";
                labTp.Text = "";
                lblMoney.Text = labMoney.Text;
            }
        }
        //计算找零多少钱
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if (txtMoney.Text != "")
            {
                //凡是文本框转换的地方都要进行判断转换
                decimal decMoney = Convert.ToDecimal(txtMoney.Text);
                decimal zuihouMoney = Convert.ToDecimal(lblMoney.Text);
                lblSpareMoney.Text = (decMoney - zuihouMoney).ToString();
            }
            else
            {
                lblSpareMoney.Text = "";
            }


        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {



            OrderInfo order = new OrderInfo();
            order.OrderId = Convert.ToInt32(labOrderId.Text);//订单的id
            order.EndTime = DateTime.Now;//订单中的结束时间
           
            //如果选择会员
            if (cmbMemmber.SelectedIndex == 0)
            {
                //不是会员
               // order.DisCount = 10;

            }
            else
            {
                //是会员

                //会员的余额更新
                //如果是会员,那么要获取该会员的余额-当前消费的金额,更新到会员的表中
                decimal memYuMoney = Convert.ToDecimal(labyeMoney.Text) - Convert.ToDecimal(lblMoney.Text);
                int memId = Convert.ToInt32(cmbMemmber.SelectedValue);
                MemmberInfoBLL bll = new MemmberInfoBLL();
                bool memresult  = bll.UpdateMoney(memId, memYuMoney);//更新会员的余额
                order.OrderMemId = memId;//订单中的会员id
                order.DisCount = Convert.ToDecimal(lblDis.Text);//这个是订单中的会员折扣

            }
            //更新餐桌的状态=0
            //获取餐桌的id,更改餐桌的状态
            DeskInfoBLL dkBll = new DeskInfoBLL();
            bool result = dkBll.UpdateDeskStateByDeskId(this.Id, 0);
            //订单的状态=2
            //获取订单的id更改订单的状态.更新这个订单最后花费多少钱,结束时间
            order.OrderMoney = Convert.ToDecimal(lblMoney.Text);//这个订单花了多少钱
            //窗体关闭
            OrderInfoBLL obll = new OrderInfoBLL();
            bool oresult= obll.UpdateOrderInfoMoney(order);
            if (result&&oresult)
            {
                MessageBox.Show("结账成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("结账失败");
            }

        }
    }
}
