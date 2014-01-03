/////////////////////////////////////////////////////////////////////////////
/// ��֮�������
/// ��ѡDataGrid
/// 
/// �Ϻ���֮�տƼ����޹�˾��Ȩ����
/// ���ߣ�����
////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Shmzh.Web.UI.Controls
{
    /// <summary>
    /// ��֮�ն�ѡDataGrid�����
    /// </summary>
    [ToolboxData("<{0}:MzhDataGrid runat=server></{0}:MzhDataGrid>")]
    [ToolboxBitmap(typeof(MzhDataGrid), "Shmzh.Web.UI.MzhDataGrid.bmp")]
    [ParseChildren(true)]
    public class MzhDataGrid : DataGrid
    {
        #region Enum
        /// <summary>
        /// ѡ������ö�١�
        /// </summary>
        public enum SelectMode { None, SingleSelect, MultiSelect };
        /// <summary>
        /// ��ҳ��ʾģʽ��
        /// </summary>
        /// <remarks>
        /// None������ʾ��
        /// DropListMode�������б�ģʽ��
        /// JumpMode:��תģʽ��
        /// </remarks>
        public enum PagerShowMode { None, DropListMode, JumpMode };
        #endregion

        #region Event
        [Category("Action"),Description("�ڸ�������Դ��ÿҳ��Ҫ��ʾ�������Ŀʱ������")]
        public event EventHandler PageSizeChanged;
        #endregion

        #region Const String
        /// <summary>
        /// DataGrid����Table��ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID = "datagrid";
        /// <summary>
        /// DataGrid�ı����е�ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_HD_ROW = "m-grid-hd-row";
        /// <summary>
        /// DataGrid�������е�ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_ROW = "m-grid-row";
        /// <summary>
        /// DataGrid�Ľ����е�ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_ROW_ALT = "m-grid-row-alt";
        /// <summary>
        /// DataGrid��ҳ���е�ȱʡ��css��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_FT_ROW = "m-grid-ft-row";
        /// <summary>
        /// DataGrid�ķ�ҳ�е�ȱʡ��css��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_PAGER = "m-grid-page-row";
        /// <summary>
        /// DataGrid���������������ʱ��ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_ROW_OVER = "m-grid-row-over";
        /// <summary>
        /// DataGrid��������ѡ��ʱ��ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_ROW_SELECTED = "m-grid-row-selected";
        /// <summary>
        /// DataGrid��ҳ����������ȱʡcss��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_PAGER_INPUT_PAGE = "m-grid-pager-input-page";
        /// <summary>
        /// DataGrid��ҳ���ȱʡ��css��ʽ����
        /// </summary>
        private static readonly string MZH_GRID_PAGER_BUTTON_JUMP = "m-grid-pager-button-jump";
        /// <summary>
        /// String.js
        /// </summary>
        private static readonly string MZHSTRING_SCRIPT_ID = "MzhWeb_String_Script_1.00";
        private static readonly string MZHSTRING_SCRIPT = string.Format("<script src=\"{0}string.js\"></script>", ResourceRoot.URL);
        /// <summary>
        /// Array.js
        /// </summary>
        private static readonly string MZHARRAY_SCRIPT_ID = "MzhWeb_Array_Script_1.00";
        private static readonly string MZHARRAY_SCRIPT = string.Format("<script src=\"{0}array.js\"></script>", ResourceRoot.URL);
        /// <summary>
        /// CSS.js
        /// </summary>
        private const string MZHCSS_SCRIPT_ID = "MzhWeb_CSS_Script_1.00";
        private readonly string MZHCSS_SCRIPT = string.Format("<script src=\"{0}css.js\"></script>", ResourceRoot.URL);
        /// <summary>
        /// DataGrid.js
        /// </summary>
        private const string MZHDATAGRID_SCRIPT_ID = "MzhWeb_MzhDataGrid_Script_1.00";
        private readonly string MZHDATAGRID_SCRIPT = string.Format("<script src=\"{0}DataGrid.js\"></script>", ResourceRoot.URL);
        #endregion

        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ��ŵ�ǰѡ����(����)ID��
        /// </summary>
        protected HtmlInputHidden tbSelectedID;
        /// <summary>
        /// ��ŵ�ǰѡ����(����)��ID����ID1,ID2,ID3����
        /// </summary>
        protected HtmlInputHidden tbSelectedArray;
        /// <summary>
        /// ��ŵ�ǰѡ����(����)��ID��('ID1','ID2','ID3')��
        /// </summary>
        protected HtmlInputHidden tbSelectedStream;
        /// <summary>
        /// ��ǰѡ��ģʽ�Ƿ��Ƕ�ѡģʽ��
        /// </summary>
        private string _isMultiSelect;
        /// <summary>
        /// PageSize�ļ����
        /// </summary>
        private int pageSelectorPageSizeInterval = 10;
        /// <summary>
        /// DataBindί�����͡�
        /// </summary>
        public delegate void DataBindDelegate();
        /// <summary>
        /// DataBindDelegate����
        /// </summary>
        /// <remarks>��ָ����AutoDataBind����Ӧ�����ݰ󶨷�����
        /// ����û���pageIndexchanged�¼���pageSizeChanged�¼���onSortingCommand�¼���û��ʵ�ִ���ʱ���Զ����õ����ݰ󶨷�����
        /// </remarks>
        public MzhDataGrid.DataBindDelegate AutoDataBind;
        /// <summary>
        /// �Ƿ��Ѿ�ִ��DataBind������
        /// </summary>
        private bool IsDoneDataBind = false;
        #endregion

        #region �Զ�������
        /// <summary>
        /// ָ��DataGrid�Ƿ���Ҫ��ѡ���ѡ.
        /// </summary>
        [Category("ѡ��ģʽ"), DescriptionAttribute("ָ��DataGrid�Ƿ���Ҫ��ѡ���ѡ��"), PersistenceMode(PersistenceMode.InnerProperty),]
        public SelectMode SelectType
        {
            get
            {
                return ViewState["SelectMode"] == null ? SelectMode.None : (SelectMode)ViewState["SelectMode"];
            }
            set
            {
                this.ViewState["SelectMode"] = value;
                this._isMultiSelect = value == SelectMode.MultiSelect ? "1" : "0";
            }
        }
        /// <summary>
        /// ָ���ڼ�����ΪID��.
        /// </summary>
        [Category("ѡ��ģʽ"), DescriptionAttribute("ָ���ڼ�����ΪID�С�")]
        public int IdCell
        {
            get { return ViewState["IdCell"] == null ? 0 : (int)ViewState["IdCell"]; }
            set { ViewState["IdCell"] = value; }
        }
        /// <summary>
        /// ������ʾ����ʽ.
        /// </summary>
        [Category("Appearance"), DescriptionAttribute("��꾭��DataGridʱ,�е���ʽ")]
        public string HignLightCSS
        {
            get
            {
                return this.ViewState["HIGHLIGHTCSS"] == null ? string.Empty : this.ViewState["HIGHLIGHTCSS"].ToString();
            }
            set
            {
                this.ViewState["HIGHLIGHTCSS"] = value;
            }
        }
        /// <summary>
        /// ѡ���е���ʽ.
        /// </summary>
        [Category("Appearance"), DescriptionAttribute("ѡ���е���ʽ��")]
        public string SelectedCSS
        {
            get
            {
                return this.ViewState["SELECTEDCSS"] == null ? string.Empty : this.ViewState["SELECTEDCSS"].ToString();
            }
            set
            {
                this.ViewState["SELECTEDCSS"] = value;
            }
        }
        /// <summary>
        /// ��ǰѡ���е�ID.
        /// </summary>
        [Category("ѡ��ģʽ"), DescriptionAttribute("��ǰѡ���е�ID��")]
        public string SelectedID
        {
            get
            {
                return tbSelectedID.Value;
            }
        }
        /// <summary>
        /// ��ѡID�б�,�Զ��ŷָ�.����ѡʱ��Ч.
        /// </summary>
        [Category("ѡ��ģʽ"), DescriptionAttribute("��ѡID�б��Զ��ŷָ�������ѡʱ��Ч��")]
        public string SelectedArray
        {
            get
            {
                return tbSelectedArray.Value;
            }
        }
        /// <summary>
        /// ��ѡID���(������),�Զ��ŷָ�.����ѡʱ��Ч.
        /// </summary>
        [Category("ѡ��ģʽ"), DescriptionAttribute("��ѡID�б������ţ����Զ��ŷָ�������ѡʱ��Ч��")]
        public string SelectedStream
        {
            get
            {
                return tbSelectedStream.Value;
            }
        }
        /// <summary>
        /// �ܼ�¼��.
        /// </summary>
        [Category("Paging"), DescriptionAttribute("��¼���β�ѯ�����м�¼��")]
        private int RecordsCount
        {
            get
            {
                if (this.ViewState["RecordsCount"] == null)
                {
                    this.ViewState["RecordsCount"] = (this.DataSource is ICollection)
                                                       ? (this.DataSource as ICollection).Count
                                                       : 0;
                }
                return (int)this.ViewState["RecordsCount"];
            }
            set { this.ViewState["RecordsCount"] = value; }

        }
        /// <summary>
        /// ��ҳ��ʾģʽ
        /// </summary>
        [Category("Paging"), DescriptionAttribute("��ҳ��ʾģʽ")]
        public PagerShowMode MultiPageShowMode
        {
            get { return ViewState["PagerShowMode"] == null ? PagerShowMode.None : (PagerShowMode)ViewState["PagerShowMode"]; }
            set { ViewState["PagerShowMode"] = value; }
        }
        /// <summary>
        /// �Ƿ���ʾ��¼��
        /// </summary>
        [Category("Paging"), DescriptionAttribute("�Ƿ���ʾ��¼���������ʾ������Ҫ��Ϊ����ÿ�β�ѯ�����øü�¼����")]
        [Obsolete("�����������ϣ�����ShowRecordsCount��", false)]
        public bool IsShowTotalRecorderCount
        {
            get
            {
                var o = ViewState["IsShowTotalRecorderCount"];
                return o == null ? true : (bool)o;
            }
            set
            {
                ViewState["IsShowTotalRecorderCount"] = value;
            }
        }
        [Category("Paging"), DescriptionAttribute("�Ƿ���ʾ��¼����"), DefaultValue("true"),]
        public bool ShowRecordsCount
        {
            get
            {
                var o = ViewState["ShowRecordsCount"];
                return o == null ? true : (bool)o;
            }
            set
            {
                ViewState["ShowRecordsCount"] = value;
            }
        }
        /// <summary>
        /// ��תҳ���������ʽ��
        /// </summary>
        [Category("Paging"), DescriptionAttribute("��תҳ���������ʽ��")]
        public string CSSClassForPagerInputPage
        {
            get
            {
                return MZH_GRID_PAGER_INPUT_PAGE;
            }
        }
        /// <summary>
        /// ��ת��ť��ʽ��
        /// </summary>
        [Category("Paging"), DescriptionAttribute("��ת��ť��ʽ��")]
        public string CSSClassForPagerButtonJump
        {
            get
            {
                return MZH_GRID_PAGER_BUTTON_JUMP;
            }
        }
        /// <summary>
        /// Get or Set whether an empty grid should be shown instead of the EmptyDataTemplate.
        /// </summary>
        [Category("Misc"), Description("�Ƿ���EmptyDataTemplateģ���������滻��������ʾ��"), DefaultValue("false"),]
        public bool ShowGridOnEmptyData
        {
            get
            {
                var o = ViewState["ShowGridOnEmptyData"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["ShowGridOnEmptyData"] = value;
            }
        }
        /// <summary>
        /// �Ƿ���ʾҳ���¼�������б�
        /// </summary>
        public bool ShowPageSize
        {
            get
            {
                var o = ViewState["ShowPageSize"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["ShowPageSize"] = value;
            }
        }
        /// <summary>
        /// ������ʽ��
        /// </summary>
        public string SORTEXPRESSION
        {
            get
            {
                return this.ViewState["SORTEXPRESSION"] == null
                           ? string.Empty
                           : this.ViewState["SORTEXPRESSION"].ToString();
            }
            set { this.ViewState["SORTEXPRESSION"] = value; }
        }
        /// <summary>
        /// ����ʱ�Ƿ񴥷���֤
        /// </summary>
        [Category("Paging"), Description("����ʱ�Ƿ񴥷���֤"), DefaultValue("false"),]
        public bool CauseValidationWhenPaging
        {
            get
            {
                var o = ViewState["CauseValidationWhenPaging"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["CauseValidationWhenPaging"] = value;
            }
        }
        #region ClientEvent
        /// <summary>
        /// �ڿͻ���onclick��ִ�еĿͻ��˽ű���
        /// </summary>
        [DefaultValue(""), Themeable(false), Category("Client Behavior"), Description("�ڿͻ���onclick��ִ�еĿͻ��˽ű���"),]
        public virtual string OnClientClick
        {
            get
            {
                var s = (string)ViewState["OnClientClick"];
                return s ?? String.Empty;
            }
            set
            {
                ViewState["OnClientClick"] = value;
            }
        }
        /// <summary>
        /// �ڿͻ��������������˫���¼���
        /// </summary>
        [DefaultValue(""), Themeable(false), Category("Client Behavior"), Description("�ڿͻ���ondblclick��ִ�еĿͻ��˽ű���"),]
        public virtual string OnClientDblClick
        {
            get
            {
                var s = (string)ViewState["OnClientDblClick"];
                return s ?? string.Empty;
            }
            set
            {
                ViewState["OnClientDblClick"] = value;
            }
        }
        #endregion
        #endregion

        #region CTOR
        public MzhDataGrid()
        {

        }
        #endregion

        #region �Զ��巽��
        /// <summary> 
        /// ����IDѡ��DataGrid�е�ĳһ�С�
        /// </summary>
        /// <param name="Id"> ѡ���е�ID�� </param>
        public void SelectItem(object Id)
        {
            if (SelectType == SelectMode.None) return;
            tbSelectedID.Value = Id.ToString();
            tbSelectedArray.Value = Id.ToString();
            tbSelectedStream.Value = "'" + Id + "'";
        }

        /// <summary> 
        /// ����ID��ѡ��DataGrid�ж�����¼��
        /// </summary>
        /// <param name="Ids"> ѡ���е�ID�����Զ��ŷָ��� </param>
        public void SelectItems(string Ids)
        {
            var IdArray = Ids.Split(',');
            var selectedStream = "";
            for (var i = 0; i < IdArray.Length; i++)
            {
                selectedStream += "'" + IdArray[i] + "'";
                if (i != IdArray.Length - 1)
                    selectedStream += ",";
            }

            if (SelectType != SelectMode.MultiSelect) return;
            tbSelectedID.Value = IdArray[0];
            tbSelectedArray.Value = Ids;
            tbSelectedStream.Value = selectedStream;
        }
        #endregion

        #region ˽�з���

        /// <summary>
        /// ������ת��ָ����ҳ��
        /// </summary>
        /// <param name="pageIndex">ҳ�롣</param>
        private void GoToPage(int pageIndex)
        {
            this.CurrentPageIndex = pageIndex;
            this.DataBind();
            this.OnPageIndexChanged(new DataGridPageChangedEventArgs(this, pageIndex));
            
        }

        /// <summary>
        /// �����ܼ�¼����
        /// </summary>
        /// <param name="cell"></param>
        private void BuildTotalRecorderCount(Control cell)
        {
            //TODO:change Total language
            //cell.Controls.Add(new LiteralControl("Total <b>" + this.RecordsCount + "</b> Records "));
            cell.Controls.Add(new LiteralControl("�� <b>" + this.RecordsCount + "</b> ��"));
        }

        /// <summary>
        /// ������ǰ�����ҳ��
        /// </summary>
        /// <param name="cell">��Ҫ������ǰ�������UI�ĵ�Ԫ��</param>
        private void BuildNextPrevUI(Control cell)
        {

            // �ж��Ƿ���Ҫ������ҳ��UI���ֻ��һҳ����Ϣ����Ҫ������
            var bIsBuildNextPrevUI = ((this.CurrentPageIndex < 0) ? false : ((this.CurrentPageIndex > (this.PageCount - 1)) == false));
            // �жϵ�ǰ�ǲ��ǵ�һҳ
            var bIsFirstPage = (this.CurrentPageIndex > 0);
            // �жϵ�ǰ�ǲ������һҳ
            var bIsLastPage = (this.CurrentPageIndex < (this.PageCount - 1));

            // Ҫ�������ĸ���ҳ�ؼ���UI

            //cell.Controls.Add(new LiteralControl("[ "));


            // ����ת����һҳ�Ŀؼ�
            //TODO:change |< language
            var btnFirst = new LinkButton
                                      {
                                          ID = "First",
                                          CommandName = "FirstPAGE",
                                          ToolTip = "Go to first page",
                                          Text = "|<",//"��ҳ",
                                          CausesValidation = this.CauseValidationWhenPaging,
                                          Enabled = (!bIsBuildNextPrevUI ? false : bIsFirstPage),
                                          CssClass = "First",
                                          
                                          Width = 16,
                                          //Height = 16,
                                      };
            // ȷ��ת���һҳ�İ�ť�Ƿ����
            cell.Controls.Add(btnFirst);

            cell.Controls.Add(new LiteralControl("  "));

            // ������ǰ��ҳ�Ŀؼ�
            //TODO:change < language
            var btnPrev = new LinkButton
                                     {
                                         ID = "Prev",
                                         CommandName = "PrevPAGE",
                                         ToolTip = "Go to pre page",
                                         Text = "<",//"��һҳ",
                                         CausesValidation = this.CauseValidationWhenPaging,
                                         Enabled = (!bIsBuildNextPrevUI ? false : bIsFirstPage),
                                         CssClass = "Prev",
                                         Width = 16,
                                         //Height = 16,
                                     };
            cell.Controls.Add(btnPrev);
            cell.Controls.Add(new LiteralControl("  "));

            // �������ҳ�Ŀؼ�
            //TODO: change > language
            var btnNext = new LinkButton
                                     {
                                         ID = "Next",
                                         CommandName = "NextPAGE",
                                         ToolTip = "Go to next page",
                                         Text = ">",//"��һҳ",
                                         CausesValidation = this.CauseValidationWhenPaging,
                                         Enabled = (!bIsBuildNextPrevUI ? false : bIsLastPage),
                                         CssClass = "Next",
                                         Width = 16,
                                         //Height = 16,
                                     };
            
            cell.Controls.Add(btnNext);
            cell.Controls.Add(new LiteralControl("  "));

            // �����������һҳ�Ŀؼ�
            // TODO: change >| language
            var btnLast = new LinkButton
                                     {
                                         ID = "Last",
                                         CommandName = "LastPAGE",
                                         ToolTip = "Go to last page",
                                         Text = ">|",
                                         //Text = "βҳ",
                                         CausesValidation = this.CauseValidationWhenPaging,
                                         Enabled = (!bIsBuildNextPrevUI ? false : bIsLastPage),
                                         CssClass = "Last",
                                         Width = 16,
                                         //Height = 16,
                                         
                                     };
            cell.Controls.Add(btnLast);
            cell.Controls.Add(new LiteralControl("  "));
        }

        /// <summary>
        /// ����ʹ�����ַ�ҳ��UI���֣��������洴����UI�ǻ���ġ�
        /// </summary>
        /// <param name="cell"></param>
        private void BuildNumericPagesForDropList(Control cell)
        {
            // ��ҳ������
            var pageIndexList = new DropDownList {ID = "PageIndexList", AutoPostBack = true, EnableViewState = true,CausesValidation=this.CauseValidationWhenPaging,};
            pageIndexList.SelectedIndexChanged += pageIndexList_SelectedIndexChanged;
            pageIndexList.ApplyStyle(this.PagerStyle);
            //TODO:Change Page Language
            //var lblJumpTo = new Literal { Text = "Page" };
            //var lblPageWord = new Literal { Text = "" };
            var lblJumpTo = new Literal { Text = "��" };
            var lblPageWord = new Literal { Text = "" };
            int iPageIndex;
            // ���û�з�ҳ���PageList�ؼ��������һ����û������ҳ����Ϣ
            if ((this.PageCount <= 0) || (this.CurrentPageIndex == -1))
            {
                //pageIndexList.Items.Add("û��������ҳ");
                pageIndexList.Items.Add("No page");
                pageIndexList.Enabled = false;
                pageIndexList.SelectedIndex = 0;
            }
            else
            {
                for (var i = 1; i <= this.PageCount; i++)
                {
                    // ҳ������������˵��ҳ֮�����1
                    iPageIndex = i - 1;
                    var itemPageNumber = new ListItem(i + " / " + this.PageCount, iPageIndex.ToString());
                    pageIndexList.Items.Add(itemPageNumber);
                }
                pageIndexList.SelectedIndex = this.CurrentPageIndex;
            }

            cell.Controls.Add(lblJumpTo);
            cell.Controls.Add(pageIndexList);
            cell.Controls.Add(lblPageWord);
        }

        /// <summary>
        /// ����ʹ�����ַ�ҳ��UI���֣��������洴����UI�ǻ���ġ�
        /// </summary>
        /// <param name="cell"></param>
        private void BuildNumericPagesForJump(Control cell)
        {
            // ҳ����ת�����
            var btnJump = new Button();
            btnJump.Click += JumpButton_Clicked;
            btnJump.CssClass = this.CSSClassForPagerButtonJump;
            btnJump.Text = "ת��";

            var curPageShow = this.CurrentPageIndex + 1;

            var txtPage = new TextBox {Text = curPageShow.ToString(), ID = "txtPage",CausesValidation=this.CauseValidationWhenPaging};
            txtPage.Attributes.Add("onkeypress", "if (event.keyCode<45 || event.keyCode>57) {event.keyCode=0;}");
            txtPage.CssClass = this.CSSClassForPagerInputPage;

            var lblJumpTo = new Literal {Text = "�ڣ�"};
            var lblPageCount = new Literal
                                   {
                                       Text = (curPageShow + " / " + this.PageCount)
                                   };

            cell.Controls.Add(lblJumpTo);
            cell.Controls.Add(lblPageCount);
            cell.Controls.Add(txtPage);
            cell.Controls.Add(btnJump);
        }
        
        /// <summary>
        /// ��������Դ��ÿҳ�е���ʾ�����Ŀѡ������
        /// </summary>
        /// <param name="cell"></param>
        private void BuildPageSizeSelector(Control cell)
        {
            var cboPageSize = new DropDownList {AutoPostBack = true,CausesValidation=this.CauseValidationWhenPaging,};

            
            // -- limit the max page size to a 100 records
            //var j = this.RecordsCount + pageSelectorPageSizeInterval;
            for (var i = pageSelectorPageSizeInterval; i <= this.RecordsCount + pageSelectorPageSizeInterval; i += pageSelectorPageSizeInterval)
            {
                cboPageSize.Items.Add(i.ToString());
                
                if (i >= 100 && i < 1000)
                    pageSelectorPageSizeInterval = 100;
                else if (i >= 1000)
                    pageSelectorPageSizeInterval = 1000;
            }
            
            pageSelectorPageSizeInterval = 10;

            if (cboPageSize.Items.FindByText(this.PageSize.ToString()) != null)
            {
                cboPageSize.Items.FindByText(this.PageSize.ToString()).Selected = true;
            }
            //TODO :Change Pagesize Language
            //cell.Controls.Add(new Literal {Text="Pagesize"});
            cell.Controls.Add(new Literal { Text = "ÿҳ" });
            cboPageSize.SelectedIndexChanged += this.cboPageSize_SelectedIndexChanged;
            cell.Controls.Add(cboPageSize);
        }

        #endregion

        #region ���ط���
        /// <summary>
        /// ���ݰ󶨷�����
        /// </summary>
        public override void DataBind()
        {
            Logger.Debug("DataGrid DataBind()");
            if(this.DataSource != null)
            {
                if (this.DataSource is DataSet)
                {
                    this.DataSource = (this.DataSource as DataSet).Tables[0].DefaultView;
                }
                else if (this.DataSource is DataTable)
                {
                    this.DataSource = (this.DataSource as DataTable).DefaultView;
                }
                else if(this.DataSource is DataView)
                {

                }
                //�ܼ�¼����
                this.RecordsCount = (this.DataSource is ICollection)
                                                       ? (this.DataSource as ICollection).Count
                                                       : 0;
            }

            if (this.AllowSorting)
            {
                //Logger.Info("AllowSorting");
                if (this.DataSource != null)
                {
                    if (this.DataSource is DataView)
                    {
                       // Logger.Info("DataView");
                        if (!string.IsNullOrEmpty(this.SORTEXPRESSION))
                        {
                           // Logger.Info("DataBind:"+this.ViewState["SORTEXPRESSION"].ToString());
                            (this.DataSource as DataView).Sort = this.SORTEXPRESSION;
                        }
                    }
                    //Logger.Info(this.DataSource.GetType().ToString());
                    
                    
                    var methodObj = this.DataSource.GetType().GetMethod("AutoSort");
                    if(methodObj!=null)
                    {
                        if (!string.IsNullOrEmpty(this.SORTEXPRESSION))
                            methodObj.Invoke(this.DataSource, new[] { this.SORTEXPRESSION });
                    }
                    
                    //Logger.Info(string.Format("{0}-{1}",typeObj.Name,methodObj.ToString()));
                    
                    //else if(this.DataSource is ListBase<Object>)
                    //{
                    //    Logger.Info("is ListBase<object>");
                            
                    //    (this.DataSource as ListBase<Object>).Sort(this.SORTEXPRESSION);
                    //}
                }
            }
            try
            {
                Logger.Debug("DataGrid's Invoke DataBind");
                base.DataBind();
            }
            catch
            {
                try
                {
                    this.CurrentPageIndex -= 1;
                    base.DataBind();
                }
                catch
                {
                    this.CurrentPageIndex = 0;
                    base.DataBind();
                }
            }
            finally
            {
                this.IsDoneDataBind = true;
            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// DataGrid�ĳ�ʼ���¼���
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.CssClass = this.CssClass.Trim() == string.Empty ? MZH_GRID : this.CssClass.Trim();
            this.HignLightCSS = this.HignLightCSS.Trim() == string.Empty ? MZH_GRID_ROW_OVER : this.HignLightCSS;
            this.SelectedCSS = this.SelectedCSS.Trim() == string.Empty ? MZH_GRID_ROW_SELECTED : this.SelectedCSS;

            if (this.ViewState["SORTEXPRESSION"] == null)
            {
                this.ViewState["SORTEXPRESSION"] = "";
            }
            //Logger.Info("this.autoDataBind");
            //Logger.Info(this.AutoDataBind != null);
            //if (this.AutoDataBind != null)
            {
                if (this.AllowSorting)
                    this.SortCommand += MzhDataGrid_SortCommand;
                if (this.ShowPageSize)
                    this.PageSizeChanged += MzhDataGrid_PageSizeChanged;
                if (this.AllowPaging)
                    this.PageIndexChanged += MzhDataGrid_PageIndexChanged;
            }
        }
        /// <summary>
        /// ���ݰ��¼�.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemDataBound(DataGridItemEventArgs e)
        {
            base.OnItemDataBound(e);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (SelectType != SelectMode.None)
                {
                    if (string.IsNullOrEmpty(e.Item.Attributes["id"]))
                        e.Item.Attributes.Add("id", e.Item.Cells[this.IdCell].Text);
                }
            }
        }
        /// <summary>
        /// ��ҳ�¼�.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPageIndexChanged(DataGridPageChangedEventArgs e)
        {
            this.CurrentPageIndex = e.NewPageIndex;
            base.OnPageIndexChanged(e);
            if (!this.IsDoneDataBind)
            {
                this.DataBind();
            }
        }
        /// <summary>
        /// ��DataGrid���ж�����ʱ�򼤷�������ֵ��׽��ҳ�����������ʹ�õ�ʱ�������ҪȻ��İ�ť��CommandName���������һ��
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemCommand(DataGridCommandEventArgs e)
        {
            var strCommandName = e.CommandName;
            if (e.CommandName == null)
                return;

            string.IsInterned(strCommandName);
            switch (e.CommandName)
            {
                case "FirstPAGE":
                    {
                        this.GoToPage(0);
                        break;
                    }
                case "PrevPAGE":
                    {
                        this.GoToPage(Math.Max((this.CurrentPageIndex - 1), 0));
                        break;
                    }
                case "NextPAGE":
                    {
                        this.GoToPage(Math.Min((this.CurrentPageIndex + 1), (this.PageCount - 1)));
                        break;
                    }
                case "LastPAGE":
                    {
                        this.GoToPage((this.PageCount - 1));
                        break;
                    }
            }
            base.OnItemCommand(e);
        }

        protected override void OnEditCommand(DataGridCommandEventArgs e)
        {
            Logger.Debug("DataGrid's OnEditCommand");
            base.OnEditCommand(e);
            Logger.Debug(this.IsDoneDataBind);
            if (!this.IsDoneDataBind)
            {
                if (this.AutoDataBind != null)
                    this.AutoDataBind();
            }
        }
        protected override void OnUpdateCommand(DataGridCommandEventArgs e)
        {
            base.OnUpdateCommand(e);
            if (!this.IsDoneDataBind)
            {
                if (this.AutoDataBind != null)
                    this.AutoDataBind();
            }
        }
        protected override void OnCancelCommand(DataGridCommandEventArgs e)
        {
            base.OnCancelCommand(e);
            if (!this.IsDoneDataBind)
            {
                if (this.AutoDataBind != null)
                    this.AutoDataBind();
            }
        }
        /// <summary>
        /// �����¼�.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSortCommand(DataGridSortCommandEventArgs e)
        {
            Logger.Debug("DataGrid' OnSortCommand");
            if(!string.IsNullOrEmpty(this.SORTEXPRESSION) && this.SORTEXPRESSION == e.SortExpression)
            {
                this.SORTEXPRESSION = e.SortExpression + " DESC";
            }
            else
            {
                this.SORTEXPRESSION = e.SortExpression;
            }

            //if (this.ViewState["SORTEXPRESSION"] != null && this.ViewState["SORTEXPRESSION"].ToString() == e.SortExpression)
            //{
            //    this.ViewState["SORTEXPRESSION"] = e.SortExpression + " desc";
            //    //Logger.Info("OnSortCommand:"+e.SortExpression+" desc");
            //}
            //else
            //{

            //    this.ViewState["SORTEXPRESSION"] = e.SortExpression;
            //    //Logger.Info(e.SortExpression);
            //}
                
            //Logger.Info(string.Format("Mzh_DataGrid OnSortCommand:{0}",this.SORTEXPRESSION));
            base.OnSortCommand(e);//ִ���û������������
            if(!this.IsDoneDataBind)
            {
                this.DataBind();
            }
        }
        #endregion

        #region PageSizeChanged�¼�
        /// <summary> 
        /// Occurs when the value of the SelectedIndex property changes. 
        /// </summary> 
        private void cboPageSize_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // -- reset current page index to 0;
            this.CurrentPageIndex = 0;
            var cboPageSize = (DropDownList)sender;
            this.PageSize = int.Parse(cboPageSize.SelectedValue);

            if (PageSizeChanged != null) PageSizeChanged(sender, e);
        }
        #endregion

        #region Render
        /// <summary>
        /// �����û����ֵ�HTML����.
        /// </summary>
        /// <returns></returns>
        private string getRenderHTML()
        {
            var sb = new StringBuilder();
            if (SelectType != SelectMode.None)
            {
                sb.Append("<SCRIPT>");
                sb.Append(Environment.NewLine);
                sb.Append(string.Format("var {0}_obj=new DataGridObject(document.getElementById('{0}'),{1},'{2}','{3}');",
                                                                            this.ClientID, this._isMultiSelect, this.HignLightCSS, this.SelectedCSS));
                sb.Append(Environment.NewLine);
                sb.Append("$(\"#" + this.ClientID + " tr[id]\")");
                sb.Append(".bind(\"mouseover\",function(){" + this.ClientID + "_obj.execMouseOver(this);})");
                sb.Append(".bind(\"mouseout\",function(){"  + this.ClientID + "_obj.execMouseOut(this);})");
                sb.Append(".bind(\"mousedown\",function(){" + this.ClientID + "_obj.execMouseDown(this);})");
                sb.Append(".bind(\"click\",function(){" + this.ClientID + "_obj.execClick(this);" + this.ClientID + "_obj.setSelectedID();" + this.ClientID + "_obj.setSelectedArray();" + this.ClientID + "_obj.setSelectedStream();})");
                if (this.OnClientDblClick != string.Empty)
                {
                    var onDblClick = Util.EnsureEndWithSemiColon(this.OnClientDblClick);
                    sb.Append(".bind(\"dblclick\",function(){"+onDblClick+"})");
                }
                sb.Append(";");
                sb.Append("</SCRIPT>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// ��ʼ��DataGrid�
        /// </summary>
        /// <param name="item"></param>
        /// <param name="columns"></param>
        protected override void InitializeItem(DataGridItem item, DataGridColumn[] columns)
        {
            //Logger.Info("MzhDataGrid InitializeItem");
            base.InitializeItem(item, columns);
            switch (item.ItemType)
            {
                case ListItemType.Header:
                    item.CssClass = item.CssClass.Trim() == string.Empty ? MZH_GRID_HD_ROW : item.CssClass;
                    break;
                case ListItemType.Item:
                    item.CssClass = item.CssClass.Trim() == string.Empty ? MZH_GRID_ROW : item.CssClass;
                    //for (var i = 0; i < item.Cells.Count;i++ )
                    //{
                    //    item.Cells[i].CssClass = string.Format("{0} {1}", "lr", item.Cells[i].CssClass);
                    //}
                        break;
                case ListItemType.AlternatingItem:
                    item.CssClass = item.CssClass.Trim() == string.Empty ? MZH_GRID_ROW_ALT : item.CssClass;
                    
                    break;
                case ListItemType.Footer:
                    item.CssClass = item.CssClass.Trim() == string.Empty ? MZH_GRID_FT_ROW : item.CssClass;
                    break;
            }
        }
        /// <summary>
        /// ����InitializePager��
        /// </summary>
        /// <param name="item"></param>
        /// <param name="columnSpan"></param>
        /// <param name="pagedDataSource"></param>
        protected override void InitializePager(DataGridItem item, int columnSpan, PagedDataSource pagedDataSource)
        {
            //Logger.Info("MzhDataGrid InitializePager");
            
            var cell = new TableCell();
            
            item.Cells.AddAt(0,cell);
            item.CssClass = item.CssClass.Trim() == string.Empty ? MZH_GRID_PAGER : item.CssClass;
            if (this.ShowPageSize)
                this.BuildPageSizeSelector(cell);
            if (this.MultiPageShowMode == PagerShowMode.DropListMode)
            {
                this.BuildNextPrevUI(cell);
                this.BuildNumericPagesForDropList(cell);
            }
            else
            {
                
                this.BuildNumericPagesForJump(cell);
                this.BuildNextPrevUI(cell);
                //this.BuildNumericPagesForDropList(cell);
            }
            if (this.ShowRecordsCount)
                this.BuildTotalRecorderCount(cell);
        }
        /// <summary>
        /// �������ѡ����ֵ�������ı������.
        /// </summary>
        protected virtual void CreateControlHierarchy()
        {
            //Logger.Info("CreateControlHierarchy");
            tbSelectedID = new HtmlInputHidden {ID = "SelectedID"};
            tbSelectedArray = new HtmlInputHidden {ID = "SelectedArray"};
            tbSelectedStream = new HtmlInputHidden {ID = "SelectedStream"};
        }
        /// <summary>
        /// ��ؼ�������ע����ѡ����ֵ�������ı������.
        /// </summary>
        /// <remarks>���ѡ��ģʽѡ�����None����ؼ�������ע�������ı������.</remarks>
        protected override void PrepareControlHierarchy()
        {
            //Logger.Info("PrepareControlHierarchy");
            
            try
            {
                base.PrepareControlHierarchy();
                if (Controls.Count == 0)
                    return;
                var childTable = (Table)Controls[0];
                var rows = childTable.Rows;
                var rowCount = rows.Count;

                if (rowCount == 0)
                    return;
                var columnCount = Columns.Count;
                var definedColumns = new DataGridColumn[columnCount];
                if (columnCount > 0)
                    Columns.CopyTo(definedColumns, 0);

                var visibleColumns = 0;
                for (var i = 0; i < rowCount; i++)
                {
                    var item = (DataGridItem) rows[i];
                    var cells = item.Cells;
                    var cellCount = cells.Count;
                    if((columnCount > 0) && (item.ItemType == ListItemType.Header))
                    {
                        var definedCells = cellCount;

                        if (columnCount < cellCount)
                            definedCells = columnCount;
                        for (var j = 0; j < definedCells; j++)
                        {
                            if (definedColumns[j].Visible)
                            {
                                 visibleColumns++;
                            }
                        }
                    }
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        for (var m = 0; m < item.Cells.Count; m++)
                        {
                            item.Cells[m].CssClass = "lr " + item.Cells[m].CssClass;
                        }
                    }

                }
                
                if (AllowPaging)
                {
                    if (Items.Count > 0)
                    {
                        for (var i = 0; i < rowCount; i++)
                        {
                            var item = (DataGridItem)rows[i];
                            if (item.ItemType == ListItemType.Pager && item.Cells.Count > 0)
                            {
                                item.Cells[0].ColumnSpan = Items[0].Cells.Count - (Columns.Count - visibleColumns);
                            }
                        }
                    }
                    else if (Items.Count == 0)
                    {
                        for (var i = 0; i < rowCount; i++)
                        {
                            var item = (DataGridItem)rows[i];
                            if (item.ItemType == ListItemType.Pager && item.Cells.Count > 0)
                            {
                                item.Cells[0].ColumnSpan = visibleColumns;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message,ex);
            }
            if (SelectType == SelectMode.None) return;
            Controls.Add(tbSelectedID);
            Controls.Add(tbSelectedArray);
            Controls.Add(tbSelectedStream);
        }
        /// <summary>
        /// �����ӿؼ�.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();
            base.CreateChildControls();
            CreateControlHierarchy();
            PrepareControlHierarchy();
            TrackViewState();
            ChildControlsCreated = true;
        }
        /// <summary>
        /// ��PreRender�¼���ʱ��,��ҳ����ע��JS�ű���.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (SelectType != SelectMode.None && this.Visible)
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered(MZHSTRING_SCRIPT_ID))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), MZHSTRING_SCRIPT_ID, MZHSTRING_SCRIPT);

                if (!Page.ClientScript.IsClientScriptBlockRegistered(MZHARRAY_SCRIPT_ID))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), MZHARRAY_SCRIPT_ID, MZHARRAY_SCRIPT);

                if (!Page.ClientScript.IsClientScriptBlockRegistered(MZHCSS_SCRIPT_ID))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), MZHCSS_SCRIPT_ID, MZHCSS_SCRIPT);

                if (!Page.ClientScript.IsClientScriptBlockRegistered(MZHDATAGRID_SCRIPT_ID))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), MZHDATAGRID_SCRIPT_ID, MZHDATAGRID_SCRIPT);
            }
        }
        /// <summary> 
        /// ���˿ؼ����ָ�ָ�������������
        /// </summary>
        /// <param name="output"> Ҫд������ HTML ��д�� </param>
        protected override void Render(HtmlTextWriter output)
        {
            //Logger.Info("Render");
            EnsureChildControls();
            base.Render(output);
            output.Write(getRenderHTML());
        }
        #endregion

        #region Event
        /// <summary>
        /// ������ת�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JumpButton_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var txtPage = ((TextBox)btn.Parent.FindControl("txtPage"));
            int pageIndex;
            try
            {
                pageIndex = int.Parse(txtPage.Text.Trim());
                pageIndex = (pageIndex - 1) < 0 ? 0 : (pageIndex - 1);
            }
            catch (Exception)
            {
                txtPage.Text = "0";
                throw;
            }

            this.GoToPage(pageIndex);
        }
        /// <summary>
        /// �����б�ҳ�¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageIndexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dllPageList = (DropDownList)sender;
            var iPageIndex = int.Parse(dllPageList.SelectedItem.Value);

            this.GoToPage(iPageIndex);
        }

        /// <summary>
        /// DataGrid�������¼���
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        void MzhDataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            //Logger.Info("MzhDataGrid_SortCommand");
            if (this.AutoDataBind != null)
                this.AutoDataBind();
        }
        /// <summary>
        /// DataGrid��ҳ��ı��¼���
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        void MzhDataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //Logger.Info("MzhDataGrid_PageIndexChanged");
            if (this.AutoDataBind != null)
                this.AutoDataBind();
        }
        /// <summary>
        /// DataGrid��ÿҳ��ʾ��¼���ı��¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MzhDataGrid_PageSizeChanged(object sender, EventArgs e)
        {
            //Logger.Info("MzhDataGrid_PageSizeChanged");
            if (this.AutoDataBind != null)
                this.AutoDataBind();
        }
        #endregion

    }
}
