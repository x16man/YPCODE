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
**		�ļ�: STAG.cs
**		����: ���ݲɼ�ϵͳ������Ϣ��ʵ��㡣
**		����: ��¼�����������漰�������ݲɼ�ϵͳ��������Ϣ��ȱʡ������Ϣ�Ͳֿ�
**			  ��Ϣ��
**              
**		����: �ź�
**		����: 2005-05-09
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
	/// STAGData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class STAGData:DataSet
	{
		#region ��Ա����
		/// <summary>
		/// ��ѯʧ�ܳ�����Ϣ ��
		/// </summary>
		public const string QUERY_FAILED = "���ݲɼ�ϵͳ������Ϣ��ѯʧ�ܣ�";
		/// <summary>
		/// ���ݲɼ�ϵͳ���ñ�
		/// </summary>
		public const string STAG_Table = "STAG";
		/// <summary>
		/// ���ݲɼ�ϵͳ�ķ�������ַ��
		/// </summary>
		public const string SvrADD_Field = "SvrAdd";
		/// <summary>
		/// ���ݲɼ�ϵͳ�����ݿ����ơ�
		/// </summary>
		public const string DBName_Field = "DBName";
		/// <summary>
		/// ���ݲɼ�ϵͳ���û�����
		/// </summary>
		public const string UserName_Field = "UserName";
		/// <summary>
		/// ���ݲɼ�ϵͳ�Ŀ��
		/// </summary>
		public const string PWD_Field = "PWD";
		/// <summary>
		/// ���ϱ�š�
		/// </summary>
		public const string ItemCode_Field = "ItemCode";
		/// <summary>
		/// �ֿ��š�
		/// </summary>
		public const string StoCode_Field = "StoCode";
		/// <summary>
		/// ʵ�������
		/// </summary>
		public const string VolumnItem_Field = "VolumnItem";
		/// <summary>
		/// ������Ũ�ȡ�
		/// </summary>
		public const string ThicknessItem_Field = "ThicknessItem";
		/// <summary>
		/// ����ܶȡ�
		/// </summary>
		public const string DensityItem_Field = "DensityItem";
		/// <summary>
		/// ��������
		/// </summary>
		public const string FeItem_Field = "FeItem";
		/// <summary>
		/// �۹�����
		/// </summary>
		public const string SolidItem_Field = "SolidItem";
		/// <summary>
		/// �����1��
		/// </summary>
		public const string ConCode1_Field = "ConCode1";
		/// <summary>
		/// �����2��
		/// </summary>
		public const string ConCode2_Field = "ConCode2";
		/// <summary>
		/// �����1��Һλָ��š�
		/// </summary>
		public const string TagCode1_Field = "TagCode1";
		/// <summary>
		/// �����2��Һλָ��š�
		/// </summary>
		public const string TagCode2_Field = "TagCode2";
		
		#endregion

		#region ����
		/// <summary>
		/// ��¼��������
		/// </summary>
		public int Count
		{
			get {	return this.Tables[STAGData.STAG_Table].Rows.Count;	}
		}
		/// <summary>
		/// ���ݲɼ�ϵͳ��������ַ��
		/// </summary>
		public string ServerAddress
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.SvrADD_Field].ToString():null;	}
		}
		/// <summary>
		/// ���ݲɼ�ϵͳ���ݿ����ơ�
		/// </summary>
		public string DBName
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.DBName_Field].ToString():null;	}
		}
		/// <summary>
		/// ���ݲɼ�ϵͳ�û���¼����
		/// </summary>
		public string UserName
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.UserName_Field].ToString():null;	}
		}
		/// <summary>
		/// ���ݲɼ�ϵͳ�û����
		/// </summary>
		public string PassWord
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.PWD_Field].ToString():null;	}
		}
		/// <summary>
		/// ȱʡ���ϱ�š�
		/// </summary>
		public string ItemCode
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ItemCode_Field].ToString():null;	}
		}
		/// <summary>
		/// ȱʡ�ֿ��š�
		/// </summary>
		public string StoCode
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.StoCode_Field].ToString():null;	}
		}
		/// <summary>
		/// ʵ�������
		/// </summary>
		public int VolumnItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.VolumnItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// ������Ũ�ȡ�
		/// </summary>
		public int ThicknessItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ThicknessItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// ����ܶȡ�
		/// </summary>
		public int DensityItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.DensityItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int FeItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.FeItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// �۹�����
		/// </summary>
		public int SolidItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.SolidItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// �����1��
		/// </summary>
		public int ConCode1
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ConCode1_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// �����2��
		/// </summary>
		public int ConCode2
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ConCode2_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// �����1Һλָ�ꡣ
		/// </summary>
		public int TagCode1
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.TagCode1_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// �����2Һλָ�ꡣ
		/// </summary>
		public int TagCode2
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.TagCode2_Field].ToString()):Convert.ToInt32(null);	}
		}
		#endregion
		
		#region ˽�з���
		private void BuildDataTable()
		{
			// ������STAG ��
			DataTable table   = new DataTable(STAGData.STAG_Table);
			//����ֶΡ�
			table.Columns.Add(STAGData.SvrADD_Field, typeof(System.String));
			table.Columns.Add(STAGData.DBName_Field, typeof(System.String));
			table.Columns.Add(STAGData.UserName_Field, typeof(System.String));
			table.Columns.Add(STAGData.PWD_Field, typeof(System.String));
			table.Columns.Add(STAGData.ItemCode_Field, typeof(System.String));
			table.Columns.Add(STAGData.StoCode_Field, typeof(System.String));
			table.Columns.Add(STAGData.VolumnItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.ThicknessItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.DensityItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.FeItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.SolidItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.ConCode1_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.ConCode2_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.TagCode1_Field, typeof(System.String));
			table.Columns.Add(STAGData.TagCode2_Field, typeof(System.String));

			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
		#endregion

		#region ��������
		/// <summary>
		/// ��ȡPLC��ָ��̶�ֵ��
		/// </summary>
		/// <param name="ConCode">int:	��λ��</param>
		/// <param name="time">Datetime:	ʱ��㡣</param>
		/// <returns>decimal:	ָ��̶�ֵ��</returns>
		public decimal GetPLCValue(int ConCode,DateTime time)
		{
			return 50;
		}
		#endregion

		#region ���캯��
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private STAGData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}	
		/// <summary>
		/// STAGData��Ĺ��캯����newһ��STAGData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public STAGData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		#endregion
	}
}
