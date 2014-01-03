using System;
using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 报表分类实体类。
    /// </summary>
    [Serializable]
    public class RelationInfo : IRelationInfo
    {
        #region Property
        /// <summary>
        /// 报表与分类关系的Id。
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 报表分类Id。
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 报表Id。
        /// </summary>
        public string SchemaId { get; set; }

        /// <summary>
        /// 报表模板名称。
        /// </summary>
        public string SchemaName{get;set;}

        /// <summary>
        /// 报表模板类型。
        /// </summary>
        public string SchemaType{get; set;}

        /// <summary>
        /// 报表模板的时间类型。
        /// </summary>
        public string SchemaCycle{get; set;}

        /// <summary>
        /// 报表模板的Url。
        /// </summary>
        public string SchemaUrl{get;set ;}

        /// <summary>
        /// 报表模板描述。
        /// </summary>
        public string Remark
        {
            get; set;
        }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Sort { get; set; }

        public bool CanView { get; set; }

        public bool CanSave { get; set; }

        public bool CanSure { get; set; }

        public bool CanCancel { get; set; }

        public int AccessControl { get; set; }
        public int OldAccessControl { get; set; }
        #endregion

        /// <summary>
        /// 报表与分类关系实体的构造函数。
        /// </summary>
        public RelationInfo()
        {}
    }
}
