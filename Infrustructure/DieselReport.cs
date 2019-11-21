/*
 如果使用水晶报表10.5的dll 需要启用
 宏LEGACY_REPORT_DLL来编译项目
 */
using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Infrastructure
{
    public class DieselReport:EPReport
    {
        public 
            DieselReport(string JCLSH,string connectionString=null)
            : base(JCLSH,connectionString)
        {
            this.m_doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            m_doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"/rpt/HB_XX_CY_REPORT.rpt");
#if LEGACY_REPORT_DLL
            for (int i = 0; i < m_doc.ParameterFields.Count; i++)
                m_doc.ParameterFields[i].CurrentValues.AddValue("");
#endif
            m_docReady = true;
        }

        //private string GetJobjectValue(JObject JData, string jKey)
        //{

        //    try
        //    {
        //        return JData["vehicleData"][jKey].ToString();
        //    }
        //    catch(Exception ex)
        //    {
        //        PUBControl.SYS_LOG.write_log("Report.log", "取基本信息:"+jKey +"，不存在"+ex.Message);
        //        return "";
        //    }
        //}
        protected override void 
            FillReportBaseInfo()
        {
            try
            { 
                Add("JCLSH", m_vehInfo.JCLSH);
                Add("WQLSH", m_vehInfo.WQLSH);
                Add("JCRQ", m_vehInfo.CLXXSJ);
                Add("CLZL", m_vehInfo.CLZL);
                Add("VIN", m_vehInfo.VIN);
                Add("CLZZCS", m_vehInfo.CLZZCS);
                Add("FDJXH", m_vehInfo.FDJXH);
                Add("FDJH", m_vehInfo.FDJH);
                Add("FDJPL", m_vehInfo.FDJPL);
                Add("FDJGS", m_vehInfo.FDJGS);
                Add("GYFS", m_vehInfo.GYFS);
                Add("EDGL", m_vehInfo.EDGL);
                Add("EDZS", m_vehInfo.EDZS);
                Add("ZBZL", m_vehInfo.ZBZL);
                Add("ZZL", m_vehInfo.ZZL);
                //Add("FDJZZCS", m_vehInfo.FDJZZCS);
                Add("DDJXH", m_vehInfo.DDJXH);
                Add("DCRL", m_vehInfo.DCRL);           
                Add("CNZZXH", m_vehInfo.CNZZXH);
                Add("OBDWZ", m_vehInfo.OBDWZ);
                if(m_vehInfo.JYXM.IndexOf ("X")>=0)
                {
                    Add("YCY", m_vehInfo.WQYCY);
                }
                else
                {
                    Add("YCY", m_vehInfo.YCY);
                }
               
                Add("OBDWZ", m_vehInfo.OBDWZ);
                Add("OBDJYY", m_vehInfo.WQYCY);
                Add("WQYCY", m_vehInfo.WQYCY);
                // Add("DPFXH", "国六");
                Add("PFJD", m_vehInfo.CLPFJD);
                Add("HCLLX","");
                Add("HCLXH", "");
                Add("FDJSCQY", m_vehInfo.FDJZZCS);
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

                //填充ECU相关的数据
              if(m_obd.ECUInfo !="")
                {

                }

                //填充实时数据
                if (m_obd.RTData != "")
                {

                }


#if DEBUG_RPT 

                Add("FDJ_CALID", m_obd.FDJ_CALID);
                Add("HCLZZ_CALID", m_obd.HCLZZ_CALID);
                Add("QTKZDY_CALID", m_obd.QTKZDY_CALID);

                Add("FDJ_CVN", m_obd.FDJ_CVN);
                Add("HCLZZ_CVN", m_obd.HCLZZ_CVN);
                Add("QTKZDY_CVN", m_obd.QTKZDY_CVN);

                m_obd.OBD_PD = m_obd.OBD_PD.Replace("合格", "通过");

                Add("OBD_PD", m_obd.OBD_PD);

                if(m_obd.OBD_PD=="不通过")
                {
                    Add("TX_PD", "否");
                }
                else
                {
                    Add("TX_PD", "是");
                }
#endif
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
                #region enviroment & result data
                if (m_zyjs != null)
                {
                    Add("HJWD", m_zyjs.ZYJSWD);
                    Add("HJDQY", m_zyjs.ZYJSDQY);
                    Add("HJSD", m_zyjs.ZYJSSD);

                    if (m_zyjs.ZYJSXZ==null || m_zyjs.ZYJSXZ=="")
                    {
                        m_vehInfo.EDZS = "";
                    }

                    Add("ZYJS_RPM", m_vehInfo.EDZS);
                    Add("ZYJS_ZYJSDSZS", m_zyjs.ZYJSDSZS);
                    //Add("ZYJS_ZYJSJG1", m_zyjs.ZYJSJG1);
                    Add("ZYJS_ZYJSJG2", m_zyjs.ZYJSJG1);
                    Add("ZYJS_ZYJSJG3", m_zyjs.ZYJSJG2);
                    Add("ZYJS_ZYJSJG4", m_zyjs.ZYJSJG3);
                    Add("ZYJS_ZYJSPJZ", m_zyjs.ZYJSPJZ);
                    Add("ZYJS_ZYJSXZ", m_zyjs.ZYJSXZ);
                    Add("WQ_PD",GetJudgeText( m_zyjs.ZYJS_PD));
                   
                }
                if (m_ld != null)
                {
                    Add("HJWD", m_ld.LDWD);
                    Add("HJDQY", m_ld.LDDQY);
                    Add("HJSD", m_ld.LDSD);
                    Add("LGDN_RPM", m_ld.ZSJG);
                    Add("LGDN_GLJG", m_ld.GLJG);
                    Add("LGDN_GLXZ", m_ld.GLXZ);
                    Add("LGDN_SCZDGLXDSD", m_ld.SCZDGLXDSD);
                    Add("LGDN_GXSXS100", m_ld.GXSXS100);
                    Add("LGDN_HSU100", m_ld.HSU100);
                    Add("LGDN_HSU80", m_ld.HSU80);
                    Add("LGDN_GXSXS80", m_ld.GXSXS80);
                    Add("LGDN_GXSXSXZ", m_ld.GXSXSXZ);
                    Add("LGDN_NO80", m_ld.NO80);
                    Add("LGDN_NOXZ", m_ld.NOXZ);
                    Add("WQ_PD", GetJudgeText(m_ld.LD_PD));
                 
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
