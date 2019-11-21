using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层DEV_STANDARD_VMAS_DAL
     /// </summary>
     public class DEV_STANDARD_VMAS_DAL
     {
         private string Conn{ get;set; }
         public DEV_STANDARD_VMAS_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大ID
         /// </summary>
         public int GetMax_ID(string p_strWhere)
         {
             int intResult = 0;
             string strSql = "select max(ID) as m from DEV_STANDARD_VMAS";

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
                     intResult = dtTemp.Rows[0]["m"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["m"]);
                 }
             }

             dtTemp.Dispose();

             return intResult + 1;

          }

          /// <summary>
          /// 得到最大ID
          /// </summary>
          public int GetMax_ID()
          {
              return GetMax_ID("");
          }


          /// <summary>
          /// 判断数据是否存在
          /// </summary>
          public bool Exists(int intID)
          {
               bool bolResult = false;


               string strSql = "";
               strSql += "select count(1) as c from DEV_STANDARD_VMAS";
               strSql += " where ";
               strSql += " ID='"+ intID +"'";

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
              strSql += "select count(1) as c from DEV_STANDARD_VMAS";
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
          public string InsertSQL(DEV_STANDARD_VMAS model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("SEARCH_CONDITION") == true && model.SEARCH_CONDITION != null)
              {
                   strFieldSQL += ",SEARCH_CONDITION";
                   strValueSQL += ",'" + model.SEARCH_CONDITION.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXMC") == true && model.ZXMC != null)
              {
                   strFieldSQL += ",ZXMC";
                   strValueSQL += ",'" + model.ZXMC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("COXZ") == true && model.COXZ != null)
              {
                   strFieldSQL += ",COXZ";
                   strValueSQL += ",'" + model.COXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCXZ") == true && model.HCXZ != null)
              {
                   strFieldSQL += ",HCXZ";
                   strValueSQL += ",'" + model.HCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOXZ") == true && model.NOXZ != null)
              {
                   strFieldSQL += ",NOXZ";
                   strValueSQL += ",'" + model.NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NOXZ") == true && model.HC_NOXZ != null)
              {
                   strFieldSQL += ",HC_NOXZ";
                   strValueSQL += ",'" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PDFS") == true && model.PDFS != null)
              {
                   strFieldSQL += ",PDFS";
                   strValueSQL += ",'" + model.PDFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IS_SHOW") == true && model.IS_SHOW != null)
              {
                   strFieldSQL += ",IS_SHOW";
                   strValueSQL += "," + model.IS_SHOW + "";
              }

              if(model.Changed("AREA_NAME") == true && model.AREA_NAME != null)
              {
                   strFieldSQL += ",AREA_NAME";
                   strValueSQL += ",'" + model.AREA_NAME.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("UTYPE") == true && model.UTYPE != null)
              {
                   strFieldSQL += ",UTYPE";
                   strValueSQL += "," + model.UTYPE + "";
              }

              string strSql = "";
              strSql += "insert into DEV_STANDARD_VMAS";
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
          public bool Insert(DEV_STANDARD_VMAS model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(DEV_STANDARD_VMAS model,int intID)
          {
              string strUpdateSQL = "";

              if(model.Changed("SEARCH_CONDITION") == true && model.SEARCH_CONDITION != null)
              {
                  strUpdateSQL += ",SEARCH_CONDITION='" + model.SEARCH_CONDITION.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXMC") == true && model.ZXMC != null)
              {
                  strUpdateSQL += ",ZXMC='" + model.ZXMC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("COXZ") == true && model.COXZ != null)
              {
                  strUpdateSQL += ",COXZ='" + model.COXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCXZ") == true && model.HCXZ != null)
              {
                  strUpdateSQL += ",HCXZ='" + model.HCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOXZ") == true && model.NOXZ != null)
              {
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NOXZ") == true && model.HC_NOXZ != null)
              {
                  strUpdateSQL += ",HC_NOXZ='" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PDFS") == true && model.PDFS != null)
              {
                  strUpdateSQL += ",PDFS='" + model.PDFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IS_SHOW") == true && model.IS_SHOW != null)
              {
                  strUpdateSQL += ",IS_SHOW=" + model.IS_SHOW + "";
              }

              if(model.Changed("AREA_NAME") == true && model.AREA_NAME != null)
              {
                  strUpdateSQL += ",AREA_NAME='" + model.AREA_NAME.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("UTYPE") == true && model.UTYPE != null)
              {
                  strUpdateSQL += ",UTYPE=" + model.UTYPE + "";
              }

               string strSql = "";
               strSql += "update DEV_STANDARD_VMAS set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " ID="+ intID +"";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(DEV_STANDARD_VMAS model, int intID)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, intID));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(DEV_STANDARD_VMAS model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("SEARCH_CONDITION") == true && model.SEARCH_CONDITION != null)
               {
                  strUpdateSQL += ",SEARCH_CONDITION='" + model.SEARCH_CONDITION.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZXMC") == true && model.ZXMC != null)
               {
                  strUpdateSQL += ",ZXMC='" + model.ZXMC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("COXZ") == true && model.COXZ != null)
               {
                  strUpdateSQL += ",COXZ='" + model.COXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HCXZ") == true && model.HCXZ != null)
               {
                  strUpdateSQL += ",HCXZ='" + model.HCXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NOXZ") == true && model.NOXZ != null)
               {
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC_NOXZ") == true && model.HC_NOXZ != null)
               {
                  strUpdateSQL += ",HC_NOXZ='" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PDFS") == true && model.PDFS != null)
               {
                  strUpdateSQL += ",PDFS='" + model.PDFS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IS_SHOW") == true && model.IS_SHOW != null)
               {
                  strUpdateSQL += ",IS_SHOW=" + model.IS_SHOW + "";
               }

               if(model.Changed("AREA_NAME") == true && model.AREA_NAME != null)
               {
                  strUpdateSQL += ",AREA_NAME='" + model.AREA_NAME.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("UTYPE") == true && model.UTYPE != null)
               {
                  strUpdateSQL += ",UTYPE=" + model.UTYPE + "";
               }

              string strSql = "";
              strSql += "update DEV_STANDARD_VMAS set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(DEV_STANDARD_VMAS model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(DEV_STANDARD_VMAS model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",SEARCH_CONDITION='" + model.SEARCH_CONDITION.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZXMC='" + model.ZXMC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",COXZ='" + model.COXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HCXZ='" + model.HCXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC_NOXZ='" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PDFS='" + model.PDFS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IS_SHOW=" + model.IS_SHOW + "";
                  strUpdateSQL += ",AREA_NAME='" + model.AREA_NAME.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",UTYPE=" + model.UTYPE + "";


               string strSql = "";
               strSql += "update DEV_STANDARD_VMAS set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(DEV_STANDARD_VMAS model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(int intID)
          {
              string strSql = "";
              strSql += "delete from DEV_STANDARD_VMAS";
              strSql += " where ";
               strSql += " ID="+ intID +"";

              return strSql;

          }

          /// <summary>
          /// 删除一条数据
          /// </summary>
          public bool Delete(int intID)
          {
              return DbHelper.ExecuteSql(Conn, DeleteSQL(intID));
          }

          /// <summary>
          /// 删除一个集合 SQL
          /// </summary>
          public string DeleteRangeSQL(string p_strWhere)
          {
              string strSql = "";
              strSql += "delete from DEV_STANDARD_VMAS";
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
              strSql += "delete from DEV_STANDARD_VMAS";

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
         public DEV_STANDARD_VMAS GetModel(int intID)
         {
             string strSql = "";
             strSql += "select * from DEV_STANDARD_VMAS";
             strSql += " where ";
               strSql += " ID="+ intID +"";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             DEV_STANDARD_VMAS model = new DEV_STANDARD_VMAS();

             if(dtTemp.Rows.Count>0)
             {
                 model = new DEV_STANDARD_VMAS();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.SEARCH_CONDITION = dtTemp.Rows[0]["SEARCH_CONDITION"] == DBNull.Value ? "" : dtTemp.Rows[0]["SEARCH_CONDITION"].ToString();
                 model.ZXMC = dtTemp.Rows[0]["ZXMC"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZXMC"].ToString();
                 model.COXZ = dtTemp.Rows[0]["COXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["COXZ"].ToString();
                 model.HCXZ = dtTemp.Rows[0]["HCXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HCXZ"].ToString();
                 model.NOXZ = dtTemp.Rows[0]["NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["NOXZ"].ToString();
                 model.HC_NOXZ = dtTemp.Rows[0]["HC_NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC_NOXZ"].ToString();
                 model.PDFS = dtTemp.Rows[0]["PDFS"] == DBNull.Value ? "" : dtTemp.Rows[0]["PDFS"].ToString();
                 model.IS_SHOW = dtTemp.Rows[0]["IS_SHOW"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IS_SHOW"]);
                 model.AREA_NAME = dtTemp.Rows[0]["AREA_NAME"] == DBNull.Value ? "" : dtTemp.Rows[0]["AREA_NAME"].ToString();
                 model.UTYPE = dtTemp.Rows[0]["UTYPE"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["UTYPE"]);
             }

             dtTemp.Dispose();

             return model;
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public void GetModel(ref DataTable p_dtData, int intID)
         {
             p_dtData.Clear();

             string strSql = "";
             strSql += "select * from DEV_STANDARD_VMAS";
             strSql += " where ";
               strSql += " ID="+ intID +"";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public DEV_STANDARD_VMAS[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from DEV_STANDARD_VMAS";
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

          DEV_STANDARD_VMAS[] arrModel=new DEV_STANDARD_VMAS[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new DEV_STANDARD_VMAS();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].SEARCH_CONDITION = dtTemp.Rows[N]["SEARCH_CONDITION"] == DBNull.Value ? "" : dtTemp.Rows[N]["SEARCH_CONDITION"].ToString();
                 arrModel[N].ZXMC = dtTemp.Rows[N]["ZXMC"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZXMC"].ToString();
                 arrModel[N].COXZ = dtTemp.Rows[N]["COXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["COXZ"].ToString();
                 arrModel[N].HCXZ = dtTemp.Rows[N]["HCXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HCXZ"].ToString();
                 arrModel[N].NOXZ = dtTemp.Rows[N]["NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["NOXZ"].ToString();
                 arrModel[N].HC_NOXZ = dtTemp.Rows[N]["HC_NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC_NOXZ"].ToString();
                 arrModel[N].PDFS = dtTemp.Rows[N]["PDFS"] == DBNull.Value ? "" : dtTemp.Rows[N]["PDFS"].ToString();
                 arrModel[N].IS_SHOW = dtTemp.Rows[N]["IS_SHOW"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IS_SHOW"]);
                 arrModel[N].AREA_NAME = dtTemp.Rows[N]["AREA_NAME"] == DBNull.Value ? "" : dtTemp.Rows[N]["AREA_NAME"].ToString();
                 arrModel[N].UTYPE = dtTemp.Rows[N]["UTYPE"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["UTYPE"]);
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public DEV_STANDARD_VMAS[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public DEV_STANDARD_VMAS[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public DEV_STANDARD_VMAS[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public DEV_STANDARD_VMAS[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public DEV_STANDARD_VMAS[] GetModelList()
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
          strSql += "select * from DEV_STANDARD_VMAS";
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
