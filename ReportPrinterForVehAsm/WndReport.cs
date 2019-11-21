using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core;
using Infrastructure;
using Model;

namespace ReportPrinterForVehAsm
{
    public partial class WndReport : Form
    {
        EPReport m_Report;
        public 
            WndReport(RESULT_VEHICLE_INFO vehicleInfo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += WndReport_FormClosing;
            if (vehicleInfo.JYXM.Contains("X"))
            {
                if (vehicleInfo.RLLBDH == "A" || vehicleInfo.RLLBDH == "E")
                {
                    m_Report = new GasolineReport(vehicleInfo.JCLSH);
                    m_Report.ResetReportData();
                    crystalReportViewer1.ReportSource = m_Report.ReportInstance();
                }
                else if (vehicleInfo.RLLBDH == "B")
                {
                    m_Report = new DieselReport(vehicleInfo.JCLSH);
                    m_Report.ResetReportData();
                    crystalReportViewer1.ReportSource = m_Report.ReportInstance();
                }
            }
            else
            {
                m_Report = new ObdReport(vehicleInfo.JCLSH);
                m_Report.ResetReportData();
                crystalReportViewer1.ReportSource = m_Report.ReportInstance();
            }
        }
        public void
            PrintReport(int Copies, string PrinterName = null)
        {
            if (m_Report != null)
                m_Report.OutputReport(Copies, PrinterName);
        }

         public void OutPutPdf(string filePath)
        {
            m_Report.ReportInstance().ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                filePath);
        }

        private void 
            WndReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Report != null)
            {
                m_Report.DocumentDestructor();
                m_Report = null;
            }
        }

		private void WndReport_Load(object sender, EventArgs e)
		{

		}
	}
}
