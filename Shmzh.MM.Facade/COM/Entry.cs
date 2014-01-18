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
	/// Entry�࣬��Ҫ���ṩ���õ��ݵ�״̬���ܡ�
	/// </summary>
	public class Entry
	{
		#region ��Ա����
		private DataTable DT;
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion

		#region ���캯��
		/// <summary>
		/// ������Ĺ��캯����
		/// </summary>
		/// <param name="oDataTable">DataTable:	���ݵ����ݱ�.</param>
		public Entry( DataTable oDataTable )
		{
			DT = oDataTable;
		}
		#endregion

		#region ��������
		/// <summary>
		/// ���ݲ�ͬ�Ĳ���ģʽ��ȡ���ݵ�״̬.
		/// </summary>
		/// <param name="OpMode">string:	������ʽ.</param>
		/// <returns>string:	����״̬.</returns>
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
				case OP.Bor://�������ϵ�.
					EntryState = DocStatus.New;
					break;
				case OP.Check://�������յ�.
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
