using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 指标信息的数据访问接口。
    /// </summary>
    public interface ITagGather
    {
        /// <summary>
        /// 根据指标Id查询指标列表。
        /// </summary>
        /// <returns>指标列表。</returns>
        List<TagGatherInfo> GetByTagId(String tagId);
    }
}
