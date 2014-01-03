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
    /// 系统管理中用户拥有角色的WebService接口.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/",Description = "系统管理中用户拥有角色的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class OwnedRole : System.Web.Services.WebService,IOwnedRole
    {
        #region Implementation of IOwnedRole

        /// <summary>
        /// 根据产品获取所有的角色与对象的关系的集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        [WebMethod(Description = "根据产品获取所有的角色与对象的关系的集合")]
        public List<OwnedRoleInfo> GetAllByProductCode(short productCode)
        {
            return DataProvider.OwnedRoleProvider.GetAllByProductCode(productCode);
        }

        /// <summary>
        /// 根据用户名获取用户所具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        [WebMethod(Description = "根据用户名获取用户所具有的角色和访问对象的关系")]
        public List<OwnedRoleInfo> GetByUserName(string userName)
        {
            return DataProvider.OwnedRoleProvider.GetByUserName(userName);
        }

        /// <summary>
        /// 根据组编号获取具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>角色和访问对象关系的集合</returns>
        [WebMethod(Description = "根据组编号获取具有的角色和访问对象的关系")]
        public List<OwnedRoleInfo> GetByGroupCode(short groupCode)
        {
            return DataProvider.OwnedRoleProvider.GetByGroupCode(groupCode);
        }

        #endregion
    }
}
