using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class OrderInfoDAL
    {
        /// <summary>
        /// 订单结束后的更新
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderInfoMoney(OrderInfo order)
        {
            string sql = "update OrderInfo set OrderState=2,OrderMemId=@OrderMemId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@DisCount where DelFlag=0 and OrderId=@OrderId";
            SQLiteParameter[] param = { 
                              new SQLiteParameter("@OrderMemId",order.OrderMemId),          
                    new SQLiteParameter("@EndTime",order.EndTime),  
                     new SQLiteParameter("@OrderMoney",order.OrderMoney), 
                      new SQLiteParameter("@DisCount",order.DisCount), 
                       new SQLiteParameter("@OrderId",order.OrderId)
                                      };

           return SqliteHelper.ExecuteNonQuery(sql,param);
        }

        /// <summary>
        /// 获取订单消费的总金额
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <returns></returns>
        public decimal GetOrderMoney(int orderId)
        {
            string sql = "select OrderMoney from OrderInfo where DelFlag=0 and OrderId=@OrderId";

          object obj=  SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@OrderId", orderId));
       
       
        return Convert.ToDecimal(obj);//Convert.ToDecimal();
        }


        /// <summary>
        /// 更新订单表中的金额
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <returns></returns>
        public int UpdateOrderMoney(int orderId,decimal money)
        {
            string sql = "update OrderInfo set OrderMoney=@OrderMoney,BeginTime=SubTime where DelFlag=0 and OrderId=@OrderId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@OrderId", orderId), new SQLiteParameter("@OrderMoney", money));
        }


        /// <summary>
        /// 根据餐桌的id查询正在使用的订单的id
        /// </summary> 
        /// <param name="deskId"></param>
        /// <returns></returns>
        public int GetOrderIdByDeskId(int deskId)
        {
            string sql = "select OrderInfo.OrderId from R_Order_Desk inner join OrderInfo on OrderInfo.OrderId=R_Order_Desk.OrderId where OrderState=1 and DeskId=@DeskId";
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql,new SQLiteParameter("@DeskId",deskId)));
        }


        /// <summary>
        /// 添加一个新的订单并返回该订单的id
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>订单id</returns>
        public int GetOrderIdInsertOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo(Remark,OrderState,DelFlag,SubBy,SubTime)values(@Remark,@OrderState,@DelFlag,@SubBy,@SubTime);select last_insert_rowid();";//获取插入的id

            SQLiteParameter[] param ={
                     new SQLiteParameter("@Remark",order.Remark),
                         new SQLiteParameter("@OrderState",order.OrderState),
                             new SQLiteParameter("@DelFlag",order.DelFlag),
                                 new SQLiteParameter("@SubBy",order.SubBy),
                                     new SQLiteParameter("@SubTime",order.SubTime)
                                   };

            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, param));
        }
    }
}
