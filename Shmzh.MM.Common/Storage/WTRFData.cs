namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   

	/// <summary>
	/// WTRFData ��ժҪ˵����
	/// </summary>
	/// 
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WTRFData:DataSet
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
		public const string ROLL_SUCCESSED="ת������ɹ�";
		#endregion

		#region ��Ա����
		/// <value>��������ʵ��</value>
		public const string WTRF_TABLE  = "WTRF";								//������
		public const string TGTSTONAME_FIELD		= "TgtStoName";				//ת��ֿ����ơ�
		public const string TGTSTOCODE_FIELD  = "TgtStoCode";					//ת��ֿ��š�
		public const string SRCSTOCODE_FIELD		= "SrcStoCode";				//�����ֿ��š�
		public const string SRCSTONAME_FIELD    = "SrcStoName";					//�����ֿ����ơ�
		public const string TRANSFERDATE_FIELD = "TransferDate";				//ת�����ڡ�
		public const string SRCSTOMANAGERCODE_FIELD     = "SrcStoManagerCode";	//�����ֿ����Ա��š�
		public const string SRCSTOMANAGER_FIELD       = "SrcStoManager";		//�����ֿ����Ա���ơ�
		public const string TGTSTOMANAGERCODE_FIELD		= "TgtStoManagerCode";	//ת��ֿ����Ա��š�
		public const string TGTSTOMANAGER_FIELD  = "TgtStoManager";				//ת��ֿ����Ա���ơ�
		public const string PLANNUM_FIELD		= "PlanNum";					//Ӧת������
//		public const string ITEMNUM_FIELD    = "ItemNum";						//ʵת������
		public const string JFKM_FIELD            = "JFKM";						//�跽��Ŀ��

		public const string CONNAME_FIELD= "ConName";							//��λ����
		public const string CONCODE_FIELD = "ConCode";							//��λ���
		public const string OUT_FAILED= "ת�ⵥ����ʧ�ܣ�";
		public const string OUT_SUCCESSED = "ת�ⵥ���ϳɹ���";

		
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
		/// ת�ⵥ�ļ�¼����
		/// </summary>
		public int Count
		{
			get { return this.Tables[WTRFData.WTRF_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ�����ת�ⵥ�����ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(WTRF_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;

			columns.Add(TGTSTONAME_FIELD, typeof(System.String));			//ת��ֿ����ơ�
			columns.Add(TGTSTOCODE_FIELD, typeof(System.String));			//ת��ֿ��š�
			columns.Add(SRCSTOCODE_FIELD, typeof(System.String));			//�����ֿ��š�
			columns.Add(SRCSTONAME_FIELD, typeof(System.String));			//�����ֿ����ơ�
			columns.Add(TRANSFERDATE_FIELD, typeof(System.String));		//ת�����ڡ�
			columns.Add(SRCSTOMANAGERCODE_FIELD, typeof(System.String));	//�����ֿ����Ա��š�
			columns.Add(SRCSTOMANAGER_FIELD, typeof(System.String));		//�����ֿ����Ա���ơ�
			columns.Add(TGTSTOMANAGERCODE_FIELD, typeof(System.String));	//ת��ֿ����Ա��š�
			columns.Add(TGTSTOMANAGER_FIELD, typeof(System.String));		//ת��ֿ����Ա���ơ�
			columns.Add(PLANNUM_FIELD, typeof(System.String));				//Ӧת������
		//	columns.Add(ITEMNUM_FIELD, typeof(System.Decimal));				//ʵת������
			columns.Add(JFKM_FIELD,typeof(System.String));						//�跽��Ŀ��
		
			System.Data.DataColumn[] myPrimCol = new System.Data.DataColumn[1];
			myPrimCol[0] = table.Columns[InItemData.ENTRYNO_FIELD];
			table.PrimaryKey = myPrimCol;
			
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private WTRFData(SerializationInfo info, StreamingContext context) : base(info, context) 
	{		
	}

		public WTRFData()
		{
			BuildDataTables();
		}
		#endregion
		
	}
}
