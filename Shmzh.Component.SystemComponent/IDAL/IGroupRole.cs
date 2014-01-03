using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组与角色关系的数据访问接口。
    /// </summary>
    public interface IGroupRole
    {
        /// <summary>
        /// 添加组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色。</param>
        /// <returns>bool</returns>
        bool Insert(GroupRoleInfo groupRoleInfo);
        /// <summary>
        /// 批量添加组角色。
        /// </summary>
        /// <param name="groupCodes">组编号串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        /// <remarks>首先删除</remarks>
        bool Insert(string groupCodes, string roleCodes, short productCode);
        
        /// <summary>
        /// 针对知识库条目批量添加组角色。
        /// </summary>
        /// <param name="groupCodes">组编号串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="checkCode">知识库条目id。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        bool Insert(string groupCodes, string roleCodes, string checkCode, string type);
        /// <summary>
        /// 删除组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色。</param>
        /// <returns>bool</returns>
        bool Delete(GroupRoleInfo groupRoleInfo);
        /// <summary>
        /// 删除某些组的某一产品的组角色关系。
        /// </summary>
        /// <param name="groupCodes">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        bool Delete(string groupCodes, short productCode);
        
        /// <summary>
        /// 针对知识库条目删除组的角色。
        /// </summary>
        /// <param name="groupCodes"></param>
        /// <param name="checkCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool Delete(string groupCodes, string checkCode, string type);
        
        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        /// <param name="checkCode">知识库条目id。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        bool ClearAccess(string checkCode, string type);

        /// <summary>
        /// 复制组角色到目标组
        /// </summary>
        /// <param name="sourceGroupCode">源组名称。</param>
        /// <param name="targetGroupCode">目标组名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns></returns>
        bool CopyTo(string sourceGroupCode, string targetGroupCode, short productCode);

        /// <summary>
        /// 根据组编号和产品编号获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByGroupCodeAndProductCode(short groupCode, short productCode);
        /// <summary>
        /// 根据组编号和知识库条目编号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">知识库条目编号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色编号。</returns>
        IList<GroupRoleInfo> GetByGroupCodeAndCheckCodeAndType(short groupCode, string checkCode, string type);
        /// <summary>
        /// 根据知识库条目编号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="checkCode">知识库条目编号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByCheckCodeAndType(string checkCode, string type);
        /// <summary>
        /// 根据产品编号获取组角色编号。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByProductCode(short productCode);
        /// <summary>
        /// 根据产品编号和角色编号获取组角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByRoleCode(short roleCode);
        /// <summary>
        /// 根据产品编号和用户名、姓名来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">组名。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByProductCodeAndName(short productCode, string name);
        /// <summary>
        /// 根据产品编号和组编号来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByProductCodeAndGroupCode(short productCode, short groupCode);

        /// <summary>
        /// 根据产品编号和组编号和检查对象来获取组角色集合
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByProductCodeAndGroupCodeAndCheckCodeAndType(short productCode, short groupCode, string checkCode, string type);

        /// <summary>
        /// 根据用户组和访问对象类型获取组角色列表。
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <param name="type">访问对象类型</param>
        /// <returns>组角色集合。</returns>
        IList<GroupRoleInfo> GetByGroupCodeAndType(short groupCode, string type);
    }
}
