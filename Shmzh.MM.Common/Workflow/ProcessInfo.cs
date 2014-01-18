using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.MM.Common.Workflow
{
    public class ProcessInfo
    {
        #region Property

        [Bindable(BindableSupport.Yes)]
        public int Proc_ID { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Proc_Name { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Proc_Desc { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string ViewUrl { get; set; }
        #endregion
    }
}
