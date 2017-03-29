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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        private int Id;//存餐桌的id
        public event EventHandler evt;
        //设置内容
        public void SetLab(object sender, EventArgs e)
        {
            FrmEventArgs fea = e as FrmEventArgs;
            DeskInfo dk = fea.Obj as DeskInfo;
            labDeskName.Text = dk.DeskName;//餐桌的编号
            labRoomType.Text = fea.Name;
            labLittleMoney.Text = fea.Money.ToString();
            this.Id = dk.DeskId;//存餐桌的id
        }
        //确定开单
        private void btnOK_Click(object sender, EventArgs e)
        {
            //餐桌的id,改变餐桌的状态
            DeskInfoBLL dkBll = new DeskInfoBLL();
            bool dkResult = dkBll.UpdateDeskStateByDeskId(this.Id, 1);//餐桌开单了
            //添加一个订单,需要备注,订单的状态,提交人,提交时间,删除标识
            OrderInfo order = new OrderInfo();
            order.Remark = txtPersonCount.Text + txtDescription.Text;//人数和描述(备注)直接存到备注信息里
            order.SubBy = 1;
            order.SubTime = DateTime.Now;
            order.DelFlag = 0;
            order.OrderState = 1;//标识的是这个订单正在使用
            OrderInfoBLL odBll = new OrderInfoBLL();
            int orderId = odBll.GetOrderIdInsertOrderInfo(order);//插入一个订单的同时获取该订单的id
            //向中间表(订单和餐桌)插入 订单的id还有餐桌的id
            ROrderDeskBLL roddkBll = new ROrderDeskBLL();
            ROrderDesk rod = new ROrderDesk();
            rod.DeskId = this.Id;//餐桌id
            rod.OrderId = orderId;//订单id
            bool RoDResult = roddkBll.AddROrderDesk(rod);
            if (dkResult && RoDResult)
            {
                MessageBox.Show("开单成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("开单失败");
            }

            if (ckbMeal.Checked)
            {
                FrmAddMoney fam = new FrmAddMoney();
                this.evt += new EventHandler(fam.SetTxt);
                FrmEventArgs fea = new FrmEventArgs();
                fea.Name = labDeskName.Text;//餐桌的编号
                fea.Temp = orderId;//订单的id
                if (this.evt != null)
                {
                    this.evt(this, fea);
                }
                //增加消费的窗体关闭后,当前的开单窗体关闭
                fam.FormClosed += new FormClosedEventHandler(fam_FormClosed);
                fam.ShowDialog();
            }
        }

        void fam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
