using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 方案信息的数据访问接口。
    /// </summary>
    public interface ICategoryItem
    {
        /// <summary>
        /// 获取所有分类监控方案.
        /// </summary>
        /// <returns>所有分类监控方案.</returns>
        List<CategoryItemInfo> GetAll();
        /// <summary>
        /// 获取由XML文件配置的方案列表。
        /// </summary>
        /// <returns></returns>
        List<CategoryItemInfo> GetXmlItemInfo();
        /// <summary>
        /// 获取所有类别条目信息实体集合。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>所有类别条目信息实体集合。</returns>
        List<CategoryItemInfo> GetByCategoryId(int categoryId);
        /// <summary>
        /// 一个方案可能分到多个分类。
        /// </summary>
        /// <param name="configFile">配置文件名或曲线方案名。</param>
        /// <returns></returns>
        List<CategoryItemInfo> GetByConfigFile(String configFile);
        /// <summary>
        /// 根据类别条目Id获取类别信息实体。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>类别条目信息实体。</returns>
        CategoryItemInfo GetById(Int32 itemId);
        /// <summary>
        /// 根据类别条目编号获取类别信息实体。
        /// </summary>
        /// <param name="code">类别条目编号。</param>
        /// <returns>类别条目信息实体。</returns>
        CategoryItemInfo GetByCode(String code);
        /// <summary>
        /// 根据类别条目Id进行删除。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>bool</returns>
        Boolean Delete(Int32 itemId);
        /// <summary>
        /// 添加类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        int Insert(CategoryItemInfo entity);
        /// <summary>
        /// 修改类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        Boolean Update(CategoryItemInfo entity);
        /// <summary>
        /// 修改类别条目信息实体
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="entity">类别条目信息实体对象</param>
        /// <returns>bool</returns>
        Boolean Update(SqlTransaction trans, CategoryItemInfo entity);
        /// <summary>
        /// 方案分类条目移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        Boolean Move(Int32 itemId, Byte opType);
    }
}
