using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Configuration;
using System.Timers;
using MemcachedProviders.Cache;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;


namespace Shmzh.MemCache.Service
{
    public partial class gatherService : ServiceBase
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private System.Timers.Timer myTimer;
        //各种对象数据刷新的频率及延后时间.
        private int secondInterval, secondDelay;
        private int minuteInterval, minuteDelay;
        private int min15Interval, min15Delay;
        private int hourInterval, hourDelay;
        private int dayInterval, dayDelay;
        private int tagMsInterval,tagMsDelay;
        private int runStatusInterval, runStatusDelay;

        //是否已经开始刷新各对象的数据.
        private bool IsRefreshingSecond;
        private bool IsRefreshingMinute;
        private bool IsRefreshingMin15;
        private bool IsRefreshingHour;
        private bool IsRefreshingDay;
        private bool IsRefreshingTagMs;
        private bool IsRefreshingRunStatus;

        //上次执行时间.
        private DateTime lastSecondTime;
        private DateTime lastMinuteTime;
        private DateTime lastMin15Time;
        private DateTime lastHourTime;
        private DateTime lastDayTime;
        private DateTime lastTagMSTime;
        private DateTime lastRunStatusTime;
        #endregion

        #region private method
        /// <summary>
        /// 获取当前最新的秒数据。
        /// </summary>
        /// <remarks>
        /// 由于最新秒表数据的查询是根据最新的时间字段来查询的,而秒表的数据又是从几个文本文件陆续导入进来的,所以在某一时间获取的秒表数据可能是不完整的.
        /// 所以如果查询的数据时不完整的话,就不加入到缓存中.
        /// 至于如何判断是否是完整的数据则是通过前后两次查询的结果集数目来判定.
        /// 1、第一次查询,则直接加入缓存.
        /// 2、本次查询的结果集数目比上一次的多,则也加入缓存.
        /// 3、前后两次结果集的数目之差不超过100，也认为是正常的，也加入缓存之中。
        /// </remarks>
        private void GetSecondData()
        {
            this.lastSecondTime = DateTime.Now;
            this.IsRefreshingSecond = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.TagSecondProvider.Get_Latest_All();
            sw.Stop();
            Logger.Info(string.Format("Get latest TagSecond spend {0} milliseconds,count is {1}", sw.ElapsedMilliseconds, objs.Count));
            
            var oldObjs = DistCache.Get(CacheKeyEnum.LatestSecondTagData) as List<TagSecondInfo>;
            
            if (objs != null && objs.Count > 0 && (oldObjs==null || Math.Abs(objs.Count - oldObjs.Count) < 100 || objs.Count > oldObjs.Count))
            {
                DistCache.Add(CacheKeyEnum.LatestSecondTagData, objs);
                Logger.Info("秒数据加入缓存.");
            }
            else
            {
                Logger.Info("获取到的秒数据数目不满足条件,重新进行获取.");
                System.Threading.Thread.Sleep(2000);
                GetSecondData();
            }
            
            this.IsRefreshingSecond = false;
        }
        /// <summary>
        /// 获取当前最新的分钟数据。
        /// </summary>
        private void GetMinuteData()
        {
            this.lastMinuteTime = DateTime.Now;
            this.IsRefreshingMinute = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.TagMinuteProvider.Get_Latest_All();
            sw.Stop();
            Logger.Info(string.Format("Get latest TagMinute spend {0} milliseconds,count is {1}", sw.ElapsedMilliseconds, objs.Count));
            if (objs != null && objs.Count > 0)
            {
                DistCache.Add(CacheKeyEnum.LatestMinuteTagData, objs);
                Logger.Info("分钟数据加入缓存.");
            }
            
            this.IsRefreshingMinute = false;
        }
        /// <summary>
        /// 获取当前的指标清单。
        /// </summary>
        private void GetTagMSData()
        {
            this.lastTagMSTime = DateTime.Now;
            this.IsRefreshingTagMs = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.TagProvider.GetAll();
            sw.Stop();
            Logger.Info(string.Format("Get TagMS Spend {0} milliseconds", sw.ElapsedMilliseconds));
            if (objs != null && objs.Count > 0)
            {
                DistCache.Add(CacheKeyEnum.TagMS, objs);
                Logger.Info("指标清单数据加入缓存.");
            }
            this.IsRefreshingTagMs = false;
        }
        /// <summary>
        /// 获取当前的最新的15分钟.
        /// </summary>
        private void GetMin15Data()
        {
            this.lastMin15Time = DateTime.Now;
            this.IsRefreshingMin15 = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.TagMin15Provider.Get_Latest_All();
            sw.Stop();

            Logger.Info(string.Format("Get Latest Min15Tag spend {0} milliseconds", sw.ElapsedMilliseconds));
            if (objs != null && objs.Count > 0)
            {
                DistCache.Add(CacheKeyEnum.LatestMin15TagData, objs);
                Logger.Info("15分钟数据加入缓存.");
            }
            this.IsRefreshingMin15 = false;
        }
        /// <summary>
        /// 获取当前最新的小时数据.
        /// </summary>
        private void GetHourData()
        {
            this.lastHourTime = DateTime.Now;
            this.IsRefreshingHour = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.TagHourProvider.Get_Latest_All();
            sw.Stop();
            Logger.Info(string.Format("Get Latest TagHour spend {0} milliseconds", sw.ElapsedMilliseconds));
            if (objs != null && objs.Count > 0)
            {
                DistCache.Add(CacheKeyEnum.LatestHourTagData, objs);
                Logger.Info("小时数据加入缓存.");
            }
            this.IsRefreshingHour = false;
        }
        /// <summary>
        /// 获取当前最新的天数据.
        /// </summary>
        private void GetDayData()
        {
            this.lastDayTime = DateTime.Now;
            this.IsRefreshingDay = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.TagDayProvider.Get_Latest_All();
            sw.Stop();
            Logger.Info(string.Format("Get Latest TagDay Spend {0} milliseconds", sw.ElapsedMilliseconds));
            if (objs != null && objs.Count > 0)
            {
                DistCache.Add(CacheKeyEnum.LatestDayTagData, objs);
                Logger.Info("天数据加入缓存.");
            }
            this.IsRefreshingDay = false;
        }
        /// <summary>
        /// 获取当前最新的机泵运行状态.
        /// </summary>
        private void GetCurrentRunStatus()
        {
            this.lastRunStatusTime = DateTime.Now;
            this.IsRefreshingRunStatus = true;
            var sw = new Stopwatch();
            sw.Start();
            var objs = DataProvider.RunStatusProvider.Get_Current_All();
            sw.Stop();
            Logger.Info(string.Format("Get Latest RunStatus spend {0} milliseconds", sw.ElapsedMilliseconds));
            if (objs != null && objs.Count > 0)
            {
                DistCache.Add(CacheKeyEnum.CurrentRunStatus, objs);
                Logger.Info("机泵运行状态数据加入缓存.");
            }
            this.IsRefreshingRunStatus = false;
        }
        #endregion

