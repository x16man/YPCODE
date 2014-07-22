using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class GraphSchemaRTag : IDAL.IGraphSchemaRTag
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="tabId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<GraphSchemaRTagInfo> GetByTabId(Int32 tabId)
        {
            const string strSql = @"SELECT [RTagId],[TabId],[TagName],[TagId],[Unit],[SerialNumber],[DataType] FROM [GraphSchemaRTag] WHERE [TabId] = @TabId ORDER BY [SerialNumber], [RTagId]";
            var objs = new List<GraphSchemaRTagInfo>();
            var parms = new[] { new SqlParameter("@TabId", SqlDbType.Int) { Value = tabId }, };
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaRTagInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr!=null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 获取所有的GraphSchemaRTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaRTagInfo.</returns>
        public List<GraphSchemaRTagInfo> GetAll()
        {
            const string sqlStatement = @"SELECT [RTagId],[TabId],[TagName],[TagId],[Unit],[SerialNumber],[DataType] FROM [GraphSchemaRTag]";
            var objs = new List<GraphSchemaRTagInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
            while(dr.Read())
            {
                objs.Add(ConvertToGraphSchemaRTagInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public GraphSchemaRTagInfo GetById(Int32 keyId)
        {
            const string sqlStatement = @"SELECT [RTagId],[TabId],[TagName],[TagId],[Unit],[SerialNumber],[DataType] FROM [GraphSchemaRTag] WHERE [RTagId] = @RTagId";
            var parms = new[] { new SqlParameter("@RTagId", SqlDbType.Int) { Value = keyId } };
            GraphSchemaRTagInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToGraphSchemaRTagInfo(dr);
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            } 
            finally
            {
                if (dr != null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public Boolean Delete(Int32 rTagId)
        {
            const string sqlStatement = @"UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [GraphSchemaRTag] A
INNER JOIN [GraphSchemaRTag] B ON A.[TabId] = B.[TabId] AND A.[SerialNumber] > B.[SerialNumber]
WHERE B.[RTagId] = @RTagId
DELETE FROM [GraphSchemaRTag] WHERE [RTagId] = @RTagId";
            var parms = new[] { new SqlParameter("@RTagId", SqlDbType.Int) { Value = rTagId } };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="obj">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public Boolean Delete(GraphSchemaRTagInfo obj)
        {
            return Delete(obj.RTagId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GraphSchemaRTagInfo rTagInfo)
        {
            using (var conn = new SqlConnection(ConnectionString.Monitor))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        InsertWithTrans(trans, rTagInfo);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Logger.Error(ex.Message);
                        return false;
                    }
                }
                conn.Close();
            }
            return true;
        }

        /// <summary>
        /// 添加曲线方案关联项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="rTagInfo">曲线方案关联项对象.</param>
        /// <returns>bool</returns>
        public Boolean InsertWithTrans(SqlTransaction trans, GraphSchemaRTagInfo rTagInfo)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [GraphSchemaRTag] WHERE [TabId] = @TabId
            INSERT INTO [GraphSchemaRTag] ([TabId],[TagName],[TagId],[Unit],[DataType],[SerialNumber]) VALUES (@TabId,@TagName,@TagId,@Unit,@DataType,@SerialNumber)";
            var parms = new[] { 
                new SqlParameter("@TabId", SqlDbType.Int) { Value = rTagInfo.TabId },
                new SqlParameter("@TagName", SqlDbType.NVarChar, 50) { Value = rTagInfo.TagName },
                new SqlParameter("@TagId", SqlDbType.NVarChar, 300) { Value = rTagInfo.TagId },
                new SqlParameter("@Unit", SqlDbType.NVarChar, 20) { Value = rTagInfo.Unit },
                new SqlParameter("@DataType", SqlDbType.NVarChar, 20) { Value = rTagInfo.DataType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="rTagInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public Boolean Update(GraphSchemaRTagInfo rTagInfo)
        {
            const string sqlStatement = "UPDATE [GraphSchemaRTag] SET [TabId] = @TabId,[TagId] = @TagId,[TagName] = @TagName,[Unit] = @Unit, [DataType] = @DataType WHERE [RTagId] = @RTagId";
            var parms = new[] { 
                new SqlParameter("@RTagId", SqlDbType.Int) { Value = rTagInfo.RTagId },
                new SqlParameter("@TabId", SqlDbType.Int) { Value = rTagInfo.TabId },
                new SqlParameter("@TagId", SqlDbType.NVarChar, 300) { Value = rTagInfo.TagId },
                new SqlParameter("@TagName", SqlDbType.NVarChar, 50) { Value = rTagInfo.TagName },
                new SqlParameter("@Unit", SqlDbType.NVarChar, 20) { Value = rTagInfo.Unit },
                new SqlParameter("@DataType", SqlDbType.NVarChar, 20) { Value = rTagInfo.DataType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 曲线方案关联项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(Int32 keyId, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@RTagId", SqlDbType.Int) { Value = keyId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "GraphSchemaRTag_Move", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        #endregion

        #region private method
        /// <summary>
        /// 将IDataRecord转换为GraphSchemaRTagInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>GraphSchemaRTagInfo对象。</returns>
        static GraphSchemaRTagInfo ConvertToGraphSchemaRTagInfo(IDataRecord dr)
        {
            var obj = new GraphSchemaRTagInfo
                          {
                              RTagId = Convert.ToInt32(dr["RTagId"]),
                              TabId = Convert.ToInt32(dr["TabId"]),
                              TagId = (dr["TagId"] == DBNull.Value ? String.Empty : dr["TagId"].ToString()),
                              TagName = (dr["TagName"] == DBNull.Value ? String.Empty : dr["TagName"].ToString()),
                              Unit = (dr["Unit"] == DBNull.Value ? String.Empty : dr["Unit"].ToString()),
                              DataType = (dr["DataType"] == DBNull.Value ? String.Empty : dr["DataType"].ToString()),
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"])
                          };
            return obj;
        }
        #endregion

    }
}
