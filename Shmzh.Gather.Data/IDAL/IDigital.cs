using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    /// <summary>
    /// 数字量指标的数据访问接口。
    /// </summary>
    public interface IDigital
    {
        /// <summary>
        /// 根据指定的时间来获取数字量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>数字量指标数据。</returns>
        List<DigitalInfo> GetByTime(DateTime time);

        /// <summary>
        /// 根据指定的时间来同步数字量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>bool</returns>
        bool SyncByTime(DateTime time);
    }
}
