using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_SDS_DAL
     /// </summary>
     public class RESULT_SDS_DAL
     {
         private string Conn{ get;set; }
         public RESULT_SDS_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(JCLSH) as m from RESULT_SDS";

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
               strSql += "select count(1) as c from RESULT_SDS";
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
              strSql += "select count(1) as c from RESULT_SDS";
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
          public string InsertSQL(RESULT_SDS model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("SDSJCCS") == true && model.SDSJCCS != null)
              {
                   strFieldSQL += ",SDSJCCS";
                   strValueSQL += ",'" + model.SDSJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO") == true && model.GDSCO != null)
              {
                   strFieldSQL += ",GDSCO";
                   strValueSQL += ",'" + model.GDSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHC") == true && model.GDSHC != null)
              {
                   strFieldSQL += ",GDSHC";
                   strValueSQL += ",'" + model.GDSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO") == true && model.DSCO != null)
              {
                   strFieldSQL += ",DSCO";
                   strValueSQL += ",'" + model.DSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC") == true && model.DSHC != null)
              {
                   strFieldSQL += ",DSHC";
                   strValueSQL += ",'" + model.DSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCOXZ") == true && model.GDSCOXZ != null)
              {
                   strFieldSQL += ",GDSCOXZ";
                   strValueSQL += ",'" + model.GDSCOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHCXZ") == true && model.GDSHCXZ != null)
              {
                   strFieldSQL += ",GDSHCXZ";
                   strValueSQL += ",'" + model.GDSHCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXZ") == true && model.DSCOXZ != null)
              {
                   strFieldSQL += ",DSCOXZ";
                   strValueSQL += ",'" + model.DSCOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHCXZ") == true && model.DSHCXZ != null)
              {
                   strFieldSQL += ",DSHCXZ";
                   strValueSQL += ",'" + model.DSHCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO_PD") == true && model.GDSCO_PD != null)
              {
                   strFieldSQL += ",GDSCO_PD";
                   strValueSQL += ",'" + model.GDSCO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHC_PD") == true && model.GDSHC_PD != null)
              {
                   strFieldSQL += ",GDSHC_PD";
                   strValueSQL += ",'" + model.GDSHC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO_PD") == true && model.DSCO_PD != null)
              {
                   strFieldSQL += ",DSCO_PD";
                   strValueSQL += ",'" + model.DSCO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC_PD") == true && model.DSHC_PD != null)
              {
                   strFieldSQL += ",DSHC_PD";
                   strValueSQL += ",'" + model.DSHC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXS") == true && model.GLKQXS != null)
              {
                   strFieldSQL += ",GLKQXS";
                   strValueSQL += ",'" + model.GLKQXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXSSX") == true && model.GLKQXSSX != null)
              {
                   strFieldSQL += ",GLKQXSSX";
                   strValueSQL += ",'" + model.GLKQXSSX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXSXX") == true && model.GLKQXSXX != null)
              {
                   strFieldSQL += ",GLKQXSXX";
                   strValueSQL += ",'" + model.GLKQXSXX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXS_PD") == true && model.GLKQXS_PD != null)
              {
                   strFieldSQL += ",GLKQXS_PD";
                   strValueSQL += ",'" + model.GLKQXS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSWD") == true && model.SDSWD != null)
              {
                   strFieldSQL += ",SDSWD";
                   strValueSQL += ",'" + model.SDSWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSDQY") == true && model.SDSDQY != null)
              {
                   strFieldSQL += ",SDSDQY";
                   strValueSQL += ",'" + model.SDSDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSSD") == true && model.SDSSD != null)
              {
                   strFieldSQL += ",SDSSD";
                   strValueSQL += ",'" + model.SDSSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO2") == true && model.GDSCO2 != null)
              {
                   strFieldSQL += ",GDSCO2";
                   strValueSQL += ",'" + model.GDSCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSO2") == true && model.GDSO2 != null)
              {
                   strFieldSQL += ",GDSO2";
                   strValueSQL += ",'" + model.GDSO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO2") == true && model.DSCO2 != null)
              {
                   strFieldSQL += ",DSCO2";
                   strValueSQL += ",'" + model.DSCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSO2") == true && model.DSO2 != null)
              {
                   strFieldSQL += ",DSO2";
                   strValueSQL += ",'" + model.DSO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSYW") == true && model.SDSYW != null)
              {
                   strFieldSQL += ",SDSYW";
                   strValueSQL += ",'" + model.SDSYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSDSZS") == true && model.SDSDSZS != null)
              {
                   strFieldSQL += ",SDSDSZS";
                   strValueSQL += ",'" + model.SDSDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSGDSZS") == true && model.SDSGDSZS != null)
              {
                   strFieldSQL += ",SDSGDSZS";
                   strValueSQL += ",'" + model.SDSGDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCOXZZ") == true && model.GDSCOXZZ != null)
              {
                   strFieldSQL += ",GDSCOXZZ";
                   strValueSQL += ",'" + model.GDSCOXZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXZZ") == true && model.DSCOXZZ != null)
              {
                   strFieldSQL += ",DSCOXZZ";
                   strValueSQL += ",'" + model.DSCOXZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCOXYZ") == true && model.GDSCOXYZ != null)
              {
                   strFieldSQL += ",GDSCOXYZ";
                   strValueSQL += ",'" + model.GDSCOXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO2XYZ") == true && model.GDSCO2XYZ != null)
              {
                   strFieldSQL += ",GDSCO2XYZ";
                   strValueSQL += ",'" + model.GDSCO2XYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHCXYZ") == true && model.GDSHCXYZ != null)
              {
                   strFieldSQL += ",GDSHCXYZ";
                   strValueSQL += ",'" + model.GDSHCXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXYZ") == true && model.DSCOXYZ != null)
              {
                   strFieldSQL += ",DSCOXYZ";
                   strValueSQL += ",'" + model.DSCOXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO2XYZ") == true && model.DSCO2XYZ != null)
              {
                   strFieldSQL += ",DSCO2XYZ";
                   strValueSQL += ",'" + model.DSCO2XYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHCXYZ") == true && model.DSHCXYZ != null)
              {
                   strFieldSQL += ",DSHCXYZ";
                   strValueSQL += ",'" + model.DSHCXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDS_PD") == true && model.SDS_PD != null)
              {
                   strFieldSQL += ",SDS_PD";
                   strValueSQL += ",'" + model.SDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DS_PD") == true && model.DS_PD != null)
              {
                   strFieldSQL += ",DS_PD";
                   strValueSQL += ",'" + model.DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDS_PD") == true && model.GDS_PD != null)
              {
                   strFieldSQL += ",GDS_PD";
                   strValueSQL += ",'" + model.GDS_PD.ToString().Replace("'","''") + "'";
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

              if(model.Changed("JUMP_RPM") == true && model.JUMP_RPM != null)
              {
                   strFieldSQL += ",JUMP_RPM";
                   strValueSQL += ",'" + model.JUMP_RPM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsDZYW") == true && model.IsDZYW != null)
              {
                   strFieldSQL += ",IsDZYW";
                   strValueSQL += ",'" + model.IsDZYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDCode") == true && model.OBDCode != null)
              {
                   strFieldSQL += ",OBDCode";
                   strValueSQL += ",'" + model.OBDCode.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                   strFieldSQL += ",StopReason";
                   strValueSQL += ",'" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientCO") == true && model.AmbientCO != null)
              {
                   strFieldSQL += ",AmbientCO";
                   strValueSQL += ",'" + model.AmbientCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientCO2") == true && model.AmbientCO2 != null)
              {
                   strFieldSQL += ",AmbientCO2";
                   strValueSQL += ",'" + model.AmbientCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientHC") == true && model.AmbientHC != null)
              {
                   strFieldSQL += ",AmbientHC";
                   strValueSQL += ",'" + model.AmbientHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientNO") == true && model.AmbientNO != null)
              {
                   strFieldSQL += ",AmbientNO";
                   strValueSQL += ",'" + model.AmbientNO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientO2") == true && model.AmbientO2 != null)
              {
                   strFieldSQL += ",AmbientO2";
                   strValueSQL += ",'" + model.AmbientO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundCO") == true && model.BackgroundCO != null)
              {
                   strFieldSQL += ",BackgroundCO";
                   strValueSQL += ",'" + model.BackgroundCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundCO2") == true && model.BackgroundCO2 != null)
              {
                   strFieldSQL += ",BackgroundCO2";
                   strValueSQL += ",'" + model.BackgroundCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundHC") == true && model.BackgroundHC != null)
              {
                   strFieldSQL += ",BackgroundHC";
                   strValueSQL += ",'" + model.BackgroundHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundNO") == true && model.BackgroundNO != null)
              {
                   strFieldSQL += ",BackgroundNO";
                   strValueSQL += ",'" + model.BackgroundNO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundO2") == true && model.BackgroundO2 != null)
              {
                   strFieldSQL += ",BackgroundO2";
                   strValueSQL += ",'" + model.BackgroundO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ResidualHC") == true && model.ResidualHC != null)
              {
                   strFieldSQL += ",ResidualHC";
                   strValueSQL += ",'" + model.ResidualHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_DSCO") == true && model.PT_DSCO != null)
              {
                   strFieldSQL += ",PT_DSCO";
                   strValueSQL += ",'" + model.PT_DSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_DSHC") == true && model.PT_DSHC != null)
              {
                   strFieldSQL += ",PT_DSHC";
                   strValueSQL += ",'" + model.PT_DSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GDSCO") == true && model.PT_GDSCO != null)
              {
                   strFieldSQL += ",PT_GDSCO";
                   strValueSQL += ",'" + model.PT_GDSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GDSHC") == true && model.PT_GDSHC != null)
              {
                   strFieldSQL += ",PT_GDSHC";
                   strValueSQL += ",'" + model.PT_GDSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GLKQXS") == true && model.PT_GLKQXS != null)
              {
                   strFieldSQL += ",PT_GLKQXS";
                   strValueSQL += ",'" + model.PT_GLKQXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_SDS_PD") == true && model.PT_SDS_PD != null)
              {
                   strFieldSQL += ",PT_SDS_PD";
                   strValueSQL += ",'" + model.PT_SDS_PD.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_SDS";
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
          public bool Insert(RESULT_SDS model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_SDS model,string strJCLSH)
          {
              string strUpdateSQL = "";

              if(model.Changed("SDSJCCS") == true && model.SDSJCCS != null)
              {
                  strUpdateSQL += ",SDSJCCS='" + model.SDSJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO") == true && model.GDSCO != null)
              {
                  strUpdateSQL += ",GDSCO='" + model.GDSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHC") == true && model.GDSHC != null)
              {
                  strUpdateSQL += ",GDSHC='" + model.GDSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO") == true && model.DSCO != null)
              {
                  strUpdateSQL += ",DSCO='" + model.DSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC") == true && model.DSHC != null)
              {
                  strUpdateSQL += ",DSHC='" + model.DSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCOXZ") == true && model.GDSCOXZ != null)
              {
                  strUpdateSQL += ",GDSCOXZ='" + model.GDSCOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHCXZ") == true && model.GDSHCXZ != null)
              {
                  strUpdateSQL += ",GDSHCXZ='" + model.GDSHCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXZ") == true && model.DSCOXZ != null)
              {
                  strUpdateSQL += ",DSCOXZ='" + model.DSCOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHCXZ") == true && model.DSHCXZ != null)
              {
                  strUpdateSQL += ",DSHCXZ='" + model.DSHCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO_PD") == true && model.GDSCO_PD != null)
              {
                  strUpdateSQL += ",GDSCO_PD='" + model.GDSCO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHC_PD") == true && model.GDSHC_PD != null)
              {
                  strUpdateSQL += ",GDSHC_PD='" + model.GDSHC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO_PD") == true && model.DSCO_PD != null)
              {
                  strUpdateSQL += ",DSCO_PD='" + model.DSCO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC_PD") == true && model.DSHC_PD != null)
              {
                  strUpdateSQL += ",DSHC_PD='" + model.DSHC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXS") == true && model.GLKQXS != null)
              {
                  strUpdateSQL += ",GLKQXS='" + model.GLKQXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXSSX") == true && model.GLKQXSSX != null)
              {
                  strUpdateSQL += ",GLKQXSSX='" + model.GLKQXSSX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXSXX") == true && model.GLKQXSXX != null)
              {
                  strUpdateSQL += ",GLKQXSXX='" + model.GLKQXSXX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLKQXS_PD") == true && model.GLKQXS_PD != null)
              {
                  strUpdateSQL += ",GLKQXS_PD='" + model.GLKQXS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSWD") == true && model.SDSWD != null)
              {
                  strUpdateSQL += ",SDSWD='" + model.SDSWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSDQY") == true && model.SDSDQY != null)
              {
                  strUpdateSQL += ",SDSDQY='" + model.SDSDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSSD") == true && model.SDSSD != null)
              {
                  strUpdateSQL += ",SDSSD='" + model.SDSSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO2") == true && model.GDSCO2 != null)
              {
                  strUpdateSQL += ",GDSCO2='" + model.GDSCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSO2") == true && model.GDSO2 != null)
              {
                  strUpdateSQL += ",GDSO2='" + model.GDSO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO2") == true && model.DSCO2 != null)
              {
                  strUpdateSQL += ",DSCO2='" + model.DSCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSO2") == true && model.DSO2 != null)
              {
                  strUpdateSQL += ",DSO2='" + model.DSO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSYW") == true && model.SDSYW != null)
              {
                  strUpdateSQL += ",SDSYW='" + model.SDSYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSDSZS") == true && model.SDSDSZS != null)
              {
                  strUpdateSQL += ",SDSDSZS='" + model.SDSDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDSGDSZS") == true && model.SDSGDSZS != null)
              {
                  strUpdateSQL += ",SDSGDSZS='" + model.SDSGDSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCOXZZ") == true && model.GDSCOXZZ != null)
              {
                  strUpdateSQL += ",GDSCOXZZ='" + model.GDSCOXZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXZZ") == true && model.DSCOXZZ != null)
              {
                  strUpdateSQL += ",DSCOXZZ='" + model.DSCOXZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCOXYZ") == true && model.GDSCOXYZ != null)
              {
                  strUpdateSQL += ",GDSCOXYZ='" + model.GDSCOXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSCO2XYZ") == true && model.GDSCO2XYZ != null)
              {
                  strUpdateSQL += ",GDSCO2XYZ='" + model.GDSCO2XYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDSHCXYZ") == true && model.GDSHCXYZ != null)
              {
                  strUpdateSQL += ",GDSHCXYZ='" + model.GDSHCXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXYZ") == true && model.DSCOXYZ != null)
              {
                  strUpdateSQL += ",DSCOXYZ='" + model.DSCOXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO2XYZ") == true && model.DSCO2XYZ != null)
              {
                  strUpdateSQL += ",DSCO2XYZ='" + model.DSCO2XYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHCXYZ") == true && model.DSHCXYZ != null)
              {
                  strUpdateSQL += ",DSHCXYZ='" + model.DSHCXYZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SDS_PD") == true && model.SDS_PD != null)
              {
                  strUpdateSQL += ",SDS_PD='" + model.SDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DS_PD") == true && model.DS_PD != null)
              {
                  strUpdateSQL += ",DS_PD='" + model.DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GDS_PD") == true && model.GDS_PD != null)
              {
                  strUpdateSQL += ",GDS_PD='" + model.GDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KSSJ") == true && model.KSSJ != null)
              {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSSJ") == true && model.JSSJ != null)
              {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JUMP_RPM") == true && model.JUMP_RPM != null)
              {
                  strUpdateSQL += ",JUMP_RPM='" + model.JUMP_RPM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsDZYW") == true && model.IsDZYW != null)
              {
                  strUpdateSQL += ",IsDZYW='" + model.IsDZYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDCode") == true && model.OBDCode != null)
              {
                  strUpdateSQL += ",OBDCode='" + model.OBDCode.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientCO") == true && model.AmbientCO != null)
              {
                  strUpdateSQL += ",AmbientCO='" + model.AmbientCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientCO2") == true && model.AmbientCO2 != null)
              {
                  strUpdateSQL += ",AmbientCO2='" + model.AmbientCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientHC") == true && model.AmbientHC != null)
              {
                  strUpdateSQL += ",AmbientHC='" + model.AmbientHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientNO") == true && model.AmbientNO != null)
              {
                  strUpdateSQL += ",AmbientNO='" + model.AmbientNO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AmbientO2") == true && model.AmbientO2 != null)
              {
                  strUpdateSQL += ",AmbientO2='" + model.AmbientO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundCO") == true && model.BackgroundCO != null)
              {
                  strUpdateSQL += ",BackgroundCO='" + model.BackgroundCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundCO2") == true && model.BackgroundCO2 != null)
              {
                  strUpdateSQL += ",BackgroundCO2='" + model.BackgroundCO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundHC") == true && model.BackgroundHC != null)
              {
                  strUpdateSQL += ",BackgroundHC='" + model.BackgroundHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundNO") == true && model.BackgroundNO != null)
              {
                  strUpdateSQL += ",BackgroundNO='" + model.BackgroundNO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BackgroundO2") == true && model.BackgroundO2 != null)
              {
                  strUpdateSQL += ",BackgroundO2='" + model.BackgroundO2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ResidualHC") == true && model.ResidualHC != null)
              {
                  strUpdateSQL += ",ResidualHC='" + model.ResidualHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_DSCO") == true && model.PT_DSCO != null)
              {
                  strUpdateSQL += ",PT_DSCO='" + model.PT_DSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_DSHC") == true && model.PT_DSHC != null)
              {
                  strUpdateSQL += ",PT_DSHC='" + model.PT_DSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GDSCO") == true && model.PT_GDSCO != null)
              {
                  strUpdateSQL += ",PT_GDSCO='" + model.PT_GDSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GDSHC") == true && model.PT_GDSHC != null)
              {
                  strUpdateSQL += ",PT_GDSHC='" + model.PT_GDSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GLKQXS") == true && model.PT_GLKQXS != null)
              {
                  strUpdateSQL += ",PT_GLKQXS='" + model.PT_GLKQXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_SDS_PD") == true && model.PT_SDS_PD != null)
              {
                  strUpdateSQL += ",PT_SDS_PD='" + model.PT_SDS_PD.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_SDS set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_SDS model, string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strJCLSH));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_SDS model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("SDSJCCS") == true && model.SDSJCCS != null)
               {
                  strUpdateSQL += ",SDSJCCS='" + model.SDSJCCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCO") == true && model.GDSCO != null)
               {
                  strUpdateSQL += ",GDSCO='" + model.GDSCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSHC") == true && model.GDSHC != null)
               {
                  strUpdateSQL += ",GDSHC='" + model.GDSHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCO") == true && model.DSCO != null)
               {
                  strUpdateSQL += ",DSCO='" + model.DSCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHC") == true && model.DSHC != null)
               {
                  strUpdateSQL += ",DSHC='" + model.DSHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCOXZ") == true && model.GDSCOXZ != null)
               {
                  strUpdateSQL += ",GDSCOXZ='" + model.GDSCOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSHCXZ") == true && model.GDSHCXZ != null)
               {
                  strUpdateSQL += ",GDSHCXZ='" + model.GDSHCXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCOXZ") == true && model.DSCOXZ != null)
               {
                  strUpdateSQL += ",DSCOXZ='" + model.DSCOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHCXZ") == true && model.DSHCXZ != null)
               {
                  strUpdateSQL += ",DSHCXZ='" + model.DSHCXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCO_PD") == true && model.GDSCO_PD != null)
               {
                  strUpdateSQL += ",GDSCO_PD='" + model.GDSCO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSHC_PD") == true && model.GDSHC_PD != null)
               {
                  strUpdateSQL += ",GDSHC_PD='" + model.GDSHC_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCO_PD") == true && model.DSCO_PD != null)
               {
                  strUpdateSQL += ",DSCO_PD='" + model.DSCO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHC_PD") == true && model.DSHC_PD != null)
               {
                  strUpdateSQL += ",DSHC_PD='" + model.DSHC_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLKQXS") == true && model.GLKQXS != null)
               {
                  strUpdateSQL += ",GLKQXS='" + model.GLKQXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLKQXSSX") == true && model.GLKQXSSX != null)
               {
                  strUpdateSQL += ",GLKQXSSX='" + model.GLKQXSSX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLKQXSXX") == true && model.GLKQXSXX != null)
               {
                  strUpdateSQL += ",GLKQXSXX='" + model.GLKQXSXX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLKQXS_PD") == true && model.GLKQXS_PD != null)
               {
                  strUpdateSQL += ",GLKQXS_PD='" + model.GLKQXS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDSWD") == true && model.SDSWD != null)
               {
                  strUpdateSQL += ",SDSWD='" + model.SDSWD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDSDQY") == true && model.SDSDQY != null)
               {
                  strUpdateSQL += ",SDSDQY='" + model.SDSDQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDSSD") == true && model.SDSSD != null)
               {
                  strUpdateSQL += ",SDSSD='" + model.SDSSD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCO2") == true && model.GDSCO2 != null)
               {
                  strUpdateSQL += ",GDSCO2='" + model.GDSCO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSO2") == true && model.GDSO2 != null)
               {
                  strUpdateSQL += ",GDSO2='" + model.GDSO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCO2") == true && model.DSCO2 != null)
               {
                  strUpdateSQL += ",DSCO2='" + model.DSCO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSO2") == true && model.DSO2 != null)
               {
                  strUpdateSQL += ",DSO2='" + model.DSO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDSYW") == true && model.SDSYW != null)
               {
                  strUpdateSQL += ",SDSYW='" + model.SDSYW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDSDSZS") == true && model.SDSDSZS != null)
               {
                  strUpdateSQL += ",SDSDSZS='" + model.SDSDSZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDSGDSZS") == true && model.SDSGDSZS != null)
               {
                  strUpdateSQL += ",SDSGDSZS='" + model.SDSGDSZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCOXZZ") == true && model.GDSCOXZZ != null)
               {
                  strUpdateSQL += ",GDSCOXZZ='" + model.GDSCOXZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCOXZZ") == true && model.DSCOXZZ != null)
               {
                  strUpdateSQL += ",DSCOXZZ='" + model.DSCOXZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCOXYZ") == true && model.GDSCOXYZ != null)
               {
                  strUpdateSQL += ",GDSCOXYZ='" + model.GDSCOXYZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSCO2XYZ") == true && model.GDSCO2XYZ != null)
               {
                  strUpdateSQL += ",GDSCO2XYZ='" + model.GDSCO2XYZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDSHCXYZ") == true && model.GDSHCXYZ != null)
               {
                  strUpdateSQL += ",GDSHCXYZ='" + model.GDSHCXYZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCOXYZ") == true && model.DSCOXYZ != null)
               {
                  strUpdateSQL += ",DSCOXYZ='" + model.DSCOXYZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCO2XYZ") == true && model.DSCO2XYZ != null)
               {
                  strUpdateSQL += ",DSCO2XYZ='" + model.DSCO2XYZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHCXYZ") == true && model.DSHCXYZ != null)
               {
                  strUpdateSQL += ",DSHCXYZ='" + model.DSHCXYZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SDS_PD") == true && model.SDS_PD != null)
               {
                  strUpdateSQL += ",SDS_PD='" + model.SDS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DS_PD") == true && model.DS_PD != null)
               {
                  strUpdateSQL += ",DS_PD='" + model.DS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GDS_PD") == true && model.GDS_PD != null)
               {
                  strUpdateSQL += ",GDS_PD='" + model.GDS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KSSJ") == true && model.KSSJ != null)
               {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JSSJ") == true && model.JSSJ != null)
               {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JUMP_RPM") == true && model.JUMP_RPM != null)
               {
                  strUpdateSQL += ",JUMP_RPM='" + model.JUMP_RPM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsDZYW") == true && model.IsDZYW != null)
               {
                  strUpdateSQL += ",IsDZYW='" + model.IsDZYW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBDCode") == true && model.OBDCode != null)
               {
                  strUpdateSQL += ",OBDCode='" + model.OBDCode.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("StopReason") == true && model.StopReason != null)
               {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AmbientCO") == true && model.AmbientCO != null)
               {
                  strUpdateSQL += ",AmbientCO='" + model.AmbientCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AmbientCO2") == true && model.AmbientCO2 != null)
               {
                  strUpdateSQL += ",AmbientCO2='" + model.AmbientCO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AmbientHC") == true && model.AmbientHC != null)
               {
                  strUpdateSQL += ",AmbientHC='" + model.AmbientHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AmbientNO") == true && model.AmbientNO != null)
               {
                  strUpdateSQL += ",AmbientNO='" + model.AmbientNO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AmbientO2") == true && model.AmbientO2 != null)
               {
                  strUpdateSQL += ",AmbientO2='" + model.AmbientO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BackgroundCO") == true && model.BackgroundCO != null)
               {
                  strUpdateSQL += ",BackgroundCO='" + model.BackgroundCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BackgroundCO2") == true && model.BackgroundCO2 != null)
               {
                  strUpdateSQL += ",BackgroundCO2='" + model.BackgroundCO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BackgroundHC") == true && model.BackgroundHC != null)
               {
                  strUpdateSQL += ",BackgroundHC='" + model.BackgroundHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BackgroundNO") == true && model.BackgroundNO != null)
               {
                  strUpdateSQL += ",BackgroundNO='" + model.BackgroundNO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BackgroundO2") == true && model.BackgroundO2 != null)
               {
                  strUpdateSQL += ",BackgroundO2='" + model.BackgroundO2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ResidualHC") == true && model.ResidualHC != null)
               {
                  strUpdateSQL += ",ResidualHC='" + model.ResidualHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_DSCO") == true && model.PT_DSCO != null)
               {
                  strUpdateSQL += ",PT_DSCO='" + model.PT_DSCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_DSHC") == true && model.PT_DSHC != null)
               {
                  strUpdateSQL += ",PT_DSHC='" + model.PT_DSHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_GDSCO") == true && model.PT_GDSCO != null)
               {
                  strUpdateSQL += ",PT_GDSCO='" + model.PT_GDSCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_GDSHC") == true && model.PT_GDSHC != null)
               {
                  strUpdateSQL += ",PT_GDSHC='" + model.PT_GDSHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_GLKQXS") == true && model.PT_GLKQXS != null)
               {
                  strUpdateSQL += ",PT_GLKQXS='" + model.PT_GLKQXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_SDS_PD") == true && model.PT_SDS_PD != null)
               {
                  strUpdateSQL += ",PT_SDS_PD='" + model.PT_SDS_PD.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_SDS set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_SDS model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_SDS model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",SDSJCCS='" + model.SDSJCCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCO='" + model.GDSCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSHC='" + model.GDSHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCO='" + model.DSCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHC='" + model.DSHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCOXZ='" + model.GDSCOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSHCXZ='" + model.GDSHCXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCOXZ='" + model.DSCOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHCXZ='" + model.DSHCXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCO_PD='" + model.GDSCO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSHC_PD='" + model.GDSHC_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCO_PD='" + model.DSCO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHC_PD='" + model.DSHC_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLKQXS='" + model.GLKQXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLKQXSSX='" + model.GLKQXSSX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLKQXSXX='" + model.GLKQXSXX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLKQXS_PD='" + model.GLKQXS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDSWD='" + model.SDSWD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDSDQY='" + model.SDSDQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDSSD='" + model.SDSSD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCO2='" + model.GDSCO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSO2='" + model.GDSO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCO2='" + model.DSCO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSO2='" + model.DSO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDSYW='" + model.SDSYW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDSDSZS='" + model.SDSDSZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDSGDSZS='" + model.SDSGDSZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCOXZZ='" + model.GDSCOXZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCOXZZ='" + model.DSCOXZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCOXYZ='" + model.GDSCOXYZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSCO2XYZ='" + model.GDSCO2XYZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDSHCXYZ='" + model.GDSHCXYZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCOXYZ='" + model.DSCOXYZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCO2XYZ='" + model.DSCO2XYZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHCXYZ='" + model.DSHCXYZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SDS_PD='" + model.SDS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DS_PD='" + model.DS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GDS_PD='" + model.GDS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JUMP_RPM='" + model.JUMP_RPM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsDZYW='" + model.IsDZYW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBDCode='" + model.OBDCode.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AmbientCO='" + model.AmbientCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AmbientCO2='" + model.AmbientCO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AmbientHC='" + model.AmbientHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AmbientNO='" + model.AmbientNO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AmbientO2='" + model.AmbientO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BackgroundCO='" + model.BackgroundCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BackgroundCO2='" + model.BackgroundCO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BackgroundHC='" + model.BackgroundHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BackgroundNO='" + model.BackgroundNO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BackgroundO2='" + model.BackgroundO2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ResidualHC='" + model.ResidualHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_DSCO='" + model.PT_DSCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_DSHC='" + model.PT_DSHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_GDSCO='" + model.PT_GDSCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_GDSHC='" + model.PT_GDSHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_GLKQXS='" + model.PT_GLKQXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_SDS_PD='" + model.PT_SDS_PD.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_SDS set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_SDS model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strJCLSH)
          {
              string strSql = "";
              strSql += "delete from RESULT_SDS";
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
              strSql += "delete from RESULT_SDS";
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
              strSql += "delete from RESULT_SDS";

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
         public RESULT_SDS GetModel(string strJCLSH)
         {
             string strSql = "";
             strSql += "select * from RESULT_SDS";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_SDS model = new RESULT_SDS();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_SDS();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.SDSJCCS = dtTemp.Rows[0]["SDSJCCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSJCCS"].ToString();
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.GDSCO = dtTemp.Rows[0]["GDSCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCO"].ToString();
                 model.GDSHC = dtTemp.Rows[0]["GDSHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSHC"].ToString();
                 model.DSCO = dtTemp.Rows[0]["DSCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCO"].ToString();
                 model.DSHC = dtTemp.Rows[0]["DSHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHC"].ToString();
                 model.GDSCOXZ = dtTemp.Rows[0]["GDSCOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCOXZ"].ToString();
                 model.GDSHCXZ = dtTemp.Rows[0]["GDSHCXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSHCXZ"].ToString();
                 model.DSCOXZ = dtTemp.Rows[0]["DSCOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCOXZ"].ToString();
                 model.DSHCXZ = dtTemp.Rows[0]["DSHCXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHCXZ"].ToString();
                 model.GDSCO_PD = dtTemp.Rows[0]["GDSCO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCO_PD"].ToString();
                 model.GDSHC_PD = dtTemp.Rows[0]["GDSHC_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSHC_PD"].ToString();
                 model.DSCO_PD = dtTemp.Rows[0]["DSCO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCO_PD"].ToString();
                 model.DSHC_PD = dtTemp.Rows[0]["DSHC_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHC_PD"].ToString();
                 model.GLKQXS = dtTemp.Rows[0]["GLKQXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLKQXS"].ToString();
                 model.GLKQXSSX = dtTemp.Rows[0]["GLKQXSSX"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLKQXSSX"].ToString();
                 model.GLKQXSXX = dtTemp.Rows[0]["GLKQXSXX"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLKQXSXX"].ToString();
                 model.GLKQXS_PD = dtTemp.Rows[0]["GLKQXS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLKQXS_PD"].ToString();
                 model.SDSWD = dtTemp.Rows[0]["SDSWD"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSWD"].ToString();
                 model.SDSDQY = dtTemp.Rows[0]["SDSDQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSDQY"].ToString();
                 model.SDSSD = dtTemp.Rows[0]["SDSSD"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSSD"].ToString();
                 model.GDSCO2 = dtTemp.Rows[0]["GDSCO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCO2"].ToString();
                 model.GDSO2 = dtTemp.Rows[0]["GDSO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSO2"].ToString();
                 model.DSCO2 = dtTemp.Rows[0]["DSCO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCO2"].ToString();
                 model.DSO2 = dtTemp.Rows[0]["DSO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSO2"].ToString();
                 model.SDSYW = dtTemp.Rows[0]["SDSYW"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSYW"].ToString();
                 model.SDSDSZS = dtTemp.Rows[0]["SDSDSZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSDSZS"].ToString();
                 model.SDSGDSZS = dtTemp.Rows[0]["SDSGDSZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDSGDSZS"].ToString();
                 model.GDSCOXZZ = dtTemp.Rows[0]["GDSCOXZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCOXZZ"].ToString();
                 model.DSCOXZZ = dtTemp.Rows[0]["DSCOXZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCOXZZ"].ToString();
                 model.GDSCOXYZ = dtTemp.Rows[0]["GDSCOXYZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCOXYZ"].ToString();
                 model.GDSCO2XYZ = dtTemp.Rows[0]["GDSCO2XYZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSCO2XYZ"].ToString();
                 model.GDSHCXYZ = dtTemp.Rows[0]["GDSHCXYZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDSHCXYZ"].ToString();
                 model.DSCOXYZ = dtTemp.Rows[0]["DSCOXYZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCOXYZ"].ToString();
                 model.DSCO2XYZ = dtTemp.Rows[0]["DSCO2XYZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCO2XYZ"].ToString();
                 model.DSHCXYZ = dtTemp.Rows[0]["DSHCXYZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHCXYZ"].ToString();
                 model.SDS_PD = dtTemp.Rows[0]["SDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["SDS_PD"].ToString();
                 model.DS_PD = dtTemp.Rows[0]["DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["DS_PD"].ToString();
                 model.GDS_PD = dtTemp.Rows[0]["GDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GDS_PD"].ToString();
                 model.KSSJ = dtTemp.Rows[0]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["KSSJ"].ToString();
                 model.JSSJ = dtTemp.Rows[0]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JSSJ"].ToString();
                 model.JUMP_RPM = dtTemp.Rows[0]["JUMP_RPM"] == DBNull.Value ? "" : dtTemp.Rows[0]["JUMP_RPM"].ToString();
                 model.IsDZYW = dtTemp.Rows[0]["IsDZYW"] == DBNull.Value ? "" : dtTemp.Rows[0]["IsDZYW"].ToString();
                 model.OBDCode = dtTemp.Rows[0]["OBDCode"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBDCode"].ToString();
                 model.StopReason = dtTemp.Rows[0]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[0]["StopReason"].ToString();
                 model.AmbientCO = dtTemp.Rows[0]["AmbientCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["AmbientCO"].ToString();
                 model.AmbientCO2 = dtTemp.Rows[0]["AmbientCO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["AmbientCO2"].ToString();
                 model.AmbientHC = dtTemp.Rows[0]["AmbientHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["AmbientHC"].ToString();
                 model.AmbientNO = dtTemp.Rows[0]["AmbientNO"] == DBNull.Value ? "" : dtTemp.Rows[0]["AmbientNO"].ToString();
                 model.AmbientO2 = dtTemp.Rows[0]["AmbientO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["AmbientO2"].ToString();
                 model.BackgroundCO = dtTemp.Rows[0]["BackgroundCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["BackgroundCO"].ToString();
                 model.BackgroundCO2 = dtTemp.Rows[0]["BackgroundCO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["BackgroundCO2"].ToString();
                 model.BackgroundHC = dtTemp.Rows[0]["BackgroundHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["BackgroundHC"].ToString();
                 model.BackgroundNO = dtTemp.Rows[0]["BackgroundNO"] == DBNull.Value ? "" : dtTemp.Rows[0]["BackgroundNO"].ToString();
                 model.BackgroundO2 = dtTemp.Rows[0]["BackgroundO2"] == DBNull.Value ? "" : dtTemp.Rows[0]["BackgroundO2"].ToString();
                 model.ResidualHC = dtTemp.Rows[0]["ResidualHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["ResidualHC"].ToString();
                 model.PT_DSCO = dtTemp.Rows[0]["PT_DSCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_DSCO"].ToString();
                 model.PT_DSHC = dtTemp.Rows[0]["PT_DSHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_DSHC"].ToString();
                 model.PT_GDSCO = dtTemp.Rows[0]["PT_GDSCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_GDSCO"].ToString();
                 model.PT_GDSHC = dtTemp.Rows[0]["PT_GDSHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_GDSHC"].ToString();
                 model.PT_GLKQXS = dtTemp.Rows[0]["PT_GLKQXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_GLKQXS"].ToString();
                 model.PT_SDS_PD = dtTemp.Rows[0]["PT_SDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_SDS_PD"].ToString();
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
             strSql += "select * from RESULT_SDS";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_SDS[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_SDS";
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

          RESULT_SDS[] arrModel=new RESULT_SDS[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_SDS();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].SDSJCCS = dtTemp.Rows[N]["SDSJCCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSJCCS"].ToString();
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].GDSCO = dtTemp.Rows[N]["GDSCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCO"].ToString();
                 arrModel[N].GDSHC = dtTemp.Rows[N]["GDSHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSHC"].ToString();
                 arrModel[N].DSCO = dtTemp.Rows[N]["DSCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCO"].ToString();
                 arrModel[N].DSHC = dtTemp.Rows[N]["DSHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHC"].ToString();
                 arrModel[N].GDSCOXZ = dtTemp.Rows[N]["GDSCOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCOXZ"].ToString();
                 arrModel[N].GDSHCXZ = dtTemp.Rows[N]["GDSHCXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSHCXZ"].ToString();
                 arrModel[N].DSCOXZ = dtTemp.Rows[N]["DSCOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCOXZ"].ToString();
                 arrModel[N].DSHCXZ = dtTemp.Rows[N]["DSHCXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHCXZ"].ToString();
                 arrModel[N].GDSCO_PD = dtTemp.Rows[N]["GDSCO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCO_PD"].ToString();
                 arrModel[N].GDSHC_PD = dtTemp.Rows[N]["GDSHC_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSHC_PD"].ToString();
                 arrModel[N].DSCO_PD = dtTemp.Rows[N]["DSCO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCO_PD"].ToString();
                 arrModel[N].DSHC_PD = dtTemp.Rows[N]["DSHC_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHC_PD"].ToString();
                 arrModel[N].GLKQXS = dtTemp.Rows[N]["GLKQXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLKQXS"].ToString();
                 arrModel[N].GLKQXSSX = dtTemp.Rows[N]["GLKQXSSX"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLKQXSSX"].ToString();
                 arrModel[N].GLKQXSXX = dtTemp.Rows[N]["GLKQXSXX"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLKQXSXX"].ToString();
                 arrModel[N].GLKQXS_PD = dtTemp.Rows[N]["GLKQXS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLKQXS_PD"].ToString();
                 arrModel[N].SDSWD = dtTemp.Rows[N]["SDSWD"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSWD"].ToString();
                 arrModel[N].SDSDQY = dtTemp.Rows[N]["SDSDQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSDQY"].ToString();
                 arrModel[N].SDSSD = dtTemp.Rows[N]["SDSSD"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSSD"].ToString();
                 arrModel[N].GDSCO2 = dtTemp.Rows[N]["GDSCO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCO2"].ToString();
                 arrModel[N].GDSO2 = dtTemp.Rows[N]["GDSO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSO2"].ToString();
                 arrModel[N].DSCO2 = dtTemp.Rows[N]["DSCO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCO2"].ToString();
                 arrModel[N].DSO2 = dtTemp.Rows[N]["DSO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSO2"].ToString();
                 arrModel[N].SDSYW = dtTemp.Rows[N]["SDSYW"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSYW"].ToString();
                 arrModel[N].SDSDSZS = dtTemp.Rows[N]["SDSDSZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSDSZS"].ToString();
                 arrModel[N].SDSGDSZS = dtTemp.Rows[N]["SDSGDSZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDSGDSZS"].ToString();
                 arrModel[N].GDSCOXZZ = dtTemp.Rows[N]["GDSCOXZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCOXZZ"].ToString();
                 arrModel[N].DSCOXZZ = dtTemp.Rows[N]["DSCOXZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCOXZZ"].ToString();
                 arrModel[N].GDSCOXYZ = dtTemp.Rows[N]["GDSCOXYZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCOXYZ"].ToString();
                 arrModel[N].GDSCO2XYZ = dtTemp.Rows[N]["GDSCO2XYZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSCO2XYZ"].ToString();
                 arrModel[N].GDSHCXYZ = dtTemp.Rows[N]["GDSHCXYZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDSHCXYZ"].ToString();
                 arrModel[N].DSCOXYZ = dtTemp.Rows[N]["DSCOXYZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCOXYZ"].ToString();
                 arrModel[N].DSCO2XYZ = dtTemp.Rows[N]["DSCO2XYZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCO2XYZ"].ToString();
                 arrModel[N].DSHCXYZ = dtTemp.Rows[N]["DSHCXYZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHCXYZ"].ToString();
                 arrModel[N].SDS_PD = dtTemp.Rows[N]["SDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["SDS_PD"].ToString();
                 arrModel[N].DS_PD = dtTemp.Rows[N]["DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["DS_PD"].ToString();
                 arrModel[N].GDS_PD = dtTemp.Rows[N]["GDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GDS_PD"].ToString();
                 arrModel[N].KSSJ = dtTemp.Rows[N]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["KSSJ"].ToString();
                 arrModel[N].JSSJ = dtTemp.Rows[N]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JSSJ"].ToString();
                 arrModel[N].JUMP_RPM = dtTemp.Rows[N]["JUMP_RPM"] == DBNull.Value ? "" : dtTemp.Rows[N]["JUMP_RPM"].ToString();
                 arrModel[N].IsDZYW = dtTemp.Rows[N]["IsDZYW"] == DBNull.Value ? "" : dtTemp.Rows[N]["IsDZYW"].ToString();
                 arrModel[N].OBDCode = dtTemp.Rows[N]["OBDCode"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBDCode"].ToString();
                 arrModel[N].StopReason = dtTemp.Rows[N]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[N]["StopReason"].ToString();
                 arrModel[N].AmbientCO = dtTemp.Rows[N]["AmbientCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["AmbientCO"].ToString();
                 arrModel[N].AmbientCO2 = dtTemp.Rows[N]["AmbientCO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["AmbientCO2"].ToString();
                 arrModel[N].AmbientHC = dtTemp.Rows[N]["AmbientHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["AmbientHC"].ToString();
                 arrModel[N].AmbientNO = dtTemp.Rows[N]["AmbientNO"] == DBNull.Value ? "" : dtTemp.Rows[N]["AmbientNO"].ToString();
                 arrModel[N].AmbientO2 = dtTemp.Rows[N]["AmbientO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["AmbientO2"].ToString();
                 arrModel[N].BackgroundCO = dtTemp.Rows[N]["BackgroundCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["BackgroundCO"].ToString();
                 arrModel[N].BackgroundCO2 = dtTemp.Rows[N]["BackgroundCO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["BackgroundCO2"].ToString();
                 arrModel[N].BackgroundHC = dtTemp.Rows[N]["BackgroundHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["BackgroundHC"].ToString();
                 arrModel[N].BackgroundNO = dtTemp.Rows[N]["BackgroundNO"] == DBNull.Value ? "" : dtTemp.Rows[N]["BackgroundNO"].ToString();
                 arrModel[N].BackgroundO2 = dtTemp.Rows[N]["BackgroundO2"] == DBNull.Value ? "" : dtTemp.Rows[N]["BackgroundO2"].ToString();
                 arrModel[N].ResidualHC = dtTemp.Rows[N]["ResidualHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["ResidualHC"].ToString();
                 arrModel[N].PT_DSCO = dtTemp.Rows[N]["PT_DSCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_DSCO"].ToString();
                 arrModel[N].PT_DSHC = dtTemp.Rows[N]["PT_DSHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_DSHC"].ToString();
                 arrModel[N].PT_GDSCO = dtTemp.Rows[N]["PT_GDSCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_GDSCO"].ToString();
                 arrModel[N].PT_GDSHC = dtTemp.Rows[N]["PT_GDSHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_GDSHC"].ToString();
                 arrModel[N].PT_GLKQXS = dtTemp.Rows[N]["PT_GLKQXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_GLKQXS"].ToString();
                 arrModel[N].PT_SDS_PD = dtTemp.Rows[N]["PT_SDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_SDS_PD"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_SDS[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_SDS[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_SDS[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_SDS[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_SDS[] GetModelList()
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
          strSql += "select * from RESULT_SDS";
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
