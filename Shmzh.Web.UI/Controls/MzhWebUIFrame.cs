using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.ComponentModel;
using System.IO;
using System.Collections;
using System.Data;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

[assembly:TagPrefix("Shmzh.Web.UI.Controls", "MZH")]
namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// MzhWebUIFrame 的摘要说明。
	/// </summary>
	[DefaultProperty("Text"),ToolboxData("<{0}:MzhWebUIFrame runat=server></{0}:MzhWebUIFrame>")]
	public class MzhWebUIFrame : System.Web.UI.WebControls.WebControl
	{
        #region 公共接口及相关变量

	    /// <summary>
	    /// 当前用户。
	    /// </summary>
	    public Shmzh.Components.SystemComponent.User CurrentUser { get; set; }

	    /// <summary>
		/// 用户登录名
		/// </summary>
		public string LoginName
		{
			get
			{
			    return this.Page.Session["User"]!=null ? ((User) this.Page.Session["User"]).thisUserInfo.LoginName : _loginName;
			}
	        set {_loginName = value;}
		}
		private string _loginName = string.Empty;
		/// <summary>
		/// 显示名称。
		/// </summary>
		public string DisplayName
		{
			get {
			    return this.Page.Session["User"]!=null ? ((User) this.Page.Session["User"]).thisUserInfo.EmpName : _displayName;
			}
		    set {_displayName = value;}
		}
		private string _displayName = string.Empty;

	    /// <summary>
	    ///  产品ID
	    /// </summary>
	    public short ProductID 
        { 
            get { return short.Parse(System.Configuration.ConfigurationManager.AppSettings["ProductId"]); }  
        }

	    /// <summary>
	    /// 起始页
	    /// </summary>
	    public string DefaultPage { get; set; }

	    /// <summary>
	    /// Logo的URL连接。
	    /// </summary>
        [Category("Appearance"), DescriptionAttribute("Logo的超链接。"),DefaultValue("/KMSuit/")]
	    public string LogoUrl
	    {
            get
            {
                var o = ViewState["LogoUrl"];
                return (o != null ? o.ToString() : "/KMSuit/");
            }
            set
            {
                ViewState["LogoUrl"] = value;
            }
	    }

        /// <summary>
        /// Logo图片的URL地址。
        /// </summary>
	    [Category("Appearance"), DescriptionAttribute("Logo图片的地址。"), DefaultValue("/aspnet_client/Shmzh.Web.UI/Images/Logo.png")]
	    public string LogoImageUrl
	    {
            get
            {
                var o = ViewState["LogoImageUrl"];
                return (o != null ? o.ToString() : "/aspnet_client/Shmzh.Web.UI/Images/Logo.png");
            }
            set
            {
                ViewState["LogoImageUrl"] = value;
            }
	    }

        /// <summary>
        /// Logo图片的标题。
        /// </summary>
        [Category("Appearance"), DescriptionAttribute("Logo图片的标题。"), DefaultValue("办公首页")]
        public string LogoTitle
        {
            get
            {
                var o = ViewState["LogoTitle"];
                return (o != null ? o.ToString() : "办公首页");
            }
            set
            {
                ViewState["LogoTitle"] = value;
            }
        }

	    /// <summary>
	    ///  是否将Title做为页面参数进行传递
	    /// </summary>
	    public bool IsTransferTitle { get; set; }

	    /// <summary>
	    /// 模版文件名
	    /// </summary>
	    public string TemplateFilename { get; set; }

	    public MzhWebUIFrame()
	    {
	        TemplateFilename = "Normal.htm";
	    }

	    //private string _frameTemplate;
        /// <summary>
        /// 加载模版
        /// </summary>
        /// <returns></returns>
        public bool load()
        {
//            string strFileName = this.Page.Server.MapPath("Resource/Template/" + _templateFilename);
//            _frameTemplate = this.ReadTemplateFile(strFileName);
//            
//			if (_frameTemplate.Length > 0) 
//			{
//				this.ReplaceTemplateInfo();
//				return true;
//			}
//			else
//			{
//				return false;
//			}
			return true;
        }
        #endregion

		/// <summary>
		/// 菜单项实体类。
		/// </summary>
		/// <remarks>
		/// 用于菜单项数据的存储，以及输出页面上菜单项呈现的HTML代码，使用ToString()方法。
		/// 菜单项的HTML元素表示方式为超链接，分隔符采用Span元素。无效的菜单的输出为空字符。
		/// </remarks>
		protected class MenuInfo
		{
			#region Property

		    /// <summary>
		    /// 菜单项ID。
		    /// </summary>
		    public int ID { get; set; }

		    /// <summary>
		    /// 菜单项名称
		    /// </summary>
		    public string Name { get; set; }

		    /// <summary>
		    /// 菜单项的ToolTip。
		    /// </summary>
		    public string Title { get; set; }

		    /// <summary>
		    /// 菜单项所属的产品编号。
		    /// </summary>
		    public int ProductID { get; set; }

		    /// <summary>
		    /// 菜单项对应的权限编号。
		    /// </summary>
		    public int RightCode { get; set; }

		    /// <summary>
		    /// 上级菜单ID。
		    /// </summary>
		    public int ParentID { get; set; }

		    /// <summary>
		    /// 顺序号。
		    /// </summary>
		    public int Order { get; set; }

		    /// <summary>
		    /// 级别。
		    /// </summary>
		    public int Level { get; set; }

		    /// <summary>
		    /// URL连接类型。目前有三种：在Frame中显示、以弹出窗口方式显示、执行JS脚本。
		    /// </summary>
		    public int URLType { get; set; }

		    /// <summary>
			/// URL
			/// </summary>
			public string URL 
			{ 
				get 
				{
					if (this.Level ==1 )//一级菜单。
					{
					    if (_url.Trim()==string.Empty||_url=="#")//没有设置特定的url.
						{
							return string.Format("Default.aspx?Level1ID={0}&Title={1}",this.ID,System.Web.HttpUtility.UrlEncode(this.Title));
						}
					    else
					    {
                            if(this.URLType == 0)//在Frame中显示
					            return  string.Format("Default.aspx?Level1ID={0}&Title={1}&DefaultUrl={2}", this.ID, System.Web.HttpUtility.UrlEncode(this.Title), System.Web.HttpUtility.UrlEncode(_url));
					    }
					    return _url;
					}
                    var tempUrl = _url;

					if(!_url.ToUpper().Contains("TITLE=") && !string.IsNullOrEmpty(this.Title) && !string.IsNullOrEmpty(_url) && _url !="#" && this.Title.ToUpper()!="NONE")
					{
                        if (_url.Contains("?"))
                            tempUrl = _url + string.Format("&Title={0}", System.Web.HttpUtility.UrlEncode(this.Title));
                        else
                        {
                            tempUrl = _url + string.Format("?Title={0}", System.Web.HttpUtility.UrlEncode(this.Title));
                        }
					}

				    return tempUrl==string.Empty?"#":tempUrl;
				} 
				set { _url = value; } 
			}
			public string _url; 
			/// <summary>
			/// 目标窗体。
			/// </summary>
			public string Target
			{
				get
				{
				    return this.HasSubMenu == 1 ? "" : "mainFrame";
				}
			}

		    /// <summary>
		    /// 图片。
		    /// </summary>
		    public string Image { get; set; }

		    /// <summary>
			/// 样式。如果没有指定样式，则采用默认样式。
			/// </summary>
			public string CSSClass 
			{ 
				get
				{
				    if (_cssClass.Length > 0)
						return _cssClass;
				    if (this.Type == 1 && this.Level == 1)//如果是一级菜单的分割符
				    {
				        return "veticalSeparator";
				    }
				    if (this.Type == 1 && this.Level != 1)//如果是二、三级菜单的分隔符。
				    {
				        return "horizontalSeparator";
				    }
				    switch (this.Level)
				    {
				        case 1:
				            return "Level1Menu";
				        case 2:
				            return "Level2Menu";
				        case 3:
				            return "Level3Menu";
				        default:
				            return "Level3Menu";
				    }
				}
			    set { _cssClass = value; } 
			}
			private string _cssClass;

		    /// <summary>
		    /// 是否有效。
		    /// </summary>
		    public int IsEnable { get; set; }

		    /// <summary>
		    /// 是否有子菜单。
		    /// </summary>
		    public int HasSubMenu { get; set; }

		    /// <summary>
		    /// 菜单项类型。目前有两种：普通菜单项、分割符。
		    /// </summary>
		    public int Type { get; set; }

		    /// <summary>
		    /// 备注。
		    /// </summary>
		    public string Remark { get; set; }
            /// <summary>
            /// 检查对象编号(ID).
            /// </summary>
            public string CheckCode { get; set; }
            /// <summary>
            /// 检查对象类型。
            /// </summary>
            public string ObjType { get; set; }
            
		    #endregion

			#region Constructor
			public MenuInfo(){}
		
			public MenuInfo(object id, object strName, object strTitle, object productID, object rightCode, object parentID, object order, object level, object urlType, object strURL, object strImage, object strCSSClass, object isEnable, object hasSubMenu, object type, object strRemark, object checkCode, object objType)
			{
				ID = int.Parse(id.ToString());
				Name = strName.ToString();
				Title = strTitle.ToString();
				ProductID = int.Parse(productID.ToString());
				RightCode = int.Parse(rightCode.ToString());
				ParentID = int.Parse(parentID.ToString());
				Order = int.Parse(order.ToString());
				Level = int.Parse(level.ToString());
				URLType = int.Parse(urlType.ToString());
				_url = strURL.ToString();
				Image = strImage.ToString();
				_cssClass = strCSSClass.ToString();
				IsEnable = int.Parse(isEnable.ToString());
				HasSubMenu = int.Parse(hasSubMenu.ToString());
				Type = int.Parse(type.ToString());
				Remark = strRemark.ToString();
			    CheckCode = checkCode.ToString();
			    ObjType = objType.ToString();
			}
			#endregion

			#region public method
			/// <summary>
			/// 对于正常的菜单项输出一个超链接对象。 物料的菜单项则输出为空，分割符则输出一个带样式的span元素。
			/// </summary>
			/// <returns>菜单项在页面中显示的HTML字符串。</returns>
			public override string ToString()
			{
				if (this.IsEnable == 0) return string.Empty;//无效。
                if (this.Level == 1 && this.Type == 1) //一级菜单的分割符。
                    return string.Format("<span class=\"rootmenu_sep\">|</span>");
			    if (this.Level > 1 && this.Type == 1)//二三级菜单的分隔符。
			        return "<hr/>";

			    switch(this.URLType)
				{
					case 0://在Frame中显示
						return string.Format("<a href='{0}' target='{1}' title='{2}'>{3}</a>", this.URL, this.Target, this.Remark, this.Name);
					case 1://OpenWindow方式打开显示
						//return string.Format("<a id=menu{4}_{3} href='javascript:void(0);' onclick=\"popup(this.id,'{0}');\" title='{1}'>{2}</a>", this.URL, this.Title, this.Name,this.ID,this.Level);
				        return string.Format("<a href='{0}' target='_blank' title='{1}'>{2}</a>",this.URL, this.Remark, this.Name);
					case 2://执行JS脚本。
                        return string.Format("<a href=\"javascript:void(0);\" onclick=\"{0}\" title=\"{1}\">{2}</a>", this.URL, this.Remark, this.Name);
					default:
						return string.Format("<a href='{0}' target='{1}' title='{2}'>{3}</a>", this.URL, this.Target, this.Remark, this.Name);
				}
			}
			#endregion
		}

		/// <summary>
		/// 模板页类。
		/// </summary>
		protected class TemplatePage 
		{
			#region member
			private string templateContent;
            private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
			#endregion

			#region Property
            /// <summary>
            /// 页面的菜单列表。
            /// </summary>
		    public List<MenuInfo> MenuList;
		    /// <summary>
		    ///  一级菜单ID
		    /// </summary>
		    public int Level1MenuID { get; set; }
            /// <summary>
            /// 一级菜单。
            /// </summary>
            public MenuInfo Level1Menu { get; set; }
		    /// <summary>
		    /// 当前用户。
		    /// </summary>
		    public Shmzh.Components.SystemComponent.User CurrentUser { get; set; }
            /// <summary>
            /// 默认单位。
            /// </summary>
            public Shmzh.Components.SystemComponent.CompanyInfo DefaultCompany { get; set; }
		    #endregion

			#region private method
			/// <summary>
			/// 读取模板页。
			/// </summary>
			/// <param name="strTemplateFilename">模板文件名(不带路径)。</param>
			/// <returns>模板内容字符串。</returns>
			/// <remarks>该模板所处的位置是固定的，Resource/Template/下。</remarks>
			private string ReadTemplateFile(string strTemplateFilename)
			{
				var sr = new StreamReader(strTemplateFilename); 
				var strBuffer = sr.ReadToEnd(); 
				sr.Close();
				return strBuffer;
			}
			/// <summary>
			/// 根据产品ID获取一级菜单列表，同时确定当前的一级菜单ID。
			/// </summary>
			/// <param name="productId">产品Id。</param>
			/// <returns>类型：ArrayList。
			/// 产品的一级菜单列表。</returns>
			private List<MenuInfo> GetTopMenuByProductId(int productId)
			{
				var menuList = new List<MenuInfo>();
			    var myDA = DataProvider.MenuProvider;
				var ds = myDA.GetAllAvalibleMenuByParentId(0);//获取所有的一级科目。
				if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
				{
					foreach(DataRow oRow in ds.Tables[0].Rows)
					{
					    if (oRow["fCheckCode"] == DBNull.Value || oRow["fObjType"] == DBNull.Value)
					    {
					        if (this.CurrentUser.HasRight(int.Parse(oRow["fRightCode"].ToString())))
					        {
					            if (int.Parse(oRow["fProductID"].ToString()) == productId)
					            {
					                var oMenuInfo = new MenuInfo(oRow["fID"], oRow["fName"], oRow["fTitle"], oRow["fProductID"],
					                                             oRow["fRightCode"], oRow["fParentID"], oRow["fOrder"], oRow["fLevel"],
					                                             oRow["fURLType"], oRow["fURL"], oRow["fImage"], oRow["fCSSClass"],
					                                             oRow["fIsEnable"], oRow["fHasSubMenu"], oRow["fType"], oRow["fRemark"], oRow["fCheckCode"], oRow["fObjType"]);
					                menuList.Add(oMenuInfo);
					            }
					        }
					    }
					    else
					    {
					        if(this.CurrentUser.HasRight(int.Parse(oRow["fRightCode"].ToString()), oRow["fCheckCode"].ToString(), oRow["fObjType"].ToString()) &&
					            int.Parse(oRow["fProductID"].ToString()) == productId)
					        {
                                var oMenuInfo = new MenuInfo(oRow["fID"], oRow["fName"], oRow["fTitle"], oRow["fProductID"],
                                                                 oRow["fRightCode"], oRow["fParentID"], oRow["fOrder"], oRow["fLevel"],
                                                                 oRow["fURLType"], oRow["fURL"], oRow["fImage"], oRow["fCSSClass"],
                                                                 oRow["fIsEnable"], oRow["fHasSubMenu"], oRow["fType"], oRow["fRemark"], oRow["fCheckCode"], oRow["fObjType"]);
                                menuList.Add(oMenuInfo);
					        }
					    }
				    }
				}
				
				return menuList;
			}
			/// <summary>
			/// 根据上一级菜单ID获取子菜单列表。
			/// </summary>
			/// <param name="parentId">上一级菜单ID。</param>
			/// <returns>类型：ArrayList。
			/// 子菜单列表。</returns>
			private List<MenuInfo> GetChildMenuByParentId(int parentId)
			{
				var menuList = new List<MenuInfo>();
                var ds = DataProvider.MenuProvider.GetAllAvalibleMenuByParentId(parentId);
				if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
				{
					foreach(DataRow oRow in ds.Tables[0].Rows)
					{
                        if (oRow["fCheckCode"] == DBNull.Value || oRow["fObjType"] == DBNull.Value)
                        {
                            if (this.CurrentUser.HasRight(int.Parse(oRow["fRightCode"].ToString())))
                            {
                                var oMenuInfo = new MenuInfo(oRow["fID"], oRow["fName"], oRow["fTitle"], oRow["fProductID"], oRow["fRightCode"], oRow["fParentID"], oRow["fOrder"], oRow["fLevel"], oRow["fURLType"], oRow["fURL"], oRow["fImage"], oRow["fCSSClass"], oRow["fIsEnable"], oRow["fHasSubMenu"], oRow["fType"], oRow["fRemark"], oRow["fCheckCode"], oRow["fObjType"]);
                                menuList.Add(oMenuInfo);
                            }
                        }
						else
                        {
                            if (this.CurrentUser.HasRight(int.Parse(oRow["fRightCode"].ToString()), oRow["fCheckCode"].ToString(), oRow["fObjType"].ToString()) )
                            {
                                var oMenuInfo = new MenuInfo(oRow["fID"], oRow["fName"], oRow["fTitle"], oRow["fProductID"],
                                                                 oRow["fRightCode"], oRow["fParentID"], oRow["fOrder"], oRow["fLevel"],
                                                                 oRow["fURLType"], oRow["fURL"], oRow["fImage"], oRow["fCSSClass"],
                                                                 oRow["fIsEnable"], oRow["fHasSubMenu"], oRow["fType"], oRow["fRemark"], oRow["fCheckCode"], oRow["fObjType"]);
                                menuList.Add(oMenuInfo);
                            }
                        }
					}
				}
				return menuList;
			}
            /// <summary>
            /// 根据产品Id获取所有有效的菜单项。
            /// </summary>
            /// <param name="productId">产品Id。</param>
            private void GetAllAvalibleByProductId(int productId)
            {
                this.MenuList = new List<MenuInfo>();
                var objs = DataProvider.MenuProvider.GetAllAvalibleByProductCode(productId);//获取所有有效的科目的一级科目。
                
                foreach (var obj in objs)
                {
                    if (string.IsNullOrEmpty(obj.CheckCode) || string.IsNullOrEmpty(obj.ObjType))
                    {
                        if (this.CurrentUser.HasRight(obj.RightCode))
                        {
                            var oMenuInfo = new MenuInfo(obj.ID, obj.Name, obj.Title, obj.ParentID,
                                                         obj.RightCode, obj.ParentID, obj.Order, obj.Level,
                                                         obj.URLType, obj.URL, obj.ImageURL, obj.CSSClass,
                                                         obj.IsEnable, obj.HasSubMenu, obj.Type, obj.Remark,
                                                         obj.CheckCode, obj.ObjType);
                            this.MenuList.Add(oMenuInfo);
                            
                        }
                    }
                    else
                    {
                        if (this.CurrentUser.HasRight(obj.RightCode, obj.CheckCode, obj.ObjType) && obj.ProductID == productId)
                        {
                            var oMenuInfo = new MenuInfo(obj.ID, obj.Name, obj.Title, obj.ParentID,
                                                         obj.RightCode, obj.ParentID, obj.Order, obj.Level,
                                                         obj.URLType, obj.URL, obj.ImageURL, obj.CSSClass,
                                                         obj.IsEnable, obj.HasSubMenu, obj.Type, obj.Remark,
                                                         obj.CheckCode, obj.ObjType);
                            this.MenuList.Add(oMenuInfo);
                        }
                    }
                }
                
            }
            /// <summary>
            /// 获取默认企业信息。
            /// </summary>
            /// <returns></returns>
            private string GetDefaultCompanyInfo()
            {
                return this.DefaultCompany == null ? "上海名之赫科技有限公司" : this.DefaultCompany.CoName;
            }
            /// <summary>
            /// 获取公司的英文名称.
            /// </summary>
            /// <returns>公司的英文名称.</returns>
            private string GetDefaultCompanyEnName()
            {
                return this.DefaultCompany == null ? "Shmzh" : this.DefaultCompany.CoEnName;
            }
            /// <summary>
            /// 获取产品
            /// </summary>
            /// <param name="productCode"></param>
            /// <returns>产品名称。</returns>
            private string GetProductName(short productCode)
            {
                var productInfo = DataProvider.ProductProvider.GetByCode(productCode);
                return productInfo == null ? string.Empty : productInfo.ProductName;
            }
		    #endregion 

			#region Constructor
			/// <summary>
			/// 构造函数。
			/// </summary>
            /// <param name="templateCode">模板代码。</param>
			public TemplatePage(string templateCode)
			{
                this.templateContent = this.ReadTemplateFile(templateCode);
			    //var obj = DataProvider.CreateTemplateProvider().GetByCode(templateCode);
			    //this.templateContent = obj.Content;
			}
			#endregion

			#region Parse Method
			/// <summary>
			/// 解析Logo信息。
			/// </summary>
			/// <returns>对Logo块进行解析后的模板页</returns>
			public TemplatePage ParseLogo()
			{
				this.templateContent = this.templateContent.Replace("{$LogoInfo}", "<img src=\"Images/Logo.png\" />");
				return this;
			}
            /// <summary>
            /// 解析Logo信息。
            /// </summary>
            /// <param name="LogoURL">Logo的超链接。</param>
            /// <param name="LogoImageUrl">Logo图片的地址。</param>
            /// <param name="LogoTitle">Logo图片的Tooltip提示.</param>
            /// <returns>对Logo块进行解析后的模板页</returns>
            public TemplatePage ParseLogo(string LogoURL,string LogoImageUrl,string LogoTitle)
            {
                this.templateContent = this.templateContent.Replace("{$LogoInfo}", string.Format("<a href='{0}' title='" + LogoTitle + "'><img src='{1}'/></a>", LogoURL, LogoImageUrl));
                return this;
            }
            /// <summary>
            /// 解析产品系统名称。
            /// </summary>
            /// <param name="productCode">产品编号。</param>
            /// <returns></returns>
            public TemplatePage ParseProductName(short productCode)
            {
                this.templateContent = this.templateContent.Replace("{$ProductName}", this.GetProductName(productCode));
                return this;
            }

		    /// <summary>
			/// 解析产品信息。
			/// </summary>
			/// <returns>对产品信息块进行解析后的模板页</returns>
			public TemplatePage ParseProd()
			{
				this.templateContent = this.templateContent.Replace("{$ProductInfo}", "<img src=\"Images/Product.gif\" />");
				return this;
			}
            /// <summary>
            /// 解析页面标题。
            /// </summary>
            /// <param name="productCode">产品编号。</param>
            /// <returns>解析过title后的页面内容。</returns>
            public TemplatePage ParseTitle(short productCode)
            {
                this.templateContent = this.templateContent.Replace("{$Title}", this.GetProductName(productCode));
                return this;
            }
			/// <summary>
			/// 解析用户的信息。
			/// </summary>
			/// <param name="name"></param>
			/// <param name="url"></param>
			/// <returns>对用户信息块进行解析后的模板页</returns>
			public TemplatePage ParseUser(string name,string url)
			{
                //TODO: Change Language
                this.templateContent = this.templateContent.Replace("{$UserInfo}", string.Format("<span id='logoff'><a href='/SystemManagementWeb/Login/LogOff.aspx?ReturnURL={1}'>Sign Out</a></span><span id='pwd'><a id='linkChangePWD' onclick='showChangePWD(this.id);' href='javascript:void(0);' >Password</a></span><span id='welcome'>Hi,<a id='' href='javascript:void(0);' onclick='showMe(this.id);'>{0}</a></span>", name, url));
                //this.templateContent = this.templateContent.Replace("{$UserInfo}", string.Format("<span id='logoff'><a href='/SystemManagementWeb/Login/LogOff.aspx?ReturnURL={1}'>注销</a></span><span id='pwd'><a id='linkChangePWD' onclick='showChangePWD(this.id);' href='javascript:void(0);' >修改密码</a></span><span id='welcome'>欢迎,<a id='' href='javascript:void(0);' onclick='showMe(this.id);'>{0}</a></span>", name, url));
            
                return this;
			}

            public TemplatePage ParseUserName(string name)
            {
                this.templateContent = this.templateContent.Replace("{$UserName}", name);
                return this;
            }
            public TemplatePage ParseReturnUrl(string url)
            {
                this.templateContent = this.templateContent.Replace("{$ReturnUrl}", url);
                return this;
            }
			/// <summary>
			/// 解析版权信息。
			/// </summary>
			/// <returns></returns>
			public TemplatePage ParseCopyRight()
			{
			    this.templateContent = this.templateContent.Replace("{$copyright}", "©");
				return this;
			}
            /// <summary>
            /// 解析公司信息。
            /// </summary>
            /// <returns></returns>
            public TemplatePage ParseCompany()
            {

                this.templateContent = this.templateContent.Replace("{$Company}", this.GetDefaultCompanyInfo());
                this.templateContent = this.templateContent.Replace("{$CompanyEnName}", this.GetDefaultCompanyEnName());
                return this;
            }
            /// <summary>
            /// 解析帮助文件的Url路径。
            /// </summary>
            /// <param name="helpUrl">帮助文件的Url路径。</param>
            /// <returns></returns>
            public TemplatePage ParseHelpUrl(string helpUrl)
            {
                this.templateContent = this.templateContent.Replace("{$HelpUrl}", helpUrl);
                return this;
            }
            public TemplatePage ParseLicense(string license)
            {
                if(string.IsNullOrEmpty(license))
                {
                    this.templateContent = this.templateContent.Replace("{$License}", "");
                    return this;
                }
                var a = new Authorization(license, this.DefaultCompany);
                         
                if(a.LicenseStatus == 2)
                {

                    this.templateContent = this.templateContent.Replace("{$License}", string.Format("试用版 - 剩余{0}天试用",a.LeftTrailDays));
                }
                else
                {
                    this.templateContent = this.templateContent.Replace("{$License}", "");
                }
                
                return this;
            }
		    /// <summary>
			/// 更新默认页。
			/// </summary>
			/// <param name="productId">产品ID。</param>
			/// <param name="defaultPageUrl">默认打开页面。</param>
			/// <returns></returns>
			public TemplatePage ParseDefaultPage(int productId, string defaultPageUrl)
			{
                if(string.IsNullOrEmpty(defaultPageUrl))
                {
                    if(this.Level1MenuID != 0)
                    {
                        var obj = this.MenuList.Find(item => item.ID == this.Level1MenuID);
                        //Logger.Info(obj._url);
                        if(obj._url.Length>1)//一级菜单的url长度大于1.
                        {
                            this.templateContent = this.templateContent.Replace("{$DefaultPage}", obj._url);
                            return this;
                        }
                        else
                        {
                            var menuList = this.MenuList.FindAll(item => item.ParentID == this.Level1MenuID);

                            for (var i = 0; i < menuList.Count; i++)
                            {
                                var firstLevel2Menu = menuList[i];
                                var level3MenuList = this.MenuList.FindAll(item => item.ParentID == firstLevel2Menu.ID);
                                if (level3MenuList.Count > 0)
                                {
                                    //TODO:Url
                                    this.templateContent = this.templateContent.Replace("{$DefaultPage}", (level3MenuList[0] as MenuInfo).URL);
                                    return this;
                                }
                            }
                        }
                        
                        this.templateContent = this.templateContent.Replace("{$DefaultPage}", string.Empty);
                        return this;
                    }
                    else//一级菜单ID为0(没有指定一级菜单，则按照顺序来确定一级菜单)
                    {
                        var menuList = this.MenuList.FindAll(item => item.ParentID == 0);
                        menuList.Sort((a,b)=>a.Order.CompareTo(b.Order));
                        
                        if(menuList.Count > 0)
                        {
                            //Logger.Info(menuList[0]._url);
                            if (menuList[0]._url.Length > 1)
                            {
                                this.templateContent = this.templateContent.Replace("{$DefaultPage}", menuList[0].URL);
                                return this;
                            }
                            else
                            {
                                var level2MenuList = this.MenuList.FindAll(item=>item.ParentID == menuList[0].ID);
                                level2MenuList.Sort((a,b)=>a.Order.CompareTo(b.Order));
                                for(var i=0; i< level2MenuList.Count;i++)
                                {
                                    var firstLevel2Menu = level2MenuList[i];
                                    var level3MenuList = this.MenuList.FindAll(item => item.ParentID == firstLevel2Menu.ID);
                                    if (level3MenuList.Count > 0)
                                    {
                                        this.templateContent = this.templateContent.Replace("{$DefaultPage}", (level3MenuList[0]).URL);
                                        return this;
                                    }
                                }
                            }
                        }
                        this.templateContent = this.templateContent.Replace("{$DefaultPage}", string.Empty);
                        return this;
                    }
                }
                else
                {
                    this.templateContent = this.templateContent.Replace("{$DefaultPage}", defaultPageUrl);
                }
                return this;
			}
			/// <summary>
			/// 解析一级菜单。
			/// </summary>
			/// <returns>对一级目录块进行解析后的模板页。</returns>
			public TemplatePage ParseRootMenu(int productId)
			{
				//var menuList = this.GetTopMenuByProductId(productId);
                this.GetAllAvalibleByProductId(productId);
			    var level1Menus = this.MenuList.FindAll(item => item.ParentID == 0);//获取所有的一级菜单。
                level1Menus.Sort((a,b)=>a.Order.CompareTo(b.Order));
				if (this.Level1MenuID == 0 && level1Menus.Count > 0)//外部没有指定了第一级目录ID。(通常是通过URL参数)
				{
				    this.Level1Menu = (level1Menus)[0];
					this.Level1MenuID = this.Level1Menu.ID;//以列表中第一项作为当前的一级菜单。
                    
				}
				this.templateContent = this.templateContent.Replace("{$RootMenu}",EncodeRootMenu(level1Menus));
				return this;
			}
			/// <summary>
			/// 解析二、三级菜单。
			/// </summary>
			/// <returns>对二三级目录块进行解析后的模板页。</returns>
			public TemplatePage ParseSubMenu()
			{
				if (this.Level1MenuID == 0)//如果一级菜单ID为0，则不展示下级菜单。
					this.templateContent = this.templateContent.Replace("{$ChildMenu}","");
				else
				{
				    //var menuList = this.GetChildMenuByParentId(this.Level1MenuID);
				    var menuList = this.MenuList.FindAll(item => item.ParentID == this.Level1MenuID);
                    menuList.Sort((a,b)=>a.Order.CompareTo(b.Order));
                    if(menuList.Count > 0)
                    {
                        this.templateContent = this.templateContent.Replace("{$ChildMenu}",this.EncodeLevel2Menu(menuList));
                    }
                    else
                    {
                        this.templateContent = this.templateContent.Replace("{$ChildMenu}","");
                    }
				}
			    return this;
			}
			#endregion

			#region encode method
			/// <summary>
			/// 一级菜单列表的编码。
			/// </summary>
            /// <param name="menuList">一级菜单列表。</param>
			/// <returns>经过编码后的字符串。</returns>
			protected string EncodeRootMenu(List<MenuInfo> menuList)
			{
				var i=0;
				var strHtmlCode = string.Empty;
				if (menuList != null)
				{
					foreach (var objMenuInfo in menuList)
					{
						strHtmlCode += this.WrapLevel1MenuItem(i, objMenuInfo)+"\r\n";
						i++;
					}
				}
				return strHtmlCode;
			}

			/// <summary>
			/// 对子菜单项进行编码。
			/// </summary>
            /// <param name="menuList">子菜单列表。</param>
			/// <returns>编码后的子菜单列表字符串。</returns>
			protected string EncodeLevel2Menu(List<MenuInfo> menuList)
			{
				var strHtmlCode = "";
				foreach(MenuInfo oMenuInfo in menuList)
				{
				    var level3MenuString = this.EncodeLevel3Menu(oMenuInfo.ID);
                    if(!string.IsNullOrEmpty(level3MenuString))
					    strHtmlCode += string.Format("<li class='drawer'>\r\n<h4 class='drawer-handle'>{0}</h4>\r\n<ul>\r\n{1}</ul>\r\n</li>\r\n ",oMenuInfo,this.EncodeLevel3Menu(oMenuInfo.ID));
				}
				return strHtmlCode;
			}
			/// <summary>
			/// 对二级菜单下属的三级菜单列表进行html包装。
			/// </summary>
            /// <param name="level2MenuId"></param>
			/// <returns></returns>
			protected string EncodeLevel3Menu(int level2MenuId)
			{
				var strHtmlCode = "";
				//var menuList = this.GetChildMenuByParentId(level2MenuId);
			    var menuList = this.MenuList.FindAll(item => item.ParentID == level2MenuId);

				foreach(var oMenuInfo in menuList)
				{
					strHtmlCode += string.Format("<li>{0}</li>\r\n",oMenuInfo);
				}
				return strHtmlCode;
			}

			/// <summary>
			/// 包装一级菜单项。
			/// </summary>
			/// <param name="id">一级菜单ID</param>
			/// <param name="objMenuInfo">菜单对象</param>
			/// <returns>一个一级菜单的编码后的代码。</returns>
			protected string WrapLevel1MenuItem(int id, MenuInfo objMenuInfo)
			{
				return string.Format("<div id=\"{0}\" class=\"{1}\">{2}</div>", id, objMenuInfo.CSSClass, objMenuInfo);
			}
			/// <summary>
			/// 包装二级菜单项。
			/// </summary>
			/// <param name="id"></param>
			/// <param name="objMenuInfo"></param>
			/// <returns></returns>
			protected string WrapLevel2MenuItem(int id, MenuInfo objMenuInfo)
			{
				return string.Format("<div id=\"{0}\" class=\"{1}\">{2}</div>", id, objMenuInfo.CSSClass, objMenuInfo);
			}
			/// <summary>
			/// 包装三级菜单项。
			/// </summary>
			/// <param name="id"></param>
			/// <param name="objMenuInfo"></param>
			/// <returns></returns>
			protected string WrapLevel3MenuItem(int id, MenuInfo objMenuInfo)
			{
				return string.Format("<div id=\"{0}\" class=\"{1}\"><li>{2}</li></div>", id, objMenuInfo.CSSClass, objMenuInfo);
			}
			/// <summary>
			/// 对span对象进行编码。
			/// </summary>
			/// <param name="id"></param>
			/// <param name="cssClassName"></param>
			/// <param name="content"></param>
			/// <returns></returns>
			protected string EncodeHtml_Span(string id, string cssClassName, string content)
			{
				return string.Format("<span id=\"{0}\" class=\"{1}\">{2}</span>", id, cssClassName, content);
			}
			#endregion
		
			public override string ToString()
			{
				return this.templateContent;
			}
		}
		/// <summary> 
		/// 将此控件呈现给指定的输出参数。
		/// </summary>
		/// <param name="output"> 要写出到的 HTML 编写器 </param>
		protected override void Render(HtmlTextWriter output)
		{
            string templatePath;

            if (ConfigurationManager.AppSettings["IsUsingCommonTemplate"].ToUpper() == "TRUE")
            {
                templatePath = this.Page.Server.MapPath(string.Format("/aspnet_client/Shmzh.Web.UI/Resource/template/{0}", this.TemplateFilename));
            }
            else
            {
                templatePath = string.Format("{0}Resource/Template/{1}", AppDomain.CurrentDomain.BaseDirectory, this.TemplateFilename);
            }
		    //string templateCode = ConfigurationManager.AppSettings["TemplateCode"];
            
            //var myPage = new TemplatePage(templateCode){CurrentUser = this.CurrentUser};
            var myPage = new TemplatePage(templatePath) { CurrentUser = this.CurrentUser };
            if (!string.IsNullOrEmpty(this.Page.Request.QueryString["Level1ID"]) )
			{
				myPage.Level1MenuID = int.Parse(this.Page.Request.QueryString["Level1ID"]);
			    
			    
			}
            if(!string.IsNullOrEmpty(this.Page.Request.QueryString["DefaultUrl"]))
            {
                this.DefaultPage = this.Page.Request.QueryString["DefaultUrl"];
            }

		    myPage.DefaultCompany = this.Page.Session["DefaultCompany"] as CompanyInfo;

            myPage.ParseLogo(this.LogoUrl, this.LogoImageUrl, this.LogoTitle);
			myPage.ParseProd();
		    myPage.ParseProductName(this.ProductID);
		    myPage.ParseTitle(this.ProductID);
		    myPage.ParseUserName(this.DisplayName);

			myPage.ParseUser(this.DisplayName, this.Page.Server.UrlEncode(Page.Request.Url.ToString()));
		    myPage.ParseReturnUrl(this.Page.Server.UrlEncode(Page.Request.Url.ToString()));
			myPage.ParseCopyRight();
		    myPage.ParseCompany();
		    var license = this.Page.Session["License"].ToString();
		    myPage.ParseLicense(license);

		    var helpUrl = ConfigurationManager.AppSettings["HelpUrl"];
            if (string.IsNullOrEmpty(helpUrl))
                helpUrl = "#";
		    myPage.ParseHelpUrl(helpUrl);

            myPage.ParseRootMenu(this.ProductID);
			myPage.ParseSubMenu();

            myPage.ParseDefaultPage(this.ProductID, this.DefaultPage);

			output.Write(myPage.ToString());
		}
	}
}
