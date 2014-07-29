using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Shmzh.Windows.Forms
{
   
    

    public class MzhTextBox : TextBox
    {

        public ComponseType componsetemp;

        
        public ComponseType Componsetemp
        {
            get
            {
                return componsetemp;
            }
            set
            {
                componsetemp = value;
            }
        }

       
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            switch (componsetemp)
            {
                case ComponseType.Double:
                    try
                    {
                        double.Parse(this.Text);
                    }
                    catch
                    {
                        this.Text = "";
                    }
                    break;
                case ComponseType.Short:
                    try
                    {
                        short.Parse(this.Text);
                    }
                    catch
                    {
                        this.Text = "";
                    }
                    break;
                default:
                    try
                    {
                        Int32.Parse(this.Text);
                    }
                    catch
                    {
                        this.Text = "";
                    }
                    break;
            }

        }
    }
}
