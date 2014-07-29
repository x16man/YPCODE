using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// MonitorObj 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MonitorObj : System.Web.Services.WebService,IMonitorObj
    {
        #region Implementation of IMonitorObj

        /// <summary>
        /// 根据监测对象分类Id获取检测对象属性记录实体。
        /// </summary>
        /// <param name="id">设备分类Id。</param>
        /// <returns>监测对象实体。</returns>
        [WebMethod]
        public MonitorObjInfo GetById(int id)
        {
            return DataProvider.MonitorObjProvider.GetById(id);
        }

        /// <summary>
        /// 根据编号获取监测对象。
        /// </summary>
        /// <param name="code">编号。</param>
        /// <returns>监测对象。</returns>
        [WebMethod]
        public MonitorObjInfo GetByCode(string code)
        {
            return DataProvider.MonitorObjProvider.GetByCode(code);
        }

        /// <summary>
        /// 获取所有的检测对象属性集合。
        /// </summary>
        /// <returns>检测对象集合。</returns>
        [WebMethod]
        public List<MonitorObjInfo> GetAll()
        {
            return DataProvider.MonitorObjProvider.GetAll();
        }

        /// <summary>
        /// 根据设备分类Id获取设备属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备属性集合。</returns>
        [WebMethod]
        public List<MonitorObjInfo> GetByTypeId(int typeId)
        {
            return DataProvider.MonitorObjProvider.GetByTypeId(typeId);
        }

        /// <summary>
        /// 根据监测对象和指定的属性字段名称获取属性值。
        /// </summary>
        /// <param name="monitorObjCode">监测对象编号。</param>
        /// <param name="attrFieldName">属性字段名称。</param>
        /// <returns>属性值。</returns>
        [WebMethod]
        public string GetAttributeValue(string monitorObjCode, string attrFieldName)
        {
            return DataProvider.MonitorObjProvider.GetAttributeValue(monitorObjCode, attrFieldName);
        }

        /// <summary>
        /// 根据监测对象Id来删除监测对象。
        /// </summary>
        /// <param name="id">监测对象Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int id)
        {
            return DataProvider.MonitorObjProvider.Delete(id);
        }

        /// <summary>
        /// 删除监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        public bool Delete(MonitorObjInfo monitorObjInfo)
        {
            return DataProvider.MonitorObjProvider.Delete(monitorObjInfo);
        }

        /// <summary>
        /// 添加监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>int</returns>
        [WebMethod]
        public int Insert(MonitorObjInfo monitorObjInfo)
        {
            return DataProvider.MonitorObjProvider.Insert(monitorObjInfo);
        }

        /// <summary>
        /// 监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(MonitorObjInfo monitorObjInfo)
        {
            return DataProvider.MonitorObjProvider.Update(monitorObjInfo);
        }

        #endregion
    }
}
