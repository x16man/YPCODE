using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class OperationProvider:IOperation
    {
        #region Implementation of IOperation

        /// <summary>
        /// 添加报表操作信息。
        /// </summary>
        /// <param name="obj">报表操作信息。</param>
        /// <returns>bool</returns>
        public abstract bool Insert(OperationInfo obj);

        /// <summary>
        /// 更改报表操作信息。
        /// </summary>
        /// <param name="obj">报表操作信息。</param>
        /// <returns>bool</returns>
        public abstract bool Update(CategoryInfo obj);

        /// <summary>
        /// 根据Id删除报表操作记录。
        /// </summary>
        /// <param name="id">报表操作记录Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(decimal id);

        /// <summary>
        /// 删除报表操作记录。
        /// </summary>
        /// <param name="obj">报表操作实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(OperationInfo obj);

        /// <summary>
        /// 根据报表编号和时间点获取所有的报表操作记录。
        /// </summary>
        /// <param name="reportCode">报表编号。</param>
        /// <param name="cycleId">时间点。</param>
        /// <returns>报表操作记录。</returns>
        public abstract IList<OperationInfo> GetByReportCodeAndCycleId(string reportCode, int cycleId);

        /// <summary>
        /// 根据Id获取报表操作记录。
        /// </summary>
        /// <param name="id">报表操作记录Id。</param>
        /// <returns>报表操作记录。</returns>
        public abstract OperationInfo GetById(decimal id);

        /// <summary>
        /// 根据报表编号和时间点获取最近一次的报表操作记录
        /// </summary>
        /// <param name="reportCode">报表编号</param>
        /// <param name="cycleId">时间点</param>
        /// <returns>报表操作记录</returns>
        public abstract OperationInfo GetLatestByReportCodeAndCycleId(string reportCode, int cycleId);

        #endregion
    }
}
