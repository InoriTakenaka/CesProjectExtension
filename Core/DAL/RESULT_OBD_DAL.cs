using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_OBD_DAL
     /// </summary>
     public class RESULT_OBD_DAL
     {
         private string Conn{ get;set; }
         public RESULT_OBD_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大ID
         /// </summary>
         public int GetMax_ID(string p_strWhere)
         {
             int intResult = 0;
             string strSql = "select max(ID) as m from RESULT_OBD";

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
               strSql += "select count(1) as c from RESULT_OBD";
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
              strSql += "select count(1) as c from RESULT_OBD";
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
          public string InsertSQL(RESULT_OBD model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VIN") == true && model.VIN != null)
              {
                   strFieldSQL += ",VIN";
                   strValueSQL += ",'" + model.VIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("testdate") == true && model.testdate != null)
              {
                   strFieldSQL += ",testdate";
                   strValueSQL += ",'" + model.testdate + "'";
              }

              if(model.Changed("isupdated") == true && model.isupdated != null)
              {
                   strFieldSQL += ",isupdated";
                   strValueSQL += "," + model.isupdated + "";
              }

              if(model.Changed("ZSD_PD") == true && model.ZSD_PD != null)
              {
                   strFieldSQL += ",ZSD_PD";
                   strValueSQL += ",'" + model.ZSD_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GZ_PD") == true && model.GZ_PD != null)
              {
                   strFieldSQL += ",GZ_PD";
                   strValueSQL += ",'" + model.GZ_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_VIN") == true && model.ECU_VIN != null)
              {
                   strFieldSQL += ",ECU_VIN";
                   strValueSQL += ",'" + model.ECU_VIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_CALID") == true && model.ECU_CALID != null)
              {
                   strFieldSQL += ",ECU_CALID";
                   strValueSQL += ",'" + model.ECU_CALID.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_CVN") == true && model.ECU_CVN != null)
              {
                   strFieldSQL += ",ECU_CVN";
                   strValueSQL += ",'" + model.ECU_CVN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_PD") == true && model.ECU_PD != null)
              {
                   strFieldSQL += ",ECU_PD";
                   strValueSQL += ",'" + model.ECU_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("TX_PD") == true && model.TX_PD != null)
              {
                   strFieldSQL += ",TX_PD";
                   strValueSQL += ",'" + model.TX_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JX_PD") == true && model.JX_PD != null)
              {
                   strFieldSQL += ",JX_PD";
                   strValueSQL += ",'" + model.JX_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ALL_PD") == true && model.ALL_PD != null)
              {
                   strFieldSQL += ",ALL_PD";
                   strValueSQL += ",'" + model.ALL_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FreezeData") == true && model.FreezeData != null)
              {
                   strFieldSQL += ",FreezeData";
                   strValueSQL += ",'" + model.FreezeData.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECUInfo") == true && model.ECUInfo != null)
              {
                   strFieldSQL += ",ECUInfo";
                   strValueSQL += ",'" + model.ECUInfo.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IUPR") == true && model.IUPR != null)
              {
                   strFieldSQL += ",IUPR";
                   strValueSQL += ",'" + model.IUPR.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SystemCheckState") == true && model.SystemCheckState != null)
              {
                   strFieldSQL += ",SystemCheckState";
                   strValueSQL += ",'" + model.SystemCheckState.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RTData") == true && model.RTData != null)
              {
                   strFieldSQL += ",RTData";
                   strValueSQL += ",'" + model.RTData.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SRTData") == true && model.SRTData != null)
              {
                   strFieldSQL += ",SRTData";
                   strValueSQL += ",'" + model.SRTData.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DTC") == true && model.DTC != null)
              {
                   strFieldSQL += ",DTC";
                   strValueSQL += ",'" + model.DTC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("TX_BHGYY") == true && model.TX_BHGYY != null)
              {
                   strFieldSQL += ",TX_BHGYY";
                   strValueSQL += ",'" + model.TX_BHGYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("TX_GZDZT") == true && model.TX_GZDZT != null)
              {
                   strFieldSQL += ",TX_GZDZT";
                   strValueSQL += ",'" + model.TX_GZDZT.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_OBD";
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
          public bool Insert(RESULT_OBD model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_OBD model,int intID)
          {
              string strUpdateSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VIN") == true && model.VIN != null)
              {
                  strUpdateSQL += ",VIN='" + model.VIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("testdate") == true && model.testdate != null)
              {
                  strUpdateSQL += ",testdate='" + model.testdate + "'";
              }

              if(model.Changed("isupdated") == true && model.isupdated != null)
              {
                  strUpdateSQL += ",isupdated=" + model.isupdated + "";
              }

              if(model.Changed("ZSD_PD") == true && model.ZSD_PD != null)
              {
                  strUpdateSQL += ",ZSD_PD='" + model.ZSD_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GZ_PD") == true && model.GZ_PD != null)
              {
                  strUpdateSQL += ",GZ_PD='" + model.GZ_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_VIN") == true && model.ECU_VIN != null)
              {
                  strUpdateSQL += ",ECU_VIN='" + model.ECU_VIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_CALID") == true && model.ECU_CALID != null)
              {
                  strUpdateSQL += ",ECU_CALID='" + model.ECU_CALID.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_CVN") == true && model.ECU_CVN != null)
              {
                  strUpdateSQL += ",ECU_CVN='" + model.ECU_CVN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECU_PD") == true && model.ECU_PD != null)
              {
                  strUpdateSQL += ",ECU_PD='" + model.ECU_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("TX_PD") == true && model.TX_PD != null)
              {
                  strUpdateSQL += ",TX_PD='" + model.TX_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JX_PD") == true && model.JX_PD != null)
              {
                  strUpdateSQL += ",JX_PD='" + model.JX_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ALL_PD") == true && model.ALL_PD != null)
              {
                  strUpdateSQL += ",ALL_PD='" + model.ALL_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FreezeData") == true && model.FreezeData != null)
              {
                  strUpdateSQL += ",FreezeData='" + model.FreezeData.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ECUInfo") == true && model.ECUInfo != null)
              {
                  strUpdateSQL += ",ECUInfo='" + model.ECUInfo.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IUPR") == true && model.IUPR != null)
              {
                  strUpdateSQL += ",IUPR='" + model.IUPR.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SystemCheckState") == true && model.SystemCheckState != null)
              {
                  strUpdateSQL += ",SystemCheckState='" + model.SystemCheckState.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RTData") == true && model.RTData != null)
              {
                  strUpdateSQL += ",RTData='" + model.RTData.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SRTData") == true && model.SRTData != null)
              {
                  strUpdateSQL += ",SRTData='" + model.SRTData.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DTC") == true && model.DTC != null)
              {
                  strUpdateSQL += ",DTC='" + model.DTC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("TX_BHGYY") == true && model.TX_BHGYY != null)
              {
                  strUpdateSQL += ",TX_BHGYY='" + model.TX_BHGYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("TX_GZDZT") == true && model.TX_GZDZT != null)
              {
                  strUpdateSQL += ",TX_GZDZT='" + model.TX_GZDZT.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_OBD set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " ID="+ intID +"";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_OBD model, int intID)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, intID));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_OBD model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("VIN") == true && model.VIN != null)
               {
                  strUpdateSQL += ",VIN='" + model.VIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("testdate") == true && model.testdate != null)
               {
                  strUpdateSQL += ",testdate='" + model.testdate + "'";
               }

               if(model.Changed("isupdated") == true && model.isupdated != null)
               {
                  strUpdateSQL += ",isupdated=" + model.isupdated + "";
               }

               if(model.Changed("ZSD_PD") == true && model.ZSD_PD != null)
               {
                  strUpdateSQL += ",ZSD_PD='" + model.ZSD_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GZ_PD") == true && model.GZ_PD != null)
               {
                  strUpdateSQL += ",GZ_PD='" + model.GZ_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ECU_VIN") == true && model.ECU_VIN != null)
               {
                  strUpdateSQL += ",ECU_VIN='" + model.ECU_VIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ECU_CALID") == true && model.ECU_CALID != null)
               {
                  strUpdateSQL += ",ECU_CALID='" + model.ECU_CALID.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ECU_CVN") == true && model.ECU_CVN != null)
               {
                  strUpdateSQL += ",ECU_CVN='" + model.ECU_CVN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ECU_PD") == true && model.ECU_PD != null)
               {
                  strUpdateSQL += ",ECU_PD='" + model.ECU_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("TX_PD") == true && model.TX_PD != null)
               {
                  strUpdateSQL += ",TX_PD='" + model.TX_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JX_PD") == true && model.JX_PD != null)
               {
                  strUpdateSQL += ",JX_PD='" + model.JX_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ALL_PD") == true && model.ALL_PD != null)
               {
                  strUpdateSQL += ",ALL_PD='" + model.ALL_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FreezeData") == true && model.FreezeData != null)
               {
                  strUpdateSQL += ",FreezeData='" + model.FreezeData.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ECUInfo") == true && model.ECUInfo != null)
               {
                  strUpdateSQL += ",ECUInfo='" + model.ECUInfo.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IUPR") == true && model.IUPR != null)
               {
                  strUpdateSQL += ",IUPR='" + model.IUPR.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SystemCheckState") == true && model.SystemCheckState != null)
               {
                  strUpdateSQL += ",SystemCheckState='" + model.SystemCheckState.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RTData") == true && model.RTData != null)
               {
                  strUpdateSQL += ",RTData='" + model.RTData.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SRTData") == true && model.SRTData != null)
               {
                  strUpdateSQL += ",SRTData='" + model.SRTData.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DTC") == true && model.DTC != null)
               {
                  strUpdateSQL += ",DTC='" + model.DTC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("TX_BHGYY") == true && model.TX_BHGYY != null)
               {
                  strUpdateSQL += ",TX_BHGYY='" + model.TX_BHGYY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("TX_GZDZT") == true && model.TX_GZDZT != null)
               {
                  strUpdateSQL += ",TX_GZDZT='" + model.TX_GZDZT.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_OBD set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_OBD model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_OBD model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",VIN='" + model.VIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",testdate='" + model.testdate + "'";
                  strUpdateSQL += ",isupdated=" + model.isupdated + "";
                  strUpdateSQL += ",ZSD_PD='" + model.ZSD_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GZ_PD='" + model.GZ_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ECU_VIN='" + model.ECU_VIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ECU_CALID='" + model.ECU_CALID.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ECU_CVN='" + model.ECU_CVN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ECU_PD='" + model.ECU_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",TX_PD='" + model.TX_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JX_PD='" + model.JX_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ALL_PD='" + model.ALL_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FreezeData='" + model.FreezeData.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ECUInfo='" + model.ECUInfo.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IUPR='" + model.IUPR.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SystemCheckState='" + model.SystemCheckState.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RTData='" + model.RTData.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SRTData='" + model.SRTData.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DTC='" + model.DTC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",TX_BHGYY='" + model.TX_BHGYY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",TX_GZDZT='" + model.TX_GZDZT.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_OBD set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_OBD model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(int intID)
          {
              string strSql = "";
              strSql += "delete from RESULT_OBD";
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
              strSql += "delete from RESULT_OBD";
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
              strSql += "delete from RESULT_OBD";

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
         public RESULT_OBD GetModel(int intID)
         {
             string strSql = "";
             strSql += "select * from RESULT_OBD";
             strSql += " where ";
               strSql += " ID="+ intID +"";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_OBD model = new RESULT_OBD();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_OBD();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.VIN = dtTemp.Rows[0]["VIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["VIN"].ToString();
                 model.testdate = dtTemp.Rows[0]["testdate"] == DBNull.Value ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dtTemp.Rows[0]["testdate"]);
                 model.isupdated = dtTemp.Rows[0]["isupdated"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["isupdated"]);
                 model.ZSD_PD = dtTemp.Rows[0]["ZSD_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZSD_PD"].ToString();
                 model.GZ_PD = dtTemp.Rows[0]["GZ_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GZ_PD"].ToString();
                 model.ECU_VIN = dtTemp.Rows[0]["ECU_VIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["ECU_VIN"].ToString();
                 model.ECU_CALID = dtTemp.Rows[0]["ECU_CALID"] == DBNull.Value ? "" : dtTemp.Rows[0]["ECU_CALID"].ToString();
                 model.ECU_CVN = dtTemp.Rows[0]["ECU_CVN"] == DBNull.Value ? "" : dtTemp.Rows[0]["ECU_CVN"].ToString();
                 model.ECU_PD = dtTemp.Rows[0]["ECU_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ECU_PD"].ToString();
                 model.TX_PD = dtTemp.Rows[0]["TX_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["TX_PD"].ToString();
                 model.JX_PD = dtTemp.Rows[0]["JX_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["JX_PD"].ToString();
                 model.ALL_PD = dtTemp.Rows[0]["ALL_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ALL_PD"].ToString();
                 model.FreezeData = dtTemp.Rows[0]["FreezeData"] == DBNull.Value ? "" : dtTemp.Rows[0]["FreezeData"].ToString();
                 model.ECUInfo = dtTemp.Rows[0]["ECUInfo"] == DBNull.Value ? "" : dtTemp.Rows[0]["ECUInfo"].ToString();
                 model.IUPR = dtTemp.Rows[0]["IUPR"] == DBNull.Value ? "" : dtTemp.Rows[0]["IUPR"].ToString();
                 model.SystemCheckState = dtTemp.Rows[0]["SystemCheckState"] == DBNull.Value ? "" : dtTemp.Rows[0]["SystemCheckState"].ToString();
                 model.RTData = dtTemp.Rows[0]["RTData"] == DBNull.Value ? "" : dtTemp.Rows[0]["RTData"].ToString();
                 model.SRTData = dtTemp.Rows[0]["SRTData"] == DBNull.Value ? "" : dtTemp.Rows[0]["SRTData"].ToString();
                 model.DTC = dtTemp.Rows[0]["DTC"] == DBNull.Value ? "" : dtTemp.Rows[0]["DTC"].ToString();
                 model.TX_BHGYY = dtTemp.Rows[0]["TX_BHGYY"] == DBNull.Value ? "" : dtTemp.Rows[0]["TX_BHGYY"].ToString();
                 model.TX_GZDZT = dtTemp.Rows[0]["TX_GZDZT"] == DBNull.Value ? "" : dtTemp.Rows[0]["TX_GZDZT"].ToString();
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
             strSql += "select * from RESULT_OBD";
             strSql += " where ";
               strSql += " ID="+ intID +"";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_OBD[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_OBD";
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

          RESULT_OBD[] arrModel=new RESULT_OBD[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_OBD();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].VIN = dtTemp.Rows[N]["VIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["VIN"].ToString();
                 arrModel[N].testdate = dtTemp.Rows[N]["testdate"] == DBNull.Value ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dtTemp.Rows[N]["testdate"]);
                 arrModel[N].isupdated = dtTemp.Rows[N]["isupdated"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["isupdated"]);
                 arrModel[N].ZSD_PD = dtTemp.Rows[N]["ZSD_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZSD_PD"].ToString();
                 arrModel[N].GZ_PD = dtTemp.Rows[N]["GZ_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GZ_PD"].ToString();
                 arrModel[N].ECU_VIN = dtTemp.Rows[N]["ECU_VIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["ECU_VIN"].ToString();
                 arrModel[N].ECU_CALID = dtTemp.Rows[N]["ECU_CALID"] == DBNull.Value ? "" : dtTemp.Rows[N]["ECU_CALID"].ToString();
                 arrModel[N].ECU_CVN = dtTemp.Rows[N]["ECU_CVN"] == DBNull.Value ? "" : dtTemp.Rows[N]["ECU_CVN"].ToString();
                 arrModel[N].ECU_PD = dtTemp.Rows[N]["ECU_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ECU_PD"].ToString();
                 arrModel[N].TX_PD = dtTemp.Rows[N]["TX_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["TX_PD"].ToString();
                 arrModel[N].JX_PD = dtTemp.Rows[N]["JX_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["JX_PD"].ToString();
                 arrModel[N].ALL_PD = dtTemp.Rows[N]["ALL_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ALL_PD"].ToString();
                 arrModel[N].FreezeData = dtTemp.Rows[N]["FreezeData"] == DBNull.Value ? "" : dtTemp.Rows[N]["FreezeData"].ToString();
                 arrModel[N].ECUInfo = dtTemp.Rows[N]["ECUInfo"] == DBNull.Value ? "" : dtTemp.Rows[N]["ECUInfo"].ToString();
                 arrModel[N].IUPR = dtTemp.Rows[N]["IUPR"] == DBNull.Value ? "" : dtTemp.Rows[N]["IUPR"].ToString();
                 arrModel[N].SystemCheckState = dtTemp.Rows[N]["SystemCheckState"] == DBNull.Value ? "" : dtTemp.Rows[N]["SystemCheckState"].ToString();
                 arrModel[N].RTData = dtTemp.Rows[N]["RTData"] == DBNull.Value ? "" : dtTemp.Rows[N]["RTData"].ToString();
                 arrModel[N].SRTData = dtTemp.Rows[N]["SRTData"] == DBNull.Value ? "" : dtTemp.Rows[N]["SRTData"].ToString();
                 arrModel[N].DTC = dtTemp.Rows[N]["DTC"] == DBNull.Value ? "" : dtTemp.Rows[N]["DTC"].ToString();
                 arrModel[N].TX_BHGYY = dtTemp.Rows[N]["TX_BHGYY"] == DBNull.Value ? "" : dtTemp.Rows[N]["TX_BHGYY"].ToString();
                 arrModel[N].TX_GZDZT = dtTemp.Rows[N]["TX_GZDZT"] == DBNull.Value ? "" : dtTemp.Rows[N]["TX_GZDZT"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_OBD[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_OBD[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_OBD[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_OBD[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_OBD[] GetModelList()
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
          strSql += "select * from RESULT_OBD";
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
