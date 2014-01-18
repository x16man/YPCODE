using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.WorkFlow.Model;

namespace Shmzh.Components.WorkFlow.IDAL
{
    public interface ITask
    {
        /// <summary>
        /// 从物料系统中获取待办事宜。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>待办事宜列表。</returns>
        IList<TaskInfo> GetFromMM(string userName);
        /// <summary>
        /// 从工作流中获取待办事宜。
        /// </summary>
        /// <param name="userId">用户Id。</param>
        /// <returns>待办事宜列表。</returns>
        IList<TaskInfo> GetFromDLFlo(int userId);
        /// <summary>
        /// 从系统的待办事宜中获取。
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IList<TaskInfo> GetFromMZH(string userName);
    }
}
