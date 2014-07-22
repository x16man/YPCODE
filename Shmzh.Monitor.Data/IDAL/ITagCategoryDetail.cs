using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 指标类别信息的数据访问接口。
    /// </summary>
    public interface ITagCategoryDetail
    {
        /// <summary>
        /// 根据类别获取所包含指标信息实体集合。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns></returns>
        List<TagCategoryDetailInfo> GetByCategoryId(int categoryId);

        /// <summary>
        /// 根据类别获取所包含指标信息实体集合。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns></returns>
        List<TagInfo> GetTagsByCategoryId(int categoryId);
        
        /// <summary>
        /// 添加重设指定类别所包含的指标。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <param name="tagIds">所包含指标的Id数组。</param>
        /// <returns>bool</returns>
        Boolean Reset(int categoryId, String[] tagIds);
    }
}
