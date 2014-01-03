using System.Collections.Generic;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class SchemaProvider:ISchema
    {
        #region Implementation of ISchema

        /// <summary>
        /// 添加报表模板。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        public abstract bool Insert(SchemaInfo obj);

        /// <summary>
        /// 更改报表模板。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        public abstract bool Update(SchemaInfo obj);

        /// <summary>
        /// 根据Id删除报表模板记录。
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(string id);

        /// <summary>
        /// 删除报表模板实体。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(SchemaInfo obj);

        /// <summary>
        /// 获取所有的报表模板。
        /// </summary>
        /// <returns>报表模板集合</returns>
        public abstract IList<SchemaInfo> GetAll();

        /// <summary>
        /// 根据Id获取报表模板。
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <returns>报表模板实体</returns>
        public abstract SchemaInfo GetById(string id);

        #endregion
    }
}
