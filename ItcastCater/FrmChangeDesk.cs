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
    public partial class FrmChangeDesk : Form
    {
        public FrmChangeDesk()
        {
            InitializeComponent();
        }
        private int Tp;//标识3- 增加-4--修改
        public void LoadRoomNameAndRoomId(int p)
        {
            //显示房间的名字
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo>list= bll.GetRoomNameAndId(0);
            list.Insert(0, new RoomInfo() {  RoomName="请选择", RoomId=-1});
            cmdRoom.DataSource = list;
            cmdRoom.DisplayMember = "RoomName";
            cmdRoom.ValueMember = "RoomId";
        }
        //事件赋值
        public void SetTxt(object sender, EventArgs e)
        {
            LoadRoomNameAndRoomId(0);
            //清空当前窗体的所有的文本框内容
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb=item as TextBox;
                    tb.Text = "";
                }
            }
            FrmEventArgs fea=e as FrmEventArgs;
            this.Tp = fea.Temp;//标识存起来
            if (this.Tp==4)//修改
            {
                DeskInfo dk = fea.Obj as DeskInfo;
                txtDeskName.Text = dk.DeskName;
                txtDeskRegion.Text = dk.DeskRegion;
                txtDeskRemark.Text = dk.DeskRemark;
                labId.Text = dk.DeskId.ToString();//把id存起来
                cmdRoom.SelectedValue = dk.RoomId;//把房间的id绑定到下拉框,下拉框就会显示对象的名字
            }
         

        }
        //添加和修改
        private void btnOk_Click(object sender, EventArgs e)
        {

            //先判断不能为空

            if (IsCheck())
            { 
                //判断是新增还是修改
                DeskInfo dk = new DeskInfo();
                dk.DeskName = txtDeskName.Text;
                dk.DeskRegion = txtDeskRegion.Text;
                dk.DeskRemark = txtDeskRemark.Text;
                dk.RoomId =Convert.ToInt32( cmdRoom.SelectedValue);
                if (this.Tp==3)//添加
                {
                    dk.DelFlag = 0;
                    dk.DeskState = 0;
                    dk.SubBy = 1;
                    dk.SubTime = DateTime.Now;
                }
                else if (this.Tp==4)//修改
                {
                    dk.DeskId = Convert.ToInt32(labId.Text);
                }
                DeskInfoBLL bll = new DeskInfoBLL();
                string msg=  bll.SaveDeskinfo(dk, this.Tp)?"操作成功":"操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
           


        }
        private bool IsCheck()
        {
            if (string.IsNullOrEmpty(txtDeskName.Text))
            {
                MessageBox.Show("餐桌名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRegion.Text))
            {
                MessageBox.Show("描述信息不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRemark.Text))
            {
                MessageBox.Show("备注不能为空");
                return false;
            }
            if (cmdRoom.SelectedValue.ToString()=="-1")
            {
                MessageBox.Show("请选择房间");
                return false;
            }
            return true;
        }
    }
}
