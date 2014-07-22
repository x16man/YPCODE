using System;
using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// TagCategoryDetail 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TagCategoryDetail : System.Web.Services.WebService,ITagCategoryDetail
    {

        #region Implementation of ITagCategoryDetail

        /// <summary>
        /// 根据类别获取所包含指标信息实体集合。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns></returns>
        [WebMethod]
        public List<TagCategoryDetailInfo> GetByCategoryId(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryDetailProvider.GetByCategoryId(categoryId);
        }

        /// <summary>
        /// 根据类别获取所包含指标信息实体集合。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <returns></returns>
        [WebMethod]
        public List<TagInfo> GetTagsByCategoryId(int categoryId)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryDetailProvider.GetTagsByCategoryId(categoryId);
        }

        /// <summary>
        /// 添加重设指定类别所包含的指标。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <param name="tagIds">所包含指标的Id数组。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Reset(int categoryId, string[] tagIds)
        {
            return Shmzh.Monitor.Data.DataProvider.TagCategoryDetailProvider.Reset(categoryId, tagIds);
        }

        #endregion
    }
}
