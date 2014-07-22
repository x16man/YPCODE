using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// GraphSchema 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GraphSchema : System.Web.Services.WebService, IGraphSchema
    {
        #region Implementation of IGraphSchema

        /// <summary>
        /// 根据方案Id获取方案信息。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <returns>方案信息实体。</returns>
        [WebMethod]
        public GraphSchemaInfo GetById(int schemaId)
        {
            return DataProvider.GraphSchemaProvider.GetById(schemaId);
        }

        /// <summary>
        /// 根据方案名称获取方案信息。
        /// </summary>
        /// <param name="name">方案名称。</param>
        /// <returns>方案信息实体。</returns>
        [WebMethod]
        public GraphSchemaInfo GetByName(string name)
        {
            return DataProvider.GraphSchemaProvider.GetByName(name);
        }

        /// <summary>
        /// 获取所有的曲线方案。
        /// </summary>
        /// <returns>曲线方案集合。</returns>
        [WebMethod]
        public List<GraphSchemaInfo> GetAll()
        {
            return DataProvider.GraphSchemaProvider.GetAll();
        }

        /// <summary>
        /// 根据方案Id获取所属的全部方案。
        /// </summary>
        /// <param name="categoryId">方案类别Id。</param>
        /// <returns></returns>
        [WebMethod]
        public List<GraphSchemaInfo> GetByCategoryId(int categoryId)
        {
            return DataProvider.GraphSchemaProvider.GetByCategoryId(categoryId);
        }

        /// <summary>
        /// 获取未分类的方案。当loginName 为 null 或 "" 时取全部未分类的方案。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns></returns>
        [WebMethod]
        public List<GraphSchemaInfo> GetNoCategorySchema(String loginName)
        {
            return DataProvider.GraphSchemaProvider.GetNoCategorySchema(loginName);
        }

        /// <summary>
        /// 根据曲线方案Id来删除曲线方案。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int schemaId)
        {
            return DataProvider.GraphSchemaProvider.Delete(schemaId);
        }

        /// <summary>
        /// 删除曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaInfo graphSchemaInfo)
        {
            return DataProvider.GraphSchemaProvider.Delete(graphSchemaInfo);
        }

        /// <summary>
        /// 添加曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public int Insert(GraphSchemaInfo graphSchemaInfo)
        {
            return DataProvider.GraphSchemaProvider.Insert(graphSchemaInfo);
        }

        public int InsertWithTrans(SqlTransaction trans, GraphSchemaInfo graphSchemaInfo)
        {
            return DataProvider.GraphSchemaProvider.InsertWithTrans(trans, graphSchemaInfo);
        }

        /// <summary>
        /// 修改曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GraphSchemaInfo graphSchemaInfo)
        {
            return DataProvider.GraphSchemaProvider.Update(graphSchemaInfo);
        }

        /// <summary>
        /// 更新创建或修改人。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <param name="referLoginName">登录名。</param>
        /// <returns></returns>
        [WebMethod]
        public bool UpdateLoginName(int schemaId, string referLoginName)
        {
            return DataProvider.GraphSchemaProvider.UpdateLoginName(schemaId, referLoginName);
        }

        /// <summary>
        /// 深层次保存曲线方案对象.
        /// </summary>
        /// <param name="obj">曲线方案对象.</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool DeepSave(GraphSchemaInfo obj)
        {
            return DataProvider.GraphSchemaProvider.DeepSave(obj);
        }
        #endregion
    }
}
