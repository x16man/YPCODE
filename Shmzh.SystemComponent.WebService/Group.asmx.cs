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
    /// Group 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Group : System.Web.Services.WebService
    {
        #region Implementation of IGroup

        /// <summary>
        /// 添加组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(GroupInfo groupInfo)
        {
            return DataProvider.GroupProvider.Insert(groupInfo);
        }

        /// <summary>
        /// 修改组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GroupInfo groupInfo)
        {
            return DataProvider.GroupProvider.Update(groupInfo);
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
        [WebMethod]
        public bool Delete(short groupCode)
        {
            return DataProvider.GroupProvider.Delete(groupCode);
        }

        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="groupName">组名称。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool IsExist(string groupName)
        {
            return DataProvider.GroupProvider.IsExist(groupName);
        }

        /// <summary>
        /// 获取所有组。
        /// </summary>
        /// <returns>ArrayList。</returns>
        [WebMethod]
        public List<GroupInfo> GetAll()
        {
            return DataProvider.GroupProvider.GetAll() as List<GroupInfo>;
        }

        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>ArrayList</returns>
        [WebMethod]
        public GroupInfo GetByCode(short groupCode)
        {
            return DataProvider.GroupProvider.GetByCode(groupCode);
        }

        #endregion
    }
}
