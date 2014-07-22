using System;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject 
{
    [Serializable]
    public class Group : MarshalByRefObject, IGroup
    {
        private static IGroup dal;
        static Group()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.GroupProvider;
        }

        #region IGroup 成员
        /// <summary>
        /// 添加组。
        /// </summary>
        /// <param name="groupInfo">组信息实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupInfo groupInfo)
        {
            return dal.Insert(groupInfo);
        }

        /// <summary>
        /// 修改组。
        /// </summary>
        /// <param name="groupInfo">组信息实体。</param>
        /// <returns>bool</returns>
        public bool Update(GroupInfo groupInfo)
        {
            return dal.Update(groupInfo);
        }
        
         /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupInfo">组信息实体。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupInfo groupInfo)
        {
            return dal.Delete(groupInfo);
        }
       
        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short groupCode)
        {
            return dal.Delete(groupCode);
        }

        /// <summary>
        /// 判断组名称是否已经存在。
        /// </summary>
        /// <param name="groupName">组名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string groupName)
        {
            return dal.IsExist(groupName);
        }
       
        /// <summary>
        /// 获取所有组记录。
        /// </summary>
        /// <returns>组记录集合。</returns>
        public IList<GroupInfo> GetAll()
        {
            return dal.GetAll();
        }
       
        /// <summary>
        /// 根据组编好获取组信息实体。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组信息实体。</returns>
        public GroupInfo GetByCode(short groupCode)
        {
            return dal.GetByCode(groupCode);
        }

       #endregion
    }
}
