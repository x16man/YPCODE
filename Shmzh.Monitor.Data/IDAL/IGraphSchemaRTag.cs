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
    public interface IGraphSchemaRTag
    {
        /// <summary>
        /// 获取所有的GraphSchemaRTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaRTagInfo.</returns>
        List<GraphSchemaRTagInfo> GetAll();
        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        GraphSchemaRTagInfo GetById(Int32 keyId);
        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="tabId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        List<GraphSchemaRTagInfo> GetByTabId(int tabId);
        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 rTagId);
        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Delete(GraphSchemaRTagInfo rTagInfo);
        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Insert(GraphSchemaRTagInfo rTagInfo);
        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Update(GraphSchemaRTagInfo rTagInfo);

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        Boolean Move(Int32 keyId, Byte opType);

        /// <summary>
        /// 添加曲线方案关联项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="rTagInfo">曲线方案关联项对象.</param>
        /// <returns>bool</returns>
        Boolean InsertWithTrans(SqlTransaction trans, GraphSchemaRTagInfo rTagInfo);
    }
}
