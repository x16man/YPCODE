using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class FloatingBlockItem : IDAL.IFloatingBlockItem
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IFloatingBlockItem 成员

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="blockId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<FloatingBlockItemInfo> GetByBlockId(Int32 blockId)
        {
            const string strSql = @"SELECT [BlockItemId],[BlockId],[Label],[Unit],[TagExp],[DataType]
      ,[ValueFontSize],[ValueFontFamily],[ValueForeColor],[UnitFontSize]
      ,[UnitFontFamily],[UnitForeColor],[SerialNumber] FROM [FloatingBlockItem] WHERE [BlockId] = @BlockId ORDER BY [SerialNumber], [BlockItemId]";
            var objs = new List<FloatingBlockItemInfo>();
            var parms = new[] { new SqlParameter("@BlockId", SqlDbType.Int) { Value = blockId }, };
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToFloatingBlockItemInfo(dr));
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
        /// 获取所有FloatingBlockItemInfo.
        /// </summary>
        /// <returns>所有FloatingBlockItemInfo.</returns>
        public List<FloatingBlockItemInfo> GetAll()
        {
            const string sqlStatement = @"SELECT [BlockItemId],[BlockId],[Label],[Unit],[TagExp],[DataType]
      ,[ValueFontSize],[ValueFontFamily],[ValueForeColor],[UnitFontSize]
      ,[UnitFontFamily],[UnitForeColor],[SerialNumber] FROM [FloatingBlockItem]";
            var objs = new List<FloatingBlockItemInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToFloatingBlockItemInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockItemId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public FloatingBlockItemInfo GetById(Int32 blockItemId)
        {
            const string sqlStatement = @"SELECT [BlockItemId],[BlockId],[Label],[Unit],[TagExp],[DataType]
      ,[ValueFontSize],[ValueFontFamily],[ValueForeColor],[UnitFontSize]
      ,[UnitFontFamily],[UnitForeColor],[SerialNumber] FROM [FloatingBlockItem] WHERE [BlockItemId] = @BlockItemId";
            var parms = new[] { new SqlParameter("@BlockItemId", SqlDbType.Int) { Value = blockItemId } };
            FloatingBlockItemInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToFloatingBlockItemInfo(dr);
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
        /// <param name="blockItemId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public Boolean Delete(Int32 blockItemId)
        {
            const string sqlStatement = @"UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [FloatingBlockItem] A
INNER JOIN [FloatingBlockItem] B ON A.[BlockId] = B.[BlockId] AND A.[SerialNumber] > B.[SerialNumber]
WHERE B.[BlockItemId] = @BlockItemId
DELETE FROM [FloatingBlockItem] WHERE [BlockItemId] = @BlockItemId";
            var parms = new[] { new SqlParameter("@BlockItemId", SqlDbType.Int) { Value = blockItemId } };
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
        public Boolean Delete(FloatingBlockItemInfo obj)
        {
            return Delete(obj.BlockItemId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Insert(FloatingBlockItemInfo blockItemInfo)
        {
            return this.InsertWithTrans(null, blockItemInfo);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="blockItemInfo">FloatingBlockItemInfo Instance.</param>
        /// <returns>bool</returns>
        public Boolean InsertWithTrans(SqlTransaction trans, FloatingBlockItemInfo blockItemInfo)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [FloatingBlockItem] WHERE [BlockId] = @BlockId
            INSERT INTO [FloatingBlockItem] ([BlockId],[Label],[Unit],[TagExp],[DataType]
      ,[ValueFontSize],[ValueFontFamily],[ValueForeColor],[UnitFontSize]
      ,[UnitFontFamily],[UnitForeColor],[SerialNumber]) VALUES (@BlockId,@Label,@Unit,@TagExp,@DataType,@ValueFontSize,
@ValueFontFamily,@ValueForeColor,@UnitFontSize,@UnitFontFamily,@UnitForeColor,@SerialNumber)";
            var parms = new[] { 
                new SqlParameter("@BlockId", SqlDbType.Int) { Value = blockItemInfo.BlockId },
                new SqlParameter("@Label", SqlDbType.NVarChar, 20) { Value = blockItemInfo.Label },
                new SqlParameter("@Unit", SqlDbType.NVarChar, 20) { Value = blockItemInfo.Unit },
                new SqlParameter("@TagExp", SqlDbType.NVarChar, 500) { Value = blockItemInfo.TagExp },
                new SqlParameter("@DataType", SqlDbType.NVarChar, 20) { Value = blockItemInfo.DataType },
                new SqlParameter("@ValueFontSize", SqlDbType.Real) { Value = blockItemInfo.ValueFontSize },
                new SqlParameter("@ValueFontFamily", SqlDbType.NVarChar, 30) { Value = blockItemInfo.ValueFontFamily },
                new SqlParameter("@ValueForeColor", SqlDbType.Int) { Value = blockItemInfo.ValueForeColor },
                new SqlParameter("@UnitFontSize", SqlDbType.Real) { Value = blockItemInfo.UnitFontSize },
                new SqlParameter("@UnitFontFamily", SqlDbType.NVarChar, 30) { Value = blockItemInfo.UnitFontFamily },
                new SqlParameter("@UnitForeColor", SqlDbType.Int) { Value = blockItemInfo.UnitForeColor },
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
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public Boolean Update(FloatingBlockItemInfo blockItemInfo)
        {
            const string sqlStatement = @"UPDATE [FloatingBlockItem] SET [BlockId]=@BlockId,[Label]=@Label,[Unit]=@Unit,[TagExp]=@TagExp,[DataType]=@DataType
      ,[ValueFontSize]=@ValueFontSize,[ValueFontFamily]=@ValueFontFamily,[ValueForeColor]=@ValueForeColor,[UnitFontSize]=@UnitFontSize
      ,[UnitFontFamily]=@UnitFontFamily,[UnitForeColor]=@UnitForeColor WHERE [BlockItemId] = @BlockItemId";
            var parms = new[] { 
                new SqlParameter("@BlockId", SqlDbType.Int) { Value = blockItemInfo.BlockId },
                new SqlParameter("@Label", SqlDbType.NVarChar, 20) { Value = blockItemInfo.Label },
                new SqlParameter("@Unit", SqlDbType.NVarChar, 20) { Value = blockItemInfo.Unit },
                new SqlParameter("@TagExp", SqlDbType.NVarChar, 500) { Value = blockItemInfo.TagExp },
                new SqlParameter("@DataType", SqlDbType.NVarChar, 20) { Value = blockItemInfo.DataType },
                new SqlParameter("@ValueFontSize", SqlDbType.Real) { Value = blockItemInfo.ValueFontSize },
                new SqlParameter("@ValueFontFamily", SqlDbType.NVarChar, 30) { Value = blockItemInfo.ValueFontFamily },
                new SqlParameter("@ValueForeColor", SqlDbType.Int) { Value = blockItemInfo.ValueForeColor },
                new SqlParameter("@UnitFontSize", SqlDbType.Real) { Value = blockItemInfo.UnitFontSize },
                new SqlParameter("@UnitFontFamily", SqlDbType.NVarChar, 30) { Value = blockItemInfo.UnitFontFamily },
                new SqlParameter("@UnitForeColor", SqlDbType.Int) { Value = blockItemInfo.UnitForeColor },
                new SqlParameter("@BlockItemId", SqlDbType.Int) { Value = blockItemInfo.BlockItemId }
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
        /// 浮动窗口项移动。
        /// </summary>
        /// <param name="blockItemId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(Int32 blockItemId, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@BlockItemId", SqlDbType.Int) { Value = blockItemId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "FloatingBlockItem_Move", parms);
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
        /// 将IDataRecord转换为FloatingBlockItemInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>FloatingBlockItemInfo对象。</returns>
        static FloatingBlockItemInfo ConvertToFloatingBlockItemInfo(IDataRecord dr)
        {
            var obj = new FloatingBlockItemInfo
                          {
                              BlockItemId = Convert.ToInt32(dr["BlockItemId"]),
                              BlockId = Convert.ToInt32(dr["BlockId"]),
                              Label = (dr["Label"] == DBNull.Value ? String.Empty : dr["Label"].ToString()),
                              Unit = (dr["Unit"] == DBNull.Value ? String.Empty : dr["Unit"].ToString()),
                              TagExp = (dr["TagExp"] == DBNull.Value ? String.Empty : dr["TagExp"].ToString()),
                              DataType = (dr["DataType"] == DBNull.Value ? String.Empty : dr["DataType"].ToString()),
                              ValueFontSize = Convert.ToSingle(dr["ValueFontSize"]),
                              ValueFontFamily = (dr["ValueFontFamily"] == DBNull.Value ? String.Empty : dr["ValueFontFamily"].ToString()),
                              ValueForeColor = Convert.ToInt32(dr["ValueForeColor"]),
                              UnitFontSize = Convert.ToSingle(dr["UnitFontSize"]),
                              UnitFontFamily = (dr["UnitFontFamily"] == DBNull.Value ? String.Empty : dr["UnitFontFamily"].ToString()),
                              UnitForeColor = Convert.ToInt32(dr["UnitForeColor"]),
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"])
                          };
            return obj;
        }
        #endregion

    }
}
