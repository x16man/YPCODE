using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    public class TagGather:IDAL.ITagGather
    {
        public TagGather()
        {
        }

        /// <summary>
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        public List<TagGatherInfo> GetByTagId(String tagId)
        {
            var objs = new TagGatherService.TagGather().GetByTagId(tagId);
            var obj1s = new List<TagGatherInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagGatherInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }
    }
}
