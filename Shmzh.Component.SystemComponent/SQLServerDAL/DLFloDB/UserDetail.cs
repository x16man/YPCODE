using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class UserDetail:IDAL.IUserDetail
    {
        #region Field

        private string ViewName = @"(Select 	A.UserID,A.HRID,A.UserName,A.UserDspName,B.OrgID,C.ItemName As OrgName,A.JobTitle
From 	TB_Users A Left Outer Join TB_ORGMEMLNK B
ON	A.UserID = B.UserID
LEFT JOIN TB_ORGTREE C
ON 	B.ORGID = C.ITEMID
Where 	A.Enable=1)
";
        #endregion

        #region private method
        /// <summary>
        /// 将SqlDataReader转换为UserDetailInfo实体。
        /// </summary>
        /// <param name="dr">SqlDataReader</param>
        /// <returns>UserDetailInfo实体</returns>
        private static UserDetailInfo ConvertToUserDetailInfo(IDataRecord dr)
        {
            var obj = new UserDetailInfo();
            obj.UserId = dr.GetInt32(0);
            obj.HRID = dr.GetString(1);
            obj.UserName = dr.GetString(2);
            obj.UserDspName = dr.GetString(3);
            obj.OrgID = dr["OrgID"] == DBNull.Value ? 0 : int.Parse(dr["OrgID"].ToString());
            obj.OrgName = dr["OrgName"] == DBNull.Value ? string.Empty : dr["OrgName"].ToString();
            obj.JobTitle = dr["JobTitle"] == DBNull.Value ? string.Empty : dr["JobTitle"].ToString();
            return obj;
        }
        #endregion

        #region Implementation of IUserDetail

        /// <summary>
        /// 根据组织机构来获取人员列表.
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>人员列表.</returns>
        public ListBase<UserDetailInfo> GetByOrg(int orgId)
        {
            var sqlStatement = string.Format("Select * From {0} As A Where A.OrgID = @OrgID", ViewName);
            var parms = new[] {new SqlParameter("@OrgID", SqlDbType.Int) {Value = orgId}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, sqlStatement, parms);
            var objs = new ListBase<UserDetailInfo>();
            while(dr.Read())
            {
                objs.Add(ConvertToUserDetailInfo(dr));
            }
            return objs;
        }

        /// <summary>
        /// 根据查询内容来获取人员列表.
        /// </summary>
        /// <param name="content">查询内容.</param>
        /// <returns>人员列表.</returns>
        public ListBase<UserDetailInfo> GetByContent(string content)
        {
            content = StringUtil.DeleteKeyWord(content);

            var sqlStatement = string.Format("Select * From {0} As A Where A.HRID Like '%{1}%' OR UserName Like '%{1}%' OR UserDspName Like '%{1}%' OR JobTitle Like '%{1}%'", ViewName,content);
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, sqlStatement);

            var objs = new ListBase<UserDetailInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToUserDetailInfo(dr));
            }
            return objs;
        }

        /// <summary>
        /// 获取所有人员列表.
        /// </summary>
        /// <returns>人员列表.</returns>
        public ListBase<UserDetailInfo> GetAllAvalible()
        {
            var sqlStatement = string.Format("Select * From {0} As A ",ViewName);
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, sqlStatement);

            var objs = new ListBase<UserDetailInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToUserDetailInfo(dr));
            }
            return objs;
        }

        #endregion
    }
}
