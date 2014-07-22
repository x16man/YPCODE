using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Services;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using MemcachedProviders.Cache;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// TagDay 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/",Description="指标的天数据的WebService的访问接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagDay : System.Web.Services.WebService,ITagDay
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Property
        /// <summary>
        /// 是否使用Cache.
        /// </summary>
        private bool IsUsingCache
        {
            get
            {
                Logger.Info(ConfigurationManager.AppSettings["IsUsingCache"]);
                Logger.Info(ConfigurationManager.AppSettings["IsUsingCache"] == "1");
                return ConfigurationManager.AppSettings["IsUsingCache"] == "1";
            }
        }
        #endregion

        #region ITagDay 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标id.</param>
        /// <param name="beginCycleId">开始时间Id.</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间Id、结束时间Id来获取天表的数据集合。")]
        public List<TagDayInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagDayProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。")]
        public List<TagDayInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagDayProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        [WebMethod(Description="根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。")]
        public List<TagDayInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagDayProvider.Get_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表数据集合。</returns>
        [WebMethod(Description="根据指定的指标Id串、开始时间、结束时间来获取天表的数据集合。")]
        public List<TagDayInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagDayProvider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }

        /// <summary>
        /// 根据指标Id获取最新的天表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>最新的天表数据。</returns>
        [WebMethod(Description="根据指标Id获取最新的天表数据。")]
        public TagDayInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Info(string.Format("this.IsUsingCache is {0}", this.IsUsingCache));
            if (this.IsUsingCache == true)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestDayTagData) as List<TagDayInfo>;
                if (objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if (obj != null)
                    {
                        Logger.Info(string.Format("{0}'s Day Data is Found in MemCache", tagId));
                        return obj;
                    }
                    else
                    {
                        Logger.Info(string.Format("{0}'s Day Data is not Found in MemCache", tagId));
                        return DataProvider.TagDayProvider.Get_Latest_By_TagId(tagId);
                    }
                }
                else
                {
                    Logger.Info(string.Format("The MemCache is not exist."));
                    return DataProvider.TagDayProvider.Get_Latest_By_TagId(tagId);
                }
            }
            else
            {
                Logger.Info(string.Format("{0}'s Day Data is not using MemCache", tagId));
                return DataProvider.TagDayProvider.Get_Latest_By_TagId(tagId);
            }
        }

        /// <summary>
        /// 根据指标Id串获取最新的天表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>天表数据集合。</returns>
        [WebMethod(Description="根据指标Id串获取最新的天表数据集合。")]
        public List<TagDayInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Info(string.Format("this.IsUsingCache is {0}", this.IsUsingCache));
            if(this.IsUsingCache == true)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestDayTagData) as List<TagDayInfo>;
                if(objs != null && objs.Count > 0)
                {
                    var results = objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id)>=0);
                    if (results.Count > 0)
                    {
                        Logger.Info(string.Format("{0}'s Day Data is Found in MemCache", tagIds));
                        return results as List<TagDayInfo>;
                    }
                    else
                    {
                        Logger.Info(string.Format("{0}'s Day Data is not Found in MemCache", tagIds));
                        return DataProvider.TagDayProvider.Get_Latest_By_TagIds(tagIds);
                    }
                }
                else
                {
                    return DataProvider.TagDayProvider.Get_Latest_By_TagIds(tagIds);
                }
            }
            else
            {
                Logger.Info(string.Format("{0}'s Day Data is not using MemCache", tagIds));

                return DataProvider.TagDayProvider.Get_Latest_By_TagIds(tagIds);
            }
        }

        /// <summary>
        /// 获取最新的日表数据。
        /// </summary>
        /// <returns>日表数据集合。</returns>
        [WebMethod(Description="获取最新的日表数据。")]
        public List<TagDayInfo> Get_Latest_All()
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestDayTagData) as List<TagDayInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    return DataProvider.TagDayProvider.Get_Latest_All();
                }
            }
            else
            {
                return DataProvider.TagDayProvider.Get_Latest_All();
            }
        }

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
        [WebMethod(Description="气温、水量与指标关系查询。")] 
        public List<TagDayInfo> TagAndTemperatureAnalyze(String tagIds, String temperatureTagHigh, String temperatureTagLow,
            String waterTag, int beginCycleId, int endCycleId, double beginWater, double endWater,
            double beginTemperature, double endTemperature)
        {
            return DataProvider.TagDayProvider.TagAndTemperatureAnalyze(tagIds, temperatureTagHigh, temperatureTagLow,
                    waterTag, beginCycleId, endCycleId, beginWater, endWater, beginTemperature, 
                    endTemperature);
        }

        #endregion

        #region ITagDay 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。")]
        public List<TagDayInfo> Get_OLHC_By_Tag_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagDayProvider.Get_OLHC_By_Tag_CycleId(tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。")]
        public List<TagDayInfo> Get_OLHC_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagDayProvider.Get_OLHC_By_TagId_DateTime(tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagIds">指标Id串</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。")]
        public List<TagDayInfo> Get_OLHC_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagDayProvider.Get_OLHC_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagIds">指标Id串</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。")]
        public List<TagDayInfo> Get_OLHC_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagDayProvider.Get_OLHC_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }

        #endregion
    }
}
