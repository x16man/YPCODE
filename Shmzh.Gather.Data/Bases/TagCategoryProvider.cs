using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    /// <summary>
    /// 指标分类的抽象数据访问类。
    /// </summary>
    public abstract class TagCategoryProvider:IDAL.ITagCategory
    {
        #region Implementation of ITagCategory

        /// <summary>
        /// 添加指标分类。
        /// </summary>
        /// <param name="obj">指标分类实体。</param>
        /// <returns>指标分类Id。</returns>
        public abstract int Insert(TagCategoryInfo obj);

        /// <summary>
        /// 更改指标分类。
        /// </summary>
        /// <param name="obj">指标分类实体。</param>
        /// <returns>bool</returns>
        public abstract bool Update(TagCategoryInfo obj);

        /// <summary>
        /// 删除指标分类。
        /// </summary>
        /// <param name="obj">指标分类实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(TagCategoryInfo obj);

        /// <summary>
        /// 删除指标分类。
        /// </summary>
        /// <param name="id">指标分类Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// 获取所有的指标分类。
        /// </summary>
        /// <returns>指标分类的集合。</returns>
        public abstract List<TagCategoryInfo> GetAll();

        /// <summary>
        /// 根据上级分类Id获取指标分类。
        /// </summary>
        /// <param name="parentId">上级分类Id。</param>
        /// <returns>指标分类的集合。</returns>
        public abstract List<TagCategoryInfo> GetByParentId(int parentId);

        /// <summary>
        /// 根据指标分类Id获取指标分类。
        /// </summary>
        /// <param name="id">指标分类Id。</param>
        /// <returns>指标分类实体。</returns>
        public abstract TagCategoryInfo GetById(int id);

        #endregion
    }
}