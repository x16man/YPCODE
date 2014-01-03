using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// 系统管理中角色权限的WebService接口.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/",Description = "系统管理中角色权限的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class RoleRight : System.Web.Services.WebService,IRoleRight
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
        [WebMethod(Description = "获取所有有效的角色权限关系。")]
        public ListBase<RoleRightInfo> GetAllAvalible()
        {
            return DataProvider.RoleRightProvider.GetAllAvalible();
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
