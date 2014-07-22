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
    public interface IFloatingBlock
    {
        /// <summary>
        /// 获取所有浮动窗口.
        /// </summary>
        /// <returns>所有浮动窗口.</returns>
        List<FloatingBlockInfo> GetAll();
        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        FloatingBlockInfo GetById(Int32 blockId);
        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        List<FloatingBlockInfo> GetBySchemaId(int schemaId);
        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="blockId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 blockId);
        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Delete(FloatingBlockInfo blockInfo);
        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>int</returns>
        int Insert(FloatingBlockInfo blockInfo);
        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Update(FloatingBlockInfo blockInfo);
        /// <summary>
        /// 添加曲线方案关联项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="blockInfo">浮动窗体对象.</param>
        /// <returns>int</returns>
        int InsertWithTrans(SqlTransaction trans, FloatingBlockInfo blockInfo);
    }
}
