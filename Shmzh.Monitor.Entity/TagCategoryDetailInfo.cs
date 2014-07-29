using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 指标类别与指标对应关系信息实体。
    /// </summary>
    [Serializable]
    public class TagCategoryDetailInfo
    {
        #region CTOR
        public TagCategoryDetailInfo()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// 指标类别Id。
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 指标Id。
        /// </summary>
        public String TagId { get; set; }      
        #endregion
    }
}
