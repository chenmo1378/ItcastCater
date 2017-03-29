using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.DAL
{
    public class CategoryInfoDAL
    {
        //新增
        public int AddCategoryInfo(CategoryInfo cat)
        {
            string sql = "insert into CategoryInfo ( CatName, CatNum , Remark,DelFlag,SubTime,SubBy ) values(@CatName, @CatNum , @Remark,@DelFlag,@SubTime,@SubBy )";
            return AddAndUpdate(cat,sql,1);
        }
        //修改
        public int UpdateCategoryInfo(CategoryInfo cat)
        {
            string sql = "update CategoryInfo set CatName=@CatName, CatNum=@CatNum, Remark=@Remark where CatId=@CatId ";
            return AddAndUpdate(cat, sql, 2);
        }
        public int AddAndUpdate(CategoryInfo cat, string sql, int temp)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();

            SQLiteParameter[] param = {                    
                      new SQLiteParameter("@CatName",cat.CatName),
                        new SQLiteParameter("@CatNum",cat.CatNum),
                          new SQLiteParameter("@Remark",cat.Remark)
                                     };

            list.AddRange(param);
            if (temp == 1)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", cat.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", cat.SubTime));
                list.Add(new SQLiteParameter("@SubBy", cat.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SQLiteParameter("@CatId",cat.CatId));
            }
            return SqliteHelper.ExecuteNonQuery(sql,list.ToArray());
        }

        /// <summary>
        /// 根据商品类别id查询商品数据
        /// </summary>
        /// <param name="catId">商品id</param>
        /// <returns>商品类别对象</returns>
        public CategoryInfo GetCategoryInfoByCatId(int catId)
        {
            string sql = "select * from CategoryInfo where DelFlag=0 and CatId=@CatId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@CatId", catId));
            CategoryInfo cat = null;
            if (dt.Rows.Count > 0)
            {
                cat = RowToCategoryInfo(dt.Rows[0]);
            }
            return cat;
        }
        /// <summary>
        /// 查询所有的商品类别
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>商品类别对象集合</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            string sql = " select * from CategoryInfo where DelFlag=@DelFlag";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));
            List<CategoryInfo> list = new List<CategoryInfo>();
            CategoryInfo ct = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ct = RowToCategoryInfo(item);
                    list.Add(ct);
                }
            }
            return list;
        }

        private CategoryInfo RowToCategoryInfo(DataRow item)
        {
            CategoryInfo ct = new CategoryInfo();
            ct.CatId = Convert.ToInt32(item["CatId"]);
            ct.CatName = item["CatName"].ToString();
            ct.CatNum = item["CatNum"].ToString();
            ct.Remark = item["Remark"].ToString();
            ct.SubBy = Convert.ToInt32(item["SubBy"]);
            ct.SubTime = Convert.ToDateTime(item["SubTime"]);
            return ct;
        }
    }
}
