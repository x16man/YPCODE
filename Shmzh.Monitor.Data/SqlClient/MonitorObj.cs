using System;
using System.Collections.Generic;
using System.Data;
using Shmzh.Monitor.Entity;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;


namespace Shmzh.Monitor.Data.SqlClient
{
    public class MonitorObj :IDAL.IMonitorObj
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_SELECT_BY_ID = @"Select * From MonitorObj Where Id = @Id";
        private const string SQL_SELECT_BY_CODE = @"Select * From MonitorObj Where Code = @Code";
        private const string SQL_SELECT_ALL = @"Select * From MonitorObj";
        private const string SQL_SELECT_BY_TYPEID = @"Select * From MonitorObj Where TypeId = @TypeId";
        private const string SQL_INSERT = @"Insert Into MonitorObj (Code,Name,TypeId,SerialNo,AttrField01,AttrField02,AttrField03,AttrField04,AttrField05,AttrField06,AttrField07,AttrField08,AttrField09,AttrField10,AttrField11,AttrField12,AttrField13,AttrField14,AttrField15,AttrField16,AttrField17,AttrField18,AttrField19,AttrField20)
 Values (@Code,@Name,@TypeId,@SerialNo,@AttrField01,@AttrField02,@AttrField03,@AttrField04,@AttrField05,@AttrField06,@AttrField07,@AttrField08,@AttrField09,@AttrField10,@AttrField11,@AttrField12,@AttrField13,@AttrField14,@AttrField15,@AttrField16,@AttrField17,@AttrField18,@AttrField19,@AttrField20)  SET @Id = SCOPE_IDENTITY()";
        private const string SQL_UPDATE = @"
Update MonitorObj 
Set Code = @Code,
    Name=@Name,
    TypeId = @TypeId, 
    SerialNo= @SerialNo,
    AttrField01 = @AttrField01,
    AttrField02 = @AttrField02, 
    AttrField03 = @AttrField03, 
    AttrField04 = @AttrField04,
    AttrField05 = @AttrField05,
    AttrField06 = @AttrField06,
    AttrField07 = @AttrField07,
    AttrField08 = @AttrField08,
    AttrField09 = @AttrField09,
    AttrField10 = @AttrField10,
    AttrField11 = @AttrField11,
    AttrField12 = @AttrField12,
    AttrField13 = @AttrField13,
    AttrField14 = @AttrField14,
    AttrField15 = @AttrField15,
    AttrField16 = @AttrField16,
    AttrField17 = @AttrField17,
    AttrField18 = @AttrField18,
    AttrField19 = @AttrField19,
    AttrField20 = @AttrField20 
Where Id = @Id";
        private const string SQL_DELETE = @"Delete From MonitorObj Where [ID] = @Id";
        #endregion

