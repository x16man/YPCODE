using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 指标类别信息的数据访问接口。
    /// </summary>
    public interface ITagCategory
    {
        /// <summary>
        /// 获取所有指标类别信息实体集合。
        /// </summary>
        /// <returns>所有指标类别信息实体集合。</returns>
        List<TagCategoryInfo> GetAll();
        /// <summary>
        /// 根据父类别获取指标类别信息实体集合。
        /// </summary>
        /// <param name="parentId">父类别Id。</param>
        /// <returns></returns>
        List<TagCategoryInfo> GetByParentId(int parentId);
        /// <summary>
        /// 根据指标类别Id获取指标类别信息实体。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns>指标类别信息实体。</returns>
        TagCategoryInfo GetById(Int32 categoryId);
        /// <summary>
        /// 根据指标类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns>bool</returns>
        Boolean Delete(Int32 categoryId);
        /// <summary>
        /// 添加指标类别信息实体。
        /// </summary>
        /// <param name="entity">指标类别信息实体对象。</param>
        /// <returns>bool</returns>
        int Insert(TagCategoryInfo entity);
        /// <summary>
        /// 修改指标类别信息实体。
        /// </summary>
        /// <param name="entity">指标类别信息实体对象。</param>
        /// <returns>bool</returns>
        Boolean Update(TagCategoryInfo entity);
        /// <summary>
        /// 上移或下移。
        /// </summary>
        /// <param name="categoryId">要移动的指标类别Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        bool MoveUpDown(Int32 categoryId, byte opType);

        /// <summary>
        /// 移动某指标类别到另一个类别下。
        /// </summary>
        /// <param name="moveCategoryId">要移动的指标类别Id。</param>
        /// <param name="targetCategoryId">作为父类别的类别Id。</param>
        /// <returns></returns>
        bool Move(int moveCategoryId, int targetCategoryId);
    }
}
