using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class AnalogProvider :IAnalog
    {
        #region Implementation of IAnalog

        /// <summary>
        /// 根据指定的时间来获取模拟量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>数字量指标数据。</returns>
        public abstract List<AnalogInfo> GetByTime(DateTime time);

        /// <summary>
        /// 根据指定的时间来同步模拟量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>bool</returns>
        public abstract bool SyncByTime(DateTime time);

        #endregion
    }
}
