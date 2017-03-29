using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class ProductInfoDAL
    {

        //模糊查询
        /// <summary>
        /// 根据编号查询数据
        /// </summary>
        /// <param name="proNum">编号</param>
        /// <returns>集合</returns>
        public List<ProductInfo> GetProductByProNum(string proNum)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProNum like @proNum";

            SQLiteParameter param = new SQLiteParameter("@proNum", "%" + proNum + "%");
            DataTable dt = SqliteHelper.ExecuteTable(sql, param);
            List<ProductInfo> list = new List<ProductInfo>();
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    pro = RowToProductInfo(item);
                    list.Add(pro);
                }
            }
            return list;
        }


        /// <summary>
        /// 根据商品类别的id查询该类别下所有的产品数据
        /// </summary>
        /// <param name="catId">类别id</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and CatId=@CatId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@CatId", catId));
            List<ProductInfo> list = new List<ProductInfo>();
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    pro = RowToProductInfo(item);
                    list.Add(pro);
                }
            }
            return list;
        }


        //删除数据
        public int DeleteProduct(int id)
        {
            string sql = "update ProductInfo set DelFlag=1 where ProId=@ProId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@ProId", id));
        }


        //新增
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo(CatId,ProName, ProCost,ProSpell, ProPrice, ProUnit, Remark,  DelFlag, SubTime, ProStock,ProNum, SubBy) values(@CatId,@ProName, @ProCost,@ProSpell, @ProPrice,@ProUnit, @Remark,@DelFlag,@SubTime, @ProStock,@ProNum, @SubBy)";

            return AddAndUpdate(pro, sql, 3);
        }
        //修改
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CatId=@CatId,ProName=@ProName, ProCost=@ProCost,ProSpell=@ProSpell, ProPrice=@ProPrice, ProUnit=@ProUnit, Remark=@Remark,  ProStock=@ProStock,ProNum=@ProNum where ProId=@ProId";
            return AddAndUpdate(pro, sql, 4);
        }
        private int AddAndUpdate(ProductInfo pro, string sql, int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            SQLiteParameter[] param = { 
               new SQLiteParameter("@CatId",pro.CatId),
                      new SQLiteParameter("@ProName",pro.ProName),
                       new SQLiteParameter("@ProCost",pro.ProCost),
                        new SQLiteParameter("@ProSpell",pro.ProSpell),
                       new SQLiteParameter("@ProPrice",pro.ProPrice),
                         new SQLiteParameter("@ProUnit",pro.ProUnit),
                           new SQLiteParameter("@Remark",pro.Remark),
                             new SQLiteParameter("@ProStock",pro.ProStock),
                               new SQLiteParameter("@ProNum",pro.ProNum)

                                      };
            list.AddRange(param);
            if (temp == 3)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", pro.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", pro.SubTime));
                list.Add(new SQLiteParameter("@SubBy", pro.SubBy));

            }
            else if (temp == 4)//修改
            {
                list.Add(new SQLiteParameter("@ProId", pro.ProId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据id获取菜的对象的数据
        /// </summary>
        /// <param name="id">菜的id</param>
        /// <returns></returns>
        public ProductInfo GetProductByProId(int id)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProId=@ProId";
            ProductInfo pro = null;
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProId", id));
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }


        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>产品对象集合</returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            string sql = "select * from ProductInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));
            List<ProductInfo> list = new List<ProductInfo>();
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    pro = RowToProductInfo(item);
                    list.Add(pro);
                }
            }
            return list;
        }

        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CatId = Convert.ToInt32(dr["CatId"]);
            pro.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pro.ProId = Convert.ToInt32(dr["ProId"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = dr["ProNum"].ToString();
            pro.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToDecimal(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;
        }
    }
}
