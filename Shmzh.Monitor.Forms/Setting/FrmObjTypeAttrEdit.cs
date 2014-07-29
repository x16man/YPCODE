using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
namespace Shmzh.Monitor.Forms.Setting
{
    public partial class FrmObjTypeAttrEdit : Form
    {
        #region Property
        /// <summary>
        /// 类别Id。
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 类别属性实体。
        /// </summary>
        public ObjTypeAttrInfo TypeAttr { get; set; }
        #endregion
        
        #region CTOR
        private FrmObjTypeAttrEdit()
        {
            InitializeComponent();
            this.BindDataType();//绑定数据类型。
        }
        public FrmObjTypeAttrEdit(int typeId):this()
        {
            this.Text = "新建类别属性";
            this.TypeId = typeId;
        }
        public FrmObjTypeAttrEdit(ObjTypeAttrInfo objTypeAttrInfo):this()
        {
            this.Text = "编辑类别属性";
            this.TypeId = objTypeAttrInfo.TypeId;
            this.TypeAttr = objTypeAttrInfo;
            this.txtSerialNo.Text = objTypeAttrInfo.SerialNo.ToString();
            this.txtName.Text = objTypeAttrInfo.Name;
            this.cbFieldName.SelectedItem = objTypeAttrInfo.FieldName;
            foreach(var obj in this.cbDataType.Items)
            {
                if (((DictionaryEntry)obj).Key.ToString() == objTypeAttrInfo.DataType)
                {
                    this.cbDataType.SelectedItem = obj;
                    break;
                }
            }
        }
        #endregion

        #region Method
        private void BindDataType()
        {
            this.cbDataType.Items.Clear();
            this.cbDataType.Items.Add(new DictionaryEntry("String", "字符串"));
            this.cbDataType.Items.Add(new DictionaryEntry("Numric", "数字型"));
            this.cbDataType.DisplayMember = "value";
            this.cbDataType.ValueMember = "key";
        }
        #endregion

        #region Event
        private void btnYes_Click(object sender, EventArgs e)
        {
            //Validate.
            if (string.IsNullOrEmpty(this.txtSerialNo.Text))
                this.txtSerialNo.Text = "0";
            try
            {
                short.Parse(this.txtSerialNo.Text.Trim());
            }
            catch 
            {
                MessageBox.Show("序号的数据格式不正确！");
                this.txtSerialNo.Focus();
                return;
            }
            if(string.IsNullOrEmpty(this.txtName.Text))
            {
                MessageBox.Show("类别属性名称不能为空！");
                this.txtName.Focus();
                return;
            }
            if (this.cbFieldName.Text.Trim().Length == 0)
            {
                MessageBox.Show("字段名不允许为空！");
                this.cbFieldName.Focus();
                return;
            }
            
            if(this.cbDataType.Text.Trim().Length == 0)
            {
                MessageBox.Show("数据类型不允许为空！");
                this.cbDataType.Focus();
                return;
            }
            //Save.
            if(this.TypeAttr == null)//Add
            {
                //判断字段名是否已经被使用过。
                var objs = DataProvider.ObjTypeAttrProvider.GetByTypeId(this.TypeId);
                if (objs.FindAll(o => o.FieldName == this.cbFieldName.SelectedItem.ToString()).Count>0)
                {
                    MessageBox.Show("在该类别下选定的字段名已经被使用！");
                    return;
                }
                this.TypeAttr = new ObjTypeAttrInfo
                                    {
                                        SerialNo = short.Parse(this.txtSerialNo.Text),
                                        Name = this.txtName.Text,
                                        TypeId = this.TypeId,
                                        FieldName = this.cbFieldName.SelectedItem.ToString(),
                                        DataType = ((DictionaryEntry)this.cbDataType.SelectedItem).Key.ToString(),
                                    };
                var ret = DataProvider.ObjTypeAttrProvider.Insert(this.TypeAttr);
                if(ret > 0)
                {
                    this.TypeAttr.Id = ret;
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
                    MessageBox.Show("添加失败！");
                }
            }
            else//Update
            {
                //判断字段名是否已经被使用过。
                var objs = DataProvider.ObjTypeAttrProvider.GetByTypeId(this.TypeId);
                var obj = objs.Find(o => o.FieldName == this.cbFieldName.SelectedItem.ToString());
                if(obj != null && obj.Id != this.TypeAttr.Id)
                {
                    MessageBox.Show("在该类别下选定的字段名已经被使用！");
                    return;
                }
                this.TypeAttr.SerialNo = short.Parse(this.txtSerialNo.Text);
                this.TypeAttr.Name = this.txtName.Text.Trim();
                this.TypeAttr.FieldName = this.cbFieldName.SelectedItem.ToString();
                this.TypeAttr.DataType = ((DictionaryEntry) this.cbDataType.SelectedItem).Key.ToString();
                if(DataProvider.ObjTypeAttrProvider.Update(this.TypeAttr))
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
                    MessageBox.Show("修改失败！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.Close();
            }
        }
        #endregion

    }
}
