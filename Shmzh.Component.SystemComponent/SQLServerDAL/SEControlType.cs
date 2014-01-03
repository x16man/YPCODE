using System;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 查询引擎的控件类型的SQLServer的数据访问层。
    /// </summary>
    public class SEControlType :IDAL.ISEControlType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT = @"Insert Into SEControlType ([Id],[Name],[Remark]) Values (@Id,@Name,@Remark)";

        private const string SQL_UPDATE = @"Update SEControlType Set [Id]=@Id,[Name] = @Name, [Remark] = @Remark Where [Id] = @OldId";

        private const string SQL_DELETE = @"Delete From SEControlType Where [Id] = @Id";

        private const string SQL_SELECT_ALL = @"Select * From SEControlType";

        private const string SQL_SELECT_BY_ID = @"Select * From SEControlType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_ID = @"Select Count(*) From SEControlType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_NAME = @"Select Count(*) From SEControlType Where [Name] = @Name";
        #endregion

        #region private method
        /// <summary>
        /// 获取查询引擎的数据类型的参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetSEControlTypeParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.NVarChar,20), 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255),
                                new SqlParameter("@OldId", SqlDbType.Int), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成SEControlTypeInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>查询引擎控件类型实体。</returns>
        private SEControlTypeInfo ConvertToSEControlTypeInfo(IDataRecord dr)
        {
            var obj = new SEControlTypeInfo
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion 

        #region ISEControlType 成员

        /// <summary>
        /// 添加控件类型。
        /// </summary>
        /// <param name="obj">控件类型实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SEControlTypeInfo obj)
        {
            var parms = GetSEControlTypeParameters();
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
        /// 修改控件类型。
        /// </summary>
        /// <param name="obj">控件类型实体。</param>
        /// <returns>bool</returns>
        public bool Update(SEControlTypeInfo obj)
        {
            var parms = GetSEControlTypeParameters();
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
        /// 删除控件类型实体。
        /// </summary>
        /// <param name="obj">控件类型实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SEControlTypeInfo obj)
        {
            var parms = GetSEControlTypeParameters();
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
        /// 删除控件类型实体。
        /// </summary>
        /// <param name="id">控件类型实体id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetSEControlTypeParameters();
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
        /// 获取所有的控件类型。
        /// </summary>
        /// <returns>控件类型集合。</returns>
        public System.Collections.Generic.IList<SEControlTypeInfo> GetAll()
        {
            var objs = new ListBase<SEControlTypeInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取控件类型。
        /// </summary>
        /// <param name="id">控件类型id。</param>
        /// <returns>控件类型实体。</returns>
        public SEControlTypeInfo GetById(int id)
        {
            var parms = GetSEControlTypeParameters();
            parms[0].Value = id;
            SEControlTypeInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text,SQL_SELECT_BY_ID,parms );
            while (dr.Read())
            {
                obj = ConvertToSEControlTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 判断id是否已经存在。
        /// </summary>
        /// <param name="id">id。</param>
        /// <returns>bool</returns>
        public bool IsExist(int id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id},};
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断名称是否已经存在。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExist(string name)
        {
            var parms = new[] { new SqlParameter("@Name", SqlDbType.NVarChar,20) { Value = name }, };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }
        #endregion
    }
}