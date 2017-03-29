using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class UserInfoDAL
    {

        /// <summary>
        /// 根据登录名 查询数据库
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns>返回的是对象</returns>
        public UserInfo LoginByLoginName(string loginName)
        {
            string sql = "select * from UserInfo where DelFlag=0 and LoginUserName=@loginName";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@loginName", loginName));

            UserInfo user = null;
            if (dt.Rows.Count > 0)//有行
            {
                user = RowToUserInfo(dt.Rows[0]);
            }
            return user;

        }

        //关系转对象
        private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.LastLoginIp = dr["LastLoginIp"].ToString();
            user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.Pwd = dr["Pwd"].ToString();
            user.SubTime = Convert.ToDateTime(dr["SubTime"]);
            user.UserId = Convert.ToInt32(dr["UserId"]);
            user.UserName = dr["UserName"].ToString();
            return user;
        }
    }
}
