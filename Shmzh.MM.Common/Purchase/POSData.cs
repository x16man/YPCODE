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
    /// POSData 的摘要说明。
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [Serializable]
    public class POSData : DataSet
    {
        #region 成员变量
        public const string VPOS_VIEW = "ViewPurchaseOrderSource";
        public const string ENTRYNO_FIELD = "SourceEntry";
        public const string ENTRYCODE_FIELD = "EntryCode";
        public const string DOCCODE_FIELD = "SourceDocCode";
        public const string DOCNAME_FIELD = "DocName";
        public const string ENTRYSTATE_FIELD = "EntryState";
        public const string ENTRYDATE_FIELD = "EntryDate";
        public const string ENTRYSTATENAME_FIELD = "EntryStateName";
        public const string REQDEPT_FIELD = "ReqDept";
        public const string REQDEPTNAME_FIELD = "ReqDeptName";
        public const string PROPOSERCODE_FIELD = "ProposerCode";
        public const string PROPOSER_FIELD = "Proposer";
        public const string REQREASONCODE_FIELD = "ReqReasonCode";
        public const string REQREASON_FIELD = "ReqReason";
        public const string SERIALNO_FIELD = "SourceSerialNo";
        public const string NEWCODE_FIELD = "NewCode";
        public const string ITEMCODE_FIELD = "ItemCode";
        public const string ITEMNAME_FIELD = "ItemName";
        public const string ITEMSPECIAL_FIELD = "ItemSpecial";
        public const string ITEMUNIT_FIELD = "ItemUnit";
        public const string ITEMUNITNAME_FIELD = "ItemUnitName";
        public const string CATCODE_FIELD = "CatCode";
        public const string CATNAME_FIELD = "CatName";
        public const string ITEMPRICE_FIELD = "ItemPrice";
        public const string ITEMNUM_FIELD = "ItemNum";
        public const string ITEMMONEY_FIELD = "ItemMoney";
        public const string ITEMLACKNUM_FIELD = "ItemLackNum";
        public const string REQDATE_FIELD = "ReqDate";
        public const string PKID_FIELD = "PKID";
        #endregion

        #region 私有方法
        private void BuildDataTables()
        {
            DataTable table   = new DataTable(VPOS_VIEW);
            
            DataColumnCollection columns = table.Columns;
            
            columns.Add( ENTRYNO_FIELD, typeof(System.Int32));
            columns.Add( ENTRYCODE_FIELD, typeof(System.String));
            columns.Add( DOCCODE_FIELD, typeof(System.Int16));
            columns.Add( DOCNAME_FIELD, typeof(System.String));
            columns.Add( ENTRYSTATE_FIELD, typeof(System.String));
            columns.Add( ENTRYDATE_FIELD, typeof(System.DateTime));
            columns.Add( ENTRYSTATENAME_FIELD, typeof(System.String));
            columns.Add( REQDEPT_FIELD, typeof(System.String));
            columns.Add( REQDEPTNAME_FIELD, typeof(System.String));
            columns.Add( PROPOSERCODE_FIELD, typeof(System.String));
            columns.Add( PROPOSER_FIELD, typeof(System.String));
            columns.Add( REQREASONCODE_FIELD, typeof(System.String));
            columns.Add( REQREASON_FIELD, typeof(System.String));
            columns.Add( SERIALNO_FIELD, typeof(System.Int16));
            columns.Add(NEWCODE_FIELD, typeof (String));
            columns.Add( ITEMCODE_FIELD, typeof(System.String));
            columns.Add( ITEMNAME_FIELD, typeof(System.String));
            columns.Add( ITEMSPECIAL_FIELD, typeof(System.String));
            columns.Add( ITEMUNIT_FIELD, typeof(System.Int16));
            columns.Add( ITEMUNITNAME_FIELD, typeof(System.String));
            columns.Add( CATCODE_FIELD, typeof(System.Int16));
            columns.Add( CATNAME_FIELD, typeof(System.String));
            columns.Add( ITEMPRICE_FIELD, typeof(System.Decimal));
            columns.Add( ITEMNUM_FIELD, typeof(System.Decimal));
            columns.Add( ITEMMONEY_FIELD, typeof(System.Decimal));
            columns.Add( ITEMLACKNUM_FIELD, typeof(System.Decimal));
            columns.Add( REQDATE_FIELD, typeof(System.DateTime));
            columns.Add(PKID_FIELD,typeof(System.String));
            this.Tables.Add(table);
        }
        #endregion

        #region 构造函数
        private POSData(SerializationInfo info, StreamingContext context) : base(info, context) 
        {		
        }
        public POSData()
        {
            this.BuildDataTables();
        }
        #endregion
    }
}
