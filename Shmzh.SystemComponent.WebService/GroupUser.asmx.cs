using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// 组用户的WebSerivce接口。
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class GroupUser : System.Web.Services.WebService//,IGroupUser 
    {
        #region Implementation of IGroupUser

        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        [WebMethod(Description ="增加组用户")]
        public bool Insert(GroupUserInfo groupUserInfo)
        {
            return DataProvider.GroupUserProvider.Insert(groupUserInfo);
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
        [WebMethod(Description ="删除组用户")]
        public bool Delete(GroupUserInfo groupUserInfo)
        {
            return DataProvider.GroupUserProvider.Delete(groupUserInfo);
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
        [WebMethod (Description ="获取所有组用户")]
        public List<GroupUserInfo> GetAll()
        {
            return DataProvider.GroupUserProvider.GetAll() as List<GroupUserInfo>;
        }

        /// <summary>
        /// 根据组编号来获取组用户集合。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组用户集合。</returns>
        [WebMethod (Description ="根据组编号获取组用户集合")]
        public List<GroupUserInfo> GetByGroupCode(short groupCode)
        {
            return DataProvider.GroupUserProvider.GetByGroupCode(groupCode) as List<GroupUserInfo>;
        }

        /// <summary>
        /// 根据用户名获取组用户集合。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>组用户集合。</returns>
        [WebMethod (Description ="根据用户名获取组用户集合")]
        public List<GroupUserInfo> GetByUserCode(string userCode)
        {
            return DataProvider.GroupUserProvider.GetByUserCode(userCode) as List<GroupUserInfo>;
        }

        #endregion
    }
}
