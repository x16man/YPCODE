using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Shmzh.MM.Common.Storage;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Storage
{
    public class InventoryShortages
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region private method
        private InventoryShortageInfo ConvertToInventoryShortageInfo(IDataRecord dr)
        {
            return new InventoryShortageInfo
            {
                EntryNo = (int)dr["EntryNo"],
                EntryCode = dr["EntryCode"].ToString(),
                DocCode = (short)dr["DocCode"],
                DocName = dr["DocName"].ToString(),
                DocNo = dr["DocNo"].ToString(),
                EntryDate = (DateTime)dr["EntryDate"],
                EntryState = dr["EntryState"].ToString(),
                PresentDate = dr["PresentDate"]==DBNull.Value?DateTime.MinValue:(DateTime)dr["PresentDate"],
                CancelDate = dr["CancelDate"]==DBNull.Value ?DateTime.MinValue:(DateTime)dr["CancelDate"],
                AuthorCode = dr["AuthorCode"].ToString(),
                AuthorName = dr["AuthorName"].ToString(),
                AuthorLoginId = dr["AuthorLoginId"].ToString(),
                AuthorDept = dr["AuthorDept"].ToString(),
                AuthorDeptName = dr["AuthorDeptName"].ToString(),
                Audit1 = dr["Audit1"]==DBNull.Value?string.Empty:dr["Audit1"].ToString(),
                Assessor1 = dr["Assessor1"]==DBNull.Value?string.Empty:dr["Assessor1"].ToString(),
                AuditDate1 = dr["AuditDate1"]==DBNull.Value?DateTime.MinValue:(DateTime)dr["AuditDate1"],
                AuditSuggest1 = dr["AuditSuggest1"]==DBNull.Value?string.Empty:dr["AuditSuggest1"].ToString(),
                Audit2 = dr["Audit2"] == DBNull.Value ? string.Empty : dr["Audit2"].ToString(),
                Assessor2 = dr["Assessor2"] == DBNull.Value ? string.Empty : dr["Assessor2"].ToString(),
                AuditDate2 = dr["AuditDate2"] == DBNull.Value ? DateTime.MinValue : (DateTime)dr["AuditDate2"],
                AuditSuggest2 = dr["AuditSuggest2"] == DBNull.Value ? string.Empty : dr["AuditSuggest2"].ToString(),
                Audit3 = dr["Audit3"] == DBNull.Value ? string.Empty : dr["Audit3"].ToString(),
                Assessor3 = dr["Assessor3"] == DBNull.Value ? string.Empty : dr["Assessor3"].ToString(),
                AuditDate3 = dr["AuditDate3"] == DBNull.Value ? DateTime.MinValue : (DateTime)dr["AuditDate3"],
                AuditSuggest3 = dr["AuditSuggest3"] == DBNull.Value ? string.Empty : dr["AuditSuggest3"].ToString(),
                StoCode = dr["StoCode"].ToString(),
                StoName = dr["StoName"].ToString(),
                SubTotal = (decimal)dr["SubTotal"],
                StoManagerCode = dr["StoManagerCode"]==DBNull.Value ?string.Empty:dr["StoManagerCode"].ToString(),
                StoManager = dr["StoManager"]==DBNull.Value?string.Empty:dr["StoManager"].ToString(),
                DrawDate = dr["DrawDate"]==DBNull.Value?DateTime.MinValue:DateTime.Parse(dr["DrawDate"].ToString()),
                ParentEntryNo = dr["ParentEntryNo"]==DBNull.Value?0:int.Parse(dr["ParentEntryNo"].ToString()),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
        }
        #endregion

        #region Method
        public InventoryShortageInfo GetById(int entryNo)
        {
            var sqlStatement = "Select * From InventoryShortage Where EntryNo = @EntryNo";
            var parms = new[] { new SqlParameter("@EntryNo", SqlDbType.Int) { Value = entryNo } };
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            InventoryShortageInfo obj = null;
            while (dr.Read())
            {
                obj = ConvertToInventoryShortageInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        public ListBase<InventoryShortageInfo> GetAll()
        {
            var sqlStatement = "Select * From InventoryShortage";
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement);
            var objs = new ListBase<InventoryShortageInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToInventoryShortageInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public ListBase<InventoryShortageInfo> GetByParentEntryNo(int entryNo)
        {
            var sqlStatement = "Select * From InventoryShortage Where ParentEntryNo = @ParentEntryNo";
            var parms = new[]{new SqlParameter("@ParentEntryNo",SqlDbType.Int){Value = entryNo}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM,CommandType.Text,sqlStatement,parms);
            var objs = new ListBase<InventoryShortageInfo>();
            while(dr.Read())
            {
                objs.Add(ConvertToInventoryShortageInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public bool Insert(InventoryShortageInfo obj)
        {
            return Insert(null, obj);
        }
        public bool Insert(DbTransaction trans, InventoryShortageInfo obj)
        {
            var sqlStatement = @"
Exec Doc_GetEntryNoAndCode @DocCode,@EntryNo output,@EntryCode output            
Insert Into InventoryShortage (EntryNo,EntryCode,DocCode,DocName,DocNo,EntryDate,PresentDate,CancelDate,EntryState,StoCode,StoName,SubTotal,AuthorCode,AuthorName,AuthorLoginId,AuthorDept,AuthorDeptName,ParentEntryNo,Remark) 
Values(@EntryNo,@EntryCode,@DocCode,@DocName,@DocNo,@EntryDate,@PresentDate,@CancelDate,@EntryState,@StoCode,@StoName,@SubTotal,@AuthorCode,@AuthorName,@AuthorLoginId,@AuthorDept,@AuthorDeptName,@ParentEntryNo,@Remark)
";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = 0,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@EntryCode",SqlDbType.NVarChar,30){Value = string.Empty,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@DocCode",SqlDbType.SmallInt){Value = obj.DocCode},
                                new SqlParameter("@DocName",SqlDbType.NVarChar,30){Value = obj.DocName},
                                new SqlParameter("@DocNo",SqlDbType.NVarChar,30){Value = obj.DocNo},
                                new SqlParameter("@EntryDate",SqlDbType.DateTime){Value = obj.EntryDate},
                                new SqlParameter("@PresentDate",SqlDbType.DateTime){Value = DBNull.Value},
                                new SqlParameter("@CancelDate",SqlDbType.DateTime){Value = DBNull.Value},
                                new SqlParameter("@EntryState",SqlDbType.Char,1){Value = obj.EntryState},
                                new SqlParameter("@StoCode",SqlDbType.NVarChar,10){Value = obj.StoCode},
                                new SqlParameter("@StoName",SqlDbType.NVarChar,20){Value = obj.StoName},
                                new SqlParameter("@SubTotal",SqlDbType.Decimal){Value = obj.SubTotal},
                                
                                new SqlParameter("@AuthorCode",SqlDbType.NVarChar,5){Value = obj.AuthorCode}, 
                                new SqlParameter("@AuthorName",SqlDbType.NVarChar,20){Value = obj.AuthorName},
                                new SqlParameter("@AuthorLoginId",SqlDbType.NVarChar,20){Value = obj.AuthorLoginId},
                                new SqlParameter("@AuthorDept",SqlDbType.NVarChar,5){Value = obj.AuthorDept},
                                new SqlParameter("@AuthorDeptName",SqlDbType.NVarChar,20){Value = obj.AuthorDeptName},
                                new SqlParameter("@ParentEntryNo",SqlDbType.Int){Value =obj.ParentEntryNo==0?DBNull.Value:(object)obj.ParentEntryNo}, 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,100){Value = obj.Remark},
                            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                {
                    var ret = SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                    Logger.Info(string.Format("InventoryShortage insert return {0}",ret));
                }
                obj.EntryNo = (int)parms[0].Value;
                obj.EntryCode = parms[1].Value.ToString();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public bool Update(InventoryShortageInfo obj)
        {
            return Update(null, obj);
        }
        public bool Update(DbTransaction trans, InventoryShortageInfo obj)
        {
            var sqlStatement = @"
Update  InventoryShortage 
Set     EntryCode = @EntryCode
,       DocCode = @DocCode
,       DocName = @DocName
,       DocNo = @DocNo
,       EntryDate = @EntryDate
,       PresentDate = @PresentDate
,       CancelDate = @CancelDate
,       EntryState = @EntryState
,       StoCode = @StoCode
,       StoName = @StoName
,       SubTotal = @SubTotal
,       AuthorCode = @AuthorCode
,       AuthorName = @AuthorName
,       AuthorLoginId = @AuthorLoginId
,       AuthorDept = @AuthorDept
,       AuthorDeptName = @AuthorDeptName
,       Audit1 = @Audit1
,       Assessor1 = @Assessor1
,       AuditDate1 = @AuditDate1
,       AuditSuggest1 = @AuditSuggest1
,       Audit2 = @Audit2
,       Assessor2 = @Assessor2
,       AuditDate2 = @AuditDate2
,       AuditSuggest2 = @AuditSuggest2
,       Audit3 = @Audit3
,       Assessor3 = @Assessor3
,       AuditDate3 = @AuditDate3
,       AuditSuggest3 = @AuditSuggest3
,       StoManagerCode = @StoManagerCode
,       StoManager = @StoManager
,       DrawDate = @DrawDate
,       ParentEntryNo = @ParentEntryNo
,       Remark = @Remark 
Where   EntryNo = @EntryNo";
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = obj.EntryNo},
                                new SqlParameter("@EntryCode",SqlDbType.NVarChar,30){Value = obj.EntryCode},
                                new SqlParameter("@DocCode",SqlDbType.SmallInt){Value = obj.DocCode},
                                new SqlParameter("@DocName",SqlDbType.NVarChar,30){Value = obj.DocName},
                                new SqlParameter("@DocNo",SqlDbType.NVarChar,30){Value = obj.DocNo},
                                new SqlParameter("@EntryDate",SqlDbType.DateTime){Value = obj.EntryDate},
                                new SqlParameter("@PresentDate",SqlDbType.DateTime){Value = obj.PresentDate==DateTime.MinValue?DBNull.Value:(object)obj.PresentDate},
                                new SqlParameter("@CancelDate",SqlDbType.DateTime){Value = obj.CancelDate==DateTime.MinValue?DBNull.Value:(object)obj.CancelDate},
                                new SqlParameter("@EntryState",SqlDbType.Char,1){Value = obj.EntryState},
                                new SqlParameter("@StoCode",SqlDbType.NVarChar,10){Value = obj.StoCode},
                                new SqlParameter("@StoName",SqlDbType.NVarChar,20){Value = obj.StoName},
                                new SqlParameter("@SubTotal",SqlDbType.Decimal){Value = obj.SubTotal},
                                
                                new SqlParameter("@AuthorCode",SqlDbType.NVarChar,5){Value = obj.AuthorCode}, 
                                new SqlParameter("@AuthorName",SqlDbType.NVarChar,20){Value = obj.AuthorName},
                                new SqlParameter("@AuthorLoginId",SqlDbType.NVarChar,20){Value = obj.AuthorLoginId},
                                new SqlParameter("@AuthorDept",SqlDbType.NVarChar,5){Value = obj.AuthorDept},
                                new SqlParameter("@AuthorDeptName",SqlDbType.NVarChar,20){Value = obj.AuthorDeptName},
                                
                                new SqlParameter("@Audit1",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.Audit1)?DBNull.Value:(object)obj.Audit1}, 
                                new SqlParameter("@Audit2",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.Audit2)?DBNull.Value:(object)obj.Audit2}, 
                                new SqlParameter("@Audit3",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.Audit3)?DBNull.Value:(object)obj.Audit3},
 
                                new SqlParameter("@Assessor1",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.Assessor1)?DBNull.Value:(object)obj.Assessor1}, 
                                new SqlParameter("@Assessor2",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.Assessor2)?DBNull.Value:(object)obj.Assessor2}, 
                                new SqlParameter("@Assessor3",SqlDbType.NVarChar,20){Value = string.IsNullOrEmpty(obj.Assessor3)?DBNull.Value:(object)obj.Assessor3}, 

                                new SqlParameter("@AuditDate1",SqlDbType.DateTime){Value = obj.AuditDate1==DateTime.MinValue?DBNull.Value:(object)obj.AuditDate1},
                                new SqlParameter("@AuditDate2",SqlDbType.DateTime){Value = obj.AuditDate2==DateTime.MinValue?DBNull.Value:(object)obj.AuditDate2},
                                new SqlParameter("@AuditDate3",SqlDbType.DateTime){Value = obj.AuditDate3==DateTime.MinValue?DBNull.Value:(object)obj.AuditDate3},

                                new SqlParameter("@AuditSuggest1",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.AuditSuggest1)?DBNull.Value:(object)obj.AuditSuggest1}, 
                                new SqlParameter("@AuditSuggest2",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.AuditSuggest2)?DBNull.Value:(object)obj.AuditSuggest2},
                                new SqlParameter("@AuditSuggest3",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.AuditSuggest3)?DBNull.Value:(object)obj.AuditSuggest3},

                                new SqlParameter("@StoManagerCode",SqlDbType.NVarChar,5){Value = string.IsNullOrEmpty(obj.StoManagerCode)?DBNull.Value:(object)obj.StoManagerCode},
                                new SqlParameter("@StoManager",SqlDbType.NVarChar,20){Value =string.IsNullOrEmpty(obj.StoManager)?DBNull.Value:(object)obj.StoManager},
                                new SqlParameter("@DrawDate", SqlDbType.DateTime){Value = obj.DrawDate==DateTime.MinValue?DBNull.Value:(object)obj.DrawDate}, 
                                new SqlParameter("@ParentEntryNo", SqlDbType.Int){Value = obj.ParentEntryNo==0?DBNull.Value:(object)obj.ParentEntryNo}, 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,100){Value = obj.Remark},
                            };
            try
            {
                if (trans == null)
                {
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                }
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
        public bool Delete(InventoryShortageInfo obj)
        {
            return Delete(null, obj.EntryNo);
        }
        public bool Delete(DbTransaction trans, InventoryShortageInfo obj)
        {
            return Delete(trans, obj.EntryNo);
        }
        public bool Delete(int entryNo)
        {
            return Delete(null, entryNo);
        }
        public bool Delete(DbTransaction trans, int entryNo)
        {
            var sqlStatement = "Delete From InventoryShortage Where EntryNo = @EntryNo";
            var parms = new[] { new SqlParameter("@EntryNo", SqlDbType.Int) { Value = entryNo } };
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
        /// <summary>
        /// 盘亏单发料.
        /// </summary>
        /// <param name="EntryNo">int:	盘亏单流水号.</param>
        /// <param name="SerialNoList">string:	顺序号串.</param>
        /// <param name="ItemNumList">string:	领料单发料数串.</param>
        /// <param name="PKIDList">string:	主键串。</param>
        /// <param name="ItemDrawNumList">string:	库存发料数串.</param>
        /// <param name="UserCode">string:	用户编号.</param>
        /// <param name="UserName">string:	用户名称。</param>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>bool:	成功返回true，失败返回false。</returns>
        public bool DrawOutStock(int EntryNo, string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
        {
            var parms = new[]{
                new SqlParameter("@EntryNo",SqlDbType.Int){Value = EntryNo},
                new SqlParameter("@SerialNoList",SqlDbType.NVarChar,4000){Value=SerialNoList},
                new SqlParameter("@ItemNumList",SqlDbType.NVarChar,4000){Value=ItemNumList},
                new SqlParameter("@PKIDList",SqlDbType.NVarChar,4000){Value=PKIDList},
                new SqlParameter("@ItemDrawNumList",SqlDbType.NVarChar,4000){Value = ItemDrawNumList},
                new SqlParameter("@UserCode",SqlDbType.NVarChar,5){Value=UserCode},
                new SqlParameter("@UserName",SqlDbType.NVarChar,20){Value=UserName},
                new SqlParameter("@UserLoginId",SqlDbType.NVarChar,20){Value=UserLoginId},
            };
            try 
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.StoredProcedure, "InventoryShortage_StockOut", parms);
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