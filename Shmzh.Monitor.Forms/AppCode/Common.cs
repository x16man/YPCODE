using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Shmzh.Monitor.Data;
using ZedGraph;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;


namespace Shmzh.Monitor.Forms
{
    public class Common
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 固定时间字符串。格式为 yyyy-M-d 或 yyyy-M-d H:m 或 yyyy-M-d H:m:s
        /// </summary>
        private static Regex fixDTRegex = new Regex(@"\d{4}-\d{1,2}-\d{1,2}( +\d{1,2}:\d{1,2}(:\d{1,2})?)?");
        /// <summary>
        /// 正则表达式。
        /// 格式MAX([指标],[开始时间],[结束时间],[获取数据的部分])。[获取数据的部分] 示例:[V]或[T]或[T|时间格式]
        /// 格式MIN([指标],[开始时间],[结束时间],[获取数据的部分])。[获取数据的部分] 示例:[V]或[T]或[T|时间格式]
        /// 格式AVG([指标],[开始时间],[结束时间],[获取数据的部分])。[获取数据的部分] 示例:[V]或[T]或[T|时间格式]
        /// 格式SUM([指标],[开始时间],[结束时间],[获取数据的部分])。[获取数据的部分] 示例:[V]或[T]或[T|时间格式]
        /// </summary>
        internal static Regex calcRegex = new Regex(@"((MAX)|(MIN)|(AVG)|(SUM))\(\[[-/\+\*\w\(\)\[\]:]+\], *\[(([-\w,:@]+)|(\d{4}-\d{1,2}-\d{1,2}( +\d{1,2}:\d{1,2}(:\d{1,2})?)?))\], *\[(([-\w,:@]+)|(\d{4}-\d{1,2}-\d{1,2}( +\d{1,2}:\d{1,2}(:\d{1,2})?)?))\](, *\[(V|(T(\|[-\w: /]+)?))\])?\)", RegexOptions.IgnoreCase);
        #endregion

        #region Property
        /// <summary>
        /// 当前登录的用户信息。
        /// </summary>
        public static Shmzh.Components.SystemComponent.User CurrentUser { get; set; }

        /// <summary>
        /// 当前日期。
        /// </summary>
        private static DateTime Today { get { return DateTime.Today; } }
        /// <summary>
        /// 当前时间。
        /// </summary>
        private static DateTime Now { get { return DateTime.Now; } }
        #endregion

        #region Class
        /// <summary>
        /// 定义时间轴的长度。
        /// 分钟取 2 小时。
        /// 15分钟取 1 天。
        /// 小时取 3 天。
        /// 天取 3 个月。
        /// 月取 8 年。
        /// 年取 全部。
        /// </summary>
        internal static class AxisLength
        {
            /// <summary>
            /// 单位：分钟。
            /// </summary>
            public static int Min = 120;
            /// <summary>
            /// 单位：15分钟。
            /// </summary>
            public static int Min15 = 96;
            /// <summary>
            /// 单位：小时。
            /// </summary>
            public static int Hour = 72;
            /// <summary>
            /// 单位：天。
            /// </summary>
            public static int Day = 90;
            /// <summary>
            /// 单位：月。
            /// </summary>
            public static int Month = 96;
        }

        /// <summary>
        /// 曲线图中数据的坐标刻度值显示格式。
        /// </summary>
        internal static class DataTypeFormat
        {
            private static String _formatMin = ConfigurationManager.AppSettings["FormatMin"] == null ? ZedGraph.Scale.Default.FormatMinuteMinute : ConfigurationManager.AppSettings["FormatMin"];
            private static String _formatMin15 = ConfigurationManager.AppSettings["FormatMin15"] == null ? ZedGraph.Scale.Default.FormatHourMinute : ConfigurationManager.AppSettings["FormatMin15"];
            private static String _formatHour = ConfigurationManager.AppSettings["FormatHour"] == null ? ZedGraph.Scale.Default.FormatDayHour : ConfigurationManager.AppSettings["FormatHour"];
            private static String _formatDay = ConfigurationManager.AppSettings["FormatDay"] == null ? ZedGraph.Scale.Default.FormatDayDay : ConfigurationManager.AppSettings["FormatDay"];
            private static String _formatMonth = ConfigurationManager.AppSettings["FormatMonth"] == null ? ZedGraph.Scale.Default.FormatYearMonth : ConfigurationManager.AppSettings["FormatMonth"];
            private static String _formatYear = ConfigurationManager.AppSettings["FormatYear"] == null ? ZedGraph.Scale.Default.FormatYearYear : ConfigurationManager.AppSettings["FormatYear"];

