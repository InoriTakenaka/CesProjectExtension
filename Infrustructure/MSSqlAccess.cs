using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
namespace Infrastructure
{
    public class MSSqlAccess
    {
        private readonly string m_connectionString;

        public 
            MSSqlAccess(string connectionString)
        {
            m_connectionString = connectionString;
        }

        /// <summary>
        /// Find Entity By specific key and its value 
        /// </summary>
        /// <param name="key">must be a accessible member of class E 's instance</param>
        /// <param name="value">your condition</param>
        /// <returns></returns>
        public E 
            Find<E>(string key, string value)
        {
            E t = Activator.CreateInstance<E>();
            PropertyInfo[] props = t.GetType().GetProperties();
            string tableName = t.GetType().Name;
            string sql = $"SELECT * FROM {tableName} WHERE {key} = '{value}' ";
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    foreach (PropertyInfo p in props)
                    {
                        string pName = p.Name;
                        try
                        {
                            if (!p.PropertyType.IsGenericType)
                                p.SetValue(t, reader[pName] == DBNull.Value ?
                                    null : Convert.ChangeType(reader[pName], p.PropertyType), null);
                            else
                            {
                                Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                    p.SetValue(t, reader[pName] == DBNull.Value ?
                                        null : Convert.ChangeType(reader[pName], p.PropertyType.GetGenericArguments()[0]), null);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// Query a Entity Collection by Specific SQL Command 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="SqlCommandText"></param>
        /// <returns></returns>
        public List<E> 
            Select<E>(string SqlCommandText)
        {
            List<E> recordSet = new List<E>();
            E t = Activator.CreateInstance<E>();
            PropertyInfo[] props = t.GetType().GetProperties();
            string tableName = t.GetType().Name;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(SqlCommandText, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    E instance = Activator.CreateInstance<E>();
                    foreach (PropertyInfo p in props)
                    {
                        string pName = p.Name;
                        try
                        {
                            if (!p.PropertyType.IsGenericType)
                                p.SetValue(instance, reader[pName] == DBNull.Value ?
                                    null : Convert.ChangeType(reader[pName], p.PropertyType), null);
                            else
                            {
                                Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                    p.SetValue(instance, reader[pName] == DBNull.Value ?
                                        null : Convert.ChangeType(reader[pName], p.PropertyType.GetGenericArguments()[0]), null);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    recordSet.Add(instance);
                }
            }
            return recordSet;
        }

        /// <summary>
        /// Insert a new row to Table 
        /// </summary>
        /// <typeparam name="E">Entity Type/Table Name</typeparam>
        /// <param name="e">Instance of E</param>
        /// <returns></returns>
        public int 
            Insert<E>(E e)
        {
            int r = -1;
            string sql = InsertSQL(e);
            SqlParameter[] sqlParameters = e.GetType().GetProperties()
                .ForEach(prop => new SqlParameter($"@{prop.Name}", prop.GetValue(e, null) ?? DBNull.Value))
                .ToList().ToArray();
            using(SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlConnection.Open();
                r = sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
                return r;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="e">Instance of E</param>
        /// <param name="key">Primary key</param>
        /// <returns></returns>
        public int 
            Update<E>(E e,string key)
        {
            string sql = UpdateSQL(e, key);
            SqlParameter[] sqlParameters = e.GetType().GetProperties()
                .ForEach(prop => new SqlParameter($"@{prop.Name}", prop.GetValue(e, null) ?? DBNull.Value))
                .ToList().ToArray();
            int r = -1;
            using (SqlConnection sqlConnection = new SqlConnection(m_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddRange(sqlParameters);
                sqlConnection.Open();
                r = sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
                return r;
            }
        }

        /// <summary>
        /// Query Sql Builder
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public string 
            InsertSQL<E>(E e)
        {
            PropertyInfo[] props = e.GetType().GetProperties();
            return $"INSERT INTO [{e.GetType().Name}] " +
                $"({string.Join(",", props.ForEach(prop=>prop.Name).ToList().ToArray()) }) " +
                $"VALUES ({string.Join(",",props.ForEach(prop=>$"@{prop.Name}").ToList().ToArray())})";
        }

        /// <summary>
        /// Update Sql Builder
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string 
            UpdateSQL<E>(E e,string key)
        {
            PropertyInfo[] props = e.GetType().GetProperties();
            return $"UPDATE [{e.GetType().Name}] " +
                $"SET { string.Join(",", props.ForEach(prop => $"{prop.Name}=@{prop.Name}").ToList().ToArray()) } " +
                $"WHERE {key }=@{key}";
        }
    }
}
