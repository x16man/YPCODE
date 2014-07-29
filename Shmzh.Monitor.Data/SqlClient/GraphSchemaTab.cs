using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class GraphSchemaTab : IDAL.IGraphSchemaTab
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<GraphSchemaTabInfo> GetBySchemaId(Int32 schemaId)
        {
            const string strSql = @"SELECT [TabId],[SchemaId],[TabName],[TabType],[TabVisible],[Title],[TitleVisible],[SerialNumber] FROM [GraphSchemaTab] WHERE [SchemaId] = @SchemaId ORDER BY [SerialNumber], [TabId]";
            var objs = new List<GraphSchemaTabInfo>();
            var parms = new[] { new SqlParameter("@SchemaId", SqlDbType.Int) { Value = schemaId }, };
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaTabInfo(dr));
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
        /// 获取所有的GraphSchemaTabInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTabInfo.</returns>
        public List<GraphSchemaTabInfo> GetAll()
        {
            const string sqlStatement = @"SELECT [TabId],[SchemaId],[TabName],[TabType],[TabVisible],[Title],[TitleVisible],[SerialNumber] FROM [GraphSchemaTab] ";

            var objs = new List<GraphSchemaTabInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaTabInfo(dr));
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
            return objs;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="keyId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public GraphSchemaTabInfo GetById(Int32 keyId)
        {
            const string sqlStatement = @"SELECT [TabId],[SchemaId],[TabName],[TabType],[TabVisible],[Title],[TitleVisible],[SerialNumber] FROM [GraphSchemaTab] WHERE [TabId] = @TabId";
            var parms = new[] { new SqlParameter("@TabId", SqlDbType.Int) { Value = keyId } };
            GraphSchemaTabInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToGraphSchemaTabInfo(dr);
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
        /// <param name="keyId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public Boolean Delete(Int32 keyId)
        {
            const string sqlStatement = @"UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [GraphSchemaTab] A
INNER JOIN [GraphSchemaTab] B ON A.[SchemaId] = B.[SchemaId] AND A.[SerialNumber] > B.[SerialNumber]
WHERE B.[TabId] = @TabId
DELETE FROM [GraphSchemaRTag] WHERE [TabId] = @TabId
DELETE FROM [GraphSchemaTab] WHERE [TabId] = @TabId";
            var parms = new[] { new SqlParameter("@TabId", SqlDbType.Int) { Value = keyId } };
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
        public Boolean Delete(GraphSchemaTabInfo obj)
        {
            return Delete(obj.TabId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>int</returns>
        public int Insert(GraphSchemaTabInfo tabInfo)
        {
            return this.InsertWithTrans(null, tabInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="tabInfo">曲线方案关联项对象</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, GraphSchemaTabInfo tabInfo)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [GraphSchemaTab] WHERE [SchemaId] = @SchemaId
            INSERT INTO [GraphSchemaTab] ([SchemaId],[TabName],[TabType],[TabVisible],[Title],[TitleVisible],[SerialNumber]) VALUES (@SchemaId,@TabName,@TabType,@TabVisible,@Title,@TitleVisible,@SerialNumber) 
SET @TabId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@TabId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = tabInfo.SchemaId },
                new SqlParameter("@TabName", SqlDbType.NVarChar, 20) { Value = tabInfo.TabName },
                new SqlParameter("@TabType", SqlDbType.TinyInt) { Value = tabInfo.TabType },
                new SqlParameter("@TabVisible", SqlDbType.Bit) { Value = tabInfo.TabVisible },
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = tabInfo.Title },
                new SqlParameter("@TitleVisible", SqlDbType.Bit) { Value = tabInfo.TitleVisible }
            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                
                tabInfo.TabId = (int)parms[0].Value;
                return tabInfo.TabId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="tabInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public Boolean Update(GraphSchemaTabInfo tabInfo)
        {
            const string sqlStatement = "UPDATE [GraphSchemaTab] SET [SchemaId] = @SchemaId,[TabName] = @TabName,[TabType] = @TabType,[TabVisible] = @TabVisible, [Title] = @Title, [TitleVisible] = @TitleVisible WHERE [TabId] = @TabId";
            var parms = new[] { 
                new SqlParameter("@TabId", SqlDbType.Int) { Value = tabInfo.TabId },
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = tabInfo.SchemaId },
                new SqlParameter("@TabName", SqlDbType.NVarChar, 20) { Value = tabInfo.TabName },
                new SqlParameter("@TabType", SqlDbType.TinyInt) { Value = tabInfo.TabType },
                new SqlParameter("@TabVisible", SqlDbType.Bit) { Value = tabInfo.TabVisible },
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = tabInfo.Title },
                new SqlParameter("@TitleVisible", SqlDbType.Bit) { Value = tabInfo.TitleVisible }
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
                new SqlParameter("@TabId", SqlDbType.Int) { Value = keyId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "GraphSchemaTab_Move", parms);
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
        /// 将IDataRecord转换为GraphSchemaTabInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>GraphSchemaTabInfo对象。</returns>
        static GraphSchemaTabInfo ConvertToGraphSchemaTabInfo(IDataRecord dr)
        {
            var obj = new GraphSchemaTabInfo
                          {
                              TabId = Convert.ToInt32(dr["TabId"]),
                              SchemaId = Convert.ToInt32(dr["SchemaId"]),
                              TabName = (dr["TabName"] == DBNull.Value ? String.Empty : dr["TabName"].ToString()),
                              TabType = Convert.ToByte(dr["TabType"]),
                              TabVisible = Convert.ToBoolean(dr["TabVisible"]),
                              Title = (dr["Title"] == DBNull.Value ? String.Empty : dr["Title"].ToString()),
                              TitleVisible = Convert.ToBoolean(dr["TitleVisible"]),                              
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"])
                          };
            return obj;
        }        
        #endregion

    }
}
