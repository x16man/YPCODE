using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using System.Configuration;
using MemcachedProviders.Cache;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// TagSecond 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/",Description="指标的秒数据的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagSecond : System.Web.Services.WebService,ITagSecond
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

        #region ITagSecond 成员

        /// <summary>
        /// 根据Id获取最新的秒表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>秒数据实体。</returns>
        [WebMethod(Description="根据指标Id获取指标最新的秒数据.")]
        public TagSecondInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagSecond.Get_Latest_By_TagId({0})",tagId));
            if(IsUsingCache)
            {
                var sw = new Stopwatch();
                sw.Start();
                var objs = DistCache.Get(CacheKeyEnum.LatestSecondTagData) as List<TagSecondInfo>;
                sw.Stop();
                Logger.Debug(string.Format("DistCache.Get(CacheKeyEnum.LatestSecondTagData) as List<TagSecondInfo> spend {0} Milliseconds", sw.ElapsedMilliseconds));
                    
                if(objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if (obj == null)
                    {
                        Logger.Debug(string.Format("{0} not found in MemCache.Get it by SQL."));
                        return DataProvider.TagSecondProvider.Get_Latest_By_TagId(tagId);
                    }
                    else
                        return obj as TagSecondInfo;
                }
                else
                {
                    Logger.Debug(string.Format("{0} The Cache is not exists the Tag's second's data,get it from database.",tagId));
                    return DataProvider.TagSecondProvider.Get_Latest_By_TagId(tagId);
                }
            }
            else
            {
                Logger.Debug("Get Tag's Second Data not using cache.");
                return DataProvider.TagSecondProvider.Get_Latest_By_TagId(tagId);
            }
        }

        /// <summary>
        /// 根据指标Id串来获取最新的秒表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        [WebMethod(Description="根据指标Id串(例如:'1001001','1001002')来获取多个指标的最新的秒数据.")]
        public List<TagSecondInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagSecond.Get_Latest_By_TagIds({0})", tagIds));
            if(IsUsingCache)
            {
                var sw = new Stopwatch();
                sw.Start();
                var objs = DistCache.Get(CacheKeyEnum.LatestSecondTagData) as List<TagSecondInfo>;
                Logger.Debug(string.Format("DistCache.Get(CacheKeyEnum.LatestSecondTagData) as List<TagSecondInfo> spend {0} Milliseconds", sw.ElapsedMilliseconds));
                if(objs != null && objs.Count > 0)
                {
                    var results = objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id)>=0);
                    if (results != null && results.Count > 0)
                    {
                        return results as List<TagSecondInfo>;
                    }
                    else 
                    {
                        Logger.Debug(string.Format("{0} not found in Memcache,Get it From DataBase.",tagIds));
                        return DataProvider.TagSecondProvider.Get_Latest_By_TagIds(tagIds);
                    }
                }
                else
                {
                    Logger.Debug(string.Format("{0} The Cache is not exists the Tag's second's data,get it from database.",tagIds));
                    return DataProvider.TagSecondProvider.Get_Latest_By_TagIds(tagIds);
                }
            }
            else
            {
                Logger.Debug("Get Tag's Second Data not using cache.Get it from database.");
                return DataProvider.TagSecondProvider.Get_Latest_By_TagIds(tagIds);
            }
        }

        /// <summary>
        /// 获取所有指标的最新秒数据。
        /// </summary>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        [WebMethod(Description="获取所有自动采集指标的最新的秒数据.")]
        public List<TagSecondInfo> Get_Latest_All()
        {
            Logger.Debug(string.Format("TagSecond.Get_Latest_All"));
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestSecondTagData) as List<TagSecondInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    Logger.Debug("The MemCache not exists the latest Second Data,Get it from database.");
                    return DataProvider.TagSecondProvider.Get_Latest_All(); 
                }
            }
            else
            {
                return DataProvider.TagSecondProvider.Get_Latest_All();
            }
            
        }

        #endregion
    }
}
