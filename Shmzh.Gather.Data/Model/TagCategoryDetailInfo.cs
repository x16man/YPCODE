using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 指标与指标分类的关系实体。
    /// </summary>
    public class TagCategoryDetailInfo
    {
        #region Property
        /// <summary>
        /// 指标分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int CategoryId { get; set; }
        
        /// <summary>
        /// 指标Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagId { get; set; }
        #endregion
    }
}
