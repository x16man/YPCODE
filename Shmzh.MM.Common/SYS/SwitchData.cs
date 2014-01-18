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
	/// SwitchData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class SwitchData : DataSet
	{
		#region ��Ա����
		public static string Switch_Table = "Switch";
		public static string FunctionID_Field = "FunctionID";
		public static string Enable_Field = "Enable";
		public static string Remark_Field = "Remark";
		#endregion

		#region ����
		public int Count
		{
			get { return this.Tables[SwitchData.Switch_Table].Rows.Count;}
		}
		#endregion
		
		#region ˽�з���
		/// <summary>
		/// �������ݱ�
		/// </summary>
		private void BuildDataTable()
		{
			// ������DEPT ��
			DataTable table   = new DataTable(Switch_Table);
			//����ֶΡ�
			table.Columns.Add(FunctionID_Field, typeof(System.String));
			table.Columns.Add(Enable_Field, typeof(System.Int32));
			table.Columns.Add(Remark_Field, typeof(System.String));
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
		private SwitchData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���캯����
		/// </summary>
		public SwitchData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		#endregion
	}
}
