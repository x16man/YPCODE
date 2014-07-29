using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
namespace Shmzh.Monitor.Data.Service
{
    class GraphSchemaTab:IDAL.IGraphSchemaTab
    {
        #region Implementation of IGraphSchemaTab

        /// <summary>
        /// 获取所有的GraphSchemaTabInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTabInfo.</returns>
        public List<GraphSchemaTabInfo> GetAll()
        {
            var objs = new GraphSchemaTabService.GraphSchemaTab().GetAll();
            var obj1s = new List<GraphSchemaTabInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GraphSchemaTabInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public GraphSchemaTabInfo GetById(int keyId)
        {
            var obj = new GraphSchemaTabService.GraphSchemaTab().GetById(keyId);
            GraphSchemaTabInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new GraphSchemaTabInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;

        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<GraphSchemaTabInfo> GetBySchemaId(int schemaId)
        {
            var objs = new GraphSchemaTabService.GraphSchemaTab().GetBySchemaId(schemaId);
            var obj1s = new List<GraphSchemaTabInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new GraphSchemaTabInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="tabId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int tabId)
        {
            return new GraphSchemaTabService.GraphSchemaTab().Delete(tabId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaTabInfo tabInfo)
        {
            return Delete(tabInfo.TabId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public int Insert(GraphSchemaTabInfo tabInfo)
        {
            var obj = new GraphSchemaTabService.GraphSchemaTabInfo();
            CopyHelper.Copy(tabInfo, obj);
            //return 0;
            return new GraphSchemaTabService.GraphSchemaTab().Insert(obj);
        }

        public int InsertWithTrans(SqlTransaction trans, GraphSchemaTabInfo tabInfo)
        {
            //return 0;
            return DataProvider.GraphSchemaTabProvider.InsertWithTrans(trans, tabInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaTabInfo tabInfo)
        {
            var obj = new GraphSchemaTabService.GraphSchemaTabInfo();
            CopyHelper.Copy(tabInfo, obj);
            return new GraphSchemaTabService.GraphSchemaTab().Update(obj);
        }

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int keyId, byte opType)
        {
            return new GraphSchemaTabService.GraphSchemaTab().Move(keyId, opType);
        }

        #endregion
    }
}
