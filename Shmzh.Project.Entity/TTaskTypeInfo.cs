using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TTaskTypeInfo
    {
        ///<summary>
        ///类型名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        ///<summary>
        ///备注
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment1 { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment2 { get; set; }


    }
}
