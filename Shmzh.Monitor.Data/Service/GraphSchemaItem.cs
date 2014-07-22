using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
namespace Shmzh.Monitor.Data.Service
{
    class GraphSchemaItem:IDAL.IGraphSchemaItem
    {
        #region Implementation of IGraphSchemaItem

        /// <summary>
        /// 获取所有的曲线方案项。
        /// </summary>
        /// <returns>所有的曲线方案项。</returns>
        public List<GraphSchemaItemInfo> GetAll()
        {

            var objs = new GraphSchemaItemService.GraphSchemaItem().GetAll();
            var obj1s = new List<GraphSchemaItemInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GraphSchemaItemInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据方案项Id获取曲线方案项。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线方案项实体。</returns>
        public GraphSchemaItemInfo GetById(int itemId)
        {
            var obj = new GraphSchemaItemService.GraphSchemaItem().GetById(itemId);
            GraphSchemaItemInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new GraphSchemaItemInfo();
                CopyHelper.Copy(obj,obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据曲线方案Id获取所有的
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线方案项集合。</returns>
        public List<GraphSchemaItemInfo> GetBySchemaId(int schemaId)
        {
            var objs = new GraphSchemaItemService.GraphSchemaItem().GetBySchemaId(schemaId);
            var obj1s = new List<GraphSchemaItemInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new GraphSchemaItemInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案项Id进行删除。
        /// </summary>
        /// <param name="schemaItemId">曲线方案项Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int schemaItemId)
        {
            return new GraphSchemaItemService.GraphSchemaItem().Delete(schemaItemId);
        }

        /// <summary>
        /// 删除曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaItemInfo itemInfo)
        {
            return Delete(itemInfo.ItemId);
        }

        /// <summary>
        /// 添加曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        public int Insert(GraphSchemaItemInfo itemInfo)
        {
            var obj = new GraphSchemaItemService.GraphSchemaItemInfo();
            CopyHelper.Copy(itemInfo,obj);
            //return 0;
            return new GraphSchemaItemService.GraphSchemaItem().Insert(obj);
        }

        /// <summary>
        /// 添加曲线方案项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="itemInfo">曲线方案项</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, GraphSchemaItemInfo itemInfo)
        {
            //return 0;
            return DataProvider.GraphSchemaItemProvider.InsertWithTrans(trans, itemInfo);
        }

        /// <summary>
        /// 修改曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaItemInfo itemInfo)
        {
            var obj = new GraphSchemaItemService.GraphSchemaItemInfo();
            CopyHelper.Copy(itemInfo, obj);
            return new GraphSchemaItemService.GraphSchemaItem().Update(obj);
        }

        /// <summary>
        /// 曲线方案 Item 移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int itemId, byte opType)
        {
            return new GraphSchemaItemService.GraphSchemaItem().Move(itemId, opType);
        }

        #endregion
    }
}
