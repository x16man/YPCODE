
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// 检验项的业务规则层。
	/// </summary>
	public class CITM :Messages
	{
		#region 构造函数
		public CITM()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		public  object GetByRepCode(int RepCode)
		{
			CITMData oCITMData ;
			CITMs oCITMs = new CITMs();
			oCITMData = (CITMData)oCITMs.GetByRepCode(RepCode);
			return oCITMData;

		}
	}
}
