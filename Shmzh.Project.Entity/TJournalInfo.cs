using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TJournalInfo
    {
        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string questionflg { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string question { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string way { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime Jdate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime submissionDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string submissionMan { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string content { get; set; }

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
