// <copyright file="EntryDept.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

    /// <summary>
	/// EntryDept ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class EntryDept : DataSet
	{
		/// <summary>
		/// ����
		/// </summary>
		public const string MYSYSTEMDEPT_TABLE = "mySystemDept";		//.
		/// <summary>
		/// ���ű��
		/// </summary>
		public const string DEPTCODE_FIELD = "DeptCode";		//��
		/// <summary>
		/// ��˾���
		/// </summary>
		public const string DEPTCO_FIELD = "DeptCo";		//��š�
		/// <summary>
		/// ������������
		/// </summary>
		public const string DEPTCNNAME_FIELD = "DeptCnName";
		/// <summary>
		/// ����Ӣ������
		/// </summary>
		public const string DEPTENNAME_FIELD = "DeptEnName";
		/// <summary>
		/// �ϼ�����
		/// </summary>
		public const string PARENTDEPT_FIELD = "ParentDept";
		/// <summary>
		/// �ϼ���������
		/// </summary>
		public const string PARENTDEPTNAME_FIELD = "ParentDeptName";
		/// <summary>
		/// ��������
		/// </summary>
		public const string DEPTMGR_FIELD = "DeptMgr";
		/// <summary>
		/// ��������
		/// </summary>
		public const string CREATEDATE_FIELD = "CreateDate";
		/// <summary>
		/// �Ƿ���Ч
		/// </summary>
		public const string ISVALID_FIELD = "IsValid";
		/// <summary>
		/// ����
		/// </summary>
		public const string DEPTLEVEL_FIELD = "DeptLevel";
		/// <summary>
		/// ����
		/// </summary>
		public const string REMARK_FIELD = "Remark";
		/// <summary>
		/// ���
		/// </summary>
		public const string SERIAL_FIELD = "Serial";
		/// <summary>
		/// ����ID
		/// </summary>
		public const string TYPEID_FIELD = "TypeID";
		/// <summary>
		/// ��������
		/// </summary>
		public const string TYPENAME_FIELD = "TypeName";
		/// <summary>
		/// ���������û���
		/// </summary>
		public const string DEPTMGRNAME_FIELD = "DeptMgrName";
		/// <summary>
		/// �ɱ�����
		/// </summary>
		public const string COSTCENTER_FIELD = "CostCenter";

		/// <summary>
		/// �ɱ�����
		/// </summary>
		public const string SHOWINOTHERSYS_FIELD = "ShowInOtherSys";

		/// <summary>
		/// ���캯��
		/// </summary>
		public EntryDept()
		{
			this.BuildDataTable();
		}
		/// <summary>
		/// �������ݱ�
		/// </summary>
		private void BuildDataTable()
		{
			// ������Sto ��
			var table   = new DataTable(MYSYSTEMDEPT_TABLE);
			
            //����ֶΡ�
			table.Columns.Add(DEPTCODE_FIELD, typeof(string));
			table.Columns.Add(DEPTCO_FIELD, typeof(string));
			table.Columns.Add(DEPTCNNAME_FIELD,typeof(string));
			table.Columns.Add(DEPTENNAME_FIELD, typeof(string));
			table.Columns.Add(PARENTDEPT_FIELD, typeof(string));
			table.Columns.Add(PARENTDEPTNAME_FIELD, typeof(string));
			table.Columns.Add(DEPTMGR_FIELD, typeof(string));

			table.Columns.Add(CREATEDATE_FIELD, typeof(DateTime));
			table.Columns.Add(ISVALID_FIELD, typeof(string));
			table.Columns.Add(DEPTLEVEL_FIELD, typeof(short));
			table.Columns.Add(REMARK_FIELD, typeof(string));
			table.Columns.Add(SERIAL_FIELD, typeof(short));
			table.Columns.Add(TYPEID_FIELD, typeof(string));
			table.Columns.Add(TYPENAME_FIELD, typeof(string));
			table.Columns.Add(DEPTMGRNAME_FIELD, typeof(string));
			table.Columns.Add(COSTCENTER_FIELD, typeof(string));
			table.Columns.Add(SHOWINOTHERSYS_FIELD, typeof(int));

			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
