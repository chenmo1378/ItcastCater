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
    public partial class FrmChangeRoom : Form
    {
        public FrmChangeRoom()
        {
            InitializeComponent();
        }
        private int Tp;//标识
        public void SetText(object sender, EventArgs e)
        {
            FrmEventArgs fea = e as FrmEventArgs;
            this.Tp = fea.Temp;//把标识取出来存到TP中
            //循环遍历该窗体的所有的控件
            foreach (Control item in this.Controls)//窗体的所有控件
            {
                if (item is TextBox)//判断该控件是不是文本框
                {
                    TextBox tb = item as TextBox;//
                    tb.Text = "";//清空所有文本框的内容
                }
            }
            if (this.Tp==2)//如果是2就是修改
            {
                //为每个文本框赋值
                RoomInfo r= fea.Obj as RoomInfo;
                txtIsDeflaut.Text = r.IsDefault.ToString();
                txtRMinMoney.Text = r.RoomMinimunConsume.ToString();
                txtRName.Text = r.RoomName;
                txtRPerNum.Text = r.RoomMaxConsumer.ToString();
                txtRType.Text = r.RoomType.ToString();
                labId.Text = r.RoomId.ToString();
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            //获取文本框的内容 .判断不能为空,我的要求每个文本框都不能为空
            if (IsCheck())
            {
                RoomInfo r = new RoomInfo();
                //文本框的内容是否能转换我这忽略了
                r.IsDefault = Convert.ToInt32(txtIsDeflaut.Text);
                r.RoomMaxConsumer = Convert.ToDecimal(txtRPerNum.Text);
                r.RoomMinimunConsume = Convert.ToDecimal(txtRMinMoney.Text);
                r.RoomName = txtRName.Text;
                r.RoomType = Convert.ToInt32(txtRType.Text);
                //判断是新增还是修改
                if (this.Tp == 1)//新增
                {
                    r.DelFlag = 0;
                    r.SubBy = 1;
                    r.SubTime = DateTime.Now;
                }
                else if (this.Tp == 2)//修改
                {
                    r.RoomId = Convert.ToInt32(labId.Text);
                }
                RoomInfoBLL bll = new RoomInfoBLL();
                string msg= bll.SaveRoom(r, this.Tp)?"操作成功":"操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
            

        }
        //判断文本框不为空
        private bool IsCheck()
        {
            if (string.IsNullOrEmpty(txtIsDeflaut.Text))
            {
                MessageBox.Show("默认编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRMinMoney.Text))
            {
                MessageBox.Show("最低消费不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRName.Text))
            {
                MessageBox.Show("房间名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRPerNum.Text))
            {
                MessageBox.Show("人数不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRType.Text))
            {
                MessageBox.Show("房间类型不能为空");
                return false;
            }
            return true;
        }


    }
}
