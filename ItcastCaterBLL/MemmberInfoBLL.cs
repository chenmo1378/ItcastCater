using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
    public class MemmberInfoBLL
    {

        MemmberInfoDAL dal = new MemmberInfoDAL();
          /// <summary>
        /// 根据会员id更新会员的余额
        /// </summary>
        /// <param name="memId">会员的id</param>
        /// <param name="money">会员的余额</param>
        /// <returns></returns>
        public bool UpdateMoney(int memId, decimal money)
        {
            return dal.UpdateMoney(memId,money)>0?true:false;
        }
           /// <summary>
        /// 根据会员id获取会员的级别还有金额还有折扣
        /// </summary>
        /// <param name="memId">会员id</param>
        /// <returns></returns>
        public MemmberInfo GetMemMoneyAndDisCountAndTypeNameByMemId(int memId)
        {
            return dal.GetMemMoneyAndDisCountAndTypeNameByMemId(memId);
        }
        /// <summary>
        /// 添加和修改会员
        /// </summary>
        /// <param name="mem">会员对象</param>
        /// <param name="temp">标识</param>
        /// <returns></returns>
        public bool SaveMemmberInfo(MemmberInfo mem,int temp)
        {
            int r = -1;
            if (temp==1)
            {
                r = dal.AddMemmbeer(mem);
            }
            else if (temp==2)
            {
                r = dal.UpdateMemmber(mem);
            }
            return r > 0 ? true : false;
        }
        //根据id查询该会员
        /// <summary>
        /// 根据id查询该会员所有信息
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>会员对象</returns>
        public MemmberInfo GetMemmberByMemmberid(int memmberId)
        {
            return dal.GetMemmberByMemmberid(memmberId);
        }
        //删除会员
        /// <summary>
        /// 根据会员id删除该会员
        /// </summary>
        /// <param name="memmberId">会员id</param>
        /// <returns>软删除</returns>
        public bool DeleteMemmber(int memmberId)
        {
            return dal.DeleteMemmber(memmberId) > 0 ? true : false;
        }
        /// <summary>
        /// 查询所有的没有删除的会员
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<MemmberInfo> GetAllMemmberInfoByDelFlag(int delFlag)
        {
            return dal.GetAllMemmberInfoByDelFlag(delFlag);
        }
    }
}
