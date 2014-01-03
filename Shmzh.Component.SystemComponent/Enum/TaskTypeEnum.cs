using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Components.SystemComponent.Enum
{
    /// <summary>
    /// 待办事宜任务类型枚举。
    /// </summary>
    public enum TaskTypeEnum
    {
        /// <summary>
        /// 会议任务。
        /// </summary>
        MeetingTask=1,
        /// <summary>
        /// 车辆年检。
        /// </summary>
        VechicleYearCheck=5,
        /// <summary>
        /// 车辆维护。
        /// </summary>
        VechicleMaintain = 6,
        /// <summary>
        /// 网站文章。
        /// </summary>
        WebSiteArticle = 11,
        /// <summary>
        /// 设备报修单涉外解决。
        /// </summary>
        DeviceRepairOutAdd = 16,
        /// <summary>
        /// 项目预报表。
        /// </summary>
        ProjectPreReport = 20,
        /// <summary>
        /// 项目任务。
        /// </summary>
        ProjectTask = 21,
        /// <summary>
        /// 项目临时任务。
        /// </summary>
        ProjectTempTask = 22,
    }
}
