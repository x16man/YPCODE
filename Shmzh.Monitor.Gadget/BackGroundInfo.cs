using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Shmzh.Monitor.Gadget
{
    public class BackGroundInfo
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region CTOR
        public BackGroundInfo() {  }
        #endregion

        #region Property        
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BackColor { get; set; }
        
        public Boolean IsTiled { get; set; }

        /// <summary>
        /// 背景图片路径
        /// </summary>
        public String Src { get; set; }

        /// <summary>
        /// 当前的图片源。
        /// </summary>
        private String CurrentSrc { get; set; }
        /// <summary>
        /// 当前图片。
        /// </summary>
        public Image CurrentImage { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// 呈现背景。
        /// </summary>
        /// <param name="g">GDI+绘图图面。</param>
        /// <param name="width">宽。</param>
        /// <param name="height">高。</param>
        public void Render(Graphics g, Int32 width, Int32 height)
        {
            if (BackColor != Color.Transparent)
            {
                g.FillRectangle(new SolidBrush(BackColor), 0, 0, width, height);
            }
            if (!String.IsNullOrEmpty(Src))
            {
                if (this.CurrentSrc != Src)
                {
                    this.CurrentSrc = Src;
                    if (!ConfigImages.ContainsKey(Src))
                    {
                        Logger.Error(String.Format("背景图片“{0}”找不到!", Src));
                    }
                    CurrentImage = ConfigImages.GetByKey(Src);
                }

                if (IsTiled)
                {
                    g.DrawImage(CurrentImage, 0, 0, width, height);
                }
                else
                {
                    g.DrawImage(CurrentImage, 0, 0, CurrentImage.Width, CurrentImage.Height);
                }
            }
        }
               
        #endregion
    }
}

