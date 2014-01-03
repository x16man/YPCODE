using System.Collections.Generic;
using System.Data.Common;


namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 工作流组织机构的数据访问接口。
    /// </summary>
    public interface ITB_SYN
    {
        /// <summary>
        /// 更新东兰同步标志表。
        /// </summary>
        /// <param name="obj">同步标志信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Update(string CD, DbTransaction trans);
    }
}
