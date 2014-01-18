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


namespace Shmzh.Components.WorkFlow
{
	using System.Data;

    /// <summary>
	/// �������˵���������ר�õ�ʵ��㡣
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[System.SerializableAttribute] 
	public class Task3Data	: DataSet
	{
		#region Field
		/// <summary>
		/// DataTable�ı�����
		/// </summary>
		public const string Task3_Table = "Task3";					//�������������
		public const string Task_ID_Field = "Task_ID";				//����ID��
		public const string Entity_ID_Field = "Entity_ID";			//����ID��
		public const string DocCode_Field = "DocCode";				//�������͡�
		public const string ReqDeptCode_Field = "ReqDeptCode";		//���벿�ű�š�
		public const string ReqDeptName_Field = "ReqDeptName";		//���벿�����ơ�
		public const string SerialNo_Field = "SerialNo";			//���кš�
		public const string ItemCode_Field = "ItemCode";			//���ϱ�š�
		public const string ItemName_Field = "ItemName";			//�������ơ�
		public const string ItemSpec_Field = "ItemSpec";			//����ͺš�
		public const string UnitCode_Field = "UnitCode";			//��λ��š�
		public const string UnitName_Field = "UnitName";			//��λ���ơ�
		public const string ItemNum_Field = "ItemNum";				//������
		public const string ItemMoney_Field = "ItemMoney";			//��
		public const string UseCode_Field = "UseCode";				//��;��š�
		public const string UseName_Field = "UseName";				//��;���ơ�
		public const string ReqDate_Field = "ReqDate";				//Ҫ�����ڡ�
		public const string Level_Field = "Level";					//�����̶ȡ�
		public const string ABC_Field = "ABC";						//ABC���ࡣ
		public const string Grantor_ID_Field = "Grantor_ID";		//���Ų����ˡ�
		public const string Staff_ID_Field = "Staff_ID";			//ʵ�ʲ����ˡ�
		public const string Assessor1_Field = "Assessor1";			//һ�������ˡ�
		public const string Assessor2_Field = "Assessor2";			//���������ˡ�
		public const string Assessor3_Field = "Assessor3";			//���������ˡ�
		#endregion

		#region private method
		private void BuildDataTable()
		{
			var table   = new DataTable(Task3_Table);
			//����ֶΡ�
			table.Columns.Add(Task_ID_Field, typeof(System.Int32));
			table.Columns.Add(Entity_ID_Field, typeof(System.Int32));
			table.Columns.Add(DocCode_Field, typeof(System.Int16));
			table.Columns.Add(ReqDeptCode_Field, typeof(System.String));
			table.Columns.Add(ReqDeptName_Field, typeof(System.String));
			table.Columns.Add(SerialNo_Field, typeof(System.Int16));
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));			
			table.Columns.Add(ItemSpec_Field, typeof(System.String));
			table.Columns.Add(UnitCode_Field, typeof(System.Int16));
			table.Columns.Add(UnitName_Field, typeof(System.String));
			table.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			table.Columns.Add(UseCode_Field, typeof(System.String));
			table.Columns.Add(UseName_Field, typeof(System.String));
			table.Columns.Add(ReqDate_Field, typeof(System.DateTime));
			table.Columns.Add(Level_Field, typeof(System.String));
			table.Columns.Add(ABC_Field, typeof(System.String));
			table.Columns.Add(Grantor_ID_Field, typeof(System.String));
			table.Columns.Add(Staff_ID_Field, typeof(System.String));
			table.Columns.Add(Assessor1_Field, typeof(System.String));
			table.Columns.Add(Assessor2_Field, typeof(System.String));
			table.Columns.Add(Assessor3_Field, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region CTOR
		public Task3Data()
		{
			BuildDataTable();
		}
		#endregion
	}
}
