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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //关闭当前窗体
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //获取帐号和密码

            string name = txtLoginName.Text.Trim();
            string pwd = txtLoginPwd.Text.Trim();
            //判断帐号和密码不能为空
           pwd= Common.GetStringMD5(pwd);
            if (CheckText(name,pwd))
            {
                //帐号和密码都不为空
                UserInfoBLL bll = new UserInfoBLL();
                string msg;
                //登录是否成功
                if (bll.LoginByLoginName(name,pwd,out msg))
                {
                    msgDiv1.MsgDivShow(msg, 1,Bind);
                }
                else//登录失败
                {
                    msgDiv1.MsgDivShow(msg,1);
                }

            }
           
            
            //调用bll中的登录的方法

        
        }
       //验证帐号和密码不能为空
        private bool CheckText(string name, string pwd)
        {
           
            if (string.IsNullOrEmpty(name))
            {
                msgDiv1.MsgDivShow("帐号不能为空",1);
                return false;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                msgDiv1.MsgDivShow("密码不能为空", 1);
                return false;
            }
            return true;
        }
        private void Bind()
        {
            //设置当前窗口的一个状态
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
