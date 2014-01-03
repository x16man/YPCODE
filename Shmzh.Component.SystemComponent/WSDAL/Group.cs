using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class Group:IGroup
    {
        #region Implementation of IGroup

        /// <summary>
        /// 添加组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupInfo groupInfo)
        {
            var obj = new GroupService.GroupInfo();
            CopyHelper.Copy(groupInfo,obj);
            return new GroupService.Group().Insert(obj);
        }

        /// <summary>
        /// 修改组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        public bool Update(GroupInfo groupInfo)
        {
            var obj = new GroupService.GroupInfo();
            CopyHelper.Copy(groupInfo, obj);
            return new GroupService.Group().Update(obj);
        }

        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupInfo groupInfo)
        {
            return this.Delete(groupInfo.GroupCode);
        }

        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short groupCode)
        {
            return new GroupService.Group().Delete(groupCode);
        }

        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="groupName">组名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string groupName)
        {
            return new GroupService.Group().IsExist(groupName);
        }

        /// <summary>
        /// 获取所有组。
        /// </summary>
        /// <returns>ArrayList。</returns>
        public IList<GroupInfo> GetAll()
        {
            var objs = new GroupService.Group().GetAll();
            var obj1s = new List<GroupInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>ArrayList</returns>
        public GroupInfo GetByCode(short groupCode)
        {
            var obj = new GroupService.Group().GetByCode(groupCode);
            if (obj != null)
            {
                var obj1 = new GroupInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        #endregion
    }
}
