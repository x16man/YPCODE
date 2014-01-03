using System.Collections.Generic;
using System.Data.Common;


namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 工作流组织机构的数据访问接口。
    /// </summary>
    public interface ITB_ORGMEMLK
    {
        /// <summary>
        /// 添加东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Insert(TB_ORGMEMLKInfo obj, DbTransaction trans);

        /// <summary>
        /// 修改东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Update(TB_ORGMEMLKInfo obj, DbTransaction trans);


        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(TB_ORGMEMLKInfo obj, DbTransaction trans);

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="lnkId">部门key。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(int lnkId, DbTransaction trans);

        /// <summary>
        /// 获取所有记录。
        /// </summary>
        /// <returns></returns>
        IList<TB_ORGMEMLKInfo> GetALL();

        /// <summary>
        /// 获取所有有效记录。
        /// </summary>
        /// <returns></returns>
        IList<TB_ORGMEMLKInfo> GetAllAvalible();

        /// <summary>
        /// 根据名称获取组织机构。
        /// </summary>
        /// <param name="lnkId">名称。</param>
        /// <returns>组织机构。</returns>
        TB_ORGMEMLKInfo GetByLnkId(int lnkId);

        /// <summary>
        /// 根据组织机构Id和用户Id获取记录。
        /// </summary>
        /// <param name="orgId">组织机构Id。</param>
        /// <param name="userId">用户Id。</param>
        /// <returns>组织机构与用户关系实体。</returns>
        TB_ORGMEMLKInfo GetByOrgIdAndUserId(int orgId, int userId);

        /// <summary>
        /// 根据用户Id获取记录。
        /// </summary>
        /// <param name="userId">用户Id。</param>
        /// <returns>组织机构与用户关系实体。</returns>
        TB_ORGMEMLKInfo GetByUserId(int userId);

    }
}
