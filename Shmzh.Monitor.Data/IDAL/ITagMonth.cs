using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 月表数据的数据访问接口。
    /// </summary>
    public interface ITagMonth
    {
        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取月表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>月表数据集合。</returns>
        List<TagMonthInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId);
        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取月表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>月表数据集合。</returns>
        List<TagMonthInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime);
        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取月表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>月表数据集合</returns>
        List<TagMonthInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId);
        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取月表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>月表数据集合</returns>
        List<TagMonthInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime);
        /// <summary>
        /// 根据指定的Id获取最新的月表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>月表数据实体。</returns>
        TagMonthInfo Get_Latest_By_TagId(string tagId);
        /// <summary>
        /// 根据指定Id串获取最新的月表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>最新的月表数据。</returns>
        List<TagMonthInfo> Get_Latest_By_TagIds(string tagIds);

        /// <summary>
        /// 获取最新月表数据。
        /// </summary>
        /// <returns>最新的月表数据。</returns>
        List<TagMonthInfo> Get_Latest_All();
    }
}
