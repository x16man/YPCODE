using System.Collections.Generic;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 设备类别的数据访问接口。
    /// </summary>
    public interface IObjType
    {
        /// <summary>
        /// 根据Id获取监控对象类型.
        /// </summary>
        /// <param name="id">监控对象类型Id.</param>
        /// <returns>监控对象类型对象.</returns>
        ObjTypeInfo GetById(int id);
        /// <summary>
        /// 获取所有的监控对象类型对象.
        /// </summary>
        /// <returns>所有的监控对象类型对象.</returns>
        List<ObjTypeInfo> GetAll();
        /// <summary>
        /// 根据上级Id获取监控对象类型对象集合.
        /// </summary>
        /// <param name="parentId">上级Id.</param>
        /// <returns>监控对象类型对象集合.</returns>
        List<ObjTypeInfo> GetByParentId(int parentId);
        /// <summary>
        /// 删除监控对象类型对象.
        /// </summary>
        /// <param name="id">监控对象类型对象Id.</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 删除监控对象类型对象
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        bool Delete(ObjTypeInfo objTypeInfo);
        /// <summary>
        /// 添加监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        int Insert(ObjTypeInfo objTypeInfo);
        /// <summary>
        /// 更新监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        bool Update(ObjTypeInfo objTypeInfo);
    }
}
