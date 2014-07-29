using System;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    /// <summary>
    /// 项目财务到帐信息视图实体。
    /// </summary>
    [Serializable]
    public class ViewProjectIncomeInfo
    {
        #region Property
        /// <summary>
        /// Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 项目Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProjectId { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ProjectCode { get; set; }
        /// <summary>
        /// 项目公司编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CompanyCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ProjectName { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Month { get; set; }
        /// <summary>
        /// 到帐金额
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Amount { get; set; }

        /// <summary>
        /// 申请金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal ApplicationAmount { get; set; }
        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ViewProjectIncomeInfo)) return false;
            return Equals((ViewProjectIncomeInfo) obj);
        }

        public bool Equals(ViewProjectIncomeInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && other.ProjectId == ProjectId && Equals(other.ProjectCode, ProjectCode) && Equals(other.CompanyCode, CompanyCode) && Equals(other.ProjectName, ProjectName) && other.Year == Year && other.Month == Month && other.Amount == Amount;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id;
                result = (result*397) ^ ProjectId;
                result = (result*397) ^ (ProjectCode != null ? ProjectCode.GetHashCode() : 0);
                result = (result*397) ^ (CompanyCode != null ? CompanyCode.GetHashCode() : 0);
                result = (result*397) ^ (ProjectName != null ? ProjectName.GetHashCode() : 0);
                result = (result*397) ^ Year;
                result = (result*397) ^ Month;
                result = (result*397) ^ Amount.GetHashCode();
                return result;
            }
        }
    }
}
