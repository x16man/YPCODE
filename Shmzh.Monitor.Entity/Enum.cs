namespace Shmzh.Monitor.Entity
{
    public enum DataType
    {
        Second,Minute,Min15,Hour,Day,Month,Year
    }

    public enum TabType:byte 
    {
        /// <summary>
        /// 相关指标。
        /// </summary>
        RelativeTag = 0
    }    

    public sealed class CacheKeyEnum
    {
        /// <summary>
        /// 指标缓存的Key名称。
        /// </summary>
        public const string TagMS = "TagMS";

        public const string TagGather = "TagGather";

        public const string LatestSecondTagData = "LatestSecondTagData";

        public const string LatestMinuteTagData = "LatestMinuteTagData";

        public const string LatestMin15TagData = "LatestMin15TagData";

        public const string LatestHourTagData = "LatestHourTagData";

        public const string LatestDayTagData = "LatestDayTagData";

        public const string LatestMonthTagData = "LatestMonthTagData";

        public const string LatestYearTagData = "LatestYearTagData";

        public const string CurrentRunStatus = "CurrentRunStatus";
    }
}