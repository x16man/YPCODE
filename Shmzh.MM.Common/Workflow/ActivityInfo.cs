using System;

namespace Shmzh.MM.Common.Workflow
{
    using System.ComponentModel;
    public class ActivityInfo
    {
        #region property
        [Bindable(BindableSupport.Yes)]
        public int Act_Id { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Proc_Id { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Act_Name { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Act_Url { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Task_Name { get; set; }

        [Bindable(BindableSupport.Yes)]
        public DateTime Time_Allowed { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Rule_Applied { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Ex_Pre_Rul_Func { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Ex_Post_Rul_Func { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Act_Type { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string OR_Merge_Flag { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Num_Votes_Needed { get; set; }

        [Bindable(BindableSupport.Yes)]
        public int Auto_Executive { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string ACT_DESC { get; set; }

        #endregion
    }
}