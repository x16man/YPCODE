using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TBeforhandCancelListInfo
    {
        ///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public int PID { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string FixtureName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public int FixtureCount { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime InvestDate { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal BuyMoney { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal NowMoney { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string Remark { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string CreateEmpCode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime CreateDate { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string UpdateEmpcode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime UpdateDate { get; set; }


    }
}
