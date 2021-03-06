﻿using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class DigitalProvider :IDigital
    {
        #region Implementation of IDigital

        /// <summary>
        /// 根据指定的时间来获取数字量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>数字量指标数据。</returns>
        public abstract List<DigitalInfo> GetByTime(DateTime time);

        /// <summary>
        /// 根据指定的时间来同步数字量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>bool</returns>
        public abstract bool SyncByTime(DateTime time);

        #endregion
    }
}
