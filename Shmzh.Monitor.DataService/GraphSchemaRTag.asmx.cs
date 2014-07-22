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
    /// GraphSchemaRTag 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GraphSchemaRTag : System.Web.Services.WebService,IGraphSchemaRTag
    {
        #region Implementation of IGraphSchemaRTag

        /// <summary>
        /// 获取所有的GraphSchemaRTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaRTagInfo.</returns>
        [WebMethod]
        public List<GraphSchemaRTagInfo> GetAll()
        {
            return DataProvider.GraphSchemaRTagProvider.GetAll();
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        [WebMethod]
        public GraphSchemaRTagInfo GetById(int keyId)
        {
            return DataProvider.GraphSchemaRTagProvider.GetById(keyId);
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="tabId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        [WebMethod]
        public List<GraphSchemaRTagInfo> GetByTabId(int tabId)
        {
            return DataProvider.GraphSchemaRTagProvider.GetByTabId(tabId);
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int rTagId)
        {
            return DataProvider.GraphSchemaRTagProvider.Delete(rTagId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaRTagInfo rTagInfo)
        {
            return DataProvider.GraphSchemaRTagProvider.Delete(rTagInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(GraphSchemaRTagInfo rTagInfo)
        {
            return DataProvider.GraphSchemaRTagProvider.Insert(rTagInfo);
        }
        
        public bool InsertWithTrans(SqlTransaction trans, GraphSchemaRTagInfo rTagInfo)
        {
            return DataProvider.GraphSchemaRTagProvider.InsertWithTrans(trans, rTagInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GraphSchemaRTagInfo rTagInfo)
        {
            return DataProvider.GraphSchemaRTagProvider.Update(rTagInfo);
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
            return DataProvider.GraphSchemaRTagProvider.Move(keyId, opType);
        }

        #endregion
    }
}
