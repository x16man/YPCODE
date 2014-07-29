using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Configuration;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using Shmzh.Components.Util;
using Ciloci.Flee;

namespace Shmzh.Monitor.Forms
{
    public static class CacheProvider
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 缓存数据实体。
        /// </summary>
        private static CacheInfo cacheInfo = new CacheInfo();
        /// <summary>
        /// 匹配指标的正则表达式。
        /// </summary>
        private static Regex tagRegex = new Regex(@"\[[-\w]*\]");
        /// <summary>
        /// 缓存列表的容积，超出时自动清除超出的数据。不大于零的值表示禁用缓存。
        /// </summary>
        private static int LIST_MAX_COUNT = (ConfigurationManager.AppSettings["CacheCapacity"] == null ? 6000 : Convert.ToInt32(ConfigurationManager.AppSettings["CacheCapacity"]));
        #endregion

        #region Private Methods
        /// <summary>
        /// 将指标表达式中出现的指标转换成一个唯一的指标数组。
        /// </summary>
        /// <param name="tagExp">指标表达式。</param>
        /// <returns>指标数组（唯一性）。</returns>
        private static String[] DistinctTag(String tagExp)
        {
            var tags = new List<String>();
            var mc = tagRegex.Matches(tagExp);
            for (var i = 0; i < mc.Count; i++)
            {
                var temp = mc[i].ToString().Replace("[", String.Empty).Replace("]", String.Empty);
                if (!tags.Contains(temp))
                {
                    tags.Add(temp);
                }
            }
            return tags.ToArray();
        }

        public static IGenericExpression<double> DefineExpression(String tagExp, String[] tagIds)
        {
            IGenericExpression<double> MyExpression;
            ExpressionContext MyContext = new ExpressionContext();
            MyContext.Imports.AddType(typeof(System.Math));
            String tagExpression = tagExp;
            for (int i = 0; i < tagIds.Length; i++)
            {
                tagExpression = tagExpression.Replace(string.Format("[{0}]", tagIds[i]), string.Format("x{0}", i));
                MyContext.Variables.DefineVariable(string.Format("x{0}", i), typeof(double));
            }
            MyExpression = MyContext.CompileGeneric<double>(tagExpression);
            return MyExpression;
        }

        public static IGenericExpression<double> DefineExpression(String tagExp, String[] tagIds, bool isAddSquareBracket)
        {
            IGenericExpression<double> MyExpression;
            ExpressionContext MyContext = new ExpressionContext();
            MyContext.Imports.AddType(typeof(System.Math));
            String tagExpression = tagExp;
            String tmpFormat = "{0}";
            if (isAddSquareBracket) tmpFormat = "[" + tmpFormat + "]";
            for (int i = 0; i < tagIds.Length; i++)
            {
                tagExpression = tagExpression.Replace(string.Format(tmpFormat, tagIds[i]), string.Format("x{0}", i));
                MyContext.Variables.DefineVariable(string.Format("x{0}", i), typeof(double));
            }
            MyExpression = MyContext.CompileGeneric<double>(tagExpression);
            return MyExpression;
        }
        #endregion

