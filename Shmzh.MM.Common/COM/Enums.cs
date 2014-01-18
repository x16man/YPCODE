#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
namespace Shmzh.MM.Common
{
	/// <summary>
	/// ��������ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class DocType 
	{
		/// <summary>
		/// �ɹ����뵥��
		/// </summary>
		public const int ROS = 1;
		/// <summary>
		/// �������󵥡�
		/// </summary>
		public const int MRP = 2;
		/// <summary>
		/// �ɹ�������
		/// </summary>
		public const int PO = 3;
		/// <summary>
		/// ���ϵ���
		/// </summary>
		public const int DRW = 4;
		/// <summary>
		/// �ɹ��ƻ���
		/// </summary>
		public const int PP = 5;
		/// <summary>
		/// �ɹ����ϵ���
		/// </summary>
		public const int BOR = 6;
		/// <summary>
		/// �ɹ����ϵ���
		/// </summary>
		public const int RTV = 7;
		/// <summary>
		/// �������ϵ���
		/// </summary>
		public const int RTS = 8;
		/// <summary>
		/// �������յ���
		/// </summary>
		public const int CBR = 9;
		/// <summary>
		/// ת�ⵥ��
		/// </summary>
		public const int TRF = 10;
		/// <summary>
		/// ���ϵ�.
		/// </summary>
		public const int SCR = 11;
		/// <summary>
		/// ��λ������
		/// </summary>
		public const int ADJ = 12;
		/// <summary>
		/// ���ν�������
		/// </summary>
		public const int BRB = 13;
		/// <summary>
		/// �����
		/// </summary>
		public const int PAY = 14;
		/// <summary>
		/// ί��ӹ����뵥��
		/// </summary>
		public const int WTOW = 16;
		/// <summary>
		/// ί��ӹ����ϵ���
		/// </summary>
		public const int WINW = 17;
        /// <summary>
        /// ���������롣
        /// </summary>
        public const int WITR = 18;

	    public const int INVENTRYPROFIT = 19;

	    public const int INVENTORYSHORTAGE = 20;
		/// <summary>
		/// �ɹ���������
		/// </summary>
		public const int CANCEL = 21;

		private DocType() {}
	}
	/// <summary>
	/// ���ݵ�״̬ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class DocStatus
	{
		/// <summary>
		/// �½�״̬��
		/// </summary>
		public const string New = "N";
		/// <summary>
		/// �ύ����״̬��
		/// </summary>
		public const string Present = "P";
		/// <summary>
		/// ��ָ�ɡ�
		/// </summary>
		public const string Assigned = "A";
		/// <summary>
		/// ������״̬��
		/// </summary>
		public const string Cancel  = "C";
		/// <summary>
		/// һ������ͨ��״̬��
		/// </summary>
		public const string FstPass = "F";
		/// <summary>
		/// ��������ͨ��״̬��
		/// </summary>
		public const string SecPass = "S";
        /// <summary>
        /// ��������ͨ��״̬�����״̬Ŀǰֻ�н����깺��ʹ�á�
        /// </summary>
	    public const string WZPass = "L";
        /// <summary>
        /// �������δͨ����
        /// </summary>
	    public const string WZNoPass = "W";
		/// <summary>
		/// ����ͨ��״̬��
		/// </summary>
		public const string TrdPass = "T";
		/// <summary>
		/// һ��������ͨ��״̬��
		/// </summary>
		public const string FstNoPass = "X";
		/// <summary>
		/// ����������ͨ��״̬��
		/// </summary>
		public const string SecNoPass = "Y";
		/// <summary>
		/// ����������ͨ��״̬��
		/// </summary>
		public const string TrdNoPass = "Z";
		/// <summary>
		/// ��ȷ�϶���״̬��
		/// </summary>
		public const string OrdExec = "E";
		/// <summary>
		/// �ɹ�Ա�ܾ��ɹ��������ֿ����Ա�ܷ����ϵ���
		/// </summary>
		public const string OrdReject = "R";
		/// <summary>
		/// �������˻�״̬��
		/// </summary>
		public const string OrdBack = "B";
		/// <summary>
		/// ������״̬��
		/// </summary>
		public const string Received = "I";
		/// <summary>
		/// �Ѹ���״̬��
		/// </summary>
		public const string Pay = "J";
		/// <summary>
		/// �ѷ���״̬��
		/// </summary>
		public const string Drawed = "O";
		/// <summary>
		/// �ѱ���״̬
		/// </summary>
		public const string Discard ="D";
		/// <summary>
		/// �����Ѿ���ɡ�
		/// </summary>
		public const string OrdOver = "V";
		/// <summary>
		/// ���������յ�.
		/// </summary>
		public const string Checked = "K";
		/// <summary>
		/// ���������ϵ�.
		/// </summary>
		public const string BOR = "G";
		/// <summary>
		/// �˻�״̬(�ɹ��˻���).
		/// </summary>
		public const string RTV = "H";
		private DocStatus() {}
	}
	/// <summary>
	/// �ֶΰ�ģʽö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class ColumnScheme
	{
		/// <summary>
		/// ���ϵ����ֶ�ģʽ��
		/// </summary>
		public const string DRAW = "DRAW";
		/// <summary>
		/// ���ϵ��Ƶ��İ�ģʽ.
		/// </summary>
		public const string DRAWAuthor = "DRAWAuthor";
		/// <summary>
		/// ί��ӹ����뵥�Ƶ�ģʽ��
		/// </summary>
		public const string WTOWAuthor = "WTOWAuthor";
		/// <summary>
		/// ί��ӹ����뵥�ķ���ģʽ��
		/// </summary>
		public const string WTOW = "WTOW";
		/// <summary>
		/// ί��ӹ����ϵ���
		/// </summary>
		public const string WINW = "WINW";
		/// <summary>
		/// ί��ӹ����ϵ��Ƶ�ģʽ��
		/// </summary>
		public const string WINWAuthor = "WINWAuthor";
		/// <summary>
		/// ����ʱ����λѡ��
		/// </summary>
		public const string CONCHOOSER = "CONCHOOSER";
		/// <summary>
		/// ת��ʱ����λѡ��
		/// </summary>
		public const string TRANSCHOOSER = "TRANSCHOOSER";
		///<summary>
		///�������ϵ�ģʽ
		///</summary>
		public const string RTS = "RTS";
		/// <summary>
		/// �������ϵ�����ģʽ
		/// </summary>
		public const string RTSRECEIVE = "RTSRECEIVE";
		/// <summary>
		/// ���ϵ����ֶ�ģʽ��
		/// </summary>
		public const string BOR = "BOR";
		/// <summary>
		/// ���ϵ����ϵ��ֶ�ģʽ��
		/// </summary>
		public const string BORRECEIVE = "BORRECEIVE";
		/// <summary>
		/// �ɹ��ƻ����ֶ�ģʽ��
		/// </summary>
		public const string PP = "PP";
		/// <summary>
		/// �ɹ��������ֶ�ģʽ��
		/// </summary>
		public const string PO = "PO";
		/// <summary>
		/// �ɹ���������Դ��
		/// </summary>
		public const string POS = "POS";
		/// <summary>
		/// ���ϵ�����Դ��
		/// </summary>
		public const string PBSA = "PBSA";
		/// <summary>
		/// �������յ���
		/// </summary>
		public const string PCBR = "PCBR";
		/// <summary>
		/// �ɹ����뵥��
		/// </summary>
		public const string ROS = "ROS";
		public const string ROSAuthor = "ROSAuthor";
		/// <summary>
		/// ת�ⵥ
		/// </summary>
		public const string TRF = "TRF";
		/// <summary>
		/// ���ϵ�
		/// </summary>
		public const string SCR = "SCR";
		/// <summary>
		/// ת�ⵥ����ʱ
		/// </summary>
		public const string TRFIn = "TRFIn";
		/// <summary>
		/// �ɹ��˻����Ӷΰ�ģʽ.
		/// </summary>
		public const string RTV = "RTV";
		/// <summary>
		/// ��λ����ģʽ
		/// </summary>
		public const string ADJ = "ADJ";
		/// <summary>
		/// �ɹ��˻����˻�ģʽ.
		/// </summary>
		public const string RTVRECEIVE = "RTVRECEIVE";
		/// <summary>
		/// ���ν��ϵ���
		/// </summary>
		public const string BRB = "BRB";
		/// <summary>
		/// �������ɺ���;
		/// </summary>
		public const string USING = "USING";
		/// <summary>
		/// �ɹ���������
		/// </summary>
		public const string Cancel = "Cancel";
		private ColumnScheme() {}
	}
	/// <summary>
	/// �����б�����ö�١�
	/// </summary>
	public enum SDDLTYPE 
	{
		PURMAK = 1,			//�ƹ�
		CATEGORY = 2,		//Ŀ¼
		ITEMSTATE = 3,		//����״̬
		UNIT = 4,			//��λ
		ABC = 5,			//ABC����
		ACCOUNT = 6,		//��Ŀ
		STORAGE = 7,		//�ֿ�
		CONTAINER = 8,		//��λ
		CHECKREPORT = 9,	//���鱨��
		VENDOR = 10,		//��Ӧ��
		VCTYPE = 11,		//��Ӧ�̿ͻ����
		VCSTATUS = 12,		//��Ӧ�̿ͻ�״̬
		VCAPPROVE = 13,		//��Ӧ�̿ͻ��Ѻ�׼
		CURRENCY = 14,		//���Ҵ���
		PAYSTYLE = 15,		//���ʽ
		USER = 16,			//�û�
		PURPOSE = 17,		//��;
		PSLP = 18,			//�ɹ�Ա
		DEPT = 19,			//����
		ITEMQUERY = 20,		//���ϲ�ѯ������
		ACAT = 21,			//������δ����ķ����б�
		ENTRYSTATE = 22,	//����״̬��
		YEAR = 23,			//��ݡ�
		MONTH = 24,			//�·ݡ�
		TAX = 25,           //˰�롣
		//***DXJ����***
		CPTY = 26,			//��ͬ�������ʡ�
		CPMM = 27,			//��ͬ����׶Ρ�
		CPMS = 28,			//��ͬ�׶θ����־��
		CTYP = 29,			//��ͬ���͡�
       
