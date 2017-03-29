using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;
namespace ItcastCater.DAL
{
   public class MemmberTypeDAL
    {
       /// <summary>
       /// 查询会员级别
       /// </summary>
       /// <param name="delFlag">删除标识</param>
       /// <returns>级别对象集合</returns>
       public List<MemmberType> GetAllMemmberTypeByDelFlag(int delFlag)
       {
           string sql = "select MemType,MemTpName from MemmberType where DelFlag=@DelFlag";
           SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@DelFlag",delFlag));
           List<MemmberType> list = new List<MemmberType>();
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   MemmberType mt = new MemmberType();
                   mt.MemTpName = reader["MemTpName"].ToString();
                   mt.MemType = Convert.ToInt32(reader["MemType"]);
                   list.Add(mt);
               }
           }
           return list;
       }

      
    }
}
