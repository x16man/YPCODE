//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// DeptData �ǲ��ű������ʵ��㣬���𴴽�һ��DEPT�����ݼ���
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PPRCData : DataSet
	{
		//��ṹ��
		public const string PPRC_Table = "PPRC";
		public const string Code_Field = "Code";
		public const string CnName_Field = "CNName";
		public const string EnName_Field = "ENName";
		public const string Locked_Field = "Locked";
		public const string Desc_Field = "Desc";

		
		public PPRCData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PPRCData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���������ݿ���DEPT���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ������DEPT ��
			DataTable table   = new DataTable(PPRC_Table);
			//����ֶΡ�
			table.Columns.Add(Code_Field, typeof(System.Int32));
			table.Columns.Add(CnName_Field, typeof(System.String));
			table.Columns.Add(EnName_Field, typeof(System.String));
			table.Columns.Add(Locked_Field, typeof(System.String));
			table.Columns.Add(Desc_Field, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
