using System.Configuration;
using System.Web.Services;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using System.Collections.Generic;
using MemcachedProviders.Cache;


namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// 设备运行状态的数据访问服务。
    /// </summary>
    [WebService(Namespace = "http://shuizhi.ypwater.com/DataService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None/*.BasicProfile1_1*/)]
    [System.ComponentModel.ToolboxItem(false)]
    public class RunStatus : WebService ,IRunStatus
    {
        #region Property
        private static bool IsUsingCache
        {
            get
            {
                return ConfigurationManager.AppSettings["IsUsingCache"] == "1";
            }
        }
        #endregion

        #region IRunStatus 成员
        /// <summary>
        /// 根据指标Id，来获取绑定了该指标的设备的运行状态。
        /// </summary>
        /// <param name="tagId">与设备绑定的指标。</param>
        /// <returns>设备运行状态实体。</returns>
        [WebMethod]
        public RunStatusInfo Get_Current_By_TagId(string tagId)
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.TagMS) as List<TagInfo>;
                if(objs != null && objs.Count > 0)
                {
                    var obj = objs.Find(item => item.I_Tag_Id == tagId);
                    if(obj == null)
                    {
                        return DataProvider.RunStatusProvider.Get_Current_By_TagId(tagId);
                    }
                    else
                    {
                        return Get_Current_By_DevCode(obj.Dev_Code);
                    }
                }
            }
            return DataProvider.RunStatusProvider.Get_Current_By_TagId(tagId);
        }

        #endregion

        #region IRunStatus 成员

        /// <summary>
        /// 根据设备编号获取设备的当前的运行状态。
        /// </summary>
        /// <param name="devCode">设备编号。</param>
        /// <returns>设备的当前运行状态实体。</returns>
        [WebMethod]
        public RunStatusInfo Get_Current_By_DevCode(string devCode)
        {
            if(IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.CurrentRunStatus) as List<RunStatusInfo>;
                if(objs != null && objs.Count> 0)
                {
                    return objs.Find(item => item.Dev_Code == devCode);        
                }
            }
            
            return DataProvider.RunStatusProvider.Get_Current_By_DevCode(devCode);
            
        }

        /// <summary>
        /// 根据设备编号获取多个设备的当前的运行状态。
        /// </summary>
        /// <param name="devCodes">设备编号字符串(逗号分隔)。</param>
        /// <returns>多个设备的当前的运行状态集合。</returns>
        [WebMethod]
        public List<RunStatusInfo> Get_Current_By_DevCodes(string devCodes)
        {
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.CurrentRunStatus) as List<RunStatusInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs.FindAll(item => devCodes.Contains(item.Dev_Code));
                }
            }
            
            return DataProvider.RunStatusProvider.Get_Current_By_DevCodes(devCodes);
        }

        /// <summary>
        /// 获取所有设备的当前运行状态。
        /// </summary>
        /// <returns>设备的当前运行状态集合。</returns>
        [WebMethod]
        public List<RunStatusInfo> Get_Current_All()
        {
            if (IsUsingCache)
            {
                var objs = DistCache.Get(CacheKeyEnum.CurrentRunStatus) as List<RunStatusInfo>;
                if (objs != null && objs.Count > 0)
                {
                    return objs;
                }
            }
            return DataProvider.RunStatusProvider.Get_Current_All();
        }

        #endregion
    }
}