		//***END***
		STOMANAGER = 30,	//�ֿ����Ա��
		OWNDEPT = 31,       //��Ȩ�����Ĳ��š�
		QRYSLT = 32,        //��ѯ������
		UCLIST = 33,        //�������ɼ���;�ķ��ࡣ
		YLORDER=34,			//Һ����صĶ����б�
		CheckResult=35,		//���ս����
		Drawer=36,			//�����ˡ�
		Classify=37,		//��;����.
		YCL=38,				//��ˮԭ����
		VendorType = 39,	//��Ӧ�̷��ࡣ
        CMPT = 40,           //�ʽ�����
        SingningLocation = 41,          //ǩԼ�ص�
		Performance = 42,      //��Լ���
        AllDept = 43        //������Ч����

	};
	/// <summary>
	/// ��Ӧ�����͡�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class PprnType
	{
		/// <summary>
		/// ��Ӧ�̡�
		/// </summary>
		public const string Vendor = "V";//��Ӧ�̡�
		/// <summary>
		/// ����λ��
		/// </summary>
		public const string Self = "I";//����λ.
		/// <summary>
		/// OTA��Ӧ�̡�
		/// </summary>
		public const string OTAVendor = "O";//OTA��Ӧ�̡�
		private PprnType() {}
	}

    /*
	/// <summary>
	/// ��Ӧ��״̬ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class PprnStatus
	{
		/// <summary>
		/// ��ġ�
		/// </summary>
		public const string Active = "A";//��ġ�
		/// <summary>
		/// ����ġ�
		/// </summary>
		public const string NoActive = "I";//����ġ�
		/// <summary>
		/// ����̭�ġ�
		/// </summary>
		public const string DisUse = "P";//����̭�ġ�
		private PprnStatus() {}
	}*/
	/// <summary>
	/// ���ݲ���������ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class OP
	{
        public const string View = "View";//�鿴��
		/// <summary>
		/// �½���
		/// </summary>
		public const string New = "New";//�½���

        public const string Copy = "Copy";//���ơ�
		/// <summary>
		/// �½����ύ��
		/// </summary>
		public const string NewAndPresent = "NP";//�½����ύ��
		/// <summary>
		/// �½���ָ�ɡ�
		/// </summary>
		public const string NewAndAssign = "NA";//�½���ָ�ɡ�
		/// <summary>
		/// �޸ġ�
		/// </summary>
		public const string Edit = "Edit";//�޸ġ�
		/// <summary>
		/// �޸Ĳ��ύ��
		/// </summary>
		public const string EditAndPresent = "EP";//�޸Ĳ��ύ��
		/// <summary>
		/// �޸Ĳ�ָ�ɡ�
		/// </summary>
		public const string EditAndAssign = "EA";//�޸Ĳ�ָ�ɡ�
		/// <summary>
		/// �ύ��
		/// </summary>
		public const string Submit = "Submit";//�ύ��
		/// <summary>
		/// ָ�ɡ�
		/// </summary>
		public const string Assigned = "Assigned";//ָ�ɡ�
		/// <summary>
		/// //���ϡ�
		/// </summary>
		public const string Cancel = "Cancel";//���ϡ�
		/// <summary>
		/// һ��������
		/// </summary>
		public const string FirstAudit = "FirstAudit";//һ��������
		/// <summary>
		/// ����������
		/// </summary>
		public const string SecondAudit = "SecondAudit";//����������
		/// <summary>
		/// ����������
		/// </summary>
		public const string ThirdAudit = "ThirdAudit";//����������
        /// <summary>
        /// �������
        /// </summary>
	    public const string WZAudit = "WZAudit";//������ˡ�
		/// <summary>
		/// ���顣
		/// </summary>
		public const string Check = "Check";//���顣
		/// <summary>
		/// ���ɲɹ����ϵ���
		/// </summary>
		public const string Bor = "Bor";//���ɲɹ����ϵ���
		/// <summary>
		/// ȷ�ϡ�
		/// </summary>
		public const string Affirm = "Affirm";//ȷ�ϡ�
		/// <summary>
		/// �ܾ���
		/// </summary>
		public const string Reject = "Reject";//�ܾ���
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string I = "In";//���ϡ�
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string O = "Out";//���ϡ�
		/// <summary>
		/// ת�⡣
		/// </summary>
		public const string Trans = "Trans";//ת�⡣		
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string Discard ="Discard";//���ϡ�
		/// <summary>
		/// ��λ������
		/// </summary>
		public const string Adjust = "Adjust";//��λ������
		/// <summary>
		/// ���֡�
		/// </summary>
		public const string Red = "Red";//���֡�
		/// <summary>
		/// ɾ����
		/// </summary>
		public const string Delete = "Del";//ɾ��.
		/// <summary>
		/// ���
		/// </summary>
		public const string Pay = "Pay";
		/// <summary>
		/// �ܾ����
		/// </summary>
		public const string NoPay ="NoPay";
		private OP() {}
	}
	/// <summary>
	/// ���ݵĲ�����ť����ʾ����ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class OPName
	{
		/// <summary>
		/// �½���
		/// </summary>
		public const string New = "����";
		/// <summary>
		/// �༭��
		/// </summary>
		public const string Edit = "����";
		/// <summary>
		/// �ύ��
		/// </summary>
		public const string Submit = "�ύ";
		/// <summary>
		/// ָ�ɡ�
		/// </summary>
		public const string Assigned = "ָ��";
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string Cancel = "����";
		/// <summary>
		/// һ��������
		/// </summary>
		public const string FirstAudit = "ȷ��";
		/// <summary>
		/// ����������
		/// </summary>
		public const string SecondAudit = "ȷ��";
		/// <summary>
		/// ����������
		/// </summary>
		public const string ThirdAudit = "ȷ��";
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string I = "����";
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string O = "����";
		/// <summary>
		/// ���ϡ�
		/// </summary>
		public const string Discard = "����";
		/// <summary>
		/// ת�⡣
		/// </summary>
		public const string Trans = "ת��";
		/// <summary>
		/// ȷ�ϡ�
		/// </summary>
		public const string Affirm = "ȷ��";
		/// <summary>
		/// �ܾ���
		/// </summary>
		public const string Reject = "�ܾ�";
		/// <summary>
		/// �������յ���
		/// </summary>
		public const string Check = "�������յ�";
		/// <summary>
		/// �������ϵ���
		/// </summary>
		public const string Bor = "�������ϵ�";

        /// <summary>
        /// ������ˡ�
        /// </summary>
	    public const string WZAudit = "ȷ��";
		private OPName() {}
	}
	/// <summary>
	/// Session�ṹö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class MySession
	{
       
		/// <summary>
		/// User����
		/// </summary>
		public const string User = "User";
		/// <summary>
		/// �û����š�
		/// </summary>
		public const string UserCode = "USERCODE";
		/// <summary>
		/// �û�������
		/// </summary>
		public const string UserName = "USERNAME";
		/// <summary>
		/// �û���¼����
		/// </summary>
		public const string UserLoginId = "LOGINID";
		/// <summary>
		/// �û��������ű�š�
		/// </summary>
		public const string DeptCode = "USERDEPTCODE";
		/// <summary>
		/// �û������������ơ�
		/// </summary>
		public const string DeptName = "USERDEPTNAME";
         
		/// <summary>
		/// �ɹ����ϵ���DT��
		/// </summary>
		public const string BOR_DT = "BOR_DT";
		/// <summary>
		/// ���ϵ���DT��
		/// </summary>
		public const string DRW_DT = "DRW_DT";
		/// <summary>
		/// �ɹ����뵥��DT��
		/// </summary>
		public const string ROS_DT = "ROS_DT";
		/// <summary>
		/// �������󵥵�DT��
		/// </summary>
		public const string MRP_DT = "MRP_DT";
		/// <summary>
		/// �ɹ��ƻ���DT��
		/// </summary>
		public const string PP_DT  = "PP_DT";
		/// <summary>
		/// �ɹ�������DT��
		/// </summary>
		public const string ORD_DT = "ORD_DT";
		/// <summary>
		/// ���ν�������DT��
		/// </summary>
		public const string BRB_DT = "BRB_DT";
		/// <summary>
		/// �������յ���DT��
		/// </summary>
		public const string CBR_DT = "CBR_DT";
		/// <summary>
		/// �ɹ��˻�����DT��
		/// </summary>
		public const string RTV_DT = "RTV_DT";
		/// <summary>
		/// �������ϵ���DT��
		/// </summary>
		public const string RTS_DT = "RTS_DT";
		/// <summary>
		/// ���ϵ���DT��
		/// </summary>
		public const string SCR_DT = "SCR_DT";
		/// <summary>
		/// ת�ⵥ��DT��
		/// </summary>
		public const string TRF_DT = "TRF_DT";
		/// <summary>
		/// ת�ⵥת���DT.
		/// </summary>
		public const string TRFIN_DT = "TRFIN_DT";
		/// <summary>
		/// ��λ��������DT��
		/// </summary>
		public const string ADJ_DT = "ADJ_DT";
		/// <summary>
		/// ��λѡ��
		/// </summary>
		public const string CONCHOOSER_DT = "CONCHOOSE";
		/// <summary>
		/// ���ϵ��ľ�̬���ݱ�
		/// </summary>
		public const string DrawDt = "DrawDt";
		/// <summary>
		/// ���ϵ��ľ�̬���ݱ�
		/// </summary>
		public const string ReceiveDt = "ReceiveDt";
		//		public const string TransDt = "TransDt";
		public const string Help = "HelpCode";
		/// <summary>
		/// ί��ӹ����뵥��̬���ݱ�
		/// </summary>
		public const string WTOW_DT = "WTOWDt";
		/// <summary>
		/// ί��ӹ����ϵ����ϱ�̬���ݱ�
		/// </summary>
		public const string WDIW_DT = "WDIWDt";
		/// <summary>
		/// ί��ӹ����ϵ����ı�̬���ݱ�
		/// </summary>
		public const string WRES_DT = "WRESDt";
		public const string Cancel_DT = "Cancel";
		private MySession() {}
	}
	/// <summary>
	/// ���������ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class AuditResult
	{
		/// <summary>
		/// ����ͨ����
		/// </summary>
		public const string Passed = "Y";
		/// <summary>
		/// ������ͨ����
		/// </summary>
		public const string NoPassed = "N";
		/// <summary>
		/// AuditResult�Ĺ��캯����
		/// </summary>
		private AuditResult() {}
	}
	/// <summary>
	/// ��ѯ��������ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class QryParam
	{
		/// <summary>
		/// �����б�������磺���ţ��ֿ�ȡ�
		/// </summary>
		public const string ModuleTag = "ModuleTag";
		/// <summary>
		/// �û���¼����
		/// </summary>
		public const string UserCode = "UserCode";
		/// <summary>
		/// �Ƿ�ÿ��ҳ��ˢ��ʱ��������б�
		/// </summary>
		public const string IsClear = "IsClear";
		/// <summary>
		/// �������͡�
		/// </summary>
		public const string DocType = "DocType";
	}

