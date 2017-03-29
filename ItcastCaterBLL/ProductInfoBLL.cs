using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
    public class ProductInfoBLL
    {

        ProductInfoDAL dal = new ProductInfoDAL();

         //模糊查询
        /// <summary>
        /// 根据编号查询数据
        /// </summary>
        /// <param name="proNum">编号</param>
        /// <returns>集合</returns>
        public List<ProductInfo> GetProductByProNum(string proNum)
        {
            return dal.GetProductByProNum(proNum);
        }

          /// <summary>
        /// 根据商品类别的id查询该类别下所有的产品数据
        /// </summary>
        /// <param name="catId">类别id</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatId(int catId)
        {
            return dal.GetProductInfoByCatId(catId);
        }

        /// <summary>
        /// 删除一行产品数据
        /// </summary>
        /// <param name="id">产品的id</param>
        /// <returns></returns>
        public bool DeleteProduct(int id)
        {
            return dal.DeleteProduct(id)>0?true:false;
        }

        //增加和修改
        public bool SaveProduct(ProductInfo pro, int temp)
        {
            int r = -1;
            if (temp==3)
            {
                r = dal.AddProductInfo(pro);
            }
            else if (temp==4)
            {
                r = dal.UpdateProductInfo(pro);
            }
            return r > 0 ? true : false;
        }

        /// <summary>
        /// 根据id获取菜的对象的数据
        /// </summary>
        /// <param name="id">菜的id</param>
        /// <returns></returns>
        public ProductInfo GetProductByProId(int id)
        {
            return dal.GetProductByProId(id);
        }
        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>产品对象集合</returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            return dal.GetAllProductInfoByDelFlag(delFlag);
        }
    }
}
