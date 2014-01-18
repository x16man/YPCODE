using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Shmzh.MM.Common;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Common
{
    public class SBODs
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
        
        #region private method
        /// <summary>
        /// 将DataReader转换为单据类型实体。
        /// </summary>
        /// <param name="dr">DataReader对象。</param>
        /// <returns>单据类型实体。</returns>
        private SBODInfo ConvertToSBODInfo(IDataRecord dr)
        {
            var obj = new SBODInfo
                          {
                              DocCode = (short)dr["DocCode"], 
                              DocName = dr["DocName"].ToString(), 
                              CodeRule = dr["CodeRule"]==DBNull.Value ?string.Empty:dr["CodeRule"].ToString(),
                              DocNo = dr["DocNo"]==DBNull.Value?string.Empty:dr["DocNo"].ToString(),
                              StartNo = dr["StartNo"]==DBNull.Value?1:(int)dr["StartNo"],
                              NextNo = dr["NextNo"]==DBNull.Value?1:(int)dr["NextNo"],
                              OneItem = dr["OneItem"]==DBNull.Value?false:dr["OneItem"].ToString()=="Y",
                              AuditLevel = dr["AuditLevel"]==DBNull.Value?(short)1:(short)dr["AuditLevel"],
                              IsAccount = dr["IsAccount"]==DBNull.Value?false:dr["IsAccount"].ToString()=="Y",
                              IsAudit1 = dr["IsAudit1"]==DBNull.Value?false:dr["IsAudit1"].ToString()=="Y",
                              IsAudit2 = dr["IsAudit2"] == DBNull.Value ? false : dr["IsAudit2"].ToString() == "Y",
                              IsAudit3 = dr["IsAudit3"] == DBNull.Value ? false : dr["IsAudit3"].ToString() == "Y",
                              AuditName1 = dr["AuditName1"]==DBNull.Value?string.Empty:dr["AuditName1"].ToString(),
                              AuditName2 = dr["AuditName2"] == DBNull.Value ? string.Empty : dr["AuditName2"].ToString(),
                              AuditName3 = dr["AuditName3"] == DBNull.Value ? string.Empty : dr["AuditName3"].ToString(),
                              Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                          };
            return obj;
        }
        #endregion

        #region Method
        public bool Insert(SBODInfo obj)
        {
            var sqlStatement = @"
Insert Info SBOD (DocCode,DocName,DocNo,CodeRule,StartNo,NextNo,OneItem,AuditLevel,IsAudit1,IsAudit2,IsAudit3,IsAccount,AuditName1,AuditName2,AuditName3,Remark) 
Values (@DocCode,@DocName,@DocNo,@CodeRule,@StartNo,@NextNo,@OneItem,@AuditLevel,@IsAudit1,@IsAudit2,@IsAudit3,@IsAccount,@AuditName1,@AuditName2,@AuditName3,@Remark)";
            var parms = new[]
                            {
                                new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = obj.DocCode},
                                new SqlParameter("@DocName", SqlDbType.NVarChar, 30) {Value = string.IsNullOrEmpty(obj.DocName) ? string.Empty : obj.DocName},
                                new SqlParameter("@DocNo", SqlDbType.NVarChar, 30) {Value = string.IsNullOrEmpty(obj.DocNo) ? string.Empty : obj.DocNo},
                                new SqlParameter("@CodeRule", SqlDbType.NVarChar, 20) {Value = string.IsNullOrEmpty(obj.CodeRule) ? string.Empty : obj.CodeRule},
                                new SqlParameter("@StartNo", SqlDbType.Int) {Value = obj.StartNo},
                                new SqlParameter("@NextNo", SqlDbType.Int) {Value = obj.NextNo},
                                new SqlParameter("@OneItem", SqlDbType.Char, 1) {Value = obj.OneItem ? "Y" : "N"},
                                new SqlParameter("@AuditLevel", SqlDbType.SmallInt) {Value = obj.AuditLevel},
                                new SqlParameter("@IsAccount",SqlDbType.Char,1){Value = obj.IsAccount?"Y":"N"},
                                new SqlParameter("@IsAudit1", SqlDbType.Char, 1) {Value = obj.IsAudit1 ? "Y" : "N"},
                                new SqlParameter("@IsAudit2",SqlDbType.Char,1){Value = obj.IsAudit2?"Y":"N"},
                                new SqlParameter("@IsAudit3",SqlDbType.Char,1){Value = obj.IsAudit3?"Y":"N"},
                                new SqlParameter("@AuditName1",SqlDbType.NVarChar,20){Value = obj.AuditName1},
                                new SqlParameter("@AuditName2",SqlDbType.NVarChar,20){Value = obj.AuditName2}, 
                                new SqlParameter("@AuditName3",SqlDbType.NVarChar,20){Value = obj.AuditName3},
                                new SqlParameter("@Remark",SqlDbType.NVarChar,50){Value = obj.Remark},
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
        public bool Update(SBODInfo obj)
        {
            return Update(null, obj);
        }
        public bool Update(DbTransaction trans, SBODInfo obj)
        {
            var sqlStatement = @"
Update SBOD 
Set DocName= @DocName
,   DocNo=@DocNo
,   CodeRule=@CodeRule
,   StartNo=@StartNo
,   NextNo=@NextNo
,   OneItem=@OneItem
,   AuditLevel = @AuditLevel
,   IsAccount = @IsAccount
,   IsAudit1 = @IsAudit1
,   IsAudit2 = @IsAudit2
,   IsAudit3 = @IsAudit3
,   AuditName1 = @AuditName1
,   AuditName2 = @AuditName2
,   AuditName3 = @AuditName3
，  Remark = @Remark
Where   DocCode = @DocCode";
            var parms = new[]
                            {
                                new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = obj.DocCode},
                                new SqlParameter("@DocName", SqlDbType.NVarChar, 30) {Value = string.IsNullOrEmpty(obj.DocName) ? string.Empty : obj.DocName},
                                new SqlParameter("@DocNo", SqlDbType.NVarChar, 30) {Value = string.IsNullOrEmpty(obj.DocNo) ? string.Empty : obj.DocNo},
                                new SqlParameter("@CodeRule", SqlDbType.NVarChar, 20) {Value = string.IsNullOrEmpty(obj.CodeRule) ? string.Empty : obj.CodeRule},
                                new SqlParameter("@StartNo", SqlDbType.Int) {Value = obj.StartNo},
                                new SqlParameter("@NextNo", SqlDbType.Int) {Value = obj.NextNo},
                                new SqlParameter("@OneItem", SqlDbType.Char, 1) {Value = obj.OneItem ? "Y" : "N"},
                                new SqlParameter("@AuditLevel", SqlDbType.SmallInt) {Value = obj.AuditLevel},
                                new SqlParameter("@IsAccount",SqlDbType.Char,1){Value = obj.IsAccount?"Y":"N"},
                                new SqlParameter("@IsAudit1", SqlDbType.Char, 1) {Value = obj.IsAudit1 ? "Y" : "N"},
                                new SqlParameter("@IsAudit2",SqlDbType.Char,1){Value = obj.IsAudit2?"Y":"N"},
                                new SqlParameter("@IsAudit3",SqlDbType.Char,1){Value = obj.IsAudit3?"Y":"N"},
                                new SqlParameter("@AuditName1",SqlDbType.NVarChar,20){Value = obj.AuditName1},
                                new SqlParameter("@AuditName2",SqlDbType.NVarChar,20){Value = obj.AuditName2}, 
                                new SqlParameter("@AuditName3",SqlDbType.NVarChar,20){Value = obj.AuditName3},
                                new SqlParameter("@Remark",SqlDbType.NVarChar,50){Value = obj.Remark},
                            };
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                {
                    SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.Text, sqlStatement, parms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public bool Delete(SBODInfo obj)
        {
            return Delete(obj.DocCode);
        }
        public bool Delete(short docCode)
        {
            var sqlStatement = "Delete From SBOD Where DocCode = @DocCode";
            var parms = new[] {new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode}};
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
        public SBODInfo GetByDocCode(short docCode)
        {
            var sqlStatement = "Select * From SBOD Where DocCode = @DocCode";
            var parms = new[] {new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode}};
            SBODInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToSBODInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        public ListBase<SBODInfo> GetAll()
        {
            var sqlStatement = "Select * From SBOD";
            var objs = new ListBase<SBODInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToSBODInfo(dr));
            }
            dr.Close();
            return objs;
        }
        #endregion
    }
}
