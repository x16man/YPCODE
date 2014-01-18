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

namespace  Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// ����������������ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PBRBData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "�����������½�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "�����������½�ʧ�ܣ�";
		public const string UPDATE_FAILED = "�����������޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "�����������޸ĳɹ���";
		public const string DELETE_FAILED = "����������ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "����������ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "�����������޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "�����������޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "����������һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "����������һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "������������������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "�������������������ɹ���";
		public const string THIRDAUDIT_FAILED = "������������������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "�������������������ɹ���";
		public const string PRESENT_FAILED = "�����������ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "�����������ύ�ɹ���";
		public const string CANCEL_FAILED = "��������������ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "�������������ϳɹ���";
		public const string NOOBJECT = "�ն���";
		public const string NOSTORAGE = "û��ָ���ֿ⣡";
		public const string NOCON = "û��ָ����λ��";
		public const string NOVENDOR = "û��ָ����Ӧ�̣�";
		public const string NOORDER = "û��ָ��������";
		public const string XORDER = "����Ķ����ţ�";
		public const string XCancel = "�������ϵ�ǰ�����ڵ��ݴ����½���������ͨ����״̬�£�";
		public const string XDelete = "ֻ�������ϵ�״̬�²�����ɾ����";
		public const string XPresent = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ����ύ������";
		public const string XFirstAudit = "ֻ���ڵ����Ѿ��ύ��״̬�£�������Ե��ݽ���һ��������";
		public const string XSecondAudit = "ֻ���ڵ���һ������ͨ����ǰ���£�������Ե��ݽ��ж���������";
		public const string XThirdAudit = "ֻ���ڵ��ݶ�������ͨ����ǰ���£�������Ե��ݽ�������������";
		public const string XUpdate = "ֻ���ڵ������½�,����,������ͨ����ǰ���£�������Ե��ݽ����޸ģ�";
		/// <value>��������ʵ��</value>
		public const string PBRB_TABLE = "PBRB";						//����������
		//������Ϣ��
		public const string PRVCODE_FIELD = "PrvCode";					//��Ӧ�̴��롣
		public const string PRVNAME_FIELD = "PrvName";					//��Ӧ�����ơ�
		public const string STOCODE_FIELD = "StoCode";					//�ֿ��š�
		public const string STONAME_FIELD = "StoName";					//�ֿ����ơ�
		public const string CONCODE_FIELD = "ConCode";					//��λ��š�
		public const string CONNAME_FIELD = "ConName";					//��λ���ơ�
		public const string CONAREA_FIELD = "ConArea";					//�����
		public const string ORDERNO_FIELD = "OrderNo";					//������ˮ�š�
		public const string ORDERCODE_FIELD = "OrderCode";				//������š�
		public const string BUYERCODE_FIELD = "BuyerCode";				//�ɹ�Ա��š�
		public const string BUYERNAME_FIELD = "BuyerName";				//�ɹ�Ա���ơ�
		public const string TOTALHEIGHT_FIELD = "TotalHeight";			//�ܸ߶ȡ�
		public const string TOTALVOLUMN_FIELD = "TotalVolumn";			//���������
		public const string THICKNESS_FIELD = "Thickness";				//������Ũ�ȡ�
		public const string DENSITY_FIELD = "Density";					//����ܶȡ�
		public const string AMOUNTTO_FIELD = "AmountTo";				//�۹�����
		public const string BATCHCODE_FIELD = "BatchCode";				//���š�
		//�������ϴӱ���Ϣ��
		public const string SHIPNO_FIELD = "ShipNo";					//������
		public const string STARTTIME_FIELD = "StartTime";				//����ʱ�䡣
		public const string ENDTIME_FIELD = "EndTime";					//�깤ʱ�䡣
		public const string IMPORTTIME_FIELD = "ImportTime";			//����ʱ�䡣
		public const string EXPORTTIME_FIELD = "ExportTime";			//����ʱ�䡣
		public const string STARTVOLUMN_FIELD = "StartVolumn";			//�鲵ǰҺλ��
		public const string ENDVOLUMN_FIELD = "EndVolumn";				//�鲵��Һλ��
		public const string ITEMVOLUMN_FIELD = "ItemVolumn";			//�����
		public const string PRODUCTCAT_FIELD = "ProductCat";			//����
		public const string DANGERCAT_FIELD = "DangerCat";				//Σ��Ʒ���
		#endregion

		#region ����
		/// <summary>
		/// ��¼����
		/// </summary>
		public int Count
		{
			get { return this.Tables[PBRBData.PBRB_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ������������ϵ������ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PBRBData.PBRB_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			//�������ϵ��������ֶ����ӡ�
			columns.Add(PBRBData.PRVCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.PRVNAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.STOCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.STONAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.CONCODE_FIELD, typeof(System.Int32));
			columns.Add(PBRBData.CONNAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.CONAREA_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.ORDERNO_FIELD, typeof(System.Int32));
			columns.Add(PBRBData.ORDERCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.BUYERCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.BUYERNAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.TOTALHEIGHT_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.TOTALVOLUMN_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.THICKNESS_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.DENSITY_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.AMOUNTTO_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.BATCHCODE_FIELD, typeof(System.String));
			//����������ӱ��ֶ����ӡ�
			columns.Add(PBRBData.SHIPNO_FIELD, typeof(System.String));
			columns.Add(PBRBData.STARTTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.ENDTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.IMPORTTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.EXPORTTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.STARTVOLUMN_FIELD, typeof(System.String));
			columns.Add(PBRBData.ENDVOLUMN_FIELD, typeof(System.String));
			columns.Add(PBRBData.ITEMVOLUMN_FIELD, typeof(System.String));
			columns.Add(PBRBData.PRODUCTCAT_FIELD, typeof(System.String));
			columns.Add(PBRBData.DANGERCAT_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private PBRBData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PBRBData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
