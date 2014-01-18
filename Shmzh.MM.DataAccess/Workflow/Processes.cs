using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.MM.Common.Workflow;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Workflow
{
    public class Processes
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Private Method
        private ProcessInfo ConvertToProcessInfo(IDataRecord dr)
        {
            return new ProcessInfo()
            {
                Proc_ID = dr.GetInt32(0),
                Proc_Name = dr.GetString(1),
                Proc_Desc = dr["Proc_Desc"]==DBNull.Value?string.Empty:dr["Proc_Desc"].ToString(),
                ViewUrl = dr["ViewUrl"] == DBNull.Value ?string.Empty:dr["ViewUrl"].ToString(),
            };
        }
        #endregion

        #region Method
        public bool Insert(ProcessInfo obj)
        {
            var sqlStatement = "Insert Into Process Values (@Proc_Id,@Proc_Name,@Proc_Desc,@VierUrl)";
            var parms = new[]
                            {
                                new SqlParameter("@Proc_Id", SqlDbType.Int) {Value = obj.Proc_ID},
                                new SqlParameter("@Proc_Name", SqlDbType.NVarChar, 30) {Value = obj.Proc_Name},
                                new SqlParameter("@Proc_Desc", SqlDbType.NVarChar, 50) {Value = string.IsNullOrEmpty(obj.Proc_Desc) ? DBNull.Value : (object) obj.Proc_Desc},
                                new SqlParameter("@ViewUrl", SqlDbType.NVarChar, 255) {Value = string.IsNullOrEmpty(obj.ViewUrl) ? DBNull.Value : (object) obj.ViewUrl},
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
        public bool Update(ProcessInfo obj)
        {
            var sqlStatement = "Update Process Set Proc_Name = @Proc_Name,Proc_Desc = @Proc_Desc,ViewUrl = @ViewUrl Where Proc_Id = @Proc_Id";
            var parms = new[]
                            {
                                new SqlParameter("@Proc_Id", SqlDbType.Int) {Value = obj.Proc_ID},
                                new SqlParameter("@Proc_Name", SqlDbType.NVarChar, 30) {Value = obj.Proc_Name},
                                new SqlParameter("@Proc_Desc", SqlDbType.NVarChar, 50) {Value = string.IsNullOrEmpty(obj.Proc_Desc) ? DBNull.Value : (object) obj.Proc_Desc},
                                new SqlParameter("@ViewUrl", SqlDbType.NVarChar, 255) {Value = string.IsNullOrEmpty(obj.ViewUrl) ? DBNull.Value : (object) obj.ViewUrl},
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
                throw;
            }
        }
        public bool Delete(int procId)
        {
            var sqlStatement = "Delete From Process Where Proc_Id = @Proc_Id";
            var parms = new[]
                            {
                                new SqlParameter("@Proc_Id",SqlDbType.Int){Value = procId},
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
        #endregion
    }
}
