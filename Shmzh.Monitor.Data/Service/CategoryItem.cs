using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class CategoryItem:IDAL.ICategoryItem
    {
        #region Implementation of ICategoryItem

        /// <summary>
        /// 获取所有分类监控方案.
        /// </summary>
        /// <returns>所有分类监控方案.</returns>
        public List<CategoryItemInfo> GetAll()
        {
            var objs = new CategoryItemService.CategoryItem().GetAll();
            var obj1s = new List<CategoryItemInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new CategoryItemInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 获取由XML文件配置的方案列表。
        /// </summary>
        /// <returns></returns>
        public List<CategoryItemInfo> GetXmlItemInfo()
        {
            var objs = new CategoryItemService.CategoryItem().GetXmlItemInfo();
            var obj1s = new List<CategoryItemInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new CategoryItemInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有类别条目信息实体集合。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>所有类别条目信息实体集合。</returns>
        public List<CategoryItemInfo> GetByCategoryId(int categoryId)
        {
            var objs = new CategoryItemService.CategoryItem().GetByCategoryId(categoryId);
            var obj1s = new List<CategoryItemInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new CategoryItemInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 一个方案可能分到多个分类。
        /// </summary>
        /// <param name="configFile">配置文件名或曲线方案名。</param>
        /// <returns></returns>
        public List<CategoryItemInfo> GetByConfigFile(string configFile)
        {
            var objs = new CategoryItemService.CategoryItem().GetByConfigFile(configFile);
            var obj1s = new List<CategoryItemInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new CategoryItemInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据类别条目Id获取类别信息实体。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>类别条目信息实体。</returns>
        public CategoryItemInfo GetById(int itemId)
        {
            var obj = new CategoryItemService.CategoryItem().GetById(itemId);
            CategoryItemInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new CategoryItemInfo();
                CopyHelper.Copy(obj,obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据类别条目编号获取类别信息实体。
        /// </summary>
        /// <param name="code">类别条目编号。</param>
        /// <returns>类别条目信息实体。</returns>
        public CategoryItemInfo GetByCode(string code)
        {
            var obj = new CategoryItemService.CategoryItem().GetByCode(code);
            CategoryItemInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new CategoryItemInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据类别条目Id进行删除。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int itemId)
        {
            return new CategoryItemService.CategoryItem().Delete(itemId);
        }

        /// <summary>
        /// 添加类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        public int Insert(CategoryItemInfo entity)
        {
            var obj = new CategoryItemService.CategoryItemInfo();
            CopyHelper.Copy(entity, obj);
            return new CategoryItemService.CategoryItem().Insert(obj);
        }

        /// <summary>
        /// 修改类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        public bool Update(CategoryItemInfo entity)
        {
            return this.Update(null, entity);
        }

        public bool Update(SqlTransaction trans, CategoryItemInfo entity)
        {
            var obj = new CategoryItemService.CategoryItemInfo();
            CopyHelper.Copy(entity, obj);
            return new CategoryItemService.CategoryItem().Update(obj);
        }

        /// <summary>
        /// 方案分类条目移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int itemId, byte opType)
        {
            return new CategoryItemService.CategoryItem().Move(itemId, opType);
        }

        #endregion
    }
}
