using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 指标分类的实体类。
    /// </summary>
    public class TagCategoryInfo
    {
        #region Property
        /// <summary>
        /// 指标分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 指标分类名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 上级分类Id.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentId { get; set; }

        /// <summary>
        /// 序号.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int SerialNo { get; set; }
        #endregion

        #region CTOR
        public TagCategoryInfo()
        {
        }

        #endregion
    }
}
