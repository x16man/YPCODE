using System.Collections.Generic;
using System.Data;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class UserRole:IUserRole
    {
        #region Implementation of IUserRole

        /// <summary>
        /// 添加用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(UserRoleInfo userRoleInfo)
        {
            var obj = new UserRoleService.UserRoleInfo();
            CopyHelper.Copy(userRoleInfo, obj);
            return new UserRoleService.UserRole().Insert(obj);
        }

        /// <summary>
        /// 批量添加用户角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="roleCodes">角色编号拼接字符串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool Insert(string userNames, string roleCodes, short productCode)
        {
            return new UserRoleService.UserRole().Insert1(userNames, roleCodes, productCode);
        }

        /// <summary>
        /// 复制用户角色到目标用户
        /// </summary>
        /// <param name="sourceUserName">源用户名。</param>
        /// <param name="targetUserName">目标用户名。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns></returns>
        public bool CopyTo(string sourceUserName, string targetUserName, short productCode)
        {
            return new UserRoleService.UserRole().CopyTo(sourceUserName, targetUserName, productCode);
        }

        /// <summary>
        /// 针对知识库条目批量增加用户角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        public bool Insert(string userNames, string roleCodes, string checkCode, string type)
        {
            return new UserRoleService.UserRole().Insert2(userNames, roleCodes, checkCode, type);
        }

        /// <summary>
        /// 删除用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        public bool Delete(UserRoleInfo userRoleInfo)
        {
            var obj = new UserRoleService.UserRoleInfo();
            CopyHelper.Copy(userRoleInfo, obj);
            return new UserRoleService.UserRole().Delete(obj);
        }

        /// <summary>
        /// 批量删除某些用户的某个产品的角色。
        /// </summary>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string userNames, short productCode)
        {
            return new UserRoleService.UserRole().Delete1(userNames, productCode);
        }

        /// <summary>
        /// 针对知识库条目删除某一个用户的角色。
        /// </summary>
        /// <param name="userNames">用户名。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        public bool Delete(string userNames, string checkCode, string type)
        {
            return new UserRoleService.UserRole().Delete2(userNames, checkCode, type);
        }

        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        /// <param name="checkCode">知识库条目的id。</param>
        /// <param name="type">知识库条目的类型。</param>
        /// <returns>bool</returns>
        public bool ClearAccess(string checkCode, string type)
        {
            return new UserRoleService.UserRole().ClearAccess(checkCode, type);
        }

        /// <summary>
        /// 根据用户名获取所有用户角色。
        /// </summary>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByUserName(string userName)
        {
            var objs = new UserRoleService.UserRole().GetByUserName(userName);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByProductCode(short productCode)
        {
            var objs = new UserRoleService.UserRole().GetByProductCode(productCode);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据角色编号获取用户角色集合。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByRoleCode(short roleCode)
        {
            var objs = new UserRoleService.UserRole().GetByRoleCode(roleCode);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和模糊匹配用户名、姓名来获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByProductCodeAndName(short productCode, string name)
        {
            var objs = new UserRoleService.UserRole().GetByProductCodeAndName(productCode,name );
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByProductCodeAndUserName(short productCode, string userName)
        {
            var objs = new UserRoleService.UserRole().GetByProductCodeAndUserName(productCode, userName);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="userName">用户名。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByProductCodeAndUserNameAndCheckCodeAndType(short productCode, string userName, string checkCode, string type)
        {
            var objs = new UserRoleService.UserRole().GetByProductCodeAndUserNameAndCheckCodeAndType(productCode, userName,checkCode ,type);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据CheckCode和Type获取用户角色列表。
        /// </summary>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByCheckCodeAndType(string checkCode, string type)
        {
            var objs = new UserRoleService.UserRole().GetByCheckCodeAndType(checkCode, type);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据用户名和知识库条目获取用户角色集合。
        /// </summary>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByCheckCodeAndTypeAndUserName(string checkCode, string type, string userName)
        {
            var objs = new UserRoleService.UserRole().GetByCheckCodeAndTypeAndUserName(checkCode, type, userName);
            var obj1s = new List<UserRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new UserRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取没有设置任何访问权限的对象.
        /// </summary>
        /// <param name="rightCode">权限代码</param>
        /// <param name="productcode">产品代码</param>
        /// <returns>DataSet</returns>
        public DataSet GetNoAccessObj(int rightCode, int productcode)
        {
            return new UserRoleService.UserRole().GetNoAccessObj(rightCode, productcode);
        }

        #endregion
    }
}
