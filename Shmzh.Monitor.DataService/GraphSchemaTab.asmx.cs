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
    /// GraphSchemaTab 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GraphSchemaTab : System.Web.Services.WebService,IGraphSchemaTab
    {
        #region Implementation of IGraphSchemaTab

        /// <summary>
        /// 获取所有的GraphSchemaTabInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTabInfo.</returns>
        [WebMethod]
        public List<GraphSchemaTabInfo> GetAll()
        {
            return DataProvider.GraphSchemaTabProvider.GetAll();
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        [WebMethod]
        public GraphSchemaTabInfo GetById(int keyId)
        {
            return DataProvider.GraphSchemaTabProvider.GetById(keyId);
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        [WebMethod]
        public List<GraphSchemaTabInfo> GetBySchemaId(int schemaId)
        {
            return DataProvider.GraphSchemaTabProvider.GetBySchemaId(schemaId);
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="tabId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int tabId)
        {
            return DataProvider.GraphSchemaTabProvider.Delete(tabId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaTabInfo tabInfo)
        {
            return DataProvider.GraphSchemaTabProvider.Delete(tabInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public int Insert(GraphSchemaTabInfo tabInfo)
        {
            return DataProvider.GraphSchemaTabProvider.Insert(tabInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="tabInfo">曲线方案关联项对象</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, GraphSchemaTabInfo tabInfo)
        {
            return DataProvider.GraphSchemaTabProvider.InsertWithTrans(trans, tabInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GraphSchemaTabInfo tabInfo)
        {
            return DataProvider.GraphSchemaTabProvider.Update(tabInfo);
        }

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int keyId, byte opType)
        {
            return DataProvider.GraphSchemaTabProvider.Move(keyId, opType);
        }

        #endregion
    }
}
