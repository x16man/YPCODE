using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
using Ciloci.Flee;

namespace Test
{
    public partial class Form1 : Form
    {
        //private IGenericExpression<double> MyExpression;
        //private ExpressionContext MyContext = new ExpressionContext();
        private Regex myRegex = new Regex("[[0-z]*]");
        private static Regex devRegex = new Regex("{[0-9|A-Z|a-z|-]*}");

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            InitializeComponent();
        }

        private void tbnQuery_Click(object sender, EventArgs e)
        {
            using (new StopwatchWriter("Query") )
            {
                var obj = DataProvider.TagProvider.GetById(this.txtTagId.Text);
                this.rtbSrc.Text = obj.ToString();
            }
        }

        private void btnRunStatus_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.RunStatusProvider.Get_Current_By_TagId(this.txtTagId.Text);
            if(obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
        }
        /// <summary>
        /// 秒数据查询。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagSecondProvider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[", string.Empty).Replace("]", string.Empty));
            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Second);
            this.txtSecond.Text = retValue.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagMinuteProvider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[",string.Empty).Replace("]",string.Empty));
            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Minute);
            this.txtMinute.Text = retValue.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagMin15Provider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[", string.Empty).Replace("]", string.Empty));
            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Min15);
            this.txtMin15.Text = retValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagHourProvider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[", string.Empty).Replace("]", string.Empty));
            //Logger.Info(obj.I_Tag_Id);

            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Hour);
            this.txtHour.Text = retValue.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagDayProvider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[", string.Empty).Replace("]", string.Empty));
            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Day);
            this.txtDay.Text = retValue.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagMonthProvider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[", string.Empty).Replace("]", string.Empty));
            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Month);
            this.txtMonth.Text = retValue.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var obj = DataProvider.TagYearProvider.Get_Latest_By_TagId(this.txtTagId.Text.Replace("[", string.Empty).Replace("]", string.Empty));
            if (obj != null)
                this.rtbSrc.Text = obj.ToString();
            else
            {
                this.rtbSrc.Text = "Null";
            }
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Year);
            this.txtYear.Text = retValue.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var obj1 = Math.Round(double.Parse(this.txtFloat.Text), int.Parse(this.txtDigNum.Text),MidpointRounding.AwayFromZero);
            var obj2 = Math.Round(double.Parse(this.txtFloat.Text), int.Parse(this.txtDigNum.Text), MidpointRounding.ToEven);
            this.txtResult1.Text= obj1.ToString();
            this.txtResult2.Text = obj2.ToString();
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Year);
            this.txtYear.Text = retValue.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //var mc = myRegex.Matches(this.txtTagId.Text);
            var mc = devRegex.Matches(this.txtTagId.Text);
            var tags = new List<string>();
            for (var i = 0; i < mc.Count; i++)
            {
                if (!tags.Contains(mc[i].ToString()))
                    tags.Add(mc[i].ToString());
            }
            var ss = tags.ToArray();
            foreach(var s in ss)
            {
                //this.rtbSrc.Text += s.Replace("[",string.Empty).Replace("]", string.Empty);
                this.rtbSrc.Text += s.Replace("{", string.Empty).Replace("}", string.Empty);
                this.rtbSrc.Text += "\r\n";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var retValue = DataProvider.GetCurrentValue(this.txtTagId.Text, DataType.Minute);
            this.rtbSrc.Text = retValue.ToString();
        }

        private void btnBool_Click(object sender, EventArgs e)
        {
            var MyContext = new ExpressionContext();
            
            //MyContext.Imports.AddType(typeof(System.Drawing.Color),"System.Drawing");
            var exp = this.txtBoolExression.Text.Replace("value", "120");

            var MyExpression = MyContext.CompileGeneric<string>(exp);

            var retValue = MyExpression.Evaluate();
            this.txtBoolResult.Text = retValue.ToString();
            
        }

        private void btnTagDay_Click(object sender, EventArgs e)
        {
            var objs = DataProvider.TagDayProvider.Get_By_TagId_DateTime("1301004", new DateTime(2006, 1, 1),
                                                                         new DateTime(2006, 5, 2));
            MessageBox.Show(objs.Count.ToString());

            objs = DataProvider.TagDayProvider.Get_By_TagId_CycleId("1301004", 20060101, 20060501);
            MessageBox.Show(objs.Count.ToString());

            objs = DataProvider.TagDayProvider.Get_OLHC_By_TagId_DateTime("1301004", new DateTime(2006, 1, 1),
                                                                         new DateTime(2006, 5, 2));
            MessageBox.Show(objs.Count.ToString());
            
            objs = DataProvider.TagDayProvider.Get_OLHC_By_Tag_CycleId("1301004", 20060101, 20060501);
            MessageBox.Show(objs.Count.ToString());

        }
        

    }
}
