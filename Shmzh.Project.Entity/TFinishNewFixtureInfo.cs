using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TFinishNewFixtureInfo
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
		public string PrvCode { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string PrvName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal FixtureMoney { get; set; }

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
		public decimal Distributionfees { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal DepreciationCost { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public DateTime AccountDate { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string Place { get; set; }


    }
}
