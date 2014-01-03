using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class MenuType:IDAL.IMenuType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT_MENUTYPE =
            "Insert Into mySystemMenuType ([Id],[Name],[IsUsedByFrameWork],[Remark]) Values (@Id,@Name,@IsUsedByFrameWork,@Remark)";

        private const string SQL_UPDATE_MENUTYPE =
            "Update mySystemMenuType Set [Name] = @Name,IsUsedByFrameWork = @IsUsedByFrameWork,Remark=@Remark Where Id = @Id";

        private const string SQL_DELETE_MENUTYPE = "Delete From mySystemMenuType Where Id = @Id";

        private const string SQL_SELECT_ALL = "Select * From mySystemMenuType";

        private const string SQL_SELECT_ALLUSEDBYFRAMEWORK =
            "Select * From mySystemMenuType Where IsUsedByFrameWork = 1";

        private const string SQL_SELECT_BY_ID = "Select * From mySystemMenuType Where Id = @Id";
        private const string SQL_SELECT_COUNT_BY_ID = "Select Count(*) From mySystemMenuType Where Id = @Id";
        private const string SQL_SELECT_COUNT_BY_NAME = "Select Count(*) From mySystemMenuType Where [Name] = @Name";
        #endregion

        #region private method
        /// <summary>
        /// 获取菜单类型参数。
        /// </summary>
        /// <returns>菜单类型参数.</returns>
        private static SqlParameter[] GetMenuTypeParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_MENUTYPE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int),
                                new SqlParameter("@Name", SqlDbType.NVarChar,10), 
                                new SqlParameter("@IsUsedByFrameWork", SqlDbType.Bit), 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,50), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_MENUTYPE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成MenuTypeInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>菜单类型实体。</returns>
        private MenuTypeInfo ConvertToMenuTypeInfo(IDataRecord dr)
        {
            var obj = new MenuTypeInfo
            {
                ID = dr.GetInt32(0),
                Name = dr.GetString(1),
                IsUsedByFrameWork = dr.GetBoolean(2),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IMenuType 成员

        public bool Insert(MenuTypeInfo menuTypeInfo)
        {
            var parms = GetMenuTypeParameters();
            parms[0].Value = menuTypeInfo.ID;
            parms[1].Value = menuTypeInfo.Name;
            parms[2].Value = menuTypeInfo.IsUsedByFrameWork;
            parms[3].Value = menuTypeInfo.Remark;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_MENUTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Update(MenuTypeInfo menuTypeInfo)
        {
            var parms = GetMenuTypeParameters();
            parms[0].Value = menuTypeInfo.ID;
            parms[1].Value = menuTypeInfo.Name;
            parms[2].Value = menuTypeInfo.IsUsedByFrameWork;
            parms[3].Value = menuTypeInfo.Remark;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_MENUTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(MenuTypeInfo menuTypeInfo)
        {
            var parms = GetMenuTypeParameters();
            parms[0].Value = menuTypeInfo.ID;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_MENUTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            var parms = GetMenuTypeParameters();
            parms[0].Value = id;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_MENUTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool IsExist(int id)
        {
            var parms = GetMenuTypeParameters();
            parms[0].Value = id;
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        public bool IsExist(string name)
        {
            var parms = GetMenuTypeParameters();
            parms[1].Value = name;
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }

        public IList<MenuTypeInfo> GetAll()
        {
            var objs = new ListBase<MenuTypeInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData,CommandType.Text,SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToMenuTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public IList<MenuTypeInfo> GetALLUsedByFrameWork()
        {
            var objs = new ListBase<MenuTypeInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLUSEDBYFRAMEWORK);
            while (dr.Read())
            {
                objs.Add(ConvertToMenuTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public MenuTypeInfo GetById(int id)
        {
            MenuTypeInfo obj = null;
            var parms = GetMenuTypeParameters();
            parms[0].Value = id;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID, parms);
            while (dr.Read())
            {
                obj = ConvertToMenuTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
