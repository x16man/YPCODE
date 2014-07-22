using System;
using System.ComponentModel;
namespace Shmzh.Project.Entity
{
    /// <summary>
    /// 项目财务到帐信息实体。
    /// </summary>
    [Serializable]
    public class ProjectYearIncomeInfo
    {
        #region Property

        /// <summary>
        /// Id.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }
        /// <summary>
        /// 项目Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProjectId { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Year { get; set; }
        /// <summary>
        /// 财务到帐金额
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Amount { get; set; }
        #endregion

        #region CTOR
        public ProjectYearIncomeInfo(){}
        #endregion
    }
}
