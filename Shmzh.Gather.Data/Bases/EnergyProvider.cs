using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class EnergyProvider :IEnergy
    {
        #region Implementation of IEnergy

        /// <summary>
        /// 根据指定的时间来获取电量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>数字量指标数据。</returns>
        public abstract List<EnergyInfo> GetByTime(DateTime time);

        /// <summary>
        /// 根据指定的时间来同步电量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>bool</returns>
        public abstract bool SyncByTime(DateTime time);

        #endregion
    }
}
