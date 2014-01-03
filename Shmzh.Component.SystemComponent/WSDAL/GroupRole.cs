using System.Collections.Generic;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class GroupRole:IGroupRole
    {
        #region Field
        
        #endregion
        #region Implementation of IGroupRole

        /// <summary>
        /// 添加组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupRoleInfo groupRoleInfo)
        {
            var obj = new GroupRoleService.GroupRoleInfo();
            CopyHelper.Copy(groupRoleInfo,obj);
            
            
            return new GroupRoleService.GroupRole().Insert(obj);
        }

        /// <summary>
        /// 批量添加组角色。
        /// </summary>
        /// <param name="groupCodes">组编号串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        /// <remarks>首先删除</remarks>
        public bool Insert(string groupCodes, string roleCodes, short productCode)
        {
            return new GroupRoleService.GroupRole().Insert1(groupCodes, roleCodes, productCode);
        }

        /// <summary>
        /// 针对知识库条目批量添加组角色。
        /// </summary>
        /// <param name="groupCodes">组编号串。</param>
        /// <param name="roleCodes">角色编号串。</param>
        /// <param name="checkCode">知识库条目id。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        public bool Insert(string groupCodes, string roleCodes, string checkCode, string type)
        {
            return new GroupRoleService.GroupRole().Insert2(groupCodes, roleCodes, checkCode, type);
        }

        /// <summary>
        /// 删除组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupRoleInfo groupRoleInfo)
        {
            var obj = new GroupRoleService.GroupRoleInfo();
            CopyHelper.Copy(groupRoleInfo,obj);
            return new GroupRoleService.GroupRole().Delete(obj);
        }

        /// <summary>
        /// 删除某些组的某一产品的组角色关系。
        /// </summary>
        /// <param name="groupCodes">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string groupCodes, short productCode)
        {
            return new GroupRoleService.GroupRole().Delete1(groupCodes, productCode);
        }

        /// <summary>
        /// 针对知识库条目删除组的角色。
        /// </summary>
        /// <param name="groupCodes"></param>
        /// <param name="checkCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Delete(string groupCodes, string checkCode, string type)
        {
            return new GroupRoleService.GroupRole().Delete2(groupCodes, checkCode, type);
        }

        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        /// <param name="checkCode">知识库条目id。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>bool</returns>
        public bool ClearAccess(string checkCode, string type)
        {
            return new GroupRoleService.GroupRole().ClearAccess(checkCode, type);
        }

        /// <summary>
        /// 复制组角色到目标组
        /// </summary>
        /// <param name="sourceGroupCode">源组名称。</param>
        /// <param name="targetGroupCode">目标组名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns></returns>
        public bool CopyTo(string sourceGroupCode, string targetGroupCode, short productCode)
        {
            return new GroupRoleService.GroupRole().CopyTo(sourceGroupCode, targetGroupCode, productCode);
        }

        /// <summary>
        /// 根据组编号和产品编号获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByGroupCodeAndProductCode(short groupCode, short productCode)
        {
            var objs = new GroupRoleService.GroupRole().GetByGroupCodeAndProductCode(groupCode,productCode);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据组编号和知识库条目编号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">知识库条目编号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色编号。</returns>
        public IList<GroupRoleInfo> GetByGroupCodeAndCheckCodeAndType(short groupCode, string checkCode, string type)
        {
            var objs = new GroupRoleService.GroupRole().GetByGroupCodeAndCheckCodeAndType(groupCode,checkCode,type);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据知识库条目编号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="checkCode">知识库条目编号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByCheckCodeAndType(string checkCode, string type)
        {
            var objs = new GroupRoleService.GroupRole().GetByCheckCodeAndType( checkCode, type);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号获取组角色编号。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCode(short productCode)
        {
            var objs = new GroupRoleService.GroupRole().GetByProductCode(productCode);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和角色编号获取组角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByRoleCode(short roleCode)
        {
            var objs = new GroupRoleService.GroupRole().GetByRoleCode(roleCode);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和用户名、姓名来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">组名。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCodeAndName(short productCode, string name)
        {
            var objs = new GroupRoleService.GroupRole().GetByProductCodeAndName(productCode,name);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和组编号来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCodeAndGroupCode(short productCode, short groupCode)
        {
            var objs = new GroupRoleService.GroupRole().GetByProductCodeAndGroupCode(productCode, groupCode);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据产品编号和组编号和检查对象来获取组角色集合
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCodeAndGroupCodeAndCheckCodeAndType(short productCode, short groupCode, string checkCode, string type)
        {
            var objs = new GroupRoleService.GroupRole().GetByProductCodeAndGroupCodeAndCheckCodeAndType(productCode, groupCode,checkCode,type);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据用户组和访问对象类型获取组角色列表。
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <param name="type">访问对象类型</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByGroupCodeAndType(short groupCode, string type)
        {
            var objs = new GroupRoleService.GroupRole().GetByGroupCodeAndType( groupCode, type);
            var obj1s = new List<GroupRoleInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupRoleInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion


    }
}
