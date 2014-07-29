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
    /// 指标年数据的数据访问接口.
    /// </summary>
    [WebService(Namespace = "http://service.ypwater.com/", Description = "指标年数据的数据访问接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagYear : System.Web.Services.WebService,ITagYear
    {
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


        #region ITagYear 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取年表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>年表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间Id、结束时间Id来获取年表数据集合。")]
        public List<TagYearInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagYearProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取年表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>年表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取年表数据集合。")]
        public List<TagYearInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagYearProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取年表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>年表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间Id、结束时间Id来获取年表数据集合。")]
        public List<TagYearInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            return DataProvider.TagYearProvider.Get_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取年表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>年表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间、结束时间来获取年表数据集合。")]
        public List<TagYearInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagYearProvider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }

        /// <summary>
        /// 根据指定的指标Id获取最新的年表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>年表数据实体。</returns>
        [WebMethod(Description = "根据指定的指标Id获取最新的年表数据。")]
        public TagYearInfo Get_Latest_By_TagId(string tagId)
        {
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestYearTagData) as List<TagYearInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs.Find(item => item.I_Tag_Id == tagId);
                }
            }
            return DataProvider.TagYearProvider.Get_Latest_By_TagId(tagId);
        }

        /// <summary>
        /// 根据指定的指标Id串获取最新的年表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <returns>年表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串获取最新的年表数据。")]
        public List<TagYearInfo> Get_Latest_By_TagIds(string tagIds)
        {
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestYearTagData) as List<TagYearInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs.FindAll(item => tagIds.IndexOf(item.I_Tag_Id) >= 0);
                }
            }
            return DataProvider.TagYearProvider.Get_Latest_By_TagIds(tagIds);
        }

        /// <summary>
        /// 获取最新的年数据。
        /// </summary>
        /// <returns>年表数据集合。</returns>
        [WebMethod(Description = "获取最新的年数据。")]
        public List<TagYearInfo> Get_Latest_All()
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.LatestYearTagData) as List<TagYearInfo>;
                if(objs!= null && objs.Count > 0)
                {
                    return objs;
                }
            }
            return DataProvider.TagYearProvider.Get_Latest_All();
        }

        #endregion
    }
}
