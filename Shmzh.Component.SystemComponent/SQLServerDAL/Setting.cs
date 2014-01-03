using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class Setting :ISetting
    {
        #region 属性
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = @"Insert Into [SettingInfo] ([SettingKey],[Value],[Description],[Category]) Values (@SettingKey,@Value,@Description,@Category)";
        private const string SQL_UPDATE = @"Update  [SettingInfo] set [SettingKey] = @SettingKey,[Value] = @Value,[Description] = @Description,[Category] = @Category where [SettingKey] = @SettingKey";
        private const string SQL_DELETE = @"Delete  [SettingInfo] where [SettingKey] = @SettingKey";
        // private const string SQL_SELECT_BY_Key = @"Select [SettingKey],[Value],[Description],[Category] From [SettingInfo] Where Category = @Category";
        private const string SQL_SELECT_BY_ID = @"Select [SettingKey],[Value],[Description],[Category] From [SettingInfo] Where SettingKey = @SettingKey";
        private const string SQL_SELECT_COUNT_BY_ID = @"Select Count(*) From SettingInfo Where SettingKey = @SettingKey";
        private const string SQL_SELECT_ALL = @"Select [SettingKey],[Value],[Description],[Category] From [SettingInfo]";
        private const string SQL_SELECT_Category = @"Select [SettingKey],[Value],[Description],[Category] From [SettingInfo] WHERE [Category] = @Category";
        #endregion 


        #region private 方法
        /// <summary>
        /// 获取查询模块参数。
        /// </summary>
        /// <returns>查询模块参数。</returns>
         private static SqlParameter[] GetSettingInfoParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@SettingKey", SqlDbType.NVarChar,50),
                                new SqlParameter("@Value", SqlDbType.NVarChar,100),
                                new SqlParameter("@Description", SqlDbType.NVarChar,255),
                                new SqlParameter("@Category", SqlDbType.NVarChar,10)
                            };
                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }

        /// <summary>
        /// 将DataRow转换成SEModuleInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>查询模块实体。</returns>
        private SettingInfo ConvertToSettingInfo(IDataRecord dr)
        {
            var obj = new SettingInfo
            {
                Key = dr.GetString(0),
                Value = dr.GetString(1),
                Category = dr["Category"] == DBNull.Value ? string.Empty : dr["Category"].ToString(),
                Remark = dr["Description"] == DBNull.Value ? string.Empty : dr["Description"].ToString(),
            };
            return obj;
        }
        #endregion 

        #region ISetting 成员

       

        public bool Insert(SettingInfo settingInfo)
        {
            var parms = GetSettingInfoParameters();
            parms[0].Value = settingInfo.Key;
            parms[1].Value = settingInfo.Value;
            parms[2].Value = string.IsNullOrEmpty(settingInfo.Remark) ? (object)DBNull.Value : settingInfo.Remark;
            parms[3].Value = settingInfo.Category;
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

        public bool Update(SettingInfo settingInfo)
        {
            var parms = GetSettingInfoParameters();
            parms[0].Value = settingInfo.Key;
            parms[1].Value = settingInfo.Value;
            parms[2].Value = string.IsNullOrEmpty(settingInfo.Remark) ? (object)DBNull.Value : settingInfo.Remark;
            parms[3].Value = settingInfo.Category;
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

        public bool Delete(SettingInfo settingInfo)
        {
            var parms = new[] {new SqlParameter("@SettingKey", SqlDbType.NVarChar,50) {Value = settingInfo.Key}};
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

        public bool Delete(string key)
        {
            var parms = new[] { new SqlParameter("@SettingKey", SqlDbType.NVarChar, 50) { Value = key } };
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

        public bool IsExist(string key)
        {
            try
            {
                var parms = new[] { new SqlParameter("@SettingKey", SqlDbType.NVarChar, 50) { Value = key } };
                var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_ID, parms);
                return (int)obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public IList<SettingInfo> GetAll()
        {
            try
            {
                var objs = new ListBase<SettingInfo>();
                var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
                while (dr.Read())
                {
                    objs.Add(ConvertToSettingInfo(dr));
                }
                dr.Close();
                return objs;
            } 
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new ListBase<SettingInfo>();
            }
        }

        public IList<SettingInfo> GetByCategory(String category)
        {
            var objs = new ListBase<SettingInfo>();
            try
            {
                var parms = new[] { new SqlParameter("@Category", SqlDbType.NVarChar, 10) { Value = category } };
                var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_Category, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToSettingInfo(dr));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return objs;
        }

        public SettingInfo GetByKey(string key)
        {
            SettingInfo obj = null;
            var parms = new[] { new SqlParameter("@SettingKey", SqlDbType.NVarChar,50) { Value = key } };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID, parms);
            while (dr.Read())
            {
                obj = ConvertToSettingInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
