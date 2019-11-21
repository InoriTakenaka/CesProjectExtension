using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类DEV_STANDARD_VMAS
     ///</summary>
     public class DEV_STANDARD_VMAS
     {
         private int __ID=0;
         private string __SEARCH_CONDITION=string.Empty;
         private string __ZXMC=string.Empty;
         private string __COXZ=string.Empty;
         private string __HCXZ=string.Empty;
         private string __NOXZ=string.Empty;
         private string __HC_NOXZ=string.Empty;
         private string __PDFS=string.Empty;
         private int? __IS_SHOW=null;
         private string __AREA_NAME=string.Empty;
         private int? __UTYPE=null;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public DEV_STANDARD_VMAS()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("SEARCH_CONDITION",false);
             this.__Changed.Add("ZXMC",false);
             this.__Changed.Add("COXZ",false);
             this.__Changed.Add("HCXZ",false);
             this.__Changed.Add("NOXZ",false);
             this.__Changed.Add("HC_NOXZ",false);
             this.__Changed.Add("PDFS",false);
             this.__Changed.Add("IS_SHOW",false);
             this.__Changed.Add("AREA_NAME",false);
             this.__Changed.Add("UTYPE",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__SEARCH_CONDITION =string.Empty;
             this.__ZXMC =string.Empty;
             this.__COXZ =string.Empty;
             this.__HCXZ =string.Empty;
             this.__NOXZ =string.Empty;
             this.__HC_NOXZ =string.Empty;
             this.__PDFS =string.Empty;
             this.__IS_SHOW =null;
             this.__AREA_NAME =string.Empty;
             this.__UTYPE =null;
             this.__Changed["ID"] = false;
             this.__Changed["SEARCH_CONDITION"] = false;
             this.__Changed["ZXMC"] = false;
             this.__Changed["COXZ"] = false;
             this.__Changed["HCXZ"] = false;
             this.__Changed["NOXZ"] = false;
             this.__Changed["HC_NOXZ"] = false;
             this.__Changed["PDFS"] = false;
             this.__Changed["IS_SHOW"] = false;
             this.__Changed["AREA_NAME"] = false;
             this.__Changed["UTYPE"] = false;
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
         ///设置或获取类中的[COXZ]的数据
         /// </summary>
         public string COXZ
         {
              set{ __COXZ = value.Replace("'","’"); __Changed["COXZ"] = true;}
              get{return __COXZ;}
         }
         /// <summary>
         ///设置或获取类中的[HCXZ]的数据
         /// </summary>
         public string HCXZ
         {
              set{ __HCXZ = value.Replace("'","’"); __Changed["HCXZ"] = true;}
              get{return __HCXZ;}
         }
         /// <summary>
         ///设置或获取类中的[NOXZ]的数据
         /// </summary>
         public string NOXZ
         {
              set{ __NOXZ = value.Replace("'","’"); __Changed["NOXZ"] = true;}
              get{return __NOXZ;}
         }
         /// <summary>
         ///设置或获取类中的[HC_NOXZ]的数据
         /// </summary>
         public string HC_NOXZ
         {
              set{ __HC_NOXZ = value.Replace("'","’"); __Changed["HC_NOXZ"] = true;}
              get{return __HC_NOXZ;}
         }
         /// <summary>
         ///设置或获取类中的[PDFS]的数据
         /// </summary>
         public string PDFS
         {
              set{ __PDFS = value.Replace("'","’"); __Changed["PDFS"] = true;}
              get{return __PDFS;}
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
    }
}
