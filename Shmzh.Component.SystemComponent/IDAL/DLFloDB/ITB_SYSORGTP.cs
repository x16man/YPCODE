using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组织机构类型的数据访问接口。
    /// </summary>
    public interface ITB_SYSORGTP
    {
        /// <summary>
        /// 添加东兰工作流组织类型信息。
        /// </summary>
        /// <param name="obj">组织类型实体。</param>
        /// <param name="trans"></param>
        bool Insert(TB_SYSORGTPInfo obj, DbTransaction trans);

        /// <summary>
        /// 修改东兰工作流组织机构类型信息。
        /// </summary>
        /// <param name="obj">组织类型实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Update(TB_SYSORGTPInfo obj, DbTransaction trans);

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
         /// <param name="obj">组织类型实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(TB_SYSORGTPInfo obj, DbTransaction trans);

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="typeId">类型Id。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(int typeId, DbTransaction trans);

        /// <summary>
        /// 东兰工作流是否存在某一名称的组织类型。
        /// </summary>
        /// <param name="typeName">类型名称。</param>
        bool IsExistName(string typeName);
        /// <summary>
        /// 根据组织类型名称获取组织机构类型。
        /// </summary>
        /// <param name="typeName">组织机构类型名称。</param>
        /// <returns>组织机构类型。</returns>
        TB_SYSORGTPInfo GetByTypeName(string typeName);
    }
}
