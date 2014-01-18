using System;
using System.Collections.Generic;
using System.Web;

namespace MZHMM.WebMM.Common
{
    public class Enums
    {
    }

    #region SysRight
    /// 有关权限的枚举。
	/// </summary>
    public sealed class SysRight
    {
        /// <summary>
        /// 无权操作的警告信息．
        /// </summary>
        public const string NoRight = "对不起，您无权进行此操作！";

        /// <summary>
        /// 物料信息浏览．
        /// </summary>
        public const int ItemBrowse = 17002;

        /// <summary>
        /// 物料信息管理．
        /// </summary>
        public const int ItemMaintain = 17003;

        /// <summary>
        /// 物料分类浏览．
        /// </summary>
        public const int CategoryBrowser = 17004;

        /// <summary>
        /// 物料分类管理．
        /// </summary>
        public const int CategoryMaintain = 17005;

        /// <summary>
        /// 度量单位浏览．
        /// </summary>
        public const int UnitBrowser = 17006;

        /// <summary>
        /// 度量单位管理．
        /// </summary>
        public const int UnitMaintain = 17007;

        /// <summary>
        /// 仓库浏览．
        /// </summary>
        public const int StoBrowser = 17008;

        /// <summary>
        /// 仓库管理．
        /// </summary>
        public const int StoMaintain = 17009;

        /// <summary>
        /// 架位浏览．
        /// </summary>
        public const int ConBrowser = 17010;

        /// <summary>
        /// 架位管理．
        /// </summary>
        public const int ConMaintain = 17011;

        /// <summary>
        /// 仓库管理员浏览．
        /// </summary>
        public const int StoManagerBrowser = 17012;

        /// <summary>
        /// 仓库管理员管理．
        /// </summary>
        public const int StoManagerMaintain = 17013;

        /// <summary>
        /// 用途浏览．
        /// </summary>
        public const int PurposeBrowser = 17014;

        /// <summary>
        /// 用途管理．
        /// </summary>
        public const int PurposeMaintain = 17015;

        /// <summary>
        /// 用途分类浏览．
        /// </summary>
        public const int ClassfiyBrowser = 17016;

        /// <summary>
        /// 用途分类管理．
        /// </summary>
        public const int ClassfiyMaintain = 17017;

        /// <summary>
        /// 库存月结 ．
        /// </summary>
        public const int YJMaintain = 17018;

        /// <summary>
        /// 科目归结．
        /// </summary>
        public const int YJBaocunMaintain = 17019;

        /// <summary>
        /// 科目修改 ．
        /// </summary>
        public const int KMUpdateMaintain = 17020;

        /// <summary>
        /// 报表浏览．
        /// </summary>
        public const int ReportBrowse = 17021;

        /// <summary>
        /// 单据部门维护．
        /// </summary>
        public const int UserDocDeptMaintain = 17022;

        /// <summary>
        /// 授权管理．
        /// </summary>
        public const int GrantMaintain = 17023;

        /// <summary>
        /// 查询管理．
        /// </summary>
        public const int SolutionMaintain = 17024;

        
        /// <summary>
        /// 库存分布统计．
        /// </summary>
        public const int StockAnalysis = 17025;

        /// <summary>
        /// 发料分布统计．
        /// </summary>
        public const int WithDrawAnalysis = 17026;

        /// <summary>
        /// 申购分布统计．
        /// </summary>
       public const int ROSAnalysis = 17027;

        /// <summary>
        /// 综合统计分析．
        /// </summary>
        public const int CurrentAnalysis = 17028;

        /// <summary>
        /// 同期统计分析．
        /// </summary>
        public const int CorrespondingAnalysis = 17029;

        /// <summary>
        /// ABC统计分析．
        /// </summary>
        public const int CorrespondingABCAnalysis = 17030;

        /// <summary>
        /// 物料统计分析．
        /// </summary>
        public const int DocStat = 17031;

        /// <summary>
        /// 采购申请单浏览(本人)．
        /// </summary>
        public const int ROSBrowser = 17032;


