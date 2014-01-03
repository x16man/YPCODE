﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 查询引擎控件的参数随想的SQLServer的数据访问层。
    /// </summary>
    public class SEControlParam : IDAL.ISEControlParam
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = "Insert Into SEControlParam (ControlId,ParamName,ParamType,ParamValue,ParamIndex) Values (@ControlId,@ParamName,@ParamType,@ParamValue,@ParamIndex) SET @Id = SCOPE_IDENTITY()";

        private const string SQL_UPDATE =
            "Update SEControlParam Set ControlId = @ControlId,ParamName=@ParamName,ParamType=@ParamType,ParamValue=@ParamValue,ParamIndex=@ParamIndex Where Id = @Id";

        private const string SQL_DELETE = "Delete From SEControlParam Where Id = @Id";

        private const string SQL_SELECT_BY_CONTROL = "Select * From SEControlParam Where ControlId = @ControlId";
        private const string SQL_SELECT_BY_ID = "Select * From SEControlParam Where Id = @Id";
        #endregion

        #region private method
        /// <summary>
        /// 获取查询引擎的数据类型的参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ControlId", SqlDbType.Int),
                                new SqlParameter("@ParamName", SqlDbType.NVarChar,50),
                                new SqlParameter("@ParamType", SqlDbType.Int),
                                new SqlParameter("@ParamValue", SqlDbType.NVarChar,50), 
                                new SqlParameter("@ParamIndex", SqlDbType.TinyInt),
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
        private SEControlParamInfo ConvertToSEControlParamInfo(IDataRecord dr)
        {
            var obj = new SEControlParamInfo
            {
                Id = dr.GetInt32(0),
                ParamName = dr.GetString(1),
                ParamType = dr.GetInt32(2),
                ParamValue = dr.GetString(3),
                ParamIndex = dr.GetByte(4),
            };
            return obj;
        }
        #endregion

        #region ISEControlParam 成员

        /// <summary>
        /// 添加控件参数。
        /// </summary>
        /// <param name="obj">控件参数实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SEControlParamInfo obj)
        {
            var parms = GetParameters();
            parms[0].Value = 0;
            parms[1].Value = obj.ParamName;
            parms[2].Value = obj.ParamType;
            parms[3].Value = obj.ParamValue;
            parms[4].Value = obj.ParamIndex;
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
        /// 修改控件参数。
        /// </summary>
        /// <param name="obj">控件参数实体。</param>
        /// <returns>bool</returns>
        public bool Update(SEControlParamInfo obj)
        {
            var parms = GetParameters();
            parms[0].Value = 0;
            parms[1].Value = obj.ParamName;
            parms[2].Value = obj.ParamType;
            parms[3].Value = obj.ParamValue;
            parms[4].Value = obj.ParamIndex;
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
        /// 删除控件参数实体。
        /// </summary>
        /// <param name="obj">控件参数实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SEControlParamInfo obj)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = obj.Id}};
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
        /// 删除控件参数实体。
        /// </summary>
        /// <param name="id">控件参数实体id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
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
        /// 获取所有的控件参数。
        /// </summary>
        /// <returns>控件参数集合。</returns>
        public IList<SEControlParamInfo> GetByControlId(int controlId)
        {
            var parms = new[] {new SqlParameter("@ControlId", SqlDbType.Int) {Value = controlId}};
            var objs = new ListBase<SEControlParamInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_CONTROL, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlParamInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取控件参数。
        /// </summary>
        /// <param name="id">控件参数id。</param>
        /// <returns>控件参数实体。</returns>
        public SEControlParamInfo GetById(int id)
        {
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            SEControlParamInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID, parms);
            while (dr.Read())
            {
                obj = ConvertToSEControlParamInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
