using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shmzh.Monitor.Gadget
{
    public class HoverInfo : ITriggerEvent
    {
        #region Field
        private Boolean isMouseOver = false;
        private List<HoverInfo> childNodes;
        private Rectangle _hotBounds = Rectangle.Empty;
        #endregion

        public virtual String TriggerEvent { get; set; }

        public virtual bool IsMouseOver
        {
            get { return isMouseOver; }
            set { isMouseOver = value; }
        }

        /// <summary>
        /// 更新数据时要刷新的边界矩形。
        /// </summary>
        public virtual Rectangle Bounds { get; set; }

        /// <summary>
        /// 用户关联数据。
        /// </summary>
        public Object Tag { get; set; }

        /// <summary>
        /// 触发事件的边界矩形。
        /// </summary>
        public virtual Rectangle HotBounds
        {
            get 
            {
                return _hotBounds == Rectangle.Empty ? Bounds : _hotBounds;
            }
            set 
            {
                _hotBounds = value;
            }
        }

        /// <summary>
        /// 父级节点。
        /// </summary>
        public HoverInfo ParentNode { get; set; }
        
        /// <summary>
        /// 子级节点。
        /// </summary>
        public List<HoverInfo> ChildNodes
        {
            get
            {
                if (childNodes == null)
                    childNodes = new List<HoverInfo>();
                return childNodes;
            }
            set { childNodes = value; }
        }
    }
}
