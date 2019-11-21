using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_ZYJS_DAL
     /// </summary>
     public class RESULT_ZYJS_DAL
     {
         private string Conn{ get;set; }
         public RESULT_ZYJS_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(JCLSH) as m from RESULT_ZYJS";

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
          /// 得到最大JCLSH
          /// </summary>
          public string GetMax_JCLSH()
          {
              return GetMax_JCLSH("");
          }


          /// <summary>
          /// 判断数据是否存在
          /// </summary>
          public bool Exists(string strJCLSH)
          {
               bool bolResult = false;

               if (strJCLSH == null)
               {
                   return false;
               }

               if (strJCLSH.Length == 0)
               {
                   return false;
               }

               string strSql = "";
               strSql += "select count(1) as c from RESULT_ZYJS";
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

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
              strSql += "select count(1) as c from RESULT_ZYJS";
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
          public string InsertSQL(RESULT_ZYJS model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("ZYJSJCCS") == true && model.ZYJSJCCS != null)
              {
                   strFieldSQL += ",ZYJSJCCS";
                   strValueSQL += ",'" + model.ZYJSJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG1") == true && model.ZYJSJG1 != null)
              {
                   strFieldSQL += ",ZYJSJG1";
                   strValueSQL += ",'" + model.ZYJSJG1.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG2") == true && model.ZYJSJG2 != null)
              {
                   strFieldSQL += ",ZYJSJG2";
                   strValueSQL += ",'" + model.ZYJSJG2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG3") == true && model.ZYJSJG3 != null)
              {
                   strFieldSQL += ",ZYJSJG3";
                   strValueSQL += ",'" + model.ZYJSJG3.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG4") == true && model.ZYJSJG4 != null)
              {
                   strFieldSQL += ",ZYJSJG4";
                   strValueSQL += ",'" + model.ZYJSJG4.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSPJZ") == true && model.ZYJSPJZ != null)
              {
                   strFieldSQL += ",ZYJSPJZ";
                   strValueSQL += ",'" + model.ZYJSPJZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSXZ") == true && model.ZYJSXZ != null)
              {
                   strFieldSQL += ",ZYJSXZ";
                   strValueSQL += ",'" + model.ZYJSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJS_PD") == true && model.ZYJS_PD != null)
              {
                   strFieldSQL += ",ZYJS_PD";
                   strValueSQL += ",'" + model.ZYJS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSYW") == true && model.ZYJSYW != null)
              {
                   strFieldSQL += ",ZYJSYW";
                   strValueSQL += ",'" + model.ZYJSYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSDSZS") == true && model.ZYJSDSZS != null)
              {
                   strFieldSQL += ",ZYJSDSZS";
                   strValueSQL += ",'" + model.ZYJSDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSWD") == true && model.ZYJSWD != null)
              {
                   strFieldSQL += ",ZYJSWD";
                   strValueSQL += ",'" + model.ZYJSWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSDQY") == true && model.ZYJSDQY != null)
              {
                   strFieldSQL += ",ZYJSDQY";
                   strValueSQL += ",'" + model.ZYJSDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSSD") == true && model.ZYJSSD != null)
              {
                   strFieldSQL += ",ZYJSSD";
                   strValueSQL += ",'" + model.ZYJSSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KSSJ") == true && model.KSSJ != null)
              {
                   strFieldSQL += ",KSSJ";
                   strValueSQL += ",'" + model.KSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSSJ") == true && model.JSSJ != null)
              {
                   strFieldSQL += ",JSSJ";
                   strValueSQL += ",'" + model.JSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFLZS") == true && model.SFLZS != null)
              {
                   strFieldSQL += ",SFLZS";
                   strValueSQL += ",'" + model.SFLZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSJG2") == true && model.PT_ZYJSJG2 != null)
              {
                   strFieldSQL += ",PT_ZYJSJG2";
                   strValueSQL += ",'" + model.PT_ZYJSJG2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSJG3") == true && model.PT_ZYJSJG3 != null)
              {
                   strFieldSQL += ",PT_ZYJSJG3";
                   strValueSQL += ",'" + model.PT_ZYJSJG3.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSJG4") == true && model.PT_ZYJSJG4 != null)
              {
                   strFieldSQL += ",PT_ZYJSJG4";
                   strValueSQL += ",'" + model.PT_ZYJSJG4.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSPJZ") == true && model.PT_ZYJSPJZ != null)
              {
                   strFieldSQL += ",PT_ZYJSPJZ";
                   strValueSQL += ",'" + model.PT_ZYJSPJZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSDSZS") == true && model.PT_ZYJSDSZS != null)
              {
                   strFieldSQL += ",PT_ZYJSDSZS";
                   strValueSQL += ",'" + model.PT_ZYJSDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJS_PD") == true && model.PT_ZYJS_PD != null)
              {
                   strFieldSQL += ",PT_ZYJS_PD";
                   strValueSQL += ",'" + model.PT_ZYJS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS1") == true && model.ZYJSZS1 != null)
              {
                   strFieldSQL += ",ZYJSZS1";
                   strValueSQL += ",'" + model.ZYJSZS1.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS2") == true && model.ZYJSZS2 != null)
              {
                   strFieldSQL += ",ZYJSZS2";
                   strValueSQL += ",'" + model.ZYJSZS2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS3") == true && model.ZYJSZS3 != null)
              {
                   strFieldSQL += ",ZYJSZS3";
                   strValueSQL += ",'" + model.ZYJSZS3.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS4") == true && model.ZYJSZS4 != null)
              {
                   strFieldSQL += ",ZYJSZS4";
                   strValueSQL += ",'" + model.ZYJSZS4.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_ZYJS";
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
          public bool Insert(RESULT_ZYJS model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_ZYJS model,string strJCLSH)
          {
              string strUpdateSQL = "";

              if(model.Changed("ZYJSJCCS") == true && model.ZYJSJCCS != null)
              {
                  strUpdateSQL += ",ZYJSJCCS='" + model.ZYJSJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG1") == true && model.ZYJSJG1 != null)
              {
                  strUpdateSQL += ",ZYJSJG1='" + model.ZYJSJG1.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG2") == true && model.ZYJSJG2 != null)
              {
                  strUpdateSQL += ",ZYJSJG2='" + model.ZYJSJG2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG3") == true && model.ZYJSJG3 != null)
              {
                  strUpdateSQL += ",ZYJSJG3='" + model.ZYJSJG3.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSJG4") == true && model.ZYJSJG4 != null)
              {
                  strUpdateSQL += ",ZYJSJG4='" + model.ZYJSJG4.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSPJZ") == true && model.ZYJSPJZ != null)
              {
                  strUpdateSQL += ",ZYJSPJZ='" + model.ZYJSPJZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSXZ") == true && model.ZYJSXZ != null)
              {
                  strUpdateSQL += ",ZYJSXZ='" + model.ZYJSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJS_PD") == true && model.ZYJS_PD != null)
              {
                  strUpdateSQL += ",ZYJS_PD='" + model.ZYJS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSYW") == true && model.ZYJSYW != null)
              {
                  strUpdateSQL += ",ZYJSYW='" + model.ZYJSYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSDSZS") == true && model.ZYJSDSZS != null)
              {
                  strUpdateSQL += ",ZYJSDSZS='" + model.ZYJSDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSWD") == true && model.ZYJSWD != null)
              {
                  strUpdateSQL += ",ZYJSWD='" + model.ZYJSWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSDQY") == true && model.ZYJSDQY != null)
              {
                  strUpdateSQL += ",ZYJSDQY='" + model.ZYJSDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSSD") == true && model.ZYJSSD != null)
              {
                  strUpdateSQL += ",ZYJSSD='" + model.ZYJSSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KSSJ") == true && model.KSSJ != null)
              {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSSJ") == true && model.JSSJ != null)
              {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFLZS") == true && model.SFLZS != null)
              {
                  strUpdateSQL += ",SFLZS='" + model.SFLZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSJG2") == true && model.PT_ZYJSJG2 != null)
              {
                  strUpdateSQL += ",PT_ZYJSJG2='" + model.PT_ZYJSJG2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSJG3") == true && model.PT_ZYJSJG3 != null)
              {
                  strUpdateSQL += ",PT_ZYJSJG3='" + model.PT_ZYJSJG3.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSJG4") == true && model.PT_ZYJSJG4 != null)
              {
                  strUpdateSQL += ",PT_ZYJSJG4='" + model.PT_ZYJSJG4.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSPJZ") == true && model.PT_ZYJSPJZ != null)
              {
                  strUpdateSQL += ",PT_ZYJSPJZ='" + model.PT_ZYJSPJZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJSDSZS") == true && model.PT_ZYJSDSZS != null)
              {
                  strUpdateSQL += ",PT_ZYJSDSZS='" + model.PT_ZYJSDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ZYJS_PD") == true && model.PT_ZYJS_PD != null)
              {
                  strUpdateSQL += ",PT_ZYJS_PD='" + model.PT_ZYJS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS1") == true && model.ZYJSZS1 != null)
              {
                  strUpdateSQL += ",ZYJSZS1='" + model.ZYJSZS1.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS2") == true && model.ZYJSZS2 != null)
              {
                  strUpdateSQL += ",ZYJSZS2='" + model.ZYJSZS2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS3") == true && model.ZYJSZS3 != null)
              {
                  strUpdateSQL += ",ZYJSZS3='" + model.ZYJSZS3.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYJSZS4") == true && model.ZYJSZS4 != null)
              {
                  strUpdateSQL += ",ZYJSZS4='" + model.ZYJSZS4.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_ZYJS set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_ZYJS model, string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strJCLSH));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_ZYJS model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("ZYJSJCCS") == true && model.ZYJSJCCS != null)
               {
                  strUpdateSQL += ",ZYJSJCCS='" + model.ZYJSJCCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSJG1") == true && model.ZYJSJG1 != null)
               {
                  strUpdateSQL += ",ZYJSJG1='" + model.ZYJSJG1.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSJG2") == true && model.ZYJSJG2 != null)
               {
                  strUpdateSQL += ",ZYJSJG2='" + model.ZYJSJG2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSJG3") == true && model.ZYJSJG3 != null)
               {
                  strUpdateSQL += ",ZYJSJG3='" + model.ZYJSJG3.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSJG4") == true && model.ZYJSJG4 != null)
               {
                  strUpdateSQL += ",ZYJSJG4='" + model.ZYJSJG4.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSPJZ") == true && model.ZYJSPJZ != null)
               {
                  strUpdateSQL += ",ZYJSPJZ='" + model.ZYJSPJZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSXZ") == true && model.ZYJSXZ != null)
               {
                  strUpdateSQL += ",ZYJSXZ='" + model.ZYJSXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJS_PD") == true && model.ZYJS_PD != null)
               {
                  strUpdateSQL += ",ZYJS_PD='" + model.ZYJS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSYW") == true && model.ZYJSYW != null)
               {
                  strUpdateSQL += ",ZYJSYW='" + model.ZYJSYW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSDSZS") == true && model.ZYJSDSZS != null)
               {
                  strUpdateSQL += ",ZYJSDSZS='" + model.ZYJSDSZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSWD") == true && model.ZYJSWD != null)
               {
                  strUpdateSQL += ",ZYJSWD='" + model.ZYJSWD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSDQY") == true && model.ZYJSDQY != null)
               {
                  strUpdateSQL += ",ZYJSDQY='" + model.ZYJSDQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSSD") == true && model.ZYJSSD != null)
               {
                  strUpdateSQL += ",ZYJSSD='" + model.ZYJSSD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KSSJ") == true && model.KSSJ != null)
               {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JSSJ") == true && model.JSSJ != null)
               {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SFLZS") == true && model.SFLZS != null)
               {
                  strUpdateSQL += ",SFLZS='" + model.SFLZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ZYJSJG2") == true && model.PT_ZYJSJG2 != null)
               {
                  strUpdateSQL += ",PT_ZYJSJG2='" + model.PT_ZYJSJG2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ZYJSJG3") == true && model.PT_ZYJSJG3 != null)
               {
                  strUpdateSQL += ",PT_ZYJSJG3='" + model.PT_ZYJSJG3.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ZYJSJG4") == true && model.PT_ZYJSJG4 != null)
               {
                  strUpdateSQL += ",PT_ZYJSJG4='" + model.PT_ZYJSJG4.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ZYJSPJZ") == true && model.PT_ZYJSPJZ != null)
               {
                  strUpdateSQL += ",PT_ZYJSPJZ='" + model.PT_ZYJSPJZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ZYJSDSZS") == true && model.PT_ZYJSDSZS != null)
               {
                  strUpdateSQL += ",PT_ZYJSDSZS='" + model.PT_ZYJSDSZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ZYJS_PD") == true && model.PT_ZYJS_PD != null)
               {
                  strUpdateSQL += ",PT_ZYJS_PD='" + model.PT_ZYJS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSZS1") == true && model.ZYJSZS1 != null)
               {
                  strUpdateSQL += ",ZYJSZS1='" + model.ZYJSZS1.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSZS2") == true && model.ZYJSZS2 != null)
               {
                  strUpdateSQL += ",ZYJSZS2='" + model.ZYJSZS2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSZS3") == true && model.ZYJSZS3 != null)
               {
                  strUpdateSQL += ",ZYJSZS3='" + model.ZYJSZS3.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYJSZS4") == true && model.ZYJSZS4 != null)
               {
                  strUpdateSQL += ",ZYJSZS4='" + model.ZYJSZS4.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_ZYJS set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_ZYJS model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_ZYJS model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",ZYJSJCCS='" + model.ZYJSJCCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSJG1='" + model.ZYJSJG1.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSJG2='" + model.ZYJSJG2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSJG3='" + model.ZYJSJG3.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSJG4='" + model.ZYJSJG4.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSPJZ='" + model.ZYJSPJZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSXZ='" + model.ZYJSXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJS_PD='" + model.ZYJS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSYW='" + model.ZYJSYW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSDSZS='" + model.ZYJSDSZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSWD='" + model.ZYJSWD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSDQY='" + model.ZYJSDQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSSD='" + model.ZYJSSD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SFLZS='" + model.SFLZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ZYJSJG2='" + model.PT_ZYJSJG2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ZYJSJG3='" + model.PT_ZYJSJG3.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ZYJSJG4='" + model.PT_ZYJSJG4.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ZYJSPJZ='" + model.PT_ZYJSPJZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ZYJSDSZS='" + model.PT_ZYJSDSZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ZYJS_PD='" + model.PT_ZYJS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSZS1='" + model.ZYJSZS1.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSZS2='" + model.ZYJSZS2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSZS3='" + model.ZYJSZS3.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYJSZS4='" + model.ZYJSZS4.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_ZYJS set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_ZYJS model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strJCLSH)
          {
              string strSql = "";
              strSql += "delete from RESULT_ZYJS";
              strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              return strSql;

          }

          /// <summary>
          /// 删除一条数据
          /// </summary>
          public bool Delete(string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, DeleteSQL(strJCLSH));
          }

          /// <summary>
          /// 删除一个集合 SQL
          /// </summary>
          public string DeleteRangeSQL(string p_strWhere)
          {
              string strSql = "";
              strSql += "delete from RESULT_ZYJS";
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
              strSql += "delete from RESULT_ZYJS";

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
         public RESULT_ZYJS GetModel(string strJCLSH)
         {
             string strSql = "";
             strSql += "select * from RESULT_ZYJS";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_ZYJS model = new RESULT_ZYJS();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_ZYJS();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.ZYJSJCCS = dtTemp.Rows[0]["ZYJSJCCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSJCCS"].ToString();
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.ZYJSJG1 = dtTemp.Rows[0]["ZYJSJG1"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSJG1"].ToString();
                 model.ZYJSJG2 = dtTemp.Rows[0]["ZYJSJG2"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSJG2"].ToString();
                 model.ZYJSJG3 = dtTemp.Rows[0]["ZYJSJG3"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSJG3"].ToString();
                 model.ZYJSJG4 = dtTemp.Rows[0]["ZYJSJG4"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSJG4"].ToString();
                 model.ZYJSPJZ = dtTemp.Rows[0]["ZYJSPJZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSPJZ"].ToString();
                 model.ZYJSXZ = dtTemp.Rows[0]["ZYJSXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSXZ"].ToString();
                 model.ZYJS_PD = dtTemp.Rows[0]["ZYJS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJS_PD"].ToString();
                 model.ZYJSYW = dtTemp.Rows[0]["ZYJSYW"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSYW"].ToString();
                 model.ZYJSDSZS = dtTemp.Rows[0]["ZYJSDSZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSDSZS"].ToString();
                 model.ZYJSWD = dtTemp.Rows[0]["ZYJSWD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSWD"].ToString();
                 model.ZYJSDQY = dtTemp.Rows[0]["ZYJSDQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSDQY"].ToString();
                 model.ZYJSSD = dtTemp.Rows[0]["ZYJSSD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSSD"].ToString();
                 model.KSSJ = dtTemp.Rows[0]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["KSSJ"].ToString();
                 model.JSSJ = dtTemp.Rows[0]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JSSJ"].ToString();
                 model.SFLZS = dtTemp.Rows[0]["SFLZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["SFLZS"].ToString();
                 model.PT_ZYJSJG2 = dtTemp.Rows[0]["PT_ZYJSJG2"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ZYJSJG2"].ToString();
                 model.PT_ZYJSJG3 = dtTemp.Rows[0]["PT_ZYJSJG3"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ZYJSJG3"].ToString();
                 model.PT_ZYJSJG4 = dtTemp.Rows[0]["PT_ZYJSJG4"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ZYJSJG4"].ToString();
                 model.PT_ZYJSPJZ = dtTemp.Rows[0]["PT_ZYJSPJZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ZYJSPJZ"].ToString();
                 model.PT_ZYJSDSZS = dtTemp.Rows[0]["PT_ZYJSDSZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ZYJSDSZS"].ToString();
                 model.PT_ZYJS_PD = dtTemp.Rows[0]["PT_ZYJS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ZYJS_PD"].ToString();
                 model.ZYJSZS1 = dtTemp.Rows[0]["ZYJSZS1"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSZS1"].ToString();
                 model.ZYJSZS2 = dtTemp.Rows[0]["ZYJSZS2"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSZS2"].ToString();
                 model.ZYJSZS3 = dtTemp.Rows[0]["ZYJSZS3"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSZS3"].ToString();
                 model.ZYJSZS4 = dtTemp.Rows[0]["ZYJSZS4"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYJSZS4"].ToString();
             }

             dtTemp.Dispose();

             return model;
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public void GetModel(ref DataTable p_dtData, string strJCLSH)
         {
             p_dtData.Clear();

             string strSql = "";
             strSql += "select * from RESULT_ZYJS";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ZYJS[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_ZYJS";
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

          RESULT_ZYJS[] arrModel=new RESULT_ZYJS[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_ZYJS();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].ZYJSJCCS = dtTemp.Rows[N]["ZYJSJCCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSJCCS"].ToString();
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].ZYJSJG1 = dtTemp.Rows[N]["ZYJSJG1"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSJG1"].ToString();
                 arrModel[N].ZYJSJG2 = dtTemp.Rows[N]["ZYJSJG2"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSJG2"].ToString();
                 arrModel[N].ZYJSJG3 = dtTemp.Rows[N]["ZYJSJG3"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSJG3"].ToString();
                 arrModel[N].ZYJSJG4 = dtTemp.Rows[N]["ZYJSJG4"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSJG4"].ToString();
                 arrModel[N].ZYJSPJZ = dtTemp.Rows[N]["ZYJSPJZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSPJZ"].ToString();
                 arrModel[N].ZYJSXZ = dtTemp.Rows[N]["ZYJSXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSXZ"].ToString();
                 arrModel[N].ZYJS_PD = dtTemp.Rows[N]["ZYJS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJS_PD"].ToString();
                 arrModel[N].ZYJSYW = dtTemp.Rows[N]["ZYJSYW"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSYW"].ToString();
                 arrModel[N].ZYJSDSZS = dtTemp.Rows[N]["ZYJSDSZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSDSZS"].ToString();
                 arrModel[N].ZYJSWD = dtTemp.Rows[N]["ZYJSWD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSWD"].ToString();
                 arrModel[N].ZYJSDQY = dtTemp.Rows[N]["ZYJSDQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSDQY"].ToString();
                 arrModel[N].ZYJSSD = dtTemp.Rows[N]["ZYJSSD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSSD"].ToString();
                 arrModel[N].KSSJ = dtTemp.Rows[N]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["KSSJ"].ToString();
                 arrModel[N].JSSJ = dtTemp.Rows[N]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JSSJ"].ToString();
                 arrModel[N].SFLZS = dtTemp.Rows[N]["SFLZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["SFLZS"].ToString();
                 arrModel[N].PT_ZYJSJG2 = dtTemp.Rows[N]["PT_ZYJSJG2"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ZYJSJG2"].ToString();
                 arrModel[N].PT_ZYJSJG3 = dtTemp.Rows[N]["PT_ZYJSJG3"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ZYJSJG3"].ToString();
                 arrModel[N].PT_ZYJSJG4 = dtTemp.Rows[N]["PT_ZYJSJG4"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ZYJSJG4"].ToString();
                 arrModel[N].PT_ZYJSPJZ = dtTemp.Rows[N]["PT_ZYJSPJZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ZYJSPJZ"].ToString();
                 arrModel[N].PT_ZYJSDSZS = dtTemp.Rows[N]["PT_ZYJSDSZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ZYJSDSZS"].ToString();
                 arrModel[N].PT_ZYJS_PD = dtTemp.Rows[N]["PT_ZYJS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ZYJS_PD"].ToString();
                 arrModel[N].ZYJSZS1 = dtTemp.Rows[N]["ZYJSZS1"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSZS1"].ToString();
                 arrModel[N].ZYJSZS2 = dtTemp.Rows[N]["ZYJSZS2"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSZS2"].ToString();
                 arrModel[N].ZYJSZS3 = dtTemp.Rows[N]["ZYJSZS3"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSZS3"].ToString();
                 arrModel[N].ZYJSZS4 = dtTemp.Rows[N]["ZYJSZS4"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYJSZS4"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ZYJS[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ZYJS[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ZYJS[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ZYJS[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ZYJS[] GetModelList()
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
          strSql += "select * from RESULT_ZYJS";
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
