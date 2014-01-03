using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DDE2OPC.DALFactory;
using DDE2OPC.Model;
using DDE2OPC.Properties;

namespace DDE2OPC
{
    public partial class FormMapInput : Form
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MapInfo CurrentMapInfo;
        #endregion

        #region Method

        private void InitUI()
        {
            this.Icon = Resources.tag_blue_icon;
            this.groupBox_Map.Text = Resources.FormMapInput_GroupBox_Map_Text;
            this.label_DDETopic.Text = Resources.FormMapInput_Label_DDETopic_Text;
            this.label_DDEItem.Text = Resources.FormMapInput_Label_DDEItem_Text;
            this.label_OPCAddress.Text = Resources.FormMapInput_Label_OPCAddress_Text;
            this.label_Remark.Text = Resources.FormMapInput_Label_Remark_Text;
            this.button_OK.Text = Resources.FormMapInput_Button_OK_Text;
            this.button_Cancel.Text = Resources.FormMapInput_Button_Cancel_Text;
        }
        private void Reset()
        {
            this.CurrentMapInfo = null;
            this.textBox_DDETopic.Text = string.Empty;
            this.textBox_DDEItem.Text = string.Empty;
            this.textBox_OPCAddress.Text = string.Empty;
            this.textBox_Remark.Text = string.Empty;
        }
        #endregion

        public FormMapInput()
        {
            InitializeComponent();
            this.InitUI();
        }
        public FormMapInput(MapInfo obj):this()
        {
            this.CurrentMapInfo = obj;
            this.textBox_DDETopic.Text = obj.DDETopic;
            this.textBox_DDEItem.Text = obj.DDEItem;
            this.textBox_OPCAddress.Text = obj.OPCAddress;
            this.textBox_Remark.Text = obj.Remark;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            var isNew = false;
            if(this.CurrentMapInfo == null)
            {
                this.CurrentMapInfo = new MapInfo();
                isNew = true;
            }
            this.CurrentMapInfo.DDETopic = this.textBox_DDETopic.Text.Trim();
            this.CurrentMapInfo.DDEItem = this.textBox_DDEItem.Text.Trim();
            this.CurrentMapInfo.OPCAddress = this.textBox_OPCAddress.Text.Trim();
            this.CurrentMapInfo.Remark = this.textBox_Remark.Text.Trim();
            if (isNew)
            {
                DataProvider.MapProvider.Insert(this.CurrentMapInfo);
            }

            else
            {
                DataProvider.MapProvider.Update(this.CurrentMapInfo);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
