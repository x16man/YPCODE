using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TTempTaskInfo
    {
        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fType { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fPriority { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fState { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime fPlanStartDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime fPlanFinishDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fPlanWorkTimeLimit { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime fRealStartDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime fRealFinishDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fRealWorkTimeLimit { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fCompletePercent { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fPrincipal { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fMaster { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fExaminant { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string fMemo { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime fCreateTime { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string TaskGuid { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AduitGuid { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditEmpCode { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditEmpName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime AuditDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckEmpCode { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckEmpName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ChecktDate { get; set; }


    }
}
