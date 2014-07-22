using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 指标类别信息实体。
    /// </summary>
    [Serializable]
    public class TagCategoryInfo
    {
        #region CTOR
        public TagCategoryInfo()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// 指标类别Id。
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 指标类别名称。
        /// </summary>
        public String CategoryName { get; set; }

        /// <summary>
        /// 父类别Id。
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 排序号。
        /// </summary>
        public int SerialNumber { get; set; }
        #endregion
    }
}
