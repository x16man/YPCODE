using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class GroupCat:IGroupCat
    {
        #region Implementation of IGroupCat

        /// <summary>
        /// 添加组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupCatInfo obj)
        {
            var groupCatInfo = new GroupCatService.GroupCatInfo();
            CopyHelper.Copy(obj, groupCatInfo);
            return new GroupCatService.GroupCat().Insert(groupCatInfo);
        }

        /// <summary>
        /// 修改组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        public bool Update(GroupCatInfo obj)
        {
            var groupCatInfo = new GroupCatService.GroupCatInfo();
            CopyHelper.Copy(obj, groupCatInfo);
            return new GroupCatService.GroupCat().Update(groupCatInfo);
        }

        /// <summary>
        /// 删除组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupCatInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除组分类。
        /// </summary>
        /// <param name="id">组分类Id。</param>
        /// <returns>bool</returns>
        public bool Delete(short id)
        {
            return new GroupCatService.GroupCat().Delete(id);
        }

        /// <summary>
        /// 是否已经存在组分类名称。
        /// </summary>
        /// <param name="name">组分类名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string name)
        {
            return new GroupCatService.GroupCat().IsExist(name);
        }

        /// <summary>
        /// 获取所有组分类。
        /// </summary>
        /// <returns>组分类列表。</returns>
        public IList<GroupCatInfo> GetAll()
        {
            var objs = new GroupCatService.GroupCat().GetAll();
            var obj1s = new List<GroupCatInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupCatInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="id">组编号。</param>
        /// <returns>组分类。</returns>
        public GroupCatInfo GetById(short id)
        {
            var obj = new GroupCatService.GroupCat().GetById(id);
            if (obj != null)
            {
                var obj1 = new GroupCatInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        #endregion
    }
}
