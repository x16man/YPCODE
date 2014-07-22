using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shmzh.Gather.DataService.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.comboBox_Tag.SelectedIndex = 0;
        }
        public class TagDataInfo
        {
            public DateTime TheTime { get; set; }
            public Double Value { get; set; }

        }

        private void button_Go_Click(object sender, EventArgs e)
        {
            var tagId = this.comboBox_Tag.Text;
            var time = this.dateTimePicker_DateTime.Value.Date;
            var theObjs = new List<TagDataInfo>();

            if(radioButton_Hour.Checked)
            {
                var beginTime = time;
                var endTime = time.AddHours(24);
                var objs = new TagService.TagService().GetHourData_By_TagId_DateTime(tagId, beginTime, endTime);
                foreach(var obj in objs)
                {
                    theObjs.Add(new TagDataInfo(){TheTime = Shmzh.Components.Util.Gather.HourCycleId2DateTime(obj.I_Cycle_Id),Value = obj.I_Value_Man });
                }
                this.dataGridView1.DataSource = theObjs;
            }
            else
            {
                var beginTime = new DateTime(time.Year,time.Month,1);
                var endTime = beginTime.AddMonths(1);
                var objs = new TagService.TagService().GetDayData_By_TagId_DateTime(tagId, beginTime, endTime);
                foreach (var obj in objs)
                {
                    theObjs.Add(new TagDataInfo() { TheTime = Shmzh.Components.Util.Gather.DayCycleId2DateTime(obj.I_Cycle_Id), Value = obj.I_Value_Man });
                }
                this.dataGridView1.DataSource = theObjs;
            }
        }
    }
}
