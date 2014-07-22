using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MemcachedProviders.Cache;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
namespace memcacheTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadTag_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagProvider.GetAll();
            DistCache.Add("TagMS", objs);
            this.lblLoadTagResult.Text = "已加入缓存！";
        }

        private void btnCheckTag_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("TagMS") as List<TagInfo>;

            this.lblCheckTagResult.Text = objs == null ? "缓存中不存在TagMS" : string.Format("缓存中存在TagMS({0})",objs.Count);
        }

        private void btnLoadSecondData_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagSecondProvider.Get_Latest_All();
            DistCache.Add("LatestSecondData", objs);
            this.lblLoadSecondData.Text = "已加入缓存！";
        }

        private void btnCheckSecondData_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestSecondData") as List<TagSecondInfo>;

            this.lblCheckSecondData.Text = objs == null ? "缓存中不存在LatestSecondData" : string.Format("缓存中存在LatestSecondData({0})", objs.Count);
        }

        private void btnLoadMinuteData_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagMinuteProvider.Get_Latest_All();
            DistCache.Add("LatestMinuteData", objs);
            this.lblLoadMinuteData.Text = "已加入缓存！";
        }

        private void btnCheckMinuteData_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestMinuteData") as List<TagMinuteInfo>;

            this.lblCheckMinuteData.Text = objs == null ? "缓存中不存在LatestMinuteData" : string.Format("缓存中存在LatestMinuteData({0})", objs.Count);
        }

        private void btnLoadMin15Data_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagMin15Provider.Get_Latest_All();
            DistCache.Add("LatestMin15Data", objs);
            this.lblLoadMin15Data.Text = "已加入缓存！";
        }

        private void btnCheckMin15Data_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestMin15Data") as List<TagMin15Info>;

            this.lblCheckMin15Data.Text = objs == null ? "缓存中不存在LatestMin15Data" : string.Format("缓存中存在LatestMin15Data({0})", objs.Count);
        }

        private void btnLoadHourData_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagHourProvider.Get_Latest_All();
            DistCache.Add("LatestHourData", objs);
            this.lblLoadHourData.Text = "已加入缓存！";
        }

        private void btnCheckHourData_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestHourData") as List<TagHourInfo>;

            this.lblCheckHourData.Text = objs == null ? "缓存中不存在LatestHourData" : string.Format("缓存中存在LatestHourData({0})", objs.Count);
        }

        private void btnLoadDayData_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagDayProvider.Get_Latest_All();
            DistCache.Add("LatestDayData", objs);
            this.lblLoadDayData.Text = "已加入缓存！";
        }

        private void btnCheckDayData_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestDayData") as List<TagDayInfo>;

            this.lblCheckDayData.Text = objs == null ? "缓存中不存在LatestDayData" : string.Format("缓存中存在LatestDayData({0})", objs.Count);
        }

        private void btnLoadMonthData_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagMonthProvider.Get_Latest_All();
            DistCache.Add("LatestMonthData", objs);
            this.lblLoadMonthData.Text = "已加入缓存！";
        }

        private void btnCheckMonthData_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestMonthData") as List<TagMonthInfo>;

            this.lblCheckMonthData.Text = objs == null ? "缓存中不存在LatestMonthData" : string.Format("缓存中存在LatestMonthData({0})", objs.Count);
        }

        private void btnLoadYearData_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagYearProvider.Get_Latest_All();
            DistCache.Add("LatestYearData", objs);
            this.lblLoadYearData.Text = "已加入缓存！";
        }

        private void btnCheckYearData_Click(object sender, EventArgs e)
        {
            var objs = DistCache.Get("LatestYearData") as List<TagYearInfo>;

            this.lblCheckYearData.Text = objs == null ? "缓存中不存在LatestYearData" : string.Format("缓存中存在LatestYearData({0})", objs.Count);
        }
    }
}
