using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class GroupCat:IGroupCat
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region private method
        /// <summary>
        /// 将DataRow转换成GroupCatInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组分类实体。</returns>
        private static GroupCatInfo ConvertToGroupCatInfo(IDataRecord dr)
        {
            var obj = new GroupCatInfo
            {
                Id = dr.GetInt16(0),
                Name = dr.GetString(1),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                SerialNo = dr["SerialNo"] == DBNull.Value ? (short)0 : short.Parse(dr["SerialNo"].ToString()),
            };
            return obj;
        }
        #endregion

        #region Implementation of IGroupCat

        /// <summary>
        /// 添加组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupCatInfo obj)
        {
            var sqlStatement = @"Insert Into mySystemGroupCat([Name],[Remark],[SerialNo]) Values (@Name,@Remark,@SerialNo) Set @Id = SCOPE_IDENTITY() ";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.SmallInt) {Value = 0,Direction = ParameterDirection.InputOutput}, 
                                new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = obj.Name},
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 50) {Value = obj.Remark}, 
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt) {Value = obj.SerialNo}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement, parms);
                obj.Id = (short)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }

        /// <summary>
        /// 修改组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        public bool Update(GroupCatInfo obj)
        {
            var sqlStatement = @"Update mySystemGroupCat Set Name = @Name,Remark = @Remark,SerialNo = @SerialNo Where Id = @Id ";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.SmallInt) {Value = obj.Id}, 
                                new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = obj.Name},
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 50) {Value = obj.Remark}, 
                                new SqlParameter("@SerialNo", SqlDbType.SmallInt) {Value = obj.SerialNo}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 删除组分类。
        /// </summary>
        /// <param name="obj">组分类实体。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupCatInfo obj)
        {
            return Delete(obj.Id);
        }

        /// <summary>
        /// 删除组分类。
        /// </summary>
        /// <param name="id">组分类Id。</param>
        /// <returns>bool</returns>
        public bool Delete(short id)
        {
            var sqlStatement = @"Delete From mySystemGroupCat Where Id = @Id ";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.SmallInt) {Value = id}, 
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 是否已经存在组分类名称。
        /// </summary>
        /// <param name="name">组分类名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string name)
        {
            var sqlStatement = "Select Count(*) From mySystemGroupCat Where [Name] = @Name";
            var parms = new[] {new SqlParameter("@Name", SqlDbType.NVarChar, 20) {Value = name}};
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 获取所有组分类。
        /// </summary>
        /// <returns>组分类列表。</returns>
        public IList<GroupCatInfo> GetAll()
        {
            var sqlStatement = "Select Id,[Name],[Remark],[SerialNo] From mySystemGroupCat";
            var objs = new ListBase<GroupCatInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToGroupCatInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据组编号获取组。
        /// </summary>
        /// <param name="id">组编号。</param>
        /// <returns>组分类。</returns>
        public GroupCatInfo GetById(short id)
        {
            var sqlStatement = "Select Id,[Name],[Remark],[SerialNo] From mySystemGroupCat Where Id = @Id";
            var parms = new[] {new SqlParameter("@Id", SqlDbType.SmallInt) {Value = id}};
            GroupCatInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToGroupCatInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