            public static String FormatMin { get { return _formatMin; } }
            public static String FormatMin15 { get { return _formatMin15; } }
            public static String FormatHour { get { return _formatHour; } }
            public static String FormatDay { get { return _formatDay; } }
            public static String FormatMonth { get { return _formatMonth; } }
            public static String FormatYear { get { return _formatYear; } }
        }

        internal class TimeSpanValue
        {
            public TimeSpanValue() { }

            public TimeSpanValue(DateTime beginTime, DateTime endTime, String pointTime, double pointValue, String valueType)
            {
                this.BeginTime = beginTime;
                this.EndTime = endTime;
                this.PointTime = pointTime;
                this.PointValue = pointValue;
                this.ValueType = valueType;
            }

            public DateTime BeginTime { get; set; }
            public DateTime EndTime { get; set; }
            public String PointTime { get; set; }
            public double PointValue { get; set; }

            /// <summary>
            /// V:表示值(PointValue),T:表示时间(PointTime)。
            /// </summary>
            public String ValueType { get; set; } 
        }
        #endregion

        #region Method

        /// <summary>
        /// 获取曲线图实时的X轴的最大时间值。       
        /// </summary>
        /// <param name="strDataType"></param>
        /// <returns></returns>
        public static DateTime GetReelTimeXAxisMaxTime(String strDataType)
        {
            switch (strDataType)
            {
                case "Min":
                    //当前小时的最后一分钟(第59分钟)。
                    return Today.AddHours(Now.Hour + 1).AddMinutes(-1);
                case "Min15":
                    //当前小时的最后一刻钟(第45分钟)。
                    return Today.AddHours(Now.Hour + 1).AddMinutes(-15);
                case "Hour":
                    //当天的最后一小时(第23小时)。
                    return Today.AddDays(1).AddHours(-1);
                case "Day":
                    //当月的最后一天。
                    return (new DateTime(Today.Year, Today.Month, 1)).AddMonths(1).AddDays(-1);
                case "Month":
                    //当年的最后一月。
                    return (new DateTime(Today.Year, 1, 1)).AddYears(1).AddMonths(-1);
                case "Year":
                    return (new DateTime(Today.Year, 1, 1)).AddYears(1);
                default:
                    return Today.AddDays(1);
            }
        }

