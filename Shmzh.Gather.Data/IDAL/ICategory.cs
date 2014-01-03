using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    public interface ICategory
    {
        /// <summary>
        /// 添加报表分类。
        /// </summary>
        /// <param name="obj">报表分类实体。</param>
        /// <returns>bool</returns>
        int Insert(CategoryInfo obj);

        /// <summary>
        /// 更改报表分类。
        /// </summary>
        /// <param name="obj">报表分类实体。</param>
        /// <returns>bool</returns>
        bool Update(CategoryInfo obj);

        /// <summary>
        /// 根据Id删除报表分类记录。
        /// </summary>
        /// <param name="id">报表分类Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// 删除报表实体。
        /// </summary>
        /// <param name="obj">报表实体。</param>
        /// <returns>bool</returns>
        bool Delete(CategoryInfo obj);
        
        /// <summary>
        /// 获取所有的报表分类。
        /// </summary>
        /// <returns>报表分类集合</returns>
        IList<CategoryInfo> GetAll();

        /// <summary>
        /// 根据父Id获取报表分类集合.
        /// </summary>
        /// <param name="parentId">父Id.</param>
        /// <returns>报表分类集合.</returns>
        IList<CategoryInfo> GetByParentId(int parentId);

        /// <summary>
        /// 根据父Id获取所有下辖的报表分类集合(向下递归).
        /// </summary>
        /// <param name="parentId">父Id.</param>
        /// <returns>报表分类集合.</returns>
        IList<CategoryInfo> RecursiveGetByParentId(int parentId);

        /// <summary>
        /// 根据Id获取报表分类。
        /// </summary>
        /// <param name="id">报表分类Id。</param>
        /// <returns>报表分类</returns>
        CategoryInfo GetById(int id);

        /// <summary>
        /// 根据分类名称获取报表分类。
        /// </summary>
        /// <param name="name">分类名称。</param>
        /// <returns>报表分类</returns>
        /// <remarks>由于分类名称不是唯一的，所以会取第一个符合的分类记录来进行检索。</remarks>
        CategoryInfo GetByName(string name);
    }
}
