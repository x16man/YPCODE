using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TProjectStuffFeeInfo
    {
        ///<summary>
        ///项目ID
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///材料名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string DatumName { get; set; }

        ///<summary>
        ///规格
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Specs { get; set; }

        ///<summary>
        ///类型
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Type { get; set; }

        ///<summary>
        ///数量
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Amount { get; set; }

        ///<summary>
        ///单价
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal UnitPrice { get; set; }

        ///<summary>
        ///总价
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal TotalPrices { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Unit { get; set; }

        ///<summary>
        ///标识
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int Flg { get; set; }

        ///<summary>
        ///备注
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment { get; set; }

        ///<summary>
        ///备注1
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment1 { get; set; }

        ///<summary>
        ///备注1
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment2 { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal STotalPrices { get; set; }


    }
}
