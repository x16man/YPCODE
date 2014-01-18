using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Shmzh.MM.Common.Storage;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Storage
{
    public class InventoryProfitDetails
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private method
        private InventoryProfitDetailInfo ConvertToInventoryProfitDetailInfo(IDataRecord dr)
        {
            var obj = new InventoryProfitDetailInfo();
                          
            obj.EntryNo = (int) dr["EntryNo"];
            obj.SerialNo = short.Parse(dr["SerialNo"].ToString());
            obj.ItemCode = dr["ItemCode"].ToString();
            obj.ItemName = dr["ItemName"].ToString();
            obj.ItemSpec = dr["ItemSpec"] == DBNull.Value ? string.Empty : dr["ItemSpec"].ToString();
            obj.ItemUnit = (short) dr["ItemUnit"];
            obj.ItemUnitName = dr["ItemUnitName"].ToString();
            obj.ItemPrice = dr["ItemPrice"] == DBNull.Value ? 0 : (decimal) dr["ItemPrice"];
            obj.ItemNum = dr["ItemNum"] == DBNull.Value ? 0 : (decimal) dr["ItemNum"];
            obj.ItemMoney = dr["ItemMoney"] == DBNull.Value ? 0 : (decimal) dr["ItemMoney"];
            obj.StoCode = dr["StoCode"] == DBNull.Value ? string.Empty : dr["StoCode"].ToString();
            obj.StoName = dr["StoName"] == DBNull.Value ? string.Empty : dr["StoName"].ToString();
            obj.ConCode = dr["ConCode"] == DBNull.Value ? 0 : (int) dr["ConCode"];
            obj.ConName = dr["ConName"] == DBNull.Value ? string.Empty : dr["ConName"].ToString();
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();
            obj.StkId = dr["StkId"] == DBNull.Value ? 0 : (decimal)dr["StkId"];
            obj.CarryingAmount = dr["CarryingAmount"] == DBNull.Value ? 0 : (decimal)dr["CarryingAmount"];
            obj.InventoryAmount = dr["InventoryAmount"] == DBNull.Value ? 0 : (decimal)dr["InventoryAmount"];
                          
            return obj;
        }
        #endregion

        #region Method
        public bool Insert(InventoryProfitDetailInfo obj)
        {
            return Insert(null, obj);
        }
        public bool Insert(DbTransaction trans, InventoryProfitDetailInfo obj)
        {
            var sqlStatement = @"Insert Into InventoryProfitDetail(EntryNo,SerialNo,ItemCode,ItemName,ItemSpec,ItemUnit,ItemUnitName,ItemPrice,ItemNum,ItemMoney,StoCode,StoName,ConCode,ConName,Remark,StkId,CarryingAmount,InventoryAmount)
Values (@EntryNo,@SerialNo,@ItemCode,@ItemName,@ItemSpec,@ItemUnit,@ItemUnitName,@ItemPrice,@ItemNum,@ItemMoney,@StoCode,@StoName,@ConCode,@ConName,@Remark,@StkId,@CarryingAmount,@InventoryAmount)";
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
                                new SqlParameter("@StoCode",SqlDbType.NVarChar,10){Value = string.IsNullOrEmpty(obj.StoCode)?DBNull.Value:(object)obj.StoCode},
                                new SqlParameter("@StoName",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.StoName)?DBNull.Value:(object)obj.StoName},
                                new SqlParameter("@ConCode",SqlDbType.Int){Value = obj.ConCode==0?DBNull.Value:(object)obj.ConCode},
                                new SqlParameter("@ConName",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.ConName)?DBNull.Value:(object)obj.ConName},
                                new SqlParameter("@Remark",SqlDbType.NVarChar,100){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new SqlParameter("@StkId",SqlDbType.Decimal){Value = obj.StkId==0?DBNull.Value:(object)obj.StkId},
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
        public bool Update(InventoryProfitDetailInfo obj)
        {
            return Update(null, obj);
        }
        public bool Update(DbTransaction trans, InventoryProfitDetailInfo obj)
        {
            var sqlStatement = @"
Update  InventoryProfitDetail 
Set     ItemCode = @ItemCode
,       ItemName = @ItemName
,       ItemSpec = @ItemSpec
,       ItemUnit = @ItemUnit
,       ItemUnitName = @ItemUnitName
,       ItemPrice = @ItemPrice
,       ItemNum = @ItemNum
,       ItemMoney = @ItemMoney
,       StoCode = @StoCode
,       StoName = @StoName
,       ConCode = @ConCode
,       ConName = @ConName
,       Remark = @Remark
,       StkId = @StkId
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
                                new SqlParameter("@StoCode",SqlDbType.NVarChar,10){Value = string.IsNullOrEmpty(obj.StoCode)?DBNull.Value:(object)obj.StoCode},
                                new SqlParameter("@StoName",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.StoName)?DBNull.Value:(object)obj.StoName},
                                new SqlParameter("@ConCode",SqlDbType.Int){Value = obj.ConCode==0?DBNull.Value:(object)obj.ConCode},
                                new SqlParameter("@ConName",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.ConName)?DBNull.Value:(object)obj.ConName},
                                new SqlParameter("@Remark",SqlDbType.NVarChar,100){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new SqlParameter("@StkId",SqlDbType.Decimal){Value = obj.StkId==0?DBNull.Value:(object)obj.StkId},
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
        public bool Delete(InventoryProfitDetailInfo obj)
        {
            return Delete(obj.EntryNo, obj.SerialNo);
        }
        public bool Delete(int entryNo,short serialNo)
        {
            var sqlStatement = "Delete From InventoryProfitDetail Where EntryNo = @EntryNo And SerialNo = @SerialNo";
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
            var sqlStatement = "Delete From InventoryProfitDetail Where EntryNo = @EntryNo";
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
        public InventoryProfitDetailInfo GetByEntryNoAndSerialNo(int entryNo,short serialNo)
        {
            var sqlStatement = "Select * From InventoryProfitDetail Where EntryNo = @EntryNo And SerialNo = @SerialNo";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo}, 
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt) {Value = serialNo},
                            };
            InventoryProfitDetailInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToInventoryProfitDetailInfo(dr);
                break;
            }
            dr.Close();
            return obj;

        }
        public List<InventoryProfitDetailInfo> GetByEntryNo(int entryNo)
        {
            var sqlStatement = "Select * From InventoryProfitDetail Where EntryNo = @EntryNo Order By SerialNo";
            var parms = new[] {new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo}};
            var objs = new List<InventoryProfitDetailInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToInventoryProfitDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public List<InventoryProfitDetailInfo> GetByInventoryId(int id)
        {
            var sqlStatement = @"
Select 0 as EntryNo,0 As SerialNo,B.ItemCode,C.CnName As ItemName,C.Special As ItemSpec
,       D.Code As ItemUnit,D.Description As ItemUnitName
,       C.CstPrice as ItemPrice
,       (B.InventoryAmount-B.CarryingAmount) As ItemNum
,       (C.CstPrice*(B.InventoryAmount-B.CarryingAmount)) as ItemMoney
,       E.Code As StoCode,E.Description As StoName
,       F.Code As ConCode,F.Description As ConName
,       null as Remark,null As StkId
,       B.CarryingAmount
,       B.InventoryAmount
From    Inventory A,InventoryDetail B,WITM C,WUNT D,WSTO E,WCON F
Where   A.Id = @Id And
        A.Id = B.ParentId And
        B.InventoryAmount > B.CarryingAmount And 
        B.ItemCode = C.Code And
        C.UnitCode = D.Code And
        A.StoCode = E.Code And
        B.ConCode = F.Code";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            var objs = new List<InventoryProfitDetailInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToInventoryProfitDetailInfo(dr));
            }
            dr.Close();
            return objs;

        }
        public bool Receive(DbTransaction trans, InventoryProfitDetailInfo obj)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = obj.EntryNo},
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt) {Value = obj.SerialNo},
                                new SqlParameter("@Ret",SqlDbType.Int){Direction=ParameterDirection.ReturnValue},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.StoredProcedure, "InventoryStockIn", parms);
                Logger.Info(string.Format("InventoryProfit Receive {0}", parms[2].Value));
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