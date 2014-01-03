using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// Role 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Role : System.Web.Services.WebService//,IRole
    {
        #region Implementation of IRole

        /// <summary>
        /// 添加角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(RoleInfo roleInfo)
        {
            return DataProvider.RoleProvider.Insert(roleInfo);
        }

        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(RoleInfo roleInfo)
        {
            return DataProvider.RoleProvider.Update(roleInfo);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        public bool Delete(RoleInfo roleInfo)
        {
            return this.Delete((short)roleInfo.RoleCode);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(short roleCode)
        {
            return DataProvider.RoleProvider.Delete(roleCode);
        }

        /// <summary>
        /// 是否已经存在角色编号。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool IsExist(short roleCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 是否已经存在角色名称。
        /// </summary>
        /// <param name="roleName">组名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool IsExist1(string roleName, short productCode)
        {
            return DataProvider.RoleProvider.IsExist(roleName, productCode);
        }

        /// <summary>
        /// 根据产品编号获取所有角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色记录集合。</returns>
        [WebMethod]
        public List<RoleInfo> GetAllByProductCode(short productCode)
        {
            return DataProvider.RoleProvider.GetAllAvalibleByProductCode(productCode) as List<RoleInfo>;
        }

        /// <summary>
        /// 根据产品编号获取所有有效的角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色记录集合。</returns>
        [WebMethod]
        public List<RoleInfo> GetAllAvalibleByProductCode(short productCode)
        {
            return DataProvider.RoleProvider.GetAllAvalibleByProductCode(productCode) as List<RoleInfo>;
        }

        /// <summary>
        /// 根据角色编号获取角色实体。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>ArrayList</returns>
        [WebMethod]
        public RoleInfo GetByCode(short roleCode)
        {
            return DataProvider.RoleProvider.GetByCode(roleCode);
        }

        #endregion
    }
}
