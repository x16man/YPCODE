using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 方案信息的数据访问接口。
    /// </summary>
    public interface ICategory
    {
        /// <summary>
        /// 获取所有类别信息实体集合。
        /// </summary>
        /// <returns>所有类别信息实体集合。</returns>
        List<CategoryInfo> GetAll();
        /// <summary>
        /// 根据类别Id获取类别信息实体。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>类别信息实体。</returns>
        CategoryInfo GetById(Int32 categoryId);
        /// <summary>
        /// 根据类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>bool</returns>
        Boolean Delete(Int32 categoryId);
        /// <summary>
        /// 添加类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>int</returns>
        int Insert(CategoryInfo entity);
        /// <summary>
        /// 修改类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>bool</returns>
        Boolean Update(CategoryInfo entity);
        /// <summary>
        /// 方案分类移动。
        /// </summary>
        /// <param name="categoryId">CategoryId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        Boolean Move(Int32 categoryId, Byte opType);
    }
}
