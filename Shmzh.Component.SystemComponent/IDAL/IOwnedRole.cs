using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 用户具有的访问对象和角色的关系的数据访问接口。
    /// </summary>
    public interface IOwnedRole
    {
        /// <summary>
        /// 根据产品获取所有的角色与对象的关系的集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        List<OwnedRoleInfo> GetAllByProductCode(short productCode);
        /// <summary>
        /// 根据用户名获取用户所具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="UserName">用户名。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        List<OwnedRoleInfo> GetByUserName(string UserName);

        /// <summary>
        /// 根据组编号获取具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>角色和访问对象关系的集合</returns>
        List<OwnedRoleInfo> GetByGroupCode(short groupCode);
    }
}
