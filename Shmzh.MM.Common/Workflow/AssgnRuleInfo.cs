using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.MM.Common.Workflow
{
    public class AssgnRuleInfo
    {
        #region Property
        [Bindable(BindableSupport.Yes)]
        public int ACT_ID { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string Based_On { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string Method { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int Dept_Id { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int Role_Id { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int Team_Id { get; set; }
        [Bindable(BindableSupport.Yes)]
        public string Grantor_Id { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int Ex_Func { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int IsDept { get; set; }
        [Bindable(BindableSupport.Yes)]
        public int IsUser { get; set; }
        #endregion

    }
}
