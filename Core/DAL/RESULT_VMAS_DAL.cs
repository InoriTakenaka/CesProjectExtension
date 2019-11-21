using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_VMAS_DAL
     /// </summary>
     public class RESULT_VMAS_DAL
     {
         private string Conn{ get;set; }
         public RESULT_VMAS_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(JCLSH) as m from RESULT_VMAS";

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
               strSql += "select count(1) as c from RESULT_VMAS";
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
              strSql += "select count(1) as c from RESULT_VMAS";
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
          public string InsertSQL(RESULT_VMAS model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VMASJCCS") == true && model.VMASJCCS != null)
              {
                   strFieldSQL += ",VMASJCCS";
                   strValueSQL += ",'" + model.VMASJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCJG") == true && model.HCJG != null)
              {
                   strFieldSQL += ",HCJG";
                   strValueSQL += ",'" + model.HCJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("COJG") == true && model.COJG != null)
              {
                   strFieldSQL += ",COJG";
                   strValueSQL += ",'" + model.COJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOJG") == true && model.NOJG != null)
              {
                   strFieldSQL += ",NOJG";
                   strValueSQL += ",'" + model.NOJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NOJG") == true && model.HC_NOJG != null)
              {
                   strFieldSQL += ",HC_NOJG";
                   strValueSQL += ",'" + model.HC_NOJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCXZ") == true && model.HCXZ != null)
              {
                   strFieldSQL += ",HCXZ";
                   strValueSQL += ",'" + model.HCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("COXZ") == true && model.COXZ != null)
              {
                   strFieldSQL += ",COXZ";
                   strValueSQL += ",'" + model.COXZ.ToString().Replace("'","''") + "'";
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

              if(model.Changed("HC_PD") == true && model.HC_PD != null)
              {
                   strFieldSQL += ",HC_PD";
                   strValueSQL += ",'" + model.HC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO_PD") == true && model.CO_PD != null)
              {
                   strFieldSQL += ",CO_PD";
                   strValueSQL += ",'" + model.CO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO_PD") == true && model.NO_PD != null)
              {
                   strFieldSQL += ",NO_PD";
                   strValueSQL += ",'" + model.NO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NO_PD") == true && model.HC_NO_PD != null)
              {
                   strFieldSQL += ",HC_NO_PD";
                   strValueSQL += ",'" + model.HC_NO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PDFS") == true && model.PDFS != null)
              {
                   strFieldSQL += ",PDFS";
                   strValueSQL += ",'" + model.PDFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LXWCSJ") == true && model.LXWCSJ != null)
              {
                   strFieldSQL += ",LXWCSJ";
                   strValueSQL += ",'" + model.LXWCSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LJWCSJ") == true && model.LJWCSJ != null)
              {
                   strFieldSQL += ",LJWCSJ";
                   strValueSQL += ",'" + model.LJWCSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LJXXLC") == true && model.LJXXLC != null)
              {
                   strFieldSQL += ",LJXXLC";
                   strValueSQL += ",'" + model.LJXXLC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VMAS_PD") == true && model.VMAS_PD != null)
              {
                   strFieldSQL += ",VMAS_PD";
                   strValueSQL += ",'" + model.VMAS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WD") == true && model.WD != null)
              {
                   strFieldSQL += ",WD";
                   strValueSQL += ",'" + model.WD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SD") == true && model.SD != null)
              {
                   strFieldSQL += ",SD";
                   strValueSQL += ",'" + model.SD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DQY") == true && model.DQY != null)
              {
                   strFieldSQL += ",DQY";
                   strValueSQL += ",'" + model.DQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BJ_O2") == true && model.BJ_O2 != null)
              {
                   strFieldSQL += ",BJ_O2";
                   strValueSQL += ",'" + model.BJ_O2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CL_HC") == true && model.CL_HC != null)
              {
                   strFieldSQL += ",CL_HC";
                   strValueSQL += ",'" + model.CL_HC.ToString().Replace("'","''") + "'";
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

              if(model.Changed("CO2JG") == true && model.CO2JG != null)
              {
                   strFieldSQL += ",CO2JG";
                   strValueSQL += ",'" + model.CO2JG.ToString().Replace("'","''") + "'";
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

              if(model.Changed("GPPLCS") == true && model.GPPLCS != null)
              {
                   strFieldSQL += ",GPPLCS";
                   strValueSQL += ",'" + model.GPPLCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                   strFieldSQL += ",StopReason";
                   strValueSQL += ",'" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_CO") == true && model.PT_CO != null)
              {
                   strFieldSQL += ",PT_CO";
                   strValueSQL += ",'" + model.PT_CO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_HC") == true && model.PT_HC != null)
              {
                   strFieldSQL += ",PT_HC";
                   strValueSQL += ",'" + model.PT_HC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO") == true && model.PT_NO != null)
              {
                   strFieldSQL += ",PT_NO";
                   strValueSQL += ",'" + model.PT_NO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_VMAS_PD") == true && model.PT_VMAS_PD != null)
              {
                   strFieldSQL += ",PT_VMAS_PD";
                   strValueSQL += ",'" + model.PT_VMAS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Lamba") == true && model.Lamba != null)
              {
                   strFieldSQL += ",Lamba";
                   strValueSQL += ",'" + model.Lamba.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_VMAS";
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
          public bool Insert(RESULT_VMAS model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_VMAS model,string strJCLSH)
          {
              string strUpdateSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VMASJCCS") == true && model.VMASJCCS != null)
              {
                  strUpdateSQL += ",VMASJCCS='" + model.VMASJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCJG") == true && model.HCJG != null)
              {
                  strUpdateSQL += ",HCJG='" + model.HCJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("COJG") == true && model.COJG != null)
              {
                  strUpdateSQL += ",COJG='" + model.COJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOJG") == true && model.NOJG != null)
              {
                  strUpdateSQL += ",NOJG='" + model.NOJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NOJG") == true && model.HC_NOJG != null)
              {
                  strUpdateSQL += ",HC_NOJG='" + model.HC_NOJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCXZ") == true && model.HCXZ != null)
              {
                  strUpdateSQL += ",HCXZ='" + model.HCXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("COXZ") == true && model.COXZ != null)
              {
                  strUpdateSQL += ",COXZ='" + model.COXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOXZ") == true && model.NOXZ != null)
              {
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NOXZ") == true && model.HC_NOXZ != null)
              {
                  strUpdateSQL += ",HC_NOXZ='" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_PD") == true && model.HC_PD != null)
              {
                  strUpdateSQL += ",HC_PD='" + model.HC_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO_PD") == true && model.CO_PD != null)
              {
                  strUpdateSQL += ",CO_PD='" + model.CO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO_PD") == true && model.NO_PD != null)
              {
                  strUpdateSQL += ",NO_PD='" + model.NO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HC_NO_PD") == true && model.HC_NO_PD != null)
              {
                  strUpdateSQL += ",HC_NO_PD='" + model.HC_NO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PDFS") == true && model.PDFS != null)
              {
                  strUpdateSQL += ",PDFS='" + model.PDFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LXWCSJ") == true && model.LXWCSJ != null)
              {
                  strUpdateSQL += ",LXWCSJ='" + model.LXWCSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LJWCSJ") == true && model.LJWCSJ != null)
              {
                  strUpdateSQL += ",LJWCSJ='" + model.LJWCSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LJXXLC") == true && model.LJXXLC != null)
              {
                  strUpdateSQL += ",LJXXLC='" + model.LJXXLC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VMAS_PD") == true && model.VMAS_PD != null)
              {
                  strUpdateSQL += ",VMAS_PD='" + model.VMAS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WD") == true && model.WD != null)
              {
                  strUpdateSQL += ",WD='" + model.WD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SD") == true && model.SD != null)
              {
                  strUpdateSQL += ",SD='" + model.SD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DQY") == true && model.DQY != null)
              {
                  strUpdateSQL += ",DQY='" + model.DQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BJ_O2") == true && model.BJ_O2 != null)
              {
                  strUpdateSQL += ",BJ_O2='" + model.BJ_O2.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CL_HC") == true && model.CL_HC != null)
              {
                  strUpdateSQL += ",CL_HC='" + model.CL_HC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KSSJ") == true && model.KSSJ != null)
              {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSSJ") == true && model.JSSJ != null)
              {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CO2JG") == true && model.CO2JG != null)
              {
                  strUpdateSQL += ",CO2JG='" + model.CO2JG.ToString().Replace("'","''") + "'";
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

              if(model.Changed("GPPLCS") == true && model.GPPLCS != null)
              {
                  strUpdateSQL += ",GPPLCS='" + model.GPPLCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_CO") == true && model.PT_CO != null)
              {
                  strUpdateSQL += ",PT_CO='" + model.PT_CO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_HC") == true && model.PT_HC != null)
              {
                  strUpdateSQL += ",PT_HC='" + model.PT_HC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO") == true && model.PT_NO != null)
              {
                  strUpdateSQL += ",PT_NO='" + model.PT_NO.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_VMAS_PD") == true && model.PT_VMAS_PD != null)
              {
                  strUpdateSQL += ",PT_VMAS_PD='" + model.PT_VMAS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Lamba") == true && model.Lamba != null)
              {
                  strUpdateSQL += ",Lamba='" + model.Lamba.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_VMAS set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_VMAS model, string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strJCLSH));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_VMAS model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("VMASJCCS") == true && model.VMASJCCS != null)
               {
                  strUpdateSQL += ",VMASJCCS='" + model.VMASJCCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HCJG") == true && model.HCJG != null)
               {
                  strUpdateSQL += ",HCJG='" + model.HCJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("COJG") == true && model.COJG != null)
               {
                  strUpdateSQL += ",COJG='" + model.COJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NOJG") == true && model.NOJG != null)
               {
                  strUpdateSQL += ",NOJG='" + model.NOJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC_NOJG") == true && model.HC_NOJG != null)
               {
                  strUpdateSQL += ",HC_NOJG='" + model.HC_NOJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HCXZ") == true && model.HCXZ != null)
               {
                  strUpdateSQL += ",HCXZ='" + model.HCXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("COXZ") == true && model.COXZ != null)
               {
                  strUpdateSQL += ",COXZ='" + model.COXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NOXZ") == true && model.NOXZ != null)
               {
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC_NOXZ") == true && model.HC_NOXZ != null)
               {
                  strUpdateSQL += ",HC_NOXZ='" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC_PD") == true && model.HC_PD != null)
               {
                  strUpdateSQL += ",HC_PD='" + model.HC_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO_PD") == true && model.CO_PD != null)
               {
                  strUpdateSQL += ",CO_PD='" + model.CO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO_PD") == true && model.NO_PD != null)
               {
                  strUpdateSQL += ",NO_PD='" + model.NO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HC_NO_PD") == true && model.HC_NO_PD != null)
               {
                  strUpdateSQL += ",HC_NO_PD='" + model.HC_NO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PDFS") == true && model.PDFS != null)
               {
                  strUpdateSQL += ",PDFS='" + model.PDFS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LXWCSJ") == true && model.LXWCSJ != null)
               {
                  strUpdateSQL += ",LXWCSJ='" + model.LXWCSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LJWCSJ") == true && model.LJWCSJ != null)
               {
                  strUpdateSQL += ",LJWCSJ='" + model.LJWCSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LJXXLC") == true && model.LJXXLC != null)
               {
                  strUpdateSQL += ",LJXXLC='" + model.LJXXLC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("VMAS_PD") == true && model.VMAS_PD != null)
               {
                  strUpdateSQL += ",VMAS_PD='" + model.VMAS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WD") == true && model.WD != null)
               {
                  strUpdateSQL += ",WD='" + model.WD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SD") == true && model.SD != null)
               {
                  strUpdateSQL += ",SD='" + model.SD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DQY") == true && model.DQY != null)
               {
                  strUpdateSQL += ",DQY='" + model.DQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BJ_O2") == true && model.BJ_O2 != null)
               {
                  strUpdateSQL += ",BJ_O2='" + model.BJ_O2.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CL_HC") == true && model.CL_HC != null)
               {
                  strUpdateSQL += ",CL_HC='" + model.CL_HC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KSSJ") == true && model.KSSJ != null)
               {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JSSJ") == true && model.JSSJ != null)
               {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CO2JG") == true && model.CO2JG != null)
               {
                  strUpdateSQL += ",CO2JG='" + model.CO2JG.ToString().Replace("'","''") + "'";
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

               if(model.Changed("GPPLCS") == true && model.GPPLCS != null)
               {
                  strUpdateSQL += ",GPPLCS='" + model.GPPLCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("StopReason") == true && model.StopReason != null)
               {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_CO") == true && model.PT_CO != null)
               {
                  strUpdateSQL += ",PT_CO='" + model.PT_CO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_HC") == true && model.PT_HC != null)
               {
                  strUpdateSQL += ",PT_HC='" + model.PT_HC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_NO") == true && model.PT_NO != null)
               {
                  strUpdateSQL += ",PT_NO='" + model.PT_NO.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_VMAS_PD") == true && model.PT_VMAS_PD != null)
               {
                  strUpdateSQL += ",PT_VMAS_PD='" + model.PT_VMAS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Lamba") == true && model.Lamba != null)
               {
                  strUpdateSQL += ",Lamba='" + model.Lamba.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_VMAS set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_VMAS model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_VMAS model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",VMASJCCS='" + model.VMASJCCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HCJG='" + model.HCJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",COJG='" + model.COJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NOJG='" + model.NOJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC_NOJG='" + model.HC_NOJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HCXZ='" + model.HCXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",COXZ='" + model.COXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC_NOXZ='" + model.HC_NOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC_PD='" + model.HC_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO_PD='" + model.CO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO_PD='" + model.NO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HC_NO_PD='" + model.HC_NO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PDFS='" + model.PDFS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LXWCSJ='" + model.LXWCSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LJWCSJ='" + model.LJWCSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LJXXLC='" + model.LJXXLC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",VMAS_PD='" + model.VMAS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WD='" + model.WD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SD='" + model.SD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DQY='" + model.DQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BJ_O2='" + model.BJ_O2.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CL_HC='" + model.CL_HC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CO2JG='" + model.CO2JG.ToString().Replace("'","''") + "'";
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
                  strUpdateSQL += ",GPPLCS='" + model.GPPLCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_CO='" + model.PT_CO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_HC='" + model.PT_HC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_NO='" + model.PT_NO.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_VMAS_PD='" + model.PT_VMAS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Lamba='" + model.Lamba.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_VMAS set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_VMAS model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strJCLSH)
          {
              string strSql = "";
              strSql += "delete from RESULT_VMAS";
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
              strSql += "delete from RESULT_VMAS";
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
              strSql += "delete from RESULT_VMAS";

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
         public RESULT_VMAS GetModel(string strJCLSH)
         {
             string strSql = "";
             strSql += "select * from RESULT_VMAS";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_VMAS model = new RESULT_VMAS();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_VMAS();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.VMASJCCS = dtTemp.Rows[0]["VMASJCCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["VMASJCCS"].ToString();
                 model.HCJG = dtTemp.Rows[0]["HCJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["HCJG"].ToString();
                 model.COJG = dtTemp.Rows[0]["COJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["COJG"].ToString();
                 model.NOJG = dtTemp.Rows[0]["NOJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["NOJG"].ToString();
                 model.HC_NOJG = dtTemp.Rows[0]["HC_NOJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC_NOJG"].ToString();
                 model.HCXZ = dtTemp.Rows[0]["HCXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HCXZ"].ToString();
                 model.COXZ = dtTemp.Rows[0]["COXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["COXZ"].ToString();
                 model.NOXZ = dtTemp.Rows[0]["NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["NOXZ"].ToString();
                 model.HC_NOXZ = dtTemp.Rows[0]["HC_NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC_NOXZ"].ToString();
                 model.HC_PD = dtTemp.Rows[0]["HC_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC_PD"].ToString();
                 model.CO_PD = dtTemp.Rows[0]["CO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO_PD"].ToString();
                 model.NO_PD = dtTemp.Rows[0]["NO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO_PD"].ToString();
                 model.HC_NO_PD = dtTemp.Rows[0]["HC_NO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["HC_NO_PD"].ToString();
                 model.PDFS = dtTemp.Rows[0]["PDFS"] == DBNull.Value ? "" : dtTemp.Rows[0]["PDFS"].ToString();
                 model.LXWCSJ = dtTemp.Rows[0]["LXWCSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LXWCSJ"].ToString();
                 model.LJWCSJ = dtTemp.Rows[0]["LJWCSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LJWCSJ"].ToString();
                 model.LJXXLC = dtTemp.Rows[0]["LJXXLC"] == DBNull.Value ? "" : dtTemp.Rows[0]["LJXXLC"].ToString();
                 model.VMAS_PD = dtTemp.Rows[0]["VMAS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["VMAS_PD"].ToString();
                 model.WD = dtTemp.Rows[0]["WD"] == DBNull.Value ? "" : dtTemp.Rows[0]["WD"].ToString();
                 model.SD = dtTemp.Rows[0]["SD"] == DBNull.Value ? "" : dtTemp.Rows[0]["SD"].ToString();
                 model.DQY = dtTemp.Rows[0]["DQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["DQY"].ToString();
                 model.BJ_O2 = dtTemp.Rows[0]["BJ_O2"] == DBNull.Value ? "" : dtTemp.Rows[0]["BJ_O2"].ToString();
                 model.CL_HC = dtTemp.Rows[0]["CL_HC"] == DBNull.Value ? "" : dtTemp.Rows[0]["CL_HC"].ToString();
                 model.KSSJ = dtTemp.Rows[0]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["KSSJ"].ToString();
                 model.JSSJ = dtTemp.Rows[0]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JSSJ"].ToString();
                 model.CO2JG = dtTemp.Rows[0]["CO2JG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CO2JG"].ToString();
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
                 model.GPPLCS = dtTemp.Rows[0]["GPPLCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["GPPLCS"].ToString();
                 model.StopReason = dtTemp.Rows[0]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[0]["StopReason"].ToString();
                 model.PT_CO = dtTemp.Rows[0]["PT_CO"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_CO"].ToString();
                 model.PT_HC = dtTemp.Rows[0]["PT_HC"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_HC"].ToString();
                 model.PT_NO = dtTemp.Rows[0]["PT_NO"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_NO"].ToString();
                 model.PT_VMAS_PD = dtTemp.Rows[0]["PT_VMAS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_VMAS_PD"].ToString();
                 model.Lamba = dtTemp.Rows[0]["Lamba"] == DBNull.Value ? "" : dtTemp.Rows[0]["Lamba"].ToString();
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
             strSql += "select * from RESULT_VMAS";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VMAS[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_VMAS";
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

          RESULT_VMAS[] arrModel=new RESULT_VMAS[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_VMAS();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].VMASJCCS = dtTemp.Rows[N]["VMASJCCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["VMASJCCS"].ToString();
                 arrModel[N].HCJG = dtTemp.Rows[N]["HCJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["HCJG"].ToString();
                 arrModel[N].COJG = dtTemp.Rows[N]["COJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["COJG"].ToString();
                 arrModel[N].NOJG = dtTemp.Rows[N]["NOJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["NOJG"].ToString();
                 arrModel[N].HC_NOJG = dtTemp.Rows[N]["HC_NOJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC_NOJG"].ToString();
                 arrModel[N].HCXZ = dtTemp.Rows[N]["HCXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HCXZ"].ToString();
                 arrModel[N].COXZ = dtTemp.Rows[N]["COXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["COXZ"].ToString();
                 arrModel[N].NOXZ = dtTemp.Rows[N]["NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["NOXZ"].ToString();
                 arrModel[N].HC_NOXZ = dtTemp.Rows[N]["HC_NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC_NOXZ"].ToString();
                 arrModel[N].HC_PD = dtTemp.Rows[N]["HC_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC_PD"].ToString();
                 arrModel[N].CO_PD = dtTemp.Rows[N]["CO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO_PD"].ToString();
                 arrModel[N].NO_PD = dtTemp.Rows[N]["NO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO_PD"].ToString();
                 arrModel[N].HC_NO_PD = dtTemp.Rows[N]["HC_NO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["HC_NO_PD"].ToString();
                 arrModel[N].PDFS = dtTemp.Rows[N]["PDFS"] == DBNull.Value ? "" : dtTemp.Rows[N]["PDFS"].ToString();
                 arrModel[N].LXWCSJ = dtTemp.Rows[N]["LXWCSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LXWCSJ"].ToString();
                 arrModel[N].LJWCSJ = dtTemp.Rows[N]["LJWCSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LJWCSJ"].ToString();
                 arrModel[N].LJXXLC = dtTemp.Rows[N]["LJXXLC"] == DBNull.Value ? "" : dtTemp.Rows[N]["LJXXLC"].ToString();
                 arrModel[N].VMAS_PD = dtTemp.Rows[N]["VMAS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["VMAS_PD"].ToString();
                 arrModel[N].WD = dtTemp.Rows[N]["WD"] == DBNull.Value ? "" : dtTemp.Rows[N]["WD"].ToString();
                 arrModel[N].SD = dtTemp.Rows[N]["SD"] == DBNull.Value ? "" : dtTemp.Rows[N]["SD"].ToString();
                 arrModel[N].DQY = dtTemp.Rows[N]["DQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["DQY"].ToString();
                 arrModel[N].BJ_O2 = dtTemp.Rows[N]["BJ_O2"] == DBNull.Value ? "" : dtTemp.Rows[N]["BJ_O2"].ToString();
                 arrModel[N].CL_HC = dtTemp.Rows[N]["CL_HC"] == DBNull.Value ? "" : dtTemp.Rows[N]["CL_HC"].ToString();
                 arrModel[N].KSSJ = dtTemp.Rows[N]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["KSSJ"].ToString();
                 arrModel[N].JSSJ = dtTemp.Rows[N]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JSSJ"].ToString();
                 arrModel[N].CO2JG = dtTemp.Rows[N]["CO2JG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CO2JG"].ToString();
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
                 arrModel[N].GPPLCS = dtTemp.Rows[N]["GPPLCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["GPPLCS"].ToString();
                 arrModel[N].StopReason = dtTemp.Rows[N]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[N]["StopReason"].ToString();
                 arrModel[N].PT_CO = dtTemp.Rows[N]["PT_CO"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_CO"].ToString();
                 arrModel[N].PT_HC = dtTemp.Rows[N]["PT_HC"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_HC"].ToString();
                 arrModel[N].PT_NO = dtTemp.Rows[N]["PT_NO"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_NO"].ToString();
                 arrModel[N].PT_VMAS_PD = dtTemp.Rows[N]["PT_VMAS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_VMAS_PD"].ToString();
                 arrModel[N].Lamba = dtTemp.Rows[N]["Lamba"] == DBNull.Value ? "" : dtTemp.Rows[N]["Lamba"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VMAS[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VMAS[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VMAS[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VMAS[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VMAS[] GetModelList()
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
          strSql += "select * from RESULT_VMAS";
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
