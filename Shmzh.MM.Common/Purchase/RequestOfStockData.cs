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

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// RequestOfStockData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class RequestOfStockData:DataSet
	{
		#region ��Ա����
		/// <value>��������ʵ��</value>
		public const string PROS_TABLE  = "PROS";						//������
		public const string PROPOSER_FIELD		= "Proposer";			//�����ˡ�
		public const string PROPOSERCODE_FIELD  = "ProposerCode";		//�����˱�š�
		public const string REQDEPT_FIELD		= "ReqDept";			//���벿�š�
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";		//���벿�����ơ�
		public const string REQREASONCODE_FIELD = "ReqReasonCode";		//�������ɴ��롣
		public const string REQREASON_FIELD     = "ReqReason";			//�������ɡ�
		public const string REQDATE_FIELD       = "ReqDate";			//Ҫ�󵽻����ڡ�
		public const string NoPurpose = "�ɹ����뵥����Ҫָ����;��";
		public const string NoReqDept = "�ɹ����뵥����ָ�����벿�ţ�";
		public const string NoProposer = "�ɹ����뵥����ָ�������ˣ�";
		public const string XDelete = "ֻ�������ϵ�״̬�²�����ɾ����";
		public const string XCancel = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ������ϲ�����";
		public const string XPresent = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ����ύ������";
		public const string XFirstAudit = "ֻ���ڵ����Ѿ��ύ��״̬�£�������Ե��ݽ���һ��������";
		public const string XSecondAudit = "ֻ���ڵ����������ͨ����ǰ���£�������Ե��ݽ��ж���������";
		public const string XThirdAudit = "ֻ���ڵ��ݶ�������ͨ����ǰ���£�������Ե��ݽ�������������";
	    public const string XWZAudit = "ֻ���ڵ��ݲ�������ͨ����ǰ���£�������Ե��ݽ���������ˣ�";
		public const string XUpdate = "ֻ���ڵ����½�,����,������ͨ����ǰ���£�������Ե��ݽ����޸ģ�";
		#endregion

		#region ����
		/// <summary>
		/// �ɹ����뵥�ļ�¼����
		/// </summary>
		public int Count
		{
			get { return this.Tables[RequestOfStockData.PROS_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ������ɹ����뵥�����ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			var table   = new DataTable(PROS_TABLE);
			var oItemData=new InItemData(table);
			var columns = table.Columns;

			columns.Add(PROPOSER_FIELD, typeof(System.String));			//�����ˡ�
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//�����˱�š�
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//���벿�š�
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//���벿�����ơ�
			columns.Add(REQREASONCODE_FIELD, typeof(System.String));	//�������ɡ�
			columns.Add(REQREASON_FIELD, typeof(System.String));		//�������ɡ�
			columns.Add(REQDATE_FIELD, typeof(System.String));			//Ҫ�󵽻����ڡ�
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private RequestOfStockData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public RequestOfStockData()
		{
			BuildDataTables();
		}
		#endregion
		
		
	}
}
