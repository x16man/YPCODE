using System;
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
    public partial class FrmObjTypeEdit : Form
    {
        #region Property
        /// <summary>
        /// 上级类别Id。
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 类别实体。
        /// </summary>
        public ObjTypeInfo ObjType { get; set; }
        #endregion

        #region private method
        /// <summary>
        /// 校验数据的有效性。
        /// </summary>
        /// <returns>bool</returns>
        private bool IsValidate()
        {
            return !string.IsNullOrEmpty(this.txtName.Text);
        }

        #endregion

        #region CTOR
        private FrmObjTypeEdit()
        {
            InitializeComponent();
        }
        public FrmObjTypeEdit(int parentId):this()
        {
            this.ParentId = parentId;
            this.Text = "新建监测对象类别";
        }
        public FrmObjTypeEdit(ObjTypeInfo objTypeInfo):this()
        {
            this.ObjType = objTypeInfo;
            this.ParentId = objTypeInfo.ParentId;
            this.txtName.Text = objTypeInfo.Name;
            this.txtRemark.Text = objTypeInfo.Remark;
            this.Text = "编辑监测对象类别";
        }
        #endregion

        #region Event
        private void btnYes_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                if (this.ObjType == null) //Add
                {
                    this.ObjType = new ObjTypeInfo
                                       {
                                           Name = this.txtName.Text.Trim(),
                                           Remark = this.txtRemark.Text.Trim(),
                                           ParentId = this.ParentId
                                       };
                    var ret = DataProvider.ObjTypeProvider.Insert(this.ObjType);
                    if (ret > 0)
                    {
                        this.ObjType.Id = ret;
                        if (this.Owner != null)
                            this.DialogResult = DialogResult.OK;
                        else
                            this.Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }
                else //Update
                {
                    this.ObjType.Name = this.txtName.Text.Trim();
                    this.ObjType.Remark = this.txtRemark.Text.Trim();
                    if (DataProvider.ObjTypeProvider.Update(this.ObjType))
                    {
                        if (this.Owner != null)
                            this.DialogResult = DialogResult.OK;
                        else
                            this.Close();

                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("名称不能为空！");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
                this.Close();
            else
                this.DialogResult = DialogResult.Cancel;
        }

        

        

        #endregion
    }
}
