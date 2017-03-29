using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.International.Converters.PinYinConverter;

namespace ItcastCater
{
   public class Common
    {
       public static string GetStringMD5(string pwd)
       {
           string s = "";
           byte[] buffer = System.Text.Encoding.UTF8.GetBytes(pwd);
           //创建一个md5加密对象
           MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
           byte[] cryMd5 = md5.ComputeHash(buffer);

           for (int i = 0; i < cryMd5.Length; i++)
           {
               s += cryMd5[i].ToString("x2");
           }
           return s;
       }
       public static string GetStringPinYin(string str)
       {
           //这个字符串中的字符是不是汉字
           string s = "";
           foreach (char item in str)
           {
               //判断这个字符是不是汉字
               if (ChineseChar.IsValidChar(item))
               {
                   ChineseChar cc = new ChineseChar(item);
                   //去掉拼音后面的声调(数字)
                   s += cc.Pinyins[0].TrimEnd('1', '2', '3', '4', '5').ToString() + " ";
               }
               else
               {
                   s += item + " ";
               }
           }
           return s;
       }
    }
}
