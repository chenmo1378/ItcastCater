using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;


namespace ItcastCater.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();

        //方法判断用户登录是否成功

        /// <summary>
        /// 判断登录是否成功
        /// </summary>
        /// <param name="loginName">帐号</param>
        /// <param name="pwd">密码</param>
        /// <param name="msg">消息</param>
        /// <returns>返回登录成功还是失败,bool类型</returns>
        public bool LoginByLoginName(string loginName, string pwd, out string msg)
        {
            UserInfo user = dal.LoginByLoginName(loginName);
            bool flag = false;
            if (user != null)
            {
                //判断密码是否正确
                if (user.Pwd == pwd)
                {
                    //登录成功
                    msg = "登录成功";
                    flag = true;
                }
                else
                {
                    //登录失败
                    msg = "密码错误";
                }
            }
            else
            {
                //帐号不存在
                msg = "帐号不存在";
            }
            return flag;
        }
    }
}
