using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// FloatingBlockItem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class FloatingBlockItem : System.Web.Services.WebService,IFloatingBlockItem
    {
        #region Implementation of IFloatingBlockItem

        /// <summary>
        /// 获取所有FloatingBlockItemInfo.
        /// </summary>
        /// <returns>所有FloatingBlockItemInfo.</returns>
        [WebMethod]
        public List<FloatingBlockItemInfo> GetAll()
        {
            return DataProvider.FloatingBlockItemProvider.GetAll();
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockItemId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        [WebMethod]
        public FloatingBlockItemInfo GetById(int blockItemId)
        {
            return DataProvider.FloatingBlockItemProvider.GetById(blockItemId);
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="blockId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        [WebMethod]
        public List<FloatingBlockItemInfo> GetByBlockId(int blockId)
        {
            return DataProvider.FloatingBlockItemProvider.GetByBlockId(blockId);
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int rTagId)
        {
            return DataProvider.FloatingBlockItemProvider.Delete(rTagId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(FloatingBlockItemInfo blockItemInfo)
        {
            return DataProvider.FloatingBlockItemProvider.Delete(blockItemInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(FloatingBlockItemInfo blockItemInfo)
        {
            return DataProvider.FloatingBlockItemProvider.Insert(blockItemInfo);
        }

        public bool InsertWithTrans(SqlTransaction trans, FloatingBlockItemInfo blockItemInfo)
        {
            return DataProvider.FloatingBlockItemProvider.InsertWithTrans(trans, blockItemInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(FloatingBlockItemInfo blockItemInfo)
        {
            return DataProvider.FloatingBlockItemProvider.Update(blockItemInfo);
        }

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="blockItemId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int blockItemId, byte opType)
        {
            return DataProvider.FloatingBlockItemProvider.Move(blockItemId, opType);
        }

        #endregion
    }
}
