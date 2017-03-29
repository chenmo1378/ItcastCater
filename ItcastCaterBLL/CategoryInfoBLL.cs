using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
    public class CategoryInfoBLL
    {
        CategoryInfoDAL dal = new CategoryInfoDAL();
        /// <summary>
        /// 新增和修改
        /// </summary>
        /// <param name="cat">类别对象</param>
        /// <param name="temp">标识1---新增,2是修改</param>
        /// <returns></returns>
        public bool SaveCategory(CategoryInfo cat, int temp)
        {
            int r = -1;
            if (temp==1)
            {
                r = dal.AddCategoryInfo(cat);
            }
            else if (temp==2)
            {
                r = dal.UpdateCategoryInfo(cat);
            }
            return r > 0 ? true : false;
 
        }


         /// <summary>
       /// 根据商品类别id查询商品数据
       /// </summary>
       /// <param name="catId">商品id</param>
       /// <returns>商品类别对象</returns>
        public CategoryInfo GetCategoryInfoByCatId(int catId)
        {
            return dal.GetCategoryInfoByCatId(catId);
        }
          /// <summary>
       /// 查询所有的商品类别
       /// </summary>
       /// <param name="delFlag">删除标识</param>
       /// <returns>商品类别对象集合</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return dal.GetAllCategoryInfoByDelFlag(delFlag);
        }
    }
}
