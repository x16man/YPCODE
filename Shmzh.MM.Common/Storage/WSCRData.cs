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
* penalties.  Any violations of this copyright will be WSCRecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// WSCRData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WSCRData:DataSet
	{
		#region ������Ϣ
		public const string NOOBJECT = "";
		public const string ADD_FAILED = "";
		public const string ROLL_FAILED ="";
		public const string ADD_SUCCESSED = "";
		public const string UPDATE_FAILED = "";
		public const string UPDATE_SUCCESSED = "";
		public const string DELETE_FAILED = "";
		public const string DELETE_SUCCESSED = "";
		public const string UPDATESTATE_FAILED = "";
		public const string UPDATESTATE_SUCCESSED = "";
		public const string FIRSTAUDIT_FAILED = "";
		public const string FIRSTAUDIT_SUCCESSED = "";
		public const string SECONDAUDIT_FAILED = "";
		public const string SECONDAUDIT_SUCCESSED = "";
		public const string THIRDAUDIT_FAILED = "";
		public const string THIRDAUDIT_SUCCESSED = "";
		public const string PRESENT_FAILED = "";
		public const string PRESENT_SUCCESSED = "";
		public const string CANCEL_FAILED = "";
		public const string CANCEL_SUCCESSED = "";
		public const string AFFIRM_SUCCESSED = "";
		public const string AFFIRM_FAILED = "";
		#endregion

		#region ��Ա����
		/// <value>��������ʵ��</value>
		public const string WSCR_TABLE  = "WSCR";						//������
		public const string PROPOSER_FIELD		= "Proposer";			//�����ˡ�
		public const string PROPOSERCODE_FIELD  = "ProposerCode";		//�����˱�š�
		public const string REQDEPT_FIELD		= "ReqDept";			//���벿�š�
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";		//���벿�����ơ�
		public const string REQREASONCODE_FIELD = "ReqReasonCode";		//�������ɴ��롣
		public const string REQREASON_FIELD     = "ReqReason";			//�������ɡ�
		public const string PLANNUM_FIELD			= "PlanNum";		//Ӧ������
		public const string STOCKNUM_FIELD       = "StockNum";				//��ǰ��档
		public const string STONAME_FIELD		= "StoName";
		public const string	STOCODE_FIELD		= "StoCode";
		public const string NoPurpose = "�ɹ����뵥����Ҫָ����;��";
		public const string NoReqDept = "�ɹ����뵥����ָ�����벿�ţ�";
		public const string NoProposer = "�ɹ����뵥����ָ�������ˣ�";
		public const string XDelete = "ֻ�������ϵ�״̬�²�����ɾ����";
		public const string XCancel = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ������ϲ�����";
		public const string XPresent = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ����ύ������";
		public const string XFirstAudit = "ֻ���ڵ����Ѿ��ύ��״̬�£�������Ե��ݽ���һ��������";
		public const string XSecondAudit = "ֻ���ڵ���һ������ͨ����ǰ���£�������Ե��ݽ��ж���������";
		public const string XThirdAudit = "ֻ���ڵ��ݶ�������ͨ����ǰ���£�������Ե��ݽ�������������";
		public const string XUpdate = "ֻ���ڵ������½�,����,������ͨ����ǰ���£�������Ե��ݽ����޸ģ�";
		#endregion

		#region ����
		/// <summary>
		/// �ɹ����뵥�ļ�¼����
		/// </summary>
		public int Count
		{
			get { return this.Tables[WSCRData.WSCR_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ������ɹ����뵥�����ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(WSCR_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;

			columns.Add(PROPOSER_FIELD, typeof(System.String));			//�����ˡ�
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//�����˱�š�
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//���벿�š�
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//���벿�����ơ�
			columns.Add(REQREASONCODE_FIELD, typeof(System.String));	//�������ɡ�
			columns.Add(REQREASON_FIELD, typeof(System.String));		//�������ɡ�
			columns.Add(PLANNUM_FIELD, typeof(System.String));			//Ӧ��������
			columns.Add(STOCKNUM_FIELD, typeof(System.String));
			columns.Add(STONAME_FIELD, typeof(System.String));
			columns.Add(STOCODE_FIELD, typeof(System.String ));
				
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private WSCRData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WSCRData()
		{
			BuildDataTables();
		}
		#endregion
		
		
	}
}