	/// <summary>
	/// ��ѯ�����еĲ���ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class MyParm
	{
		/// <summary>
		/// �յ�SQL��䡣
		/// </summary>
		public const string  NON_SQL = "-1";
	}
	/// <summary>
	/// ��ѯģ�顣
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class QRYModule
	{
		/// <summary>
		/// �ɹ����뵥��
		/// </summary>
		public const int ROS = 101;
		/// <summary>
		/// �������󵥡�
		/// </summary>
		public const int MRP = 102;
		/// <summary>
		/// �ɹ��ƻ�
		/// </summary>
		public const int PP = 103;
		/// <summary>
		/// �ɹ�����
		/// </summary>
		public const int PO = 104;
		/// <summary>
		/// �ɹ�����
		/// </summary>
		public const int PBOR = 105;
		/// <summary>
		/// �ɹ��˻�
		/// </summary>
		public const int PRTV = 106;
		/// <summary>
		/// �ɹ���ͬ
		/// </summary>
		public const int PCTR = 107;
		/// <summary>
		/// �ɹ�������
		/// </summary>
		public const int Cancel = 108;
		/// <summary>
		/// ��Ӧ�����ļ�
		/// </summary>
		public const int PPRN = 201;
		/// <summary>
		/// �������ļ�
		/// </summary>
		public const int ITEM = 301;
		/// <summary>
		/// ���ϵ�
		/// </summary>
		public const int DRW = 302;
		/// <summary>
		/// ����
		/// </summary>
		public const int PIN = 303;
		/// <summary>
		/// ����
		/// </summary>
		public const int OUT = 304;
		/// <summary>
		/// ����ѯ
		/// </summary>
		public const int STOCK = 305;
		/// <summary>
		/// ��λ����
		/// </summary>
		public const int ADJ = 306;
		/// <summary>
		/// ת��
		/// </summary>
		public const int TRF = 306;
		/// <summary>
		/// �������ϵ�
		/// </summary>
		public const int RTS = 309;
		/// <summary>
		/// ���ϵ�
		/// </summary>
		public const int SCR = 310;
		/// <summary>
		/// ����������
		/// </summary>
		public const int BRB = 320;
		/// <summary>
		/// ������������
		/// </summary>
		public const int BDB = 330;
		/// <summary>
		/// ��;��
		/// </summary>
		public const int USE = 340;
		/// <summary>
		/// ԭ���ϡ�
		/// </summary>
		public const int YCL = 350;
		/// <summary>
		/// ί��ӹ����뵥��
		/// </summary>
		public const int WTOW = 360;
		/// <summary>
		/// ί��ӹ����ϵ���
		/// </summary>
		public const int WINW = 370;
		/// <summary>
		/// ���
		/// </summary>
		public const int PPAY = 380;
	}
	/// <summary>
	/// �������͡�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class ReportType
	{
		private ReportType() {}
		/// <summary>
		/// �ڳ�����̵㱨��
		/// </summary>
		public const string StartMAIO_Report = "StartKCPD";
		/// <summary>
		/// �ڳ�����̵���˲᷽ʽ��
		/// </summary>
		public const string StartMAIOByCat_Report = "StartMAIOByCat";
		/// <summary>
		/// �ڳ�����̵����ӯ�̿����ݷֲ�����
		/// </summary>
		public const string StartMAIO_Chart = "StartKCPDChart";
		/// <summary>
		/// 6�µ׿���̵���ձ�
		/// </summary>
		public const string StartMAIO_Compare = "Cat6value";
		/// <summary>
		/// ���Ͽ���嵥
		/// </summary>
		public const string Stock_Report = "Stock";
		/// <summary>
		/// �����շ���ϸ��
		/// </summary>
		public const string Material_IO_Detail_Report = "Material_IO_Detail";
		/// <summary>
		/// �ֿ���ĩ�շ��汨��
		/// </summary>
		public const string StockSIOE_Report = "StockSIOE";
		/// <summary>
		/// �˱����շ����ܱ�
		/// </summary>
		public const string ZBSIOETotal_Report = "ZBSIOETotal";
		/// <summary>
		/// �����շ�����ܱ�(���ŷ�)
		/// </summary>
		public const string ZBGroupSIOETotal_Report = "ZBGroupSIOETotal_Report";
		/// <summary>
		/// �������Ϸּ���ϸ��
		/// </summary>
		public const string Fin_OutFJHZB_Report = "Fin_OutFJHZB";
		/// <summary>
		/// �������Ϸּ����ܱ�
		/// </summary>
		public const string Fin_OutFJHZB_Group_Report = "Fin_OutFJHZB_Group";
		/// <summary>
		/// ��Ʊ��ϸ��
		/// </summary>
		public const string InvDetail_Report = "BorDetailByInvoice";
		/// <summary>
		/// �������������
		/// </summary>
		public const string StockQuestion_Report = "StockQuestion";
		/// <summary>
		/// �°��������
		/// </summary>
		public const string StockQuestionNew_Report = "StockQuestionNew";
		/// <summary>
		/// ��ͬ
		/// </summary>
		public const string Contract_Report = "Contracts";
		/// <summary>
		/// ���ڿ�档
		/// </summary>
		public const string ExtendedStock_Report = "ExtendedStock";
		/// <summary>
		/// ������Ʒ�Ĳɹ����ٱ���
		/// </summary>
		public const string BigItemTrace_Report = "BigItemTrace";
		/// <summary>
		/// ��Ŀ�ɹ����Ϸ�������
		/// </summary>
		public const string ProjectItemAnalysis_Report="ProjectItemAnalysis";
        /// <summary>
        /// ��Ŀ�ɹ����Ϸ�������
        /// </summary>
        public const string ProjectStuffAnalysis_Report = "ProjecStuffAnalysis";
	
		/// <summary>
		/// ��ֵ�׺�Ʒ�����÷ֲ�����
		/// </summary>
		public const string LEECDist_Report = "LEECDistReport";
	}
	/// <summary>
	/// ����·����
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class ReportPath
	{
		private ReportPath() {}
		/// <summary>
		/// �ڳ�����̵㱨���·����
		/// </summary>
		public const string StartMAIO_ReportPath = "/MMReports/MAIOResult";
		/// <summary>
		/// �ڳ�����̵㱨���·����(�˲᷽ʽ)
		/// </summary>
		public const string StartMAIOByCat_ReportPath = "/MMReports/MAIOResultByCat";
		/// <summary>
		/// �ֿ���ĩ�շ��汨���·����
		/// </summary>
		public const string StockSIOE_ReportPath = "/MMReports/StockSIOE";

        public const string StockSIOE_ReportZeroPath = "/MMReports/StockSIOEZero";
		/// <summary>
		/// ����̵���ӯ�̿����ݷֲ�ͼ�����·����
		/// </summary>
		public const string StartMAIO_ChartPath = "/MMReports/MAIOYKRecord"; 
		/// <summary>
		/// 6�µ׿���̵���ձ�
		/// </summary>
		public const string StartMAIO_ComparePath = "/MMReports/Cat6Value";
		/// <summary>
		/// ���Ͽ���嵥��
		/// </summary>
		public const string Stock_ReportPath = "/MMReports/Stock";
		/// <summary>
		/// �����շ���ϸ��
		/// </summary>
		public const string Material_IO_Detail_ReportPath = "/MMReports/Material_IO_Detail_Report";
		/// <summary>
		/// �˱����շ����ܱ�
		/// </summary>
		public const string ZBSIOETotal_ReportPath = "/MMReports/ZBSIOETotal";
		/// <summary>
		/// �����շ�����ܱ�(���ŷ�)
		/// </summary>
		public const string ZBGroupSIOETotal_ReportPath = "/MMReports/ZBGroupSIOETotal";
		/// <summary>
		/// �������Ϸּ���ϸ��
		/// </summary>
		public const string Fin_OutFJHZB_ReportPath = "/MMReports/Fin_OutFJHZBNew";
		/// <summary>
		/// �������Ϸּ����ܱ�
		/// </summary>
		public const string Fin_OutFJHZB_Group_ReportPath = "/MMReports/Fin_OutFJHZB_GroupNew";
		/// <summary>
		/// ��Ʊ��ϸ�嵥��
		/// </summary>
		public const string InvDetail_ReportPath = "/MMReports/BorDetailByInvoice";
		/// <summary>
		/// �����������
		/// </summary>
		public const string StockQuestion_ReportPath = "/MMReports/StockQuestion";
		/// <summary>
		/// �°��������
		/// </summary>
		public const string StockQuestionNew_ReportPath = "/MMReports/StockQuestionNew";
		/// <summary>
		/// ��ͬ��
		/// </summary>
		public const string Contract_ReportPath = "/MMReports/Contracts";
		/// <summary>
		/// ���ڿ�档
		/// </summary>
		public const string ExtendedStock_ReportPath = "/MMReports/ExtendedStock";
		/// <summary>
		/// ������Ʒ�ɹ����ٷ�������
		/// </summary>
		public const string BigItemTrace_ReportPath = "/MMReports/BigItemTrace";
		/// <summary>
		/// ��Ŀ�ɹ����Ϸ�������
		/// </summary>
		public const string ProjectItemAnalysis_ReportPath = "/MMReports/ProjectItemAnalysis";

        /// <summary>
        /// �ɹ����Ϸ�����
        /// </summary>
        public const string ProjectStuffAnalysis_ReportPath = "/MMReports/ProjecStuffAnalysis";
		

		/// <summary>
		/// ��ֵ�׺�Ʒ�����÷ֲ�����
		/// </summary>
		public const string LEECDist_ReportPath = "/MMReports/LEECDistReport";
	}
    /*
	/// <summary>
	/// �й�Ȩ�޵�ö�١�
	/// </summary>
	public sealed class SysRight
	{
		/// <summary>
		/// ��Ȩ�����ľ�����Ϣ��
		/// </summary>
		public const string NoRight = "�Բ�������Ȩ���д˲�����";
		/// <summary>
		/// ���Ϸ������
		/// </summary>
		public const int CategoryBrowser = 300;
		/// <summary>
		/// ���Ϸ�������
		/// </summary>
		public const int CategoryAdd = 310;
		/// <summary>
		/// ���Ϸ����޸�
		/// </summary>
		public const int CategoryEdit = 320;
		/// <summary>
		/// ���Ϸ��ิ��
		/// </summary>
		public const int CategoryCopy = 330;
		/// <summary>
		/// ���Ϸ���ɾ��
		/// </summary>
		public const int CategoryDelete = 340;
		/// <summary>
		/// �������
		/// </summary>
		public const int ItemBrowser = 350;
		/// <summary>
		/// ��������
		/// </summary>
		public const int ItemAdd = 360;
		/// <summary>
		/// �����޸�
		/// </summary>
		public const int ItemEdit = 370;
		/// <summary>
		/// ����ɾ��
		/// </summary>
		public const int ItemDelete = 380;
		/// <summary>
		/// ���ϸ���
		/// </summary>
		public const int ItemCopy = 390;
		/// <summary>
		/// �ɹ����뵥���
		/// </summary>
		public const int ROSBrowser = 400;
		/// <summary>
		/// �ɹ����뵥�½�
		/// </summary>
		public const int ROSAdd = 410;
		/// <summary>
		/// �ɹ����뵥�޸�
		/// </summary>
		public const int ROSEdit = 420;
		/// <summary>
		/// �ɹ����뵥ɾ��
		/// </summary>
		public const int ROSDelete = 430;
		/// <summary>
		/// �ɹ����뵥����
		/// </summary>
		public const int ROSCancel = 440;
		/// <summary>
		/// �ɹ����뵥�ύ
		/// </summary>
		public const int ROSPresent = 450;
		/// <summary>
		/// �ɹ����뵥һ������
		/// </summary>
		public const int ROSFirstAudit = 460;
		/// <summary>
		/// �ɹ����뵥��������
		/// </summary>
		public const int ROSSecondAudit = 470;
		/// <summary>
		/// �ɹ����뵥��������
		/// </summary>
		public const int ROSThirdAudit = 480;
		/// <summary>
		/// �����������
		/// </summary>
		public const int MRPBrowser = 490;
		/// <summary>
		/// ���������½�
		/// </summary>
		public const int MRPAdd = 500;
		/// <summary>
		/// ���������޸�
		/// </summary>
		public const int MRPEdit = 510;
		/// <summary>
		/// ��������ɾ��
		/// </summary>
		public const int MRPDelete = 520;
		/// <summary>
		/// ������������
		/// </summary>
		public const int MRPCancel = 530;
		/// <summary>
		/// ���������ύ
		/// </summary>
		public const int MRPPresent = 540;
		/// <summary>
		/// ��������һ������
		/// </summary>
		public const int MRPFirstAudit = 550;
		/// <summary>
		/// �������󵥶�������
		/// </summary>
		public const int MRPSecondAudit = 560;
		/// <summary>
		/// ����������������
		/// </summary>
		public const int MRPThirdAudit = 570;
		/// <summary>
		/// �ɹ��ƻ����
		/// </summary>
		public const int PPBrowser = 580;
		/// <summary>
		/// �ɹ��ƻ��½�
		/// </summary>
		public const int PPAdd = 590;
		/// <summary>
		/// �ɹ��ƻ��޸�
		/// </summary>
		public const int PPEdit = 600;
		/// <summary>
		/// �ɹ��ƻ�ɾ��
		/// </summary>
		public const int PPDelete = 610;
		/// <summary>
		/// �ɹ��ƻ�����
		/// </summary>
		public const int PPCancel = 620;
		/// <summary>
		/// �ɹ��ƻ��ύ
		/// </summary>
		public const int PPPresent = 630;
		/// <summary>
		/// �ɹ��ƻ�һ������
		/// </summary>
		public const int PPFirstAudit = 640;
		/// <summary>
		/// �ɹ��ƻ���������
		/// </summary>
		public const int PPSecondAudit = 650;
		/// <summary>
		/// �ɹ��ƻ���������
		/// </summary>
		public const int PPThirdAudit = 660;
		/// <summary>
		/// �ɹ��������
		/// </summary>
		public const int POBrowser = 670;
		/// <summary>
		/// �ɹ������½�
		/// </summary>
		public const int POAdd = 680;
		/// <summary>
		/// �ɹ������޸�
		/// </summary>
		public const int POEdit = 690;
		/// <summary>
		/// �ɹ�����ɾ��
		/// </summary>
		public const int PODelete = 700;
		/// <summary>
		/// �ɹ���������
		/// </summary>
		public const int POCancel = 710;
		/// <summary>
		/// �ɹ������ύ
		/// </summary>
		public const int POPresent = 720;
		/// <summary>
		/// �ɹ�����ָ��
		/// </summary>
		public const int POAssign = 730;
		/// <summary>
		/// �ɹ������ɹ�ȷ��
		/// </summary>
		public const int POConfirm = 740;
		/// <summary>
		/// �ɹ�����һ������
		/// </summary>
		public const int POFirstAudit = 750;
		/// <summary>
		/// �ɹ�������������
		/// </summary>
		public const int POSecondAudit = 760;
		/// <summary>
		/// �ɹ�������������
		/// </summary>
		public const int POThirdAudit = 770;
		/// <summary>
		/// �ɹ����ϵ����
		/// </summary>
		public const int BORBrowser = 780;
		/// <summary>
		/// �ɹ����ϵ��½�
		/// </summary>
		public const int BORAdd = 790;
		/// <summary>
		/// �ɹ����ϵ��޸�
		/// </summary>
		public const int BOREdit = 800;
		/// <summary>
		/// �ɹ����ϵ�ɾ��
		/// </summary>
		public const int BORDelete = 810;
		/// <summary>
		/// �ɹ����ϵ�����
		/// </summary>
		public const int BORCancel = 820;
		/// <summary>
		/// �ɹ����ϵ��ύ
		/// </summary>
		public const int BORPresent = 830;
		/// <summary>
		/// �ɹ����ϵ�һ������
		/// </summary>
		public const int BORFirstAudit = 840;
		/// <summary>
		/// �ɹ����ϵ���������
		/// </summary>
		public const int BORSecondAudit = 850;
		/// <summary>
		/// �ɹ����ϵ���������
		/// </summary>
		public const int BORThirdAudit = 860;
		/// <summary>
		/// ���ϵ����
		/// </summary>
		public const int DRWBrowser = 870;
		/// <summary>
		/// ���ϵ��½�
		/// </summary>
		public const int DRWAdd = 880;
		/// <summary>
		/// ���ϵ��޸�
		/// </summary>
		public const int DRWEdit = 890;
		/// <summary>
		/// ���ϵ�ɾ��
		/// </summary>
		public const int DRWDelete = 900;
		/// <summary>
		/// ���ϵ�����
		/// </summary>
		public const int DRWCancel = 910;
		/// <summary>
		/// ���ϵ��ύ
		/// </summary>
		public const int DRWPresent = 920;
		/// <summary>
		/// ���ϵ�һ������
		/// </summary>
		public const int DRWFirstAudit = 930;
		/// <summary>
		/// ���ϵ���������
		/// </summary>
		public const int DRWSecondAudit = 940;
		/// <summary>
		/// ���ϵ���������
		/// </summary>
		public const int DRWThirdAudit = 950;
		/// <summary>
		/// ����
		/// </summary>
		public const int StockIn = 960;
		/// <summary>
		/// ����
		/// </summary>
		public const int StockOut = 970;
		/// <summary>
		/// ����ѯ
		/// </summary>
		public const int StockBrowser = 980;
		/// <summary>
		/// ��̨ͬ�����
		/// </summary>
		public const int ContractBrowser = 990;
		/// <summary>
		/// ��̨ͬ���½�
		/// </summary>
		public const int ContractAdd = 1000;
		/// <summary>
		/// ��̨ͬ���޸�
		/// </summary>
		public const int ContractEdit = 1010;
		/// <summary>
		/// ��̨ͬ������
		/// </summary>
		public const int ContractCancel = 1020;
		/// <summary>
		/// ��Ӧ�����
		/// </summary>
		public const int VendorBrowser = 1030;
		/// <summary>
		/// ��Ӧ���½�
		/// </summary>
		public const int VendorAdd = 1040;
		/// <summary>
		/// ��Ӧ���޸�
		/// </summary>
		public const int VendorEdit = 1050;
		/// <summary>
		/// ��Ӧ��ɾ��
		/// </summary>
		public const int VendorDelete = 1060;
		/// <summary>
		/// ���յ����
		/// </summary>
		public const int CBRBrowser = 1070;
		/// <summary>
		/// ���յ��½�
		/// </summary>
		public const int CBRAdd = 1080;
		/// <summary>
		/// ���յ��ύ
		/// </summary>
		public const int CBRPresent = 1090;
		/// <summary>
		/// ���յ��޸�
		/// </summary>
		public const int CBREdit = 1100;
		/// <summary>
		/// ���յ�ɾ��
		/// </summary>
		public const int CBRDelete = 1110;
		/// <summary>
		/// ���յ�����
		/// </summary>
		public const int CBRCancel = 1120;
		/// <summary>
		/// ���յ�һ������
		/// </summary>
		public const int CBRFirstAudit = 1130;
		/// <summary>
		/// ���յ���������
		/// </summary>
		public const int CBRSecondAudit = 1140;
		/// <summary>
		/// ���յ���������
		/// </summary>
		public const int CBRThirdAudit = 1150;
		/// <summary>
		/// �ɹ��˻������
		/// </summary>
		public const int RTVBrowser = 1160;
		/// <summary>
		/// �ɹ��˻����½�
		/// </summary>
		public const int RTVAdd = 1170;
		/// <summary>
		/// �ɹ��˻����ύ
		/// </summary>
		public const int RTVPresent = 1180;
		/// <summary>
		/// �ɹ��˻����޸�
		/// </summary>
		public const int RTVEdit = 1190;
		/// <summary>
		/// �ɹ��˻���ɾ��
		/// </summary>
		public const int RTVDelete = 1200;
		/// <summary>
		/// �ɹ��˻�������
		/// </summary>
		public const int RTVCancel = 1210;
		/// <summary>
		/// �ɹ��˻���һ������
		/// </summary>
		public const int RTVFirstAudit = 1220;
		/// <summary>
		/// �ɹ��˻�����������
		/// </summary>
		public const int RTVSecondAudit = 1230;
		/// <summary>
		/// �ɹ��˻�����������
		/// </summary>
		public const int RTVThirdAudit = 1240;
		/// <summary>
		/// �������ϵ����
		/// </summary>
		public const int RTSBrowser = 1250;
		/// <summary>
		/// �������ϵ��½�
		/// </summary>
		public const int RTSAdd = 1260;
		/// <summary>
		/// �������ϵ��ύ
		/// </summary>
		public const int RTSPresent = 1270;
		/// <summary>
		/// �������ϵ��޸�
		/// </summary>
		public const int RTSEdit = 1280;
		/// <summary>
		/// �������ϵ�ɾ��
		/// </summary>
		public const int RTSDelete = 1290;
		/// <summary>
		/// �������ϵ�����
		/// </summary>
		public const int RTSCancel = 1300;
		/// <summary>
		/// �������ϵ�һ������
		/// </summary>
		public const int RTSFirstAudit = 1310;
		/// <summary>
		/// �������ϵ���������
		/// </summary>
		public const int RTSSecondAudit = 1320;
		/// <summary>
		/// �������ϵ���������
		/// </summary>
		public const int RTSThirdAudit = 1330;
		/// <summary>
		/// ת�ⵥ���
		/// </summary>
		public const int TRFBrowser = 1340;
		/// <summary>
		/// ת�ⵥ�½�
		/// </summary>
		public const int TRFAdd = 1350;
		/// <summary>
		/// ת�ⵥ�ύ
		/// </summary>
		public const int TRFPresent = 1360;
		/// <summary>
		/// ת�ⵥ�޸�
		/// </summary>
		public const int TRFEdit = 1370;
		/// <summary>
		/// ת�ⵥɾ��
		/// </summary>
		public const int TRFDelete = 1380;
		/// <summary>
		/// ת�ⵥ����
		/// </summary>
		public const int TRFCancel = 1390;
		/// <summary>
		/// ת�ⵥһ������
		/// </summary>
		public const int TRFFirstAudit = 1400;
		/// <summary>
		/// ת�ⵥ��������
		/// </summary>
		public const int TRFSecondAudit = 1410;
		/// <summary>
		/// ת�ⵥ��������
		/// </summary>
		public const int TRFThirdAudit = 1420;
		/// <summary>
		/// ���ϵ����
		/// </summary>
		public const int SCRBrowser = 1430;
		/// <summary>
		/// ���ϵ��½�
		/// </summary>
		public const int SCRAdd = 1440;
		/// <summary>
		/// ���ϵ��ύ
		/// </summary>
		public const int SCRPresent = 1450;
		/// <summary>
		/// ���ϵ��޸�
		/// </summary>
		public const int SCREdit = 1460;
		/// <summary>
		/// ���ϵ�ɾ��
		/// </summary>
		public const int SCRDelete = 1470;
		/// <summary>
		/// ���ϵ�����
		/// </summary>
		public const int SCRCancel = 1480;
		/// <summary>
		/// ���ϵ�һ������
		/// </summary>
		public const int SCRFirstAudit = 1490;
		/// <summary>
		/// ���ϵ���������
		/// </summary>
		public const int SCRSecondAudit = 1500;
		/// <summary>
		/// ���ϵ���������
		/// </summary>
		public const int SCRThirdAudit = 1510;
		/// <summary>
		/// ��;���
		/// </summary>
		public const int PurposeBrowser = 1520;
		/// <summary>
		/// ��;�½�
		/// </summary>
		public const int PurposeAdd = 1530;
		/// <summary>
		/// ��;�޸�
		/// </summary>
		public const int PurposeEdit = 1540;
		/// <summary>
		/// ��;����
		/// </summary>
		public const int PurposeCopy = 1550;
		/// <summary>
		/// ��;ɾ��
		/// </summary>
		public const int PurposeDelete = 1560;
		/// <summary>
		/// �ֿ����
		/// </summary>
		public const int StoBrowser = 1570;
		/// <summary>
		/// �ֿ��½�
		/// </summary>
		public const int StoAdd = 1580;
		/// <summary>
		/// �ֿ��޸�
		/// </summary>
		public const int StoEdit = 1590;
		/// <summary>
		/// �ֿ⸴��
		/// </summary>
		public const int StoCopy = 1600;
		/// <summary>
		/// �ֿ�ɾ��
		/// </summary>
		public const int StoDelete = 1610;
		/// <summary>
		/// ��λ���
		/// </summary>
		public const int ConBrowser = 1620;
		/// <summary>
		/// ��λ�½�
		/// </summary>
		public const int ConAdd = 1630;
		/// <summary>
		/// ��λ�޸�
		/// </summary>
		public const int ConEdit = 1640;
		/// <summary>
		/// ��λ����
		/// </summary>
		public const int ConCopy = 1650;
		/// <summary>
		/// ��λɾ��
		/// </summary>
		public const int ConDelete = 1660;
		/// <summary>
		/// �ֿ����Ա���
		/// </summary>
		public const int StoManagerBrowser = 1670;
		/// <summary>
		/// �ֿ����Ա�½�
		/// </summary>
		public const int StoManagerAdd = 1680;
		/// <summary>
		/// �ֿ����Ա�޸�
		/// </summary>
		public const int StoManagerEdit = 1690;
		/// <summary>
		/// �ֿ����Ա����
		/// </summary>
		public const int StoManagerCopy = 1700;
		/// <summary>
		/// �ֿ����Աɾ��
		/// </summary>
		public const int StoManagerDelete = 1710;
		/// <summary>
		/// ������λ���
		/// </summary>
		public const int UnitBrowser = 1720;
		/// <summary>
		/// ������λ�½�
		/// </summary>
		public const int UnitAdd = 1730;
		/// <summary>
		/// ������λ�޸�
		/// </summary>
		public const int UnitEdit = 1740;
		/// <summary>
		/// ������λ����
		/// </summary>
		public const int UnitCopy = 1750;
		/// <summary>
		/// ������λɾ��
		/// </summary>
		public const int UnitDelete = 1760;
		/// <summary>
		/// �ɹ�Ա���
		/// </summary>
		public const int BuyerBrowser = 1770;
		/// <summary>
		/// �ɹ�Ա�½�
		/// </summary>
		public const int BuyerAdd = 1780;
		/// <summary>
		/// �ɹ�Ա�޸�
		/// </summary>
		public const int BuyerEdit = 1790;
		/// <summary>
		/// �ɹ�Ա����
		/// </summary>
		public const int BuyerCopy = 1800;
		/// <summary>
		/// �ɹ�Աɾ��
		/// </summary>
		public const int BuyerDelete = 1810;
		/// <summary>
		/// ��ͬ�������
		/// </summary>
		public const int ContractTypeBrowser = 1820;
		/// <summary>
		/// ��ͬ�����½�
		/// </summary>
		public const int ContractTypeAdd = 1830;
		/// <summary>
		/// ��ͬ�����޸�
		/// </summary>
		public const int ContractTypeEdit = 1840;
		/// <summary>
		/// ��ͬ����ɾ��
		/// </summary>
		public const int ContractTypeDelete = 1850;
		/// <summary>
		/// ��ͬ�����������
		/// </summary>
		public const int ContractPaymentPropertyBrowser = 1860;
		/// <summary>
		/// ��ͬ���������½�
		/// </summary>
		public const int ContractPaymentPropertyAdd = 1870;
		/// <summary>
		/// ��ͬ���������޸�
		/// </summary>
		public const int ContractPaymentPropertyEdit = 1880;
		/// <summary>
		/// ��ͬ��������ɾ��
		/// </summary>
		public const int ContractPaymentPropertyDelete = 1890;
		/// <summary>
		/// ��ͬ����׶����
		/// </summary>
		public const int ContractPaymentStepBrowser = 1900;
		/// <summary>
		/// ��ͬ���������½�
		/// </summary>
		public const int ContractPaymentStepAdd = 1910;
		/// <summary>
		/// ��ͬ���������޸�
		/// </summary>
		public const int ContractPaymentStepEdit = 1920;
		/// <summary>
		/// ��ͬ��������ɾ��
		/// </summary>
		public const int ContractPaymentStepDelete = 1930;
		/// <summary>
		/// ��ͬ����׶α�־���
		/// </summary>
		public const int ContractPaymentStepSignBrowser = 1940;
		/// <summary>
		/// ��ͬ����׶α�־�½�
		/// </summary>
		public const int ContractPaymentStepSignAdd = 1950;
		/// <summary>
		/// ��ͬ����׶α�־�޸�
		/// </summary>
		public const int ContractPaymentStepSignEdit = 1960;
		/// <summary>
		/// ��ͬ����׶α�־ɾ��
		/// </summary>
		public const int ContractPaymentStepSignDelete = 1970;
		/// <summary>
		/// ϵͳ�û�����
		/// </summary>
		public const int UserManage = 1980;
		/// <summary>
		/// ϵͳ�����޸�
		/// </summary>
		public const int PWDChange = 1990;
		/// <summary>
		/// ��ɫȨ��ά��
		/// </summary>
		public const int RoleRightManage = 2000;
		/// <summary>
		/// ��ɫ����
		/// </summary>
		public const int RoleManage = 2010;
		/// <summary>
		/// �û���ɫ����
		/// </summary>
		public const int UserRoleManage = 2020;
		/// <summary>
		/// �û����ݲ��Ź���
		/// </summary>
		public const int UDDManage = 2030;
		/// <summary>
		/// ��ѯ��������
		/// </summary>
		public const int QuerySchemeManage = 2040;
		/// <summary>
		/// �������������
		/// </summary>
		public const int BRBBrowser = 2050;
		/// <summary>
		/// �����������½�
		/// </summary>
		public const int BRBAdd = 2060;
		/// <summary>
		/// �����������޸�
		/// </summary>
		public const int BRBEdit = 2070;
		/// <summary>
		/// �����������ύ
		/// </summary>
		public const int BRBPresent = 2080;
		/// <summary>
		/// ��������������
		/// </summary>
		public const int BRBCancel = 2090;
		/// <summary>
		/// ����������ɾ��
		/// </summary>
		public const int BRBDelete = 2100;
		/// <summary>
		/// ����������һ������
		/// </summary>
		public const int BRBFirstAudit = 2110;
		/// <summary>
		/// ������������������
		/// </summary>
		public const int BRBSecondAudit = 2120;
		/// <summary>
		/// ������������������
		/// </summary>
		public const int BRBThirdAudit = 2130;
		/// <summary>
		/// �������������
		/// </summary>
		public const int BDBBrowser = 2140;
		/// <summary>
		/// �����������½�
		/// </summary>
		public const int BDBAdd = 2150;
		/// <summary>
		/// �����������޸�
		/// </summary>
		public const int BDBEdit = 2160;
		/// <summary>
		/// �����������ύ
		/// </summary>
		public const int BDBPresent = 2170;
		/// <summary>
		/// ��������������
		/// </summary>
		public const int BDBCancel = 2180;
		/// <summary>
		/// ����������ɾ��
		/// </summary>
		public const int BDBDelete = 2190;
		/// <summary>
		/// ����������һ������
		/// </summary>
		public const int BDBFirstAudit = 2200;
		/// <summary>
		/// ������������������
		/// </summary>
		public const int BDBSecondAudit = 2210;
		/// <summary>
		/// ������������������
		/// </summary>
		public const int BDBThirdAudit = 2220;
		/// <summary>
		/// ���񸶿�Ȩ��
		/// </summary>
		public const int FinPay = 2230;
		/// <summary>
		/// ί��ӹ����뵥���
		/// </summary>
		public const int WTOWBrowser = 2240;
		/// <summary>
		/// ί��ӹ����뵥�½�
		/// </summary>
		public const int WTOWAdd = 2250;
		/// <summary>
		/// ί��ӹ����뵥�༭
		/// </summary>
		public const int WTOWEdit = 2260;
		/// <summary>
		/// ί��ӹ����뵥�ύ
		/// </summary>
		public const int WTOWPresent = 2270;
		/// <summary>
		/// ί��ӹ����뵥����
		/// </summary>
		public const int WTOWCancel = 2280;
		/// <summary>
		/// ί��ӹ����뵥ɾ��
		/// </summary>
		public const int WTOWDelete = 2290;
		/// <summary>
		/// ί��ӹ����뵥һ������
		/// </summary>
		public const int WTOWFirstAudit = 2300;
		/// <summary>
		/// ί��ӹ����뵥��������
		/// </summary>
		public const int WTOWSecondAudit = 2310;
		/// <summary>
		/// ί��ӹ����뵥��������
		/// </summary>
		public const int WTOWThirdAudit = 2320;
		/// <summary>
		/// ί��ӹ����ϵ����
		/// </summary>
		public const int WINWBrowser = 2330;
		/// <summary>
		/// ί��ӹ����ϵ��½�
		/// </summary>
		public const int WINWAdd = 2340;
		/// <summary>
		/// ί��ӹ����ϵ��༭
		/// </summary>
		public const int WINWEdit = 2350;
		/// <summary>
		/// ί��ӹ����ϵ��ύ
		/// </summary>
		public const int WINWPresent = 2360;
		/// <summary>
		/// ί��ӹ����ϵ�����
		/// </summary>
		public const int WINWCancel = 2370;
		/// <summary>
		/// ί��ӹ����ϵ�ɾ��
		/// </summary>
		public const int WINWDelete = 2380;
		/// <summary>
		/// ί��ӹ����ϵ�һ������
		/// </summary>
		public const int WINWFirstAudit = 2390;
		/// <summary>
		/// ί��ӹ����ϵ���������
		/// </summary>
		public const int WINWSecondAudit = 2400;
		/// <summary>
		/// ί��ӹ����ϵ���������
		/// </summary>
		public const int WINWThirdAudit = 2410;
		/// <summary>
		/// ���ͳ�Ʋ鿴
		/// </summary>
		public const int StockAnalysis = 2420;
		/// <summary>
		/// ����ͳ�Ʋ鿴
		/// </summary>
		public const int WithDrawAnalysis = 2430;
		/// <summary>
		/// �깺ͳ�Ʋ鿴
		/// </summary>
		public const int ROSAnalysis = 2440;
		/// <summary>
		/// ��Ӧ��ͳ�Ʋ鿴
		/// </summary>
		public const int VendorAnalysis = 2450;
		/// <summary>
		/// ����鿴
		/// </summary>
		public const int PayBrowser = 2460;
		/// <summary>
		/// �����½�
		/// </summary>
		public const int PayAdd = 2470;
		/// <summary>
		/// �����ύ
		/// </summary>
		public const int PayPresent = 2480;
		/// <summary>
		/// ��������
		/// </summary>
		public const int PayThirdAudit = 2490;
		/// <summary>
		/// ����ȷ��
		/// </summary>
		public const int PayConfirm = 2500;
		/// <summary>
		/// ��������
		/// </summary>
		public const int PayCancel = 2510;
		/// <summary>
		/// ����ɾ��
		/// </summary>
		public const int PayDelete = 2520;
		/// <summary>
		/// ԭ�����շ�ά��
		/// </summary>
		public const int YCLIO = 2530;
		/// <summary>
		/// ����ģ��
		/// </summary>
		public const int Audit = 2540;
		/// <summary>
		/// ��Ӧ�̷���ά��
		/// </summary>
		public const int PPRCMaintain = 2550;
		/// <summary>
		/// �ɹ��������鿴
		/// </summary>
		public const int CancelBrowser = 2560;
		/// <summary>
		/// �ɹ��������½�
		/// </summary>
		public const int CancelAdd = 2570;
		/// <summary>
		/// �ɹ��������༭
		/// </summary>
		public const int CancelEdit = 2580;
		/// <summary>
		/// �ɹ��������ύ
		/// </summary>
		public const int CancelPresent = 2590;
		/// <summary>
		/// �ɹ�����������
		/// </summary>
		public const int CancelCancel = 2600;
		/// <summary>
		/// �ɹ�������ɾ��
		/// </summary>
		public const int CancelDelete = 2610;
		/// <summary>
		/// �ɹ�������һ������
		/// </summary>
		public const int CancelFirstAudit = 2620;
		/// <summary>
		/// �ɹ���������������
		/// </summary>
		public const int CancelSecondAudit = 2630;
		/// <summary>
		/// �ɹ���������������
		/// </summary>
		public const int CancelThirdAudit = 2640;
		private SysRight() {}
	}*/

