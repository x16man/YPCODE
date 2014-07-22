using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using System.Diagnostics;

namespace Shmzh.Monitor.Forms.Setting
{
    public partial class FrmObjTypeAttr : Form
    {
        #region Field
        /// <summary>
        /// 列别属性集合。
        /// </summary>
        private List<ObjTypeAttrInfo> _objTypeAttrList;

        #endregion

        #region CTOR
        public FrmObjTypeAttr()
        {
            InitializeComponent();
            
        }
        #endregion

        #region Method
        
        /// <summary>
        /// 创建监测对象类别树。
        /// </summary>
        public void CreateObjTypeTree()
        {
            this.tvObjType.Nodes.Clear();
            var rootNode = new TreeNode("监测对象类别") {ImageIndex = 5,Tag = -1,SelectedImageIndex = 5,};
            
            this.tvObjType.Nodes.Add(rootNode);

            this.CreateChildNode(rootNode);
            rootNode.Expand();
        }
        /// <summary>
        /// 创建子节点。
        /// </summary>
        /// <param name="parentNode">父节点。</param>
        private void CreateChildNode(TreeNode parentNode)
        {
            var parentId = int.Parse(parentNode.Tag.ToString());
            var objs = DataProvider.ObjTypeProvider.GetByParentId(parentId);
            foreach(var obj in objs)
            {
                var node = new TreeNode(obj.Name) {ImageIndex = 3,Tag = obj.Id, SelectedImageIndex = 4,};
                this.CreateChildNode(node);
                parentNode.Nodes.Add(node);
            }
        }
        /// <summary>
        /// 根据监测对象类别创建监测对象列表。
        /// </summary>
        /// <param name="typeId">监测对象类别Id。</param>
        public void BindMonitorObjList(int typeId)
        {
            this.lvMonitorObj.Items.Clear();

            //this.lvMonitorObj.Groups.Clear();
            //var objTypeInfo = DataProvider.ObjTypeProvider.GetById(typeId);
            
            //var groupItem = new ListViewGroup(objTypeInfo.Name, HorizontalAlignment.Left);
            //this.lvMonitorObj.Groups.Add(groupItem);
            //添加Group之后，GridLine会丢失。
            
            var objs = DataProvider.MonitorObjProvider.GetByTypeId(typeId);
            for (int i = 0, l = objs.Count; i < l; i++)
            {
                var item = new ListViewItem(objs[i].SerialNo.ToString()) {Tag = objs[i], ImageIndex = 2};
                item.SubItems.Add(objs[i].Code);
                item.SubItems.Add(objs[i].Name);
                
                foreach(var obj in _objTypeAttrList)
                {
                    switch (obj.FieldName.ToUpper())
                    {
                        case "ATTRFIELD01":
                            item.SubItems.Add(objs[i].AttrField01);
                            break;
                        case "ATTRFIELD02":
                            item.SubItems.Add(objs[i].AttrField02);
                            break;
                        case "ATTRFIELD03":
                            item.SubItems.Add(objs[i].AttrField03);
                            break;
                        case "ATTRFIELD04":
                            item.SubItems.Add(objs[i].AttrField04);
                            break;
                        case "ATTRFIELD05":
                            item.SubItems.Add(objs[i].AttrField05);
                            break;
                        case "ATTRFIELD06":
                            item.SubItems.Add(objs[i].AttrField06);
                            break;
                        case "ATTRFIELD07":
                            item.SubItems.Add(objs[i].AttrField07);
                            break;
                        case "ATTRFIELD08":
                            item.SubItems.Add(objs[i].AttrField08);
                            break;
                        case "ATTRFIELD09":
                            item.SubItems.Add(objs[i].AttrField09);
                            break;
                        case "ATTRFIELD10":
                            item.SubItems.Add(objs[i].AttrField10);
                            break;
                        case "ATTRFIELD11":
                            item.SubItems.Add(objs[i].AttrField11);
                            break;
                        case "ATTRFIELD12":
                            item.SubItems.Add(objs[i].AttrField12);
                            break;
                        case "ATTRFIELD13":
                            item.SubItems.Add(objs[i].AttrField13);
                            break;
                        case "ATTRFIELD14":
                            item.SubItems.Add(objs[i].AttrField14);
                            break;
                        case "ATTRFIELD15":
                            item.SubItems.Add(objs[i].AttrField15);
                            break;
                        case "ATTRFIELD16":
                            item.SubItems.Add(objs[i].AttrField16);
                            break;
                        case "ATTRFIELD17":
                            item.SubItems.Add(objs[i].AttrField17);
                            break;
                        case "ATTRFIELD18":
                            item.SubItems.Add(objs[i].AttrField18);
                            break;
                        case "ATTRFIELD19":
                            item.SubItems.Add(objs[i].AttrField19);
                            break;
                        case "ATTRFIELD20":
                            item.SubItems.Add(objs[i].AttrField20);
                            break;
                    }
                }
                
                //item.Group = groupItem;
                this.lvMonitorObj.Items.Add(item);
            }
            
            
            
        }
        /// <summary>
        /// 根据监测对象类别创建类别属性列表。
        /// </summary>
        /// <param name="typeId">监测对象类别Id。</param>
        public void BindTypeAttrList(int typeId)
        {
            this.lvTypeAttr.Items.Clear();
            //this.lvTypeAttr.Groups.Clear();
            //var objTypeInfo = DataProvider.ObjTypeProvider.GetById(typeId);
            
            //var groupItem = new ListViewGroup(objTypeInfo.Name, HorizontalAlignment.Left);
            //this.lvTypeAttr.Groups.Add(groupItem);
            
            var objs = DataProvider.ObjTypeAttrProvider.GetByTypeId(typeId);
            String dateType = "";
            for(int i=0,l=objs.Count;i<l;i++)
            {
                switch (objs[i].DataType)
                {
                    case "Numeric":
                    case "Numric":
                        dateType = "数字型";
                        break;
                    case "String":
                    default:
                        dateType = "字符串";
                        break;
                }
                var item =
                    new ListViewItem(
                        new[]
                            {
                                objs[i].SerialNo.ToString(), objs[i].Name, objs[i].FieldName,
                                dateType
                            }, 1)
                        {
                            //BackColor = (i%2 == 0 ? Color.White : Color.FromArgb(237, 245, 250)),
                            Tag = objs[i],
                        };
                //item.Group = groupItem;    
                this.lvTypeAttr.Items.Add(item);
                //Trace.WriteLine(string.Format("Item's Width is {0}", item.GetBounds(ItemBoundsPortion.Entire).Width));
            }
        }
        /// <summary>
        /// 初始化监测对象的列结构。
        /// </summary>
        /// <param name="typeId"></param>
        public void InitMonitorObjList(int typeId)
        {
            this.lvMonitorObj.ShowGroups = true;
            this.lvMonitorObj.Columns.Clear();
            this.lvMonitorObj.Columns.AddRange(new[]
                                                   {
                                                       new ColumnHeader(){Name = "chSerialNo", Text = "序号",Width = 40}, 
                                                       new ColumnHeader(){Name = "chCode",Text = "编号", Width = 100},
                                                       new ColumnHeader(){Name = "chName",Text = "名称", Width = 120},
                                                    });
            this._objTypeAttrList = DataProvider.ObjTypeAttrProvider.GetByTypeId(typeId);
            foreach (var obj in _objTypeAttrList)
            {
                this.lvMonitorObj.Columns.Add(new ColumnHeader()
                                                  {
                                                      Name = string.Format("ch{0}", obj.FieldName),
                                                      Text = obj.Name,
                                                      Width = 120
                                                  });
            }
        }
        /// <summary>
        /// 初始化列别属性的列结构。
        /// </summary>
        public void InitTypeAttrList()
        {
            this.lvTypeAttr.ShowGroups = true;
            this.lvTypeAttr.Columns.Clear();
            this.lvTypeAttr.Columns.AddRange(new[]
                                                 {
                                                     new ColumnHeader() {Name = "chSerialNo", Text = "序号",Width = 40},
                                                     new ColumnHeader() {Name = "chName", Text = "名称",Width = 120},
                                                     new ColumnHeader() {Name = "cbFieldName", Text = "字段名", Width = 100,},
                                                     new ColumnHeader() {Name = "chDataType", Text="数据类型",Width = 100}, 
                                                 });
        }
        /// <summary>
        /// 监测对象类别增加。
        /// </summary>
        public void AddObjType()
        {
            if(this.tvObjType.SelectedNode != null)
            {
                var form = new FrmObjTypeEdit(int.Parse(this.tvObjType.SelectedNode.Tag.ToString()));
                if(form.ShowDialog(this) == DialogResult.OK)
                {
                    
                    this.tvObjType.SelectedNode.Nodes.Add(new TreeNode(form.ObjType.Name)
                                                              {
                                                                  ImageIndex = 3,
                                                                  Tag = form.ObjType.Id,
                                                                  SelectedImageIndex = 4,
                                                              });
                }
                form.Close();
            }
            else
            {
                MessageBox.Show("请先选择上一级类别节点！");
            }
        }
        /// <summary>
        /// 监测对象类别编辑。
        /// </summary>
        public void EditObjType()
        {
            if (this.tvObjType.SelectedNode != null && this.tvObjType.SelectedNode.Parent != null)
            {
                var typeId = int.Parse(this.tvObjType.SelectedNode.Tag.ToString());
                var obj = DataProvider.ObjTypeProvider.GetById(typeId);
                var form = new FrmObjTypeEdit(obj);
                if(form.ShowDialog(this) == DialogResult.OK)
                {
                    this.tvObjType.SelectedNode.Text = obj.Name;
                }
                form.Close();
            }
            else
            {
                MessageBox.Show("请先选择要编辑的类别节点！");
            }
        }
        /// <summary>
        /// 监测对象删除。
        /// </summary>
        public void DeleteObjType()
        {
            if(this.tvObjType.SelectedNode != null && this.tvObjType.SelectedNode.Tag.ToString()!="-1")
            {
                if(this.tvObjType.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("该节点下还有子节点，不能删除！");
                }
                else
                {
                    var typeId = int.Parse(this.tvObjType.SelectedNode.Tag.ToString());
                    var monitorObjs = DataProvider.MonitorObjProvider.GetByTypeId(typeId);
                    var attrObjs = DataProvider.ObjTypeAttrProvider.GetByTypeId(typeId);
                    if(monitorObjs.Count == 0&& attrObjs.Count == 0)
                    {

                        if(MessageBox.Show("您是否确定要删除？","删除确认",MessageBoxButtons.YesNo)==DialogResult.Yes )
                        {
                            if (DataProvider.ObjTypeProvider.Delete(typeId))
                            {
                                this.tvObjType.SelectedNode.Remove();
                            }
                            else
                            {
                                MessageBox.Show("删除失败！");
                            }    
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("该类别下已经关联监测对象或已经设定类别属性，不能进行删除！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的类别节点！");
            }
        }
        /// <summary>
        /// 增加监测对象。
        /// </summary>
        public void AddMonitorObj()
        {
            if (this.tvObjType.SelectedNode != null && this.tvObjType.SelectedNode.Parent != null)
            {
                var typeId = int.Parse(this.tvObjType.SelectedNode.Tag.ToString());
                var form = new FrmMonitorObjEdit(typeId);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindMonitorObjList(typeId);
                }
                form.Close();
            }
            else
            {
                MessageBox.Show("请先选择类别节点！");
            }
        }
        /// <summary>
        /// 编辑监测对象。
        /// </summary>
        public void EditMonitorObj()
        {
            if (this.lvMonitorObj.SelectedItems.Count > 0)
            {
                var obj = this.lvMonitorObj.SelectedItems[0].Tag as MonitorObjInfo;
                var form = new FrmMonitorObjEdit(obj);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindMonitorObjList(obj.TypeId);
                }
                form.Close();
            }
            else
            {
                MessageBox.Show("请先选择要编辑的类别属性记录！");
            }
        }
        /// <summary>
        /// 删除监测对象。
        /// </summary>
        public void DeleteMonitorObj()
        {
            if (this.lvMonitorObj.SelectedItems.Count > 0)
            {
                var obj = this.lvMonitorObj.SelectedItems[0].Tag as MonitorObjInfo;
                if (MessageBox.Show("您是否确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DataProvider.MonitorObjProvider.Delete(obj))
                        this.lvMonitorObj.SelectedItems[0].Remove();
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 增加类别属性。
        /// </summary>
        public void AddTypeAttr()
        {
            if (this.tvObjType.SelectedNode != null && this.tvObjType.SelectedNode.Parent != null)
            {
                var typeId = int.Parse(this.tvObjType.SelectedNode.Tag.ToString());
                var form = new FrmObjTypeAttrEdit(typeId);
                if(form.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindTypeAttrList(typeId);                    
                }
                form.Close();
            }
            else
            {
                MessageBox.Show("请先选择类别节点！");
            }
        }
        /// <summary>
        /// 编辑类别属性。
        /// </summary>
        public void EditTypeAttr()
        {
            if(this.lvTypeAttr.SelectedItems.Count > 0)
            {
                var obj = this.lvTypeAttr.SelectedItems[0].Tag as ObjTypeAttrInfo;
                var form = new FrmObjTypeAttrEdit(obj);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindTypeAttrList(obj.TypeId);
                }
                form.Close();
            }
            else
            {
                MessageBox.Show("请先选择要编辑的类别属性记录！");
            }
        }
        /// <summary>
        /// 删除类别属性。
        /// </summary>
        public void DeleteTypeAttr()
        {
            if (this.lvTypeAttr.SelectedItems.Count > 0)
            {
                var obj = this.lvTypeAttr.SelectedItems[0].Tag as ObjTypeAttrInfo;
                if (MessageBox.Show("您是否确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DataProvider.ObjTypeAttrProvider.Delete(obj))
                    {
                        this.BindTypeAttrList(obj.TypeId);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 窗体加载事件处理程序。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmObjTypeAttr_Load(object sender, EventArgs e)
        {
            this.CreateObjTypeTree();
            this.InitMonitorObjList(-1);
            this.InitTypeAttrList();
        }
        
        private void tvObjType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Parent != null)
            {
                e.Node.ImageIndex = 4;
                var typeId = int.Parse(e.Node.Tag.ToString());
                this.InitMonitorObjList(typeId);
                this.BindMonitorObjList(typeId);
                this.BindTypeAttrList(typeId);    
            }
        }

        private void tvObjType_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(this.tvObjType.SelectedNode != null)
            {
                if(this.tvObjType.SelectedNode.Parent != null)//root node
                {
                    this.tvObjType.SelectedNode.ImageIndex = 3;
                }
            }

        }

        private void tsObjType_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString().ToUpper())
            {
                case "ADD":
                    AddObjType();
                    break;
                case "EDIT":
                    EditObjType();
                    break;
                case "DELETE":
                    DeleteObjType();
                    break;
            }
        }

        private void tsMonitorObj_TypeAttr_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString().ToUpper())
            {
                case "ADD":
                    if(this.tabContent.SelectedIndex == 0)
                    {
                        this.AddMonitorObj();
                    }
                    else
                    {
                        this.AddTypeAttr();
                    }
                    break;
                case "EDIT":
                    if (this.tabContent.SelectedIndex == 0)
                    {
                        this.EditMonitorObj();
                    }
                    else
                    {
                        this.EditTypeAttr();
                    }
                    break;
                case "DELETE":
                    if (this.tabContent.SelectedIndex == 0)
                    {
                        this.DeleteMonitorObj();
                    }
                    else
                    {
                        this.DeleteTypeAttr();
                    }
                    break;
            }
        }
        #endregion

        #region D&G
        private void lvTypeAttr_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvObjType_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void tvObjType_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem listViewItem;
            TreeNode destTreeNode;
            var treeView = sender as TreeView;
            var x = tvObjType.PointToClient(new Point(e.X, e.Y)).X;
            var y = tvObjType.PointToClient(new Point(e.X, e.Y)).Y;
            if (e.Data.GetDataPresent("System.Windows.Forms.ListViewItem", false))
            {
                listViewItem = e.Data.GetData("System.Windows.Forms.ListViewItem") as ListViewItem;
                destTreeNode = (sender as TreeView).GetNodeAt(x, y);
                if (destTreeNode != null)
                {
                    
                    if(listViewItem.Tag is ObjTypeAttrInfo)
                    {
                        var obj = listViewItem.Tag as ObjTypeAttrInfo;
                        var typeId = int.Parse(destTreeNode.Tag.ToString());
                        if(typeId == -1)
                        {
                            MessageBox.Show("不能拖放到根节点！");
                        }
                        else if(typeId == obj.TypeId)
                        {
                            MessageBox.Show("不能拖放到同一个类别节点上！");
                            
                        }
                        else
                        {
                            obj.TypeId = typeId;
                            if(DataProvider.ObjTypeAttrProvider.Update(obj))
                            {
                                listViewItem.Remove();
                            }
                            else
                            {
                                MessageBox.Show("拖放失败！");
                            }
                        }
                    }
                    else if(listViewItem.Tag is MonitorObjInfo)
                    {
                        var obj = listViewItem.Tag as MonitorObjInfo;
                    }
                    
                }
            }
        }

        private void tvObjType_MouseHover(object sender, EventArgs e)
        {
            //var p = tvObjType.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            //this.Text = string.Format("x:{0},y:{1}", p.X, p.Y);
        }

        private void tvObjType_MouseMove(object sender, MouseEventArgs e)
        {
            var p = tvObjType.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            
            var obj = tvObjType.GetNodeAt(p);
            var oldObj = tvObjType.Tag as TreeNode;
            
            if(obj != null)
            {
                if(obj != oldObj)
                {
                    if (oldObj != null)
                    {
                        oldObj.BackColor = tvObjType.BackColor;
                    }
                    obj.BackColor = Color.Gray;
                    tvObjType.Tag = obj;    
                }
            }
            else
            {
                if (oldObj != null)
                {
                    oldObj.BackColor = tvObjType.BackColor;
                }
                tvObjType.Tag = null;
            }
            
        }

        private void tvObjType_MouseLeave(object sender, EventArgs e)
        {
            var node = tvObjType.Tag as TreeNode;
            if(node != null)
            {
                node.BackColor = tvObjType.BackColor;
            }
        }
        #endregion
    }
}
