using System;
using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data;
using System.Configuration;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using MemcachedProviders.Cache;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://shuizhi.ypwater.org/DataService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Tag : WebService,ITag
    {
        #region Property
        private static bool IsUsingCache
        {
            get {
                return ConfigurationManager.AppSettings["IsUsingCache"] == "1";
            }
        }
        #endregion
        #region ITag 成员

        /// <summary>
        /// 根据指标Id获取指标信息。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>指标信息实体。</returns>
        [WebMethod]
        public TagInfo GetById(string tagId)
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.TagMS) as List<TagInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs.Find(item=>item.I_Tag_Id == tagId);
                }
                else
                {
                    return DataProvider.TagProvider.GetById(tagId);
                }
            }
            else
            {
                return DataProvider.TagProvider.GetById(tagId);
            }
        }

        /// <summary>
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        [WebMethod]
        public List<TagInfo> GetAll()
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.TagMS) as List<TagInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs;
                }
                else
                {
                    return DataProvider.TagProvider.GetAll();
                }
            }
            else
            {
                return DataProvider.TagProvider.GetAll();
            }
        }

        /// <summary>
        /// 根据输入字符进行快速查询。
        /// </summary>
        /// <param name="tagId">查询条件。</param>
        /// <returns>指标集合。</returns>
        [WebMethod]
        public List<TagInfo> QuickSearch(string strCondition)
        {
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.TagMS) as List<TagInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs.FindAll(item => item.I_Tag_Id.Contains(strCondition) || item.I_Tag_Name.Contains(strCondition));
                }
                else
                {
                    return DataProvider.TagProvider.QuickSearch(strCondition);
                }
            }
            else
            {
                return DataProvider.TagProvider.QuickSearch(strCondition);
            }
        }

        /// <summary>
        /// 根据指标类型、指标Id、指标名称获取指标列表。
        /// </summary>
        /// <param name="tagType">指标类型</param>
        /// <param name="tagId">指标Id</param>
        /// <param name="tagName">指标名称</param>
        /// <returns>指标集合。</returns>
        [WebMethod]
        public List<TagInfo> GetByType_TagId_TagName(string tagType, string tagId, string tagName)
        {
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.TagMS) as List<TagInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs.FindAll(item => item.I_Tag_Type.StartsWith(tagType) && item.I_Tag_Id.StartsWith(tagId) && item.I_Tag_Name.Contains(tagName));
                }
                else
                {
                    return DataProvider.TagProvider.GetByType_TagId_TagName(tagType, tagId, tagName);
                }
            }
            else
            {
                return DataProvider.TagProvider.GetByType_TagId_TagName(tagType, tagId, tagName);
            }
        }

        /// <summary>
        /// 获取服务器时间。
        /// </summary>
        /// <returns>服务器时间。</returns>
        [WebMethod]
        public DateTime GetDate()
        {
            return DataProvider.TagProvider.GetDate();
        }

        #endregion

        #region ITag 成员

        /// <summary>
        /// 获取三项指标合格率。
        /// </summary>
        /// <returns>三项指标合格率。</returns>
        [WebMethod]
        public double Get3TagEligibleRate(DateTime beginDate, DateTime endDate)
        {
            return DataProvider.TagProvider.Get3TagEligibleRate(beginDate,endDate);
        }

        /// <summary>
        /// 获取4项指标合格率。
        /// </summary>
        /// <returns>4项指标合格率。</returns>
        [WebMethod]
        public double Get4TagEligibleRate(DateTime beginDate,DateTime endDate)
        {
            return DataProvider.TagProvider.Get4TagEligibleRate(beginDate,endDate);
        }

        /// <summary>
        /// 获取7项指标合格率。
        /// </summary>
        /// <returns>7项指标合格率。</returns>
        [WebMethod]
        public double Get7TagEligibleRate(DateTime beginDate,DateTime endDate)
        {
            return DataProvider.TagProvider.Get7TagEligibleRate(beginDate,endDate);
        }

        #endregion
    }
}
