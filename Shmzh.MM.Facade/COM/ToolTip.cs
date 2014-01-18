#region 文档信息
/******************************************************************************
**		文件:	ToolTip.cs
**		名称: 	ToolTip
**		描述: 
**
**              
**		作者:	FM.audio
**		日期: 	created by 2009-4-16 17:55:51
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-------------------------------
**    
*******************************************************************************/
#endregion


namespace Shmzh.MM.Facade
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.BusinessRules;
    using System.Data;
    using Shmzh.MM.Facade;
    using MZHCommon.Database;
    using System.Collections;
    using Shmzh.Components.SystemComponent;

    /// <summary>
    /// ToolTip
    /// </summary>
    public class ToolTip
    {
        #region 私有字段
        //RequestOfStockData oROSData;
        //DataTable oDT;
        //PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        #endregion

        #region 私有方法

        #endregion

        #region 构造函数

        #endregion

        #region 公有属性

        #endregion

        #region 公有方法
        /// <summary>
        /// 获取申购单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetROSData(int entryno)
        {
            RequestOfStockData ds = (new PurchaseSystem()).GetRequestOfStockByEntryNo(entryno);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow oDataRow = ds.Tables[0].NewRow();
                oDataRow[RequestOfStockData.PROPOSER_FIELD] = "无"; //申请人。
                oDataRow[RequestOfStockData.PROPOSERCODE_FIELD] = "无";//申请人编号。
                oDataRow[RequestOfStockData.REQDEPT_FIELD] = "无";//申请部门。
                oDataRow[RequestOfStockData.REQDEPTNAME_FIELD] = "无";//申请部门名称。
                oDataRow[RequestOfStockData.REQREASONCODE_FIELD] = "无";//申请理由。
                oDataRow[RequestOfStockData.REQREASON_FIELD] = "无";//申请理由。
                oDataRow[RequestOfStockData.REQDATE_FIELD] = "无";//要求到货日期。
                ds.Tables[0].Rows.Add(oDataRow);
            }
            return ds;
        }

        /// <summary>
        /// 获取物料需求单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetMRPData(int entryno)
        {
            PMRPData ds = (new PurchaseSystem()).GetPMRPByEntryNo(entryno);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow oDataRow = ds.Tables[0].NewRow();
                oDataRow[PMRPData.PROPOSER_FIELD] = "无"; //申请人。
                oDataRow[PMRPData.PROPOSERCODE_FIELD] = "无";//申请人编号。
                oDataRow[PMRPData.REQDEPT_FIELD] = "无";//申请部门。
                oDataRow[PMRPData.REQDEPTNAME_FIELD] = "无";//申请部门名称。
                oDataRow[PMRPData.REQREASONCODE_FIELD] = "无";//申请理由。
                oDataRow[PMRPData.REQREASON_FIELD] = "无";//申请理由。
                oDataRow[PMRPData.REQDATE_FIELD] = "无";//要求到货日期。
                ds.Tables[0].Rows.Add(oDataRow);
            }
            return ds;
        }

        /// <summary>
        /// 获取物料需求单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetPOData(int entryno)
        {
            //var oSQLServer = new SQLServer();
            //var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.PO } };
            //var oData = new DataSet();
            //oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            //return oData;
            var objs = new PurchaseSystem().GetPOByEntryNo(entryno);
            return objs;
        }

        /// <summary>
        /// 获取领料单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetDRWData(int entryno)
        {
             var oSQLServer = new SQLServer(ConnectionString.MM);
             var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.DRW } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取采购计划的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetPPData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.PP } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取采购收料单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetBORData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.BOR } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取采购退料的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetRTVData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.RTV } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取生产退料单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetRTSData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.RTS } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取收料验收单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetCBRData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.CBR } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取转库单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetTRFData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.TRF } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取报废单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetSCRData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.SCR } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            
            return oData;
        }

        /// <summary>
        /// 获取价位调整单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetADJData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.ADJ } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取批次进货单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetBRBData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.BRB } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取批次领料单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetPAYData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode",DocType.PAY } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取委外加工申请单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetWTOWData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.WTOW } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取委外加工收料单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetWINWData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.WINW } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        /// <summary>
        /// 获取采购撤销单的数据集
        /// </summary>
        /// <param name="entryno">表单id</param>
        /// <returns>object</returns>
        public object GetCANCELData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.CANCEL } };
             var oData = new DataSet();
             oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }

        public object GetInventoryProfitData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.INVENTRYPROFIT } };
            var oData = new DataSet();
            oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }
        public object GetInventoryShortageData(int entryno)
        {
            var oSQLServer = new SQLServer(ConnectionString.MM);
            var oHT = new Hashtable { { "@EntryNo", entryno }, { "@DocCode", DocType.INVENTORYSHORTAGE } };
            var oData = new DataSet();
            oData = oSQLServer.ExecSPReturnDS("GetToolTipDatabyEntryNo", oHT);
            return oData;
        }
        #endregion
    }
}
