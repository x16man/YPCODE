using System.Collections.Generic;
using System.Data;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组的数据访问接口。
    /// </summary>
    public interface IUserRole
    {
        /// <summary>
        /// 添加用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        bool Insert(UserRoleInfo userRoleInfo);
        /// <summary>
        /// 批量添加用户角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="roleCodes">角色编号拼接字符串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        bool Insert(string userNames, string roleCodes, short productCode);
        /// <summary>
        /// 复制用户角色到目标用户
        /// </summary>
        /// <param name="sourceUserName">源用户名。</param>
        /// <param name="targetUserName">目标用户名。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns></returns>
        bool CopyTo(string sourceUserName, string targetUserName, short productCode);
        /// <summary>
        /// 针对知识库条目批量增加用户角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        bool Insert(string userNames, string roleCodes, string checkCode, string type);
        /// <summary>
        /// 删除用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        bool Delete(UserRoleInfo userRoleInfo);
        /// <summary>
        /// 批量删除某些用户的某个产品的角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        bool Delete(string userNames, short productCode);
        /// <summary>
        /// 针对知识库条目删除某一个用户的角色。
        /// </summary>
        /// <param name="userNames">用户名。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        bool Delete(string userNames, string checkCode, string type);
        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        /// <param name="checkCode">知识库条目的id。</param>
        /// <param name="type">知识库条目的类型。</param>
        /// <returns>bool</returns>
        bool ClearAccess(string checkCode, string type);
        /// <summary>
        /// 根据用户名获取所有用户角色。
        /// </summary>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByUserName(string userName);
        /// <summary>
        /// 根据产品编号获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByProductCode(short productCode);
        /// <summary>
        /// 根据角色编号获取用户角色集合。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByRoleCode(short roleCode);
        /// <summary>
        /// 根据产品编号和模糊匹配用户名、姓名来获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByProductCodeAndName(short productCode, string name);
        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByProductCodeAndUserName(short productCode, string userName);

        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="userName">用户名。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByProductCodeAndUserNameAndCheckCodeAndType(short productCode, string userName, string checkCode, string type);
        /// <summary>
        /// 根据CheckCode和Type获取用户角色列表。
        /// </summary>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByCheckCodeAndType(string checkCode, string type);
        /// <summary>
        /// 根据用户名和知识库条目获取用户角色集合。
        /// </summary>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>用户角色集合。</returns>
        IList<UserRoleInfo> GetByCheckCodeAndTypeAndUserName(string checkCode, string type, string userName);
        /// <summary>
        /// 获取没有设置任何访问权限的对象.
        /// </summary>
        /// <param name="rightCode">权限代码</param>
        /// <param name="productcode">产品代码</param>
        /// <returns>DataSet</returns>
        DataSet GetNoAccessObj(int rightCode, int productcode);
        
    }
}
