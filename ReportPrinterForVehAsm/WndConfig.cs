using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core;
using Infrastructure;
namespace ReportPrinterForVehAsm
{
    public partial class WndConfig : Form
    {
        public 
            WndConfig()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            InitConfig();
        }

        public void
            InitConfig()
        {
            try
            {
                if (!DevConfigManager.ready) DevConfigManager.InitConfig();
                StringBuilder buffer = new StringBuilder(20);
                string serverName =
                    DevConfigManager.GetConfigString("SERVER_DB", "DB_SERVER", string.Empty, buffer, buffer.Capacity);
                string instaceName =
                    DevConfigManager.GetConfigString("SERVER_DB", "DB_NAME", string.Empty, buffer, buffer.Capacity);
                string uid =
                    DevConfigManager.GetConfigString("SERVER_DB", "UID", string.Empty, buffer, buffer.Capacity);
                string pwd =
                    DevConfigManager.GetConfigString("SERVER_DB", "PWD", string.Empty, buffer, buffer.Capacity);
                string connectioString = "server={0}; Initial Catalog={1};User Id={2};Password={3};"
                                                            .FormatWith(serverName, instaceName, uid, pwd);
                dbConfig.DB_SERVER = serverName;
                dbConfig.DB_NAME = instaceName;
                dbConfig.UID = uid;
                dbConfig.PWD = pwd;
                dbConfig.g_strConnectionStringSqlClient1 = connectioString;

                txtServer.Text = serverName;
                txtInstanceName.Text = instaceName;
                txtUserName.Text = uid;
                txtPwd.Text = pwd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string serverName = txtServer.Text;
            string instanceName = txtInstanceName.Text;
            string userName = txtUserName.Text;
            string pwd = txtPwd.Text;
            Boolean confirm = false;
            confirm = DevConfigManager.SetConfigString("SERVER_DB", "DB_SERVER", serverName);
            confirm = DevConfigManager.SetConfigString("SERVER_DB", "DB_NAME", instanceName);
            confirm = DevConfigManager.SetConfigString("SERVER_DB", "UID", userName);
            confirm = DevConfigManager.SetConfigString("SERVER_DB", "PWD", pwd);
            if (confirm)
            {
                dbConfig.DB_SERVER = serverName;
                dbConfig.DB_NAME = instanceName;
                dbConfig.UID=userName;
                dbConfig.PWD = pwd;
                dbConfig.g_strConnectionStringSqlClient1 = "server={0}; Initial Catalog={1};User Id={2};Password={3};"
                                                        .FormatWith(serverName, instanceName, userName, pwd);
                MessageBox.Show("保存成功");
                this.Hide();
            }
            else MessageBox.Show("保存失败");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
