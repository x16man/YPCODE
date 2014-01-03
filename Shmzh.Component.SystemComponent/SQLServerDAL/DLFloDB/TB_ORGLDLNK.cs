using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    public class TB_ORGLDLNK:IDAL.ITB_ORGLDLNK
    {
        #region Field
        private const string FloDBName = "FloDBName";

        #endregion

        #region Method
        private TB_ORGLDLNKInfo ConvertToObject(IDataReader dr)
        {
            var obj = new TB_ORGLDLNKInfo();
            obj.LNKID = int.Parse(dr["LNKID"].ToString());
            obj.OrgId = int.Parse(dr["OrgId"].ToString());
            obj.LeadTypeId = int.Parse(dr["LeadTypeId"].ToString());
            obj.UserId = int.Parse(dr["UserId"].ToString());
            return obj;
        }
        #endregion
        public List<TB_ORGLDLNKInfo> GetByLeadTypeId(int leadTypeId)
        {
            var sqlStatement = string.Format("Select * From {0}.dbo.TB_ORGLDLNK Where LeadTypeID = @LeadTypeId",ConfigurationManager.AppSettings[FloDBName]);
            var parms = new[] {new SqlParameter("@LeadTypeId", SqlDbType.Int) {Value = leadTypeId}};
            var objs = new ListBase<TB_ORGLDLNKInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }
    }
}
