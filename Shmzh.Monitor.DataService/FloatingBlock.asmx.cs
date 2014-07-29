using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// FloatingBlock 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class FloatingBlock : System.Web.Services.WebService,IFloatingBlock
    {

        #region Implementation of IFloatingBlock

        /// <summary>
        /// 获取所有浮动窗口.
        /// </summary>
        /// <returns>所有浮动窗口.</returns>
        [WebMethod]
        public List<FloatingBlockInfo> GetAll()
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.GetAll();
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        [WebMethod]
        public FloatingBlockInfo GetById(int blockId)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.GetById(blockId);
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        [WebMethod]
        public List<FloatingBlockInfo> GetBySchemaId(int schemaId)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.GetBySchemaId(schemaId);
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="blockId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int blockId)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.Delete(blockId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(FloatingBlockInfo blockInfo)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.Delete(blockInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public int Insert(FloatingBlockInfo blockInfo)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.Insert(blockInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="blockInfo">浮动窗体对象.</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, FloatingBlockInfo blockInfo)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.InsertWithTrans(trans, blockInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(FloatingBlockInfo blockInfo)
        {
            return Shmzh.Monitor.Data.DataProvider.FloatingBlockProvider.Update(blockInfo);
        }

        #endregion
    }
}
