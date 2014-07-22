using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class GraphSchemaItem : IDAL.IGraphSchemaItem
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员

        /// <summary>
        /// 获取所有的曲线方案项。
        /// </summary>
        /// <returns>所有的曲线方案项。</returns>
        public List<GraphSchemaItemInfo> GetAll()
        {
            const string sqlStatement = @"Select [ItemId],[SchemaId],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily]
                                                  ,[LegendVisible],[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack],[LegendPosition]
                                                  ,[XAxis],[XScaleVisible],[XScaleFontSize],[XScaleFontFamily],[XTitleVisible]
                                                  ,[XTitleFontSize],[XTitleFontFamily],[YAxis],[YScaleVisible],[YScaleFontSize]
                                                  ,[YScaleFontFaminly],[YTitleVisible],[YTitleFontSize],[YTitleFontFamily],[XScaleFormat],[YScaleFormat]
                                                  ,[MinSpaceL],[MinSpaceR],[SerialNumber] 
                                        FROM [GraphSchemaItem] 
                                        ORDER BY [SerialNumber]";
            var objs = new List<GraphSchemaItemInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaItemInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 根据曲线方案Id获取所有的
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线方案项集合。</returns>
        public List<GraphSchemaItemInfo> GetBySchemaId(Int32 schemaId)
        {
            const string sqlStatement = @"SELECT [ItemId],[SchemaId],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily]
                                                  ,[LegendVisible],[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack],[LegendPosition]
                                                  ,[XAxis],[XScaleVisible],[XScaleFontSize],[XScaleFontFamily],[XTitleVisible]
                                                  ,[XTitleFontSize],[XTitleFontFamily],[YAxis],[YScaleVisible],[YScaleFontSize]
                                                  ,[YScaleFontFaminly],[YTitleVisible],[YTitleFontSize],[YTitleFontFamily],[XScaleFormat],[YScaleFormat]
                                                  ,[MinSpaceL],[MinSpaceR],[SerialNumber] 
                                        FROM    [GraphSchemaItem] 
                                        WHERE   [SchemaId] = @SchemaId 
                                        ORDER BY [SerialNumber]";
            var objs = new List<GraphSchemaItemInfo>();
            var parms = new[] { new SqlParameter("@SchemaId", SqlDbType.Int) { Value = schemaId } };
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToGraphSchemaItemInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 根据方案项Id获取曲线方案项。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>曲线方案项实体。</returns>
        public GraphSchemaItemInfo GetById(Int32 itemId)
        {
            const string sqlStatement = @"SELECT [ItemId],[SchemaId],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily]
      ,[LegendVisible],[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack],[LegendPosition]
      ,[XAxis],[XScaleVisible],[XScaleFontSize],[XScaleFontFamily],[XTitleVisible]
      ,[XTitleFontSize],[XTitleFontFamily],[YAxis],[YScaleVisible],[YScaleFontSize]
      ,[YScaleFontFaminly],[YTitleVisible],[YTitleFontSize],[YTitleFontFamily],[XScaleFormat],[YScaleFormat]
      ,[MinSpaceL],[MinSpaceR],[SerialNumber] FROM [GraphSchemaItem] WHERE [ItemId] = @ItemId";
            var parms = new[] { new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId } };
            GraphSchemaItemInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToGraphSchemaItemInfo(dr);
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr != null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 根据曲线方案项Id进行删除。
        /// </summary>
        /// <param name="itemId">曲线方案项Id。</param>
        /// <returns>bool</returns>
        public bool Delete(Int32 itemId)
        {
            const string sqlStatement = @"DELETE FROM [GraphSchemaTag] WHERE [ItemId] = @ItemId
UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [GraphSchemaItem] A
INNER JOIN [GraphSchemaItem] B ON A.[SchemaId] = B.[SchemaId] AND A.[SerialNumber] > B.[SerialNumber]
WHERE B.[ItemId] = @ItemId
DELETE FROM [GraphSchemaItem] WHERE [ItemId] = @ItemId";
            var parms = new[] { new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId } };
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
        /// 删除曲线方案项。
        /// </summary>
        /// <param name="obj">曲线方案项。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaItemInfo obj)
        {
            return Delete(obj.ItemId);
        }

        /// <summary>
        /// 添加曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>int</returns>
        public int Insert(GraphSchemaItemInfo itemInfo)
        {
            return this.InsertWithTrans(null, itemInfo);
        }

        /// <summary>
        /// 添加曲线方案项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="itemInfo">曲线方案项</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, GraphSchemaItemInfo itemInfo)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [GraphSchemaItem] WHERE [SchemaId] = @SchemaId
INSERT INTO [GraphSchemaItem] ([SchemaId],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily]
      ,[LegendVisible],[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack],[LegendPosition]
      ,[XAxis],[XScaleVisible],[XScaleFontSize],[XScaleFontFamily],[XTitleVisible]
      ,[XTitleFontSize],[XTitleFontFamily],[YAxis],[YScaleVisible],[YScaleFontSize]
      ,[YScaleFontFaminly],[YTitleVisible],[YTitleFontSize],[YTitleFontFamily],[XScaleFormat],[YScaleFormat]
      ,[MinSpaceL],[MinSpaceR],[SerialNumber]) VALUES (@SchemaId,@Title,@TitleVisible,@TitleFontSize,@TitleFontFamily,
      @LegendVisible,@LegendFontSize,@LegendFontFamily,@LegendIsShowSymbols,@LegendIsHStack,@LegendPosition,
      @XAxis,@XScaleVisible,@XScaleFontSize,@XScaleFontFamily,@XTitleVisible,
      @XTitleFontSize,@XTitleFontFamily,@YAxis,@YScaleVisible,@YScaleFontSize,
      @YScaleFontFaminly,@YTitleVisible,@YTitleFontSize,@YTitleFontFamily,@XScaleFormat,@YScaleFormat,
      @MinSpaceL,@MinSpaceR,@SerialNumber) SET @ItemId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@ItemId", SqlDbType.Int){ Direction = ParameterDirection.Output },
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = itemInfo.SchemaId },
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = itemInfo.Title },
                new SqlParameter("@XAxis", SqlDbType.NVarChar, 50) { Value = itemInfo.XAxis },
                new SqlParameter("@YAxis", SqlDbType.NVarChar, 50) { Value = itemInfo.YAxis },
                new SqlParameter("@TitleVisible", SqlDbType.Bit) { Value = itemInfo.TitleVisible },
                new SqlParameter("@TitleFontSize", SqlDbType.Real) { Value = itemInfo.TitleFontSize },
                new SqlParameter("@TitleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.TitleFontFamily },
                new SqlParameter("@LegendVisible", SqlDbType.Bit) { Value = itemInfo.LegendVisible },
                new SqlParameter("@LegendFontSize", SqlDbType.Real) { Value = itemInfo.LegendFontSize },
                new SqlParameter("@LegendFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.LegendFontFamily },
                new SqlParameter("@LegendIsShowSymbols", SqlDbType.Bit) { Value = itemInfo.LegendIsShowSymbols },
                new SqlParameter("@LegendIsHStack", SqlDbType.Bit) { Value = itemInfo.LegendIsHStack },
                new SqlParameter("@LegendPosition", SqlDbType.NVarChar, 20) { Value = itemInfo.LegendPosition },
                new SqlParameter("@XScaleVisible", SqlDbType.Bit) { Value = itemInfo.XScaleVisible },
                new SqlParameter("@XScaleFontSize", SqlDbType.Real) { Value = itemInfo.XScaleFontSize },
                new SqlParameter("@XScaleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.XScaleFontFamily },
                new SqlParameter("@XTitleVisible", SqlDbType.Bit) { Value = itemInfo.XTitleVisible },
                new SqlParameter("@XTitleFontSize", SqlDbType.Real) { Value = itemInfo.XTitleFontSize },
                new SqlParameter("@XTitleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.XTitleFontFamily },
                new SqlParameter("@YScaleVisible", SqlDbType.Bit) { Value = itemInfo.YScaleVisible },
                new SqlParameter("@YScaleFontSize", SqlDbType.Real) { Value = itemInfo.YScaleFontSize },
                new SqlParameter("@YScaleFontFaminly", SqlDbType.NVarChar, 30) { Value = itemInfo.YScaleFontFaminly },
                new SqlParameter("@YTitleVisible", SqlDbType.Bit) { Value = itemInfo.YTitleVisible },
                new SqlParameter("@YTitleFontSize", SqlDbType.Real) { Value = itemInfo.YTitleFontSize },
                new SqlParameter("@YTitleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.YTitleFontFamily },
                new SqlParameter("@XScaleFormat", SqlDbType.NVarChar, 30) { Value = itemInfo.XScaleFormat },
                new SqlParameter("@YScaleFormat", SqlDbType.NVarChar, 30) { Value = itemInfo.YScaleFormat },
                new SqlParameter("@MinSpaceL", SqlDbType.Real) { Value = itemInfo.MinSpaceL },
                new SqlParameter("@MinSpaceR", SqlDbType.Real) { Value = itemInfo.MinSpaceR },
            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                
                itemInfo.ItemId = (int)parms[0].Value;
                return itemInfo.ItemId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 修改曲线方案项。
        /// </summary>
        /// <param name="itemInfo">曲线方案项。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaItemInfo itemInfo)
        {
            const string sqlStatement = @"UPDATE [GraphSchemaItem] SET [SchemaId] = @SchemaId,[Title] = @Title,
[TitleVisible]=@TitleVisible,[TitleFontSize]=@TitleFontSize,[TitleFontFamily]=@TitleFontFamily
,[LegendVisible]=@LegendVisible,[LegendFontSize]=@LegendFontSize,[LegendFontFamily]=@LegendFontFamily,[LegendIsShowSymbols]=@LegendIsShowSymbols,[LegendIsHStack]=@LegendIsHStack,[LegendPosition]=@LegendPosition
      ,[XAxis] = @XAxis,[XScaleVisible]=@XScaleVisible,[XScaleFontSize]=@XScaleFontSize,[XScaleFontFamily]=@XScaleFontFamily,[XTitleVisible]=@XTitleVisible
      ,[XTitleFontSize]=@XTitleFontSize,[XTitleFontFamily]=@XTitleFontFamily,[YAxis] = @YAxis,[YScaleVisible]=@YScaleVisible,[YScaleFontSize]=@YScaleFontSize
      ,[YScaleFontFaminly]=@YScaleFontFaminly,[YTitleVisible]=@YTitleVisible,[YTitleFontSize]=@YTitleFontSize,[YTitleFontFamily]=@YTitleFontFamily
      ,[XScaleFormat]=@XScaleFormat,[YScaleFormat]=@YScaleFormat
      ,[MinSpaceL]=@MinSpaceL,[MinSpaceR]=@MinSpaceR WHERE [ItemId] = @ItemId";
            var parms = new[] { 
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = itemInfo.SchemaId },
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = itemInfo.Title },
                new SqlParameter("@XAxis", SqlDbType.NVarChar, 50) { Value = itemInfo.XAxis },
                new SqlParameter("@YAxis", SqlDbType.NVarChar, 50) { Value = itemInfo.YAxis },
                new SqlParameter("@TitleVisible", SqlDbType.Bit) { Value = itemInfo.TitleVisible },
                new SqlParameter("@TitleFontSize", SqlDbType.Real) { Value = itemInfo.TitleFontSize },
                new SqlParameter("@TitleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.TitleFontFamily },
                new SqlParameter("@LegendVisible", SqlDbType.Bit) { Value = itemInfo.LegendVisible },
                new SqlParameter("@LegendFontSize", SqlDbType.Real) { Value = itemInfo.LegendFontSize },
                new SqlParameter("@LegendFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.LegendFontFamily },
                new SqlParameter("@LegendIsShowSymbols", SqlDbType.Bit) { Value = itemInfo.LegendIsShowSymbols },
                new SqlParameter("@LegendIsHStack", SqlDbType.Bit) { Value = itemInfo.LegendIsHStack },
                new SqlParameter("@LegendPosition", SqlDbType.NVarChar, 20) { Value = itemInfo.LegendPosition },
                new SqlParameter("@XScaleVisible", SqlDbType.Bit) { Value = itemInfo.XScaleVisible },
                new SqlParameter("@XScaleFontSize", SqlDbType.Real) { Value = itemInfo.XScaleFontSize },
                new SqlParameter("@XScaleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.XScaleFontFamily },
                new SqlParameter("@XTitleVisible", SqlDbType.Bit) { Value = itemInfo.XTitleVisible },
                new SqlParameter("@XTitleFontSize", SqlDbType.Real) { Value = itemInfo.XTitleFontSize },
                new SqlParameter("@XTitleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.XTitleFontFamily },
                new SqlParameter("@YScaleVisible", SqlDbType.Bit) { Value = itemInfo.YScaleVisible },
                new SqlParameter("@YScaleFontSize", SqlDbType.Real) { Value = itemInfo.YScaleFontSize },
                new SqlParameter("@YScaleFontFaminly", SqlDbType.NVarChar, 30) { Value = itemInfo.YScaleFontFaminly },
                new SqlParameter("@YTitleVisible", SqlDbType.Bit) { Value = itemInfo.YTitleVisible },
                new SqlParameter("@YTitleFontSize", SqlDbType.Real) { Value = itemInfo.YTitleFontSize },
                new SqlParameter("@YTitleFontFamily", SqlDbType.NVarChar, 30) { Value = itemInfo.YTitleFontFamily },
                new SqlParameter("@XScaleFormat", SqlDbType.NVarChar, 30) { Value = itemInfo.XScaleFormat },
                new SqlParameter("@YScaleFormat", SqlDbType.NVarChar, 30) { Value = itemInfo.YScaleFormat },
                new SqlParameter("@MinSpaceL", SqlDbType.Real) { Value = itemInfo.MinSpaceL },
                new SqlParameter("@MinSpaceR", SqlDbType.Real) { Value = itemInfo.MinSpaceR },
                new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemInfo.ItemId }
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
        /// 曲线方案 Item 移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(Int32 itemId, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "GraphSchemaItem_Move", parms);
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
        /// 将IDataRecord对象转换为GraphSchemaItemInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>GraphSchemaItemInfo对象。</returns>
        static GraphSchemaItemInfo ConvertToGraphSchemaItemInfo(IDataRecord dr)
        {
            var obj = new GraphSchemaItemInfo
                          {
                              ItemId = Convert.ToInt32(dr["ItemId"]),
                              SchemaId = Convert.ToInt32(dr["SchemaId"]),
                              Title = (dr["Title"] == DBNull.Value ? String.Empty : dr["Title"].ToString()),
                              XAxis = (dr["XAxis"] == DBNull.Value ? String.Empty : dr["XAxis"].ToString()),
                              YAxis = (dr["YAxis"] == DBNull.Value ? String.Empty : dr["YAxis"].ToString()),
                              TitleVisible = Convert.ToBoolean(dr["TitleVisible"])
                          };
            if (dr["TitleFontSize"] != DBNull.Value) obj.TitleFontSize = Convert.ToSingle(dr["TitleFontSize"]);
            if (dr["TitleFontFamily"] != DBNull.Value) obj.TitleFontFamily = dr["TitleFontFamily"].ToString();

            obj.LegendVisible = Convert.ToBoolean(dr["LegendVisible"]);
            if (dr["LegendFontSize"] != DBNull.Value) obj.LegendFontSize = Convert.ToSingle(dr["LegendFontSize"]);
            if (dr["LegendFontFamily"] != DBNull.Value) obj.LegendFontFamily = dr["LegendFontFamily"].ToString();
            if (dr["LegendIsShowSymbols"] != DBNull.Value) obj.LegendIsShowSymbols = Convert.ToBoolean(dr["LegendIsShowSymbols"]);
            if (dr["LegendIsHStack"] != DBNull.Value) obj.LegendIsHStack = Convert.ToBoolean(dr["LegendIsHStack"]);
            if (dr["LegendPosition"] != DBNull.Value) obj.LegendPosition = dr["LegendPosition"].ToString();

            obj.XScaleVisible = Convert.ToBoolean(dr["XScaleVisible"]);
            if (dr["XScaleFontSize"] != DBNull.Value) obj.XScaleFontSize = Convert.ToSingle(dr["XScaleFontSize"]);
            if (dr["XScaleFontFamily"] != DBNull.Value) obj.XScaleFontFamily = dr["XScaleFontFamily"].ToString();

            obj.XTitleVisible = Convert.ToBoolean(dr["XTitleVisible"]);
            if (dr["XTitleFontSize"] != DBNull.Value) obj.XTitleFontSize = Convert.ToSingle(dr["XTitleFontSize"]);
            if (dr["XTitleFontFamily"] != DBNull.Value) obj.XTitleFontFamily = dr["XTitleFontFamily"].ToString();

            obj.YScaleVisible = Convert.ToBoolean(dr["YScaleVisible"]);
            if (dr["YScaleFontSize"] != DBNull.Value) obj.YScaleFontSize = Convert.ToSingle(dr["YScaleFontSize"]);
            if (dr["YScaleFontFaminly"] != DBNull.Value) obj.YScaleFontFaminly = dr["YScaleFontFaminly"].ToString();

            obj.YTitleVisible = Convert.ToBoolean(dr["YTitleVisible"]);
            if (dr["YTitleFontSize"] != DBNull.Value) obj.YTitleFontSize = Convert.ToSingle(dr["YTitleFontSize"]);
            if (dr["YTitleFontFamily"] != DBNull.Value) obj.YTitleFontFamily = dr["YTitleFontFamily"].ToString();

            if (dr["XScaleFormat"] != DBNull.Value) obj.XScaleFormat = dr["XScaleFormat"].ToString();
            if (dr["YScaleFormat"] != DBNull.Value) obj.YScaleFormat = dr["YScaleFormat"].ToString();

            if (dr["MinSpaceL"] != DBNull.Value) obj.MinSpaceL = Convert.ToSingle(dr["MinSpaceL"]);
            if (dr["MinSpaceR"] != DBNull.Value) obj.MinSpaceR = Convert.ToSingle(dr["MinSpaceR"]);
            if (dr["SerialNumber"] != DBNull.Value) obj.SerialNumber = Convert.ToInt32(dr["SerialNumber"]);

            return obj;
        }
        #endregion
    }
}
