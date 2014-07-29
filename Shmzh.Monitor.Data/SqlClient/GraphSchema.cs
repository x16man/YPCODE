using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class GraphSchema : IDAL.IGraphSchema
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员

        /// <summary>
        /// 获取所有的曲线方案。
        /// </summary>
        /// <returns>曲线方案集合。</returns>
        public List<GraphSchemaInfo> GetAll()
        {
            const string sqlStatement = @"SELECT [SchemaId],[Name],[Remark],[IsValid],[Layout], [DataType], [TabWidth],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily],[LegendVisible]
                                                  ,[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack]
                                                  ,[LegendPosition],[Margin],[InnerPaneGap],[ReferLoginName],[ReferOpTime] 
                                          FROM [GraphSchema] ORDER BY [Name]";
            var objs = new List<GraphSchemaInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while ((dr.Read()))
                {
                    objs.Add(ConvertToGraphSchemaInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr != null ) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 根据方案Id获取方案信息。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <returns>方案信息实体。</returns>
        public GraphSchemaInfo GetById(Int32 schemaId)
        {
            const string sqlStatement = @"SELECT [SchemaId],[Name],[Remark],[IsValid],[Layout], [DataType], [TabWidth],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily],[LegendVisible]
                                                ,[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack]
                                                ,[LegendPosition],[Margin],[InnerPaneGap],[ReferLoginName],[ReferOpTime] 
                                            FROM [GraphSchema] 
                                            WHERE [SchemaId] = @SchemaId";
            var parms = new[] { new SqlParameter("@SchemaId", SqlDbType.Int) { Value = schemaId } };
            GraphSchemaInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToGraphSchemaInfo(dr);
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
        /// 根据方案Id获取所属的全部方案。
        /// </summary>
        /// <param name="categoryId">方案类别Id。</param>
        /// <returns></returns>
        public List<GraphSchemaInfo> GetByCategoryId(int categoryId)
        {
            const string sqlStatement = @"SELECT [SchemaId],[Name],[Remark],[IsValid],[Layout], [DataType], [TabWidth],A.[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily],[LegendVisible]
                                                ,[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack]
                                                ,[LegendPosition],[Margin],[InnerPaneGap],[ReferLoginName],[ReferOpTime] 
                                        FROM [GraphSchema] A INNER JOIN [CategoryItem] B 
                                        ON A.[Name] = B.[ConfigFile]
                                        WHERE B.[CategoryId] = @CategoryId
                                        ORDER BY [Name]";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            var objs = new List<GraphSchemaInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while ((dr.Read()))
                {
                    GraphSchemaInfo entity = ConvertToGraphSchemaInfo(dr);
                    objs.Add(entity);
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
        /// 获取未分类的方案。当loginName 为 null 或 "" 时取全部未分类的方案。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns></returns>
        public List<GraphSchemaInfo> GetNoCategorySchema(String loginName)
        {
            var sqlStatement = @"SELECT [SchemaId],[Name],[Remark],[IsValid],[Layout], [DataType], [TabWidth],A.[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily],[LegendVisible]
      ,[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack]
      ,[LegendPosition],[Margin],[InnerPaneGap],[ReferLoginName],[ReferOpTime] FROM [GraphSchema] A
WHERE [Name] NOT IN (SELECT DISTINCT [ConfigFile] FROM [CategoryItem])";
            if (!String.IsNullOrEmpty(loginName))
            {
                sqlStatement += String.Format(" AND [ReferLoginName] = '{0}'", loginName.Replace("'", "''"));
            }
            var objs = new List<GraphSchemaInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while ((dr.Read()))
                {
                    objs.Add(ConvertToGraphSchemaInfo(dr));
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
        /// 根据方案名称获取方案信息。
        /// </summary>
        /// <param name="name">方案名称。</param>
        /// <returns>方案信息实体。</returns>
        public GraphSchemaInfo GetByName(String name)
        {
            const string sqlStatement = @"SELECT [SchemaId],[Name],[Remark],[IsValid],[Layout], [DataType], [TabWidth],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily],[LegendVisible]
                                                  ,[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack]
                                                  ,[LegendPosition],[Margin],[InnerPaneGap],[ReferLoginName],[ReferOpTime] 
                                        FROM    [GraphSchema] 
                                        WHERE   [Name] = @Name";
            var parms = new[] { new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = name } };
            GraphSchemaInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                if (dr.Read())
                {
                    obj = ConvertToGraphSchemaInfo(dr);
                } 
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr != null ) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 根据曲线方案Id来删除曲线方案。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>bool</returns>
        public bool Delete(Int32 schemaId)
        {
            const string sqlStatement = @"DELETE FROM [GraphSchemaRTag] WHERE [TabId] IN (SELECT [TabId] FROM [GraphSchemaTab] WHERE [SchemaId] = @SchemaId)
                                            DELETE FROM [GraphSchemaTab] WHERE [SchemaId] = @SchemaId
                                            DELETE FROM [FloatingBlockItem] WHERE [BlockId] IN (SELECT [BlockId] FROM [FloatingBlock] WHERE [SchemaId] = @SchemaId)
                                            DELETE FROM [FloatingBlock] WHERE [SchemaId] = @SchemaId
                                            DELETE FROM [GraphSchemaTag] WHERE [ItemId] IN (SELECT [ItemId] FROM [GraphSchemaItem] WHERE [SchemaId] = @SchemaId)
                                            DELETE FROM [GraphSchemaItem] WHERE [SchemaId] = @SchemaId
                                            DELETE FROM [CategoryItem] FROM [CategoryItem] A INNER JOIN [GraphSchema] B ON A.[ConfigFile] = B.[Name] WHERE B.[SchemaId] = @SchemaId
                                            DELETE FROM [GraphSchema] WHERE [SchemaId] = @SchemaId";
            var parms = new[] { new SqlParameter("@SchemaId", SqlDbType.Int) { Value = schemaId } };
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
        /// 删除曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaInfo graphSchemaInfo)
        {
            return Delete(graphSchemaInfo.SchemaId);
        }

        /// <summary>
        /// 添加曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        public int Insert(GraphSchemaInfo graphSchemaInfo)
        {
            return this.InsertWithTrans(null, graphSchemaInfo);
        }

        /// <summary>
        /// 添加曲线方案对象.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="graphSchemaInfo">曲线方案对象.</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, GraphSchemaInfo graphSchemaInfo)
        {
            const string sqlStatement = @"INSERT INTO [GraphSchema] ([Name],[Remark],[IsValid],[Layout], [DataType], [TabWidth],[Title],[TitleVisible],[TitleFontSize],[TitleFontFamily],[LegendVisible]
                                                      ,[LegendFontSize],[LegendFontFamily],[LegendIsShowSymbols],[LegendIsHStack]
                                                      ,[LegendPosition],[Margin],[InnerPaneGap],[ReferLoginName],[ReferOpTime]) 
                                        VALUES (@Name,@Remark,@IsValid,@Layout,@DataType, @TabWidth,@Title,@TitleVisible,@TitleFontSize,@TitleFontFamily,@LegendVisible,
                                                @LegendFontSize,@LegendFontFamily,@LegendIsShowSymbols,@LegendIsHStack,@LegendPosition,@Margin,@InnerPaneGap, @ReferLoginName, getdate()) 
                                                SET @SchemaId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@SchemaId",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.Name },
                new SqlParameter("@Remark", SqlDbType.NVarChar, 255) { Value = graphSchemaInfo.Remark },
                new SqlParameter("@IsValid", SqlDbType.Bit) { Value = graphSchemaInfo.IsValid },
                new SqlParameter("@Layout", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.Layout },
                new SqlParameter("@DataType", SqlDbType.NVarChar, 20) { Value = graphSchemaInfo.DataType },
                new SqlParameter("@TabWidth", SqlDbType.Int){Value = graphSchemaInfo.TabWidth},
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.Title },
                new SqlParameter("@TitleVisible", SqlDbType.Bit) { Value = graphSchemaInfo.TitleVisible },
                new SqlParameter("@TitleFontSize", SqlDbType.Real) { Value = graphSchemaInfo.TitleFontSize },
                new SqlParameter("@TitleFontFamily", SqlDbType.NVarChar, 30) { Value = graphSchemaInfo.TitleFontFamily },
                new SqlParameter("@LegendVisible", SqlDbType.Bit) { Value = graphSchemaInfo.LegendVisible },
                new SqlParameter("@LegendFontSize", SqlDbType.Real) { Value = graphSchemaInfo.LegendFontSize },
                new SqlParameter("@LegendFontFamily", SqlDbType.NVarChar, 30) { Value = graphSchemaInfo.LegendFontFamily },
                new SqlParameter("@LegendIsShowSymbols", SqlDbType.Bit) { Value = graphSchemaInfo.LegendIsShowSymbols },
                new SqlParameter("@LegendIsHStack", SqlDbType.Bit) { Value = graphSchemaInfo.LegendIsHStack },
                new SqlParameter("@LegendPosition", SqlDbType.NVarChar, 20) { Value = graphSchemaInfo.LegendPosition },
                new SqlParameter("@Margin", SqlDbType.NVarChar, 30) { Value = graphSchemaInfo.Margin },
                new SqlParameter("@InnerPaneGap", SqlDbType.Real) { Value = graphSchemaInfo.InnerPaneGap },
                new SqlParameter("@ReferLoginName", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.ReferLoginName }
            };
            try
            {
                if(trans == null)
                {
                    SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                }
                else
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                }
                graphSchemaInfo.SchemaId = (int)parms[0].Value;
                return graphSchemaInfo.SchemaId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 修改曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>int</returns>
        public bool Update(GraphSchemaInfo graphSchemaInfo)
        {
            const string sqlStatement = @"UPDATE [GraphSchema] SET [Name] = @Name,[Remark] = @Remark,[IsValid] = @IsValid,[Layout] = @Layout, [DataType] = @DataType, [TabWidth] = @TabWidth 
            ,[Title]=@Title,[TitleVisible]=@TitleVisible,[TitleFontSize]=@TitleFontSize,[TitleFontFamily]=@TitleFontFamily,[LegendVisible]=@LegendVisible
      ,[LegendFontSize]=@LegendFontSize,[LegendFontFamily]=@LegendFontFamily,[LegendIsShowSymbols]=@LegendIsShowSymbols,[LegendIsHStack]=@LegendIsHStack
      ,[LegendPosition]=@LegendPosition,[Margin]=@Margin,[InnerPaneGap]=@InnerPaneGap,[ReferLoginName]=@ReferLoginName,[ReferOpTime]=getdate() WHERE [SchemaId] = @SchemaId";
            var parms = new[] { 
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = graphSchemaInfo.SchemaId },
                new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.Name },
                new SqlParameter("@Remark", SqlDbType.NVarChar, 255) { Value = graphSchemaInfo.Remark },
                new SqlParameter("@IsValid", SqlDbType.Bit) { Value = graphSchemaInfo.IsValid },
                new SqlParameter("@Layout", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.Layout },
                new SqlParameter("@DataType", SqlDbType.NVarChar, 20) { Value = graphSchemaInfo.DataType },
                new SqlParameter("@TabWidth", SqlDbType.Int){Value = graphSchemaInfo.TabWidth},
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.Title },
                new SqlParameter("@TitleVisible", SqlDbType.Bit) { Value = graphSchemaInfo.TitleVisible },
                new SqlParameter("@TitleFontSize", SqlDbType.Real) { Value = graphSchemaInfo.TitleFontSize },
                new SqlParameter("@TitleFontFamily", SqlDbType.NVarChar, 30) { Value = graphSchemaInfo.TitleFontFamily },
                new SqlParameter("@LegendVisible", SqlDbType.Bit) { Value = graphSchemaInfo.LegendVisible },
                new SqlParameter("@LegendFontSize", SqlDbType.Real) { Value = graphSchemaInfo.LegendFontSize },
                new SqlParameter("@LegendFontFamily", SqlDbType.NVarChar, 30) { Value = graphSchemaInfo.LegendFontFamily },
                new SqlParameter("@LegendIsShowSymbols", SqlDbType.Bit) { Value = graphSchemaInfo.LegendIsShowSymbols },
                new SqlParameter("@LegendIsHStack", SqlDbType.Bit) { Value = graphSchemaInfo.LegendIsHStack },
                new SqlParameter("@LegendPosition", SqlDbType.NVarChar, 20) { Value = graphSchemaInfo.LegendPosition },
                new SqlParameter("@Margin", SqlDbType.NVarChar, 30) { Value = graphSchemaInfo.Margin },
                new SqlParameter("@InnerPaneGap", SqlDbType.Real) { Value = graphSchemaInfo.InnerPaneGap },
                new SqlParameter("@ReferLoginName", SqlDbType.NVarChar, 50) { Value = graphSchemaInfo.ReferLoginName }
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
        /// 更新创建或修改人。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <param name="referLoginName">登录名。</param>
        /// <returns></returns>
        public bool UpdateLoginName(int schemaId, String referLoginName)
        {
            const string sqlStatement = @"UPDATE [GraphSchema] SET [ReferLoginName]=@ReferLoginName, [ReferOpTime]=getdate() WHERE [SchemaId] = @SchemaId";
            var parms = new[] {
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = schemaId },
                new SqlParameter("@ReferLoginName", SqlDbType.NVarChar, 50) { Value = referLoginName }
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
        /// 深层次保存曲线方案对象.
        /// </summary>
        /// <param name="obj">曲线方案对象.</param>
        /// <returns>bool</returns>
        public bool DeepSave(GraphSchemaInfo obj)
        {
            using (var conn = new SqlConnection(ConnectionString.Monitor))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var id = this.InsertWithTrans(trans, obj);//添加曲线方案.
                    if(id > 0)
                    {
                        foreach(var obj1 in obj.ItemList)//处理曲线方案项.
                        {
                            obj1.SchemaId = id;
                            var graphSchemaItemId = DataProvider.GraphSchemaItemProvider.InsertWithTrans(trans, obj1);
                            if(graphSchemaItemId > 0)
                            {
                                foreach(var tag in obj1.TagList)//处理曲线方案项指标.
                                {
                                    tag.ItemId = graphSchemaItemId;
                                    if(!DataProvider.GraphSchemaTagProvider.InsertWithTrans(trans, tag))
                                    {
                                        trans.Rollback();
                                        conn.Close();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                        foreach(var obj2 in obj.FloatingBlockInfos)
                        {
                            obj2.SchemaId = id;
                            var floatingBlockId = DataProvider.FloatingBlockProvider.InsertWithTrans(trans, obj2);
                            if(floatingBlockId > 0)
                            {
                                foreach (var floatingBlockItem in obj2.ItemList)
                                {
                                    floatingBlockItem.BlockId = floatingBlockId;
                                    if (!DataProvider.FloatingBlockItemProvider.InsertWithTrans(trans, floatingBlockItem))
                                    {
                                        trans.Rollback();
                                        conn.Close();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                        foreach (var obj3 in obj.GraphSchemaTabInfos)
                        {
                            obj3.SchemaId = id;
                            var graphSchemaTabId = DataProvider.GraphSchemaTabProvider.InsertWithTrans(trans, obj3);
                            if (graphSchemaTabId > 0)
                            {
                                foreach (var graphSchemaRTag in obj3.RTagList)
                                {
                                    graphSchemaRTag.TabId = graphSchemaTabId;
                                    if (!DataProvider.GraphSchemaRTagProvider.InsertWithTrans(trans, graphSchemaRTag))
                                    {
                                        trans.Rollback();
                                        conn.Close();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                conn.Close();
                                return false;
                            }
                        }
                        trans.Commit();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        Logger.Error("DeepSave:GraphSchemaProvider.Insert Failed!");
                        trans.Rollback();
                        conn.Close();
                        return false;
                    }
                }
            }
        }
        #endregion

        #region private method
        /// <summary>
        /// 将IDataRecord对象转换为GraphSchemaInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>GraphSchemaInfo对象。</returns>
        static GraphSchemaInfo ConvertToGraphSchemaInfo(IDataRecord dr)
        {
            var obj = new GraphSchemaInfo
                          {
                              SchemaId = Convert.ToInt32(dr["SchemaId"]),
                              Name = (dr["Name"] == DBNull.Value ? String.Empty : dr["Name"].ToString()),
                              Remark = (dr["Remark"] == DBNull.Value ? String.Empty : dr["Remark"].ToString()),
                              Layout = (dr["Layout"] == DBNull.Value ? String.Empty : dr["Layout"].ToString()),
                              IsValid = Convert.ToBoolean(dr["IsValid"]),
                              DataType = (dr["DataType"] == DBNull.Value ? String.Empty : dr["DataType"].ToString()),
                              TabWidth = Convert.ToInt32(dr["TabWidth"]),
                              Title = (dr["Title"] == DBNull.Value ? String.Empty : dr["Title"].ToString()),
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
            if (dr["Margin"] != DBNull.Value) obj.Margin = dr["Margin"].ToString();
            if (dr["InnerPaneGap"] != DBNull.Value) obj.InnerPaneGap = Convert.ToSingle(dr["InnerPaneGap"]);
            if (dr["ReferLoginName"] != DBNull.Value) obj.ReferLoginName = dr["ReferLoginName"].ToString();
            return obj;
        }
        #endregion

    }
}
