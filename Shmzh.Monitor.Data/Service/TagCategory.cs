using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class TagCategory:IDAL.ITagCategory
    {
        #region Implementation of ITagCategory

        /// <summary>
        /// 获取所有指标类别信息实体集合。
        /// </summary>
        /// <returns>所有指标类别信息实体集合。</returns>
        public List<TagCategoryInfo> GetAll()
        {
            var objs = new TagCategoryService.TagCategory().GetAll();
            var obj1s = new List<TagCategoryInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagCategoryInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据父类别获取指标类别信息实体集合。
        /// </summary>
        /// <param name="parentId">父类别Id。</param>
        /// <returns></returns>
        public List<TagCategoryInfo> GetByParentId(int parentId)
        {
            var objs = new TagCategoryService.TagCategory().GetByParentId(parentId);
            var obj1s = new List<TagCategoryInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagCategoryInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指标类别Id获取指标类别信息实体。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns>指标类别信息实体。</returns>
        public TagCategoryInfo GetById(int categoryId)
        {
            var obj = new TagCategoryService.TagCategory().GetById(categoryId);
            TagCategoryInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new TagCategoryInfo();
                CopyHelper.Copy(obj,obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据指标类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int categoryId)
        {
            return new TagCategoryService.TagCategory().Delete(categoryId);

        }

        /// <summary>
        /// 添加指标类别信息实体。
        /// </summary>
        /// <param name="entity">指标类别信息实体对象。</param>
        /// <returns>bool</returns>
        public int Insert(TagCategoryInfo entity)
        {
            var obj = new TagCategoryService.TagCategoryInfo();
            CopyHelper.Copy(entity,obj);
            //return new TagCategoryService.TagCategory().Insert(obj);
            return 0;
        }

        /// <summary>
        /// 修改指标类别信息实体。
        /// </summary>
        /// <param name="entity">指标类别信息实体对象。</param>
        /// <returns>bool</returns>
        public bool Update(TagCategoryInfo entity)
        {
            var obj = new TagCategoryService.TagCategoryInfo();
            CopyHelper.Copy(entity, obj);
            return new TagCategoryService.TagCategory().Update(obj);
        }

        /// <summary>
        /// 上移或下移。
        /// </summary>
        /// <param name="categoryId">要移动的指标类别Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool MoveUpDown(int categoryId, byte opType)
        {
            return new TagCategoryService.TagCategory().MoveUpDown(categoryId, opType);
        }

        /// <summary>
        /// 移动某指标类别到另一个类别下。
        /// </summary>
        /// <param name="moveCategoryId">要移动的指标类别Id。</param>
        /// <param name="targetCategoryId">作为父类别的类别Id。</param>
        /// <returns></returns>
        public bool Move(int moveCategoryId, int targetCategoryId)
        {
            return new TagCategoryService.TagCategory().Move(moveCategoryId, targetCategoryId);
        }

        #endregion
    }
}
