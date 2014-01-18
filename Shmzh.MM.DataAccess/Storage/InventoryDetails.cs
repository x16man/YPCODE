using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Shmzh.MM.Common.Storage;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Storage
{
    public class InventoryDetails
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region private method
        private InventoryDetailInfo ConvertToInventoryDetailInfo(IDataRecord dr)
        {
            return new InventoryDetailInfo
                       {
                           Id = (long)dr["Id"],
                           ParentId = (int)dr["ParentId"],
                           ConCode = (int)dr["ConCode"],
                           ConName = dr["ConName"].ToString(),
                           ItemCode = dr["ItemCode"].ToString(),
                           ItemName = dr["ItemName"].ToString(),
                           ItemSpec =  dr["ItemSpec"]==DBNull.Value?string.Empty:dr["ItemSpec"].ToString(),
                           ItemUnit = dr["ItemUnit"]==DBNull.Value ?string.Empty:dr["ItemUnit"].ToString(),
                           CarryingAmount = (decimal)dr["CarryingAmount"],
                           InventoryAmount = dr["InventoryAmount"]==DBNull.Value?0:(decimal)dr["InventoryAmount"],
                       };
        }
        #endregion

        #region Method

        public InventoryDetailInfo GetById(long id)
        {
            var sqlStatement = @"Select A.*,B.Description As StoName,C.Description As ConName,D.CnName AS ItemName,D.Special As ItemSpec,E.Description As ItemUnit
                                 From   InventoryDetail A
                                        INNER JOIN WSTO B
                                 ON     A.StoCode = B.Code
                                        INNER JOIN WCON C
                                 ON     A.ConCode = C.Code
                                        INNER JOIN WITM D
                                 ON     A.ItemCode = D.Code
                                        INNER JOIN WUNT E 
                                 ON     D.UnitCode = E.Code
                                 Where  A.Id = @Id";
            var parms = new[] {new SqlParameter("@Id", SqlDbType.BigInt) {Value = id}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            InventoryDetailInfo obj = null;

            while (dr.Read())
            {
                obj = ConvertToInventoryDetailInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        public ListBase<InventoryDetailInfo> GetByParentId(int parentId)
        {
            var sqlStatement = @"Select A.*,C.Description As ConName,D.CnName AS ItemName,D.Special As ItemSpec,E.Description As ItemUnit
                                 From   InventoryDetail A
                                        INNER JOIN WCON C
                                 ON     A.ConCode = C.Code
                                        INNER JOIN WITM D
                                 ON     A.ItemCode = D.Code
                                        INNER JOIN WUNT E 
                                 ON     D.UnitCode = E.Code
                                 Where  A.ParentId = @ParentId
                                 Order By C.Description,A.ItemCode";
            var parms = new[] { new SqlParameter("@ParentId", SqlDbType.BigInt) { Value = parentId } };
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            var objs = new ListBase<InventoryDetailInfo>();

            while (dr.Read())
            {
                objs.Add( ConvertToInventoryDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public bool CopyFromCurrentStock(int parentId)
        {
            return CopyFromCurrentStock(null, parentId);
        }
        public bool CopyFromCurrentStock(DbTransaction trans, int parentId)
        {
            var sqlStatement = "Insert Into InventoryDetail (ParentId,ConCode,ItemCode,CarryingAmount) Select @ParentId,WSTK.ConCode,WSTK.ItemCode,Sum(WSTK.ItemNum) From WSTK,Inventory Where WSTK.StoCode = Inventory.StoCode And Inventory.Id = @ParentId Group By WSTK.ConCode,WSTK.ItemCode";
            var parms = new[] {new SqlParameter("@ParentId", SqlDbType.Int) {Value = parentId}};
            try
            {
                if(trans == null)
                {
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery((SqlTransaction) trans, CommandType.Text, sqlStatement, parms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public long Insert(InventoryDetailInfo obj)
        {
            return Insert(null, obj);
        }
        public long Insert(DbTransaction trans, InventoryDetailInfo obj)
        {
            var sqlStatement = @"Insert Into InventoryDetail (ParentId,ConCode,ItemCode,CarryingAmount,InventoryAmount) 
                                 Values (@ParentId,@ConCode,@ItemCode,@CarryingAmount,@InventoryAmount) 
                                 Set @Id=SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.BigInt) {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ParentId",SqlDbType.Int){Value = obj.ParentId},
                                new SqlParameter("@ConCode", SqlDbType.Int){Value = obj.ConCode},
                                new SqlParameter("@ItemCode", SqlDbType.NVarChar,20){Value = obj.ItemCode},
                                new SqlParameter("@CarryingAmount", SqlDbType.Decimal){Value = obj.CarryingAmount},
                                new SqlParameter("@InventoryAmount",SqlDbType.Decimal){Value = obj.InventoryAmount},
                            };
            try
            {
                if (trans == null)
                {
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                    
                }
                else
                {
                    SqlHelper.ExecuteNonQuery((SqlTransaction) trans, CommandType.Text, sqlStatement, parms);
                }
                obj.Id = (long)parms[0].Value;
                return obj.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return 0;
            }
        }
        public bool Update(InventoryDetailInfo obj)
        {
            return Update(null, obj);
        }
        public bool Update(DbTransaction trans, InventoryDetailInfo obj)
        {
            var sqlStatement = @"
Update  InventoryDetail 
Set     ParentId = @ParentId
,       ConCode = @ConCode
,       ItemCode = @ItemCode
,       CarryingAmount = @CarryingAmount
,       InventoryAmount = @InventoryAmount
Where   Id = @Id";
 
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.BigInt) {Value = obj.Id},
                                new SqlParameter("@ParentId",SqlDbType.Int){Value = obj.ParentId},
                                new SqlParameter("@ConCode", SqlDbType.Int){Value = obj.ConCode},
                                new SqlParameter("@ItemCode", SqlDbType.NVarChar,20){Value = obj.ItemCode},
                                new SqlParameter("@CarryingAmount", SqlDbType.Decimal){Value = obj.CarryingAmount},
                                new SqlParameter("@InventoryAmount",SqlDbType.Decimal){Value = obj.InventoryAmount},
                            };
            try
            {
                if (trans == null)
                {
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);

                }
                else
                {
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public bool Delete(InventoryDetailInfo obj)
        {
            return Delete(null,obj.Id);
        }
        public bool Delete(DbTransaction trans, InventoryDetailInfo obj)
        {
            return Delete(trans, obj.Id);
        }
        public bool Delete(long id)
        {
            return Delete(null, id);
        }
        public bool Delete(DbTransaction trans, long id)
        {
            var sqlStatement = "Delete From InventoryDetail Where Id = @Id";
            var parms = new[] {new SqlParameter("@Id", SqlDbType.BigInt) {Value = id}};
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public bool Delete(int parentId)
        {
            return Delete(null, parentId);
        }
        public bool Delete(DbTransaction trans, int parentId)
        {
            var sqlStatement = "Delete From InventoryDetail Where ParentId = @ParentId";
            var parms = new[] { new SqlParameter("@ParentId", SqlDbType.BigInt) { Value = parentId } };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        #endregion
    }
}
