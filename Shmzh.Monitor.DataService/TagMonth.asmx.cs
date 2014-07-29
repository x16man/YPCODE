using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using MemcachedProviders.Cache;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// 指标月数据的WebService访问接口.
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/",Description="指标月数据的WebService访问接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagMonth : WebService,ITagMonth
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

        #region ITagMonth 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取月表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>月表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间Id、结束时间Id来获取月表数据集合。")]
        public List<TagMonthInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagMonthProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取月表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>月表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取月表数据集合。")]
        public List<TagMonthInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagMonthProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取月表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>月表数据集合</returns>
        [WebMethod(Description="根据指定的指标Id串、开始时间Id、结束时间Id来获取月表数据集合。")]
        public List<TagMonthInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagMonthProvider.Get_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取月表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>月表数据集合</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间、结束时间来获取月表数据集合。")]
        public List<TagMonthInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagMonthProvider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }

        /// <summary>
        /// 根据指标Id获取最新的月数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>月表数据实体。</returns>
        [WebMethod(Description = "根据指标Id获取最新的月数据。")]
        public TagMonthInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagMonth.Get_Latest_By_TagId({0})",tagId));
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMonthTagData) as List<TagMonthInfo>;
                if(objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if(obj == null)
                    {
                        Logger.Debug(string.Format("{0}'s data not found in MemCache,then get it from database.",tagId));
                        return DataProvider.TagMonthProvider.Get_Latest_By_TagId(tagId);
                    }
                    else
                    {
                        return obj;
                    }
                }
                else
                {
                    return DataProvider.TagMonthProvider.Get_Latest_By_TagId(tagId);
                }
            }
            else
            {
                return DataProvider.TagMonthProvider.Get_Latest_By_TagId(tagId);
            }
        }

        /// <summary>
        /// 根据指定Id串获取最新的月表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>最新的月表数据。</returns>
        [WebMethod(Description = "根据指定Id串获取最新的月表数据。")]
        public List<TagMonthInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagMonth.Get_Latest_By_TagIds({0})", tagIds));
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMonthTagData) as List<TagMonthInfo>;
                if (objs != null && objs.Count > 0)
                {
                    var results = objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id)>=0);
                    if(results!=null && results.Count > 0)
                    {
                        return results;
                    }
                    else
                    {
                        return DataProvider.TagMonthProvider.Get_Latest_By_TagIds(tagIds);
                    }
                }
                else
                {
                    return DataProvider.TagMonthProvider.Get_Latest_By_TagIds(tagIds);
                }
            }
            else
            {
                return DataProvider.TagMonthProvider.Get_Latest_By_TagIds(tagIds);
            }
        }

        /// <summary>
        /// 获取最新月表数据。
        /// </summary>
        /// <returns>最新的月表数据。</returns>
        [WebMethod(Description = "获取最新月表数据。")]
        public List<TagMonthInfo> Get_Latest_All()
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMonthTagData) as List<TagMonthInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    return DataProvider.TagMonthProvider.Get_Latest_All();
                }
            }
            return DataProvider.TagMonthProvider.Get_Latest_All();
        }

        #endregion
    }
}
