using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using System.Data;
using System.Data.SQLite;

namespace ItcastCater.DAL
{
    public class RoomInfoDAL
    {
        /// <summary>
        /// 删除该房间
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int DeleteRoomById(int roomId)
        {
            string sql = "update RoomInfo set DelFlag=1 where RoomId=@RoomId";
           return SqliteHelper.ExecuteNonQuery(sql,new SQLiteParameter("@RoomId",roomId));
        
        }

        /// <summary>
        /// 获取所有房间的名字和id
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<RoomInfo> GetRoomNameAndId(int delFlag)
        {
            string sql = "select RoomId,RoomName from RoomInfo where DelFlag=@DelFlag";
           SQLiteDataReader reader= SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@DelFlag", delFlag));

           List<RoomInfo> list = new List<RoomInfo>();
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   RoomInfo r = new RoomInfo();
                   r.RoomId = Convert.ToInt32(reader["RoomId"]);
                   r.RoomName = reader["RoomName"].ToString();
                   list.Add(r);
               }
           }
           return list;
        }

        /// <summary>
        /// 根据id查询房间信息
        /// </summary>
        /// <param name="id">房间id</param>
        /// <returns></returns>
        public RoomInfo GetRoomInfoByRoomId(int id)
        {
            string sql = "select RoomName , RoomType ,RoomMinimunConsume ,RoomMaxConsumer, IsDefault  from RoomInfo where DelFlag=0 and RoomId=@RoomId";
           SQLiteDataReader reader= SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@RoomId",id));
           RoomInfo r = new RoomInfo();
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   r.RoomName = reader["RoomName"].ToString();
                   r.RoomType = Convert.ToInt32(reader["RoomType"]);
                   r.RoomMinimunConsume = Convert.ToDecimal(reader["RoomMinimunConsume"]);
                   r.RoomMaxConsumer = Convert.ToDecimal(reader["RoomMaxConsumer"]);
                   r.IsDefault = Convert.ToInt32(reader["IsDefault"]);
               }
           }
           return r;
        }

        /// <summary>
        /// 增加一个房间
        /// </summary>
        /// <param name="room">房间对象</param>
        /// <returns>受影响的行数</returns>
        public int AddRoomInfo(RoomInfo room)
        {
            string sql = "insert into RoomInfo( RoomName,  RoomType, RoomMinimunConsume ,RoomMaxConsumer, IsDefault, DelFlag, SubTime ,SubBy) values( @RoomName,  @RoomType, @RoomMinimunConsume ,@RoomMaxConsumer, @IsDefault, @DelFlag, @SubTime ,@SubBy)";
            return AddAndUpdate(room, 1, sql);
            //return SqliteHelper.ExecuteNonQuery(sql,param);
        }
        public int UpdateRoomInfo(RoomInfo room)
        {
            string sql = "update RoomInfo set RoomName=@RoomName,  RoomType=@RoomType, RoomMinimunConsume=@RoomMinimunConsume ,RoomMaxConsumer=@RoomMaxConsumer, IsDefault=@IsDefault where RoomId=@RoomId";
            return AddAndUpdate(room, 2, sql);
        }
        /// <summary>
        /// 新增和修改的合并
        /// </summary>
        /// <param name="room">房间对象</param>
        /// <param name="temp">1代表的是新增,2代表的是修改</param>
        /// <param name="sql">sql残烛</param>
        /// <returns>受影响的行数</returns>
        private int AddAndUpdate(RoomInfo room, int temp, string sql)
        {
            SQLiteParameter[] param = {      
                       new SQLiteParameter("@RoomName",room.RoomName),
                       new SQLiteParameter("@RoomType",room.RoomType),
                       new SQLiteParameter("@RoomMinimunConsume",room.RoomMinimunConsume),
                       new SQLiteParameter("@RoomMaxConsumer",room.RoomMaxConsumer),
                       new SQLiteParameter("@IsDefault",room.IsDefault)
                                      };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(param);
            if (temp == 1)//代表新增
            {
                list.Add(new SQLiteParameter("@DelFlag", room.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", room.SubTime));
                list.Add(new SQLiteParameter("@SubBy", room.SubBy));
            }
            else //修改
            {
                list.Add(new SQLiteParameter("@RoomId", room.RoomId));

            }

            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 获取没有被删除的所有房间
        /// </summary>
        /// <param name="delFlag">删除标识0--未删除,1--删除</param>
        /// <returns>每个房间对象-集合</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            string sql = "select RoomId ,RoomName , RoomType ,RoomMinimunConsume ,RoomMaxConsumer, IsDefault ,SubTime ,SubBy from RoomInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));
            List<RoomInfo> list = new List<RoomInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //关系转对象
                    RoomInfo room = RowToRoomInfo(dr);
                    list.Add(room);
                }
            }
            return list;

        }
        //关系转对象
        private RoomInfo RowToRoomInfo(DataRow dr)
        {
            RoomInfo r = new RoomInfo();
            r.IsDefault = Convert.ToInt32(dr["IsDefault"]);
            r.RoomId = Convert.ToInt32(dr["RoomId"]);
            r.RoomMaxConsumer = Convert.ToDecimal(dr["RoomMaxConsumer"]);
            r.RoomMinimunConsume = Convert.ToDecimal(dr["RoomMinimunConsume"]);
            r.RoomName = dr["RoomName"].ToString();
            r.RoomType = Convert.ToInt32(dr["RoomType"]);
            r.SubBy = Convert.ToInt32(dr["SubBy"]);
            r.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return r;
        }
    }
}
