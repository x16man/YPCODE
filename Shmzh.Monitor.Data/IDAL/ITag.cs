using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    /// <summary>
    /// 指标信息的数据访问接口。
    /// </summary>
    public interface ITag
    {
        /// <summary>
        /// 根据指标Id获取指标信息。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>指标信息实体。</returns>
        TagInfo GetById(string tagId);

        /// <summary>
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        List<TagInfo> GetAll();

        /// <summary>
        /// 根据输入字符进行快速查询。
        /// </summary>
        /// <param name="tagId">查询条件。</param>
        /// <returns>指标集合。</returns>
        List<TagInfo> QuickSearch(string strCondition);

        /// <summary>
        /// 根据指标类型、指标Id、指标名称获取指标列表。
        /// </summary>
        /// <param name="tagType">指标类型</param>
        /// <param name="tagId">指标Id</param>
        /// <param name="tagName">指标名称</param>
        /// <returns>指标集合。</returns>
        List<TagInfo> GetByType_TagId_TagName(string tagType, string tagId, string tagName);
        
        /// <summary>
        /// 获取服务器时间。
        /// </summary>
        /// <returns>服务器时间。</returns>
        DateTime GetDate();

        /// <summary>
        /// 获取三项指标合格率。
        /// </summary>
        /// <returns>三项指标合格率。</returns>
        double Get3TagEligibleRate(DateTime beginDate,DateTime endDate);
        
        /// <summary>
        /// 获取4项指标合格率。
        /// </summary>
        /// <returns>4项指标合格率。</returns>
        double Get4TagEligibleRate(DateTime beginDate,DateTime endDate);
        
        /// <summary>
        /// 获取7项指标合格率。
        /// </summary>
        /// <returns>7项指标合格率。</returns>
        double Get7TagEligibleRate(DateTime beginDate,DateTime endDate);
    }
}
