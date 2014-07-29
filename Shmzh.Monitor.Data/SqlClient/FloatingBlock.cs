using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class FloatingBlock : IDAL.IFloatingBlock
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
        public List<FloatingBlockInfo> GetBySchemaId(Int32 schemaId)
        {
            const string sqlStatement = @"SELECT [BlockId],[SchemaId],[BorderColor],[FillColor],[LableFontSize]
                                        ,[LableFontFamily],[LableForeColor],[X],[Y],[Width],[Height],[IsAutoSize],[IsLabelInLine] 
                                FROM [FloatingBlock] 
                                WHERE [SchemaId] = @SchemaId ORDER BY [BlockId]";
            var objs = new List<FloatingBlockInfo>();
            var parms = new[] { new SqlParameter("@SchemaId", SqlDbType.Int) { Value = schemaId }, };
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToFloatingBlockInfo(dr));
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
        /// 获取所有浮动窗口.
        /// </summary>
        /// <returns>所有浮动窗口.</returns>
        public List<FloatingBlockInfo> GetAll()
        {
            var sqlStatement =
                @"SELECT [BlockId],[SchemaId],[BorderColor],[FillColor],[LableFontSize]
                                                ,[LableFontFamily],[LableForeColor],[X],[Y],[Width],[Height],[IsAutoSize],[IsLabelInLine] 
                                            FROM [FloatingBlock]";
            var objs = new List<FloatingBlockInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToFloatingBlockInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public FloatingBlockInfo GetById(Int32 blockId)
        {
            const string sqlStatement = @"SELECT [BlockId],[SchemaId],[BorderColor],[FillColor],[LableFontSize]
                                                ,[LableFontFamily],[LableForeColor],[X],[Y],[Width],[Height],[IsAutoSize],[IsLabelInLine] 
                                            FROM [FloatingBlock] 
                                            WHERE [BlockId] = @BlockId";
            var parms = new[] { new SqlParameter("@BlockId", SqlDbType.Int) { Value = blockId } };
            FloatingBlockInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToFloatingBlockInfo(dr);
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
        /// <param name="blockId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public Boolean Delete(Int32 blockId)
        {
            const string sqlStatement = @"DELETE FROM [FloatingBlockItem] WHERE [BlockId] = @BlockId
DELETE FROM [FloatingBlock] WHERE [BlockId] = @BlockId";
            var parms = new[] { new SqlParameter("@BlockId", SqlDbType.Int) { Value = blockId } };
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
        public Boolean Delete(FloatingBlockInfo obj)
        {
            return Delete(obj.BlockId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public int Insert(FloatingBlockInfo blockInfo)
        {
            return this.InsertWithTrans(null, blockInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="blockInfo">浮动窗体对象.</param>
        /// <returns>int</returns>
        public int InsertWithTrans(SqlTransaction trans, FloatingBlockInfo blockInfo)
        {
            const string sqlStatement = @"INSERT INTO [FloatingBlock] ([SchemaId],[BorderColor],[FillColor],[LableFontSize]
      ,[LableFontFamily],[LableForeColor],[X],[Y],[Width],[Height],[IsAutoSize],[IsLabelInLine]) 
VALUES (@SchemaId,@BorderColor,@FillColor,@LableFontSize,
@LableFontFamily,@LableForeColor,@X,@Y,@Width,@Height,@IsAutoSize,@IsLabelInLine) SET @BlockId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@BlockId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = blockInfo.SchemaId },
                new SqlParameter("@BorderColor", SqlDbType.Int) { Value = blockInfo.BorderColor },
                new SqlParameter("@FillColor", SqlDbType.Int) { Value = blockInfo.FillColor },
                new SqlParameter("@LableFontSize", SqlDbType.Real) { Value = blockInfo.LableFontSize },
                new SqlParameter("@LableFontFamily", SqlDbType.NVarChar, 30) { Value = blockInfo.LableFontFamily },
                new SqlParameter("@LableForeColor", SqlDbType.Int) { Value = blockInfo.LableForeColor },
                new SqlParameter("@X", SqlDbType.Real) { Value = blockInfo.X },
                new SqlParameter("@Y", SqlDbType.Real) { Value = blockInfo.Y },
                new SqlParameter("@Width", SqlDbType.Real) { Value = blockInfo.Width },
                new SqlParameter("@Height", SqlDbType.Real) { Value = blockInfo.Height },
                new SqlParameter("@IsAutoSize", SqlDbType.Bit) { Value = blockInfo.IsAutoSize },
                new SqlParameter("@IsLabelInLine", SqlDbType.Bit) { Value = blockInfo.IsLabelInLine }
            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                blockInfo.BlockId = (int)parms[0].Value;
                return blockInfo.BlockId;
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
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public Boolean Update(FloatingBlockInfo blockInfo)
        {
            const string sqlStatement = @"UPDATE [FloatingBlock] SET [SchemaId] = @SchemaId,[BorderColor] = @BorderColor,[FillColor] = @FillColor,
                [LableFontSize] = @LableFontSize, [LableFontFamily] = @LableFontFamily, [LableForeColor] = @LableForeColor, X=@X, Y=@Y,[Width]=@Width,[Height]=@Height,[IsAutoSize]=@IsAutoSize,[IsLabelInLine]=@IsLabelInLine WHERE [BlockId] = @BlockId";
            var parms = new[] { 
                new SqlParameter("@BlockId", SqlDbType.Int) { Value = blockInfo.BlockId },
                new SqlParameter("@SchemaId", SqlDbType.Int) { Value = blockInfo.SchemaId },
                new SqlParameter("@BorderColor", SqlDbType.Int) { Value = blockInfo.BorderColor },
                new SqlParameter("@FillColor", SqlDbType.Int) { Value = blockInfo.FillColor },
                new SqlParameter("@LableFontSize", SqlDbType.Real) { Value = blockInfo.LableFontSize },
                new SqlParameter("@LableFontFamily", SqlDbType.NVarChar, 30) { Value = blockInfo.LableFontFamily },
                new SqlParameter("@LableForeColor", SqlDbType.Int) { Value = blockInfo.LableForeColor },
                new SqlParameter("@X", SqlDbType.Real) { Value = blockInfo.X },
                new SqlParameter("@Y", SqlDbType.Real) { Value = blockInfo.Y },
                new SqlParameter("@Width", SqlDbType.Real) { Value = blockInfo.Width },
                new SqlParameter("@Height", SqlDbType.Real) { Value = blockInfo.Height },
                new SqlParameter("@IsAutoSize", SqlDbType.Bit) { Value = blockInfo.IsAutoSize },
                new SqlParameter("@IsLabelInLine", SqlDbType.Bit) { Value = blockInfo.IsLabelInLine }
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

        #endregion

        #region private method
        /// <summary>
        /// 将IDataRecord转换为FloatingBlockInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>FloatingBlockInfo对象。</returns>
        static FloatingBlockInfo ConvertToFloatingBlockInfo(IDataRecord dr)
        {
            var obj = new FloatingBlockInfo
                          {
                              BlockId = Convert.ToInt32(dr["BlockId"]),
                              SchemaId = Convert.ToInt32(dr["SchemaId"]),
                              BorderColor = Convert.ToInt32(dr["BorderColor"]),
                              FillColor = Convert.ToInt32(dr["FillColor"]),
                              LableFontSize = Convert.ToSingle(dr["LableFontSize"]),
                              LableFontFamily = (dr["LableFontFamily"] == DBNull.Value ? String.Empty : dr["LableFontFamily"].ToString()),
                              LableForeColor = Convert.ToInt32(dr["LableForeColor"]),
                              X = Convert.ToSingle(dr["X"]),
                              Y = Convert.ToSingle(dr["Y"]),
                              Width = Convert.ToSingle(dr["Width"]),
                              Height = Convert.ToSingle(dr["Height"]),
                              IsAutoSize = Convert.ToBoolean(dr["IsAutoSize"]),
                              IsLabelInLine = Convert.ToBoolean(dr["IsLabelInLine"])
                          };
            return obj;
        }
        #endregion

    }
}
