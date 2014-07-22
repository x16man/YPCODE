using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// GraphSchemaTag 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GraphSchemaTag : System.Web.Services.WebService,IGraphSchemaTag
    {
        #region Implementation of IGraphSchemaTag

        /// <summary>
        /// 获取所有的GraphSchemaTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTagInfo.</returns>
        [WebMethod]
        public List<GraphSchemaTagInfo> GetAll()
        {
            return DataProvider.GraphSchemaTagProvider.GetAll();
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案项指标Id。</param>
        /// <returns>方案项指标信息实体。</returns>
        [WebMethod]
        public GraphSchemaTagInfo GetById(int keyId)
        {
            return DataProvider.GraphSchemaTagProvider.GetById(keyId);
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线指标集合。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线指标集合。</returns>
        [WebMethod]
        public List<GraphSchemaTagInfo> GetBySchemaItemId(int itemId)
        {
            return DataProvider.GraphSchemaTagProvider.GetBySchemaItemId(itemId);
        }

        /// <summary>
        /// 根据曲线方案指标Id进行删除。
        /// </summary>
        /// <param name="schemaTagId">曲线方案指标Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int schemaTagId)
        {
            return DataProvider.GraphSchemaTagProvider.Delete(schemaTagId);
        }

        /// <summary>
        /// 删除曲线方案指标。
        /// </summary>
        /// <param name="tagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaTagInfo tagInfo)
        {
            return DataProvider.GraphSchemaTagProvider.Delete(tagInfo);
        }

        /// <summary>
        /// 添加曲线方案指标。
        /// </summary>
        /// <param name="schemaTagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(GraphSchemaTagInfo schemaTagInfo)
        {
            return DataProvider.GraphSchemaTagProvider.Insert(schemaTagInfo);
        }

        /// <summary>
        /// 添加曲线方案指标.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="tagInfo">指标对象.</param>
        /// <returns>bool</returns>
        public bool InsertWithTrans(SqlTransaction trans, GraphSchemaTagInfo tagInfo)
        {
            return DataProvider.GraphSchemaTagProvider.InsertWithTrans(trans, tagInfo);
        }

        /// <summary>
        /// 修改曲线方案指标。
        /// </summary>
        /// <param name="schemaTagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GraphSchemaTagInfo schemaTagInfo)
        {
            return DataProvider.GraphSchemaTagProvider.Update(schemaTagInfo);
        }

        /// <summary>
        /// 图表方案指标项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int keyId, byte opType)
        {
            return DataProvider.GraphSchemaTagProvider.Move(keyId, opType);
        }

        #endregion
    }
}
