using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchemaSearch : Form
    {
        private DateTime _endTime = DateTime.Now;
        public FrmGraphSchemaSearch()
        {
            InitializeComponent();
        }

        public String DataType { get; set; }
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        private void FrmGraphSchemaSearch_Load(object sender, EventArgs e)
        {
            dtpEndTime.Value = _endTime;
            Common.BindTagDataType(this.cbDataType, false);
            if(!String.IsNullOrEmpty(DataType))
            {
                try
                {
                    cbDataType.SelectedValue = DataType;
                }
                catch{ }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            _endTime = dtpEndTime.Value;
            DataType = cbDataType.SelectedValue.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
