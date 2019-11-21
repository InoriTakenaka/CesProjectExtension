using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层COSTUME_MODEL_LIMIT_DAL
     /// </summary>
     public class COSTUME_MODEL_LIMIT_DAL
     {
         private string Conn{ get;set; }
         public COSTUME_MODEL_LIMIT_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大MODEL_NAME
         /// </summary>
         public string GetMax_MODEL_NAME(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(MODEL_NAME) as m from COSTUME_MODEL_LIMIT";

             if(p_strWhere.Trim().Length > 0)
             {
                 strSql += " where " + p_strWhere;
             }

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn ,strSql, ref dtTemp);

             if(dtTemp.Rows.Count>0)
             {
                 if(dtTemp.Rows[0]["m"].ToString().Length>0)
                 {
                     strResult = dtTemp.Rows[0]["m"] == DBNull.Value ? "" : dtTemp.Rows[0]["m"].ToString();
                 }
             }

             dtTemp.Dispose();

             return string.Format("{0:D50}", Convert.ToInt32(strResult) + 1);

          }

          /// <summary>
          /// 得到最大MODEL_NAME
          /// </summary>
          public string GetMax_MODEL_NAME()
          {
              return GetMax_MODEL_NAME("");
          }


          /// <summary>
          /// 判断数据是否存在
          /// </summary>
          public bool Exists(string strMODEL_NAME)
          {
               bool bolResult = false;

               if (strMODEL_NAME == null)
               {
                   return false;
               }

               if (strMODEL_NAME.Length == 0)
               {
                   return false;
               }

               string strSql = "";
               strSql += "select count(1) as c from COSTUME_MODEL_LIMIT";
               strSql += " where ";
               strSql += " MODEL_NAME='"+ strMODEL_NAME +"'";

               DataTable dtTemp = new DataTable();
               DbHelper.GetTable(Conn, strSql, ref dtTemp);

               if (dtTemp.Rows.Count > 0)
               {
                   bolResult = Convert.ToInt32(dtTemp.Rows[0]["c"]) > 0;
               }

               dtTemp.Dispose();

               return bolResult;

          }

          /// <summary>
          /// 获取数据总记录数
          /// </summary>
          public int GetRecordCount(string p_strWhere)
          {
              int intResult=0;

              string strSql = "";
              strSql += "select count(1) as c from COSTUME_MODEL_LIMIT";
              if(p_strWhere.Trim().Length > 0)
              {
                 strSql += " where " + p_strWhere;
              }

              DataTable dtTemp = new DataTable();
              DbHelper.GetTable(Conn, strSql, ref dtTemp);

              if(dtTemp.Rows.Count>0)
              {
                  intResult=Convert.ToInt32(dtTemp.Rows[0]["c"]);
              }

              dtTemp.Dispose();

              return intResult;
          }

          /// <summary>
          /// 获取数据总记录数
          /// </summary>
          public int GetRecordCount()
          {
              return GetRecordCount("");
          }

          /// <summary>
          /// 获取数据分页总数
           /// </summary>
          public int GetPageCount(string p_strWhere, int p_intPageSize)
          {
              int intResult=0;

              if(p_intPageSize > 0)
              {
                  int intRecordCount = GetRecordCount(p_strWhere);
                  intResult = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(intRecordCount) / Convert.ToDecimal(p_intPageSize)));
                  if (intRecordCount > (intResult * p_intPageSize))
                  {
                       intResult++;
                  }
              }

              if(intResult == 0)
              {
                   intResult++;
              }
              return intResult;
           }

          /// <summary>
          /// 获取数据分页总数
          /// </summary>
          public int GetPageCount(int p_intPageSize)
          {
              return GetPageCount("", p_intPageSize);
          }

          /// <summary>
          /// 添加一条数据 SQL
          /// </summary>
          public string InsertSQL(COSTUME_MODEL_LIMIT model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("MODEL_NAME") == true && model.MODEL_NAME != null)
              {
                   strFieldSQL += ",MODEL_NAME";
                   strValueSQL += ",'" + model.MODEL_NAME.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("METHOD_NAME") == true && model.METHOD_NAME != null)
              {
                   strFieldSQL += ",METHOD_NAME";
                   strValueSQL += ",'" + model.METHOD_NAME.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into COSTUME_MODEL_LIMIT";
              strSql += "(";
              strSql += strFieldSQL.Substring(1);
              strSql += ")";
              strSql += " values";
              strSql += "(";
              strSql += strValueSQL.Substring(1);
              strSql += ")";

              return strSql;
          }

          /// <summary>
          /// 添加一条数据
          /// </summary>
          public bool Insert(COSTUME_MODEL_LIMIT model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(COSTUME_MODEL_LIMIT model,string strMODEL_NAME)
          {
              string strUpdateSQL = "";

              if(model.Changed("MODEL_NAME") == true && model.MODEL_NAME != null)
              {
                  strUpdateSQL += ",MODEL_NAME='" + model.MODEL_NAME.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("METHOD_NAME") == true && model.METHOD_NAME != null)
              {
                  strUpdateSQL += ",METHOD_NAME='" + model.METHOD_NAME.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update COSTUME_MODEL_LIMIT set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " MODEL_NAME='"+ strMODEL_NAME +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(COSTUME_MODEL_LIMIT model, string strMODEL_NAME)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strMODEL_NAME));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(COSTUME_MODEL_LIMIT model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("MODEL_NAME") == true && model.MODEL_NAME != null)
               {
                  strUpdateSQL += ",MODEL_NAME='" + model.MODEL_NAME.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("METHOD_NAME") == true && model.METHOD_NAME != null)
               {
                  strUpdateSQL += ",METHOD_NAME='" + model.METHOD_NAME.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update COSTUME_MODEL_LIMIT set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(COSTUME_MODEL_LIMIT model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(COSTUME_MODEL_LIMIT model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",MODEL_NAME='" + model.MODEL_NAME.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",METHOD_NAME='" + model.METHOD_NAME.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update COSTUME_MODEL_LIMIT set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(COSTUME_MODEL_LIMIT model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strMODEL_NAME)
          {
              string strSql = "";
              strSql += "delete from COSTUME_MODEL_LIMIT";
              strSql += " where ";
               strSql += " MODEL_NAME='"+ strMODEL_NAME +"'";

              return strSql;

          }

          /// <summary>
          /// 删除一条数据
          /// </summary>
          public bool Delete(string strMODEL_NAME)
          {
              return DbHelper.ExecuteSql(Conn, DeleteSQL(strMODEL_NAME));
          }

          /// <summary>
          /// 删除一个集合 SQL
          /// </summary>
          public string DeleteRangeSQL(string p_strWhere)
          {
              string strSql = "";
              strSql += "delete from COSTUME_MODEL_LIMIT";
              strSql += " where " + p_strWhere;

              return strSql;
           }

          /// <summary>
          /// 删除一个集合
          /// </summary>
          public bool DeleteRange(string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, DeleteRangeSQL(p_strWhere));
          }

          /// <summary>
          /// 删除全部 SQL
          /// </summary>
          public string DeleteAllSQL()
          {
              string strSql = "";
              strSql += "delete from COSTUME_MODEL_LIMIT";

              return strSql;
           }

         /// <summary>
         /// 删除全部
         /// </summary>
         public bool DeleteAll()
         {
             return DbHelper.ExecuteSql(Conn, DeleteAllSQL());
         }

          /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public COSTUME_MODEL_LIMIT GetModel(string strMODEL_NAME)
         {
             string strSql = "";
             strSql += "select * from COSTUME_MODEL_LIMIT";
             strSql += " where ";
               strSql += " MODEL_NAME='"+ strMODEL_NAME +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             COSTUME_MODEL_LIMIT model = new COSTUME_MODEL_LIMIT();

             if(dtTemp.Rows.Count>0)
             {
                 model = new COSTUME_MODEL_LIMIT();

                 model.MODEL_NAME = dtTemp.Rows[0]["MODEL_NAME"] == DBNull.Value ? "" : dtTemp.Rows[0]["MODEL_NAME"].ToString();
                 model.METHOD_NAME = dtTemp.Rows[0]["METHOD_NAME"] == DBNull.Value ? "" : dtTemp.Rows[0]["METHOD_NAME"].ToString();
             }

             dtTemp.Dispose();

             return model;
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public void GetModel(ref DataTable p_dtData, string strMODEL_NAME)
         {
             p_dtData.Clear();

             string strSql = "";
             strSql += "select * from COSTUME_MODEL_LIMIT";
             strSql += " where ";
               strSql += " MODEL_NAME='"+ strMODEL_NAME +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public COSTUME_MODEL_LIMIT[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
      {
          int m_intPageNumber = p_intPageNumber;
          int m_intPageCount = GetPageCount(p_strWhere, p_intPageSize);

          if((m_intPageNumber < 1) || (m_intPageNumber == 0))
          {
               m_intPageNumber = 1;
          }

          if(m_intPageNumber == -1)
          {
               m_intPageNumber = m_intPageCount;
          }

          if(m_intPageNumber > m_intPageCount)
          {
               m_intPageNumber = m_intPageCount;
          }

          string strSql = "";
          strSql += "select * from COSTUME_MODEL_LIMIT";
          if(p_strWhere.Trim().Length > 0)
          {
               strSql += " where " + p_strWhere;
          }
          if(p_strOrder.Trim().Length > 0)
          {
               strSql += " order by " + p_strOrder;
          }

          DataTable dtTemp = new DataTable();

          if(p_intPageSize > 0)
          {
               DbHelper.GetTable(Conn, strSql, ref dtTemp, (m_intPageNumber-1)*p_intPageSize, p_intPageSize);
          }
          else
          {
               DbHelper.GetTable(Conn, strSql, ref dtTemp);
          }

          COSTUME_MODEL_LIMIT[] arrModel=new COSTUME_MODEL_LIMIT[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new COSTUME_MODEL_LIMIT();

                 arrModel[N].MODEL_NAME = dtTemp.Rows[N]["MODEL_NAME"] == DBNull.Value ? "" : dtTemp.Rows[N]["MODEL_NAME"].ToString();
                 arrModel[N].METHOD_NAME = dtTemp.Rows[N]["METHOD_NAME"] == DBNull.Value ? "" : dtTemp.Rows[N]["METHOD_NAME"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public COSTUME_MODEL_LIMIT[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public COSTUME_MODEL_LIMIT[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public COSTUME_MODEL_LIMIT[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public COSTUME_MODEL_LIMIT[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public COSTUME_MODEL_LIMIT[] GetModelList()
      {
          return GetModelList("", "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
      {
          p_dtData.Clear();

          int m_intPageNumber = p_intPageNumber;
          int m_intPageCount = GetPageCount(p_strWhere, p_intPageSize);

          if((m_intPageNumber < 1) || (m_intPageNumber == 0))
          {
              m_intPageNumber = 1;
          }

          if(m_intPageNumber == -1)
          {
              m_intPageNumber = m_intPageCount;
          }

          if(m_intPageNumber > m_intPageCount)
          {
              m_intPageNumber = m_intPageCount;
          }

          string strSql = "";
          strSql += "select * from COSTUME_MODEL_LIMIT";
          if(p_strWhere.Trim().Length > 0)
          {
              strSql += " where " + p_strWhere;
          }
          if(p_strOrder.Trim().Length > 0)
          {
              strSql += " order by " + p_strOrder;
          }

          if(p_intPageSize > 0)
          {
              DbHelper.GetTable(Conn, strSql, ref p_dtData, (m_intPageNumber-1)*p_intPageSize, p_intPageSize);
          }
          else
          {
              DbHelper.GetTable(Conn, strSql, ref p_dtData);
          }
       }

       /// <summary>
       /// 得到对象集合
       /// </summary>
       public void GetModelList(ref DataTable p_dtData, string p_strWhere)
       {
           GetModelList(ref p_dtData, p_strWhere, "", -1, -1);
       }

       /// <summary>
       /// 得到对象集合
       /// </summary>
       public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder)
       {
           GetModelList(ref p_dtData, p_strWhere, p_strOrder, -1, -1);
       }

       /// <summary>
       /// 得到对象集合
       /// </summary>
       public void GetModelList(ref DataTable p_dtData, int p_intPageNumber, int p_intPageSize)
       {
           GetModelList(ref p_dtData, "", "", p_intPageNumber, p_intPageSize);
       }

       /// <summary>
       /// 得到对象集合
       /// </summary>
       public void GetModelList(ref DataTable p_dtData, string p_strWhere, int p_intPageNumber, int p_intPageSize)
       {
           GetModelList(ref p_dtData, p_strWhere, "", p_intPageNumber, p_intPageSize);
       }
       /// <summary>
       /// 得到对象集合
       /// </summary>
       public void GetModelList(ref DataTable p_dtData)
       {
           GetModelList(ref p_dtData, "", "", -1, -1);
       }
   }
}
