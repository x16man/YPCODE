using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Test
{
    public partial class Form3 : Form
    {
        private int x=0;
        private DateTime xDate = DateTime.Today;
        public Form3()
        {
            InitializeComponent();
            this.zedGraphControl1.Dock = DockStyle.Fill;
            this.zedGraphControl1.GraphPane.XAxis.Type = AxisType.Date;
            this.zedGraphControl1.InitFromConfig();
            var t = new Timer();
            t.Interval = 30;
            t.Tick += new EventHandler(t_Tick);
            //t.Enabled = true;
            
            CreateGraph();
            //t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            var y = Math.Sin(new XDate(xDate)*Math.PI/15.0);
            if(this.zedGraphControl1.GraphPane.CurveList.Count > 0)
            {
                //x++;
                xDate = xDate.AddMinutes(5);
                if(new XDate(xDate) >= this.zedGraphControl1.GraphPane.XAxis.Scale.Max)
                {
                    var k = this.zedGraphControl1.GraphPane.XAxis.Scale.Max -
                            this.zedGraphControl1.GraphPane.XAxis.Scale.Min;

                    this.zedGraphControl1.GraphPane.XAxis.Scale.Min = this.zedGraphControl1.GraphPane.XAxis.Scale.Max;
                    this.zedGraphControl1.GraphPane.XAxis.Scale.Max += k;
                    
                }

                //this.zedGraphControl1.GraphPane.CurveList[0].AddPoint(new PointPair(x,y));
                this.zedGraphControl1.GraphPane.CurveList[0].AddPoint(new PointPair(new XDate(xDate),y));
                this.zedGraphControl1.GraphPane.AxisChange();
                this.zedGraphControl1.Invalidate();
                
            }
            else
            {
                this.Text = "Noe Curve List";
            }
        }
        private void CreateGraph()
        {
            var list = new PointPairList();
            
            this.zedGraphControl1.GraphPane.XAxis.Scale.Min = new XDate(DateTime.Today);
            this.zedGraphControl1.GraphPane.XAxis.Scale.Max = new XDate(DateTime.Today.AddHours(60));
            this.zedGraphControl1.GraphPane.YAxis.Scale.Min = 0.6;
            this.zedGraphControl1.GraphPane.YAxis.Scale.Max = 1.1;
            var myCurve = this.zedGraphControl1.GraphPane.AddCurve("test", list, Color.BlueViolet);
            
            myCurve.Symbol.Type = SymbolType.None;
            myCurve.Line.IsSmooth = true;
            myCurve.Line.IsAntiAlias = true;
            myCurve.Line.IsOptimizedDraw = true;
            myCurve.Line.Width = 2;
            this.zedGraphControl1.GraphPane.AxisChange();
            
        }
    }
}
