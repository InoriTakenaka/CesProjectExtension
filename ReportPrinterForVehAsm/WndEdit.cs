using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Infrastructure;
using Model;
using System.Windows.Forms;
using Core;

namespace ReportPrinterForVehAsm
{
    public partial class WndEdit : Form
    {
        RESULT_VEHICLE_INFO m_info;
        MSSqlAccess m_db;
        public WndEdit(string jclsh)
        {
            InitializeComponent();
            m_db = new MSSqlAccess(dbConfig.g_strConnectionStringSqlClient1);
            m_info = m_db.Find<RESULT_VEHICLE_INFO>("JCLSH", jclsh);
        }

        public void InitControls()
        {
            m_FDJGS.Text = m_info.FDJGS;
            m_FDJH.Text = m_info.FDJH;
            m_FDJSCQY.Text = m_info.FDJZZCS;
            m_FDJXH.Text = m_info.FDJXH;
            m_HCLLX.Text = m_info.PQHCLZZDH;
            m_HCLXH.Text = m_info.PQHCLZZ;
            m_GYFS.Text = m_info.GYFS;
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_info.FDJGS = m_FDJGS.Text;
            m_info.FDJH = m_FDJH.Text;
            m_info.FDJZZCS = m_FDJSCQY.Text;
            m_info.FDJXH = m_FDJXH.Text;
            m_info.PQHCLZZDH = m_HCLLX.Text;
            m_info.PQHCLZZ = m_HCLXH.Text;
            m_info.GYFS = m_GYFS.Text;
            m_db.Update(m_info, "JCLSH");
        }
    }
}
