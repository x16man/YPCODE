﻿using System;
using System.Windows.Forms;

namespace Shmzh.Components.Util
{
    /// <summary>
    /// 调用方法：在treeview的AfterCheck事件中。
    /// <para>private void treeView1_AfterCheck(object sender, TreeViewEventArgs e) </para>
    /// <para>{</para>
    /// <para>   TreeViewCheck.CheckControl(e)</para>
    /// <para>}</para>
    /// </summary>
    public class TreeViewCheck
    {
        /// <summary>
        /// 系列节点 Checked 属性控制
        /// </summary>
        /// <param name="e"></param>
        public static void CheckControl(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node != null && !Convert.IsDBNull(e.Node))
                {
                    CheckParentNode(e.Node);
                    if (e.Node.Nodes.Count > 0)
                    {
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                }
            }
        }

        /// <summary>
        /// 系列节点 Checked 属性控制
        /// </summary>
        /// <param name="tn"></param>
        public static void CheckControl(TreeNode tn)
        {
            if (tn != null && !Convert.IsDBNull(tn))
            {
                CheckParentNode(tn);
                if (tn.Nodes.Count > 0)
                {
                    CheckAllChildNodes(tn, tn.Checked);
                }
            }
        }

        #region 私有方法

        //改变所有子节点的状态
        private static void CheckAllChildNodes(TreeNode pn, bool isChecked)
        {
            foreach (TreeNode tn in pn.Nodes)
            {
                tn.Checked = isChecked;

                if (tn.Nodes.Count > 0)
                {
                    CheckAllChildNodes(tn, isChecked);
                }
            }
        }

        //改变父节点的选中状态，此处为所有子节点不选中时才取消父节点选中，可以根据需要修改
        private static void CheckParentNode(TreeNode curNode)
        {
            bool bChecked = false;

            if (curNode.Parent != null)
            {
                foreach (TreeNode node in curNode.Parent.Nodes)
                {
                    if (node.Checked)
                    {
                        bChecked = true;
                        break;
                    }
                }

                if (bChecked)
                {
                    curNode.Parent.Checked = true;
                    CheckParentNode(curNode.Parent);
                }
                else
                {
                    curNode.Parent.Checked = false;
                    CheckParentNode(curNode.Parent);
                }
            }
        }

        #endregion
    }
}
