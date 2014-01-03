using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 工作流组织机构类型的SQL server的数据访问对象。
    /// </summary>
    public class TB_SYSORGTP : IDAL.ITB_SYSORGTP
    {
        #region 字段

        private const string FloDBName = "FloDBName";
        private static readonly string SQL_INSERT = string.Format(@"
INSERT INTO {0}.[dbo].[TB_SYSORGTP]( [ClassOrder], [TypeName], [Enable])
VALUES ( @ClassOrder, @TypeName, @Enable) 
Set @TypeId= SCOPE_IDENTITY()", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_UPDATE = string.Format(@"
UPDATE {0}.dbo.[TB_SYSORGTP] SET [ClassOrder] = @ClassOrder,[TypeName] =@TypeName,[Enable] = @Enable WHERE [TypeId] = @TypeId", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_BY_NAME = string.Format("SELECT Count(*) FROM {0}.[dbo].[TB_SYSORGTP] WHERE [TypeName] = @TypeName", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_DELETE = string.Format("DELETE FROM {0}.[dbo].[TB_SYSORGTP] WHERE TypeID= @TypeId", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_BY_TYPENAME =string.Format("Select TypeId,ClassOrder,TypeName,Enable From {0}.[dbo].[TB_SYSORGTP] Where TypeName = @TypeName", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region 方法
        
        #endregion

        #region 接口方法
        /// <summary>
        /// 添加东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans"></param>
        public bool Insert(TB_SYSORGTPInfo obj, DbTransaction trans)
        {
            var parms = new[] 
            { 
                new SqlParameter("@TypeId", SqlDbType.Int) { Value = obj.TypeId ,Direction = ParameterDirection.InputOutput}, 
                new SqlParameter("@ClassOrder",SqlDbType.Int){Value = obj.ClassOrder},
                new SqlParameter("@TypeName", SqlDbType.NVarChar,50){Value = obj.TypeName},
                new SqlParameter("@Enable",SqlDbType.Bit){Value = obj.Enable},
            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT, parms);
                obj.TypeId = (int)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 修改东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans"></param>
        public bool Update(TB_SYSORGTPInfo obj, DbTransaction trans)
        {
            var parms = new[] 
            { 
                new SqlParameter("@TypeId", SqlDbType.Int) { Value = obj.TypeId }, 
                new SqlParameter("@ClassOrder",SqlDbType.Int){Value = obj.ClassOrder},
                new SqlParameter("@TypeName", SqlDbType.NVarChar,50){Value = obj.TypeName},
                new SqlParameter("@Enable",SqlDbType.Bit){Value = obj.Enable},
            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans"></param>
        public bool Delete(TB_SYSORGTPInfo obj, DbTransaction trans)
        {
            return Delete(obj.TypeId, trans);
        }

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="typeId">组织机构类型Id。</param>
        /// <param name="trans">事务对象。</param>
        public bool Delete(int typeId, DbTransaction trans)
        {
            var parms = new[] { new SqlParameter("@TypeId", SqlDbType.Int) { Value = typeId } };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 东兰工作流是否存在某一名称的部门
        /// </summary>
        /// <param name="typeName"></param>
        public bool IsExistName(string typeName)
        {
            var parms = new[] { new SqlParameter("@TypeName", SqlDbType.NVarChar, 50) { Value = typeName } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 根据组织类型名称获取组织机构类型。
        /// </summary>
        /// <param name="typeName">组织机构类型名称。</param>
        /// <returns>组织机构类型。</returns>
        public TB_SYSORGTPInfo GetByTypeName(string typeName)
        {
            var parms = new[] {new SqlParameter("@TypeName", SqlDbType.NVarChar, 50) {Value = typeName},};
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_TYPENAME, parms);
            TB_SYSORGTPInfo obj = null;
            while (dr.Read())
            {
                obj = new TB_SYSORGTPInfo
                          {
                              TypeId = dr.GetInt32(0),
                              ClassOrder = dr.GetInt32(1),
                              TypeName = dr.GetString(2),
                              Enable = dr.GetBoolean(3)
                          };
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
