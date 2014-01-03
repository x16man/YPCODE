using System.Collections.Generic;
using System.Data.Common;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 工作流组织机构的数据访问接口。
    /// </summary>
    public interface ITB_ORGTREE
    {
        /// <summary>
        /// 添加东兰工作流部门信息。
        /// </summary>
        /// <param name="tborgtreeinfo">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Insert(TB_ORGTREEInfo tborgtreeinfo, DbTransaction trans);

        /// <summary>
        /// 修改东兰工作流部门信息。
        /// </summary>
        /// <param name="tborgtreeinfo">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Update(TB_ORGTREEInfo tborgtreeinfo, DbTransaction trans);

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="tborgtreeinfo">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(TB_ORGTREEInfo tborgtreeinfo, DbTransaction trans);

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="itemId">部门key。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(int itemId, DbTransaction trans);

        /// <summary>
        /// 获取所有组织机构。
        /// </summary>
        /// <returns>所有组织机构。</returns>
        IList<TB_ORGTREEInfo> GetAll();

        /// <summary>
        /// 获取所有组织机构。
        /// </summary>
        /// <returns>所有组织机构。</returns>
        IList<TB_ORGTREEInfo> GetAllAvalible();

        /// <summary>
        /// 根据名称获取组织机构。
        /// </summary>
        /// <param name="name">名称。</param>
        /// <returns>组织机构。</returns>
        TB_ORGTREEInfo GetByName(string name);

        /// <summary>
        /// 东兰工作流是否存在某一名称的部门
        /// </summary>
        /// <param name="name"></param>
        bool IsExistName(string name);

        /// <summary>
        /// 部门失效
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="trans">事务对象。</param>
        bool Disable(int itemid, DbTransaction trans);

        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="deptname">部门名称。</param>
        /// <returns>bool</returns>
        bool HasChildDept(string deptname);
        
        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="deptName">父部门名称。</param>
        /// <returns>bool</returns>
        bool HasUser(string deptName);
        
        /// <summary>
        /// 判断是否有领导。
        /// </summary>
        /// <param name="deptName">部门名称。</param>
        /// <returns></returns>
        bool HasLeader(string deptName);
    }
}