        /// <summary>
        /// 采购申请单管理（新增,修改,删除）．
        /// </summary>
        public const int ROSMaintain = 17033;

        /// <summary>
        /// 采购申请单提交．
        /// </summary>
        public const int ROSPresent = 17034;


        /// <summary>
        /// 采购申请单作废．
        /// </summary>
        public const int ROSCancel = 17035;

        /// <summary>
        /// 采购申请单一级审批．
        /// </summary>
        public const int ROSFirstAudit = 17036;


        /// <summary>
        /// 采购申请单二级审批．
        /// </summary>
        public const int ROSSecondAudit = 17037;

        /// <summary>
        /// 采购申请单三级审批．
        /// </summary>
        public const int ROSThirdAudit = 17038;

        /// <summary>
        /// 采购申请单物资审核。
        /// </summary>
        public const int ROSWZAudit = 17205;

        /// <summary>
        /// 物料需求单浏览(本人）．
        /// </summary>
        public const int MRPBrowser = 17039;


        /// <summary>
        /// 物料需求单管理（新增,修改,删除）．
        /// </summary>
        public const int MRPMaintain = 17040;

        /// <summary>
        /// 物料需求单作废．
        /// </summary>
        public const int MRPCancel = 17041;

        /// <summary>
        /// 物料需求单提交．
        /// </summary>
        public const int MRPPresent = 17042;

        /// <summary>
        /// 物料需求单一级审批．
        /// </summary>
        public const int MRPFirstAudit = 17043;


        /// <summary>
        /// 物料需求单二级审批．
        /// </summary>
        public const int MRPSecondAudit = 17044;

        /// <summary>
        /// 物料需求单三级审批．
        /// </summary>
        public const int MRPThirdAudit = 17045;


        /// <summary>
        /// 采购计划浏览（本人）．
        /// </summary>
        public const int PPBrowser = 17046;


        /// <summary>
        /// 采购计划管理（新增,修改,删除）．
        /// </summary>
        public const int PPMaintain = 17047;

        /// <summary>
        /// 采购计划作废．
        /// </summary>
        public const int PPCancel = 17048;

        /// <summary>
        /// 采购计划提交．
        /// </summary>
        public const int PPPresent = 17049;

        /// <summary>
        /// 采购计划一级审批．
        /// </summary>
        public const int PPFirstAudit = 17050;


        /// <summary>
        /// 采购计划二级审批．
        /// </summary>
        public const int PPSecondAudit = 17051;

        /// <summary>
        /// 采购计划三级审批．
        /// </summary>
        public const int PPThirdAudit = 17052;



        /// <summary>
        /// 采购订单浏览（本人）．
        /// </summary>
        public const int POBrowser = 17053;


        /// <summary>
        /// 采购订单管理（新增,修改,删除）．
        /// </summary>
        public const int POMaintain = 17054;

        /// <summary>
        /// 采购订单作废．
        /// </summary>
        public const int POCancel = 17055;

        /// <summary>
        /// 采购订单提交．
        /// </summary>
        public const int POPresent = 17056;

        /// <summary>
        /// 采购订单指派．
        /// </summary>
        public const int POAssign = 17057;

        /// <summary>
        /// 采购订单采购确认．
        /// </summary>
        public const int POConfirm = 17058;

        /// <summary>
        /// 采购订单红字．
        /// </summary>
        public const int POCancelOpera = 17059;

        /// <summary>
        /// 采购订单一级审批．
        /// </summary>
        public const int POFirstAudit = 17060;


        /// <summary>
        /// 采购订单二级审批．
        /// </summary>
        public const int POSecondAudit = 17061;

        /// <summary>
        /// 采购订单三级审批．
        /// </summary>
        public const int POThirdAudit = 17062;


        /// <summary>
        /// 采购收料单浏览（本人）．
        /// </summary>
        public const int BORBrowser = 17063;


        /// <summary>
        /// 采购收料单管理（新增,修改,删除）．
        /// </summary>
        public const int BORMaintain = 17064;

