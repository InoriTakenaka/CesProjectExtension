using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_ASM_DAL
     /// </summary>
     public class RESULT_ASM_DAL
     {
         private string Conn{ get;set; }
         public RESULT_ASM_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(JCLSH) as m from RESULT_ASM";

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
               strSql += "select count(1) as c from RESULT_ASM";
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
              strSql += "select count(1) as c from RESULT_ASM";
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
          public string InsertSQL(RESULT_ASM model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMJCCS") == true && model.ASMJCCS != null)
              {
                   strFieldSQL += ",ASMJCCS";
                   strValueSQL += ",'" + model.ASMJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC5025JG") == true && model.HC5025JG != null)
              {
                   strFieldSQL += ",HC5025JG";
                   strValueSQL += ",'" + model.HC5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO5025JG") == true && model.CO5025JG != null)
              {
                   strFieldSQL += ",CO5025JG";
                   strValueSQL += ",'" + model.CO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO5025JG") == true && model.NO5025JG != null)
              {
                   strFieldSQL += ",NO5025JG";
                   strValueSQL += ",'" + model.NO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC2540JG") == true && model.HC2540JG != null)
              {
                   strFieldSQL += ",HC2540JG";
                   strValueSQL += ",'" + model.HC2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2540JG") == true && model.CO2540JG != null)
              {
                   strFieldSQL += ",CO2540JG";
                   strValueSQL += ",'" + model.CO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO2540JG") == true && model.NO2540JG != null)
              {
                   strFieldSQL += ",NO2540JG";
                   strValueSQL += ",'" + model.NO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC5025XZ") == true && model.HC5025XZ != null)
              {
                   strFieldSQL += ",HC5025XZ";
                   strValueSQL += ",'" + model.HC5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO5025XZ") == true && model.CO5025XZ != null)
              {
                   strFieldSQL += ",CO5025XZ";
                   strValueSQL += ",'" + model.CO5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO5025XZ") == true && model.NO5025XZ != null)
              {
                   strFieldSQL += ",NO5025XZ";
                   strValueSQL += ",'" + model.NO5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC2540XZ") == true && model.HC2540XZ != null)
              {
                   strFieldSQL += ",HC2540XZ";
                   strValueSQL += ",'" + model.HC2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2540XZ") == true && model.CO2540XZ != null)
              {
                   strFieldSQL += ",CO2540XZ";
                   strValueSQL += ",'" + model.CO2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO2540XZ") == true && model.NO2540XZ != null)
              {
                   strFieldSQL += ",NO2540XZ";
                   strValueSQL += ",'" + model.NO2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC5025_PD") == true && model.HC5025_PD != null)
              {
                   strFieldSQL += ",HC5025_PD";
                   strValueSQL += ",'" + model.HC5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO5025_PD") == true && model.CO5025_PD != null)
              {
                   strFieldSQL += ",CO5025_PD";
                   strValueSQL += ",'" + model.CO5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO5025_PD") == true && model.NO5025_PD != null)
              {
                   strFieldSQL += ",NO5025_PD";
                   strValueSQL += ",'" + model.NO5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC2540_PD") == true && model.HC2540_PD != null)
              {
                   strFieldSQL += ",HC2540_PD";
                   strValueSQL += ",'" + model.HC2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2540_PD") == true && model.CO2540_PD != null)
              {
                   strFieldSQL += ",CO2540_PD";
                   strValueSQL += ",'" + model.CO2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO2540_PD") == true && model.NO2540_PD != null)
              {
                   strFieldSQL += ",NO2540_PD";
                   strValueSQL += ",'" + model.NO2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_5025_PD") == true && model.ASM_5025_PD != null)
              {
                   strFieldSQL += ",ASM_5025_PD";
                   strValueSQL += ",'" + model.ASM_5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_2540_PD") == true && model.ASM_2540_PD != null)
              {
                   strFieldSQL += ",ASM_2540_PD";
                   strValueSQL += ",'" + model.ASM_2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_PD") == true && model.ASM_PD != null)
              {
                   strFieldSQL += ",ASM_PD";
                   strValueSQL += ",'" + model.ASM_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMWD") == true && model.ASMWD != null)
              {
                   strFieldSQL += ",ASMWD";
                   strValueSQL += ",'" + model.ASMWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMDQY") == true && model.ASMDQY != null)
              {
                   strFieldSQL += ",ASMDQY";
                   strValueSQL += ",'" + model.ASMDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMSD") == true && model.ASMSD != null)
              {
                   strFieldSQL += ",ASMSD";
                   strValueSQL += ",'" + model.ASMSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMYW") == true && model.ASMYW != null)
              {
                   strFieldSQL += ",ASMYW";
                   strValueSQL += ",'" + model.ASMYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSYW") == true && model.DSYW != null)
              {
                   strFieldSQL += ",DSYW";
                   strValueSQL += ",'" + model.DSYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC") == true && model.DSHC != null)
              {
                   strFieldSQL += ",DSHC";
                   strValueSQL += ",'" + model.DSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO") == true && model.DSCO != null)
              {
                   strFieldSQL += ",DSCO";
                   strValueSQL += ",'" + model.DSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHCXZ") == true && model.DSHCXZ != null)
              {
                   strFieldSQL += ",DSHCXZ";
                   strValueSQL += ",'" + model.DSHCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXZ") == true && model.DSCOXZ != null)
              {
                   strFieldSQL += ",DSCOXZ";
                   strValueSQL += ",'" + model.DSCOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC_PD") == true && model.DSHC_PD != null)
              {
                   strFieldSQL += ",DSHC_PD";
                   strValueSQL += ",'" + model.DSHC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO_PD") == true && model.DSCO_PD != null)
              {
                   strFieldSQL += ",DSCO_PD";
                   strValueSQL += ",'" + model.DSCO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL5025") == true && model.GL5025 != null)
              {
                   strFieldSQL += ",GL5025";
                   strValueSQL += ",'" + model.GL5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL2540") == true && model.GL2540 != null)
              {
                   strFieldSQL += ",GL2540";
                   strValueSQL += ",'" + model.GL2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO25025JG") == true && model.CO25025JG != null)
              {
                   strFieldSQL += ",CO25025JG";
                   strValueSQL += ",'" + model.CO25025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO22540JG") == true && model.CO22540JG != null)
              {
                   strFieldSQL += ",CO22540JG";
                   strValueSQL += ",'" + model.CO22540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2DSJG") == true && model.CO2DSJG != null)
              {
                   strFieldSQL += ",CO2DSJG";
                   strValueSQL += ",'" + model.CO2DSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O25025JG") == true && model.O25025JG != null)
              {
                   strFieldSQL += ",O25025JG";
                   strValueSQL += ",'" + model.O25025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O22540JG") == true && model.O22540JG != null)
              {
                   strFieldSQL += ",O22540JG";
                   strValueSQL += ",'" + model.O22540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O2DSJG") == true && model.O2DSJG != null)
              {
                   strFieldSQL += ",O2DSJG";
                   strValueSQL += ",'" + model.O2DSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM5025JG") == true && model.RPM5025JG != null)
              {
                   strFieldSQL += ",RPM5025JG";
                   strValueSQL += ",'" + model.RPM5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM2540JG") == true && model.RPM2540JG != null)
              {
                   strFieldSQL += ",RPM2540JG";
                   strValueSQL += ",'" + model.RPM2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPMDSJG") == true && model.RPMDSJG != null)
              {
                   strFieldSQL += ",RPMDSJG";
                   strValueSQL += ",'" + model.RPMDSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSNO") == true && model.DSNO != null)
              {
                   strFieldSQL += ",DSNO";
                   strValueSQL += ",'" + model.DSNO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025JG") == true && model.NMD5025JG != null)
              {
                   strFieldSQL += ",NMD5025JG";
                   strValueSQL += ",'" + model.NMD5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540JG") == true && model.NMD2540JG != null)
              {
                   strFieldSQL += ",NMD2540JG";
                   strValueSQL += ",'" + model.NMD2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDSJG") == true && model.NMDDSJG != null)
              {
                   strFieldSQL += ",NMDDSJG";
                   strValueSQL += ",'" + model.NMDDSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD5025CODE") == true && model.OBD5025CODE != null)
              {
                   strFieldSQL += ",OBD5025CODE";
                   strValueSQL += ",'" + model.OBD5025CODE.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD2540CODE") == true && model.OBD2540CODE != null)
              {
                   strFieldSQL += ",OBD2540CODE";
                   strValueSQL += ",'" + model.OBD2540CODE.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO25025XZ") == true && model.CO25025XZ != null)
              {
                   strFieldSQL += ",CO25025XZ";
                   strValueSQL += ",'" + model.CO25025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO22540XZ") == true && model.CO22540XZ != null)
              {
                   strFieldSQL += ",CO22540XZ";
                   strValueSQL += ",'" + model.CO22540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2DSZX") == true && model.CO2DSZX != null)
              {
                   strFieldSQL += ",CO2DSZX";
                   strValueSQL += ",'" + model.CO2DSZX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O25025XZ") == true && model.O25025XZ != null)
              {
                   strFieldSQL += ",O25025XZ";
                   strValueSQL += ",'" + model.O25025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O22540XZ") == true && model.O22540XZ != null)
              {
                   strFieldSQL += ",O22540XZ";
                   strValueSQL += ",'" + model.O22540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O2DSXZ") == true && model.O2DSXZ != null)
              {
                   strFieldSQL += ",O2DSXZ";
                   strValueSQL += ",'" + model.O2DSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM5025XZ") == true && model.RPM5025XZ != null)
              {
                   strFieldSQL += ",RPM5025XZ";
                   strValueSQL += ",'" + model.RPM5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM2540XZ") == true && model.RPM2540XZ != null)
              {
                   strFieldSQL += ",RPM2540XZ";
                   strValueSQL += ",'" + model.RPM2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPMDSXZ") == true && model.RPMDSXZ != null)
              {
                   strFieldSQL += ",RPMDSXZ";
                   strValueSQL += ",'" + model.RPMDSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSNOXZ") == true && model.DSNOXZ != null)
              {
                   strFieldSQL += ",DSNOXZ";
                   strValueSQL += ",'" + model.DSNOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025XZ_MAX") == true && model.NMD5025XZ_MAX != null)
              {
                   strFieldSQL += ",NMD5025XZ_MAX";
                   strValueSQL += ",'" + model.NMD5025XZ_MAX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025XZ_MIN") == true && model.NMD5025XZ_MIN != null)
              {
                   strFieldSQL += ",NMD5025XZ_MIN";
                   strValueSQL += ",'" + model.NMD5025XZ_MIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540XZ_MAX") == true && model.NMD2540XZ_MAX != null)
              {
                   strFieldSQL += ",NMD2540XZ_MAX";
                   strValueSQL += ",'" + model.NMD2540XZ_MAX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540XZ_MIN") == true && model.NMD2540XZ_MIN != null)
              {
                   strFieldSQL += ",NMD2540XZ_MIN";
                   strValueSQL += ",'" + model.NMD2540XZ_MIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDSXZ_MAX") == true && model.NMDDSXZ_MAX != null)
              {
                   strFieldSQL += ",NMDDSXZ_MAX";
                   strValueSQL += ",'" + model.NMDDSXZ_MAX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDSXZ_MIN") == true && model.NMDDSXZ_MIN != null)
              {
                   strFieldSQL += ",NMDDSXZ_MIN";
                   strValueSQL += ",'" + model.NMDDSXZ_MIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD5025_PD") == true && model.OBD5025_PD != null)
              {
                   strFieldSQL += ",OBD5025_PD";
                   strValueSQL += ",'" + model.OBD5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD2540_PD") == true && model.OBD2540_PD != null)
              {
                   strFieldSQL += ",OBD2540_PD";
                   strValueSQL += ",'" + model.OBD2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO25025_PD") == true && model.CO25025_PD != null)
              {
                   strFieldSQL += ",CO25025_PD";
                   strValueSQL += ",'" + model.CO25025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO22540_PD") == true && model.CO22540_PD != null)
              {
                   strFieldSQL += ",CO22540_PD";
                   strValueSQL += ",'" + model.CO22540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2DS_PD") == true && model.CO2DS_PD != null)
              {
                   strFieldSQL += ",CO2DS_PD";
                   strValueSQL += ",'" + model.CO2DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O25025_PD") == true && model.O25025_PD != null)
              {
                   strFieldSQL += ",O25025_PD";
                   strValueSQL += ",'" + model.O25025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O22540_PD") == true && model.O22540_PD != null)
              {
                   strFieldSQL += ",O22540_PD";
                   strValueSQL += ",'" + model.O22540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O2DS_PD") == true && model.O2DS_PD != null)
              {
                   strFieldSQL += ",O2DS_PD";
                   strValueSQL += ",'" + model.O2DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM5025_PD") == true && model.RPM5025_PD != null)
              {
                   strFieldSQL += ",RPM5025_PD";
                   strValueSQL += ",'" + model.RPM5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM2540_PD") == true && model.RPM2540_PD != null)
              {
                   strFieldSQL += ",RPM2540_PD";
                   strValueSQL += ",'" + model.RPM2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPMDS_PD") == true && model.RPMDS_PD != null)
              {
                   strFieldSQL += ",RPMDS_PD";
                   strValueSQL += ",'" + model.RPMDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSNO_PD") == true && model.DSNO_PD != null)
              {
                   strFieldSQL += ",DSNO_PD";
                   strValueSQL += ",'" + model.DSNO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025_PD") == true && model.NMD5025_PD != null)
              {
                   strFieldSQL += ",NMD5025_PD";
                   strValueSQL += ",'" + model.NMD5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540_PD") == true && model.NMD2540_PD != null)
              {
                   strFieldSQL += ",NMD2540_PD";
                   strValueSQL += ",'" + model.NMD2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDS_PD") == true && model.NMDDS_PD != null)
              {
                   strFieldSQL += ",NMDDS_PD";
                   strValueSQL += ",'" + model.NMDDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_DS_PD") == true && model.ASM_DS_PD != null)
              {
                   strFieldSQL += ",ASM_DS_PD";
                   strValueSQL += ",'" + model.ASM_DS_PD.ToString().Replace("'","''") + "'";
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

              if(model.Changed("DCF5025") == true && model.DCF5025 != null)
              {
                   strFieldSQL += ",DCF5025";
                   strValueSQL += ",'" + model.DCF5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Kh5025") == true && model.Kh5025 != null)
              {
                   strFieldSQL += ",Kh5025";
                   strValueSQL += ",'" + model.Kh5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DCF2540") == true && model.DCF2540 != null)
              {
                   strFieldSQL += ",DCF2540";
                   strValueSQL += ",'" + model.DCF2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Kh2540") == true && model.Kh2540 != null)
              {
                   strFieldSQL += ",Kh2540";
                   strValueSQL += ",'" + model.Kh2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has5025FastPassed") == true && model.Has5025FastPassed != null)
              {
                   strFieldSQL += ",Has5025FastPassed";
                   strValueSQL += ",'" + model.Has5025FastPassed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has5025Passed") == true && model.Has5025Passed != null)
              {
                   strFieldSQL += ",Has5025Passed";
                   strValueSQL += ",'" + model.Has5025Passed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has2540FastPassed") == true && model.Has2540FastPassed != null)
              {
                   strFieldSQL += ",Has2540FastPassed";
                   strValueSQL += ",'" + model.Has2540FastPassed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has2540Passed") == true && model.Has2540Passed != null)
              {
                   strFieldSQL += ",Has2540Passed";
                   strValueSQL += ",'" + model.Has2540Passed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                   strFieldSQL += ",StopReason";
                   strValueSQL += ",'" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_CO5025JG") == true && model.PT_CO5025JG != null)
              {
                   strFieldSQL += ",PT_CO5025JG";
                   strValueSQL += ",'" + model.PT_CO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_HC5025JG") == true && model.PT_HC5025JG != null)
              {
                   strFieldSQL += ",PT_HC5025JG";
                   strValueSQL += ",'" + model.PT_HC5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO5025JG") == true && model.PT_NO5025JG != null)
              {
                   strFieldSQL += ",PT_NO5025JG";
                   strValueSQL += ",'" + model.PT_NO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_CO2540JG") == true && model.PT_CO2540JG != null)
              {
                   strFieldSQL += ",PT_CO2540JG";
                   strValueSQL += ",'" + model.PT_CO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_HC2540JG") == true && model.PT_HC2540JG != null)
              {
                   strFieldSQL += ",PT_HC2540JG";
                   strValueSQL += ",'" + model.PT_HC2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO2540JG") == true && model.PT_NO2540JG != null)
              {
                   strFieldSQL += ",PT_NO2540JG";
                   strValueSQL += ",'" + model.PT_NO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ASM_PD") == true && model.PT_ASM_PD != null)
              {
                   strFieldSQL += ",PT_ASM_PD";
                   strValueSQL += ",'" + model.PT_ASM_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("THP5025") == true && model.THP5025 != null)
              {
                   strFieldSQL += ",THP5025";
                   strValueSQL += ",'" + model.THP5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("THP2540") == true && model.THP2540 != null)
              {
                   strFieldSQL += ",THP2540";
                   strValueSQL += ",'" + model.THP2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFKSTG5025") == true && model.SFKSTG5025 != null)
              {
                   strFieldSQL += ",SFKSTG5025";
                   strValueSQL += ",'" + model.SFKSTG5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFKSTG2540") == true && model.SFKSTG2540 != null)
              {
                   strFieldSQL += ",SFKSTG2540";
                   strValueSQL += ",'" + model.SFKSTG2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Lamba5025") == true && model.Lamba5025 != null)
              {
                   strFieldSQL += ",Lamba5025";
                   strValueSQL += ",'" + model.Lamba5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Lamba2540") == true && model.Lamba2540 != null)
              {
                   strFieldSQL += ",Lamba2540";
                   strValueSQL += ",'" + model.Lamba2540.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_ASM";
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
          public bool Insert(RESULT_ASM model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_ASM model,string strJCLSH)
          {
              string strUpdateSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMJCCS") == true && model.ASMJCCS != null)
              {
                  strUpdateSQL += ",ASMJCCS='" + model.ASMJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC5025JG") == true && model.HC5025JG != null)
              {
                  strUpdateSQL += ",HC5025JG='" + model.HC5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO5025JG") == true && model.CO5025JG != null)
              {
                  strUpdateSQL += ",CO5025JG='" + model.CO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO5025JG") == true && model.NO5025JG != null)
              {
                  strUpdateSQL += ",NO5025JG='" + model.NO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC2540JG") == true && model.HC2540JG != null)
              {
                  strUpdateSQL += ",HC2540JG='" + model.HC2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2540JG") == true && model.CO2540JG != null)
              {
                  strUpdateSQL += ",CO2540JG='" + model.CO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO2540JG") == true && model.NO2540JG != null)
              {
                  strUpdateSQL += ",NO2540JG='" + model.NO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC5025XZ") == true && model.HC5025XZ != null)
              {
                  strUpdateSQL += ",HC5025XZ='" + model.HC5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO5025XZ") == true && model.CO5025XZ != null)
              {
                  strUpdateSQL += ",CO5025XZ='" + model.CO5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO5025XZ") == true && model.NO5025XZ != null)
              {
                  strUpdateSQL += ",NO5025XZ='" + model.NO5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC2540XZ") == true && model.HC2540XZ != null)
              {
                  strUpdateSQL += ",HC2540XZ='" + model.HC2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2540XZ") == true && model.CO2540XZ != null)
              {
                  strUpdateSQL += ",CO2540XZ='" + model.CO2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO2540XZ") == true && model.NO2540XZ != null)
              {
                  strUpdateSQL += ",NO2540XZ='" + model.NO2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC5025_PD") == true && model.HC5025_PD != null)
              {
                  strUpdateSQL += ",HC5025_PD='" + model.HC5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO5025_PD") == true && model.CO5025_PD != null)
              {
                  strUpdateSQL += ",CO5025_PD='" + model.CO5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO5025_PD") == true && model.NO5025_PD != null)
              {
                  strUpdateSQL += ",NO5025_PD='" + model.NO5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC2540_PD") == true && model.HC2540_PD != null)
              {
                  strUpdateSQL += ",HC2540_PD='" + model.HC2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2540_PD") == true && model.CO2540_PD != null)
              {
                  strUpdateSQL += ",CO2540_PD='" + model.CO2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO2540_PD") == true && model.NO2540_PD != null)
              {
                  strUpdateSQL += ",NO2540_PD='" + model.NO2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_5025_PD") == true && model.ASM_5025_PD != null)
              {
                  strUpdateSQL += ",ASM_5025_PD='" + model.ASM_5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_2540_PD") == true && model.ASM_2540_PD != null)
              {
                  strUpdateSQL += ",ASM_2540_PD='" + model.ASM_2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_PD") == true && model.ASM_PD != null)
              {
                  strUpdateSQL += ",ASM_PD='" + model.ASM_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMWD") == true && model.ASMWD != null)
              {
                  strUpdateSQL += ",ASMWD='" + model.ASMWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMDQY") == true && model.ASMDQY != null)
              {
                  strUpdateSQL += ",ASMDQY='" + model.ASMDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMSD") == true && model.ASMSD != null)
              {
                  strUpdateSQL += ",ASMSD='" + model.ASMSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASMYW") == true && model.ASMYW != null)
              {
                  strUpdateSQL += ",ASMYW='" + model.ASMYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSYW") == true && model.DSYW != null)
              {
                  strUpdateSQL += ",DSYW='" + model.DSYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC") == true && model.DSHC != null)
              {
                  strUpdateSQL += ",DSHC='" + model.DSHC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO") == true && model.DSCO != null)
              {
                  strUpdateSQL += ",DSCO='" + model.DSCO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHCXZ") == true && model.DSHCXZ != null)
              {
                  strUpdateSQL += ",DSHCXZ='" + model.DSHCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCOXZ") == true && model.DSCOXZ != null)
              {
                  strUpdateSQL += ",DSCOXZ='" + model.DSCOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSHC_PD") == true && model.DSHC_PD != null)
              {
                  strUpdateSQL += ",DSHC_PD='" + model.DSHC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSCO_PD") == true && model.DSCO_PD != null)
              {
                  strUpdateSQL += ",DSCO_PD='" + model.DSCO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL5025") == true && model.GL5025 != null)
              {
                  strUpdateSQL += ",GL5025='" + model.GL5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL2540") == true && model.GL2540 != null)
              {
                  strUpdateSQL += ",GL2540='" + model.GL2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO25025JG") == true && model.CO25025JG != null)
              {
                  strUpdateSQL += ",CO25025JG='" + model.CO25025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO22540JG") == true && model.CO22540JG != null)
              {
                  strUpdateSQL += ",CO22540JG='" + model.CO22540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2DSJG") == true && model.CO2DSJG != null)
              {
                  strUpdateSQL += ",CO2DSJG='" + model.CO2DSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O25025JG") == true && model.O25025JG != null)
              {
                  strUpdateSQL += ",O25025JG='" + model.O25025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O22540JG") == true && model.O22540JG != null)
              {
                  strUpdateSQL += ",O22540JG='" + model.O22540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O2DSJG") == true && model.O2DSJG != null)
              {
                  strUpdateSQL += ",O2DSJG='" + model.O2DSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM5025JG") == true && model.RPM5025JG != null)
              {
                  strUpdateSQL += ",RPM5025JG='" + model.RPM5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM2540JG") == true && model.RPM2540JG != null)
              {
                  strUpdateSQL += ",RPM2540JG='" + model.RPM2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPMDSJG") == true && model.RPMDSJG != null)
              {
                  strUpdateSQL += ",RPMDSJG='" + model.RPMDSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSNO") == true && model.DSNO != null)
              {
                  strUpdateSQL += ",DSNO='" + model.DSNO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025JG") == true && model.NMD5025JG != null)
              {
                  strUpdateSQL += ",NMD5025JG='" + model.NMD5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540JG") == true && model.NMD2540JG != null)
              {
                  strUpdateSQL += ",NMD2540JG='" + model.NMD2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDSJG") == true && model.NMDDSJG != null)
              {
                  strUpdateSQL += ",NMDDSJG='" + model.NMDDSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD5025CODE") == true && model.OBD5025CODE != null)
              {
                  strUpdateSQL += ",OBD5025CODE='" + model.OBD5025CODE.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD2540CODE") == true && model.OBD2540CODE != null)
              {
                  strUpdateSQL += ",OBD2540CODE='" + model.OBD2540CODE.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO25025XZ") == true && model.CO25025XZ != null)
              {
                  strUpdateSQL += ",CO25025XZ='" + model.CO25025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO22540XZ") == true && model.CO22540XZ != null)
              {
                  strUpdateSQL += ",CO22540XZ='" + model.CO22540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2DSZX") == true && model.CO2DSZX != null)
              {
                  strUpdateSQL += ",CO2DSZX='" + model.CO2DSZX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O25025XZ") == true && model.O25025XZ != null)
              {
                  strUpdateSQL += ",O25025XZ='" + model.O25025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O22540XZ") == true && model.O22540XZ != null)
              {
                  strUpdateSQL += ",O22540XZ='" + model.O22540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O2DSXZ") == true && model.O2DSXZ != null)
              {
                  strUpdateSQL += ",O2DSXZ='" + model.O2DSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM5025XZ") == true && model.RPM5025XZ != null)
              {
                  strUpdateSQL += ",RPM5025XZ='" + model.RPM5025XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM2540XZ") == true && model.RPM2540XZ != null)
              {
                  strUpdateSQL += ",RPM2540XZ='" + model.RPM2540XZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPMDSXZ") == true && model.RPMDSXZ != null)
              {
                  strUpdateSQL += ",RPMDSXZ='" + model.RPMDSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSNOXZ") == true && model.DSNOXZ != null)
              {
                  strUpdateSQL += ",DSNOXZ='" + model.DSNOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025XZ_MAX") == true && model.NMD5025XZ_MAX != null)
              {
                  strUpdateSQL += ",NMD5025XZ_MAX='" + model.NMD5025XZ_MAX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025XZ_MIN") == true && model.NMD5025XZ_MIN != null)
              {
                  strUpdateSQL += ",NMD5025XZ_MIN='" + model.NMD5025XZ_MIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540XZ_MAX") == true && model.NMD2540XZ_MAX != null)
              {
                  strUpdateSQL += ",NMD2540XZ_MAX='" + model.NMD2540XZ_MAX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540XZ_MIN") == true && model.NMD2540XZ_MIN != null)
              {
                  strUpdateSQL += ",NMD2540XZ_MIN='" + model.NMD2540XZ_MIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDSXZ_MAX") == true && model.NMDDSXZ_MAX != null)
              {
                  strUpdateSQL += ",NMDDSXZ_MAX='" + model.NMDDSXZ_MAX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDSXZ_MIN") == true && model.NMDDSXZ_MIN != null)
              {
                  strUpdateSQL += ",NMDDSXZ_MIN='" + model.NMDDSXZ_MIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD5025_PD") == true && model.OBD5025_PD != null)
              {
                  strUpdateSQL += ",OBD5025_PD='" + model.OBD5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBD2540_PD") == true && model.OBD2540_PD != null)
              {
                  strUpdateSQL += ",OBD2540_PD='" + model.OBD2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO25025_PD") == true && model.CO25025_PD != null)
              {
                  strUpdateSQL += ",CO25025_PD='" + model.CO25025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO22540_PD") == true && model.CO22540_PD != null)
              {
                  strUpdateSQL += ",CO22540_PD='" + model.CO22540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2DS_PD") == true && model.CO2DS_PD != null)
              {
                  strUpdateSQL += ",CO2DS_PD='" + model.CO2DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O25025_PD") == true && model.O25025_PD != null)
              {
                  strUpdateSQL += ",O25025_PD='" + model.O25025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O22540_PD") == true && model.O22540_PD != null)
              {
                  strUpdateSQL += ",O22540_PD='" + model.O22540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("O2DS_PD") == true && model.O2DS_PD != null)
              {
                  strUpdateSQL += ",O2DS_PD='" + model.O2DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM5025_PD") == true && model.RPM5025_PD != null)
              {
                  strUpdateSQL += ",RPM5025_PD='" + model.RPM5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPM2540_PD") == true && model.RPM2540_PD != null)
              {
                  strUpdateSQL += ",RPM2540_PD='" + model.RPM2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RPMDS_PD") == true && model.RPMDS_PD != null)
              {
                  strUpdateSQL += ",RPMDS_PD='" + model.RPMDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSNO_PD") == true && model.DSNO_PD != null)
              {
                  strUpdateSQL += ",DSNO_PD='" + model.DSNO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD5025_PD") == true && model.NMD5025_PD != null)
              {
                  strUpdateSQL += ",NMD5025_PD='" + model.NMD5025_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMD2540_PD") == true && model.NMD2540_PD != null)
              {
                  strUpdateSQL += ",NMD2540_PD='" + model.NMD2540_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NMDDS_PD") == true && model.NMDDS_PD != null)
              {
                  strUpdateSQL += ",NMDDS_PD='" + model.NMDDS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ASM_DS_PD") == true && model.ASM_DS_PD != null)
              {
                  strUpdateSQL += ",ASM_DS_PD='" + model.ASM_DS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KSSJ") == true && model.KSSJ != null)
              {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSSJ") == true && model.JSSJ != null)
              {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
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

              if(model.Changed("DCF5025") == true && model.DCF5025 != null)
              {
                  strUpdateSQL += ",DCF5025='" + model.DCF5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Kh5025") == true && model.Kh5025 != null)
              {
                  strUpdateSQL += ",Kh5025='" + model.Kh5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DCF2540") == true && model.DCF2540 != null)
              {
                  strUpdateSQL += ",DCF2540='" + model.DCF2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Kh2540") == true && model.Kh2540 != null)
              {
                  strUpdateSQL += ",Kh2540='" + model.Kh2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has5025FastPassed") == true && model.Has5025FastPassed != null)
              {
                  strUpdateSQL += ",Has5025FastPassed='" + model.Has5025FastPassed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has5025Passed") == true && model.Has5025Passed != null)
              {
                  strUpdateSQL += ",Has5025Passed='" + model.Has5025Passed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has2540FastPassed") == true && model.Has2540FastPassed != null)
              {
                  strUpdateSQL += ",Has2540FastPassed='" + model.Has2540FastPassed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Has2540Passed") == true && model.Has2540Passed != null)
              {
                  strUpdateSQL += ",Has2540Passed='" + model.Has2540Passed.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_CO5025JG") == true && model.PT_CO5025JG != null)
              {
                  strUpdateSQL += ",PT_CO5025JG='" + model.PT_CO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_HC5025JG") == true && model.PT_HC5025JG != null)
              {
                  strUpdateSQL += ",PT_HC5025JG='" + model.PT_HC5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO5025JG") == true && model.PT_NO5025JG != null)
              {
                  strUpdateSQL += ",PT_NO5025JG='" + model.PT_NO5025JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_CO2540JG") == true && model.PT_CO2540JG != null)
              {
                  strUpdateSQL += ",PT_CO2540JG='" + model.PT_CO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_HC2540JG") == true && model.PT_HC2540JG != null)
              {
                  strUpdateSQL += ",PT_HC2540JG='" + model.PT_HC2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO2540JG") == true && model.PT_NO2540JG != null)
              {
                  strUpdateSQL += ",PT_NO2540JG='" + model.PT_NO2540JG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_ASM_PD") == true && model.PT_ASM_PD != null)
              {
                  strUpdateSQL += ",PT_ASM_PD='" + model.PT_ASM_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("THP5025") == true && model.THP5025 != null)
              {
                  strUpdateSQL += ",THP5025='" + model.THP5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("THP2540") == true && model.THP2540 != null)
              {
                  strUpdateSQL += ",THP2540='" + model.THP2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFKSTG5025") == true && model.SFKSTG5025 != null)
              {
                  strUpdateSQL += ",SFKSTG5025='" + model.SFKSTG5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFKSTG2540") == true && model.SFKSTG2540 != null)
              {
                  strUpdateSQL += ",SFKSTG2540='" + model.SFKSTG2540.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Lamba5025") == true && model.Lamba5025 != null)
              {
                  strUpdateSQL += ",Lamba5025='" + model.Lamba5025.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Lamba2540") == true && model.Lamba2540 != null)
              {
                  strUpdateSQL += ",Lamba2540='" + model.Lamba2540.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_ASM set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_ASM model, string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strJCLSH));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_ASM model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASMJCCS") == true && model.ASMJCCS != null)
               {
                  strUpdateSQL += ",ASMJCCS='" + model.ASMJCCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC5025JG") == true && model.HC5025JG != null)
               {
                  strUpdateSQL += ",HC5025JG='" + model.HC5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO5025JG") == true && model.CO5025JG != null)
               {
                  strUpdateSQL += ",CO5025JG='" + model.CO5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO5025JG") == true && model.NO5025JG != null)
               {
                  strUpdateSQL += ",NO5025JG='" + model.NO5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC2540JG") == true && model.HC2540JG != null)
               {
                  strUpdateSQL += ",HC2540JG='" + model.HC2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2540JG") == true && model.CO2540JG != null)
               {
                  strUpdateSQL += ",CO2540JG='" + model.CO2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO2540JG") == true && model.NO2540JG != null)
               {
                  strUpdateSQL += ",NO2540JG='" + model.NO2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC5025XZ") == true && model.HC5025XZ != null)
               {
                  strUpdateSQL += ",HC5025XZ='" + model.HC5025XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO5025XZ") == true && model.CO5025XZ != null)
               {
                  strUpdateSQL += ",CO5025XZ='" + model.CO5025XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO5025XZ") == true && model.NO5025XZ != null)
               {
                  strUpdateSQL += ",NO5025XZ='" + model.NO5025XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC2540XZ") == true && model.HC2540XZ != null)
               {
                  strUpdateSQL += ",HC2540XZ='" + model.HC2540XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2540XZ") == true && model.CO2540XZ != null)
               {
                  strUpdateSQL += ",CO2540XZ='" + model.CO2540XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO2540XZ") == true && model.NO2540XZ != null)
               {
                  strUpdateSQL += ",NO2540XZ='" + model.NO2540XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC5025_PD") == true && model.HC5025_PD != null)
               {
                  strUpdateSQL += ",HC5025_PD='" + model.HC5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO5025_PD") == true && model.CO5025_PD != null)
               {
                  strUpdateSQL += ",CO5025_PD='" + model.CO5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO5025_PD") == true && model.NO5025_PD != null)
               {
                  strUpdateSQL += ",NO5025_PD='" + model.NO5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC2540_PD") == true && model.HC2540_PD != null)
               {
                  strUpdateSQL += ",HC2540_PD='" + model.HC2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2540_PD") == true && model.CO2540_PD != null)
               {
                  strUpdateSQL += ",CO2540_PD='" + model.CO2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO2540_PD") == true && model.NO2540_PD != null)
               {
                  strUpdateSQL += ",NO2540_PD='" + model.NO2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASM_5025_PD") == true && model.ASM_5025_PD != null)
               {
                  strUpdateSQL += ",ASM_5025_PD='" + model.ASM_5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASM_2540_PD") == true && model.ASM_2540_PD != null)
               {
                  strUpdateSQL += ",ASM_2540_PD='" + model.ASM_2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASM_PD") == true && model.ASM_PD != null)
               {
                  strUpdateSQL += ",ASM_PD='" + model.ASM_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASMWD") == true && model.ASMWD != null)
               {
                  strUpdateSQL += ",ASMWD='" + model.ASMWD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASMDQY") == true && model.ASMDQY != null)
               {
                  strUpdateSQL += ",ASMDQY='" + model.ASMDQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASMSD") == true && model.ASMSD != null)
               {
                  strUpdateSQL += ",ASMSD='" + model.ASMSD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASMYW") == true && model.ASMYW != null)
               {
                  strUpdateSQL += ",ASMYW='" + model.ASMYW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSYW") == true && model.DSYW != null)
               {
                  strUpdateSQL += ",DSYW='" + model.DSYW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHC") == true && model.DSHC != null)
               {
                  strUpdateSQL += ",DSHC='" + model.DSHC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCO") == true && model.DSCO != null)
               {
                  strUpdateSQL += ",DSCO='" + model.DSCO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHCXZ") == true && model.DSHCXZ != null)
               {
                  strUpdateSQL += ",DSHCXZ='" + model.DSHCXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCOXZ") == true && model.DSCOXZ != null)
               {
                  strUpdateSQL += ",DSCOXZ='" + model.DSCOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSHC_PD") == true && model.DSHC_PD != null)
               {
                  strUpdateSQL += ",DSHC_PD='" + model.DSHC_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSCO_PD") == true && model.DSCO_PD != null)
               {
                  strUpdateSQL += ",DSCO_PD='" + model.DSCO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GL5025") == true && model.GL5025 != null)
               {
                  strUpdateSQL += ",GL5025='" + model.GL5025.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GL2540") == true && model.GL2540 != null)
               {
                  strUpdateSQL += ",GL2540='" + model.GL2540.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO25025JG") == true && model.CO25025JG != null)
               {
                  strUpdateSQL += ",CO25025JG='" + model.CO25025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO22540JG") == true && model.CO22540JG != null)
               {
                  strUpdateSQL += ",CO22540JG='" + model.CO22540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2DSJG") == true && model.CO2DSJG != null)
               {
                  strUpdateSQL += ",CO2DSJG='" + model.CO2DSJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O25025JG") == true && model.O25025JG != null)
               {
                  strUpdateSQL += ",O25025JG='" + model.O25025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O22540JG") == true && model.O22540JG != null)
               {
                  strUpdateSQL += ",O22540JG='" + model.O22540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O2DSJG") == true && model.O2DSJG != null)
               {
                  strUpdateSQL += ",O2DSJG='" + model.O2DSJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPM5025JG") == true && model.RPM5025JG != null)
               {
                  strUpdateSQL += ",RPM5025JG='" + model.RPM5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPM2540JG") == true && model.RPM2540JG != null)
               {
                  strUpdateSQL += ",RPM2540JG='" + model.RPM2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPMDSJG") == true && model.RPMDSJG != null)
               {
                  strUpdateSQL += ",RPMDSJG='" + model.RPMDSJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSNO") == true && model.DSNO != null)
               {
                  strUpdateSQL += ",DSNO='" + model.DSNO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD5025JG") == true && model.NMD5025JG != null)
               {
                  strUpdateSQL += ",NMD5025JG='" + model.NMD5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD2540JG") == true && model.NMD2540JG != null)
               {
                  strUpdateSQL += ",NMD2540JG='" + model.NMD2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMDDSJG") == true && model.NMDDSJG != null)
               {
                  strUpdateSQL += ",NMDDSJG='" + model.NMDDSJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBD5025CODE") == true && model.OBD5025CODE != null)
               {
                  strUpdateSQL += ",OBD5025CODE='" + model.OBD5025CODE.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBD2540CODE") == true && model.OBD2540CODE != null)
               {
                  strUpdateSQL += ",OBD2540CODE='" + model.OBD2540CODE.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO25025XZ") == true && model.CO25025XZ != null)
               {
                  strUpdateSQL += ",CO25025XZ='" + model.CO25025XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO22540XZ") == true && model.CO22540XZ != null)
               {
                  strUpdateSQL += ",CO22540XZ='" + model.CO22540XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2DSZX") == true && model.CO2DSZX != null)
               {
                  strUpdateSQL += ",CO2DSZX='" + model.CO2DSZX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O25025XZ") == true && model.O25025XZ != null)
               {
                  strUpdateSQL += ",O25025XZ='" + model.O25025XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O22540XZ") == true && model.O22540XZ != null)
               {
                  strUpdateSQL += ",O22540XZ='" + model.O22540XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O2DSXZ") == true && model.O2DSXZ != null)
               {
                  strUpdateSQL += ",O2DSXZ='" + model.O2DSXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPM5025XZ") == true && model.RPM5025XZ != null)
               {
                  strUpdateSQL += ",RPM5025XZ='" + model.RPM5025XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPM2540XZ") == true && model.RPM2540XZ != null)
               {
                  strUpdateSQL += ",RPM2540XZ='" + model.RPM2540XZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPMDSXZ") == true && model.RPMDSXZ != null)
               {
                  strUpdateSQL += ",RPMDSXZ='" + model.RPMDSXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSNOXZ") == true && model.DSNOXZ != null)
               {
                  strUpdateSQL += ",DSNOXZ='" + model.DSNOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD5025XZ_MAX") == true && model.NMD5025XZ_MAX != null)
               {
                  strUpdateSQL += ",NMD5025XZ_MAX='" + model.NMD5025XZ_MAX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD5025XZ_MIN") == true && model.NMD5025XZ_MIN != null)
               {
                  strUpdateSQL += ",NMD5025XZ_MIN='" + model.NMD5025XZ_MIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD2540XZ_MAX") == true && model.NMD2540XZ_MAX != null)
               {
                  strUpdateSQL += ",NMD2540XZ_MAX='" + model.NMD2540XZ_MAX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD2540XZ_MIN") == true && model.NMD2540XZ_MIN != null)
               {
                  strUpdateSQL += ",NMD2540XZ_MIN='" + model.NMD2540XZ_MIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMDDSXZ_MAX") == true && model.NMDDSXZ_MAX != null)
               {
                  strUpdateSQL += ",NMDDSXZ_MAX='" + model.NMDDSXZ_MAX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMDDSXZ_MIN") == true && model.NMDDSXZ_MIN != null)
               {
                  strUpdateSQL += ",NMDDSXZ_MIN='" + model.NMDDSXZ_MIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBD5025_PD") == true && model.OBD5025_PD != null)
               {
                  strUpdateSQL += ",OBD5025_PD='" + model.OBD5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBD2540_PD") == true && model.OBD2540_PD != null)
               {
                  strUpdateSQL += ",OBD2540_PD='" + model.OBD2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO25025_PD") == true && model.CO25025_PD != null)
               {
                  strUpdateSQL += ",CO25025_PD='" + model.CO25025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO22540_PD") == true && model.CO22540_PD != null)
               {
                  strUpdateSQL += ",CO22540_PD='" + model.CO22540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2DS_PD") == true && model.CO2DS_PD != null)
               {
                  strUpdateSQL += ",CO2DS_PD='" + model.CO2DS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O25025_PD") == true && model.O25025_PD != null)
               {
                  strUpdateSQL += ",O25025_PD='" + model.O25025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O22540_PD") == true && model.O22540_PD != null)
               {
                  strUpdateSQL += ",O22540_PD='" + model.O22540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("O2DS_PD") == true && model.O2DS_PD != null)
               {
                  strUpdateSQL += ",O2DS_PD='" + model.O2DS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPM5025_PD") == true && model.RPM5025_PD != null)
               {
                  strUpdateSQL += ",RPM5025_PD='" + model.RPM5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPM2540_PD") == true && model.RPM2540_PD != null)
               {
                  strUpdateSQL += ",RPM2540_PD='" + model.RPM2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RPMDS_PD") == true && model.RPMDS_PD != null)
               {
                  strUpdateSQL += ",RPMDS_PD='" + model.RPMDS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSNO_PD") == true && model.DSNO_PD != null)
               {
                  strUpdateSQL += ",DSNO_PD='" + model.DSNO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD5025_PD") == true && model.NMD5025_PD != null)
               {
                  strUpdateSQL += ",NMD5025_PD='" + model.NMD5025_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMD2540_PD") == true && model.NMD2540_PD != null)
               {
                  strUpdateSQL += ",NMD2540_PD='" + model.NMD2540_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NMDDS_PD") == true && model.NMDDS_PD != null)
               {
                  strUpdateSQL += ",NMDDS_PD='" + model.NMDDS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ASM_DS_PD") == true && model.ASM_DS_PD != null)
               {
                  strUpdateSQL += ",ASM_DS_PD='" + model.ASM_DS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KSSJ") == true && model.KSSJ != null)
               {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JSSJ") == true && model.JSSJ != null)
               {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
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

               if(model.Changed("DCF5025") == true && model.DCF5025 != null)
               {
                  strUpdateSQL += ",DCF5025='" + model.DCF5025.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Kh5025") == true && model.Kh5025 != null)
               {
                  strUpdateSQL += ",Kh5025='" + model.Kh5025.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DCF2540") == true && model.DCF2540 != null)
               {
                  strUpdateSQL += ",DCF2540='" + model.DCF2540.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Kh2540") == true && model.Kh2540 != null)
               {
                  strUpdateSQL += ",Kh2540='" + model.Kh2540.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Has5025FastPassed") == true && model.Has5025FastPassed != null)
               {
                  strUpdateSQL += ",Has5025FastPassed='" + model.Has5025FastPassed.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Has5025Passed") == true && model.Has5025Passed != null)
               {
                  strUpdateSQL += ",Has5025Passed='" + model.Has5025Passed.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Has2540FastPassed") == true && model.Has2540FastPassed != null)
               {
                  strUpdateSQL += ",Has2540FastPassed='" + model.Has2540FastPassed.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Has2540Passed") == true && model.Has2540Passed != null)
               {
                  strUpdateSQL += ",Has2540Passed='" + model.Has2540Passed.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("StopReason") == true && model.StopReason != null)
               {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_CO5025JG") == true && model.PT_CO5025JG != null)
               {
                  strUpdateSQL += ",PT_CO5025JG='" + model.PT_CO5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_HC5025JG") == true && model.PT_HC5025JG != null)
               {
                  strUpdateSQL += ",PT_HC5025JG='" + model.PT_HC5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_NO5025JG") == true && model.PT_NO5025JG != null)
               {
                  strUpdateSQL += ",PT_NO5025JG='" + model.PT_NO5025JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_CO2540JG") == true && model.PT_CO2540JG != null)
               {
                  strUpdateSQL += ",PT_CO2540JG='" + model.PT_CO2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_HC2540JG") == true && model.PT_HC2540JG != null)
               {
                  strUpdateSQL += ",PT_HC2540JG='" + model.PT_HC2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_NO2540JG") == true && model.PT_NO2540JG != null)
               {
                  strUpdateSQL += ",PT_NO2540JG='" + model.PT_NO2540JG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_ASM_PD") == true && model.PT_ASM_PD != null)
               {
                  strUpdateSQL += ",PT_ASM_PD='" + model.PT_ASM_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("THP5025") == true && model.THP5025 != null)
               {
                  strUpdateSQL += ",THP5025='" + model.THP5025.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("THP2540") == true && model.THP2540 != null)
               {
                  strUpdateSQL += ",THP2540='" + model.THP2540.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SFKSTG5025") == true && model.SFKSTG5025 != null)
               {
                  strUpdateSQL += ",SFKSTG5025='" + model.SFKSTG5025.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SFKSTG2540") == true && model.SFKSTG2540 != null)
               {
                  strUpdateSQL += ",SFKSTG2540='" + model.SFKSTG2540.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Lamba5025") == true && model.Lamba5025 != null)
               {
                  strUpdateSQL += ",Lamba5025='" + model.Lamba5025.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Lamba2540") == true && model.Lamba2540 != null)
               {
                  strUpdateSQL += ",Lamba2540='" + model.Lamba2540.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_ASM set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_ASM model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_ASM model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASMJCCS='" + model.ASMJCCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC5025JG='" + model.HC5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO5025JG='" + model.CO5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO5025JG='" + model.NO5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC2540JG='" + model.HC2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2540JG='" + model.CO2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO2540JG='" + model.NO2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC5025XZ='" + model.HC5025XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO5025XZ='" + model.CO5025XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO5025XZ='" + model.NO5025XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC2540XZ='" + model.HC2540XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2540XZ='" + model.CO2540XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO2540XZ='" + model.NO2540XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC5025_PD='" + model.HC5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO5025_PD='" + model.CO5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO5025_PD='" + model.NO5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC2540_PD='" + model.HC2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2540_PD='" + model.CO2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO2540_PD='" + model.NO2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASM_5025_PD='" + model.ASM_5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASM_2540_PD='" + model.ASM_2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASM_PD='" + model.ASM_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASMWD='" + model.ASMWD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASMDQY='" + model.ASMDQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASMSD='" + model.ASMSD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASMYW='" + model.ASMYW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSYW='" + model.DSYW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHC='" + model.DSHC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCO='" + model.DSCO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHCXZ='" + model.DSHCXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCOXZ='" + model.DSCOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSHC_PD='" + model.DSHC_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSCO_PD='" + model.DSCO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GL5025='" + model.GL5025.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GL2540='" + model.GL2540.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO25025JG='" + model.CO25025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO22540JG='" + model.CO22540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2DSJG='" + model.CO2DSJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O25025JG='" + model.O25025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O22540JG='" + model.O22540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O2DSJG='" + model.O2DSJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPM5025JG='" + model.RPM5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPM2540JG='" + model.RPM2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPMDSJG='" + model.RPMDSJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSNO='" + model.DSNO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD5025JG='" + model.NMD5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD2540JG='" + model.NMD2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMDDSJG='" + model.NMDDSJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBD5025CODE='" + model.OBD5025CODE.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBD2540CODE='" + model.OBD2540CODE.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO25025XZ='" + model.CO25025XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO22540XZ='" + model.CO22540XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2DSZX='" + model.CO2DSZX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O25025XZ='" + model.O25025XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O22540XZ='" + model.O22540XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O2DSXZ='" + model.O2DSXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPM5025XZ='" + model.RPM5025XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPM2540XZ='" + model.RPM2540XZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPMDSXZ='" + model.RPMDSXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSNOXZ='" + model.DSNOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD5025XZ_MAX='" + model.NMD5025XZ_MAX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD5025XZ_MIN='" + model.NMD5025XZ_MIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD2540XZ_MAX='" + model.NMD2540XZ_MAX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD2540XZ_MIN='" + model.NMD2540XZ_MIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMDDSXZ_MAX='" + model.NMDDSXZ_MAX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMDDSXZ_MIN='" + model.NMDDSXZ_MIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBD5025_PD='" + model.OBD5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBD2540_PD='" + model.OBD2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO25025_PD='" + model.CO25025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO22540_PD='" + model.CO22540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2DS_PD='" + model.CO2DS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O25025_PD='" + model.O25025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O22540_PD='" + model.O22540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",O2DS_PD='" + model.O2DS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPM5025_PD='" + model.RPM5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPM2540_PD='" + model.RPM2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RPMDS_PD='" + model.RPMDS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSNO_PD='" + model.DSNO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD5025_PD='" + model.NMD5025_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMD2540_PD='" + model.NMD2540_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NMDDS_PD='" + model.NMDDS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ASM_DS_PD='" + model.ASM_DS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
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
                  strUpdateSQL += ",DCF5025='" + model.DCF5025.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Kh5025='" + model.Kh5025.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DCF2540='" + model.DCF2540.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Kh2540='" + model.Kh2540.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Has5025FastPassed='" + model.Has5025FastPassed.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Has5025Passed='" + model.Has5025Passed.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Has2540FastPassed='" + model.Has2540FastPassed.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Has2540Passed='" + model.Has2540Passed.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_CO5025JG='" + model.PT_CO5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_HC5025JG='" + model.PT_HC5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_NO5025JG='" + model.PT_NO5025JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_CO2540JG='" + model.PT_CO2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_HC2540JG='" + model.PT_HC2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_NO2540JG='" + model.PT_NO2540JG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_ASM_PD='" + model.PT_ASM_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",THP5025='" + model.THP5025.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",THP2540='" + model.THP2540.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SFKSTG5025='" + model.SFKSTG5025.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SFKSTG2540='" + model.SFKSTG2540.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Lamba5025='" + model.Lamba5025.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Lamba2540='" + model.Lamba2540.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_ASM set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_ASM model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strJCLSH)
          {
              string strSql = "";
              strSql += "delete from RESULT_ASM";
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
              strSql += "delete from RESULT_ASM";
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
              strSql += "delete from RESULT_ASM";

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
         public RESULT_ASM GetModel(string strJCLSH)
         {
             string strSql = "";
             strSql += "select * from RESULT_ASM";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_ASM model = new RESULT_ASM();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_ASM();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.ASMJCCS = dtTemp.Rows[0]["ASMJCCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASMJCCS"].ToString();
                 model.HC5025JG = dtTemp.Rows[0]["HC5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC5025JG"].ToString();
                 model.CO5025JG = dtTemp.Rows[0]["CO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO5025JG"].ToString();
                 model.NO5025JG = dtTemp.Rows[0]["NO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO5025JG"].ToString();
                 model.HC2540JG = dtTemp.Rows[0]["HC2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC2540JG"].ToString();
                 model.CO2540JG = dtTemp.Rows[0]["CO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2540JG"].ToString();
                 model.NO2540JG = dtTemp.Rows[0]["NO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO2540JG"].ToString();
                 model.HC5025XZ = dtTemp.Rows[0]["HC5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC5025XZ"].ToString();
                 model.CO5025XZ = dtTemp.Rows[0]["CO5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO5025XZ"].ToString();
                 model.NO5025XZ = dtTemp.Rows[0]["NO5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO5025XZ"].ToString();
                 model.HC2540XZ = dtTemp.Rows[0]["HC2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC2540XZ"].ToString();
                 model.CO2540XZ = dtTemp.Rows[0]["CO2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2540XZ"].ToString();
                 model.NO2540XZ = dtTemp.Rows[0]["NO2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO2540XZ"].ToString();
                 model.HC5025_PD = dtTemp.Rows[0]["HC5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC5025_PD"].ToString();
                 model.CO5025_PD = dtTemp.Rows[0]["CO5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO5025_PD"].ToString();
                 model.NO5025_PD = dtTemp.Rows[0]["NO5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO5025_PD"].ToString();
                 model.HC2540_PD = dtTemp.Rows[0]["HC2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC2540_PD"].ToString();
                 model.CO2540_PD = dtTemp.Rows[0]["CO2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2540_PD"].ToString();
                 model.NO2540_PD = dtTemp.Rows[0]["NO2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO2540_PD"].ToString();
                 model.ASM_5025_PD = dtTemp.Rows[0]["ASM_5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASM_5025_PD"].ToString();
                 model.ASM_2540_PD = dtTemp.Rows[0]["ASM_2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASM_2540_PD"].ToString();
                 model.ASM_PD = dtTemp.Rows[0]["ASM_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASM_PD"].ToString();
                 model.ASMWD = dtTemp.Rows[0]["ASMWD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASMWD"].ToString();
                 model.ASMDQY = dtTemp.Rows[0]["ASMDQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASMDQY"].ToString();
                 model.ASMSD = dtTemp.Rows[0]["ASMSD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASMSD"].ToString();
                 model.ASMYW = dtTemp.Rows[0]["ASMYW"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASMYW"].ToString();
                 model.DSYW = dtTemp.Rows[0]["DSYW"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSYW"].ToString();
                 model.DSHC = dtTemp.Rows[0]["DSHC"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHC"].ToString();
                 model.DSCO = dtTemp.Rows[0]["DSCO"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCO"].ToString();
                 model.DSHCXZ = dtTemp.Rows[0]["DSHCXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHCXZ"].ToString();
                 model.DSCOXZ = dtTemp.Rows[0]["DSCOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCOXZ"].ToString();
                 model.DSHC_PD = dtTemp.Rows[0]["DSHC_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSHC_PD"].ToString();
                 model.DSCO_PD = dtTemp.Rows[0]["DSCO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSCO_PD"].ToString();
                 model.GL5025 = dtTemp.Rows[0]["GL5025"] == DBNull.Value ? "" : dtTemp.Rows[0]["GL5025"].ToString();
                 model.GL2540 = dtTemp.Rows[0]["GL2540"] == DBNull.Value ? "" : dtTemp.Rows[0]["GL2540"].ToString();
                 model.CO25025JG = dtTemp.Rows[0]["CO25025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO25025JG"].ToString();
                 model.CO22540JG = dtTemp.Rows[0]["CO22540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO22540JG"].ToString();
                 model.CO2DSJG = dtTemp.Rows[0]["CO2DSJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2DSJG"].ToString();
                 model.O25025JG = dtTemp.Rows[0]["O25025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["O25025JG"].ToString();
                 model.O22540JG = dtTemp.Rows[0]["O22540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["O22540JG"].ToString();
                 model.O2DSJG = dtTemp.Rows[0]["O2DSJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["O2DSJG"].ToString();
                 model.RPM5025JG = dtTemp.Rows[0]["RPM5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPM5025JG"].ToString();
                 model.RPM2540JG = dtTemp.Rows[0]["RPM2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPM2540JG"].ToString();
                 model.RPMDSJG = dtTemp.Rows[0]["RPMDSJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPMDSJG"].ToString();
                 model.DSNO = dtTemp.Rows[0]["DSNO"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSNO"].ToString();
                 model.NMD5025JG = dtTemp.Rows[0]["NMD5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD5025JG"].ToString();
                 model.NMD2540JG = dtTemp.Rows[0]["NMD2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD2540JG"].ToString();
                 model.NMDDSJG = dtTemp.Rows[0]["NMDDSJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMDDSJG"].ToString();
                 model.OBD5025CODE = dtTemp.Rows[0]["OBD5025CODE"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBD5025CODE"].ToString();
                 model.OBD2540CODE = dtTemp.Rows[0]["OBD2540CODE"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBD2540CODE"].ToString();
                 model.CO25025XZ = dtTemp.Rows[0]["CO25025XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO25025XZ"].ToString();
                 model.CO22540XZ = dtTemp.Rows[0]["CO22540XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO22540XZ"].ToString();
                 model.CO2DSZX = dtTemp.Rows[0]["CO2DSZX"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2DSZX"].ToString();
                 model.O25025XZ = dtTemp.Rows[0]["O25025XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["O25025XZ"].ToString();
                 model.O22540XZ = dtTemp.Rows[0]["O22540XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["O22540XZ"].ToString();
                 model.O2DSXZ = dtTemp.Rows[0]["O2DSXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["O2DSXZ"].ToString();
                 model.RPM5025XZ = dtTemp.Rows[0]["RPM5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPM5025XZ"].ToString();
                 model.RPM2540XZ = dtTemp.Rows[0]["RPM2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPM2540XZ"].ToString();
                 model.RPMDSXZ = dtTemp.Rows[0]["RPMDSXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPMDSXZ"].ToString();
                 model.DSNOXZ = dtTemp.Rows[0]["DSNOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSNOXZ"].ToString();
                 model.NMD5025XZ_MAX = dtTemp.Rows[0]["NMD5025XZ_MAX"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD5025XZ_MAX"].ToString();
                 model.NMD5025XZ_MIN = dtTemp.Rows[0]["NMD5025XZ_MIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD5025XZ_MIN"].ToString();
                 model.NMD2540XZ_MAX = dtTemp.Rows[0]["NMD2540XZ_MAX"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD2540XZ_MAX"].ToString();
                 model.NMD2540XZ_MIN = dtTemp.Rows[0]["NMD2540XZ_MIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD2540XZ_MIN"].ToString();
                 model.NMDDSXZ_MAX = dtTemp.Rows[0]["NMDDSXZ_MAX"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMDDSXZ_MAX"].ToString();
                 model.NMDDSXZ_MIN = dtTemp.Rows[0]["NMDDSXZ_MIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMDDSXZ_MIN"].ToString();
                 model.OBD5025_PD = dtTemp.Rows[0]["OBD5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBD5025_PD"].ToString();
                 model.OBD2540_PD = dtTemp.Rows[0]["OBD2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBD2540_PD"].ToString();
                 model.CO25025_PD = dtTemp.Rows[0]["CO25025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO25025_PD"].ToString();
                 model.CO22540_PD = dtTemp.Rows[0]["CO22540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO22540_PD"].ToString();
                 model.CO2DS_PD = dtTemp.Rows[0]["CO2DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2DS_PD"].ToString();
                 model.O25025_PD = dtTemp.Rows[0]["O25025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["O25025_PD"].ToString();
                 model.O22540_PD = dtTemp.Rows[0]["O22540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["O22540_PD"].ToString();
                 model.O2DS_PD = dtTemp.Rows[0]["O2DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["O2DS_PD"].ToString();
                 model.RPM5025_PD = dtTemp.Rows[0]["RPM5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPM5025_PD"].ToString();
                 model.RPM2540_PD = dtTemp.Rows[0]["RPM2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPM2540_PD"].ToString();
                 model.RPMDS_PD = dtTemp.Rows[0]["RPMDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["RPMDS_PD"].ToString();
                 model.DSNO_PD = dtTemp.Rows[0]["DSNO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSNO_PD"].ToString();
                 model.NMD5025_PD = dtTemp.Rows[0]["NMD5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD5025_PD"].ToString();
                 model.NMD2540_PD = dtTemp.Rows[0]["NMD2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMD2540_PD"].ToString();
                 model.NMDDS_PD = dtTemp.Rows[0]["NMDDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NMDDS_PD"].ToString();
                 model.ASM_DS_PD = dtTemp.Rows[0]["ASM_DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ASM_DS_PD"].ToString();
                 model.KSSJ = dtTemp.Rows[0]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["KSSJ"].ToString();
                 model.JSSJ = dtTemp.Rows[0]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JSSJ"].ToString();
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
                 model.DCF5025 = dtTemp.Rows[0]["DCF5025"] == DBNull.Value ? "" : dtTemp.Rows[0]["DCF5025"].ToString();
                 model.Kh5025 = dtTemp.Rows[0]["Kh5025"] == DBNull.Value ? "" : dtTemp.Rows[0]["Kh5025"].ToString();
                 model.DCF2540 = dtTemp.Rows[0]["DCF2540"] == DBNull.Value ? "" : dtTemp.Rows[0]["DCF2540"].ToString();
                 model.Kh2540 = dtTemp.Rows[0]["Kh2540"] == DBNull.Value ? "" : dtTemp.Rows[0]["Kh2540"].ToString();
                 model.Has5025FastPassed = dtTemp.Rows[0]["Has5025FastPassed"] == DBNull.Value ? "" : dtTemp.Rows[0]["Has5025FastPassed"].ToString();
                 model.Has5025Passed = dtTemp.Rows[0]["Has5025Passed"] == DBNull.Value ? "" : dtTemp.Rows[0]["Has5025Passed"].ToString();
                 model.Has2540FastPassed = dtTemp.Rows[0]["Has2540FastPassed"] == DBNull.Value ? "" : dtTemp.Rows[0]["Has2540FastPassed"].ToString();
                 model.Has2540Passed = dtTemp.Rows[0]["Has2540Passed"] == DBNull.Value ? "" : dtTemp.Rows[0]["Has2540Passed"].ToString();
                 model.StopReason = dtTemp.Rows[0]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[0]["StopReason"].ToString();
                 model.PT_CO5025JG = dtTemp.Rows[0]["PT_CO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_CO5025JG"].ToString();
                 model.PT_HC5025JG = dtTemp.Rows[0]["PT_HC5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_HC5025JG"].ToString();
                 model.PT_NO5025JG = dtTemp.Rows[0]["PT_NO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_NO5025JG"].ToString();
                 model.PT_CO2540JG = dtTemp.Rows[0]["PT_CO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_CO2540JG"].ToString();
                 model.PT_HC2540JG = dtTemp.Rows[0]["PT_HC2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_HC2540JG"].ToString();
                 model.PT_NO2540JG = dtTemp.Rows[0]["PT_NO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_NO2540JG"].ToString();
                 model.PT_ASM_PD = dtTemp.Rows[0]["PT_ASM_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_ASM_PD"].ToString();
                 model.THP5025 = dtTemp.Rows[0]["THP5025"] == DBNull.Value ? "" : dtTemp.Rows[0]["THP5025"].ToString();
                 model.THP2540 = dtTemp.Rows[0]["THP2540"] == DBNull.Value ? "" : dtTemp.Rows[0]["THP2540"].ToString();
                 model.SFKSTG5025 = dtTemp.Rows[0]["SFKSTG5025"] == DBNull.Value ? "" : dtTemp.Rows[0]["SFKSTG5025"].ToString();
                 model.SFKSTG2540 = dtTemp.Rows[0]["SFKSTG2540"] == DBNull.Value ? "" : dtTemp.Rows[0]["SFKSTG2540"].ToString();
                 model.Lamba5025 = dtTemp.Rows[0]["Lamba5025"] == DBNull.Value ? "" : dtTemp.Rows[0]["Lamba5025"].ToString();
                 model.Lamba2540 = dtTemp.Rows[0]["Lamba2540"] == DBNull.Value ? "" : dtTemp.Rows[0]["Lamba2540"].ToString();
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
             strSql += "select * from RESULT_ASM";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ASM[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_ASM";
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

          RESULT_ASM[] arrModel=new RESULT_ASM[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_ASM();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].ASMJCCS = dtTemp.Rows[N]["ASMJCCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASMJCCS"].ToString();
                 arrModel[N].HC5025JG = dtTemp.Rows[N]["HC5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC5025JG"].ToString();
                 arrModel[N].CO5025JG = dtTemp.Rows[N]["CO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO5025JG"].ToString();
                 arrModel[N].NO5025JG = dtTemp.Rows[N]["NO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO5025JG"].ToString();
                 arrModel[N].HC2540JG = dtTemp.Rows[N]["HC2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC2540JG"].ToString();
                 arrModel[N].CO2540JG = dtTemp.Rows[N]["CO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2540JG"].ToString();
                 arrModel[N].NO2540JG = dtTemp.Rows[N]["NO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO2540JG"].ToString();
                 arrModel[N].HC5025XZ = dtTemp.Rows[N]["HC5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC5025XZ"].ToString();
                 arrModel[N].CO5025XZ = dtTemp.Rows[N]["CO5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO5025XZ"].ToString();
                 arrModel[N].NO5025XZ = dtTemp.Rows[N]["NO5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO5025XZ"].ToString();
                 arrModel[N].HC2540XZ = dtTemp.Rows[N]["HC2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC2540XZ"].ToString();
                 arrModel[N].CO2540XZ = dtTemp.Rows[N]["CO2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2540XZ"].ToString();
                 arrModel[N].NO2540XZ = dtTemp.Rows[N]["NO2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO2540XZ"].ToString();
                 arrModel[N].HC5025_PD = dtTemp.Rows[N]["HC5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC5025_PD"].ToString();
                 arrModel[N].CO5025_PD = dtTemp.Rows[N]["CO5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO5025_PD"].ToString();
                 arrModel[N].NO5025_PD = dtTemp.Rows[N]["NO5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO5025_PD"].ToString();
                 arrModel[N].HC2540_PD = dtTemp.Rows[N]["HC2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC2540_PD"].ToString();
                 arrModel[N].CO2540_PD = dtTemp.Rows[N]["CO2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2540_PD"].ToString();
                 arrModel[N].NO2540_PD = dtTemp.Rows[N]["NO2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO2540_PD"].ToString();
                 arrModel[N].ASM_5025_PD = dtTemp.Rows[N]["ASM_5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASM_5025_PD"].ToString();
                 arrModel[N].ASM_2540_PD = dtTemp.Rows[N]["ASM_2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASM_2540_PD"].ToString();
                 arrModel[N].ASM_PD = dtTemp.Rows[N]["ASM_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASM_PD"].ToString();
                 arrModel[N].ASMWD = dtTemp.Rows[N]["ASMWD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASMWD"].ToString();
                 arrModel[N].ASMDQY = dtTemp.Rows[N]["ASMDQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASMDQY"].ToString();
                 arrModel[N].ASMSD = dtTemp.Rows[N]["ASMSD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASMSD"].ToString();
                 arrModel[N].ASMYW = dtTemp.Rows[N]["ASMYW"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASMYW"].ToString();
                 arrModel[N].DSYW = dtTemp.Rows[N]["DSYW"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSYW"].ToString();
                 arrModel[N].DSHC = dtTemp.Rows[N]["DSHC"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHC"].ToString();
                 arrModel[N].DSCO = dtTemp.Rows[N]["DSCO"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCO"].ToString();
                 arrModel[N].DSHCXZ = dtTemp.Rows[N]["DSHCXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHCXZ"].ToString();
                 arrModel[N].DSCOXZ = dtTemp.Rows[N]["DSCOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCOXZ"].ToString();
                 arrModel[N].DSHC_PD = dtTemp.Rows[N]["DSHC_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSHC_PD"].ToString();
                 arrModel[N].DSCO_PD = dtTemp.Rows[N]["DSCO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSCO_PD"].ToString();
                 arrModel[N].GL5025 = dtTemp.Rows[N]["GL5025"] == DBNull.Value ? "" : dtTemp.Rows[N]["GL5025"].ToString();
                 arrModel[N].GL2540 = dtTemp.Rows[N]["GL2540"] == DBNull.Value ? "" : dtTemp.Rows[N]["GL2540"].ToString();
                 arrModel[N].CO25025JG = dtTemp.Rows[N]["CO25025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO25025JG"].ToString();
                 arrModel[N].CO22540JG = dtTemp.Rows[N]["CO22540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO22540JG"].ToString();
                 arrModel[N].CO2DSJG = dtTemp.Rows[N]["CO2DSJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2DSJG"].ToString();
                 arrModel[N].O25025JG = dtTemp.Rows[N]["O25025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["O25025JG"].ToString();
                 arrModel[N].O22540JG = dtTemp.Rows[N]["O22540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["O22540JG"].ToString();
                 arrModel[N].O2DSJG = dtTemp.Rows[N]["O2DSJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["O2DSJG"].ToString();
                 arrModel[N].RPM5025JG = dtTemp.Rows[N]["RPM5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPM5025JG"].ToString();
                 arrModel[N].RPM2540JG = dtTemp.Rows[N]["RPM2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPM2540JG"].ToString();
                 arrModel[N].RPMDSJG = dtTemp.Rows[N]["RPMDSJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPMDSJG"].ToString();
                 arrModel[N].DSNO = dtTemp.Rows[N]["DSNO"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSNO"].ToString();
                 arrModel[N].NMD5025JG = dtTemp.Rows[N]["NMD5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD5025JG"].ToString();
                 arrModel[N].NMD2540JG = dtTemp.Rows[N]["NMD2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD2540JG"].ToString();
                 arrModel[N].NMDDSJG = dtTemp.Rows[N]["NMDDSJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMDDSJG"].ToString();
                 arrModel[N].OBD5025CODE = dtTemp.Rows[N]["OBD5025CODE"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBD5025CODE"].ToString();
                 arrModel[N].OBD2540CODE = dtTemp.Rows[N]["OBD2540CODE"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBD2540CODE"].ToString();
                 arrModel[N].CO25025XZ = dtTemp.Rows[N]["CO25025XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO25025XZ"].ToString();
                 arrModel[N].CO22540XZ = dtTemp.Rows[N]["CO22540XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO22540XZ"].ToString();
                 arrModel[N].CO2DSZX = dtTemp.Rows[N]["CO2DSZX"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2DSZX"].ToString();
                 arrModel[N].O25025XZ = dtTemp.Rows[N]["O25025XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["O25025XZ"].ToString();
                 arrModel[N].O22540XZ = dtTemp.Rows[N]["O22540XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["O22540XZ"].ToString();
                 arrModel[N].O2DSXZ = dtTemp.Rows[N]["O2DSXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["O2DSXZ"].ToString();
                 arrModel[N].RPM5025XZ = dtTemp.Rows[N]["RPM5025XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPM5025XZ"].ToString();
                 arrModel[N].RPM2540XZ = dtTemp.Rows[N]["RPM2540XZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPM2540XZ"].ToString();
                 arrModel[N].RPMDSXZ = dtTemp.Rows[N]["RPMDSXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPMDSXZ"].ToString();
                 arrModel[N].DSNOXZ = dtTemp.Rows[N]["DSNOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSNOXZ"].ToString();
                 arrModel[N].NMD5025XZ_MAX = dtTemp.Rows[N]["NMD5025XZ_MAX"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD5025XZ_MAX"].ToString();
                 arrModel[N].NMD5025XZ_MIN = dtTemp.Rows[N]["NMD5025XZ_MIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD5025XZ_MIN"].ToString();
                 arrModel[N].NMD2540XZ_MAX = dtTemp.Rows[N]["NMD2540XZ_MAX"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD2540XZ_MAX"].ToString();
                 arrModel[N].NMD2540XZ_MIN = dtTemp.Rows[N]["NMD2540XZ_MIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD2540XZ_MIN"].ToString();
                 arrModel[N].NMDDSXZ_MAX = dtTemp.Rows[N]["NMDDSXZ_MAX"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMDDSXZ_MAX"].ToString();
                 arrModel[N].NMDDSXZ_MIN = dtTemp.Rows[N]["NMDDSXZ_MIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMDDSXZ_MIN"].ToString();
                 arrModel[N].OBD5025_PD = dtTemp.Rows[N]["OBD5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBD5025_PD"].ToString();
                 arrModel[N].OBD2540_PD = dtTemp.Rows[N]["OBD2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBD2540_PD"].ToString();
                 arrModel[N].CO25025_PD = dtTemp.Rows[N]["CO25025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO25025_PD"].ToString();
                 arrModel[N].CO22540_PD = dtTemp.Rows[N]["CO22540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO22540_PD"].ToString();
                 arrModel[N].CO2DS_PD = dtTemp.Rows[N]["CO2DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2DS_PD"].ToString();
                 arrModel[N].O25025_PD = dtTemp.Rows[N]["O25025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["O25025_PD"].ToString();
                 arrModel[N].O22540_PD = dtTemp.Rows[N]["O22540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["O22540_PD"].ToString();
                 arrModel[N].O2DS_PD = dtTemp.Rows[N]["O2DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["O2DS_PD"].ToString();
                 arrModel[N].RPM5025_PD = dtTemp.Rows[N]["RPM5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPM5025_PD"].ToString();
                 arrModel[N].RPM2540_PD = dtTemp.Rows[N]["RPM2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPM2540_PD"].ToString();
                 arrModel[N].RPMDS_PD = dtTemp.Rows[N]["RPMDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["RPMDS_PD"].ToString();
                 arrModel[N].DSNO_PD = dtTemp.Rows[N]["DSNO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSNO_PD"].ToString();
                 arrModel[N].NMD5025_PD = dtTemp.Rows[N]["NMD5025_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD5025_PD"].ToString();
                 arrModel[N].NMD2540_PD = dtTemp.Rows[N]["NMD2540_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMD2540_PD"].ToString();
                 arrModel[N].NMDDS_PD = dtTemp.Rows[N]["NMDDS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NMDDS_PD"].ToString();
                 arrModel[N].ASM_DS_PD = dtTemp.Rows[N]["ASM_DS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ASM_DS_PD"].ToString();
                 arrModel[N].KSSJ = dtTemp.Rows[N]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["KSSJ"].ToString();
                 arrModel[N].JSSJ = dtTemp.Rows[N]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JSSJ"].ToString();
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
                 arrModel[N].DCF5025 = dtTemp.Rows[N]["DCF5025"] == DBNull.Value ? "" : dtTemp.Rows[N]["DCF5025"].ToString();
                 arrModel[N].Kh5025 = dtTemp.Rows[N]["Kh5025"] == DBNull.Value ? "" : dtTemp.Rows[N]["Kh5025"].ToString();
                 arrModel[N].DCF2540 = dtTemp.Rows[N]["DCF2540"] == DBNull.Value ? "" : dtTemp.Rows[N]["DCF2540"].ToString();
                 arrModel[N].Kh2540 = dtTemp.Rows[N]["Kh2540"] == DBNull.Value ? "" : dtTemp.Rows[N]["Kh2540"].ToString();
                 arrModel[N].Has5025FastPassed = dtTemp.Rows[N]["Has5025FastPassed"] == DBNull.Value ? "" : dtTemp.Rows[N]["Has5025FastPassed"].ToString();
                 arrModel[N].Has5025Passed = dtTemp.Rows[N]["Has5025Passed"] == DBNull.Value ? "" : dtTemp.Rows[N]["Has5025Passed"].ToString();
                 arrModel[N].Has2540FastPassed = dtTemp.Rows[N]["Has2540FastPassed"] == DBNull.Value ? "" : dtTemp.Rows[N]["Has2540FastPassed"].ToString();
                 arrModel[N].Has2540Passed = dtTemp.Rows[N]["Has2540Passed"] == DBNull.Value ? "" : dtTemp.Rows[N]["Has2540Passed"].ToString();
                 arrModel[N].StopReason = dtTemp.Rows[N]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[N]["StopReason"].ToString();
                 arrModel[N].PT_CO5025JG = dtTemp.Rows[N]["PT_CO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_CO5025JG"].ToString();
                 arrModel[N].PT_HC5025JG = dtTemp.Rows[N]["PT_HC5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_HC5025JG"].ToString();
                 arrModel[N].PT_NO5025JG = dtTemp.Rows[N]["PT_NO5025JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_NO5025JG"].ToString();
                 arrModel[N].PT_CO2540JG = dtTemp.Rows[N]["PT_CO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_CO2540JG"].ToString();
                 arrModel[N].PT_HC2540JG = dtTemp.Rows[N]["PT_HC2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_HC2540JG"].ToString();
                 arrModel[N].PT_NO2540JG = dtTemp.Rows[N]["PT_NO2540JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_NO2540JG"].ToString();
                 arrModel[N].PT_ASM_PD = dtTemp.Rows[N]["PT_ASM_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_ASM_PD"].ToString();
                 arrModel[N].THP5025 = dtTemp.Rows[N]["THP5025"] == DBNull.Value ? "" : dtTemp.Rows[N]["THP5025"].ToString();
                 arrModel[N].THP2540 = dtTemp.Rows[N]["THP2540"] == DBNull.Value ? "" : dtTemp.Rows[N]["THP2540"].ToString();
                 arrModel[N].SFKSTG5025 = dtTemp.Rows[N]["SFKSTG5025"] == DBNull.Value ? "" : dtTemp.Rows[N]["SFKSTG5025"].ToString();
                 arrModel[N].SFKSTG2540 = dtTemp.Rows[N]["SFKSTG2540"] == DBNull.Value ? "" : dtTemp.Rows[N]["SFKSTG2540"].ToString();
                 arrModel[N].Lamba5025 = dtTemp.Rows[N]["Lamba5025"] == DBNull.Value ? "" : dtTemp.Rows[N]["Lamba5025"].ToString();
                 arrModel[N].Lamba2540 = dtTemp.Rows[N]["Lamba2540"] == DBNull.Value ? "" : dtTemp.Rows[N]["Lamba2540"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ASM[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ASM[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ASM[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ASM[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_ASM[] GetModelList()
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
          strSql += "select * from RESULT_ASM";
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
