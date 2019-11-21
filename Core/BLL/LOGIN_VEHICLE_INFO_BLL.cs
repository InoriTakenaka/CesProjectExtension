using System;
using System.Collections.Generic;
using System.Data;
using Model;
using DAL;

namespace BLL
{
     /// <summary>
     /// 业务逻辑层LOGIN_VEHICLE_INFO
     /// </summary>
     public class LOGIN_VEHICLE_INFO_BLL
     {
         public LOGIN_VEHICLE_INFO_BLL()
         {
         }

         private LOGIN_VEHICLE_INFO_DAL g_DAL = new LOGIN_VEHICLE_INFO_DAL();

         /// <summary>
         /// 得到最大ID
         /// </summary>
         public int GetMax_ID(string p_strWhere)
         {
             return g_DAL.GetMax_ID(p_strWhere);
         }

         /// <summary>
         /// 得到最大ID
         /// </summary>
         public int GetMax_ID()
         {
             return g_DAL.GetMax_ID();
         }


         /// <summary>
         /// 判断数据是否存在
         /// </summary>
         public bool Exists(int intID)
         {
             return g_DAL.Exists(intID);
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
         public string InsertSQL(LOGIN_VEHICLE_INFO model)
         {
             return g_DAL.InsertSQL(model);
         }

         /// <summary>
         /// 添加一条数据
         /// </summary>
         public bool Insert(LOGIN_VEHICLE_INFO model)
         {
             return g_DAL.Insert(model);
         }

         /// <summary>
         /// 修改一条数据 SQL
         /// </summary>
         public string UpdateSQL(LOGIN_VEHICLE_INFO model, int intID)
         {
             return g_DAL.UpdateSQL(model, intID);
         }

         /// <summary>
         /// 修改一条数据
         /// </summary>
         public bool Update(LOGIN_VEHICLE_INFO model, int intID)
         {
             return g_DAL.Update(model,  intID);
         }

         /// <summary>
         /// 修改一个集合 SQL
         /// </summary>
         public string UpdateRangeSQL(LOGIN_VEHICLE_INFO model, string p_strWhere)
         {
             return g_DAL.UpdateRangeSQL(model, p_strWhere);
         }

         /// <summary>
         /// 修改一个集合
         /// </summary>
         public bool UpdateRange(LOGIN_VEHICLE_INFO model, string p_strWhere)
         {
             return g_DAL.UpdateRange(model, p_strWhere);
         }

         /// <summary>
         /// 修改全部数据 SQL
         /// </summary>
         public string UpdateAllSQL(LOGIN_VEHICLE_INFO model)
         {
             return g_DAL.UpdateAllSQL(model);
         }

         /// <summary>
         /// 修改全部数据
         /// </summary>
         public bool UpdateAll(LOGIN_VEHICLE_INFO model)
         {
             return g_DAL.UpdateAll(model);
         }

         /// <summary>
         /// 删除一条数据 SQL
         /// </summary>
         public string DeleteSQL(int intID)
         {
             return g_DAL.DeleteSQL(intID);
         }

         /// <summary>
         /// 删除一条数据
         /// </summary>
         public bool Delete(int intID)
         {
             return g_DAL.Delete(intID);
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
         public LOGIN_VEHICLE_INFO GetModel(int intID)
         {
             return g_DAL.GetModel(intID);
         }

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public void GetModel(ref DataTable p_dtData, int intID)
         {
             g_DAL.GetModel(ref p_dtData, intID);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
          public LOGIN_VEHICLE_INFO[] GetModelList(string p_strWhere, string p_strOrder, int p_intPageNumber, int p_intPageSize)
         {
             return g_DAL.GetModelList(p_strWhere, p_strOrder, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public LOGIN_VEHICLE_INFO[] GetModelList(string p_strWhere)
         {
             return g_DAL.GetModelList(p_strWhere);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public LOGIN_VEHICLE_INFO[] GetModelList(string p_strWhere, string p_strOrder)
         {
             return g_DAL.GetModelList(p_strWhere, p_strOrder);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public LOGIN_VEHICLE_INFO[] GetModelList(int p_intPageNumber, int p_intPageSize)
         {
             return g_DAL.GetModelList(p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public LOGIN_VEHICLE_INFO[] GetModelList(string p_strWhere, int p_intPageNumber, int p_intPageSize)
         {
             return g_DAL.GetModelList(p_strWhere, p_intPageNumber, p_intPageSize);
         }

         /// <summary>
         /// 得到对象集合
         /// </summary>
         public LOGIN_VEHICLE_INFO[] GetModelList()
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
