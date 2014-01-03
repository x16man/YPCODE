using System.Collections.Generic;
using System.Data.Common;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 东兰工作流用户数据接口。
    /// </summary>
    public interface ITB_Users
    {
        /// <summary>
        /// 添加工作流人员信息.
        /// </summary>
        /// <param name="tbluserInfo">用户信息。</param>
        /// <param name="trans">事务对象。</param>
        bool Insert(TB_UsersInfo tbluserInfo, DbTransaction trans);

        /// <summary>
        /// 修改东兰工作流人员信息。
        /// </summary>
        /// <param name="tbluserInfo">用户信息。</param>
        /// <param name="trans">事务对象。</param>
        bool Update(TB_UsersInfo tbluserInfo, DbTransaction trans);
        
        /// <summary>
        /// 删除东兰工作流人员信息。
        /// </summary>
         /// <param name="tbluserInfo">用户信息。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(TB_UsersInfo tbluserInfo, DbTransaction trans);
        
        /// <summary>
        /// 删除东兰工作流人员信息。
        /// </summary>
        /// <param name="key">人员信息编号。</param>
        /// <param name="trans">事务对象。</param>
        bool Delete(int key, DbTransaction trans);
        
        
        /// <summary>
        /// 根据用户名获取人员信息。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>用户实体。</returns>
        TB_UsersInfo GetByUserName(string userName);

        /// <summary>
        /// 根据工号获取人员信息。
        /// </summary>
        /// <param name="hrid">工号。</param>
        /// <returns>用户实体。</returns>
        TB_UsersInfo GetByHrId(string hrid);
        /// <summary>
        /// 根据用户Id获取用户实体。
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>用户实体</returns>
        TB_UsersInfo GetByUserId(int userId);
        /// <summary>
        /// 根据组织机构Id获取用户列表。
        /// </summary>
        /// <param name="orgId">组织机构Id。</param>
        /// <returns>用户列表。</returns>
        IList<TB_UsersInfo> GetByOrgId(int orgId);

        /// <summary>
        /// 获取所有的用户列表。
        /// </summary>
        /// <returns>所有的用户列表。</returns>
        IList<TB_UsersInfo> GetAll();

        /// <summary>
        /// 获取所有有效的用户列表。
        /// </summary>
        /// <returns>所有有效的用户列表。</returns>
        IList<TB_UsersInfo> GetAllAvalible();

        /// <summary>
        /// 获取所有预算审批人的用户列表。
        /// </summary>
        /// <returns>所有预算审批人的用户列表。</returns>
        List<TB_UsersInfo> GetAllBudgetManager();
    }
}