        /// <summary>
        /// 采购收料单作废．
        /// </summary>
        public const int BORCancel = 17065;

        /// <summary>
        /// 采购收料单提交．
        /// </summary>
        public const int BORPresent = 17066;

        /// <summary>
        /// 采购收料单红字．
        /// </summary>
        public const int BORCancelOpera = 17067;

        /// <summary>
        /// 采购收料单发票清单．
        /// </summary>
        public const int BORInvDetail = 17068;

        /// <summary>
        /// 采购收料单一级审批．
        /// </summary>
        public const int BORFirstAudit = 17069;


        /// <summary>
        /// 采购收料单二级审批．
        /// </summary>
        public const int BORSecondAudit = 17070;

        /// <summary>
        /// 采购收料单三级审批．
        /// </summary>
        public const int BORThirdAudit = 17071;


        /// <summary>
        /// 采购退货单浏览（本人）．
        /// </summary>
        public const int RTVBrowser = 17072;


        /// <summary>
        /// 采购退货单管理（新增,修改,删除）．
        /// </summary>
        public const int RTVMaintain = 17073;

        /// <summary>
        /// 采购退货单退料．
        /// </summary>
       // public const int RTVDrawItem = 17074;

        /// <summary>
        /// 采购退货单提交．
        /// </summary>
        public const int RTVPresent = 17075;

        /// <summary>
        /// 采购退货单作废．
        /// </summary>
        public const int RTVCancel = 17076;

        /// <summary>
        /// 采购退货单一级审批．
        /// </summary>
        public const int RTVFirstAudit = 17077;


        /// <summary>
        /// 采购退货单二级审批．
        /// </summary>
        public const int RTVSecondAudit = 17078;

        /// <summary>
        /// 采购退货单三级审批．
        /// </summary>
        public const int RTVThirdAudit = 17079;

        /// <summary>
        /// 委外加工收料单浏览（本人）．
        /// </summary>
        public const int WINWBrowser = 17080;


        /// <summary>
        /// 委外加工收料单管理（新增,修改,删除）．
        /// </summary>
        public const int WINWMaintain = 17081;

        /// <summary>
        /// 委外加工收料单提交．
        /// </summary>
        public const int WINWPresent = 17082;

        /// <summary>
        /// 委外加工收料单作废．
        /// </summary>
        public const int WINWCancel = 17083;

        /// <summary>
        /// 委外加工收料单部门审批．
        /// </summary>
        public const int WINWFirstAudit = 17084;


        /// <summary>
        /// 委外加工收料单财务审批．
        /// </summary>
        public const int WINWSecondAudit = 17085;

        /// <summary>
        /// 委外加工收料单厂长审批．
        /// </summary>
        public const int WINWThirdAudit = 17086;

        /// <summary>
        /// 委外加工收料单收料．
        /// </summary>
       // public const int WINWDraw = 17087;

        /// <summary>
        /// 委外加工收料单红字．
        /// </summary>
        public const int WINWRed = 17088;


        /// <summary>
        /// 采购收料付款单浏览（本人）
        /// </summary>
        public const int PayBrowser = 17089;


        /// <summary>
        /// 采购收料付款单管理（新增,删除）．
        /// </summary>
        public const int PayMaintain = 17090;

        /// <summary>
        /// 采购收料付款单提交．
        /// </summary>
        public const int PayPresent = 17091;

        /// <summary>
        /// 采购收料付款单审批．
        /// </summary>
        public const int PayThirdAudit = 17092;

        /// <summary>
        /// 采购收料付款单确认．
        /// </summary>
        public const int PayConfirm = 17093;

        /// <summary>
        /// 采购收料付款单作废．
        /// </summary>
        public const int PayCancel = 17094;


        /// <summary>
        /// 采购撤销单浏览．
        /// </summary>
        public const int CancelBrowser = 17095;


        /// <summary>
        /// 采购撤销单管理（新增,修改,删除）．
        /// </summary>
        public const int CancelMaintain = 17096;

