using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    public class TagSecond :IDAL.ITagSecond
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        public TagSecond()
        {
        }

        #region ITagSecond 成员

        /// <summary>
        /// 根据Id获取最新的秒表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>秒数据实体。</returns>
        public TagSecondInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagSecond.Get_Latest_By_TagId({0})", tagId));
            var obj = new TagSecondService.TagSecond().Get_Latest_By_TagId(tagId);
            TagSecondInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new TagSecondInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据指标Id串来获取最新的秒表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        public List<TagSecondInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagSecond.Get_Latest_By_TagIds({0})",tagIds));
            var objs = new TagSecondService.TagSecond().Get_Latest_By_TagIds(tagIds);
            var obj1s = new List<TagSecondInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagSecondInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有指标的最新秒数据。
        /// </summary>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        public List<TagSecondInfo> Get_Latest_All()
        {
            Logger.Debug(string.Format("TagSecond.Get_Latest_All()"));

            var objs = new TagSecondService.TagSecond().Get_Latest_All();
            var obj1s = new List<TagSecondInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagSecondInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
