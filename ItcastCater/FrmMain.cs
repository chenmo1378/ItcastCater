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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public event EventHandler evtBill;//开单的
        public event EventHandler evtMoney;
        public event EventHandler evtBalance;//结账的
        //房间设置
        private void btnRoom_Click(object sender, EventArgs e)
        {
            FrmRoom frmRoom = new FrmRoom();
            frmRoom.ShowDialog();
        }
        //会员设置窗体
        private void button4_Click(object sender, EventArgs e)
        {
            FrmMember fm = new FrmMember();
            fm.ShowDialog();
        }
        //加载商品设置窗体
        private void button5_Click(object sender, EventArgs e)
        {
            FrmCategory fcg = new FrmCategory();
            fcg.ShowDialog();
        }
        //加载房间
        private void LoadRoomInfoByDelFlag(int delFlag)
        {
            RoomInfoBLL bll = new RoomInfoBLL();//创建一个实例
            //获取所有的房间集合
            List<RoomInfo> listRoom = bll.GetAllRoomInfoByDelFlag(delFlag);
            //反循环
            for (int i = listRoom.Count - 1; i >= 0; i--)
            {
                //创建tabpage(控件)选项卡,创建一个listview(东西)
                //tabpage添加到tcinfo中,listview添加到tabpage中
                TabPage tp = new TabPage();
                tp.Tag = listRoom[i];//把房间的对象存到"控件"的tag属性中
                tp.Text = listRoom[i].RoomName;

                ListView lv = new ListView();//创建一个显示餐桌的"东西"
                lv.Dock = DockStyle.Fill;//这个控件在父容器中填满
                lv.View = View.LargeIcon;//图片的显示方式
                lv.BackColor = Color.White;//背景颜色
                lv.LargeImageList = imageList1;
                lv.MultiSelect = false;//禁止多选
                //为lv添加一个事件,当里面的选中项发生改变时做什么事情
                lv.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lv_ItemSelectionChanged);
                tp.Controls.Add(lv);//把lv这个东西添加到tabpage控件中
                tcInFo.TabPages.Add(tp);
            }
        }
        //加载餐桌,tp表示的是哪个选项卡.p表示的是删除标识
        private void LoadDeskInfoByDelFlag(TabPage tp)//, int p)
        {
            RoomInfo room = tp.Tag as RoomInfo;
            int roomId = Convert.ToInt32(room.RoomId);//获取房间的id
            ListView lv = tp.Controls[0] as ListView;//获取当前选项卡中的listview控件(东西)
            lv.Clear();//清空
            DeskInfoBLL bll = new DeskInfoBLL();
            //通过房间的id获取该房间下的所有的餐桌
            List<DeskInfo> list = bll.GetAllDeskInfoByRoomId(roomId);//

            for (int i = 0; i < list.Count; i++)
            {
                //if (list[i].DeskState==0)
                //{
                //    lv.Items.Add(list[i].DeskName, 0);
                //}
                //else if (list[i].DeskState==1)
                //{
                //    lv.Items.Add(list[i].DeskName, 1);
                //}
                lv.Items.Add(list[i].DeskName, Convert.ToInt32(list[i].DeskState));
                lv.Items[i].Tag = list[i];//把餐桌的对象绑定到每个项的tag属性中
                //else if (list[i].DeskState==2)
                //{

                //}
            }
        }

        //这个事件 主要是选中餐桌的时候把吃饭的餐桌的消费的菜单显示到主窗体的dgv中
        void lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }


        //主窗体加载
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //先加载房间
            LoadRoomInfoByDelFlag(0);

            //加载餐桌
            //只加载默认的第一个房间里面的餐桌,当选中某个tabpage控件的时候再去加载该房间中的餐桌
            TabPage tp = tcInFo.TabPages[0];
            LoadDeskInfoByDelFlag(tp);//, 0);
            tcInFo.SelectedIndexChanged += new EventHandler(tcInFo_SelectedIndexChanged);
        }

        void tcInFo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeskInfoByDelFlag(tcInFo.TabPages[tcInFo.SelectedIndex]);//, 0);//加载餐桌
        }
        //增加消费
        private void button2_Click(object sender, EventArgs e)
        {


            TabPage tp = tcInFo.SelectedTab;//获取当前餐桌所在的房间的选项卡
            RoomInfo r = tp.Tag as RoomInfo;//从tag中获取房间的对象==坑---名字,最低消费
            ListView lv = tp.Controls[0] as ListView;//获取listview
            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem lvt = lv.SelectedItems[0];//获取当前listview中选中的项
                DeskInfo dk = lvt.Tag as DeskInfo;//可以获取该选中的餐桌的编号还有id
                if (dk.DeskState == 1)
                {
                    FrmAddMoney fam = new FrmAddMoney();
                    this.evtMoney += new EventHandler(fam.SetTxt);//添加事件
                    //获取要传递的参数后  显示开单的窗体
                    FrmEventArgs fea = new FrmEventArgs();
                    //fea.Obj = dk;//餐桌的对象
                    fea.Name = dk.DeskName;//餐桌的编号
                    //这里必须要获取该餐桌的订单id===============坑
                    OrderInfoBLL obll = new OrderInfoBLL();
                    int orderId = obll.GetOrderIdByDeskId(dk.DeskId);//获取订单的id(当前餐桌)
                    fea.Temp = orderId;//订单id传到消费窗体中
                    if (this.evtMoney != null)
                    {
                        this.evtMoney(this, fea);
                    }
                    //此窗体关闭后 一定要进行刷新.
                    fam.FormClosed += new FormClosedEventHandler(fbl_FormClosed);
                    fam.ShowDialog();//增加消费的窗体显示出来
                }
                else
                {
                    MessageBox.Show("请选择已经开单的餐桌");
                }

            }
            else
            {
                MessageBox.Show("请看好目标后再下手");
            }
        }
        //顾客开单
        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tp = tcInFo.SelectedTab;//获取当前餐桌所在的房间的选项卡
            RoomInfo r = tp.Tag as RoomInfo;//从tag中获取房间的对象==坑---名字,最低消费
            ListView lv = tp.Controls[0] as ListView;//获取listview
            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem lvt = lv.SelectedItems[0];//获取当前listview中选中的项
                DeskInfo dk = lvt.Tag as DeskInfo;//可以获取该选中的餐桌的编号还有id
                if (dk.DeskState == 0)
                {
                    FrmBilling fbl = new FrmBilling();
                    this.evtBill += new EventHandler(fbl.SetLab);
                    //获取要传递的参数后  显示开单的窗体
                    FrmEventArgs fea = new FrmEventArgs();
                    fea.Obj = dk;//餐桌的对象
                    fea.Name = r.RoomName;//房间的名字,  //获取该餐桌所在的房间,这个房间的最低消费
                    fea.Money = Convert.ToDecimal(r.RoomMinimunConsume);
                    if (this.evtBill != null)
                    {
                        this.evtBill(this, fea);
                    }
                    //此窗体关闭后 一定要进行刷新.
                    fbl.FormClosed += new FormClosedEventHandler(fbl_FormClosed);
                    fbl.ShowDialog();//开单的窗体
                }
                else
                {
                    MessageBox.Show("请选择未开单的餐桌");
                }

            }
            else
            {
                MessageBox.Show("请看好目标后再下手");
            }
        }
        //订单窗体关闭事件
        void fbl_FormClosed(object sender, FormClosedEventArgs e)
        {
            //获取当前的房间的选项,获取这个选项中的tabpage，刷新这个房间的餐桌(状态)
            //超级大坑.
            TabPage tp = tcInFo.SelectedTab;
            LoadDeskInfoByDelFlag(tp);//, 0);
        }
        //结账按钮
        private void button3_Click(object sender, EventArgs e)
        {
            TabPage tp = tcInFo.SelectedTab;//获取当前餐桌所在的房间的选项卡
            RoomInfo r = tp.Tag as RoomInfo;//从tag中获取房间的对象==坑---名字,最低消费
            ListView lv = tp.Controls[0] as ListView;//获取listview
            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem lvt = lv.SelectedItems[0];//获取当前listview中选中的项
                DeskInfo dk = lvt.Tag as DeskInfo;//可以获取该选中的餐桌的编号还有id
                if (dk.DeskState == 1)
                {
                    FrmBalance fb = new FrmBalance();
                    this.evtBalance += new EventHandler(fb.SetTxt);//传值
                    //获取要传递的参数后  显示开单的窗体
                    FrmEventArgs fea = new FrmEventArgs();
                   
                    fea.Name = dk.DeskName;//餐桌的编号
                    fea.DkIdZ = dk.DeskId;//餐桌的id
                    //这里必须要获取该餐桌的订单id===============坑
                    OrderInfoBLL obll = new OrderInfoBLL();
                    int orderId = obll.GetOrderIdByDeskId(dk.DeskId);//获取订单的id(当前餐桌)
                    fea.Temp = orderId;//订单id传到消费窗体中
                    if (this.evtBalance != null)
                    {
                        this.evtBalance(this, fea);
                    }
                    //此窗体关闭后 一定要进行刷新.
                    fb.FormClosed += new FormClosedEventHandler(fbl_FormClosed);//调用上面的方法
                    fb.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请选择已经开单的餐桌");
                }

            }
            else
            {
                MessageBox.Show("请看好目标后再下手");
            }
        }

      


    }
}
