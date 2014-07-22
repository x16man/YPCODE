using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TFinishCancelFeeInfo
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
		public string FixtureNo { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string FixtureName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string FixtureSpecial { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string Manufacturer { get; set; }

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
		public string Place { get; set; }


    }
}
