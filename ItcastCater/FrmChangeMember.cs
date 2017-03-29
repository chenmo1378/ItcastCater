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
    public partial class FrmChangeMember : Form
    {
        public FrmChangeMember()
        {
            InitializeComponent();
        }
        private int Tp;
        //加载会员级别的
        public void LoadMemmberType(int p)
        {
            MemmberTypeBLL bll = new MemmberTypeBLL();
            List<MemmberType> list = bll.GetAllMemmberTypeByDelFlag(p);
            list.Insert(0, new MemmberType() {  MemType=-1, MemTpName="请选择"});
            cmbMemType.DataSource = list;
            cmbMemType.DisplayMember = "MemTpName";
            cmbMemType.ValueMember = "MemType";
        }
        //设置文本框的内容
        public void SetTxt(object sender, EventArgs e)
        {
            LoadMemmberType(0);
            //清空所有文本框
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    tb.Text = "";
                }
            }
            FrmEventArgs fea=e as FrmEventArgs;
            //设置标识
            this.Tp = fea.Temp;
            //判断是修改还是增加
            if (this.Tp==2)
            {
                MemmberInfo mem=fea.Obj as MemmberInfo;
                //设置所有文本框的内容
                txtBirs.Text = mem.MemBirthdaty.ToString();//生日
                txtMemDiscount.Text = mem.MemDiscount.ToString();//折扣
                txtMemIntegral.Text = mem.MemIntegral.ToString();//积分
                txtmemMoney.Text = mem.MemMoney.ToString();//余额
                txtMemName.Text = mem.MemName;//会员名字
                txtMemNum.Text = mem.MemNum;//会员编号
                txtMemPhone.Text = mem.MemMobilePhone;//手机
                dtEndServerTime.Value =Convert.ToDateTime( mem.MemEndServerTime);//有效时间
                rdoMan.Checked = mem.MemGender == "男" ? true : false;
                rdoWomen.Checked = mem.MemGender == "女" ? true : false;
                labId.Text = mem.MemmberId.ToString();
                cmbMemType.SelectedValue = mem.MemType;
            }
            else if (this.Tp==1)
            {
                txtMemIntegral.Text="0";
            }
        }
        //增加或者是修改
        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断文本框不能为空
            if (IsCheck())
            {
                //判断是新增还是修改
                MemmberInfo mem = new MemmberInfo();
                //地址没写
                mem.MemBirthdaty =Convert.ToDateTime( txtBirs.Text);//生日最好用控件
                mem.MemDiscount = Convert.ToDecimal(txtMemDiscount.Text);//折扣
                mem.MemEndServerTime = dtEndServerTime.Value;
                mem.MemGender = IsGender();
                mem.MemIntegral = Convert.ToInt32(txtMemIntegral.Text);
                mem.MemMobilePhone = txtMemPhone.Text;
                mem.MemMoney = Convert.ToDecimal(txtmemMoney.Text);
                mem.MemName = txtMemName.Text;
                mem.MemNum = txtMemNum.Text;
                mem.MemType =Convert.ToInt32( cmbMemType.SelectedValue);

                if (this.Tp==1)//新增
                {
                    mem.DelFlag = 0;
                    mem.SubTime = DateTime.Now;
                }
                else if (this.Tp==2)//修改id
                {
                    mem.MemmberId = Convert.ToInt32(labId.Text);
                }
                //调用方法 是新增还是修改

                MemmberInfoBLL bll = new MemmberInfoBLL();

                string msg = bll.SaveMemmberInfo(mem,this.Tp)?"操作成功":"操作失败";
                MessageBox.Show(msg);
                this.Close();

            }
        }
        //性别
        private string IsGender()
        {
            if (rdoMan.Checked)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        }
        //判断文本框不能为空
        private bool IsCheck()
        {
            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemIntegral.Text))
            {
                MessageBox.Show("积分不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("余额不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;

            }
            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(dtEndServerTime.Text))
            {
                MessageBox.Show("有效期不能为空");
                return false;
            }
            return true;
        }
    }
}
