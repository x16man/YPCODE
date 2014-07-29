using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class GraphSchemaTag : IDAL.IGraphSchemaTag
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员

        /// <summary>
        /// 根据曲线方案项Id获取曲线指标集合。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<GraphSchemaTagInfo> GetBySchemaItemId(Int32 itemId)
        {
            const string strSql = @"SELECT [KeyId],[ItemId],[TagId],[TagName],[CurveType],[CurveColor], [SerialNumber],[LineWidth], [SymbolType], [SymbolSize], [MAPeriod],[LineType],[SymbolColor] FROM [GraphSchemaTag] WHERE [ItemId] = @ItemId ORDER BY [SerialNumber], [KeyId]";
            var objs = new List<GraphSchemaTagInfo>();
            var parms = new[] {new SqlParameter("@ItemId", SqlDbType.Int) {Value = itemId},};
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaTagInfo(dr));
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
        /// 获取所有的GraphSchemaTagInfo.
        /// </summary>
        /// <returns>所有的GraphSchemaTagInfo.</returns>
        public List<GraphSchemaTagInfo> GetAll()
        {
            const string strSql = @"SELECT [KeyId],[ItemId],[TagId],[TagName],[CurveType],[CurveColor], [SerialNumber],[LineWidth], [SymbolType], [SymbolSize], [MAPeriod],[LineType],[SymbolColor] FROM [GraphSchemaTag]";
            var objs = new List<GraphSchemaTagInfo>();
            
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, strSql);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaTagInfo(dr));
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
        /// <param name="keyId">方案项指标Id。</param>
        /// <returns>方案项指标信息实体。</returns>
        public GraphSchemaTagInfo GetById(Int32 keyId)
        {
            const string sqlStatement = @"SELECT [KeyId],[ItemId],[TagId],[TagName],[CurveType],[CurveColor], [SerialNumber], [LineWidth], [SymbolType], [SymbolSize], [MAPeriod],[LineType],[SymbolColor] FROM [GraphSchemaTag] WHERE [KeyId] = @KeyId";
            var parms = new[] { new SqlParameter("@KeyId", SqlDbType.Int) { Value = keyId } };
            GraphSchemaTagInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToGraphSchemaTagInfo(dr);
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
        /// 根据曲线方案指标Id进行删除。
        /// </summary>
        /// <param name="keyId">曲线方案指标Id。</param>
        /// <returns>bool</returns>
        public bool Delete(Int32 keyId)
        {
            const string sqlStatement = @"UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [GraphSchemaTag] A
INNER JOIN [GraphSchemaTag] B ON A.[ItemId] = B.[ItemId] AND A.[SerialNumber] > B.[SerialNumber]
WHERE B.[KeyId] = @KeyId
DELETE FROM [GraphSchemaTag] WHERE [KeyId] = @KeyId";
            var parms = new[] { new SqlParameter("@KeyId", SqlDbType.Int) { Value = keyId } };
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
        /// 删除曲线方案指标。
        /// </summary>
        /// <param name="obj">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaTagInfo obj)
        {
            return Delete(obj.KeyId);
        }

        /// <summary>
        /// 添加曲线方案指标。
        /// </summary>
        /// <param name="tagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GraphSchemaTagInfo tagInfo)
        {
            return this.InsertWithTrans(null, tagInfo);
        }

        /// <summary>
        /// 添加曲线方案指标.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="tagInfo">指标对象.</param>
        /// <returns>bool</returns>
        public bool InsertWithTrans(SqlTransaction trans, GraphSchemaTagInfo tagInfo)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [GraphSchemaTag] WHERE [ItemId] = @ItemId
            INSERT INTO [GraphSchemaTag] ([ItemId],[TagId],[TagName],[CurveType],[CurveColor], [LineWidth], [SymbolType], [SymbolSize], [MAPeriod], [SerialNumber],[LineType],[SymbolColor]) VALUES (@ItemId,@TagId,@TagName,@CurveType, @CurveColor, @LineWidth, @SymbolType, @SymbolSize, @MAPeriod, @SerialNumber,@LineType,@SymbolColor)";
            var parms = new[] { 
                new SqlParameter("@ItemId", SqlDbType.Int) { Value = tagInfo.ItemId },
                new SqlParameter("@TagId", SqlDbType.NVarChar, 500) { Value = tagInfo.TagId },
                new SqlParameter("@TagName", SqlDbType.NVarChar, 50) { Value = tagInfo.TagName },
                new SqlParameter("@CurveType", SqlDbType.NVarChar, 20) { Value = tagInfo.CurveType },
                new SqlParameter("@CurveColor", SqlDbType.Int) { Value = tagInfo.CurveColor },
                new SqlParameter("@LineWidth", SqlDbType.Float) { Value = tagInfo.LineWidth },
                new SqlParameter("@SymbolType", SqlDbType.NVarChar, 20) { Value = tagInfo.SymbolType },
                new SqlParameter("@SymbolSize", SqlDbType.Float) { Value = tagInfo.SymbolSize },                
                new SqlParameter("@MAPeriod", SqlDbType.Float) { Value = tagInfo.MAPeriod },
                new SqlParameter("@LineType", SqlDbType.TinyInt) { Value = tagInfo.LineType },
                new SqlParameter("@SymbolColor", SqlDbType.Int) { Value = tagInfo.SymbolColor }
            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                else
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
        /// 修改曲线方案指标。
        /// </summary>
        /// <param name="tagInfo">曲线方案指标对象。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaTagInfo tagInfo)
        {
            const string sqlStatement = "UPDATE [GraphSchemaTag] SET [ItemId] = @ItemId,[TagId] = @TagId,[TagName] = @TagName,[CurveType] = @CurveType,[CurveColor] = @CurveColor,[LineWidth] = @LineWidth, [SymbolType] = @SymbolType, [MAPeriod] = @MAPeriod, [SymbolSize] = @SymbolSize,[LineType]=@LineType,[SymbolColor]=@SymbolColor WHERE [KeyId] = @KeyId";
            var parms = new[] { 
                new SqlParameter("@KeyId", SqlDbType.Int) { Value = tagInfo.KeyId },
                new SqlParameter("@ItemId", SqlDbType.Int) { Value = tagInfo.ItemId },
                new SqlParameter("@TagId", SqlDbType.NVarChar, 500) { Value = tagInfo.TagId },
                new SqlParameter("@TagName", SqlDbType.NVarChar, 50) { Value = tagInfo.TagName },
                new SqlParameter("@CurveType", SqlDbType.NVarChar, 20) { Value = tagInfo.CurveType },
                new SqlParameter("@CurveColor", SqlDbType.Int) { Value = tagInfo.CurveColor },
                new SqlParameter("@LineWidth", SqlDbType.Float) { Value = tagInfo.LineWidth },
                new SqlParameter("@SymbolType", SqlDbType.NVarChar, 20) { Value = tagInfo.SymbolType },
                new SqlParameter("@SymbolSize", SqlDbType.Float) { Value = tagInfo.SymbolSize },                
                new SqlParameter("@MAPeriod", SqlDbType.Float) { Value = tagInfo.MAPeriod },
                new SqlParameter("@LineType", SqlDbType.TinyInt) { Value = tagInfo.LineType },
                new SqlParameter("@SymbolColor", SqlDbType.Int) { Value = tagInfo.SymbolColor }
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
        /// 图表方案指标项移动。
        /// </summary>
        /// <param name="keyId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(Int32 keyId, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@KeyId", SqlDbType.Int) { Value = keyId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "GraphSchemaTag_Move", parms);
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
        /// 将IDataRecord转换为GraphSchemaTagInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>GraphSchemaTagInfo对象。</returns>
        static GraphSchemaTagInfo ConvertToGraphSchemaTagInfo(IDataRecord dr)
        {
            var obj = new GraphSchemaTagInfo
                          {
                              KeyId = Convert.ToInt32(dr["KeyId"]),
                              ItemId = Convert.ToInt32(dr["ItemId"]),
                              TagId = dr["TagId"].ToString(),
                              TagName = (dr["TagName"] == DBNull.Value ? String.Empty : dr["TagName"].ToString()),
                              CurveType = (dr["CurveType"] == DBNull.Value ? String.Empty : dr["CurveType"].ToString()),
                              CurveColor = (dr["CurveColor"] == DBNull.Value ? -16777216 : Convert.ToInt32(dr["CurveColor"])),
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"]),
                              LineWidth = Convert.ToSingle(dr["LineWidth"]),
                              SymbolSize = Convert.ToSingle(dr["SymbolSize"]),
                              SymbolType = (dr["SymbolType"] == DBNull.Value ? "None" : dr["SymbolType"].ToString()),
                              MAPeriod = Convert.ToInt32(dr["MAPeriod"]),
                              LineType = Convert.ToByte(dr["LineType"]),
                              SymbolColor = (dr["SymbolColor"] == DBNull.Value ? -16777216 : Convert.ToInt32(dr["SymbolColor"]))
                          };
            return obj;
        }
        #endregion

    }
}
