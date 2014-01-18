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
	///		ItemPurMak 的摘要说明。
	/// </summary>
	public partial class StorageDropdownlist : System.Web.UI.UserControl
	{
		#region 成员变量
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

		#region 属性
		/// <summary>
		/// 下拉列表的宽度属性。
		/// </summary>
		public Unit Width
		{
            get { return thisDDL.Width; }
            set { thisDDL.Width = value; }
		}
			/// <summary>
		/// 下拉列表的对象属性。
		/// </summary>
		public int Module_Tag
		{
			get{ return ViewState["Module_Tag"]==null?0:(int)ViewState["Module_Tag"]; }
			set{ ViewState["Module_Tag"]=value; }
		}
		/// <summary>
		/// 下拉列表的回送属性。
		/// </summary>
		public bool AutoPostBack
		{
			get{ return thisDDL.AutoPostBack; }
			set{this.thisDDL.AutoPostBack = value;}
		}
		/// <summary>
		/// 下拉列表的当前显示值属性。
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
		/// 下拉列表的当前值属性。
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
		/// 仓库编号属性。
		/// </summary>
		public string StoCode
		{
			get { return _StoCode; }
			set { _StoCode = value; }
		}
		/// <summary>
		/// 部门编号。
		/// </summary>
		public string DeptCode
		{
			get {	return _DeptCode;}
			set {	_DeptCode = value;}
		}

        public string DeptCo { get; set; }
		/// <summary>
		/// 下拉列表是否有效属性。
		/// </summary>
		public bool Enable
		{
			get {	return this.thisDDL.Enabled;	}
			set {	this.thisDDL.Enabled = value;	}
		}
		/// <summary>
		/// 当前的用户.
		/// </summary>
		/// <remarks>
		/// 该属性仅在通用查询中使用，用于限定有权操作的部门列表中。
		/// </remarks>
		public string UserCode
		{
			get { return this._UserCode; }
			set { this._UserCode = value; }
		}
		/// <summary>
		/// 当前的单据类型。
		/// </summary>
		/// <remarks>
		/// 该属性仅在通用查询中使用，用于限定有权操作的部门列表中。
		/// </remarks>
		public short DocType
		{
			get { return this._DocType;}
			set { this._DocType = value;}
		}
		/// <summary>
		/// PageLoad的时候是否要清除下拉列表中项。
		/// </summary>
		/// <remarks>
		/// 该属性仅在通用查询中使用。初始值为false。
		/// </remarks>
		public bool IsClear
		{
			get { return this._IsClear; }
			set { this._IsClear = value; }
		}
		/// <summary>
		/// 查询模块ID。
		/// </summary>
		public int QRYModuleID
		{
			get { return this._QRYModuleID;}
			set { this._QRYModuleID = value;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 下拉列表数据绑定。
		/// </summary>
		public void myBindData()
		{
			if(this.IsClear)
			{
				thisDDL.Items.Clear();
			}

			switch(this.Module_Tag)
			{
					#region 制购属性
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
					#region 物料分类
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
					#region 有效的物料分类
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
					#region 物料状态
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
					#region"度量单位"
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
					#region"合作伙伴类别"
				case (int)SDDLTYPE.VCTYPE:
				{
					thisDDL.Items.Add(new ListItem("供应商",PprnType.Vendor));
					//thisDDL.Items.Add(new ListItem("A—全部","A"));
					//thisDDL.Items.Add(new ListItem("V—客户","C"));
					thisDDL.Items.Add(new ListItem("本单位",PprnType.Self));
					thisDDL.Items.Add(new ListItem("OTA供应商",PprnType.OTAVendor));
					break;
				}
					#endregion
					#region"物料查询条件项"
				case (int)SDDLTYPE.ITEMQUERY:
				{
					thisDDL.Items.Add(new ListItem("物料名称","NAME"));
					thisDDL.Items.Add(new ListItem("拼音","PY"));	
					thisDDL.Items.Add(new ListItem("物料编号","CODE"));
                    thisDDL.Items.Add(new ListItem("新编号","NEWCODE"));
					thisDDL.Items.Add(new ListItem("规格型号","SPEC"));
					thisDDL.Items.Add(new ListItem("全----部","ALL"));
					break;
				}
					#endregion			
					#region"合作伙伴已审核"
				case (int)SDDLTYPE.VCAPPROVE:
				{
					thisDDL.Items.Add(new ListItem("是","Y"));
					thisDDL.Items.Add(new ListItem("否","N"));
					//thisDDL.Items.Add(new ListItem("试用期","P"));
					break;
				}
					#endregion
					#region"货币代码"
				case (int)SDDLTYPE.CURRENCY:
				{
					thisDDL.Items.Add(new ListItem("人民币","RMB"));
					thisDDL.Items.Add(new ListItem("美  元","USD"));
					thisDDL.Items.Add(new ListItem("欧  元","EUR"));
					thisDDL.Items.Add(new ListItem("港  币","HKD"));
					thisDDL.Items.Add(new ListItem("日  元","JPY"));
					thisDDL.Items.Add(new ListItem("加  元","JPY"));
					thisDDL.Items.Add(new ListItem("澳  元","JPY"));
					thisDDL.Items.Add(new ListItem("英  镑","GBP"));
					thisDDL.Items.Add(new ListItem("法  郎","CHF"));
					thisDDL.Items.Add(new ListItem("克  郎","CHF"));
					break;
				}
					#endregion
					#region"付款方式"
				case (int)SDDLTYPE.PAYSTYLE:
				{
					//Fourth Shift 种类
					//--------------------------------------------
					//B = BOE（ 汇 票）
					//C = 支 票
					//D = 银 行 汇 票
					//G = GIRO/BACS（ 银 行 直 接 转 帐 制 度） 
					//M = 其 它
					//T = 银 行 划 款
					//---------------------------------------------
					//水厂种类
					//---------------------------------------------
					//付委、现金、支票
					thisDDL.Items.Add(new ListItem("付委", "G"));//Bank Transfer
					thisDDL.Items.Add(new ListItem("现金", "Q"));//In Cash
					thisDDL.Items.Add(new ListItem("支票", "C"));//Cash Draft
					//-----------------------------------------------------------------------------------------------------
					//国际贸易种类
					//-----------------------------------------------------------------------------------------------------
					//					thisDDL.Items.Add(new ListItem("L/D—信用  证", "L/D"));//信用证L/C(Letter of Credit) 
					//					thisDDL.Items.Add(new ListItem("D/P—付款交单", "D/P"));//付款交单D/P(Documents against Payment)
					//					thisDDL.Items.Add(new ListItem("D/A—承付交单", "D/A"));//承付交单D/A(Documents against Acceptance)
					//					thisDDL.Items.Add(new ListItem("M/T—信    汇", "M/T"));//信汇M/T(Mail Transfer)
					//					thisDDL.Items.Add(new ListItem("T/T—电    汇", "T/T"));//电汇T/T(Telegraphic Transfer)
					//					thisDDL.Items.Add(new ListItem("D/D—票    汇", "D/D"));//票汇 D/D(Demand Draft)
					//					thisDDL.Items.Add(new ListItem("P/N—银行本票", "P/N"));//银行本票P/N(Promissory Notes)
					//					thisDDL.Items.Add(new ListItem("I/C—现金支付", "I/C"));//现金支付 (In Cash)
					//					thisDDL.Items.Add(new ListItem("C/D—现金支票", "C/D"));//现金支票 （Cash Draft）
					//					thisDDL.Items.Add(new ListItem("O/A—记    账", "O/A"));//记账 O/A(Open Account)
					//					thisDDL.Items.Add(new ListItem("O/A—记    账", "O/A"));//
					//					thisDDL.Items.Add(new ListItem("F/F—免    费", "F/F"));//免费不是实际付款方式，考虑到在国际贸易业务和管理、统计方面的需要，用在样品、赠送、捐赠、援助等不付款的情况。
					break;
				}
					#endregion
					#region"总帐方式"
				case (int)SDDLTYPE.ACCOUNT:
				{
					olt1=new ListItem(ItemAccountType.WAREHOUSE_DESCRIPTION,ItemAccountType.WAREHOUSE_CODE);
					thisDDL.Items.Add(olt1);

					olt2=new ListItem(ItemAccountType.CATEGROY_DESCRIPTION,ItemAccountType.CATEGROY_CODE);
					thisDDL.Items.Add(olt2);
				
					break;
				}
					#endregion
					#region"仓库列表"
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
					#region"用途列表"
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
					#region 用途分类
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
					#region"采购员列表"
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
					#region"架位列表"
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
					#region"部门列表"
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
					#region 本部门领料人
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
					#region"用户列表"
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
					#region"检验报告"
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
					#region"供应商"
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
					#region 供应商分类
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
					#region"单据状态"
				case (int)SDDLTYPE.ENTRYSTATE:
				{
					thisDDL.Items.Add(new ListItem("新建","N"));
					thisDDL.Items.Add(new ListItem("待审一","F"));
					thisDDL.Items.Add(new ListItem("待审二","S"));
					thisDDL.Items.Add(new ListItem("待审三","T"));
					thisDDL.Items.Add(new ListItem("完成","O"));
					break;
				}
					#endregion
					#region 税率
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
					#region 年份
				case (int)SDDLTYPE.YEAR:
				{
					for (i = 2005; i< DateTime.Now.Year +2;i++)
					{
						thisDDL.Items.Add(new ListItem(i.ToString(),i.ToString()));
					}
					break;
				}
					#endregion
					#region 月份
				case (int)SDDLTYPE.MONTH:
				{
					for (i = 1; i < 13; i++)
					{
						thisDDL.Items.Add(new ListItem(i.ToString(),i.ToString()));
					}
					break;
				}
					#endregion
					#region 有权操作的部门
				case (int)SDDLTYPE.OWNDEPT:
				{
					oDeptData = oSysSystem.GetDeptByUserAndDoc(this.UserCode,this.DocType);
					
					//增加为定义项。
					olt = new ListItem("未定义","-1");
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
					#region 液铝相关订单列表
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
					#region 验收情况
				case (int)SDDLTYPE.CheckResult:
				{
					
					olt = new ListItem("验收通过","验收通过");
                    thisDDL.Items.Add(olt);
                    olt = new ListItem("验收不通过", "验收不通过");
                    thisDDL.Items.Add(olt);
					break;
				}
					#endregion
					#region 原材料
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
		/// 下拉列表Load事件。
		/// </summary>
		protected void thisDDL_Load(object sender, System.EventArgs e)
		{
			
		}
		#endregion
		
		#region 公用方法
		/// <summary>
		/// 根据值选定某一项。
		/// </summary>
		/// <param name="selected">string: 值。</param>
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
		/// 绑定数据。
		/// </summary>
		public void SetDDL()
		{
			this.myBindData();
		}
		#endregion

		#region 事件
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
