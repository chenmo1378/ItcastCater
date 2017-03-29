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
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }
        private int Tp;//标识
        //注册事件调用的方法
        public void SetTxt(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    tb.Text = "";
                }
            }
            FrmEventArgs fea = e as FrmEventArgs;
            this.Tp = fea.Temp;
            if (this.Tp==2)
            {
                CategoryInfo ct= fea.Obj as CategoryInfo;
                txtCName.Text = ct.CatName;
                txtCNum.Text = ct.CatNum;
                txtCRemark.Text = ct.Remark;
                labId.Text = ct.CatId.ToString();//id存起来
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断文本框不能为空
            if (IsCheck())
            {
                //判断是新增还是修改
                CategoryInfo cat = new CategoryInfo();
                cat.CatName = txtCName.Text;
                cat.CatNum = txtCNum.Text;
                cat.Remark = txtCRemark.Text;
                if (this.Tp==1)//新增
                {
                    cat.DelFlag = 0;
                    cat.SubBy = 1;
                    cat.SubTime = DateTime.Now;
                }
                else if (this.Tp==2)//修改
                {
                    cat.CatId = Convert.ToInt32(labId.Text);
                }
                CategoryInfoBLL bll=new CategoryInfoBLL();
                string msg = bll.SaveCategory(cat, this.Tp) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();

            }
        }
        //判断文本框不能为空
        private bool IsCheck()
        {
            if (string.IsNullOrEmpty(txtCName.Text))
            {
                MessageBox.Show("商品类别名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                MessageBox.Show("商品类别编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                MessageBox.Show("备注不能为空");
                return false;
            }
            return true;
        }
    }
}
