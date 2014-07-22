using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagGather : IDAL.ITagGather
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region ITag 成员
        /// <summary>
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        public List<TagGatherInfo> GetByTagId(String tagId)
        {
            if (tagId == null) tagId = "";
            String strSQL = @"SELECT [I_TAG_ID],[I_DESIGN_CD],[I_ADDRESS],[I_PARA_A],[I_PARA_B],[I_PARA_C],[I_MAX],[I_MIN],[I_ACTION]
FROM [T_TAG_GATHER] WHERE [I_TAG_ID] LIKE @TagId";
            var parms = new[] {
                new SqlParameter("@TagId", SqlDbType.VarChar, 8) {Value = tagId + "%"},
            };
            var objs = new List<TagGatherInfo>();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, strSQL, parms))
                {
                    while (dr.Read())
                    {
                        objs.Add(ConvertToTagInfo(dr));
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }           
            return objs;
        }     

        #endregion

        #region Private Method
        /// <summary>
        /// 将DataRow转换为TagGatherInfo对象。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>指标对象。</returns>
        private static TagGatherInfo ConvertToTagInfo(IDataRecord dr)
        {
            var obj = new TagGatherInfo
                          {
                              I_TAG_ID = dr["I_TAG_ID"].ToString(),
                              I_DESIGN_CD = dr["I_DESIGN_CD"] == DBNull.Value ? string.Empty : dr["I_DESIGN_CD"].ToString(),
                              I_ADDRESS = dr["I_ADDRESS"] == DBNull.Value ? string.Empty : dr["I_ADDRESS"].ToString(),
                              I_PARA_A = dr["I_PARA_A"] == DBNull.Value ? double.MaxValue : double.Parse(dr["I_PARA_A"].ToString()),
                              I_PARA_B = dr["I_PARA_B"] == DBNull.Value ? double.MinValue : double.Parse(dr["I_PARA_B"].ToString()),
                              I_PARA_C = dr["I_PARA_C"] == DBNull.Value ? double.MinValue : double.Parse(dr["I_PARA_C"].ToString()),
                              I_MAX = dr["I_MAX"] == DBNull.Value ? double.MinValue : double.Parse(dr["I_MAX"].ToString()),
                              I_MIN = dr["I_MIN"] == DBNull.Value ? double.MinValue : double.Parse(dr["I_MIN"].ToString()),
                              I_ACTION = Convert.ToInt16(dr["I_ACTION"])
                          };
            return obj;
        }
        #endregion
    }
}
