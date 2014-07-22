using System;
using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// Category 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Category : System.Web.Services.WebService,ICategory
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Implementation of ICategory

        /// <summary>
        /// 获取所有类别信息实体集合。
        /// </summary>
        /// <returns>所有类别信息实体集合。</returns>
        [WebMethod]
        public List<CategoryInfo> GetAll()
        {
            //Logger.Info("GetAll");
            var objs = Shmzh.Monitor.Data.DataProvider.CategoryProvider.GetAll();
            return objs;
        }

        /// <summary>
        /// 根据类别Id获取类别信息实体。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>类别信息实体。</returns>
        [WebMethod]
        public CategoryInfo GetById(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryProvider.GetById(categoryId);
        }

        /// <summary>
        /// 根据类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryProvider.Delete(categoryId);
        }

        /// <summary>
        /// 添加类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>int</returns>
        [WebMethod]
        public int Insert(CategoryInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryProvider.Insert(entity);
        }

        /// <summary>
        /// 修改类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(CategoryInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryProvider.Update(entity);
        }

        /// <summary>
        /// 方案分类移动。
        /// </summary>
        /// <param name="categoryId">CategoryId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int categoryId, byte opType)
        {
            return Shmzh.Monitor.Data.DataProvider.CategoryProvider.Move(categoryId, opType);
        }

        #endregion
    }
}
