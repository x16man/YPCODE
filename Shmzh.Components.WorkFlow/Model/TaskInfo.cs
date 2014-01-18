using System;
using System.ComponentModel;

namespace Shmzh.Components.WorkFlow.Model
{
    /// <summary>
    /// 待办事宜实体。
    /// </summary>
    [Serializable]
    public class TaskInfo
    {
        #region Property
        /// <summary>
        /// 任务ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Id { get; set; }
        

        /// <summary>
        /// 任务ID
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int TaskId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TaskName { get; set; }

        /// <summary>
        /// 过程ID
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProcId { get; set; }

        /// <summary>
        /// 任务描述，主题，当前处理
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ProcName { get; set; }

        /// <summary>
        /// 重要程度
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Priority { get; set; }

        /// <summary>
        /// 提交人
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Poster { get; set; }

        /// <summary>
        /// 任务到达日期时间
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime RecTime { get; set; }

        /// <summary>
        /// 是否存在URL,作为任务发起的连接
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool HasURL { get; set; }

        /// <summary>
        /// URL地址
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string URL { get; set; }

        /// <summary>
        /// 东兰工作流ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int WFID { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string WFCD { get; set; }
        /// <summary>
        /// 单据ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RSID { get; set; }
        /// <summary>
        /// 类型用来表示来之东兰工作流（0）还是物料系统（1），还是TODOList（2）。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Type { get; set; }
        #endregion

        #region CTOR
        public TaskInfo()
        {
            RecTime = DateTime.Now;
        }
        #endregion
    }
}
