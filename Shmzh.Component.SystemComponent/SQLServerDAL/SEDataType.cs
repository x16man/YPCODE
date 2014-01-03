using System;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 查询引擎的数据类型的SQLServer的数据访问层。
    /// </summary>
    public class SEDataType :IDAL.ISEDataType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT = @"Insert Into SEDataType ([Id],[Name],[Remark]) Values (@Id,@Name,@Remark) ";

        private const string SQL_UPDATE = @"Update SEDataType Set [Id]=@Id,[Name] = @Name, [Remark] = @Remark Where [Id] = @OldId";

        private const string SQL_DELETE = @"Delete From SEDataType Where [Id] = @Id";

        private const string SQL_SELECT_ALL = @"Select * From SEDataType";

        private const string SQL_SELECT_BY_ID = @"Select * From SEDataType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_ID = @"Select count(*) From SEDataType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_NAME = @"Select count(*) From SEDataType Where [Name]=@Name";
        #endregion

        #region private method
        /// <summary>
        /// 获取查询引擎的数据类型的参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetSEDataTypeParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.NVarChar,20), 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255), 
                                new SqlParameter("@OldId",SqlDbType.Int), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成SEDataTypeInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>查询引擎数据类型实体。</returns>
        private SEDataTypeInfo ConvertToSEDataTypeInfo(IDataRecord dr)
        {
            var obj = new SEDataTypeInfo
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion 

        #region ISEDataType 成员

        /// <summary>
        /// 添加数据类型。
        /// </summary>
        /// <param name="obj">数据类型实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SEDataTypeInfo obj)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.Name;
            parms[2].Value = string.IsNullOrEmpty(obj.Remark) ? (object) DBNull.Value : obj.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改数据类型。
        /// </summary>
        /// <param name="obj">数据类型实体。</param>
        /// <returns>bool</returns>
        public bool Update(SEDataTypeInfo obj)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.Name;
            parms[2].Value = string.IsNullOrEmpty(obj.Remark) ? (object)DBNull.Value : obj.Remark;
            parms[3].Value = obj.OldId;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除数据类型。
        /// </summary>
        /// <param name="obj">数据类型实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SEDataTypeInfo obj)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = obj.Id;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除数据类型。
        /// </summary>
        /// <param name="id">数据类型Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = id;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取所有数据类型集合。
        /// </summary>
        /// <returns>数据类型集合。</returns>
        public System.Collections.Generic.IList<SEDataTypeInfo> GetAll()
        {
            var objs = new ListBase<SEDataTypeInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToSEDataTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据id获取数据类型。
        /// </summary>
        /// <param name="id">数据类型Id</param>
        /// <returns>数据类型实体。</returns>
        public SEDataTypeInfo GetById(int id)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = id;
            SEDataTypeInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text,SQL_SELECT_BY_ID,parms );
            while (dr.Read())
            {
                obj = ConvertToSEDataTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

        #region ISEDataType 成员

        /// <summary>
        /// 判断ID是否已经存在。
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool IsExist(int id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断名称是否已经存在。
        /// </summary>
        /// <param name="name">名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string name)
        {
            var parms = new[] { new SqlParameter("@Name", SqlDbType.NVarChar,20) { Value = name } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }

        #endregion
    }
}