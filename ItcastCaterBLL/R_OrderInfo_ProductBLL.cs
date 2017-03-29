using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
   public class R_OrderInfo_ProductBLL
    {
       R_OrderInfo_ProductDAL dal = new R_OrderInfo_ProductDAL();

        /// <summary>
       /// 删除当前选中的菜
       /// </summary>
       /// <param name="ROrderProId">中间表id</param>
       /// <returns></returns>
       public bool DeleteROrderInfoProduct(int ROrderProId)
       {
           return dal.DeleteROrderInfoProduct(ROrderProId)>0?true:false;
       }
         /// <summary>
        /// 查消费的数量还有总价格
       /// </summary>
       /// <param name="orderId">订单的id</param>
       /// <returns>总数量和总价格</returns>
       public R_OrderInfo_Product GetCountAndMoney(int orderId)
       {
           return dal.GetCountAndMoney(orderId);
       }
         /// <summary>
       /// 查询该餐桌点的所有的菜
       /// </summary>
       /// <param name="orderId">订单的id</param>
       /// <returns>菜对象集合</returns>
       public List<R_OrderInfo_Product> GetProduct(int orderId)
       {
          return dal.GetProduct(orderId);
       }
         /// <summary>
       /// 增加消费
       /// </summary>
       /// <param name="rop">消费表的对象</param>
       /// <returns>是否添加成功</returns>
       public bool AddOrderProduct(R_OrderInfo_Product rop)
       {
           return dal.AddOrderProduct(rop)>0?true:false;
       }
    }
}
