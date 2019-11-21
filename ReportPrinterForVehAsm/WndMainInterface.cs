//#define DEBUG
using System;
using System.Text;
using Core;
using Drivers;
using Infrastructure;

namespace ReportPrinterForVehAsm
{
    public class WndMainInterface
    {
        public DRV_H.SendCommanddeg                   m_fptrSendCommand;                 
        public DRV_H.AddMsgdeg                        m_fptrAddMsg;   
        public DRV_H.WriteResultdeg                   m_fptrWriteResult;
        public DRV_H.WriteProcessDatadeg              m_fptrWriteProcessData;
        public DRV_H.WriteTestStatusdeg               m_fptrWriteTestStatus;
        public Boolean                                DLL_READY { get; private set; }

        private System.Windows.Forms.Form m_wndMain = null;
        private System.Windows.Forms.Form m_wndConfig = null;
        
        public
           WndMainInterface() { }
        public bool
            InstallDev(
            DRV_H.SendCommanddeg       fptrSendCommand,
            DRV_H.AddMsgdeg                    fptrAddMsg,
            DRV_H.WriteResultdeg              fptrWriteResult,
            DRV_H.WriteProcessDatadeg  fptrWriteProcessData,
            DRV_H.WriteTestStatusdeg      fptrWriteTestStatus)
        {
            m_fptrSendCommand = fptrSendCommand;
            m_fptrAddMsg = fptrAddMsg;
            m_fptrWriteResult = fptrWriteResult;
            m_fptrWriteProcessData = fptrWriteProcessData;
            m_fptrWriteTestStatus = fptrWriteTestStatus;

            DevConfigManager.InitConfig();
            if (!DevConfigManager.ready) throw new NullReferenceException();
            StringBuilder buffer  = new StringBuilder(256);           
            string serverName =
                DevConfigManager.GetConfigString("SERVER_DB", "DB_SERVER", string.Empty, buffer, buffer.Capacity);
            string instanceName =
                DevConfigManager.GetConfigString("SERVER_DB", "DB_NAME", string.Empty, buffer, buffer.Capacity);
            string uid =
                DevConfigManager.GetConfigString("SERVER_DB", "UID", string.Empty, buffer, buffer.Capacity);
            string pwd =
                DevConfigManager.GetConfigString("SERVER_DB", "PWD", string.Empty, buffer, buffer.Capacity);
            string connectioString = $"server={serverName}; Initial Catalog={instanceName};User Id={uid};Password={pwd};";
            string canEdit = DevConfigManager.GetConfigString("SERVER_DB", "EDIT_INFO", string.Empty, buffer, buffer.Capacity);
            dbConfig.DB_SERVER = serverName;
            dbConfig.DB_NAME = instanceName;
            dbConfig.UID = uid;
            dbConfig.PWD = pwd;
            dbConfig.g_strConnectionStringSqlClient1 = connectioString;

            m_wndMain = new WndMain(canEdit == "1") { ControlBox = false };
            m_wndMain.Hide();
            m_wndConfig = new WndConfig { ControlBox = false };
            m_wndConfig.Hide();

            DLL_READY = true;
            return true;
        }
#if DEBUG
        public bool InstallDev()
        {
            DevConfigManager.InitConfig();
            if (!DevConfigManager.ready) throw new NullReferenceException();
            StringBuilder buffer = new StringBuilder(256);
            string serverName =
                DevConfigManager.GetConfigString("SERVER_DB", "DB_SERVER", string.Empty, buffer, buffer.Capacity);
            string instanceName =
                DevConfigManager.GetConfigString("SERVER_DB", "DB_NAME", string.Empty, buffer, buffer.Capacity);
            string uid =
                DevConfigManager.GetConfigString("SERVER_DB", "UID", string.Empty, buffer, buffer.Capacity);
            string pwd =
                DevConfigManager.GetConfigString("SERVER_DB", "PWD", string.Empty, buffer, buffer.Capacity);
            string connectioString = $"server={serverName}; Initial Catalog={instanceName};User Id={uid};Password={pwd};";
            string canEdit = DevConfigManager.GetConfigString("SERVER_DB", "EDIT_INFO", string.Empty, buffer, buffer.Capacity);
            dbConfig.DB_SERVER = serverName;
            dbConfig.DB_NAME = instanceName;
            dbConfig.UID = uid;
            dbConfig.PWD = pwd;
            dbConfig.g_strConnectionStringSqlClient1 = connectioString;

            m_wndMain = new WndMain(canEdit == "1") { ControlBox = false };
            m_wndMain.Hide();
            m_wndConfig = new WndConfig { ControlBox = false };
            m_wndConfig.Hide();

            DLL_READY = true;
            return true;
        }
#else


#endif
		public bool
            GetDevInfo(ref string strInfo)
        {
            return false;
        }
        public bool
            LoadConfigForm()
        {
            if (m_wndConfig == null) return false; 
            else m_wndConfig.Show();
            return true;
        }
        public bool 
            LoadDevForm()
        {
            if (m_wndMain == null) return false;
            else m_wndMain.Show();
            return true;
        }

        public System.Windows.Forms.Form 
            GetUiForm()
        {
            return m_wndMain;
        }
        /// <summary>
        /// Call this Method to Print a Report
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="command">
        /// 格式:jclsh,cpoies,printername
        /// </param>
        /// <returns></returns>
        public bool 
            RunTest(string connectionString,string command)
        {
            try
            {
                string[] commandParams = command.Split(',');
                string jclsh = commandParams[0];
                int copies = commandParams[1].SafeParse();
                string printerName = commandParams[2];

                BLL.RESULT_VEHICLE_INFO_BLL bllVehicle = new BLL.RESULT_VEHICLE_INFO_BLL();
                Model.RESULT_VEHICLE_INFO vehicleInfo = bllVehicle.GetModel(jclsh);
                if (vehicleInfo.JYXM.Contains("X"))
                {
                    if (vehicleInfo.RLLBDH == "A" || vehicleInfo.RLLBDH == "E")
                    {
                        GasolineReport report = new GasolineReport(jclsh, connectionString);
                        report.OutputReport(copies, printerName);
                        report.DocumentDestructor();

                        return true;
                    }
                    else if (vehicleInfo.RLLBDH == "B")
                    {
                        DieselReport report = new DieselReport(jclsh, connectionString);
                        report.OutputReport(copies, printerName);
                        report.DocumentDestructor();
                        return true;
                    }
                }
                else
                {
                    ObdReport report = new ObdReport(jclsh, connectionString);
                    report.OutputReport(copies, printerName);
                    report.DocumentDestructor();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool 
            SendCommand(UInt32 command, ref byte Val)
        {
            if(command==1)
            {
                
            }
            return false;
        }
        public bool 
            UnInstallDev()
        {
            if (m_wndMain != null) m_wndMain.Close();
            return false;
        }
    }
}
