using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// History 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class History : System.Web.Services.WebService,IHistory
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region Implementation of IHistory

        /// <summary>
        /// 添加系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "添加系统访问的历史记录")]
        public bool Insert(HistoryInfo historyInfo)
        {
            return DataProvider.HistoryProvider.Insert(historyInfo);
        }

        /// <summary>
        /// 修改系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "更改系统访问的历史记录")]
        public bool Update(HistoryInfo historyInfo)
        {
            return DataProvider.HistoryProvider.Update(historyInfo);
        }

        /// <summary>
        /// 删除系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        public bool Delete(HistoryInfo historyInfo)
        {
            return this.Delete(historyInfo.Id);
        }

        /// <summary>
        /// 删除系统访问记录。
        /// </summary>
        /// <param name="id">系统访问记录Id。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "删除系统访问的历史记录")]
        public bool Delete(long id)
        {
            return DataProvider.HistoryProvider.Delete(id);
        }

        /// <summary>
        /// 根据时间段获取所有用户的登录退出记录。
        /// </summary>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        [WebMethod(Description = "根据时间段获取所有用户的登录退出记录")]
        public List<HistoryInfo> GetAllByDateTime(DateTime beginTime, DateTime endTime)
        {
            return DataProvider.HistoryProvider.GetAllByDateTime(beginTime, endTime);
        }

        /// <summary>
        /// 根据时间段获取指定用户的登录退出记录
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        [WebMethod(Description = "根据时间段获取指定用户的登录退出记录")]
        public List<HistoryInfo> GetByUserAndDateTime(string userName, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.HistoryProvider.GetByUserAndDateTime(userName, beginTime, endTime);
        }

        #endregion
    }
}
