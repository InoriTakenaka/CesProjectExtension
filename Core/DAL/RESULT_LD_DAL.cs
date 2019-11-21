using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_LD_DAL
     /// </summary>
     public class RESULT_LD_DAL
     {
         private string Conn{ get;set; }
         public RESULT_LD_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(JCLSH) as m from RESULT_LD";

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
               strSql += "select count(1) as c from RESULT_LD";
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
              strSql += "select count(1) as c from RESULT_LD";
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
          public string InsertSQL(RESULT_LD model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDJCCS") == true && model.LDJCCS != null)
              {
                   strFieldSQL += ",LDJCCS";
                   strValueSQL += ",'" + model.LDJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLJG") == true && model.GLJG != null)
              {
                   strFieldSQL += ",GLJG";
                   strValueSQL += ",'" + model.GLJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLXZ") == true && model.GLXZ != null)
              {
                   strFieldSQL += ",GLXZ";
                   strValueSQL += ",'" + model.GLXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL_PD") == true && model.GL_PD != null)
              {
                   strFieldSQL += ",GL_PD";
                   strValueSQL += ",'" + model.GL_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZSJG") == true && model.ZSJG != null)
              {
                   strFieldSQL += ",ZSJG";
                   strValueSQL += ",'" + model.ZSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZSXZ") == true && model.ZSXZ != null)
              {
                   strFieldSQL += ",ZSXZ";
                   strValueSQL += ",'" + model.ZSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS_PD") == true && model.ZS_PD != null)
              {
                   strFieldSQL += ",ZS_PD";
                   strValueSQL += ",'" + model.ZS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS100") == true && model.GXSXS100 != null)
              {
                   strFieldSQL += ",GXSXS100";
                   strValueSQL += ",'" + model.GXSXS100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS90") == true && model.GXSXS90 != null)
              {
                   strFieldSQL += ",GXSXS90";
                   strValueSQL += ",'" + model.GXSXS90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS80") == true && model.GXSXS80 != null)
              {
                   strFieldSQL += ",GXSXS80";
                   strValueSQL += ",'" + model.GXSXS80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXSXZ") == true && model.GXSXSXZ != null)
              {
                   strFieldSQL += ",GXSXSXZ";
                   strValueSQL += ",'" + model.GXSXSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS_PD") == true && model.GXSXS_PD != null)
              {
                   strFieldSQL += ",GXSXS_PD";
                   strValueSQL += ",'" + model.GXSXS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDWD") == true && model.LDWD != null)
              {
                   strFieldSQL += ",LDWD";
                   strValueSQL += ",'" + model.LDWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDDQY") == true && model.LDDQY != null)
              {
                   strFieldSQL += ",LDDQY";
                   strValueSQL += ",'" + model.LDDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDSD") == true && model.LDSD != null)
              {
                   strFieldSQL += ",LDSD";
                   strValueSQL += ",'" + model.LDSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LD_PD") == true && model.LD_PD != null)
              {
                   strFieldSQL += ",LD_PD";
                   strValueSQL += ",'" + model.LD_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDYW") == true && model.LDYW != null)
              {
                   strFieldSQL += ",LDYW";
                   strValueSQL += ",'" + model.LDYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU100") == true && model.HSU100 != null)
              {
                   strFieldSQL += ",HSU100";
                   strValueSQL += ",'" + model.HSU100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU90") == true && model.HSU90 != null)
              {
                   strFieldSQL += ",HSU90";
                   strValueSQL += ",'" + model.HSU90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU80") == true && model.HSU80 != null)
              {
                   strFieldSQL += ",HSU80";
                   strValueSQL += ",'" + model.HSU80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSZS") == true && model.DSZS != null)
              {
                   strFieldSQL += ",DSZS";
                   strValueSQL += ",'" + model.DSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSZDGLXDSD") == true && model.JSZDGLXDSD != null)
              {
                   strFieldSQL += ",JSZDGLXDSD";
                   strValueSQL += ",'" + model.JSZDGLXDSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SCZDGLXDSD") == true && model.SCZDGLXDSD != null)
              {
                   strFieldSQL += ",SCZDGLXDSD";
                   strValueSQL += ",'" + model.SCZDGLXDSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SMSJ") == true && model.SMSJ != null)
              {
                   strFieldSQL += ",SMSJ";
                   strValueSQL += ",'" + model.SMSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSSJ") == true && model.CSSJ != null)
              {
                   strFieldSQL += ",CSSJ";
                   strValueSQL += ",'" + model.CSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL100") == true && model.GL100 != null)
              {
                   strFieldSQL += ",GL100";
                   strValueSQL += ",'" + model.GL100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL90") == true && model.GL90 != null)
              {
                   strFieldSQL += ",GL90";
                   strValueSQL += ",'" + model.GL90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL80") == true && model.GL80 != null)
              {
                   strFieldSQL += ",GL80";
                   strValueSQL += ",'" + model.GL80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS100") == true && model.ZS100 != null)
              {
                   strFieldSQL += ",ZS100";
                   strValueSQL += ",'" + model.ZS100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS90") == true && model.ZS90 != null)
              {
                   strFieldSQL += ",ZS90";
                   strValueSQL += ",'" + model.ZS90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS80") == true && model.ZS80 != null)
              {
                   strFieldSQL += ",ZS80";
                   strValueSQL += ",'" + model.ZS80.ToString().Replace("'","''") + "'";
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

              if(model.Changed("NO100") == true && model.NO100 != null)
              {
                   strFieldSQL += ",NO100";
                   strValueSQL += ",'" + model.NO100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO90") == true && model.NO90 != null)
              {
                   strFieldSQL += ",NO90";
                   strValueSQL += ",'" + model.NO90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO80") == true && model.NO80 != null)
              {
                   strFieldSQL += ",NO80";
                   strValueSQL += ",'" + model.NO80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOXZ") == true && model.NOXZ != null)
              {
                   strFieldSQL += ",NOXZ";
                   strValueSQL += ",'" + model.NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO_PD") == true && model.NO_PD != null)
              {
                   strFieldSQL += ",NO_PD";
                   strValueSQL += ",'" + model.NO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSUXZ") == true && model.HSUXZ != null)
              {
                   strFieldSQL += ",HSUXZ";
                   strValueSQL += ",'" + model.HSUXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU_PD") == true && model.HSU_PD != null)
              {
                   strFieldSQL += ",HSU_PD";
                   strValueSQL += ",'" + model.HSU_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KH80") == true && model.KH80 != null)
              {
                   strFieldSQL += ",KH80";
                   strValueSQL += ",'" + model.KH80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("MaxPower") == true && model.MaxPower != null)
              {
                   strFieldSQL += ",MaxPower";
                   strValueSQL += ",'" + model.MaxPower.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                   strFieldSQL += ",StopReason";
                   strValueSQL += ",'" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GXSXS100") == true && model.PT_GXSXS100 != null)
              {
                   strFieldSQL += ",PT_GXSXS100";
                   strValueSQL += ",'" + model.PT_GXSXS100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GXSXS80") == true && model.PT_GXSXS80 != null)
              {
                   strFieldSQL += ",PT_GXSXS80";
                   strValueSQL += ",'" + model.PT_GXSXS80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO80") == true && model.PT_NO80 != null)
              {
                   strFieldSQL += ",PT_NO80";
                   strValueSQL += ",'" + model.PT_NO80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GLJG") == true && model.PT_GLJG != null)
              {
                   strFieldSQL += ",PT_GLJG";
                   strValueSQL += ",'" + model.PT_GLJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_LD_PD") == true && model.PT_LD_PD != null)
              {
                   strFieldSQL += ",PT_LD_PD";
                   strValueSQL += ",'" + model.PT_LD_PD.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_LD";
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
          public bool Insert(RESULT_LD model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_LD model,string strJCLSH)
          {
              string strUpdateSQL = "";

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDJCCS") == true && model.LDJCCS != null)
              {
                  strUpdateSQL += ",LDJCCS='" + model.LDJCCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLJG") == true && model.GLJG != null)
              {
                  strUpdateSQL += ",GLJG='" + model.GLJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLXZ") == true && model.GLXZ != null)
              {
                  strUpdateSQL += ",GLXZ='" + model.GLXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL_PD") == true && model.GL_PD != null)
              {
                  strUpdateSQL += ",GL_PD='" + model.GL_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZSJG") == true && model.ZSJG != null)
              {
                  strUpdateSQL += ",ZSJG='" + model.ZSJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZSXZ") == true && model.ZSXZ != null)
              {
                  strUpdateSQL += ",ZSXZ='" + model.ZSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS_PD") == true && model.ZS_PD != null)
              {
                  strUpdateSQL += ",ZS_PD='" + model.ZS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS100") == true && model.GXSXS100 != null)
              {
                  strUpdateSQL += ",GXSXS100='" + model.GXSXS100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS90") == true && model.GXSXS90 != null)
              {
                  strUpdateSQL += ",GXSXS90='" + model.GXSXS90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS80") == true && model.GXSXS80 != null)
              {
                  strUpdateSQL += ",GXSXS80='" + model.GXSXS80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXSXZ") == true && model.GXSXSXZ != null)
              {
                  strUpdateSQL += ",GXSXSXZ='" + model.GXSXSXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXSXS_PD") == true && model.GXSXS_PD != null)
              {
                  strUpdateSQL += ",GXSXS_PD='" + model.GXSXS_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDWD") == true && model.LDWD != null)
              {
                  strUpdateSQL += ",LDWD='" + model.LDWD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDDQY") == true && model.LDDQY != null)
              {
                  strUpdateSQL += ",LDDQY='" + model.LDDQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDSD") == true && model.LDSD != null)
              {
                  strUpdateSQL += ",LDSD='" + model.LDSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LD_PD") == true && model.LD_PD != null)
              {
                  strUpdateSQL += ",LD_PD='" + model.LD_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LDYW") == true && model.LDYW != null)
              {
                  strUpdateSQL += ",LDYW='" + model.LDYW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU100") == true && model.HSU100 != null)
              {
                  strUpdateSQL += ",HSU100='" + model.HSU100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU90") == true && model.HSU90 != null)
              {
                  strUpdateSQL += ",HSU90='" + model.HSU90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU80") == true && model.HSU80 != null)
              {
                  strUpdateSQL += ",HSU80='" + model.HSU80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSZS") == true && model.DSZS != null)
              {
                  strUpdateSQL += ",DSZS='" + model.DSZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSZDGLXDSD") == true && model.JSZDGLXDSD != null)
              {
                  strUpdateSQL += ",JSZDGLXDSD='" + model.JSZDGLXDSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SCZDGLXDSD") == true && model.SCZDGLXDSD != null)
              {
                  strUpdateSQL += ",SCZDGLXDSD='" + model.SCZDGLXDSD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SMSJ") == true && model.SMSJ != null)
              {
                  strUpdateSQL += ",SMSJ='" + model.SMSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSSJ") == true && model.CSSJ != null)
              {
                  strUpdateSQL += ",CSSJ='" + model.CSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL100") == true && model.GL100 != null)
              {
                  strUpdateSQL += ",GL100='" + model.GL100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL90") == true && model.GL90 != null)
              {
                  strUpdateSQL += ",GL90='" + model.GL90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GL80") == true && model.GL80 != null)
              {
                  strUpdateSQL += ",GL80='" + model.GL80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS100") == true && model.ZS100 != null)
              {
                  strUpdateSQL += ",ZS100='" + model.ZS100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS90") == true && model.ZS90 != null)
              {
                  strUpdateSQL += ",ZS90='" + model.ZS90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZS80") == true && model.ZS80 != null)
              {
                  strUpdateSQL += ",ZS80='" + model.ZS80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KSSJ") == true && model.KSSJ != null)
              {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JSSJ") == true && model.JSSJ != null)
              {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO100") == true && model.NO100 != null)
              {
                  strUpdateSQL += ",NO100='" + model.NO100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO90") == true && model.NO90 != null)
              {
                  strUpdateSQL += ",NO90='" + model.NO90.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO80") == true && model.NO80 != null)
              {
                  strUpdateSQL += ",NO80='" + model.NO80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NOXZ") == true && model.NOXZ != null)
              {
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("NO_PD") == true && model.NO_PD != null)
              {
                  strUpdateSQL += ",NO_PD='" + model.NO_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSUXZ") == true && model.HSUXZ != null)
              {
                  strUpdateSQL += ",HSUXZ='" + model.HSUXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HSU_PD") == true && model.HSU_PD != null)
              {
                  strUpdateSQL += ",HSU_PD='" + model.HSU_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KH80") == true && model.KH80 != null)
              {
                  strUpdateSQL += ",KH80='" + model.KH80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("MaxPower") == true && model.MaxPower != null)
              {
                  strUpdateSQL += ",MaxPower='" + model.MaxPower.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("StopReason") == true && model.StopReason != null)
              {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GXSXS100") == true && model.PT_GXSXS100 != null)
              {
                  strUpdateSQL += ",PT_GXSXS100='" + model.PT_GXSXS100.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GXSXS80") == true && model.PT_GXSXS80 != null)
              {
                  strUpdateSQL += ",PT_GXSXS80='" + model.PT_GXSXS80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_NO80") == true && model.PT_NO80 != null)
              {
                  strUpdateSQL += ",PT_NO80='" + model.PT_NO80.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_GLJG") == true && model.PT_GLJG != null)
              {
                  strUpdateSQL += ",PT_GLJG='" + model.PT_GLJG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PT_LD_PD") == true && model.PT_LD_PD != null)
              {
                  strUpdateSQL += ",PT_LD_PD='" + model.PT_LD_PD.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_LD set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_LD model, string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strJCLSH));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_LD model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LDJCCS") == true && model.LDJCCS != null)
               {
                  strUpdateSQL += ",LDJCCS='" + model.LDJCCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLJG") == true && model.GLJG != null)
               {
                  strUpdateSQL += ",GLJG='" + model.GLJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLXZ") == true && model.GLXZ != null)
               {
                  strUpdateSQL += ",GLXZ='" + model.GLXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GL_PD") == true && model.GL_PD != null)
               {
                  strUpdateSQL += ",GL_PD='" + model.GL_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZSJG") == true && model.ZSJG != null)
               {
                  strUpdateSQL += ",ZSJG='" + model.ZSJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZSXZ") == true && model.ZSXZ != null)
               {
                  strUpdateSQL += ",ZSXZ='" + model.ZSXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZS_PD") == true && model.ZS_PD != null)
               {
                  strUpdateSQL += ",ZS_PD='" + model.ZS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GXSXS100") == true && model.GXSXS100 != null)
               {
                  strUpdateSQL += ",GXSXS100='" + model.GXSXS100.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GXSXS90") == true && model.GXSXS90 != null)
               {
                  strUpdateSQL += ",GXSXS90='" + model.GXSXS90.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GXSXS80") == true && model.GXSXS80 != null)
               {
                  strUpdateSQL += ",GXSXS80='" + model.GXSXS80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GXSXSXZ") == true && model.GXSXSXZ != null)
               {
                  strUpdateSQL += ",GXSXSXZ='" + model.GXSXSXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GXSXS_PD") == true && model.GXSXS_PD != null)
               {
                  strUpdateSQL += ",GXSXS_PD='" + model.GXSXS_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LDWD") == true && model.LDWD != null)
               {
                  strUpdateSQL += ",LDWD='" + model.LDWD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LDDQY") == true && model.LDDQY != null)
               {
                  strUpdateSQL += ",LDDQY='" + model.LDDQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LDSD") == true && model.LDSD != null)
               {
                  strUpdateSQL += ",LDSD='" + model.LDSD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LD_PD") == true && model.LD_PD != null)
               {
                  strUpdateSQL += ",LD_PD='" + model.LD_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LDYW") == true && model.LDYW != null)
               {
                  strUpdateSQL += ",LDYW='" + model.LDYW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HSU100") == true && model.HSU100 != null)
               {
                  strUpdateSQL += ",HSU100='" + model.HSU100.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HSU90") == true && model.HSU90 != null)
               {
                  strUpdateSQL += ",HSU90='" + model.HSU90.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HSU80") == true && model.HSU80 != null)
               {
                  strUpdateSQL += ",HSU80='" + model.HSU80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSZS") == true && model.DSZS != null)
               {
                  strUpdateSQL += ",DSZS='" + model.DSZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JSZDGLXDSD") == true && model.JSZDGLXDSD != null)
               {
                  strUpdateSQL += ",JSZDGLXDSD='" + model.JSZDGLXDSD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SCZDGLXDSD") == true && model.SCZDGLXDSD != null)
               {
                  strUpdateSQL += ",SCZDGLXDSD='" + model.SCZDGLXDSD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SMSJ") == true && model.SMSJ != null)
               {
                  strUpdateSQL += ",SMSJ='" + model.SMSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CSSJ") == true && model.CSSJ != null)
               {
                  strUpdateSQL += ",CSSJ='" + model.CSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GL100") == true && model.GL100 != null)
               {
                  strUpdateSQL += ",GL100='" + model.GL100.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GL90") == true && model.GL90 != null)
               {
                  strUpdateSQL += ",GL90='" + model.GL90.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GL80") == true && model.GL80 != null)
               {
                  strUpdateSQL += ",GL80='" + model.GL80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZS100") == true && model.ZS100 != null)
               {
                  strUpdateSQL += ",ZS100='" + model.ZS100.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZS90") == true && model.ZS90 != null)
               {
                  strUpdateSQL += ",ZS90='" + model.ZS90.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZS80") == true && model.ZS80 != null)
               {
                  strUpdateSQL += ",ZS80='" + model.ZS80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KSSJ") == true && model.KSSJ != null)
               {
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JSSJ") == true && model.JSSJ != null)
               {
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO100") == true && model.NO100 != null)
               {
                  strUpdateSQL += ",NO100='" + model.NO100.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO90") == true && model.NO90 != null)
               {
                  strUpdateSQL += ",NO90='" + model.NO90.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO80") == true && model.NO80 != null)
               {
                  strUpdateSQL += ",NO80='" + model.NO80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NOXZ") == true && model.NOXZ != null)
               {
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("NO_PD") == true && model.NO_PD != null)
               {
                  strUpdateSQL += ",NO_PD='" + model.NO_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HSUXZ") == true && model.HSUXZ != null)
               {
                  strUpdateSQL += ",HSUXZ='" + model.HSUXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HSU_PD") == true && model.HSU_PD != null)
               {
                  strUpdateSQL += ",HSU_PD='" + model.HSU_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KH80") == true && model.KH80 != null)
               {
                  strUpdateSQL += ",KH80='" + model.KH80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("MaxPower") == true && model.MaxPower != null)
               {
                  strUpdateSQL += ",MaxPower='" + model.MaxPower.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("StopReason") == true && model.StopReason != null)
               {
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_GXSXS100") == true && model.PT_GXSXS100 != null)
               {
                  strUpdateSQL += ",PT_GXSXS100='" + model.PT_GXSXS100.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_GXSXS80") == true && model.PT_GXSXS80 != null)
               {
                  strUpdateSQL += ",PT_GXSXS80='" + model.PT_GXSXS80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_NO80") == true && model.PT_NO80 != null)
               {
                  strUpdateSQL += ",PT_NO80='" + model.PT_NO80.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_GLJG") == true && model.PT_GLJG != null)
               {
                  strUpdateSQL += ",PT_GLJG='" + model.PT_GLJG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PT_LD_PD") == true && model.PT_LD_PD != null)
               {
                  strUpdateSQL += ",PT_LD_PD='" + model.PT_LD_PD.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_LD set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_LD model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_LD model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LDJCCS='" + model.LDJCCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLJG='" + model.GLJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLXZ='" + model.GLXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GL_PD='" + model.GL_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZSJG='" + model.ZSJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZSXZ='" + model.ZSXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZS_PD='" + model.ZS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GXSXS100='" + model.GXSXS100.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GXSXS90='" + model.GXSXS90.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GXSXS80='" + model.GXSXS80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GXSXSXZ='" + model.GXSXSXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GXSXS_PD='" + model.GXSXS_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LDWD='" + model.LDWD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LDDQY='" + model.LDDQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LDSD='" + model.LDSD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LD_PD='" + model.LD_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LDYW='" + model.LDYW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HSU100='" + model.HSU100.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HSU90='" + model.HSU90.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HSU80='" + model.HSU80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSZS='" + model.DSZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JSZDGLXDSD='" + model.JSZDGLXDSD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SCZDGLXDSD='" + model.SCZDGLXDSD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SMSJ='" + model.SMSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CSSJ='" + model.CSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GL100='" + model.GL100.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GL90='" + model.GL90.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GL80='" + model.GL80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZS100='" + model.ZS100.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZS90='" + model.ZS90.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZS80='" + model.ZS80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KSSJ='" + model.KSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JSSJ='" + model.JSSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO100='" + model.NO100.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO90='" + model.NO90.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO80='" + model.NO80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NOXZ='" + model.NOXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",NO_PD='" + model.NO_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HSUXZ='" + model.HSUXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HSU_PD='" + model.HSU_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KH80='" + model.KH80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",MaxPower='" + model.MaxPower.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",StopReason='" + model.StopReason.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_GXSXS100='" + model.PT_GXSXS100.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_GXSXS80='" + model.PT_GXSXS80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_NO80='" + model.PT_NO80.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_GLJG='" + model.PT_GLJG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PT_LD_PD='" + model.PT_LD_PD.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_LD set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_LD model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strJCLSH)
          {
              string strSql = "";
              strSql += "delete from RESULT_LD";
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
              strSql += "delete from RESULT_LD";
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
              strSql += "delete from RESULT_LD";

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
         public RESULT_LD GetModel(string strJCLSH)
         {
             string strSql = "";
             strSql += "select * from RESULT_LD";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_LD model = new RESULT_LD();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_LD();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.LDJCCS = dtTemp.Rows[0]["LDJCCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["LDJCCS"].ToString();
                 model.GLJG = dtTemp.Rows[0]["GLJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLJG"].ToString();
                 model.GLXZ = dtTemp.Rows[0]["GLXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLXZ"].ToString();
                 model.GL_PD = dtTemp.Rows[0]["GL_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GL_PD"].ToString();
                 model.ZSJG = dtTemp.Rows[0]["ZSJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZSJG"].ToString();
                 model.ZSXZ = dtTemp.Rows[0]["ZSXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZSXZ"].ToString();
                 model.ZS_PD = dtTemp.Rows[0]["ZS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZS_PD"].ToString();
                 model.GXSXS100 = dtTemp.Rows[0]["GXSXS100"] == DBNull.Value ? "" : dtTemp.Rows[0]["GXSXS100"].ToString();
                 model.GXSXS90 = dtTemp.Rows[0]["GXSXS90"] == DBNull.Value ? "" : dtTemp.Rows[0]["GXSXS90"].ToString();
                 model.GXSXS80 = dtTemp.Rows[0]["GXSXS80"] == DBNull.Value ? "" : dtTemp.Rows[0]["GXSXS80"].ToString();
                 model.GXSXSXZ = dtTemp.Rows[0]["GXSXSXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GXSXSXZ"].ToString();
                 model.GXSXS_PD = dtTemp.Rows[0]["GXSXS_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GXSXS_PD"].ToString();
                 model.LDWD = dtTemp.Rows[0]["LDWD"] == DBNull.Value ? "" : dtTemp.Rows[0]["LDWD"].ToString();
                 model.LDDQY = dtTemp.Rows[0]["LDDQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["LDDQY"].ToString();
                 model.LDSD = dtTemp.Rows[0]["LDSD"] == DBNull.Value ? "" : dtTemp.Rows[0]["LDSD"].ToString();
                 model.LD_PD = dtTemp.Rows[0]["LD_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["LD_PD"].ToString();
                 model.LDYW = dtTemp.Rows[0]["LDYW"] == DBNull.Value ? "" : dtTemp.Rows[0]["LDYW"].ToString();
                 model.HSU100 = dtTemp.Rows[0]["HSU100"] == DBNull.Value ? "" : dtTemp.Rows[0]["HSU100"].ToString();
                 model.HSU90 = dtTemp.Rows[0]["HSU90"] == DBNull.Value ? "" : dtTemp.Rows[0]["HSU90"].ToString();
                 model.HSU80 = dtTemp.Rows[0]["HSU80"] == DBNull.Value ? "" : dtTemp.Rows[0]["HSU80"].ToString();
                 model.DSZS = dtTemp.Rows[0]["DSZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSZS"].ToString();
                 model.JSZDGLXDSD = dtTemp.Rows[0]["JSZDGLXDSD"] == DBNull.Value ? "" : dtTemp.Rows[0]["JSZDGLXDSD"].ToString();
                 model.SCZDGLXDSD = dtTemp.Rows[0]["SCZDGLXDSD"] == DBNull.Value ? "" : dtTemp.Rows[0]["SCZDGLXDSD"].ToString();
                 model.SMSJ = dtTemp.Rows[0]["SMSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SMSJ"].ToString();
                 model.CSSJ = dtTemp.Rows[0]["CSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CSSJ"].ToString();
                 model.GL100 = dtTemp.Rows[0]["GL100"] == DBNull.Value ? "" : dtTemp.Rows[0]["GL100"].ToString();
                 model.GL90 = dtTemp.Rows[0]["GL90"] == DBNull.Value ? "" : dtTemp.Rows[0]["GL90"].ToString();
                 model.GL80 = dtTemp.Rows[0]["GL80"] == DBNull.Value ? "" : dtTemp.Rows[0]["GL80"].ToString();
                 model.ZS100 = dtTemp.Rows[0]["ZS100"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZS100"].ToString();
                 model.ZS90 = dtTemp.Rows[0]["ZS90"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZS90"].ToString();
                 model.ZS80 = dtTemp.Rows[0]["ZS80"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZS80"].ToString();
                 model.KSSJ = dtTemp.Rows[0]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["KSSJ"].ToString();
                 model.JSSJ = dtTemp.Rows[0]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JSSJ"].ToString();
                 model.NO100 = dtTemp.Rows[0]["NO100"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO100"].ToString();
                 model.NO90 = dtTemp.Rows[0]["NO90"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO90"].ToString();
                 model.NO80 = dtTemp.Rows[0]["NO80"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO80"].ToString();
                 model.NOXZ = dtTemp.Rows[0]["NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["NOXZ"].ToString();
                 model.NO_PD = dtTemp.Rows[0]["NO_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["NO_PD"].ToString();
                 model.HSUXZ = dtTemp.Rows[0]["HSUXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["HSUXZ"].ToString();
                 model.HSU_PD = dtTemp.Rows[0]["HSU_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["HSU_PD"].ToString();
                 model.KH80 = dtTemp.Rows[0]["KH80"] == DBNull.Value ? "" : dtTemp.Rows[0]["KH80"].ToString();
                 model.MaxPower = dtTemp.Rows[0]["MaxPower"] == DBNull.Value ? "" : dtTemp.Rows[0]["MaxPower"].ToString();
                 model.StopReason = dtTemp.Rows[0]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[0]["StopReason"].ToString();
                 model.PT_GXSXS100 = dtTemp.Rows[0]["PT_GXSXS100"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_GXSXS100"].ToString();
                 model.PT_GXSXS80 = dtTemp.Rows[0]["PT_GXSXS80"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_GXSXS80"].ToString();
                 model.PT_NO80 = dtTemp.Rows[0]["PT_NO80"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_NO80"].ToString();
                 model.PT_GLJG = dtTemp.Rows[0]["PT_GLJG"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_GLJG"].ToString();
                 model.PT_LD_PD = dtTemp.Rows[0]["PT_LD_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["PT_LD_PD"].ToString();
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
             strSql += "select * from RESULT_LD";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_LD[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_LD";
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

          RESULT_LD[] arrModel=new RESULT_LD[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_LD();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].LDJCCS = dtTemp.Rows[N]["LDJCCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["LDJCCS"].ToString();
                 arrModel[N].GLJG = dtTemp.Rows[N]["GLJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLJG"].ToString();
                 arrModel[N].GLXZ = dtTemp.Rows[N]["GLXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLXZ"].ToString();
                 arrModel[N].GL_PD = dtTemp.Rows[N]["GL_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GL_PD"].ToString();
                 arrModel[N].ZSJG = dtTemp.Rows[N]["ZSJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZSJG"].ToString();
                 arrModel[N].ZSXZ = dtTemp.Rows[N]["ZSXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZSXZ"].ToString();
                 arrModel[N].ZS_PD = dtTemp.Rows[N]["ZS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZS_PD"].ToString();
                 arrModel[N].GXSXS100 = dtTemp.Rows[N]["GXSXS100"] == DBNull.Value ? "" : dtTemp.Rows[N]["GXSXS100"].ToString();
                 arrModel[N].GXSXS90 = dtTemp.Rows[N]["GXSXS90"] == DBNull.Value ? "" : dtTemp.Rows[N]["GXSXS90"].ToString();
                 arrModel[N].GXSXS80 = dtTemp.Rows[N]["GXSXS80"] == DBNull.Value ? "" : dtTemp.Rows[N]["GXSXS80"].ToString();
                 arrModel[N].GXSXSXZ = dtTemp.Rows[N]["GXSXSXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GXSXSXZ"].ToString();
                 arrModel[N].GXSXS_PD = dtTemp.Rows[N]["GXSXS_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GXSXS_PD"].ToString();
                 arrModel[N].LDWD = dtTemp.Rows[N]["LDWD"] == DBNull.Value ? "" : dtTemp.Rows[N]["LDWD"].ToString();
                 arrModel[N].LDDQY = dtTemp.Rows[N]["LDDQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["LDDQY"].ToString();
                 arrModel[N].LDSD = dtTemp.Rows[N]["LDSD"] == DBNull.Value ? "" : dtTemp.Rows[N]["LDSD"].ToString();
                 arrModel[N].LD_PD = dtTemp.Rows[N]["LD_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["LD_PD"].ToString();
                 arrModel[N].LDYW = dtTemp.Rows[N]["LDYW"] == DBNull.Value ? "" : dtTemp.Rows[N]["LDYW"].ToString();
                 arrModel[N].HSU100 = dtTemp.Rows[N]["HSU100"] == DBNull.Value ? "" : dtTemp.Rows[N]["HSU100"].ToString();
                 arrModel[N].HSU90 = dtTemp.Rows[N]["HSU90"] == DBNull.Value ? "" : dtTemp.Rows[N]["HSU90"].ToString();
                 arrModel[N].HSU80 = dtTemp.Rows[N]["HSU80"] == DBNull.Value ? "" : dtTemp.Rows[N]["HSU80"].ToString();
                 arrModel[N].DSZS = dtTemp.Rows[N]["DSZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSZS"].ToString();
                 arrModel[N].JSZDGLXDSD = dtTemp.Rows[N]["JSZDGLXDSD"] == DBNull.Value ? "" : dtTemp.Rows[N]["JSZDGLXDSD"].ToString();
                 arrModel[N].SCZDGLXDSD = dtTemp.Rows[N]["SCZDGLXDSD"] == DBNull.Value ? "" : dtTemp.Rows[N]["SCZDGLXDSD"].ToString();
                 arrModel[N].SMSJ = dtTemp.Rows[N]["SMSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SMSJ"].ToString();
                 arrModel[N].CSSJ = dtTemp.Rows[N]["CSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CSSJ"].ToString();
                 arrModel[N].GL100 = dtTemp.Rows[N]["GL100"] == DBNull.Value ? "" : dtTemp.Rows[N]["GL100"].ToString();
                 arrModel[N].GL90 = dtTemp.Rows[N]["GL90"] == DBNull.Value ? "" : dtTemp.Rows[N]["GL90"].ToString();
                 arrModel[N].GL80 = dtTemp.Rows[N]["GL80"] == DBNull.Value ? "" : dtTemp.Rows[N]["GL80"].ToString();
                 arrModel[N].ZS100 = dtTemp.Rows[N]["ZS100"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZS100"].ToString();
                 arrModel[N].ZS90 = dtTemp.Rows[N]["ZS90"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZS90"].ToString();
                 arrModel[N].ZS80 = dtTemp.Rows[N]["ZS80"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZS80"].ToString();
                 arrModel[N].KSSJ = dtTemp.Rows[N]["KSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["KSSJ"].ToString();
                 arrModel[N].JSSJ = dtTemp.Rows[N]["JSSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JSSJ"].ToString();
                 arrModel[N].NO100 = dtTemp.Rows[N]["NO100"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO100"].ToString();
                 arrModel[N].NO90 = dtTemp.Rows[N]["NO90"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO90"].ToString();
                 arrModel[N].NO80 = dtTemp.Rows[N]["NO80"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO80"].ToString();
                 arrModel[N].NOXZ = dtTemp.Rows[N]["NOXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["NOXZ"].ToString();
                 arrModel[N].NO_PD = dtTemp.Rows[N]["NO_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["NO_PD"].ToString();
                 arrModel[N].HSUXZ = dtTemp.Rows[N]["HSUXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["HSUXZ"].ToString();
                 arrModel[N].HSU_PD = dtTemp.Rows[N]["HSU_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["HSU_PD"].ToString();
                 arrModel[N].KH80 = dtTemp.Rows[N]["KH80"] == DBNull.Value ? "" : dtTemp.Rows[N]["KH80"].ToString();
                 arrModel[N].MaxPower = dtTemp.Rows[N]["MaxPower"] == DBNull.Value ? "" : dtTemp.Rows[N]["MaxPower"].ToString();
                 arrModel[N].StopReason = dtTemp.Rows[N]["StopReason"] == DBNull.Value ? "" : dtTemp.Rows[N]["StopReason"].ToString();
                 arrModel[N].PT_GXSXS100 = dtTemp.Rows[N]["PT_GXSXS100"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_GXSXS100"].ToString();
                 arrModel[N].PT_GXSXS80 = dtTemp.Rows[N]["PT_GXSXS80"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_GXSXS80"].ToString();
                 arrModel[N].PT_NO80 = dtTemp.Rows[N]["PT_NO80"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_NO80"].ToString();
                 arrModel[N].PT_GLJG = dtTemp.Rows[N]["PT_GLJG"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_GLJG"].ToString();
                 arrModel[N].PT_LD_PD = dtTemp.Rows[N]["PT_LD_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["PT_LD_PD"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_LD[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_LD[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_LD[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_LD[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_LD[] GetModelList()
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
          strSql += "select * from RESULT_LD";
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
