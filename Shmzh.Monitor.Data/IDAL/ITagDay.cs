﻿using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 天表数据的数据访问接口。
    /// </summary>
    public interface ITagDay
    {
        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标id.</param>
        /// <param name="beginCycleId">开始时间Id.</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        List<TagDayInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId);
        
        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        List<TagDayInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime);
        
        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        List<TagDayInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId);
        
        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表数据集合。</returns>
        List<TagDayInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime);
        
        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合</returns>
        List<TagDayInfo> Get_OLHC_By_Tag_CycleId(string tagId, int beginCycleId, int endCycleId);
        
        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合</returns>
        List<TagDayInfo> Get_OLHC_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime);
        
        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagIds">指标Id串</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        List<TagDayInfo> Get_OLHC_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId);
        
        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagIds">指标Id串</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        List<TagDayInfo> Get_OLHC_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime);
        
        /// <summary>
        /// 根据指标Id获取最新的天表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>最新的天表数据。</returns>
        TagDayInfo Get_Latest_By_TagId(string tagId);
        
        /// <summary>
        /// 根据指标Id串获取最新的天表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>天表数据集合。</returns>
        List<TagDayInfo> Get_Latest_By_TagIds(string tagIds);

        /// <summary>
        /// 获取最新的日表数据。
        /// </summary>
        /// <returns>日表数据集合。</returns>
        List<TagDayInfo> Get_Latest_All();

        /// <summary>
        /// 气温、水量与指标关系查询。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。不包含当日最高气温指标、当日最低气温指标和总出厂水量指标。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <param name="temperatureTagHigh">当日最高气温指标。</param>
        /// <param name="temperatureTagLow">当日最低气温指标。</param>
        /// <param name="waterTag">总出厂水量指标。</param>
        /// <param name="beginTemperature">最低气温。</param>
        /// <param name="endTemperature">最高气温。</param>
        /// <param name="beginWater">最小水量。</param>
        /// <param name="endWater">最大水量。</param>
        /// <returns>天表的数据集合</returns>
        List<TagDayInfo> TagAndTemperatureAnalyze(String tagIds, String temperatureTagHigh, String temperatureTagLow,
            String waterTag, int beginCycleId, int endCycleId, double beginWater, double endWater,
            double beginTemperature, double endTemperature);
    }
}
