using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class OwnedRole:IOwnedRole
    {
        #region Implementation of IOwnedRole

        /// <summary>
        /// 根据产品获取所有的角色与对象的关系的集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        public List<OwnedRoleInfo> GetAllByProductCode(short productCode)
        {
            var objs = new OwnedRoleService.OwnedRole().GetAllByProductCode(productCode);
            var obj1s = new ListBase<OwnedRoleInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new OwnedRoleInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据用户名获取用户所具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        public List<OwnedRoleInfo> GetByUserName(string userName)
        {
            var objs = new OwnedRoleService.OwnedRole().GetByUserName(userName);
            var obj1s = new ListBase<OwnedRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new OwnedRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据组编号获取具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>角色和访问对象关系的集合</returns>
        public List<OwnedRoleInfo> GetByGroupCode(short groupCode)
        {
            var objs = new OwnedRoleService.OwnedRole().GetByGroupCode(groupCode);
            var obj1s = new ListBase<OwnedRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new OwnedRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
