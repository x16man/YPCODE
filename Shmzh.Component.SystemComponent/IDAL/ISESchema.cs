using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 查询方案的数据访问接口。
    /// </summary>
    public interface ISESchema
    {
        /// <summary>
        /// 添加查询方案。
        /// </summary>
        /// <param name="obj">查询方案实体。</param>
        /// <returns>bool</returns>
        bool Insert(SESchemaInfo obj);
        /// <summary>
        /// 修改查询方案。
        /// </summary>
        /// <param name="obj">查询方案实体。</param>
        /// <returns>bool</returns>
        bool Update(SESchemaInfo obj);
        /// <summary>
        /// 删除查询方案。
        /// </summary>
        /// <param name="obj">查询方案实体。</param>
        /// <returns>bool</returns>
        bool Delete(SESchemaInfo obj);
        /// <summary>
        /// 删除查询方案。
        /// </summary>
        /// <param name="id">查询方案Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 根据查询模块和用户获取所有查询方案集合。
        /// </summary>
        /// <param name="moduleId">查询模块Id。</param>
        /// <param name="userCode">用户名。</param> 
        /// <returns>查询方案集合。</returns>
        IList<SESchemaInfo> GetByModuleAndUser(string moduleId, string userCode);
        /// <summary>
        /// 根据查询模块和用户获取默认的查询方案。
        /// </summary>
        /// <param name="moduleId">查询模块Id。</param>
        /// <param name="userCode">用户名。</param>
        /// <returns>查询方案Id。</returns>
        SESchemaInfo GetDefaultByModuleAndUser(string moduleId, string userCode);
        /// <summary>
        /// 根据id获取查询方案。
        /// </summary>
        /// <param name="id">查询方案Id</param>
        /// <returns>查询方案实体。</returns>
        SESchemaInfo GetById(int id);
        
        /// <summary>
        /// 判断查询方案名称是否已经存在。
        /// </summary>
        /// <param name="moduleId">查询模块Id。</param>
        /// <param name="userCode">用户名。</param>
        /// <param name="schemaName">查询方案名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string moduleId,string userCode, string schemaName);
    }
}