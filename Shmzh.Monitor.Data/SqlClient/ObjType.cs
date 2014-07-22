using System;
using System.Collections.Generic;
using System.Data;
using Shmzh.Components.SystemComponent;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class ObjType :IDAL.IObjType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_SELECT_BY_ID = @"Select * From ObjType Where Id = @Id";
        private const string SQL_SELECT_ALL = @"Select * From ObjType";
        private const string SQL_SELECT_BY_PARENTID = @"Select * From ObjType Where ParentId = @ParentId";

        private const string SQL_INSERT =@"Insert Into ObjType (Name,ParentId,Remark) Values (@Name,@ParentId,@Remark) SET @Id = SCOPE_IDENTITY()";
        private const string SQL_UPDATE = @"Update ObjType Set [Name] = @Name,[ParentId] = @ParentId,[Remark]=@Remark Where Id = @Id";
        private const string SQL_DELETE = @"Delete From ObjType Where Id = @Id";
        #endregion

        #region private method
        private static ObjTypeInfo ConvertToObjTypeInfo(IDataRecord dr)
        {
            var obj = new ObjTypeInfo
                          {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                ParentId = dr.GetInt32(2),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IDevType 成员

        /// <summary>
        /// 根据Id获取监控对象类型.
        /// </summary>
        /// <param name="id">监控对象类型Id.</param>
        /// <returns>监控对象类型对象.</returns>
        public ObjTypeInfo  GetById(int id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            ObjTypeInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_ID, parms);
                while (dr.Read())
                {
                    obj = ConvertToObjTypeInfo(dr);
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if(dr!= null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 获取所有的监控对象类型对象.
        /// </summary>
        /// <returns>所有的监控对象类型对象.</returns>
        public List<ObjTypeInfo>  GetAll()
        {
            var objs = new List<ObjTypeInfo>();
            SqlDataReader dr = null;

            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_ALL);
                while (dr.Read())
                {
                    objs.Add(ConvertToObjTypeInfo(dr));
                }
            }
            catch(Exception ex)
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
        /// 根据上级Id获取监控对象类型对象集合.
        /// </summary>
        /// <param name="parentId">上级Id.</param>
        /// <returns>监控对象类型对象集合.</returns>
        public List<ObjTypeInfo>  GetByParentId(int parentId)
        {
            var parms = new[] {new SqlParameter("@ParentId", SqlDbType.Int) {Value = parentId}};
            var objs = new List<ObjTypeInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, SQL_SELECT_BY_PARENTID, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToObjTypeInfo(dr));
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
        /// 删除监控对象类型对象.
        /// </summary>
        /// <param name="id">监控对象类型对象Id.</param>
        /// <returns>bool</returns>
        public bool  Delete(int id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
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
        /// 删除监控对象类型对象
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public bool  Delete(ObjTypeInfo objTypeInfo)
        {
            return Delete(objTypeInfo.Id);
        }

        /// <summary>
        /// 添加监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public int  Insert(ObjTypeInfo objTypeInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = 0,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = objTypeInfo.Name},
                                new SqlParameter("@ParentId", SqlDbType.Int){ Value = objTypeInfo.ParentId},
                                new SqlParameter("@Remark", SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(objTypeInfo.Remark)?(object)DBNull.Value:objTypeInfo.Remark},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, SQL_INSERT, parms);
                objTypeInfo.Id = int.Parse(parms[0].Value.ToString());
                return objTypeInfo.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 更新监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public bool  Update(ObjTypeInfo objTypeInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = objTypeInfo.Id},
                                new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = objTypeInfo.Name},
                                new SqlParameter("@ParentId", SqlDbType.Int){ Value = objTypeInfo.ParentId},
                                new SqlParameter("@Remark", SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(objTypeInfo.Remark)?(object)DBNull.Value:objTypeInfo.Remark},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, SQL_UPDATE, parms);
                objTypeInfo.Id = int.Parse(parms[0].Value.ToString());
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