        #region private method
        private static MonitorObjInfo ConvertToDevAttrInfo(IDataRecord dr)
        {
            var obj = new MonitorObjInfo
            {
                Id = dr.GetInt32(0),
                Code = dr.GetString(1),
                Name = dr.GetString(2),
                TypeId = dr.GetInt32(3),
                SerialNo = dr.GetInt32(4),
                AttrField01 = dr["AttrField01"] == DBNull.Value?string.Empty:dr["AttrField01"].ToString(),
                AttrField02 = dr["AttrField02"] == DBNull.Value ? string.Empty : dr["AttrField02"].ToString(),
                AttrField03 = dr["AttrField03"] == DBNull.Value ? string.Empty : dr["AttrField03"].ToString(),
                AttrField04 = dr["AttrField04"] == DBNull.Value ? string.Empty : dr["AttrField04"].ToString(),
                AttrField05 = dr["AttrField05"] == DBNull.Value ? string.Empty : dr["AttrField05"].ToString(),
                AttrField06 = dr["AttrField06"] == DBNull.Value ? string.Empty : dr["AttrField06"].ToString(),
                AttrField07 = dr["AttrField07"] == DBNull.Value ? string.Empty : dr["AttrField07"].ToString(),
                AttrField08 = dr["AttrField08"] == DBNull.Value ? string.Empty : dr["AttrField08"].ToString(),
                AttrField09 = dr["AttrField09"] == DBNull.Value ? string.Empty : dr["AttrField09"].ToString(),
                AttrField10 = dr["AttrField10"] == DBNull.Value ? string.Empty : dr["AttrField10"].ToString(),
                AttrField11 = dr["AttrField11"] == DBNull.Value ? string.Empty : dr["AttrField11"].ToString(),
                AttrField12 = dr["AttrField12"] == DBNull.Value ? string.Empty : dr["AttrField12"].ToString(),
                AttrField13 = dr["AttrField13"] == DBNull.Value ? string.Empty : dr["AttrField13"].ToString(),
                AttrField14 = dr["AttrField14"] == DBNull.Value ? string.Empty : dr["AttrField14"].ToString(),
                AttrField15 = dr["AttrField15"] == DBNull.Value ? string.Empty : dr["AttrField15"].ToString(),
                AttrField16 = dr["AttrField16"] == DBNull.Value ? string.Empty : dr["AttrField16"].ToString(),
                AttrField17 = dr["AttrField17"] == DBNull.Value ? string.Empty : dr["AttrField17"].ToString(),
                AttrField18 = dr["AttrField18"] == DBNull.Value ? string.Empty : dr["AttrField18"].ToString(),
                AttrField19 = dr["AttrField19"] == DBNull.Value ? string.Empty : dr["AttrField19"].ToString(),
                AttrField20 = dr["AttrField20"] == DBNull.Value ? string.Empty : dr["AttrField20"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IMonitorObj 成员

        /// <summary>
        /// 根据监测对象分类Id获取检测对象属性记录实体。
        /// </summary>
        /// <param name="id">设备分类Id。</param>
        /// <returns>监测对象实体。</returns>
        public MonitorObjInfo GetById(int id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            MonitorObjInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_ID, parms);
                while (dr.Read())
                {
                    obj = ConvertToDevAttrInfo(dr);
                    break;
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
            return obj;
        }

        /// <summary>
        /// 根据编号获取监测对象。
        /// </summary>
        /// <param name="code">编号。</param>
        /// <returns>监测对象。</returns>
        public MonitorObjInfo GetByCode(string code)
        {
            var parms = new[] { new SqlParameter("@Code", SqlDbType.NVarChar,20) { Value = code } };
            MonitorObjInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_CODE, parms);
                while (dr.Read())
                {
                    obj = ConvertToDevAttrInfo(dr);
                    break;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr!=null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 获取所有的检测对象属性集合。
        /// </summary>
        /// <returns>检测对象集合。</returns>
        public List<MonitorObjInfo> GetAll()
        {
            var objs = new List<MonitorObjInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_ALL);
                while (dr.Read())
                {
                    objs.Add(ConvertToDevAttrInfo(dr));
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
        /// 根据设备分类Id获取设备属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备属性集合。</returns>
        public List<MonitorObjInfo> GetByTypeId(int typeId)
        {
            var parms = new[] { new SqlParameter("@TypeId", SqlDbType.Int) { Value = typeId } };
            var objs = new List<MonitorObjInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_TYPEID, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToDevAttrInfo(dr));
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
        /// 根据监测对象Id来删除监测对象。
        /// </summary>
        /// <param name="id">监测对象Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        public bool Delete(MonitorObjInfo monitorObjInfo)
        {
            return Delete(monitorObjInfo.Id);
        }

        /// <summary>
        /// 添加监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>int</returns>
        public int Insert(MonitorObjInfo monitorObjInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int)
                                    {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Code", SqlDbType.NVarChar, 20) {Value = monitorObjInfo.Code},
                                new SqlParameter("@Name", SqlDbType.NVarChar,50){Value = monitorObjInfo.Name},
                                new SqlParameter("@TypeId",SqlDbType.Int){Value = monitorObjInfo.TypeId},
                                new SqlParameter("@SerialNo", SqlDbType.Int){Value = monitorObjInfo.SerialNo},
                                new SqlParameter("@AttrField01", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField01},
                                new SqlParameter("@AttrField02", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField02},
                                new SqlParameter("@AttrField03", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField03},
                                new SqlParameter("@AttrField04", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField04},
                                new SqlParameter("@AttrField05", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField05},
                                new SqlParameter("@AttrField06", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField06},
                                new SqlParameter("@AttrField07", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField07},
                                new SqlParameter("@AttrField08", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField08},
                                new SqlParameter("@AttrField09", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField09},
                                new SqlParameter("@AttrField10", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField10},
                                new SqlParameter("@AttrField11", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField11},
                                new SqlParameter("@AttrField12", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField12},
                                new SqlParameter("@AttrField13", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField13},
                                new SqlParameter("@AttrField14", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField14},
                                new SqlParameter("@AttrField15", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField15},
                                new SqlParameter("@AttrField16", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField16},
                                new SqlParameter("@AttrField17", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField17},
                                new SqlParameter("@AttrField18", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField18},
                                new SqlParameter("@AttrField19", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField19},
                                new SqlParameter("@AttrField20", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField20},
                                
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, SQL_INSERT, parms);
                monitorObjInfo.Id = int.Parse(parms[0].ToString());
                return monitorObjInfo.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 监测对象。
        /// </summary>
        /// <param name="monitorObjInfo">监测对象。</param>
        /// <returns>bool</returns>
        public bool Update(MonitorObjInfo monitorObjInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Value = monitorObjInfo.Id},
                                new SqlParameter("@Code", SqlDbType.NVarChar, 20) {Value = monitorObjInfo.Code},
                                new SqlParameter("@Name", SqlDbType.NVarChar,50){Value = monitorObjInfo.Name},
                                new SqlParameter("@TypeId",SqlDbType.Int){Value = monitorObjInfo.TypeId},
                                new SqlParameter("@SerialNo", SqlDbType.Int){Value = monitorObjInfo.SerialNo},
                                new SqlParameter("@AttrField01", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField01},
                                new SqlParameter("@AttrField02", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField02},
                                new SqlParameter("@AttrField03", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField03},
                                new SqlParameter("@AttrField04", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField04},
                                new SqlParameter("@AttrField05", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField05},
                                new SqlParameter("@AttrField06", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField06},
                                new SqlParameter("@AttrField07", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField07},
                                new SqlParameter("@AttrField08", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField08},
                                new SqlParameter("@AttrField09", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField09},
                                new SqlParameter("@AttrField10", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField10},
                                new SqlParameter("@AttrField11", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField11},
                                new SqlParameter("@AttrField12", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField12},
                                new SqlParameter("@AttrField13", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField13},
                                new SqlParameter("@AttrField14", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField14},
                                new SqlParameter("@AttrField15", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField15},
                                new SqlParameter("@AttrField16", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField16},
                                new SqlParameter("@AttrField17", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField17},
                                new SqlParameter("@AttrField18", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField18},
                                new SqlParameter("@AttrField19", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField19},
                                new SqlParameter("@AttrField20", SqlDbType.NVarChar,100){Value = monitorObjInfo.AttrField20},
                                
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        #endregion

        #region IMonitorObj 成员

        /// <summary>
        /// 根据监测对象和指定的属性字段名称获取属性值。
        /// </summary>
        /// <param name="monitorObjCode">监测对象编号。</param>
        /// <param name="attrFieldName">属性字段名称。</param>
        /// <returns>属性值。</returns>
        public string GetAttributeValue(string monitorObjCode, string attrFieldName)
        {
            var sqlStatement = string.Format("Select {0} From MonitorObj Where Code = @Code",attrFieldName);
            var parms = new[] {new SqlParameter("@Code", SqlDbType.NVarChar, 20) {Value = monitorObjCode}};
            object obj = null;
            try
            {
                obj = SqlHelper.ExecuteScalar(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return obj == null ? string.Empty : obj.ToString();
        }

        #endregion
    }
}
