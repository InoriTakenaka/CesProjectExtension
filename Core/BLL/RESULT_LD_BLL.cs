using System;
using System.Collections.Generic;
using System.Data;
using Model;
using DAL;

namespace BLL
{
     /// <summary>
     /// 业务逻辑层RESULT_LD
     /// </summary>
     public class RESULT_LD_BLL
     {
         public RESULT_LD_BLL()
         {
         }

         private RESULT_LD_DAL g_DAL = new RESULT_LD_DAL();

         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH(string p_strWhere)
         {
             return g_DAL.GetMax_JCLSH(p_strWhere);
         }

         /// <summary>
         /// 得到最大JCLSH
         /// </summary>
         public string GetMax_JCLSH()
         {
             return g_DAL.GetMax_JCLSH();
         }


         /// <summary>
         /// 判断数据是否存在
         /// </summary>
         public bool Exists(string strJCLSH)
         {
             return g_DAL.Exists(strJCLSH);
         }

         /// <summary>
         /// 获取数据总记录数
         /// </summary>
         public int GetRecordCount(string p_strWhere)
         {
             return g_DAL.GetRecordCount(p_strWhere);
         }

         /// <summary>
         /// 获取数据总记录数
         /// </summary>
         public int GetRecordCount()
         {
             return g_DAL.GetRecordCount();
         }

         /// <summary>
         /// 获取数据分页总数
         /// </summary>
         public int GetPageCount(string p_strWhere, int p_intPageSize)
         {
             return g_DAL.GetPageCount(p_strWhere, p_intPageSize);
         }

         /// <summary>
         /// 获取数据分页总数
         /// </summary>
         public int GetPageCount(int p_intPageSize)
         {
             return g_DAL.GetPageCount(p_intPageSize);
         }

         /// <summary>
         /// 添加一条数据 SQL
         /// </summary>
         public string InsertSQL(RESULT_LD model)
         {
             return g_DAL.InsertSQL(model);
         }

         /// <summary>
         /// 添加一条数据
         /// </summary>
         public bool Insert(RESULT_LD model)
         {
             return g_DAL.Insert(model);
         }

         /// <summary>
         /// 修改一条数据 SQL
         /// </summary>
         public string UpdateSQL(RESULT_LD model, string strJCLSH)
         {
             return g_DAL.UpdateSQL(model, strJCLSH);
         }

         /// <summary>
         /// 修改一条数据
         /// </summary>
         public bool Update(RESULT_LD model, string strJCLSH)
         {
             return g_DAL.Update(model,  strJCLSH);
         }

         /// <summary>
         /// 修改一个集合 SQL
         /// </summary>
         public string UpdateRangeSQL(RESULT_LD model, string p_strWhere)
         {
             return g_DAL.UpdateRangeSQL(model, p_strWhere);
         }

         /// <summary>
         /// 修改一个集合
         /// </summary>
         public bool UpdateRange(RESULT_LD model, string p_strWhere)
         {
             return g_DAL.UpdateRange(model, p_strWhere);
         }

         /// <summary>
         /// 修改全部数据 SQL
         /// </summary>
         public string UpdateAllSQL(RESULT_LD model)
         {
             return g_DAL.UpdateAllSQL(model);
         }

         /// <summary>
         /// 修改全部数据
         /// </summary>
         public bool UpdateAll(RESULT_LD model)
         {
             return g_DAL.UpdateAll(model);
         }

         /// <summary>
         /// 删除一条数据 SQL
         /// </summary>
         public string DeleteSQL(string strJCLSH)
         {
             return g_DAL.DeleteSQL(strJCLSH);
         }

         /// <summary>
         /// 删除一条数据
         /// </summary>
         public bool Delete(string strJCLSH)
         {
             return g_DAL.Delete(strJCLSH);
         }

         /// <summary>
         /// 删除一个集合 SQL
         /// </summary>
         public string DeleteRangeSQL(string p_strWhere)
         {
             return g_DAL.DeleteRangeSQL(p_strWhere);
         }

         /// <summary>
         /// 删除一个集合
         /// </summary>
         public bool DeleteRange(string p_strWhere)
         {
             return g_DAL.DeleteRange(p_strWhere);
         }

         /// <summary>
         /// 删除全部 SQL
         /// </summary>
         public string DeleteAllSQL()
         {
             return g_DAL.DeleteAllSQL();
         }

         /// <summary>
         /// 删除全部
         /// </summary>
         public bool DeleteAll()
         {
             return g_DAL.DeleteAll();
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public RESULT_LD GetModel(string strJCLSH)
         {
             return g_DAL.GetModel(strJCLSH);
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public void GetModel(ref DataTable p_dtData, string strJCLSH)
         {
             g_DAL.GetModel(ref p_dtData, strJCLSH);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
          public RESULT_LD[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
         {
             return g_DAL.GetModelList(p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public RESULT_LD[] GetModelList(string p_strWhere)
         {
             return g_DAL.GetModelList(p_strWhere);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public RESULT_LD[] GetModelList(string p_strWhere, string p_strOrder)
         {
             return g_DAL.GetModelList(p_strWhere, p_strOrder);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public RESULT_LD[] GetModelList(int p_intPageNumber, int p_intPageSize)
         {
             return g_DAL.GetModelList(p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public RESULT_LD[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
         {
             return g_DAL.GetModelList(p_strWhere, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public RESULT_LD[] GetModelList()
         {
             return g_DAL.GetModelList();
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
         {
             g_DAL.GetModelList(ref p_dtData, p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public void GetModelList(ref DataTable p_dtData, string p_strWhere)
         {
             g_DAL.GetModelList(ref p_dtData, p_strWhere);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public void GetModelList(ref DataTable p_dtData, string p_strWhere, string p_strOrder)
         {
             g_DAL.GetModelList(ref p_dtData, p_strWhere, p_strOrder);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public void GetModelList(ref DataTable p_dtData, int p_intPageNumber, int p_intPageSize)
         {
             g_DAL.GetModelList(ref p_dtData, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public void GetModelList(ref DataTable p_dtData, string p_strWhere, int p_intPageNumber, int p_intPageSize)
         {
             g_DAL.GetModelList(ref p_dtData, p_strWhere, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
          public void GetModelList(ref DataTable p_dtData)
         {
             g_DAL.GetModelList(ref p_dtData);
         }
     }
}
