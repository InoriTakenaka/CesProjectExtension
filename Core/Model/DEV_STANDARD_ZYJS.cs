using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类DEV_STANDARD_ZYJS
     ///</summary>
     public class DEV_STANDARD_ZYJS
     {
         private int __ID=0;
         private string __SEARCH_CONDITION=string.Empty;
         private string __ZXMC=string.Empty;
         private string __ZYJSXZ=string.Empty;
         private int? __IS_SHOW=null;
         private string __AREA_NAME=string.Empty;
         private int? __UTYPE=null;
         private string __HSUXZ=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public DEV_STANDARD_ZYJS()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("SEARCH_CONDITION",false);
             this.__Changed.Add("ZXMC",false);
             this.__Changed.Add("ZYJSXZ",false);
             this.__Changed.Add("IS_SHOW",false);
             this.__Changed.Add("AREA_NAME",false);
             this.__Changed.Add("UTYPE",false);
             this.__Changed.Add("HSUXZ",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__SEARCH_CONDITION =string.Empty;
             this.__ZXMC =string.Empty;
             this.__ZYJSXZ =string.Empty;
             this.__IS_SHOW =null;
             this.__AREA_NAME =string.Empty;
             this.__UTYPE =null;
             this.__HSUXZ =string.Empty;
             this.__Changed["ID"] = false;
             this.__Changed["SEARCH_CONDITION"] = false;
             this.__Changed["ZXMC"] = false;
             this.__Changed["ZYJSXZ"] = false;
             this.__Changed["IS_SHOW"] = false;
             this.__Changed["AREA_NAME"] = false;
             this.__Changed["UTYPE"] = false;
             this.__Changed["HSUXZ"] = false;
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
         ///设置或获取类中的[SEARCH_CONDITION]的数据
         /// </summary>
         public string SEARCH_CONDITION
         {
              set{ __SEARCH_CONDITION = value.Replace("'","’"); __Changed["SEARCH_CONDITION"] = true;}
              get{return __SEARCH_CONDITION;}
         }
         /// <summary>
         ///设置或获取类中的[ZXMC]的数据
         /// </summary>
         public string ZXMC
         {
              set{ __ZXMC = value.Replace("'","’"); __Changed["ZXMC"] = true;}
              get{return __ZXMC;}
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
         ///设置或获取类中的[IS_SHOW]的数据
         /// </summary>
         public int? IS_SHOW
         {
              set{ __IS_SHOW = value; __Changed["IS_SHOW"] = true;}
              get{return __IS_SHOW;}
         }
         /// <summary>
         ///设置或获取类中的[AREA_NAME]的数据
         /// </summary>
         public string AREA_NAME
         {
              set{ __AREA_NAME = value.Replace("'","’"); __Changed["AREA_NAME"] = true;}
              get{return __AREA_NAME;}
         }
         /// <summary>
         ///设置或获取类中的[UTYPE]的数据
         /// </summary>
         public int? UTYPE
         {
              set{ __UTYPE = value; __Changed["UTYPE"] = true;}
              get{return __UTYPE;}
         }
         /// <summary>
         ///设置或获取类中的[HSUXZ]的数据
         /// </summary>
         public string HSUXZ
         {
              set{ __HSUXZ = value.Replace("'","’"); __Changed["HSUXZ"] = true;}
              get{return __HSUXZ;}
         }
    }
}
