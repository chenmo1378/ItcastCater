using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
   public class UserInfo
    {
        //UserId UserName LoginUserName Pwd LastLoginTime LastLoginIp DelFlag SubTime

        private int _userId;
       /// <summary>
       /// 用户的id
       /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
       private string _userName;
       //用户的名字
       public string UserName
       {
           get { return _userName; }
           set { _userName = value; }
       }
       private string _loginUserName;
       //用户的登录名
       public string LoginUserName
       {
           get { return _loginUserName; }
           set { _loginUserName = value; }
       }
       private string _pwd;
       //登录密码
       public string Pwd
       {
           get { return _pwd; }
           set { _pwd = value; }
       }
       private DateTime? _lastLoginTime;
       //登录时间
       public DateTime? LastLoginTime
       {
           get { return _lastLoginTime; }
           set { _lastLoginTime = value; }
       }
       private string _lastLoginIp;
       //ip
       public string LastLoginIp
       {
           get { return _lastLoginIp; }
           set { _lastLoginIp = value; }
       }
       private int? _delFlag;
       //删除标识
       public int? DelFlag
       {
           get { return _delFlag; }
           set { _delFlag = value; }
       }
       private DateTime _subTime;
       //提交时间
       public DateTime SubTime
       {
           get { return _subTime; }
           set { _subTime = value; }
       }

    }
}
