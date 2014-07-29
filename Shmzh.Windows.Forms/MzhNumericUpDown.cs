using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Windows.Forms
{
    public enum ComponseType
    {
        Int32 = 0,
        Short = 1,
        Double = 2
    }

    public class MzhNumericUpDown :  NumericUpDown
    {
        public ComponseType componsetemp = ComponseType.Double;

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Maximum = 99999999999999M;
            this.Minimum = -99999999999999M;
            this.DecimalPlaces = 2;
            this.Increment = 0.01M;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.Text != "")
            {
                switch (componsetemp)
                {
                    case ComponseType.Short:
                        try
                        {
                            short.Parse(this.Text);
                        }
                        catch
                        {
                            this.Text = "";
                            this.Focus();
                        }
                        break;
                    case ComponseType.Int32:
                        try
                        {
                            Int32.Parse(this.Text);
                        }
                        catch
                        {
                            this.Text = "";
                            this.Focus();
                        }
                        break;
                    default:
                        try
                        {
                            double.Parse(this.Text);
                        }
                        catch
                        {
                            this.Text = "";
                            this.Focus();
                        }
                        break;
                }
            }
        }
     }
}
