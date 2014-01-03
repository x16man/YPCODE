using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 角色的数据访问接口。
    /// </summary>
    public interface IRole
    {
        /// <summary>
        /// 添加角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        bool Insert(RoleInfo roleInfo);
        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        bool Update(RoleInfo roleInfo);
        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        bool Delete(RoleInfo roleInfo);
        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        bool Delete(short roleCode);
        /// <summary>
        /// 是否已经存在角色编号。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        bool IsExist(short roleCode);
        /// <summary>
        /// 是否已经存在角色名称。
        /// </summary>
        /// <param name="roleName">组名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        bool IsExist(string roleName, short productCode);

        /// <summary>
        /// 根据产品编号获取所有角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色记录集合。</returns>
        IList<RoleInfo> GetAllByProductCode(short productCode);
        /// <summary>
        /// 根据产品编号获取所有有效的角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色记录集合。</returns>
        IList<RoleInfo> GetAllAvalibleByProductCode(short productCode);
        /// <summary>
        /// 根据角色编号获取角色实体。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>ArrayList</returns>
        RoleInfo GetByCode(short roleCode);
        

    }
}
