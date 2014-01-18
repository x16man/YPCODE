using System.Data;
using Shmzh.MM.Common;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace Shmzh.MM.Facade
{
	/// <summary>
	/// Entry类，主要是提供设置单据的状态功能。
	/// </summary>
	public class Entry
	{
		#region 成员变量
		private DataTable DT;
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion

		#region 构造函数
		/// <summary>
		/// 单据类的构造函数。
		/// </summary>
		/// <param name="oDataTable">DataTable:	单据的数据表.</param>
		public Entry( DataTable oDataTable )
		{
			DT = oDataTable;
		}
		#endregion

		#region 公开方法
		/// <summary>
		/// 根据不同的操作模式获取单据的状态.
		/// </summary>
		/// <param name="OpMode">string:	操作方式.</param>
		/// <returns>string:	单据状态.</returns>
		public string  GetEntryState( string OpMode)
		{
			DataRow oDataRow = DT.Rows[0];
			string EntryState = OP.New;

			var oDocType = short.Parse(oDataRow[DocBaseData.DOCCODE_FIELD].ToString());

			switch (OpMode)
			{
				case OP.New:
                case OP.Copy:
					EntryState =  DocStatus.New;
					break;
				case OP.Bor://生成收料单.
					EntryState = DocStatus.New;
					break;
				case OP.Check://生成验收单.
					EntryState = DocStatus.New;
					break;
				case OP.NewAndPresent:
					EntryState = DocStatus.Present;
					break;
				case OP.NewAndAssign:
					EntryState = DocStatus.Assigned;
					break;
				case OP.Edit:
					EntryState = DocStatus.New;
					break;
				case OP.EditAndPresent:
					EntryState = DocStatus.Present;
					break;
				case OP.EditAndAssign:
					EntryState = DocStatus.Assigned;
					break;
				case OP.Submit:
					EntryState = DocStatus.Present;
					break;
				case OP.Assigned:
					EntryState = DocStatus.Assigned;
					break;
                case OP.Reject:
			        EntryState = DocStatus.OrdReject;
                    break;
				case OP.FirstAudit:
					if ( oDataRow[InItemData.AUDIT1_FIELD].ToString() == AuditResult.Passed )
					{
						int AuditLevel = 0;
						SysSystem mySysSystem = new SysSystem();
						AuditLevel = mySysSystem.GetAuditLevel(oDocType);
						if (AuditLevel == 1)
						{
							EntryState = DocStatus.TrdPass;
						}
						else
						{
							EntryState = DocStatus.FstPass;
						}
					}
					else
					{
						if ( oDataRow[InItemData.AUDIT1_FIELD].ToString() == AuditResult.NoPassed )
						{
							EntryState = DocStatus.FstNoPass;
						}
					}
					break;
				case OP.SecondAudit:
					if ( oDataRow[InItemData.AUDIT2_FIELD].ToString() == AuditResult.Passed )
					{
						int AuditLevel = 0;
						SysSystem mySysSystem = new SysSystem();
						AuditLevel = mySysSystem.GetAuditLevel(oDocType);
						if (AuditLevel == 2)
						{
							EntryState = DocStatus.TrdPass;
						}
						else
						{
							EntryState = DocStatus.SecPass;
						}
					}
					else
					{
						if ( oDataRow[InItemData.AUDIT2_FIELD].ToString() == AuditResult.NoPassed )
						{
							EntryState = DocStatus.SecNoPass;
						}
					}
					break;
				case OP.ThirdAudit:
					if ( oDataRow[InItemData.AUDIT3_FIELD].ToString() == AuditResult.Passed )
					{
                        //var obj = DataProvider.SettingProvider.GetByKey("ROSNeedWZAudit");
                        //if(obj == null || obj.Value!="1" || oDocType != 1)
                        //{
                        //    EntryState = DocStatus.TrdPass;
                        //}
                        //else
                        //{
                        //    EntryState = DocStatus.ThirdPass;
                        //}
                        EntryState = DocStatus.TrdPass;
                        Logger.Debug(EntryState);
					}
					else
					{
						if ( oDataRow[InItemData.AUDIT3_FIELD].ToString() == AuditResult.NoPassed )
						{
							EntryState = DocStatus.TrdNoPass;
						}
					}
					break;
                case OP.WZAudit:
                    if (oDataRow[InItemData.AUDIT4_FIELD].ToString() == AuditResult.Passed)
                    {
                        EntryState = DocStatus.WZPass;
                    }
                    else
                    {
                        if (oDataRow[InItemData.AUDIT4_FIELD].ToString() == AuditResult.NoPassed)
                        {
                            EntryState = DocStatus.WZNoPass;
                        }
                    }
			        break;
				case OP.I:
					EntryState = DocStatus.Received;
					break;
				case OP.O:
					EntryState = DocStatus.Drawed;
					break;
				case OP.Red:
					EntryState = DocStatus.New;
					break;
				case OP.Pay:
					EntryState = DocStatus.Pay;
					break;
				case OP.NoPay:
					EntryState = DocStatus.OrdReject;
					break;
			}
			return EntryState;
		}
		#endregion
	}
}
