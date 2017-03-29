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
    public partial class FrmMember : Form
    {
        public FrmMember()
        {
            InitializeComponent();
        }
        public event EventHandler evt;//事件
        FrmEventArgs fea = new FrmEventArgs();
        private void FrmMember_Load(object sender, EventArgs e)
        {
            //显示所有的会员信息
            LoadMemmberInfoByDelFlag(0);
        }
        private void LoadMemmberInfoByDelFlag(int p)
        {
            MemmberInfoBLL bll = new MemmberInfoBLL();
            dgvMemmber.AutoGenerateColumns = false;//禁止自动生成列
            dgvMemmber.DataSource = bll.GetAllMemmberInfoByDelFlag(p);
            dgvMemmber.SelectedRows[0].Selected = false;//默认不选中
        }
        //删除会员
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count>0)
            {
                if (DialogResult.OK==MessageBox.Show("是否删除","删除", MessageBoxButtons.OKCancel))
                {
                    string strId = dgvMemmber.SelectedRows[0].Cells[0].Value.ToString();
                    int memId = Convert.ToInt32(strId);
                    MemmberInfoBLL bll = new MemmberInfoBLL();
                    string msg = bll.DeleteMemmber(memId) ? "操作成功" : "操作失败";
                    MessageBox.Show(msg);
                    LoadMemmberInfoByDelFlag(0);
                }
               
            }
            else
            {
                MessageBox.Show("请选中删除的会员");
            }
        }

        //添加
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            ShowChangeMemmber(1);//1表示增加
        }
        //修改
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count>0)
            {
                
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value);
                MemmberInfoBLL bll=new MemmberInfoBLL();
                MemmberInfo mem = bll.GetMemmberByMemmberid(id);
                mem.MemmberId = id;
                fea.Obj = mem;
                ShowChangeMemmber(2);//2表示修改
                //根据选中行的id去数据库查询是否有这条数据,并以对象的方式返回来
                //传对象
            }
        }
        //显示会员设置窗体
        private void ShowChangeMemmber(int p)
        {
            FrmChangeMember fcm = new FrmChangeMember();
            this.evt+=new EventHandler(fcm.SetTxt);
            fea.Temp = p;
            if (this.evt!=null)
            {
                this.evt(this,fea);
            }
            fcm.FormClosed += new FormClosedEventHandler(fcm_FormClosed);
            fcm.ShowDialog();
        }

        void fcm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemmberInfoByDelFlag(0);
        }
    }
}
