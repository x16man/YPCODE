using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
namespace Shmzh.Monitor.Data.Service
{
    class ObjType:IDAL.IObjType
    {
        #region Implementation of IObjType

        /// <summary>
        /// 根据Id获取监控对象类型.
        /// </summary>
        /// <param name="id">监控对象类型Id.</param>
        /// <returns>监控对象类型对象.</returns>
        public ObjTypeInfo GetById(int id)
        {
            var obj = new ObjTypeService.ObjType().GetById(id);
            ObjTypeInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new ObjTypeInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 获取所有的监控对象类型对象.
        /// </summary>
        /// <returns>所有的监控对象类型对象.</returns>
        public List<ObjTypeInfo> GetAll()
        {
            var objs = new ObjTypeService.ObjType().GetAll();
            var obj1s = new List<ObjTypeInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new ObjTypeInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据上级Id获取监控对象类型对象集合.
        /// </summary>
        /// <param name="parentId">上级Id.</param>
        /// <returns>监控对象类型对象集合.</returns>
        public List<ObjTypeInfo> GetByParentId(int parentId)
        {
            var objs = new ObjTypeService.ObjType().GetByParentId(parentId);
            var obj1s = new List<ObjTypeInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new ObjTypeInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 删除监控对象类型对象.
        /// </summary>
        /// <param name="id">监控对象类型对象Id.</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            return new ObjTypeService.ObjType().Delete(id);
        }

        /// <summary>
        /// 删除监控对象类型对象
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public bool Delete(ObjTypeInfo objTypeInfo)
        {
            return Delete(objTypeInfo.Id);
        }

        /// <summary>
        /// 添加监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public int Insert(ObjTypeInfo objTypeInfo)
        {
            var obj = new ObjTypeService.ObjTypeInfo();
            CopyHelper.Copy(objTypeInfo, obj);
            
            return new ObjTypeService.ObjType().Insert(obj);
        }

        /// <summary>
        /// 更新监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public bool Update(ObjTypeInfo objTypeInfo)
        {
            var obj = new ObjTypeService.ObjTypeInfo();
            CopyHelper.Copy(objTypeInfo, obj);
            return new ObjTypeService.ObjType().Update(obj);
        }

        #endregion
    }
}
