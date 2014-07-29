using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;


namespace Shmzh.Monitor.Data.Service
{
    public class TagYear:IDAL.ITagYear
    {
        public TagYear(){}
        #region ITagYear 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取年表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            var objs = new TagYearService.TagYear().Get_By_TagId_CycleId(tagId, beginCycleId, beginCycleId);
            var obj1s = new List<TagYearInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagYearInfo();
                CopyHelper.Copy( obj,  obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取年表数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            var objs = new TagYearService.TagYear().Get_By_TagId_DateTime(tagId, beginTime, endTime);
            var obj1s = new List<TagYearInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagYearInfo();
                CopyHelper.Copy( obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取年表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            var objs = new TagYearService.TagYear().Get_By_TagIds_CycleId(tagIds, beginCycleId, beginCycleId);
            var obj1s = new List<TagYearInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagYearInfo();
                CopyHelper.Copy( obj,  obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取年表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            var objs = new TagYearService.TagYear().Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
            var obj1s = new List<TagYearInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagYearInfo();
                CopyHelper.Copy( obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据指定的指标Id获取最新的年表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>年表数据实体。</returns>
        public TagYearInfo Get_Latest_By_TagId(string tagId)
        {
            var obj = new TagYearService.TagYear().Get_Latest_By_TagId(tagId);
            TagYearInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new TagYearInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据指定的指标Id串获取最新的年表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_Latest_By_TagIds(string tagIds)
        {
            var objs = new TagYearService.TagYear().Get_Latest_By_TagIds(tagIds);
            var obj1s = new List<TagYearInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagYearInfo();
                CopyHelper.Copy( obj,  obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取最新的年数据。
        /// </summary>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_Latest_All()
        {
            var objs = new TagYearService.TagYear().Get_Latest_All();
            var obj1s = new List<TagYearInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new TagYearInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
