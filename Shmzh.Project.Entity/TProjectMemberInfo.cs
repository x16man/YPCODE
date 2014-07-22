using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TProjectMemberInfo
    {
        ///<summary>
        ///项目ID
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///工号
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCode { get; set; }

        ///<summary>
        ///姓名
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCnName { get; set; }

        ///<summary>
        ///登录名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string LoginName { get; set; }

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
