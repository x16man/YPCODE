using System;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 工作流系统中的用户。
    /// </summary>
    [Serializable]
    public class TB_UsersInfo
    {
        #region property
        /// <summary>
        /// 用户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int UserId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string HRID { get; set; }

        /// <summary>
        /// 登陆名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// 所属域。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Domain { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string PWD { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserDspName { get; set; }

        /// <summary>
        /// 邮件地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EMail { get; set; }

        /// <summary>
        /// 电话。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Tel { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Dept { get; set; }

        /// <summary>
        /// 职位名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string JobTitle { get; set; }

        /// <summary>
        /// 上级部门主管工号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SpHRID { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 成本中心。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CostCenter { get; set; }

        /// <summary>
        /// 地区编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string LocationCode { get; set; }

        /// <summary>
        /// 是否删除。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool Enalbe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsOut { get; set; }

        /// <summary>
        /// 代理用户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int AgentUserId { get; set; }

        /// <summary>
        /// 语言。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Language { get; set; }

        /// <summary>
        /// 移动电话。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string MbTel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool CanAssignOut { get; set; }

        /// <summary>
        /// 是否离职。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsLeave { get; set; }

        /// <summary>
        ///  离职时间
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime LeaveDate { get; set; }

        /// <summary>
        /// 用户分类。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int UserCatId { get; set; }

        #endregion
    }
}
