namespace WebMM.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Shmzh.MM.Facade;
    using MZHMM.WebMM.Common;
    using Shmzh.MM.Common;
    using MZHCommon.Database;
    using System.Collections;
    using System.Data;

    /// <summary>
    /// 摘要的用户Web组件.
    /// </summary>
    public partial class WUCToolTip : System.Web.UI.UserControl
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Field
        //private DataSet childData;
        #endregion

        #region Property
        public string EntryNo
        {
            set;
            get;
        }

        public string DocCode
        {
            set;
            get;
        }
        #endregion

        #region event
        /// <summary>
        /// 页面加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    VisibleRPT(0);
                    this.BuildUpTitleString();
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("WUCToolTip Page_Load Message:{0}", ex.Message));
                    Logger.Error(ex);
                    Logger.Error("DocCode=" + this.DocCode);
                }
            }
        }
        #endregion

        
        #region method
        /// <summary>
        /// 是否隐藏RPT控件
        /// </summary>
        /// <param name="flag"></param>
        private void VisibleRPT(int flag)
        {
            if (flag == 1)
            {
                this.rptToolTipMRP.Visible = true;
                this.rptToolTipROS.Visible = true;
                this.rptToolTipPO.Visible = true;
                this.rptToolTipDRW.Visible = true;
                this.rptToolTipPP.Visible = true;
                this.rptToolTipBOR.Visible = true;
                this.rptToolTipRTV.Visible = true;
                this.rptToolTipCBR.Visible = true;
                this.rptToolTipTRF.Visible = true;
                this.rptToolTipSCR.Visible = true;
                this.rptToolTipADJ.Visible = true;
                this.rptToolTipBRB.Visible = true;
                this.rptToolTipPAY.Visible = true;
                this.rptToolTipWTOW.Visible = true;
                this.rptToolTipWINW.Visible = true;
                this.rptToolTipCANCEL.Visible = true;
                this.rptToolTipInventoryProfit.Visible = true;
                this.rptToolTipInventoryShortage.Visible = true;
            } 
            else
            {
                this.rptToolTipMRP.Visible = false;
                this.rptToolTipROS.Visible = false;
                this.rptToolTipPO.Visible = false;
                this.rptToolTipDRW.Visible = false;
                this.rptToolTipPP.Visible = false;
                this.rptToolTipBOR.Visible = false;
                this.rptToolTipRTV.Visible = false;
                this.rptToolTipCBR.Visible = false;
                this.rptToolTipTRF.Visible = false;
                this.rptToolTipSCR.Visible = false;
                this.rptToolTipADJ.Visible = false;
                this.rptToolTipBRB.Visible = false;
                this.rptToolTipPAY.Visible = false;
                this.rptToolTipWTOW.Visible = false;
                this.rptToolTipWINW.Visible = false;
                this.rptToolTipCANCEL.Visible = false;
                this.rptToolTipInventoryProfit.Visible = false;
                this.rptToolTipInventoryShortage.Visible = false;
            }
        }

        /// <summary>
        /// 根据单据类型和单据流水号返回单据
        /// </summary>
        public void BuildUpTitleString()
        {

            if (DocCode.Trim().Length > 0)
            {
                var titleString = string.Empty;
                switch (int.Parse(DocCode))
                {
                    case DocType.ROS:
                        {
                            this.rptToolTipROS.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetROSData(int.Parse(EntryNo));
                            this.rptToolTipROS.DataBind();
                            this.rptToolTipROS.Visible = true;
                        }
                        break;
                    case DocType.MRP:
                        {
                            this.rptToolTipMRP.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetMRPData(int.Parse(EntryNo));
                            this.rptToolTipMRP.DataBind();
                            this.rptToolTipMRP.Visible = true;
                        }
                        break;
                    case DocType.PO:
                        {
                            this.rptToolTipPO.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetPOData(int.Parse(EntryNo));
                            this.rptToolTipPO.DataBind();
                            this.rptToolTipPO.Visible = true;
                        }
                        break;
                    case DocType.DRW:
                        {
                            this.rptToolTipDRW.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetDRWData(int.Parse(EntryNo));
                            this.rptToolTipDRW.DataBind();
                            this.rptToolTipDRW.Visible = true;
                        }
                        break;
                    case DocType.PP:
                        {
                            this.rptToolTipPP.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetPPData(int.Parse(EntryNo));
                            this.rptToolTipPP.DataBind();
                            this.rptToolTipPP.Visible = true;
                        }
                        break;
                    case DocType.BOR:
                        {
                            this.rptToolTipBOR.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetBORData(int.Parse(EntryNo));
                            this.rptToolTipBOR.DataBind();
                            this.rptToolTipBOR.Visible = true;
                        }
                        break;
                    case DocType.RTV:
                        {
                            this.rptToolTipRTV.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetRTVData(int.Parse(EntryNo));
                            this.rptToolTipRTV.DataBind();
                            this.rptToolTipRTV.Visible = true;
                        }
                        break;
                    case DocType.RTS:
                        {
                            this.rptToolTipRTS.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetRTSData(int.Parse(EntryNo));
                            this.rptToolTipRTS.DataBind();
                            this.rptToolTipRTS.Visible = true;
                        }
                        break;
                    case DocType.CBR:
                        {
                            this.rptToolTipCBR.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetCBRData(int.Parse(EntryNo));
                            this.rptToolTipCBR.DataBind();
                            this.rptToolTipCBR.Visible = true;
                        }
                        break;
                    case DocType.TRF:
                        {
                            this.rptToolTipTRF.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetTRFData(int.Parse(EntryNo));
                            this.rptToolTipTRF.DataBind();
                            this.rptToolTipTRF.Visible = true;
                        }
                        break;
                    case DocType.SCR:
                        {
                            this.rptToolTipSCR.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetSCRData(int.Parse(EntryNo));
                            this.rptToolTipSCR.DataBind();
                            this.rptToolTipSCR.Visible = true;
                        }
                        break;
                    case DocType.ADJ:
                        {
                            this.rptToolTipADJ.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetADJData(int.Parse(EntryNo));
                            this.rptToolTipADJ.DataBind();
                            this.rptToolTipADJ.Visible = true;
                        }
                        break;
                    case DocType.BRB:
                        {
                            this.rptToolTipBRB.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetBRBData(int.Parse(EntryNo));
                            this.rptToolTipBRB.DataBind();
                            this.rptToolTipBRB.Visible = true;
                        }
                        break;
                    case DocType.PAY:
                        {
                            this.rptToolTipPAY.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetPAYData(int.Parse(EntryNo));
                            this.rptToolTipPAY.DataBind();
                            this.rptToolTipPAY.Visible = true;
                        }
                        break;
                    case DocType.WTOW:
                        {
                            this.rptToolTipWTOW.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetWTOWData(int.Parse(EntryNo));
                            this.rptToolTipWTOW.DataBind();
                            this.rptToolTipWTOW.Visible = true;
                        }
                        break;
                    case DocType.WINW:
                        {
                            this.rptToolTipWINW.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetWINWData(int.Parse(EntryNo));
                            this.rptToolTipWINW.DataBind();
                            this.rptToolTipWINW.Visible = true;
                        }
                        break;
                    case DocType.CANCEL:
                        {
                            this.rptToolTipCANCEL.DataSource = (new Shmzh.MM.Facade.ToolTip()).GetCANCELData(int.Parse(EntryNo));
                            this.rptToolTipCANCEL.DataBind();
                            this.rptToolTipCANCEL.Visible = true;
                        }
                        break;
                    case DocType.INVENTRYPROFIT:
                        {
                            this.rptToolTipInventoryProfit.DataSource =
                                new Shmzh.MM.Facade.ToolTip().GetInventoryProfitData(int.Parse(EntryNo));
                            this.rptToolTipInventoryProfit.DataBind();
                            this.rptToolTipInventoryProfit.Visible = true;
                        }
                        break;
                    case DocType.INVENTORYSHORTAGE:
                        {
                            this.rptToolTipInventoryShortage.DataSource =
                                new Shmzh.MM.Facade.ToolTip().GetInventoryShortageData(int.Parse(EntryNo));
                            this.rptToolTipInventoryShortage.DataBind();
                            this.rptToolTipInventoryShortage.Visible = true;
                        }
                        break;
                    default:
                        titleString = "未找到相应单据类型！！！";
                        break;
                }
            }
            
           
        }


        private string BuildUpHtmlCode()
        {
            var htmlcode = string.Empty;

            return htmlcode;
        }
        #endregion
    }
}