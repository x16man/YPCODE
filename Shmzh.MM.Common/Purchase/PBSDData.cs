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
	/// PBSData ��ժҪ˵����ViewValidOrderDetail��ͼ��
	/// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public class PBSDData : DataSet
	{
		#region ��Ա����
		public const string PBSD_VIEW = "ViewValidOrderDetail";
		public const string PKID_FIELD				= "PKID";
		public const string BATCHCODE_FIELD			= "BatchCode";		//���š�
		public const string PLANNUM_FIELD			= "PlanNum";		//Ӧ��������
		public const string TAXCODE_FIELD			= "TaxCode";		//˰�մ��롣
		public const string TAXRATE_FIELD			= "TaxRate";		//˰�ʡ�
		public const string ITEMTAX_FIELD			= "ItemTax";		//˰�
		public const string ITEMSUM_FIELD			= "ItemSum";		//���Ͻ��ϼơ�
		#endregion

		#region ˽�з���
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PBSD_VIEW);
            
			InItemData oItemData = new InItemData(table);

			DataColumnCollection columns = table.Columns;
			//���ϵ�������Դ�������ֶΡ�
			columns.Add(PBSDData.PKID_FIELD,		typeof(System.String));	//������
			columns.Add(PBSDData.BATCHCODE_FIELD,	typeof(System.String));	//���š�
			columns.Add(PBSDData.PLANNUM_FIELD, typeof(System.String)); //Ӧ��������
			columns.Add(PBSDData.TAXCODE_FIELD,		typeof(System.String));	//˰�롣
			columns.Add(PBSDData.TAXRATE_FIELD,		typeof(System.String));	//����˰�ʡ�
			columns.Add(PBSDData.ITEMTAX_FIELD,		typeof(System.String));	//����˰�
			columns.Add(PBSDData.ITEMSUM_FIELD,		typeof(System.String));	//�����ܽ�
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private PBSDData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PBSDData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
