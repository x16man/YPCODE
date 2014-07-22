using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    public class TagHour : IDAL.ITagHour
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TagHour()
        {

        }

        #region ITagHour 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取小时数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>小时数据集合。</returns>
        public List<TagHourInfo> Get_BY_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            var objs = new TagHourService.TagHour().Get_BY_TagId_CycleId(tagId, beginCycleId, endCycleId);
            var obj1s = new List<TagHourInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取小时数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>小时数据集合。</returns>
        public List<TagHourInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            var objs = new TagHourService.TagHour().Get_By_TagId_DateTime(tagId, beginTime, endTime);
            var obj1s = new List<TagHourInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取小时数据集合。
        /// </summary>
        /// <param name="tagIds">指标数据Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>小时数据集合。</returns>
        public List<TagHourInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            var objs = new TagHourService.TagHour().Get_By_TagIds_CycleId(tagIds, beginCycleId, endCycleId);
            var obj1s = new List<TagHourInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取小时数据集合。
        /// </summary>
        /// <param name="tagIds">指标数据集合。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>小时数据集合。</returns>
        public List<TagHourInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            var objs = new TagHourService.TagHour().Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
            var obj1s = new List<TagHourInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id获取最新的小时表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>最新的小时表数据。</returns>
        public TagHourInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagHour.Get_Latest_By_TagId({0})", tagId));
            var obj = new TagHourService.TagHour().Get_Latest_By_TagId(tagId);
            TagHourInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
            }

            return obj1;
        }

        /// <summary>
        /// 根据指定指标Id串获取最新的小时表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>最新的小时表数据。</returns>
        public List<TagHourInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagHour.Get_Latest_By_TagIds({0})", tagIds));
            var objs = new TagHourService.TagHour().Get_Latest_By_TagIds(tagIds);
            var obj1s = new List<TagHourInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有最新的小时表数据。
        /// </summary>
        /// <returns>最新的小时表数据。</returns>
        public List<TagHourInfo> Get_Latest_All()
        {
            Logger.Debug(string.Format("TagHour.Get_Latest_All()"));
            var objs = new TagHourService.TagHour().Get_Latest_All();
            var obj1s = new List<TagHourInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagHourInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
