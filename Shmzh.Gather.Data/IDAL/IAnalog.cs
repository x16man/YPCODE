using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    /// <summary>
    /// 模拟量指标的数据访问接口。
    /// </summary>
    public interface IAnalog
    {
        /// <summary>
        /// 根据指定的时间来获取模拟量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>数字量指标数据。</returns>
        List<AnalogInfo> GetByTime(DateTime time);

        /// <summary>
        /// 根据指定的时间来同步模拟量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>bool</returns>
        bool SyncByTime(DateTime time);
    }
}
