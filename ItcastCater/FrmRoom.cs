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
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }
        public event EventHandler Myevt;
        public FrmEventArgs fea = new FrmEventArgs();
        //窗体加载
        private void FrmRoom_Load(object sender, EventArgs e)
        {
            //加载所有的房间数据
            LoadRoomInfoByDelFlag(0);
            //加载所有的餐桌数据
            LoadDeskInfoByDelFlag(0);
        }
        //加载房间
        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            //禁止自动生成列
            dgvRoomInfo.AutoGenerateColumns = false;
            dgvRoomInfo.DataSource= bll.GetAllRoomInfoByDelFlag(p);
            //默认没有被选中的行
            dgvRoomInfo.SelectedRows[0].Selected = false;
        }

        //加载餐桌

        private void LoadDeskInfoByDelFlag(int p)
        {
            DeskInfoBLL bll = new DeskInfoBLL();
            dgvDeskInfo.AutoGenerateColumns = false;//禁止自动生成列
            dgvDeskInfo.DataSource = bll.GetAllDeskInfoByDelFlag(p);
            dgvDeskInfo.SelectedRows[0].Selected = false;//没有被选中的
        }
        //新增
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ShowRoomChange(1);//1表示新增
        }
        //修改
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvRoomInfo.SelectedRows.Count>0)
            {
                //获取id
                string id = dgvRoomInfo.SelectedRows[0].Cells[0].Value.ToString();
                //根据id获取这一行的内容赋值给一个对象
                RoomInfoBLL bll = new RoomInfoBLL();
                //根据id查询房间信息
                RoomInfo room = bll.GetRoomInfoByRoomId(Convert.ToInt32(id));
                room.RoomId = Convert.ToInt32(id);
                fea.Obj = room;//把对象传到事件中去
                ShowRoomChange(2);//2表示修改
            }
            else
            {
                MessageBox.Show("请选中行");
            }
          
        }
        private void ShowRoomChange(int p)
        {
            fea.Temp = p;//传标识
            FrmChangeRoom frmCroom = new FrmChangeRoom();
            //注册事件
            this.Myevt += new EventHandler(frmCroom.SetText);//这个窗体中的方法就是为了赋值
            //判断事件不能为空
            if (this.Myevt!=null)
            {
                this.Myevt(this,fea);
            }
            frmCroom.FormClosed += new FormClosedEventHandler(frmCroom_FormClosed);
            frmCroom.ShowDialog();
        }
        //房间新增和修改窗体关闭后刷新
        void frmCroom_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadRoomInfoByDelFlag(0);
        }
        //选中行的时候获取id并查询该id对应的信息
        private void dgvRoomInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断是否有选中的行
            //if (dgvRoomInfo.SelectedRows.Count>0)
            //{
                ////获取id
                //string id = dgvRoomInfo.SelectedRows[0].Cells[0].Value.ToString();
                ////根据id获取这一行的内容赋值给一个对象
                //RoomInfoBLL bll = new RoomInfoBLL();
                ////根据id查询房间信息
                //RoomInfo room = bll.GetRoomInfoByRoomId(Convert.ToInt32(id));
                //room.RoomId = Convert.ToInt32(id);
                //fea.Obj = room;//把对象传到事件中去
            //}
        }
        //增加餐桌
        private void btnAddDesk_Click(object sender, EventArgs e)
        {
            ShowFrmChangeDesk(3);
        }
        //修改餐桌
        private void btnUpdateDesk_Click(object sender, EventArgs e)
        {
            if (dgvDeskInfo.SelectedRows.Count>0)
            {
                //获取选中行的id.查询该id餐桌的信息
                string id = dgvDeskInfo.SelectedRows[0].Cells[0].Value.ToString();
                DeskInfoBLL bll = new DeskInfoBLL();
                int deskId = Convert.ToInt32(id);
                DeskInfo dk = bll.GetDeskById(deskId);
                dk.DeskId = deskId;
                //对象传值
                fea.Obj = dk;
                ShowFrmChangeDesk(4);
            }
            else
            {
                MessageBox.Show("请选中行");
            }
        }
        //p为3是增加,4为修改
        public void ShowFrmChangeDesk(int p)
        {
            FrmChangeDesk fcDesk = new FrmChangeDesk();
            //添加一个事件
            this.Myevt+=new EventHandler(fcDesk.SetTxt);
            fea.Temp = p;
            if (this.Myevt!=null)
            {
                this.Myevt(this,fea);
            }
            fcDesk.FormClosed += new FormClosedEventHandler(fcDesk_FormClosed);
            fcDesk.ShowDialog();//显示餐桌信息的窗体

        }
        //刷新餐桌的信息
        void fcDesk_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByDelFlag(0);
        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeskInfo.SelectedRows.Count>0)
            {
                //删除餐桌的时候要判断该餐桌是否被使用
                int id = Convert.ToInt32(dgvDeskInfo.SelectedRows[0].Cells[0].Value);
                //省略了
                DeskInfoBLL bll = new DeskInfoBLL();
                string str = bll.DeleteDesk(id) ? "操作成功" : "操作失败";
                MessageBox.Show(str);
                LoadDeskInfoByDelFlag(0);
            }
        }
        //删除房间的时候
        private void button3_Click(object sender, EventArgs e)
        {
            //选中
            if (dgvRoomInfo.SelectedRows.Count>0)
            {
                if ( DialogResult.OK== MessageBox.Show("是否删除","删除", MessageBoxButtons.OKCancel))
                {
                    //开始删除
                    int id = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value);
                    DeskInfoBLL bll = new DeskInfoBLL();
                    //有正在使用的餐桌
                    if (Convert.ToInt32( bll.GetDeskState(id))>0)
                    {
                        MessageBox.Show("有餐桌正在使用不能删除");
                    }
                    else
                    {
                        //删除房间,删除该房间下的餐桌
                        RoomInfoBLL rbll = new RoomInfoBLL();
                        //判断一个该房间下是否有餐桌,有就删,没有就直接删房间
                        if (bll.DeleteDesk(id)&&rbll.DeleteRoomById(id))
                        {
                            MessageBox.Show("操作成功");
                            LoadRoomInfoByDelFlag(0);
                            LoadDeskInfoByDelFlag(0);
                        }
                        else
                        {
                            MessageBox.Show("操作失败");
                        }
                    }
                }
            }
        }

     
    }
}
