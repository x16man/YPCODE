using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TProjectManFeeInfo
    {
        ///<summary>
        ///项目ID
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///工程内容
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Proceeding { get; set; }

        ///<summary>
        ///人工
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Specs { get; set; }

        ///<summary>
        ///单价
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Unitprice { get; set; }

        ///<summary>
        ///总价
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal TotalPrices { get; set; }

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
        ///备注2
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
