using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace ItcastCater.DAL
{
    public class SqliteHelper
    {
        //获取连接字符串
        private static readonly string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        /// <summary>
        /// 此方法可以做增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数</param>
        /// <returns>此方法返回的是受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] param)
        {
            using (SQLiteConnection con=new SQLiteConnection(str))
            {
                using (SQLiteCommand cmd=new SQLiteCommand(sql,con))
                {
                    con.Open();
                    if (param!=null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 此方法可以做首行首列,可以查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数</param>
        /// <returns>此方法返回的是首行首列</returns>
        public static object ExecuteScalar(string sql, params SQLiteParameter[] param)
        {
            using (SQLiteConnection con=new SQLiteConnection(str))
            {
                using (SQLiteCommand cmd=new SQLiteCommand(sql,con))
                {
                    con.Open();
                    if (param!=null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 此方法用来查询一行一行的数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数</param>
        /// <returns>返回的是SQLiteDataReader</returns>
        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] param)
        {
            SQLiteConnection con = new SQLiteConnection(str);
            using (SQLiteCommand cmd=new SQLiteCommand(sql,con))
            {
                if (param!=null)
                {
                    cmd.Parameters.AddRange(param);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 返回的是一个表的数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">sql参数</param>
        /// <returns>返回的是DataTable类型的数据</returns>
        public static DataTable ExecuteTable(string sql, params SQLiteParameter[] param)
        {
            #region 第一种方式代码
            //DataTable dt = new DataTable();
            //using (SQLiteConnection con = new SQLiteConnection(str))
            //{
            //    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            //    {
            //        using (SQLiteDataAdapter sda=new SQLiteDataAdapter(sql,con))
            //        {
            //            sda.Fill(dt);
            //        }
            //    }
            //}
            //return dt; 
            #endregion
            DataTable dt = new DataTable();
            using (SQLiteDataAdapter sda=new SQLiteDataAdapter(sql,str))
            {
                if (param!=null)
                {
                    sda.SelectCommand.Parameters.AddRange(param);
                }
                sda.Fill(dt);
            }
            return dt;
        }

    }
}
