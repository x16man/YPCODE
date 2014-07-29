using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Windows.Forms
{
    public class ResizableToolStripDropDown:ToolStripDropDown 
    {
        public ResizableToolStripDropDown()
        {
            this.AutoSize = false;
        }

        private Rectangle BottomGripBounds
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - 4;
                rect.Height = 4;

                return rect;
            }
        }
        private Rectangle BottomRightGripBounds
        {
            get
            {
                Rectangle rect = BottomGripBounds;
                rect.X = rect.Width - 4;
                rect.Width = 4;

                return rect;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_NCHITTEST)
            {
                // fetch out X & Y out of the message
                int x = NativeMethods.LOWORD(m.LParam);
                int y = NativeMethods.HIWORD(m.LParam);

                // convert to client coords
                Point clientLocation = PointToClient(new Point(x, y));

                // prefer bottom right check
                if (BottomRightGripBounds.Contains(clientLocation))
                {
                    m.Result = (IntPtr)NativeMethods.HTBOTTOMRIGHT;
                    return;
                }
                // the bottom check
                if (BottomGripBounds.Contains(clientLocation))
                {
                    m.Result = (IntPtr)NativeMethods.HTBOTTOM;
                    return;
                }
                // else, let the base WndProc handle it.

            }
            base.WndProc(ref m);
        }
        
        internal class NativeMethods
        {
            internal const int WM_NCHITTEST = 0x0084,
                             HTBOTTOM = 15,
                             HTBOTTOMRIGHT = 17;
            internal static int HIWORD(int n)
            {
                return (n >> 16) & 0xffff;
            }

            internal static int HIWORD(IntPtr n)
            {
                return HIWORD(unchecked((int)(long)n));
            }

            internal static int LOWORD(int n)
            {
                return n & 0xffff;
            }

            internal static int LOWORD(IntPtr n)
            {
                return LOWORD(unchecked((int)(long)n));
            }

        }

    }
}
