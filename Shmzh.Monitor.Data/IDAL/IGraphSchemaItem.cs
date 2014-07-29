using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 方案信息的数据访问接口。
    /// </summary>
    public interface IGraphSchemaItem
    {
        /// <summary>
        /// 获取所有的曲线方案项。
        /// </summary>
        /// <returns>所有的曲线方案项。</returns>
        List<GraphSchemaItemInfo> GetAll();
        /// <summary>
        /// 根据方案项Id获取曲线方案项。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线方案项实体。</returns>
        GraphSchemaItemInfo GetById(Int32 itemId);
        /// <summary>
        /// 根据曲线方案Id获取所有的
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线方案项集合。</returns>
        List<GraphSchemaItemInfo> GetBySchemaId(int schemaId);
        /// <summary>
        /// 根据曲线方案项Id进行删除。
        /// </summary>
        /// <param name="schemaItemId">曲线方案项Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 schemaItemId);
        /// <summary>
        /// 删除曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        bool Delete(GraphSchemaItemInfo itemInfo);
        /// <summary>
        /// 添加曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>int</returns>
        int Insert(GraphSchemaItemInfo itemInfo);
        /// <summary>
        /// 修改曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        bool Update(GraphSchemaItemInfo itemInfo);
        /// <summary>
        /// 曲线方案 Item 移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns>bool</returns>
        Boolean Move(Int32 itemId, Byte opType);
        /// <summary>
        /// 添加曲线方案项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="itemInfo">曲线方案项</param>
        /// <returns>int</returns>
        int InsertWithTrans(SqlTransaction trans, GraphSchemaItemInfo itemInfo);
    }
}
