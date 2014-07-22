using System;
using System.Collections.Generic;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.IDAL
{
    /// <summary>
    /// 任务的数据访问接口。
    /// </summary>
    public interface ITempTask
    {
        /// <summary>
        /// 最近24小时任务。
        /// </summary>
        /// <param name="projectType">项目类型，例如""或"类型1,类型2"或"类型1"</param>
        /// <param name="fState">项目状态，例如""或"不通过,已确认,未完成,已完成"或"未完成"</param>
        /// <returns>任务集合</returns>
        List<TempTaskInfo> GetDayTask(String projectType, String fState);
        /// <summary>
        /// 最近1周未完成任务。
        /// </summary>
        /// <param name="projectType">项目类型，例如""或"类型1,类型2"或"类型1"</param>
        /// <param name="fState">项目状态，例如""或"不通过,已确认,未完成,已完成"或"未完成"</param>
        /// <returns>任务集合</returns>
        List<TempTaskInfo> GetWeekTask(String projectType, String fState);

        /// <summary>
        /// 根据查询条件获取任务。
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="otherCondition">其他条件</param>
        /// <returns>任务集合</returns>
        List<TempTaskInfo> GetTask(DateTime startTime, DateTime endTime, String otherCondition);
    } 
    
}
