using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 操作日志的数据访问接口。
    /// </summary>
    public interface IOperationLog
    {
        /// <summary>
        /// 添加操作日志。
        /// </summary>
        /// <param name="obj">操作日志实体。</param>
        /// <returns>bool</returns>
        bool Insert(OperationLogInfo obj);

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="obj">操作日志实体.</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Insert(OperationLogInfo obj, DbTransaction trans);

        /// <summary>
        /// 根据指定的时间范围和操作类型来获取操作日志列表。
        /// </summary>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <param name="opType">操作类型。</param>
        /// <returns>操作日志列表。</returns>
        IList<OperationLogInfo> GetByTimeAndOpType(DateTime beginTime, DateTime endTime, string opType);

        /// <summary>
        /// 根据指定的时间范围和操作类型、产品编号来获取操作日志列表
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="opType">操作类型</param>
        /// <param name="productCode">产品编号</param>
        /// <returns>操作日志列表</returns>
        IList<OperationLogInfo> GetByTimeAndOpTypeAndProductCode(DateTime beginTime, DateTime endTime, string opType, short productCode);
        /// <summary>
        /// 根据指定的操作类型获取最新的100条操作记录。
        /// </summary>
        /// <param name="opType">操作类型。</param>
        /// <returns>操作日志列表。</returns>
        IList<OperationLogInfo> GetTop100(string opType);

        /// <summary>
        /// 根据指定的操作类型获取最新的100条操作记录。
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="productCode">产品编号</param>
        /// <returns>操作日志列表</returns>
        IList<OperationLogInfo> GetTop100(string opType, short productCode);

        /// <summary>
        /// 根据指定的开始时间、结束时间、操作类型、操作描述等条件进行查询。
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="opType">操作类型</param>
        /// <param name="likeOpDesc">操作描述。</param>
        /// <returns>操作日志列表</returns>
        IList<OperationLogInfo> GetByTimeAndOpTypeAndOpDesc(DateTime beginTime, DateTime endTime, string opType, string likeOpDesc);
        /// <summary>
        /// 根据指定的开始时间、结束时间、操作类型、产品编号、操作描述等条件进行查询。
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="opType">操作类型</param>
        /// <param name="productCode">产品编号</param>
        /// <param name="likeOpDesc">操作描述。</param>
        /// <returns>操作日志列表</returns>
        IList<OperationLogInfo> GetByTimeAndOpTypeAndProductCodeAndOpDesc(DateTime beginTime, DateTime endTime, string opType, short productCode,string likeOpDesc);
    }
}
