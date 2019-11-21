using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类RESULT_ZYJS
     ///</summary>
     public class RESULT_ZYJS
     {
         private int __ID=0;
         private string __ZYJSJCCS=string.Empty;
         private string __JCLSH=string.Empty;
         private string __ZYJSJG1=string.Empty;
         private string __ZYJSJG2=string.Empty;
         private string __ZYJSJG3=string.Empty;
         private string __ZYJSJG4=string.Empty;
         private string __ZYJSPJZ=string.Empty;
         private string __ZYJSXZ=string.Empty;
         private string __ZYJS_PD=string.Empty;
         private string __ZYJSYW=string.Empty;
         private string __ZYJSDSZS=string.Empty;
         private string __ZYJSWD=string.Empty;
         private string __ZYJSDQY=string.Empty;
         private string __ZYJSSD=string.Empty;
         private string __KSSJ=string.Empty;
         private string __JSSJ=string.Empty;
         private string __SFLZS=string.Empty;
         private string __PT_ZYJSJG2=string.Empty;
         private string __PT_ZYJSJG3=string.Empty;
         private string __PT_ZYJSJG4=string.Empty;
         private string __PT_ZYJSPJZ=string.Empty;
         private string __PT_ZYJSDSZS=string.Empty;
         private string __PT_ZYJS_PD=string.Empty;
         private string __ZYJSZS1=string.Empty;
         private string __ZYJSZS2=string.Empty;
         private string __ZYJSZS3=string.Empty;
         private string __ZYJSZS4=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public RESULT_ZYJS()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("ZYJSJCCS",false);
             this.__Changed.Add("JCLSH",false);
             this.__Changed.Add("ZYJSJG1",false);
             this.__Changed.Add("ZYJSJG2",false);
             this.__Changed.Add("ZYJSJG3",false);
             this.__Changed.Add("ZYJSJG4",false);
             this.__Changed.Add("ZYJSPJZ",false);
             this.__Changed.Add("ZYJSXZ",false);
             this.__Changed.Add("ZYJS_PD",false);
             this.__Changed.Add("ZYJSYW",false);
             this.__Changed.Add("ZYJSDSZS",false);
             this.__Changed.Add("ZYJSWD",false);
             this.__Changed.Add("ZYJSDQY",false);
             this.__Changed.Add("ZYJSSD",false);
             this.__Changed.Add("KSSJ",false);
             this.__Changed.Add("JSSJ",false);
             this.__Changed.Add("SFLZS",false);
             this.__Changed.Add("PT_ZYJSJG2",false);
             this.__Changed.Add("PT_ZYJSJG3",false);
             this.__Changed.Add("PT_ZYJSJG4",false);
             this.__Changed.Add("PT_ZYJSPJZ",false);
             this.__Changed.Add("PT_ZYJSDSZS",false);
             this.__Changed.Add("PT_ZYJS_PD",false);
             this.__Changed.Add("ZYJSZS1",false);
             this.__Changed.Add("ZYJSZS2",false);
             this.__Changed.Add("ZYJSZS3",false);
             this.__Changed.Add("ZYJSZS4",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__ZYJSJCCS =string.Empty;
             this.__JCLSH =string.Empty;
             this.__ZYJSJG1 =string.Empty;
             this.__ZYJSJG2 =string.Empty;
             this.__ZYJSJG3 =string.Empty;
             this.__ZYJSJG4 =string.Empty;
             this.__ZYJSPJZ =string.Empty;
             this.__ZYJSXZ =string.Empty;
             this.__ZYJS_PD =string.Empty;
             this.__ZYJSYW =string.Empty;
             this.__ZYJSDSZS =string.Empty;
             this.__ZYJSWD =string.Empty;
             this.__ZYJSDQY =string.Empty;
             this.__ZYJSSD =string.Empty;
             this.__KSSJ =string.Empty;
             this.__JSSJ =string.Empty;
             this.__SFLZS =string.Empty;
             this.__PT_ZYJSJG2 =string.Empty;
             this.__PT_ZYJSJG3 =string.Empty;
             this.__PT_ZYJSJG4 =string.Empty;
             this.__PT_ZYJSPJZ =string.Empty;
             this.__PT_ZYJSDSZS =string.Empty;
             this.__PT_ZYJS_PD =string.Empty;
             this.__ZYJSZS1 =string.Empty;
             this.__ZYJSZS2 =string.Empty;
             this.__ZYJSZS3 =string.Empty;
             this.__ZYJSZS4 =string.Empty;
             this.__Changed["ID"] = false;
             this.__Changed["ZYJSJCCS"] = false;
             this.__Changed["JCLSH"] = false;
             this.__Changed["ZYJSJG1"] = false;
             this.__Changed["ZYJSJG2"] = false;
             this.__Changed["ZYJSJG3"] = false;
             this.__Changed["ZYJSJG4"] = false;
             this.__Changed["ZYJSPJZ"] = false;
             this.__Changed["ZYJSXZ"] = false;
             this.__Changed["ZYJS_PD"] = false;
             this.__Changed["ZYJSYW"] = false;
             this.__Changed["ZYJSDSZS"] = false;
             this.__Changed["ZYJSWD"] = false;
             this.__Changed["ZYJSDQY"] = false;
             this.__Changed["ZYJSSD"] = false;
             this.__Changed["KSSJ"] = false;
             this.__Changed["JSSJ"] = false;
             this.__Changed["SFLZS"] = false;
             this.__Changed["PT_ZYJSJG2"] = false;
             this.__Changed["PT_ZYJSJG3"] = false;
             this.__Changed["PT_ZYJSJG4"] = false;
             this.__Changed["PT_ZYJSPJZ"] = false;
             this.__Changed["PT_ZYJSDSZS"] = false;
             this.__Changed["PT_ZYJS_PD"] = false;
             this.__Changed["ZYJSZS1"] = false;
             this.__Changed["ZYJSZS2"] = false;
             this.__Changed["ZYJSZS3"] = false;
             this.__Changed["ZYJSZS4"] = false;
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
         ///设置或获取类中的[ZYJSJCCS]的数据
         /// </summary>
         public string ZYJSJCCS
         {
              set{ __ZYJSJCCS = value.Replace("'","’"); __Changed["ZYJSJCCS"] = true;}
              get{return __ZYJSJCCS;}
         }
         /// <summary>
         ///设置或获取类中的[JCLSH]的数据
         /// </summary>
         public string JCLSH
         {
              set{ __JCLSH = value.Replace("'","’"); __Changed["JCLSH"] = true;}
              get{return __JCLSH;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSJG1]的数据
         /// </summary>
         public string ZYJSJG1
         {
              set{ __ZYJSJG1 = value.Replace("'","’"); __Changed["ZYJSJG1"] = true;}
              get{return __ZYJSJG1;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSJG2]的数据
         /// </summary>
         public string ZYJSJG2
         {
              set{ __ZYJSJG2 = value.Replace("'","’"); __Changed["ZYJSJG2"] = true;}
              get{return __ZYJSJG2;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSJG3]的数据
         /// </summary>
         public string ZYJSJG3
         {
              set{ __ZYJSJG3 = value.Replace("'","’"); __Changed["ZYJSJG3"] = true;}
              get{return __ZYJSJG3;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSJG4]的数据
         /// </summary>
         public string ZYJSJG4
         {
              set{ __ZYJSJG4 = value.Replace("'","’"); __Changed["ZYJSJG4"] = true;}
              get{return __ZYJSJG4;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSPJZ]的数据
         /// </summary>
         public string ZYJSPJZ
         {
              set{ __ZYJSPJZ = value.Replace("'","’"); __Changed["ZYJSPJZ"] = true;}
              get{return __ZYJSPJZ;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSXZ]的数据
         /// </summary>
         public string ZYJSXZ
         {
              set{ __ZYJSXZ = value.Replace("'","’"); __Changed["ZYJSXZ"] = true;}
              get{return __ZYJSXZ;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJS_PD]的数据
         /// </summary>
         public string ZYJS_PD
         {
              set{ __ZYJS_PD = value.Replace("'","’"); __Changed["ZYJS_PD"] = true;}
              get{return __ZYJS_PD;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSYW]的数据
         /// </summary>
         public string ZYJSYW
         {
              set{ __ZYJSYW = value.Replace("'","’"); __Changed["ZYJSYW"] = true;}
              get{return __ZYJSYW;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSDSZS]的数据
         /// </summary>
         public string ZYJSDSZS
         {
              set{ __ZYJSDSZS = value.Replace("'","’"); __Changed["ZYJSDSZS"] = true;}
              get{return __ZYJSDSZS;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSWD]的数据
         /// </summary>
         public string ZYJSWD
         {
              set{ __ZYJSWD = value.Replace("'","’"); __Changed["ZYJSWD"] = true;}
              get{return __ZYJSWD;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSDQY]的数据
         /// </summary>
         public string ZYJSDQY
         {
              set{ __ZYJSDQY = value.Replace("'","’"); __Changed["ZYJSDQY"] = true;}
              get{return __ZYJSDQY;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSSD]的数据
         /// </summary>
         public string ZYJSSD
         {
              set{ __ZYJSSD = value.Replace("'","’"); __Changed["ZYJSSD"] = true;}
              get{return __ZYJSSD;}
         }
         /// <summary>
         ///设置或获取类中的[KSSJ]的数据
         /// </summary>
         public string KSSJ
         {
              set{ __KSSJ = value.Replace("'","’"); __Changed["KSSJ"] = true;}
              get{return __KSSJ;}
         }
         /// <summary>
         ///设置或获取类中的[JSSJ]的数据
         /// </summary>
         public string JSSJ
         {
              set{ __JSSJ = value.Replace("'","’"); __Changed["JSSJ"] = true;}
              get{return __JSSJ;}
         }
         /// <summary>
         ///设置或获取类中的[SFLZS]的数据
         /// </summary>
         public string SFLZS
         {
              set{ __SFLZS = value.Replace("'","’"); __Changed["SFLZS"] = true;}
              get{return __SFLZS;}
         }
         /// <summary>
         ///设置或获取类中的[PT_ZYJSJG2]的数据
         /// </summary>
         public string PT_ZYJSJG2
         {
              set{ __PT_ZYJSJG2 = value.Replace("'","’"); __Changed["PT_ZYJSJG2"] = true;}
              get{return __PT_ZYJSJG2;}
         }
         /// <summary>
         ///设置或获取类中的[PT_ZYJSJG3]的数据
         /// </summary>
         public string PT_ZYJSJG3
         {
              set{ __PT_ZYJSJG3 = value.Replace("'","’"); __Changed["PT_ZYJSJG3"] = true;}
              get{return __PT_ZYJSJG3;}
         }
         /// <summary>
         ///设置或获取类中的[PT_ZYJSJG4]的数据
         /// </summary>
         public string PT_ZYJSJG4
         {
              set{ __PT_ZYJSJG4 = value.Replace("'","’"); __Changed["PT_ZYJSJG4"] = true;}
              get{return __PT_ZYJSJG4;}
         }
         /// <summary>
         ///设置或获取类中的[PT_ZYJSPJZ]的数据
         /// </summary>
         public string PT_ZYJSPJZ
         {
              set{ __PT_ZYJSPJZ = value.Replace("'","’"); __Changed["PT_ZYJSPJZ"] = true;}
              get{return __PT_ZYJSPJZ;}
         }
         /// <summary>
         ///设置或获取类中的[PT_ZYJSDSZS]的数据
         /// </summary>
         public string PT_ZYJSDSZS
         {
              set{ __PT_ZYJSDSZS = value.Replace("'","’"); __Changed["PT_ZYJSDSZS"] = true;}
              get{return __PT_ZYJSDSZS;}
         }
         /// <summary>
         ///设置或获取类中的[PT_ZYJS_PD]的数据
         /// </summary>
         public string PT_ZYJS_PD
         {
              set{ __PT_ZYJS_PD = value.Replace("'","’"); __Changed["PT_ZYJS_PD"] = true;}
              get{return __PT_ZYJS_PD;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSZS1]的数据
         /// </summary>
         public string ZYJSZS1
         {
              set{ __ZYJSZS1 = value.Replace("'","’"); __Changed["ZYJSZS1"] = true;}
              get{return __ZYJSZS1;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSZS2]的数据
         /// </summary>
         public string ZYJSZS2
         {
              set{ __ZYJSZS2 = value.Replace("'","’"); __Changed["ZYJSZS2"] = true;}
              get{return __ZYJSZS2;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSZS3]的数据
         /// </summary>
         public string ZYJSZS3
         {
              set{ __ZYJSZS3 = value.Replace("'","’"); __Changed["ZYJSZS3"] = true;}
              get{return __ZYJSZS3;}
         }
         /// <summary>
         ///设置或获取类中的[ZYJSZS4]的数据
         /// </summary>
         public string ZYJSZS4
         {
              set{ __ZYJSZS4 = value.Replace("'","’"); __Changed["ZYJSZS4"] = true;}
              get{return __ZYJSZS4;}
         }
    }
}
