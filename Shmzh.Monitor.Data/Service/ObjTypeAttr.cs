using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class ObjTypeAttr:IDAL.IObjTypeAttr
    {
        #region Implementation of IObjTypeAttr

        /// <summary>
        /// 根据方案Id获取设备分类属性实体。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>设备分类属性实体。</returns>
        public ObjTypeAttrInfo GetById(int id)
        {
            var obj = new ObjTypeAttrService.ObjTypeAttr().GetById(id);
            ObjTypeAttrInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new ObjTypeAttrInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据设备分类Id获取设备分类属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备分类属性集合。</returns>
        public List<ObjTypeAttrInfo> GetByTypeId(int typeId)
        {
            var objs = new ObjTypeAttrService.ObjTypeAttr().GetByTypeId(typeId);
            var obj1s = new List<ObjTypeAttrInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new ObjTypeAttrInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据设备分类属性Id来删除设备分类属性。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            return new ObjTypeAttrService.ObjTypeAttr().Delete(id);
        }

        /// <summary>
        /// 删除设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public bool Delete(ObjTypeAttrInfo objTypeAttrInfo)
        {
            return Delete(objTypeAttrInfo.Id);
        }

        /// <summary>
        /// 添加设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public int Insert(ObjTypeAttrInfo objTypeAttrInfo)
        {
            var obj = new ObjTypeAttrService.ObjTypeAttrInfo();
            CopyHelper.Copy( objTypeAttrInfo, obj);
            
            return new ObjTypeAttrService.ObjTypeAttr().Insert(obj);
        }

        /// <summary>
        /// 修改设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public bool Update(ObjTypeAttrInfo objTypeAttrInfo)
        {
            var obj = new ObjTypeAttrService.ObjTypeAttrInfo();
            CopyHelper.Copy(objTypeAttrInfo, obj);
            return new ObjTypeAttrService.ObjTypeAttr().Update(obj);
        }

        #endregion
    }
}
