using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class MonitorObj:IDAL.IMonitorObj
    {
        #region Implementation of IMonitorObj

        /// <summary>
        /// 根据监测对象分类Id获取检测对象属性记录实体。
        /// </summary>
        /// <param name="id">设备分类Id。</param>
        /// <returns>监测对象实体。</returns>
        public MonitorObjInfo GetById(int id)
        {
            var obj = new MonitorObjService.MonitorObj().GetById(id);
            MonitorObjInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new MonitorObjInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据编号获取监测对象。
        /// </summary>
        /// <param name="code">编号。</param>
        /// <returns>监测对象。</returns>
        public MonitorObjInfo GetByCode(string code)
        {
            var obj = new MonitorObjService.MonitorObj().GetByCode(code);
            MonitorObjInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new MonitorObjInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;

            
        }

        /// <summary>
        /// 获取所有的检测对象属性集合。
        /// </summary>
        /// <returns>检测对象集合。</returns>
        public List<MonitorObjInfo> GetAll()
        {
            var objs = new MonitorObjService.MonitorObj().GetAll();
            var obj1s = new List<MonitorObjInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new MonitorObjInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据设备分类Id获取设备属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备属性集合。</returns>
        public List<MonitorObjInfo> GetByTypeId(int typeId)
        {
            var objs = new MonitorObjService.MonitorObj().GetByTypeId(typeId);
            var obj1s = new List<MonitorObjInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new MonitorObjInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据监测对象和指定的属性字段名称获取属性值。
        /// </summary>
        /// <param name="monitorObjCode">监测对象编号。</param>
        /// <param name="attrFieldName">属性字段名称。</param>
        /// <returns>属性值。</returns>
        public string GetAttributeValue(string monitorObjCode, string attrFieldName)
        {
            return new MonitorObjService.MonitorObj().GetAttributeValue(monitorObjCode, attrFieldName);
        }

        /// <summary>
        /// 根据监测对象Id来删除监测对象。
        /// </summary>
        /// <param name="id">监测对象Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            return new MonitorObjService.MonitorObj().Delete(id);
        }

        /// <summary>
        /// 删除监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        public bool Delete(MonitorObjInfo monitorObjInfo)
        {
            return Delete(monitorObjInfo.Id);
        }

        /// <summary>
        /// 添加监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>int</returns>
        public int Insert(MonitorObjInfo monitorObjInfo)
        {
            var obj = new MonitorObjService.MonitorObjInfo();
            CopyHelper.Copy(monitorObjInfo, obj);
            
            return new MonitorObjService.MonitorObj().Insert(obj);
        }

        /// <summary>
        /// 监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        public bool Update(MonitorObjInfo monitorObjInfo)
        {
            var obj = new MonitorObjService.MonitorObjInfo();
            CopyHelper.Copy(monitorObjInfo, obj);
            return new MonitorObjService.MonitorObj().Update(obj);
        }

        #endregion
    }
}
