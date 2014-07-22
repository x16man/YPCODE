using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TBeforehandReportInfo
    {
        		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string ItemName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime PlanDate { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public int PlanWork { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string PlanContent { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal Stuff { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string Comment { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal PurchaseMoney { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal SettingMoney { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal CivilworkMoney { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal OtherMoney { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string CreateEmpCode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string CreateName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime  CreateDate { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string UpdateEmpCode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string UpdateName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime UpdateDate { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string ApproveEmpCode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string ApproveName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string PrincipalEmpCode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string PrincipalName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string Comment1 { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string State { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string TaskGuid { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime ApproveDate { get; set; }



    }
}
