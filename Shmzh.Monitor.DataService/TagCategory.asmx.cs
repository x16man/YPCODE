using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// TagCategory 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagCategory : System.Web.Services.WebService,ITagCategory
    {

        
        #region Implementation of ITagCategory

        /// <summary>
        /// 获取所有指标类别信息实体集合。
        /// </summary>
        /// <returns>所有指标类别信息实体集合。</returns>
        [WebMethod]
        public List<TagCategoryInfo> GetAll()
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.GetAll();
        }

        /// <summary>
        /// 根据父类别获取指标类别信息实体集合。
        /// </summary>
        /// <param name="parentId">父类别Id。</param>
        /// <returns></returns>
        [WebMethod]
        public List<TagCategoryInfo> GetByParentId(int parentId)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.GetByParentId(parentId);
        }

        /// <summary>
        /// 根据指标类别Id获取指标类别信息实体。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns>指标类别信息实体。</returns>
        [WebMethod]
        public TagCategoryInfo GetById(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.GetById(categoryId);
        }

        /// <summary>
        /// 根据指标类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.Delete(categoryId);
        }

        /// <summary>
        /// 添加指标类别信息实体。
        /// </summary>
        /// <param name="entity">指标类别信息实体对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public int Insert(TagCategoryInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.Insert(entity);
        }

        /// <summary>
        /// 修改指标类别信息实体。
        /// </summary>
        /// <param name="entity">指标类别信息实体对象。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(TagCategoryInfo entity)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.Update(entity);
        }

        /// <summary>
        /// 上移或下移。
        /// </summary>
        /// <param name="categoryId">要移动的指标类别Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        [WebMethod]
        public bool MoveUpDown(int categoryId, byte opType)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.MoveUpDown(categoryId, opType);
        }

        /// <summary>
        /// 移动某指标类别到另一个类别下。
        /// </summary>
        /// <param name="moveCategoryId">要移动的指标类别Id。</param>
        /// <param name="targetCategoryId">作为父类别的类别Id。</param>
        /// <returns></returns>
        [WebMethod]
        public bool Move(int moveCategoryId, int targetCategoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryProvider.Move(moveCategoryId, targetCategoryId);
        }

        #endregion
    }
}
