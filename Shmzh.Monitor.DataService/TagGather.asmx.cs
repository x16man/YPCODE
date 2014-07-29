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
    public class TagGather : WebService,ITagGather
    {
        #region Property
        private static bool IsUsingCache
        {
            get {
                return ConfigurationManager.AppSettings["IsUsingCache"] == "1";
            }
        }
        #endregion
       

        /// <summary>
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        [WebMethod]
        public List<TagGatherInfo> GetByTagId(String tagId)
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.TagGather) as List<TagGatherInfo>;
                if(objs != null && objs.Count > 0)
                {
                    return objs.FindAll(item=>item.I_TAG_ID.StartsWith(tagId));
                }
                else
                {
                    return DataProvider.TagGatherProvider.GetByTagId(tagId);
                }
            }
            else
            {
                return DataProvider.TagGatherProvider.GetByTagId(tagId);
            }
        }

       
        
    }
}
