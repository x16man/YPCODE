using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class RoleRight:IRoleRight
    {
        #region Implementation of IRoleRight

        /// <summary>
        /// 添加角色权限。
        /// </summary>
        /// <param name="roleRightInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(RoleRightInfo roleRightInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量添加角色权限。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <param name="rightCodes">权限编码拼接字符串。</param>
        /// <returns>bool</returns>
        public bool Insert(short roleCode, string rightCodes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除角色权限。
        /// </summary>
        /// <param name="roleRightInfo">角色权限实体。</param>
        /// <returns>bool</returns>
        public bool Delete(RoleRightInfo roleRightInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据角色编号删除角色权限关系。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short roleCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有的角色权限关系。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有有效的角色权限关系。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        public ListBase<RoleRightInfo> GetAllAvalible()
        {
            var objs = new RoleRightService.RoleRight().GetAllAvalible();
            var obj1s = new ListBase<RoleRightInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new RoleRightInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据角色编号获取角色权限。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetByRoleCode(short roleCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据权限编号获取角色权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetByRightCode(short rightCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户名获取角色权限集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetByProductCodeAndUserName(short productCode, string userName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
