using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;
using System.Drawing;

namespace Shmzh.Monitor.Gadget
{
    public class TextInfo : TextBaseInfo
    {
        private String _text = " ";
        public TextInfo()
        {
        }

        /// <summary>
        /// 是否垂直显示。
        /// </summary>
        public Boolean IsVertical { get; set; }
        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }
             
        public void Render(Graphics g)
        {
            var absoluteX = this.BasePoint == null ? this.X : this.BasePoint.X + this.X;
            var absoluteY = this.BasePoint == null ? this.Y : this.BasePoint.Y + this.Y;
            if (ParentNode is DeviceInfo)
            {
                var devInfo = ParentNode as DeviceInfo;
                if (devInfo.State != DeviceState.Running) return;
            }
            var tempSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.Default;
            var fontStyle = FontStyle.Regular;
            Brush brush;
            Color backColor;

            if (IsMouseOver)
            {
                if (SelectedIsItalic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (SelectedIsBold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (SelectedIsUnderLine)
                {
                    fontStyle |= FontStyle.Underline;
                }
                brush = new SolidBrush(SelectedColor);
                backColor = SelectedBackColor;
            }
            else
            {
                if (NormalIsItalic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (NormalIsBold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (NormalIsUnderLine)
                {
                    fontStyle |= FontStyle.Underline;
                }
                brush = new SolidBrush(NormalColor);
                backColor = NormalBackColor;
            }

            var sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
           
            if (IsVertical)
            {
                sf.FormatFlags |= StringFormatFlags.DirectionVertical;
            }
            else
            {
                switch (Align)
                {
                    case TextAlign.Left:
                        sf.Alignment = StringAlignment.Near;
                        break;
                    case TextAlign.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case TextAlign.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }
            }

            Font font = new Font(FontFamily, FontSize, fontStyle);
            SizeF sizeF = g.MeasureString(Text, font, new PointF(absoluteX, absoluteY), sf);
            if (Width == 0 || Height == 0)
            {
                Bounds = new Rectangle(new Point(absoluteX, absoluteY), new Size(Convert.ToInt32(Math.Ceiling(sizeF.Width)), Convert.ToInt32(Math.Ceiling(sizeF.Height))));
            }
            else
            {
                Bounds = new Rectangle(absoluteX, absoluteY, Width, Height);
            }
           
            //画背景。
            if (backColor != Color.Transparent) g.FillRectangle(new SolidBrush(backColor), new Rectangle(Bounds.X, Bounds.Y - TopWidth / 2, Bounds.Width, Bounds.Height));
           
            //画字。
            if (!String.IsNullOrEmpty(Text)) g.DrawString(Text, font, brush, Bounds, sf);
            if (Width == 0 || Height == 0)
            {
                Bounds = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height + BottomWidth / 2);
            }
           
            //画边框。
            if (BorderColor != Color.Transparent)
            {
                using (Pen pen = new Pen(BorderColor))
                {
                    Single halfTop = TopWidth / 2F;
                    Single halfBottom = BottomWidth / 2F;
                    if (BottomWidth == 1)
                    {
                        halfBottom--;
                    }
                    
                    if (LeftWidth > 0)
                    {
                        pen.Width = LeftWidth;
                        g.DrawLine(pen, Bounds.Left, Bounds.Top - TopWidth, Bounds.Left, Bounds.Bottom);
                    }
                    if (TopWidth > 0)
                    {
                        pen.Width = TopWidth;
                        g.DrawLine(pen, Bounds.Left, Bounds.Top - halfTop, Bounds.Right, Bounds.Top - halfTop);
                    }
                    if (RightWidth > 0)
                    {
                        pen.Width = RightWidth;
                        g.DrawLine(pen, Bounds.Right, Bounds.Top - TopWidth, Bounds.Right, Bounds.Bottom);
                    }
                    if (BottomWidth > 0)
                    {
                        pen.Width = BottomWidth;
                        g.DrawLine(pen, Bounds.Left, Bounds.Bottom - halfBottom, Bounds.Right, Bounds.Bottom - halfBottom);
                    }

                    Bounds = Rectangle.Inflate(Bounds, Math.Max(LeftWidth, RightWidth), Math.Max(TopWidth, BottomWidth));
                }
            }
            font.Dispose();
            brush.Dispose();
            sf.Dispose();
            g.SmoothingMode = tempSmoothingMode;
        }
    }
}