        /// <summary>
        /// 采购撤销单提交．
        /// </summary>
        public const int CancelPresent = 17097;

        /// <summary>
        /// 采购撤销单作废．
        /// </summary>
        public const int CancelCancel = 17098;

        /// <summary>
        /// 采购撤销单一级审批．
        /// </summary>
        public const int CancelFirstAudit = 17099;


        /// <summary>
        /// 采购撤销单二级审批．
        /// </summary>
        public const int CancelSecondAudit = 17100;

        /// <summary>
        /// 采购撤销单三级审批．
        /// </summary>
        public const int CancelThirdAudit = 17101;


        /// <summary>
        /// 委外加工申请单浏览．
        /// </summary>
        public const int WTOWBrowser = 17102;


        /// <summary>
        /// 委外加工申请单管理（新增,修改,删除）
        /// </summary>
        public const int WTOWMaintain = 17103;

        /// <summary>
        /// 委外加工申请单提交
        /// </summary>
        public const int WTOWPresent = 17104;

        /// <summary>
        /// 委外加工申请单作废．
        /// </summary>
        public const int WTOWCancel = 17105;

        /// <summary>
        /// 委外加工申请单一级审批．
        /// </summary>
        public const int WTOWFirstAudit = 17106;


        /// <summary>
        /// 委外加工申请单二级审批．
        /// </summary>
        public const int WTOWSecondAudit = 17107;

        /// <summary>
        /// 委外加工申请单三级审批．
        /// </summary>
        public const int WTOWThirdAudit = 17108;

        /// <summary>
        /// 委外加工收料单收料．
        /// </summary>
       // public const int WTOWDraw = 17109;

        /// <summary>
        /// 委外加工收料单红字．
        /// </summary>
        public const int WTOWRed = 17110;


        /// <summary>
        /// 领料单浏览(本人）．
        /// </summary>
        public const int DRWBrowser = 17111;


        /// <summary>
        /// 领料单管理（新增,修改,删除）
        /// </summary>
        public const int DRWMaintain = 17112;

        /// <summary>
        /// 委外加工申请单作废．
        /// </summary>
        public const int DRWCancel = 17113;

        /// <summary>
        /// 领料单提交
        /// </summary>
        public const int DRWPresent = 17114;

        
        /// <summary>
        /// 领料单一级审批．
        /// </summary>
        public const int DRWFirstAudit = 17115;


        /// <summary>
        /// 领料单二级审批．
        /// </summary>
        public const int DRWSecondAudit = 17116;

        /// <summary>
        /// 领料单三级审批．
        /// </summary>
        public const int DRWThirdAudit = 17117;

        /// <summary>
        /// 领料单收料．
        /// </summary>
       // public const int DRWDraw = 17118;

        /// <summary>
        /// 领料单红字．
        /// </summary>
        public const int DRWRed = 17119;



        /// <summary>
        /// 生产退料单浏览（本人）．
        /// </summary>
        public const int RTSBrowser = 17120;


        /// <summary>
        /// 生产退料单管理（新增,修改,删除）
        /// </summary>
        public const int RTSMaintain = 17121;

        /// <summary>
        /// 生产退料单提交
        /// </summary>
        public const int RTSPresent = 17122;

        /// <summary>
        /// 生产退料单作废．
        /// </summary>
        public const int RTSCancel = 17123;

        /// <summary>
        /// 生产退料单审批．
        /// </summary>
        public const int RTSFirstAudit = 17124;


        /// <summary>
        /// 生产退料单二级审批．
        /// </summary>
        public const int RTSSecondAudit = 17125;

        /// <summary>
        /// 生产退料单三级审批．
        /// </summary>
        public const int RTSThirdAudit = 17126;

        /// <summary>
        /// 生产退料单收料
        /// </summary>
       // public const int RTSDraw = 17127;

        /// <summary>
        /// 报废单浏览（本人）．
        /// </summary>
        public const int SCRBrowser = 17128;


        /// <summary>
        /// 报废单管理（新增,修改,删除）
        /// </summary>
        public const int SCRMaintain = 17129;

