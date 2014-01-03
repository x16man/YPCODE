using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 系统访问记录的数据访问接口。
    /// </summary>
    public interface IHistory
    {
        /// <summary>
        /// 添加系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        bool Insert(HistoryInfo historyInfo);
        /// <summary>
        /// 修改系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        bool Update(HistoryInfo historyInfo);
        /// <summary>
        /// 删除系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        bool Delete(HistoryInfo historyInfo);
        /// <summary>
        /// 删除系统访问记录。
        /// </summary>
        /// <param name="id">系统访问记录Id。</param>
        /// <returns>bool</returns>
        bool Delete(long id);
        /// <summary>
        /// 根据时间段获取所有用户的登录退出记录。
        /// </summary>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        List<HistoryInfo> GetAllByDateTime(DateTime beginTime, DateTime endTime);
        /// <summary>
        /// 根据时间段获取指定用户的登录退出记录
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        List<HistoryInfo> GetByUserAndDateTime(string userName, DateTime beginTime, DateTime endTime);
            
    }
}
