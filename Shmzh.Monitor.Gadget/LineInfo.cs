using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ciloci.Flee;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Gadget
{
    public class LineInfo : IDisposable
    {
        #region Fields
        //private List<Point> points;
        private GraphicsPath _gp;
        private Rectangle _bounds = Rectangle.Empty;
        private Double _value;
        private Boolean isInitialized = false;
        private Single _arrowFactor = 2.0F;
        #endregion

        #region CTOR
        public LineInfo()
        {
            //this.BackColor = Color.Transparent;
        }
        #endregion
        /// <summary>
        /// 析构函数。
        /// </summary>
        ~LineInfo()
        {
            Dispose();
        }

        #region property
        /// <summary>
        /// 指标Id。
        /// </summary>
        public String TagId { get; set; }
        /// <summary>
        /// 数据类型（分钟、15分钟、小时、天、月、年）。可选值：Second/Min/Min15/Hour/Day/Month/Year.
        /// </summary>
        public String DataType { get; set; }
        ///// <summary>
        ///// 线的点集合。
        ///// </summary>
        //public List<Point> Points
        //{
        //    get
        //    {
        //        if (points == null)
        //        {
        //            points = new List<Point>();
        //        }
        //        return points;
        //    }
        //    set
        //    {
        //        points = value;
        //    }
        //}
        /// <summary>
        /// 路径。
        /// </summary>
        public GraphicsPath GP
        {
            get
            {
                if(_gp == null) _gp = new GraphicsPath();
                return _gp;
            }
            set { _gp = value; }
        }

        /// <summary>
        /// 是否有开始箭头。
        /// </summary>
        public Boolean StartArrow { get; set; }
        /// <summary>
        /// 是否有结束箭头。
        /// </summary>
        public Boolean EndArrow { get; set; }
        /// <summary>
        /// 线的颜色。
        /// </summary>
        public Color NormalColor { get; set; }
        
        /// <summary>
        /// 线的宽度。
        /// </summary>
        public Single NormalWidth { get; set; }
        
        /// <summary>
        /// 线型，可选值：Solid/Dash/DashDot/DashDotDot/Dot/DashDash。
        /// </summary>
        public String LineStyle { get; set; }

        /// <summary>
        /// 箭头大小与线宽的比例。
        /// </summary>
        public Single ArrowFactor
        {
            private get { return _arrowFactor; }
            set { _arrowFactor = value; }
        }
       
        /// <summary>
        /// 指标对应值。
        /// </summary>
        public Double Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                OnValueChanged();
            }
        }

        public String ColorExp { private get; set; }
        public String WidthExp { private get; set; }
        public String LineStyleExp { private get; set; }
        
        /// <summary>
        /// 包围该线的矩形。
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                if (this._bounds.Equals(Rectangle.Empty))
                {
                    if (_gp.PointCount > 1)
                    {
                        Single minX = 0, minY = 0;
                        Single maxX = 1.0F, maxY = 1.0F;
                        foreach (PointF point in _gp.PathPoints)
                        {
                            if (point.X < minX)
                            {
                                minX = point.X;
                            }
                            else if (point.X > maxX)
                            {
                                maxX = point.X;
                            }

                            if (point.Y < minY)
                            {
                                minY = point.Y;
                            }
                            else if (point.Y > maxY)
                            {
                                maxY = point.Y;
                            }
                        }
                        _bounds =
                            Rectangle.Ceiling(new RectangleF(minX, minY, maxX - minX + NormalWidth / 2F + 1.0F,
                                                             maxY - minY + NormalWidth / 2F + 1.0F));
                    }
                }
                return _bounds;
            }
        }
       
        #endregion

        #region Method
        /// <summary>
        /// 线的绘制。
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)
        {
            if (!isInitialized)
            {
                OnValueChanged();
                isInitialized = true;
            }
            
            if (NormalWidth <= 0 || NormalColor == Color.Transparent) return;
            var pen = new Pen(NormalColor, NormalWidth);
            var lineCap = new AdjustableArrowCap(pen.Width * ArrowFactor, pen.Width * ArrowFactor, true);
            if (StartArrow)
            {
                pen.CustomStartCap = lineCap;
            }
            if (EndArrow)
            {
                pen.CustomEndCap = lineCap;
            }
            switch (LineStyle)
            {
                case "Solid":
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case "Dash":
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case "DashDot":
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case "DashDotDot":
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
                case "Dot":
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case "DashDash":
                    pen.DashPattern = new Single[] { 6.0F, 1.5F, 2.0F, 1.5F };
                    break;
                default:
                    pen.DashStyle = DashStyle.Solid;
                    break;
            }
            //g.DrawLines(pen, Points.ToArray());
            g.DrawPath(pen, _gp);
        }

        private void OnValueChanged()
        {
            if (Utils.IsExp(ColorExp))
            {
                NormalColor = StringUtil.StringToColor(Utils.CalcExpString(ColorExp, Value), Color.Black);
            }
            else
            {
                NormalColor = StringUtil.StringToColor(ColorExp, Color.Black);
            }

            if (Utils.IsExp(WidthExp))
            {
                NormalWidth = Convert.ToSingle(Utils.CalcExpInt(WidthExp, Value));
            }
            else
            {
                NormalWidth = Convert.ToSingle(WidthExp);
            }

            if (Utils.IsExp(LineStyleExp))
            {
                LineStyle = Utils.CalcExpString(LineStyleExp, Value);
            }
            else
            {
                LineStyle = LineStyleExp;
            }
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            if(_gp != null)
            {
                _bounds = Rectangle.Empty;
                _gp.Dispose();
                _gp = null;
            }
        }

        
        #endregion
    }
}
