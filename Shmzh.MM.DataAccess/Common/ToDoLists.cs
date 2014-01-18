namespace Shmzh.MM.DataAccess.Common
{
    using System;
    using System.Data.SqlClient;
    using System.Data;
    using Shmzh.Components.SystemComponent;
    using System.Data.Common;
    public class ToDoLists
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool Create(DbTransaction trans, int procId, int entryNo, int currentActId, string completionFlag, string loginId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Proc_ID", SqlDbType.Int) {Value = procId},
                                new SqlParameter("@Entity_ID", SqlDbType.Int) {Value = entryNo},
                                new SqlParameter("@Curr_Act_ID",SqlDbType.Int){Value = currentActId},
                                new SqlParameter("@Completion_Flag",SqlDbType.Char,1){Value = completionFlag},
                                new SqlParameter("@UserLoginId",SqlDbType.NVarChar,20){Value = loginId},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.StoredProcedure, "WF_CreateToDoList",
                                          parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }
    }
}