using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Shmzh.MM.Common.Storage;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Storage
{
    public class InventoryShortageDetails
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private method
        private InventoryShortageDetailInfo ConvertToInventoryShortageDetailInfo(IDataRecord dr)
        {
            var obj = new InventoryShortageDetailInfo();
                          
            obj.EntryNo = (int) dr["EntryNo"];
            obj.SerialNo = short.Parse( dr["SerialNo"].ToString());
            obj.ItemCode = dr["ItemCode"].ToString();
            obj.ItemName = dr["ItemName"].ToString();
            obj.ItemSpec = dr["ItemSpec"] == DBNull.Value ? string.Empty : dr["ItemSpec"].ToString();
            obj.ItemUnit = (short) dr["ItemUnit"];
            obj.ItemUnitName = dr["ItemUnitName"].ToString();
            obj.ItemPrice = dr["ItemPrice"] == DBNull.Value ? 0 : (decimal) dr["ItemPrice"];
            obj.ItemNum = dr["ItemNum"] == DBNull.Value ? 0 : (decimal) dr["ItemNum"];
            obj.ItemMoney = dr["ItemMoney"] == DBNull.Value ? 0 : (decimal) dr["ItemMoney"];
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();
            obj.CurrentStockNum = dr["CurrentStockNum"] == DBNull.Value ? 0 : decimal.Parse(dr["CurrentStockNum"].ToString());
            obj.CarryingAmount = dr["CarryingAmount"]==DBNull.Value?0:decimal.Parse(dr["CarryingAmount"].ToString());
            obj.InventoryAmount = dr["InventoryAmount"]==DBNull.Value?0:decimal.Parse(dr["InventoryAmount"].ToString());
                         
            return obj;
        }
        #endregion

        #region Method
        public bool Insert(InventoryShortageDetailInfo obj)
        {
            return Insert(null, obj);
        }
        public bool Insert(DbTransaction trans, InventoryShortageDetailInfo obj)
        {
            var sqlStatement = @"Insert Into InventoryShortageDetail(EntryNo,SerialNo,ItemCode,ItemName,ItemSpec,ItemUnit,ItemUnitName,ItemPrice,ItemNum,ItemMoney,Remark,CarryingAmount,InventoryAmount)
Values (@EntryNo,@SerialNo,@ItemCode,@ItemName,@ItemSpec,@ItemUnit,@ItemUnitName,@ItemPrice,@ItemNum,@ItemMoney,@Remark,@CarryingAmount,@InventoryAmount)";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = obj.EntryNo},
                                new SqlParameter("@SerialNo",SqlDbType.SmallInt){Value = obj.SerialNo},
                                new SqlParameter("@ItemCode",SqlDbType.NVarChar,20){Value = obj.ItemCode},
                                new SqlParameter("@ItemName",SqlDbType.NVarChar,50){Value = obj.ItemName},
                                new SqlParameter("@ItemSpec",SqlDbType.NVarChar,30){Value = string.IsNullOrEmpty(obj.ItemSpec)?DBNull.Value:(object)obj.ItemSpec},
                                new SqlParameter("@ItemUnit",SqlDbType.SmallInt){Value = obj.ItemUnit},
                                new SqlParameter("@ItemUnitName",SqlDbType.NVarChar,20){Value = obj.ItemUnitName},
                                new SqlParameter("@ItemPrice",SqlDbType.Decimal){Value = obj.ItemPrice},
                                new SqlParameter("@ItemNum",SqlDbType.Decimal){Value = obj.ItemNum},
                                new SqlParameter("@ItemMoney",SqlDbType.Decimal){Value = obj.ItemMoney},
                                new SqlParameter("@Remark",SqlDbType.NVarChar,100){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new SqlParameter("@CarryingAmount",SqlDbType.Decimal){Value=obj.CarryingAmount},
                                new SqlParameter("@InventoryAmount",SqlDbType.Decimal){Value=obj.InventoryAmount},
                            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                {
                    SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.Text, sqlStatement, parms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }
        public bool Update(InventoryShortageDetailInfo obj)
        {
            return Update(null, obj);
        }
        public bool Update(DbTransaction trans, InventoryShortageDetailInfo obj)
        {
            var sqlStatement = @"
Update  InventoryShortageDetail 
Set     ItemCode = @ItemCode
,       ItemName = @ItemName
,       ItemSpec = @ItemSpec
,       ItemUnit = @ItemUnit
,       ItemUnitName = @ItemUnitName
,       ItemPrice = @ItemPrice
,       ItemNum = @ItemNum
,       ItemMoney = @ItemMoney
,       Remark = @Remark
,       CarryingAmount = @CarryingAmount
,       InventoryAmount = @InventoryAmount
Where   EntryNo = @EntryNo And
        SerialNo = @SerialNo";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = obj.EntryNo},
                                new SqlParameter("@SerialNo",SqlDbType.SmallInt){Value = obj.SerialNo},
                                new SqlParameter("@ItemCode",SqlDbType.NVarChar,20){Value = obj.ItemCode},
                                new SqlParameter("@ItemName",SqlDbType.NVarChar,50){Value = obj.ItemName},
                                new SqlParameter("@ItemSpec",SqlDbType.NVarChar,30){Value = string.IsNullOrEmpty(obj.ItemSpec)?DBNull.Value:(object)obj.ItemSpec},
                                new SqlParameter("@ItemUnit",SqlDbType.SmallInt){Value = obj.ItemUnit},
                                new SqlParameter("@ItemUnitName",SqlDbType.NVarChar,20){Value = obj.ItemUnitName},
                                new SqlParameter("@ItemPrice",SqlDbType.Decimal){Value = obj.ItemPrice},
                                new SqlParameter("@ItemNum",SqlDbType.Decimal){Value = obj.ItemNum},
                                new SqlParameter("@ItemMoney",SqlDbType.Decimal){Value = obj.ItemMoney},
                                new SqlParameter("@Remark",SqlDbType.NVarChar,100){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new SqlParameter("@CarryingAmount",SqlDbType.Decimal){Value=obj.CarryingAmount},
                                new SqlParameter("@InventoryAmount",SqlDbType.Decimal){Value=obj.InventoryAmount},
                            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }
        public bool Delete(InventoryShortageDetailInfo obj)
        {
            return Delete(obj.EntryNo, obj.SerialNo);
        }
        public bool Delete(int entryNo,short serialNo)
        {
            var sqlStatement = "Delete From InventoryShortageDetail Where EntryNo = @EntryNo And SerialNo = @SerialNo";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo},
                                new SqlParameter("@SerialNo",SqlDbType.SmallInt){Value = serialNo},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }
        public bool Delete(DbTransaction trans, int entryNo)
        {
            var sqlStatement = "Delete From InventoryShortageDetail Where EntryNo = @EntryNo";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public InventoryShortageDetailInfo GetByEntryNoAndSerialNo(int entryNo,short serialNo)
        {
            var sqlStatement = "Select B.*,dbo.GetStockSumByStoCodeAndItem(A.StoCode,B.ItemCode,B.ItemName,B.ItemSpec) As CurrentStockNum From A.InventoryShortage A,InventoryShortageDetail B Where A.EntryNo = B.EntryNo And A.EntryNo = @EntryNo And B.SerialNo = @SerialNo";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo}, 
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt) {Value = serialNo},
                            };
            InventoryShortageDetailInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToInventoryShortageDetailInfo(dr);
                break;
            }
            dr.Close();
            return obj;

        }
        public List<InventoryShortageDetailInfo> GetByEntryNo(int entryNo)
        {
            var sqlStatement = "Select B.* ,dbo.GetStockSumByStoCodeAndItem(A.StoCode,B.ItemCode,B.ItemName,B.ItemSpec) As CurrentStockNum From InventoryShortage A,InventoryShortageDetail B Where A.EntryNo = B.EntryNo And A.EntryNo = @EntryNo Order By SerialNo";
            var parms = new[] {new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo}};
            var objs = new List<InventoryShortageDetailInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToInventoryShortageDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public List<InventoryShortageDetailInfo> GetByInventoryId(int id)
        {
            var sqlStatement = @"
Select 0 as EntryNo,0 As SerialNo,B.ItemCode,C.CnName As ItemName,C.Special As ItemSpec
,       D.Code As ItemUnit,D.Description As ItemUnitName
,       C.CstPrice as ItemPrice
,       (B.CarryingAmount-B.InventoryAmount) As ItemNum
,       (C.CstPrice*(B.CarryingAmount-B.InventoryAmount)) as ItemMoney
,       null as Remark
,       dbo.GetStockSumByStoCodeAndItem(A.StoCode,B.ItemCode,C.CnName,C.Special) As CurrentStockNum
,       B.CarryingAmount,B.InventoryAmount
From    Inventory A,InventoryDetail B,WITM C,WUNT D
Where   A.Id = @Id And
        A.Id = B.ParentId And
        B.InventoryAmount < B.CarryingAmount And 
        B.ItemCode = C.Code And
        C.UnitCode = D.Code ";

            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            var objs = new List<InventoryShortageDetailInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToInventoryShortageDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public bool Draw(DbTransaction trans, InventoryShortageDetailInfo obj)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = obj.EntryNo},
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt) {Value = obj.SerialNo},
                                new SqlParameter("@Ret",SqlDbType.Int){Direction=ParameterDirection.ReturnValue},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.StoredProcedure, "InventoryStockOut", parms);
                Logger.Info(string.Format("InventoryShortage Draw {0}", parms[2].Value));
                return (int)parms[2].Value == -1 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }
        #endregion
    }
}