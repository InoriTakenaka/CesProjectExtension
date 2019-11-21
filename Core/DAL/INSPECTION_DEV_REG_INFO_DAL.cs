using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层INSPECTION_DEV_REG_INFO_DAL
     /// </summary>
     public class INSPECTION_DEV_REG_INFO_DAL
     {
         private string Conn{ get;set; }
         public INSPECTION_DEV_REG_INFO_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大ID
         /// </summary>
         public int GetMax_ID(string p_strWhere)
         {
             int intResult = 0;
             string strSql = "select max(ID) as m from INSPECTION_DEV_REG_INFO";

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
               strSql += "select count(1) as c from INSPECTION_DEV_REG_INFO";
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
              strSql += "select count(1) as c from INSPECTION_DEV_REG_INFO";
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
          public string InsertSQL(INSPECTION_DEV_REG_INFO model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("JCXH") == true && model.JCXH != null)
              {
                   strFieldSQL += ",JCXH";
                   strValueSQL += "," + model.JCXH + "";
              }

              if(model.Changed("SBLX") == true && model.SBLX != null)
              {
                   strFieldSQL += ",SBLX";
                   strValueSQL += ",'" + model.SBLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBMC") == true && model.SBMC != null)
              {
                   strFieldSQL += ",SBMC";
                   strValueSQL += ",'" + model.SBMC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBMCDH") == true && model.SBMCDH != null)
              {
                   strFieldSQL += ",SBMCDH";
                   strValueSQL += ",'" + model.SBMCDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBZZC") == true && model.SBZZC != null)
              {
                   strFieldSQL += ",SBZZC";
                   strValueSQL += ",'" + model.SBZZC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBXH") == true && model.SBXH != null)
              {
                   strFieldSQL += ",SBXH";
                   strValueSQL += ",'" + model.SBXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBCCBH") == true && model.SBCCBH != null)
              {
                   strFieldSQL += ",SBCCBH";
                   strValueSQL += ",'" + model.SBCCBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBCCRQ") == true && model.SBCCRQ != null)
              {
                   strFieldSQL += ",SBCCRQ";
                   strValueSQL += ",'" + model.SBCCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBRZBH") == true && model.SBRZBH != null)
              {
                   strFieldSQL += ",SBRZBH";
                   strValueSQL += ",'" + model.SBRZBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBRZRQ") == true && model.SBRZRQ != null)
              {
                   strFieldSQL += ",SBRZRQ";
                   strValueSQL += ",'" + model.SBRZRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBRZYXQZ") == true && model.SBRZYXQZ != null)
              {
                   strFieldSQL += ",SBRZYXQZ";
                   strValueSQL += ",'" + model.SBRZYXQZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JLBDBH") == true && model.JLBDBH != null)
              {
                   strFieldSQL += ",JLBDBH";
                   strValueSQL += ",'" + model.JLBDBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JLBDRQ") == true && model.JLBDRQ != null)
              {
                   strFieldSQL += ",JLBDRQ";
                   strValueSQL += ",'" + model.JLBDRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JLBDYXQZ") == true && model.JLBDYXQZ != null)
              {
                   strFieldSQL += ",JLBDYXQZ";
                   strValueSQL += ",'" + model.JLBDYXQZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BZ") == true && model.BZ != null)
              {
                   strFieldSQL += ",BZ";
                   strValueSQL += ",'" + model.BZ.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into INSPECTION_DEV_REG_INFO";
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
          public bool Insert(INSPECTION_DEV_REG_INFO model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(INSPECTION_DEV_REG_INFO model,int intID)
          {
              string strUpdateSQL = "";

              if(model.Changed("JCXH") == true && model.JCXH != null)
              {
                  strUpdateSQL += ",JCXH=" + model.JCXH + "";
              }

              if(model.Changed("SBLX") == true && model.SBLX != null)
              {
                  strUpdateSQL += ",SBLX='" + model.SBLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBMC") == true && model.SBMC != null)
              {
                  strUpdateSQL += ",SBMC='" + model.SBMC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBMCDH") == true && model.SBMCDH != null)
              {
                  strUpdateSQL += ",SBMCDH='" + model.SBMCDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBZZC") == true && model.SBZZC != null)
              {
                  strUpdateSQL += ",SBZZC='" + model.SBZZC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBXH") == true && model.SBXH != null)
              {
                  strUpdateSQL += ",SBXH='" + model.SBXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBCCBH") == true && model.SBCCBH != null)
              {
                  strUpdateSQL += ",SBCCBH='" + model.SBCCBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBCCRQ") == true && model.SBCCRQ != null)
              {
                  strUpdateSQL += ",SBCCRQ='" + model.SBCCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBRZBH") == true && model.SBRZBH != null)
              {
                  strUpdateSQL += ",SBRZBH='" + model.SBRZBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBRZRQ") == true && model.SBRZRQ != null)
              {
                  strUpdateSQL += ",SBRZRQ='" + model.SBRZRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SBRZYXQZ") == true && model.SBRZYXQZ != null)
              {
                  strUpdateSQL += ",SBRZYXQZ='" + model.SBRZYXQZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JLBDBH") == true && model.JLBDBH != null)
              {
                  strUpdateSQL += ",JLBDBH='" + model.JLBDBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JLBDRQ") == true && model.JLBDRQ != null)
              {
                  strUpdateSQL += ",JLBDRQ='" + model.JLBDRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JLBDYXQZ") == true && model.JLBDYXQZ != null)
              {
                  strUpdateSQL += ",JLBDYXQZ='" + model.JLBDYXQZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BZ") == true && model.BZ != null)
              {
                  strUpdateSQL += ",BZ='" + model.BZ.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update INSPECTION_DEV_REG_INFO set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " ID="+ intID +"";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(INSPECTION_DEV_REG_INFO model, int intID)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, intID));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(INSPECTION_DEV_REG_INFO model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("JCXH") == true && model.JCXH != null)
               {
                  strUpdateSQL += ",JCXH=" + model.JCXH + "";
               }

               if(model.Changed("SBLX") == true && model.SBLX != null)
               {
                  strUpdateSQL += ",SBLX='" + model.SBLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBMC") == true && model.SBMC != null)
               {
                  strUpdateSQL += ",SBMC='" + model.SBMC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBMCDH") == true && model.SBMCDH != null)
               {
                  strUpdateSQL += ",SBMCDH='" + model.SBMCDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBZZC") == true && model.SBZZC != null)
               {
                  strUpdateSQL += ",SBZZC='" + model.SBZZC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBXH") == true && model.SBXH != null)
               {
                  strUpdateSQL += ",SBXH='" + model.SBXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBCCBH") == true && model.SBCCBH != null)
               {
                  strUpdateSQL += ",SBCCBH='" + model.SBCCBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBCCRQ") == true && model.SBCCRQ != null)
               {
                  strUpdateSQL += ",SBCCRQ='" + model.SBCCRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBRZBH") == true && model.SBRZBH != null)
               {
                  strUpdateSQL += ",SBRZBH='" + model.SBRZBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBRZRQ") == true && model.SBRZRQ != null)
               {
                  strUpdateSQL += ",SBRZRQ='" + model.SBRZRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SBRZYXQZ") == true && model.SBRZYXQZ != null)
               {
                  strUpdateSQL += ",SBRZYXQZ='" + model.SBRZYXQZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JLBDBH") == true && model.JLBDBH != null)
               {
                  strUpdateSQL += ",JLBDBH='" + model.JLBDBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JLBDRQ") == true && model.JLBDRQ != null)
               {
                  strUpdateSQL += ",JLBDRQ='" + model.JLBDRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JLBDYXQZ") == true && model.JLBDYXQZ != null)
               {
                  strUpdateSQL += ",JLBDYXQZ='" + model.JLBDYXQZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BZ") == true && model.BZ != null)
               {
                  strUpdateSQL += ",BZ='" + model.BZ.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update INSPECTION_DEV_REG_INFO set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(INSPECTION_DEV_REG_INFO model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(INSPECTION_DEV_REG_INFO model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",JCXH=" + model.JCXH + "";
                  strUpdateSQL += ",SBLX='" + model.SBLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBMC='" + model.SBMC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBMCDH='" + model.SBMCDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBZZC='" + model.SBZZC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBXH='" + model.SBXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBCCBH='" + model.SBCCBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBCCRQ='" + model.SBCCRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBRZBH='" + model.SBRZBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBRZRQ='" + model.SBRZRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SBRZYXQZ='" + model.SBRZYXQZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JLBDBH='" + model.JLBDBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JLBDRQ='" + model.JLBDRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JLBDYXQZ='" + model.JLBDYXQZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BZ='" + model.BZ.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update INSPECTION_DEV_REG_INFO set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(INSPECTION_DEV_REG_INFO model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(int intID)
          {
              string strSql = "";
              strSql += "delete from INSPECTION_DEV_REG_INFO";
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
              strSql += "delete from INSPECTION_DEV_REG_INFO";
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
              strSql += "delete from INSPECTION_DEV_REG_INFO";

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
         public INSPECTION_DEV_REG_INFO GetModel(int intID)
         {
             string strSql = "";
             strSql += "select * from INSPECTION_DEV_REG_INFO";
             strSql += " where ";
               strSql += " ID="+ intID +"";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             INSPECTION_DEV_REG_INFO model = new INSPECTION_DEV_REG_INFO();

             if(dtTemp.Rows.Count>0)
             {
                 model = new INSPECTION_DEV_REG_INFO();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.JCXH = dtTemp.Rows[0]["JCXH"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["JCXH"]);
                 model.SBLX = dtTemp.Rows[0]["SBLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBLX"].ToString();
                 model.SBMC = dtTemp.Rows[0]["SBMC"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBMC"].ToString();
                 model.SBMCDH = dtTemp.Rows[0]["SBMCDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBMCDH"].ToString();
                 model.SBZZC = dtTemp.Rows[0]["SBZZC"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBZZC"].ToString();
                 model.SBXH = dtTemp.Rows[0]["SBXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBXH"].ToString();
                 model.SBCCBH = dtTemp.Rows[0]["SBCCBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBCCBH"].ToString();
                 model.SBCCRQ = dtTemp.Rows[0]["SBCCRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBCCRQ"].ToString();
                 model.SBRZBH = dtTemp.Rows[0]["SBRZBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBRZBH"].ToString();
                 model.SBRZRQ = dtTemp.Rows[0]["SBRZRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBRZRQ"].ToString();
                 model.SBRZYXQZ = dtTemp.Rows[0]["SBRZYXQZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SBRZYXQZ"].ToString();
                 model.JLBDBH = dtTemp.Rows[0]["JLBDBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JLBDBH"].ToString();
                 model.JLBDRQ = dtTemp.Rows[0]["JLBDRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JLBDRQ"].ToString();
                 model.JLBDYXQZ = dtTemp.Rows[0]["JLBDYXQZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JLBDYXQZ"].ToString();
                 model.BZ = dtTemp.Rows[0]["BZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["BZ"].ToString();
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
             strSql += "select * from INSPECTION_DEV_REG_INFO";
             strSql += " where ";
               strSql += " ID="+ intID +"";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public INSPECTION_DEV_REG_INFO[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from INSPECTION_DEV_REG_INFO";
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

          INSPECTION_DEV_REG_INFO[] arrModel=new INSPECTION_DEV_REG_INFO[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new INSPECTION_DEV_REG_INFO();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].JCXH = dtTemp.Rows[N]["JCXH"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["JCXH"]);
                 arrModel[N].SBLX = dtTemp.Rows[N]["SBLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBLX"].ToString();
                 arrModel[N].SBMC = dtTemp.Rows[N]["SBMC"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBMC"].ToString();
                 arrModel[N].SBMCDH = dtTemp.Rows[N]["SBMCDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBMCDH"].ToString();
                 arrModel[N].SBZZC = dtTemp.Rows[N]["SBZZC"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBZZC"].ToString();
                 arrModel[N].SBXH = dtTemp.Rows[N]["SBXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBXH"].ToString();
                 arrModel[N].SBCCBH = dtTemp.Rows[N]["SBCCBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBCCBH"].ToString();
                 arrModel[N].SBCCRQ = dtTemp.Rows[N]["SBCCRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBCCRQ"].ToString();
                 arrModel[N].SBRZBH = dtTemp.Rows[N]["SBRZBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBRZBH"].ToString();
                 arrModel[N].SBRZRQ = dtTemp.Rows[N]["SBRZRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBRZRQ"].ToString();
                 arrModel[N].SBRZYXQZ = dtTemp.Rows[N]["SBRZYXQZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SBRZYXQZ"].ToString();
                 arrModel[N].JLBDBH = dtTemp.Rows[N]["JLBDBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JLBDBH"].ToString();
                 arrModel[N].JLBDRQ = dtTemp.Rows[N]["JLBDRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JLBDRQ"].ToString();
                 arrModel[N].JLBDYXQZ = dtTemp.Rows[N]["JLBDYXQZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JLBDYXQZ"].ToString();
                 arrModel[N].BZ = dtTemp.Rows[N]["BZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["BZ"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public INSPECTION_DEV_REG_INFO[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public INSPECTION_DEV_REG_INFO[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public INSPECTION_DEV_REG_INFO[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public INSPECTION_DEV_REG_INFO[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public INSPECTION_DEV_REG_INFO[] GetModelList()
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
          strSql += "select * from INSPECTION_DEV_REG_INFO";
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
