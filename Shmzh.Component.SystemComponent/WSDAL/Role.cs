using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class Role:IRole
    {
        #region Implementation of IRole

        /// <summary>
        /// 添加角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(RoleInfo roleInfo)
        {
            var obj = new RoleService.RoleInfo();
            CopyHelper.Copy(roleInfo ,obj);
            return new RoleService.Role().Insert(obj);
        }

        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        public bool Update(RoleInfo roleInfo)
        {
            var obj = new RoleService.RoleInfo();
            CopyHelper.Copy(roleInfo, obj);
            return new RoleService.Role().Update(obj);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        public bool Delete(RoleInfo roleInfo)
        {
            return new RoleService.Role().Delete((short)roleInfo.RoleCode);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short roleCode)
        {
            return new RoleService.Role().Delete(roleCode);
        }

        /// <summary>
        /// 是否已经存在角色编号。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(short roleCode)
        {
            return new RoleService.Role().IsExist(roleCode);
        }

        /// <summary>
        /// 是否已经存在角色名称。
        /// </summary>
        /// <param name="roleName">组名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(string roleName, short productCode)
        {
            return new RoleService.Role().IsExist1(roleName, productCode);
        }

        /// <summary>
        /// 根据产品编号获取所有角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色记录集合。</returns>
        public IList<RoleInfo> GetAllByProductCode(short productCode)
        {
            var objs = new RoleService.Role().GetAllByProductCode(productCode);
            var obj1s = new List<RoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new RoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号获取所有有效的角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色记录集合。</returns>
        public IList<RoleInfo> GetAllAvalibleByProductCode(short productCode)
        {
            var objs = new RoleService.Role().GetAllAvalibleByProductCode(productCode);
            var obj1s = new List<RoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new RoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据角色编号获取角色实体。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>ArrayList</returns>
        public RoleInfo GetByCode(short roleCode)
        {
            var obj = new RoleService.Role().GetByCode(roleCode);
            if (obj != null)
            {
                var obj1 = new RoleInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        #endregion
    }
}
