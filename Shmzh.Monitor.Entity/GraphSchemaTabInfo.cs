using System;
using System.ComponentModel;
using System.Collections.Generic;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class GraphSchemaTabInfo
    {
        private List<GraphSchemaRTagInfo> rTagList;
        #region Property
        /// <summary>
        /// TabId.
        /// </summary>
        [Bindable(true)]
        public Int32 TabId { get; set; }

        /// <summary>
        /// 方案Id。
        /// </summary>
        [Bindable(true)]
        public Int32 SchemaId { get; set; }

        /// <summary>
        /// Tab 名。
        /// </summary>
        [Bindable(true)]
        public String TabName { get; set; }
        
        /// <summary>
        /// Tab 类型。
        /// </summary>
        [Bindable(true)]
        public Byte TabType { get; set; }
        
        /// <summary>
        /// Tab 可见性。
        /// </summary>
        [Bindable(true)]
        public Boolean TabVisible { get; set; }

        /// <summary>
        /// 标题。
        /// </summary>
        [Bindable(true)]
        public String Title { get; set; }

        /// <summary>
        /// 标题 可见性。
        /// </summary>
        [Bindable(true)]
        public Boolean TitleVisible { get; set; }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(true)]
        public Int32 SerialNumber { get; set; }

        /// <summary>
        /// GraphSchemaRTagInfo 列表。
        /// </summary>
        public List<GraphSchemaRTagInfo> RTagList
        {
            get
            {
                if (rTagList == null)
                    rTagList = new List<GraphSchemaRTagInfo>();
                return rTagList;
            }
            set { rTagList = value; }
        }
       
        #endregion

        #region CTOR
        public GraphSchemaTabInfo()
        {
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{8}:

- TabId: {0}
- SchemaId:{1}
- TabName: {2}
- TabType:{3}
- TabVisible:{4}
- Title: {5}
- TitleVisible:{6}
- SerialNumber:{7}
",

                this.TabId,
                this.SchemaId,
                this.TabName,
                this.TabType,
                this.TabVisible,
                this.Title,
                this.TitleVisible,
                this.SerialNumber,
                this.GetType());
        }
    }

}
