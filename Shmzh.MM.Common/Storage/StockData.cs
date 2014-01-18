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
    using System;
    using System.Data;
    using System.Runtime.Serialization; 
    /// <summary>
    /// StockData 的摘要说明。
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [SerializableAttribute] 
    public class StockData : DataSet
    {
        #region 成员变量
        public const string NOOBJECT = "";

        public const string WSTK_TABLE = "WSTK";
        public const string WSTKWARNING_TABLE = "WSTKWARNING";
        public const string PKID_FIELD = "PKID";
        public const string ENTRYNO_FIELD = "EntryNo";
        public const string ENTRYCODE_FIELD = "EntryCode";
        public const string DOCCODE_FIELD = "DocCode";
        public const string DOCNAME_FIELD = "DocName";
        public const string PRVCODE_FIELD = "PrvCode";
        public const string PRVNAME_FIELD = "PrvName";
        public const string ACCEPTCODE_FIELD = "AcceptCode";
        public const string ACCEPTNAME_FIELD = "AcceptName";
        public const string NEWCODE_FIELD = "NewCode";
        public const string ITEMCODE_FIELD = "ItemCode";
        public const string ITEMNAME_FIELD = "ItemName";
        public const string ITEMSPEC_FIELD = "ItemSpecial";
        public const string ITEMUNIT_FIELD = "ItemUnit";
        public const string ITEMUNITNAME_FIELD = "ItemUnitName";
        public const string ITEMLOWNUM_FIELD = "ItemLowNum";
        public const string ITEMUPPNUM_FIELD = "ItemUppNum";
        public const string ITEMNUM_FIELD = "ItemNum";
        public const string ITEMPRICE_FIELD = "ItemPrice";
        public const string ITEMMONEY_FIELD = "ItemMoney";
        public const string BATCHCODE_FIELD = "BatchCode";
        public const string STOCODE_FIELD = "StoCode";
        public const string STONAME_FIELE = "StoName";
        public const string CONCODE_FIELD = "ConCode";
        public const string CONNAME_FIELD = "ConName";
        public const string BUYERCODE_FIELD = "BuyerCode";
        public const string BUYERNAME_FIELD = "BuyerName";
        #endregion

        #region 属性
        /// <summary>
        /// 报警库存的记录数。
        /// </summary>
        public int WarningCount
        {
            get { return this.Tables[StockData.WSTKWARNING_TABLE].Rows.Count; }
        }
        /// <summary>
        /// 库存记录数。
        /// </summary>
        public int Count
        {
            get { return this.Tables[StockData.WSTK_TABLE].Rows.Count; }
        }
        #endregion

        #region 私有方法
        private void BuildDataTable() 
        {
            // 创建　Sto 表．
            DataTable table   = new DataTable(StockData.WSTK_TABLE);
            //添加字段。
            table.Columns.Add(StockData.PKID_FIELD, typeof(System.Int64));
            table.Columns.Add(StockData.ENTRYNO_FIELD, typeof(System.Int32));
            table.Columns.Add(StockData.ENTRYCODE_FIELD,typeof(System.String));
            table.Columns.Add(StockData.DOCCODE_FIELD, typeof(System.Int32));
            table.Columns.Add(StockData.DOCNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.PRVCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.PRVNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ACCEPTCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ACCEPTNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.NEWCODE_FIELD, typeof (System.String));
            table.Columns.Add(StockData.ITEMCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMSPEC_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMUNIT_FIELD, typeof(System.Int32));
            table.Columns.Add(StockData.ITEMUNITNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMNUM_FIELD, typeof(System.Decimal));
            table.Columns.Add(StockData.ITEMPRICE_FIELD, typeof(System.Decimal));
            table.Columns.Add(StockData.ITEMMONEY_FIELD, typeof(System.Decimal));
            table.Columns.Add(StockData.BATCHCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.STOCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.STONAME_FIELE, typeof(System.String));
            table.Columns.Add(StockData.CONCODE_FIELD, typeof(System.Int32));
            table.Columns.Add(StockData.CONNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.BUYERCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.BUYERNAME_FIELD, typeof(System.String));
            //向数据集中增加DataTable。
            this.Tables.Add(table);
            //创建库存报警表。
            table   = new DataTable(StockData.WSTKWARNING_TABLE);
            table.Columns.Add(StockData.NEWCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMCODE_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMSPEC_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMUNIT_FIELD, typeof(System.Int32));
            table.Columns.Add(StockData.ITEMUNITNAME_FIELD, typeof(System.String));
            table.Columns.Add(StockData.ITEMLOWNUM_FIELD, typeof(System.Decimal));
            table.Columns.Add(StockData.ITEMUPPNUM_FIELD, typeof(System.Decimal));

            table.Columns.Add(StockData.ITEMNUM_FIELD, typeof(System.Decimal));
            this.Tables.Add(table);
        }
        #endregion

        #region 构造函数
        private StockData(SerializationInfo info, StreamingContext context) : base(info, context) 
        {		
        }
        public StockData()
        {
            BuildDataTable();
        }

        #endregion
    }
}
