using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Shmzh.Components.Util;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.mzhRibbonMenuButton1.Visible = false;
            this.mzhRibbonMenuButton2.Visible = false;
            this.mzhRibbonMenuButton3.Visible = false;
            this.mzhRibbonMenuButton4.Visible = false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.mzhRibbonMenuButton1.Visible = true;
            this.mzhRibbonMenuButton1.Visible = true;
            this.mzhRibbonMenuButton2.Visible = true;
            this.mzhRibbonMenuButton3.Visible = true;
            this.mzhRibbonMenuButton4.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            var pt = this.PointToClient(Cursor.Position);
            if(this.panel1.Bounds.Contains(pt))
            {
                this.mzhRibbonMenuButton1.Visible = true;
                this.mzhRibbonMenuButton2.Visible = true;
                this.mzhRibbonMenuButton3.Visible = true;
                this.mzhRibbonMenuButton4.Visible = true;
            }
            else
            {
                this.mzhRibbonMenuButton1.Visible = false;
                this.mzhRibbonMenuButton2.Visible = false;
                this.mzhRibbonMenuButton3.Visible = false;
                this.mzhRibbonMenuButton4.Visible = false;
            }
        }

   }
}
