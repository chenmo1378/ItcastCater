using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
    public class OrderInfoBLL
    {
        OrderInfoDAL dal = new OrderInfoDAL();
          /// <summary>
        /// 订单结束后的更新
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool UpdateOrderInfoMoney(OrderInfo order)
        {
            return dal.UpdateOrderInfoMoney(order)>0?true:false;
        }
          /// <summary>
        /// 获取订单消费的总金额
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <returns></returns>
        public decimal GetOrderMoney(int orderId)
        {
            return dal.GetOrderMoney(orderId);
        }
          /// <summary>
        /// 更新订单表中的金额
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <returns></returns>
        public bool UpdateOrderMoney(int orderId, decimal money)
        {
            return dal.UpdateOrderMoney(orderId,money)>0?true:false;
        }
         /// <summary>
        /// 根据餐桌的id查询正在使用的订单的id
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public int GetOrderIdByDeskId(int deskId)
        {
            return dal.GetOrderIdByDeskId(deskId);
        }
          /// <summary>
        /// 添加一个新的订单并返回该订单的id
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>订单id</returns>
        public int GetOrderIdInsertOrderInfo(OrderInfo order)
        {
            return dal.GetOrderIdInsertOrderInfo(order);
        }
    }
}
