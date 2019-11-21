/*
 如果使用水晶报表10.5的dll 需要启用
 宏LEGACY_REPORT_DLL来编译项目
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Core;
using Model;
using BLL;

namespace Infrastructure
{
    public abstract class EPReport
    {
        protected ReportDocument m_doc;
        protected int m_docType;
        protected RESULT_VEHICLE_INFO m_vehInfo;
        protected RESULT_ASM m_asm;
        protected RESULT_SDS m_sds;
        protected RESULT_LD m_ld;
        protected RESULT_ZYJS m_zyjs;
        protected RESULT_VMAS m_vmas;
        //protected RESULT_HB_OBD m_obd;
        protected RESULT_OBD m_obd;
        protected List<INSPECTION_DEV_REG_INFO> m_dev;
        protected int m_devID;
        protected bool m_docReady;

        protected void
            Add(string Key, object Value)
        {
#if LEGACY_REPORT_DLL
            try
            {
               m_doc.ParameterFields[Key].CurrentValues.Clear();
               m_doc.ParameterFields[Key].CurrentValues.AddValue(Value);
            }
            catch (Exception ex)
            {
                PUBControl.SYS_LOG.write_log("report.log", "EXCEPTION: key -> {0}\r\n msg -> {1}\r\n call stack -> {2}"
                    .FormatWith(Key, ex.Message, ex.StackTrace));
            }
#else
           m_doc.SetParameterValue(Key, Value);
#endif
        }
        public virtual void
            OutputReport(int Copies, string PrinterName = null)
        {
            string _printerName = string.Empty;
            PrintDocument printer = new PrintDocument();
            if (PrinterName == null) _printerName = printer.PrinterSettings.PrinterName;
            else _printerName = PrinterName;
            if (!m_docReady) return;
            // m_doc.PrintOptions.ApplyPageMargins(margin);
            m_doc.PrintOptions.PrinterName = _printerName;
            m_doc.PrintToPrinter(1, false, 0, 0);
        }
        public void
            ResetReportData(){
            FillReportBaseInfo();
            FillOBDInspect();
            FillDevInfo();
            FillReportData();
        }

        #region  填充数据
        protected abstract void
            FillReportBaseInfo();
        protected abstract void
            FillOBDInspect();
        protected abstract void
            FillDevInfo();
        protected abstract void
            FillReportData();
        #endregion

        protected virtual void
            InitData(string JCLSH, string connectionString = null)
        {
            RESULT_VEHICLE_INFO_BLL bllVehicleInfo = new RESULT_VEHICLE_INFO_BLL();
            m_vehInfo = bllVehicleInfo.GetModel(JCLSH);
            INSPECTION_DEV_REG_INFO_BLL bllDev = new INSPECTION_DEV_REG_INFO_BLL();
            var arrDevs = bllDev.GetModelList(string.Format(" JCXH = '{0}' ", m_vehInfo.JCXH));
            m_dev = new List<INSPECTION_DEV_REG_INFO>();
            foreach (var dev in arrDevs) { m_dev.Add(dev); }
            RESULT_OBD_BLL bllOBD = new RESULT_OBD_BLL();
            RESULT_OBD[] obds = bllOBD.GetModelList("JCLSH='{0}'".FormatWith(JCLSH));
            if (obds.Length > 0)
                m_obd = obds[0];
            else m_obd = null;
            if (m_vehInfo.RLLBDH == "A" || m_vehInfo.RLLBDH == "E")
            {
                if (m_vehInfo.JYXM.Contains("X2"))
                {
                    RESULT_ASM_BLL bllASM = new RESULT_ASM_BLL();
                    m_asm = bllASM.GetModel(JCLSH);
                }
                if (m_vehInfo.JYXM.Contains("X1"))
                {
                    RESULT_SDS_BLL bllSDS = new RESULT_SDS_BLL();
                    m_sds = bllSDS.GetModel(JCLSH);
                }
                if (m_vehInfo.JYXM.Contains("X3"))
                {
                    RESULT_VMAS_BLL bllVMAS = new RESULT_VMAS_BLL();
                    m_vmas = bllVMAS.GetModel(JCLSH);
                }
                m_ld = null;
                m_zyjs = null;
            }
            else if (m_vehInfo.RLLBDH == "B")
            {
                if (m_vehInfo.JYXM.Contains("X4"))
                {
                    RESULT_LD_BLL bllLD = new RESULT_LD_BLL();
                    m_ld = bllLD.GetModel(JCLSH);
                }
                if (m_vehInfo.JYXM.Contains("X5"))
                {
                    RESULT_ZYJS_BLL bllZYJS = new RESULT_ZYJS_BLL();
                    m_zyjs = bllZYJS.GetModel(JCLSH);
                }
                m_asm = null;
                m_sds = null;
                m_vmas = null;
            }
        }
        
        public
            EPReport(string JCLSH, string connectionString = null)
        {
            try
            {
                InitData(JCLSH, connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            m_doc = null;
            m_docReady = false;
        }
        public
            ReportDocument ReportInstance()
        {
            return m_doc;
        }
        public void
            DocumentDestructor()
        {
            m_doc.Close();
            m_doc.Dispose();
            m_doc = null;
            m_vehInfo = null;
            m_asm = null;
            m_sds = null;
            m_ld = null;
            m_zyjs = null;
            m_docReady = false;
            m_obd = null;
            m_dev = null;
        }
        protected string
            GetJudgeText(string PD)
        {
            if (PD == "1")
            {
                return "合格";
            }
            else if (PD == "2")
            {
                return "不合格";
            }
            else return string.Empty;
        }
        protected string 
            GetXmlValue(System.Data.DataSet origin, string section, string key)
        {
            string val = "";
            if (origin.Tables.Contains(section))
            {
                System.Data.DataTable dt = origin.Tables[section];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string field = dt.Columns[i].ColumnName;
                        if (field == key)
                        {
                            val = dt.Rows[0][field].ToString();
                            break;
                        }
                    }
                }
            }
            return val;
        }
    }
}
