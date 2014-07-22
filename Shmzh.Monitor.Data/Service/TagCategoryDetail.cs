using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class TagCategoryDetail:IDAL.ITagCategoryDetail
    {
        #region Implementation of ITagCategoryDetail

        /// <summary>
        /// 根据类别获取所包含指标信息实体集合。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns></returns>
        public List<TagCategoryDetailInfo> GetByCategoryId(int categoryId)
        {
            var objs = new TagCategoryDetailService.TagCategoryDetail().GetByCategoryId(categoryId);
            var obj1s = new List<TagCategoryDetailInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagCategoryDetailInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据类别获取所包含指标信息实体集合。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns></returns>
        public List<TagInfo> GetTagsByCategoryId(int categoryId)
        {
            var objs = new TagCategoryDetailService.TagCategoryDetail().GetTagsByCategoryId(categoryId);
            var obj1s = new List<TagInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 添加重设指定类别所包含的指标。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <param name="tagIds">所包含指标的Id数组。</param>
        /// <returns>bool</returns>
        public bool Reset(int categoryId, string[] tagIds)
        {
            return new TagCategoryDetailService.TagCategoryDetail().Reset(categoryId, tagIds);
        }

        #endregion
    }
}
