using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类DEV_STANDARD_ASM
     ///</summary>
     public class DEV_STANDARD_ASM
     {
         private int __ID=0;
         private string __SEARCH_CONDITION=string.Empty;
         private string __ZXMC=string.Empty;
         private string __HC5025XZ=string.Empty;
         private string __CO5025XZ=string.Empty;
         private string __NO5025XZ=string.Empty;
         private string __HC2540XZ=string.Empty;
         private string __CO2540XZ=string.Empty;
         private string __NO2540XZ=string.Empty;
         private string __DSHCXZ=string.Empty;
         private string __DSCOXZ=string.Empty;
         private int? __IS_SHOW=null;
         private string __AREA_NAME=string.Empty;
         private int? __UTYPE=null;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public DEV_STANDARD_ASM()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("SEARCH_CONDITION",false);
             this.__Changed.Add("ZXMC",false);
             this.__Changed.Add("HC5025XZ",false);
             this.__Changed.Add("CO5025XZ",false);
             this.__Changed.Add("NO5025XZ",false);
             this.__Changed.Add("HC2540XZ",false);
             this.__Changed.Add("CO2540XZ",false);
             this.__Changed.Add("NO2540XZ",false);
             this.__Changed.Add("DSHCXZ",false);
             this.__Changed.Add("DSCOXZ",false);
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
             this.__HC5025XZ =string.Empty;
             this.__CO5025XZ =string.Empty;
             this.__NO5025XZ =string.Empty;
             this.__HC2540XZ =string.Empty;
             this.__CO2540XZ =string.Empty;
             this.__NO2540XZ =string.Empty;
             this.__DSHCXZ =string.Empty;
             this.__DSCOXZ =string.Empty;
             this.__IS_SHOW =null;
             this.__AREA_NAME =string.Empty;
             this.__UTYPE =null;
             this.__Changed["ID"] = false;
             this.__Changed["SEARCH_CONDITION"] = false;
             this.__Changed["ZXMC"] = false;
             this.__Changed["HC5025XZ"] = false;
             this.__Changed["CO5025XZ"] = false;
             this.__Changed["NO5025XZ"] = false;
             this.__Changed["HC2540XZ"] = false;
             this.__Changed["CO2540XZ"] = false;
             this.__Changed["NO2540XZ"] = false;
             this.__Changed["DSHCXZ"] = false;
             this.__Changed["DSCOXZ"] = false;
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
         ///设置或获取类中的[HC5025XZ]的数据
         /// </summary>
         public string HC5025XZ
         {
              set{ __HC5025XZ = value.Replace("'","’"); __Changed["HC5025XZ"] = true;}
              get{return __HC5025XZ;}
         }
         /// <summary>
         ///设置或获取类中的[CO5025XZ]的数据
         /// </summary>
         public string CO5025XZ
         {
              set{ __CO5025XZ = value.Replace("'","’"); __Changed["CO5025XZ"] = true;}
              get{return __CO5025XZ;}
         }
         /// <summary>
         ///设置或获取类中的[NO5025XZ]的数据
         /// </summary>
         public string NO5025XZ
         {
              set{ __NO5025XZ = value.Replace("'","’"); __Changed["NO5025XZ"] = true;}
              get{return __NO5025XZ;}
         }
         /// <summary>
         ///设置或获取类中的[HC2540XZ]的数据
         /// </summary>
         public string HC2540XZ
         {
              set{ __HC2540XZ = value.Replace("'","’"); __Changed["HC2540XZ"] = true;}
              get{return __HC2540XZ;}
         }
         /// <summary>
         ///设置或获取类中的[CO2540XZ]的数据
         /// </summary>
         public string CO2540XZ
         {
              set{ __CO2540XZ = value.Replace("'","’"); __Changed["CO2540XZ"] = true;}
              get{return __CO2540XZ;}
         }
         /// <summary>
         ///设置或获取类中的[NO2540XZ]的数据
         /// </summary>
         public string NO2540XZ
         {
              set{ __NO2540XZ = value.Replace("'","’"); __Changed["NO2540XZ"] = true;}
              get{return __NO2540XZ;}
         }
         /// <summary>
         ///设置或获取类中的[DSHCXZ]的数据
         /// </summary>
         public string DSHCXZ
         {
              set{ __DSHCXZ = value.Replace("'","’"); __Changed["DSHCXZ"] = true;}
              get{return __DSHCXZ;}
         }
         /// <summary>
         ///设置或获取类中的[DSCOXZ]的数据
         /// </summary>
         public string DSCOXZ
         {
              set{ __DSCOXZ = value.Replace("'","’"); __Changed["DSCOXZ"] = true;}
              get{return __DSCOXZ;}
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
