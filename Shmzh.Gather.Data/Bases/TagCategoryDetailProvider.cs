using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class TagCategoryDetailProvider:IDAL.ITagCategoryDetail
    {
        #region Implementation of ITagCategoryDetail

        /// <summary>
        /// 添加指标与指标分类关系。
        /// </summary>
        /// <param name="obj">指标与指标分类关系实体。</param>
        /// <returns>bool</returns>
        public abstract bool Insert(TagCategoryDetailInfo obj);

        /// <summary>
        /// 删除指标与指标分类关系实体。
        /// </summary>
        /// <param name="obj">指标与指标分类关系实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(TagCategoryDetailInfo obj);

        /// <summary>
        /// 获取所有指标与指标分类关系体集合。
        /// </summary>
        /// <returns>指标与指标分类关系体集合。</returns>
        public abstract List<TagCategoryDetailInfo> GetAll();

        /// <summary>
        /// 根据指标分类Id获取指标与指标分类关系体集合。
        /// </summary>
        /// <param name="categoryId">指标分类Id。</param>
        /// <returns>指标与指标分类关系体集合。</returns>
        public abstract List<TagCategoryDetailInfo> GetByCategoryId(int categoryId);

        #endregion
    }
}
