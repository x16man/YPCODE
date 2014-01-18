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
	/// CBRSDetailData ��ժҪ˵����ViewCBRSourceDetail��ͼ��
	/// </summary>
	public class RTVSDetailData : DataSet
	{
		#region ��Ա����
		public const string RTVSD_VIEW = "ViewRTVSourceDetail";
		public const string PKID_FIELD				= "PKID";
		public const string PLANNUM_FIELD			= "PlanNum";		//Ӧ��������
		public const string TAXCODE_FIELD			= "TaxCode";		//˰�մ��롣
		public const string TAXRATE_FIELD			= "TaxRate";		//˰�ʡ�
		public const string ITEMTAX_FIELD			= "ItemTax";		//˰�
		public const string ITEMSUM_FIELD			= "ItemSum";		//���Ͻ��ϼơ�
		#endregion

		#region ˽�з���
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(RTVSD_VIEW);
            
			InItemData oItemData = new InItemData(table);

			DataColumnCollection columns = table.Columns;
			//�ɹ����ϵ�������Դ�������ֶΡ�
			columns.Add(RTVSDetailData.PKID_FIELD,		typeof(System.String));	//������
			columns.Add(RTVSDetailData.PLANNUM_FIELD,	typeof(System.String)); //Ӧ��������
			columns.Add(RTVSDetailData.TAXCODE_FIELD,	typeof(System.String));	//˰�롣
			columns.Add(RTVSDetailData.TAXRATE_FIELD,	typeof(System.String));	//����˰�ʡ�
			columns.Add(RTVSDetailData.ITEMTAX_FIELD,	typeof(System.String));	//����˰�
			columns.Add(RTVSDetailData.ITEMSUM_FIELD,	typeof(System.String));	//�����ܽ�
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private RTVSDetailData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public RTVSDetailData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
