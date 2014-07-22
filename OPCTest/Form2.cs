using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OPCTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = int.Parse(this.textBox1.Text);
            var b = int.Parse(this.textBox2.Text);
            var c = a & b;
            this.textBox3.Text = c.ToString();
        }
    }
}
