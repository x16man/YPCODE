using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{
	/// <summary>
	/// ���ϵ��ƹ����Զ��塣
	/// </summary>
	[SerializableAttribute]
	public class ItemPurMak
	{
		/// <summary>
		/// �ɹ���š�
		/// </summary>
		public static string  PURCHASE_CODE
		{
			get {return "P";}
		}
		/// <summary>
		/// �ɹ����ơ�
		/// </summary>
		public static string  PURCHASE_DESCRIPTION
		{
			get {return "�ɹ�";}
		}
		/// <summary>
		/// ���Ʊ�š�
		/// </summary>
		public static string MAKESELF_CODE
		{
			get{return "M";}
		}
		/// <summary>
		/// �������ơ�
		/// </summary>
		public static string MAKESELF_DESCRIPTION
		{
			get{return "����";}
		}
		/// <summary>
		/// ��Э��š�
		/// </summary>
		public static string COOPERATE_CODE
		{
			get{return "C";}
		}
		/// <summary>
		/// ��Э���ơ�
		/// </summary>
		public static string COOPERATE_DESCRIPTION
		{
			get{return "��Э";}
		}
		/// <summary>
		/// �ƹ�������Ŀ��
		/// </summary>
		public static int Count
		{
			get{return 3;}
		}
	}

	/// <summary>
	/// ����״̬���塣
	/// </summary>
	[SerializableAttribute]
	public class ItemState
	{
		/// <summary>
		/// ��ǰ���ô��롣
		/// </summary>
		public static string  ACTIVE_CODE
		{
			get {return "A";}
		}
		/// <summary>
		/// ��ǰ�������ơ�
		/// </summary>
		public static string  ACTIVE_DESCRIPTION
		{
			get {return "����";}
		}
		/// <summary>
		/// ������ƴ��롣
		/// </summary>
		public static string ENGINEER_CODE
		{
			get{return "E";}
		}
		/// <summary>
		/// ����������ơ�
		/// </summary>
		public static string ENGINEER__DESCRIPTION
		{
			get{return "�������";}
		}
		/// <summary>
		/// ���ϴ��롣
		/// </summary>
		public static string CANCEL_CODE
		{
			get{return "C";}
		}
		/// <summary>
		/// �������ơ�
		/// </summary>
		public static string CANCEL_DESCRITION
		{
			get{return "����";}
		}
		/// <summary>
		/// ����̭���롣
		/// </summary>
		public static string ELIMILATE_CODE
		{
			get{return "P";}
		}
		/// <summary>
		/// ����̭���ơ�
		/// </summary>
		public static string ELIMILATE_DESCRIPTION
		{
			get{return "����̭";}
		}
		/// <summary>
		/// ����״̬������Ŀ��
		/// </summary>
		public static int Count
		{
			get{return 4;}
		}

	}

	/// <summary>
	/// ���ϵ�ABC�ȼ����ࡣ
	/// </summary>
	/// <remarks>���ö�ٵ����á�</remarks>
	[SerializableAttribute]
	public class ABC
	{
		/// <summary>
		/// A����š�
		/// </summary>
		public static string  A_CODE
		{
			get {return "A";}
		}
		/// <summary>
		/// A�����ơ�
		/// </summary>
		public static string  A_DESCRIPTION
		{
			get {return "A������";}
		}
		/// <summary>
		/// B����š�
		/// </summary>
		public static string B_CODE
		{
			get{return "B";}
		}
		/// <summary>
		/// B������ ��
		/// </summary>
		public static string B_DESCRIPTION
		{
			get{return "B������";}
		}
		/// <summary>
		/// C����š�
		/// </summary>
		public static string C_CODE
		{
			get{return "C";}
		}
		/// <summary>
		/// C�����ơ�
		/// </summary>
		public static string C_DESCRIPTION
		{
			get{return "C������";}
		}
		/// <summary>
		/// �ȼ�������
		/// </summary>
		public static int Count
		{
			get{return 3;}
		}

	}

	/// <summary>
	/// ���ʷ�ʽ��
	/// </summary>
	[SerializableAttribute]
	public class ItemAccountType
	{
		/// <summary>
		/// ���ݷ�����˴��롣
		/// </summary>
		public static string  CATEGROY_CODE
		{
			get {return "C";}
		}
		/// <summary>
		/// ���ݷ���������ơ�
		/// </summary>
		public static string  CATEGROY_DESCRIPTION
		{
			get {return "���Ϸ���";}
		}
		/// <summary>
		/// ���ݲֿ���˴��롣
		/// </summary>
		public static string WAREHOUSE_CODE
		{
			get{return "W";}
		}
		/// <summary>
		/// ���ݲֿ�������ơ�
		/// </summary>
		public static string WAREHOUSE_DESCRIPTION
		{
			get{return "��Ųֿ�";}
		}
		/// <summary>
		/// ���˷�ʽ������Ŀ��
		/// </summary>
		public static int Count
		{
			get{return 2;}
		}

	}
	/// <summary>
	/// ���Ϸ��������ʵ���ࡣ
	/// </summary>
	/// <remarks>ǿ�������ݼ��������л���</remarks>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class ItemData:DataSet
	{
		/// <summary>
		/// �������ļ�ʵ�������
		/// </summary>
		public const string ITEM_TABLE = "WITM";
		/// <summary>
		/// ���ϱ���ֶΡ�
		/// </summary>
		public const string CODE_FIELD = "Code";

	    public const string NEWCODE_FIELD = "NewCode";
		/// <summary>
		/// �������������ֶΡ�
		/// </summary>
		public const string CNNAME_FIELD = "CnName";
		/// <summary>
		/// ����Ӣ�������ֶΡ�
		/// </summary>
		public const string ENNAME_FIELD = "EnName";
		/// <summary>
		/// ����������ֶΡ�
		/// </summary>
		public const string CATCODE_FIELD   = "CatCode";
		/// <summary>
		/// ������������ֶΡ�
		/// </summary>
		public const string CatName_Field   = "Cat_Des";
		/// <summary>
		/// ����ͺ��ֶΡ�
		/// </summary>
		public const string SPECIAL_FIELD = "Special";
		/// <summary>
		/// �������ֶΡ�
		/// </summary>
		public const string MACCODE_FIELD     = "MacCode";
		/// <summary>
		/// �ƹ������ֶΡ�
		/// </summary>
		public const string PURMAK_FIELD     = "PurMak";
		/// <summary>
		/// ������λ����ֶΡ�
		/// </summary>
		public const string UNITCODE_FIELD     = "UnitCode";
		/// <summary>
		/// ������λ�����ֶΡ�
		/// </summary>
		public const string UnitName_Field     = "Unit_Des";
		/// <summary>
		/// ����״̬�ֶΡ�
		/// </summary>
		public const string STATE_FIELD     = "State";
		/// <summary>
		/// �Ƿ����Ÿ����ֶΡ�
		/// </summary>
		public const string BATCH_FIELD     = "Batch";
		/// <summary>
		/// �Ƿ�ϵ�Ÿ����ֶΡ�
		/// </summary>
		public const string SERIALNO_FIELD     = "SerialNo";
		/// <summary>
		/// �Ƿ���Ҫ�����ֶΡ�
		/// </summary>
		public const string CHECKED_FIELD     = "Checked";
		/// <summary>
		/// ���鱨���ֶΡ�
		/// </summary>
		public const string CHKRPTCODE_FIELD     = "ChkRptCode";
		/// <summary>
		/// ABC�ȼ��ֶΡ�
		/// </summary>
		public const string ABC_FIELD     = "ABC";
		/// <summary>
		/// �ƶ������ֶΡ�
		/// </summary>
		public const string CSTPRICE_FIELD     = "CstPrice";
		/// <summary>
		/// �����۸��ֶΡ�
		/// </summary>
		public const string EVAPRICE_FIELD     = "EvaPrice";
		/// <summary>
		/// ���ʷ�ʽ�ֶΡ�
		/// </summary>
		public const string ACCTYPE_FIELD     = "AccType";
		/// <summary>
		/// ��߿���ֶΡ�
		/// </summary>
		public const string UPPNUM_FIELD     = "UppNum";
		/// <summary>
		/// ��Ϳ���ֶΡ�
		/// </summary>
		public const string LOWNUM_FIELD     = "LowNum";
		/// <summary>
		/// ��ȫ����ֶΡ�
		/// </summary>
		public const string SAFNUM_FIELD     = "SafNum";
		/// <summary>
		/// �������ֶΡ�
		/// </summary>
		public const string ORDNUM_FIELD     = "OrdNum";
		/// <summary>
		/// ��С����������
		/// </summary>
		public const string ORDBAT_FIELD     = "OrdBat";
		/// <summary>
		/// ȱʡ��Ųֿ����ֶΡ�
		/// </summary>
		public const string DEFSTO_FIELD     = "DefSto";
		/// <summary>
		/// ȱʡ��Ųֿ������ֶΡ�
		/// </summary>
		public const string StoName_Field    = "Sto_Des";
		/// <summary>
		/// ȱʡ��ż�λ����ֶΡ�
		/// </summary>
		public const string DEFCON_FIELD     = "DefCon";
		/// <summary>
		/// ȱʡ��ż�λ�����ֶΡ�
		/// </summary>
		public const string ConName_Field    = "Con_Des";
		/// <summary>
		/// �Ƿ�������Ч���ֶΡ�
		/// </summary>
		public const string SETENABLE_FIELD     = "SetEnable";
		/// <summary>
		/// ��Ч�ڿ�ʼ�����ֶΡ�
		/// </summary>
		public const string ENFRMDATE_FIELD     = "EnFrmDate";
		/// <summary>
		/// ��Ч�ڽ��������ֶΡ�
		/// </summary>
		public const string ENENDDATE_FIELD     = "EnEndDate";
		/// <summary>
		/// ��Ч�ڱ�ע�ֶΡ�
		/// </summary>
		public const string ENREMARK_FIELD     = "EnRemark";
		/// <summary>
		/// �Ƿ񶳽��ֶΡ�
		/// </summary>
		public const string SETFREEZED_FIELD     = "SetFreezed";
		/// <summary>
		/// ��ʼ���������ֶΡ�
		/// </summary>
		public const string FRFRMDATE_FIELD     = "FrFrmDate";
		/// <summary>
		/// ������������ֶΡ�
		/// </summary>
		public const string FRENDDATE_FIELD     = "FrEndDate";
		/// <summary>
		/// ���ᱸע�ֶΡ�
		/// </summary>
		public const string FRREMARK_FIELD     = "FrRemark";
		/// <summary>
		/// ���湩Ӧ���ֶΡ�
		/// </summary>
		public const string PRVCODE_FIELD     = "PrvCode";
		/// <summary>
		/// �Ƿ������ֶΡ�
		/// </summary>
		public const string LOCKED_FIELD	="Locked";
		/// <summary>
		/// ��ǰ�������
		/// </summary>
		public const string ITEMNUM_FIELD = "ItemNum";

		
		/// <summary>
		/// ���ʱ��벻��Ϊ�ա�
		/// </summary>
		public const string CODE_NOT_NULL="���ʱ��벻��Ϊ��";
		/// <summary>
		/// �������Ʋ���Ϊ�ա�
		/// </summary>
		public const string DESCRIPTION_NOT_NULL="�������Ʋ���Ϊ��";
		/// <summary>
		/// ���ʱ������Ψһ��
		/// </summary>
		public const string CODE_NOT_UNIQUE="���ʱ������Ψһ";
		/// <summary>
		/// ���ϴ��롣
		/// </summary>
		public const string CODE_LABEL      = "���ϴ���";

	    public const string NEWCODE_LABEL = "�����ϴ���";
		/// <summary>
		/// �����������ơ�
		/// </summary>
		public const string CNNAME_LABEL      = "������������";
		/// <summary>
		/// ����Ӣ�����ơ�
		/// </summary>
		public const string ENNAME_LABEL     = "����Ӣ������";
		/// <summary>
		/// ����ͺš�
		/// </summary>
		public const string SPECIAL_LABEL = "����ͺ�";
		/// <summary>
		/// �ƶ����ۡ�
		/// </summary>
		public const string CSTPRICE_LABEL = "�ƶ�����";
		/// <summary>
		/// �����۸�
		/// </summary>
		public const string EVAPRICE_LABEL = "�����۸�";
		/// <summary>
		/// ����������
		/// </summary>
		public const string ORDBAT_LABEL = "��������";
		/// <summary>
		/// ��Ϳ�档
		/// </summary>
		public const string LOWNUM_LABEL = "��Ϳ��";
		/// <summary>
		/// �����㡣
		/// </summary>
		public const string ORDNUM_LABEL = "������";
		/// <summary>
		/// ��ȫ�������
		/// </summary>
		public const string SAFNUM_LABEL = "��ȫ�����";
		/// <summary>
		/// ��߿�档
		/// </summary>
		public const string UPPNUM_LABEL = "��߿��";
		/// <summary>
		/// ����˵����
		/// </summary>
		public const string FRREMARK_LABEL = "����˵��";
		/// <summary>
		/// ��Ч��˵����
		/// </summary>
		public const string ENREMARK_LABEL = "��Ч��˵��";
		/// <summary>
		/// �������ļ�����ʵ���еļ�¼����
		/// </summary>
		public int Count
		{
			get {return this.Tables[ItemData.ITEM_TABLE].Rows.Count;}
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private ItemData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		/// <summary>
		///    ItemData��Ĺ��캯����.  
		/// </summary>
		/// <remarks>ͨ������WITM�����ݱ�����ʼ��һ��ItemData��ʵ����</remarks> 
		public ItemData()
		{
			BuildDataTables();
		}
		/// <summary>
		/// �������ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			//
			// Create the Categories table
			//
			DataTable table   = new DataTable(ITEM_TABLE);
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CODE_FIELD, typeof(System.String));
		    columns.Add(NEWCODE_FIELD, typeof (System.String));
			columns.Add(CNNAME_FIELD, typeof(System.String));
			columns.Add(ENNAME_FIELD, typeof(System.String));
			columns.Add(CATCODE_FIELD, typeof(System.Int16));

			//��������
			columns.Add(CatName_Field, typeof(System.String));

			columns.Add(SPECIAL_FIELD, typeof(System.String));
			columns.Add(MACCODE_FIELD, typeof(System.Int16));
			columns.Add(PURMAK_FIELD, typeof(System.String)).DefaultValue=ItemPurMak.PURCHASE_CODE;
			columns.Add(UNITCODE_FIELD, typeof(System.Int16));
			//��λ����	
			columns.Add(UnitName_Field, typeof(System.String));

			columns.Add(STATE_FIELD, typeof(System.String)).DefaultValue=ItemState.ACTIVE_CODE;
			columns.Add(BATCH_FIELD, typeof(System.String)).DefaultValue="N";

			columns.Add(SERIALNO_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(CHECKED_FIELD, typeof(System.String)).DefaultValue="Y";
			columns.Add(CHKRPTCODE_FIELD, typeof(System.Int16));
			columns.Add(ABC_FIELD, typeof(System.String));
			columns.Add(CSTPRICE_FIELD, typeof(System.Decimal));
			columns.Add(EVAPRICE_FIELD, typeof(System.Decimal));
			columns.Add(ACCTYPE_FIELD, typeof(System.String)).DefaultValue=ItemAccountType.WAREHOUSE_CODE;
			columns.Add(UPPNUM_FIELD, typeof(System.Decimal));
			columns.Add(LOWNUM_FIELD, typeof(System.Decimal));
			columns.Add(SAFNUM_FIELD, typeof(System.Decimal));

			columns.Add(ORDNUM_FIELD, typeof(System.Decimal));
			columns.Add(ORDBAT_FIELD, typeof(System.Decimal));
			columns.Add(DEFSTO_FIELD, typeof(System.String));
			//�ֿ�����
			columns.Add(StoName_Field, typeof(System.String));

			columns.Add(DEFCON_FIELD, typeof(System.Int16));
			columns.Add(ConName_Field,typeof(System.String));
			columns.Add(SETENABLE_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(ENFRMDATE_FIELD, typeof(System.DateTime));
			columns.Add(ENENDDATE_FIELD, typeof(System.DateTime));
			columns.Add(ENREMARK_FIELD, typeof(System.String));
			columns.Add(SETFREEZED_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(FRFRMDATE_FIELD, typeof(System.DateTime));

			columns.Add(FRENDDATE_FIELD, typeof(System.DateTime));
			columns.Add(FRREMARK_FIELD, typeof(System.String));
			columns.Add(PRVCODE_FIELD, typeof(System.String));
			columns.Add(LOCKED_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(ITEMNUM_FIELD, typeof(System.Decimal));

			this.Tables.Add(table);
		}
	}
}

       
