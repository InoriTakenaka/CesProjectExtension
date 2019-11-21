using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using NPOI.HSSF.UserModel;
//using NPOI.SS.UserModel;
using Core;
using Infrastructure;
using Model;
using BLL;

namespace ReportPrinterForVehAsm
{
    public partial class WndMain : Form
    {
        const int PAGE_SIZE = 15;
        private int m_CurrentPage = 1;
        private RESULT_VEHICLE_INFO[] m_resultList;
        private Boolean m_canEdit;
        public 
            WndMain(Boolean CanEdit)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.startTime.Format = DateTimePickerFormat.Custom;
            this.startTime.CustomFormat = "yyyy-MM-dd";
            this.endTime.Format = DateTimePickerFormat.Custom;
            this.endTime.CustomFormat = "yyyy-MM-dd";
            m_canEdit = CanEdit;
        }
        protected void 
            Search()
        {
            //DbAccess db;
            //if (m_connectionString.IsEffective()) db = new DbAccess(m_connectionString, false);
            //else db = new DbAccess();

            string VIN = txtVIN.Text.Trim();
            string condition = "";
            if (VIN.IsEffective())
            {
                condition = "AND (VIN LIKE '%{0}%')".FormatWith(VIN);
            }
            condition += @"AND ( CONVERT( VARCHAR(10),CLXXSJ,120)  >= CONVERT( VARCHAR(10),'{0}',120 ) ) ".FormatWith(startTime.Text);
            condition += @"AND ( CONVERT( VARCHAR(10),CLXXSJ,120 ) <= CONVERT( VARCHAR(10),'{0}',120 ) )".FormatWith(endTime.Text);
            RESULT_VEHICLE_INFO_BLL bllVehicleInfo = new RESULT_VEHICLE_INFO_BLL();
//            string query = string.Format(@" SELECT * 
//                                                                       FROM (
//                                                                       SELECT ROW_NUMBER() OVER (ORDER BY ID DESC) AS ROWID,* 
//                                                                       FROM RESULT_VEHICLE_INFO 
//                                                                       WHERE CHARINDEX('X',JYXM)<>'0'{0} ) AS B
//                                                                       WHERE ROWID BETWEEN {1} AND {2}",
//                                                                      condition, m_CurrentPage == 1 ? 1 : (m_CurrentPage - 1) * PAGE_SIZE, m_CurrentPage * PAGE_SIZE);
            string query = string.Format("( CHARINDEX('X',JYXM)<>'0' or  CHARINDEX('O',JYXM)<>'0')  {0} ", condition);

            m_resultList = bllVehicleInfo.GetModelList(query, m_CurrentPage, 20);
            //List<RESULT_VEHICLE_INFO> LstVehs = new List<RESULT_VEHICLE_INFO>();
            if (m_resultList == null || m_resultList.Length == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }


            foreach (RESULT_VEHICLE_INFO veh in m_resultList)
            {
                //RESULT_VEHICLE_INFO info = new RESULT_VEHICLE_INFO();
                //string hb = Get_HB_JYXM(veh.JYXM);             
                //switch (hb)
                //{
                //    case "X1":
                //        veh.JYXM = ISPMSD.X1;
                //        break;					
                //        //ASM
                //    case "X2":
                //        veh.JYXM = ISPMSD.X2;
                //        break;
                //        //VMAS
                //    case "X3":
                //        veh.JYXM = ISPMSD.X3;

                //        break;
                //    case "X4":
                //        veh.JYXM = ISPMSD.X4;
                //        break;
                //    case "X5": veh.JYXM = ISPMSD.X5;
                //        break;
                //    case "X6": veh.JYXM = ISPMSD.X6;
                //        break;
                //}
                if (veh.Z_PD == "1")
                    veh.Z_PD = "合格";
                else if (veh.Z_PD == "2")
                    veh.Z_PD = "不合格";
            }


            this.dataGridView1.DataSource = m_resultList;
        }
        private void 
            btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void 
            dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenReportViewer();
        }
        void 
            OpenReportViewer()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    RESULT_VEHICLE_INFO vehicleInfo =
                        dataGridView1.CurrentRow.DataBoundItem as RESULT_VEHICLE_INFO;

                    if (m_canEdit)
                    {
                        DialogResult dialogResult = MessageBox.Show("需要增补车辆基本信息吗？", "Attetion",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            WndEdit wndEdit = new WndEdit(vehicleInfo.JCLSH) { ControlBox = false, FormBorderStyle = FormBorderStyle.FixedSingle };
                            wndEdit.ShowDialog();
                        }
                    }


                    WndReport reportViewer = new WndReport(vehicleInfo);
                    reportViewer.Show();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SearchAndPrint(string jclsh)
        {
            try
            {
                string query = "   ( CHARINDEX('X',JYXM)<>'0' or  CHARINDEX('O',JYXM)<>'0') and  jclsh='" + jclsh + "'";

                RESULT_VEHICLE_INFO_BLL bllVehicleInfo = new RESULT_VEHICLE_INFO_BLL();
                RESULT_VEHICLE_INFO[] lstVehs = bllVehicleInfo.GetModelList(query, 0, 2);

                if (lstVehs == null || lstVehs.Length == 0)
                {
                    PUBControl.SYS_LOG.write_log("PrintReport.log", "未找到" + jclsh);
                    return;
                }


                foreach (RESULT_VEHICLE_INFO veh in lstVehs)
                {
                    string hb = Get_HB_JYXM(veh.JYXM);
                    switch (hb)
                    {
                        case "X1":
                            veh.JYXM = ISPMSD.X1;
                            break;

                        //ASM
                        case "X2":
                            veh.JYXM = ISPMSD.X2;

                            break;
                        //VMAS
                        case "X3":
                            veh.JYXM = ISPMSD.X3;

                            break;
                        case "X4":
                            veh.JYXM = ISPMSD.X4;
                            break;
                        case "X5":
                            veh.JYXM = ISPMSD.X5;
                            break;
                        case "X6":
                            veh.JYXM = ISPMSD.X6;
                            break;
                    }


                    if (veh.Z_PD == "1")
                        veh.Z_PD = "合格";
                    else if (veh.Z_PD == "2")
                        veh.Z_PD = "不合格";
                }

                 
                WndReport reportViewer = new WndReport(lstVehs[0]);
               // reportViewer.Show();
               // System.Threading.Thread.Sleep(1000);
                reportViewer.PrintReport(0, null);
                reportViewer.Close();

            }
            catch (Exception ex)
            {
                PUBControl.SYS_LOG.write_log("PrintReport.log", "自动打印：" + ex.Message);
            }


        }



        /// <summary>
        /// 导出报告单
        /// </summary>
        /// <param name="jclsh"></param>
        public void SearchAndOutPut(string jclsh)
        {
            try
            {
                string query = "   ( CHARINDEX('X',JYXM)<>'0' or  CHARINDEX('O',JYXM)<>'0') and  jclsh='" + jclsh + "'";

                RESULT_VEHICLE_INFO_BLL bllVehicleInfo = new RESULT_VEHICLE_INFO_BLL();
                RESULT_VEHICLE_INFO[] lstVehs = bllVehicleInfo.GetModelList(query, 0, 2);

                if (lstVehs == null || lstVehs.Length == 0)
                {
                    PUBControl.SYS_LOG.write_log("PrintReport.log", "未找到" + jclsh);
                    return;
                }
                
                foreach (RESULT_VEHICLE_INFO veh in lstVehs)
                {
                    string hb = Get_HB_JYXM(veh.JYXM);
                    switch (hb)
                    {
                        case "X1":
                            veh.JYXM = ISPMSD.X1;
                            break;

                        //ASM
                        case "X2":
                            veh.JYXM = ISPMSD.X2;

                            break;
                        //VMAS
                        case "X3":
                            veh.JYXM = ISPMSD.X3;

                            break;
                        case "X4":
                            veh.JYXM = ISPMSD.X4;
                            break;
                        case "X5":
                            veh.JYXM = ISPMSD.X5;
                            break;
                        case "X6":
                            veh.JYXM = ISPMSD.X6;
                            break;
                    }


                    if (veh.Z_PD == "1")
                        veh.Z_PD = "合格";
                    else if (veh.Z_PD == "2")
                        veh.Z_PD = "不合格";
                }
                WndReport reportViewer = new WndReport(lstVehs[0]);
                // reportViewer.Show();
                // System.Threading.Thread.Sleep(1000);
                reportViewer.OutPutPdf(System.IO.Directory.GetParent(Application.StartupPath).FullName + "\\data\\" +
                    jclsh + ".pdf");

                reportViewer.Close();

            }
            catch (Exception ex)
            {
                PUBControl.SYS_LOG.write_log("PrintReport.log", "自动打印：" + ex.Message);
            }
        }


        private void 
            btnNext_Click(object sender, EventArgs e)
        {
            m_CurrentPage++;
            Search();
        }
        private void 
            btnLast_Click(object sender, EventArgs e)
        {
            if (m_CurrentPage > 1)
            {
                m_CurrentPage -= 1;
                Search();
            }
            else
            {
                MessageBox.Show("没有上一页了");
            }
        }
        private string
            Get_HB_JYXM(string jyxm)
        {
            string[] _jyxm = jyxm.Split(',');
            foreach (string subStr in _jyxm)
            {
                if (subStr.Contains("X"))
                    return subStr;
            }
            return string.Empty;
        }

		private void WndMain_Load(object sender, EventArgs e)
		{
			panel2.Font = this.Font;
		}

        private string GetPDText(string source)
        {
            if (source == "1") return "合格";
            else if (source == "2") return "不合格";
            else return source;
        }

        private string GetJYXMText(string source)
        {
            string[] jyxm = source.Split(',');
            string result = "";
            for (int i = 0; i < jyxm.Length; i++)
            {
                string item = jyxm[i];
                if (item == "X1") result += ISPMSD.X1;
                if (item == "X2") result += ISPMSD.X2;
                if (item == "X3") result += ISPMSD.X3;
                if (item == "X4") result += ISPMSD.X4;
                if (item == "X5") result += ISPMSD.X5;
                if (item == "X6") result += ISPMSD.X6;
                if (item == "OB") result += "OBD检验";
                result += " ";
            }
            return result;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "";
            dlg.InitialDirectory = @"C:\";
            dlg.Filter = "Comma-Separated Values|*.csv";
            dlg.ShowDialog();
            string path = dlg.FileName;
            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "检测流水号,检验类别,环保流水号,车辆下线时间,VIN,检验项目,结论";
            sw.WriteLine(data);
            for (int i = 0; i < m_resultList.Length; i++)
            {
                var info = m_resultList[i];
                data = info.JCLSH + "," + info.JYLB + "," + info.WQLSH + "," + info.CLXXSJ + "," 
                    + info.VIN + "," + GetJYXMText(info.JYXM) + "," + GetPDText(info.Z_PD);
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }

        public void DataExport(DataTable metaData)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title="";
            dlg.InitialDirectory=@"C:\";
            dlg.Filter="文本文件|*.txt";
            dlg.ShowDialog();
            string path = dlg.FileName;
            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";
            for (int i = 0; i < metaData.Columns.Count; i++)
            {
                data += metaData.Columns[i].ColumnName.ToString();
                if (i < metaData.Columns.Count - 1)
                    data += ",";
            }
            sw.WriteLine(data);
            for (int i = 0; i < metaData.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < metaData.Columns.Count; j++)
                {
                    data+= metaData.Rows[i][j].ToString();
                    if (j < metaData.Columns.Count - 1)
                        data += ",";
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }
	}
}
