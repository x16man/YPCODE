namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   

	/// <summary>
	/// WADJData ��ժҪ˵����
	/// </summary>
	/// 
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WADJData:DataSet
	{
		#region ������Ϣ
		public const string NOOBJECT = "";
		public const string ADD_FAILED = "";
		public const string ADD_SUCCESSED = "";
		public const string UPDATE_FAILED = "";
		public const string UPDATE_SUCCESSED = "";
		public const string DELETE_FAILED = "";
		public const string DELETE_SUCCESSED = "";
		public const string UPDATESTATE_FAILED = "";
		public const string UPDATESTATE_SUCCESSED = "";
		public const string FIRSTAUDIT_FAILED = "";
		public const string FIRSTAUDIT_SUCCESSED = "";
		public const string SECONDAUDIT_FAILED = "";
		public const string SECONDAUDIT_SUCCESSED = "";
		public const string THIRDAUDIT_FAILED = "";
		public const string THIRDAUDIT_SUCCESSED = "";
		public const string PRESENT_FAILED = "";
		public const string PRESENT_SUCCESSED = "";
		public const string CANCEL_FAILED = "";
		public const string CANCEL_SUCCESSED = "";
		public const string AFFIRM_SUCCESSED = "";
		public const string AFFIRM_FAILED = "";
		public const string ROLL_FAILED="��治�㣬���ܷ���";
		public const string ROLL_SUCCESSED="��λ���������ɹ�";
		#endregion

		#region ��Ա����
		/// <value>��������ʵ��</value>
		public const string WADJ_TABLE  = "WADJ";						//������
		public const string PKID_FIELD = "PKID";						//���������
		public const string STONAME_FIELD = "StoName";					//�ֿ����ơ�
		public const string STOCODE_FIELD = "StoCode";					//�ֿ��š�
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";	//�ֿ����Ա��š�
		public const string STOMANAGER_FIELD = "StoManager";			//�ֿ����Ա���ơ�
		public const string STOCKNUM_FIELD = "StockNum";				//���������
		public const string JFKM_FIELD = "JFKM";						//�跽��Ŀ��
		public const string SRCCONNAME_FIELD= "SrcConName";				//Դ��λ����
		public const string SRCCONCODE_FIELD = "SrcConCode";			//Դ��λ���
		public const string TGTCONNAME_FIELD= "TgtConName";				//Ŀ���λ����
		public const string TGTCONCODE_FIELD = "TgtConCode";			//Ŀ���λ���
		public const string OUT_FAILED= "��λ����������ʧ�ܣ�";
		public const string OUT_SUCCESSED = "��λ���������ϳɹ���";
		public const string XDelete = "ֻ�������ϵ�״̬�²�����ɾ����";
		public const string XCancel = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ������ϲ�����";
		public const string XPresent = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ����ύ������";
		public const string XFirstAudit = "ֻ���ڵ����Ѿ��ύ��״̬�£�������Ե��ݽ���һ��������";
		public const string XSecondAudit = "ֻ���ڵ���һ������ͨ����ǰ���£�������Ե��ݽ��ж���������";
		public const string XThirdAudit = "ֻ���ڵ��ݶ�������ͨ����ǰ���£�������Ե��ݽ�������������";
		public const string XUpdate = "ֻ���ڵ������½�,����,������ͨ����ǰ���£�������Ե��ݽ����޸ģ�";
		
		#endregion

		#region ����
		/// <summary>
		/// ��λ�������ļ�¼����
		/// </summary>
		public int Count
		{
			get { return this.Tables[WADJData.WADJ_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ�������λ�����������ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(WADJ_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(PKID_FIELD, typeof(System.String));				//����¼ID��
			columns.Add(STONAME_FIELD, typeof(System.String));			//�ֿ����ơ�
			columns.Add(STOCODE_FIELD, typeof(System.String));			//�ֿ��š�			
			columns.Add(STOMANAGERCODE_FIELD, typeof(System.String));	//�ֿ����Ա��š�
			columns.Add(STOMANAGER_FIELD, typeof(System.String));		//�ֿ����Ա���ơ�
			columns.Add(STOCKNUM_FIELD, typeof(System.String));			//���������
			columns.Add(JFKM_FIELD,typeof(System.String));				//�跽��Ŀ��
			columns.Add(SRCCONCODE_FIELD,typeof(System.String));		//Դ��λ��š�
			columns.Add(SRCCONNAME_FIELD,typeof(System.String));		//Դ��λ���ơ�
			columns.Add(TGTCONCODE_FIELD,typeof(System.String));		//Ŀ���λ��š�
			columns.Add(TGTCONNAME_FIELD,typeof(System.String));		//Ŀ���λ���ơ�

			System.Data.DataColumn[] myPrimCol = new System.Data.DataColumn[1];
			myPrimCol[0] = table.Columns[InItemData.ENTRYNO_FIELD];
			table.PrimaryKey = myPrimCol;
			
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private WADJData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WADJData()
		{
			BuildDataTables();
		}
		#endregion
		
	}
}
