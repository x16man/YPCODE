using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class Category:IDAL.ICategory
    {
        #region Implementation of ICategory

        /// <summary>
        /// 获取所有类别信息实体集合。
        /// </summary>
        /// <returns>所有类别信息实体集合。</returns>
        public List<CategoryInfo> GetAll()
        {
            var objs = new CategoryService.Category().GetAll();
            var obj1s = new List<CategoryInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new CategoryInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据类别Id获取类别信息实体。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>类别信息实体。</returns>
        public CategoryInfo GetById(int categoryId)
        {
            var obj = new CategoryService.Category().GetById(categoryId);
            CategoryInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new CategoryInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int categoryId)
        {
            return new CategoryService.Category().Delete(categoryId);
        }

        /// <summary>
        /// 添加类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>int</returns>
        public int Insert(CategoryInfo entity)
        {
            var obj = new CategoryService.CategoryInfo();
            CopyHelper.Copy(entity,obj);
            //return new CategoryService.Category().Insert(obj);
            return 0;
        }

        /// <summary>
        /// 修改类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>bool</returns>
        public bool Update(CategoryInfo entity)
        {
            var obj = new CategoryService.CategoryInfo();
            CopyHelper.Copy(entity, obj);
            return new CategoryService.Category().Update(obj);
        }

        /// <summary>
        /// 方案分类移动。
        /// </summary>
        /// <param name="categoryId">CategoryId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int categoryId, byte opType)
        {
            return new CategoryService.Category().Move(categoryId, opType);
        }

        #endregion
    }
}
