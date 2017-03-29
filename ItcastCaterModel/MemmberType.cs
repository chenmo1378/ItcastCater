using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
   public class MemmberType
    {
        //MemType,MemTpName ,MemTpDesc,DelFlag, SubBy

        private int _memType;

        public int MemType
        {
            get { return _memType; }
            set { _memType = value; }
        }
       private string _memTpName;

       public string MemTpName
       {
           get { return _memTpName; }
           set { _memTpName = value; }
       }
       private string _memTpDesc;

       public string MemTpDesc
       {
           get { return _memTpDesc; }
           set { _memTpDesc = value; }
       }
       private int _delFlag;

       public int DelFlag
       {
           get { return _delFlag; }
           set { _delFlag = value; }
       }
       private int _subBy;

       public int SubBy
       {
           get { return _subBy; }
           set { _subBy = value; }
       }
    }
}
