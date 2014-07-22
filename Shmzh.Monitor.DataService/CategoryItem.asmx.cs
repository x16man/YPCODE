using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;


namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// CategoryItem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CategoryItem : System.Web.Services.WebService,ICategoryItem
    {

        #region Implementation of ICategoryItem

        /// <summary>
        /// 获取所有分类监控方案.
        /// </summary>
        /// <returns>所有分类监控方案.</returns>
        [WebMethod]
        public List<CategoryItemInfo> GetAll()
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetAll();
        }

        /// <summary>
        /// 获取由XML文件配置的方案列表。
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<CategoryItemInfo> GetXmlItemInfo()
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetXmlItemInfo();
        }

        /// <summary>
        /// 获取所有类别条目信息实体集合。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>所有类别条目信息实体集合。</returns>
        [WebMethod]
        public List<CategoryItemInfo> GetByCategoryId(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetByCategoryId(categoryId);
        }

        /// <summary>
        /// 一个方案可能分到多个分类。
        /// </summary>
        /// <param name="configFile">配置文件名或曲线方案名。</param>
        /// <returns></returns>
        [WebMethod]
        public List<CategoryItemInfo> GetByConfigFile(string configFile)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetByConfigFile(configFile);
        }

        /// <summary>
        /// 根据类别条目Id获取类别信息实体。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>类别条目信息实体。</returns>
        [WebMethod]
        public CategoryItemInfo GetById(int itemId)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetById(itemId);
        }

        /// <summary>
        /// 根据类别条目编号获取类别信息实体。
        /// </summary>
        /// <param name="code">类别条目编号。</param>
        /// <returns>类别条目信息实体。</returns>
        [WebMethod]
        public CategoryItemInfo GetByCode(string code)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetByCode(code);
        }

        /// <summary>
        /// 根据类别条目Id进行删除。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int itemId)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.Delete(itemId);
        }

        /// <summary>
        /// 添加类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public int Insert(CategoryItemInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.Insert(entity);
        }

        /// <summary>
        /// 修改类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(CategoryItemInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.Update(entity);
        }

        public bool Update(SqlTransaction trans, CategoryItemInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.Update(trans, entity);
        }

        /// <summary>
        /// 方案分类条目移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int itemId, byte opType)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.Move(itemId, opType);
        }

        #endregion
    }
}
