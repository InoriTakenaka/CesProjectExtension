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
using System.Data.SqlClient;
using System.Reflection;

namespace SystemSettingExtension
{
    public partial class WndMain : Form
    {
        List<COSTUME_MODEL_LIMIT> m_relations;
        MSSqlAccess m_db;
        DEV_STANDARD_ASM m_asm;
        DEV_STANDARD_LD m_ld;
        DEV_STANDARD_SDS m_sds;
        DEV_STANDARD_VMAS m_vmas;
        DEV_STANDARD_ZYJS m_fa;

        public WndMain()
        {
            InitializeComponent();
            m_db = new MSSqlAccess(dbConfig.g_strConnectionStringSqlClient1);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitVehicleModelList();
        }

        private void InitVehicleModelList()
        {
            //BLL.COSTUME_MODEL_LIMIT_BLL records = new BLL.COSTUME_MODEL_LIMIT_BLL();
            m_relations = m_db.Select<COSTUME_MODEL_LIMIT>("SELECT * FROM COSTUME_MODEL_LIMIT");           
            for (int i = 0; i < m_relations.Count; i++)
                m_VehModel.Items.Add(m_relations[i].MODEL_NAME);
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            WndAddModel wndAdd = new WndAddModel((str) => m_VehModel.Items.Add(str));
            wndAdd.Show();
        }

