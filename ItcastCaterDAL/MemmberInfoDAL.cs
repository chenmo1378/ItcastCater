using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class MemmberInfoDAL
    {
        /// <summary>
        /// 根据会员id更新会员的余额
        /// </summary>
        /// <param name="memId">会员的id</param>
        /// <param name="money">会员的余额</param>
        /// <returns></returns>
        public int UpdateMoney(int memId,decimal money)
        {
            string sql = "update MemmberInfo set MemMoney=@MemMoney where DelFlag=0 and MemmberId=@MemmberId";
            SQLiteParameter[] param = { 
              new SQLiteParameter("@MemMoney",money),                        
                           new SQLiteParameter("@MemmberId",memId),              
                                      };
           return SqliteHelper.ExecuteNonQuery(sql,param);
        }

        /// <summary>
        /// 根据会员id获取会员的级别还有金额还有折扣
        /// </summary>
        /// <param name="memId">会员id</param>
        /// <returns></returns>
        public MemmberInfo GetMemMoneyAndDisCountAndTypeNameByMemId(int memId)
        {
            string sql = "select MemTpName,MemDiscount,MemMoney from MemmberInfo inner join MemmberType on MemmberType.MemType=MemmberInfo.MemType where MemmberInfo.DelFlag=0 and MemmberId=@MemmberId";
           SQLiteDataReader reader= SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@MemmberId",memId));
           MemmberInfo mem = null;
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   mem = new MemmberInfo();
                   mem.MemTpName = reader["MemTpName"].ToString();
                   mem.MemMoney = Convert.ToDecimal(reader["MemMoney"]);
                   mem.MemDiscount = Convert.ToDecimal(reader["MemDiscount"]);
               }
           }
           return mem;
        }

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public int AddMemmbeer(MemmberInfo mem)
        {
            string sql = "insert into MemmberInfo(MemName,MemMobilePhone,MemType,MemNum,MemGender,MemDiscount,MemMoney,DelFlag,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty) values(@MemName,@MemMobilePhone,@MemType,@MemNum,@MemGender,@MemDiscount,@MemMoney,@DelFlag,@SubTime,@MemIntegral,@MemEndServerTime,@MemBirthdaty)";
            return AddAndUpdate(sql,mem,1);
        }
        /// <summary>
        /// 修改会员
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public int UpdateMemmber(MemmberInfo mem)
        {
            string sql = "update MemmberInfo set MemName=@MemName,MemMobilePhone=@MemMobilePhone,MemType=@MemType,MemNum=@MemNum,MemGender=@MemGender,MemDiscount=@MemDiscount,MemMoney=@MemMoney,MemIntegral=@MemIntegral,MemEndServerTime=@MemEndServerTime,MemBirthdaty=@MemBirthdaty where MemmberId=@MemmberId";
            return AddAndUpdate(sql,mem,2);
        }
        //temp 1是新增,2是修改
        public int AddAndUpdate(string sql, MemmberInfo mem, int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            SQLiteParameter[] param = { 
new SQLiteParameter("@MemName",mem.MemName),
new SQLiteParameter("@MemMobilePhone",mem.MemMobilePhone),
new SQLiteParameter("@MemType",mem.MemType),
new SQLiteParameter("@MemNum",mem.MemNum),
new SQLiteParameter("@MemGender",mem.MemGender),
new SQLiteParameter("@MemDiscount",mem.MemDiscount),
new SQLiteParameter("@MemMoney",mem.MemMoney),
new SQLiteParameter("@MemIntegral",mem.MemIntegral),
new SQLiteParameter("@MemEndServerTime",mem.MemEndServerTime),
new SQLiteParameter("@MemBirthdaty",mem.MemBirthdaty)               
                                      };
            list.AddRange(param);
            if (temp==1)
            {
                list.Add(new SQLiteParameter("@DelFlag",mem.DelFlag));
                list.Add(new SQLiteParameter("@SubTime",mem.SubTime));
            }
            else if (temp==2)
            {
                list.Add(new SQLiteParameter("@MemmberId",mem.MemmberId));
            }
            return SqliteHelper.ExecuteNonQuery(sql,list.ToArray());
        }
        //根据id查询该会员
        /// <summary>
        /// 根据id查询该会员所有信息
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>会员对象</returns>
        public MemmberInfo GetMemmberByMemmberid(int memmberId)
        {
            string sql = "select * from MemmberInfo where DelFlag=0 and MemmberId=@MemmberId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@MemmberId", memmberId));
            MemmberInfo mem = null;
            if (dt.Rows.Count > 0)
            {
                mem = RowToMemberInfo(dt.Rows[0]);
            }
            return mem;
        }

        //删除会员
        /// <summary>
        /// 根据会员id删除该会员
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>软删除</returns>
        public int DeleteMemmber(int memmberId)
        {
            string sql = "update MemmberInfo set DelFlag=1 where MemmberId=@MemmberId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@MemmberId", memmberId));
        }

        /// <summary>
        /// 查询所有的没有删除的会员
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<MemmberInfo> GetAllMemmberInfoByDelFlag(int delFlag)
        {
            string sql = "select * from MemmberInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));
            List<MemmberInfo> list = new List<MemmberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    MemmberInfo mem = RowToMemberInfo(item);
                    list.Add(mem);
                }
            }
            return list;
        }


        private MemmberInfo RowToMemberInfo(DataRow dr)
        {
            MemmberInfo memmber = new MemmberInfo();
            memmber.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            memmber.MemAddress = dr["MemAddress"].ToString();
            memmber.MemBirthdaty = Convert.ToDateTime(dr["MemBirthdaty"]);
            memmber.MemDiscount = Convert.ToDecimal(dr["MemDiscount"]);
            memmber.MemEndServerTime = Convert.ToDateTime(dr["MemEndServerTime"]);
            memmber.MemGender = dr["MemGender"].ToString();
            memmber.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            memmber.MemmberId = Convert.ToInt32(dr["MemmberId"]);
            memmber.MemMobilePhone = dr["MemMobilePhone"].ToString();
            memmber.MemMoney = Convert.ToDecimal(dr["MemMoney"]);
            memmber.MemName = dr["MemName"].ToString();
            memmber.MemNum = dr["MemNum"].ToString();
            memmber.MemPhone = dr["MemPhone"].ToString();
            memmber.MemType = Convert.ToInt32(dr["MemType"]);
            memmber.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return memmber;

        }

    }
}
