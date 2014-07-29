using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Forms.Setting;
namespace Test
{
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FrmObjTypeAttr().Show();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            var form = new Form4 { Dock = DockStyle.Fill, TopLevel = false, Visible = true, FormBorderStyle = FormBorderStyle.None };
            this.panelContent.Controls.Add(form);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //new AddFlow().Show();
        }

        private void Entry_Paint(object sender, PaintEventArgs e)
        {
            SetAndFillClip(e);
        }
        private void SetAndFillClip(PaintEventArgs e)
        {

            // Set the Clip property to a new region.
            e.Graphics.Clip = new Region(new Rectangle(10, 10, 100, 200));

            // Fill the region.
            e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip);

            // Demonstrate the clip region by drawing a string
            // at the outer edge of the region.
            e.Graphics.DrawString("Outside of Clip", new Font("Arial",
                12.0F, FontStyle.Regular), Brushes.White, 0.0F, 0.0F);

        }

    }
}
