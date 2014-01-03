using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class History:IHistory
    {
        #region Implementation of IHistory

        /// <summary>
        /// 添加系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        public bool Insert(HistoryInfo historyInfo)
        {
            var obj = new HistoryService.HistoryInfo();
            CopyHelper.Copy(historyInfo,obj);
            return new HistoryService.History().Insert(obj);
        }

        /// <summary>
        /// 修改系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        public bool Update(HistoryInfo historyInfo)
        {
            var obj = new HistoryService.HistoryInfo();
            CopyHelper.Copy(historyInfo, obj);
            return new HistoryService.History().Update(obj);
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
        public bool Delete(long id)
        {
            return new HistoryService.History().Delete(id);
        }

        /// <summary>
        /// 根据时间段获取所有用户的登录退出记录。
        /// </summary>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        public List<HistoryInfo> GetAllByDateTime(DateTime beginTime, DateTime endTime)
        {
            var objs = new HistoryService.History().GetAllByDateTime(beginTime, endTime);
            var obj1s = new List<HistoryInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new HistoryInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据时间段获取指定用户的登录退出记录
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        public List<HistoryInfo> GetByUserAndDateTime(string userName, DateTime beginTime, DateTime endTime)
        {
            var objs = new HistoryService.History().GetByUserAndDateTime(userName, beginTime, endTime);
            var obj1s = new List<HistoryInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new HistoryInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
