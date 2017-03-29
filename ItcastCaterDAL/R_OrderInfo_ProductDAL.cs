using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using System.Data;
using System.Data.SQLite;
namespace ItcastCater.DAL
{
   public class R_OrderInfo_ProductDAL
    {

       /// <summary>
       /// 删除当前选中的菜
       /// </summary>
       /// <param name="ROrderProId">中间表id</param>
       /// <returns></returns>
       public int DeleteROrderInfoProduct(int ROrderProId)
       {
string sql = "update R_OrderInfo_Product set DelFlag=1 where ROrderProId=@ROrderProId";
return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@ROrderProId", ROrderProId));
       }

       //
       /// <summary>
        /// 查消费的数量还有总价格
       /// </summary>
       /// <param name="orderId">订单的id</param>
       /// <returns>总数量和总价格</returns>
       public R_OrderInfo_Product GetCountAndMoney(int orderId)
       {
           string sql = "select count(*),sum(UnitCount*ProPrice) from R_OrderInfo_Product inner join ProductInfo on ProductInfo.ProId=R_OrderInfo_Product.ProId where R_OrderInfo_Product.DelFlag=0 and OrderId=@OrderId";
           SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@OrderId",orderId));
           R_OrderInfo_Product rop = null;
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   rop = new R_OrderInfo_Product();//这是个大坑
                   rop.CT = reader.GetInt32(0);
                   rop.MONEY = reader.GetDecimal(1);
               }
           }
           return rop;
       }


       /// <summary>
       /// 查询该餐桌点的所有的菜
       /// </summary>
       /// <param name="orderId">订单的id</param>
       /// <returns>菜对象集合</returns>
       public List<R_OrderInfo_Product> GetProduct(int orderId)
       {
           string sql = "select ROrderProId,ProName,ProPrice,UnitCount,ProUnit,CatName,R_OrderInfo_Product.SubTime from  R_OrderInfo_Product inner join ProductInfo on ProductInfo.ProId=R_OrderInfo_Product.ProId inner join CategoryInfo on ProductInfo.CatId=CategoryInfo.CatId where R_OrderInfo_Product.DelFlag=0 and OrderId=@OrderId";
           List<R_OrderInfo_Product> list = new List<R_OrderInfo_Product>();
          
          SQLiteDataReader reader= SqliteHelper.ExecuteReader(sql, new SQLiteParameter("@OrderId",orderId));
          if (reader.HasRows)
          {
              while (reader.Read())
              {
                  R_OrderInfo_Product rop = new R_OrderInfo_Product();
                  rop.ROrderProId = Convert.ToInt32(reader["ROrderProId"]);
                  rop.CatName = reader["CatName"].ToString();
                  rop.ProName = reader["ProName"].ToString();
                  rop.ProPrice = Convert.ToDecimal(reader["ProPrice"]);
                  rop.UnitCount = Convert.ToDecimal(reader["UnitCount"]);
                  rop.ProUnit = reader["ProUnit"].ToString();
                  rop.SubTime = Convert.ToDateTime(reader["SubTime"]);
                  rop.ProMoney = rop.ProPrice * rop.UnitCount;//总价
                  list.Add(rop);
                  //rop.MONEY=
              }
          }
          return list;//



       }
       /// <summary>
       /// 增加消费
       /// </summary>
       /// <param name="rop">消费表的对象</param>
       /// <returns>是否添加成功</returns>
       public int AddOrderProduct(R_OrderInfo_Product rop)
       {
           string sql = "insert into R_OrderInfo_Product(OrderId,ProId,DelFlag,SubTime,State,UnitCount) values(@OrderId,@ProId,@DelFlag,@SubTime,@State,@UnitCount)";
           SQLiteParameter[] param ={
                            new SQLiteParameter("@OrderId",rop.OrderId),      
                             new SQLiteParameter("@ProId",rop.ProId),    
                              new SQLiteParameter("@DelFlag",rop.DelFlag),    
                               new SQLiteParameter("@SubTime",rop.SubTime),    
                                new SQLiteParameter("@State",rop.State),    
                                 new SQLiteParameter("@UnitCount",rop.UnitCount) 
                                  };
           return SqliteHelper.ExecuteNonQuery(sql,param);
       }
    }
}
