using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// UserRole 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class UserRole : System.Web.Services.WebService//,IUserRole
    {
        #region Implementation of IUserRole

        /// <summary>
        /// 添加用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(UserRoleInfo userRoleInfo)
        {
            return DataProvider.UserRoleProvider.Insert(userRoleInfo);
        }

        /// <summary>
        /// 批量添加用户角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="roleCodes">角色编号拼接字符串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert1(string userNames, string roleCodes, short productCode)
        {
            return DataProvider.UserRoleProvider.Insert(userNames, roleCodes, productCode);
        }

        /// <summary>
        /// 复制用户角色到目标用户
        /// </summary>
        /// <param name="sourceUserName">源用户名。</param>
        /// <param name="targetUserName">目标用户名。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns></returns>
        [WebMethod]
        public bool CopyTo(string sourceUserName, string targetUserName, short productCode)
        {
            return DataProvider.UserRoleProvider.CopyTo(sourceUserName, targetUserName, productCode);
        }

        /// <summary>
        /// 针对知识库条目批量增加用户角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert2(string userNames, string roleCodes, string checkCode, string type)
        {
            return DataProvider.UserRoleProvider.Insert(userNames, roleCodes, checkCode, type);
        }

        /// <summary>
        /// 删除用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(UserRoleInfo userRoleInfo)
        {
            return DataProvider.UserRoleProvider.Delete(userRoleInfo);
        }

        /// <summary>
        /// 批量删除某些用户的某个产品的角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete1(string userNames, short productCode)
        {
            return DataProvider.UserRoleProvider.Delete(userNames, productCode);
        }

        /// <summary>
        /// 针对知识库条目删除某一个用户的角色。
        /// </summary>
        /// <param name="userNames">用户名。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete2(string userNames, string checkCode, string type)
        {
            return DataProvider.UserRoleProvider.Delete(userNames, checkCode, type);
        }

        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        /// <param name="checkCode">知识库条目的id。</param>
        /// <param name="type">知识库条目的类型。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool ClearAccess(string checkCode, string type)
        {
            return DataProvider.UserRoleProvider.ClearAccess(checkCode, type);
        }

        /// <summary>
        /// 根据用户名获取所有用户角色。
        /// </summary>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByUserName(string userName)
        {
            return DataProvider.UserRoleProvider.GetByUserName(userName) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByProductCode(short productCode)
        {
            return DataProvider.UserRoleProvider.GetByProductCode(productCode) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据角色编号获取用户角色集合。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByRoleCode(short roleCode)
        {
            return DataProvider.UserRoleProvider.GetByRoleCode(roleCode) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和模糊匹配用户名、姓名来获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByProductCodeAndName(short productCode, string name)
        {
            return DataProvider.UserRoleProvider.GetByProductCodeAndName(productCode, name) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByProductCodeAndUserName(short productCode, string userName)
        {
            return DataProvider.UserRoleProvider.GetByProductCodeAndUserName(productCode, userName) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="userName">用户名。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByProductCodeAndUserNameAndCheckCodeAndType(short productCode, string userName, string checkCode, string type)
        {
            return DataProvider.UserRoleProvider.GetByProductCodeAndUserNameAndCheckCodeAndType(productCode, userName, checkCode, type) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据CheckCode和Type获取用户角色列表。
        /// </summary>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByCheckCodeAndType(string checkCode, string type)
        {
            return DataProvider.UserRoleProvider.GetByCheckCodeAndType(checkCode, type) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 根据用户名和知识库条目获取用户角色集合。
        /// </summary>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>用户角色集合。</returns>
        [WebMethod]
        public List<UserRoleInfo> GetByCheckCodeAndTypeAndUserName(string checkCode, string type, string userName)
        {
            return DataProvider.UserRoleProvider.GetByCheckCodeAndTypeAndUserName(checkCode, type, userName) as List<UserRoleInfo>;
        }

        /// <summary>
        /// 获取没有设置任何访问权限的对象.
        /// </summary>
        /// <param name="rightCode">权限代码</param>
        /// <param name="productcode">产品代码</param>
        /// <returns>DataSet</returns>
        [WebMethod]
        public DataSet GetNoAccessObj(int rightCode, int productcode)
        {
            return DataProvider.UserRoleProvider.GetNoAccessObj(rightCode, productcode);
        }

        #endregion
    }
}
