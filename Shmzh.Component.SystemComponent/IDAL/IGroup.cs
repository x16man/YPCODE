using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组的数据访问接口。
    /// </summary>
    public interface IGroup
    {
        /// <summary>
        /// 添加组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        bool Insert(GroupInfo groupInfo);
        /// <summary>
        /// 修改组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        bool Update(GroupInfo groupInfo);
        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupInfo">组实体。</param>
        /// <returns>bool</returns>
        bool Delete(GroupInfo groupInfo);
        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>bool</returns>
        bool Delete(short groupCode);
        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="groupName">组名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string groupName);
        /// <summary>
        /// 获取所有组。
        /// </summary>
        /// <returns>ArrayList。</returns>
        IList<GroupInfo> GetAll();
        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>ArrayList</returns>
        GroupInfo GetByCode(short groupCode);

    }
}
