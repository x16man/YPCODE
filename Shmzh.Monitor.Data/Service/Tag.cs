using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    public class Tag:IDAL.ITag
    {
        public Tag()
        {
        }

        #region ITag 成员

        /// <summary>
        /// 根据指标Id获取指标信息。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>指标信息实体。</returns>
        public TagInfo GetById(string tagId)
        {
            var obj = new TagService.Tag().GetById(tagId);
            TagInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new TagInfo();
                CopyHelper.Copy(obj,obj1);
            }
            
            return obj1;
        }

        /// <summary>
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        public List<TagInfo> GetAll()
        {
            var objs = new TagService.Tag().GetAll();
            var obj1s = new List<TagInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据输入字符进行快速查询。
        /// </summary>
        /// <param name="tagId">查询条件。</param>
        /// <returns>指标集合。</returns>
        public List<TagInfo> QuickSearch(string strCondition)
        {
            var objs = new TagService.Tag().QuickSearch(strCondition);
            var obj1s = new List<TagInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指标类型、指标Id、指标名称获取指标列表。
        /// </summary>
        /// <param name="tagType">指标类型</param>
        /// <param name="tagId">指标Id</param>
        /// <param name="tagName">指标名称</param>
        /// <returns>指标集合。</returns>
        public List<TagInfo> GetByType_TagId_TagName(string tagType, string tagId, string tagName)
        {
            var objs = new TagService.Tag().GetByType_TagId_TagName(tagType, tagId, tagName);
            var obj1s = new List<TagInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取服务器时间。
        /// </summary>
        /// <returns>服务器时间。</returns>
        public DateTime GetDate()
        {
            return new TagService.Tag().GetDate();
        }

        #endregion

        #region ITag 成员


        public double Get3TagEligibleRate(DateTime beginDate,DateTime endDate)
        {
            return new TagService.Tag().Get3TagEligibleRate(beginDate, endDate);
        }

        public double Get4TagEligibleRate(DateTime beginDate,DateTime endDate)
        {
            return new TagService.Tag().Get4TagEligibleRate(beginDate, endDate);
        }

        public double Get7TagEligibleRate(DateTime beginDate,DateTime endDate)
        {
            return new TagService.Tag().Get7TagEligibleRate(beginDate, endDate);
        }

        #endregion
    }
}
