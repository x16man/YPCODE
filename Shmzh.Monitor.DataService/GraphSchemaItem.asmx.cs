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
    /// GraphSchemaItem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GraphSchemaItem : System.Web.Services.WebService,IGraphSchemaItem
    {
        #region Implementation of IGraphSchemaItem

        /// <summary>
        /// 获取所有的曲线方案项。
        /// </summary>
        /// <returns>所有的曲线方案项。</returns>
        [WebMethod]
        public List<GraphSchemaItemInfo> GetAll()
        {
            return DataProvider.GraphSchemaItemProvider.GetAll();
        }

        /// <summary>
        /// 根据方案项Id获取曲线方案项。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线方案项实体。</returns>
        [WebMethod]
        public GraphSchemaItemInfo GetById(int itemId)
        {
            return DataProvider.GraphSchemaItemProvider.GetById(itemId);
        }

        /// <summary>
        /// 根据曲线方案Id获取所有的
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线方案项集合。</returns>
        [WebMethod]
        public List<GraphSchemaItemInfo> GetBySchemaId(int schemaId)
        {
            return DataProvider.GraphSchemaItemProvider.GetBySchemaId(schemaId);
        }

        /// <summary>
        /// 根据曲线方案项Id进行删除。
        /// </summary>
        /// <param name="schemaItemId">曲线方案项Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int schemaItemId)
        {
            return DataProvider.GraphSchemaItemProvider.Delete(schemaItemId);
        }

        /// <summary>
        /// 删除曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaItemInfo itemInfo)
        {
            return DataProvider.GraphSchemaItemProvider.Delete(itemInfo);
        }

        /// <summary>
        /// 添加曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>int</returns>
        [WebMethod]
        public int Insert(GraphSchemaItemInfo itemInfo)
        {
            return DataProvider.GraphSchemaItemProvider.Insert(itemInfo);
        }

        /// <summary>
        /// 添加曲线方案项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="itemInfo">曲线方案项</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, GraphSchemaItemInfo itemInfo)
        {
            return DataProvider.GraphSchemaItemProvider.InsertWithTrans(trans, itemInfo);
        }


        /// <summary>
        /// 修改曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(GraphSchemaItemInfo itemInfo)
        {
            return DataProvider.GraphSchemaItemProvider.Update(itemInfo);
        }

        /// <summary>
        /// 曲线方案 Item 移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int itemId, byte opType)
        {
            return DataProvider.GraphSchemaItemProvider.Move(itemId, opType);
        }

        #endregion
    }
}
