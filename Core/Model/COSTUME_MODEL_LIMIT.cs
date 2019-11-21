using System;
using System.Collections.Generic;

namespace Model
{
     ///<summary>
     ///实体类COSTUME_MODEL_LIMIT
     ///</summary>
     public class COSTUME_MODEL_LIMIT
     {
         private string __MODEL_NAME=string.Empty;
         private string __METHOD_NAME=string.Empty;

         private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


         public COSTUME_MODEL_LIMIT()
         {
             this.__Changed.Add("MODEL_NAME",false);
             this.__Changed.Add("METHOD_NAME",false);
         }

         /// <summary>
         /// 将类重置到初始化状态
         /// </summary>
         public void Reset()
         {
             this.__MODEL_NAME =string.Empty;
             this.__METHOD_NAME =string.Empty;
             this.__Changed["MODEL_NAME"] = false;
             this.__Changed["METHOD_NAME"] = false;
         }

         /// <summary>
         /// 获取类中成员的改变状态
         /// </summary>
         public bool Changed(string strKey)
         {
             return __Changed[strKey];
         }

         /// <summary>
         ///设置或获取类中的[MODEL_NAME]的数据
         /// </summary>
         public string MODEL_NAME
         {
              set{ __MODEL_NAME = value.Replace("'","’"); __Changed["MODEL_NAME"] = true;}
              get{return __MODEL_NAME;}
         }
         /// <summary>
         ///设置或获取类中的[METHOD_NAME]的数据
         /// </summary>
         public string METHOD_NAME
         {
              set{ __METHOD_NAME = value.Replace("'","’"); __Changed["METHOD_NAME"] = true;}
              get{return __METHOD_NAME;}
         }
    }
}