        #region Classes
        public static class TagMinuteProvider
        {
            /// <summary>
            /// 分钟表是每天一个数据表的，所以不周日期的时间段要拆分开来取值。
            /// 这个方法只能取date日期内的时间段，调用时请确保 beginTime 和 endTime 与 date 在同一天。
            /// </summary>
            /// <param name="date">日期。</param>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <returns></returns>
            public static List<TagMinuteInfo> Get_By_Date_TagId_DateTime(DateTime date, String tagExp, DateTime beginTime, DateTime endTime)
            {
                bool isExpression = false;
                if (tagExp.Contains("[") && tagExp.Contains("]"))
                {
                    if (!tagExp.StartsWith("[") || !tagExp.EndsWith("]") || tagExp.Substring(1).Contains("["))
                    {
                        isExpression = true;
                    }
                }
                List<TagMinuteInfo> list = new List<TagMinuteInfo>();

                if (isExpression)
                {
                    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                    //watch.Reset();
                    //watch.Start();
                    //tagIds,resultList,objs 索引相对应。
                    String[] tagIds = DistinctTag(tagExp);
                    List<TagMinuteInfo>[] resultList = new List<TagMinuteInfo>[tagIds.Length];
                    for (int i = 0; i < tagIds.Length; i++)
                    {
                        resultList[i] = Get_By_Date_TagId_DateTime_SingleTag(date, tagIds[i], beginTime, endTime);
                    }

                    IGenericExpression<double> MyExpression = DefineExpression(tagExp, tagIds);

                    int beginCycleId = Gather.DateTime2MinuteCycleId(beginTime);
                    int endCycleId = Gather.DateTime2MinuteCycleId(endTime);
                    bool isValid;
                    for (int cycleId = beginCycleId; cycleId <= endCycleId; cycleId++)
                    {
                        isValid = false;
                        TagMinuteInfo[] objs = new TagMinuteInfo[tagIds.Length];
                        for (int j = 0; j < tagIds.Length; j++)
                        {
                            objs[j] = resultList[j].Find(o => o.I_Cycle_Id == cycleId);
                            if (objs[j] != null) isValid = true;
                        }
                        if (isValid)
                        {
                            TagMinuteInfo tagMinInfo = new TagMinuteInfo()
                            {
                                I_Cycle_Id = cycleId,
                                I_Tag_Id = tagExp
                            };

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].I_Value_Man;
                                }
                                else 
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            double retValue = MyExpression.Evaluate();
                            tagMinInfo.I_Value_Man = retValue;

                            list.Add(tagMinInfo);
                        }
                    }
                    //watch.Stop();
                    //Logger.Info(String.Format("分钟--时间：{0} ms", watch.Elapsed.Milliseconds));
                }
                else
                {
                    String tagId = tagExp.Replace("[", "").Replace("]", "");
                    list = Get_By_Date_TagId_DateTime_SingleTag(date, tagId, beginTime, endTime);
                }
                return list;
            }

            public static List<TagMinuteInfo> Get_By_Date_TagId_DateTime_SingleTag(DateTime date, String tagId, DateTime beginTime, DateTime endTime)
            {
                List<TagMinuteInfo> list = new List<TagMinuteInfo>();
                
                int beginCycleId = Gather.DateTime2MinuteCycleId(beginTime);
                int endCycleId = Gather.DateTime2MinuteCycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;
                if (cacheInfo.CMinList.Count > 0)
                {
                    if (shouldCount == 1)
                    {
                        CTagMinuteInfo cObj = cacheInfo.CMinList.Find(o => o.Date.Equals(date.Date) && o.I_Tag_Id == tagId && o.I_Cycle_Id == beginCycleId);
                        if (cObj != null)
                        {
                            list.Add(cObj);
                        }
                    }
                    else
                    {
                        var cMinList = cacheInfo.CMinList.FindAll(o => o.Date.Equals(date.Date) && o.I_Tag_Id == tagId &&
                            o.I_Cycle_Id >= beginCycleId && o.I_Cycle_Id <= endCycleId);
                        foreach (CTagMinuteInfo cItem in cMinList)
                        {
                            list.Add(cItem);
                        }
                    }
                }
                if (list.Count == 0)
                {
                    list = DataProvider.TagMinuteProvider.Get_By_Date_TagId_CycleId(date, tagId, beginCycleId, endCycleId);
                    foreach (TagMinuteInfo item in list)
                    {
                        //if (cacheInfo.CMinList.Exists(o => o.Date == date && o.I_Cycle_Id == item.I_Cycle_Id && o.I_Tag_Id == item.I_Tag_Id))
                        //    continue;
                        var cItem = new CTagMinuteInfo(date, item);
                        cacheInfo.CMinList.Add(cItem);
                    }
                }
                list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                if (list.Count < shouldCount)
                {
                    int cycleId = beginCycleId;
                    List<TagMinuteInfo> skipList = new List<TagMinuteInfo>();
                    foreach (TagMinuteInfo item in list)
                    {
                        if (cycleId == item.I_Cycle_Id)
                        {
                            cycleId++;
                            continue;
                        }
                        else if (cycleId < item.I_Cycle_Id)
                        {
                            var tmpList = DataProvider.TagMinuteProvider.Get_By_Date_TagId_CycleId(date, tagId, cycleId, item.I_Cycle_Id - 1);
                            foreach (TagMinuteInfo tagMinInfo in tmpList)
                            {
                                //if (cacheInfo.CMinList.Exists(o => o.Date == date && o.I_Cycle_Id == tagMinInfo.I_Cycle_Id && o.I_Tag_Id == tagMinInfo.I_Tag_Id))
                                //    continue;
                                var cItem = new CTagMinuteInfo(date, tagMinInfo);
                                cacheInfo.CMinList.Add(cItem);
                            }
                            skipList.AddRange(tmpList);
                            cycleId = item.I_Cycle_Id + 1;
                        }
                    }

                    if (cycleId <= endCycleId)
                    {
                        var tmpList = DataProvider.TagMinuteProvider.Get_By_Date_TagId_CycleId(date, tagId, cycleId, endCycleId);
                        foreach (TagMinuteInfo tagMinInfo in tmpList)
                        {
                            //if (cacheInfo.CMinList.Exists(o => o.Date == date && o.I_Cycle_Id == tagMinInfo.I_Cycle_Id && o.I_Tag_Id == tagMinInfo.I_Tag_Id))
                            //    continue;
                            var cItem = new CTagMinuteInfo(date, tagMinInfo);
                            cacheInfo.CMinList.Add(cItem);
                        }
                        skipList.AddRange(tmpList);
                    }
                    if (skipList.Count > 0)
                    {
                        list.AddRange(skipList);
                        list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                    }
                }
                //删除超出缓存大小的数据。
                if (cacheInfo.CMinList.Count > LIST_MAX_COUNT)
                    cacheInfo.CMinList.RemoveRange(0, cacheInfo.CMinList.Count - LIST_MAX_COUNT);
                return list;
            }
        }

        public static class TagMin15Provider
        {
            /// <summary>
            /// 15分钟表只有一个数据表的。从缓存取值。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <returns></returns>
            public static List<TagMin15Info> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime)
            {
                return Get_By_TagId_DateTime(tagExp, beginTime, endTime);
            }

            /// <summary>
            /// 15分钟表只有一个数据表的。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <param name="getFromCache">是否从缓存获取数据。</param>
            /// <returns></returns>
            public static List<TagMin15Info> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime, bool getFromCache)
            {
                bool isExpression = false;
                if (tagExp.Contains("[") && tagExp.Contains("]"))
                {
                    if (!tagExp.StartsWith("[") || !tagExp.EndsWith("]") || tagExp.Substring(1).Contains("["))
                    {
                        isExpression = true;
                    }
                }
                List<TagMin15Info> list = new List<TagMin15Info>();

                if (isExpression)
                {
                    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                    //watch.Reset();
                    //watch.Start();
                    //tagIds,resultList,objs 索引相对应。
                    String[] tagIds = DistinctTag(tagExp);
                    List<TagMin15Info>[] resultList = new List<TagMin15Info>[tagIds.Length];
                    for (int i = 0; i < tagIds.Length; i++)
                    {
                        if (getFromCache)
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_Cache(tagIds[i], beginTime, endTime);
                        else
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_DB(tagIds[i], beginTime, endTime);
                    }

                    IGenericExpression<double> MyExpression = DefineExpression(tagExp, tagIds);

                    int beginCycleId = Gather.DateTime2Min15CycleId(beginTime);
                    int endCycleId = Gather.DateTime2Min15CycleId(endTime);
                    bool isValid;
                    for (int cycleId = beginCycleId; cycleId <= endCycleId; cycleId++)
                    {
                        isValid = false;
                        TagMin15Info[] objs = new TagMin15Info[tagIds.Length];
                        for (int j = 0; j < tagIds.Length; j++)
                        {
                            objs[j] = resultList[j].Find(o => o.I_Cycle_Id == cycleId);
                            if (objs[j] != null) isValid = true;
                        }
                        if (isValid)
                        {
                            TagMin15Info tagMinInfo = new TagMin15Info()
                            {
                                I_Cycle_Id = cycleId,
                                I_Tag_Id = tagExp
                            };
                            double retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].I_Value_Man;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.I_Value_Man = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Begin_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Begin_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].End_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.End_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Max_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Max_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Min_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Min_Value = retValue;
                            
                            list.Add(tagMinInfo);
                        }
                    }
                    //watch.Stop();
                    //Logger.Info(String.Format("15分钟--时间：{0} ms", watch.Elapsed.Milliseconds));
                }
                else
                {
                    String tagId = tagExp.Replace("[", "").Replace("]", "");
                    if (getFromCache)
                        list = Get_By_TagId_DateTime_SingleTag_Cache(tagId, beginTime, endTime);
                    else
                        list = Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                return list;
            }

            /// <summary>
            /// 直接从数据库取值。
            /// </summary>
            private static List<TagMin15Info> Get_By_TagId_DateTime_SingleTag_DB(string tagId, DateTime beginTime, DateTime endTime)
            {
                List<TagMin15Info> list = new List<TagMin15Info>();
                int beginCycleId = Gather.DateTime2Min15CycleId(beginTime);
                int endCycleId = Gather.DateTime2Min15CycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;
                list = DataProvider.TagMin15Provider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                return list;
            }

            /// <summary>
            /// 从缓存取值，取不到再从数据库取值。
            /// </summary>
            private static List<TagMin15Info> Get_By_TagId_DateTime_SingleTag_Cache(string tagId, DateTime beginTime, DateTime endTime)
            {
                if (LIST_MAX_COUNT <= 0)
                {
                    return Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                List<TagMin15Info> list = new List<TagMin15Info>();
                int beginCycleId = Gather.DateTime2Min15CycleId(beginTime);
                int endCycleId = Gather.DateTime2Min15CycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;

                if (cacheInfo.Min15List.Count > 0)
                {
                    if (shouldCount == 1)
                    {
                        TagMin15Info obj = cacheInfo.Min15List.Find(o =>o.I_Tag_Id == tagId && o.I_Cycle_Id == beginCycleId);
                        if (obj != null)
                        {
                            list.Add(obj);
                        }
                    }
                    else
                    {
                        var min15List = cacheInfo.Min15List.FindAll(o =>o.I_Tag_Id == tagId &&
                            o.I_Cycle_Id >= beginCycleId && o.I_Cycle_Id <= endCycleId);
                        foreach (TagMin15Info min15 in min15List)
                        {
                            list.Add(min15);
                        }
                    }
                }
                if (list.Count == 0)
                {
                    list = DataProvider.TagMin15Provider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                    foreach (TagMin15Info item in list)
                    {
                        cacheInfo.Min15List.Add(item);
                    }
                }
                list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));

                if (list.Count < shouldCount)
                {
                    int cycleId = beginCycleId;
                    List<TagMin15Info> skipList = new List<TagMin15Info>();
                    foreach (TagMin15Info item in list)
                    {
                        if (cycleId == item.I_Cycle_Id)
                        {
                            cycleId++;
                            continue;
                        }
                        else if (cycleId < item.I_Cycle_Id)
                        {
                            var tmpList = DataProvider.TagMin15Provider.Get_By_TagId_CycleId(tagId, cycleId, item.I_Cycle_Id - 1);
                            foreach (TagMin15Info obj in tmpList)
                            {
                                cacheInfo.Min15List.Add(obj);
                            }
                            skipList.AddRange(tmpList);
                            cycleId = item.I_Cycle_Id + 1;
                        }
                    }

                    if (cycleId <= endCycleId)
                    {
                        var tmpList = DataProvider.TagMin15Provider.Get_By_TagId_CycleId(tagId, cycleId, endCycleId);
                        foreach (TagMin15Info obj in tmpList)
                        {
                            cacheInfo.Min15List.Add(obj);
                        }
                        skipList.AddRange(tmpList);
                    }
                    if (skipList.Count > 0)
                    {
                        list.AddRange(skipList);
                        list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                    }
                }
                //删除超出缓存大小的数据。
                if (cacheInfo.Min15List.Count > LIST_MAX_COUNT)
                    cacheInfo.Min15List.RemoveRange(0, cacheInfo.Min15List.Count - LIST_MAX_COUNT);
                return list;
            }
        }
        
        public static class TagHourProvider
        {
            /// <summary>
            /// 小时表是只有一个数据表的。从缓存取值。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <returns></returns>
            public static List<TagHourInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime)
            {
                return Get_By_TagId_DateTime(tagExp, beginTime, endTime, true);
            }
            /// <summary>
            /// 小时表是只有一个数据表的。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <param name="getFromCache">是否从缓存获取数据。</param>
            /// <returns></returns>
            public static List<TagHourInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime, bool getFromCache)
            {
                bool isExpression = false;
                if (tagExp.Contains("[") && tagExp.Contains("]"))
                {
                    if (!tagExp.StartsWith("[") || !tagExp.EndsWith("]") || tagExp.Substring(1).Contains("["))
                    {
                        isExpression = true;
                    }
                }
                List<TagHourInfo> list = new List<TagHourInfo>();

                if (isExpression)
                {
                    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                    //watch.Reset();
                    //watch.Start();
                    //tagIds,resultList,objs 索引相对应。
                    String[] tagIds = DistinctTag(tagExp);
                    List<TagHourInfo>[] resultList = new List<TagHourInfo>[tagIds.Length];
                    for (int i = 0; i < tagIds.Length; i++)
                    {
                        if (getFromCache)
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_Cache(tagIds[i], beginTime, endTime);
                        else
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_DB(tagIds[i], beginTime, endTime);
                    }

                    IGenericExpression<double> MyExpression = DefineExpression(tagExp, tagIds);
                    
                    int beginCycleId = Gather.DateTime2HourCycleId(beginTime);
                    int endCycleId = Gather.DateTime2HourCycleId(endTime);
                    bool isValid;
                    for (int cycleId = beginCycleId; cycleId <= endCycleId; cycleId++)
                    {
                        isValid = false;
                        TagHourInfo[] objs = new TagHourInfo[tagIds.Length];
                        for (int j = 0; j < tagIds.Length; j++)
                        {
                            objs[j] = resultList[j].Find(o => o.I_Cycle_Id == cycleId);
                            if (objs[j] != null) isValid = true;
                        }
                        if (isValid)
                        {
                            TagHourInfo tagMinInfo = new TagHourInfo()
                            {
                                I_Cycle_Id = cycleId,
                                I_Tag_Id = tagExp
                            };
                            double retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].I_Value_Man;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.I_Value_Man = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Begin_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Begin_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].End_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.End_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Max_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Max_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Min_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Min_Value = retValue;

                            list.Add(tagMinInfo);
                        }
                    }
                    //watch.Stop();
                    //Logger.Info(String.Format("小时--时间：{0} ms", watch.Elapsed.Milliseconds));
                }
                else
                {
                    String tagId = tagExp.Replace("[", "").Replace("]", "");
                    if (getFromCache)
                        list = Get_By_TagId_DateTime_SingleTag_Cache(tagId, beginTime, endTime);
                    else
                        list = Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                return list;
            }

            /// <summary>
            /// 直接从数据库取值。
            /// </summary>
            private static List<TagHourInfo> Get_By_TagId_DateTime_SingleTag_DB(string tagId, DateTime beginTime, DateTime endTime)
            {
                List<TagHourInfo> list = new List<TagHourInfo>();
                int beginCycleId = Gather.DateTime2HourCycleId(beginTime);
                int endCycleId = Gather.DateTime2HourCycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;
                list = DataProvider.TagHourProvider.Get_BY_TagId_CycleId(tagId, beginCycleId, endCycleId);
                return list; 
            }

            /// <summary>
            /// 从缓存取值，取不到再从数据库取值。
            /// </summary>
            private static List<TagHourInfo> Get_By_TagId_DateTime_SingleTag_Cache(string tagId, DateTime beginTime, DateTime endTime)
            {
                if (LIST_MAX_COUNT <= 0)
                {
                    return Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                List<TagHourInfo> list = new List<TagHourInfo>();
                int beginCycleId = Gather.DateTime2HourCycleId(beginTime);
                int endCycleId = Gather.DateTime2HourCycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;

                if (cacheInfo.HourList.Count > 0)
                {
                    if (shouldCount == 1)
                    {
                        TagHourInfo obj = cacheInfo.HourList.Find(o => o.I_Tag_Id == tagId && o.I_Cycle_Id == beginCycleId);
                        if (obj != null)
                        {
                            list.Add(obj);
                        }
                    }
                    else
                    {
                        var hourList = cacheInfo.HourList.FindAll(o => o.I_Tag_Id == tagId &&
                            o.I_Cycle_Id >= beginCycleId && o.I_Cycle_Id <= endCycleId);
                        foreach (TagHourInfo obj in hourList)
                        {
                            list.Add(obj);
                        }
                    }
                }
                if (list.Count == 0)
                {
                    list = DataProvider.TagHourProvider.Get_BY_TagId_CycleId(tagId, beginCycleId, endCycleId);
                    foreach (TagHourInfo item in list)
                    {
                        cacheInfo.HourList.Add(item);
                    }
                }
                list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));

                if (list.Count < shouldCount)
                {
                    int cycleId = beginCycleId;
                    List<TagHourInfo> skipList = new List<TagHourInfo>();
                    foreach (TagHourInfo item in list)
                    {
                        if (cycleId == item.I_Cycle_Id)
                        {
                            cycleId++;
                            continue;
                        }
                        else if (cycleId < item.I_Cycle_Id)
                        {
                            var tmpList = DataProvider.TagHourProvider.Get_BY_TagId_CycleId(tagId, cycleId, item.I_Cycle_Id - 1);
                            foreach (TagHourInfo obj in tmpList)
                            {
                                cacheInfo.HourList.Add(obj);
                            }
                            skipList.AddRange(tmpList);
                            cycleId = item.I_Cycle_Id + 1;
                        }
                    }

                    if (cycleId <= endCycleId)
                    {
                        var tmpList = DataProvider.TagHourProvider.Get_BY_TagId_CycleId(tagId, cycleId, endCycleId);
                        foreach (TagHourInfo obj in tmpList)
                        {
                            cacheInfo.HourList.Add(obj);
                        }
                        skipList.AddRange(tmpList);
                    }
                    if (skipList.Count > 0)
                    {
                        list.AddRange(skipList);
                        list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                    }
                }

                //删除超出缓存大小的数据。
                if (cacheInfo.HourList.Count > LIST_MAX_COUNT)
                    cacheInfo.HourList.RemoveRange(0, cacheInfo.HourList.Count - LIST_MAX_COUNT);
                return list;
            }
        }

        public static class TagDayProvider
        {
            /// <summary>
            /// 天表是只有一个数据表的。从数据库取值。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <param name="getFromCache">是否从缓存获取数据。</param>
            /// <returns></returns>
            public static List<TagDayInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime)
            {
                return Get_By_TagId_DateTime(tagExp, beginTime, endTime, true);
            }

            /// <summary>
            /// 天表是只有一个数据表的。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <param name="getFromCache">是否从缓存获取数据。</param>
            /// <returns></returns>
            public static List<TagDayInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime, bool getFromCache)
            {
                bool isExpression = false;
                if (tagExp.Contains("[") && tagExp.Contains("]"))
                {
                    if (!tagExp.StartsWith("[") || !tagExp.EndsWith("]") || tagExp.Substring(1).Contains("["))
                    {
                        isExpression = true;
                    }
                }
                List<TagDayInfo> list = new List<TagDayInfo>();

                if (isExpression)
                {
                    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                    //watch.Reset();
                    //watch.Start();
                    //tagIds,resultList,objs 索引相对应。
                    String[] tagIds = DistinctTag(tagExp);
                    List<TagDayInfo>[] resultList = new List<TagDayInfo>[tagIds.Length];
                    for (int i = 0; i < tagIds.Length; i++)
                    {
                        if(getFromCache)
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_Cache(tagIds[i], beginTime, endTime);
                        else
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_DB(tagIds[i], beginTime, endTime);
                    }

                    IGenericExpression<double> MyExpression = DefineExpression(tagExp, tagIds);

                    //int beginCycleId = Gather.DateTime2HourCycleId(beginTime);
                    //int endCycleId = Gather.DateTime2HourCycleId(endTime);
                    bool isValid;
                    //for (int cycleId = beginCycleId; cycleId <= endCycleId; cycleId++)
                    for (DateTime cycleTime = beginTime; cycleTime <= endTime; cycleTime=cycleTime.AddDays(1))
                    {
                        int cycleId = Gather.DateTime2DayCycleId(cycleTime);
                        isValid = false;
                        TagDayInfo[] objs = new TagDayInfo[tagIds.Length];
                        for (int j = 0; j < tagIds.Length; j++)
                        {
                            objs[j] = resultList[j].Find(o => o.I_Cycle_Id == cycleId);
                            if (objs[j] != null) isValid = true;
                        }
                        if (isValid)
                        {
                            TagDayInfo tagDayInfo = new TagDayInfo()
                            {
                                I_Cycle_Id = cycleId,
                                I_Tag_Id = tagExp
                            };
                            double retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].I_Value_Man;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagDayInfo.I_Value_Man = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Begin_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagDayInfo.Begin_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].End_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagDayInfo.End_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Max_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagDayInfo.Max_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Min_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagDayInfo.Min_Value = retValue;

                            list.Add(tagDayInfo);
                        }
                    }
                    //watch.Stop();
                    //Logger.Info(String.Format("天--时间：{0} ms", watch.Elapsed.Milliseconds));
                }
                else
                {
                    String tagId = tagExp.Replace("[", "").Replace("]", "");
                    if(getFromCache)
                        list = Get_By_TagId_DateTime_SingleTag_Cache(tagId, beginTime, endTime);
                    else
                        list = Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                return list;
            }

            /// <summary>
            /// 直接从数据库取值。
            /// </summary>
            private static List<TagDayInfo> Get_By_TagId_DateTime_SingleTag_DB(string tagId, DateTime beginTime, DateTime endTime)
            {
                List<TagDayInfo> list = new List<TagDayInfo>();
                int beginCycleId = Gather.DateTime2DayCycleId(beginTime);
                int endCycleId = Gather.DateTime2DayCycleId(endTime);
                int shouldCount = (int)(endTime.Subtract(beginTime).TotalDays) + 1;
                if (shouldCount <= 0) return list;
                list = DataProvider.TagDayProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                return list;
            }

            /// <summary>
            /// 从缓存取值，取不到再从数据库取值。
            /// </summary>
            private static List<TagDayInfo> Get_By_TagId_DateTime_SingleTag_Cache(string tagId, DateTime beginTime, DateTime endTime)
            {
                if (LIST_MAX_COUNT <= 0)
                {
                    return Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                List<TagDayInfo> list = new List<TagDayInfo>();
                int beginCycleId = Gather.DateTime2DayCycleId(beginTime);
                int endCycleId = Gather.DateTime2DayCycleId(endTime);
                int shouldCount = (int)(endTime.Subtract(beginTime).TotalDays) + 1;
                if (shouldCount <= 0) return list;

                if (cacheInfo.DayList.Count > 0)
                {
                    if (shouldCount == 1)
                    {
                        TagDayInfo obj = cacheInfo.DayList.Find(o => o.I_Tag_Id == tagId && o.I_Cycle_Id == beginCycleId);
                        if (obj != null)
                        {
                            list.Add(obj);
                        }
                    }
                    else
                    {
                        var dayList = cacheInfo.DayList.FindAll(o => o.I_Tag_Id == tagId &&
                            o.I_Cycle_Id >= beginCycleId && o.I_Cycle_Id <= endCycleId);
                        foreach (TagDayInfo obj in dayList)
                        {
                            list.Add(obj);
                        }
                    }
                }
                if (list.Count == 0)
                {
                    list = DataProvider.TagDayProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                    foreach (TagDayInfo item in list)
                    {
                        cacheInfo.DayList.Add(item);
                    }
                }
                list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));

                if (list.Count < shouldCount)
                {
                    int cycleId = beginCycleId;
                    List<TagDayInfo> skipList = new List<TagDayInfo>();
                    foreach (TagDayInfo item in list)
                    {
                        if (cycleId == item.I_Cycle_Id)
                        {
                            cycleId = Gather.DateTime2DayCycleId(Gather.DayCycleId2DateTime(item.I_Cycle_Id).AddDays(1));
                            continue;
                        }
                        else if (cycleId < item.I_Cycle_Id)
                        {
                            DateTime tmpEndCycleTime = Gather.DayCycleId2DateTime(item.I_Cycle_Id);
                            var tmpList = DataProvider.TagDayProvider.Get_By_TagId_CycleId(tagId, cycleId, Gather.DateTime2DayCycleId(tmpEndCycleTime.AddDays(-1)));
                            foreach (TagDayInfo obj in tmpList)
                            {
                                cacheInfo.DayList.Add(obj);
                            }
                            skipList.AddRange(tmpList);
                            cycleId = Gather.DateTime2DayCycleId(tmpEndCycleTime.AddDays(1));
                        }
                    }

                    if (cycleId <= endCycleId)
                    {
                        var tmpList = DataProvider.TagDayProvider.Get_By_TagId_CycleId(tagId, cycleId, endCycleId);
                        foreach (TagDayInfo obj in tmpList)
                        {
                            cacheInfo.DayList.Add(obj);
                        }
                        skipList.AddRange(tmpList);
                    }
                    if (skipList.Count > 0)
                    {
                        list.AddRange(skipList);
                        list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                    }
                }

                //删除超出缓存大小的数据。
                if (cacheInfo.DayList.Count > LIST_MAX_COUNT)
                    cacheInfo.DayList.RemoveRange(0, cacheInfo.DayList.Count - LIST_MAX_COUNT);
                return list;
            }
        }

        public static class TagMonthProvider
        {
            /// <summary>
            /// 月表是只有一个数据表的。从缓存取数据。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <returns></returns>
            public static List<TagMonthInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime)
            {
                return Get_By_TagId_DateTime(tagExp, beginTime, endTime, true);
            }
            /// <summary>
            /// 月表是只有一个数据表的。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <param name="getFromCache">是否从缓存获取数据。</param>
            /// <returns></returns>
            public static List<TagMonthInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime, bool getFromCache)
            {
                bool isExpression = false;
                if (tagExp.Contains("[") && tagExp.Contains("]"))
                {
                    if (!tagExp.StartsWith("[") || !tagExp.EndsWith("]") || tagExp.Substring(1).Contains("["))
                    {
                        isExpression = true;
                    }
                }
                List<TagMonthInfo> list = new List<TagMonthInfo>();

                if (isExpression)
                {
                    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                    //watch.Reset();
                    //watch.Start();
                    //tagIds,resultList,objs 索引相对应。
                    String[] tagIds = DistinctTag(tagExp);
                    List<TagMonthInfo>[] resultList = new List<TagMonthInfo>[tagIds.Length];
                    for (int i = 0; i < tagIds.Length; i++)
                    {
                        if (getFromCache)
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_Cache(tagIds[i], beginTime, endTime);
                        else
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_DB(tagIds[i], beginTime, endTime);
                    }

                    IGenericExpression<double> MyExpression = DefineExpression(tagExp, tagIds);

                    bool isValid;
                    for (DateTime cycleTime = beginTime; cycleTime <= endTime; cycleTime = cycleTime.AddMonths(1))
                    {
                        int cycleId = Gather.DateTime2MonthCycleId(cycleTime);
                        isValid = false;
                        TagMonthInfo[] objs = new TagMonthInfo[tagIds.Length];
                        for (int j = 0; j < tagIds.Length; j++)
                        {
                            objs[j] = resultList[j].Find(o => o.I_Cycle_Id == cycleId);
                            if (objs[j] != null) isValid = true;
                        }
                        if (isValid)
                        {
                            TagMonthInfo tagMonthInfo = new TagMonthInfo()
                            {
                                I_Cycle_Id = cycleId,
                                I_Tag_Id = tagExp
                            };
                            double retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].I_Value_Man;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMonthInfo.I_Value_Man = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Begin_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMonthInfo.Begin_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].End_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMonthInfo.End_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Max_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMonthInfo.Max_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Min_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMonthInfo.Min_Value = retValue;

                            list.Add(tagMonthInfo);
                        }
                    }
                    //watch.Stop();
                    //Logger.Info(String.Format("月--时间：{0} ms", watch.Elapsed.Milliseconds));
                }
                else
                {
                    String tagId = tagExp.Replace("[", "").Replace("]", "");
                    if (getFromCache)
                        list = Get_By_TagId_DateTime_SingleTag_Cache(tagId, beginTime, endTime);
                    else
                        list = Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                return list;
            }

            /// <summary>
            /// 直接从数据库取值。
            /// </summary>
            private static List<TagMonthInfo> Get_By_TagId_DateTime_SingleTag_DB(string tagId, DateTime beginTime, DateTime endTime)
            {
                List<TagMonthInfo> list = new List<TagMonthInfo>();
                int beginCycleId = Gather.DateTime2MonthCycleId(beginTime);
                int endCycleId = Gather.DateTime2MonthCycleId(endTime);
                int shouldCount = Common.CalcDiffMonths(beginTime, endTime);
                if (shouldCount <= 0) return list;
                list = DataProvider.TagMonthProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                return list;
            }
            /// <summary>
            /// 从缓存取值，取不到再从数据库取值。
            /// </summary>
            private static List<TagMonthInfo> Get_By_TagId_DateTime_SingleTag_Cache(string tagId, DateTime beginTime, DateTime endTime)
            {
                if (LIST_MAX_COUNT <= 0)
                {
                    return Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                List<TagMonthInfo> list = new List<TagMonthInfo>();
                int beginCycleId = Gather.DateTime2MonthCycleId(beginTime);
                int endCycleId = Gather.DateTime2MonthCycleId(endTime);
                int shouldCount = Common.CalcDiffMonths(beginTime, endTime);
                if (shouldCount <= 0) return list;

                if (cacheInfo.MonthList.Count > 0)
                {
                    if (shouldCount == 1)
                    {
                        TagMonthInfo obj = cacheInfo.MonthList.Find(o => o.I_Tag_Id == tagId && o.I_Cycle_Id == beginCycleId);
                        if (obj != null)
                        {
                            list.Add(obj);
                        }
                    }
                    else
                    {
                        var monthList = cacheInfo.MonthList.FindAll(o => o.I_Tag_Id == tagId &&
                            o.I_Cycle_Id >= beginCycleId && o.I_Cycle_Id <= endCycleId);
                        foreach (TagMonthInfo obj in monthList)
                        {
                            list.Add(obj);
                        }
                    }
                }
                if (list.Count == 0)
                {
                    list = DataProvider.TagMonthProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                    foreach (TagMonthInfo item in list)
                    {
                        cacheInfo.MonthList.Add(item);
                    }
                }
                list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));

                if (list.Count < shouldCount)
                {
                    int cycleId = beginCycleId;
                    List<TagMonthInfo> skipList = new List<TagMonthInfo>();
                    foreach (TagMonthInfo item in list)
                    {
                        if (cycleId == item.I_Cycle_Id)
                        {
                            cycleId = Gather.DateTime2MonthCycleId(Gather.MonthCycleId2DateTime(item.I_Cycle_Id).AddMonths(1));
                            continue;
                        }
                        else if (cycleId < item.I_Cycle_Id)
                        {
                            DateTime tmpEndCycleTime = Gather.MonthCycleId2DateTime(item.I_Cycle_Id);
                            var tmpList = DataProvider.TagMonthProvider.Get_By_TagId_CycleId(tagId, cycleId, Gather.DateTime2MonthCycleId(tmpEndCycleTime.AddMonths(-1)));
                            foreach (TagMonthInfo obj in tmpList)
                            {
                                cacheInfo.MonthList.Add(obj);
                            }
                            skipList.AddRange(tmpList);
                            cycleId = Gather.DateTime2MonthCycleId(tmpEndCycleTime.AddMonths(1));
                        }
                    }

                    if (cycleId <= endCycleId)
                    {
                        var tmpList = DataProvider.TagMonthProvider.Get_By_TagId_CycleId(tagId, cycleId, endCycleId);
                        foreach (TagMonthInfo obj in tmpList)
                        {
                            cacheInfo.MonthList.Add(obj);
                        }
                        skipList.AddRange(tmpList);
                    }
                    if (skipList.Count > 0)
                    {
                        list.AddRange(skipList);
                        list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                    }
                }

                //删除超出缓存大小的数据。
                if (cacheInfo.MonthList.Count > LIST_MAX_COUNT)
                    cacheInfo.MonthList.RemoveRange(0, cacheInfo.MonthList.Count - LIST_MAX_COUNT);
                return list;
            }
        }

        public static class TagYearProvider
        {
            /// <summary>
            /// 年表是只有一个数据表的。从缓存取数据。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <returns></returns>
            public static List<TagYearInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime)
            { 
                return Get_By_TagId_DateTime(tagExp, beginTime, endTime, true);
            }
            /// <summary>
            /// 年表是只有一个数据表的。
            /// </summary>
            /// <param name="tagExp">指标表达式。</param>
            /// <param name="beginTime">起始时间。</param>
            /// <param name="endTime">结束时间。</param>
            /// <param name="getFromCache">是否从缓存获取数据。</param>
            /// <returns></returns>
            public static List<TagYearInfo> Get_By_TagId_DateTime(String tagExp, DateTime beginTime, DateTime endTime, bool getFromCache)
            {
                bool isExpression = false;
                if (tagExp.Contains("[") && tagExp.Contains("]"))
                {
                    if (!tagExp.StartsWith("[") || !tagExp.EndsWith("]") || tagExp.Substring(1).Contains("["))
                    {
                        isExpression = true;
                    }
                }
                List<TagYearInfo> list = new List<TagYearInfo>();

                if (isExpression)
                {
                    //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                    //watch.Reset();
                    //watch.Start();
                    //tagIds,resultList,objs 索引相对应。
                    String[] tagIds = DistinctTag(tagExp);
                    List<TagYearInfo>[] resultList = new List<TagYearInfo>[tagIds.Length];
                    for (int i = 0; i < tagIds.Length; i++)
                    {
                        if (getFromCache)
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_Cache(tagIds[i], beginTime, endTime);
                        else
                            resultList[i] = Get_By_TagId_DateTime_SingleTag_DB(tagIds[i], beginTime, endTime);
                    }

                    IGenericExpression<double> MyExpression = DefineExpression(tagExp, tagIds);

                    int beginCycleId = Gather.DateTime2YearCycleId(beginTime);
                    int endCycleId = Gather.DateTime2YearCycleId(endTime);
                    bool isValid;
                    for (int cycleId = beginCycleId; cycleId <= endCycleId; cycleId++)
                    {
                        isValid = false;
                        TagYearInfo[] objs = new TagYearInfo[tagIds.Length];
                        for (int j = 0; j < tagIds.Length; j++)
                        {
                            objs[j] = resultList[j].Find(o => o.I_Cycle_Id == cycleId);
                            if (objs[j] != null) isValid = true;
                        }
                        if (isValid)
                        {
                            TagYearInfo tagMinInfo = new TagYearInfo()
                            {
                                I_Cycle_Id = cycleId,
                                I_Tag_Id = tagExp
                            };
                            double retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].I_Value_Man;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.I_Value_Man = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Begin_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Begin_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].End_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.End_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Max_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Max_Value = retValue;

                            for (int k = 0; k < tagIds.Length; k++)
                            {
                                if (objs[k] != null)
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = objs[k].Min_Value;
                                }
                                else
                                {
                                    MyExpression.Context.Variables[string.Format("x{0}", k)] = 0.0D;
                                }
                            }
                            retValue = MyExpression.Evaluate();
                            tagMinInfo.Min_Value = retValue;

                            list.Add(tagMinInfo);
                        }
                    }
                    //watch.Stop();
                    //Logger.Info(String.Format("年--时间：{0} ms", watch.Elapsed.Milliseconds));
                }
                else
                {
                    String tagId = tagExp.Replace("[", "").Replace("]", "");
                    if (getFromCache)
                        list = Get_By_TagId_DateTime_SingleTag_Cache(tagId, beginTime, endTime);
                    else
                        list = Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                return list;
            }

            /// <summary>
            /// 直接从数据库取值。
            /// </summary>
            private static List<TagYearInfo> Get_By_TagId_DateTime_SingleTag_DB(string tagId, DateTime beginTime, DateTime endTime)
            {
                List<TagYearInfo> list = new List<TagYearInfo>();
                int beginCycleId = Gather.DateTime2YearCycleId(beginTime);
                int endCycleId = Gather.DateTime2YearCycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;
                list = DataProvider.TagYearProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                return list;
            }

            /// <summary>
            /// 从缓存取值，取不到再从数据库取值。
            /// </summary>
            private static List<TagYearInfo> Get_By_TagId_DateTime_SingleTag_Cache(string tagId, DateTime beginTime, DateTime endTime)
            {
                if (LIST_MAX_COUNT <= 0)
                {
                    return Get_By_TagId_DateTime_SingleTag_DB(tagId, beginTime, endTime);
                }
                List<TagYearInfo> list = new List<TagYearInfo>();
                int beginCycleId = Gather.DateTime2YearCycleId(beginTime);
                int endCycleId = Gather.DateTime2YearCycleId(endTime);
                int shouldCount = endCycleId - beginCycleId + 1;
                if (shouldCount <= 0) return list;

                if (cacheInfo.YearList.Count > 0)
                {
                    if (shouldCount == 1)
                    {
                        TagYearInfo obj = cacheInfo.YearList.Find(o => o.I_Tag_Id == tagId && o.I_Cycle_Id == beginCycleId);
                        if (obj != null)
                        {
                            list.Add(obj);
                        }
                    }
                    else
                    {
                        var yearList = cacheInfo.YearList.FindAll(o => o.I_Tag_Id == tagId &&
                            o.I_Cycle_Id >= beginCycleId && o.I_Cycle_Id <= endCycleId);
                        foreach (TagYearInfo obj in yearList)
                        {
                            list.Add(obj);
                        }
                    }
                }
                if (list.Count == 0)
                {
                    list = DataProvider.TagYearProvider.Get_By_TagId_CycleId(tagId, beginCycleId, endCycleId);
                    foreach (TagYearInfo item in list)
                    {
                        cacheInfo.YearList.Add(item);
                    }
                }
                list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));

                if (list.Count < shouldCount)
                {
                    int cycleId = beginCycleId;
                    List<TagYearInfo> skipList = new List<TagYearInfo>();
                    foreach (TagYearInfo item in list)
                    {
                        if (cycleId == item.I_Cycle_Id)
                        {
                            cycleId++;
                            continue;
                        }
                        else if (cycleId < item.I_Cycle_Id)
                        {
                            var tmpList = DataProvider.TagYearProvider.Get_By_TagId_CycleId(tagId, cycleId, item.I_Cycle_Id - 1);
                            foreach (TagYearInfo obj in tmpList)
                            {
                                cacheInfo.YearList.Add(obj);
                            }
                            skipList.AddRange(tmpList);
                            cycleId = item.I_Cycle_Id + 1;
                        }
                    }

                    if (cycleId <= endCycleId)
                    {
                        var tmpList = DataProvider.TagYearProvider.Get_By_TagId_CycleId(tagId, cycleId, endCycleId);
                        foreach (TagYearInfo obj in tmpList)
                        {
                            cacheInfo.YearList.Add(obj);
                        }
                        skipList.AddRange(tmpList);
                    }
                    if (skipList.Count > 0)
                    {
                        list.AddRange(skipList);
                        list.Sort((a, b) => a.I_Cycle_Id.CompareTo(b.I_Cycle_Id));
                    }
                }

                //删除超出缓存大小的数据。
                if (cacheInfo.YearList.Count > LIST_MAX_COUNT)
                    cacheInfo.YearList.RemoveRange(0, cacheInfo.YearList.Count - LIST_MAX_COUNT);
                return list;
            }
        }
        #endregion
    }
}
