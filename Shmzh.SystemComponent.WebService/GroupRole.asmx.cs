using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// GroupRole 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class GroupRole : System.Web.Services.WebService//,IGroupRole
    {
        #region Implementation of IGroupRole

        /// <summary>
        /// 添加组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(GroupRoleInfo groupRoleInfo)
        {
            return DataProvider.GroupRoleProvider.Insert(groupRoleInfo);
        }

        /// <summary>
        /// 批量添加组角色。
        /// </summary>
        /// <param name="groupCodes">组编号串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        /// <remarks>首先删除</remarks>
        [WebMethod]
        public bool Insert1(string groupCodes, string roleCodes, short productCode)
        {
            return DataProvider.GroupRoleProvider.Insert(groupCodes, roleCodes, productCode);
        }

        /// <summary>
        /// 针对知识库条目批量添加组角色。
        /// </summary>
        /// <param name="groupCodes">组编号串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="checkCode">知识库条目id。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert2(string groupCodes, string roleCodes, string checkCode, string type)
        {
            return DataProvider.GroupRoleProvider.Insert(groupCodes, roleCodes, checkCode, type);
        }

        /// <summary>
        /// 删除组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(GroupRoleInfo groupRoleInfo)
        {
            return DataProvider.GroupRoleProvider.Delete(groupRoleInfo);
        }

        /// <summary>
        /// 删除某些组的某一产品的组角色关系。
        /// </summary>
        /// <param name="groupCodes">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete1(string groupCodes, short productCode)
        {
            return DataProvider.GroupRoleProvider.Delete(groupCodes, productCode);
        }

        /// <summary>
        /// 针对知识库条目删除组的角色。
        /// </summary>
        /// <param name="groupCodes"></param>
        /// <param name="checkCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod]
        public bool Delete2(string groupCodes, string checkCode, string type)
        {
            return DataProvider.GroupRoleProvider.Delete(groupCodes, checkCode, type);
        }

        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        /// <param name="checkCode">知识库条目id。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool ClearAccess(string checkCode, string type)
        {
            return DataProvider.GroupRoleProvider.ClearAccess(checkCode, type);
        }

        /// <summary>
        /// 复制组角色到目标组
        /// </summary>
        /// <param name="sourceGroupCode">源组名称。</param>
        /// <param name="targetGroupCode">目标组名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns></returns>
        [WebMethod]
        public bool CopyTo(string sourceGroupCode, string targetGroupCode, short productCode)
        {
            return DataProvider.GroupRoleProvider.CopyTo(sourceGroupCode, targetGroupCode, productCode);
        }

        /// <summary>
        /// 根据组编号和产品编号获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByGroupCodeAndProductCode(short groupCode, short productCode)
        {
            return DataProvider.GroupRoleProvider.GetByGroupCodeAndProductCode(groupCode, productCode) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据组编号和知识库条目编号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">知识库条目编号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色编号。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByGroupCodeAndCheckCodeAndType(short groupCode, string checkCode, string type)
        {
            return DataProvider.GroupRoleProvider.GetByGroupCodeAndCheckCodeAndType(groupCode, checkCode, type) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据知识库条目编号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="checkCode">知识库条目编号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByCheckCodeAndType(string checkCode, string type)
        {
            return DataProvider.GroupRoleProvider.GetByCheckCodeAndType(checkCode, type) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号获取组角色编号。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByProductCode(short productCode)
        {
            return DataProvider.GroupRoleProvider.GetByProductCode(productCode) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和角色编号获取组角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByRoleCode(short roleCode)
        {
            return DataProvider.GroupRoleProvider.GetByRoleCode(roleCode) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和用户名、姓名来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">组名。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByProductCodeAndName(short productCode, string name)
        {
            return DataProvider.GroupRoleProvider.GetByProductCodeAndName(productCode, name) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和组编号来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByProductCodeAndGroupCode(short productCode, short groupCode)
        {
            return DataProvider.GroupRoleProvider.GetByProductCodeAndGroupCode(productCode, groupCode) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据产品编号和组编号和检查对象来获取组角色集合
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByProductCodeAndGroupCodeAndCheckCodeAndType(short productCode, short groupCode, string checkCode, string type)
        {
            return DataProvider.GroupRoleProvider.GetByProductCodeAndGroupCodeAndCheckCodeAndType(productCode, groupCode, checkCode, type) as List<GroupRoleInfo>;
        }

        /// <summary>
        /// 根据用户组和访问对象类型获取组角色列表。
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <param name="type">访问对象类型</param>
        /// <returns>组角色集合。</returns>
        [WebMethod]
        public List<GroupRoleInfo> GetByGroupCodeAndType(short groupCode, string type)
        {
            return DataProvider.GroupRoleProvider.GetByGroupCodeAndType(groupCode, type) as List<GroupRoleInfo>;
        }

        #endregion
    }
}
