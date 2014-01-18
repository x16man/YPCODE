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
	/// MAIOData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class MAIOData : DataSet
	{
		#region ��Ա����
		public const string MAIO_Table = "MAIO";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string UnitCode_Field = "UnitCode";
		public const string UnitName_Field = "UnitName";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string ConCode_Field = "ConCode";
		public const string ConName_Field = "ConName";
		public const string BookNum_Field = "BookNum";
		public const string BookPrice_Field = "BookPrice";
		public const string BookValue_Field = "BookValue";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemValue_Field = "ItemValue";
		public const string AcceptDate_Field = "AcceptDate";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorDate_Field = "AuthorDate";
		#endregion

		#region ����
		/// <summary>
		/// ���ϱ�š�
		/// </summary>
		public string ItemCode
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemCode_Field].ToString();}
		}
		/// <summary>
		/// �������ơ�
		/// </summary>
		public string ItemName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemName_Field].ToString();}
		}
		/// <summary>
		/// ����ͺš�
		/// </summary>
		public string ItemSpec
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemSpec_Field].ToString();}
		}
		/// <summary>
		/// ��λ��š�
		/// </summary>
		public int UnitCode
		{
			get { return int.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.UnitCode_Field].ToString());}
		}
		/// <summary>
		/// ��λ���ơ�
		/// </summary>
		public string UnitName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.UnitName_Field].ToString();}
		}
		/// <summary>
		/// �ֿ��š�
		/// </summary>
		public string StoCode
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.StoCode_Field].ToString();}
		}
		/// <summary>
		/// �ֿ����ơ�
		/// </summary>
		public string StoName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.StoName_Field].ToString();}
		}
		/// <summary>
		/// ��λ��š�
		/// </summary>
//		public int ConCode
//		{
//			get { return int.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ConCode_Field].ToString());}
//		}
		/// <summary>
		/// ��λ���ơ�
		/// </summary>
		public string ConName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ConName_Field].ToString();}
		}
		/// <summary>
		/// ����������
		/// </summary>
		public decimal BookNum
		{
			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.BookNum_Field].ToString());}
		}
		/// <summary>
		/// ���浥�ۡ�
		/// </summary>
		public decimal BookPrice
		{
			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.BookPrice_Field].ToString());}
		}
		/// <summary>
		/// �����
		/// </summary>
//		public decimal BookValue
//		{
//			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.BookValue_Field].ToString());}
//		}
		/// <summary>
		/// ʵ��������
		/// </summary>
		public decimal ItemNum
		{
			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemNum_Field].ToString());}
		}
		/// <summary>
		/// ʵ�ʵ��ۡ�
		/// </summary>
//		public decimal ItemPrice
//		{
//			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemPrice_Field].ToString());}
//		}
		/// <summary>
		/// ʵ�ʽ�
		/// </summary>
//		public decimal ItemValue
//		{
//			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemValue_Field].ToString());}
//		}
		/// <summary>
		/// �������ڡ�
		/// </summary>
//		public DateTime AcceptDate
//		{
//			get { return DateTime.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AcceptDate_Field].ToString());}
//		}
		/// <summary>
		/// ��д�˱�š�
		/// </summary>
		public string AuthorCode
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AuthorCode_Field].ToString();}
		}
		/// <summary>
		/// ��д�����ơ�
		/// </summary>
		public string AuthorName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AuthorName_Field].ToString();}
		}
		/// <summary>
		/// ��д���ڡ�
		/// </summary>
//		public DateTime AuthorDate
//		{
//			get { return DateTime.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AuthorDate_Field].ToString());}
//		}
		/// <summary>
		/// ��¼����
		/// </summary>
		public int Count
		{
			get {return this.Tables[MAIOData.MAIO_Table].Rows.Count;}
		}
		#endregion
		
		#region ˽�з���
		private void BuildDataTable() 
		{
			// ������Sto ��
			DataTable table   = new DataTable(MAIOData.MAIO_Table);
			//����ֶΡ�
			table.Columns.Add(MAIOData.ItemCode_Field, typeof(System.String));
			table.Columns.Add(MAIOData.ItemName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.ItemSpec_Field,typeof(System.String));
			table.Columns.Add(MAIOData.UnitCode_Field, typeof(System.Int16));
			table.Columns.Add(MAIOData.UnitName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.StoCode_Field, typeof(System.String));
			table.Columns.Add(MAIOData.StoName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.ConCode_Field, typeof(System.Int32));
			table.Columns.Add(MAIOData.ConName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.BookNum_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.BookPrice_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.BookValue_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.ItemPrice_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.ItemValue_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.AcceptDate_Field, typeof(System.DateTime));
			table.Columns.Add(MAIOData.AuthorCode_Field, typeof(System.String));
			table.Columns.Add(MAIOData.AuthorName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.AuthorDate_Field, typeof(System.DateTime));
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
		private MAIOData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public MAIOData()
		{
			this.BuildDataTable();
		}
		#endregion
	}
}
