using System;
using System.Drawing;

namespace Shmzh.Monitor.Gadget
{
    public class ImageInfo : BaseInfo
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Boolean isInitialized = false;
        #endregion

        #region Property
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public String HoverSrc { get; set; }
        public String Src { get; set; }
        public Color BorderColor { get; set; }
        public Int32 BorderWidth { get; set; }

        public override String TriggerEvent { get; set; }
        #endregion

        public void Render(Graphics g)
        {
            if (!isInitialized)
            {
                isInitialized = true;
                OnValueChanged();
            }
            var strImg = IsMouseOver ? HoverSrc : Src;
            var img = ConfigImages.GetByKey(strImg);
            Width = Width == 0 ? img.Width : Width;
            Height = Height == 0 ? img.Height : Height;
            Bounds = new Rectangle(X, Y, Width, Height);
            g.DrawImage(img, Bounds);
            if (BorderWidth > 0)
            {
                using (var p = new Pen(BorderColor) { Width = BorderWidth })
                {
                    g.DrawRectangle(p, Rectangle.Inflate(Bounds, BorderWidth / 2, BorderWidth / 2));
                }
                Bounds = Rectangle.Inflate(Bounds, BorderWidth, BorderWidth);
            }
        }

        protected virtual void OnValueChanged(){ }
    }
}