        /// <summary>
        /// 报废单提交
        /// </summary>
        public const int SCRPresent = 17130;

        /// <summary>
        /// 报废单作废．
        /// </summary>
        public const int SCRCancel = 17131;

        /// <summary>
        /// 报废单审批．
        /// </summary>
        public const int SCRFirstAudit = 17132;


        /// <summary>
        /// 报废单审批．
        /// </summary>
        public const int SCRSecondAudit = 17133;

        /// <summary>
        /// 报废单三级审批．
        /// </summary>
        public const int SCRThirdAudit = 17134;

        /// <summary>
        /// 收料浏览．
        /// </summary>
        public const int StockInBrowse = 17135;

        /// <summary>
        /// 收料．
        /// </summary>
        public const int StockIn = 17136;

        /// <summary>
        /// 发料浏览．
        /// </summary>
        public const int StockOutBorwse = 17137;

        /// <summary>
        /// 发料．
        /// </summary>
        public const int StockOut = 17138;

        /// <summary>
        /// 库存查询．
        /// </summary>
        public const int StockBrowser = 17139;

        /// <summary>
        /// 原材料收发浏览．
        /// </summary>
        public const int YCLIO = 17140;

        /// <summary>
        /// 采购员浏览
        /// </summary>
        public const int BuyerBrowse = 17141;

        /// <summary>
        /// 采购员管理
        /// </summary>
        public const int BuyerMaintain = 17142;

       
       

        /// <summary>
        /// 物料的单价
        /// </summary>
        public const int RosPrice = 17143;


        /// <summary>
        /// 采购申请单本人浏览．
        /// </summary>
        public const int ROSBrowserByDept = 17144;

        /// <summary>
        /// 物料需求单浏览(部门）．
        /// </summary>
        public const int MRPBrowserByDept = 17145;

        /// <summary>
        /// 采购计划浏览（部门）．
        /// </summary>
        public const int PPBrowserByDept = 17146;

        /// <summary>
        /// 采购订单浏览（部门）．
        /// </summary>
        public const int POBrowserByDept = 17147;

        /// <summary>
        /// 采购退货单浏览（部门）．
        /// </summary>
        public const int RTVBrowserByDept = 17148;


        /// <summary>
        /// 委外加工收料单浏览（部门）．
        /// </summary>
        public const int WINWBrowserByDept = 17149;

        /// <summary>
        /// 原材料收发管理．
        /// </summary>
        public const int YCLIOMaintain = 17150;

        /// <summary>
        /// 采购收料付款单浏览（部门）
        /// </summary>
        public const int PayBrowserByDept = 17151;

        /// <summary>
        /// 采购撤销单浏览( 部门)．
        /// </summary>
        public const int CancelBrowserByDept = 17152;

        /// <summary>
        /// 委外加工申请单浏览(部门)．
        /// </summary>
        public const int WTOWBrowserByDept = 17153;

        /// <summary>
        /// 采购收料单浏览（部门）．
        /// </summary>
        public const int BORBrowserByDept = 17154;


        /// <summary>
        /// 领料单浏览(部门）．
        /// </summary>
        public const int DRWBrowserByDept = 17155;



        /// <summary>
        /// 生产退料单浏览（部门）．
        /// </summary>
        public const int RTSBrowserByDept = 17156;

        /// <summary>
        /// 报废单浏览（部门）．
        /// </summary>
        public const int SCRBrowserByDept = 17157;


        /// <summary>
        /// 采购收料单发票号修改．
        /// </summary>
        public const int BORUpdateInvoice = 17158;

        /// <summary>
        /// 未付款发票．
        /// </summary>
        public const int TodoWUCNoPayed = 17171;

        /// <summary>
        /// 领导审批．
        /// </summary>
        public const int Anothertodo = 17172;

        /// <summary>
        /// 小工具．
        /// </summary>
        public const int AdminTool = 17173;


        /// <summary>
        /// 物料信息中的平均单价
        /// </summary>
        public const int CstPrice = 17174;


