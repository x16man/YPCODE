using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Shmzh.Monitor.Forms
{
    public class DailyTaskConfig
    {
        #region Fields
        private List<StateInfo> stateList = null;
        private List<PriorityInfo> priorityList = null;
        private ListConfig dayListConfig = new ListConfig();
        private ListConfig weekListConfig = new ListConfig();
        #endregion

        public List<StateInfo> StateList
        {
            get
            {
                if (stateList == null)
                    stateList = new List<StateInfo>();
                return stateList;
            }
            set { stateList = value; }
        }

        public List<PriorityInfo> PriorityList
        {
            get
            {
                if (priorityList == null)
                    priorityList = new List<PriorityInfo>();
                return priorityList;
            }
            set { priorityList = value; }
        }

        /// <summary>
        /// 24小时 列表设置。
        /// </summary>
        public ListConfig DayListConfig
        {
            get { return dayListConfig; }
            set { dayListConfig = value; }
        }

        /// <summary>
        /// 最近一周列表设置。
        /// </summary>
        public ListConfig WeekListConfig
        {
            get { return weekListConfig; }
            set { weekListConfig = value; }
        }

        public StateInfo GetStateByName(String name)
        {
            return stateList.Find(o => o.Name.Equals(name));
        }

        public PriorityInfo GetPriorityByName(String name)
        {
            return priorityList.Find(o => o.Name.Equals(name));
        }

        public String Title { get; set; }
        public String TitleFont { get; set; }
        public Single TitleFontSize { get; set; }
        public Color TitleForeColor { get; set; }
        public Boolean TitleIsBold { get; set; }

        public String LabelFont { get; set; }
        public Single LabelFontSize { get; set; }
        public Color LabelForeColor { get; set; }
        public Boolean LabelIsBold { get; set; }

        #region Classes
        public class StateInfo
        {
            public String Name { get; set; }
            public Color ForeColor { get; set; }
        }

        public class PriorityInfo
        {
            public String Name { get; set; }
            public Color BackColor { get; set; }
        }

        /// <summary>
        /// 列表设置。
        /// </summary>
        public class ListConfig
        {
            private List<Column> _columns;

            public String Title { get; set; }
            public String ProjectType { get; set; }
            public String State { get; set; }
            public Int32 Height { get; set; }
            public Int32 PgdnTime { get; set; }

            public Int32 HeaderHeight { get; set; }
            public String HeaderFont { get; set; }
            public Single HeaderFontSize { get; set; }
            public Color HeaderForeColor { get; set; }
            public Color HeaderBackColor { get; set; }
            public Boolean HeaderIsBold { get; set; }

            public String RowFont { get; set; }
            public Single RowFontSize { get; set; }
            public Boolean RowIsBold { get; set; }

            public List<Column> Columns
            {
                get { if (_columns == null) _columns = new List<Column>(); return _columns; }
                set { _columns = value; }
            }
        }

        public class Column
        {
            public String Name { get; set; }
            public String Title { get; set; }
            public bool Visible { get; set; }
        }
        #endregion
    }
}
