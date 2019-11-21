using System;
using System.Data;
using Model;
using DBUtility;
using Core;

namespace DAL
{
     /// <summary>
     /// 数据访问层RESULT_VEHICLE_INFO_DAL
     /// </summary>
     public class RESULT_VEHICLE_INFO_DAL
     {
         private string Conn{ get;set; }
         public RESULT_VEHICLE_INFO_DAL()
         {
              Conn = dbConfig.g_strConnectionStringSqlClient1;
         }


         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             string strResult = "0";
             string strSql = "select max(JCLSH) as m from RESULT_VEHICLE_INFO";

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
               strSql += "select count(1) as c from RESULT_VEHICLE_INFO";
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
              strSql += "select count(1) as c from RESULT_VEHICLE_INFO";
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
          public string InsertSQL(RESULT_VEHICLE_INFO model)
          {
              string strFieldSQL = "";
              string strValueSQL = "";

              if(model.Changed("JCXH") == true && model.JCXH != null)
              {
                   strFieldSQL += ",JCXH";
                   strValueSQL += "," + model.JCXH + "";
              }

              if(model.Changed("JCXHMS") == true && model.JCXHMS != null)
              {
                   strFieldSQL += ",JCXHMS";
                   strValueSQL += ",'" + model.JCXHMS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCCS") == true && model.JCCS != null)
              {
                   strFieldSQL += ",JCCS";
                   strValueSQL += "," + model.JCCS + "";
              }

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                   strFieldSQL += ",JCLSH";
                   strValueSQL += ",'" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYXM") == true && model.JYXM != null)
              {
                   strFieldSQL += ",JYXM";
                   strValueSQL += ",'" + model.JYXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YJXM") == true && model.YJXM != null)
              {
                   strFieldSQL += ",YJXM";
                   strValueSQL += ",'" + model.YJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FJXM") == true && model.FJXM != null)
              {
                   strFieldSQL += ",FJXM";
                   strValueSQL += ",'" + model.FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Z_PD") == true && model.Z_PD != null)
              {
                   strFieldSQL += ",Z_PD";
                   strValueSQL += ",'" + model.Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsUpload") == true && model.IsUpload != null)
              {
                   strFieldSQL += ",IsUpload";
                   strValueSQL += "," + model.IsUpload + "";
              }

              if(model.Changed("IsAudit") == true && model.IsAudit != null)
              {
                   strFieldSQL += ",IsAudit";
                   strValueSQL += "," + model.IsAudit + "";
              }

              if(model.Changed("IsPrint") == true && model.IsPrint != null)
              {
                   strFieldSQL += ",IsPrint";
                   strValueSQL += "," + model.IsPrint + "";
              }

              if(model.Changed("WQLSH") == true && model.WQLSH != null)
              {
                   strFieldSQL += ",WQLSH";
                   strValueSQL += ",'" + model.WQLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJLSH") == true && model.AJLSH != null)
              {
                   strFieldSQL += ",AJLSH";
                   strValueSQL += ",'" + model.AJLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJLSH") == true && model.ZJLSH != null)
              {
                   strFieldSQL += ",ZJLSH";
                   strValueSQL += ",'" + model.ZJLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("MTLSH") == true && model.MTLSH != null)
              {
                   strFieldSQL += ",MTLSH";
                   strValueSQL += ",'" + model.MTLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBGDBH01") == true && model.JCBGDBH01 != null)
              {
                   strFieldSQL += ",JCBGDBH01";
                   strValueSQL += ",'" + model.JCBGDBH01.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBGDBH02") == true && model.JCBGDBH02 != null)
              {
                   strFieldSQL += ",JCBGDBH02";
                   strValueSQL += ",'" + model.JCBGDBH02.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPHM") == true && model.HPHM != null)
              {
                   strFieldSQL += ",HPHM";
                   strValueSQL += ",'" + model.HPHM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPZL") == true && model.HPZL != null)
              {
                   strFieldSQL += ",HPZL";
                   strValueSQL += ",'" + model.HPZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPZLDH") == true && model.HPZLDH != null)
              {
                   strFieldSQL += ",HPZLDH";
                   strValueSQL += ",'" + model.HPZLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCHPHM") == true && model.GLCHPHM != null)
              {
                   strFieldSQL += ",GLCHPHM";
                   strValueSQL += ",'" + model.GLCHPHM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VIN") == true && model.VIN != null)
              {
                   strFieldSQL += ",VIN";
                   strValueSQL += ",'" + model.VIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYLB") == true && model.JYLB != null)
              {
                   strFieldSQL += ",JYLB";
                   strValueSQL += ",'" + model.JYLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYLBDH") == true && model.JYLBDH != null)
              {
                   strFieldSQL += ",JYLBDH";
                   strValueSQL += ",'" + model.JYLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJH") == true && model.FDJH != null)
              {
                   strFieldSQL += ",FDJH";
                   strValueSQL += ",'" + model.FDJH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJXH") == true && model.FDJXH != null)
              {
                   strFieldSQL += ",FDJXH";
                   strValueSQL += ",'" + model.FDJXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJZZCS") == true && model.FDJZZCS != null)
              {
                   strFieldSQL += ",FDJZZCS";
                   strValueSQL += ",'" + model.FDJZZCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DPXH") == true && model.DPXH != null)
              {
                   strFieldSQL += ",DPXH";
                   strValueSQL += ",'" + model.DPXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PP") == true && model.PP != null)
              {
                   strFieldSQL += ",PP";
                   strValueSQL += ",'" + model.PP.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLZZCS") == true && model.CLZZCS != null)
              {
                   strFieldSQL += ",CLZZCS";
                   strValueSQL += ",'" + model.CLZZCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("XH") == true && model.XH != null)
              {
                   strFieldSQL += ",XH";
                   strValueSQL += ",'" + model.XH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PPXH") == true && model.PPXH != null)
              {
                   strFieldSQL += ",PPXH";
                   strValueSQL += ",'" + model.PPXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDXS") == true && model.QDXS != null)
              {
                   strFieldSQL += ",QDXS";
                   strValueSQL += ",'" + model.QDXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDXSDH") == true && model.QDXSDH != null)
              {
                   strFieldSQL += ",QDXSDH";
                   strValueSQL += ",'" + model.QDXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZWZ") == true && model.QDZWZ != null)
              {
                   strFieldSQL += ",QDZWZ";
                   strValueSQL += ",'" + model.QDZWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZCZWZ") == true && model.ZCZWZ != null)
              {
                   strFieldSQL += ",ZCZWZ";
                   strValueSQL += ",'" + model.ZCZWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QZDZ") == true && model.QZDZ != null)
              {
                   strFieldSQL += ",QZDZ";
                   strValueSQL += ",'" + model.QZDZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QZDZDH") == true && model.QZDZDH != null)
              {
                   strFieldSQL += ",QZDZDH";
                   strValueSQL += ",'" + model.QZDZDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YGGSNFKT") == true && model.YGGSNFKT != null)
              {
                   strFieldSQL += ",YGGSNFKT";
                   strValueSQL += ",'" + model.YGGSNFKT.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YGGSNFKTDH") == true && model.YGGSNFKTDH != null)
              {
                   strFieldSQL += ",YGGSNFKTDH";
                   strValueSQL += ",'" + model.YGGSNFKTDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RLLB") == true && model.RLLB != null)
              {
                   strFieldSQL += ",RLLB";
                   strValueSQL += ",'" + model.RLLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RLLBDH") == true && model.RLLBDH != null)
              {
                   strFieldSQL += ",RLLBDH";
                   strValueSQL += ",'" + model.RLLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RYBH") == true && model.RYBH != null)
              {
                   strFieldSQL += ",RYBH";
                   strValueSQL += ",'" + model.RYBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GYFS") == true && model.GYFS != null)
              {
                   strFieldSQL += ",GYFS";
                   strValueSQL += ",'" + model.GYFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GYFSDH") == true && model.GYFSDH != null)
              {
                   strFieldSQL += ",GYFSDH";
                   strValueSQL += ",'" + model.GYFSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CCDJRQ") == true && model.CCDJRQ != null)
              {
                   strFieldSQL += ",CCDJRQ";
                   strValueSQL += ",'" + model.CCDJRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CCRQ") == true && model.CCRQ != null)
              {
                   strFieldSQL += ",CCRQ";
                   strValueSQL += ",'" + model.CCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZBZL") == true && model.ZBZL != null)
              {
                   strFieldSQL += ",ZBZL";
                   strValueSQL += ",'" + model.ZBZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZZL") == true && model.ZZL != null)
              {
                   strFieldSQL += ",ZZL";
                   strValueSQL += ",'" + model.ZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CYS") == true && model.CYS != null)
              {
                   strFieldSQL += ",CYS";
                   strValueSQL += ",'" + model.CYS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSYS") == true && model.CSYS != null)
              {
                   strFieldSQL += ",CSYS";
                   strValueSQL += ",'" + model.CSYS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZDFS") == true && model.ZDFS != null)
              {
                   strFieldSQL += ",ZDFS";
                   strValueSQL += ",'" + model.ZDFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZDFSDH") == true && model.ZDFSDH != null)
              {
                   strFieldSQL += ",ZDFSDH";
                   strValueSQL += ",'" + model.ZDFSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLZL") == true && model.CLZL != null)
              {
                   strFieldSQL += ",CLZL";
                   strValueSQL += ",'" + model.CLZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLZLDH") == true && model.CLZLDH != null)
              {
                   strFieldSQL += ",CLZLDH";
                   strValueSQL += ",'" + model.CLZLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZXJXS") == true && model.ZXZXJXS != null)
              {
                   strFieldSQL += ",ZXZXJXS";
                   strValueSQL += ",'" + model.ZXZXJXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZXJXSDH") == true && model.ZXZXJXSDH != null)
              {
                   strFieldSQL += ",ZXZXJXSDH";
                   strValueSQL += ",'" + model.ZXZXJXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZLX") == true && model.ZXZLX != null)
              {
                   strFieldSQL += ",ZXZLX";
                   strValueSQL += ",'" + model.ZXZLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZLXDH") == true && model.ZXZLXDH != null)
              {
                   strFieldSQL += ",ZXZLXDH";
                   strValueSQL += ",'" + model.ZXZLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZGSJCS") == true && model.ZGSJCS != null)
              {
                   strFieldSQL += ",ZGSJCS";
                   strValueSQL += ",'" + model.ZGSJCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDGL") == true && model.EDGL != null)
              {
                   strFieldSQL += ",EDGL";
                   strValueSQL += ",'" + model.EDGL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDZS") == true && model.EDZS != null)
              {
                   strFieldSQL += ",EDZS";
                   strValueSQL += ",'" + model.EDZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDNJZS") == true && model.EDNJZS != null)
              {
                   strFieldSQL += ",EDNJZS";
                   strValueSQL += ",'" + model.EDNJZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDNJ") == true && model.EDNJ != null)
              {
                   strFieldSQL += ",EDNJ";
                   strValueSQL += ",'" + model.EDNJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDYH") == true && model.EDYH != null)
              {
                   strFieldSQL += ",EDYH";
                   strValueSQL += ",'" + model.EDYH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JQFS") == true && model.JQFS != null)
              {
                   strFieldSQL += ",JQFS";
                   strValueSQL += ",'" + model.JQFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JQFSDH") == true && model.JQFSDH != null)
              {
                   strFieldSQL += ",JQFSDH";
                   strValueSQL += ",'" + model.JQFSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJPL") == true && model.FDJPL != null)
              {
                   strFieldSQL += ",FDJPL";
                   strValueSQL += ",'" + model.FDJPL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJGS") == true && model.FDJGS != null)
              {
                   strFieldSQL += ",FDJGS";
                   strValueSQL += ",'" + model.FDJGS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJCC") == true && model.FDJCC != null)
              {
                   strFieldSQL += ",FDJCC";
                   strValueSQL += ",'" + model.FDJCC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BSXLX") == true && model.BSXLX != null)
              {
                   strFieldSQL += ",BSXLX";
                   strValueSQL += ",'" + model.BSXLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BSXLXDH") == true && model.BSXLXDH != null)
              {
                   strFieldSQL += ",BSXLXDH";
                   strValueSQL += ",'" + model.BSXLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CXXL") == true && model.CXXL != null)
              {
                   strFieldSQL += ",CXXL";
                   strValueSQL += ",'" + model.CXXL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CXXLDH") == true && model.CXXLDH != null)
              {
                   strFieldSQL += ",CXXLDH";
                   strValueSQL += ",'" + model.CXXLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LJXSLC") == true && model.LJXSLC != null)
              {
                   strFieldSQL += ",LJXSLC";
                   strValueSQL += ",'" + model.LJXSLC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTQY") == true && model.LTQY != null)
              {
                   strFieldSQL += ",LTQY";
                   strValueSQL += ",'" + model.LTQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTGG") == true && model.LTGG != null)
              {
                   strFieldSQL += ",LTGG";
                   strValueSQL += ",'" + model.LTGG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTSL") == true && model.LTSL != null)
              {
                   strFieldSQL += ",LTSL";
                   strValueSQL += ",'" + model.LTSL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYXZ") == true && model.SYXZ != null)
              {
                   strFieldSQL += ",SYXZ";
                   strValueSQL += ",'" + model.SYXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYXZDH") == true && model.SYXZDH != null)
              {
                   strFieldSQL += ",SYXZDH";
                   strValueSQL += ",'" + model.SYXZDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YYZH") == true && model.YYZH != null)
              {
                   strFieldSQL += ",YYZH";
                   strValueSQL += ",'" + model.YYZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SJDW") == true && model.SJDW != null)
              {
                   strFieldSQL += ",SJDW";
                   strValueSQL += ",'" + model.SJDW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYR") == true && model.SYR != null)
              {
                   strFieldSQL += ",SYR";
                   strValueSQL += ",'" + model.SYR.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LXDH") == true && model.LXDH != null)
              {
                   strFieldSQL += ",LXDH";
                   strValueSQL += ",'" + model.LXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LXDZ") == true && model.LXDZ != null)
              {
                   strFieldSQL += ",LXDZ";
                   strValueSQL += ",'" + model.LXDZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZBH") == true && model.YZBH != null)
              {
                   strFieldSQL += ",YZBH";
                   strValueSQL += ",'" + model.YZBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCRQ") == true && model.JCRQ != null)
              {
                   strFieldSQL += ",JCRQ";
                   strValueSQL += ",'" + model.JCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DLRQ") == true && model.DLRQ != null)
              {
                   strFieldSQL += ",DLRQ";
                   strValueSQL += ",'" + model.DLRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLSXSJ") == true && model.CLSXSJ != null)
              {
                   strFieldSQL += ",CLSXSJ";
                   strValueSQL += ",'" + model.CLSXSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLXXSJ") == true && model.CLXXSJ != null)
              {
                   strFieldSQL += ",CLXXSJ";
                   strValueSQL += ",'" + model.CLXXSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DLY") == true && model.DLY != null)
              {
                   strFieldSQL += ",DLY";
                   strValueSQL += ",'" + model.DLY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YCY") == true && model.YCY != null)
              {
                   strFieldSQL += ",YCY";
                   strValueSQL += ",'" + model.YCY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WGJYY") == true && model.WGJYY != null)
              {
                   strFieldSQL += ",WGJYY";
                   strValueSQL += ",'" + model.WGJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DPJYY") == true && model.DPJYY != null)
              {
                   strFieldSQL += ",DPJYY";
                   strValueSQL += ",'" + model.DPJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DTDPJYY") == true && model.DTDPJYY != null)
              {
                   strFieldSQL += ",DTDPJYY";
                   strValueSQL += ",'" + model.DTDPJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LSJYY") == true && model.LSJYY != null)
              {
                   strFieldSQL += ",LSJYY";
                   strValueSQL += ",'" + model.LSJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SQQZR") == true && model.SQQZR != null)
              {
                   strFieldSQL += ",SQQZR";
                   strValueSQL += ",'" + model.SQQZR.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQCZY") == true && model.WQCZY != null)
              {
                   strFieldSQL += ",WQCZY";
                   strValueSQL += ",'" + model.WQCZY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSC") == true && model.CSC != null)
              {
                   strFieldSQL += ",CSC";
                   strValueSQL += ",'" + model.CSC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSK") == true && model.CSK != null)
              {
                   strFieldSQL += ",CSK";
                   strValueSQL += ",'" + model.CSK.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSG") == true && model.CSG != null)
              {
                   strFieldSQL += ",CSG";
                   strValueSQL += ",'" + model.CSG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJ") == true && model.ZJ != null)
              {
                   strFieldSQL += ",ZJ";
                   strValueSQL += ",'" + model.ZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZLJ") == true && model.YZLJ != null)
              {
                   strFieldSQL += ",YZLJ";
                   strValueSQL += ",'" + model.YZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZLJ") == true && model.EZLJ != null)
              {
                   strFieldSQL += ",EZLJ";
                   strValueSQL += ",'" + model.EZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZLJ") == true && model.SZLJ != null)
              {
                   strFieldSQL += ",SZLJ";
                   strValueSQL += ",'" + model.SZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZLJ") == true && model.SIZLJ != null)
              {
                   strFieldSQL += ",SIZLJ";
                   strValueSQL += ",'" + model.SIZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZLJ") == true && model.WZLJ != null)
              {
                   strFieldSQL += ",WZLJ";
                   strValueSQL += ",'" + model.WZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZLJ") == true && model.LZLJ != null)
              {
                   strFieldSQL += ",LZLJ";
                   strValueSQL += ",'" + model.LZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZZLZ") == true && model.YZZLZ != null)
              {
                   strFieldSQL += ",YZZLZ";
                   strValueSQL += ",'" + model.YZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZYLZ") == true && model.YZYLZ != null)
              {
                   strFieldSQL += ",YZYLZ";
                   strValueSQL += ",'" + model.YZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZZZ") == true && model.YZZZ != null)
              {
                   strFieldSQL += ",YZZZ";
                   strValueSQL += ",'" + model.YZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZZLZ") == true && model.EZZLZ != null)
              {
                   strFieldSQL += ",EZZLZ";
                   strValueSQL += ",'" + model.EZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZYLZ") == true && model.EZYLZ != null)
              {
                   strFieldSQL += ",EZYLZ";
                   strValueSQL += ",'" + model.EZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZZZ") == true && model.EZZZ != null)
              {
                   strFieldSQL += ",EZZZ";
                   strValueSQL += ",'" + model.EZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZZLZ") == true && model.SZZLZ != null)
              {
                   strFieldSQL += ",SZZLZ";
                   strValueSQL += ",'" + model.SZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZYLZ") == true && model.SZYLZ != null)
              {
                   strFieldSQL += ",SZYLZ";
                   strValueSQL += ",'" + model.SZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZZZ") == true && model.SZZZ != null)
              {
                   strFieldSQL += ",SZZZ";
                   strValueSQL += ",'" + model.SZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZZLZ") == true && model.SIZZLZ != null)
              {
                   strFieldSQL += ",SIZZLZ";
                   strValueSQL += ",'" + model.SIZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZYLZ") == true && model.SIZYLZ != null)
              {
                   strFieldSQL += ",SIZYLZ";
                   strValueSQL += ",'" + model.SIZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZZZ") == true && model.SIZZZ != null)
              {
                   strFieldSQL += ",SIZZZ";
                   strValueSQL += ",'" + model.SIZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZZLZ") == true && model.WZZLZ != null)
              {
                   strFieldSQL += ",WZZLZ";
                   strValueSQL += ",'" + model.WZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZYLZ") == true && model.WZYLZ != null)
              {
                   strFieldSQL += ",WZYLZ";
                   strValueSQL += ",'" + model.WZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZZZ") == true && model.WZZZ != null)
              {
                   strFieldSQL += ",WZZZ";
                   strValueSQL += ",'" + model.WZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZZLZ") == true && model.LZZLZ != null)
              {
                   strFieldSQL += ",LZZLZ";
                   strValueSQL += ",'" + model.LZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZYLZ") == true && model.LZYLZ != null)
              {
                   strFieldSQL += ",LZYLZ";
                   strValueSQL += ",'" + model.LZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZZZ") == true && model.LZZZ != null)
              {
                   strFieldSQL += ",LZZZ";
                   strValueSQL += ",'" + model.LZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CHZHQQK") == true && model.CHZHQQK != null)
              {
                   strFieldSQL += ",CHZHQQK";
                   strValueSQL += ",'" + model.CHZHQQK.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CHZHQQKDH") == true && model.CHZHQQKDH != null)
              {
                   strFieldSQL += ",CHZHQQKDH";
                   strValueSQL += ",'" + model.CHZHQQKDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PQHCLZZ") == true && model.PQHCLZZ != null)
              {
                   strFieldSQL += ",PQHCLZZ";
                   strValueSQL += ",'" + model.PQHCLZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PQHCLZZDH") == true && model.PQHCLZZDH != null)
              {
                   strFieldSQL += ",PQHCLZZDH";
                   strValueSQL += ",'" + model.PQHCLZZDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXRQ") == true && model.GXRQ != null)
              {
                   strFieldSQL += ",GXRQ";
                   strValueSQL += ",'" + model.GXRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JZZZWZ") == true && model.JZZZWZ != null)
              {
                   strFieldSQL += ",JZZZWZ";
                   strValueSQL += ",'" + model.JZZZWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYXM_EX") == true && model.JYXM_EX != null)
              {
                   strFieldSQL += ",JYXM_EX";
                   strValueSQL += ",'" + model.JYXM_EX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZZS") == true && model.ZZS != null)
              {
                   strFieldSQL += ",ZZS";
                   strValueSQL += ",'" + model.ZZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCJCLSH") == true && model.GLCJCLSH != null)
              {
                   strFieldSQL += ",GLCJCLSH";
                   strValueSQL += ",'" + model.GLCJCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCHPZL") == true && model.GLCHPZL != null)
              {
                   strFieldSQL += ",GLCHPZL";
                   strValueSQL += ",'" + model.GLCHPZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCHPZLDH") == true && model.GLCHPZLDH != null)
              {
                   strFieldSQL += ",GLCHPZLDH";
                   strValueSQL += ",'" + model.GLCHPZLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWCXWZJL") == true && model.LWCXWZJL != null)
              {
                   strFieldSQL += ",LWCXWZJL";
                   strValueSQL += ",'" + model.LWCXWZJL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFSQCLC") == true && model.SFSQCLC != null)
              {
                   strFieldSQL += ",SFSQCLC";
                   strValueSQL += ",'" + model.SFSQCLC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCJYXM") == true && model.GLCJYXM != null)
              {
                   strFieldSQL += ",GLCJYXM";
                   strValueSQL += ",'" + model.GLCJYXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWCXWZJLDH") == true && model.LWCXWZJLDH != null)
              {
                   strFieldSQL += ",LWCXWZJLDH";
                   strValueSQL += ",'" + model.LWCXWZJLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HDZH") == true && model.HDZH != null)
              {
                   strFieldSQL += ",HDZH";
                   strValueSQL += ",'" + model.HDZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDNJGL") == true && model.EDNJGL != null)
              {
                   strFieldSQL += ",EDNJGL";
                   strValueSQL += ",'" + model.EDNJGL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FWQ_ZYXZ") == true && model.FWQ_ZYXZ != null)
              {
                   strFieldSQL += ",FWQ_ZYXZ";
                   strValueSQL += ",'" + model.FWQ_ZYXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSBH") == true && model.DSBH != null)
              {
                   strFieldSQL += ",DSBH";
                   strValueSQL += ",'" + model.DSBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBSB") == true && model.JCBSB != null)
              {
                   strFieldSQL += ",JCBSB";
                   strValueSQL += ",'" + model.JCBSB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBXH") == true && model.JCBXH != null)
              {
                   strFieldSQL += ",JCBXH";
                   strValueSQL += ",'" + model.JCBXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBAZRQ") == true && model.JCBAZRQ != null)
              {
                   strFieldSQL += ",JCBAZRQ";
                   strValueSQL += ",'" + model.JCBAZRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBDYJSB") == true && model.JCBDYJSB != null)
              {
                   strFieldSQL += ",JCBDYJSB";
                   strValueSQL += ",'" + model.JCBDYJSB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBDYJXH") == true && model.JCBDYJXH != null)
              {
                   strFieldSQL += ",JCBDYJXH";
                   strValueSQL += ",'" + model.JCBDYJXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBAZGS") == true && model.JCBAZGS != null)
              {
                   strFieldSQL += ",JCBAZGS";
                   strValueSQL += ",'" + model.JCBAZGS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWLRLSH") == true && model.LWLRLSH != null)
              {
                   strFieldSQL += ",LWLRLSH";
                   strValueSQL += ",'" + model.LWLRLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWLRHENF") == true && model.LWLRHENF != null)
              {
                   strFieldSQL += ",LWLRHENF";
                   strValueSQL += ",'" + model.LWLRHENF.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("REPORT_JYXM") == true && model.REPORT_JYXM != null)
              {
                   strFieldSQL += ",REPORT_JYXM";
                   strValueSQL += ",'" + model.REPORT_JYXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTGGLX") == true && model.LTGGLX != null)
              {
                   strFieldSQL += ",LTGGLX";
                   strValueSQL += ",'" + model.LTGGLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTGGLXDH") == true && model.LTGGLXDH != null)
              {
                   strFieldSQL += ",LTGGLXDH";
                   strValueSQL += ",'" + model.LTGGLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZKZZL") == true && model.QDZKZZL != null)
              {
                   strFieldSQL += ",QDZKZZL";
                   strValueSQL += ",'" + model.QDZKZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCZS") == true && model.GCZS != null)
              {
                   strFieldSQL += ",GCZS";
                   strValueSQL += ",'" + model.GCZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCCSXS") == true && model.HCCSXS != null)
              {
                   strFieldSQL += ",HCCSXS";
                   strValueSQL += ",'" + model.HCCSXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YWLX") == true && model.YWLX != null)
              {
                   strFieldSQL += ",YWLX";
                   strValueSQL += ",'" + model.YWLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KCLXDJ") == true && model.KCLXDJ != null)
              {
                   strFieldSQL += ",KCLXDJ";
                   strValueSQL += ",'" + model.KCLXDJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YXSSZJ") == true && model.YXSSZJ != null)
              {
                   strFieldSQL += ",YXSSZJ";
                   strValueSQL += ",'" + model.YXSSZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCYYZH") == true && model.GCYYZH != null)
              {
                   strFieldSQL += ",GCYYZH";
                   strValueSQL += ",'" + model.GCYYZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCYXSSZJ") == true && model.GCYXSSZJ != null)
              {
                   strFieldSQL += ",GCYXSSZJ";
                   strValueSQL += ",'" + model.GCYXSSZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJJCCS") == true && model.AJJCCS != null)
              {
                   strFieldSQL += ",AJJCCS";
                   strValueSQL += "," + model.AJJCCS + "";
              }

              if(model.Changed("ZJJCCS") == true && model.ZJJCCS != null)
              {
                   strFieldSQL += ",ZJJCCS";
                   strValueSQL += "," + model.ZJJCCS + "";
              }

              if(model.Changed("WJJCCS") == true && model.WJJCCS != null)
              {
                   strFieldSQL += ",WJJCCS";
                   strValueSQL += "," + model.WJJCCS + "";
              }

              if(model.Changed("MTCSFDJSS") == true && model.MTCSFDJSS != null)
              {
                   strFieldSQL += ",MTCSFDJSS";
                   strValueSQL += ",'" + model.MTCSFDJSS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("MTCSFDJSSDH") == true && model.MTCSFDJSSDH != null)
              {
                   strFieldSQL += ",MTCSFDJSSDH";
                   strValueSQL += ",'" + model.MTCSFDJSSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYWLB") == true && model.ZYWLB != null)
              {
                   strFieldSQL += ",ZYWLB";
                   strValueSQL += ",'" + model.ZYWLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYWLBDH") == true && model.ZYWLBDH != null)
              {
                   strFieldSQL += ",ZYWLBDH";
                   strValueSQL += ",'" + model.ZYWLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJ_Z_PD") == true && model.AJ_Z_PD != null)
              {
                   strFieldSQL += ",AJ_Z_PD";
                   strValueSQL += ",'" + model.AJ_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJ_Z_PD") == true && model.ZJ_Z_PD != null)
              {
                   strFieldSQL += ",ZJ_Z_PD";
                   strValueSQL += ",'" + model.ZJ_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQ_Z_PD") == true && model.WQ_Z_PD != null)
              {
                   strFieldSQL += ",WQ_Z_PD";
                   strValueSQL += ",'" + model.WQ_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QT_Z_PD") == true && model.QT_Z_PD != null)
              {
                   strFieldSQL += ",QT_Z_PD";
                   strValueSQL += ",'" + model.QT_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJ_FJXM") == true && model.AJ_FJXM != null)
              {
                   strFieldSQL += ",AJ_FJXM";
                   strValueSQL += ",'" + model.AJ_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJ_FJXM") == true && model.ZJ_FJXM != null)
              {
                   strFieldSQL += ",ZJ_FJXM";
                   strValueSQL += ",'" + model.ZJ_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQ_FJXM") == true && model.WQ_FJXM != null)
              {
                   strFieldSQL += ",WQ_FJXM";
                   strValueSQL += ",'" + model.WQ_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QT_FJXM") == true && model.QT_FJXM != null)
              {
                   strFieldSQL += ",QT_FJXM";
                   strValueSQL += ",'" + model.QT_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYLB_TYPE") == true && model.JYLB_TYPE != null)
              {
                   strFieldSQL += ",JYLB_TYPE";
                   strValueSQL += ",'" + model.JYLB_TYPE.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLSSLB") == true && model.CLSSLB != null)
              {
                   strFieldSQL += ",CLSSLB";
                   strValueSQL += ",'" + model.CLSSLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLSSLBDH") == true && model.CLSSLBDH != null)
              {
                   strFieldSQL += ",CLSSLBDH";
                   strValueSQL += ",'" + model.CLSSLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYRSFZ") == true && model.SYRSFZ != null)
              {
                   strFieldSQL += ",SYRSFZ";
                   strValueSQL += ",'" + model.SYRSFZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJJYRQ") == true && model.ZJJYRQ != null)
              {
                   strFieldSQL += ",ZJJYRQ";
                   strValueSQL += ",'" + model.ZJJYRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BXZZRQ") == true && model.BXZZRQ != null)
              {
                   strFieldSQL += ",BXZZRQ";
                   strValueSQL += ",'" + model.BXZZRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYYXQZ") == true && model.JYYXQZ != null)
              {
                   strFieldSQL += ",JYYXQZ";
                   strValueSQL += ",'" + model.JYYXQZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLYTDH") == true && model.CLYTDH != null)
              {
                   strFieldSQL += ",CLYTDH";
                   strValueSQL += ",'" + model.CLYTDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YTSXDH") == true && model.YTSXDH != null)
              {
                   strFieldSQL += ",YTSXDH";
                   strValueSQL += ",'" + model.YTSXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BZZXS") == true && model.BZZXS != null)
              {
                   strFieldSQL += ",BZZXS";
                   strValueSQL += ",'" + model.BZZXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BZZXSDH") == true && model.BZZXSDH != null)
              {
                   strFieldSQL += ",BZZXSDH";
                   strValueSQL += ",'" + model.BZZXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYXM_LW") == true && model.JYXM_LW != null)
              {
                   strFieldSQL += ",JYXM_LW";
                   strValueSQL += ",'" + model.JYXM_LW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCPZH") == true && model.GCPZH != null)
              {
                   strFieldSQL += ",GCPZH";
                   strValueSQL += ",'" + model.GCPZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCLX") == true && model.GCLX != null)
              {
                   strFieldSQL += ",GCLX";
                   strValueSQL += ",'" + model.GCLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCLXDH") == true && model.GCLXDH != null)
              {
                   strFieldSQL += ",GCLXDH";
                   strValueSQL += ",'" + model.GCLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QYCMZZZL") == true && model.QYCMZZZL != null)
              {
                   strFieldSQL += ",QYCMZZZL";
                   strValueSQL += ",'" + model.QYCMZZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DCZS") == true && model.DCZS != null)
              {
                   strFieldSQL += ",DCZS";
                   strValueSQL += ",'" + model.DCZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("XZQY") == true && model.XZQY != null)
              {
                   strFieldSQL += ",XZQY";
                   strValueSQL += ",'" + model.XZQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZCLBGD") == true && model.ZCLBGD != null)
              {
                   strFieldSQL += ",ZCLBGD";
                   strValueSQL += ",'" + model.ZCLBGD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCLBGD") == true && model.GCLBGD != null)
              {
                   strFieldSQL += ",GCLBGD";
                   strValueSQL += ",'" + model.GCLBGD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCSC") == true && model.GCCSC != null)
              {
                   strFieldSQL += ",GCCSC";
                   strValueSQL += ",'" + model.GCCSC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCSK") == true && model.GCCSK != null)
              {
                   strFieldSQL += ",GCCSK";
                   strValueSQL += ",'" + model.GCCSK.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCSG") == true && model.GCCSG != null)
              {
                   strFieldSQL += ",GCCSG";
                   strValueSQL += ",'" + model.GCCSG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCBZZXS") == true && model.GCBZZXS != null)
              {
                   strFieldSQL += ",GCBZZXS";
                   strValueSQL += ",'" + model.GCBZZXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCBZZXSDH") == true && model.GCBZZXSDH != null)
              {
                   strFieldSQL += ",GCBZZXSDH";
                   strValueSQL += ",'" + model.GCBZZXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJCLLX") == true && model.ZJCLLX != null)
              {
                   strFieldSQL += ",ZJCLLX";
                   strValueSQL += ",'" + model.ZJCLLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJCLLXDH") == true && model.ZJCLLXDH != null)
              {
                   strFieldSQL += ",ZJCLLXDH";
                   strValueSQL += ",'" + model.ZJCLLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFSWPC") == true && model.SFSWPC != null)
              {
                   strFieldSQL += ",SFSWPC";
                   strValueSQL += ",'" + model.SFSWPC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DLYSZH") == true && model.DLYSZH != null)
              {
                   strFieldSQL += ",DLYSZH";
                   strValueSQL += ",'" + model.DLYSZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFSGSQC") == true && model.SFSGSQC != null)
              {
                   strFieldSQL += ",SFSGSQC";
                   strValueSQL += ",'" + model.SFSGSQC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLCCLX") == true && model.CLCCLX != null)
              {
                   strFieldSQL += ",CLCCLX";
                   strValueSQL += ",'" + model.CLCCLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLCCLXDH") == true && model.CLCCLXDH != null)
              {
                   strFieldSQL += ",CLCCLXDH";
                   strValueSQL += ",'" + model.CLCCLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DWS") == true && model.DWS != null)
              {
                   strFieldSQL += ",DWS";
                   strValueSQL += ",'" + model.DWS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCCSXSDH") == true && model.HCCSXSDH != null)
              {
                   strFieldSQL += ",HCCSXSDH";
                   strValueSQL += ",'" + model.HCCSXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KCLXDJDH") == true && model.KCLXDJDH != null)
              {
                   strFieldSQL += ",KCLXDJDH";
                   strValueSQL += ",'" + model.KCLXDJDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KCCC") == true && model.KCCC != null)
              {
                   strFieldSQL += ",KCCC";
                   strValueSQL += ",'" + model.KCCC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCYXXSZJ") == true && model.GCYXXSZJ != null)
              {
                   strFieldSQL += ",GCYXXSZJ";
                   strValueSQL += ",'" + model.GCYXXSZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCVIN") == true && model.GCVIN != null)
              {
                   strFieldSQL += ",GCVIN";
                   strValueSQL += ",'" + model.GCVIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCCDJRQ") == true && model.GCCCDJRQ != null)
              {
                   strFieldSQL += ",GCCCDJRQ";
                   strValueSQL += ",'" + model.GCCCDJRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCCRQ") == true && model.GCCCRQ != null)
              {
                   strFieldSQL += ",GCCCRQ";
                   strValueSQL += ",'" + model.GCCCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCPPXH") == true && model.GCPPXH != null)
              {
                   strFieldSQL += ",GCPPXH";
                   strValueSQL += ",'" + model.GCPPXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Z_RESULT") == true && model.Z_RESULT != null)
              {
                   strFieldSQL += ",Z_RESULT";
                   strValueSQL += ",'" + model.Z_RESULT.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPYS") == true && model.HPYS != null)
              {
                   strFieldSQL += ",HPYS";
                   strValueSQL += ",'" + model.HPYS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPYSDH") == true && model.HPYSDH != null)
              {
                   strFieldSQL += ",HPYSDH";
                   strValueSQL += ",'" + model.HPYSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DGSFZXTS") == true && model.DGSFZXTS != null)
              {
                   strFieldSQL += ",DGSFZXTS";
                   strValueSQL += ",'" + model.DGSFZXTS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DGSFZXTSDH") == true && model.DGSFZXTSDH != null)
              {
                   strFieldSQL += ",DGSFZXTSDH";
                   strValueSQL += ",'" + model.DGSFZXTSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZDJGL") == true && model.ZDJGL != null)
              {
                   strFieldSQL += ",ZDJGL";
                   strValueSQL += ",'" + model.ZDJGL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BGDBH") == true && model.BGDBH != null)
              {
                   strFieldSQL += ",BGDBH";
                   strValueSQL += ",'" + model.BGDBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BGDJYM") == true && model.BGDJYM != null)
              {
                   strFieldSQL += ",BGDJYM";
                   strValueSQL += ",'" + model.BGDJYM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZDQLX") == true && model.SZDQLX != null)
              {
                   strFieldSQL += ",SZDQLX";
                   strValueSQL += ",'" + model.SZDQLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZDQLXDH") == true && model.SZDQLXDH != null)
              {
                   strFieldSQL += ",SZDQLXDH";
                   strValueSQL += ",'" + model.SZDQLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YYZHCLRQ") == true && model.YYZHCLRQ != null)
              {
                   strFieldSQL += ",YYZHCLRQ";
                   strValueSQL += ",'" + model.YYZHCLRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PFLSH") == true && model.PFLSH != null)
              {
                   strFieldSQL += ",PFLSH";
                   strValueSQL += ",'" + model.PFLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DDJXH") == true && model.DDJXH != null)
              {
                   strFieldSQL += ",DDJXH";
                   strValueSQL += ",'" + model.DDJXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CNZZXH") == true && model.CNZZXH != null)
              {
                   strFieldSQL += ",CNZZXH";
                   strValueSQL += ",'" + model.CNZZXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DCRL") == true && model.DCRL != null)
              {
                   strFieldSQL += ",DCRL";
                   strValueSQL += ",'" + model.DCRL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsTrainMode") == true && model.IsTrainMode != null)
              {
                   strFieldSQL += ",IsTrainMode";
                   strValueSQL += "," + model.IsTrainMode + "";
              }

              if(model.Changed("IsOBD") == true && model.IsOBD != null)
              {
                   strFieldSQL += ",IsOBD";
                   strValueSQL += "," + model.IsOBD + "";
              }

              if(model.Changed("OBDWZ") == true && model.OBDWZ != null)
              {
                   strFieldSQL += ",OBDWZ";
                   strValueSQL += ",'" + model.OBDWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsDPF") == true && model.IsDPF != null)
              {
                   strFieldSQL += ",IsDPF";
                   strValueSQL += "," + model.IsDPF + "";
              }

              if(model.Changed("DPFXH") == true && model.DPFXH != null)
              {
                   strFieldSQL += ",DPFXH";
                   strValueSQL += ",'" + model.DPFXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsSCR") == true && model.IsSCR != null)
              {
                   strFieldSQL += ",IsSCR";
                   strValueSQL += "," + model.IsSCR + "";
              }

              if(model.Changed("SCRXH") == true && model.SCRXH != null)
              {
                   strFieldSQL += ",SCRXH";
                   strValueSQL += ",'" + model.SCRXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QZJCDGGP") == true && model.QZJCDGGP != null)
              {
                   strFieldSQL += ",QZJCDGGP";
                   strValueSQL += ",'" + model.QZJCDGGP.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDJYY") == true && model.OBDJYY != null)
              {
                   strFieldSQL += ",OBDJYY";
                   strValueSQL += ",'" + model.OBDJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQYCY") == true && model.WQYCY != null)
              {
                   strFieldSQL += ",WQYCY";
                   strValueSQL += ",'" + model.WQYCY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDCommCL") == true && model.OBDCommCL != null)
              {
                   strFieldSQL += ",OBDCommCL";
                   strValueSQL += ",'" + model.OBDCommCL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDCommCX") == true && model.OBDCommCX != null)
              {
                   strFieldSQL += ",OBDCommCX";
                   strValueSQL += ",'" + model.OBDCommCX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Standard") == true && model.Standard != null)
              {
                   strFieldSQL += ",Standard";
                   strValueSQL += ",'" + model.Standard.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VehicleKind") == true && model.VehicleKind != null)
              {
                   strFieldSQL += ",VehicleKind";
                   strValueSQL += ",'" + model.VehicleKind.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsEFI") == true && model.IsEFI != null)
              {
                   strFieldSQL += ",IsEFI";
                   strValueSQL += ",'" + model.IsEFI.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsAsm") == true && model.IsAsm != null)
              {
                   strFieldSQL += ",IsAsm";
                   strValueSQL += ",'" + model.IsAsm.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDOutlookID") == true && model.OBDOutlookID != null)
              {
                   strFieldSQL += ",OBDOutlookID";
                   strValueSQL += ",'" + model.OBDOutlookID.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OutlookID") == true && model.OutlookID != null)
              {
                   strFieldSQL += ",OutlookID";
                   strValueSQL += ",'" + model.OutlookID.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VEHICLE_DATA") == true && model.VEHICLE_DATA != null)
              {
                   strFieldSQL += ",VEHICLE_DATA";
                   strValueSQL += ",'" + model.VEHICLE_DATA.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZS") == true && model.QDZS != null)
              {
                   strFieldSQL += ",QDZS";
                   strValueSQL += ",'" + model.QDZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("sunVIN") == true && model.sunVIN != null)
              {
                   strFieldSQL += ",sunVIN";
                   strValueSQL += ",'" + model.sunVIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PQGSL") == true && model.PQGSL != null)
              {
                   strFieldSQL += ",PQGSL";
                   strValueSQL += ",'" + model.PQGSL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JZZL") == true && model.JZZL != null)
              {
                   strFieldSQL += ",JZZL";
                   strValueSQL += ",'" + model.JZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLPFJD") == true && model.CLPFJD != null)
              {
                   strFieldSQL += ",CLPFJD";
                   strValueSQL += ",'" + model.CLPFJD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJSB") == true && model.FDJSB != null)
              {
                   strFieldSQL += ",FDJSB";
                   strValueSQL += ",'" + model.FDJSB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZW") == true && model.QDZW != null)
              {
                   strFieldSQL += ",QDZW";
                   strValueSQL += ",'" + model.QDZW.ToString().Replace("'","''") + "'";
              }

              string strSql = "";
              strSql += "insert into RESULT_VEHICLE_INFO";
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
          public bool Insert(RESULT_VEHICLE_INFO model)
          {
              return DbHelper.ExecuteSql(Conn,InsertSQL(model));
          }

          /// <summary>
          /// 修改一条数据 SQL
          /// </summary>
          public string UpdateSQL(RESULT_VEHICLE_INFO model,string strJCLSH)
          {
              string strUpdateSQL = "";

              if(model.Changed("JCXH") == true && model.JCXH != null)
              {
                  strUpdateSQL += ",JCXH=" + model.JCXH + "";
              }

              if(model.Changed("JCXHMS") == true && model.JCXHMS != null)
              {
                  strUpdateSQL += ",JCXHMS='" + model.JCXHMS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCCS") == true && model.JCCS != null)
              {
                  strUpdateSQL += ",JCCS=" + model.JCCS + "";
              }

              if(model.Changed("JCLSH") == true && model.JCLSH != null)
              {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYXM") == true && model.JYXM != null)
              {
                  strUpdateSQL += ",JYXM='" + model.JYXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YJXM") == true && model.YJXM != null)
              {
                  strUpdateSQL += ",YJXM='" + model.YJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FJXM") == true && model.FJXM != null)
              {
                  strUpdateSQL += ",FJXM='" + model.FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Z_PD") == true && model.Z_PD != null)
              {
                  strUpdateSQL += ",Z_PD='" + model.Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsUpload") == true && model.IsUpload != null)
              {
                  strUpdateSQL += ",IsUpload=" + model.IsUpload + "";
              }

              if(model.Changed("IsAudit") == true && model.IsAudit != null)
              {
                  strUpdateSQL += ",IsAudit=" + model.IsAudit + "";
              }

              if(model.Changed("IsPrint") == true && model.IsPrint != null)
              {
                  strUpdateSQL += ",IsPrint=" + model.IsPrint + "";
              }

              if(model.Changed("WQLSH") == true && model.WQLSH != null)
              {
                  strUpdateSQL += ",WQLSH='" + model.WQLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJLSH") == true && model.AJLSH != null)
              {
                  strUpdateSQL += ",AJLSH='" + model.AJLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJLSH") == true && model.ZJLSH != null)
              {
                  strUpdateSQL += ",ZJLSH='" + model.ZJLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("MTLSH") == true && model.MTLSH != null)
              {
                  strUpdateSQL += ",MTLSH='" + model.MTLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBGDBH01") == true && model.JCBGDBH01 != null)
              {
                  strUpdateSQL += ",JCBGDBH01='" + model.JCBGDBH01.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBGDBH02") == true && model.JCBGDBH02 != null)
              {
                  strUpdateSQL += ",JCBGDBH02='" + model.JCBGDBH02.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPHM") == true && model.HPHM != null)
              {
                  strUpdateSQL += ",HPHM='" + model.HPHM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPZL") == true && model.HPZL != null)
              {
                  strUpdateSQL += ",HPZL='" + model.HPZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPZLDH") == true && model.HPZLDH != null)
              {
                  strUpdateSQL += ",HPZLDH='" + model.HPZLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCHPHM") == true && model.GLCHPHM != null)
              {
                  strUpdateSQL += ",GLCHPHM='" + model.GLCHPHM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VIN") == true && model.VIN != null)
              {
                  strUpdateSQL += ",VIN='" + model.VIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYLB") == true && model.JYLB != null)
              {
                  strUpdateSQL += ",JYLB='" + model.JYLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYLBDH") == true && model.JYLBDH != null)
              {
                  strUpdateSQL += ",JYLBDH='" + model.JYLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJH") == true && model.FDJH != null)
              {
                  strUpdateSQL += ",FDJH='" + model.FDJH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJXH") == true && model.FDJXH != null)
              {
                  strUpdateSQL += ",FDJXH='" + model.FDJXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJZZCS") == true && model.FDJZZCS != null)
              {
                  strUpdateSQL += ",FDJZZCS='" + model.FDJZZCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DPXH") == true && model.DPXH != null)
              {
                  strUpdateSQL += ",DPXH='" + model.DPXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PP") == true && model.PP != null)
              {
                  strUpdateSQL += ",PP='" + model.PP.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLZZCS") == true && model.CLZZCS != null)
              {
                  strUpdateSQL += ",CLZZCS='" + model.CLZZCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("XH") == true && model.XH != null)
              {
                  strUpdateSQL += ",XH='" + model.XH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PPXH") == true && model.PPXH != null)
              {
                  strUpdateSQL += ",PPXH='" + model.PPXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDXS") == true && model.QDXS != null)
              {
                  strUpdateSQL += ",QDXS='" + model.QDXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDXSDH") == true && model.QDXSDH != null)
              {
                  strUpdateSQL += ",QDXSDH='" + model.QDXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZWZ") == true && model.QDZWZ != null)
              {
                  strUpdateSQL += ",QDZWZ='" + model.QDZWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZCZWZ") == true && model.ZCZWZ != null)
              {
                  strUpdateSQL += ",ZCZWZ='" + model.ZCZWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QZDZ") == true && model.QZDZ != null)
              {
                  strUpdateSQL += ",QZDZ='" + model.QZDZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QZDZDH") == true && model.QZDZDH != null)
              {
                  strUpdateSQL += ",QZDZDH='" + model.QZDZDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YGGSNFKT") == true && model.YGGSNFKT != null)
              {
                  strUpdateSQL += ",YGGSNFKT='" + model.YGGSNFKT.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YGGSNFKTDH") == true && model.YGGSNFKTDH != null)
              {
                  strUpdateSQL += ",YGGSNFKTDH='" + model.YGGSNFKTDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RLLB") == true && model.RLLB != null)
              {
                  strUpdateSQL += ",RLLB='" + model.RLLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RLLBDH") == true && model.RLLBDH != null)
              {
                  strUpdateSQL += ",RLLBDH='" + model.RLLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("RYBH") == true && model.RYBH != null)
              {
                  strUpdateSQL += ",RYBH='" + model.RYBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GYFS") == true && model.GYFS != null)
              {
                  strUpdateSQL += ",GYFS='" + model.GYFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GYFSDH") == true && model.GYFSDH != null)
              {
                  strUpdateSQL += ",GYFSDH='" + model.GYFSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CCDJRQ") == true && model.CCDJRQ != null)
              {
                  strUpdateSQL += ",CCDJRQ='" + model.CCDJRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CCRQ") == true && model.CCRQ != null)
              {
                  strUpdateSQL += ",CCRQ='" + model.CCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZBZL") == true && model.ZBZL != null)
              {
                  strUpdateSQL += ",ZBZL='" + model.ZBZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZZL") == true && model.ZZL != null)
              {
                  strUpdateSQL += ",ZZL='" + model.ZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CYS") == true && model.CYS != null)
              {
                  strUpdateSQL += ",CYS='" + model.CYS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSYS") == true && model.CSYS != null)
              {
                  strUpdateSQL += ",CSYS='" + model.CSYS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZDFS") == true && model.ZDFS != null)
              {
                  strUpdateSQL += ",ZDFS='" + model.ZDFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZDFSDH") == true && model.ZDFSDH != null)
              {
                  strUpdateSQL += ",ZDFSDH='" + model.ZDFSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLZL") == true && model.CLZL != null)
              {
                  strUpdateSQL += ",CLZL='" + model.CLZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLZLDH") == true && model.CLZLDH != null)
              {
                  strUpdateSQL += ",CLZLDH='" + model.CLZLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZXJXS") == true && model.ZXZXJXS != null)
              {
                  strUpdateSQL += ",ZXZXJXS='" + model.ZXZXJXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZXJXSDH") == true && model.ZXZXJXSDH != null)
              {
                  strUpdateSQL += ",ZXZXJXSDH='" + model.ZXZXJXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZLX") == true && model.ZXZLX != null)
              {
                  strUpdateSQL += ",ZXZLX='" + model.ZXZLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZXZLXDH") == true && model.ZXZLXDH != null)
              {
                  strUpdateSQL += ",ZXZLXDH='" + model.ZXZLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZGSJCS") == true && model.ZGSJCS != null)
              {
                  strUpdateSQL += ",ZGSJCS='" + model.ZGSJCS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDGL") == true && model.EDGL != null)
              {
                  strUpdateSQL += ",EDGL='" + model.EDGL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDZS") == true && model.EDZS != null)
              {
                  strUpdateSQL += ",EDZS='" + model.EDZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDNJZS") == true && model.EDNJZS != null)
              {
                  strUpdateSQL += ",EDNJZS='" + model.EDNJZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDNJ") == true && model.EDNJ != null)
              {
                  strUpdateSQL += ",EDNJ='" + model.EDNJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDYH") == true && model.EDYH != null)
              {
                  strUpdateSQL += ",EDYH='" + model.EDYH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JQFS") == true && model.JQFS != null)
              {
                  strUpdateSQL += ",JQFS='" + model.JQFS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JQFSDH") == true && model.JQFSDH != null)
              {
                  strUpdateSQL += ",JQFSDH='" + model.JQFSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJPL") == true && model.FDJPL != null)
              {
                  strUpdateSQL += ",FDJPL='" + model.FDJPL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJGS") == true && model.FDJGS != null)
              {
                  strUpdateSQL += ",FDJGS='" + model.FDJGS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJCC") == true && model.FDJCC != null)
              {
                  strUpdateSQL += ",FDJCC='" + model.FDJCC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BSXLX") == true && model.BSXLX != null)
              {
                  strUpdateSQL += ",BSXLX='" + model.BSXLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BSXLXDH") == true && model.BSXLXDH != null)
              {
                  strUpdateSQL += ",BSXLXDH='" + model.BSXLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CXXL") == true && model.CXXL != null)
              {
                  strUpdateSQL += ",CXXL='" + model.CXXL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CXXLDH") == true && model.CXXLDH != null)
              {
                  strUpdateSQL += ",CXXLDH='" + model.CXXLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LJXSLC") == true && model.LJXSLC != null)
              {
                  strUpdateSQL += ",LJXSLC='" + model.LJXSLC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTQY") == true && model.LTQY != null)
              {
                  strUpdateSQL += ",LTQY='" + model.LTQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTGG") == true && model.LTGG != null)
              {
                  strUpdateSQL += ",LTGG='" + model.LTGG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTSL") == true && model.LTSL != null)
              {
                  strUpdateSQL += ",LTSL='" + model.LTSL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYXZ") == true && model.SYXZ != null)
              {
                  strUpdateSQL += ",SYXZ='" + model.SYXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYXZDH") == true && model.SYXZDH != null)
              {
                  strUpdateSQL += ",SYXZDH='" + model.SYXZDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YYZH") == true && model.YYZH != null)
              {
                  strUpdateSQL += ",YYZH='" + model.YYZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SJDW") == true && model.SJDW != null)
              {
                  strUpdateSQL += ",SJDW='" + model.SJDW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYR") == true && model.SYR != null)
              {
                  strUpdateSQL += ",SYR='" + model.SYR.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LXDH") == true && model.LXDH != null)
              {
                  strUpdateSQL += ",LXDH='" + model.LXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LXDZ") == true && model.LXDZ != null)
              {
                  strUpdateSQL += ",LXDZ='" + model.LXDZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZBH") == true && model.YZBH != null)
              {
                  strUpdateSQL += ",YZBH='" + model.YZBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCRQ") == true && model.JCRQ != null)
              {
                  strUpdateSQL += ",JCRQ='" + model.JCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DLRQ") == true && model.DLRQ != null)
              {
                  strUpdateSQL += ",DLRQ='" + model.DLRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLSXSJ") == true && model.CLSXSJ != null)
              {
                  strUpdateSQL += ",CLSXSJ='" + model.CLSXSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLXXSJ") == true && model.CLXXSJ != null)
              {
                  strUpdateSQL += ",CLXXSJ='" + model.CLXXSJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DLY") == true && model.DLY != null)
              {
                  strUpdateSQL += ",DLY='" + model.DLY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YCY") == true && model.YCY != null)
              {
                  strUpdateSQL += ",YCY='" + model.YCY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WGJYY") == true && model.WGJYY != null)
              {
                  strUpdateSQL += ",WGJYY='" + model.WGJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DPJYY") == true && model.DPJYY != null)
              {
                  strUpdateSQL += ",DPJYY='" + model.DPJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DTDPJYY") == true && model.DTDPJYY != null)
              {
                  strUpdateSQL += ",DTDPJYY='" + model.DTDPJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LSJYY") == true && model.LSJYY != null)
              {
                  strUpdateSQL += ",LSJYY='" + model.LSJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SQQZR") == true && model.SQQZR != null)
              {
                  strUpdateSQL += ",SQQZR='" + model.SQQZR.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQCZY") == true && model.WQCZY != null)
              {
                  strUpdateSQL += ",WQCZY='" + model.WQCZY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSC") == true && model.CSC != null)
              {
                  strUpdateSQL += ",CSC='" + model.CSC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSK") == true && model.CSK != null)
              {
                  strUpdateSQL += ",CSK='" + model.CSK.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CSG") == true && model.CSG != null)
              {
                  strUpdateSQL += ",CSG='" + model.CSG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJ") == true && model.ZJ != null)
              {
                  strUpdateSQL += ",ZJ='" + model.ZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZLJ") == true && model.YZLJ != null)
              {
                  strUpdateSQL += ",YZLJ='" + model.YZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZLJ") == true && model.EZLJ != null)
              {
                  strUpdateSQL += ",EZLJ='" + model.EZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZLJ") == true && model.SZLJ != null)
              {
                  strUpdateSQL += ",SZLJ='" + model.SZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZLJ") == true && model.SIZLJ != null)
              {
                  strUpdateSQL += ",SIZLJ='" + model.SIZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZLJ") == true && model.WZLJ != null)
              {
                  strUpdateSQL += ",WZLJ='" + model.WZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZLJ") == true && model.LZLJ != null)
              {
                  strUpdateSQL += ",LZLJ='" + model.LZLJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZZLZ") == true && model.YZZLZ != null)
              {
                  strUpdateSQL += ",YZZLZ='" + model.YZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZYLZ") == true && model.YZYLZ != null)
              {
                  strUpdateSQL += ",YZYLZ='" + model.YZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YZZZ") == true && model.YZZZ != null)
              {
                  strUpdateSQL += ",YZZZ='" + model.YZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZZLZ") == true && model.EZZLZ != null)
              {
                  strUpdateSQL += ",EZZLZ='" + model.EZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZYLZ") == true && model.EZYLZ != null)
              {
                  strUpdateSQL += ",EZYLZ='" + model.EZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EZZZ") == true && model.EZZZ != null)
              {
                  strUpdateSQL += ",EZZZ='" + model.EZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZZLZ") == true && model.SZZLZ != null)
              {
                  strUpdateSQL += ",SZZLZ='" + model.SZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZYLZ") == true && model.SZYLZ != null)
              {
                  strUpdateSQL += ",SZYLZ='" + model.SZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZZZ") == true && model.SZZZ != null)
              {
                  strUpdateSQL += ",SZZZ='" + model.SZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZZLZ") == true && model.SIZZLZ != null)
              {
                  strUpdateSQL += ",SIZZLZ='" + model.SIZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZYLZ") == true && model.SIZYLZ != null)
              {
                  strUpdateSQL += ",SIZYLZ='" + model.SIZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SIZZZ") == true && model.SIZZZ != null)
              {
                  strUpdateSQL += ",SIZZZ='" + model.SIZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZZLZ") == true && model.WZZLZ != null)
              {
                  strUpdateSQL += ",WZZLZ='" + model.WZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZYLZ") == true && model.WZYLZ != null)
              {
                  strUpdateSQL += ",WZYLZ='" + model.WZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WZZZ") == true && model.WZZZ != null)
              {
                  strUpdateSQL += ",WZZZ='" + model.WZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZZLZ") == true && model.LZZLZ != null)
              {
                  strUpdateSQL += ",LZZLZ='" + model.LZZLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZYLZ") == true && model.LZYLZ != null)
              {
                  strUpdateSQL += ",LZYLZ='" + model.LZYLZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LZZZ") == true && model.LZZZ != null)
              {
                  strUpdateSQL += ",LZZZ='" + model.LZZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CHZHQQK") == true && model.CHZHQQK != null)
              {
                  strUpdateSQL += ",CHZHQQK='" + model.CHZHQQK.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CHZHQQKDH") == true && model.CHZHQQKDH != null)
              {
                  strUpdateSQL += ",CHZHQQKDH='" + model.CHZHQQKDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PQHCLZZ") == true && model.PQHCLZZ != null)
              {
                  strUpdateSQL += ",PQHCLZZ='" + model.PQHCLZZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PQHCLZZDH") == true && model.PQHCLZZDH != null)
              {
                  strUpdateSQL += ",PQHCLZZDH='" + model.PQHCLZZDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GXRQ") == true && model.GXRQ != null)
              {
                  strUpdateSQL += ",GXRQ='" + model.GXRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JZZZWZ") == true && model.JZZZWZ != null)
              {
                  strUpdateSQL += ",JZZZWZ='" + model.JZZZWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYXM_EX") == true && model.JYXM_EX != null)
              {
                  strUpdateSQL += ",JYXM_EX='" + model.JYXM_EX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZZS") == true && model.ZZS != null)
              {
                  strUpdateSQL += ",ZZS='" + model.ZZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCJCLSH") == true && model.GLCJCLSH != null)
              {
                  strUpdateSQL += ",GLCJCLSH='" + model.GLCJCLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCHPZL") == true && model.GLCHPZL != null)
              {
                  strUpdateSQL += ",GLCHPZL='" + model.GLCHPZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCHPZLDH") == true && model.GLCHPZLDH != null)
              {
                  strUpdateSQL += ",GLCHPZLDH='" + model.GLCHPZLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWCXWZJL") == true && model.LWCXWZJL != null)
              {
                  strUpdateSQL += ",LWCXWZJL='" + model.LWCXWZJL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFSQCLC") == true && model.SFSQCLC != null)
              {
                  strUpdateSQL += ",SFSQCLC='" + model.SFSQCLC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GLCJYXM") == true && model.GLCJYXM != null)
              {
                  strUpdateSQL += ",GLCJYXM='" + model.GLCJYXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWCXWZJLDH") == true && model.LWCXWZJLDH != null)
              {
                  strUpdateSQL += ",LWCXWZJLDH='" + model.LWCXWZJLDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HDZH") == true && model.HDZH != null)
              {
                  strUpdateSQL += ",HDZH='" + model.HDZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("EDNJGL") == true && model.EDNJGL != null)
              {
                  strUpdateSQL += ",EDNJGL='" + model.EDNJGL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FWQ_ZYXZ") == true && model.FWQ_ZYXZ != null)
              {
                  strUpdateSQL += ",FWQ_ZYXZ='" + model.FWQ_ZYXZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DSBH") == true && model.DSBH != null)
              {
                  strUpdateSQL += ",DSBH='" + model.DSBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBSB") == true && model.JCBSB != null)
              {
                  strUpdateSQL += ",JCBSB='" + model.JCBSB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBXH") == true && model.JCBXH != null)
              {
                  strUpdateSQL += ",JCBXH='" + model.JCBXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBAZRQ") == true && model.JCBAZRQ != null)
              {
                  strUpdateSQL += ",JCBAZRQ='" + model.JCBAZRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBDYJSB") == true && model.JCBDYJSB != null)
              {
                  strUpdateSQL += ",JCBDYJSB='" + model.JCBDYJSB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBDYJXH") == true && model.JCBDYJXH != null)
              {
                  strUpdateSQL += ",JCBDYJXH='" + model.JCBDYJXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JCBAZGS") == true && model.JCBAZGS != null)
              {
                  strUpdateSQL += ",JCBAZGS='" + model.JCBAZGS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWLRLSH") == true && model.LWLRLSH != null)
              {
                  strUpdateSQL += ",LWLRLSH='" + model.LWLRLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LWLRHENF") == true && model.LWLRHENF != null)
              {
                  strUpdateSQL += ",LWLRHENF='" + model.LWLRHENF.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("REPORT_JYXM") == true && model.REPORT_JYXM != null)
              {
                  strUpdateSQL += ",REPORT_JYXM='" + model.REPORT_JYXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTGGLX") == true && model.LTGGLX != null)
              {
                  strUpdateSQL += ",LTGGLX='" + model.LTGGLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("LTGGLXDH") == true && model.LTGGLXDH != null)
              {
                  strUpdateSQL += ",LTGGLXDH='" + model.LTGGLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZKZZL") == true && model.QDZKZZL != null)
              {
                  strUpdateSQL += ",QDZKZZL='" + model.QDZKZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCZS") == true && model.GCZS != null)
              {
                  strUpdateSQL += ",GCZS='" + model.GCZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCCSXS") == true && model.HCCSXS != null)
              {
                  strUpdateSQL += ",HCCSXS='" + model.HCCSXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YWLX") == true && model.YWLX != null)
              {
                  strUpdateSQL += ",YWLX='" + model.YWLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KCLXDJ") == true && model.KCLXDJ != null)
              {
                  strUpdateSQL += ",KCLXDJ='" + model.KCLXDJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YXSSZJ") == true && model.YXSSZJ != null)
              {
                  strUpdateSQL += ",YXSSZJ='" + model.YXSSZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCYYZH") == true && model.GCYYZH != null)
              {
                  strUpdateSQL += ",GCYYZH='" + model.GCYYZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCYXSSZJ") == true && model.GCYXSSZJ != null)
              {
                  strUpdateSQL += ",GCYXSSZJ='" + model.GCYXSSZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJJCCS") == true && model.AJJCCS != null)
              {
                  strUpdateSQL += ",AJJCCS=" + model.AJJCCS + "";
              }

              if(model.Changed("ZJJCCS") == true && model.ZJJCCS != null)
              {
                  strUpdateSQL += ",ZJJCCS=" + model.ZJJCCS + "";
              }

              if(model.Changed("WJJCCS") == true && model.WJJCCS != null)
              {
                  strUpdateSQL += ",WJJCCS=" + model.WJJCCS + "";
              }

              if(model.Changed("MTCSFDJSS") == true && model.MTCSFDJSS != null)
              {
                  strUpdateSQL += ",MTCSFDJSS='" + model.MTCSFDJSS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("MTCSFDJSSDH") == true && model.MTCSFDJSSDH != null)
              {
                  strUpdateSQL += ",MTCSFDJSSDH='" + model.MTCSFDJSSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYWLB") == true && model.ZYWLB != null)
              {
                  strUpdateSQL += ",ZYWLB='" + model.ZYWLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZYWLBDH") == true && model.ZYWLBDH != null)
              {
                  strUpdateSQL += ",ZYWLBDH='" + model.ZYWLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJ_Z_PD") == true && model.AJ_Z_PD != null)
              {
                  strUpdateSQL += ",AJ_Z_PD='" + model.AJ_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJ_Z_PD") == true && model.ZJ_Z_PD != null)
              {
                  strUpdateSQL += ",ZJ_Z_PD='" + model.ZJ_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQ_Z_PD") == true && model.WQ_Z_PD != null)
              {
                  strUpdateSQL += ",WQ_Z_PD='" + model.WQ_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QT_Z_PD") == true && model.QT_Z_PD != null)
              {
                  strUpdateSQL += ",QT_Z_PD='" + model.QT_Z_PD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("AJ_FJXM") == true && model.AJ_FJXM != null)
              {
                  strUpdateSQL += ",AJ_FJXM='" + model.AJ_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJ_FJXM") == true && model.ZJ_FJXM != null)
              {
                  strUpdateSQL += ",ZJ_FJXM='" + model.ZJ_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQ_FJXM") == true && model.WQ_FJXM != null)
              {
                  strUpdateSQL += ",WQ_FJXM='" + model.WQ_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QT_FJXM") == true && model.QT_FJXM != null)
              {
                  strUpdateSQL += ",QT_FJXM='" + model.QT_FJXM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYLB_TYPE") == true && model.JYLB_TYPE != null)
              {
                  strUpdateSQL += ",JYLB_TYPE='" + model.JYLB_TYPE.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLSSLB") == true && model.CLSSLB != null)
              {
                  strUpdateSQL += ",CLSSLB='" + model.CLSSLB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLSSLBDH") == true && model.CLSSLBDH != null)
              {
                  strUpdateSQL += ",CLSSLBDH='" + model.CLSSLBDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SYRSFZ") == true && model.SYRSFZ != null)
              {
                  strUpdateSQL += ",SYRSFZ='" + model.SYRSFZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJJYRQ") == true && model.ZJJYRQ != null)
              {
                  strUpdateSQL += ",ZJJYRQ='" + model.ZJJYRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BXZZRQ") == true && model.BXZZRQ != null)
              {
                  strUpdateSQL += ",BXZZRQ='" + model.BXZZRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYYXQZ") == true && model.JYYXQZ != null)
              {
                  strUpdateSQL += ",JYYXQZ='" + model.JYYXQZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLYTDH") == true && model.CLYTDH != null)
              {
                  strUpdateSQL += ",CLYTDH='" + model.CLYTDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YTSXDH") == true && model.YTSXDH != null)
              {
                  strUpdateSQL += ",YTSXDH='" + model.YTSXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BZZXS") == true && model.BZZXS != null)
              {
                  strUpdateSQL += ",BZZXS='" + model.BZZXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BZZXSDH") == true && model.BZZXSDH != null)
              {
                  strUpdateSQL += ",BZZXSDH='" + model.BZZXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JYXM_LW") == true && model.JYXM_LW != null)
              {
                  strUpdateSQL += ",JYXM_LW='" + model.JYXM_LW.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCPZH") == true && model.GCPZH != null)
              {
                  strUpdateSQL += ",GCPZH='" + model.GCPZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCLX") == true && model.GCLX != null)
              {
                  strUpdateSQL += ",GCLX='" + model.GCLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCLXDH") == true && model.GCLXDH != null)
              {
                  strUpdateSQL += ",GCLXDH='" + model.GCLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QYCMZZZL") == true && model.QYCMZZZL != null)
              {
                  strUpdateSQL += ",QYCMZZZL='" + model.QYCMZZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DCZS") == true && model.DCZS != null)
              {
                  strUpdateSQL += ",DCZS='" + model.DCZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("XZQY") == true && model.XZQY != null)
              {
                  strUpdateSQL += ",XZQY='" + model.XZQY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZCLBGD") == true && model.ZCLBGD != null)
              {
                  strUpdateSQL += ",ZCLBGD='" + model.ZCLBGD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCLBGD") == true && model.GCLBGD != null)
              {
                  strUpdateSQL += ",GCLBGD='" + model.GCLBGD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCSC") == true && model.GCCSC != null)
              {
                  strUpdateSQL += ",GCCSC='" + model.GCCSC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCSK") == true && model.GCCSK != null)
              {
                  strUpdateSQL += ",GCCSK='" + model.GCCSK.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCSG") == true && model.GCCSG != null)
              {
                  strUpdateSQL += ",GCCSG='" + model.GCCSG.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCBZZXS") == true && model.GCBZZXS != null)
              {
                  strUpdateSQL += ",GCBZZXS='" + model.GCBZZXS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCBZZXSDH") == true && model.GCBZZXSDH != null)
              {
                  strUpdateSQL += ",GCBZZXSDH='" + model.GCBZZXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJCLLX") == true && model.ZJCLLX != null)
              {
                  strUpdateSQL += ",ZJCLLX='" + model.ZJCLLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZJCLLXDH") == true && model.ZJCLLXDH != null)
              {
                  strUpdateSQL += ",ZJCLLXDH='" + model.ZJCLLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFSWPC") == true && model.SFSWPC != null)
              {
                  strUpdateSQL += ",SFSWPC='" + model.SFSWPC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DLYSZH") == true && model.DLYSZH != null)
              {
                  strUpdateSQL += ",DLYSZH='" + model.DLYSZH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SFSGSQC") == true && model.SFSGSQC != null)
              {
                  strUpdateSQL += ",SFSGSQC='" + model.SFSGSQC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLCCLX") == true && model.CLCCLX != null)
              {
                  strUpdateSQL += ",CLCCLX='" + model.CLCCLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLCCLXDH") == true && model.CLCCLXDH != null)
              {
                  strUpdateSQL += ",CLCCLXDH='" + model.CLCCLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DWS") == true && model.DWS != null)
              {
                  strUpdateSQL += ",DWS='" + model.DWS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HCCSXSDH") == true && model.HCCSXSDH != null)
              {
                  strUpdateSQL += ",HCCSXSDH='" + model.HCCSXSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KCLXDJDH") == true && model.KCLXDJDH != null)
              {
                  strUpdateSQL += ",KCLXDJDH='" + model.KCLXDJDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("KCCC") == true && model.KCCC != null)
              {
                  strUpdateSQL += ",KCCC='" + model.KCCC.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCYXXSZJ") == true && model.GCYXXSZJ != null)
              {
                  strUpdateSQL += ",GCYXXSZJ='" + model.GCYXXSZJ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCVIN") == true && model.GCVIN != null)
              {
                  strUpdateSQL += ",GCVIN='" + model.GCVIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCCDJRQ") == true && model.GCCCDJRQ != null)
              {
                  strUpdateSQL += ",GCCCDJRQ='" + model.GCCCDJRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCCCRQ") == true && model.GCCCRQ != null)
              {
                  strUpdateSQL += ",GCCCRQ='" + model.GCCCRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("GCPPXH") == true && model.GCPPXH != null)
              {
                  strUpdateSQL += ",GCPPXH='" + model.GCPPXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Z_RESULT") == true && model.Z_RESULT != null)
              {
                  strUpdateSQL += ",Z_RESULT='" + model.Z_RESULT.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPYS") == true && model.HPYS != null)
              {
                  strUpdateSQL += ",HPYS='" + model.HPYS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("HPYSDH") == true && model.HPYSDH != null)
              {
                  strUpdateSQL += ",HPYSDH='" + model.HPYSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DGSFZXTS") == true && model.DGSFZXTS != null)
              {
                  strUpdateSQL += ",DGSFZXTS='" + model.DGSFZXTS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DGSFZXTSDH") == true && model.DGSFZXTSDH != null)
              {
                  strUpdateSQL += ",DGSFZXTSDH='" + model.DGSFZXTSDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("ZDJGL") == true && model.ZDJGL != null)
              {
                  strUpdateSQL += ",ZDJGL='" + model.ZDJGL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BGDBH") == true && model.BGDBH != null)
              {
                  strUpdateSQL += ",BGDBH='" + model.BGDBH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("BGDJYM") == true && model.BGDJYM != null)
              {
                  strUpdateSQL += ",BGDJYM='" + model.BGDJYM.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZDQLX") == true && model.SZDQLX != null)
              {
                  strUpdateSQL += ",SZDQLX='" + model.SZDQLX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("SZDQLXDH") == true && model.SZDQLXDH != null)
              {
                  strUpdateSQL += ",SZDQLXDH='" + model.SZDQLXDH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("YYZHCLRQ") == true && model.YYZHCLRQ != null)
              {
                  strUpdateSQL += ",YYZHCLRQ='" + model.YYZHCLRQ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PFLSH") == true && model.PFLSH != null)
              {
                  strUpdateSQL += ",PFLSH='" + model.PFLSH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DDJXH") == true && model.DDJXH != null)
              {
                  strUpdateSQL += ",DDJXH='" + model.DDJXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CNZZXH") == true && model.CNZZXH != null)
              {
                  strUpdateSQL += ",CNZZXH='" + model.CNZZXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("DCRL") == true && model.DCRL != null)
              {
                  strUpdateSQL += ",DCRL='" + model.DCRL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsTrainMode") == true && model.IsTrainMode != null)
              {
                  strUpdateSQL += ",IsTrainMode=" + model.IsTrainMode + "";
              }

              if(model.Changed("IsOBD") == true && model.IsOBD != null)
              {
                  strUpdateSQL += ",IsOBD=" + model.IsOBD + "";
              }

              if(model.Changed("OBDWZ") == true && model.OBDWZ != null)
              {
                  strUpdateSQL += ",OBDWZ='" + model.OBDWZ.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsDPF") == true && model.IsDPF != null)
              {
                  strUpdateSQL += ",IsDPF=" + model.IsDPF + "";
              }

              if(model.Changed("DPFXH") == true && model.DPFXH != null)
              {
                  strUpdateSQL += ",DPFXH='" + model.DPFXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsSCR") == true && model.IsSCR != null)
              {
                  strUpdateSQL += ",IsSCR=" + model.IsSCR + "";
              }

              if(model.Changed("SCRXH") == true && model.SCRXH != null)
              {
                  strUpdateSQL += ",SCRXH='" + model.SCRXH.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QZJCDGGP") == true && model.QZJCDGGP != null)
              {
                  strUpdateSQL += ",QZJCDGGP='" + model.QZJCDGGP.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDJYY") == true && model.OBDJYY != null)
              {
                  strUpdateSQL += ",OBDJYY='" + model.OBDJYY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("WQYCY") == true && model.WQYCY != null)
              {
                  strUpdateSQL += ",WQYCY='" + model.WQYCY.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDCommCL") == true && model.OBDCommCL != null)
              {
                  strUpdateSQL += ",OBDCommCL='" + model.OBDCommCL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDCommCX") == true && model.OBDCommCX != null)
              {
                  strUpdateSQL += ",OBDCommCX='" + model.OBDCommCX.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("Standard") == true && model.Standard != null)
              {
                  strUpdateSQL += ",Standard='" + model.Standard.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VehicleKind") == true && model.VehicleKind != null)
              {
                  strUpdateSQL += ",VehicleKind='" + model.VehicleKind.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsEFI") == true && model.IsEFI != null)
              {
                  strUpdateSQL += ",IsEFI='" + model.IsEFI.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("IsAsm") == true && model.IsAsm != null)
              {
                  strUpdateSQL += ",IsAsm='" + model.IsAsm.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OBDOutlookID") == true && model.OBDOutlookID != null)
              {
                  strUpdateSQL += ",OBDOutlookID='" + model.OBDOutlookID.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("OutlookID") == true && model.OutlookID != null)
              {
                  strUpdateSQL += ",OutlookID='" + model.OutlookID.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("VEHICLE_DATA") == true && model.VEHICLE_DATA != null)
              {
                  strUpdateSQL += ",VEHICLE_DATA='" + model.VEHICLE_DATA.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZS") == true && model.QDZS != null)
              {
                  strUpdateSQL += ",QDZS='" + model.QDZS.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("sunVIN") == true && model.sunVIN != null)
              {
                  strUpdateSQL += ",sunVIN='" + model.sunVIN.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("PQGSL") == true && model.PQGSL != null)
              {
                  strUpdateSQL += ",PQGSL='" + model.PQGSL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("JZZL") == true && model.JZZL != null)
              {
                  strUpdateSQL += ",JZZL='" + model.JZZL.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("CLPFJD") == true && model.CLPFJD != null)
              {
                  strUpdateSQL += ",CLPFJD='" + model.CLPFJD.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("FDJSB") == true && model.FDJSB != null)
              {
                  strUpdateSQL += ",FDJSB='" + model.FDJSB.ToString().Replace("'","''") + "'";
              }

              if(model.Changed("QDZW") == true && model.QDZW != null)
              {
                  strUpdateSQL += ",QDZW='" + model.QDZW.ToString().Replace("'","''") + "'";
              }

               string strSql = "";
               strSql += "update RESULT_VEHICLE_INFO set ";
               strSql += strUpdateSQL.Substring(1);
               strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

               return strSql;
          }

          /// <summary>
          /// 修改一条数据
          /// </summary>
          public bool Update(RESULT_VEHICLE_INFO model, string strJCLSH)
          {
              return DbHelper.ExecuteSql(Conn, UpdateSQL(model, strJCLSH));
          }

          /// <summary>
          /// 修改一个集合 SQL
          /// </summary>
           public string UpdateRangeSQL(RESULT_VEHICLE_INFO model, string p_strWhere)
          {
               string strUpdateSQL = "";

               if(model.Changed("JCXH") == true && model.JCXH != null)
               {
                  strUpdateSQL += ",JCXH=" + model.JCXH + "";
               }

               if(model.Changed("JCXHMS") == true && model.JCXHMS != null)
               {
                  strUpdateSQL += ",JCXHMS='" + model.JCXHMS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCCS") == true && model.JCCS != null)
               {
                  strUpdateSQL += ",JCCS=" + model.JCCS + "";
               }

               if(model.Changed("JCLSH") == true && model.JCLSH != null)
               {
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYXM") == true && model.JYXM != null)
               {
                  strUpdateSQL += ",JYXM='" + model.JYXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YJXM") == true && model.YJXM != null)
               {
                  strUpdateSQL += ",YJXM='" + model.YJXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FJXM") == true && model.FJXM != null)
               {
                  strUpdateSQL += ",FJXM='" + model.FJXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Z_PD") == true && model.Z_PD != null)
               {
                  strUpdateSQL += ",Z_PD='" + model.Z_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsUpload") == true && model.IsUpload != null)
               {
                  strUpdateSQL += ",IsUpload=" + model.IsUpload + "";
               }

               if(model.Changed("IsAudit") == true && model.IsAudit != null)
               {
                  strUpdateSQL += ",IsAudit=" + model.IsAudit + "";
               }

               if(model.Changed("IsPrint") == true && model.IsPrint != null)
               {
                  strUpdateSQL += ",IsPrint=" + model.IsPrint + "";
               }

               if(model.Changed("WQLSH") == true && model.WQLSH != null)
               {
                  strUpdateSQL += ",WQLSH='" + model.WQLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AJLSH") == true && model.AJLSH != null)
               {
                  strUpdateSQL += ",AJLSH='" + model.AJLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJLSH") == true && model.ZJLSH != null)
               {
                  strUpdateSQL += ",ZJLSH='" + model.ZJLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("MTLSH") == true && model.MTLSH != null)
               {
                  strUpdateSQL += ",MTLSH='" + model.MTLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBGDBH01") == true && model.JCBGDBH01 != null)
               {
                  strUpdateSQL += ",JCBGDBH01='" + model.JCBGDBH01.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBGDBH02") == true && model.JCBGDBH02 != null)
               {
                  strUpdateSQL += ",JCBGDBH02='" + model.JCBGDBH02.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HPHM") == true && model.HPHM != null)
               {
                  strUpdateSQL += ",HPHM='" + model.HPHM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HPZL") == true && model.HPZL != null)
               {
                  strUpdateSQL += ",HPZL='" + model.HPZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HPZLDH") == true && model.HPZLDH != null)
               {
                  strUpdateSQL += ",HPZLDH='" + model.HPZLDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLCHPHM") == true && model.GLCHPHM != null)
               {
                  strUpdateSQL += ",GLCHPHM='" + model.GLCHPHM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("VIN") == true && model.VIN != null)
               {
                  strUpdateSQL += ",VIN='" + model.VIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYLB") == true && model.JYLB != null)
               {
                  strUpdateSQL += ",JYLB='" + model.JYLB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYLBDH") == true && model.JYLBDH != null)
               {
                  strUpdateSQL += ",JYLBDH='" + model.JYLBDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJH") == true && model.FDJH != null)
               {
                  strUpdateSQL += ",FDJH='" + model.FDJH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJXH") == true && model.FDJXH != null)
               {
                  strUpdateSQL += ",FDJXH='" + model.FDJXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJZZCS") == true && model.FDJZZCS != null)
               {
                  strUpdateSQL += ",FDJZZCS='" + model.FDJZZCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DPXH") == true && model.DPXH != null)
               {
                  strUpdateSQL += ",DPXH='" + model.DPXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PP") == true && model.PP != null)
               {
                  strUpdateSQL += ",PP='" + model.PP.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLZZCS") == true && model.CLZZCS != null)
               {
                  strUpdateSQL += ",CLZZCS='" + model.CLZZCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("XH") == true && model.XH != null)
               {
                  strUpdateSQL += ",XH='" + model.XH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PPXH") == true && model.PPXH != null)
               {
                  strUpdateSQL += ",PPXH='" + model.PPXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QDXS") == true && model.QDXS != null)
               {
                  strUpdateSQL += ",QDXS='" + model.QDXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QDXSDH") == true && model.QDXSDH != null)
               {
                  strUpdateSQL += ",QDXSDH='" + model.QDXSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QDZWZ") == true && model.QDZWZ != null)
               {
                  strUpdateSQL += ",QDZWZ='" + model.QDZWZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZCZWZ") == true && model.ZCZWZ != null)
               {
                  strUpdateSQL += ",ZCZWZ='" + model.ZCZWZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QZDZ") == true && model.QZDZ != null)
               {
                  strUpdateSQL += ",QZDZ='" + model.QZDZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QZDZDH") == true && model.QZDZDH != null)
               {
                  strUpdateSQL += ",QZDZDH='" + model.QZDZDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YGGSNFKT") == true && model.YGGSNFKT != null)
               {
                  strUpdateSQL += ",YGGSNFKT='" + model.YGGSNFKT.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YGGSNFKTDH") == true && model.YGGSNFKTDH != null)
               {
                  strUpdateSQL += ",YGGSNFKTDH='" + model.YGGSNFKTDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RLLB") == true && model.RLLB != null)
               {
                  strUpdateSQL += ",RLLB='" + model.RLLB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RLLBDH") == true && model.RLLBDH != null)
               {
                  strUpdateSQL += ",RLLBDH='" + model.RLLBDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("RYBH") == true && model.RYBH != null)
               {
                  strUpdateSQL += ",RYBH='" + model.RYBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GYFS") == true && model.GYFS != null)
               {
                  strUpdateSQL += ",GYFS='" + model.GYFS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GYFSDH") == true && model.GYFSDH != null)
               {
                  strUpdateSQL += ",GYFSDH='" + model.GYFSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CCDJRQ") == true && model.CCDJRQ != null)
               {
                  strUpdateSQL += ",CCDJRQ='" + model.CCDJRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CCRQ") == true && model.CCRQ != null)
               {
                  strUpdateSQL += ",CCRQ='" + model.CCRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZBZL") == true && model.ZBZL != null)
               {
                  strUpdateSQL += ",ZBZL='" + model.ZBZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZZL") == true && model.ZZL != null)
               {
                  strUpdateSQL += ",ZZL='" + model.ZZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CYS") == true && model.CYS != null)
               {
                  strUpdateSQL += ",CYS='" + model.CYS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CSYS") == true && model.CSYS != null)
               {
                  strUpdateSQL += ",CSYS='" + model.CSYS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZDFS") == true && model.ZDFS != null)
               {
                  strUpdateSQL += ",ZDFS='" + model.ZDFS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZDFSDH") == true && model.ZDFSDH != null)
               {
                  strUpdateSQL += ",ZDFSDH='" + model.ZDFSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLZL") == true && model.CLZL != null)
               {
                  strUpdateSQL += ",CLZL='" + model.CLZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLZLDH") == true && model.CLZLDH != null)
               {
                  strUpdateSQL += ",CLZLDH='" + model.CLZLDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZXZXJXS") == true && model.ZXZXJXS != null)
               {
                  strUpdateSQL += ",ZXZXJXS='" + model.ZXZXJXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZXZXJXSDH") == true && model.ZXZXJXSDH != null)
               {
                  strUpdateSQL += ",ZXZXJXSDH='" + model.ZXZXJXSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZXZLX") == true && model.ZXZLX != null)
               {
                  strUpdateSQL += ",ZXZLX='" + model.ZXZLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZXZLXDH") == true && model.ZXZLXDH != null)
               {
                  strUpdateSQL += ",ZXZLXDH='" + model.ZXZLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZGSJCS") == true && model.ZGSJCS != null)
               {
                  strUpdateSQL += ",ZGSJCS='" + model.ZGSJCS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EDGL") == true && model.EDGL != null)
               {
                  strUpdateSQL += ",EDGL='" + model.EDGL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EDZS") == true && model.EDZS != null)
               {
                  strUpdateSQL += ",EDZS='" + model.EDZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EDNJZS") == true && model.EDNJZS != null)
               {
                  strUpdateSQL += ",EDNJZS='" + model.EDNJZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EDNJ") == true && model.EDNJ != null)
               {
                  strUpdateSQL += ",EDNJ='" + model.EDNJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EDYH") == true && model.EDYH != null)
               {
                  strUpdateSQL += ",EDYH='" + model.EDYH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JQFS") == true && model.JQFS != null)
               {
                  strUpdateSQL += ",JQFS='" + model.JQFS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JQFSDH") == true && model.JQFSDH != null)
               {
                  strUpdateSQL += ",JQFSDH='" + model.JQFSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJPL") == true && model.FDJPL != null)
               {
                  strUpdateSQL += ",FDJPL='" + model.FDJPL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJGS") == true && model.FDJGS != null)
               {
                  strUpdateSQL += ",FDJGS='" + model.FDJGS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJCC") == true && model.FDJCC != null)
               {
                  strUpdateSQL += ",FDJCC='" + model.FDJCC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BSXLX") == true && model.BSXLX != null)
               {
                  strUpdateSQL += ",BSXLX='" + model.BSXLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BSXLXDH") == true && model.BSXLXDH != null)
               {
                  strUpdateSQL += ",BSXLXDH='" + model.BSXLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CXXL") == true && model.CXXL != null)
               {
                  strUpdateSQL += ",CXXL='" + model.CXXL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CXXLDH") == true && model.CXXLDH != null)
               {
                  strUpdateSQL += ",CXXLDH='" + model.CXXLDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LJXSLC") == true && model.LJXSLC != null)
               {
                  strUpdateSQL += ",LJXSLC='" + model.LJXSLC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LTQY") == true && model.LTQY != null)
               {
                  strUpdateSQL += ",LTQY='" + model.LTQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LTGG") == true && model.LTGG != null)
               {
                  strUpdateSQL += ",LTGG='" + model.LTGG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LTSL") == true && model.LTSL != null)
               {
                  strUpdateSQL += ",LTSL='" + model.LTSL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SYXZ") == true && model.SYXZ != null)
               {
                  strUpdateSQL += ",SYXZ='" + model.SYXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SYXZDH") == true && model.SYXZDH != null)
               {
                  strUpdateSQL += ",SYXZDH='" + model.SYXZDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YYZH") == true && model.YYZH != null)
               {
                  strUpdateSQL += ",YYZH='" + model.YYZH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SJDW") == true && model.SJDW != null)
               {
                  strUpdateSQL += ",SJDW='" + model.SJDW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SYR") == true && model.SYR != null)
               {
                  strUpdateSQL += ",SYR='" + model.SYR.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LXDH") == true && model.LXDH != null)
               {
                  strUpdateSQL += ",LXDH='" + model.LXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LXDZ") == true && model.LXDZ != null)
               {
                  strUpdateSQL += ",LXDZ='" + model.LXDZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YZBH") == true && model.YZBH != null)
               {
                  strUpdateSQL += ",YZBH='" + model.YZBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCRQ") == true && model.JCRQ != null)
               {
                  strUpdateSQL += ",JCRQ='" + model.JCRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DLRQ") == true && model.DLRQ != null)
               {
                  strUpdateSQL += ",DLRQ='" + model.DLRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLSXSJ") == true && model.CLSXSJ != null)
               {
                  strUpdateSQL += ",CLSXSJ='" + model.CLSXSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLXXSJ") == true && model.CLXXSJ != null)
               {
                  strUpdateSQL += ",CLXXSJ='" + model.CLXXSJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DLY") == true && model.DLY != null)
               {
                  strUpdateSQL += ",DLY='" + model.DLY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YCY") == true && model.YCY != null)
               {
                  strUpdateSQL += ",YCY='" + model.YCY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WGJYY") == true && model.WGJYY != null)
               {
                  strUpdateSQL += ",WGJYY='" + model.WGJYY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DPJYY") == true && model.DPJYY != null)
               {
                  strUpdateSQL += ",DPJYY='" + model.DPJYY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DTDPJYY") == true && model.DTDPJYY != null)
               {
                  strUpdateSQL += ",DTDPJYY='" + model.DTDPJYY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LSJYY") == true && model.LSJYY != null)
               {
                  strUpdateSQL += ",LSJYY='" + model.LSJYY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SQQZR") == true && model.SQQZR != null)
               {
                  strUpdateSQL += ",SQQZR='" + model.SQQZR.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WQCZY") == true && model.WQCZY != null)
               {
                  strUpdateSQL += ",WQCZY='" + model.WQCZY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CSC") == true && model.CSC != null)
               {
                  strUpdateSQL += ",CSC='" + model.CSC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CSK") == true && model.CSK != null)
               {
                  strUpdateSQL += ",CSK='" + model.CSK.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CSG") == true && model.CSG != null)
               {
                  strUpdateSQL += ",CSG='" + model.CSG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJ") == true && model.ZJ != null)
               {
                  strUpdateSQL += ",ZJ='" + model.ZJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YZLJ") == true && model.YZLJ != null)
               {
                  strUpdateSQL += ",YZLJ='" + model.YZLJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EZLJ") == true && model.EZLJ != null)
               {
                  strUpdateSQL += ",EZLJ='" + model.EZLJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SZLJ") == true && model.SZLJ != null)
               {
                  strUpdateSQL += ",SZLJ='" + model.SZLJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SIZLJ") == true && model.SIZLJ != null)
               {
                  strUpdateSQL += ",SIZLJ='" + model.SIZLJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WZLJ") == true && model.WZLJ != null)
               {
                  strUpdateSQL += ",WZLJ='" + model.WZLJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LZLJ") == true && model.LZLJ != null)
               {
                  strUpdateSQL += ",LZLJ='" + model.LZLJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YZZLZ") == true && model.YZZLZ != null)
               {
                  strUpdateSQL += ",YZZLZ='" + model.YZZLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YZYLZ") == true && model.YZYLZ != null)
               {
                  strUpdateSQL += ",YZYLZ='" + model.YZYLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YZZZ") == true && model.YZZZ != null)
               {
                  strUpdateSQL += ",YZZZ='" + model.YZZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EZZLZ") == true && model.EZZLZ != null)
               {
                  strUpdateSQL += ",EZZLZ='" + model.EZZLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EZYLZ") == true && model.EZYLZ != null)
               {
                  strUpdateSQL += ",EZYLZ='" + model.EZYLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EZZZ") == true && model.EZZZ != null)
               {
                  strUpdateSQL += ",EZZZ='" + model.EZZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SZZLZ") == true && model.SZZLZ != null)
               {
                  strUpdateSQL += ",SZZLZ='" + model.SZZLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SZYLZ") == true && model.SZYLZ != null)
               {
                  strUpdateSQL += ",SZYLZ='" + model.SZYLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SZZZ") == true && model.SZZZ != null)
               {
                  strUpdateSQL += ",SZZZ='" + model.SZZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SIZZLZ") == true && model.SIZZLZ != null)
               {
                  strUpdateSQL += ",SIZZLZ='" + model.SIZZLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SIZYLZ") == true && model.SIZYLZ != null)
               {
                  strUpdateSQL += ",SIZYLZ='" + model.SIZYLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SIZZZ") == true && model.SIZZZ != null)
               {
                  strUpdateSQL += ",SIZZZ='" + model.SIZZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WZZLZ") == true && model.WZZLZ != null)
               {
                  strUpdateSQL += ",WZZLZ='" + model.WZZLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WZYLZ") == true && model.WZYLZ != null)
               {
                  strUpdateSQL += ",WZYLZ='" + model.WZYLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WZZZ") == true && model.WZZZ != null)
               {
                  strUpdateSQL += ",WZZZ='" + model.WZZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LZZLZ") == true && model.LZZLZ != null)
               {
                  strUpdateSQL += ",LZZLZ='" + model.LZZLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LZYLZ") == true && model.LZYLZ != null)
               {
                  strUpdateSQL += ",LZYLZ='" + model.LZYLZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LZZZ") == true && model.LZZZ != null)
               {
                  strUpdateSQL += ",LZZZ='" + model.LZZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CHZHQQK") == true && model.CHZHQQK != null)
               {
                  strUpdateSQL += ",CHZHQQK='" + model.CHZHQQK.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CHZHQQKDH") == true && model.CHZHQQKDH != null)
               {
                  strUpdateSQL += ",CHZHQQKDH='" + model.CHZHQQKDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PQHCLZZ") == true && model.PQHCLZZ != null)
               {
                  strUpdateSQL += ",PQHCLZZ='" + model.PQHCLZZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PQHCLZZDH") == true && model.PQHCLZZDH != null)
               {
                  strUpdateSQL += ",PQHCLZZDH='" + model.PQHCLZZDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GXRQ") == true && model.GXRQ != null)
               {
                  strUpdateSQL += ",GXRQ='" + model.GXRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JZZZWZ") == true && model.JZZZWZ != null)
               {
                  strUpdateSQL += ",JZZZWZ='" + model.JZZZWZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYXM_EX") == true && model.JYXM_EX != null)
               {
                  strUpdateSQL += ",JYXM_EX='" + model.JYXM_EX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZZS") == true && model.ZZS != null)
               {
                  strUpdateSQL += ",ZZS='" + model.ZZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLCJCLSH") == true && model.GLCJCLSH != null)
               {
                  strUpdateSQL += ",GLCJCLSH='" + model.GLCJCLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLCHPZL") == true && model.GLCHPZL != null)
               {
                  strUpdateSQL += ",GLCHPZL='" + model.GLCHPZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLCHPZLDH") == true && model.GLCHPZLDH != null)
               {
                  strUpdateSQL += ",GLCHPZLDH='" + model.GLCHPZLDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LWCXWZJL") == true && model.LWCXWZJL != null)
               {
                  strUpdateSQL += ",LWCXWZJL='" + model.LWCXWZJL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SFSQCLC") == true && model.SFSQCLC != null)
               {
                  strUpdateSQL += ",SFSQCLC='" + model.SFSQCLC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GLCJYXM") == true && model.GLCJYXM != null)
               {
                  strUpdateSQL += ",GLCJYXM='" + model.GLCJYXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LWCXWZJLDH") == true && model.LWCXWZJLDH != null)
               {
                  strUpdateSQL += ",LWCXWZJLDH='" + model.LWCXWZJLDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HDZH") == true && model.HDZH != null)
               {
                  strUpdateSQL += ",HDZH='" + model.HDZH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("EDNJGL") == true && model.EDNJGL != null)
               {
                  strUpdateSQL += ",EDNJGL='" + model.EDNJGL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FWQ_ZYXZ") == true && model.FWQ_ZYXZ != null)
               {
                  strUpdateSQL += ",FWQ_ZYXZ='" + model.FWQ_ZYXZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DSBH") == true && model.DSBH != null)
               {
                  strUpdateSQL += ",DSBH='" + model.DSBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBSB") == true && model.JCBSB != null)
               {
                  strUpdateSQL += ",JCBSB='" + model.JCBSB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBXH") == true && model.JCBXH != null)
               {
                  strUpdateSQL += ",JCBXH='" + model.JCBXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBAZRQ") == true && model.JCBAZRQ != null)
               {
                  strUpdateSQL += ",JCBAZRQ='" + model.JCBAZRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBDYJSB") == true && model.JCBDYJSB != null)
               {
                  strUpdateSQL += ",JCBDYJSB='" + model.JCBDYJSB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBDYJXH") == true && model.JCBDYJXH != null)
               {
                  strUpdateSQL += ",JCBDYJXH='" + model.JCBDYJXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JCBAZGS") == true && model.JCBAZGS != null)
               {
                  strUpdateSQL += ",JCBAZGS='" + model.JCBAZGS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LWLRLSH") == true && model.LWLRLSH != null)
               {
                  strUpdateSQL += ",LWLRLSH='" + model.LWLRLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LWLRHENF") == true && model.LWLRHENF != null)
               {
                  strUpdateSQL += ",LWLRHENF='" + model.LWLRHENF.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("REPORT_JYXM") == true && model.REPORT_JYXM != null)
               {
                  strUpdateSQL += ",REPORT_JYXM='" + model.REPORT_JYXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LTGGLX") == true && model.LTGGLX != null)
               {
                  strUpdateSQL += ",LTGGLX='" + model.LTGGLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("LTGGLXDH") == true && model.LTGGLXDH != null)
               {
                  strUpdateSQL += ",LTGGLXDH='" + model.LTGGLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QDZKZZL") == true && model.QDZKZZL != null)
               {
                  strUpdateSQL += ",QDZKZZL='" + model.QDZKZZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCZS") == true && model.GCZS != null)
               {
                  strUpdateSQL += ",GCZS='" + model.GCZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HCCSXS") == true && model.HCCSXS != null)
               {
                  strUpdateSQL += ",HCCSXS='" + model.HCCSXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YWLX") == true && model.YWLX != null)
               {
                  strUpdateSQL += ",YWLX='" + model.YWLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KCLXDJ") == true && model.KCLXDJ != null)
               {
                  strUpdateSQL += ",KCLXDJ='" + model.KCLXDJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YXSSZJ") == true && model.YXSSZJ != null)
               {
                  strUpdateSQL += ",YXSSZJ='" + model.YXSSZJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCYYZH") == true && model.GCYYZH != null)
               {
                  strUpdateSQL += ",GCYYZH='" + model.GCYYZH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCYXSSZJ") == true && model.GCYXSSZJ != null)
               {
                  strUpdateSQL += ",GCYXSSZJ='" + model.GCYXSSZJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AJJCCS") == true && model.AJJCCS != null)
               {
                  strUpdateSQL += ",AJJCCS=" + model.AJJCCS + "";
               }

               if(model.Changed("ZJJCCS") == true && model.ZJJCCS != null)
               {
                  strUpdateSQL += ",ZJJCCS=" + model.ZJJCCS + "";
               }

               if(model.Changed("WJJCCS") == true && model.WJJCCS != null)
               {
                  strUpdateSQL += ",WJJCCS=" + model.WJJCCS + "";
               }

               if(model.Changed("MTCSFDJSS") == true && model.MTCSFDJSS != null)
               {
                  strUpdateSQL += ",MTCSFDJSS='" + model.MTCSFDJSS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("MTCSFDJSSDH") == true && model.MTCSFDJSSDH != null)
               {
                  strUpdateSQL += ",MTCSFDJSSDH='" + model.MTCSFDJSSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYWLB") == true && model.ZYWLB != null)
               {
                  strUpdateSQL += ",ZYWLB='" + model.ZYWLB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZYWLBDH") == true && model.ZYWLBDH != null)
               {
                  strUpdateSQL += ",ZYWLBDH='" + model.ZYWLBDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AJ_Z_PD") == true && model.AJ_Z_PD != null)
               {
                  strUpdateSQL += ",AJ_Z_PD='" + model.AJ_Z_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJ_Z_PD") == true && model.ZJ_Z_PD != null)
               {
                  strUpdateSQL += ",ZJ_Z_PD='" + model.ZJ_Z_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WQ_Z_PD") == true && model.WQ_Z_PD != null)
               {
                  strUpdateSQL += ",WQ_Z_PD='" + model.WQ_Z_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QT_Z_PD") == true && model.QT_Z_PD != null)
               {
                  strUpdateSQL += ",QT_Z_PD='" + model.QT_Z_PD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("AJ_FJXM") == true && model.AJ_FJXM != null)
               {
                  strUpdateSQL += ",AJ_FJXM='" + model.AJ_FJXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJ_FJXM") == true && model.ZJ_FJXM != null)
               {
                  strUpdateSQL += ",ZJ_FJXM='" + model.ZJ_FJXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WQ_FJXM") == true && model.WQ_FJXM != null)
               {
                  strUpdateSQL += ",WQ_FJXM='" + model.WQ_FJXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QT_FJXM") == true && model.QT_FJXM != null)
               {
                  strUpdateSQL += ",QT_FJXM='" + model.QT_FJXM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYLB_TYPE") == true && model.JYLB_TYPE != null)
               {
                  strUpdateSQL += ",JYLB_TYPE='" + model.JYLB_TYPE.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLSSLB") == true && model.CLSSLB != null)
               {
                  strUpdateSQL += ",CLSSLB='" + model.CLSSLB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLSSLBDH") == true && model.CLSSLBDH != null)
               {
                  strUpdateSQL += ",CLSSLBDH='" + model.CLSSLBDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SYRSFZ") == true && model.SYRSFZ != null)
               {
                  strUpdateSQL += ",SYRSFZ='" + model.SYRSFZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJJYRQ") == true && model.ZJJYRQ != null)
               {
                  strUpdateSQL += ",ZJJYRQ='" + model.ZJJYRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BXZZRQ") == true && model.BXZZRQ != null)
               {
                  strUpdateSQL += ",BXZZRQ='" + model.BXZZRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYYXQZ") == true && model.JYYXQZ != null)
               {
                  strUpdateSQL += ",JYYXQZ='" + model.JYYXQZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLYTDH") == true && model.CLYTDH != null)
               {
                  strUpdateSQL += ",CLYTDH='" + model.CLYTDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YTSXDH") == true && model.YTSXDH != null)
               {
                  strUpdateSQL += ",YTSXDH='" + model.YTSXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BZZXS") == true && model.BZZXS != null)
               {
                  strUpdateSQL += ",BZZXS='" + model.BZZXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BZZXSDH") == true && model.BZZXSDH != null)
               {
                  strUpdateSQL += ",BZZXSDH='" + model.BZZXSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JYXM_LW") == true && model.JYXM_LW != null)
               {
                  strUpdateSQL += ",JYXM_LW='" + model.JYXM_LW.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCPZH") == true && model.GCPZH != null)
               {
                  strUpdateSQL += ",GCPZH='" + model.GCPZH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCLX") == true && model.GCLX != null)
               {
                  strUpdateSQL += ",GCLX='" + model.GCLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCLXDH") == true && model.GCLXDH != null)
               {
                  strUpdateSQL += ",GCLXDH='" + model.GCLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QYCMZZZL") == true && model.QYCMZZZL != null)
               {
                  strUpdateSQL += ",QYCMZZZL='" + model.QYCMZZZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DCZS") == true && model.DCZS != null)
               {
                  strUpdateSQL += ",DCZS='" + model.DCZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("XZQY") == true && model.XZQY != null)
               {
                  strUpdateSQL += ",XZQY='" + model.XZQY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZCLBGD") == true && model.ZCLBGD != null)
               {
                  strUpdateSQL += ",ZCLBGD='" + model.ZCLBGD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCLBGD") == true && model.GCLBGD != null)
               {
                  strUpdateSQL += ",GCLBGD='" + model.GCLBGD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCCSC") == true && model.GCCSC != null)
               {
                  strUpdateSQL += ",GCCSC='" + model.GCCSC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCCSK") == true && model.GCCSK != null)
               {
                  strUpdateSQL += ",GCCSK='" + model.GCCSK.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCCSG") == true && model.GCCSG != null)
               {
                  strUpdateSQL += ",GCCSG='" + model.GCCSG.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCBZZXS") == true && model.GCBZZXS != null)
               {
                  strUpdateSQL += ",GCBZZXS='" + model.GCBZZXS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCBZZXSDH") == true && model.GCBZZXSDH != null)
               {
                  strUpdateSQL += ",GCBZZXSDH='" + model.GCBZZXSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJCLLX") == true && model.ZJCLLX != null)
               {
                  strUpdateSQL += ",ZJCLLX='" + model.ZJCLLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZJCLLXDH") == true && model.ZJCLLXDH != null)
               {
                  strUpdateSQL += ",ZJCLLXDH='" + model.ZJCLLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SFSWPC") == true && model.SFSWPC != null)
               {
                  strUpdateSQL += ",SFSWPC='" + model.SFSWPC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DLYSZH") == true && model.DLYSZH != null)
               {
                  strUpdateSQL += ",DLYSZH='" + model.DLYSZH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SFSGSQC") == true && model.SFSGSQC != null)
               {
                  strUpdateSQL += ",SFSGSQC='" + model.SFSGSQC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLCCLX") == true && model.CLCCLX != null)
               {
                  strUpdateSQL += ",CLCCLX='" + model.CLCCLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLCCLXDH") == true && model.CLCCLXDH != null)
               {
                  strUpdateSQL += ",CLCCLXDH='" + model.CLCCLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DWS") == true && model.DWS != null)
               {
                  strUpdateSQL += ",DWS='" + model.DWS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HCCSXSDH") == true && model.HCCSXSDH != null)
               {
                  strUpdateSQL += ",HCCSXSDH='" + model.HCCSXSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KCLXDJDH") == true && model.KCLXDJDH != null)
               {
                  strUpdateSQL += ",KCLXDJDH='" + model.KCLXDJDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("KCCC") == true && model.KCCC != null)
               {
                  strUpdateSQL += ",KCCC='" + model.KCCC.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCYXXSZJ") == true && model.GCYXXSZJ != null)
               {
                  strUpdateSQL += ",GCYXXSZJ='" + model.GCYXXSZJ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCVIN") == true && model.GCVIN != null)
               {
                  strUpdateSQL += ",GCVIN='" + model.GCVIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCCCDJRQ") == true && model.GCCCDJRQ != null)
               {
                  strUpdateSQL += ",GCCCDJRQ='" + model.GCCCDJRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCCCRQ") == true && model.GCCCRQ != null)
               {
                  strUpdateSQL += ",GCCCRQ='" + model.GCCCRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("GCPPXH") == true && model.GCPPXH != null)
               {
                  strUpdateSQL += ",GCPPXH='" + model.GCPPXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Z_RESULT") == true && model.Z_RESULT != null)
               {
                  strUpdateSQL += ",Z_RESULT='" + model.Z_RESULT.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HPYS") == true && model.HPYS != null)
               {
                  strUpdateSQL += ",HPYS='" + model.HPYS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("HPYSDH") == true && model.HPYSDH != null)
               {
                  strUpdateSQL += ",HPYSDH='" + model.HPYSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DGSFZXTS") == true && model.DGSFZXTS != null)
               {
                  strUpdateSQL += ",DGSFZXTS='" + model.DGSFZXTS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DGSFZXTSDH") == true && model.DGSFZXTSDH != null)
               {
                  strUpdateSQL += ",DGSFZXTSDH='" + model.DGSFZXTSDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("ZDJGL") == true && model.ZDJGL != null)
               {
                  strUpdateSQL += ",ZDJGL='" + model.ZDJGL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BGDBH") == true && model.BGDBH != null)
               {
                  strUpdateSQL += ",BGDBH='" + model.BGDBH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("BGDJYM") == true && model.BGDJYM != null)
               {
                  strUpdateSQL += ",BGDJYM='" + model.BGDJYM.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SZDQLX") == true && model.SZDQLX != null)
               {
                  strUpdateSQL += ",SZDQLX='" + model.SZDQLX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("SZDQLXDH") == true && model.SZDQLXDH != null)
               {
                  strUpdateSQL += ",SZDQLXDH='" + model.SZDQLXDH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("YYZHCLRQ") == true && model.YYZHCLRQ != null)
               {
                  strUpdateSQL += ",YYZHCLRQ='" + model.YYZHCLRQ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PFLSH") == true && model.PFLSH != null)
               {
                  strUpdateSQL += ",PFLSH='" + model.PFLSH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DDJXH") == true && model.DDJXH != null)
               {
                  strUpdateSQL += ",DDJXH='" + model.DDJXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CNZZXH") == true && model.CNZZXH != null)
               {
                  strUpdateSQL += ",CNZZXH='" + model.CNZZXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("DCRL") == true && model.DCRL != null)
               {
                  strUpdateSQL += ",DCRL='" + model.DCRL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsTrainMode") == true && model.IsTrainMode != null)
               {
                  strUpdateSQL += ",IsTrainMode=" + model.IsTrainMode + "";
               }

               if(model.Changed("IsOBD") == true && model.IsOBD != null)
               {
                  strUpdateSQL += ",IsOBD=" + model.IsOBD + "";
               }

               if(model.Changed("OBDWZ") == true && model.OBDWZ != null)
               {
                  strUpdateSQL += ",OBDWZ='" + model.OBDWZ.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsDPF") == true && model.IsDPF != null)
               {
                  strUpdateSQL += ",IsDPF=" + model.IsDPF + "";
               }

               if(model.Changed("DPFXH") == true && model.DPFXH != null)
               {
                  strUpdateSQL += ",DPFXH='" + model.DPFXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsSCR") == true && model.IsSCR != null)
               {
                  strUpdateSQL += ",IsSCR=" + model.IsSCR + "";
               }

               if(model.Changed("SCRXH") == true && model.SCRXH != null)
               {
                  strUpdateSQL += ",SCRXH='" + model.SCRXH.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QZJCDGGP") == true && model.QZJCDGGP != null)
               {
                  strUpdateSQL += ",QZJCDGGP='" + model.QZJCDGGP.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBDJYY") == true && model.OBDJYY != null)
               {
                  strUpdateSQL += ",OBDJYY='" + model.OBDJYY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("WQYCY") == true && model.WQYCY != null)
               {
                  strUpdateSQL += ",WQYCY='" + model.WQYCY.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBDCommCL") == true && model.OBDCommCL != null)
               {
                  strUpdateSQL += ",OBDCommCL='" + model.OBDCommCL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBDCommCX") == true && model.OBDCommCX != null)
               {
                  strUpdateSQL += ",OBDCommCX='" + model.OBDCommCX.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("Standard") == true && model.Standard != null)
               {
                  strUpdateSQL += ",Standard='" + model.Standard.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("VehicleKind") == true && model.VehicleKind != null)
               {
                  strUpdateSQL += ",VehicleKind='" + model.VehicleKind.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsEFI") == true && model.IsEFI != null)
               {
                  strUpdateSQL += ",IsEFI='" + model.IsEFI.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("IsAsm") == true && model.IsAsm != null)
               {
                  strUpdateSQL += ",IsAsm='" + model.IsAsm.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OBDOutlookID") == true && model.OBDOutlookID != null)
               {
                  strUpdateSQL += ",OBDOutlookID='" + model.OBDOutlookID.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("OutlookID") == true && model.OutlookID != null)
               {
                  strUpdateSQL += ",OutlookID='" + model.OutlookID.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("VEHICLE_DATA") == true && model.VEHICLE_DATA != null)
               {
                  strUpdateSQL += ",VEHICLE_DATA='" + model.VEHICLE_DATA.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QDZS") == true && model.QDZS != null)
               {
                  strUpdateSQL += ",QDZS='" + model.QDZS.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("sunVIN") == true && model.sunVIN != null)
               {
                  strUpdateSQL += ",sunVIN='" + model.sunVIN.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("PQGSL") == true && model.PQGSL != null)
               {
                  strUpdateSQL += ",PQGSL='" + model.PQGSL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("JZZL") == true && model.JZZL != null)
               {
                  strUpdateSQL += ",JZZL='" + model.JZZL.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("CLPFJD") == true && model.CLPFJD != null)
               {
                  strUpdateSQL += ",CLPFJD='" + model.CLPFJD.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("FDJSB") == true && model.FDJSB != null)
               {
                  strUpdateSQL += ",FDJSB='" + model.FDJSB.ToString().Replace("'","''") + "'";
               }

               if(model.Changed("QDZW") == true && model.QDZW != null)
               {
                  strUpdateSQL += ",QDZW='" + model.QDZW.ToString().Replace("'","''") + "'";
               }

              string strSql = "";
              strSql += "update RESULT_VEHICLE_INFO set ";
              strSql += strUpdateSQL.Substring(1);
              strSql += " where " + p_strWhere;

              return strSql;
          }

          /// <summary>
          /// 修改一个集合
          /// </summary>
          public bool UpdateRange(RESULT_VEHICLE_INFO model, string p_strWhere)
          {
              return DbHelper.ExecuteSql(Conn, UpdateRangeSQL(model, p_strWhere));
          }

          /// <summary>
          /// 修改全部数据 SQL
          /// </summary>
          public string UpdateAllSQL(RESULT_VEHICLE_INFO model)
          {
              string strUpdateSQL = "";

                  strUpdateSQL += ",JCXH=" + model.JCXH + "";
                  strUpdateSQL += ",JCXHMS='" + model.JCXHMS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCCS=" + model.JCCS + "";
                  strUpdateSQL += ",JCLSH='" + model.JCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYXM='" + model.JYXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YJXM='" + model.YJXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FJXM='" + model.FJXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Z_PD='" + model.Z_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsUpload=" + model.IsUpload + "";
                  strUpdateSQL += ",IsAudit=" + model.IsAudit + "";
                  strUpdateSQL += ",IsPrint=" + model.IsPrint + "";
                  strUpdateSQL += ",WQLSH='" + model.WQLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AJLSH='" + model.AJLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJLSH='" + model.ZJLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",MTLSH='" + model.MTLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBGDBH01='" + model.JCBGDBH01.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBGDBH02='" + model.JCBGDBH02.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HPHM='" + model.HPHM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HPZL='" + model.HPZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HPZLDH='" + model.HPZLDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLCHPHM='" + model.GLCHPHM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",VIN='" + model.VIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYLB='" + model.JYLB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYLBDH='" + model.JYLBDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJH='" + model.FDJH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJXH='" + model.FDJXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJZZCS='" + model.FDJZZCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DPXH='" + model.DPXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PP='" + model.PP.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLZZCS='" + model.CLZZCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",XH='" + model.XH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PPXH='" + model.PPXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QDXS='" + model.QDXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QDXSDH='" + model.QDXSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QDZWZ='" + model.QDZWZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZCZWZ='" + model.ZCZWZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QZDZ='" + model.QZDZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QZDZDH='" + model.QZDZDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YGGSNFKT='" + model.YGGSNFKT.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YGGSNFKTDH='" + model.YGGSNFKTDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RLLB='" + model.RLLB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RLLBDH='" + model.RLLBDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",RYBH='" + model.RYBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GYFS='" + model.GYFS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GYFSDH='" + model.GYFSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CCDJRQ='" + model.CCDJRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CCRQ='" + model.CCRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZBZL='" + model.ZBZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZZL='" + model.ZZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CYS='" + model.CYS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CSYS='" + model.CSYS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZDFS='" + model.ZDFS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZDFSDH='" + model.ZDFSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLZL='" + model.CLZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLZLDH='" + model.CLZLDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZXZXJXS='" + model.ZXZXJXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZXZXJXSDH='" + model.ZXZXJXSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZXZLX='" + model.ZXZLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZXZLXDH='" + model.ZXZLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZGSJCS='" + model.ZGSJCS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EDGL='" + model.EDGL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EDZS='" + model.EDZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EDNJZS='" + model.EDNJZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EDNJ='" + model.EDNJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EDYH='" + model.EDYH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JQFS='" + model.JQFS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JQFSDH='" + model.JQFSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJPL='" + model.FDJPL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJGS='" + model.FDJGS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJCC='" + model.FDJCC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BSXLX='" + model.BSXLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BSXLXDH='" + model.BSXLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CXXL='" + model.CXXL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CXXLDH='" + model.CXXLDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LJXSLC='" + model.LJXSLC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LTQY='" + model.LTQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LTGG='" + model.LTGG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LTSL='" + model.LTSL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SYXZ='" + model.SYXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SYXZDH='" + model.SYXZDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YYZH='" + model.YYZH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SJDW='" + model.SJDW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SYR='" + model.SYR.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LXDH='" + model.LXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LXDZ='" + model.LXDZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YZBH='" + model.YZBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCRQ='" + model.JCRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DLRQ='" + model.DLRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLSXSJ='" + model.CLSXSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLXXSJ='" + model.CLXXSJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DLY='" + model.DLY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YCY='" + model.YCY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WGJYY='" + model.WGJYY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DPJYY='" + model.DPJYY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DTDPJYY='" + model.DTDPJYY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LSJYY='" + model.LSJYY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SQQZR='" + model.SQQZR.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WQCZY='" + model.WQCZY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CSC='" + model.CSC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CSK='" + model.CSK.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CSG='" + model.CSG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJ='" + model.ZJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YZLJ='" + model.YZLJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EZLJ='" + model.EZLJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SZLJ='" + model.SZLJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SIZLJ='" + model.SIZLJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WZLJ='" + model.WZLJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LZLJ='" + model.LZLJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YZZLZ='" + model.YZZLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YZYLZ='" + model.YZYLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YZZZ='" + model.YZZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EZZLZ='" + model.EZZLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EZYLZ='" + model.EZYLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EZZZ='" + model.EZZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SZZLZ='" + model.SZZLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SZYLZ='" + model.SZYLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SZZZ='" + model.SZZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SIZZLZ='" + model.SIZZLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SIZYLZ='" + model.SIZYLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SIZZZ='" + model.SIZZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WZZLZ='" + model.WZZLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WZYLZ='" + model.WZYLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WZZZ='" + model.WZZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LZZLZ='" + model.LZZLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LZYLZ='" + model.LZYLZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LZZZ='" + model.LZZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CHZHQQK='" + model.CHZHQQK.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CHZHQQKDH='" + model.CHZHQQKDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PQHCLZZ='" + model.PQHCLZZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PQHCLZZDH='" + model.PQHCLZZDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GXRQ='" + model.GXRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JZZZWZ='" + model.JZZZWZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYXM_EX='" + model.JYXM_EX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZZS='" + model.ZZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLCJCLSH='" + model.GLCJCLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLCHPZL='" + model.GLCHPZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLCHPZLDH='" + model.GLCHPZLDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LWCXWZJL='" + model.LWCXWZJL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SFSQCLC='" + model.SFSQCLC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GLCJYXM='" + model.GLCJYXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LWCXWZJLDH='" + model.LWCXWZJLDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HDZH='" + model.HDZH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",EDNJGL='" + model.EDNJGL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FWQ_ZYXZ='" + model.FWQ_ZYXZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DSBH='" + model.DSBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBSB='" + model.JCBSB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBXH='" + model.JCBXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBAZRQ='" + model.JCBAZRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBDYJSB='" + model.JCBDYJSB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBDYJXH='" + model.JCBDYJXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JCBAZGS='" + model.JCBAZGS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LWLRLSH='" + model.LWLRLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LWLRHENF='" + model.LWLRHENF.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",REPORT_JYXM='" + model.REPORT_JYXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LTGGLX='" + model.LTGGLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",LTGGLXDH='" + model.LTGGLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QDZKZZL='" + model.QDZKZZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCZS='" + model.GCZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HCCSXS='" + model.HCCSXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YWLX='" + model.YWLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KCLXDJ='" + model.KCLXDJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YXSSZJ='" + model.YXSSZJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCYYZH='" + model.GCYYZH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCYXSSZJ='" + model.GCYXSSZJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AJJCCS=" + model.AJJCCS + "";
                  strUpdateSQL += ",ZJJCCS=" + model.ZJJCCS + "";
                  strUpdateSQL += ",WJJCCS=" + model.WJJCCS + "";
                  strUpdateSQL += ",MTCSFDJSS='" + model.MTCSFDJSS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",MTCSFDJSSDH='" + model.MTCSFDJSSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYWLB='" + model.ZYWLB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZYWLBDH='" + model.ZYWLBDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AJ_Z_PD='" + model.AJ_Z_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJ_Z_PD='" + model.ZJ_Z_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WQ_Z_PD='" + model.WQ_Z_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QT_Z_PD='" + model.QT_Z_PD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",AJ_FJXM='" + model.AJ_FJXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJ_FJXM='" + model.ZJ_FJXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WQ_FJXM='" + model.WQ_FJXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QT_FJXM='" + model.QT_FJXM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYLB_TYPE='" + model.JYLB_TYPE.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLSSLB='" + model.CLSSLB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLSSLBDH='" + model.CLSSLBDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SYRSFZ='" + model.SYRSFZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJJYRQ='" + model.ZJJYRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BXZZRQ='" + model.BXZZRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYYXQZ='" + model.JYYXQZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLYTDH='" + model.CLYTDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YTSXDH='" + model.YTSXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BZZXS='" + model.BZZXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BZZXSDH='" + model.BZZXSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JYXM_LW='" + model.JYXM_LW.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCPZH='" + model.GCPZH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCLX='" + model.GCLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCLXDH='" + model.GCLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QYCMZZZL='" + model.QYCMZZZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DCZS='" + model.DCZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",XZQY='" + model.XZQY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZCLBGD='" + model.ZCLBGD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCLBGD='" + model.GCLBGD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCCSC='" + model.GCCSC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCCSK='" + model.GCCSK.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCCSG='" + model.GCCSG.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCBZZXS='" + model.GCBZZXS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCBZZXSDH='" + model.GCBZZXSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJCLLX='" + model.ZJCLLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZJCLLXDH='" + model.ZJCLLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SFSWPC='" + model.SFSWPC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DLYSZH='" + model.DLYSZH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SFSGSQC='" + model.SFSGSQC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLCCLX='" + model.CLCCLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLCCLXDH='" + model.CLCCLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DWS='" + model.DWS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HCCSXSDH='" + model.HCCSXSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KCLXDJDH='" + model.KCLXDJDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",KCCC='" + model.KCCC.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCYXXSZJ='" + model.GCYXXSZJ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCVIN='" + model.GCVIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCCCDJRQ='" + model.GCCCDJRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCCCRQ='" + model.GCCCRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",GCPPXH='" + model.GCPPXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Z_RESULT='" + model.Z_RESULT.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HPYS='" + model.HPYS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",HPYSDH='" + model.HPYSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DGSFZXTS='" + model.DGSFZXTS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DGSFZXTSDH='" + model.DGSFZXTSDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",ZDJGL='" + model.ZDJGL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BGDBH='" + model.BGDBH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",BGDJYM='" + model.BGDJYM.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SZDQLX='" + model.SZDQLX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",SZDQLXDH='" + model.SZDQLXDH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",YYZHCLRQ='" + model.YYZHCLRQ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PFLSH='" + model.PFLSH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DDJXH='" + model.DDJXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CNZZXH='" + model.CNZZXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",DCRL='" + model.DCRL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsTrainMode=" + model.IsTrainMode + "";
                  strUpdateSQL += ",IsOBD=" + model.IsOBD + "";
                  strUpdateSQL += ",OBDWZ='" + model.OBDWZ.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsDPF=" + model.IsDPF + "";
                  strUpdateSQL += ",DPFXH='" + model.DPFXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsSCR=" + model.IsSCR + "";
                  strUpdateSQL += ",SCRXH='" + model.SCRXH.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QZJCDGGP='" + model.QZJCDGGP.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBDJYY='" + model.OBDJYY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",WQYCY='" + model.WQYCY.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBDCommCL='" + model.OBDCommCL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBDCommCX='" + model.OBDCommCX.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",Standard='" + model.Standard.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",VehicleKind='" + model.VehicleKind.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsEFI='" + model.IsEFI.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",IsAsm='" + model.IsAsm.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OBDOutlookID='" + model.OBDOutlookID.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",OutlookID='" + model.OutlookID.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",VEHICLE_DATA='" + model.VEHICLE_DATA.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QDZS='" + model.QDZS.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",sunVIN='" + model.sunVIN.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",PQGSL='" + model.PQGSL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",JZZL='" + model.JZZL.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",CLPFJD='" + model.CLPFJD.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",FDJSB='" + model.FDJSB.ToString().Replace("'","''") + "'";
                  strUpdateSQL += ",QDZW='" + model.QDZW.ToString().Replace("'","''") + "'";


               string strSql = "";
               strSql += "update RESULT_VEHICLE_INFO set ";
               strSql += strUpdateSQL.Substring(1);

               return strSql;

          }

          /// <summary>
          /// 修改全部数据
          /// </summary>
          public bool UpdateAll(RESULT_VEHICLE_INFO model)
          {
              return DbHelper.ExecuteSql(Conn, UpdateAllSQL(model));
          }

          /// <summary>
          /// 删除一条数据 SQL
          /// </summary>
          public string DeleteSQL(string strJCLSH)
          {
              string strSql = "";
              strSql += "delete from RESULT_VEHICLE_INFO";
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
              strSql += "delete from RESULT_VEHICLE_INFO";
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
              strSql += "delete from RESULT_VEHICLE_INFO";

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
         public RESULT_VEHICLE_INFO GetModel(string strJCLSH)
         {
             string strSql = "";
             strSql += "select * from RESULT_VEHICLE_INFO";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

             DataTable dtTemp = new DataTable();
             DbHelper.GetTable(Conn, strSql, ref dtTemp);

             RESULT_VEHICLE_INFO model = new RESULT_VEHICLE_INFO();

             if(dtTemp.Rows.Count>0)
             {
                 model = new RESULT_VEHICLE_INFO();

                 model.ID = dtTemp.Rows[0]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ID"]);
                 model.JCXH = dtTemp.Rows[0]["JCXH"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["JCXH"]);
                 model.JCXHMS = dtTemp.Rows[0]["JCXHMS"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCXHMS"].ToString();
                 model.JCCS = dtTemp.Rows[0]["JCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["JCCS"]);
                 model.JCLSH = dtTemp.Rows[0]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCLSH"].ToString();
                 model.JYXM = dtTemp.Rows[0]["JYXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYXM"].ToString();
                 model.YJXM = dtTemp.Rows[0]["YJXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["YJXM"].ToString();
                 model.FJXM = dtTemp.Rows[0]["FJXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["FJXM"].ToString();
                 model.Z_PD = dtTemp.Rows[0]["Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["Z_PD"].ToString();
                 model.IsUpload = dtTemp.Rows[0]["IsUpload"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsUpload"]);
                 model.IsAudit = dtTemp.Rows[0]["IsAudit"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsAudit"]);
                 model.IsPrint = dtTemp.Rows[0]["IsPrint"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsPrint"]);
                 model.WQLSH = dtTemp.Rows[0]["WQLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["WQLSH"].ToString();
                 model.AJLSH = dtTemp.Rows[0]["AJLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["AJLSH"].ToString();
                 model.ZJLSH = dtTemp.Rows[0]["ZJLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJLSH"].ToString();
                 model.MTLSH = dtTemp.Rows[0]["MTLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["MTLSH"].ToString();
                 model.JCBGDBH01 = dtTemp.Rows[0]["JCBGDBH01"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBGDBH01"].ToString();
                 model.JCBGDBH02 = dtTemp.Rows[0]["JCBGDBH02"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBGDBH02"].ToString();
                 model.HPHM = dtTemp.Rows[0]["HPHM"] == DBNull.Value ? "" : dtTemp.Rows[0]["HPHM"].ToString();
                 model.HPZL = dtTemp.Rows[0]["HPZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["HPZL"].ToString();
                 model.HPZLDH = dtTemp.Rows[0]["HPZLDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["HPZLDH"].ToString();
                 model.GLCHPHM = dtTemp.Rows[0]["GLCHPHM"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLCHPHM"].ToString();
                 model.VIN = dtTemp.Rows[0]["VIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["VIN"].ToString();
                 model.JYLB = dtTemp.Rows[0]["JYLB"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYLB"].ToString();
                 model.JYLBDH = dtTemp.Rows[0]["JYLBDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYLBDH"].ToString();
                 model.FDJH = dtTemp.Rows[0]["FDJH"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJH"].ToString();
                 model.FDJXH = dtTemp.Rows[0]["FDJXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJXH"].ToString();
                 model.FDJZZCS = dtTemp.Rows[0]["FDJZZCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJZZCS"].ToString();
                 model.DPXH = dtTemp.Rows[0]["DPXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["DPXH"].ToString();
                 model.PP = dtTemp.Rows[0]["PP"] == DBNull.Value ? "" : dtTemp.Rows[0]["PP"].ToString();
                 model.CLZZCS = dtTemp.Rows[0]["CLZZCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLZZCS"].ToString();
                 model.XH = dtTemp.Rows[0]["XH"] == DBNull.Value ? "" : dtTemp.Rows[0]["XH"].ToString();
                 model.PPXH = dtTemp.Rows[0]["PPXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["PPXH"].ToString();
                 model.QDXS = dtTemp.Rows[0]["QDXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["QDXS"].ToString();
                 model.QDXSDH = dtTemp.Rows[0]["QDXSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["QDXSDH"].ToString();
                 model.QDZWZ = dtTemp.Rows[0]["QDZWZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["QDZWZ"].ToString();
                 model.ZCZWZ = dtTemp.Rows[0]["ZCZWZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZCZWZ"].ToString();
                 model.QZDZ = dtTemp.Rows[0]["QZDZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["QZDZ"].ToString();
                 model.QZDZDH = dtTemp.Rows[0]["QZDZDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["QZDZDH"].ToString();
                 model.YGGSNFKT = dtTemp.Rows[0]["YGGSNFKT"] == DBNull.Value ? "" : dtTemp.Rows[0]["YGGSNFKT"].ToString();
                 model.YGGSNFKTDH = dtTemp.Rows[0]["YGGSNFKTDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["YGGSNFKTDH"].ToString();
                 model.RLLB = dtTemp.Rows[0]["RLLB"] == DBNull.Value ? "" : dtTemp.Rows[0]["RLLB"].ToString();
                 model.RLLBDH = dtTemp.Rows[0]["RLLBDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["RLLBDH"].ToString();
                 model.RYBH = dtTemp.Rows[0]["RYBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["RYBH"].ToString();
                 model.GYFS = dtTemp.Rows[0]["GYFS"] == DBNull.Value ? "" : dtTemp.Rows[0]["GYFS"].ToString();
                 model.GYFSDH = dtTemp.Rows[0]["GYFSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GYFSDH"].ToString();
                 model.CCDJRQ = dtTemp.Rows[0]["CCDJRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CCDJRQ"].ToString();
                 model.CCRQ = dtTemp.Rows[0]["CCRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CCRQ"].ToString();
                 model.ZBZL = dtTemp.Rows[0]["ZBZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZBZL"].ToString();
                 model.ZZL = dtTemp.Rows[0]["ZZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZZL"].ToString();
                 model.CYS = dtTemp.Rows[0]["CYS"] == DBNull.Value ? "" : dtTemp.Rows[0]["CYS"].ToString();
                 model.CSYS = dtTemp.Rows[0]["CSYS"] == DBNull.Value ? "" : dtTemp.Rows[0]["CSYS"].ToString();
                 model.ZDFS = dtTemp.Rows[0]["ZDFS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZDFS"].ToString();
                 model.ZDFSDH = dtTemp.Rows[0]["ZDFSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZDFSDH"].ToString();
                 model.CLZL = dtTemp.Rows[0]["CLZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLZL"].ToString();
                 model.CLZLDH = dtTemp.Rows[0]["CLZLDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLZLDH"].ToString();
                 model.ZXZXJXS = dtTemp.Rows[0]["ZXZXJXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZXZXJXS"].ToString();
                 model.ZXZXJXSDH = dtTemp.Rows[0]["ZXZXJXSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZXZXJXSDH"].ToString();
                 model.ZXZLX = dtTemp.Rows[0]["ZXZLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZXZLX"].ToString();
                 model.ZXZLXDH = dtTemp.Rows[0]["ZXZLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZXZLXDH"].ToString();
                 model.ZGSJCS = dtTemp.Rows[0]["ZGSJCS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZGSJCS"].ToString();
                 model.EDGL = dtTemp.Rows[0]["EDGL"] == DBNull.Value ? "" : dtTemp.Rows[0]["EDGL"].ToString();
                 model.EDZS = dtTemp.Rows[0]["EDZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["EDZS"].ToString();
                 model.EDNJZS = dtTemp.Rows[0]["EDNJZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["EDNJZS"].ToString();
                 model.EDNJ = dtTemp.Rows[0]["EDNJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["EDNJ"].ToString();
                 model.EDYH = dtTemp.Rows[0]["EDYH"] == DBNull.Value ? "" : dtTemp.Rows[0]["EDYH"].ToString();
                 model.JQFS = dtTemp.Rows[0]["JQFS"] == DBNull.Value ? "" : dtTemp.Rows[0]["JQFS"].ToString();
                 model.JQFSDH = dtTemp.Rows[0]["JQFSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JQFSDH"].ToString();
                 model.FDJPL = dtTemp.Rows[0]["FDJPL"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJPL"].ToString();
                 model.FDJGS = dtTemp.Rows[0]["FDJGS"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJGS"].ToString();
                 model.FDJCC = dtTemp.Rows[0]["FDJCC"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJCC"].ToString();
                 model.BSXLX = dtTemp.Rows[0]["BSXLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["BSXLX"].ToString();
                 model.BSXLXDH = dtTemp.Rows[0]["BSXLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["BSXLXDH"].ToString();
                 model.CXXL = dtTemp.Rows[0]["CXXL"] == DBNull.Value ? "" : dtTemp.Rows[0]["CXXL"].ToString();
                 model.CXXLDH = dtTemp.Rows[0]["CXXLDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CXXLDH"].ToString();
                 model.LJXSLC = dtTemp.Rows[0]["LJXSLC"] == DBNull.Value ? "" : dtTemp.Rows[0]["LJXSLC"].ToString();
                 model.LTQY = dtTemp.Rows[0]["LTQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["LTQY"].ToString();
                 model.LTGG = dtTemp.Rows[0]["LTGG"] == DBNull.Value ? "" : dtTemp.Rows[0]["LTGG"].ToString();
                 model.LTSL = dtTemp.Rows[0]["LTSL"] == DBNull.Value ? "" : dtTemp.Rows[0]["LTSL"].ToString();
                 model.SYXZ = dtTemp.Rows[0]["SYXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SYXZ"].ToString();
                 model.SYXZDH = dtTemp.Rows[0]["SYXZDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SYXZDH"].ToString();
                 model.YYZH = dtTemp.Rows[0]["YYZH"] == DBNull.Value ? "" : dtTemp.Rows[0]["YYZH"].ToString();
                 model.SJDW = dtTemp.Rows[0]["SJDW"] == DBNull.Value ? "" : dtTemp.Rows[0]["SJDW"].ToString();
                 model.SYR = dtTemp.Rows[0]["SYR"] == DBNull.Value ? "" : dtTemp.Rows[0]["SYR"].ToString();
                 model.LXDH = dtTemp.Rows[0]["LXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["LXDH"].ToString();
                 model.LXDZ = dtTemp.Rows[0]["LXDZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LXDZ"].ToString();
                 model.YZBH = dtTemp.Rows[0]["YZBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["YZBH"].ToString();
                 model.JCRQ = dtTemp.Rows[0]["JCRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCRQ"].ToString();
                 model.DLRQ = dtTemp.Rows[0]["DLRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["DLRQ"].ToString();
                 model.CLSXSJ = dtTemp.Rows[0]["CLSXSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLSXSJ"].ToString();
                 model.CLXXSJ = dtTemp.Rows[0]["CLXXSJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLXXSJ"].ToString();
                 model.DLY = dtTemp.Rows[0]["DLY"] == DBNull.Value ? "" : dtTemp.Rows[0]["DLY"].ToString();
                 model.YCY = dtTemp.Rows[0]["YCY"] == DBNull.Value ? "" : dtTemp.Rows[0]["YCY"].ToString();
                 model.WGJYY = dtTemp.Rows[0]["WGJYY"] == DBNull.Value ? "" : dtTemp.Rows[0]["WGJYY"].ToString();
                 model.DPJYY = dtTemp.Rows[0]["DPJYY"] == DBNull.Value ? "" : dtTemp.Rows[0]["DPJYY"].ToString();
                 model.DTDPJYY = dtTemp.Rows[0]["DTDPJYY"] == DBNull.Value ? "" : dtTemp.Rows[0]["DTDPJYY"].ToString();
                 model.LSJYY = dtTemp.Rows[0]["LSJYY"] == DBNull.Value ? "" : dtTemp.Rows[0]["LSJYY"].ToString();
                 model.SQQZR = dtTemp.Rows[0]["SQQZR"] == DBNull.Value ? "" : dtTemp.Rows[0]["SQQZR"].ToString();
                 model.WQCZY = dtTemp.Rows[0]["WQCZY"] == DBNull.Value ? "" : dtTemp.Rows[0]["WQCZY"].ToString();
                 model.CSC = dtTemp.Rows[0]["CSC"] == DBNull.Value ? "" : dtTemp.Rows[0]["CSC"].ToString();
                 model.CSK = dtTemp.Rows[0]["CSK"] == DBNull.Value ? "" : dtTemp.Rows[0]["CSK"].ToString();
                 model.CSG = dtTemp.Rows[0]["CSG"] == DBNull.Value ? "" : dtTemp.Rows[0]["CSG"].ToString();
                 model.ZJ = dtTemp.Rows[0]["ZJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJ"].ToString();
                 model.YZLJ = dtTemp.Rows[0]["YZLJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["YZLJ"].ToString();
                 model.EZLJ = dtTemp.Rows[0]["EZLJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["EZLJ"].ToString();
                 model.SZLJ = dtTemp.Rows[0]["SZLJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SZLJ"].ToString();
                 model.SIZLJ = dtTemp.Rows[0]["SIZLJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SIZLJ"].ToString();
                 model.WZLJ = dtTemp.Rows[0]["WZLJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["WZLJ"].ToString();
                 model.LZLJ = dtTemp.Rows[0]["LZLJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LZLJ"].ToString();
                 model.YZZLZ = dtTemp.Rows[0]["YZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["YZZLZ"].ToString();
                 model.YZYLZ = dtTemp.Rows[0]["YZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["YZYLZ"].ToString();
                 model.YZZZ = dtTemp.Rows[0]["YZZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["YZZZ"].ToString();
                 model.EZZLZ = dtTemp.Rows[0]["EZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["EZZLZ"].ToString();
                 model.EZYLZ = dtTemp.Rows[0]["EZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["EZYLZ"].ToString();
                 model.EZZZ = dtTemp.Rows[0]["EZZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["EZZZ"].ToString();
                 model.SZZLZ = dtTemp.Rows[0]["SZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SZZLZ"].ToString();
                 model.SZYLZ = dtTemp.Rows[0]["SZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SZYLZ"].ToString();
                 model.SZZZ = dtTemp.Rows[0]["SZZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SZZZ"].ToString();
                 model.SIZZLZ = dtTemp.Rows[0]["SIZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SIZZLZ"].ToString();
                 model.SIZYLZ = dtTemp.Rows[0]["SIZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SIZYLZ"].ToString();
                 model.SIZZZ = dtTemp.Rows[0]["SIZZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SIZZZ"].ToString();
                 model.WZZLZ = dtTemp.Rows[0]["WZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["WZZLZ"].ToString();
                 model.WZYLZ = dtTemp.Rows[0]["WZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["WZYLZ"].ToString();
                 model.WZZZ = dtTemp.Rows[0]["WZZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["WZZZ"].ToString();
                 model.LZZLZ = dtTemp.Rows[0]["LZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LZZLZ"].ToString();
                 model.LZYLZ = dtTemp.Rows[0]["LZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LZYLZ"].ToString();
                 model.LZZZ = dtTemp.Rows[0]["LZZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["LZZZ"].ToString();
                 model.CHZHQQK = dtTemp.Rows[0]["CHZHQQK"] == DBNull.Value ? "" : dtTemp.Rows[0]["CHZHQQK"].ToString();
                 model.CHZHQQKDH = dtTemp.Rows[0]["CHZHQQKDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CHZHQQKDH"].ToString();
                 model.PQHCLZZ = dtTemp.Rows[0]["PQHCLZZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["PQHCLZZ"].ToString();
                 model.PQHCLZZDH = dtTemp.Rows[0]["PQHCLZZDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["PQHCLZZDH"].ToString();
                 model.GXRQ = dtTemp.Rows[0]["GXRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GXRQ"].ToString();
                 model.JZZZWZ = dtTemp.Rows[0]["JZZZWZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JZZZWZ"].ToString();
                 model.JYXM_EX = dtTemp.Rows[0]["JYXM_EX"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYXM_EX"].ToString();
                 model.ZZS = dtTemp.Rows[0]["ZZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZZS"].ToString();
                 model.GLCJCLSH = dtTemp.Rows[0]["GLCJCLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLCJCLSH"].ToString();
                 model.GLCHPZL = dtTemp.Rows[0]["GLCHPZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLCHPZL"].ToString();
                 model.GLCHPZLDH = dtTemp.Rows[0]["GLCHPZLDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLCHPZLDH"].ToString();
                 model.LWCXWZJL = dtTemp.Rows[0]["LWCXWZJL"] == DBNull.Value ? "" : dtTemp.Rows[0]["LWCXWZJL"].ToString();
                 model.SFSQCLC = dtTemp.Rows[0]["SFSQCLC"] == DBNull.Value ? "" : dtTemp.Rows[0]["SFSQCLC"].ToString();
                 model.GLCJYXM = dtTemp.Rows[0]["GLCJYXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["GLCJYXM"].ToString();
                 model.LWCXWZJLDH = dtTemp.Rows[0]["LWCXWZJLDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["LWCXWZJLDH"].ToString();
                 model.HDZH = dtTemp.Rows[0]["HDZH"] == DBNull.Value ? "" : dtTemp.Rows[0]["HDZH"].ToString();
                 model.EDNJGL = dtTemp.Rows[0]["EDNJGL"] == DBNull.Value ? "" : dtTemp.Rows[0]["EDNJGL"].ToString();
                 model.FWQ_ZYXZ = dtTemp.Rows[0]["FWQ_ZYXZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["FWQ_ZYXZ"].ToString();
                 model.DSBH = dtTemp.Rows[0]["DSBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["DSBH"].ToString();
                 model.JCBSB = dtTemp.Rows[0]["JCBSB"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBSB"].ToString();
                 model.JCBXH = dtTemp.Rows[0]["JCBXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBXH"].ToString();
                 model.JCBAZRQ = dtTemp.Rows[0]["JCBAZRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBAZRQ"].ToString();
                 model.JCBDYJSB = dtTemp.Rows[0]["JCBDYJSB"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBDYJSB"].ToString();
                 model.JCBDYJXH = dtTemp.Rows[0]["JCBDYJXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBDYJXH"].ToString();
                 model.JCBAZGS = dtTemp.Rows[0]["JCBAZGS"] == DBNull.Value ? "" : dtTemp.Rows[0]["JCBAZGS"].ToString();
                 model.LWLRLSH = dtTemp.Rows[0]["LWLRLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["LWLRLSH"].ToString();
                 model.LWLRHENF = dtTemp.Rows[0]["LWLRHENF"] == DBNull.Value ? "" : dtTemp.Rows[0]["LWLRHENF"].ToString();
                 model.REPORT_JYXM = dtTemp.Rows[0]["REPORT_JYXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["REPORT_JYXM"].ToString();
                 model.LTGGLX = dtTemp.Rows[0]["LTGGLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["LTGGLX"].ToString();
                 model.LTGGLXDH = dtTemp.Rows[0]["LTGGLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["LTGGLXDH"].ToString();
                 model.QDZKZZL = dtTemp.Rows[0]["QDZKZZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["QDZKZZL"].ToString();
                 model.GCZS = dtTemp.Rows[0]["GCZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCZS"].ToString();
                 model.HCCSXS = dtTemp.Rows[0]["HCCSXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["HCCSXS"].ToString();
                 model.YWLX = dtTemp.Rows[0]["YWLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["YWLX"].ToString();
                 model.KCLXDJ = dtTemp.Rows[0]["KCLXDJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["KCLXDJ"].ToString();
                 model.YXSSZJ = dtTemp.Rows[0]["YXSSZJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["YXSSZJ"].ToString();
                 model.GCYYZH = dtTemp.Rows[0]["GCYYZH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCYYZH"].ToString();
                 model.GCYXSSZJ = dtTemp.Rows[0]["GCYXSSZJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCYXSSZJ"].ToString();
                 model.AJJCCS = dtTemp.Rows[0]["AJJCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["AJJCCS"]);
                 model.ZJJCCS = dtTemp.Rows[0]["ZJJCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ZJJCCS"]);
                 model.WJJCCS = dtTemp.Rows[0]["WJJCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["WJJCCS"]);
                 model.MTCSFDJSS = dtTemp.Rows[0]["MTCSFDJSS"] == DBNull.Value ? "" : dtTemp.Rows[0]["MTCSFDJSS"].ToString();
                 model.MTCSFDJSSDH = dtTemp.Rows[0]["MTCSFDJSSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["MTCSFDJSSDH"].ToString();
                 model.ZYWLB = dtTemp.Rows[0]["ZYWLB"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYWLB"].ToString();
                 model.ZYWLBDH = dtTemp.Rows[0]["ZYWLBDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZYWLBDH"].ToString();
                 model.AJ_Z_PD = dtTemp.Rows[0]["AJ_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["AJ_Z_PD"].ToString();
                 model.ZJ_Z_PD = dtTemp.Rows[0]["ZJ_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJ_Z_PD"].ToString();
                 model.WQ_Z_PD = dtTemp.Rows[0]["WQ_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["WQ_Z_PD"].ToString();
                 model.QT_Z_PD = dtTemp.Rows[0]["QT_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[0]["QT_Z_PD"].ToString();
                 model.AJ_FJXM = dtTemp.Rows[0]["AJ_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["AJ_FJXM"].ToString();
                 model.ZJ_FJXM = dtTemp.Rows[0]["ZJ_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJ_FJXM"].ToString();
                 model.WQ_FJXM = dtTemp.Rows[0]["WQ_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["WQ_FJXM"].ToString();
                 model.QT_FJXM = dtTemp.Rows[0]["QT_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[0]["QT_FJXM"].ToString();
                 model.JYLB_TYPE = dtTemp.Rows[0]["JYLB_TYPE"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYLB_TYPE"].ToString();
                 model.CLSSLB = dtTemp.Rows[0]["CLSSLB"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLSSLB"].ToString();
                 model.CLSSLBDH = dtTemp.Rows[0]["CLSSLBDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLSSLBDH"].ToString();
                 model.SYRSFZ = dtTemp.Rows[0]["SYRSFZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["SYRSFZ"].ToString();
                 model.ZJJYRQ = dtTemp.Rows[0]["ZJJYRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJJYRQ"].ToString();
                 model.BXZZRQ = dtTemp.Rows[0]["BXZZRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["BXZZRQ"].ToString();
                 model.JYYXQZ = dtTemp.Rows[0]["JYYXQZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYYXQZ"].ToString();
                 model.CLYTDH = dtTemp.Rows[0]["CLYTDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLYTDH"].ToString();
                 model.YTSXDH = dtTemp.Rows[0]["YTSXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["YTSXDH"].ToString();
                 model.BZZXS = dtTemp.Rows[0]["BZZXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["BZZXS"].ToString();
                 model.BZZXSDH = dtTemp.Rows[0]["BZZXSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["BZZXSDH"].ToString();
                 model.JYXM_LW = dtTemp.Rows[0]["JYXM_LW"] == DBNull.Value ? "" : dtTemp.Rows[0]["JYXM_LW"].ToString();
                 model.GCPZH = dtTemp.Rows[0]["GCPZH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCPZH"].ToString();
                 model.GCLX = dtTemp.Rows[0]["GCLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCLX"].ToString();
                 model.GCLXDH = dtTemp.Rows[0]["GCLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCLXDH"].ToString();
                 model.QYCMZZZL = dtTemp.Rows[0]["QYCMZZZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["QYCMZZZL"].ToString();
                 model.DCZS = dtTemp.Rows[0]["DCZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["DCZS"].ToString();
                 model.XZQY = dtTemp.Rows[0]["XZQY"] == DBNull.Value ? "" : dtTemp.Rows[0]["XZQY"].ToString();
                 model.ZCLBGD = dtTemp.Rows[0]["ZCLBGD"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZCLBGD"].ToString();
                 model.GCLBGD = dtTemp.Rows[0]["GCLBGD"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCLBGD"].ToString();
                 model.GCCSC = dtTemp.Rows[0]["GCCSC"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCCSC"].ToString();
                 model.GCCSK = dtTemp.Rows[0]["GCCSK"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCCSK"].ToString();
                 model.GCCSG = dtTemp.Rows[0]["GCCSG"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCCSG"].ToString();
                 model.GCBZZXS = dtTemp.Rows[0]["GCBZZXS"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCBZZXS"].ToString();
                 model.GCBZZXSDH = dtTemp.Rows[0]["GCBZZXSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCBZZXSDH"].ToString();
                 model.ZJCLLX = dtTemp.Rows[0]["ZJCLLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJCLLX"].ToString();
                 model.ZJCLLXDH = dtTemp.Rows[0]["ZJCLLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZJCLLXDH"].ToString();
                 model.SFSWPC = dtTemp.Rows[0]["SFSWPC"] == DBNull.Value ? "" : dtTemp.Rows[0]["SFSWPC"].ToString();
                 model.DLYSZH = dtTemp.Rows[0]["DLYSZH"] == DBNull.Value ? "" : dtTemp.Rows[0]["DLYSZH"].ToString();
                 model.SFSGSQC = dtTemp.Rows[0]["SFSGSQC"] == DBNull.Value ? "" : dtTemp.Rows[0]["SFSGSQC"].ToString();
                 model.CLCCLX = dtTemp.Rows[0]["CLCCLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLCCLX"].ToString();
                 model.CLCCLXDH = dtTemp.Rows[0]["CLCCLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLCCLXDH"].ToString();
                 model.DWS = dtTemp.Rows[0]["DWS"] == DBNull.Value ? "" : dtTemp.Rows[0]["DWS"].ToString();
                 model.HCCSXSDH = dtTemp.Rows[0]["HCCSXSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["HCCSXSDH"].ToString();
                 model.KCLXDJDH = dtTemp.Rows[0]["KCLXDJDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["KCLXDJDH"].ToString();
                 model.KCCC = dtTemp.Rows[0]["KCCC"] == DBNull.Value ? "" : dtTemp.Rows[0]["KCCC"].ToString();
                 model.GCYXXSZJ = dtTemp.Rows[0]["GCYXXSZJ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCYXXSZJ"].ToString();
                 model.GCVIN = dtTemp.Rows[0]["GCVIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCVIN"].ToString();
                 model.GCCCDJRQ = dtTemp.Rows[0]["GCCCDJRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCCCDJRQ"].ToString();
                 model.GCCCRQ = dtTemp.Rows[0]["GCCCRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCCCRQ"].ToString();
                 model.GCPPXH = dtTemp.Rows[0]["GCPPXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["GCPPXH"].ToString();
                 model.Z_RESULT = dtTemp.Rows[0]["Z_RESULT"] == DBNull.Value ? "" : dtTemp.Rows[0]["Z_RESULT"].ToString();
                 model.HPYS = dtTemp.Rows[0]["HPYS"] == DBNull.Value ? "" : dtTemp.Rows[0]["HPYS"].ToString();
                 model.HPYSDH = dtTemp.Rows[0]["HPYSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["HPYSDH"].ToString();
                 model.DGSFZXTS = dtTemp.Rows[0]["DGSFZXTS"] == DBNull.Value ? "" : dtTemp.Rows[0]["DGSFZXTS"].ToString();
                 model.DGSFZXTSDH = dtTemp.Rows[0]["DGSFZXTSDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["DGSFZXTSDH"].ToString();
                 model.ZDJGL = dtTemp.Rows[0]["ZDJGL"] == DBNull.Value ? "" : dtTemp.Rows[0]["ZDJGL"].ToString();
                 model.BGDBH = dtTemp.Rows[0]["BGDBH"] == DBNull.Value ? "" : dtTemp.Rows[0]["BGDBH"].ToString();
                 model.BGDJYM = dtTemp.Rows[0]["BGDJYM"] == DBNull.Value ? "" : dtTemp.Rows[0]["BGDJYM"].ToString();
                 model.SZDQLX = dtTemp.Rows[0]["SZDQLX"] == DBNull.Value ? "" : dtTemp.Rows[0]["SZDQLX"].ToString();
                 model.SZDQLXDH = dtTemp.Rows[0]["SZDQLXDH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SZDQLXDH"].ToString();
                 model.YYZHCLRQ = dtTemp.Rows[0]["YYZHCLRQ"] == DBNull.Value ? "" : dtTemp.Rows[0]["YYZHCLRQ"].ToString();
                 model.PFLSH = dtTemp.Rows[0]["PFLSH"] == DBNull.Value ? "" : dtTemp.Rows[0]["PFLSH"].ToString();
                 model.DDJXH = dtTemp.Rows[0]["DDJXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["DDJXH"].ToString();
                 model.CNZZXH = dtTemp.Rows[0]["CNZZXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["CNZZXH"].ToString();
                 model.DCRL = dtTemp.Rows[0]["DCRL"] == DBNull.Value ? "" : dtTemp.Rows[0]["DCRL"].ToString();
                 model.IsTrainMode = dtTemp.Rows[0]["IsTrainMode"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsTrainMode"]);
                 model.IsOBD = dtTemp.Rows[0]["IsOBD"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsOBD"]);
                 model.OBDWZ = dtTemp.Rows[0]["OBDWZ"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBDWZ"].ToString();
                 model.IsDPF = dtTemp.Rows[0]["IsDPF"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsDPF"]);
                 model.DPFXH = dtTemp.Rows[0]["DPFXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["DPFXH"].ToString();
                 model.IsSCR = dtTemp.Rows[0]["IsSCR"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[0]["IsSCR"]);
                 model.SCRXH = dtTemp.Rows[0]["SCRXH"] == DBNull.Value ? "" : dtTemp.Rows[0]["SCRXH"].ToString();
                 model.QZJCDGGP = dtTemp.Rows[0]["QZJCDGGP"] == DBNull.Value ? "" : dtTemp.Rows[0]["QZJCDGGP"].ToString();
                 model.OBDJYY = dtTemp.Rows[0]["OBDJYY"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBDJYY"].ToString();
                 model.WQYCY = dtTemp.Rows[0]["WQYCY"] == DBNull.Value ? "" : dtTemp.Rows[0]["WQYCY"].ToString();
                 model.OBDCommCL = dtTemp.Rows[0]["OBDCommCL"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBDCommCL"].ToString();
                 model.OBDCommCX = dtTemp.Rows[0]["OBDCommCX"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBDCommCX"].ToString();
                 model.Standard = dtTemp.Rows[0]["Standard"] == DBNull.Value ? "" : dtTemp.Rows[0]["Standard"].ToString();
                 model.VehicleKind = dtTemp.Rows[0]["VehicleKind"] == DBNull.Value ? "" : dtTemp.Rows[0]["VehicleKind"].ToString();
                 model.IsEFI = dtTemp.Rows[0]["IsEFI"] == DBNull.Value ? "" : dtTemp.Rows[0]["IsEFI"].ToString();
                 model.IsAsm = dtTemp.Rows[0]["IsAsm"] == DBNull.Value ? "" : dtTemp.Rows[0]["IsAsm"].ToString();
                 model.OBDOutlookID = dtTemp.Rows[0]["OBDOutlookID"] == DBNull.Value ? "" : dtTemp.Rows[0]["OBDOutlookID"].ToString();
                 model.OutlookID = dtTemp.Rows[0]["OutlookID"] == DBNull.Value ? "" : dtTemp.Rows[0]["OutlookID"].ToString();
                 model.VEHICLE_DATA = dtTemp.Rows[0]["VEHICLE_DATA"] == DBNull.Value ? "" : dtTemp.Rows[0]["VEHICLE_DATA"].ToString();
                 model.QDZS = dtTemp.Rows[0]["QDZS"] == DBNull.Value ? "" : dtTemp.Rows[0]["QDZS"].ToString();
                 model.sunVIN = dtTemp.Rows[0]["sunVIN"] == DBNull.Value ? "" : dtTemp.Rows[0]["sunVIN"].ToString();
                 model.PQGSL = dtTemp.Rows[0]["PQGSL"] == DBNull.Value ? "" : dtTemp.Rows[0]["PQGSL"].ToString();
                 model.JZZL = dtTemp.Rows[0]["JZZL"] == DBNull.Value ? "" : dtTemp.Rows[0]["JZZL"].ToString();
                 model.CLPFJD = dtTemp.Rows[0]["CLPFJD"] == DBNull.Value ? "" : dtTemp.Rows[0]["CLPFJD"].ToString();
                 model.FDJSB = dtTemp.Rows[0]["FDJSB"] == DBNull.Value ? "" : dtTemp.Rows[0]["FDJSB"].ToString();
                 model.QDZW = dtTemp.Rows[0]["QDZW"] == DBNull.Value ? "" : dtTemp.Rows[0]["QDZW"].ToString();
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
             strSql += "select * from RESULT_VEHICLE_INFO";
             strSql += " where ";
               strSql += " JCLSH='"+ strJCLSH +"'";

              DbHelper.GetTable(Conn, strSql, ref p_dtData);
         }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VEHICLE_INFO[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
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
          strSql += "select * from RESULT_VEHICLE_INFO";
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

          RESULT_VEHICLE_INFO[] arrModel=new RESULT_VEHICLE_INFO[dtTemp.Rows.Count];

          for(int N=0;N<dtTemp.Rows.Count;N++)
          {
               arrModel[N] = new RESULT_VEHICLE_INFO();

                 arrModel[N].ID = dtTemp.Rows[N]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ID"]);
                 arrModel[N].JCXH = dtTemp.Rows[N]["JCXH"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["JCXH"]);
                 arrModel[N].JCXHMS = dtTemp.Rows[N]["JCXHMS"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCXHMS"].ToString();
                 arrModel[N].JCCS = dtTemp.Rows[N]["JCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["JCCS"]);
                 arrModel[N].JCLSH = dtTemp.Rows[N]["JCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCLSH"].ToString();
                 arrModel[N].JYXM = dtTemp.Rows[N]["JYXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYXM"].ToString();
                 arrModel[N].YJXM = dtTemp.Rows[N]["YJXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["YJXM"].ToString();
                 arrModel[N].FJXM = dtTemp.Rows[N]["FJXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["FJXM"].ToString();
                 arrModel[N].Z_PD = dtTemp.Rows[N]["Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["Z_PD"].ToString();
                 arrModel[N].IsUpload = dtTemp.Rows[N]["IsUpload"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsUpload"]);
                 arrModel[N].IsAudit = dtTemp.Rows[N]["IsAudit"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsAudit"]);
                 arrModel[N].IsPrint = dtTemp.Rows[N]["IsPrint"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsPrint"]);
                 arrModel[N].WQLSH = dtTemp.Rows[N]["WQLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["WQLSH"].ToString();
                 arrModel[N].AJLSH = dtTemp.Rows[N]["AJLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["AJLSH"].ToString();
                 arrModel[N].ZJLSH = dtTemp.Rows[N]["ZJLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJLSH"].ToString();
                 arrModel[N].MTLSH = dtTemp.Rows[N]["MTLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["MTLSH"].ToString();
                 arrModel[N].JCBGDBH01 = dtTemp.Rows[N]["JCBGDBH01"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBGDBH01"].ToString();
                 arrModel[N].JCBGDBH02 = dtTemp.Rows[N]["JCBGDBH02"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBGDBH02"].ToString();
                 arrModel[N].HPHM = dtTemp.Rows[N]["HPHM"] == DBNull.Value ? "" : dtTemp.Rows[N]["HPHM"].ToString();
                 arrModel[N].HPZL = dtTemp.Rows[N]["HPZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["HPZL"].ToString();
                 arrModel[N].HPZLDH = dtTemp.Rows[N]["HPZLDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["HPZLDH"].ToString();
                 arrModel[N].GLCHPHM = dtTemp.Rows[N]["GLCHPHM"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLCHPHM"].ToString();
                 arrModel[N].VIN = dtTemp.Rows[N]["VIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["VIN"].ToString();
                 arrModel[N].JYLB = dtTemp.Rows[N]["JYLB"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYLB"].ToString();
                 arrModel[N].JYLBDH = dtTemp.Rows[N]["JYLBDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYLBDH"].ToString();
                 arrModel[N].FDJH = dtTemp.Rows[N]["FDJH"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJH"].ToString();
                 arrModel[N].FDJXH = dtTemp.Rows[N]["FDJXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJXH"].ToString();
                 arrModel[N].FDJZZCS = dtTemp.Rows[N]["FDJZZCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJZZCS"].ToString();
                 arrModel[N].DPXH = dtTemp.Rows[N]["DPXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["DPXH"].ToString();
                 arrModel[N].PP = dtTemp.Rows[N]["PP"] == DBNull.Value ? "" : dtTemp.Rows[N]["PP"].ToString();
                 arrModel[N].CLZZCS = dtTemp.Rows[N]["CLZZCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLZZCS"].ToString();
                 arrModel[N].XH = dtTemp.Rows[N]["XH"] == DBNull.Value ? "" : dtTemp.Rows[N]["XH"].ToString();
                 arrModel[N].PPXH = dtTemp.Rows[N]["PPXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["PPXH"].ToString();
                 arrModel[N].QDXS = dtTemp.Rows[N]["QDXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["QDXS"].ToString();
                 arrModel[N].QDXSDH = dtTemp.Rows[N]["QDXSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["QDXSDH"].ToString();
                 arrModel[N].QDZWZ = dtTemp.Rows[N]["QDZWZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["QDZWZ"].ToString();
                 arrModel[N].ZCZWZ = dtTemp.Rows[N]["ZCZWZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZCZWZ"].ToString();
                 arrModel[N].QZDZ = dtTemp.Rows[N]["QZDZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["QZDZ"].ToString();
                 arrModel[N].QZDZDH = dtTemp.Rows[N]["QZDZDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["QZDZDH"].ToString();
                 arrModel[N].YGGSNFKT = dtTemp.Rows[N]["YGGSNFKT"] == DBNull.Value ? "" : dtTemp.Rows[N]["YGGSNFKT"].ToString();
                 arrModel[N].YGGSNFKTDH = dtTemp.Rows[N]["YGGSNFKTDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["YGGSNFKTDH"].ToString();
                 arrModel[N].RLLB = dtTemp.Rows[N]["RLLB"] == DBNull.Value ? "" : dtTemp.Rows[N]["RLLB"].ToString();
                 arrModel[N].RLLBDH = dtTemp.Rows[N]["RLLBDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["RLLBDH"].ToString();
                 arrModel[N].RYBH = dtTemp.Rows[N]["RYBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["RYBH"].ToString();
                 arrModel[N].GYFS = dtTemp.Rows[N]["GYFS"] == DBNull.Value ? "" : dtTemp.Rows[N]["GYFS"].ToString();
                 arrModel[N].GYFSDH = dtTemp.Rows[N]["GYFSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GYFSDH"].ToString();
                 arrModel[N].CCDJRQ = dtTemp.Rows[N]["CCDJRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CCDJRQ"].ToString();
                 arrModel[N].CCRQ = dtTemp.Rows[N]["CCRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CCRQ"].ToString();
                 arrModel[N].ZBZL = dtTemp.Rows[N]["ZBZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZBZL"].ToString();
                 arrModel[N].ZZL = dtTemp.Rows[N]["ZZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZZL"].ToString();
                 arrModel[N].CYS = dtTemp.Rows[N]["CYS"] == DBNull.Value ? "" : dtTemp.Rows[N]["CYS"].ToString();
                 arrModel[N].CSYS = dtTemp.Rows[N]["CSYS"] == DBNull.Value ? "" : dtTemp.Rows[N]["CSYS"].ToString();
                 arrModel[N].ZDFS = dtTemp.Rows[N]["ZDFS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZDFS"].ToString();
                 arrModel[N].ZDFSDH = dtTemp.Rows[N]["ZDFSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZDFSDH"].ToString();
                 arrModel[N].CLZL = dtTemp.Rows[N]["CLZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLZL"].ToString();
                 arrModel[N].CLZLDH = dtTemp.Rows[N]["CLZLDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLZLDH"].ToString();
                 arrModel[N].ZXZXJXS = dtTemp.Rows[N]["ZXZXJXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZXZXJXS"].ToString();
                 arrModel[N].ZXZXJXSDH = dtTemp.Rows[N]["ZXZXJXSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZXZXJXSDH"].ToString();
                 arrModel[N].ZXZLX = dtTemp.Rows[N]["ZXZLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZXZLX"].ToString();
                 arrModel[N].ZXZLXDH = dtTemp.Rows[N]["ZXZLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZXZLXDH"].ToString();
                 arrModel[N].ZGSJCS = dtTemp.Rows[N]["ZGSJCS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZGSJCS"].ToString();
                 arrModel[N].EDGL = dtTemp.Rows[N]["EDGL"] == DBNull.Value ? "" : dtTemp.Rows[N]["EDGL"].ToString();
                 arrModel[N].EDZS = dtTemp.Rows[N]["EDZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["EDZS"].ToString();
                 arrModel[N].EDNJZS = dtTemp.Rows[N]["EDNJZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["EDNJZS"].ToString();
                 arrModel[N].EDNJ = dtTemp.Rows[N]["EDNJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["EDNJ"].ToString();
                 arrModel[N].EDYH = dtTemp.Rows[N]["EDYH"] == DBNull.Value ? "" : dtTemp.Rows[N]["EDYH"].ToString();
                 arrModel[N].JQFS = dtTemp.Rows[N]["JQFS"] == DBNull.Value ? "" : dtTemp.Rows[N]["JQFS"].ToString();
                 arrModel[N].JQFSDH = dtTemp.Rows[N]["JQFSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JQFSDH"].ToString();
                 arrModel[N].FDJPL = dtTemp.Rows[N]["FDJPL"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJPL"].ToString();
                 arrModel[N].FDJGS = dtTemp.Rows[N]["FDJGS"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJGS"].ToString();
                 arrModel[N].FDJCC = dtTemp.Rows[N]["FDJCC"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJCC"].ToString();
                 arrModel[N].BSXLX = dtTemp.Rows[N]["BSXLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["BSXLX"].ToString();
                 arrModel[N].BSXLXDH = dtTemp.Rows[N]["BSXLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["BSXLXDH"].ToString();
                 arrModel[N].CXXL = dtTemp.Rows[N]["CXXL"] == DBNull.Value ? "" : dtTemp.Rows[N]["CXXL"].ToString();
                 arrModel[N].CXXLDH = dtTemp.Rows[N]["CXXLDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CXXLDH"].ToString();
                 arrModel[N].LJXSLC = dtTemp.Rows[N]["LJXSLC"] == DBNull.Value ? "" : dtTemp.Rows[N]["LJXSLC"].ToString();
                 arrModel[N].LTQY = dtTemp.Rows[N]["LTQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["LTQY"].ToString();
                 arrModel[N].LTGG = dtTemp.Rows[N]["LTGG"] == DBNull.Value ? "" : dtTemp.Rows[N]["LTGG"].ToString();
                 arrModel[N].LTSL = dtTemp.Rows[N]["LTSL"] == DBNull.Value ? "" : dtTemp.Rows[N]["LTSL"].ToString();
                 arrModel[N].SYXZ = dtTemp.Rows[N]["SYXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SYXZ"].ToString();
                 arrModel[N].SYXZDH = dtTemp.Rows[N]["SYXZDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SYXZDH"].ToString();
                 arrModel[N].YYZH = dtTemp.Rows[N]["YYZH"] == DBNull.Value ? "" : dtTemp.Rows[N]["YYZH"].ToString();
                 arrModel[N].SJDW = dtTemp.Rows[N]["SJDW"] == DBNull.Value ? "" : dtTemp.Rows[N]["SJDW"].ToString();
                 arrModel[N].SYR = dtTemp.Rows[N]["SYR"] == DBNull.Value ? "" : dtTemp.Rows[N]["SYR"].ToString();
                 arrModel[N].LXDH = dtTemp.Rows[N]["LXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["LXDH"].ToString();
                 arrModel[N].LXDZ = dtTemp.Rows[N]["LXDZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LXDZ"].ToString();
                 arrModel[N].YZBH = dtTemp.Rows[N]["YZBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["YZBH"].ToString();
                 arrModel[N].JCRQ = dtTemp.Rows[N]["JCRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCRQ"].ToString();
                 arrModel[N].DLRQ = dtTemp.Rows[N]["DLRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["DLRQ"].ToString();
                 arrModel[N].CLSXSJ = dtTemp.Rows[N]["CLSXSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLSXSJ"].ToString();
                 arrModel[N].CLXXSJ = dtTemp.Rows[N]["CLXXSJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLXXSJ"].ToString();
                 arrModel[N].DLY = dtTemp.Rows[N]["DLY"] == DBNull.Value ? "" : dtTemp.Rows[N]["DLY"].ToString();
                 arrModel[N].YCY = dtTemp.Rows[N]["YCY"] == DBNull.Value ? "" : dtTemp.Rows[N]["YCY"].ToString();
                 arrModel[N].WGJYY = dtTemp.Rows[N]["WGJYY"] == DBNull.Value ? "" : dtTemp.Rows[N]["WGJYY"].ToString();
                 arrModel[N].DPJYY = dtTemp.Rows[N]["DPJYY"] == DBNull.Value ? "" : dtTemp.Rows[N]["DPJYY"].ToString();
                 arrModel[N].DTDPJYY = dtTemp.Rows[N]["DTDPJYY"] == DBNull.Value ? "" : dtTemp.Rows[N]["DTDPJYY"].ToString();
                 arrModel[N].LSJYY = dtTemp.Rows[N]["LSJYY"] == DBNull.Value ? "" : dtTemp.Rows[N]["LSJYY"].ToString();
                 arrModel[N].SQQZR = dtTemp.Rows[N]["SQQZR"] == DBNull.Value ? "" : dtTemp.Rows[N]["SQQZR"].ToString();
                 arrModel[N].WQCZY = dtTemp.Rows[N]["WQCZY"] == DBNull.Value ? "" : dtTemp.Rows[N]["WQCZY"].ToString();
                 arrModel[N].CSC = dtTemp.Rows[N]["CSC"] == DBNull.Value ? "" : dtTemp.Rows[N]["CSC"].ToString();
                 arrModel[N].CSK = dtTemp.Rows[N]["CSK"] == DBNull.Value ? "" : dtTemp.Rows[N]["CSK"].ToString();
                 arrModel[N].CSG = dtTemp.Rows[N]["CSG"] == DBNull.Value ? "" : dtTemp.Rows[N]["CSG"].ToString();
                 arrModel[N].ZJ = dtTemp.Rows[N]["ZJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJ"].ToString();
                 arrModel[N].YZLJ = dtTemp.Rows[N]["YZLJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["YZLJ"].ToString();
                 arrModel[N].EZLJ = dtTemp.Rows[N]["EZLJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["EZLJ"].ToString();
                 arrModel[N].SZLJ = dtTemp.Rows[N]["SZLJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SZLJ"].ToString();
                 arrModel[N].SIZLJ = dtTemp.Rows[N]["SIZLJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SIZLJ"].ToString();
                 arrModel[N].WZLJ = dtTemp.Rows[N]["WZLJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["WZLJ"].ToString();
                 arrModel[N].LZLJ = dtTemp.Rows[N]["LZLJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LZLJ"].ToString();
                 arrModel[N].YZZLZ = dtTemp.Rows[N]["YZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["YZZLZ"].ToString();
                 arrModel[N].YZYLZ = dtTemp.Rows[N]["YZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["YZYLZ"].ToString();
                 arrModel[N].YZZZ = dtTemp.Rows[N]["YZZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["YZZZ"].ToString();
                 arrModel[N].EZZLZ = dtTemp.Rows[N]["EZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["EZZLZ"].ToString();
                 arrModel[N].EZYLZ = dtTemp.Rows[N]["EZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["EZYLZ"].ToString();
                 arrModel[N].EZZZ = dtTemp.Rows[N]["EZZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["EZZZ"].ToString();
                 arrModel[N].SZZLZ = dtTemp.Rows[N]["SZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SZZLZ"].ToString();
                 arrModel[N].SZYLZ = dtTemp.Rows[N]["SZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SZYLZ"].ToString();
                 arrModel[N].SZZZ = dtTemp.Rows[N]["SZZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SZZZ"].ToString();
                 arrModel[N].SIZZLZ = dtTemp.Rows[N]["SIZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SIZZLZ"].ToString();
                 arrModel[N].SIZYLZ = dtTemp.Rows[N]["SIZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SIZYLZ"].ToString();
                 arrModel[N].SIZZZ = dtTemp.Rows[N]["SIZZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SIZZZ"].ToString();
                 arrModel[N].WZZLZ = dtTemp.Rows[N]["WZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["WZZLZ"].ToString();
                 arrModel[N].WZYLZ = dtTemp.Rows[N]["WZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["WZYLZ"].ToString();
                 arrModel[N].WZZZ = dtTemp.Rows[N]["WZZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["WZZZ"].ToString();
                 arrModel[N].LZZLZ = dtTemp.Rows[N]["LZZLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LZZLZ"].ToString();
                 arrModel[N].LZYLZ = dtTemp.Rows[N]["LZYLZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LZYLZ"].ToString();
                 arrModel[N].LZZZ = dtTemp.Rows[N]["LZZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["LZZZ"].ToString();
                 arrModel[N].CHZHQQK = dtTemp.Rows[N]["CHZHQQK"] == DBNull.Value ? "" : dtTemp.Rows[N]["CHZHQQK"].ToString();
                 arrModel[N].CHZHQQKDH = dtTemp.Rows[N]["CHZHQQKDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CHZHQQKDH"].ToString();
                 arrModel[N].PQHCLZZ = dtTemp.Rows[N]["PQHCLZZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["PQHCLZZ"].ToString();
                 arrModel[N].PQHCLZZDH = dtTemp.Rows[N]["PQHCLZZDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["PQHCLZZDH"].ToString();
                 arrModel[N].GXRQ = dtTemp.Rows[N]["GXRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GXRQ"].ToString();
                 arrModel[N].JZZZWZ = dtTemp.Rows[N]["JZZZWZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JZZZWZ"].ToString();
                 arrModel[N].JYXM_EX = dtTemp.Rows[N]["JYXM_EX"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYXM_EX"].ToString();
                 arrModel[N].ZZS = dtTemp.Rows[N]["ZZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZZS"].ToString();
                 arrModel[N].GLCJCLSH = dtTemp.Rows[N]["GLCJCLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLCJCLSH"].ToString();
                 arrModel[N].GLCHPZL = dtTemp.Rows[N]["GLCHPZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLCHPZL"].ToString();
                 arrModel[N].GLCHPZLDH = dtTemp.Rows[N]["GLCHPZLDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLCHPZLDH"].ToString();
                 arrModel[N].LWCXWZJL = dtTemp.Rows[N]["LWCXWZJL"] == DBNull.Value ? "" : dtTemp.Rows[N]["LWCXWZJL"].ToString();
                 arrModel[N].SFSQCLC = dtTemp.Rows[N]["SFSQCLC"] == DBNull.Value ? "" : dtTemp.Rows[N]["SFSQCLC"].ToString();
                 arrModel[N].GLCJYXM = dtTemp.Rows[N]["GLCJYXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["GLCJYXM"].ToString();
                 arrModel[N].LWCXWZJLDH = dtTemp.Rows[N]["LWCXWZJLDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["LWCXWZJLDH"].ToString();
                 arrModel[N].HDZH = dtTemp.Rows[N]["HDZH"] == DBNull.Value ? "" : dtTemp.Rows[N]["HDZH"].ToString();
                 arrModel[N].EDNJGL = dtTemp.Rows[N]["EDNJGL"] == DBNull.Value ? "" : dtTemp.Rows[N]["EDNJGL"].ToString();
                 arrModel[N].FWQ_ZYXZ = dtTemp.Rows[N]["FWQ_ZYXZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["FWQ_ZYXZ"].ToString();
                 arrModel[N].DSBH = dtTemp.Rows[N]["DSBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["DSBH"].ToString();
                 arrModel[N].JCBSB = dtTemp.Rows[N]["JCBSB"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBSB"].ToString();
                 arrModel[N].JCBXH = dtTemp.Rows[N]["JCBXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBXH"].ToString();
                 arrModel[N].JCBAZRQ = dtTemp.Rows[N]["JCBAZRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBAZRQ"].ToString();
                 arrModel[N].JCBDYJSB = dtTemp.Rows[N]["JCBDYJSB"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBDYJSB"].ToString();
                 arrModel[N].JCBDYJXH = dtTemp.Rows[N]["JCBDYJXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBDYJXH"].ToString();
                 arrModel[N].JCBAZGS = dtTemp.Rows[N]["JCBAZGS"] == DBNull.Value ? "" : dtTemp.Rows[N]["JCBAZGS"].ToString();
                 arrModel[N].LWLRLSH = dtTemp.Rows[N]["LWLRLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["LWLRLSH"].ToString();
                 arrModel[N].LWLRHENF = dtTemp.Rows[N]["LWLRHENF"] == DBNull.Value ? "" : dtTemp.Rows[N]["LWLRHENF"].ToString();
                 arrModel[N].REPORT_JYXM = dtTemp.Rows[N]["REPORT_JYXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["REPORT_JYXM"].ToString();
                 arrModel[N].LTGGLX = dtTemp.Rows[N]["LTGGLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["LTGGLX"].ToString();
                 arrModel[N].LTGGLXDH = dtTemp.Rows[N]["LTGGLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["LTGGLXDH"].ToString();
                 arrModel[N].QDZKZZL = dtTemp.Rows[N]["QDZKZZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["QDZKZZL"].ToString();
                 arrModel[N].GCZS = dtTemp.Rows[N]["GCZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCZS"].ToString();
                 arrModel[N].HCCSXS = dtTemp.Rows[N]["HCCSXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["HCCSXS"].ToString();
                 arrModel[N].YWLX = dtTemp.Rows[N]["YWLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["YWLX"].ToString();
                 arrModel[N].KCLXDJ = dtTemp.Rows[N]["KCLXDJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["KCLXDJ"].ToString();
                 arrModel[N].YXSSZJ = dtTemp.Rows[N]["YXSSZJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["YXSSZJ"].ToString();
                 arrModel[N].GCYYZH = dtTemp.Rows[N]["GCYYZH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCYYZH"].ToString();
                 arrModel[N].GCYXSSZJ = dtTemp.Rows[N]["GCYXSSZJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCYXSSZJ"].ToString();
                 arrModel[N].AJJCCS = dtTemp.Rows[N]["AJJCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["AJJCCS"]);
                 arrModel[N].ZJJCCS = dtTemp.Rows[N]["ZJJCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["ZJJCCS"]);
                 arrModel[N].WJJCCS = dtTemp.Rows[N]["WJJCCS"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["WJJCCS"]);
                 arrModel[N].MTCSFDJSS = dtTemp.Rows[N]["MTCSFDJSS"] == DBNull.Value ? "" : dtTemp.Rows[N]["MTCSFDJSS"].ToString();
                 arrModel[N].MTCSFDJSSDH = dtTemp.Rows[N]["MTCSFDJSSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["MTCSFDJSSDH"].ToString();
                 arrModel[N].ZYWLB = dtTemp.Rows[N]["ZYWLB"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYWLB"].ToString();
                 arrModel[N].ZYWLBDH = dtTemp.Rows[N]["ZYWLBDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZYWLBDH"].ToString();
                 arrModel[N].AJ_Z_PD = dtTemp.Rows[N]["AJ_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["AJ_Z_PD"].ToString();
                 arrModel[N].ZJ_Z_PD = dtTemp.Rows[N]["ZJ_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJ_Z_PD"].ToString();
                 arrModel[N].WQ_Z_PD = dtTemp.Rows[N]["WQ_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["WQ_Z_PD"].ToString();
                 arrModel[N].QT_Z_PD = dtTemp.Rows[N]["QT_Z_PD"] == DBNull.Value ? "" : dtTemp.Rows[N]["QT_Z_PD"].ToString();
                 arrModel[N].AJ_FJXM = dtTemp.Rows[N]["AJ_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["AJ_FJXM"].ToString();
                 arrModel[N].ZJ_FJXM = dtTemp.Rows[N]["ZJ_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJ_FJXM"].ToString();
                 arrModel[N].WQ_FJXM = dtTemp.Rows[N]["WQ_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["WQ_FJXM"].ToString();
                 arrModel[N].QT_FJXM = dtTemp.Rows[N]["QT_FJXM"] == DBNull.Value ? "" : dtTemp.Rows[N]["QT_FJXM"].ToString();
                 arrModel[N].JYLB_TYPE = dtTemp.Rows[N]["JYLB_TYPE"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYLB_TYPE"].ToString();
                 arrModel[N].CLSSLB = dtTemp.Rows[N]["CLSSLB"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLSSLB"].ToString();
                 arrModel[N].CLSSLBDH = dtTemp.Rows[N]["CLSSLBDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLSSLBDH"].ToString();
                 arrModel[N].SYRSFZ = dtTemp.Rows[N]["SYRSFZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["SYRSFZ"].ToString();
                 arrModel[N].ZJJYRQ = dtTemp.Rows[N]["ZJJYRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJJYRQ"].ToString();
                 arrModel[N].BXZZRQ = dtTemp.Rows[N]["BXZZRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["BXZZRQ"].ToString();
                 arrModel[N].JYYXQZ = dtTemp.Rows[N]["JYYXQZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYYXQZ"].ToString();
                 arrModel[N].CLYTDH = dtTemp.Rows[N]["CLYTDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLYTDH"].ToString();
                 arrModel[N].YTSXDH = dtTemp.Rows[N]["YTSXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["YTSXDH"].ToString();
                 arrModel[N].BZZXS = dtTemp.Rows[N]["BZZXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["BZZXS"].ToString();
                 arrModel[N].BZZXSDH = dtTemp.Rows[N]["BZZXSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["BZZXSDH"].ToString();
                 arrModel[N].JYXM_LW = dtTemp.Rows[N]["JYXM_LW"] == DBNull.Value ? "" : dtTemp.Rows[N]["JYXM_LW"].ToString();
                 arrModel[N].GCPZH = dtTemp.Rows[N]["GCPZH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCPZH"].ToString();
                 arrModel[N].GCLX = dtTemp.Rows[N]["GCLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCLX"].ToString();
                 arrModel[N].GCLXDH = dtTemp.Rows[N]["GCLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCLXDH"].ToString();
                 arrModel[N].QYCMZZZL = dtTemp.Rows[N]["QYCMZZZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["QYCMZZZL"].ToString();
                 arrModel[N].DCZS = dtTemp.Rows[N]["DCZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["DCZS"].ToString();
                 arrModel[N].XZQY = dtTemp.Rows[N]["XZQY"] == DBNull.Value ? "" : dtTemp.Rows[N]["XZQY"].ToString();
                 arrModel[N].ZCLBGD = dtTemp.Rows[N]["ZCLBGD"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZCLBGD"].ToString();
                 arrModel[N].GCLBGD = dtTemp.Rows[N]["GCLBGD"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCLBGD"].ToString();
                 arrModel[N].GCCSC = dtTemp.Rows[N]["GCCSC"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCCSC"].ToString();
                 arrModel[N].GCCSK = dtTemp.Rows[N]["GCCSK"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCCSK"].ToString();
                 arrModel[N].GCCSG = dtTemp.Rows[N]["GCCSG"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCCSG"].ToString();
                 arrModel[N].GCBZZXS = dtTemp.Rows[N]["GCBZZXS"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCBZZXS"].ToString();
                 arrModel[N].GCBZZXSDH = dtTemp.Rows[N]["GCBZZXSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCBZZXSDH"].ToString();
                 arrModel[N].ZJCLLX = dtTemp.Rows[N]["ZJCLLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJCLLX"].ToString();
                 arrModel[N].ZJCLLXDH = dtTemp.Rows[N]["ZJCLLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZJCLLXDH"].ToString();
                 arrModel[N].SFSWPC = dtTemp.Rows[N]["SFSWPC"] == DBNull.Value ? "" : dtTemp.Rows[N]["SFSWPC"].ToString();
                 arrModel[N].DLYSZH = dtTemp.Rows[N]["DLYSZH"] == DBNull.Value ? "" : dtTemp.Rows[N]["DLYSZH"].ToString();
                 arrModel[N].SFSGSQC = dtTemp.Rows[N]["SFSGSQC"] == DBNull.Value ? "" : dtTemp.Rows[N]["SFSGSQC"].ToString();
                 arrModel[N].CLCCLX = dtTemp.Rows[N]["CLCCLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLCCLX"].ToString();
                 arrModel[N].CLCCLXDH = dtTemp.Rows[N]["CLCCLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLCCLXDH"].ToString();
                 arrModel[N].DWS = dtTemp.Rows[N]["DWS"] == DBNull.Value ? "" : dtTemp.Rows[N]["DWS"].ToString();
                 arrModel[N].HCCSXSDH = dtTemp.Rows[N]["HCCSXSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["HCCSXSDH"].ToString();
                 arrModel[N].KCLXDJDH = dtTemp.Rows[N]["KCLXDJDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["KCLXDJDH"].ToString();
                 arrModel[N].KCCC = dtTemp.Rows[N]["KCCC"] == DBNull.Value ? "" : dtTemp.Rows[N]["KCCC"].ToString();
                 arrModel[N].GCYXXSZJ = dtTemp.Rows[N]["GCYXXSZJ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCYXXSZJ"].ToString();
                 arrModel[N].GCVIN = dtTemp.Rows[N]["GCVIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCVIN"].ToString();
                 arrModel[N].GCCCDJRQ = dtTemp.Rows[N]["GCCCDJRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCCCDJRQ"].ToString();
                 arrModel[N].GCCCRQ = dtTemp.Rows[N]["GCCCRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCCCRQ"].ToString();
                 arrModel[N].GCPPXH = dtTemp.Rows[N]["GCPPXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["GCPPXH"].ToString();
                 arrModel[N].Z_RESULT = dtTemp.Rows[N]["Z_RESULT"] == DBNull.Value ? "" : dtTemp.Rows[N]["Z_RESULT"].ToString();
                 arrModel[N].HPYS = dtTemp.Rows[N]["HPYS"] == DBNull.Value ? "" : dtTemp.Rows[N]["HPYS"].ToString();
                 arrModel[N].HPYSDH = dtTemp.Rows[N]["HPYSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["HPYSDH"].ToString();
                 arrModel[N].DGSFZXTS = dtTemp.Rows[N]["DGSFZXTS"] == DBNull.Value ? "" : dtTemp.Rows[N]["DGSFZXTS"].ToString();
                 arrModel[N].DGSFZXTSDH = dtTemp.Rows[N]["DGSFZXTSDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["DGSFZXTSDH"].ToString();
                 arrModel[N].ZDJGL = dtTemp.Rows[N]["ZDJGL"] == DBNull.Value ? "" : dtTemp.Rows[N]["ZDJGL"].ToString();
                 arrModel[N].BGDBH = dtTemp.Rows[N]["BGDBH"] == DBNull.Value ? "" : dtTemp.Rows[N]["BGDBH"].ToString();
                 arrModel[N].BGDJYM = dtTemp.Rows[N]["BGDJYM"] == DBNull.Value ? "" : dtTemp.Rows[N]["BGDJYM"].ToString();
                 arrModel[N].SZDQLX = dtTemp.Rows[N]["SZDQLX"] == DBNull.Value ? "" : dtTemp.Rows[N]["SZDQLX"].ToString();
                 arrModel[N].SZDQLXDH = dtTemp.Rows[N]["SZDQLXDH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SZDQLXDH"].ToString();
                 arrModel[N].YYZHCLRQ = dtTemp.Rows[N]["YYZHCLRQ"] == DBNull.Value ? "" : dtTemp.Rows[N]["YYZHCLRQ"].ToString();
                 arrModel[N].PFLSH = dtTemp.Rows[N]["PFLSH"] == DBNull.Value ? "" : dtTemp.Rows[N]["PFLSH"].ToString();
                 arrModel[N].DDJXH = dtTemp.Rows[N]["DDJXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["DDJXH"].ToString();
                 arrModel[N].CNZZXH = dtTemp.Rows[N]["CNZZXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["CNZZXH"].ToString();
                 arrModel[N].DCRL = dtTemp.Rows[N]["DCRL"] == DBNull.Value ? "" : dtTemp.Rows[N]["DCRL"].ToString();
                 arrModel[N].IsTrainMode = dtTemp.Rows[N]["IsTrainMode"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsTrainMode"]);
                 arrModel[N].IsOBD = dtTemp.Rows[N]["IsOBD"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsOBD"]);
                 arrModel[N].OBDWZ = dtTemp.Rows[N]["OBDWZ"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBDWZ"].ToString();
                 arrModel[N].IsDPF = dtTemp.Rows[N]["IsDPF"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsDPF"]);
                 arrModel[N].DPFXH = dtTemp.Rows[N]["DPFXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["DPFXH"].ToString();
                 arrModel[N].IsSCR = dtTemp.Rows[N]["IsSCR"] == DBNull.Value ? 0 : Convert.ToInt32(dtTemp.Rows[N]["IsSCR"]);
                 arrModel[N].SCRXH = dtTemp.Rows[N]["SCRXH"] == DBNull.Value ? "" : dtTemp.Rows[N]["SCRXH"].ToString();
                 arrModel[N].QZJCDGGP = dtTemp.Rows[N]["QZJCDGGP"] == DBNull.Value ? "" : dtTemp.Rows[N]["QZJCDGGP"].ToString();
                 arrModel[N].OBDJYY = dtTemp.Rows[N]["OBDJYY"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBDJYY"].ToString();
                 arrModel[N].WQYCY = dtTemp.Rows[N]["WQYCY"] == DBNull.Value ? "" : dtTemp.Rows[N]["WQYCY"].ToString();
                 arrModel[N].OBDCommCL = dtTemp.Rows[N]["OBDCommCL"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBDCommCL"].ToString();
                 arrModel[N].OBDCommCX = dtTemp.Rows[N]["OBDCommCX"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBDCommCX"].ToString();
                 arrModel[N].Standard = dtTemp.Rows[N]["Standard"] == DBNull.Value ? "" : dtTemp.Rows[N]["Standard"].ToString();
                 arrModel[N].VehicleKind = dtTemp.Rows[N]["VehicleKind"] == DBNull.Value ? "" : dtTemp.Rows[N]["VehicleKind"].ToString();
                 arrModel[N].IsEFI = dtTemp.Rows[N]["IsEFI"] == DBNull.Value ? "" : dtTemp.Rows[N]["IsEFI"].ToString();
                 arrModel[N].IsAsm = dtTemp.Rows[N]["IsAsm"] == DBNull.Value ? "" : dtTemp.Rows[N]["IsAsm"].ToString();
                 arrModel[N].OBDOutlookID = dtTemp.Rows[N]["OBDOutlookID"] == DBNull.Value ? "" : dtTemp.Rows[N]["OBDOutlookID"].ToString();
                 arrModel[N].OutlookID = dtTemp.Rows[N]["OutlookID"] == DBNull.Value ? "" : dtTemp.Rows[N]["OutlookID"].ToString();
                 arrModel[N].VEHICLE_DATA = dtTemp.Rows[N]["VEHICLE_DATA"] == DBNull.Value ? "" : dtTemp.Rows[N]["VEHICLE_DATA"].ToString();
                 arrModel[N].QDZS = dtTemp.Rows[N]["QDZS"] == DBNull.Value ? "" : dtTemp.Rows[N]["QDZS"].ToString();
                 arrModel[N].sunVIN = dtTemp.Rows[N]["sunVIN"] == DBNull.Value ? "" : dtTemp.Rows[N]["sunVIN"].ToString();
                 arrModel[N].PQGSL = dtTemp.Rows[N]["PQGSL"] == DBNull.Value ? "" : dtTemp.Rows[N]["PQGSL"].ToString();
                 arrModel[N].JZZL = dtTemp.Rows[N]["JZZL"] == DBNull.Value ? "" : dtTemp.Rows[N]["JZZL"].ToString();
                 arrModel[N].CLPFJD = dtTemp.Rows[N]["CLPFJD"] == DBNull.Value ? "" : dtTemp.Rows[N]["CLPFJD"].ToString();
                 arrModel[N].FDJSB = dtTemp.Rows[N]["FDJSB"] == DBNull.Value ? "" : dtTemp.Rows[N]["FDJSB"].ToString();
                 arrModel[N].QDZW = dtTemp.Rows[N]["QDZW"] == DBNull.Value ? "" : dtTemp.Rows[N]["QDZW"].ToString();
          }

          dtTemp.Dispose();

          return arrModel;
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VEHICLE_INFO[] GetModelList(string p_strWhere)
      {
          return GetModelList(p_strWhere, "", -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VEHICLE_INFO[] GetModelList(string p_strWhere, string p_strOrder)
      {
          return GetModelList(p_strWhere, p_strOrder, -1, -1);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VEHICLE_INFO[] GetModelList(int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList("", "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VEHICLE_INFO[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
      {
          return GetModelList(p_strWhere, "", p_intPageNumber, p_intPageSize);
      }

      /// <summary>
      /// 得到对象集合
      /// </summary>
      public RESULT_VEHICLE_INFO[] GetModelList()
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
          strSql += "select * from RESULT_VEHICLE_INFO";
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
