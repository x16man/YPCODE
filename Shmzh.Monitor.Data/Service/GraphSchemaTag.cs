using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Components.Util;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Data.Service
{
    class GraphSchemaTag :IDAL.IGraphSchemaTag
    {
        #region Implementation of IGraphSchemaTag

        /// <summary>
        /// 获取所有的GraphSchemaTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTagInfo.</returns>
        public List<GraphSchemaTagInfo> GetAll()
        {
            var objs = new GraphSchemaTagService.GraphSchemaTag().GetAll();
            var obj1s = new List<GraphSchemaTagInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GraphSchemaTagInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案项指标Id。</param>
        /// <returns>方案项指标信息实体。</returns>
        public GraphSchemaTagInfo GetById(int keyId)
        {
            var obj = new GraphSchemaTagService.GraphSchemaTag().GetById(keyId);
            GraphSchemaTagInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new GraphSchemaTagInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线指标集合。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<GraphSchemaTagInfo> GetBySchemaItemId(int itemId)
        {
            var objs = new GraphSchemaTagService.GraphSchemaTag().GetBySchemaItemId(itemId);
            var obj1s = new List<GraphSchemaTagInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new GraphSchemaTagInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案指标Id进行删除。
        /// </summary>
        /// <param name="schemaTagId">曲线方案指标Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int schemaTagId)
        {
            return new GraphSchemaTagService.GraphSchemaTag().Delete(schemaTagId);
        }

        /// <summary>
        /// 删除曲线方案指标。
        /// </summary>
        /// <param name="tagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaTagInfo tagInfo)
        {
            return Delete(tagInfo.KeyId);
        }

        /// <summary>
        /// 添加曲线方案指标。
        /// </summary>
        /// <param name="schemaTagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GraphSchemaTagInfo schemaTagInfo)
        {
            var obj = new GraphSchemaTagService.GraphSchemaTagInfo();
            CopyHelper.Copy(schemaTagInfo, obj);
            return new GraphSchemaTagService.GraphSchemaTag().Insert(obj);
        }

        public bool InsertWithTrans(SqlTransaction trans, GraphSchemaTagInfo tagInfo)
        {
            return DataProvider.GraphSchemaTagProvider.InsertWithTrans(trans, tagInfo);
        }

        /// <summary>
        /// 修改曲线方案指标。
        /// </summary>
        /// <param name="schemaTagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaTagInfo schemaTagInfo)
        {
            var obj = new GraphSchemaTagService.GraphSchemaTagInfo();
            CopyHelper.Copy(schemaTagInfo, obj);
            return new GraphSchemaTagService.GraphSchemaTag().Update(obj);
        }

        /// <summary>
        /// 图表方案指标项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int keyId, byte opType)
        {
            return new GraphSchemaTagService.GraphSchemaTag().Move(keyId, opType);
        }

        #endregion
    }
}
