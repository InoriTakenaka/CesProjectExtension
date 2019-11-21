using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类INSPECTION_DEV_REG_INFO
     ///</summary>
     public class INSPECTION_DEV_REG_INFO
     {
         private int __ID=0;
         private int? __JCXH=null;
         private string __SBLX=string.Empty;
         private string __SBMC=string.Empty;
         private string __SBMCDH=string.Empty;
         private string __SBZZC=string.Empty;
         private string __SBXH=string.Empty;
         private string __SBCCBH=string.Empty;
         private string __SBCCRQ=string.Empty;
         private string __SBRZBH=string.Empty;
         private string __SBRZRQ=string.Empty;
         private string __SBRZYXQZ=string.Empty;
         private string __JLBDBH=string.Empty;
         private string __JLBDRQ=string.Empty;
         private string __JLBDYXQZ=string.Empty;
         private string __BZ=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public INSPECTION_DEV_REG_INFO()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("JCXH",false);
             this.__Changed.Add("SBLX",false);
             this.__Changed.Add("SBMC",false);
             this.__Changed.Add("SBMCDH",false);
             this.__Changed.Add("SBZZC",false);
             this.__Changed.Add("SBXH",false);
             this.__Changed.Add("SBCCBH",false);
             this.__Changed.Add("SBCCRQ",false);
             this.__Changed.Add("SBRZBH",false);
             this.__Changed.Add("SBRZRQ",false);
             this.__Changed.Add("SBRZYXQZ",false);
             this.__Changed.Add("JLBDBH",false);
             this.__Changed.Add("JLBDRQ",false);
             this.__Changed.Add("JLBDYXQZ",false);
             this.__Changed.Add("BZ",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__JCXH =null;
             this.__SBLX =string.Empty;
             this.__SBMC =string.Empty;
             this.__SBMCDH =string.Empty;
             this.__SBZZC =string.Empty;
             this.__SBXH =string.Empty;
             this.__SBCCBH =string.Empty;
             this.__SBCCRQ =string.Empty;
             this.__SBRZBH =string.Empty;
             this.__SBRZRQ =string.Empty;
             this.__SBRZYXQZ =string.Empty;
             this.__JLBDBH =string.Empty;
             this.__JLBDRQ =string.Empty;
             this.__JLBDYXQZ =string.Empty;
             this.__BZ =string.Empty;
             this.__Changed["ID"] = false;
             this.__Changed["JCXH"] = false;
             this.__Changed["SBLX"] = false;
             this.__Changed["SBMC"] = false;
             this.__Changed["SBMCDH"] = false;
             this.__Changed["SBZZC"] = false;
             this.__Changed["SBXH"] = false;
             this.__Changed["SBCCBH"] = false;
             this.__Changed["SBCCRQ"] = false;
             this.__Changed["SBRZBH"] = false;
             this.__Changed["SBRZRQ"] = false;
             this.__Changed["SBRZYXQZ"] = false;
             this.__Changed["JLBDBH"] = false;
             this.__Changed["JLBDRQ"] = false;
             this.__Changed["JLBDYXQZ"] = false;
             this.__Changed["BZ"] = false;
         }

         /// <summary>
         /// 获取类中成员的改变状态
         /// </summary>
         public bool Changed(string strKey)
         {
             return __Changed[strKey];
         }

         /// <summary>
         ///设置或获取类中的[ID]的数据
         /// </summary>
         public int ID
         {
              set{ __ID = value; __Changed["ID"] = true;}
              get{return __ID;}
         }
         /// <summary>
         ///设置或获取类中的[JCXH]的数据
         /// </summary>
         public int? JCXH
         {
              set{ __JCXH = value; __Changed["JCXH"] = true;}
              get{return __JCXH;}
         }
         /// <summary>
         ///设置或获取类中的[SBLX]的数据
         /// </summary>
         public string SBLX
         {
              set{ __SBLX = value.Replace("'","’"); __Changed["SBLX"] = true;}
              get{return __SBLX;}
         }
         /// <summary>
         ///设置或获取类中的[SBMC]的数据
         /// </summary>
         public string SBMC
         {
              set{ __SBMC = value.Replace("'","’"); __Changed["SBMC"] = true;}
              get{return __SBMC;}
         }
         /// <summary>
         ///设置或获取类中的[SBMCDH]的数据
         /// </summary>
         public string SBMCDH
         {
              set{ __SBMCDH = value.Replace("'","’"); __Changed["SBMCDH"] = true;}
              get{return __SBMCDH;}
         }
         /// <summary>
         ///设置或获取类中的[SBZZC]的数据
         /// </summary>
         public string SBZZC
         {
              set{ __SBZZC = value.Replace("'","’"); __Changed["SBZZC"] = true;}
              get{return __SBZZC;}
         }
         /// <summary>
         ///设置或获取类中的[SBXH]的数据
         /// </summary>
         public string SBXH
         {
              set{ __SBXH = value.Replace("'","’"); __Changed["SBXH"] = true;}
              get{return __SBXH;}
         }
         /// <summary>
         ///设置或获取类中的[SBCCBH]的数据
         /// </summary>
         public string SBCCBH
         {
              set{ __SBCCBH = value.Replace("'","’"); __Changed["SBCCBH"] = true;}
              get{return __SBCCBH;}
         }
         /// <summary>
         ///设置或获取类中的[SBCCRQ]的数据
         /// </summary>
         public string SBCCRQ
         {
              set{ __SBCCRQ = value.Replace("'","’"); __Changed["SBCCRQ"] = true;}
              get{return __SBCCRQ;}
         }
         /// <summary>
         ///设置或获取类中的[SBRZBH]的数据
         /// </summary>
         public string SBRZBH
         {
              set{ __SBRZBH = value.Replace("'","’"); __Changed["SBRZBH"] = true;}
              get{return __SBRZBH;}
         }
         /// <summary>
         ///设置或获取类中的[SBRZRQ]的数据
         /// </summary>
         public string SBRZRQ
         {
              set{ __SBRZRQ = value.Replace("'","’"); __Changed["SBRZRQ"] = true;}
              get{return __SBRZRQ;}
         }
         /// <summary>
         ///设置或获取类中的[SBRZYXQZ]的数据
         /// </summary>
         public string SBRZYXQZ
         {
              set{ __SBRZYXQZ = value.Replace("'","’"); __Changed["SBRZYXQZ"] = true;}
              get{return __SBRZYXQZ;}
         }
         /// <summary>
         ///设置或获取类中的[JLBDBH]的数据
         /// </summary>
         public string JLBDBH
         {
              set{ __JLBDBH = value.Replace("'","’"); __Changed["JLBDBH"] = true;}
              get{return __JLBDBH;}
         }
         /// <summary>
         ///设置或获取类中的[JLBDRQ]的数据
         /// </summary>
         public string JLBDRQ
         {
              set{ __JLBDRQ = value.Replace("'","’"); __Changed["JLBDRQ"] = true;}
              get{return __JLBDRQ;}
         }
         /// <summary>
         ///设置或获取类中的[JLBDYXQZ]的数据
         /// </summary>
         public string JLBDYXQZ
         {
              set{ __JLBDYXQZ = value.Replace("'","’"); __Changed["JLBDYXQZ"] = true;}
              get{return __JLBDYXQZ;}
         }
         /// <summary>
         ///设置或获取类中的[BZ]的数据
         /// </summary>
         public string BZ
         {
              set{ __BZ = value.Replace("'","’"); __Changed["BZ"] = true;}
              get{return __BZ;}
         }
    }
}