        /// <summary>
        /// 采购收料单的收料
        /// </summary>
        //public const int BorDraw = 17175;

        
        /// <summary>
        /// 采购单查看全厂
        /// </summary>
        public const int RosBrowseALL = 17178;

        /// <summary>
        /// 物料需求单查看全厂
        /// </summary>
        public const int MRPBrowseALL = 17179;


        /// <summary>
        /// 采购计划查看全厂
        /// </summary>
        public const int PPBrowseALL = 17180;

        /// <summary>
        /// 采购订单查看全厂
        /// </summary>
        public const int POBrowseALL = 17181;

        /// <summary>
        /// 采购收料查看全厂
        /// </summary>
        public const int BORBrowseALL = 17182;


        /// <summary>
        /// 采购退料单查看全厂
        /// </summary>
        public const int RTVBrowseALL = 17183;


        /// <summary>
        /// 委外加工申请单查看全厂
        /// </summary>
        public const int WTOWBrowseALL = 17184;

        /// <summary>
        /// 委外加工收料单查看全厂
        /// </summary>
        public const int WINWBrowseALL = 17185;

        /// <summary>
        /// 采购收料付款单查看全厂
        /// </summary>
        public const int PPAYBrowseALL = 17186;

        /// <summary>
        /// 采购撤消单查看全厂
        /// </summary>
        public const int CancelBrowseALL = 17187;

        /// <summary>
        /// 领料单查看全厂
        /// </summary>
        public const int DRWBrowseALL = 17188;

        /// <summary>
        /// 生产退料查看全厂
        /// </summary>
        public const int RTSBrowseALL = 17189;

        /// <summary>
        /// 报废单查看全厂
        /// </summary>
        public const int SCRBrowseALL = 17190;
        
        /// <summary>
        /// 所有的发票
        /// </summary>
        public const int WUCNOPayedAll = 17191;
        
        /// <summary>
        /// 采购计划单价
        /// </summary>
        public const int PPCstPrice = 17192;

        /// <summary>
        /// 采购订单单价
        /// </summary>
        public const int POCstPrice = 17193;

        /// <summary>
        /// 月度需求单单价
        /// </summary>
        public const int MRPCstPrice = 17194;

        /// <summary>
        /// 采购收料单价
        /// </summary>
        public const int BORCstPrice = 17195;

        /// <summary>
        /// 采购退料单价
        /// </summary>
        public const int PRTVCstPrice = 17196;

        /// <summary>
        /// 采购撤消单价
        /// </summary>
        public const int CancelCstPrice = 17197;

        /// <summary>
        /// 领料单单价
        /// </summary>
        public const int DRWCstPrice = 17198;

        /// <summary>
        /// 生产退料单价
        /// </summary>
        public const int RTSCstPrice = 17199;

        /// <summary>
        /// 报废单单价
        /// </summary>
        public const int SCRCstPrice = 17200;

        /// <summary>
        /// 物料查询单价
        /// </summary>
        public const int QueryCstPrice = 17201;

        /// <summary>
        /// 委外收料单单价
        /// </summary>
        public const int WINWCstPrice = 17202;

        /// <summary>
        /// 委外申请单单价
        /// </summary>
        public const int WTOWCstPrice = 17203;
        
        /// <summary>
        /// 账外仓库查看权限
        /// </summary>
        public const int StockAnalysisZero = 17204;

        public const int InventoryBrowser = 17205;
        public const int InventoryMaintain = 17206;
        public const int InventoryProfitBrowser = 17207;
        public const int InventoryProfitMaintain = 17208;
        public const int InventoryProfitFirstAudit = 17209;
        public const int InventoryProfitSecondAudit = 17210;
        public const int InventoryProfitThirdAudit = 17211;
        
        public const int InventoryShortageBrowser = 17212;
        public const int InventoryShortageMaintain = 17213;
        public const int InventoryShortageFirstAudit = 17214;
        public const int InventoryShortageSecondAudit = 17215;
        public const int InventoryShortageThirdAudit = 17216;
        
    }




    #endregion

    
}
