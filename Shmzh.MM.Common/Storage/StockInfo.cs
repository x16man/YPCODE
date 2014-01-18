using System;
namespace Shmzh.MM.Common
{
    public class StockInfo
    {
        #region Property

        public decimal Id { get; set; }

        public int EntryNo { get; set; }

        public string EntryCode { get; set; }

        public int DocCode { get; set; }

        public string DocName { get; set; }

        public string PrvCode { get; set; }

        public string PrvName { get; set; }

        public string AcceptCode { get; set; }

        public string AcceptName { get; set; }

        public DateTime AcceptDate { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public string ItemSpec { get; set; }

        public string ItemUnit { get; set; }

        public string ItemUnitName { get; set; }

        public decimal ItemNum { get; set; }

        public decimal ItemPrice { get; set;}

        public decimal ItemMoney { get; set; }

        public string BatchCode { get; set; }

        public string StoCode { get; set; }

        public string StoName { get; set; }

        public int ConCode { get; set; }

        public string ConName { get; set; }

        public string BuyerCode { get; set; }

        public string BuyerName { get; set; }

        public DateTime TRFDate { get; set; }

        public string SrcStoCode { get; set; }

        public string SrcStoName { get; set; }

        public int SrcConCode { get; set; }

        public string SrcConName { get; set; }

        public string ReqDept { get; set; }

        public string ReqDeptName { get; set; }
        #endregion
    }
}