using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 分钟表的数据访问接口。
    /// </summary>
    public interface ITagMinute
    {
        /// <summary>
        /// 根据指定的日期、单个指标Id、开始时间Id、结束时间Id来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id(第几分钟)。</param>
        /// <param name="endCycleId">结束时间Id(第几分钟)。</param>
        /// <returns>分钟数据集合。</returns>
        List<TagMinuteInfo> Get_By_Date_TagId_CycleId(DateTime date, string tagId, int beginCycleId, int endCycleId);

        /// <summary>
        /// 根据指定的日期、单个指标Id、开始时间、结束时间来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>分钟数据集合</returns>
        List<TagMinuteInfo> Get_By_Date_TagId_DateTime(DateTime date, string tagId, DateTime beginTime, DateTime endTime);

        /// <summary>
        /// 根据指定的日期、多个指标Id、开始时间Id、结束时间Id来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagIds">指标Id字符串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id(第几分钟)。</param>
        /// <param name="endCycleId">结束时间Id(第几分钟)。</param>
        /// <returns>分钟数据集合</returns>
        List<TagMinuteInfo> Get_By_Date_TagIds_CycleId(DateTime date, string tagIds, int beginCycleId, int endCycleId);

        /// <summary>
        /// 根据指定的日期、多个指标Id、开始时间、结束时间来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagIds">指标Id字符串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>分钟数据集合</returns>
        List<TagMinuteInfo> Get_By_Date_TagIds_DateTime(DateTime date, string tagIds, DateTime beginTime,
                                                        DateTime endTime);

        /// <summary>
        /// 根据Id获取最新的分钟表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>分钟数据实体。</returns>
        TagMinuteInfo Get_Latest_By_TagId(string tagId);

        /// <summary>
        /// 根据指标Id串来获取最新的分钟表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        List<TagMinuteInfo> Get_Latest_By_TagIds(string tagIds);

        /// <summary>
        /// 获取所有最新的分钟数据。
        /// </summary>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        List<TagMinuteInfo> Get_Latest_All();
    }
}
