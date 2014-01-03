using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// 系统管理中用户的WebService接口.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/",Description = "系统管理中用户的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class User : System.Web.Services.WebService//IUser
    {
        #region Implementation of IUser

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户实体对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(UserInfo userInfo)
        {
            return DataProvider.UserProvider.Insert(userInfo);
        }

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(UserInfo userInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更改用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "更改用户.")]
        public bool Update(UserInfo userInfo)
        {
            return DataProvider.UserProvider.Update(userInfo);
        }

        /// <summary>
        /// 更改用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Update(UserInfo userInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        public bool Delete(UserInfo userInfo)
        {
            return this.Delete(userInfo.PKID);
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(UserInfo userInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户实体。
        /// </summary>
        /// <param name="id">用户id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int id)
        {
            return DataProvider.UserProvider.Delete(id);
        }

        /// <summary>
        /// 删除用户实体。
        /// </summary>
        /// <param name="id">用户Id。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(int id, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建Salt值。
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string CreateSalt()
        {
            return DataProvider.UserProvider.CreateSalt();
        }

        /// <summary>
        /// 设置口令。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <param name="pwd">原始口令。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool SetPassword(string loginName, string pwd)
        {
            return DataProvider.UserProvider.SetPassword(loginName, pwd);
        }

        /// <summary>
        /// 根据登录名来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool HasRight(int rightCode, string loginName)
        {
            return DataProvider.UserProvider.HasRight(rightCode, loginName);
        }

        /// <summary>
        /// 根据登录名和文章编号来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <param name="docCode">文章编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool HasRight1(int rightCode, string loginName, string docCode)
        {
            return DataProvider.UserProvider.HasRight(rightCode, loginName, docCode);
        }

        /// <summary>
        /// 根据ID获取用户对象。
        /// </summary>
        /// <param name="id">用户ID。</param>
        /// <returns>用户对象。</returns>
        [WebMethod]
        public UserInfo GetById(int id)
        {
            return DataProvider.UserProvider.GetById(id);
        }

        /// <summary>
        /// 根据登录名获取用户信息。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户实体。</returns>
        [WebMethod(Description = "根据登录名获取用户信息。")]
        public UserInfo GetByLoginName(string loginName)
        {
            return DataProvider.UserProvider.GetByLoginName(loginName);
        }

        /// <summary>
        /// 根据公司编号和登录名获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户。</returns>
        [WebMethod]
        public UserInfo GetByCompanyAndLoginName(string companyCode, string loginName)
        {
            return DataProvider.UserProvider.GetByCompanyAndLoginName(companyCode, loginName);
        }

        /// <summary>
        /// 根据工号获取用户信息。
        /// </summary>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        [WebMethod]
        public UserInfo GetByEmpCode(string empCode)
        {
            return DataProvider.UserProvider.GetByEmpCode(empCode);
        }

        /// <summary>
        /// 根据手机号码获取用户。
        /// </summary>
        /// <param name="mobile">手机号码。</param>
        /// <returns>用户。</returns>
        [WebMethod]
        public UserInfo GetByMobile(string mobile)
        {
            return DataProvider.UserProvider.GetByMobile(mobile);
        }

        /// <summary>
        /// 根据公司编号和工号获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        [WebMethod]
        public UserInfo GetByCompanyAndEmpCode(string companyCode, string empCode)
        {
            return DataProvider.UserProvider.GetByCompanyAndEmpCode(companyCode, empCode);
        }

        /// <summary>
        /// 根据产品号获取用户集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetByProductCode(short productCode)
        {
            return DataProvider.UserProvider.GetByProductCode(productCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据组编号获取用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetByGroupCode(short groupCode)
        {
            return DataProvider.UserProvider.GetByGroupCode(groupCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据角色编号获取用户。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetByRoleCode(short roleCode)
        {
            return DataProvider.UserProvider.GetByRoleCode(roleCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号获取所有员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllByCompany(string companyCode)
        {
            return DataProvider.UserProvider.GetAllByCompany(companyCode) as List<UserInfo>;
            
        }

        /// <summary>
        /// 根据公司编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllAvalibleByCompany(string companyCode)
        {
            return DataProvider.UserProvider.GetAllAvalibleByCompany(companyCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号获取所有员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllEmployeeByCompany(string companyCode)
        {
            return DataProvider.UserProvider.GetAllEmployeeByCompany(companyCode) as List<UserInfo>;
            
        }

        /// <summary>
        /// 根据公司编号获取所有用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllUserByCompany(string companyCode)
        {
            return DataProvider.UserProvider.GetAllUserByCompany(companyCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和部门编号获取所有的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return DataProvider.UserProvider.GetAllByCompanyAndDept(companyCode, deptCode, withChildDept) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和部门编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllAvalibleByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return DataProvider.UserProvider.GetAllAvalibleByCompanyAndDept(companyCode, deptCode, withChildDept) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和部门编号串获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptIds">部门编号串。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllAvalibleByCompanyAndDeptIds(string companyCode, string deptIds)
        {
            return DataProvider.UserProvider.GetAllAvalibleByCompanyAndDeptIds(companyCode, deptIds) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和部门编号获取员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门的员工。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllEmployeeByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return DataProvider.UserProvider.GetAllEmployeeByCompanyAndDept(companyCode, deptCode, withChildDept) as List<UserInfo>;
            
        }

        /// <summary>
        /// 根据公司编号和部门编号获取用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门的用户。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllUserByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return DataProvider.UserProvider.GetAllUserByCompanyAndDept(companyCode, deptCode, withChildDept) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号获取内部用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetInnerUserByCompany(string companyCode)
        {

            return DataProvider.UserProvider.GetInnerUserByCompany(companyCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号或权限编码获取该公司下具有该权限的用户集合。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetAllAvalibleByCompanyAndRightCode(string companyCode, short rightCode)
        {
            return DataProvider.UserProvider.GetAllAvalibleByCompanyAndRightCode(companyCode, rightCode) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找人员。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合.</returns>
        [WebMethod]
        public List<UserInfo> SearchAll(string companyCode, string name)
        {
            return DataProvider.UserProvider.SearchAll(companyCode, name) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找非禁用人员。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名.</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> SearchAllAvalible(string companyCode, string name)
        {
            return DataProvider.UserProvider.SearchAllAvalible(companyCode, name) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> SearchEmp(string companyCode, string name)
        {
            return DataProvider.UserProvider.SearchEmp(companyCode, name) as List<UserInfo>;
        }

        /// <summary>
        /// 根据公司编号和名称（用户名、姓名）模糊查找用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> SearchUser(string companyCode, string name)
        {
            return DataProvider.UserProvider.SearchUser(companyCode, name) as List<UserInfo>;
        }

        /// <summary>
        /// 根据SQL语句来获取用户集合。
        /// </summary>
        /// <param name="sqlStatement">SQL语句。</param>
        /// <returns>用户集合。</returns>
        [WebMethod]
        public List<UserInfo> GetBySQL(string sqlStatement)
        {
            return DataProvider.UserProvider.GetBySQL(sqlStatement) as List<UserInfo>;
        }

        /// <summary>
        /// 获取指定部门的部门主管工号。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门主管工号。</returns>
        [WebMethod ]
        public string GetDeptMgr(string deptCode)
        {
            return DataProvider.UserProvider.GetDeptMgr(deptCode);
        }

        #endregion
    }
}
