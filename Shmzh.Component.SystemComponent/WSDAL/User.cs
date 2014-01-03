using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Shmzh.Components.Util;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class User:IDAL.IUser
    {
        #region private method

        #endregion

        #region Implementation of IUser

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户实体对象。</param>
        /// <returns>bool</returns>
        public bool Insert(UserInfo userInfo)
        {
            var obj = new UserService.UserInfo();
            CopyHelper.Copy(userInfo ,obj);
            return new UserService.User().Insert(obj);
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
        public bool Update(UserInfo userInfo)
        {
            var obj = new UserService.UserInfo();
            CopyHelper.Copy(userInfo, obj);
            return new UserService.User().Update(obj);
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
        public bool Delete(int id)
        {
            return new UserService.User().Delete(id);
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
        public string CreateSalt()
        {
            return new UserService.User().CreateSalt();
        }

        /// <summary>
        /// 设置口令。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <param name="pwd">原始口令。</param>
        /// <returns>bool</returns>
        public bool SetPassword(string loginName, string pwd)
        {
            return new UserService.User().SetPassword(loginName, pwd);
        }

        /// <summary>
        /// 根据登录名来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string loginName)
        {
            return new UserService.User().HasRight(rightCode, loginName);
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
            return new UserService.User().HasRight1(rightCode, loginName, docCode);
        }

        /// <summary>
        /// 根据ID获取用户对象。
        /// </summary>
        /// <param name="id">用户ID。</param>
        /// <returns>用户对象。</returns>
        public UserInfo GetById(int id)
        {
            var obj = new UserService.User().GetById(id);
            if (obj != null)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据登录名获取用户信息。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByLoginName(string loginName)
        {
            var obj = new UserService.User().GetByLoginName(loginName);
            if (obj != null)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据公司编号和登录名获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户。</returns>
        public UserInfo GetByCompanyAndLoginName(string companyCode, string loginName)
        {
            var obj = new UserService.User().GetByCompanyAndLoginName(companyCode, loginName);
            if (obj != null)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据工号获取用户信息。
        /// </summary>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByEmpCode(string empCode)
        {
            var obj = new UserService.User().GetByEmpCode(empCode);
            if (obj != null)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据手机号码获取用户。
        /// </summary>
        /// <param name="mobile">手机号码。</param>
        /// <returns>用户。</returns>
        public UserInfo GetByMobile(string mobile)
        {
            var obj = new UserService.User().GetByMobile(mobile);
            if (obj != null)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据公司编号和工号获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByCompanyAndEmpCode(string companyCode, string empCode)
        {
            var obj = new UserService.User().GetByCompanyAndEmpCode(companyCode, empCode);
            if (obj != null)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据产品号获取用户集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByProductCode(short productCode)
        {
            var objs = new UserService.User().GetByProductCode(productCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据组编号获取用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByGroupCode(short groupCode)
        {
            var objs = new UserService.User().GetByGroupCode(groupCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据角色编号获取用户。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByRoleCode(short roleCode)
        {
            var objs = new UserService.User().GetByRoleCode(roleCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号获取所有员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllByCompany(string companyCode)
        {
            var objs = new UserService.User().GetAllByCompany(companyCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompany(string companyCode)
        {
            var objs = new UserService.User().GetAllAvalibleByCompany(companyCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号获取所有员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllEmployeeByCompany(string companyCode)
        {
            var objs = new UserService.User().GetAllEmployeeByCompany(companyCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号获取所有用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllUserByCompany(string companyCode)
        {
            var objs = new UserService.User().GetAllUserByCompany(companyCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
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
            var objs = new UserService.User().GetAllByCompanyAndDept(companyCode, deptCode, withChildDept);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
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
            var objs = new UserService.User().GetAllAvalibleByCompanyAndDept(companyCode, deptCode, withChildDept);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        public IList<UserInfo> GetAllAvalibleByCompanyAndDeptIds(string companyCode, string deptIds)
        {
            var objs = new UserService.User().GetAllAvalibleByCompanyAndDeptIds(companyCode, deptIds);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
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
            var objs = new UserService.User().GetAllEmployeeByCompanyAndDept(companyCode, deptCode, withChildDept);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
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
            var objs = new UserService.User().GetAllUserByCompanyAndDept(companyCode, deptCode, withChildDept);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号获取内部用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetInnerUserByCompany(string companyCode)
        {
            var objs = new UserService.User().GetInnerUserByCompany(companyCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号或权限编码获取该公司下具有该权限的用户集合。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompanyAndRightCode(string companyCode, short rightCode)
        {
            var objs = new UserService.User().GetAllAvalibleByCompanyAndRightCode(companyCode, rightCode);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找人员。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合.</returns>
        public IList<UserInfo> SearchAll(string companyCode, string name)
        {
            var objs = new UserService.User().SearchAll(companyCode, name);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找非禁用人员。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名.</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchAllAvalible(string companyCode, string name)
        {
            var objs = new UserService.User().SearchAllAvalible(companyCode, name);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchEmp(string companyCode, string name)
        {
            var objs = new UserService.User().SearchEmp(companyCode, name);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号和名称（用户名、姓名）模糊查找用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchUser(string companyCode, string name)
        {
            var objs = new UserService.User().SearchUser(companyCode, name);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据SQL语句来获取用户集合。
        /// </summary>
        /// <param name="sqlStatement">SQL语句。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetBySQL(string sqlStatement)
        {
            var objs = new UserService.User().GetBySQL(sqlStatement);
            var obj1s = new List<UserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取指定部门的部门主管工号。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门主管工号。</returns>
        public string GetDeptMgr(string deptCode)
        {
            return new UserService.User().GetDeptMgr(deptCode);
        }

        #endregion
    }
}
