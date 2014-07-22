using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 方案信息的数据访问接口。
    /// </summary>
    public interface IGraphSchemaTab
    {
        /// <summary>
        /// 获取所有的GraphSchemaTabInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTabInfo.</returns>
        List<GraphSchemaTabInfo> GetAll();
        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        GraphSchemaTabInfo GetById(Int32 keyId);
        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        List<GraphSchemaTabInfo> GetBySchemaId(int schemaId);
        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="tabId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 tabId);
        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Delete(GraphSchemaTabInfo tabInfo);
        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>int</returns>
        int Insert(GraphSchemaTabInfo tabInfo);
        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Update(GraphSchemaTabInfo tabInfo);

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        Boolean Move(Int32 keyId, Byte opType);

        /// <summary>
        /// 添加曲线方案关联项
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="tabInfo">曲线方案关联项对象</param>
        /// <returns>int</returns>
        int InsertWithTrans(SqlTransaction trans, GraphSchemaTabInfo tabInfo);
    }
}
