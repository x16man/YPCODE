using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Shmzh.MM.Common.Storage;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Storage
{
    /// <summary>
    /// 盘点主表类。
    /// </summary>
    public class Inventorys
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region private method
        private InventoryInfo ConvertToInventoryInfo(IDataRecord dr)
        {
            return new InventoryInfo
                       {
                           Id = dr.GetInt32(0),
                           Name = dr.GetString(1),
                           StoCode = dr.GetString(2),
                           StoName = dr.GetString(3),
                           Date = dr.GetDateTime(4),
                           UserId = dr.GetInt32(5),
                           Remark =dr["Remark"]==DBNull.Value?string.Empty:dr["Remark"].ToString(),
                       };
        }
        #endregion

        #region Method
        public InventoryInfo GetById(int id)
        {
            var sqlStatement = "Select Id,[Name],StoCode,WSTO.Description As StoName,[Date],UserId,Remark From Inventory,WSTO Where Id = @Id And Inventory.StoCode = WSTO.Code";
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            InventoryInfo obj = null;
            while (dr.Read())
            {
                obj = ConvertToInventoryInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        
        public ListBase<InventoryInfo> GetAll()
        {
            var sqlStatement = "Select Id,[Name],StoCode,WSTO.Description As StoName,[Date],UserId,Remark From Inventory,WSTO Where Inventory.StoCode = WSTO.Code";
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement);
            var objs = new ListBase<InventoryInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToInventoryInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public int Insert(InventoryInfo obj)
        {
            return Insert(null, obj);
        }
        public int Insert(DbTransaction trans, InventoryInfo obj)
        {
            var sqlStatement = "Insert Into Inventory (Name,StoCode,[Date],UserId,Remark)Values(@Name,@StoCode,@Date,@UserId,@Remark) Set @Id=SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = 0,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name",SqlDbType.NVarChar,50){Value = obj.Name},
                                new SqlParameter("@StoCode",SqlDbType.NVarChar,10){Value = obj.StoCode},
                                new SqlParameter("@Date",SqlDbType.DateTime){Value = obj.Date},
                                new SqlParameter("@UserId",SqlDbType.Int){Value = obj.UserId},
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255){Value = obj.Remark},
                            };
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                obj.Id = (int)parms[0].Value;
                return obj.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return 0;
            }
        }
        public bool Update(InventoryInfo obj)
        {
            return Update(null, obj);
        }
        public bool Update(DbTransaction trans, InventoryInfo obj)
        {
            var sqlStatement = "Update Inventory Set Name = @Name,Date = @Date,UserId = @UserId, Remark = @Remark Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = obj.Id},
                                new SqlParameter("@Name",SqlDbType.NVarChar,50){Value = obj.Name},
                                new SqlParameter("@StoCode", SqlDbType.NVarChar,10){Value = obj.StoCode}, 
                                new SqlParameter("@Date",SqlDbType.DateTime){Value = obj.Date},
                                new SqlParameter("@UserId",SqlDbType.Int){Value = obj.UserId},
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255){Value = obj.Remark},
                            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public bool Delete(InventoryInfo obj)
        {
            return Delete(null, obj.Id);
        }
        public bool Delete(DbTransaction trans, InventoryInfo obj)
        {
            return Delete(trans, obj.Id);
        }
        public bool Delete(int id)
        {
            return Delete(null, id);
        }
        public bool Delete(DbTransaction trans, int id)
        {
            var sqlStatement = "Delete From Inventory Where Id = @Id";
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        #endregion
    }
}
