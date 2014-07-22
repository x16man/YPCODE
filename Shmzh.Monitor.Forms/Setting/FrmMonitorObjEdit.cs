using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms.Setting
{
    public partial class FrmMonitorObjEdit : Form
    {
        #region property
        public int TypeId { get; set; }
        public MonitorObjInfo MonitorObj { get; set; }
        #endregion

        #region private method
        private void InitControl()
        {
            var myGroup = new GroupBox {Name = "gpMonitorObj", Text = "监测对象属性", Width = 300,Location = new Point(20,20)};
            this.Width = 340;
            var label = new Label {Name = "lblCode", Text = "编号：", Location = new Point(20, 30), AutoSize = true,};
            myGroup.Controls.Add(label);

            var txt = new TextBox
                          {
                              Name = "txtCode",
                              Text = string.Empty,
                              MaxLength = 20,
                              Location = new Point(90, 30),
                              Width = 200,
                          };
            myGroup.Controls.Add(txt);

            label = new Label { Name = "lblName", Text = "名称：", Location = new Point(20, 60), AutoSize = true, };
            myGroup.Controls.Add(label);
            txt = new TextBox
            {
                Name = "txtName",
                Text = string.Empty,
                MaxLength = 20,
                Location = new Point(90, 60),
                Width = 200,
            };
            myGroup.Controls.Add(txt);

            label = new Label { Name = "lblSerialNo", Text = "序号：", Location = new Point(20, 90), AutoSize = true, };
            myGroup.Controls.Add(label);
            txt = new TextBox
            {
                Name = "txtSerialNo",
                Text = string.Empty,
                MaxLength = 20,
                Location = new Point(90, 90),
                Width = 200,
            };
            myGroup.Controls.Add(txt);
            //专属特性
            var objs = DataProvider.ObjTypeAttrProvider.GetByTypeId(this.TypeId);
            myGroup.Height = (3 + objs.Count)*30+30;
            this.Height = myGroup.Height + 120;

            for(int i = 0,l = objs.Count;i < l;i++)
            {
                label = new Label{Name = string.Format("lbl{0}",objs[i].FieldName),Text = string.Format("{0}：",objs[i].Name),Location = new Point(20,(4+i)*30),AutoSize = true};
                myGroup.Controls.Add(label);
                txt = new TextBox
                          {
                              Name = string.Format("txt{0}", objs[i].FieldName),
                              Location = new Point(90, (4 + i)*30),
                              MaxLength = 100,
                              Width = 200
                          };
                myGroup.Controls.Add(txt);
            }
            //添加
            this.Controls.Add(myGroup);
            var btnCancel = new Button() {Name = "btnCancel", Text = "&C.取消",Location = new Point(myGroup.Location.X+myGroup.Width - 90,myGroup.Location.Y+myGroup.Height+20),AutoSize = true};
            this.Controls.Add(btnCancel);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            var btnYes = new Button() {Name = "btnYes", Text = "&Y.确定",Location = new Point(btnCancel.Location.X - 80,btnCancel.Location.Y),AutoSize = true};
            this.Controls.Add(btnYes);
            btnYes.Click += new EventHandler(btnYes_Click);
            
        }
        private void BindData(MonitorObjInfo monitorObjInfo)
        {
            foreach (var ctrlObj in this.Controls)
            {
                if (ctrlObj is GroupBox)
                {
                    var gb = ctrlObj as GroupBox;
                    foreach(var cObj in gb.Controls)
                    {
                        if(cObj is TextBox)
                        {
                            var txtObj = cObj as TextBox;
                            switch (txtObj.Name)
                            {
                                case "txtCode":
                                    txtObj.Text = monitorObjInfo.Code;
                                    break;
                                case "txtName":
                                    txtObj.Text = monitorObjInfo.Name;
                                    break;
                                case "txtSerialNo":
                                    txtObj.Text = monitorObjInfo.SerialNo.ToString();
                                    break;
                                case "txtAttrField01":
                                    txtObj.Text = monitorObjInfo.AttrField01;
                                    break;
                                case "txtAttrField02":
                                    txtObj.Text = monitorObjInfo.AttrField02;
                                    break;
                                case "txtAttrField03":
                                    txtObj.Text = monitorObjInfo.AttrField03;
                                    break;
                                case "txtAttrField04":
                                    txtObj.Text = monitorObjInfo.AttrField04;
                                    break;
                                case "txtAttrField05":
                                    txtObj.Text = monitorObjInfo.AttrField05;
                                    break;
                                case "txtAttrField06":
                                    txtObj.Text = monitorObjInfo.AttrField06;
                                    break;
                                case "txtAttrField07":
                                    txtObj.Text = monitorObjInfo.AttrField07;
                                    break;
                                case "txtAttrField08":
                                    txtObj.Text = monitorObjInfo.AttrField08;
                                    break;
                                case "txtAttrField09":
                                    txtObj.Text = monitorObjInfo.AttrField09;
                                    break;
                                case "txtAttrField10":
                                    txtObj.Text = monitorObjInfo.AttrField10;
                                    break;
                                case "txtAttrField11":
                                    txtObj.Text = monitorObjInfo.AttrField11;
                                    break;
                                case "txtAttrField12":
                                    txtObj.Text = monitorObjInfo.AttrField12;
                                    break;
                                case "txtAttrField13":
                                    txtObj.Text = monitorObjInfo.AttrField13;
                                    break;
                                case "txtAttrField14":
                                    txtObj.Text = monitorObjInfo.AttrField14;
                                    break;
                                case "txtAttrField15":
                                    txtObj.Text = monitorObjInfo.AttrField15;
                                    break;
                                case "txtAttrField16":
                                    txtObj.Text = monitorObjInfo.AttrField16;
                                    break;
                                case "txtAttrField17":
                                    txtObj.Text = monitorObjInfo.AttrField17;
                                    break;
                                case "txtAttrField18":
                                    txtObj.Text = monitorObjInfo.AttrField18;
                                    break;
                                case "txtAttrField19":
                                    txtObj.Text = monitorObjInfo.AttrField19;
                                    break;
                                case "txtAttrField20":
                                    txtObj.Text = monitorObjInfo.AttrField20;
                                    break;
                            }    
                        }
                        
                    }
                }
            }
        }
        private bool FillData(MonitorObjInfo monitorObjInfo)
        {
            foreach(var ctrl in this.Controls)
            {
                if(ctrl is GroupBox)
                {
                    var gp = ctrl as GroupBox;
                    foreach (var control in gp.Controls)
                    {
                        if(control is TextBox)
                        {
                            var txtObj = control as TextBox;
                            switch (txtObj.Name)
                            {
                                case "txtCode":
                                    if (txtObj.Text.Trim().Length == 0)
                                    {
                                        MessageBox.Show("编号不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtObj.Focus();
                                        return false;
                                    }
                                    monitorObjInfo.Code = txtObj.Text;
                                    break;
                                case "txtName":
                                    if (txtObj.Text.Trim().Length == 0)
                                    {
                                        MessageBox.Show("名称不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtObj.Focus();
                                        return false;
                                    }
                                    monitorObjInfo.Name = txtObj.Text;
                                    break;
                                case "txtSerialNo":
                                    int serialNo;
                                    try
                                    {
                                        serialNo = int.Parse(txtObj.Text.Trim());
                                    }
                                    catch 
                                    {
                                        MessageBox.Show("序号必须为整数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtObj.Focus();
                                        return false;
                                    }
                                    monitorObjInfo.SerialNo = serialNo;
                                    break;
                                case "txtAttrField01":
                                    monitorObjInfo.AttrField01 = txtObj.Text;
                                    break;
                                case "txtAttrField02":
                                    monitorObjInfo.AttrField02 = txtObj.Text;
                                    break;
                                case "txtAttrField03":
                                    monitorObjInfo.AttrField03 = txtObj.Text;
                                    break;
                                case "txtAttrField04":
                                    monitorObjInfo.AttrField04 = txtObj.Text;
                                    break;
                                case "txtAttrField05":
                                    monitorObjInfo.AttrField05 = txtObj.Text;
                                    break;
                                case "txtAttrField06":
                                    monitorObjInfo.AttrField06 = txtObj.Text;
                                    break;
                                case "txtAttrField07":
                                    monitorObjInfo.AttrField07 = txtObj.Text;
                                    break;
                                case "txtAttrField08":
                                    monitorObjInfo.AttrField08 = txtObj.Text;
                                    break;
                                case "txtAttrField09":
                                    monitorObjInfo.AttrField09 = txtObj.Text;
                                    break;
                                case "txtAttrField10":
                                    monitorObjInfo.AttrField10 = txtObj.Text;
                                    break;
                                case "txtAttrField11":
                                    monitorObjInfo.AttrField11 = txtObj.Text;
                                    break;
                                case "txtAttrField12":
                                    monitorObjInfo.AttrField12 = txtObj.Text;
                                    break;
                                case "txtAttrField13":
                                    monitorObjInfo.AttrField13 = txtObj.Text;
                                    break;
                                case "txtAttrField14":
                                    monitorObjInfo.AttrField14 = txtObj.Text;
                                    break;
                                case "txtAttrField15":
                                    monitorObjInfo.AttrField15 = txtObj.Text;
                                    break;
                                case "txtAttrField16":
                                    monitorObjInfo.AttrField16 = txtObj.Text;
                                    break;
                                case "txtAttrField17":
                                    monitorObjInfo.AttrField17 = txtObj.Text;
                                    break;
                                case "txtAttrField18":
                                    monitorObjInfo.AttrField18 = txtObj.Text;
                                    break;
                                case "txtAttrField19":
                                    monitorObjInfo.AttrField19 = txtObj.Text;
                                    break;
                                case "txtAttrField20":
                                    monitorObjInfo.AttrField20 = txtObj.Text;
                                    break;
                            }    
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region CTOR
        private FrmMonitorObjEdit()
        {
            InitializeComponent();
        }
        public FrmMonitorObjEdit(int typeId):this()
        {
            this.TypeId = typeId;
            this.InitControl();
            this.Text = "新建监测对象";
        }
        public FrmMonitorObjEdit(MonitorObjInfo monitorObjInfo):this()
        {
            this.MonitorObj = monitorObjInfo;
            this.TypeId = monitorObjInfo.TypeId;

            this.InitControl();
            this.Text = "编辑监测对象";

            this.BindData(this.MonitorObj);
        }
        public FrmMonitorObjEdit(string code):this()
        {
            this.MonitorObj = DataProvider.MonitorObjProvider.GetByCode(code);
            this.TypeId = this.MonitorObj.TypeId;
            
            this.InitControl();
            this.Text = "编辑监测对象";

            this.BindData(this.MonitorObj);                
        }
        #endregion 


        private void frmMonitorObjEdit_Paint(object sender, PaintEventArgs e)
        {
            //var g = e.Graphics;
            //g.DrawString("尚未实现呢，请稍等！",this.Font, Brushes.Black,100,100);
        }

        void btnYes_Click(object sender, EventArgs e)
        {
            if (this.MonitorObj == null)//Add
            {
                var obj = new MonitorObjInfo {TypeId = this.TypeId};
                if (!this.FillData(obj)) return;
                
                if(DataProvider.MonitorObjProvider.Insert(obj) >0)
                {
                    if (this.Owner != null)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            else//Update
            {
                if (!this.FillData(this.MonitorObj)) return;
                if(DataProvider.MonitorObjProvider.Update(this.MonitorObj))
                {
                    if(this.Owner != null)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
                this.Close();
        }
    }
}
