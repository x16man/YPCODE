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
    public interface IGraphSchemaTag
    {
        /// <summary>
        /// 获取所有的GraphSchemaTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTagInfo.</returns>
        List<GraphSchemaTagInfo> GetAll();
        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案项指标Id。</param>
        /// <returns>方案项指标信息实体。</returns>
        GraphSchemaTagInfo GetById(Int32 keyId);

        /// <summary>
        /// 根据曲线方案项Id获取曲线指标集合。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线指标集合。</returns>
        List<GraphSchemaTagInfo> GetBySchemaItemId(int itemId);

        /// <summary>
        /// 根据曲线方案指标Id进行删除。
        /// </summary>
        /// <param name="schemaTagId">曲线方案指标Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 schemaTagId);

        /// <summary>
        /// 删除曲线方案指标。
        /// </summary>
        /// <param name="tagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        bool Delete(GraphSchemaTagInfo tagInfo);

        /// <summary>
        /// 添加曲线方案指标。
        /// </summary>
        /// <param name="schemaTagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        bool Insert(GraphSchemaTagInfo schemaTagInfo);

        /// <summary>
        /// 修改曲线方案指标。
        /// </summary>
        /// <param name="schemaTagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        bool Update(GraphSchemaTagInfo schemaTagInfo);

        /// <summary>
        /// 图表方案指标项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        Boolean Move(Int32 keyId, Byte opType);

        /// <summary>
        /// 添加曲线方案指标.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="tagInfo">指标对象.</param>
        /// <returns>bool</returns>
        bool InsertWithTrans(SqlTransaction trans, GraphSchemaTagInfo tagInfo);
    }
}
