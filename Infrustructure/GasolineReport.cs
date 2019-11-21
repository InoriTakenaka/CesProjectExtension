/*
 如果使用水晶报表10.5的dll 需要启用
 宏LEGACY_REPORT_DLL来编译项目
 */
using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Model;
using PUBControl;

namespace Infrastructure
{
     public class GasolineReport:EPReport
    {
         public
             GasolineReport(string JCLSH, string connectionString = null)
             : base(JCLSH, connectionString)
         {
             this.m_doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
             m_doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"/rpt/HB_XX_QY_REPORT.rpt");
#if LEGACY_REPORT_DLL
             for (int i = 0; i < m_doc.ParameterFields.Count; i++)
                 m_doc.ParameterFields[i].CurrentValues.AddValue("");
#endif
             m_docReady = true;
         }

         protected override void 
             FillReportBaseInfo()
         {
             if (m_vehInfo == null) throw  new ArgumentNullException();
             try
             {
                 Add("JCLSH",m_vehInfo.JCLSH);
                 Add("JCRQ",m_vehInfo.CLSXSJ);
                 Add("CLZL", m_vehInfo.CLZL);
                 Add("CLZZCS", m_vehInfo.CLZZCS);
                 Add("BSXLX", m_vehInfo.BSXLX);
                 Add("ZBZL", m_vehInfo.ZBZL);
                 Add("FDJXH", m_vehInfo.FDJXH);
                 Add("FDJZZCS", m_vehInfo.FDJZZCS);
                 Add("FDJGS", m_vehInfo.FDJGS);
                 Add("DDJXH", m_vehInfo.DDJXH);
                 Add("DCRL", m_vehInfo.DCRL);

                 Add("VIN", m_vehInfo.VIN);
                 Add("DPFXH", m_vehInfo.CLPFJD);
                 Add("CHZHQQK", m_vehInfo.CHZHQQK);
                 Add("ZZL", m_vehInfo.ZZL);
                 Add("FDJH", m_vehInfo.FDJH);
                 Add("FDJPL", m_vehInfo.FDJPL);
                 Add("GYFS", m_vehInfo.GYFS);
                 Add("CNZZXH", m_vehInfo.CNZZXH);
                 Add("OBDWZ", m_vehInfo.OBDWZ);
                 Add("YCY", m_vehInfo.YCY);
                 Add("OBDJYY", m_vehInfo.OBDJYY);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         protected override void 
             FillOBDInspect()
         {
             try
             {
                string strFDJ_CALID = "";
                string strFDJ_CVN = "";
                string strHCLZZ_CALID = "";
                string strQTKZDY_CALID = "";

                if(m_obd.ECUInfo !="")
                {
                    int strLEN = m_obd.ECUInfo.IndexOf("<response>");
                    int strEND = m_obd.ECUInfo.IndexOf("</response>");
                    string strECUInfo = m_obd.ECUInfo;

                    if (strLEN > 0 && strEND > 0)
                    {
                        strECUInfo = strECUInfo.Substring(strLEN, strEND - strLEN + 11);
                    }

                   System.Data.DataSet   dsEcuInfo = XmlDatasetConvert.ConvertXMLToDataSet(strECUInfo);
                   strFDJ_CALID = GetXmlValue(dsEcuInfo, "data", "CALID");
                   strFDJ_CVN = GetXmlValue(dsEcuInfo, "data", "CVN");
                   strHCLZZ_CALID = GetXmlValue(dsEcuInfo, "data", "SCRCALID");
                   strHCLZZ_CALID = GetXmlValue(dsEcuInfo, "data", "SCRCVN");

                   Add("FDJ_CALID", strFDJ_CALID);
                   Add("FDJ_CVN", strFDJ_CVN);
                   Add("HCLZZ_CALID", strHCLZZ_CALID);
                   Add("HCLZZ_CVN", strFDJ_CVN);
                }


                if (m_obd.RTData != "")
                {
                    int strLEN = m_obd.RTData.IndexOf("<response>");
                    int strEND = m_obd.RTData.IndexOf("</response>");
                    string strRTData = "";
                    if (strLEN > 0 && strEND > 0)
                    {
                        strRTData = m_obd.RTData.Substring(strLEN, strEND - strLEN + 11).Replace("=",string.Empty).Replace("\"",string.Empty);
                    }

                    System.Data.DataSet dsRTData = XmlDatasetConvert.ConvertXMLToDataSet(strRTData);
                }
                Add("TX_PD", GetJudgeText(m_obd.TX_PD));
                Add("OBD_PD", GetJudgeText(m_obd.ALL_PD));
                //Add("FDJ_CALID", m_obd.FDJ_CALID);
                // Add("HCLZZ_CALID", m_obd.HCLZZ_CALID);
                // Add("QTKZDY_CALID", m_obd.QTKZDY_CALID);

                // Add("FDJ_CVN", m_obd.FDJ_CVN);
                // Add("HCLZZ_CVN", m_obd.HCLZZ_CVN);
                // Add("QTKZDY_CVN", m_obd.QTKZDY_CVN);
                // Add("OBD_PD", m_obd.OBD_PD);
            }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         protected override void 
             FillDevInfo()
         {
             try
             {
                 string FXYSCQY = string.Empty,
                            FXYMC = string.Empty,
                            DPCGJSCQY = string.Empty,
                            DPCGJXH = string.Empty,
                            OBDSCQY = string.Empty,
                            OBDXH = string.Empty;

                 foreach (var e in m_dev)
                 {
                     string sbmcdh = e.SBMCDH;
                     switch (sbmcdh)
                     {
                         case INSTRU.CGJ:
                             {
                                 DPCGJSCQY = e.SBZZC;
                                 DPCGJXH = e.SBXH;
                             }
                             break;
                         case INSTRU.FXY:
                             {
                                 FXYSCQY = e.SBZZC;
                                 FXYMC = e.SBMC;
                             }
                             break;
                         case INSTRU.OBD:
                             {
                                 OBDSCQY = e.SBZZC;
                                 OBDXH = e.SBXH;
                             } break;
                     }
                 }

                 Add("FXYSCQY", FXYSCQY);
                 Add("FXYMC", FXYMC);
                 Add("DPCGJSCQY", DPCGJSCQY);
                 Add("DPCGJXH", DPCGJXH);
                 Add("OBDSCQY", OBDSCQY);
                 Add("OBDXH", OBDXH);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         protected override void 
             FillReportData()
         {
             try
             {
                 if (m_vmas != null)
                 {
                     Add("VMAS_HCJG", m_vmas.HCJG=="0"?"未检出":m_vmas.HCJG);
                     Add("VMAS_COJG", m_vmas.COJG == "0" ? "未检出" : m_vmas.COJG);
                     Add("VMAS_NOJG", m_vmas.NOJG == "0" ? "未检出" : m_vmas.NOJG);
                     Add("VMAS_COXZ", m_vmas.COXZ);
                     Add("VMAS_HCXZ", m_vmas.HCXZ);
                     Add("VMAS_NOXZ", m_vmas.NOXZ);
                     Add("WQ_PD", GetJudgeText(m_vmas.VMAS_PD));

                     Add("HJWD", m_vmas.WD);
                     Add("HJDQY", m_vmas.DQY);
                     Add("HJSD", m_vmas.SD);
                 }
                 if (m_asm != null)
                 {
                     Add("ASM_HC5025JG", m_asm.HC5025JG == "0" ? "未检出" : m_asm.HC5025JG);
                     Add("ASM_CO5025JG", m_asm.CO5025JG == "0" ? "未检出" : m_asm.CO5025JG);
                     Add("ASM_NO5025JG", m_asm.NO5025JG == "0" ? "未检出" : m_asm.NO5025JG);
                     Add("ASM_HC2540JG", m_asm.HC2540JG == "0" ? "未检出" : m_asm.HC2540JG);
                     Add("ASM_CO2540JG", m_asm.CO2540JG == "0" ? "未检出" : m_asm.CO2540JG);
                     Add("ASM_NO2540JG", m_asm.NO2540JG == "0" ? "未检出" : m_asm.NO2540JG);
                     Add("ASM_HC5025XZ", m_asm.HC5025XZ);
                     Add("ASM_CO5025XZ", m_asm.CO5025XZ);
                     Add("ASM_NO5025XZ", m_asm.NO5025XZ);
                     Add("ASM_HC2540XZ", m_asm.HC2540XZ);
                     Add("ASM_CO2540XZ", m_asm.CO2540XZ);
                     Add("ASM_NO2540XZ", m_asm.NO2540XZ);

                     Add("HJWD", m_asm.ASMWD);
                     Add("HJDQY", m_asm.ASMDQY);
                     Add("HJSD", m_asm.ASMSD);
                     Add("WQ_PD", GetJudgeText(m_asm.ASM_PD));
                 }
                 if (m_sds != null)
                 {
                     Add("HJWD", m_sds.SDSWD);
                     Add("HJDQY", m_sds.SDSDQY);
                     Add("HJSD", m_sds.SDSSD);

                     Add("SDS_GLKQXS", m_sds.GLKQXS);
                     Add("SDS_GLKQXSSX", m_sds.GLKQXSSX);
                     Add("SDS_GLKQXSXX", m_sds.GLKQXSXX);
                     Add("SDS_DSCO", m_sds.DSCO == "0" ? "未检出" : m_sds.DSCO);
                     Add("SDS_DSHC", m_sds.DSHC == "0" ? "未检出" : m_sds.DSHC);
                     Add("SDS_GDSCOXZ", m_sds.GDSCOXZ);
                     Add("SDS_GDSHCXZ", m_sds.GDSHCXZ);
                     Add("SDS_GDSCO", m_sds.GDSCO == "0" ? "未检出" : m_sds.GDSCO);
                     Add("SDS_GDSHC", m_sds.GDSHC == "0" ? "未检出" : m_sds.GDSHC);
                     Add("SDS_DSCOXZ", m_sds.DSCOXZ);
                     Add("SDS_DSHCXZ", m_sds.DSHCXZ);
                     Add("SDS_DSCO_PD", m_sds.DSCO_PD);
                     Add("SDS_DSHC_PD", m_sds.DSHC_PD);
                     Add("WQ_PD", GetJudgeText(m_sds.SDS_PD));
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
    }
}
