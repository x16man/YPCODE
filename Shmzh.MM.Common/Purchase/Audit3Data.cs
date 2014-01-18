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
	/// Audit3Data ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class Audit3Data : DataSet
	{
		#region ��Ա����
		public const string Audit3_Talbe = "ViewAudit3";
		public const string PKID_Field = "PKID";
		public const string EntryNo_Field = "EntryNo";
		public const string DocCode_Field = "DocCode";
		public const string EntryCode_Field = "EntryCode";
		public const string DocName_Field = "DocName";
		public const string EntryState_Field = "EntryState";
		public const string EntryStateName_Field = "EntryStateName";
		public const string EntryDate_Field = "EntryDate";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string Assessor1_Field = "Assessor1";
		public const string Assessor2_Field = "Assessor2";
		public const string Assessor3_Field = "Assessor3";
		public const string SubTotal_Field = "SubTotal";
		#endregion

		#region ����
		public int Count
		{
			get { return this.Tables[Audit3Data.Audit3_Talbe].Rows.Count;}
		}
		#endregion
		
		#region ˽�з���
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(Audit3Data.Audit3_Talbe);
			
			DataColumnCollection columns = table.Columns;
			
			columns.Add(PKID_Field, typeof(System.String));
			columns.Add(EntryNo_Field, typeof(System.Int32));
			columns.Add(EntryCode_Field,typeof(System.String));
			columns.Add(DocCode_Field, typeof(System.Int16));			
			columns.Add(DocName_Field, typeof(System.String));
			columns.Add(EntryState_Field, typeof(System.String));
			columns.Add(EntryStateName_Field, typeof(System.String));
			columns.Add(EntryDate_Field, typeof(System.DateTime));
			columns.Add(AuthorCode_Field, typeof(System.String));
			columns.Add(AuthorName_Field,typeof(System.String));
			columns.Add(AuthorDept_Field, typeof(System.String));
			columns.Add(AuthorDeptName_Field, typeof(System.String));
			columns.Add(Assessor1_Field, typeof(System.String));
			columns.Add(Assessor2_Field, typeof(System.String));
			columns.Add(Assessor3_Field, typeof(System.String));
			columns.Add(SubTotal_Field, typeof(System.Decimal));

			this.Tables.Add(table);
		}
		#endregion

		#region ��������
		//
		//TODO: �ڴ˴���ӹ�������.
		//
		#endregion

		#region ���캯��
		public Audit3Data()
		{
			BuildDataTables();
		}
		private Audit3Data(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion
	}
}
