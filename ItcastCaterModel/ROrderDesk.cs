using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
   public class ROrderDesk
    {
        private int _rId;

        public int RId
        {
            get { return _rId; }
            set { _rId = value; }
        }
       private int _orderId;

       public int OrderId
       {
           get { return _orderId; }
           set { _orderId = value; }
       }
       private int _deskId;

       public int DeskId
       {
           get { return _deskId; }
           set { _deskId = value; }
       }
    }
}
