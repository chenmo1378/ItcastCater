using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
    public class RoomInfoBLL
    {
        RoomInfoDAL dal = new RoomInfoDAL();

         /// <summary>
        /// 删除该房间
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool DeleteRoomById(int roomId)
        {
            return dal.DeleteRoomById(roomId)>0?true:false;
        }

        /// <summary>
        /// 获取所有房间的名字和id
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<RoomInfo> GetRoomNameAndId(int delFlag)
        {
            return dal.GetRoomNameAndId(delFlag);
        }

        /// <summary>
        /// 根据id查询房间信息
        /// </summary>
        /// <param name="id">房间id</param>
        /// <returns>房间对象</returns>
        public RoomInfo GetRoomInfoByRoomId(int id)
        {
            return dal.GetRoomInfoByRoomId(id);
        }

        /// <summary>
        /// 新增和修改
        /// </summary>
        /// <param name="room">房间对象</param>
        /// <param name="temp">1为新增,2为修改</param>
        /// <returns>是否成功</returns>
        public bool SaveRoom(RoomInfo room, int temp)//
        {
            int r = -1;
            if (temp == 1)
            {
                r = dal.AddRoomInfo(room);
            }
            else if (temp == 2)
            {
                r = dal.UpdateRoomInfo(room);
            }
            return r > 0 ? true : false;

        }

        /// <summary>
        /// 增加一个房间
        /// </summary>
        /// <param name="room">房间对象</param>
        /// <returns>受影响的行数</returns>
        public bool AddRoomInfo(RoomInfo room)
        {
            return dal.AddRoomInfo(room) > 0 ? true : false;
        }

        /// <summary>
        /// 获取没有被删除的所有房间
        /// </summary>
        /// <param name="delFlag">删除标识0--未删除,1--删除</param>
        /// <returns>每个房间对象-集合</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return dal.GetAllRoomInfoByDelFlag(delFlag);
        }
    }
}
