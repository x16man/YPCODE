using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class RelationProvider:IRelation
    {
        #region Implementation of IRelation

        /// <summary>
        /// 添加报表模板与分类关系。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        public abstract int Insert(RelationInfo obj);

        /// <summary>
        /// 更改报表模板与分类关系。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        public abstract bool Update(RelationInfo obj);

        /// <summary>
        /// 根据Id删除报表模板与分类关系记录。
        /// </summary>
        /// <param name="id">报表模板与分类关系Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// 删除报表模板与分类关系实体。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(RelationInfo obj);

        /// <summary>
        /// 获取所有的报表模板与分类关系集合。
        /// </summary>
        /// <returns>报表模板与分类关系集合</returns>
        public abstract IList<RelationInfo> GetAll();

        /// <summary>
        /// 根据分类Id获取报表模板与分类关系集合。
        /// </summary>
        /// <param name="categoryId">分类Id。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        public abstract IList<RelationInfo> GetByCategoryId(int categoryId);

        /// <summary>
        /// 根据报表Id获取报表模板与分类关系的集合。
        /// </summary>
        /// <param name="schemaId">报表模板Id。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        public abstract IList<RelationInfo> GetBySchemaId(string schemaId);

        /// <summary>
        /// 根据Id获取报表模板与分类关系。
        /// </summary>
        /// <param name="id">报表模板与分类关系Id。</param>
        /// <returns>报表模板与分类关系实体。</returns>
        public abstract RelationInfo GetById(int id);

        #endregion
    }
}
