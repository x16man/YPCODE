using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.MM.Common.Workflow
{
    public class RoutingRuleInfo
    {
        #region Property


        [Bindable(BindableSupport.Yes)]
        public int Pre_Act_Id { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Curr_Act_Id { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Completion_Flag { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Next_Act_Id { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Pre_Depnt_Set { get; set; }
        #endregion
    }
}