	/// <summary>
	/// �й����߰������ö�١�
	/// </summary>
	/// <remarks>���಻�����̳м�ʵ������</remarks>
	public sealed class HelpCode
	{
		/// <summary>
		/// �ҵĹ���
		/// </summary>
		public const string MyJob = "MM_00";
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public const string BaseInfo = "MM_01";
		/// <summary>
		/// ���Ϸ���
		/// </summary>
		public const string Category = "MM_01_01";
		/// <summary>
		/// ������λ
		/// </summary>
		public const string Unit = "MM_01_02";
		/// <summary>
		/// �ֿ�
		/// </summary>
		public const string Storage = "MM_01_03";
		/// <summary>
		/// ����
		/// </summary>
		public const string Item = "MM_01_04";
		/// <summary>
		/// ��;
		/// </summary>
		public const string Purpose = "MM_01_05";
		/// <summary>
		/// ��Ӧ��
		/// </summary>
		public const string Vendor = "MM_01_06";
		/// <summary>
		/// �ɹ���ͬ����
		/// </summary>
		public const string ContactType = "MM_01_07";
		/// <summary>
		/// �ɹ���ͬ����׶�
		/// </summary>
		public const string ContactPayStep = "MM_01_08";
		/// <summary>
		/// �ɹ���ͬ����׶α�־
		/// </summary>
		public const string ContactPayStepTag = "MM_01_09";
		/// <summary>
		/// �ɹ���ͬ��������
		/// </summary>
		public const string ContactPayQuality = "MM_01_10";
        /// <summary>
        /// �ɹ��ʽ�����
        /// </summary>
        public const string ContractMoneyProperty = "MM_01_11";
		/// <summary>
		/// �ɹ�����
		/// </summary>
		public const string PurchaseManage = "MM_02";
		/// <summary>
		/// �ɹ����뵥
		/// </summary>
		public const string ROS = "MM_02_01";
		/// <summary>
		/// ��������
		/// </summary>
		public const string MRP = "MM_02_02";
		/// <summary>
		/// �ɹ��ƻ�
		/// </summary>
		public const string PP = "MM_02_03";
		/// <summary>
		/// �ɹ�����
		/// </summary>
		public const string PO = "MM_02_04";
		/// <summary>
		/// �ɹ����ϵ�
		/// </summary>
		public const string BOR = "MM_02_05";
		/// <summary>
		/// �ɹ��˻���
		/// </summary>
		public const string RTV = "MM_02_06";
		/// <summary>
		/// �ɹ���ͬ
		/// </summary>
		public const string Contract = "MM_02_07";
		/// <summary>
		/// ����������
		/// </summary>
		public const string BRB = "MM_02_08";
		/// <summary>
		/// ������
		/// </summary>
		public const string StockManage = "MM_03";
		/// <summary>
		/// ���ϵ�
		/// </summary>
		public const string DRW = "MM_03_01";
		/// <summary>
		/// �������ϵ�
		/// </summary>
		public const string RTS = "MM_03_02";
		/// <summary>
		/// ת�ⵥ
		/// </summary>
		public const string TRF = "MM_03_03";
		/// <summary>
		/// ���ϵ�
		/// </summary>
		public const string DAU = "MM_03_04";
		/// <summary>
		/// ��λ����
		/// </summary>
		public const string CAD = "MM_03_05";
		/// <summary>
		/// ����
		/// </summary>
		public const string IN = "MM_03_06";
		/// <summary>
		/// ����
		/// </summary>
		public const string OUT = "MM_03_07";
		/// <summary>
		/// ����ѯ
		/// </summary>
		public const string StockQuery = "MM_03_08";
		/// <summary>
		/// ���ϲ�ѯ
		/// </summary>
		public const string primness = "MM_03_09";
		/// <summary>
		/// ����������
		/// </summary>
		public const string BDB = "MM_03_10";
		/// <summary>
		/// �������
		/// </summary>
		public const string ReportManage = "MM_04";
		/// <summary>
		/// ϵͳ����
		/// </summary>
		public const string SystemManage = "MM_05";
		/// <summary>
		/// �û�����
		/// </summary>
		public const string UserManage = "MM_05_01";
		/// <summary>
		/// ��ɫȨ�޹���
		/// </summary>
		public const string RoleManage = "MM_05_02";
		/// <summary>
		/// �û����ݲ��Ź���
		/// </summary>
		public const string UDD = "MM_05_03";
		/// <summary>
		/// ��ѯ��������
		/// </summary>
		public const string QueryScheme = "MM_05_04";
		private HelpCode() {}
	}

}
