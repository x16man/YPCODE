using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web.Services;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using MemcachedProviders.Cache;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// TagHour 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/",Description="指标小时数据的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagHour : WebService,ITagHour
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Property
        /// <summary>
        /// 是否使用缓存.
        /// </summary>
        private static bool IsUsingCache
        {
            get
            {
                return ConfigurationManager.AppSettings["IsUsingCache"] == "1";
            }
        }
        #endregion


        #region ITagHour 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取小时数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>小时数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间Id、结束时间Id来获取小时数据集合。")]
        public List<TagHourInfo> Get_BY_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagHourProvider.Get_BY_TagId_CycleId(tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取小时数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>小时数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取小时数据集合。")]
        public List<TagHourInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagHourProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取小时数据集合。
        /// </summary>
        /// <param name="tagIds">指标数据Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>小时数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间Id、结束时间Id来获取小时数据集合。")]
        public List<TagHourInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagHourProvider.Get_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取小时数据集合。
        /// </summary>
        /// <param name="tagIds">指标数据集合。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>小时数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间、结束时间来获取小时数据集合。")]
        public List<TagHourInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagHourProvider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id获取最新的小时表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>最新的小时表数据。</returns>
        [WebMethod(Description = "根据指定的指标Id获取最新的小时表数据。")]
        public TagHourInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagHour.Get_Latest_By_TagId({0})",tagId));
            if(IsUsingCache)
            {
                var sw = new Stopwatch();
                sw.Start();
                var objs = DistCache.Get(CacheKeyEnum.LatestHourTagData) as List<TagHourInfo>;
                sw.Stop();
                Logger.Info(string.Format("DistCache.Get(CacheKeyEnum.LatestHourTagData) as List<TagHourInfo> spend {0} Milliseconds", sw.ElapsedMilliseconds));
                
                if(objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if (obj != null)
                    {
                        return obj;
                    }
                    else 
                    {
                        Logger.Debug(string.Format("{0}'s Hour Data Not found in Memcache,then get it from database.",tagId));
                        return DataProvider.TagHourProvider.Get_Latest_By_TagId(tagId);
                    }
                }
                else
                {
                    Logger.Debug(string.Format("{0} The Cache is not exists the Tag's hour's data,get it from database.", tagId));
                    return DataProvider.TagHourProvider.Get_Latest_By_TagId(tagId);
                }
            }
            else
            {
                Logger.Debug("Get Tag's Hour Data not using cache.");
                return DataProvider.TagHourProvider.Get_Latest_By_TagId(tagId);
            }
        }

        /// <summary>
        /// 根据指定指标Id串获取最新的小时表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>最新的小时表数据。</returns>
        [WebMethod(Description="根据指定指标Id串获取最新的小时表数据。")]
        public List<TagHourInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagHour.Get_Latest_By_TagIds({0}",tagIds));
            if (IsUsingCache)
            {
                var sw = new Stopwatch();
                sw.Start();
                var objs = DistCache.Get(CacheKeyEnum.LatestHourTagData) as List<TagHourInfo>;
                sw.Stop();
                Logger.Info(string.Format("DistCache.Get(CacheKeyEnum.LatestHourTagData) as List<TagHourInfo> spend {0} Milliseconds", sw.ElapsedMilliseconds));

                if (objs != null && objs.Count > 0)
                {
                    var results = objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id) >= 0);
                    if (results != null && results.Count > 0)
                    {
                        return results;
                    }
                    else
                    {
                        Logger.Debug(string.Format("{0}'s Data is not found in MemCache,then get it from database."));
                        return DataProvider.TagHourProvider.Get_Latest_By_TagIds(tagIds);
                    }
                }
                else
                {
                    Logger.Debug(string.Format("{0} The Cache is not exists the Tag's hour's data,get it from database.", tagIds));
                    return DataProvider.TagHourProvider.Get_Latest_By_TagIds(tagIds);
                }
            }
            else
            {
                Logger.Debug("Get Tag's Hour Data not using cache.");
                return DataProvider.TagHourProvider.Get_Latest_By_TagIds(tagIds);
            }
        }

        /// <summary>
        /// 获取所有最新的小时表数据。
        /// </summary>
        /// <returns>最新的小时表数据。</returns>
        [WebMethod(Description="获取所有最新的小时表数据。")]
        public List<TagHourInfo> Get_Latest_All()
        {
            Logger.Debug("TagHour.Get_Latest_All()");
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestHourTagData) as List<TagHourInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    Logger.Debug("The MemCache not exists the Tag Hour Data,then get it from database.");
                    return DataProvider.TagHourProvider.Get_Latest_All();
                }
            }
            else
            {
                Logger.Debug("Not using MemCache,then get it from database.");
                return DataProvider.TagHourProvider.Get_Latest_All();
            }
        }

        #endregion
    }
}
