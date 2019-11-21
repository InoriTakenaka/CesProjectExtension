using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类RESULT_LD
     ///</summary>
     public class RESULT_LD
     {
         private int __ID=0;
         private string __JCLSH=string.Empty;
         private string __LDJCCS=string.Empty;
         private string __GLJG=string.Empty;
         private string __GLXZ=string.Empty;
         private string __GL_PD=string.Empty;
         private string __ZSJG=string.Empty;
         private string __ZSXZ=string.Empty;
         private string __ZS_PD=string.Empty;
         private string __GXSXS100=string.Empty;
         private string __GXSXS90=string.Empty;
         private string __GXSXS80=string.Empty;
         private string __GXSXSXZ=string.Empty;
         private string __GXSXS_PD=string.Empty;
         private string __LDWD=string.Empty;
         private string __LDDQY=string.Empty;
         private string __LDSD=string.Empty;
         private string __LD_PD=string.Empty;
         private string __LDYW=string.Empty;
         private string __HSU100=string.Empty;
         private string __HSU90=string.Empty;
         private string __HSU80=string.Empty;
         private string __DSZS=string.Empty;
         private string __JSZDGLXDSD=string.Empty;
         private string __SCZDGLXDSD=string.Empty;
         private string __SMSJ=string.Empty;
         private string __CSSJ=string.Empty;
         private string __GL100=string.Empty;
         private string __GL90=string.Empty;
         private string __GL80=string.Empty;
         private string __ZS100=string.Empty;
         private string __ZS90=string.Empty;
         private string __ZS80=string.Empty;
         private string __KSSJ=string.Empty;
         private string __JSSJ=string.Empty;
         private string __NO100=string.Empty;
         private string __NO90=string.Empty;
         private string __NO80=string.Empty;
         private string __NOXZ=string.Empty;
         private string __NO_PD=string.Empty;
         private string __HSUXZ=string.Empty;
         private string __HSU_PD=string.Empty;
         private string __KH80=string.Empty;
         private string __MaxPower=string.Empty;
         private string __StopReason=string.Empty;
         private string __PT_GXSXS100=string.Empty;
         private string __PT_GXSXS80=string.Empty;
         private string __PT_NO80=string.Empty;
         private string __PT_GLJG=string.Empty;
         private string __PT_LD_PD=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public RESULT_LD()
         {
             this.__Changed.Add("ID",false);
             this.__Changed.Add("JCLSH",false);
             this.__Changed.Add("LDJCCS",false);
             this.__Changed.Add("GLJG",false);
             this.__Changed.Add("GLXZ",false);
             this.__Changed.Add("GL_PD",false);
             this.__Changed.Add("ZSJG",false);
             this.__Changed.Add("ZSXZ",false);
             this.__Changed.Add("ZS_PD",false);
             this.__Changed.Add("GXSXS100",false);
             this.__Changed.Add("GXSXS90",false);
             this.__Changed.Add("GXSXS80",false);
             this.__Changed.Add("GXSXSXZ",false);
             this.__Changed.Add("GXSXS_PD",false);
             this.__Changed.Add("LDWD",false);
             this.__Changed.Add("LDDQY",false);
             this.__Changed.Add("LDSD",false);
             this.__Changed.Add("LD_PD",false);
             this.__Changed.Add("LDYW",false);
             this.__Changed.Add("HSU100",false);
             this.__Changed.Add("HSU90",false);
             this.__Changed.Add("HSU80",false);
             this.__Changed.Add("DSZS",false);
             this.__Changed.Add("JSZDGLXDSD",false);
             this.__Changed.Add("SCZDGLXDSD",false);
             this.__Changed.Add("SMSJ",false);
             this.__Changed.Add("CSSJ",false);
             this.__Changed.Add("GL100",false);
             this.__Changed.Add("GL90",false);
             this.__Changed.Add("GL80",false);
             this.__Changed.Add("ZS100",false);
             this.__Changed.Add("ZS90",false);
             this.__Changed.Add("ZS80",false);
             this.__Changed.Add("KSSJ",false);
             this.__Changed.Add("JSSJ",false);
             this.__Changed.Add("NO100",false);
             this.__Changed.Add("NO90",false);
             this.__Changed.Add("NO80",false);
             this.__Changed.Add("NOXZ",false);
             this.__Changed.Add("NO_PD",false);
             this.__Changed.Add("HSUXZ",false);
             this.__Changed.Add("HSU_PD",false);
             this.__Changed.Add("KH80",false);
             this.__Changed.Add("MaxPower",false);
             this.__Changed.Add("StopReason",false);
             this.__Changed.Add("PT_GXSXS100",false);
             this.__Changed.Add("PT_GXSXS80",false);
             this.__Changed.Add("PT_NO80",false);
             this.__Changed.Add("PT_GLJG",false);
             this.__Changed.Add("PT_LD_PD",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__ID =0;
             this.__JCLSH =string.Empty;
             this.__LDJCCS =string.Empty;
             this.__GLJG =string.Empty;
             this.__GLXZ =string.Empty;
             this.__GL_PD =string.Empty;
             this.__ZSJG =string.Empty;
             this.__ZSXZ =string.Empty;
             this.__ZS_PD =string.Empty;
             this.__GXSXS100 =string.Empty;
             this.__GXSXS90 =string.Empty;
             this.__GXSXS80 =string.Empty;
             this.__GXSXSXZ =string.Empty;
             this.__GXSXS_PD =string.Empty;
             this.__LDWD =string.Empty;
             this.__LDDQY =string.Empty;
             this.__LDSD =string.Empty;
             this.__LD_PD =string.Empty;
             this.__LDYW =string.Empty;
             this.__HSU100 =string.Empty;
             this.__HSU90 =string.Empty;
             this.__HSU80 =string.Empty;
             this.__DSZS =string.Empty;
             this.__JSZDGLXDSD =string.Empty;
             this.__SCZDGLXDSD =string.Empty;
             this.__SMSJ =string.Empty;
             this.__CSSJ =string.Empty;
             this.__GL100 =string.Empty;
             this.__GL90 =string.Empty;
             this.__GL80 =string.Empty;
             this.__ZS100 =string.Empty;
             this.__ZS90 =string.Empty;
             this.__ZS80 =string.Empty;
             this.__KSSJ =string.Empty;
             this.__JSSJ =string.Empty;
             this.__NO100 =string.Empty;
             this.__NO90 =string.Empty;
             this.__NO80 =string.Empty;
             this.__NOXZ =string.Empty;
             this.__NO_PD =string.Empty;
             this.__HSUXZ =string.Empty;
             this.__HSU_PD =string.Empty;
             this.__KH80 =string.Empty;
             this.__MaxPower =string.Empty;
             this.__StopReason =string.Empty;
             this.__PT_GXSXS100 =string.Empty;
             this.__PT_GXSXS80 =string.Empty;
             this.__PT_NO80 =string.Empty;
             this.__PT_GLJG =string.Empty;
             this.__PT_LD_PD =string.Empty;
             this.__Changed["ID"] = false;
             this.__Changed["JCLSH"] = false;
             this.__Changed["LDJCCS"] = false;
             this.__Changed["GLJG"] = false;
             this.__Changed["GLXZ"] = false;
             this.__Changed["GL_PD"] = false;
             this.__Changed["ZSJG"] = false;
             this.__Changed["ZSXZ"] = false;
             this.__Changed["ZS_PD"] = false;
             this.__Changed["GXSXS100"] = false;
             this.__Changed["GXSXS90"] = false;
             this.__Changed["GXSXS80"] = false;
             this.__Changed["GXSXSXZ"] = false;
             this.__Changed["GXSXS_PD"] = false;
             this.__Changed["LDWD"] = false;
             this.__Changed["LDDQY"] = false;
             this.__Changed["LDSD"] = false;
             this.__Changed["LD_PD"] = false;
             this.__Changed["LDYW"] = false;
             this.__Changed["HSU100"] = false;
             this.__Changed["HSU90"] = false;
             this.__Changed["HSU80"] = false;
             this.__Changed["DSZS"] = false;
             this.__Changed["JSZDGLXDSD"] = false;
             this.__Changed["SCZDGLXDSD"] = false;
             this.__Changed["SMSJ"] = false;
             this.__Changed["CSSJ"] = false;
             this.__Changed["GL100"] = false;
             this.__Changed["GL90"] = false;
             this.__Changed["GL80"] = false;
             this.__Changed["ZS100"] = false;
             this.__Changed["ZS90"] = false;
             this.__Changed["ZS80"] = false;
             this.__Changed["KSSJ"] = false;
             this.__Changed["JSSJ"] = false;
             this.__Changed["NO100"] = false;
             this.__Changed["NO90"] = false;
             this.__Changed["NO80"] = false;
             this.__Changed["NOXZ"] = false;
             this.__Changed["NO_PD"] = false;
             this.__Changed["HSUXZ"] = false;
             this.__Changed["HSU_PD"] = false;
             this.__Changed["KH80"] = false;
             this.__Changed["MaxPower"] = false;
             this.__Changed["StopReason"] = false;
             this.__Changed["PT_GXSXS100"] = false;
             this.__Changed["PT_GXSXS80"] = false;
             this.__Changed["PT_NO80"] = false;
             this.__Changed["PT_GLJG"] = false;
             this.__Changed["PT_LD_PD"] = false;
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
         ///设置或获取类中的[LDJCCS]的数据
         /// </summary>
         public string LDJCCS
         {
              set{ __LDJCCS = value.Replace("'","’"); __Changed["LDJCCS"] = true;}
              get{return __LDJCCS;}
         }
         /// <summary>
         ///设置或获取类中的[GLJG]的数据
         /// </summary>
         public string GLJG
         {
              set{ __GLJG = value.Replace("'","’"); __Changed["GLJG"] = true;}
              get{return __GLJG;}
         }
         /// <summary>
         ///设置或获取类中的[GLXZ]的数据
         /// </summary>
         public string GLXZ
         {
              set{ __GLXZ = value.Replace("'","’"); __Changed["GLXZ"] = true;}
              get{return __GLXZ;}
         }
         /// <summary>
         ///设置或获取类中的[GL_PD]的数据
         /// </summary>
         public string GL_PD
         {
              set{ __GL_PD = value.Replace("'","’"); __Changed["GL_PD"] = true;}
              get{return __GL_PD;}
         }
         /// <summary>
         ///设置或获取类中的[ZSJG]的数据
         /// </summary>
         public string ZSJG
         {
              set{ __ZSJG = value.Replace("'","’"); __Changed["ZSJG"] = true;}
              get{return __ZSJG;}
         }
         /// <summary>
         ///设置或获取类中的[ZSXZ]的数据
         /// </summary>
         public string ZSXZ
         {
              set{ __ZSXZ = value.Replace("'","’"); __Changed["ZSXZ"] = true;}
              get{return __ZSXZ;}
         }
         /// <summary>
         ///设置或获取类中的[ZS_PD]的数据
         /// </summary>
         public string ZS_PD
         {
              set{ __ZS_PD = value.Replace("'","’"); __Changed["ZS_PD"] = true;}
              get{return __ZS_PD;}
         }
         /// <summary>
         ///设置或获取类中的[GXSXS100]的数据
         /// </summary>
         public string GXSXS100
         {
              set{ __GXSXS100 = value.Replace("'","’"); __Changed["GXSXS100"] = true;}
              get{return __GXSXS100;}
         }
         /// <summary>
         ///设置或获取类中的[GXSXS90]的数据
         /// </summary>
         public string GXSXS90
         {
              set{ __GXSXS90 = value.Replace("'","’"); __Changed["GXSXS90"] = true;}
              get{return __GXSXS90;}
         }
         /// <summary>
         ///设置或获取类中的[GXSXS80]的数据
         /// </summary>
         public string GXSXS80
         {
              set{ __GXSXS80 = value.Replace("'","’"); __Changed["GXSXS80"] = true;}
              get{return __GXSXS80;}
         }
         /// <summary>
         ///设置或获取类中的[GXSXSXZ]的数据
         /// </summary>
         public string GXSXSXZ
         {
              set{ __GXSXSXZ = value.Replace("'","’"); __Changed["GXSXSXZ"] = true;}
              get{return __GXSXSXZ;}
         }
         /// <summary>
         ///设置或获取类中的[GXSXS_PD]的数据
         /// </summary>
         public string GXSXS_PD
         {
              set{ __GXSXS_PD = value.Replace("'","’"); __Changed["GXSXS_PD"] = true;}
              get{return __GXSXS_PD;}
         }
         /// <summary>
         ///设置或获取类中的[LDWD]的数据
         /// </summary>
         public string LDWD
         {
              set{ __LDWD = value.Replace("'","’"); __Changed["LDWD"] = true;}
              get{return __LDWD;}
         }
         /// <summary>
         ///设置或获取类中的[LDDQY]的数据
         /// </summary>
         public string LDDQY
         {
              set{ __LDDQY = value.Replace("'","’"); __Changed["LDDQY"] = true;}
              get{return __LDDQY;}
         }
         /// <summary>
         ///设置或获取类中的[LDSD]的数据
         /// </summary>
         public string LDSD
         {
              set{ __LDSD = value.Replace("'","’"); __Changed["LDSD"] = true;}
              get{return __LDSD;}
         }
         /// <summary>
         ///设置或获取类中的[LD_PD]的数据
         /// </summary>
         public string LD_PD
         {
              set{ __LD_PD = value.Replace("'","’"); __Changed["LD_PD"] = true;}
              get{return __LD_PD;}
         }
         /// <summary>
         ///设置或获取类中的[LDYW]的数据
         /// </summary>
         public string LDYW
         {
              set{ __LDYW = value.Replace("'","’"); __Changed["LDYW"] = true;}
              get{return __LDYW;}
         }
         /// <summary>
         ///设置或获取类中的[HSU100]的数据
         /// </summary>
         public string HSU100
         {
              set{ __HSU100 = value.Replace("'","’"); __Changed["HSU100"] = true;}
              get{return __HSU100;}
         }
         /// <summary>
         ///设置或获取类中的[HSU90]的数据
         /// </summary>
         public string HSU90
         {
              set{ __HSU90 = value.Replace("'","’"); __Changed["HSU90"] = true;}
              get{return __HSU90;}
         }
         /// <summary>
         ///设置或获取类中的[HSU80]的数据
         /// </summary>
         public string HSU80
         {
              set{ __HSU80 = value.Replace("'","’"); __Changed["HSU80"] = true;}
              get{return __HSU80;}
         }
         /// <summary>
         ///设置或获取类中的[DSZS]的数据
         /// </summary>
         public string DSZS
         {
              set{ __DSZS = value.Replace("'","’"); __Changed["DSZS"] = true;}
              get{return __DSZS;}
         }
         /// <summary>
         ///设置或获取类中的[JSZDGLXDSD]的数据
         /// </summary>
         public string JSZDGLXDSD
         {
              set{ __JSZDGLXDSD = value.Replace("'","’"); __Changed["JSZDGLXDSD"] = true;}
              get{return __JSZDGLXDSD;}
         }
         /// <summary>
         ///设置或获取类中的[SCZDGLXDSD]的数据
         /// </summary>
         public string SCZDGLXDSD
         {
              set{ __SCZDGLXDSD = value.Replace("'","’"); __Changed["SCZDGLXDSD"] = true;}
              get{return __SCZDGLXDSD;}
         }
         /// <summary>
         ///设置或获取类中的[SMSJ]的数据
         /// </summary>
         public string SMSJ
         {
              set{ __SMSJ = value.Replace("'","’"); __Changed["SMSJ"] = true;}
              get{return __SMSJ;}
         }
         /// <summary>
         ///设置或获取类中的[CSSJ]的数据
         /// </summary>
         public string CSSJ
         {
              set{ __CSSJ = value.Replace("'","’"); __Changed["CSSJ"] = true;}
              get{return __CSSJ;}
         }
         /// <summary>
         ///设置或获取类中的[GL100]的数据
         /// </summary>
         public string GL100
         {
              set{ __GL100 = value.Replace("'","’"); __Changed["GL100"] = true;}
              get{return __GL100;}
         }
         /// <summary>
         ///设置或获取类中的[GL90]的数据
         /// </summary>
         public string GL90
         {
              set{ __GL90 = value.Replace("'","’"); __Changed["GL90"] = true;}
              get{return __GL90;}
         }
         /// <summary>
         ///设置或获取类中的[GL80]的数据
         /// </summary>
         public string GL80
         {
              set{ __GL80 = value.Replace("'","’"); __Changed["GL80"] = true;}
              get{return __GL80;}
         }
         /// <summary>
         ///设置或获取类中的[ZS100]的数据
         /// </summary>
         public string ZS100
         {
              set{ __ZS100 = value.Replace("'","’"); __Changed["ZS100"] = true;}
              get{return __ZS100;}
         }
         /// <summary>
         ///设置或获取类中的[ZS90]的数据
         /// </summary>
         public string ZS90
         {
              set{ __ZS90 = value.Replace("'","’"); __Changed["ZS90"] = true;}
              get{return __ZS90;}
         }
         /// <summary>
         ///设置或获取类中的[ZS80]的数据
         /// </summary>
         public string ZS80
         {
              set{ __ZS80 = value.Replace("'","’"); __Changed["ZS80"] = true;}
              get{return __ZS80;}
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
         ///设置或获取类中的[NO100]的数据
         /// </summary>
         public string NO100
         {
              set{ __NO100 = value.Replace("'","’"); __Changed["NO100"] = true;}
              get{return __NO100;}
         }
         /// <summary>
         ///设置或获取类中的[NO90]的数据
         /// </summary>
         public string NO90
         {
              set{ __NO90 = value.Replace("'","’"); __Changed["NO90"] = true;}
              get{return __NO90;}
         }
         /// <summary>
         ///设置或获取类中的[NO80]的数据
         /// </summary>
         public string NO80
         {
              set{ __NO80 = value.Replace("'","’"); __Changed["NO80"] = true;}
              get{return __NO80;}
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
         ///设置或获取类中的[NO_PD]的数据
         /// </summary>
         public string NO_PD
         {
              set{ __NO_PD = value.Replace("'","’"); __Changed["NO_PD"] = true;}
              get{return __NO_PD;}
         }
         /// <summary>
         ///设置或获取类中的[HSUXZ]的数据
         /// </summary>
         public string HSUXZ
         {
              set{ __HSUXZ = value.Replace("'","’"); __Changed["HSUXZ"] = true;}
              get{return __HSUXZ;}
         }
         /// <summary>
         ///设置或获取类中的[HSU_PD]的数据
         /// </summary>
         public string HSU_PD
         {
              set{ __HSU_PD = value.Replace("'","’"); __Changed["HSU_PD"] = true;}
              get{return __HSU_PD;}
         }
         /// <summary>
         ///设置或获取类中的[KH80]的数据
         /// </summary>
         public string KH80
         {
              set{ __KH80 = value.Replace("'","’"); __Changed["KH80"] = true;}
              get{return __KH80;}
         }
         /// <summary>
         ///设置或获取类中的[MaxPower]的数据
         /// </summary>
         public string MaxPower
         {
              set{ __MaxPower = value.Replace("'","’"); __Changed["MaxPower"] = true;}
              get{return __MaxPower;}
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
         ///设置或获取类中的[PT_GXSXS100]的数据
         /// </summary>
         public string PT_GXSXS100
         {
              set{ __PT_GXSXS100 = value.Replace("'","’"); __Changed["PT_GXSXS100"] = true;}
              get{return __PT_GXSXS100;}
         }
         /// <summary>
         ///设置或获取类中的[PT_GXSXS80]的数据
         /// </summary>
         public string PT_GXSXS80
         {
              set{ __PT_GXSXS80 = value.Replace("'","’"); __Changed["PT_GXSXS80"] = true;}
              get{return __PT_GXSXS80;}
         }
         /// <summary>
         ///设置或获取类中的[PT_NO80]的数据
         /// </summary>
         public string PT_NO80
         {
              set{ __PT_NO80 = value.Replace("'","’"); __Changed["PT_NO80"] = true;}
              get{return __PT_NO80;}
         }
         /// <summary>
         ///设置或获取类中的[PT_GLJG]的数据
         /// </summary>
         public string PT_GLJG
         {
              set{ __PT_GLJG = value.Replace("'","’"); __Changed["PT_GLJG"] = true;}
              get{return __PT_GLJG;}
         }
         /// <summary>
         ///设置或获取类中的[PT_LD_PD]的数据
         /// </summary>
         public string PT_LD_PD
         {
              set{ __PT_LD_PD = value.Replace("'","’"); __Changed["PT_LD_PD"] = true;}
              get{return __PT_LD_PD;}
         }
    }
}
