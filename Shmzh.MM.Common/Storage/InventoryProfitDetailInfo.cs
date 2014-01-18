using System.ComponentModel;
using Shmzh.MM.Common;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryProfitDetailInfo:IFormDetail
    {
        #region Implementation of IFormDetail

        /// <summary>
        /// 单据流水号。
        /// </summary>
        public int EntryNo { get; set; }

        /// <summary>
        /// 单据明细顺序号。
        /// </summary>
        public short SerialNo { get; set; }

        /// <summary>
        /// 物料编号。
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 物料名称。
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 规格型号。
        /// </summary>
        public string ItemSpec { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public short ItemUnit { get; set; }

        /// <summary>
        /// 单位名称。
        /// </summary>
        public string ItemUnitName { get; set; }

        /// <summary>
        /// 单价。
        /// </summary>
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// 数量。
        /// </summary>
        public decimal ItemNum { get; set; }

        /// <summary>
        /// 金额。
        /// </summary>
        public decimal ItemMoney { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region Property

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoCode { get; set; }

        /// <summary>
        /// 仓库名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoName { get; set; }

        /// <summary>
        /// 架位Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ConCode { get; set; }

        /// <summary>
        /// 架位名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ConName { get; set; }

        /// <summary>
        /// 库存Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal StkId { get; set; }

        /// <summary>
        /// 账面数量
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal CarryingAmount { get; set; }

        /// <summary>
        /// 盘点数量。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal InventoryAmount { get; set; }
        #endregion
    }
}