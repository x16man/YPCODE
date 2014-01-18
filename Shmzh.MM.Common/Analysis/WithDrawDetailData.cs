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
	/// WithDrawDetailData ��ժҪ˵����
	/// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [Serializable]
    public class WithDrawDetailData : DataSet
	{
		#region ��Ա����
		public const string WithDrawDetail_Table = "WithDrawDetail";

		public const string Classify_Field = "Classify";
		public const string ClassifyName_Field = "ClassifyName";
		public const string ReqReasonCode_Field = "ReqReasonCode";
		public const string ReqReason_Field = "ReqReason";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string ItemUnit_Field = "ItemUnit";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemMoney_Field = "ItemMoney";

		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";

		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		#endregion

		#region ����
		public int Count
		{
			get {return this.Tables[0].Rows.Count;}
		}
		#endregion
		
		#region ˽�з���
		private void BuildDataTable()
		{
			DataTable table   = new DataTable(WithDrawDetail_Table);
			//����ֶΡ�
			table.Columns.Add(Classify_Field, typeof(System.String));
			table.Columns.Add(ClassifyName_Field, typeof(System.String));
			table.Columns.Add(ReqReasonCode_Field, typeof(System.String));
			table.Columns.Add(ReqReason_Field, typeof(System.String));
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));
			table.Columns.Add(ItemSpec_Field, typeof(System.String));
			table.Columns.Add(ItemUnit_Field, typeof(System.Int16));
			table.Columns.Add(ItemUnitName_Field, typeof(System.String));
			table.Columns.Add(ItemPrice_Field, typeof(System.Decimal));
			table.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			table.Columns.Add(AuthorDept_Field, typeof(System.String));
			table.Columns.Add(AuthorDeptName_Field, typeof(System.String));
			table.Columns.Add(AuthorCode_Field, typeof(System.String));
			table.Columns.Add(AuthorName_Field, typeof(System.String));
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
		public WithDrawDetailData()
		{
			this.BuildDataTable();
		}
		#endregion
	}
}
