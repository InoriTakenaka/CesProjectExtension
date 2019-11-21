using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类RESULT_VMAS
     ///</summary>
     public class RESULT_VMAS
     {
         private int __ID=0;
         private string __JCLSH=string.Empty;
         private string __VMASJCCS=string.Empty;
         private string __HCJG=string.Empty;
         private string __COJG=string.Empty;
         private string __NOJG=string.Empty;
         private string __HC_NOJG=string.Empty;
         private string __HCXZ=string.Empty;
         private string __COXZ=string.Empty;
         private string __NOXZ=string.Empty;
         private string __HC_NOXZ=string.Empty;
         private string __HC_PD=string.Empty;
         private string __CO_PD=string.Empty;
         private string __NO_PD=string.Empty;
         private string __HC_NO_PD=string.Empty;
         private string __PDFS=string.Empty;
         private string __LXWCSJ=string.Empty;
         private string __LJWCSJ=string.Empty;
         private string __LJXXLC=string.Empty;
         private string __VMAS_PD=string.Empty;
         private string __WD=string.Empty;
         private string __SD=string.Empty;
         private string __DQY=string.Empty;
         private string __BJ_O2=string.Empty;
         private string __CL_HC=string.Empty;
         private string __KSSJ=string.Empty;
         private string __JSSJ=string.Empty;
         private string __CO2JG=string.Empty;
         private string __AmbientCO=string.Empty;
         private string __AmbientCO2=string.Empty;
         private string __AmbientHC=string.Empty;
         private string __AmbientNO=string.Empty;
         private string __AmbientO2=string.Empty;
         private string __BackgroundCO=string.Empty;
         private string __BackgroundCO2=string.Empty;
         private string __BackgroundHC=string.Empty;
         private string __BackgroundNO=string.Empty;
         private string __BackgroundO2=string.Empty;
         private string __ResidualHC=string.Empty;
         private string __GPPLCS=string.Empty;
         private string __StopReason=string.Empty;
         private string __PT_CO=string.Empty;
         private string __PT_HC=string.Empty;
         private string __PT_NO=string.Empty;
         private string __PT_VMAS_PD=string.Empty;
         private string __Lamba=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public RESULT_VMAS()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("JCLSH",false);
             this.__Changed.Add("VMASJCCS",false);
             this.__Changed.Add("HCJG",false);
             this.__Changed.Add("COJG",false);
             this.__Changed.Add("NOJG",false);
             this.__Changed.Add("HC_NOJG",false);
             this.__Changed.Add("HCXZ",false);
             this.__Changed.Add("COXZ",false);
             this.__Changed.Add("NOXZ",false);
             this.__Changed.Add("HC_NOXZ",false);
             this.__Changed.Add("HC_PD",false);
             this.__Changed.Add("CO_PD",false);
             this.__Changed.Add("NO_PD",false);
             this.__Changed.Add("HC_NO_PD",false);
             this.__Changed.Add("PDFS",false);
             this.__Changed.Add("LXWCSJ",false);
             this.__Changed.Add("LJWCSJ",false);
             this.__Changed.Add("LJXXLC",false);
             this.__Changed.Add("VMAS_PD",false);
             this.__Changed.Add("WD",false);
             this.__Changed.Add("SD",false);
             this.__Changed.Add("DQY",false);
             this.__Changed.Add("BJ_O2",false);
             this.__Changed.Add("CL_HC",false);
             this.__Changed.Add("KSSJ",false);
             this.__Changed.Add("JSSJ",false);
             this.__Changed.Add("CO2JG",false);
             this.__Changed.Add("AmbientCO",false);
             this.__Changed.Add("AmbientCO2",false);
             this.__Changed.Add("AmbientHC",false);
             this.__Changed.Add("AmbientNO",false);
             this.__Changed.Add("AmbientO2",false);
             this.__Changed.Add("BackgroundCO",false);
             this.__Changed.Add("BackgroundCO2",false);
             this.__Changed.Add("BackgroundHC",false);
             this.__Changed.Add("BackgroundNO",false);
             this.__Changed.Add("BackgroundO2",false);
             this.__Changed.Add("ResidualHC",false);
             this.__Changed.Add("GPPLCS",false);
             this.__Changed.Add("StopReason",false);
             this.__Changed.Add("PT_CO",false);
             this.__Changed.Add("PT_HC",false);
             this.__Changed.Add("PT_NO",false);
             this.__Changed.Add("PT_VMAS_PD",false);
             this.__Changed.Add("Lamba",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__JCLSH =string.Empty;
             this.__VMASJCCS =string.Empty;
             this.__HCJG =string.Empty;
             this.__COJG =string.Empty;
             this.__NOJG =string.Empty;
             this.__HC_NOJG =string.Empty;
             this.__HCXZ =string.Empty;
             this.__COXZ =string.Empty;
             this.__NOXZ =string.Empty;
             this.__HC_NOXZ =string.Empty;
             this.__HC_PD =string.Empty;
             this.__CO_PD =string.Empty;
             this.__NO_PD =string.Empty;
             this.__HC_NO_PD =string.Empty;
             this.__PDFS =string.Empty;
             this.__LXWCSJ =string.Empty;
             this.__LJWCSJ =string.Empty;
             this.__LJXXLC =string.Empty;
             this.__VMAS_PD =string.Empty;
             this.__WD =string.Empty;
             this.__SD =string.Empty;
             this.__DQY =string.Empty;
             this.__BJ_O2 =string.Empty;
             this.__CL_HC =string.Empty;
             this.__KSSJ =string.Empty;
             this.__JSSJ =string.Empty;
             this.__CO2JG =string.Empty;
             this.__AmbientCO =string.Empty;
             this.__AmbientCO2 =string.Empty;
             this.__AmbientHC =string.Empty;
             this.__AmbientNO =string.Empty;
             this.__AmbientO2 =string.Empty;
             this.__BackgroundCO =string.Empty;
             this.__BackgroundCO2 =string.Empty;
             this.__BackgroundHC =string.Empty;
             this.__BackgroundNO =string.Empty;
             this.__BackgroundO2 =string.Empty;
             this.__ResidualHC =string.Empty;
             this.__GPPLCS =string.Empty;
             this.__StopReason =string.Empty;
             this.__PT_CO =string.Empty;
             this.__PT_HC =string.Empty;
             this.__PT_NO =string.Empty;
             this.__PT_VMAS_PD =string.Empty;
             this.__Lamba =string.Empty;
             this.__Changed["ID"] = false;
             this.__Changed["JCLSH"] = false;
             this.__Changed["VMASJCCS"] = false;
             this.__Changed["HCJG"] = false;
             this.__Changed["COJG"] = false;
             this.__Changed["NOJG"] = false;
             this.__Changed["HC_NOJG"] = false;
             this.__Changed["HCXZ"] = false;
             this.__Changed["COXZ"] = false;
             this.__Changed["NOXZ"] = false;
             this.__Changed["HC_NOXZ"] = false;
             this.__Changed["HC_PD"] = false;
             this.__Changed["CO_PD"] = false;
             this.__Changed["NO_PD"] = false;
             this.__Changed["HC_NO_PD"] = false;
             this.__Changed["PDFS"] = false;
             this.__Changed["LXWCSJ"] = false;
             this.__Changed["LJWCSJ"] = false;
             this.__Changed["LJXXLC"] = false;
             this.__Changed["VMAS_PD"] = false;
             this.__Changed["WD"] = false;
             this.__Changed["SD"] = false;
             this.__Changed["DQY"] = false;
             this.__Changed["BJ_O2"] = false;
             this.__Changed["CL_HC"] = false;
             this.__Changed["KSSJ"] = false;
             this.__Changed["JSSJ"] = false;
             this.__Changed["CO2JG"] = false;
             this.__Changed["AmbientCO"] = false;
             this.__Changed["AmbientCO2"] = false;
             this.__Changed["AmbientHC"] = false;
             this.__Changed["AmbientNO"] = false;
             this.__Changed["AmbientO2"] = false;
             this.__Changed["BackgroundCO"] = false;
             this.__Changed["BackgroundCO2"] = false;
             this.__Changed["BackgroundHC"] = false;
             this.__Changed["BackgroundNO"] = false;
             this.__Changed["BackgroundO2"] = false;
             this.__Changed["ResidualHC"] = false;
             this.__Changed["GPPLCS"] = false;
             this.__Changed["StopReason"] = false;
             this.__Changed["PT_CO"] = false;
             this.__Changed["PT_HC"] = false;
             this.__Changed["PT_NO"] = false;
             this.__Changed["PT_VMAS_PD"] = false;
             this.__Changed["Lamba"] = false;
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
         ///设置或获取类中的[VMASJCCS]的数据
         /// </summary>
         public string VMASJCCS
         {
              set{ __VMASJCCS = value.Replace("'","’"); __Changed["VMASJCCS"] = true;}
              get{return __VMASJCCS;}
         }
         /// <summary>
         ///设置或获取类中的[HCJG]的数据
         /// </summary>
         public string HCJG
         {
              set{ __HCJG = value.Replace("'","’"); __Changed["HCJG"] = true;}
              get{return __HCJG;}
         }
         /// <summary>
         ///设置或获取类中的[COJG]的数据
         /// </summary>
         public string COJG
         {
              set{ __COJG = value.Replace("'","’"); __Changed["COJG"] = true;}
              get{return __COJG;}
         }
         /// <summary>
         ///设置或获取类中的[NOJG]的数据
         /// </summary>
         public string NOJG
         {
              set{ __NOJG = value.Replace("'","’"); __Changed["NOJG"] = true;}
              get{return __NOJG;}
         }
         /// <summary>
         ///设置或获取类中的[HC_NOJG]的数据
         /// </summary>
         public string HC_NOJG
         {
              set{ __HC_NOJG = value.Replace("'","’"); __Changed["HC_NOJG"] = true;}
              get{return __HC_NOJG;}
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
         ///设置或获取类中的[COXZ]的数据
         /// </summary>
         public string COXZ
         {
              set{ __COXZ = value.Replace("'","’"); __Changed["COXZ"] = true;}
              get{return __COXZ;}
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
         ///设置或获取类中的[HC_PD]的数据
         /// </summary>
         public string HC_PD
         {
              set{ __HC_PD = value.Replace("'","’"); __Changed["HC_PD"] = true;}
              get{return __HC_PD;}
         }
         /// <summary>
         ///设置或获取类中的[CO_PD]的数据
         /// </summary>
         public string CO_PD
         {
              set{ __CO_PD = value.Replace("'","’"); __Changed["CO_PD"] = true;}
              get{return __CO_PD;}
         }
         /// <summary>
         ///设置或获取类中的[NO_PD]的数据
         /// </summary>
         public string NO_PD
         {
              set{ __NO_PD = value.Replace("'","’"); __Changed["NO_PD"] = true;}
              get{return __NO_PD;}
         }
         /// <summary>
         ///设置或获取类中的[HC_NO_PD]的数据
         /// </summary>
         public string HC_NO_PD
         {
              set{ __HC_NO_PD = value.Replace("'","’"); __Changed["HC_NO_PD"] = true;}
              get{return __HC_NO_PD;}
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
         ///设置或获取类中的[LXWCSJ]的数据
         /// </summary>
         public string LXWCSJ
         {
              set{ __LXWCSJ = value.Replace("'","’"); __Changed["LXWCSJ"] = true;}
              get{return __LXWCSJ;}
         }
         /// <summary>
         ///设置或获取类中的[LJWCSJ]的数据
         /// </summary>
         public string LJWCSJ
         {
              set{ __LJWCSJ = value.Replace("'","’"); __Changed["LJWCSJ"] = true;}
              get{return __LJWCSJ;}
         }
         /// <summary>
         ///设置或获取类中的[LJXXLC]的数据
         /// </summary>
         public string LJXXLC
         {
              set{ __LJXXLC = value.Replace("'","’"); __Changed["LJXXLC"] = true;}
              get{return __LJXXLC;}
         }
         /// <summary>
         ///设置或获取类中的[VMAS_PD]的数据
         /// </summary>
         public string VMAS_PD
         {
              set{ __VMAS_PD = value.Replace("'","’"); __Changed["VMAS_PD"] = true;}
              get{return __VMAS_PD;}
         }
         /// <summary>
         ///设置或获取类中的[WD]的数据
         /// </summary>
         public string WD
         {
              set{ __WD = value.Replace("'","’"); __Changed["WD"] = true;}
              get{return __WD;}
         }
         /// <summary>
         ///设置或获取类中的[SD]的数据
         /// </summary>
         public string SD
         {
              set{ __SD = value.Replace("'","’"); __Changed["SD"] = true;}
              get{return __SD;}
         }
         /// <summary>
         ///设置或获取类中的[DQY]的数据
         /// </summary>
         public string DQY
         {
              set{ __DQY = value.Replace("'","’"); __Changed["DQY"] = true;}
              get{return __DQY;}
         }
         /// <summary>
         ///设置或获取类中的[BJ_O2]的数据
         /// </summary>
         public string BJ_O2
         {
              set{ __BJ_O2 = value.Replace("'","’"); __Changed["BJ_O2"] = true;}
              get{return __BJ_O2;}
         }
         /// <summary>
         ///设置或获取类中的[CL_HC]的数据
         /// </summary>
         public string CL_HC
         {
              set{ __CL_HC = value.Replace("'","’"); __Changed["CL_HC"] = true;}
              get{return __CL_HC;}
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
         ///设置或获取类中的[CO2JG]的数据
         /// </summary>
         public string CO2JG
         {
              set{ __CO2JG = value.Replace("'","’"); __Changed["CO2JG"] = true;}
              get{return __CO2JG;}
         }
         /// <summary>
         ///设置或获取类中的[AmbientCO]的数据
         /// </summary>
         public string AmbientCO
         {
              set{ __AmbientCO = value.Replace("'","’"); __Changed["AmbientCO"] = true;}
              get{return __AmbientCO;}
         }
         /// <summary>
         ///设置或获取类中的[AmbientCO2]的数据
         /// </summary>
         public string AmbientCO2
         {
              set{ __AmbientCO2 = value.Replace("'","’"); __Changed["AmbientCO2"] = true;}
              get{return __AmbientCO2;}
         }
         /// <summary>
         ///设置或获取类中的[AmbientHC]的数据
         /// </summary>
         public string AmbientHC
         {
              set{ __AmbientHC = value.Replace("'","’"); __Changed["AmbientHC"] = true;}
              get{return __AmbientHC;}
         }
         /// <summary>
         ///设置或获取类中的[AmbientNO]的数据
         /// </summary>
         public string AmbientNO
         {
              set{ __AmbientNO = value.Replace("'","’"); __Changed["AmbientNO"] = true;}
              get{return __AmbientNO;}
         }
         /// <summary>
         ///设置或获取类中的[AmbientO2]的数据
         /// </summary>
         public string AmbientO2
         {
              set{ __AmbientO2 = value.Replace("'","’"); __Changed["AmbientO2"] = true;}
              get{return __AmbientO2;}
         }
         /// <summary>
         ///设置或获取类中的[BackgroundCO]的数据
         /// </summary>
         public string BackgroundCO
         {
              set{ __BackgroundCO = value.Replace("'","’"); __Changed["BackgroundCO"] = true;}
              get{return __BackgroundCO;}
         }
         /// <summary>
         ///设置或获取类中的[BackgroundCO2]的数据
         /// </summary>
         public string BackgroundCO2
         {
              set{ __BackgroundCO2 = value.Replace("'","’"); __Changed["BackgroundCO2"] = true;}
              get{return __BackgroundCO2;}
         }
         /// <summary>
         ///设置或获取类中的[BackgroundHC]的数据
         /// </summary>
         public string BackgroundHC
         {
              set{ __BackgroundHC = value.Replace("'","’"); __Changed["BackgroundHC"] = true;}
              get{return __BackgroundHC;}
         }
         /// <summary>
         ///设置或获取类中的[BackgroundNO]的数据
         /// </summary>
         public string BackgroundNO
         {
              set{ __BackgroundNO = value.Replace("'","’"); __Changed["BackgroundNO"] = true;}
              get{return __BackgroundNO;}
         }
         /// <summary>
         ///设置或获取类中的[BackgroundO2]的数据
         /// </summary>
         public string BackgroundO2
         {
              set{ __BackgroundO2 = value.Replace("'","’"); __Changed["BackgroundO2"] = true;}
              get{return __BackgroundO2;}
         }
         /// <summary>
         ///设置或获取类中的[ResidualHC]的数据
         /// </summary>
         public string ResidualHC
         {
              set{ __ResidualHC = value.Replace("'","’"); __Changed["ResidualHC"] = true;}
              get{return __ResidualHC;}
         }
         /// <summary>
         ///设置或获取类中的[GPPLCS]的数据
         /// </summary>
         public string GPPLCS
         {
              set{ __GPPLCS = value.Replace("'","’"); __Changed["GPPLCS"] = true;}
              get{return __GPPLCS;}
         }
         /// <summary>
         ///设置或获取类中的[StopReason]的数据
         /// </summary>
         public string StopReason
         {
              set{ __StopReason = value.Replace("'","’"); __Changed["StopReason"] = true;}
              get{return __StopReason;}
         }
         /// <summary>
         ///设置或获取类中的[PT_CO]的数据
         /// </summary>
         public string PT_CO
         {
              set{ __PT_CO = value.Replace("'","’"); __Changed["PT_CO"] = true;}
              get{return __PT_CO;}
         }
         /// <summary>
         ///设置或获取类中的[PT_HC]的数据
         /// </summary>
         public string PT_HC
         {
              set{ __PT_HC = value.Replace("'","’"); __Changed["PT_HC"] = true;}
              get{return __PT_HC;}
         }
         /// <summary>
         ///设置或获取类中的[PT_NO]的数据
         /// </summary>
         public string PT_NO
         {
              set{ __PT_NO = value.Replace("'","’"); __Changed["PT_NO"] = true;}
              get{return __PT_NO;}
         }
         /// <summary>
         ///设置或获取类中的[PT_VMAS_PD]的数据
         /// </summary>
         public string PT_VMAS_PD
         {
              set{ __PT_VMAS_PD = value.Replace("'","’"); __Changed["PT_VMAS_PD"] = true;}
              get{return __PT_VMAS_PD;}
         }
         /// <summary>
         ///设置或获取类中的[Lamba]的数据
         /// </summary>
         public string Lamba
         {
              set{ __Lamba = value.Replace("'","’"); __Changed["Lamba"] = true;}
              get{return __Lamba;}
         }
    }
}
