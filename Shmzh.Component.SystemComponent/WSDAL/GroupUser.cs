using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class GroupUser:IGroupUser
    {
        #region Implementation of IGroupUser

        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupUserInfo groupUserInfo)
        {
            var obj = new GroupUserService.GroupUserInfo();
            CopyHelper.Copy(groupUserInfo, obj);
            return new GroupUserService.GroupUser().Insert(obj);
        }

        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="obj">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupUserInfo obj, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量添加组用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <returns>bool</returns>
        public bool Insert(short groupCode, string userNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupUserInfo groupUserInfo)
        {
            var obj = new GroupUserService.GroupUserInfo();
            CopyHelper.Copy(groupUserInfo, obj);
            return new GroupUserService.GroupUser().Delete(obj);
        }

        /// <summary>
        /// 删除组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupUserInfo groupUserInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>bool</returns>
        public bool Delete(string userCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(string userCode, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有的组用户集合.
        /// </summary>
        /// <returns>组用户集合.</returns>
        public IList<GroupUserInfo> GetAll()
        {
            var objs = new GroupUserService.GroupUser().GetAll();
            var obj1s = new List<GroupUserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupUserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据组编号来获取组用户集合。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组用户集合。</returns>
        public IList<GroupUserInfo> GetByGroupCode(short groupCode)
        {
            var objs = new GroupUserService.GroupUser().GetByGroupCode(groupCode);
            var obj1s = new List<GroupUserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupUserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据用户名获取组用户集合。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>组用户集合。</returns>
        public IList<GroupUserInfo> GetByUserCode(string userCode)
        {
            var objs = new GroupUserService.GroupUser().GetByUserCode(userCode );
            var obj1s = new List<GroupUserInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GroupUserInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
