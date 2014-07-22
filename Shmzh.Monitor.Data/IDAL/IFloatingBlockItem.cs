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
    public interface IFloatingBlockItem
    {
        /// <summary>
        /// 获取所有FloatingBlockItemInfo.
        /// </summary>
        /// <returns>所有FloatingBlockItemInfo.</returns>
        List<FloatingBlockItemInfo> GetAll();
        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockItemId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        FloatingBlockItemInfo GetById(Int32 blockItemId);
        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="blockId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        List<FloatingBlockItemInfo> GetByBlockId(int blockId);
        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 rTagId);
        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Delete(FloatingBlockItemInfo blockItemInfo);
        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Insert(FloatingBlockItemInfo blockItemInfo);
        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        bool Update(FloatingBlockItemInfo blockItemInfo);

        /// <summary>
        /// 浮动窗口项移动。
        /// </summary>
        /// <param name="blockItemId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        bool Move(Int32 blockItemId, Byte opType);
        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="blockItemInfo">FloatingBlockItemInfo Instance.</param>
        /// <returns>bool</returns>
        bool InsertWithTrans(SqlTransaction trans, FloatingBlockItemInfo blockItemInfo);
    }
}
