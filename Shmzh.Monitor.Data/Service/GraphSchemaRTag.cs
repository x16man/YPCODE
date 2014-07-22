using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class GraphSchemaRTag : IDAL.IGraphSchemaRTag
    {
        #region Implementation of IGraphSchemaRTag

        /// <summary>
        /// 获取所有的GraphSchemaRTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaRTagInfo.</returns>
        public List<GraphSchemaRTagInfo> GetAll()
        {
            var objs = new GraphSchemaRTagService.GraphSchemaRTag().GetAll();
            var obj1s = new List<GraphSchemaRTagInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GraphSchemaRTagInfo();
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
        public GraphSchemaRTagInfo GetById(int keyId)
        {
            var obj = new GraphSchemaRTagService.GraphSchemaRTag().GetById(keyId);
            GraphSchemaRTagInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new GraphSchemaRTagInfo();
                CopyHelper.Copy(obj,obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="tabId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<GraphSchemaRTagInfo> GetByTabId(int tabId)
        {
            var objs = new GraphSchemaRTagService.GraphSchemaRTag().GetByTabId(tabId);
            var obj1s = new List<GraphSchemaRTagInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new GraphSchemaRTagInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int rTagId)
        {
            return new GraphSchemaRTagService.GraphSchemaRTag().Delete(rTagId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaRTagInfo rTagInfo)
        {
            return Delete(rTagInfo.RTagId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GraphSchemaRTagInfo rTagInfo)
        {
            var obj = new GraphSchemaRTagService.GraphSchemaRTagInfo();
            CopyHelper.Copy(rTagInfo, obj);
            return new GraphSchemaRTagService.GraphSchemaRTag().Insert(obj);
        }

        public Boolean InsertWithTrans(SqlTransaction trans, GraphSchemaRTagInfo rTagInfo)
        {
            return DataProvider.GraphSchemaRTagProvider.InsertWithTrans(trans, rTagInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaRTagInfo rTagInfo)
        {
            var obj = new GraphSchemaRTagService.GraphSchemaRTagInfo();
            CopyHelper.Copy(rTagInfo, obj);
            return new GraphSchemaRTagService.GraphSchemaRTag().Update(obj);
        }

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int keyId, byte opType)
        {
            return new GraphSchemaRTagService.GraphSchemaRTag().Move(keyId, opType);
        }

        #endregion
    }
}
