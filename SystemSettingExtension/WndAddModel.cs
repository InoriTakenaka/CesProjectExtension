using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infrastructure;
using Core;
using Model;
using System.Data.SqlClient;
namespace SystemSettingExtension
{
    public partial class WndAddModel : Form
    {
        public Action<string> fptrDialogResult { get; set; }
        public WndAddModel(Action<string> fptrOnConfirm)
        {
            InitializeComponent();
            fptrDialogResult = fptrOnConfirm; 
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private bool InsertCostumeLimitTable(COSTUME_MODEL_LIMIT entity)
        {
            if (Exist(entity.MODEL_NAME))
            {
                MessageBox.Show("该车型已存在自定义限值 不用添加");
                return false;
            }
            else
            {
                BLL.COSTUME_MODEL_LIMIT_BLL bll = new BLL.COSTUME_MODEL_LIMIT_BLL();
                return bll.Insert(entity);
            }
        }

        bool Exist(string SEARCH_CONDITION)
        {
            int result = 0;
            string sql = "SELECT COUNT(*) as RESULT FROM COSTUME_MODEL_LIMIT WHERE MODEL_NAME ='{0}'"
                .FormatWith(SEARCH_CONDITION);
            using (SqlConnection connection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1))
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(sql, connection);
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read()) 
                result = (int)reader["RESULT"];
            }
            if (result == 0) return false;
            else return true;
        }

        private void m_btnConfirm_Click(object sender, EventArgs e)
        {
            COSTUME_MODEL_LIMIT model = new COSTUME_MODEL_LIMIT();
            model.MODEL_NAME = textBox1.Text;
            model.METHOD_NAME = "";
            if (InsertCostumeLimitTable(model))
            {
                MessageBox.Show("车型添加成功");
                this.fptrDialogResult(textBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("车型添加失败");
            }

        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
