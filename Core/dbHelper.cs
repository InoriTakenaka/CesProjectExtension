/*---------------------------------------------------------------------------
 * 单元描述：数据库执行。
 * 创建人：郭丰
 * 创建日期：2011-05-03
----------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Data.SqlClient;
using Core;
namespace DBUtility
{
    public sealed class DbHelper
    {
        public static string GetValue(string p_strSql)
        {
            string strResult = "";

            SqlConnection m_conConnection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1);
            m_conConnection.Open();

            DataTable m_dtTable = new DataTable();
            SqlDataAdapter ddaAdapter = new SqlDataAdapter(p_strSql, m_conConnection);
            ddaAdapter.Fill(m_dtTable);

            if (m_dtTable.Rows.Count > 0)
            {
                strResult = m_dtTable.Rows[0][0].ToString();
            }

            m_dtTable.Dispose();
            ddaAdapter.Dispose();
            m_conConnection.Close();
            m_conConnection.Dispose();

            return strResult;
        }

        public static string GetValue(string Conn, string p_strSql)
        {
            string strResult = "";

            SqlConnection m_conConnection = new SqlConnection(Conn);
            m_conConnection.Open();

            DataTable m_dtTable = new DataTable();
            SqlDataAdapter ddaAdapter = new SqlDataAdapter(p_strSql, m_conConnection);
            ddaAdapter.Fill(m_dtTable);

            if (m_dtTable.Rows.Count > 0)
            {
                strResult = m_dtTable.Rows[0][0].ToString();
            }

            m_dtTable.Dispose();
            ddaAdapter.Dispose();
            m_conConnection.Close();
            m_conConnection.Dispose();

            return strResult;
        }

        public static void GetTable(string Conn, string p_strSql, ref DataTable p_dtTable)
        {
            SqlConnection m_conConnection = new SqlConnection(Conn);
            m_conConnection.Open();
            try
            {
                SqlDataAdapter ddaAdapter = new SqlDataAdapter(p_strSql, m_conConnection);
                ddaAdapter.Fill(p_dtTable);
                ddaAdapter.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            m_conConnection.Close();
        }

        public static void GetTable(string p_strSql, ref DataTable p_dtTable)
        {
            SqlConnection m_conConnection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1);
            m_conConnection.Open();

            SqlDataAdapter ddaAdapter = new SqlDataAdapter(p_strSql, m_conConnection);
            ddaAdapter.Fill(p_dtTable);
            ddaAdapter.Dispose();

            m_conConnection.Close();
        }

        public static void GetTable(string Conn, string p_strSql, ref DataTable p_dtTable, int p_intStartRecord, int p_intPageSize)
        {
            SqlConnection m_conConnection = new SqlConnection(Conn);
            m_conConnection.Open();
            try
            {
                SqlDataAdapter ddaAdapter = new SqlDataAdapter(p_strSql, m_conConnection);
                ddaAdapter.Fill(p_intStartRecord, p_intPageSize, new DataTable[] { p_dtTable });
                ddaAdapter.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            m_conConnection.Close();
        }

        public static void GetTable(string p_strSql, ref DataTable p_dtTable, int p_intStartRecord, int p_intPageSize)
        {
            SqlConnection m_conConnection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1);
            m_conConnection.Open();

            SqlDataAdapter ddaAdapter = new SqlDataAdapter(p_strSql, m_conConnection);
            ddaAdapter.Fill(p_intStartRecord, p_intPageSize, new DataTable[] { p_dtTable });
            ddaAdapter.Dispose();

            m_conConnection.Close();
        }

        public static bool ExecuteSql(string Conn, string p_strSql)
        {
            bool bolResult = false;

            SqlConnection m_conConnection = new SqlConnection(Conn);
            m_conConnection.Open();

            if (m_conConnection.State == ConnectionState.Open)
            {
                SqlCommand m_cmdCommand = m_conConnection.CreateCommand();

                m_cmdCommand.Parameters.Clear();
                m_cmdCommand.CommandType = CommandType.Text;
                m_cmdCommand.CommandText = p_strSql;

                try
                {
                    m_cmdCommand.ExecuteNonQuery();
                    bolResult = true;
                }
                catch
                {
                }
                finally
                {
                    m_cmdCommand.Dispose();
                    m_conConnection.Close();
                }
            }

            return bolResult;
        }

        public static bool ExecuteSql(string p_strSql)
        {
            bool bolResult = false;

            SqlConnection m_conConnection = new SqlConnection(dbConfig.g_strConnectionStringSqlClient1);
            m_conConnection.Open();

            if (m_conConnection.State == ConnectionState.Open)
            {
                SqlCommand m_cmdCommand = m_conConnection.CreateCommand();

                m_cmdCommand.Parameters.Clear();
                m_cmdCommand.CommandType = CommandType.Text;
                m_cmdCommand.CommandText = p_strSql;

                try
                {
                    m_cmdCommand.ExecuteNonQuery();
                    bolResult = true;
                }
                catch
                {
                }
                finally
                {
                    m_cmdCommand.Dispose();
                    m_conConnection.Close();
                }
            }

            return bolResult;
        }
    }
}

