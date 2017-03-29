using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater
{
   /// <summary>
   /// 用来做窗体传值的类
   /// </summary>
   public class FrmEventArgs:EventArgs
    {
       /// <summary>
       /// 标识
       /// </summary>
       public int Temp { get; set; }
       /// <summary>
       /// 对象
       /// </summary>
       public object Obj { get; set; }

       public string Name { get; set; }
       public decimal Money { get; set; }

       public int DkIdZ { get; set; }
    }
}
