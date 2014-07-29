using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using System.Configuration;
using System.ComponentModel;
using System.Data.SqlClient;

namespace MZHMM.WebMM.Master
{
    public partial class Default : System.Web.UI.MasterPage
    {
        
        #region 属性
        private int i;

        private DataTable dtCatCode;
        //private bool btemp;

        private string strReturnValue;


        private int asciicode;

        private CharEnumerator CEnumerator;

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string strOrderby = " Order By ModifyDate Desc ";

        private byte[] array = new byte[1];
        /// <summary>
        /// 当前用户。
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }

        public string ItemCode
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["ItemCode"]))
                {
                    return this.Request["ItemCode"];
                }
                else
                {
                    return "";
                }
            }
        }

        #region Title操作

        protected string TitlValue = "";
        public void SetTitleSpace()
        {
            this.MzhTitle1.Visible = false;
        }

        public void SetTitleContent(string strTitle)
        {
            this.MzhTitle1.Text = strTitle;
            TitlValue = strTitle;

        }

        public string ReqTitle
        {
            get
            {
                if(Request.QueryString["Title"] == null)
                {
                    return "";
                }

                return Request.QueryString["Title"].ToString();
            }
        }
        #endregion

        


        #region 权限
        /// <summary>
        /// 紧急申购单的权限
        /// </summary>
        public bool DisplayRosPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.RosPrice);
            }
        }


        /// <summary>
        /// 委外申请的权限
        /// </summary>
        public bool DisplayWTOWPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.WTOWCstPrice);
            }
        }

        /// <summary>
        /// 月度计划需求单的权限
        /// </summary>
        public bool DisplayMRPPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.MRPCstPrice);
            }
        }

        /// <summary>
        /// 月度计划的权限
        /// </summary>
        public bool DisplayPPPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.PPCstPrice);
            }
        }

        /// <summary>
        /// 采购订单的权限
        /// </summary>
        public bool DisplayPOPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.POCstPrice);
            }
        }

        /// <summary>
        /// 采购收料的权限
        /// </summary>
        public bool DisplayBORPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.BORCstPrice);
            }
        }

        /// <summary>
        /// 采购退货单的权限
        /// </summary>
        public bool DisplayPRTVPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.PRTVCstPrice);
            }
        }

        /// <summary>
        /// 委外加工收料单的权限
        /// </summary>
        public bool DisplayWINWPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.WINWCstPrice);
            }
        }

        /// <summary>
        /// 采购撤销单 的权限
        /// </summary>
        public bool DisplayCancelPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.CancelCstPrice);
            }
        }

        /// <summary>
        /// 领料单 的权限
        /// </summary>
        public bool DisplayDRWPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.DRWCstPrice);
            }
        }

        /// <summary>
        /// 生产退料的权限
        /// </summary>
        public bool DisplayRTSPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.RTSCstPrice);
            }
        }

        /// <summary>
        /// 报废单的权限
        /// </summary>
        public bool DisplaySCRPrice
        {
            get
            {
                return CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.SCRCstPrice);
            }
        }
        #endregion



        #region 维护的传递值
        public string Op
        {
            get
            {
               if (!string.IsNullOrEmpty(Request["Op"]))
               {
                   return Request["Op"];
               }
               else
               {
                   return "New";
               }
            }
        }

        public string OpTitle
        {
            get
            {
                if (Op.ToLower() == "new")
                {
                    return "新增";
                }
                else if (Op.ToLower() == "edit")
                {
                    return "修改";
                }
                else if (Op.ToLower() == "copy")
                {
                    return "复制";
                }
                else
                {
                    return "";
                }
            }
        }

        public string StoCode
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["StoCode"]))
                {
                    return Request["StoCode"];
                }
                else
                {
                    return "";
                }
            }
        }

        public string Code
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["Code"]))
                {
                    return Request["Code"];
                }
                else
                {
                    return "";
                   
                }
            }
        }


        //public bool IsDisplayPrice
        //{
        //    get
        //    {
        //        if (this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.QueryCstPrice))
        //        {
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //}

        /// <summary>
        /// DocCode
        /// </summary>
        public int DocCode
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request["DocCode"]) )
                    {
                        return int.Parse(Request["DocCode"]);
                    }
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public string AuthorCode
        {
            get
            {
                if (Request["AuthorCode"] != null)
                {
                    return Request["AuthorCode"];
                }
                else
                {
                    return "";
                }
            }
        }

        public string AuthorDept
        {
            get
            {
                if (Request["AuthorDept"] != null)
                {
                    return Request["AuthorDept"];
                }
                else
                {
                    return "";
                }
            }
        }

        public int AuditResult
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request["AuditResult"]))
                    {
                        return int.Parse(Request["AuditResult"]);
                    }
                    return 100;
                }
                catch
                {
                    return 100;
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request["StartDate"]) )
                    {
                        return DateTime.Parse(Request["StartDate"]);
                    }
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
                catch
                {
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request["EndDate"]))
                    {
                        return DateTime.Parse(Request["EndDate"]);
                    }
                    else
                    {
                        return StartDate.AddMonths(1);

                    }
                }
                catch
                {
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
            }
        }


        #endregion 
        
        #region 采购
        public string PurposeOp
        {
            get
            {

                if (string.IsNullOrEmpty(Request["Op"]))
                {
                    return "";
                }
                else
                {
                    return Request["Op"];
                }
            }
        }

        public bool IsTODO
        {
            get
            {

                if (string.IsNullOrEmpty(Request["TODO"]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int EntryNo
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request["EntryNo"]))
                    {
                        return Convert.ToInt32(Request["EntryNo"]);
                    }
                    else
                        return 0;
                }
                catch (Exception)
                {
                    return 0;
                }
                
            }
        }
        #endregion

        /// <summary>
        /// 用户选择路径
        /// </summary>
        public string UserQueryPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["UserQueryPath"];
            }
        }

        
       /// <summary>
        /// 供应商选择路径
        /// </summary>
        public string CrmQueryPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CrMQueryPath"];
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 在浏览页面中通过User的hasright方法进行判断 权限不够直接到跳转页面
        /// </summary>
        /// <param name="iRightCode"></param>
        /// <returns></returns>
        public bool HasBrowseRight(int iRightCode)
        {

            if (!HasMaintainRight(iRightCode, true))
            {
                Response.Redirect("../Common/NoRight.aspx");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 多个权限值中只要有个满足就返回true ,不然直接跳转页面
        /// </summary>
        /// <param name="iRightCode"></param>
        /// <returns></returns>
        public bool HasBrowseRight(int []  iRightCode)
        {
            if(iRightCode.Length > 0)
            {
                //btemp = false;
                for( i = 0;i<iRightCode.Length ;i++)
                {
                    if (HasMaintainRight(iRightCode[i], false))
                    {
                        return true;
                    }
               
                }
                Response.Redirect("../Common/NoRight.aspx");
                return false;
            }
            else
            {
                Response.Redirect("../Common/NoRight.aspx");
                return false;
            }

        
        }

        public bool HasRight(int iRightCode)
        {

            if (!HasMaintainRight(iRightCode, false))
            {
                return false;
            }
            else
                return true;
        }

        public bool HasMaintainRight(int iRightCode, bool bigoright)
        {
            bool bstatus = this.CurrentUser.HasRight(iRightCode);
            
            if (!bstatus && bigoright)
            {
                Response.Redirect("../Common/NoRight.aspx");
                return false;
            }
            else
            {
                return bstatus;
            }

        }

        public string GetSql(string strsql)
        {
            switch (this.DocCode)
            {
                case 1://采购申请

                    Logger.Info("docCode=" + this.DocCode + ";Code=" + MZHMM.WebMM.Common.SysRight.RosBrowseALL);
                    if (this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.RosBrowseALL))
                        return strsql +  strOrderby;
                    break;
                case 2://月度计划需求单 
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.MRPBrowseALL);
                      if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.MRPBrowseALL))
                          return strsql + strOrderby;
                    break;
                case 5://采购计划  
                     Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.PPBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.PPBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 3://采购订单 
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.POBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.POBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 6://采购收料单 
                     Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.BORBrowseALL);
                     if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.BORBrowseALL))
                         return strsql + strOrderby;
                    break;
                case 7://采购退货单  
                     Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.RTVBrowseALL);
                     if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.RTVBrowseALL))
                         return strsql + strOrderby;
                    break;
                case 16://委外加工申请单  
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.WTOWBrowseALL);
                     if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.WTOWBrowseALL))
                         return strsql + strOrderby;
                    break;
                case 17://委外加工收料单 
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.WINWBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.WINWBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 14://采购收料付款单 
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.PPAYBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.PPAYBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 21://采购撤销单  
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.CancelBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.CancelBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 4://领料单  
                     Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.DRWBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.DRWBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 8://生产退料单  
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.RTSBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.RTSBrowseALL))
                        return strsql + strOrderby;
                    break;
                case 11://报废单  
                    Logger.Info("docCode="+this.DocCode +";Code="+MZHMM.WebMM.Common.SysRight.SCRBrowseALL);
                    if(this.CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.SCRBrowseALL))
                        return strsql + strOrderby;
                    break;
            }
            if (strsql.ToLower().IndexOf("where") > 0)
            {
                return strsql + " and (AuthorCode='" + this.CurrentUser.EmpCode + "' or AuthorDept In (SELECT DeptCode FROM dbo.OwnPersonDept('" + this.CurrentUser.LoginName + "'," + this.DocCode + ")))" + strOrderby;
            }
            else
            {
                return strsql + " where AuthorCode='" + CurrentUser.EmpCode + "' or AuthorDept In (SELECT DeptCode FROM dbo.OwnPersonDept('" + this.CurrentUser.LoginName + "'," + this.DocCode + ")))" + strOrderby;
            }
        }

        public string GetNoSpaceString(string strValue)
        {
            strReturnValue = "";

            CEnumerator = strValue.GetEnumerator();
            while (CEnumerator.MoveNext())
            {
                array = new byte[1];
                array = System.Text.Encoding.ASCII.GetBytes(CEnumerator.Current.ToString());
                asciicode = (short)(array[0]);
                if (asciicode != 32)
                {
                    strReturnValue += CEnumerator.Current.ToString();
                }
            }

            return strReturnValue;
        }

        #region 物料的控制

        private string GetCatCodeByItemCode(string strItemCode)
        {
            dtCatCode = (new Shmzh.MM.Facade.ItemSystem()).GetItemByCode(strItemCode).Tables[0];

            if (dtCatCode.Rows.Count > 0)
            {
                return dtCatCode.Rows[0]["CatCode"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 是否是合法的内容。
        /// </summary>
        /// <param name="strItemCodeList">物料编号串</param>
        /// <param name="strReqCode">用途代码</param>
        /// <returns>bool</returns>
        public bool IsContaintContent(string strItemCodeList, string strReqCode)
        {
            var strItemCode = strItemCodeList.Split(',');

            var allowedItemCategoryCode = ConfigurationManager.AppSettings[strReqCode];

            if (!string.IsNullOrEmpty(allowedItemCategoryCode))
            {
                if (strItemCode.Any(itemCode => GetCatCodeByItemCode(itemCode) != allowedItemCategoryCode))
                {
                    return false;
                }
            }
            foreach (var itemCode in strItemCode)
            {
                var catCode = GetCatCodeByItemCode(itemCode);
                var reqCode = ConfigurationManager.AppSettings[catCode];
                if (!string.IsNullOrEmpty(reqCode))
                {
                    if (reqCode != strReqCode)
                        return false;
                }
            }
            return true;
        }
        #endregion
        #endregion 

       

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