        public gatherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.myTimer = new Timer {Interval = int.Parse(ConfigurationManager.AppSettings["TimerInterval"])};
            this.myTimer.Elapsed += myTimer_Elapsed;

            this.secondInterval = int.Parse(ConfigurationManager.AppSettings["SecondInterval"]);
            this.secondDelay = int.Parse(ConfigurationManager.AppSettings["SecondDelay"]);

            this.minuteInterval = int.Parse(ConfigurationManager.AppSettings["MinuteInterval"]);
            this.minuteDelay = int.Parse(ConfigurationManager.AppSettings["MinuteDelay"]);

            this.min15Interval = int.Parse(ConfigurationManager.AppSettings["Min15Interval"]);
            this.min15Delay = int.Parse(ConfigurationManager.AppSettings["Min15Delay"]);

            this.hourInterval = int.Parse(ConfigurationManager.AppSettings["HourInterval"]);
            this.hourDelay = int.Parse(ConfigurationManager.AppSettings["HourDelay"]);

            this.dayInterval = int.Parse(ConfigurationManager.AppSettings["DayInterval"]);
            this.dayDelay = int.Parse(ConfigurationManager.AppSettings["DayDelay"]);

            this.tagMsInterval = int.Parse(ConfigurationManager.AppSettings["TagMSInterval"]);
            this.tagMsDelay = int.Parse(ConfigurationManager.AppSettings["TagMSDelay"]);

            this.runStatusInterval = int.Parse(ConfigurationManager.AppSettings["RunStatusInterval"]);
            this.runStatusDelay = int.Parse(ConfigurationManager.AppSettings["RunStatusDelay"]);