        private void m_Delete_Click(object sender, EventArgs e)
        {
            string modelName = m_VehModel.SelectedItem.ToString();
            if (modelName == "限值a" || modelName == "限值b")
            {
                MessageBox.Show("无法删除");
                return;
            }  
            BLL.COSTUME_MODEL_LIMIT_BLL records = new BLL.COSTUME_MODEL_LIMIT_BLL();
            string cmdText = "EXECUTE SP_DELETE_COSTUME_MODEL_LIMIT @MODEL_NAME";
            SqlParameter para = new SqlParameter("MODEL_NAME", modelName);
            string result = "";
            using (SqlConnection connection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1))
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(cmdText, connection);
                sqlCmd.Parameters.Add(para);
                int r = sqlCmd.ExecuteNonQuery();
                m_VehModel.Items.Remove(modelName);
                MessageBox.Show("删除成功");
                sqlCmd.Dispose();
            }
        }

        private void m_VehModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_VehModel.SelectedItems.Count == 0) return;
            else
            {
                ResetTextBox();
                string model = m_VehModel.SelectedItem.ToString();
                for (int i = 0; i < m_relations.Count; i++)
                {
                    if (m_relations[i].MODEL_NAME == model)
                    {
                        string key = "SEARCH_CONDITION";
                        if (m_relations[i].METHOD_NAME.Contains("ASM"))
                        {
                            var m_asm = m_db.Find<DEV_STANDARD_ASM>(key, model);
                            if (m_asm.ID > 0)
                            {
                                m_Edit25HC.Text = m_asm.HC5025XZ;
                                m_Edit25CO.Text = m_asm.CO5025XZ;
                                m_Edit25NO.Text = m_asm.NO5025XZ;
                                m_Edit40HC.Text = m_asm.HC2540XZ;
                                m_Edit40CO.Text = m_asm.CO2540XZ;
                                m_Edit40NO.Text = m_asm.NO2540XZ;
                            }
                            else m_asm = null;
                        }
                        if (m_relations[i].METHOD_NAME.Contains("VMAS"))
                        {
                            //BLL.DEV_STANDARD_VMAS_BLL bllVmas = new BLL.DEV_STANDARD_VMAS_BLL();
                            //DEV_STANDARD_VMAS[] arrVmas = bllVmas.GetModelList(condition);
                            m_vmas = m_db.Find<DEV_STANDARD_VMAS>(key, model);
                            if (m_vmas.ID > 0)
                            {
                                m_EditHCXZ.Text = m_vmas.COXZ;
                                m_EditCOXZ.Text = m_vmas.HCXZ;
                                m_EditNOXZ.Text = m_vmas.NOXZ;
                                m_EditHCNOXZ.Text = m_vmas.HC_NOXZ;
                            }
                            else m_vmas = null;
                        }
                        if (m_relations[i].METHOD_NAME.Contains("SDS"))
                        {
                            m_sds = m_db.Find<DEV_STANDARD_SDS>(key, model);
                            if (m_sds.ID > 0)
                            {
                                m_EditGDSCO.Text = m_sds.GDSCOXZ;
                                m_EditGDSHC.Text = m_sds.GDSHCXZ;
                                m_EditDSCO.Text = m_sds.DSCOXZ;
                                m_EditDSHC.Text = m_sds.DSHCXZ;
                                m_EditLXX.Text = m_sds.GLKQXSXX;
                                m_EditLSX.Text = m_sds.GLKQXSSX;
                            }
                            else m_sds = null;
                        }
                        if (m_relations[i].METHOD_NAME.Contains("LD"))
                        {
                            m_ld = m_db.Find<DEV_STANDARD_LD>(key, model);
                            if (m_ld.ID > 0)
                            {
                                m_EditGXSXS.Text = m_ld.GXSXSXZ;
                                m_EditGLXZ.Text = m_ld.GLXZ;
                                m_EditZSXZ.Text = m_ld.ZSXZ;
                                m_EditLDNO.Text = m_ld.NOXZ;
                                m_EditLGM.Text = m_ld.LGMXZ;
                                m_EditHSU.Text = m_ld.HSUXZ;
                            }
                            else m_ld = null;
                        }
                        if (m_relations[i].METHOD_NAME.Contains("FA"))
                        {
                            m_fa = m_db.Find<DEV_STANDARD_ZYJS>(key, model);
                            if (m_fa.ID > 0)
                            {
                                m_EditFaBTG.Text = m_fa.ZYJSXZ;
                                m_EditBTGHSU.Text = m_fa.HSUXZ;
                            }
                            else m_fa = null;
                        }
                    }
                }
            }
        }

        private void m_VehModel_DoubleClick(object sender, EventArgs e)
        {
            return;
        }

        private void m_SaveASM_Click(object sender, EventArgs e)
        {
            string hc5025 = m_Edit25HC.Text,
                    co5025 = m_Edit25CO.Text,
                    no5025 = m_Edit25NO.Text,
                    hc2540 = m_Edit40HC.Text,
                    co2540 = m_Edit40CO.Text,
                    no2540 = m_Edit40NO.Text;
            if (hc5025.IsNumeric() && co5025.IsNumeric() && no5025.IsNumeric()
                && hc2540.IsNumeric() && co2540.IsNumeric() && no2540.IsNumeric())
            {
                BLL.DEV_STANDARD_ASM_BLL bll = new BLL.DEV_STANDARD_ASM_BLL();
                if (m_asm == null)
                {
                    m_asm = new DEV_STANDARD_ASM();
                    m_asm.SEARCH_CONDITION = m_VehModel.SelectedItem.ToString();
                    m_asm.ZXMC = "A2";
                    m_asm.HC5025XZ = m_Edit25HC.Text;
                    m_asm.CO5025XZ = m_Edit25CO.Text;
                    m_asm.NO5025XZ = m_Edit25NO.Text;
                    m_asm.HC2540XZ = m_Edit40HC.Text;
                    m_asm.CO2540XZ = m_Edit40CO.Text;
                    m_asm.NO2540XZ = m_Edit40NO.Text;
                    m_asm.IS_SHOW = 1;
                    m_asm.AREA_NAME = "新国标";
                    m_asm.UTYPE = 0;
                    bll.Insert(m_asm);
                    UpdateCostumeModelLimitTable(m_VehModel.SelectedItem.ToString(), "ASM");
                }
                else
                {
                    m_asm.HC5025XZ = m_Edit25HC.Text;
                    m_asm.CO5025XZ = m_Edit25CO.Text;
                    m_asm.NO5025XZ = m_Edit25NO.Text;
                    m_asm.HC2540XZ = m_Edit40HC.Text;
                    m_asm.CO2540XZ = m_Edit40CO.Text;
                    m_asm.NO2540XZ = m_Edit40NO.Text;
                    bll.Update(m_asm, m_asm.ID);
                }
                ResetTextBox();
                MessageBox.Show("设置成功");
                m_VehModel.ClearSelected();
            }
            else
            { MessageBox.Show("输入文本必须是纯数字"); }
        }

        private void m_SaveVmas_Click(object sender, EventArgs e)
        {
            string HCXZ = m_EditHCXZ.Text,
                COXZ = m_EditCOXZ.Text,
                NOXZ = m_EditNOXZ.Text,
                HCNOXZ = m_EditHCNOXZ.Text;
            if (HCXZ.IsNumeric() && COXZ.IsNumeric()
                && NOXZ.IsNumeric() && HCNOXZ.IsNumeric())
            {
                BLL.DEV_STANDARD_VMAS_BLL bll = new BLL.DEV_STANDARD_VMAS_BLL();
                if (m_vmas == null)
                {
                    m_vmas = new DEV_STANDARD_VMAS();
                    m_vmas.SEARCH_CONDITION = m_VehModel.SelectedItem.ToString();
                    m_vmas.ZXMC = "";
                    m_vmas.COXZ = COXZ;
                    m_vmas.HCXZ = HCXZ;
                    m_vmas.NOXZ = NOXZ;
                    m_vmas.HC_NOXZ = HCNOXZ;
                    m_vmas.PDFS = "0";
                    m_vmas.IS_SHOW = 1;
                    m_vmas.AREA_NAME = "新国标";
                    m_vmas.UTYPE = 0;
                    bll.Insert(m_vmas);
                    UpdateCostumeModelLimitTable(m_VehModel.SelectedItem.ToString(), "VMAS");
                }
                else
                {
                    m_vmas.COXZ = COXZ;
                    m_vmas.HCXZ = HCXZ;
                    m_vmas.NOXZ = NOXZ;
                    m_vmas.HC_NOXZ = HCNOXZ;
                    bll.Update(m_vmas, m_vmas.ID);
                }
                ResetTextBox();
                MessageBox.Show("设置成功");
                m_VehModel.ClearSelected();
            }
            else
            { MessageBox.Show("输入文本必须是纯数字"); }
        }

        private void m_SaveSds_Click(object sender, EventArgs e)
        {
            string GDSCO = m_EditGDSCO.Text,
                GDSHC = m_EditGDSHC.Text,
                DSCO = m_EditDSCO.Text,
                DSHC = m_EditDSHC.Text,
                MIN_LAMBDA = m_EditLXX.Text,
                MAX_LAMBDA = m_EditLSX.Text;
            if (GDSCO.IsNumeric() && GDSHC.IsNumeric() && DSCO.IsNumeric()
                && DSHC.IsNumeric() && MIN_LAMBDA.IsNumeric() && MAX_LAMBDA.IsNumeric())
            {
                BLL.DEV_STANDARD_SDS_BLL bll = new BLL.DEV_STANDARD_SDS_BLL();
                if (m_sds == null)
                {
                    m_sds = new DEV_STANDARD_SDS();
                    m_sds.SEARCH_CONDITION = m_VehModel.SelectedItem.ToString();
                    m_sds.ZXMC = "双怠速法";
                    m_sds.GDSCOXZ = GDSCO;
                    m_sds.GDSHCXZ = GDSHC;
                    m_sds.DSCOXZ = DSCO;
                    m_sds.DSHCXZ = DSHC;
                    m_sds.GLKQXSSX = MAX_LAMBDA;
                    m_sds.GLKQXSXX = MIN_LAMBDA;
                    m_sds.IS_SHOW = 1;
                    m_sds.AREA_NAME = "新国标";
                    m_sds.UTYPE = 0;
                    bll.Insert(m_sds);
                    UpdateCostumeModelLimitTable(m_VehModel.SelectedItem.ToString(), "SDS");
                }
                else
                {
                    m_sds.GDSCOXZ = GDSCO;
                    m_sds.GDSHCXZ = GDSHC;
                    m_sds.DSCOXZ = DSCO;
                    m_sds.DSHCXZ = DSHC;
                    bll.Update(m_sds, m_sds.ID);
                }
                ResetTextBox();
                MessageBox.Show("设置成功");
                m_VehModel.ClearSelected();
            }
            else { MessageBox.Show("输入文本必须是纯数字"); }
        }

        private void m_SaveLD_Click(object sender, EventArgs e)
        {
            string GXSXS = m_EditGXSXS.Text,
                    GLXZ = m_EditGLXZ.Text,
                    ZSXZ = m_EditZSXZ.Text,
                    NOXZ = m_EditLDNO.Text,
                    LGM = m_EditLGM.Text,
                    HSU = m_EditHSU.Text;
            if (GXSXS.IsNumeric() && GLXZ.IsNumeric() && ZSXZ.IsNumeric()
                && NOXZ.IsNumeric() && LGM.IsNumeric() && HSU.IsNumeric())
            {
                BLL.DEV_STANDARD_LD_BLL bll = new BLL.DEV_STANDARD_LD_BLL();
                if (m_ld == null)
                {
                    m_ld = new DEV_STANDARD_LD();
                    m_ld.SEARCH_CONDITION = m_VehModel.SelectedItem.ToString();
                    m_ld.ZXMC = "加载减速";
                    m_ld.GXSXSXZ = GXSXS;
                    m_ld.GLXZ = GLXZ;
                    m_ld.ZSXZ = ZSXZ;
                    m_ld.IS_SHOW = 1;
                    m_ld.AREA_NAME = "新国标";
                    m_ld.UTYPE = 0;
                    m_ld.NOXZ = NOXZ;
                    m_ld.LGMXZ = LGM;
                    m_ld.HSUXZ = HSU;
                    bll.Insert(m_ld);
                    UpdateCostumeModelLimitTable(m_VehModel.SelectedItem.ToString(), "LD");

                }
                else
                {
                    m_ld.GXSXSXZ = GXSXS;
                    m_ld.GLXZ = GLXZ;
                    m_ld.ZSXZ = ZSXZ;
                    m_ld.NOXZ = NOXZ;
                    m_ld.LGMXZ = LGM;
                    m_ld.HSUXZ = HSU;
                    bll.Update(m_ld, m_ld.ID);
                    ResetTextBox();
                }
                ResetTextBox();
                MessageBox.Show("设置成功");
                m_VehModel.ClearSelected();
            }
            else { MessageBox.Show("输入文本必须是纯数字"); }
        }

        private void m_SaveFa_Click(object sender, EventArgs e)
        {
            string FABTG = m_EditFaBTG.Text, FAHSU = m_EditBTGHSU.Text;
            if (FABTG.IsNumeric() && FAHSU.IsNumeric())
            {
                BLL.DEV_STANDARD_ZYJS_BLL bll = new BLL.DEV_STANDARD_ZYJS_BLL();
                if (m_fa == null)
                {
                    m_fa = new DEV_STANDARD_ZYJS();
                    m_fa.SEARCH_CONDITION = m_VehModel.SelectedItem.ToString();
                    m_fa.ZXMC = "不透光";
                    m_fa.ZYJSXZ = FABTG;
                    m_fa.IS_SHOW = 1;
                    m_fa.AREA_NAME = "新国标";
                    m_fa.UTYPE = 0;
                    m_fa.HSUXZ = FAHSU;
                    bll.Insert(m_fa);
                    UpdateCostumeModelLimitTable(m_VehModel.SelectedItem.ToString(), "FA");
                }
                else
                {
                    m_fa.ZYJSXZ = FABTG;
                    m_fa.HSUXZ = FAHSU;
                    bll.Update(m_fa, m_fa.ID);
                }
                ResetTextBox();
                MessageBox.Show("设置成功");
                m_VehModel.ClearSelected();
            }
            else { MessageBox.Show("输入文本必须是纯数字"); }
        }

        /// <summary>
        /// determine specific model is exist
        /// </summary>
        /// <param name="SEARCH_CONDITION"></param>
        /// <returns></returns>
        bool Exist(string SEARCH_CONDITION, string method)
        {
            int result = 0;
            string sql = "SELECT COUNT(*) as RESULT FROM {0} WHERE SEARCH_CONDITION='{0}'"
                .FormatWith(SEARCH_CONDITION, method);
            using (SqlConnection connection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1))
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(sql, connection);
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                result = (int)reader["RESULT"];
            }
            if (result == 0) return false;
            else return true;
        }

        private Boolean UpdateCostumeModelLimitTable(string searchCondition, string method)
        {
            COSTUME_MODEL_LIMIT instance = m_db.Find<COSTUME_MODEL_LIMIT>("MODEL_NAME", searchCondition);
            int r = 0;
            if (instance.MODEL_NAME.IsEffective())
            {
                if (instance.METHOD_NAME.Contains(method)) return false;
                else
                {
                    instance.METHOD_NAME = instance.METHOD_NAME + "&" + method;
                    r = m_db.Update(instance, "MODEL_NAME");
                    for (int i = 0; i < m_relations.Count; i++)
                        if (m_relations[i].MODEL_NAME == searchCondition)
                            m_relations[i].METHOD_NAME += "&" + method;
                }
            }
            return r > 0;
        }

        private void ResetTextBox()
        {
            m_Edit25HC.Text = string.Empty;
            m_Edit25CO.Text = string.Empty;
            m_Edit25NO.Text = string.Empty;
            m_Edit40HC.Text = string.Empty;
            m_Edit40CO.Text = string.Empty;
            m_Edit40NO.Text = string.Empty;

            m_EditHCXZ.Text = string.Empty;
            m_EditCOXZ.Text = string.Empty;
            m_EditNOXZ.Text = string.Empty;
            m_EditHCNOXZ.Text = string.Empty;

            m_EditGXSXS.Text = string.Empty;
            m_EditGLXZ.Text = string.Empty;
            m_EditZSXZ.Text = string.Empty;
            m_EditLDNO.Text = string.Empty;
            m_EditLGM.Text = string.Empty;
            m_EditHSU.Text = string.Empty;

            m_EditGDSCO.Text = string.Empty;
            m_EditGDSHC.Text = string.Empty;
            m_EditDSCO.Text = string.Empty;
            m_EditDSHC.Text = string.Empty;
            m_EditLXX.Text = string.Empty;
            m_EditLSX.Text = string.Empty;

            m_EditBTGHSU.Text = string.Empty;
            m_EditFaBTG.Text = string.Empty;
        }
    }
}
