using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using MemcachedProviders.Cache;



namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// 指标的15分钟数据的WebService访问接口.
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/", Description = "指标的15分钟数据的WebService访问接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagMin15 : WebService,ITagMin15
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


        #region ITagMin15 成员

        /// <summary>
        /// 根据指定的单个指标Id、开始时间Id、结束时间Id获取15分钟表的数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。/</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>15分钟表的数据集合。</returns>
        [WebMethod(Description = "根据指标Id和开始时间点(整型)到结束时间点(整型)所指定的时间范围,来获取指标的15分钟数据.")]
        public List<TagMin15Info> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagMin15Provider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的单个指标Id、开始时间、结束时间获取15分钟表的数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>15分钟表的数据集合。</returns>
        [WebMethod(Description = "根据指标Id和开始时间点(日期型)到结束时间点(日期型)所指定的时间范围,来获取指标的15分钟数据.")]
        public List<TagMin15Info> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagMin15Provider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的多个指标Id、开始时间Id、结束时间Id获取15分钟表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串(逗号分隔).</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>15分钟表的数据集合。</returns>
        [WebMethod(Description = "根据指标Id串(例如:'1001001','1001002')和开始时间点(整型)到结束时间点(整型)所指定的时间范围,来获取指标的15分钟数据.")]
        public List<TagMin15Info> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagMin15Provider.Get_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的多个指标Id、开始时间、结束时间获取15分钟表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串(逗号分隔).</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>15分钟表的数据集合。</returns>
        [WebMethod(Description = "根据指标Id串(例如:'1001001','1001002')和开始时间点(日期型)到结束时间点(日期型)所指定的时间范围,来获取指标的15分钟数据.")]
        public List<TagMin15Info> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagMin15Provider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id获取最新的15分钟数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>15分钟数据实体。</returns>
        [WebMethod(Description = "根据指标Id获取指标的最新的15分钟数据.")]
        public TagMin15Info Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagMin15.Get_Latest_By_TagId({0}",tagId));
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMin15TagData) as List<TagMin15Info>;
                if(objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if (obj != null)
                        return obj;
                    else
                    {
                        Logger.Debug(string.Format("{0}'s Min15 data not found in MemCache,Get it from database.",tagId));
                        return DataProvider.TagMin15Provider.Get_Latest_By_TagId(tagId);
                    }
                    
                }
                else
                {
                    Logger.Debug(string.Format("The MemCache not exists the TagMin15's Data,Get the {0}'s data from database.",tagId));
                    return DataProvider.TagMin15Provider.Get_Latest_By_TagId(tagId);
                }
            }
            else
            {
                Logger.Debug("Not using memcache,so get it data from database.");
                return DataProvider.TagMin15Provider.Get_Latest_By_TagId(tagId);
            }
        }

        /// <summary>
        /// 根据指定的指标Id串来获取最新的15分钟数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>最新的15分钟数据。</returns>
        [WebMethod(Description = "根据指定的指标Id串(例如:'1001001','1001002'),来获取多个指标的最新的15分钟数据.")]
        public List<TagMin15Info> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagMin15.Get_Latest_By_TagIds({0})",tagIds));
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMin15TagData) as List<TagMin15Info>;
                if(objs!=null && objs.Count > 0)
                {
                    var results = objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id)>= 0);
                    if (results != null && results.Count > 0)
                    {
                        return results;
                    }
                    else
                    {
                        Logger.Debug(string.Format("{0}'s Min15 Data not found in MemCache,then get it from database.",tagIds));
                        return DataProvider.TagMin15Provider.Get_Latest_By_TagIds(tagIds);
                    }
                }
                else
                {
                    Logger.Debug("The MemCache not exists the Min15's Data,then get it from database.");
                    return DataProvider.TagMin15Provider.Get_Latest_By_TagIds(tagIds);
                }
            }
            else
            {
                Logger.Debug("Not using Memcache , then get it from database.");
                return DataProvider.TagMin15Provider.Get_Latest_By_TagIds(tagIds);
            }
        }

        /// <summary>
        /// 获取最新的15分钟数据。
        /// </summary>
        /// <returns>最新的15分钟数据。</returns>
        [WebMethod(Description = "获取所有指标(有15分钟数据的指标)的最新的15分钟数据.")]
        public List<TagMin15Info> Get_Latest_All()
        {
            Logger.Debug("TagMin15.Get_Latest_All()");
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestMin15TagData) as List<TagMin15Info>;
                if (objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    Logger.Debug("The MemCache not exists the Min15 data ,then get it from database.");
                    return DataProvider.TagMin15Provider.Get_Latest_All();
                }
            }
            else 
            {
                Logger.Debug("Not using MemCache,then get it from database.");
                return DataProvider.TagMin15Provider.Get_Latest_All();
            }
        }

        #endregion
    }
}
