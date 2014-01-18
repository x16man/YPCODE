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
	/// CurrentMonth_WithdrawData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class CurrentMonth_WithdrawData :DataSet
	{
		#region ��Ա����
		public const string CurrentMonth_Withdraw_Table = "CurrentMonth_Withdraw";
		public const string Classify_Field = "Classify";
		public const string ItemMoney_Field = "ItemMoney";
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
			DataTable table   = new DataTable(CurrentMonth_Withdraw_Table);
			//����ֶΡ�
			table.Columns.Add(Classify_Field, typeof(System.String));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
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
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private CurrentMonth_WithdrawData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public CurrentMonth_WithdrawData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		#endregion
	}
}
