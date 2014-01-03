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
    /// GroupCat 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class GroupCat : System.Web.Services.WebService//,IGroupCat
    {
        #region Implementation of IGroupCat

        /// <summary>
        /// 添加组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(GroupCatInfo obj)
        {
            return DataProvider.GroupCatProvider.Insert(obj);
        }

        /// <summary>
        /// 修改组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GroupCatInfo obj)
        {
            return DataProvider.GroupCatProvider.Update(obj);
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
        [WebMethod]
        public bool Delete(short id)
        {
            return DataProvider.GroupCatProvider.Delete(id);
        }

        /// <summary>
        /// 是否已经存在组分类名称。
        /// </summary>
        /// <param name="name">组分类名称。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool IsExist(string name)
        {
            return DataProvider.GroupCatProvider.IsExist(name);
        }

        /// <summary>
        /// 获取所有组分类。
        /// </summary>
        /// <returns>组分类列表。</returns>
        [WebMethod]
        public List<GroupCatInfo> GetAll()
        {
            return DataProvider.GroupCatProvider.GetAll() as List<GroupCatInfo>;
        }

        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="id">组编号。</param>
        /// <returns>组分类。</returns>
        [WebMethod]
        public GroupCatInfo GetById(short id)
        {
            return DataProvider.GroupCatProvider.GetById(id);
        }

        #endregion
    }
}
