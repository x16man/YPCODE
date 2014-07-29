using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Shmzh.Monitor.Gadget
{
    public class PieInfo : BaseInfo
    {
        #region Field
        private ZedGraphControl graph;
        private TitleInfo _title;
        private LegendInfo _legend;
        private FillInfo _chartFillInfo;
        private FillInfo _paneFillInfo;
        private List<ItemInfo> _itemList;
        private BorderInfo _border;
        #endregion

        public PieInfo()
        {
            graph = new ZedGraphControl();
            _title = new TitleInfo();
            _legend = new LegendInfo();
            _chartFillInfo = new FillInfo();
            _paneFillInfo = new FillInfo();
            _itemList = new List<ItemInfo>();
            _border = new BorderInfo() { Visible = true, Color = Color.Black, Width = 1.0f };
        }

        ~PieInfo()
        {
            graph.Dispose();
        }

        #region Property
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        
        public TitleInfo Title { get { return _title; } set { _title = value; } }
        public LegendInfo Legend { get { return _legend; } set { _legend = value; } }
        public List<ItemInfo> ItemList { get { return _itemList; } set { _itemList = value; } }
        public FillInfo ChartFillInfo { get { return _chartFillInfo; } set { _chartFillInfo = value; } }
        public FillInfo PaneFillInfo { get { return _paneFillInfo; } set{ _paneFillInfo = value;} }
        public BorderInfo Border { get { return _border; } set { _border = value; } }
        #endregion

        #region Method
        /// <summary>
        /// 输出。
        /// </summary>
        /// <param name="control"></param>
        public void Render(Control control)
        {
            graph.Size = new Size(Width, Height);
            graph.Location = new Point(X, Y);
            graph.BackColor = Color.Transparent;
            control.Controls.Add(graph);

            GraphPane myPane = graph.GraphPane;
            myPane.IsFontsScaled = false;

            if (Title.Visible)
            {
                // Set the GraphPane title
                myPane.Title.Text = Title.Text;
                myPane.Title.FontSpec.IsItalic = Title.IsItalic;
                myPane.Title.FontSpec.IsBold = Title.IsBold;
                myPane.Title.FontSpec.IsUnderline = Title.IsUnderLine;
                myPane.Title.FontSpec.Size = Title.FontSize;
                myPane.Title.FontSpec.Family = Title.FontFamily;
                myPane.Title.FontSpec.FontColor = Title.ForeColor;
            }
            myPane.Title.IsVisible = Title.Visible;

            if (PaneFillInfo.Colors != null && PaneFillInfo.Colors.Length > 0)
            {
                myPane.Fill = new Fill(PaneFillInfo.Colors, PaneFillInfo.FillAngle);
            }
            else
            {
                // Fill the pane background with a color gradient
                myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);
            }

            if (ChartFillInfo.Colors != null && ChartFillInfo.Colors.Length > 0)
            {
                myPane.Chart.Fill = new Fill(ChartFillInfo.Colors, ChartFillInfo.FillAngle);
            }
            else
            {
                // No fill for the axis background
                myPane.Chart.Fill.Type = FillType.None;
            }
            
            if (Legend.Visible)
            {
                // Set the legend to an arbitrary location
                myPane.Legend.Position = LegendPos.Right;
                AlignH alignH = AlignH.Left;
                AlignV alignV = AlignV.Top;
                try
                {
                    alignH = (AlignH)Enum.Parse(typeof(AlignH), Legend.AlignH, true);
                }
                catch{ }
                try
                {
                    alignV = (AlignV)Enum.Parse(typeof(AlignV), Legend.AlignV, true);
                }
                catch{ }
                myPane.Legend.Location = new Location(Legend.X, Legend.Y, CoordType.PaneFraction,alignH, alignV);
                myPane.Legend.FontSpec.Size = Legend.FontSize;
                myPane.Legend.FontSpec.FontColor = Legend.ForeColor;
                myPane.Legend.FontSpec.Family = Legend.FontFamily;
                myPane.Legend.FontSpec.IsItalic = Legend.IsItalic;
                myPane.Legend.FontSpec.IsBold = Legend.IsBold;
                myPane.Legend.FontSpec.IsUnderline = Legend.IsUnderLine;
                myPane.Legend.IsHStack = Legend.IsHStack;
            }
            myPane.Legend.IsVisible = Legend.Visible;
            
            foreach (ItemInfo itemInfo in ItemList)
            {
                PieItem pieItem = myPane.AddPieSlice(itemInfo.Value, itemInfo.Color1, itemInfo.Color2, itemInfo.FillAngle, itemInfo.Displacement, itemInfo.Label);
                pieItem.LabelDetail.FontSpec.Size = itemInfo.FontSize;
                pieItem.LabelDetail.FontSpec.FontColor = itemInfo.ForeColor;
                pieItem.LabelDetail.FontSpec.Family = itemInfo.FontFamily;
                pieItem.LabelDetail.FontSpec.IsItalic = itemInfo.IsItalic;
                pieItem.LabelDetail.FontSpec.IsBold = itemInfo.IsBold;
                pieItem.LabelDetail.FontSpec.IsUnderline = itemInfo.IsUnderLine;
                pieItem.Tag = itemInfo.TagId + itemInfo.Label;
                
                try
                {
                    pieItem.LabelType = (PieLabelType) Enum.Parse(typeof (PieLabelType), itemInfo.LabelType);
                }
                catch{ }
            }
            //边框。
            graph.BorderStyle = BorderStyle.None;
            myPane.Border.IsVisible = true;
            graph.MasterPane.Border.IsVisible = Border.Visible;
            if (Border.Visible)
            {
                graph.MasterPane.Border.Width = Border.Width;
                graph.MasterPane.Border.Color = Border.Color;
            }

            // Add a colored background behind the pie
            BoxObj box = new BoxObj(0, 0, 1, 1, Color.Empty, Color.PeachPuff);
            box.Location.CoordinateFrame = CoordType.ChartFraction;
            box.Border.IsVisible = false;
            box.Location.AlignH = AlignH.Left;
            box.Location.AlignV = AlignV.Top;
            box.ZOrder = ZOrder.E_BehindCurves;
            myPane.GraphObjList.Add(box);

            graph.AxisChange();
        }

        /// <summary>
        /// 刷新。
        /// </summary>
        public void Refresh()
        {
            if (!graph.Created) return;
            CurveList curves = graph.GraphPane.CurveList;
            foreach (CurveItem curveItem in curves)
            {
                PieItem pieItem = (PieItem)curveItem;
                ItemInfo itemInfo = ItemList.Find(o => (o.TagId + o.Label).Equals(pieItem.Tag.ToString()));
                pieItem.Value = itemInfo.Value;
            }
            //graph.AxisChange();
            graph.Invalidate();
        }
        #endregion

        #region Class
        public class TitleInfo : MFont
        {
            public String Text { get; set; }
            public Boolean Visible { get; set; }
        }

        public class LegendInfo : MFont
        {
            public Single X { get; set; }
            public Single Y { get; set; }
            public String AlignH { get; set; }
            public String AlignV { get; set; }
            public Boolean IsHStack { get; set; }
            public Boolean Visible { get; set; }
        }

        public class ItemInfo : MFont
        {
            public String TagId { get; set; }
            public String DataType { get; set; }
            public String Label { get; set; }
            public Color Color1 { get; set; }
            public Color Color2 { get; set; }
            public Single FillAngle { get; set; }
            public Single Displacement { get; set; }
            public Double Value { get; set; }
            public String LabelType { get; set; }
        }

        public class FillInfo
        {
            public Color[] Colors { get; set; }
            public Single FillAngle { get; set; }
        }

        public class BorderInfo
        {
            public Color Color { get; set; }
            public Single Width { get; set; }
            public bool Visible { get; set; }
        }
        
        public abstract class MFont
        {
            /// <summary>
            /// 字体。
            /// </summary>
            public String FontFamily { get; set; } 
            /// <summary>
            /// 字大小。
            /// </summary>
            public Single FontSize { get; set; }
            /// <summary>
            /// 字颜色。
            /// </summary>
            public Color ForeColor { get; set; }
            /// <summary>
            /// 是否斜体。
            /// </summary>
            public Boolean IsItalic { get; set; }
            /// <summary>
            /// 是否粗体。
            /// </summary>
            public Boolean IsBold { get; set; }
            /// <summary>
            /// 是否有下划线。
            /// </summary>
            public Boolean IsUnderLine { get; set; }
        }
        #endregion
    }
}
