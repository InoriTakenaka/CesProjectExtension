using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Infrastructure
{
    public class ObdReport:EPReport
    {
        private const string CHECK = "√";
        public ObdReport(string JCLSH, string connectionString = null)
            : base(JCLSH, connectionString)
        {
            this.m_doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            m_doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"/rpt/HB_XX_OBD_REPORT.rpt");
#if LEGACY_REPORT_DLL
            for (int i = 0; i < m_doc.ParameterFields.Count; i++)
                m_doc.ParameterFields[i].CurrentValues.AddValue("");
#endif
            m_docReady = true;
        }

        protected override void
            FillReportBaseInfo()
        {
            Add("VIN", m_vehInfo.VIN);

            string ECU = m_obd.ECUInfo.Replace("=",string.Empty).Replace("\"",string.Empty);
            DataSet ecu = PUBControl.XmlDatasetConvert.ConvertXMLToDataSet(ECU);
            string ecu_calId = "", sub_calId = "",ecu_cvn = "", sub_cvn = "",
                scr_calId = "",scr_cvn = "",
                qt_calId = "", qt_cvn = "",sub_qt_calId="",sub_qt_cvn="";
            int i = 0;
            do
            {
                ecu_calId += sub_calId + ";";
                if (i == 0)
                    sub_calId = GetXmlValue(ecu, "data", "CALID");
                else
                    sub_calId = GetXmlValue(ecu, "data", "CALID{0}".FormatWith(i));
                i++;
            } while (sub_calId.IsEffective());
            i = 0;
            do
            {
                ecu_cvn += sub_cvn + ";";
                if (i == 0)
                    sub_cvn = GetXmlValue(ecu, "data", "CVN");
                else
                    sub_cvn = GetXmlValue(ecu, "data", "CVN{0}".FormatWith(i));
                i++;
            } while (sub_cvn.IsEffective());
            i = 0;

            scr_calId = GetXmlValue(ecu, "data", "SCRCALID");
            scr_cvn = GetXmlValue(ecu, "data", "SCRCVN");

            do
            {
                qt_calId += sub_qt_calId + ";";
                if (i == 0)
                    sub_qt_calId = GetXmlValue(ecu, "data", "qtCALID");
                else
                    sub_qt_calId = GetXmlValue(ecu, "data", "qtCALID{0}".FormatWith(i));
                i++;
            } while (sub_qt_calId.IsEffective());
            i = 0;

            do
            {
                qt_cvn += sub_qt_cvn + ";";
                if (i == 0)
                    sub_qt_cvn = GetXmlValue(ecu, "data", "qtCVN");
                else
                    sub_qt_cvn = GetXmlValue(ecu, "data", "qtCVN{0}".FormatWith(i));
                i++;
            } while (sub_qt_cvn.IsEffective());

            if (m_obd.TX_PD == "1") { Add("Y_GZ", CHECK); Add("IS_TX", CHECK); }
            else if (m_obd.TX_PD == "2") Add("N_GZ", CHECK);
            if (m_obd.TX_BHGYY == "1") Add("N_TX_1", CHECK);
            else if (m_obd.TX_BHGYY == "2") Add("N_TX_2", CHECK);
            else if (m_obd.TX_BHGYY == "3") Add("N_TX_3", CHECK);
            if (m_obd.TX_GZDZT == "1") Add("Y_GZD", CHECK);
            else if (m_obd.TX_GZDZT == "2") Add("N_GZD", CHECK);

            string state = m_obd.RTData.Replace("=",string.Empty).Replace("\"",string.Empty);
            DataSet rt = PUBControl.XmlDatasetConvert.ConvertXMLToDataSet(state);
            string mileage = GetXmlValue(rt, "data", "Mileage");

            Add("FDJ_CALID", ecu_calId.TrimEnd(';').TrimStart(';'));
            Add("FDJ_CVN", ecu_cvn.TrimEnd(';').TrimStart(';'));
            Add("HCLZZ_CALID", scr_calId.TrimEnd(';').TrimStart(';'));
            Add("HCLZZ_CVN", scr_cvn.TrimEnd(';').TrimStart(';'));
            Add("QTKZDY_CALID", qt_calId.TrimEnd(';').TrimStart(';'));
            Add("QTKZDY_CVN", qt_cvn.TrimEnd(';').TrimStart(';'));
            Add("MILEAGE", mileage);
            // 就绪状态未完成项目 先默认无
            Add("N_OBD_GZ", CHECK);

            if (m_obd.ALL_PD == "1") { Add("Z_PD_1", CHECK); Add("FJ_Y", CHECK); }
            else if (m_obd.ALL_PD == "2") { Add("Z_PD_2", CHECK); Add("FJ_N", CHECK); }
        }

        protected override void 
            FillOBDInspect()
        {
            return;
        }

        protected override void 
            FillDevInfo()
        {
            return;
        }

        protected override void 
            FillReportData()
        {
            return;
        }
    }

   
}
