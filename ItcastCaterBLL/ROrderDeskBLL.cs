using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.DAL;
using ItcastCater.Model;
namespace ItcastCater.BLL
{
   public class ROrderDeskBLL
    {
       ROrderDeskDAL dal = new ROrderDeskDAL();
        /// <summary>
       /// 添加一个中间表的数据
       /// </summary>
       /// <param name="rod"></param>
       /// <returns></returns>
       public bool AddROrderDesk(ROrderDesk rod)
       {
           return dal.AddROrderDesk(rod)>0?true:false;
       }
    }
}
