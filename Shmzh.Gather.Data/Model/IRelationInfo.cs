using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 报表分类实体类。
    /// </summary>
    public interface IRelationInfo
    {
        #region Property
        /// <summary>
        /// 报表与分类关系的Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int Id { get; set; }
        
        /// <summary>
        /// 报表分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int CategoryId { get; set; }

        /// <summary>
        /// 报表模板Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string SchemaId { get; set; }
        /// <summary>
        /// 报表模板名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string SchemaName { get; set; }
        /// <summary>
        /// 报表模板类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string SchemaType { get; set; }

        /// <summary>
        /// 报表模板的时间类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string SchemaCycle { get; set; }

        /// <summary>
        /// 报表模板的Url。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string SchemaUrl { get; set; }

        /// <summary>
        /// 报表模板描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Remark{ get; set;}
        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int Sort { get; set; }

        #endregion

    }
}