        /// <summary>
        /// 获取曲线图查看历史时的X轴的最大时间值。
        /// </summary>
        /// <param name="strDataType"></param>
        /// <returns></returns>
        public static DateTime GetHistoricalXAxisMaxTime(String strDataType)
        {
            switch (strDataType)
            {
                case "Min":
                    return new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, 1);
                case "Min15":
                    return new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute / 15 * 15, 1);
                case "Hour":
                    return new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 1, 1);
                case "Day":
                    return Today;
                case "Month":
                    return new DateTime(Today.Year, Today.Month, 1);
                case "Year":
                    return new DateTime(Today.Year, 1, 1);
                default:
                    return Now;
            }
        }

        /// <summary>
        /// 获取曲线图X轴的最小时间值。根据时间轴的最大值，确定时间轴的最小值。 
        /// </summary>
        /// <param name="xAxisMaxTime">曲线图X轴的最大时间值。</param>
        /// <param name="strDataType"></param>
        /// <returns></returns>
        public static DateTime GetXAxisMinTime(DateTime xAxisMaxTime, String strDataType)
        {
            switch (strDataType)
            {
                case "Min":
                    return xAxisMaxTime.AddMinutes((-1) * AxisLength.Min);
                case "Min15":
                    return xAxisMaxTime.AddMinutes((-1) * 15 * AxisLength.Min15);
                case "Hour":
                    return xAxisMaxTime.AddHours((-1) * AxisLength.Hour);
                case "Day":
                    return xAxisMaxTime.AddDays((-1) * AxisLength.Day);
                case "Month":
                    return xAxisMaxTime.AddMonths((-1) * AxisLength.Month);
                case "Year":
                    DateTime dt = new DateTime(2000, 1, 1);
                    if(DateTime.Today.Year - dt.Year > 60)
                        dt = new DateTime(DateTime.Today.Year - 60, 1, 1);
                    return dt;
                default:
                    return xAxisMaxTime.AddDays(-1);
            }
        }
        
        /// <summary>
        /// 绑定数据类型列表。
        /// <param name="cbDataType">ComboBox 控件</param>
        /// <param name="isIncludeSecond">是否包含秒。</param>
        /// </summary>
        public static void BindTagDataType(ComboBox cbDataType, Boolean isIncludeSecond)
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            if (isIncludeSecond) 
            { 
                list.Add(new DictionaryEntry("秒", "Second")); 
            }
            list.AddRange(new List<DictionaryEntry> {
                             new DictionaryEntry("分钟", "Min"),
                             new DictionaryEntry("15分钟", "Min15"),
                             new DictionaryEntry("小时", "Hour"),
                             new DictionaryEntry("天", "Day"),
                             new DictionaryEntry("月", "Month"),
                             new DictionaryEntry("年", "Year")
                         });
            cbDataType.ValueMember = "Value";
            cbDataType.DisplayMember = "Key";
            cbDataType.DataSource = list;
        }

        /// <summary>
        /// 获取默认更新时间(单位：秒)。
        /// </summary>
        /// <param name="strDataType"></param>
        /// <returns></returns>
        public static int GetUpdateTime(String strDataType)
        {
            switch (strDataType)
            {
                case "Second":
                    return 10;
                case "Min":
                    return 60;
                case "Min15":
                    return 60 * 15;
                case "Hour":
                    return 60 * 60;
                case "Day":
                case "Month":
                case "Year":
                    return 60 * 60 * 24;
                default:
                    return 60 * 60;
            }
        }

        /// <summary>
        /// 获取时间类型名称。
        /// </summary>
        /// <param name="strDataType"></param>
        /// <returns></returns>
        public static String GetDataTypeName(String strDataType)
        {
            switch (strDataType)
            {
                case "Second":
                    return "秒";
                case "Min":
                    return "分钟";
                case "Min15":
                    return "15分钟";
                case "Hour":
                    return "小时";
                case "Day":
                    return "天";
                case "Month":
                    return "月";
                case "Year":
                    return "年";
                default:
                    return "分钟";
            }
        }

        /// <summary>
        /// 绑定曲线类型列表。
        /// </summary>
        public static void BindCurveType(ComboBox cbCurveType)
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry(GetCurveName("Bar"), "Bar"));
            list.Add(new DictionaryEntry(GetCurveName("Curve"), "Curve"));
            list.Add(new DictionaryEntry(GetCurveName("CurveMA"), "CurveMA"));
            list.Add(new DictionaryEntry(GetCurveName("JapaneseCandleStick"), "JapaneseCandleStick"));
            cbCurveType.DisplayMember = "Key";
            cbCurveType.ValueMember = "Value";
            cbCurveType.DataSource = list;
        }

        public static String GetCurveName(String strCurve)
        {
            switch (strCurve)
            {
                case "Bar":
                    return "柱状图";
                case "Curve":
                    return "曲线图";
                case "CurveMA":
                    return "移动平均线";
                case "JapaneseCandleStick":
                    return "K 线图";                
                default:
                    return "";
            }
        }

        public static List<String> GetDataTypeTest(DateTime oldTime, DateTime newTime)
        {
            List<String> dataTypeTest = new List<String>(7);
            //TimeSpan ts = oldTime.Subtract(newTime).Duration();
            if (oldTime.Year != newTime.Year)
            {
                dataTypeTest.AddRange(new[] { "Year", "Month", "Day", "Hour", "Min15", "Min", "Second" });
            }
            else if (oldTime.Month != newTime.Month)
            {
                dataTypeTest.AddRange(new[] { "Month", "Day", "Hour", "Min15", "Min", "Second" });
            }
            else if (oldTime.Day != newTime.Day)
            {
                dataTypeTest.AddRange(new[] { "Day", "Hour", "Min15", "Min", "Second" });
            }
            else if (oldTime.Hour != newTime.Hour)
            {
                dataTypeTest.AddRange(new[] { "Hour", "Min15", "Min", "Second" });
            }
            else if (oldTime.Minute / 15 != newTime.Minute / 15)
            {
                dataTypeTest.AddRange(new[] { "Min15", "Min", "Second" });
            }
            else if (oldTime.Minute != newTime.Minute)
            {
                dataTypeTest.AddRange(new[] { "Min", "Second" });
            }
            else if (oldTime.Second != newTime.Second)
            {
                dataTypeTest.AddRange(new[] { "Second" });
            }

            return dataTypeTest;
        }

        /// <summary>
        /// 计算时间。
        /// </summary>
        /// <param name="strDateTime">表达式中的时间字符串。</param>
        /// <param name="baseDateTime">如果是变动时间，变动时间的基准时间。</param>
        /// <returns></returns>
        public static DateTime CalcDateTime(String strDateTime, DateTime baseDateTime)
        {
            DateTime dateTime;
            strDateTime = strDateTime.Replace("[", "").Replace("]", "");
            try
            {
                if (fixDTRegex.IsMatch(strDateTime)) //如果是固定时间。
                {
                    dateTime = Convert.ToDateTime(fixDTRegex.Match(strDateTime).Value);
                }
                else //如果是随坐标轴最大值变动的时间。
                {
                    dateTime = baseDateTime;
                    String[] a1 = strDateTime.Split(',');
                    foreach (String s in a1)
                    {
                        String[] a2 = s.Split(':');
                        String added = a2[1];
                        int num;
                        bool isFixed = false;
                        if (added.StartsWith("@"))
                        {
                            isFixed = true;
                            num = Convert.ToInt32(added.Substring(1));
                        }
                        else
                        {
                            num = Convert.ToInt32(added);
                        }
                        switch (a2[0])
                        {
                            case "Y":
                            case "y":                                
                                dateTime = dateTime.AddYears(Convert.ToInt32(added));
                                break;
                            case "M":
                                if (isFixed)
                                    dateTime = dateTime.AddMonths(num - dateTime.Month);
                                else
                                    dateTime = dateTime.AddMonths(num);
                                break;
                            case "D":
                            case "d":
                                if (isFixed)
                                    dateTime = dateTime.AddDays(num - dateTime.Day);
                                else
                                    dateTime = dateTime.AddDays(num);
                                break;
                            case "H":
                            case "h":
                                if (isFixed)
                                    dateTime = dateTime.AddHours(num - dateTime.Hour);
                                else
                                    dateTime = dateTime.AddHours(num);
                                break;
                            case "m":
                                if (isFixed)
                                    dateTime = dateTime.AddMinutes(num - dateTime.Minute);
                                else
                                    dateTime = dateTime.AddMinutes(num);
                                break;
                            case "S":
                            case "s":
                                if (isFixed)
                                    dateTime = dateTime.AddSeconds(num - dateTime.Second);
                                else
                                    dateTime = dateTime.AddSeconds(num);
                                break;
                        }
                    }
                }
            }
            catch
            {
                Logger.Error(String.Format("{0} 时间格式错误，程序中以坐标轴最大时间替代，请及时改正。", strDateTime));
                dateTime = baseDateTime;
            }
            return dateTime;
        }

        /// <summary>
        /// 计算单个聚合函数的值。
        /// </summary>
        /// <param name="strDataType"></param>
        /// <param name="tmpExp">公式字符串。</param>
        /// <param name="baseDateTime"></param>
        /// <returns></returns>
        internal static TimeSpanValue CalcFunc(String strDataType, String tmpExp, DateTime baseDateTime)
        {
            double calcValue = double.NaN;
            int year, month, day, hour, minute, second, millisecond;
            String func = tmpExp.Substring(0, tmpExp.IndexOf('(')).ToUpper();
            tmpExp = tmpExp.Substring(tmpExp.IndexOf('('));
            tmpExp = tmpExp.Substring(1, tmpExp.Length - 2);

            Regex tempRegex = new Regex(@"\] *, *\[");
            var matches = tempRegex.Matches(tmpExp);
            int parmsCount = matches.Count + 1;
            String[] tmpArray = new String[parmsCount];
            tmpArray[0] = tmpExp.Substring(0, matches[0].Index + 1);
            tmpArray[1] = tmpExp.Substring(matches[0].Index + matches[0].Length - 1, matches[1].Index + 2 - (matches[0].Index + matches[0].Length));
            if (parmsCount == 3)
            {
                tmpArray[2] = tmpExp.Substring(matches[1].Index + matches[1].Length - 1);
            }
            else
            {
                tmpArray[2] = tmpExp.Substring(matches[1].Index + matches[1].Length - 1, matches[2].Index + 2 - (matches[1].Index + matches[1].Length));
                tmpArray[3] = tmpExp.Substring(matches[2].Index + matches[2].Length - 1);
            }

            String tmpTag = tmpArray[0].Trim();
            tmpTag = tmpTag.Substring(1, tmpTag.Length - 2);//去掉第一个"["及最后一个"]"。
            DateTime beginTime = Common.CalcDateTime(tmpArray[1].Trim(), baseDateTime);
            DateTime endTime = Common.CalcDateTime(tmpArray[2].Trim(), baseDateTime);

            String rtnType = "V";
            String rtnTypeFormat = "";
            if (tmpArray.Length == 4)
            {
                String tmpStr = tmpArray[3].Trim().Replace("[","").Replace("]","");
                String[] a1 = tmpStr.Split('|');
                rtnType = a1[0];
                if (a1.Length == 2)
                {
                    rtnTypeFormat = a1[1];
                }
            }

            DateTime pointTime = endTime;

            PointPairList ppl = new PointPairList();
            StockPointList spl = new StockPointList();
            String tmpType = "V";

            bool isJapaneseCandleStick = false;
            if (tmpTag.Contains(":"))
            {
                var arr = tmpTag.Split(':');
                tmpTag = arr[0];
                tmpType = arr[1].ToUpper();
                if (tmpType != "V")
                    isJapaneseCandleStick = true;
            }

            Common.GetGraphData(strDataType, beginTime, endTime, tmpTag, isJapaneseCandleStick, ref ppl, ref spl, true);

            if (isJapaneseCandleStick && spl.Count > 0)
            {
                double maxValue = double.MinValue;
                double minValue = double.MaxValue;
                double maxValueX = double.NaN;
                double minValueX = double.NaN;
                double total = 0.0;
                switch (tmpType)
                {
                    case "O":
                        foreach (var pt in spl)
                        {
                            total += pt.Open;
                            if (minValue > pt.Open)
                            {
                                minValue = pt.Open;
                                minValueX = pt.X;
                            }
                            if (maxValue < pt.Open)
                            {
                                maxValue = pt.Open;
                                maxValueX = pt.X;
                            }
                        }
                        break;
                    case "C":
                        foreach (var pt in spl)
                        {
                            total += pt.Close;
                            if (minValue > pt.Close)
                            {
                                minValue = pt.Close;
                                minValueX = pt.X;
                            }
                            if (maxValue < pt.Close)
                            {
                                maxValue = pt.Close;
                                maxValueX = pt.X;
                            }
                        }
                        break;
                    case "H":
                        foreach (var pt in spl)
                        {
                            total += pt.High;
                            if (minValue > pt.High)
                            {
                                minValue = pt.High;
                                minValueX = pt.X;
                            }
                            if (maxValue < pt.High)
                            {
                                maxValue = pt.High;
                                maxValueX = pt.X;
                            }
                        }
                        break;
                    case "L":
                        foreach (var pt in spl)
                        {
                            total += pt.LowValue;
                            if (minValue > pt.LowValue)
                            {
                                minValue = pt.LowValue;
                                minValueX = pt.X;
                            }
                            if (maxValue < pt.LowValue)
                            {
                                maxValue = pt.LowValue;
                                maxValueX = pt.X;
                            }
                        }
                        break;
                    default:
                        foreach (var pt in spl)
                        {
                            total += pt.Y;
                            if (minValue > pt.Y)
                            {
                                minValue = pt.Y;
                                minValueX = pt.X;
                            }
                            if (maxValue < pt.Y)
                            {
                                maxValue = pt.Y;
                                maxValueX = pt.X;
                            }
                        }
                        break;
                }
                
                switch (func)
                {
                    case "MAX":
                        calcValue = maxValue;
                        XDate.XLDateToCalendarDate(maxValueX, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        pointTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        break;
                    case "MIN":
                        calcValue = minValue;
                        XDate.XLDateToCalendarDate(minValueX, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        pointTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        break;
                    case "AVG":
                        calcValue = total / spl.Count;
                        break;
                    case "SUM":
                        calcValue = total;
                        break;
                }
            }
            else if (ppl.Count > 0)
            {
                double total = 0.0;
                foreach (var pt in ppl)
                {
                    total += pt.Y;
                }
                ppl.Sort(SortType.YValues);
                switch (func)
                {
                    case "MAX":
                        calcValue = ppl[ppl.Count - 1].Y;
                        XDate.XLDateToCalendarDate(ppl[ppl.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        pointTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        break;
                    case "MIN":
                        calcValue = ppl[0].Y;
                        XDate.XLDateToCalendarDate(ppl[0].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        pointTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        break;
                    case "AVG":
                        calcValue = total / ppl.Count;
                        break;
                    case "SUM":
                        calcValue = total;
                        break;
                }
            }

            String strPointTime;
            if (rtnTypeFormat.Length > 0)
            {
                strPointTime = pointTime.ToString(rtnTypeFormat);
            }
            else
            {
                strPointTime = pointTime.ToString();
            }
            if (Double.IsNaN(calcValue) || Double.IsInfinity(calcValue) || (calcValue == Double.MinValue) || (calcValue == Double.MaxValue))
                calcValue = 0d;
            return (new TimeSpanValue(beginTime, endTime, strPointTime, calcValue, rtnType));
        }

        /// <summary>
        /// 计算两个时间点之间相差的月数，包含开始和结束时间点的月份。
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int CalcDiffMonths(DateTime beginTime, DateTime endTime)
        {
            if (new DateTime(beginTime.Year, beginTime.Month, 1) > new DateTime(endTime.Year, endTime.Month, 1))
                return 0;
            int year = endTime.Year - beginTime.Year;
            int month = endTime.Month - beginTime.Month;
            if (endTime.Month < beginTime.Month)
            {
                year--;
                month += 12;
            }
            return (year * 12 + month + 1);
        }

        /// <summary>
        /// 获取分钟表数据，当时间区间跨两天时，拆开进行取值，因为分钟表是一天一张数据表的。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="tagId"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static PointPairList Get_By_Date_TagId_DateTime_Min(DateTime date, string tagId, DateTime beginTime, DateTime endTime)
        {
            PointPairList pointPairList = new PointPairList();
            PointPair pointPair;
            List<TagMinuteInfo> list;
            if (beginTime.Day == endTime.Day)
            {
                list = CacheProvider.TagMinuteProvider.Get_By_Date_TagId_DateTime(date, tagId, beginTime, endTime);
                foreach (var entity in list)
                {
                    pointPair = new PointPair();
                    pointPair.Y = entity.I_Value_Man;
                    pointPair.X = (double)new XDate(beginTime.Date.AddMinutes(entity.I_Cycle_Id));
                    pointPairList.Add(pointPair);
                }
            }
            else
            {
                DateTime tempTime = beginTime.Date.AddDays(1).AddMinutes(-1);
                list = CacheProvider.TagMinuteProvider.Get_By_Date_TagId_DateTime(date, tagId, beginTime, tempTime);
                foreach (var entity in list)
                {
                    pointPair = new PointPair();
                    pointPair.Y = entity.I_Value_Man;
                    pointPair.X = (double)new XDate(beginTime.Date.AddMinutes(entity.I_Cycle_Id));
                    pointPairList.Add(pointPair);
                }

                tempTime = endTime.Date;
                list = CacheProvider.TagMinuteProvider.Get_By_Date_TagId_DateTime(tempTime, tagId, tempTime, endTime);
                foreach (var entity in list)
                {
                    pointPair = new PointPair();
                    pointPair.Y = entity.I_Value_Man;
                    pointPair.X = (double)new XDate(endTime.Date.AddMinutes(entity.I_Cycle_Id));
                    pointPairList.Add(pointPair);
                }
            }
            return pointPairList;
        }

        /// <summary>
        /// 从缓存或数据库取数据。
        /// </summary>        
        public static void GetGraphData(String strDataType, DateTime beginTime, DateTime endTime, String tagId, bool isJapaneseCandleStick, ref PointPairList pointPairList, ref StockPointList spl, bool getFromCache)
        {
            if (beginTime.CompareTo(new DateTime(2002, 1, 1)) < 0)
                beginTime = new DateTime(2002, 1, 1);
            if (endTime.CompareTo(DateTime.Now) > 0)
                endTime = DateTime.Now;
            //if (beginTime.CompareTo(endTime) > 0)
            //    beginTime = endTime;
            if (beginTime.CompareTo(endTime) > 0)
                return;

            PointPair pointPair;
            switch (strDataType)
            {
                case "Min":
                    pointPairList = Common.Get_By_Date_TagId_DateTime_Min(beginTime, tagId, beginTime, endTime);
                    break;
                case "Min15":
                    var min15List = CacheProvider.TagMin15Provider.Get_By_TagId_DateTime(tagId, beginTime, endTime, getFromCache);
                    foreach (var entity in min15List)
                    {
                        var x = (double)new XDate(Gather.Min15CycleId2DateTime(entity.I_Cycle_Id));
                        if (isJapaneseCandleStick)
                        {
                            var pt = new StockPt(x, entity.Max_Value, entity.Min_Value, entity.Begin_Value, entity.End_Value, entity.I_Value_Man);
                            spl.Add(pt);
                        }
                        else
                        {
                            pointPair = new PointPair { X = x, Y = entity.I_Value_Man };
                            pointPairList.Add(pointPair);
                        }
                    }
                    break;
                case "Hour":
                    var hourList = CacheProvider.TagHourProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime, getFromCache);
                    foreach (var entity in hourList)
                    {
                        var x = (double)new XDate(Gather.HourCycleId2DateTime(entity.I_Cycle_Id));
                        if (isJapaneseCandleStick)
                        {
                            var pt = new StockPt(x, entity.Max_Value, entity.Min_Value, entity.Begin_Value, entity.End_Value, entity.I_Value_Man);
                            spl.Add(pt);
                        }
                        else
                        {
                            pointPair = new PointPair { X = x, Y = entity.I_Value_Man };
                            pointPairList.Add(pointPair);
                        }
                    }
                    break;
                case "Day":
                    var dayList = CacheProvider.TagDayProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime, getFromCache);
                    foreach (var entity in dayList)
                    {
                        var x = (double)new XDate(Gather.DayCycleId2DateTime(entity.I_Cycle_Id));
                        if (isJapaneseCandleStick)
                        {
                            var pt = new StockPt(x, entity.Max_Value, entity.Min_Value, entity.Begin_Value, entity.End_Value, entity.I_Value_Man);
                            spl.Add(pt);
                        }
                        else
                        {
                            pointPair = new PointPair { X = x, Y = entity.I_Value_Man };
                            pointPairList.Add(pointPair);
                        }
                    }
                    break;
                case "Month":
                    var monthList = CacheProvider.TagMonthProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime, getFromCache);
                    foreach (var entity in monthList)
                    {
                        var x = (double)new XDate(Gather.MonthCycleId2DateTime(entity.I_Cycle_Id));
                        if (isJapaneseCandleStick)
                        {
                            var pt = new StockPt(x, entity.Max_Value, entity.Min_Value, entity.Begin_Value, entity.End_Value, entity.I_Value_Man);
                            spl.Add(pt);
                        }
                        else
                        {
                            pointPair = new PointPair { X = x, Y = entity.I_Value_Man };
                            pointPairList.Add(pointPair);
                        }
                    }
                    break;
                case "Year":
                    var yearList = CacheProvider.TagYearProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime, getFromCache);
                    foreach (var entity in yearList)
                    {
                        var x = (double)new XDate(Gather.YearCycleId2DateTime(entity.I_Cycle_Id));
                        if (isJapaneseCandleStick)
                        {
                            var pt = new StockPt(x, entity.Max_Value, entity.Min_Value, entity.Begin_Value, entity.End_Value, entity.I_Value_Man);
                            spl.Add(pt);
                        }
                        else
                        {
                            pointPair = new PointPair { X = x, Y = entity.I_Value_Man };
                            pointPairList.Add(pointPair);
                        }
                    }
                    break;
            }
        }
      
        /// <summary>
        /// 获取当前用户是否超级用户。
        /// </summary>
        /// <returns></returns>
        public static bool GetIsSuperUser()
        {
            bool isSuper = false;
            if (CurrentUser != null)
            {
                if (CurrentUser.LoginName.ToLower() == "administrator")
                    isSuper = true;
            }
            return isSuper;
        }
        #endregion
    }
}
