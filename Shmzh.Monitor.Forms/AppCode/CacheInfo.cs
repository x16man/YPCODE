using System;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms
{
    public class CacheInfo
    {
        /// <summary>
        ///  分钟表是每天一个数据表。
        /// </summary>
        private List<CTagMinuteInfo> _cMinList;
        private List<TagMin15Info> _min15List;
        private List<TagHourInfo> _hourList;
        private List<TagDayInfo> _dayList;
        private List<TagMonthInfo> _monthList;
        private List<TagYearInfo> _yearList;
              
        public List<CTagMinuteInfo> CMinList
        {
            get
            {
                if (_cMinList == null)
                    _cMinList = new List<CTagMinuteInfo>();
                return _cMinList;
            }
            set
            {
                _cMinList = value;
            }
        }

        public List<TagMin15Info> Min15List
        {
            get 
            {
                if (_min15List == null)
                    _min15List = new List<TagMin15Info>();
                return _min15List;
            }
            set
            {
                _min15List = value;
            }
        }

        public List<TagHourInfo> HourList
        {
            get
            {
                if (_hourList == null)
                    _hourList = new List<TagHourInfo>();
                return _hourList;
            }
            set { _hourList = value; }
        }

        public List<TagDayInfo> DayList
        {
            get
            {
                if (_dayList == null)
                    _dayList = new List<TagDayInfo>();
                return _dayList;
            }
            set { _dayList = value; }
        }

        public List<TagMonthInfo> MonthList
        {
            get 
            {
                if (_monthList == null)
                    _monthList = new List<TagMonthInfo>();
                return _monthList;
            }
            set { _monthList = value; }
        }

        public List<TagYearInfo> YearList
        {
            get
            {
                if (_yearList == null)
                    _yearList = new List<TagYearInfo>();
                return _yearList;
            }
            set { _yearList = value; }
        }
    }

    public class CTagMinuteInfo : TagMinuteInfo
    {
        private DateTime _date = DateTime.MaxValue.Date;

        public CTagMinuteInfo():base() { }
        public CTagMinuteInfo(DateTime date, TagMinuteInfo tagMinuteInfo)
        {
            this._date = date.Date;
            this.I_Cycle_Id = tagMinuteInfo.I_Cycle_Id;
            this.I_Tag_Id = tagMinuteInfo.I_Tag_Id;
            this.I_Value_Man = tagMinuteInfo.I_Value_Man;
            this.I_Value_Org = tagMinuteInfo.I_Value_Org;
            this.Lower_Seconds = tagMinuteInfo.Lower_Seconds;
            this.Max_Value = tagMinuteInfo.Max_Value;
            this.Min_Value = tagMinuteInfo.Min_Value;
            this.Upper_Seconds = tagMinuteInfo.Upper_Seconds;
        }
        
        public DateTime Date
        {
            get { return this._date; }
            set { this._date = value.Date; }
        }
    }
}
