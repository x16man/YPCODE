using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    /// <summary>
    /// 报表模板与分类关系的数据接口。
    /// </summary>
    public interface IRelation
    {
        /// <summary>
        /// 添加报表模板与分类关系。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        int Insert(RelationInfo obj);

        /// <summary>
        /// 更改报表模板与分类关系。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        bool Update(RelationInfo obj);

        /// <summary>
        /// 根据Id删除报表模板与分类关系记录。
        /// </summary>
        /// <param name="id">报表模板与分类关系Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// 删除报表模板与分类关系实体。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        bool Delete(RelationInfo obj);
        
        /// <summary>
        /// 获取所有的报表模板与分类关系集合。
        /// </summary>
        /// <returns>报表模板与分类关系集合</returns>
        IList<RelationInfo> GetAll();

        /// <summary>
        /// 根据分类Id获取报表模板与分类关系集合。
        /// </summary>
        /// <param name="categoryId">分类Id。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        IList<RelationInfo> GetByCategoryId(int categoryId);

        /// <summary>
        /// 根据报表分类名称来获取报表模板与分类关系集合。
        /// </summary>
        /// <param name="categoryName">分类名称。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        /// <remarks>由于分类名称不是唯一的，所以会取第一个符合的分类记录来进行检索。</remarks>
        //IList<RelationInfo> GetByCategoryName(string categoryName);

        /// <summary>
        /// 根据报表Id获取报表模板与分类关系的集合。
        /// </summary>
        /// <param name="schemaId">报表模板Id。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        IList<RelationInfo> GetBySchemaId(string schemaId);
        
        /// <summary>
        /// 根据Id获取报表模板与分类关系。
        /// </summary>
        /// <param name="id">报表模板与分类关系Id。</param>
        /// <returns>报表模板与分类关系实体。</returns>
        RelationInfo GetById(int id);


    }
}
