#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: 
**		����: 
**		����: 
**
**              
**		����: �ź�
**		����: 
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ


namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// YCLData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class YCLData : DataSet
	{
		#region ��Ա����
		public const string YCL_Table = "WYCL";//����.
		public const string PKID_Field = "PKID";
		public const string PrvCode_Field = "PrvCode";//��š�
		public const string PrvName_Field = "PrvName";//���ơ�
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string UnitCode_Field = "UnitCode";
		public const string UnitName_Field = "UnitName";
		public const string InVolNum_Field = "InVolNum";
		public const string InItemNum_Field = "InItemNum";
		public const string OutVolNum_Field = "OutVolNum";
		public const string OutItemNum_Field = "OutItemNum";
		public const string EndVolNum_Field = "EndVolNum";
		public const string EndItemNum_Field = "EndItemNum";
		public const string OpDate_Field = "OpDate";
		#endregion

		#region ����
		//
		//TODO: �ڴ˴�������ԡ�
		//
		#endregion
		
		#region ˽�з���
		private void BuildDataTable()
		{
			// ������Sto ��
			DataTable table   = new DataTable(YCL_Table);
			//����ֶΡ�
			table.Columns.Add(PKID_Field, typeof(System.String));
			table.Columns.Add(PrvCode_Field, typeof(System.String));
			table.Columns.Add(PrvName_Field, typeof(System.String));
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));
			table.Columns.Add(UnitCode_Field, typeof(System.Int16));
			table.Columns.Add(UnitName_Field, typeof(System.String));
			table.Columns.Add(InVolNum_Field, typeof(System.Decimal));
			table.Columns.Add(InItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(OutVolNum_Field, typeof(System.Decimal));
			table.Columns.Add(OutItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(EndVolNum_Field, typeof(System.Decimal));
			table.Columns.Add(EndItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(OpDate_Field, typeof(System.DateTime));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
			
		}
		#endregion

		#region ��������
		//
		//TODO: �ڴ˴���ӹ�������.
		//
		#endregion

		#region ���캯��
		public YCLData()
		{   
			this.BuildDataTable();
		}
		private YCLData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion
	}
}
