using System;
using System.ComponentModel;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryDetailInfo
    {
        #region Property

        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int ParentId { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int ConCode { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string ConName { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string ItemCode { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string ItemName { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string ItemSpec { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string ItemUnit { get; set; }

        [Bindable(BindableSupport.Yes)]
        public Decimal CarryingAmount { get; set; }
        [Bindable(BindableSupport.Yes)]
        public Decimal InventoryAmount { get; set; }
        #endregion

        #region CTOR
        public InventoryDetailInfo()
        {}
        #endregion
    }
}
