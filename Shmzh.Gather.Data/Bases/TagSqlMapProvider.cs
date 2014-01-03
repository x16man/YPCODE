using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Gather.Data.Bases
{
    /// <summary>
    /// 本地指标与第三方的采集指标的映射关系记录的数据访问抽象类。
    /// </summary>
    public abstract class TagSqlMapProvider :ITagSqlMap
    {
        #region Implementation of ITagSqlMap

        /// <summary>
        /// 添加本地指标与第三方的采集指标的映射关系记录。
        /// </summary>
        /// <param name="obj">本地指标与第三方的采集指标的映射关系记录。</param>
        /// <returns>bool</returns>
        public abstract bool Insert(TagSqlMapInfo obj);

        /// <summary>
        /// 更改本地指标与第三方的采集指标的映射关系记录。
        /// </summary>
        /// <param name="obj">本地指标与第三方的采集指标的映射关系记录。</param>
        /// <returns>bool</returns>
        public abstract bool Update(TagSqlMapInfo obj);

        /// <summary>
        /// 根据Id删除本地指标与第三方的采集指标的映射关系记录。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(string tagId);

        /// <summary>
        /// 删除本地指标与第三方的采集指标的映射关系记录。
        /// </summary>
        /// <param name="obj">本地指标与第三方的采集指标的映射关系记录。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(TagSqlMapInfo obj);

        /// <summary>
        /// 获取所有的本地指标与第三方的采集指标的映射关系记录。
        /// </summary>
        /// <returns>本地指标与第三方的采集指标的映射关系记录集合。</returns>
        public abstract List<TagSqlMapInfo> GetAll();

        /// <summary>
        /// 根据内容获取本地指标与第三方采集指标的映射关系记录。
        /// </summary>
        /// <param name="content">查询内容</param>
        /// <returns>本地指标与第三方的采集指标的映射关系记录集合。</returns>
        public abstract List<TagSqlMapInfo> GetByContent(string content);
        /// <summary>
        /// 根据Id获取本地指标与第三方的采集指标的映射关系记录。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>本地指标与第三方的采集指标的映射关系记录。</returns>
        public abstract TagSqlMapInfo GetByTagId(string tagId);

        #endregion
    }
}
