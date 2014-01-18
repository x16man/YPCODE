using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryInfo
    {
        #region Property
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string StoCode { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string StoName { get; set; }
        [Bindable(BindableSupport.Yes)]
        public DateTime Date { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int UserId { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion

        #region CTOR
        public InventoryInfo()
        {
        }

        #endregion
    }
}
