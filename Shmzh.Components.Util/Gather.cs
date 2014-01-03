using System;

namespace Shmzh.Components.Util
{
    /// <summary>
    /// 生产采集方面用的功能类。
    /// 包括了一些日期与时间点ID进行转换的方法。
    /// </summary>
    public static class Gather
    {
        private static readonly DateTime BASEDATE = new DateTime(2002,1,1);
        /// <summary>
        /// 日期转换为分钟的时间Id。
        /// </summary>
        /// <param name="time">日期时间。</param>
        /// <returns>分钟的时间Id。</returns>
        public static int DateTime2MinuteCycleId(DateTime time)
        {
            return (int)(time - new DateTime(time.Year, time.Month, time.Day)).TotalMinutes;
        }
        
        /// <summary>
        /// 将日期转换为15分钟表的时间Id。
        /// </summary>
        /// <param name="time">日期时间。</param>
        /// <returns>15分钟表的时间Id。</returns>
        public static int DateTime2Min15CycleId(DateTime time)
        {
            return (int)(time - BASEDATE).TotalMinutes / 15;
        }
        /// <summary>
        /// 将15分钟的CycleId转换为DateTime。
        /// </summary>
        /// <param name="cycleId">15分钟CycleId。</param>
        /// <returns></returns>
        public static DateTime Min15CycleId2DateTime(int cycleId)
        {
            return BASEDATE.AddMinutes(15*cycleId);
        }
        /// <summary>
        /// 将日期转换为小时的时间Id。
        /// </summary>
        /// <param name="time">日期时间。</param>
        /// <returns>小时的时间Id。</returns>
        public static int DateTime2HourCycleId(DateTime time)
        {
            var retValue = (int)(time - BASEDATE).TotalHours;
            return retValue;
        }
        /// <summary>
        /// 小时cycleId转换为日期。
        /// </summary>
        /// <param name="cycleId">小时CycleId。</param>
        /// <returns>日期。</returns>
        public static DateTime HourCycleId2DateTime(int cycleId)
        {
            return BASEDATE.AddHours(cycleId);
        }
        /// <summary>
        /// 将日期转换为天的时间Id。
        /// </summary>
        /// <param name="time">日期时间。</param>
        /// <returns>天的时间Id。</returns>
        public static int DateTime2DayCycleId(DateTime time)
        {
            return int.Parse(time.ToString("yyyyMMdd"));
        }
        /// <summary>
        /// 天的cycleId转换为日期。
        /// </summary>
        /// <param name="cycleId">天的cycleId。</param>
        /// <returns></returns>
        public static DateTime DayCycleId2DateTime(int cycleId)
        {
            String str = cycleId.ToString();
            return new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6,2)));
        }
        /// <summary>
        /// 将日期转换为月的时间Id。
        /// </summary>
        /// <param name="time">日期时间。</param>
        /// <returns>月的时间Id。</returns>
        public static int DateTime2MonthCycleId(DateTime time)
        {
            return int.Parse(time.ToString("yyyyMM"));
        }
        /// <summary>
        /// 将月cycleId转化为日期。
        /// </summary>
        /// <param name="cycleId">月cycleId。</param>
        /// <returns></returns>
        public static DateTime MonthCycleId2DateTime(int cycleId)
        {
            var y = int.Parse(cycleId.ToString().Substring(0, 4));
            var m = int.Parse(cycleId.ToString().Substring(4));
            return new DateTime(y,m,1);
        }
        /// <summary>
        /// 将日期转换为年的时间Id。
        /// </summary>
        /// <param name="time">日期时间。</param>
        /// <returns>年的时间Id。</returns>
        public static int DateTime2YearCycleId(DateTime time)
        {
            return time.Year;
        }
        /// <summary>
        /// 将年CycleId转换为DateTime。
        /// </summary>
        /// <param name="cycleId">年CycleId。</param>
        /// <returns>日期</returns>
        public static DateTime YearCycleId2DateTime(int cycleId)
        {
            return new DateTime(cycleId,1,1);
        }
        /// <summary>
        /// 根据报表周期特性和日期获取对应的CycleId。
        /// </summary>
        /// <param name="cycleType">报表周期特性。</param>
        /// <param name="time">日期时间。</param>
        /// <returns>CycleId。</returns>
        public static int DateTime2CycleId(string cycleType, DateTime time)
        {
            switch(cycleType.ToUpper())
            {
                case "DAY":
                    return int.Parse(time.ToString("yyyyMMdd"));
                case "MONTH":
                    return int.Parse(time.ToString("yyyyMM"));
                case "YEAR":
                    return int.Parse(time.ToString("yyyy"));
                default:
                    return 0;
            }
        }
    }
}
