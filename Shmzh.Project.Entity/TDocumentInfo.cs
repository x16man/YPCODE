using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TDocumentInfo
    {
        ///<summary>
        ///文档名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        ///<summary>
        ///项目ID
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///文档描述
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Subject { get; set; }

        ///<summary>
        ///上传日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateDate { get; set; }

        ///<summary>
        ///创建人
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string man { get; set; }

        ///<summary>
        ///文件类型
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string filetype { get; set; }

        ///<summary>
        ///文档标识
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Documenttype { get; set; }

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


    }
}
