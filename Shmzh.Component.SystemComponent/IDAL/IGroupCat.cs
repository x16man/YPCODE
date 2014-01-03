using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组分类的数据访问接口。
    /// </summary>
    public interface IGroupCat
    {
        /// <summary>
        /// 添加组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        bool Insert(GroupCatInfo obj);
        /// <summary>
        /// 修改组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        bool Update(GroupCatInfo obj);
        /// <summary>
        /// 删除组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        bool Delete(GroupCatInfo obj);
        /// <summary>
        /// 删除组分类。
        /// </summary>
        /// <param name="id">组分类Id。</param>
        /// <returns>bool</returns>
        bool Delete(short id);
        /// <summary>
        /// 是否已经存在组分类名称。
        /// </summary>
        /// <param name="name">组分类名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string name);
        /// <summary>
        /// 获取所有组分类。
        /// </summary>
        /// <returns>组分类列表。</returns>
        IList<GroupCatInfo> GetAll();
        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="id">组编号。</param>
        /// <returns>组分类。</returns>
        GroupCatInfo GetById(short id);
        

    }
}
