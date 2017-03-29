using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
   public class MemmberTypeBLL
    {
       MemmberTypeDAL dal=new MemmberTypeDAL();
         /// <summary>
       /// 查询会员级别
       /// </summary>
       /// <param name="delFlag">删除标识</param>
       /// <returns>级别对象集合</returns>
       public List<MemmberType> GetAllMemmberTypeByDelFlag(int delFlag)
       {
           return dal.GetAllMemmberTypeByDelFlag(delFlag);
       }
    }
}
