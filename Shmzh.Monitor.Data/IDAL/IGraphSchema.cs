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
    public interface IGraphSchema
    {
        /// <summary>
        /// 根据方案Id获取方案信息。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <returns>方案信息实体。</returns>
        GraphSchemaInfo GetById(Int32 schemaId);
        /// <summary>
        /// 根据方案名称获取方案信息。
        /// </summary>
        /// <param name="name">方案名称。</param>
        /// <returns>方案信息实体。</returns>
        GraphSchemaInfo GetByName(String name);
        /// <summary>
        /// 获取所有的曲线方案。
        /// </summary>
        /// <returns>曲线方案集合。</returns>
        List<GraphSchemaInfo> GetAll();
        /// <summary>
        /// 根据方案Id获取所属的全部方案。
        /// </summary>
        /// <param name="categoryId">方案类别Id。</param>
        /// <returns></returns>
        List<GraphSchemaInfo> GetByCategoryId(int categoryId);
        /// <summary>
        /// 获取未分类的方案。当loginName 为 null 或 "" 时取全部未分类的方案。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns></returns>
        List<GraphSchemaInfo> GetNoCategorySchema(String loginName);
        /// <summary>
        /// 根据曲线方案Id来删除曲线方案。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>bool</returns>
        bool Delete(Int32 schemaId);
        /// <summary>
        /// 删除曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        bool Delete(GraphSchemaInfo graphSchemaInfo);
        /// <summary>
        /// 添加曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        int Insert(GraphSchemaInfo graphSchemaInfo);
        /// <summary>
        /// 修改曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>int</returns>
        bool Update(GraphSchemaInfo graphSchemaInfo);

        /// <summary>
        /// 更新创建或修改人。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <param name="referLoginName">登录名。</param>
        /// <returns></returns>
        bool UpdateLoginName(int schemaId, String referLoginName);

        /// <summary>
        /// 添加曲线方案对象.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="graphSchemaInfo">曲线方案对象.</param>
        /// <returns>int</returns>
        int InsertWithTrans(SqlTransaction trans, GraphSchemaInfo graphSchemaInfo);

        /// <summary>
        /// 深层次保存曲线方案对象.
        /// </summary>
        /// <param name="obj">曲线方案对象.</param>
        /// <returns>bool</returns>
        bool DeepSave(GraphSchemaInfo obj);
    }
}
