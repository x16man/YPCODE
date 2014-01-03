using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 组织机构的SQL Server的数据访问对象。
    /// </summary>
    public class TB_ORGTREE : IDAL.ITB_ORGTREE
    {
        #region 字段

        private const string FloDBName = "FloDBName";
        private static readonly string SQL_INSERT = string.Format(@"
INSERT INTO {0}.dbo.[TB_ORGTREE]([ParentID], [ItemName], [TypeID], [Enable]) VALUES (@ParentId, @ItemName, @TypeId, @Enable) Set @ItemId=SCOPE_IDENTITY()",ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_Update = string.Format(@"
UPDATE {0}.[dbo].[TB_ORGTREE] SET [ParentID] = @ParentId,[ItemName] = @ItemName,[TypeID] =@TypeId,[Enable] = @Enable where [ItemID] = @ItemID",ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_DISABLED = string.Format("UPDATE {0}.dbo.[TB_ORGTREE] SET [Enable] = 0 WHERE [ItemID] = @ItemId", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_ISEXIST = string.Format("SELECT Count(*) FROM {0}.[dbo].[TB_ORGTREE] WHERE [ItemName]=@ItemName", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_DELETE = string.Format("DELETE {0}.dbo.[TB_ORGTREE] WHERE ItemID= @ItemId",ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_HAS_CHILDDEPT = string.Format(@"
SELECT COUNT(*) FROM {0}.[dbo].[TB_ORGTREE] WHERE [ParentId] IN (SELECT [ItemId] FROM {0}.[dbo].[TB_ORGTREE] WHERE [ItemName]=@ItemName)", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_HAS_USER = string.Format(@"
SELECT COUNT(*) FROM {0}.[dbo].[TB_ORGMEMLNK] WHERE [orgid] IN (SELECT [ItemId] FROM {0}.[dbo].[TB_ORGTREE] WHERE [ItemName]=@ItemName)", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_HAS_LEADER = string.Format(@"
Select count(*) From {0}.[dbo].[TB_ORGLDLNK] Where [OrgID] IN (Select [ItemId] From {0}.[dbo].[TB_ORGTREE] Where [ItemName] = @ItemName)", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_BY_NAME =string.Format("Select * From {0}.[dbo].[TB_ORGTREE] Where ItemName = @ItemName", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_ALL = string.Format("Select * From {0}.[dbo].[TB_ORGTREE]", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_ALLAVALIBLE = string.Format("Select * From {0}.[dbo].[TB_ORGTREE] Where Enable = 1", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region 方法
        
        #endregion

        #region 接口方法

        /// <summary>
        /// 添加东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        public bool Insert(TB_ORGTREEInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@ItemId", SqlDbType.Int)
                                    {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ParentId",SqlDbType.Int){Value = obj.ParentID},
                                new SqlParameter("@ItemName",SqlDbType.NVarChar,50){Value = obj.ItemName},
                                new SqlParameter("@TypeId",SqlDbType.Int){Value = obj.TypeID}, 
                                new SqlParameter("@Enable",SqlDbType.Bit){Value = obj.Enable}, 
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT, parms);
                obj.TypeID = (int)parms[0].Value;
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
        /// <param name="trans">事务对象。</param>
        public bool Update(TB_ORGTREEInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@ItemId", SqlDbType.Int) {Value = obj.ItemID},
                                new SqlParameter("@ParentId", SqlDbType.Int) {Value = obj.ParentID},
                                new SqlParameter("@ItemName",SqlDbType.NVarChar,50){Value = obj.ItemName},
                                new SqlParameter("@TypeId", SqlDbType.Int){Value = obj.TypeID},
                                new SqlParameter("@Enable", SqlDbType.Bit){Value = obj.Enable}, 
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_Update, parms);
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
        /// <param name="tborgtreeinfo">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        public bool Delete(TB_ORGTREEInfo tborgtreeinfo, DbTransaction trans)
        {
            return Delete(tborgtreeinfo.ItemID, trans);
        }

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="itemId">部门key。</param>
        /// <param name="trans">事务对象。</param>
        public bool Delete(int itemId, DbTransaction trans)
        {
            var parms = new[] { new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId } };
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
        /// 获取所有组织机构。
        /// </summary>
        /// <returns>所有组织机构。</returns>
        public IList<TB_ORGTREEInfo> GetAll()
        {
            var objs = new ListBase<TB_ORGTREEInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(new TB_ORGTREEInfo
                          {
                              ItemID = dr.GetInt32(0),
                              ParentID = dr.GetInt32(1),
                              ItemName = dr.GetString(2),
                              TypeID = dr.GetInt32(3),
                              Enable = dr.GetBoolean(4)
                          });
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有组织机构。
        /// </summary>
        /// <returns>所有组织机构。</returns>
        public IList<TB_ORGTREEInfo> GetAllAvalible()
        {
            var objs = new ListBase<TB_ORGTREEInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(new TB_ORGTREEInfo
                {
                    ItemID = dr.GetInt32(0),
                    ParentID = dr.GetInt32(1),
                    ItemName = dr.GetString(2),
                    TypeID = dr.GetInt32(3),
                    Enable = dr.GetBoolean(4)
                });
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 部门失效
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="trans">事务对象。</param>
        public bool Disable(int itemId, DbTransaction trans)
        {
            var parms = new[] { new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId } };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DISABLED, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }

        /// <summary>
        /// 东兰工作流是否存在某一名称的部门
        /// </summary>
        /// <param name="name"></param>
        public bool IsExistName(string name)
        {
            var parms = new[] { new SqlParameter("@ItemName", SqlDbType.NVarChar, 50) { Value = name } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.DLFLODB, CommandType.Text, SQL_ISEXIST, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="deptName">部门名称。</param>
        /// <returns>bool</returns>
        public bool HasChildDept(string deptName)
        {
            var parms = new[] { new SqlParameter("@ItemName", SqlDbType.NVarChar, 50) { Value = deptName } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.DLFLODB, CommandType.Text,
                                              SQL_HAS_CHILDDEPT, parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="deptName">父部门名称。</param>
        /// <returns>bool</returns>
        public bool HasUser(string deptName)
        {
            var parms = new[] { new SqlParameter("@ItemName", SqlDbType.NVarChar, 50) { Value = deptName } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.DLFLODB, CommandType.Text,
                                              SQL_HAS_USER, parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断是否有领导。
        /// </summary>
        /// <param name="deptName">部门名称。</param>
        /// <returns></returns>
        public bool HasLeader(string deptName)
        {
            var parms = new[] {new SqlParameter("@ItemName", SqlDbType.NVarChar, 50) {Value = deptName}};
            var obj = SqlHelper.ExecuteScalar(ConnectionString.DLFLODB, CommandType.Text, SQL_HAS_LEADER, parms);
            return (int) obj == 0 ? false : true;
        }
        #endregion

        #region IORGTREE 成员

        /// <summary>
        /// 根据名称获取组织机构。
        /// </summary>
        /// <param name="name">名称。</param>
        /// <returns>组织机构。</returns>
        public TB_ORGTREEInfo GetByName(string name)
        {
            var parms = new[] {new SqlParameter("@ItemName", SqlDbType.NVarChar, 50) {Value = name}};
            TB_ORGTREEInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_NAME, parms);
            while (dr.Read())
            {
                obj = new TB_ORGTREEInfo
                          {
                              ItemID = dr.GetInt32(0),
                              ParentID = dr.GetInt32(1),
                              ItemName = dr.GetString(2),
                              TypeID = dr.GetInt32(3),
                              Enable = dr.GetBoolean(4)
                          };
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
