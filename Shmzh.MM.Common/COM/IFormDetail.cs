using System.ComponentModel;

namespace Shmzh.MM.Common
{
    /// <summary>
    /// 表单明细接口。
    /// </summary>
    public interface IFormDetail
    {
        /// <summary>
        /// 单据流水号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int EntryNo { get; set; }

        /// <summary>
        /// 单据明细顺序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        short SerialNo { get; set; }

        /// <summary>
        /// 物料编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemCode { get; set; }

        /// <summary>
        /// 物料名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemName { get; set; }

        /// <summary>
        /// 规格型号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemSpec { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        short ItemUnit { get; set; }

        /// <summary>
        /// 单位名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemUnitName { get; set; }

        /// <summary>
        /// 单价。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal ItemPrice { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal ItemNum { get; set; }

        /// <summary>
        /// 金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal ItemMoney { get; set; }
        
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Remark { get; set; }
    }
}