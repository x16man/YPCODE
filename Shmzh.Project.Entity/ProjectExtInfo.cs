using System;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    /// <summary>
    /// 项目信息的扩展属性.
    /// </summary>
    [Serializable]
    public class ProjectExtInfo
    {
        ///<summary>
        ///项目Id.
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public int ProjectId { get; set; }

        ///<summary>
        ///是否默认隐藏.
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsHidden { get; set; }

    }
}
