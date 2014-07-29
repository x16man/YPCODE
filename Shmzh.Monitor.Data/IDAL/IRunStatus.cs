using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 设备运行状态的数据访问接口。
    /// </summary>
    public interface IRunStatus
    {
        /// <summary>
        /// 根据指标Id获取设备的当前运行状态。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>设备的当前运行状态实体。</returns>
        RunStatusInfo Get_Current_By_TagId(string tagId);
        /// <summary>
        /// 根据设备编号获取设备的当前的运行状态。
        /// </summary>
        /// <param name="devCode">设备编号。</param>
        /// <returns>设备的当前运行状态实体。</returns>
        RunStatusInfo Get_Current_By_DevCode(string devCode);

        /// <summary>
        /// 根据设备编号获取多个设备的当前的运行状态。
        /// </summary>
        /// <param name="devCodes">设备编号字符串(逗号分隔)。</param>
        /// <returns>多个设备的当前的运行状态集合。</returns>
        List<RunStatusInfo> Get_Current_By_DevCodes(string devCodes);

        /// <summary>
        /// 获取所有设备的当前运行状态。
        /// </summary>
        /// <returns>设备的当前运行状态集合。</returns>
        List<RunStatusInfo> Get_Current_All();
    }
}
