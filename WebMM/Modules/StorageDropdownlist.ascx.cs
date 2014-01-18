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

namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;
    using System.Collections.Generic;
    
	/// <summary>
	///		ItemPurMak ��ժҪ˵����
	/// </summary>
	public partial class StorageDropdownlist : System.Web.UI.UserControl
	{
		#region ��Ա����
		private string _StoCode = "";
		private short _DocType;
		private string _UserCode;
		private string _DeptCode;
       
		private string _selectedtext;
		private bool _autopostback=false;
		private string _selectedvalue;
		//private object _width;
		private bool _IsClear = false;
		private int _QRYModuleID;
		public DropDownList thisDDL;
        
	    private ListItem olt1 = new ListItem();

	    private ListItem olt2 = new ListItem();

	    private ListItem olt3 = new ListItem();

        private ListItem olt = new ListItem();

        private ListItem olt4 = new ListItem();

	    private ItemSystem oItemSystem = new ItemSystem();

	    private CategoryData oCatData = new CategoryData();

	    private PurposeData oPurposeData = new PurposeData();

	    private CheckReportData oCheckReportData = new CheckReportData();

	    private StoData oStoData = new StoData();

	    private ClassifyData oClassifyData = new ClassifyData();

	    private string temp_text;

	    private int i;

	    private string temp_value;

	    private UnitData oUnitData;

	    private IPslpSystem oIPslpSystem = new PurchaseSystem();

	    private PslpData oPslpData = new PslpData();

	    private StoConData oStoConData = new StoConData();

	    private PPRCData oData = new PPRCData();

        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

     

	   // private EntryUser odUserData = new EntryUser();

	    private SysSystem oSysSystem = new SysSystem();
	    private PPRNData oPPRNData = new PPRNData();
	    private DeptData oDeptData = new DeptData();

	    
	    //private int solutionID;

	    private PurchaseOrderData oPurchaseOrderData;

	    private ItemData oItemData = new ItemData();

        private IList<UserInfo> userlist;

        //private Shmzh.Components.SystemComponent.SQLServerDAL.User user = new Shmzh.Components.SystemComponent.SQLServerDAL.User();

        private IList<DeptInfo> deptlist;

		#endregion

		#region ����
		/// <summary>
		/// �����б�Ŀ�����ԡ�
		/// </summary>
		public Unit Width
		{
            get { return thisDDL.Width; }
            set { thisDDL.Width = value; }
		}
			/// <summary>
		/// �����б�Ķ������ԡ�
		/// </summary>
		public int Module_Tag
		{
			get{ return ViewState["Module_Tag"]==null?0:(int)ViewState["Module_Tag"]; }
			set{ ViewState["Module_Tag"]=value; }
		}
		/// <summary>
		/// �����б�Ļ������ԡ�
		/// </summary>
		public bool AutoPostBack
		{
			get{ return thisDDL.AutoPostBack; }
			set{this.thisDDL.AutoPostBack = value;}
		}
		/// <summary>
		/// �����б�ĵ�ǰ��ʾֵ���ԡ�
		/// </summary>
		public string SelectedText
		{
			get
			{ 
				if (thisDDL.Items.Count!=0)
					return thisDDL.SelectedItem.Text; 
				else
					return "";
			}
			set
			{
				_selectedtext=value;
			}
		}
		/// <summary>
		/// �����б�ĵ�ǰֵ���ԡ�
		/// </summary>
		public string SelectedValue
		{
			get
			{
				if (thisDDL.Items.Count!=0)
				{
					return thisDDL.SelectedItem.Value; 
				}
				else
					return "";
			}
			set
			{ 
				_selectedvalue=value;
			}
		}
		/// <summary>
		/// �ֿ������ԡ�
		/// </summary>
		public string StoCode
		{
			get { return _StoCode; }
			set { _StoCode = value; }
		}
		/// <summary>
		/// ���ű�š�
		/// </summary>
		public string DeptCode
		{
			get {	return _DeptCode;}
			set {	_DeptCode = value;}
		}

        public string DeptCo { get; set; }
		/// <summary>
		/// �����б��Ƿ���Ч���ԡ�
		/// </summary>
		public bool Enable
		{
			get {	return this.thisDDL.Enabled;	}
			set {	this.thisDDL.Enabled = value;	}
		}
		/// <summary>
		/// ��ǰ���û�.
		/// </summary>
		/// <remarks>
		/// �����Խ���ͨ�ò�ѯ��ʹ�ã������޶���Ȩ�����Ĳ����б��С�
		/// </remarks>
		public string UserCode
		{
			get { return this._UserCode; }
			set { this._UserCode = value; }
		}
		/// <summary>
		/// ��ǰ�ĵ������͡�
		/// </summary>
		/// <remarks>
		/// �����Խ���ͨ�ò�ѯ��ʹ�ã������޶���Ȩ�����Ĳ����б��С�
		/// </remarks>
		public short DocType
		{
			get { return this._DocType;}
			set { this._DocType = value;}
		}
		/// <summary>
		/// PageLoad��ʱ���Ƿ�Ҫ��������б����
		/// </summary>
		/// <remarks>
		/// �����Խ���ͨ�ò�ѯ��ʹ�á���ʼֵΪfalse��
		/// </remarks>
		public bool IsClear
		{
			get { return this._IsClear; }
			set { this._IsClear = value; }
		}
		/// <summary>
		/// ��ѯģ��ID��
		/// </summary>
		public int QRYModuleID
		{
			get { return this._QRYModuleID;}
			set { this._QRYModuleID = value;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �����б����ݰ󶨡�
		/// </summary>
		public void myBindData()
		{
			if(this.IsClear)
			{
				thisDDL.Items.Clear();
			}

			switch(this.Module_Tag)
			{
					#region �ƹ�����
				case (int)SDDLTYPE.PURMAK:
				{
					olt1=new ListItem(ItemPurMak.PURCHASE_DESCRIPTION,ItemPurMak.PURCHASE_CODE);
					thisDDL.Items.Add(olt1);

					olt2=new ListItem(ItemPurMak.MAKESELF_DESCRIPTION,ItemPurMak.MAKESELF_CODE);
					thisDDL.Items.Add(olt2);

					olt3=new ListItem(ItemPurMak.COOPERATE_DESCRIPTION,ItemPurMak.COOPERATE_CODE);
					thisDDL.Items.Add(olt3);
					break;
				}
					#endregion
					#region ���Ϸ���
				case (int)SDDLTYPE.CATEGORY:
				{
					

					oCatData=oItemSystem.QueryAllCategories();
			
					for(i=0;i<oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows.Count;i++)
					{
						
						temp_text = oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows[i][CategoryData.CODE_FIELD].ToString() + "-" +oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows[i][CategoryData.DESCRIPTION_FIELD].ToString();
						temp_value = oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows[i][CategoryData.CODE_FIELD].ToString();

						olt=new ListItem(temp_text, temp_value);
						thisDDL.Items.Add(olt);
					}

					break;
				}
					#endregion
					#region ��Ч�����Ϸ���
				case (int)SDDLTYPE.ACAT:
				{


                    oCatData = oItemSystem.QueryAllCategories();
			
					for(i=0;i<oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows.Count;i++)
					{
						
						temp_text = oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows[i][CategoryData.CODE_FIELD].ToString() + "-" +oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows[i][CategoryData.DESCRIPTION_FIELD].ToString();
						temp_value = oCatData.Tables[CategoryData.CATEGORIES_TABLE].Rows[i][CategoryData.CODE_FIELD].ToString();

						olt=new ListItem(temp_text, temp_value);
						thisDDL.Items.Add(olt);
					}

					break;
				}
					#endregion
					#region ����״̬
				case (int)SDDLTYPE.ITEMSTATE:
				{
					olt1=new ListItem(ItemState.ACTIVE_DESCRIPTION,ItemState.ACTIVE_CODE);
					thisDDL.Items.Add(olt1);

					olt2=new ListItem(ItemState.CANCEL_DESCRITION,ItemState.CANCEL_CODE);
					thisDDL.Items.Add(olt2);

					olt3=new ListItem(ItemState.ELIMILATE_DESCRIPTION,ItemState.ELIMILATE_CODE);
					thisDDL.Items.Add(olt3);

					olt4=new ListItem(ItemState.ENGINEER__DESCRIPTION,ItemState.ENGINEER_CODE);
					thisDDL.Items.Add(olt4);
					
					break;
				}
					#endregion
					#region"������λ"
				case (int)SDDLTYPE.UNIT:
				{
					oUnitData=new UnitData();

					oUnitData=oItemSystem.QueryAllUnits();
			
					for(i=0;i<oUnitData.Tables[UnitData.UNIT_TABLE].Rows.Count;i++)
					{
						olt=new ListItem(oUnitData.Tables[UnitData.UNIT_TABLE].Rows[i][UnitData.DESCRIPTION_FIELD].ToString(),oUnitData.Tables[UnitData.UNIT_TABLE].Rows[i][UnitData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}
					#endregion
					#region"ABC"
				case (int)SDDLTYPE.ABC:
				{
					olt1=new ListItem(ABC.A_DESCRIPTION,ABC.A_CODE);
					thisDDL.Items.Add(olt1);

					olt2=new ListItem(ABC.B_DESCRIPTION,ABC.B_CODE);
					thisDDL.Items.Add(olt2);

					olt3=new ListItem(ABC.C_DESCRIPTION,ABC.C_CODE);
					thisDDL.Items.Add(olt3);

					break;
				}
					#endregion
					#region"����������"
				case (int)SDDLTYPE.VCTYPE:
				{
					thisDDL.Items.Add(new ListItem("��Ӧ��",PprnType.Vendor));
					//thisDDL.Items.Add(new ListItem("A��ȫ��","A"));
					//thisDDL.Items.Add(new ListItem("V���ͻ�","C"));
					thisDDL.Items.Add(new ListItem("����λ",PprnType.Self));
					thisDDL.Items.Add(new ListItem("OTA��Ӧ��",PprnType.OTAVendor));
					break;
				}
					#endregion
					#region"���ϲ�ѯ������"
				case (int)SDDLTYPE.ITEMQUERY:
				{
					thisDDL.Items.Add(new ListItem("��������","NAME"));
					thisDDL.Items.Add(new ListItem("ƴ��","PY"));	
					thisDDL.Items.Add(new ListItem("���ϱ��","CODE"));
                    thisDDL.Items.Add(new ListItem("�±��","NEWCODE"));
					thisDDL.Items.Add(new ListItem("����ͺ�","SPEC"));
					thisDDL.Items.Add(new ListItem("ȫ----��","ALL"));
					break;
				}
					#endregion			
					#region"������������"
				case (int)SDDLTYPE.VCAPPROVE:
				{
					thisDDL.Items.Add(new ListItem("��","Y"));
					thisDDL.Items.Add(new ListItem("��","N"));
					//thisDDL.Items.Add(new ListItem("������","P"));
					break;
				}
					#endregion
					#region"���Ҵ���"
				case (int)SDDLTYPE.CURRENCY:
				{
					thisDDL.Items.Add(new ListItem("�����","RMB"));
					thisDDL.Items.Add(new ListItem("��  Ԫ","USD"));
					thisDDL.Items.Add(new ListItem("ŷ  Ԫ","EUR"));
					thisDDL.Items.Add(new ListItem("��  ��","HKD"));
					thisDDL.Items.Add(new ListItem("��  Ԫ","JPY"));
					thisDDL.Items.Add(new ListItem("��  Ԫ","JPY"));
					thisDDL.Items.Add(new ListItem("��  Ԫ","JPY"));
					thisDDL.Items.Add(new ListItem("Ӣ  ��","GBP"));
					thisDDL.Items.Add(new ListItem("��  ��","CHF"));
					thisDDL.Items.Add(new ListItem("��  ��","CHF"));
					break;
				}
					#endregion
					#region"���ʽ"
				case (int)SDDLTYPE.PAYSTYLE:
				{
					//Fourth Shift ����
					//--------------------------------------------
					//B = BOE�� �� Ʊ��
					//C = ֧ Ʊ
					//D = �� �� �� Ʊ
					//G = GIRO/BACS�� �� �� ֱ �� ת �� �� �ȣ� 
					//M = �� ��
					//T = �� �� �� ��
					//---------------------------------------------
					//ˮ������
					//---------------------------------------------
					//��ί���ֽ�֧Ʊ
					thisDDL.Items.Add(new ListItem("��ί", "G"));//Bank Transfer
					thisDDL.Items.Add(new ListItem("�ֽ�", "Q"));//In Cash
					thisDDL.Items.Add(new ListItem("֧Ʊ", "C"));//Cash Draft
					//-----------------------------------------------------------------------------------------------------
					//����ó������
					//-----------------------------------------------------------------------------------------------------
					//					thisDDL.Items.Add(new ListItem("L/D������  ֤", "L/D"));//����֤L/C(Letter of Credit) 
					//					thisDDL.Items.Add(new ListItem("D/P�������", "D/P"));//�����D/P(Documents against Payment)
					//					thisDDL.Items.Add(new ListItem("D/A���и�����", "D/A"));//�и�����D/A(Documents against Acceptance)
					//					thisDDL.Items.Add(new ListItem("M/T����    ��", "M/T"));//�Ż�M/T(Mail Transfer)
					//					thisDDL.Items.Add(new ListItem("T/T����    ��", "T/T"));//���T/T(Telegraphic Transfer)
					//					thisDDL.Items.Add(new ListItem("D/D��Ʊ    ��", "D/D"));//Ʊ�� D/D(Demand Draft)
					//					thisDDL.Items.Add(new ListItem("P/N�����б�Ʊ", "P/N"));//���б�ƱP/N(Promissory Notes)
					//					thisDDL.Items.Add(new ListItem("I/C���ֽ�֧��", "I/C"));//�ֽ�֧�� (In Cash)
					//					thisDDL.Items.Add(new ListItem("C/D���ֽ�֧Ʊ", "C/D"));//�ֽ�֧Ʊ ��Cash Draft��
					//					thisDDL.Items.Add(new ListItem("O/A����    ��", "O/A"));//���� O/A(Open Account)
					//					thisDDL.Items.Add(new ListItem("O/A����    ��", "O/A"));//
					//					thisDDL.Items.Add(new ListItem("F/F����    ��", "F/F"));//��Ѳ���ʵ�ʸ��ʽ�����ǵ��ڹ���ó��ҵ��͹���ͳ�Ʒ������Ҫ��������Ʒ�����͡�������Ԯ���Ȳ�����������
					break;
				}
					#endregion
					#region"���ʷ�ʽ"
				case (int)SDDLTYPE.ACCOUNT:
				{
					olt1=new ListItem(ItemAccountType.WAREHOUSE_DESCRIPTION,ItemAccountType.WAREHOUSE_CODE);
					thisDDL.Items.Add(olt1);

					olt2=new ListItem(ItemAccountType.CATEGROY_DESCRIPTION,ItemAccountType.CATEGROY_CODE);
					thisDDL.Items.Add(olt2);
				
					break;
				}
					#endregion
					#region"�ֿ��б�"
				case (int)SDDLTYPE.STORAGE:
				{
					

					if(this.AutoPostBack)
						thisDDL.AutoPostBack=true;
					else
						thisDDL.AutoPostBack=false;

					oStoData = oItemSystem.GetStoAll();
			
					for(i=0;i<oStoData.Tables[StoData.STO_TABLE].Rows.Count;i++)
					{
						olt=new ListItem(oStoData.Tables[StoData.STO_TABLE].Rows[i][StoData.DESCRIPTION_FIELD].ToString(),oStoData.Tables[StoData.STO_TABLE].Rows[i][StoData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					
					break;
				}
					#endregion
					#region"��;�б�"
				case (int)SDDLTYPE.PURPOSE:
				{
				
					oPurposeData = oItemSystem.GetPurposeAvalible();
					for ( i=0; i < oPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count; i++)
					{
						olt = new ListItem(oPurposeData.Tables[PurposeData.USE_TABLE].Rows[i][PurposeData.DESCRIPTION_FIELD].ToString(),oPurposeData.Tables[PurposeData.USE_TABLE].Rows[i][PurposeData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					//thisDDL.AutoPostBack=true;
					break;
				}

					#endregion
					#region ��;����
				case (int)SDDLTYPE.Classify:
				{
				
					oClassifyData = oItemSystem.GetClassifyInUsing();
					for (i=0; i< oClassifyData.Count; i++)
					{
						olt = new ListItem(oClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[i][ClassifyData.DESCRIPTION_FIELD].ToString(),
													oClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[i][ClassifyData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}
					
					#endregion
					#region"�ɹ�Ա�б�"
						case (int)SDDLTYPE.PSLP:
											   {
					
					oPslpData = oIPslpSystem.GetPslpAll();
					for (i=0; i < oPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count; i++)
					{
						olt = new ListItem(oPslpData.Tables[PslpData.PSLP_TABLE].Rows[i][PslpData.DESCRIPTION_FIELD].ToString(),oPslpData.Tables[PslpData.PSLP_TABLE].Rows[i][PslpData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					//thisDDL.AutoPostBack=true;
					break;
				}
					#endregion
					#region"��λ�б�"
				case (int)SDDLTYPE.CONTAINER:
				{
					if (this._StoCode != "")
					{
						
					
						oStoConData = oItemSystem.GetStoConByStoCode(this._StoCode);
			
						for(i=0;i<oStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count;i++)
						{
							olt=new ListItem(oStoConData.Tables[StoConData.STOCON_TABLE].Rows[i][StoConData.DESCRIPTION_FIELD].ToString(),oStoConData.Tables[StoConData.STOCON_TABLE].Rows[i][StoConData.CODE_FIELD].ToString());
							thisDDL.Items.Add(olt);
						}
					}
					break;
				}
					#endregion
					#region"�����б�"
				case (int)SDDLTYPE.DEPT:
				{
                    try
                    {
                        var companyCode = ((Shmzh.Components.SystemComponent.User)Session[MySession.User]).Company;
                        var deptlist = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(companyCode);
                        
                        for (i = 0; i < deptlist.Count; i++)
                        {
                            olt = new ListItem(deptlist[i].DeptCnName, deptlist[i].DeptCode);
                            thisDDL.Items.Add(olt);
                        }
                    }
                    catch { }
					break;
				}
                case (int)SDDLTYPE.AllDept:
			        {
			            try
			            {
                            deptlist = DataProvider.DeptProvider.GetAllByCompanyCode(DeptCo);
			                for (i = 0; i < deptlist.Count; i++)
			                {
                                olt = new ListItem(deptlist[i].DeptCnName, deptlist[i].DeptCode);
                                thisDDL.Items.Add(olt);
			                }
			            }
			            catch
			            {
			                
			            }
			        break;
			        }
			       

					#endregion
					#region ������������
				case (int)SDDLTYPE.Drawer:
				{
                    var companyCode = ((Shmzh.Components.SystemComponent.User)Session[MySession.User]).Company;
                    var users = DataProvider.UserProvider.GetAllEmployeeByCompanyAndDept(companyCode, this.DeptCode,false);
                    foreach (var user in users)
                    {
                        olt = new ListItem(user.EmpName, user.EmpCode);
                        thisDDL.Items.Add(olt);
                    }
					break;
				}
					#endregion
					#region"�û��б�"
				case (int)SDDLTYPE.USER:
				{
                    var companyCode = ((Shmzh.Components.SystemComponent.User)Session["User"]).Company;
                    userlist = DataProvider.UserProvider.GetAllUserByCompany(companyCode);

                    for (i = 0; i < userlist.Count; i++)
					{
                        olt = new ListItem(userlist[i].EmpName, userlist[i].EmpCode);
                        thisDDL.Items.Add(olt);
					}
					thisDDL.AutoPostBack=true;
					break;
				}
					#endregion
					#region"���鱨��"
				case (int)SDDLTYPE.CHECKREPORT:
				{
				
					oCheckReportData = oItemSystem.QueryAllCheckReports();
			
					for(i=0;i<oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows.Count;i++)
					{
						olt=new ListItem(oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[i][CheckReportData.DESCRIPTION_FIELD].ToString(),oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[i][CheckReportData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}
					#endregion
					#region"��Ӧ��"
				case (int)SDDLTYPE.VENDOR:
				{
					oPurchaseSystem = new PurchaseSystem();
				    oPPRNData = new PPRNData();

					oPPRNData = oPurchaseSystem.GetPPRNByTypeAndStatusAndApprove("V","A","Y");
			
					for(i=0;i<oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count;i++)
					{
						olt=new ListItem(oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[i][PPRNData.CNNAME_FIELD].ToString(),oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[i][PPRNData.CODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}
					#endregion
					#region ��Ӧ�̷���
				case (int)SDDLTYPE.VendorType:
				{
					
				      
					oData = oPurchaseSystem.GetPPRCAll();

					for (i = 0; i< oData.Tables[0].Rows.Count;i++)
					{
						olt = new ListItem(oData.Tables[0].Rows[i]["CnName"].ToString(),oData.Tables[0].Rows[i]["Code"].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}
					#endregion
					#region"����״̬"
				case (int)SDDLTYPE.ENTRYSTATE:
				{
					thisDDL.Items.Add(new ListItem("�½�","N"));
					thisDDL.Items.Add(new ListItem("����һ","F"));
					thisDDL.Items.Add(new ListItem("�����","S"));
					thisDDL.Items.Add(new ListItem("������","T"));
					thisDDL.Items.Add(new ListItem("���","O"));
					break;
				}
					#endregion
					#region ˰��
				case (int)SDDLTYPE.TAX:
				{
					thisDDL.Items.Add(new ListItem("-1","0.00"));
					thisDDL.Items.Add(new ListItem("1","0.06"));
					thisDDL.Items.Add(new ListItem("2","0.10"));
					thisDDL.Items.Add(new ListItem("3","0.17"));
					thisDDL.AutoPostBack=true;
					break;
				}
					#endregion
					#region ���
				case (int)SDDLTYPE.YEAR:
				{
					for (i = 2005; i< DateTime.Now.Year +2;i++)
					{
						thisDDL.Items.Add(new ListItem(i.ToString(),i.ToString()));
					}
					break;
				}
					#endregion
					#region �·�
				case (int)SDDLTYPE.MONTH:
				{
					for (i = 1; i < 13; i++)
					{
						thisDDL.Items.Add(new ListItem(i.ToString(),i.ToString()));
					}
					break;
				}
					#endregion
					#region ��Ȩ�����Ĳ���
				case (int)SDDLTYPE.OWNDEPT:
				{
					oDeptData = oSysSystem.GetDeptByUserAndDoc(this.UserCode,this.DocType);
					
					//����Ϊ�����
					olt = new ListItem("δ����","-1");
					thisDDL.Items.Add(olt);
					for (i=0; i < oDeptData.Tables[DeptData.Dept_Table].Rows.Count; i++)
					{
						olt = new ListItem(oDeptData.Tables[DeptData.Dept_Table].Rows[i][DeptData.Description_Field].ToString(),
							                        oDeptData.Tables[DeptData.Dept_Table].Rows[i][DeptData.Code_Field].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}

					#endregion
					#region Һ����ض����б�
				case (int)SDDLTYPE.YLORDER:
				{
					
					oPurchaseOrderData = oPurchaseSystem.GetYLPOInExec();
					for (i=0; i<oPurchaseOrderData.Count; i++)
					{
						olt=new ListItem(oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE].Rows[i][InItemData.ENTRYCODE_FIELD].ToString(),
							                      oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE].Rows[i][InItemData.ENTRYCODE_FIELD].ToString());
						thisDDL.Items.Add(olt);
					}
					break;
				}
					#endregion
					#region �������
				case (int)SDDLTYPE.CheckResult:
				{
					
					olt = new ListItem("����ͨ��","����ͨ��");
                    thisDDL.Items.Add(olt);
                    olt = new ListItem("���ղ�ͨ��", "���ղ�ͨ��");
                    thisDDL.Items.Add(olt);
					break;
				}
					#endregion
					#region ԭ����
				case (int)SDDLTYPE.YCL:
				{
					
					//ItemData oItemData;
					oItemData = new ItemSystem().GetItemsByCatCode(1);
					for(i=0;i< oItemData.Count; i++)
					{
                        olt = new ListItem(oItemData.Tables[0].Rows[i][ItemData.CNNAME_FIELD].ToString(), oItemData.Tables[0].Rows[i][ItemData.CODE_FIELD].ToString());
                        thisDDL.Items.Add(olt);
					}
					break;
					
				}
					#endregion
			}		


			if (!string.IsNullOrEmpty(_selectedvalue))
			{
				olt =thisDDL.Items.FindByValue(_selectedvalue);
                if (olt != null) olt.Selected = true;
			}

			thisDDL.AutoPostBack=_autopostback;
		}

		/// <summary>
		/// �����б�Load�¼���
		/// </summary>
		protected void thisDDL_Load(object sender, System.EventArgs e)
		{
			
		}
		#endregion
		
		#region ���÷���
		/// <summary>
		/// ����ֵѡ��ĳһ�
		/// </summary>
		/// <param name="selected">string: ֵ��</param>
		public void SetItemSelected(string selected)
		{
			if(thisDDL.SelectedIndex>=0)
			{
				thisDDL.Items[thisDDL.SelectedIndex].Selected=false;
			}
            if ((!string.IsNullOrEmpty(selected)) && (thisDDL.Items.Count != 0))
			{
				olt=thisDDL.Items.FindByValue(selected);
                if (olt != null) olt.Selected = true;
			}
		}
		/// <summary>
		/// �����ݡ�
		/// </summary>
		public void SetDDL()
		{
			this.myBindData();
		}
		#endregion

		#region �¼�
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				myBindData();
			}

		}
		#endregion

		protected void thisDDL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (this.Module_Tag == (int)SDDLTYPE.STORAGE||this.Module_Tag == (int)SDDLTYPE.VENDOR)
			//{
				RaiseBubbleEvent(sender,e);
			//}
		}

		

	}
}
