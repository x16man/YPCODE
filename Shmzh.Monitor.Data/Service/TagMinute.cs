using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
namespace Shmzh.Monitor.Data.Service
{
    public class TagMinute :IDAL.ITagMinute
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        public TagMinute()
        {
            
        }
        #region ITagMinute 成员

        /// <summary>
        /// 根据指定的日期、单个指标Id、开始时间Id、结束时间Id来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id(第几分钟)。</param>
        /// <param name="endCycleId">结束时间Id(第几分钟)。</param>
        /// <returns>分钟数据集合。</returns>
        public List<TagMinuteInfo> Get_By_Date_TagId_CycleId(DateTime date, string tagId, int beginCycleId, int endCycleId)
        {
            var objs = new TagMinuteService.TagMinute().Get_By_Date_TagId_CycleId(date, tagId, beginCycleId, endCycleId);
            var obj1s = new List<TagMinuteInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagMinuteInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的日期、单个指标Id、开始时间、结束时间来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>分钟数据集合</returns>
        public List<TagMinuteInfo> Get_By_Date_TagId_DateTime(DateTime date, string tagId, DateTime beginTime, DateTime endTime)
        {
            var objs = new TagMinuteService.TagMinute().Get_By_Date_TagId_DateTime(date, tagId, beginTime, endTime);
            var obj1s = new List<TagMinuteInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagMinuteInfo();
                CopyHelper.Copy( obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的日期、多个指标Id、开始时间Id、结束时间Id来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagIds">指标Id字符串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id(第几分钟)。</param>
        /// <param name="endCycleId">结束时间Id(第几分钟)。</param>
        /// <returns>分钟数据集合</returns>
        public List<TagMinuteInfo> Get_By_Date_TagIds_CycleId(DateTime date, string tagIds, int beginCycleId, int endCycleId)
        {
            var objs = new TagMinuteService.TagMinute().Get_By_Date_TagIds_CycleId(date, tagIds, beginCycleId, endCycleId);
            var obj1s = new List<TagMinuteInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagMinuteInfo();
                CopyHelper.Copy( obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的日期、多个指标Id、开始时间、结束时间来获取分钟数据集合。
        /// </summary>
        /// <param name="date">指定的日期(对应具体的分钟表T_Tag_MYYYYMMDD)。</param>
        /// <param name="tagIds">指标Id字符串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>分钟数据集合</returns>
        public List<TagMinuteInfo> Get_By_Date_TagIds_DateTime(DateTime date, string tagIds, DateTime beginTime, DateTime endTime)
        {
            var objs = new TagMinuteService.TagMinute().Get_By_Date_TagIds_DateTime(date, tagIds, beginTime, beginTime);
            var obj1s = new List<TagMinuteInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagMinuteInfo();
                CopyHelper.Copy( obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据Id获取最新的分钟表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>分钟数据实体。</returns>
        public TagMinuteInfo Get_Latest_By_TagId(string tagId)
        {
            Logger.Debug(string.Format("TagMinute.Get_Latest_By_TagId({0})", tagId));
            var obj = new TagMinuteService.TagMinute().Get_Latest_By_TagId(tagId);
            TagMinuteInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new TagMinuteInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据指标Id串来获取最新的分钟表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        public List<TagMinuteInfo> Get_Latest_By_TagIds(string tagIds)
        {
            Logger.Debug(string.Format("TagMinute.Get_Latest_By_TagIds({0})", tagIds));
            var objs = new TagMinuteService.TagMinute().Get_Latest_By_TagIds(tagIds);
            var obj1s = new List<TagMinuteInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagMinuteInfo();
                CopyHelper.Copy( obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有最新的分钟数据。
        /// </summary>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        public List<TagMinuteInfo> Get_Latest_All()
        {
            Logger.Debug(string.Format("TagMinute.Get_Latest_All()"));
            var objs = new TagMinuteService.TagMinute().Get_Latest_All();
            var obj1s = new List<TagMinuteInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagMinuteInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        

        #endregion

        
    }
}