            Logger.Info("Service Start, Load latest tag data");
            this.GetTagMSData();
            this.GetCurrentRunStatus();
            //this.GetSecondData();
            //this.GetMinuteData();
            //this.GetMin15Data();
            this.GetHourData();
            this.GetDayData();
            // Start the timer.
            this.myTimer.Enabled = true;

        }
        
        protected override void OnStop()
        {
        }

        void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            //如果当前时间点满足获取最新秒表数据事件的触发时间条件,并且当前不在进行刷新秒表数据缓存动作,则进行刷新秒表数据缓存动作.
            if (e.SignalTime.Second % this.secondInterval == this.secondDelay && this.IsRefreshingSecond == false)
            {
                this.GetSecondData();
            }
            //如果当前时间点满足获取最新分钟表数据事件的触发时间条件,并且当前不在进行刷新分钟表数据缓存动作,则进行刷新分钟表数据缓存动作.
            if (e.SignalTime.Second % this.minuteInterval == this.minuteDelay && this.IsRefreshingMinute == false)
            {
                this.GetMinuteData();
            }
            //如果当前时间点满足获取指标清单数据事件的触发时间条件,并且当前不在进行刷新指标清单数据缓存动作,则进行刷新指标清单数据缓存动作.
            if (e.SignalTime.Minute % this.tagMsInterval == this.tagMsDelay && this.IsRefreshingTagMs == false)
            {

                if (e.SignalTime.Year == this.lastTagMSTime.Year &&
                    e.SignalTime.Month == this.lastTagMSTime.Month &&
                    e.SignalTime.Day == this.lastTagMSTime.Day &&
                    e.SignalTime.Hour == this.lastTagMSTime.Hour &&
                    e.SignalTime.Minute == this.lastTagMSTime.Minute)
                {
                    //如果触发事件的时间和上次执行在同一分钟,则不作处理.
                }
                else
                {
                    this.GetTagMSData();
                }
            }
            //如果当前时间点满足获取机泵运行状态数据事件的触发时间条件,并且当前不在进行刷新机泵运行状态数据缓存动作,则进行刷新机泵运行状态数据缓存动作.
            if (e.SignalTime.Minute % this.runStatusInterval == this.runStatusDelay && this.IsRefreshingRunStatus == false)
            {
                if (e.SignalTime.Year == this.lastRunStatusTime.Year &&
                    e.SignalTime.Month == this.lastRunStatusTime.Month &&
                    e.SignalTime.Day == this.lastRunStatusTime.Day &&
                    e.SignalTime.Hour == this.lastRunStatusTime.Hour &&
                    e.SignalTime.Minute == this.lastRunStatusTime.Minute)
                {
                    //如果触发事件的时间和上次执行在同一分钟,则不作处理.
                }
                else
                {
                    this.GetCurrentRunStatus();
                }
            }
            //如果当前时间点满足获取15分钟数据事件的触发时间条件,并且当前不在进行刷新15分钟数据缓存动作,则进行刷新15分钟数据缓存动作.
            if (e.SignalTime.Minute % this.min15Interval == this.min15Delay && this.IsRefreshingMin15 == false)
            {
                if (e.SignalTime.Year == this.lastMin15Time.Year &&
                    e.SignalTime.Month == this.lastMin15Time.Month &&
                    e.SignalTime.Day == this.lastMin15Time.Day &&
                    e.SignalTime.Hour == this.lastMin15Time.Hour &&
                    e.SignalTime.Minute == this.lastMin15Time.Minute)
                {
                    //如果触发事件的时间和上次执行在同一分钟,则不作处理.
                }
                else
                {
                    //this.GetMin15Data();
                }
            }
            //如果当前时间点满足获取指小时数据事件的触发时间条件,并且当前不在进行刷新小时数据缓存动作,则进行刷新小时数据缓存动作.
            if (e.SignalTime.Minute % this.hourInterval == this.hourDelay && this.IsRefreshingHour == false)
            {
                if (e.SignalTime.Year == this.lastHourTime.Year &&
                    e.SignalTime.Month == this.lastHourTime.Month &&
                    e.SignalTime.Day == this.lastHourTime.Day &&
                    e.SignalTime.Hour == this.lastHourTime.Hour &&
                    e.SignalTime.Minute == this.lastHourTime.Minute)
                {
                    //如果触发事件的时间和上次执行在同一分钟,则不作处理.
                }
                else
                {
                    this.GetHourData();
                }
            }
            //如果当前时间点满足获取天数据事件的触发时间条件,并且当前不在进行刷新天数据缓存动作,则进行刷新天数据缓存动作.
            if (e.SignalTime.Minute % this.dayInterval == this.dayDelay && this.IsRefreshingDay == false)
            {
                if (e.SignalTime.Year == this.lastDayTime.Year &&
                    e.SignalTime.Month == this.lastDayTime.Month &&
                    e.SignalTime.Day == this.lastDayTime.Day &&
                    e.SignalTime.Hour == this.lastDayTime.Hour &&
                    e.SignalTime.Minute == this.lastDayTime.Minute)
                {
                    //如果触发事件的时间和上次执行在同一分钟,则不作处理.
                }
                else
                {
                    this.GetDayData();
                }
            }
        }

    }
}
