using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;

namespace ItcastCater.BLL
{
   public class DeskInfoBLL
    {
       DeskInfoDAL dal = new DeskInfoDAL();
          /// <summary>
        /// 更新餐桌的状态
        /// </summary>
        /// <param name="id">餐桌的id</param>
        /// <param name="temp">餐桌的状态标识</param>
        /// <returns></returns>
       public bool UpdateDeskStateByDeskId(int id, int temp)
       {
           return dal.UpdateDeskStateByDeskId(id,temp)>0?true:false;
       }
         /// <summary>
        /// 根据房间的id获取该房间下的所有的餐桌
        /// </summary>
        /// <param name="roomId">房间的id</param>
        /// <returns>餐桌集合</returns>
       public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
       {
           return dal.GetAllDeskInfoByRoomId(roomId);
       }
         /// <summary>
        /// 删除该房间下的所有餐桌
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
       public bool DeleteDeskInfo(int RoomId)
       {
           return dal.DeleteDeskInfo(RoomId)>0?true:false;
       }
         
       /// <summary>
       /// //根据房间的id获取正在使用的餐桌
       /// </summary>
       /// <param name="roomId"></param>
       /// <returns></returns>
       public object GetDeskState(int roomId)
       {
           return dal.GetDeskState(roomId);
       }
          //删除
       public bool DeleteDesk(int id)
       {
           return dal.DeleteDeskInfo(id)>0?true:false;
       }
       
        /// <summary>
        /// 根据餐桌id查询该餐桌信息
        /// </summary>
        /// <param name="id">餐桌id</param>
        /// <returns></returns>
       public DeskInfo GetDeskById(int id)
       {
           return dal.GetDeskById(id);
       }

       /// <summary>
       /// 添加和修改
       /// </summary>
       /// <param name="dk">餐桌对象</param>
       /// <param name="temp">temp=3表示增加,4表示修改</param>
       /// <returns></returns>
       public bool SaveDeskinfo(DeskInfo dk,int temp)
       {
           int r = -1;
           if (temp==3)
           {
               r = dal.AddDeskInfo(dk);
           }
           else if (temp==4)
           {
               r = dal.UpdateDeskInfo(dk);
           }
           return r > 0 ? true : false;
       }

        /// <summary>
        /// 获取所有没有被删除的餐桌
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
       public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
       {
           return dal.GetAllDeskInfoByDelFlag(delFlag);
       }
    }
}
