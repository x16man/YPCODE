using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Windows.Forms
{
    public partial class MzhListView : ListView
    {
        public MzhListView()
        {
            SetStyle(ControlStyles.DoubleBuffer |
                                    ControlStyles.OptimizedDoubleBuffer |
                                    ControlStyles.AllPaintingInWmPaint,
                                    true);
            this.DoubleBuffered = true;
            UpdateStyles();
           
        }

        
    }
}
