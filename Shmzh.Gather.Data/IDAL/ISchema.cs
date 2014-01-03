using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    public interface ISchema
    {
        /// <summary>
        /// 添加报表模板。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        bool Insert(SchemaInfo obj);

        /// <summary>
        /// 更改报表模板。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        bool Update(SchemaInfo obj);

        /// <summary>
        /// 根据Id删除报表模板记录。
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <returns>bool</returns>
        bool Delete(string id);

        /// <summary>
        /// 删除报表模板实体。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        bool Delete(SchemaInfo obj);
        
        /// <summary>
        /// 获取所有的报表模板。
        /// </summary>
        /// <returns>报表模板集合</returns>
        IList<SchemaInfo> GetAll();

        /// <summary>
        /// 根据Id获取报表模板对象。
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <returns>报表模板实体</returns>
        SchemaInfo GetById(string id);

    }
}
