using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 角色权限的数据访问接口。
    /// </summary>
    public interface IRoleRight
    {
        /// <summary>
        /// 添加角色权限。
        /// </summary>
        /// <param name="roleRightInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        bool Insert(RoleRightInfo roleRightInfo);
        /// <summary>
        /// 批量添加角色权限。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <param name="rightCodes">权限编码拼接字符串。</param>
        /// <returns>bool</returns>
        bool Insert(short roleCode, string rightCodes);
        /// <summary>
        /// 删除角色权限。
        /// </summary>
        /// <param name="roleRightInfo">角色权限实体。</param>
        /// <returns>bool</returns>
        bool Delete(RoleRightInfo roleRightInfo);
        /// <summary>
        /// 根据角色编号删除角色权限关系。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        bool Delete(short roleCode);
        /// <summary>
        /// 获取所有的角色权限关系。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        IList<RoleRightInfo> GetAll();
        /// <summary>
        /// 获取所有有效的角色权限关系。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        ListBase<RoleRightInfo> GetAllAvalible();
        /// <summary>
        /// 根据角色编号获取角色权限。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        IList<RoleRightInfo> GetByRoleCode(short roleCode);
        /// <summary>
        /// 根据权限编号获取角色权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>角色权限集合。</returns>
        IList<RoleRightInfo> GetByRightCode(short rightCode);

        /// <summary>
        /// 根据用户名获取角色权限集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>角色权限集合。</returns>
        IList<RoleRightInfo> GetByProductCodeAndUserName(short productCode, string userName);
    }
}
