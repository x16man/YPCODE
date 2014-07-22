using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 方案信息的数据访问接口。
    /// </summary>
    public interface IObjTypeAttr
    {
        /// <summary>
        /// 根据方案Id获取设备分类属性实体。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>设备分类属性实体。</returns>
        ObjTypeAttrInfo GetById(int id);
        /// <summary>
        /// 根据设备分类Id获取设备分类属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备分类属性集合。</returns>
        List<ObjTypeAttrInfo> GetByTypeId(int typeId);
        /// <summary>
        /// 根据设备分类属性Id来删除设备分类属性。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 删除设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        bool Delete(ObjTypeAttrInfo objTypeAttrInfo);
        /// <summary>
        /// 添加设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        int Insert(ObjTypeAttrInfo objTypeAttrInfo);
        /// <summary>
        /// 修改设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        bool Update(ObjTypeAttrInfo objTypeAttrInfo);
    }
}
