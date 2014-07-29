using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TBeforehandNewListInfo
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
		public decimal FixturePrice { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public decimal FixtureCount { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string FixtureSum { get; set; }

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

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string UnitName { get; set; }

		///<summary>
		///
		///<summary>
		[Bindable(BindableSupport.Yes)]
		public string Unit { get; set; }


    }
}
