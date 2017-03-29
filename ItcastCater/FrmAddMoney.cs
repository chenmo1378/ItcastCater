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
    public partial class FrmAddMoney : Form
    {
        public FrmAddMoney()
        {
            InitializeComponent();
        }
        private int ordId;//订单的id
        //窗体传值
        public void SetTxt(object sender, EventArgs e)
        {
            FrmEventArgs fea = e as FrmEventArgs;
            labDeskName.Text = fea.Name;//获取餐桌的编号
            this.ordId = fea.Temp;//获取该订单的id;
        }
        //加载商品类别的方法
        private void LoadCategoryInfo(int delFlag)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            //获取所有没有被删除的商品类别
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(delFlag);
            LoadCategoryBingTv(list, tvCategory.Nodes);
        }
        //加载消费项目左侧第二个选项卡
        private void LoadCategoryBingTv(List<CategoryInfo> list, TreeNodeCollection tv)
        {
            foreach (CategoryInfo item in list)
            {
                TreeNode tn = tv.Add(item.CatName);
                //tn.Tag = item.CatId;
                LoadProductByCatId(item.CatId, tn);
            }
        }
        //加载消费项目左侧第二个选项卡,根据商品类别id获取该类别下的商品
        private void LoadProductByCatId(int p, TreeNode tn)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            List<ProductInfo> list = bll.GetProductInfoByCatId(p);
            foreach (ProductInfo item in list)
            {
                tn.Nodes.Add(item.ProName + "===" + item.ProPrice + "元");
            }
        }
        //窗体加载
        private void FrmAddMoney_Load(object sender, EventArgs e)
        {
            //窗体加载的时候把菜单显示出来
            LoadProductInfoByDelFlag(0);

            //加载节点树
            LoadCategoryInfo(0);

            //窗体加载的时候把用户添加的菜显示出来
            LoadOrderProduct();
        }
        //加载菜单
        private void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = bll.GetAllProductInfoByDelFlag(p);
            dgvProduct.SelectedRows[0].Selected = false;
        }
        //显示用户点的什么菜
        private void LoadOrderProduct()
        {
            R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
            dgvROrderProduct.AutoGenerateColumns = false;//禁止自动生成列
            dgvROrderProduct.DataSource = bll.GetProduct(this.ordId);
            dgvROrderProduct.SelectedRows[0].Selected = false;//默认不选中

           //不为空
           R_OrderInfo_Product rop=  bll.GetCountAndMoney(this.ordId);
           labSumMoney.Text = rop.MONEY.ToString();//总金额
           labCount.Text = rop.CT.ToString();//点了多少个菜
        }
        //双击左侧菜单添加消费项目
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            R_OrderInfo_Product rop = new R_OrderInfo_Product();
            //获取当前选中的菜的id
            string strId = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();
            rop.ProId = Convert.ToInt32(strId);
            //获取点菜的数量
            rop.UnitCount = string.IsNullOrEmpty(txtCount.Text) || txtCount.Text == "1" ? 1 : Convert.ToInt32(txtCount.Text);//判断是否能转换成功===我省略了.
            //订单的id
            rop.OrderId = this.ordId;
            //把这些数据全部插入到订单和菜单的中间表去.
            //其他的数据
            rop.DelFlag = 0;
            rop.State = 0;
            rop.SubTime = DateTime.Now;
            R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
            //如果菜添加成功了,就要在窗体的右侧显示点的什么菜
            if (bll.AddOrderProduct(rop))
            {
                //刷新右侧的菜单
                //添加菜成功后要刷新--窗体加载的时候要刷新. 主界面还要查询
                LoadOrderProduct();
                txtCount.Text = "";
            }
            else
            {
                MessageBox.Show("对不起点菜失败");
            }

        }
        //退菜
        private void btnDeleteRorderPro_Click(object sender, EventArgs e)
        {
            //获取选中菜的id
            if (dgvROrderProduct.SelectedRows.Count>0)
            {
                if (DialogResult.OK== MessageBox.Show("是否删除","删除", MessageBoxButtons.OKCancel))
                {
                    //获取当前选中要退菜的id
                    int id = Convert.ToInt32(dgvROrderProduct.SelectedRows[0].Cells[0].Value);
                    R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
                    string msg= bll.DeleteROrderInfoProduct(id)?"退菜成功":"退菜失败";//删除选中的菜
                    MessageBox.Show(msg);
                    LoadOrderProduct();//刷新
                }
            }
            else
            {
                MessageBox.Show("请选中要删除的行");
            }
        }
        //int n = 0;
        //更新订单表中的金额
        private void btnOk_Click(object sender, EventArgs e)
        {
            //n++;
            //OrderInfoBLL bll = new OrderInfoBLL();
            //if (bll.UpdateOrderMoney(this.ordId,Convert.ToDecimal(labSumMoney.Text)))
            //{
            //    MessageBox.Show("订单提交成功");
            //}
            //else
            //{
            //    MessageBox.Show("订单提交失败");
            //}
        }

        private void FrmAddMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
    
            if (DialogResult.OK== MessageBox.Show("确定关闭吗?","提示订单提交", MessageBoxButtons.OKCancel))
            {
                if (!string.IsNullOrEmpty(labSumMoney.Text))
                {
                    OrderInfoBLL bll = new OrderInfoBLL();
                    if (bll.UpdateOrderMoney(this.ordId, Convert.ToDecimal(labSumMoney.Text)))
                    {
                        MessageBox.Show("订单提交成功");
                    }
                    else
                    {
                        MessageBox.Show("订单提交失败");
                    }
                }
               
            }
           
        }
    }
}
