using System.Collections.Generic;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 方案信息的数据访问接口。
    /// </summary>
    public interface IMonitorObj
    {
        /// <summary>
        /// 根据监测对象分类Id获取检测对象属性记录实体。
        /// </summary>
        /// <param name="id">设备分类Id。</param>
        /// <returns>监测对象实体。</returns>
        MonitorObjInfo GetById(int id);
        /// <summary>
        /// 根据编号获取监测对象。
        /// </summary>
        /// <param name="code">编号。</param>
        /// <returns>监测对象。</returns>
        MonitorObjInfo GetByCode(string code);
        /// <summary>
        /// 获取所有的检测对象属性集合。
        /// </summary>
        /// <returns>检测对象集合。</returns>
        List<MonitorObjInfo> GetAll();

        /// <summary>
        /// 根据设备分类Id获取设备属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备属性集合。</returns>
        List<MonitorObjInfo> GetByTypeId(int typeId);

        /// <summary>
        /// 根据监测对象和指定的属性字段名称获取属性值。
        /// </summary>
        /// <param name="monitorObjCode">监测对象编号。</param>
        /// <param name="attrFieldName">属性字段名称。</param>
        /// <returns>属性值。</returns>
        string GetAttributeValue(string monitorObjCode, string attrFieldName);
        
        /// <summary>
        /// 根据监测对象Id来删除监测对象。
        /// </summary>
        /// <param name="id">监测对象Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// 删除监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        bool Delete(MonitorObjInfo monitorObjInfo);

        /// <summary>
        /// 添加监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>int</returns>
        int Insert(MonitorObjInfo monitorObjInfo);

        /// <summary>
        /// 监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        bool Update(MonitorObjInfo monitorObjInfo);
    }
}
