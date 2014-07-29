using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjTypeAttr : IDAL.IObjTypeAttr
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_SELECT_BY_ID = @"Select * From ObjTypeAttr Where Id = @Id";
        private const string SQL_SELECT_BY_TYPEID = @"Select * From ObjTypeAttr Where TypeId = @TypeId";
        private const string SQL_INSERT = @"Insert Into ObjTypeAttr(Name,SerialNo,TypeId,FieldName,DataType) Values (@Name,@SerialNo,@TypeId,@FieldName,@DataType)  SET @Id = SCOPE_IDENTITY()";
        private const string SQL_UPDATE = @"Update ObjTypeAttr Set Name=@Name,SerialNo = @SerialNo,TypeId = @TypeId,FieldName = @FieldName,DataType = @DataType Where Id = @Id";
        private const string SQL_DELETE = @"Delete From ObjTypeAttr Where Id = @Id";
        #endregion

        #region private method
        private static ObjTypeAttrInfo ConvertToDevTypeAttrInfo(IDataRecord dr)
        {
            var obj = new ObjTypeAttrInfo
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                SerialNo = dr.GetInt16(2),
                TypeId = dr.GetInt32(3),
                FieldName = dr.GetString(4),
                DataType = dr.GetString(5),
            };
            return obj;
        }
        #endregion

        #region IObjTypeAttr 成员

        /// <summary>
        /// 根据方案Id获取设备分类属性实体。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>设备分类属性实体。</returns>
        public ObjTypeAttrInfo GetById(int id)
        {
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            ObjTypeAttrInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_ID, parms);
                while (dr.Read())
                {
                    obj = ConvertToDevTypeAttrInfo(dr);
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
        /// 根据设备分类Id获取设备分类属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备分类属性集合。</returns>
        public List<ObjTypeAttrInfo> GetByTypeId(int typeId)
        {
            var parms = new[] { new SqlParameter("@TypeId", SqlDbType.Int) { Value = typeId } };
            var objs = new List<ObjTypeAttrInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_TYPEID, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToDevTypeAttrInfo(dr));
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
        /// 根据设备分类属性Id来删除设备分类属性。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
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
        /// 删除设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public bool Delete(ObjTypeAttrInfo objTypeAttrInfo)
        {
            return Delete(objTypeAttrInfo.Id);
        }

        /// <summary>
        /// 添加设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public int Insert(ObjTypeAttrInfo objTypeAttrInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int)
                                    {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = objTypeAttrInfo.Name},
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt){Value = objTypeAttrInfo.SerialNo},
                                new SqlParameter("@TypeId", SqlDbType.Int){Value = objTypeAttrInfo.TypeId},
                                new SqlParameter("@FieldName",SqlDbType.NVarChar,20){Value = objTypeAttrInfo.FieldName},
                                new SqlParameter("@DataType", SqlDbType.NVarChar,20){Value = objTypeAttrInfo.DataType}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, SQL_INSERT, parms);
                objTypeAttrInfo.Id = int.Parse(parms[0].Value.ToString());
                return objTypeAttrInfo.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 修改设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public bool Update(ObjTypeAttrInfo objTypeAttrInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Value = objTypeAttrInfo.Id},
                                new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = objTypeAttrInfo.Name},
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt){Value = objTypeAttrInfo.SerialNo},
                                new SqlParameter("@TypeId", SqlDbType.Int){Value = objTypeAttrInfo.TypeId},
                                new SqlParameter("@FieldName",SqlDbType.NVarChar,20){Value = objTypeAttrInfo.FieldName},
                                new SqlParameter("@DataType", SqlDbType.NVarChar,20){Value = objTypeAttrInfo.DataType}
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
    }
}
