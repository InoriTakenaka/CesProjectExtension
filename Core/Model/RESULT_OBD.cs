using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类RESULT_OBD
     ///</summary>
     public class RESULT_OBD
     {
         private int __ID=0;
         private string __JCLSH=string.Empty;
         private string __VIN=string.Empty;
         private DateTime? __testdate=null;
         private int? __isupdated=null;
         private string __ZSD_PD=string.Empty;
         private string __GZ_PD=string.Empty;
         private string __ECU_VIN=string.Empty;
         private string __ECU_CALID=string.Empty;
         private string __ECU_CVN=string.Empty;
         private string __ECU_PD=string.Empty;
         private string __TX_PD=string.Empty;
         private string __JX_PD=string.Empty;
         private string __ALL_PD=string.Empty;
         private string __FreezeData=string.Empty;
         private string __ECUInfo=string.Empty;
         private string __IUPR=string.Empty;
         private string __SystemCheckState=string.Empty;
         private string __RTData=string.Empty;
         private string __SRTData=string.Empty;
         private string __DTC=string.Empty;
         private string __TX_BHGYY=string.Empty;
         private string __TX_GZDZT=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public RESULT_OBD()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("JCLSH",false);
             this.__Changed.Add("VIN",false);
             this.__Changed.Add("testdate",false);
             this.__Changed.Add("isupdated",false);
             this.__Changed.Add("ZSD_PD",false);
             this.__Changed.Add("GZ_PD",false);
             this.__Changed.Add("ECU_VIN",false);
             this.__Changed.Add("ECU_CALID",false);
             this.__Changed.Add("ECU_CVN",false);
             this.__Changed.Add("ECU_PD",false);
             this.__Changed.Add("TX_PD",false);
             this.__Changed.Add("JX_PD",false);
             this.__Changed.Add("ALL_PD",false);
             this.__Changed.Add("FreezeData",false);
             this.__Changed.Add("ECUInfo",false);
             this.__Changed.Add("IUPR",false);
             this.__Changed.Add("SystemCheckState",false);
             this.__Changed.Add("RTData",false);
             this.__Changed.Add("SRTData",false);
             this.__Changed.Add("DTC",false);
             this.__Changed.Add("TX_BHGYY",false);
             this.__Changed.Add("TX_GZDZT",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__JCLSH =string.Empty;
             this.__VIN =string.Empty;
             this.__testdate =null;
             this.__isupdated =null;
             this.__ZSD_PD =string.Empty;
             this.__GZ_PD =string.Empty;
             this.__ECU_VIN =string.Empty;
             this.__ECU_CALID =string.Empty;
             this.__ECU_CVN =string.Empty;
             this.__ECU_PD =string.Empty;
             this.__TX_PD =string.Empty;
             this.__JX_PD =string.Empty;
             this.__ALL_PD =string.Empty;
             this.__FreezeData =string.Empty;
             this.__ECUInfo =string.Empty;
             this.__IUPR =string.Empty;
             this.__SystemCheckState =string.Empty;
             this.__RTData =string.Empty;
             this.__SRTData =string.Empty;
             this.__DTC =string.Empty;
             this.__TX_BHGYY =string.Empty;
             this.__TX_GZDZT =string.Empty;
             this.__Changed["ID"] = false;
             this.__Changed["JCLSH"] = false;
             this.__Changed["VIN"] = false;
             this.__Changed["testdate"] = false;
             this.__Changed["isupdated"] = false;
             this.__Changed["ZSD_PD"] = false;
             this.__Changed["GZ_PD"] = false;
             this.__Changed["ECU_VIN"] = false;
             this.__Changed["ECU_CALID"] = false;
             this.__Changed["ECU_CVN"] = false;
             this.__Changed["ECU_PD"] = false;
             this.__Changed["TX_PD"] = false;
             this.__Changed["JX_PD"] = false;
             this.__Changed["ALL_PD"] = false;
             this.__Changed["FreezeData"] = false;
             this.__Changed["ECUInfo"] = false;
             this.__Changed["IUPR"] = false;
             this.__Changed["SystemCheckState"] = false;
             this.__Changed["RTData"] = false;
             this.__Changed["SRTData"] = false;
             this.__Changed["DTC"] = false;
             this.__Changed["TX_BHGYY"] = false;
             this.__Changed["TX_GZDZT"] = false;
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
         ///设置或获取类中的[JCLSH]的数据
         /// </summary>
         public string JCLSH
         {
              set{ __JCLSH = value.Replace("'","’"); __Changed["JCLSH"] = true;}
              get{return __JCLSH;}
         }
         /// <summary>
         ///设置或获取类中的[VIN]的数据
         /// </summary>
         public string VIN
         {
              set{ __VIN = value.Replace("'","’"); __Changed["VIN"] = true;}
              get{return __VIN;}
         }
         /// <summary>
         ///设置或获取类中的[testdate]的数据
         /// </summary>
         public DateTime? testdate
         {
              set{ __testdate = value; __Changed["testdate"] = true;}
              get{return __testdate;}
         }
         /// <summary>
         ///设置或获取类中的[isupdated]的数据
         /// </summary>
         public int? isupdated
         {
              set{ __isupdated = value; __Changed["isupdated"] = true;}
              get{return __isupdated;}
         }
         /// <summary>
         ///设置或获取类中的[ZSD_PD]的数据
         /// </summary>
         public string ZSD_PD
         {
              set{ __ZSD_PD = value.Replace("'","’"); __Changed["ZSD_PD"] = true;}
              get{return __ZSD_PD;}
         }
         /// <summary>
         ///设置或获取类中的[GZ_PD]的数据
         /// </summary>
         public string GZ_PD
         {
              set{ __GZ_PD = value.Replace("'","’"); __Changed["GZ_PD"] = true;}
              get{return __GZ_PD;}
         }
         /// <summary>
         ///设置或获取类中的[ECU_VIN]的数据
         /// </summary>
         public string ECU_VIN
         {
              set{ __ECU_VIN = value.Replace("'","’"); __Changed["ECU_VIN"] = true;}
              get{return __ECU_VIN;}
         }
         /// <summary>
         ///设置或获取类中的[ECU_CALID]的数据
         /// </summary>
         public string ECU_CALID
         {
              set{ __ECU_CALID = value.Replace("'","’"); __Changed["ECU_CALID"] = true;}
              get{return __ECU_CALID;}
         }
         /// <summary>
         ///设置或获取类中的[ECU_CVN]的数据
         /// </summary>
         public string ECU_CVN
         {
              set{ __ECU_CVN = value.Replace("'","’"); __Changed["ECU_CVN"] = true;}
              get{return __ECU_CVN;}
         }
         /// <summary>
         ///设置或获取类中的[ECU_PD]的数据
         /// </summary>
         public string ECU_PD
         {
              set{ __ECU_PD = value.Replace("'","’"); __Changed["ECU_PD"] = true;}
              get{return __ECU_PD;}
         }
         /// <summary>
         ///设置或获取类中的[TX_PD]的数据
         /// </summary>
         public string TX_PD
         {
              set{ __TX_PD = value.Replace("'","’"); __Changed["TX_PD"] = true;}
              get{return __TX_PD;}
         }
         /// <summary>
         ///设置或获取类中的[JX_PD]的数据
         /// </summary>
         public string JX_PD
         {
              set{ __JX_PD = value.Replace("'","’"); __Changed["JX_PD"] = true;}
              get{return __JX_PD;}
         }
         /// <summary>
         ///设置或获取类中的[ALL_PD]的数据
         /// </summary>
         public string ALL_PD
         {
              set{ __ALL_PD = value.Replace("'","’"); __Changed["ALL_PD"] = true;}
              get{return __ALL_PD;}
         }
         /// <summary>
         ///设置或获取类中的[FreezeData]的数据
         /// </summary>
         public string FreezeData
         {
              set{ __FreezeData = value.Replace("'","’"); __Changed["FreezeData"] = true;}
              get{return __FreezeData;}
         }
         /// <summary>
         ///设置或获取类中的[ECUInfo]的数据
         /// </summary>
         public string ECUInfo
         {
              set{ __ECUInfo = value.Replace("'","’"); __Changed["ECUInfo"] = true;}
              get{return __ECUInfo;}
         }
         /// <summary>
         ///设置或获取类中的[IUPR]的数据
         /// </summary>
         public string IUPR
         {
              set{ __IUPR = value.Replace("'","’"); __Changed["IUPR"] = true;}
              get{return __IUPR;}
         }
         /// <summary>
         ///设置或获取类中的[SystemCheckState]的数据
         /// </summary>
         public string SystemCheckState
         {
              set{ __SystemCheckState = value.Replace("'","’"); __Changed["SystemCheckState"] = true;}
              get{return __SystemCheckState;}
         }
         /// <summary>
         ///设置或获取类中的[RTData]的数据
         /// </summary>
         public string RTData
         {
              set{ __RTData = value.Replace("'","’"); __Changed["RTData"] = true;}
              get{return __RTData;}
         }
         /// <summary>
         ///设置或获取类中的[SRTData]的数据
         /// </summary>
         public string SRTData
         {
              set{ __SRTData = value.Replace("'","’"); __Changed["SRTData"] = true;}
              get{return __SRTData;}
         }
         /// <summary>
         ///设置或获取类中的[DTC]的数据
         /// </summary>
         public string DTC
         {
              set{ __DTC = value.Replace("'","’"); __Changed["DTC"] = true;}
              get{return __DTC;}
         }
         /// <summary>
         ///设置或获取类中的[TX_BHGYY]的数据
         /// </summary>
         public string TX_BHGYY
         {
              set{ __TX_BHGYY = value.Replace("'","’"); __Changed["TX_BHGYY"] = true;}
              get{return __TX_BHGYY;}
         }
         /// <summary>
         ///设置或获取类中的[TX_GZDZT]的数据
         /// </summary>
         public string TX_GZDZT
         {
              set{ __TX_GZDZT = value.Replace("'","’"); __Changed["TX_GZDZT"] = true;}
              get{return __TX_GZDZT;}
         }
    }
}
