using System;
using System.Data;
using System.Collections;
using System.Runtime.Serialization;

namespace Shmzh.MM.Common
{
    /// <summary>
    /// 已发料的领料单明细视图实体.
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [SerializableAttribute]
    public class ViewOutedWDRWData : DataSet
    {
        #region 成员变量
        public const string ViewOutedWDRW_Table = "ViewOutedWDRW";
        public const string EntryNo_Field = "EntryNo";
        public const string ReqReasonCode_Field = "ReqReasonCode";
        public const string ReqReason_Field = "ReqReason";
        public const string DrawDate_Field = "DrawDate";
        public const string SerialNo_Field = "SerialNo";
        public const string ItemCode_Field = "ItemCode";
        public const string ItemName_Field = "ItemName";
        public const string ItemSpec_Field = "ItemSpecial";
        public const string UnitCode_Field = "ItemUnit";
        public const string UnitName_Field = "ItemUnitName";
        public const string ItemPrice_Field = "ItemPrice";
        public const string ItemNum_Field = "ItemNum";
        public const string ItemMoney_Field = "ItemMoney";
        public const string KM1_Field = "KM1";
        public const string KM2_Field = "KM2";
        public const string KM3_Field = "KM3";
        public const string KM4_Field = "KM4";
        #endregion

        #region 属性
        /// <summary>
        /// 计数.
        /// </summary>
        public int Count
        {
            get { return this.Tables[ViewOutedWDRWData.ViewOutedWDRW_Table].Rows.Count; }
        }
        #endregion


        #region 私有方法
        /// <summary>
        /// 构建数据表.
        /// </summary>
        private void BuildDataTables()
        {
            DataTable table = new DataTable(ViewOutedWDRWData.ViewOutedWDRW_Table);

            DataColumnCollection columns = table.Columns;
            columns.Add(EntryNo_Field, typeof(System.Int32));
            columns.Add(ReqReasonCode_Field, typeof(System.String));
            columns.Add(ReqReason_Field, typeof(System.String));
            columns.Add(DrawDate_Field, typeof(System.DateTime));
            columns.Add(SerialNo_Field, typeof(System.Int16));
            columns.Add(ItemCode_Field, typeof(System.String));
            columns.Add(ItemName_Field, typeof(System.String));
            columns.Add(ItemSpec_Field, typeof(System.String));
            columns.Add(UnitCode_Field, typeof(System.Int16));
            columns.Add(UnitName_Field, typeof(System.String));
            columns.Add(ItemPrice_Field, typeof(System.Decimal));
            columns.Add(ItemNum_Field, typeof(System.Decimal));
            columns.Add(ItemMoney_Field, typeof(System.Decimal));
            columns.Add(KM1_Field, typeof(System.String));
            columns.Add(KM2_Field, typeof(System.String));
            columns.Add(KM3_Field, typeof(System.String));
            columns.Add(KM4_Field, typeof(System.String));

            this.Tables.Add(table);

        }
        #endregion

        #region 构造函数
        private ViewOutedWDRWData(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        public ViewOutedWDRWData()
        {
            this.BuildDataTables();
        }
        #endregion
    }
}
