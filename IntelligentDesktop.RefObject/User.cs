using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    [Serializable]
    /// <summary>
    /// 用户对象的SQLServer数据库的数据访问对象。
    /// </summary>
    public class User : MarshalByRefObject, IUser
    {
        private static Shmzh.Components.SystemComponent.IDAL.IUser dal;

        static User()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.UserProvider;
        }

        #region IUser 成员

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户实体对象。</param>
        /// <returns>bool</returns>
        public bool Insert(UserInfo userInfo)
        {
            return dal.Insert(userInfo);
        }

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(UserInfo userInfo, DbTransaction trans)
        {
            return Insert(userInfo,trans);
        }
        
        /// <summary>
        /// 更改用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        public bool Update(UserInfo userInfo)
        {
            return dal.Update(userInfo);
        }

      
        /// <summary>
        /// 更改用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Update(UserInfo userInfo, DbTransaction trans)
        {
            return dal.Update(userInfo, trans);
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(UserInfo userInfo, DbTransaction trans)
        {
            return dal.Delete(userInfo, trans);
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        public bool Delete(UserInfo userInfo)
        {
            return dal.Delete(userInfo);
        }

        /// <summary>
        /// 删除用户实体。
        /// </summary>
        /// <param name="id">用户id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
      
        /// <summary>
        /// 删除用户实体。
        /// </summary>
        /// <param name="id">用户Id。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(int id, DbTransaction trans)
        {
            return dal.Delete(id, trans);
        }

         /// <summary>
        /// 根据ID获取用户对象。
        /// </summary>
        /// <param name="id">用户ID。</param>
        /// <returns>用户对象。</returns>
        public UserInfo GetById(int id)
        {
            return dal.GetById(id);
        }

        /// <summary>
        /// 根据产品号获取用户集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByProductCode(short productCode)
        {
            return GetByProductCode(productCode);
        }
       
         /// <summary>
        /// 根据组编号获取用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByGroupCode(short groupCode)
        {
            return dal.GetByGroupCode(groupCode);
        }

        /// <summary>
        /// 根据公司编号获取所有员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllByCompany(string companyCode)
        {
            return dal.GetAllByCompany(companyCode);
        }
       
        /// <summary>
        /// 根据公司编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompany(string companyCode)
        {
            return dal.GetAllAvalibleByCompany(companyCode);
        }

        /// <summary>
        /// 根据公司编号获取所有用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllUserByCompany(string companyCode)
        {
            return dal.GetAllUserByCompany(companyCode);
        }

        /// <summary>
        /// 根据角色编号获取用户。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByRoleCode(short roleCode)
        {
            return dal.GetByRoleCode(roleCode);
        }

        /// <summary>
        /// 根据公司编号获取内部用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetInnerUserByCompany(string companyCode)
        {
            return dal.GetInnerUserByCompany(companyCode);
        }

        /// <summary>
        /// 根据公司编号获取所有员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllEmployeeByCompany(string companyCode)
        {
            return dal.GetAllEmployeeByCompany(companyCode);
        }

         /// <summary>
        /// 根据公司编号和部门编号获取所有的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return dal.GetAllByCompanyAndDept(companyCode, deptCode, withChildDept);
        }
        
         /// <summary>
        /// 根据公司编号和部门编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return dal.GetAllAvalibleByCompanyAndDept(companyCode, deptCode, withChildDept);
        }

        /// <summary>
        /// 根据公司编号和部门编号串获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptIds">部门编号串。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompanyAndDeptIds(string companyCode, string deptIds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据公司编号和部门编号获取员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门的员工。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllEmployeeByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return dal.GetAllEmployeeByCompanyAndDept(companyCode, deptCode, withChildDept);
        }
       
        /// <summary>
        /// 根据公司编号和部门编号获取用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门的用户。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllUserByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            return dal.GetAllUserByCompanyAndDept(companyCode, deptCode, withChildDept);
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合.</returns>
        public IList<UserInfo> SearchAll(string companyCode, string name)
        {
            return dal.SearchAll(companyCode, name);
        }
        
         /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找非禁用人员。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名.</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchAllAvalible(string companyCode, string name)
        {
            return dal.SearchAllAvalible(companyCode, name);
        }
      
        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchEmp(string companyCode, string name)
        {
            return dal.SearchEmp(companyCode, name);
        }

         /// <summary>
        /// 根据公司编号和名称（用户名、姓名）模糊查找用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchUser(string companyCode, string name)
        {
            return dal.SearchUser(companyCode, name);
        }
       
         /// <summary>
        /// 根据公司编号和登录名获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户。</returns>
        public UserInfo GetByCompanyAndLoginName(string companyCode, string loginName)
        {
            return dal.GetByCompanyAndLoginName(companyCode, loginName);
        }

        /// <summary>
        /// 根据公司编号和工号获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByCompanyAndEmpCode(string companyCode, string empCode)
        {
            return dal.GetByCompanyAndEmpCode(companyCode, empCode);
        }

         /// <summary>
        /// 根据登录名获取用户信息。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByLoginName(string loginName)
        {
            return dal.GetByLoginName(loginName);
        }
      
        /// <summary>
        /// 根据工号获取用户信息。
        /// </summary>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByEmpCode(string empCode)
        {
            return dal.GetByEmpCode(empCode);
        }

        /// <summary>
        /// 根据手机号码获取用户。
        /// </summary>
        /// <param name="mobile">手机号码。</param>
        /// <returns>用户。</returns>
        public UserInfo GetByMobile(string mobile)
        {
            return dal.GetByMobile(mobile);
        }
      
         /// <summary>
        /// 生成密码哈希时需要的附加码,随机产生
        /// </summary>
        /// <returns>附加码</returns>
        public string CreateSalt()
        {
            return dal.CreateSalt();
        }
       
        /// <summary>
        /// 设置口令。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <param name="pwd">原始口令。</param>
        /// <returns>bool</returns>
        public bool SetPassword(string loginName, string pwd)
        {
            return SetPassword(loginName, pwd);
        }
      
        /// <summary>
        /// 根据公司编号或权限编码获取该公司下具有该权限的用户集合。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompanyAndRightCode(string companyCode, short rightCode)
        {
            return dal.GetAllAvalibleByCompanyAndRightCode(companyCode, rightCode);
        }

        /// <summary>
        /// 根据SQL语句来获取用户集合。
        /// </summary>
        /// <param name="sqlStatement">SQL语句。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetBySQL(string sqlStatement)
        {
            return dal.GetBySQL(sqlStatement);
        }

        /// <summary>
        /// 通过部门编号查找部门主管工号
        /// </summary>
        /// <param name="strDeptCode"></param>
        /// <returns></returns>
        public string GetDeptMgr(string strDeptCode)
        {
            return dal.GetDeptMgr(strDeptCode);
        }
       
        /// <summary>
        /// 根据登录名来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string loginName)
        {
            return dal.HasRight(rightCode, loginName);
        }

        /// <summary>
        /// 根据登录名和文章编号来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <param name="docCode">文章编号。</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string loginName, string docCode)
        {
            return dal.HasRight(rightCode, loginName, docCode);
        }

        #endregion

        #region 其他
        /// <summary>
        /// 改变口令
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="oldPassword">旧口令</param>
        /// <param name="newPassword">新口令</param>
        /// <returns>bool</returns>
        public bool ChangePassword(string loginName, string oldPassword, string newPassword)
        {
            return Shmzh.Components.SystemComponent.User.ChangePassword(loginName, oldPassword, newPassword);
        }

        public Shmzh.Components.SystemComponent.User CreateUser(String loginName)
        {
            return new Shmzh.Components.SystemComponent.User(loginName);
        }

        public Shmzh.Components.SystemComponent.User CreateUser(String loginName, String pwd)
        {
            return new Shmzh.Components.SystemComponent.User(loginName, pwd);
        }
        #endregion
    }
}