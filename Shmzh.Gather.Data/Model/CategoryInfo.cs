using System;
using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 报表分类实体类。
    /// </summary>
    [Serializable]
    public class CategoryInfo
    {
        #region Property
        /// <summary>
        /// 报表分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }
        
        /// <summary>
        /// 报表分类名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 上级分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentId { get; set; }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Sort { get; set; }

        public int AccessControl { get; set; }
        public int OldAccessControl { get; set; }
        public bool CanView { get; set; }

        public bool CanSave { get; set; }

        public bool CanSure { get; set; }

        public bool CanCancel { get; set; }
        #endregion

        /// <summary>
        /// 报表分类实体的构造函数。
        /// </summary>
        public CategoryInfo()
        {}

        
    }
}
