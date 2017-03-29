using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class DeskInfoDAL
    {
        /// <summary>
        /// 更新餐桌的状态
        /// </summary>
        /// <param name="id">餐桌的id</param>
        /// <param name="temp">餐桌的状态标识</param>
        /// <returns></returns>
        public int UpdateDeskStateByDeskId(int id,int temp)
        {
            string sql = "update DeskInfo set DeskState =@DeskState where DelFlag=0 and DeskId=@DeskId";
            SQLiteParameter[] param = {
                            new SQLiteParameter("@DeskState",temp),
                            new SQLiteParameter("@DeskId",id)
                                      };
            return SqliteHelper.ExecuteNonQuery(sql,param);
        }


        /// <summary>
        /// 根据房间的id获取该房间下的所有的餐桌
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>餐桌集合</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            string sql = "select DeskId,DeskName,DeskRemark,DeskRegion,DeskState from DeskInfo where DelFlag=0 and RoomId=@RoomId";
           SQLiteDataReader reader= SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@RoomId",roomId));
            List<DeskInfo> list = new List<DeskInfo>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeskInfo dk = new DeskInfo();
                    dk.DeskId = Convert.ToInt32(reader["DeskId"]);
                    dk.DeskName = reader["DeskName"].ToString();
                    dk.DeskRegion = reader["DeskRegion"].ToString();
                    dk.DeskRemark = reader["DeskRemark"].ToString();
                    dk.DeskState = Convert.ToInt32(reader["DeskState"]);
                    list.Add(dk);
                }
            }
            
            return list;
        }

        /// <summary>
        /// 删除该房间下的所有餐桌
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public int DeleteDeskInfo(int RoomId)
        {
            string sql = "update DeskInfo set DelFlag=1 where RoomId=@RoomId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@RoomId",RoomId));
        }

        //根据房间的id获取正在使用的餐桌
        public object GetDeskState(int roomId)
        {
            string sql = "select count(*) from DeskInfo where DelFlag=0 and DeskState=1 and RoomId=@RoomId";
           return SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@RoomId",roomId));
        }


        //删除
        public int UpdateDesk(int id)
        {
            string sql = "update DeskInfo set DelFlag=1 where DeskId=@id";
            return SqliteHelper.ExecuteNonQuery(sql,new SQLiteParameter("@id",id));
        }


        /// <summary>
        /// 根据餐桌id查询该餐桌信息
        /// </summary>
        /// <param name="id">餐桌id</param>
        /// <returns></returns>
        public DeskInfo GetDeskById(int id)
        {
            string sql = "select RoomId,DeskName,DeskRemark,DeskRegion from DeskInfo where DelFlag=0 and DeskId=@DeskId";
            SQLiteDataReader reader= SqliteHelper.ExecuteReader(sql,new SQLiteParameter("@DeskId",id));
            DeskInfo dk = new DeskInfo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                  
                    dk.DeskName = reader["DeskName"].ToString();
                    dk.DeskRegion = reader["DeskRegion"].ToString();
                    dk.DeskRemark = reader["DeskRemark"].ToString();
                    dk.RoomId = Convert.ToInt32(reader["RoomId"]);
                }
            }
            return dk;
        }

        //新增
        public int AddDeskInfo(DeskInfo dk)
        {
            //DeskId RoomId DeskName DeskRemark DeskRegion DeskState DelFlag SubTime SubBy
            string sql = "insert into DeskInfo(RoomId, DeskName, DeskRemark, DeskRegion, DeskState ,DelFlag ,SubTime, SubBy) values(@RoomId, @DeskName, @DeskRemark, @DeskRegion, @DeskState ,@DelFlag ,@SubTime, @SubBy)";
            return AddAndUpdate(dk,sql,1);
        }
        public int UpdateDeskInfo(DeskInfo dk)
        {
            string sql = "update DeskInfo set RoomId=@RoomId, DeskName=@DeskName, DeskRemark=@DeskRemark, DeskRegion=@DeskRegion where DeskId=@DeskId";
            return AddAndUpdate(dk, sql, 2);
        }
        private int AddAndUpdate(DeskInfo dk, string sql, int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            SQLiteParameter[] param = {        
            new SQLiteParameter("@RoomId",dk.RoomId),   
             new SQLiteParameter("@DeskName",dk.DeskName),
              new SQLiteParameter("@DeskRemark",dk.DeskRemark),
               new SQLiteParameter("@DeskRegion",dk.DeskRegion)
                                            
                                      };
            list.AddRange(param);
            if (temp == 1)
            {
                list.Add(new SQLiteParameter("@DeskState", dk.DeskState));
                list.Add(new SQLiteParameter("@DelFlag", dk.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", dk.SubTime));
                list.Add(new SQLiteParameter("@SubBy", dk.SubBy));
            }
            else
            {
                list.Add(new SQLiteParameter("@DeskId", dk.DeskId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        //修改


        /// <summary>
        /// 获取所有没有被删除的餐桌
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            string sql = "select * from DeskInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));

            List<DeskInfo> list = new List<DeskInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DeskInfo desk = RowToDeskInfo(item);
                    list.Add(desk);
                }
            }
            return list;
        }
        //关系转对象
        private DeskInfo RowToDeskInfo(DataRow item)
        {
            DeskInfo desk = new DeskInfo();
            desk.DeskId = Convert.ToInt32(item["DeskId"]);
            desk.DeskName = item["DeskName"].ToString();
            desk.DeskRegion = item["DeskRegion"].ToString();
            desk.DeskRemark = item["DeskRemark"].ToString();
            // desk.DeskState = item[""].ToString();
            //状态
            desk.DeskStateString = Convert.ToInt32(item["DeskState"]) == 0 ? "空闲" : "开桌";

            desk.RoomId = Convert.ToInt32(item["RoomId"]);
            desk.SubBy = Convert.ToInt32(item["SubBy"]);
            desk.SubTime = Convert.ToDateTime(item["SubTime"]);
            return desk;
        }
    }
}
