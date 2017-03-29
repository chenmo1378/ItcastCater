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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        private event EventHandler evt;
        private event EventHandler Myevt;
        FrmEventArgs fea = new FrmEventArgs();
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            //加载所有的商品类别
            LoadCategoryInfoByDelFlag(0);
            //加载所有的菜单
            LoadProductInfoByDelFlag(0);

            //为下拉框绑定商品类别数据
            BingCMBLoadCategoryInfoByDelFlag(0);
        }
        private void BingCMBLoadCategoryInfoByDelFlag(int delFlag)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(delFlag);
            list.Insert(0, new CategoryInfo { CatId=-1, CatName="请选择" });
            cmbCategory.DataSource = list;//为下拉框绑定数据
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
        //加载所有商品类别
        private void LoadCategoryInfoByDelFlag(int delFlag)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            dgvCategoryInfo.AutoGenerateColumns = false;//禁止自动生成列
            dgvCategoryInfo.DataSource = bll.GetAllCategoryInfoByDelFlag(delFlag);
            dgvCategoryInfo.SelectedRows[0].Selected = false;//没有被选中的
 
        }
        //加载所有产品
        private void LoadProductInfoByDelFlag(int delFlag)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProductInfo.AutoGenerateColumns = false;
            dgvProductInfo.DataSource = bll.GetAllProductInfoByDelFlag(delFlag);
            dgvProductInfo.SelectedRows[0].Selected = false;
        }
        //添加商品类别
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ShowFrmChangeCategory(1);//添加
        }
        //修改商品类别
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategoryInfo.SelectedRows.Count>0)
            {
                //获取id
                string id = dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString();
                //获取对象,通过id去数据库查询该id对应的商品类别信息
                CategoryInfoBLL bll = new CategoryInfoBLL();
                CategoryInfo ct = bll.GetCategoryInfoByCatId(Convert.ToInt32(id));
                ct.CatId = Convert.ToInt32(id);
                fea.Obj = ct;
                //传对象
                ShowFrmChangeCategory(2);//添加
            }
            else
            {
                MessageBox.Show("请选中行");
            }
        }
        private void ShowFrmChangeCategory(int p)
        {
            FrmChangeCategory fcc = new FrmChangeCategory();
            this.evt+=new EventHandler(fcc.SetTxt);
            fea.Temp = p;
            if (this.evt!=null)
            {
                this.evt(this,fea);
            }
            fcc.FormClosed += new FormClosedEventHandler(fcc_FormClosed);
            fcc.ShowDialog();
        }
        //商品类别窗体关闭刷新重新加载商品类别
        void fcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
        }
        //新增菜
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            //新增传3
            ShowFrmChangeProduct(3);
        }
        //修改菜
        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            //修改传4
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                //获取id,获取该id对象的数据
                string strId = dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString();
                int id = Convert.ToInt32(strId);
                ProductInfoBLL bll = new ProductInfoBLL();
                ProductInfo pro = bll.GetProductByProId(id);
                pro.ProId = id;
                fea.Obj = pro;//传对象
                //传对象
                ShowFrmChangeProduct(4);
            }
            else
            {
                MessageBox.Show("选中行");
            }
        }
        private void ShowFrmChangeProduct(int p)
        {
            FrmChangeProduct fcp = new FrmChangeProduct();
            this.Myevt+=new EventHandler(fcp.SetTxt);
            fea.Temp = p;
            if (this.Myevt!=null)
            {
                this.Myevt(this,fea);
            }
            fcp.FormClosed += new FormClosedEventHandler(fcp_FormClosed);
            fcp.ShowDialog();

        }
        //关闭后重新刷新菜
        void fcp_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }
        //删除菜
        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            //有选中的行
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                if (DialogResult.OK==MessageBox.Show("是否删除","删除", MessageBoxButtons.OKCancel))
                {
                   //获取id --去产品的表 删除这一行就可以了

                    string strId = dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString();
                    int id = Convert.ToInt32(strId);
                    ProductInfoBLL bll = new ProductInfoBLL();
                    string msg= bll.DeleteProduct(id)?"操作成功":"操作失败";
                    MessageBox.Show(msg);
                    LoadProductInfoByDelFlag(0);
                }
            }
            else
            {
                MessageBox.Show("请选中删除的行");
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex==0)
            {
                LoadProductInfoByDelFlag(0);//查询所有的产品
            }
            else
            {
                int id = Convert.ToInt32(cmbCategory.SelectedValue);
                //根据商品类别的id去产品的表中查询该类别下的所有的产品,重新绑定到dgvproduct上
                ProductInfoBLL bll = new ProductInfoBLL();
                dgvProductInfo.AutoGenerateColumns = false;
                dgvProductInfo.DataSource = bll.GetProductInfoByCatId(id);
                dgvProductInfo.SelectedRows[0].Selected = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //只要文本框的内容改变这个事件就会被触发
            //获取文本框的内容

            ProductInfoBLL bll = new ProductInfoBLL();
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadProductInfoByDelFlag(0);
            }
            else
            {
                if ( bll.GetProductByProNum(txtSearch.Text).Count==0)
                {

                }
                else
                {
                    dgvProductInfo.AutoGenerateColumns = false;
                    dgvProductInfo.DataSource = bll.GetProductByProNum(txtSearch.Text);
                    dgvProductInfo.SelectedRows[0].Selected = false;
                }
             
            }
         

        }

    }
}
