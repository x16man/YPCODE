namespace WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	//
	using NBoolean = NullableTypes.NullableBoolean;
	using NByte = NullableTypes.NullableByte; 
	using NInt16 = NullableTypes.NullableInt16;
	using NInt32 = NullableTypes.NullableInt32;
	using NInt64 = NullableTypes.NullableInt64;
	using NSingle = NullableTypes.NullableSingle; 
	using NDouble = NullableTypes.NullableDouble;
	using NDecimal = NullableTypes.NullableDecimal;
	using NString = NullableTypes.NullableString;
	using NDateTime = NullableTypes.NullableDateTime;
	
	/// <summary>
	///		WUC_WithDrawAnalysis 的摘要说明。
	/// </summary>
	public partial class WUC_WithDrawAnalysis : System.Web.UI.UserControl
	{

		#region 属性
		/// <summary>
		/// 开始日期。
		/// </summary>
		public NDateTime StartDate
		{
			get {return (NDateTime)this.dateStartDate.Value;}
			set {this.dateStartDate.Value = value;}
		}
		/// <summary>
		/// 结束日期。
		/// </summary>
		public NDateTime EndDate
		{
			get {return (NDateTime)this.dateStartDate.Value;}
			set {this.dateEndDate.Value = value;}
		}
		
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.StartDate = new NDateTime(DateTime.Now.Year,DateTime.Now.Month,1);
				this.EndDate = this.StartDate.Value.AddMonths(1);
			}
		}
	}
}
