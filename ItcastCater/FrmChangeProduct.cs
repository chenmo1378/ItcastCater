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
    public partial class FrmChangeProduct : Form
    {
        public FrmChangeProduct()
        {
            InitializeComponent();
        }
        private int Tp;
        private void LoadCategory(int delFlag)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(delFlag);
            list.Insert(0, new CategoryInfo() {  CatId=-1, CatName="请选择"});
            cmbCategory.DataSource = list;
            //绑定显示的是什么
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
         public void SetTxt(object sender, EventArgs e)
        {
            //加载所有商品类别的名字和id
            LoadCategory(0);

            //清空所有文本框
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    tb.Text = "";
                }
            }
            //设置标识
             FrmEventArgs fea=e as FrmEventArgs;
             this.Tp = fea.Temp;
            //判断是不是4--修改
             if (this.Tp==4)
             {
                 ProductInfo pro= fea.Obj as ProductInfo;
                 //一个一个来
                 cmbCategory.SelectedValue = pro.CatId;
                 txtCost.Text = pro.ProCost.ToString();
                 txtName.Text = pro.ProName;
                 txtNum.Text = pro.ProNum;
                 txtPrice.Text = pro.ProPrice.ToString();
                 txtRemark.Text = pro.Remark;
                 txtSpell.Text = pro.ProSpell;
                 txtStock.Text = pro.ProStock.ToString();
                 txtUnit.Text = pro.ProUnit;
                 labId.Text = pro.ProId.ToString();
             }
        }

         private void btnOk_Click(object sender, EventArgs e)
         {
             //判断每个文本框是不是空
             ProductInfo pro = new ProductInfo();
             pro.CatId =Convert.ToInt32( cmbCategory.SelectedValue);
             pro.ProCost = Convert.ToDecimal(txtCost.Text);
             pro.ProName = txtName.Text;
             pro.ProNum = txtNum.Text;
             pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
             pro.ProSpell = txtSpell.Text;
             pro.ProStock = Convert.ToDecimal(txtStock.Text);
             pro.ProUnit = txtUnit.Text;
             pro.Remark = txtRemark.Text;
             
             //判断是不是新增还是修改
             if (this.Tp==3)
             {
                 pro.DelFlag = 0;
                 pro.SubTime = DateTime.Now;
                 pro.SubBy = 1;
             }
             else if (this.Tp==4)
             {
                 pro.ProId = Convert.ToInt32(labId.Text);
             }
             ProductInfoBLL bll=new ProductInfoBLL();
             string msg = bll.SaveProduct(pro, this.Tp) ? "操作成功" : "操作失败";
             MessageBox.Show(msg);
             this.Close();
             //调用方法
         }

         private void txtName_TextChanged(object sender, EventArgs e)
         {
             
           txtSpell.Text=  Common.GetStringPinYin( txtName.Text);
         }
        //判断所有文本框不能为空
         //private bool IsCheckEmpty()
         //{
         //    if (string.IsNullOrEmpty())
         //    {
                 
         //    }
         //}
    }
}
