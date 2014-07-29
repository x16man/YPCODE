using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using MemcachedProviders.Cache;


namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// 指标的分钟的WebService接口.
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/", Description = "指标分钟数据的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagMinute : System.Web.Services.WebService,ITagMinute
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Property
        private static bool IsUsingCache
        {
            get
            {
                return ConfigurationManager.AppSettings["IsUsingCache"] == "1";
            }
        }
        #endregion

        #region ITagMinute 成员

        /// <summary>
        /// 根据指定的日期、单个指标Id、开始时间Id、结束时间Id来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id(第几分钟)。</param>
        /// <param name="endCycleId">结束时间Id(第几分钟)。</param>
        /// <returns>分钟数据集合。</returns>
        [WebMethod(Description = "根据指标Id和日期以及日期的从第几分钟(整型)到第几分钟(整型)所指定的时间范围,来获取指标的分钟数据.")]
        public List<TagMinuteInfo> Get_By_Date_TagId_CycleId(DateTime date, string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagMinuteProvider.Get_By_Date_TagId_CycleId(date, tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的日期、单个指标Id、开始时间、结束时间来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>分钟数据集合</returns>
        [WebMethod(Description = "根据指标Id和日期以及日期的开始时间(日期型)到结束时间(日期型)所指定的时间范围,来获取指标的分钟数据.")]
        public List<TagMinuteInfo> Get_By_Date_TagId_DateTime(DateTime date, string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagMinuteProvider.Get_By_Date_TagId_DateTime(date, tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的日期、多个指标Id、开始时间Id、结束时间Id来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagIds">指标Id字符串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id(第几分钟)。</param>
        /// <param name="endCycleId">结束时间Id(第几分钟)。</param>
        /// <returns>分钟数据集合</returns>
        [WebMethod(Description = "根据指标Id串(例如:'1001001','1001002')和日期以及日期的从第几分钟(整型)到第几分钟(整型)所指定的时间范围,来获取指标的分钟数据.")]
        public List<TagMinuteInfo> Get_By_Date_TagIds_CycleId(DateTime date, string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagMinuteProvider.Get_By_Date_TagIds_CycleId(date, tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的日期、多个指标Id、开始时间、结束时间来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagIds">指标Id字符串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>分钟数据集合</returns>
        [WebMethod(Description = "根据指标Id串(例如:'1001001','1001002')和日期以及日期的开始时间(日期型)到结束时间(日期型)所指定的时间范围,来获取指标的分钟数据.")]
        public List<TagMinuteInfo> Get_By_Date_TagIds_DateTime(DateTime date, string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagMinuteProvider.Get_By_Date_TagIds_DateTime(date, tagIds, beginTime, endTime);
        }

        /// <summary>
        /// 根据Id获取最新的分钟表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>分钟数据实体。</returns>
        [WebMethod(Description="根据指标Id获取指标的最新的分钟数据.")]
        public TagMinuteInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagMinute.Get_Latest_By_TagId({0})",tagId));
            if(IsUsingCache)
            {
                var sw = new Stopwatch();
                sw.Start();
                var objs = DistCache.Get(CacheKeyEnum.LatestMinuteTagData) as List<TagMinuteInfo>;
                sw.Stop();
                Logger.Debug(string.Format("DistCache.Get(CacheKeyEnum.LatestMinuteTagData) as List<TagMinuteInfo> spend {0} Milliseconds", sw.ElapsedMilliseconds));
                
                if(objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if (obj != null)
                        return obj;
                    else
                    {
                        Logger.Debug(string.Format("{0}'s Minute Data not found in MemCache Data.Get it from database.",tagId));
                        return DataProvider.TagMinuteProvider.Get_Latest_By_TagId(tagId);
                    }
                }
                else
                {
                    Logger.Debug(string.Format("{0} The Cache is not exists the Tag's minute's data,get it from database.", tagId));
                    return DataProvider.TagMinuteProvider.Get_Latest_By_TagId(tagId);
                }
            }
            else
            {
                Logger.Debug("Get Tag's Minute Data not using cache.");
                return DataProvider.TagMinuteProvider.Get_Latest_By_TagId(tagId);
            }
        }

        /// <summary>
        /// 根据指标Id串来获取最新的分钟表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        [WebMethod(Description="根据指标Id串(例如:'1001001','1001002'),来获取多个指标的最新的分钟数据.")]
        public List<TagMinuteInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagMinute.Get_Latest_By_TagIds({0})",tagIds));
            if (IsUsingCache)
            {
                var sw = new Stopwatch();
                sw.Start();
                var objs = DistCache.Get(CacheKeyEnum.LatestMinuteTagData) as List<TagMinuteInfo>;
                sw.Stop();
                Logger.Debug(string.Format("DistCache.Get(CacheKeyEnum.LatestMinuteTagData) as List<TagMinuteInfo> spend {0} Milliseconds", sw.ElapsedMilliseconds));

                if (objs != null && objs.Count > 0)
                {
                    var results = objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id)>=0);
                    if (results != null && results.Count > 0)
                        return results;
                    else
                    {
                        Logger.Debug(string.Format("{0}'s minute data not found in MemCache,get it from database", tagIds));
                        return DataProvider.TagMinuteProvider.Get_Latest_By_TagIds(tagIds);
                    }
                }
                else
                {
                    Logger.Debug(string.Format("{0} The Cache is not exists the Tag's minute's data,get it from database.", tagIds));
                    return DataProvider.TagMinuteProvider.Get_Latest_By_TagIds(tagIds);
                }
            }
            else
            {
                Logger.Debug(string.Format("Get {0} Tag's Minute Data not using cache.Get it from database.",tagIds));
                return DataProvider.TagMinuteProvider.Get_Latest_By_TagIds(tagIds);
            }
        }

        /// <summary>
        /// 获取所有最新的分钟数据。
        /// </summary>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        [WebMethod(Description="获取所有指标(有分钟数据的指标)的最新的分钟数据.")]
        public List<TagMinuteInfo> Get_Latest_All()
        {
            Logger.Debug("TagMinute.Get_Latest_All()");

            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMinuteTagData) as List<TagMinuteInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    Logger.Debug("The MemCache Not Exists the Minute Data.Get it from database.");
                    return DataProvider.TagMinuteProvider.Get_Latest_All();
                }
            }
            else
            {
                Logger.Debug(string.Format("Get All Tag's Minute Data not using cache.Get it from database."));
                return DataProvider.TagMinuteProvider.Get_Latest_All();
            }
            
        }

        #endregion
    }
}
