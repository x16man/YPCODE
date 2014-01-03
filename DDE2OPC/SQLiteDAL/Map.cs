using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using DDE2OPC.IDAL;
using DDE2OPC.Model;

namespace DDE2OPC.SQLiteDAL
{
    class Map :IMap
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Map"].ConnectionString;
        private readonly string providerName = ConfigurationManager.ConnectionStrings["Map"].ProviderName;
        private readonly DbProviderFactory provider;
        #endregion

        #region CTOR
        public Map()
        {
            try
            {
                provider = DbProviderFactories.GetFactory(this.providerName);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);                
            }
            
            using (var conn = provider.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();
                var objs = conn.GetSchema("Tables").Select(string.Format("Table_Name='{0}'", "Map"));
                if (objs.Length == 0)//Map Table is not exists.
                {
                    var sqlStatement =
                        "Create Table Map (Id integer primary key autoincrement not null,DDETopic NVARCHAR(50) not null,DDEItem NVARCHAR(50) NOT NULL,OPCAddress NVARCHAR(100) NOT NULL,Remark NVARCHAR(100) NULL)";
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlStatement;
                        cmd.CommandType = CommandType.Text;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message, ex);                            
                        }
                        
                    }
                }
            }
        }
        #endregion

        #region private method
        /// <summary>
        /// 将DataRow转换成MapInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private static MapInfo ConvertToMapInfo(IDataRecord dr)
        {
            var obj = new MapInfo
                          {
                              Id = dr.GetInt32(0),
                              DDETopic = dr.GetString(1),
                              DDEItem = dr.GetString(2),
                              OPCAddress = dr.GetString(3),
                              Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion

        #region Implementation of IMap

        /// <summary>
        /// 添加DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="obj">DDE与OPC的映射关系实体。</param>
        /// <returns>bool</returns>
        public bool Insert(MapInfo obj)
        {
            var sqlStatement = "Insert Into Map(DDETopic,DDEItem,OPCAddress,Remark) Values (@DDETopic,@DDEItem,@OPCAddress,@Remark)";
            using (var conn = provider.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStatement;
                    cmd.CommandType = CommandType.Text;

                    var parm_Id = cmd.CreateParameter();
                    parm_Id.DbType = DbType.Int32;
                    //parm_Id.Direction = ParameterDirection.InputOutput;
                    parm_Id.IsNullable = false;
                    parm_Id.Value = 0;
                    parm_Id.ParameterName = "@Id";

                    var parm_DDETopic = cmd.CreateParameter();
                    parm_DDETopic.DbType = DbType.String;
                    //parm_DDETopic.Direction = ParameterDirection.Input;
                    parm_DDETopic.IsNullable = false;
                    parm_DDETopic.ParameterName = "@DDETopic";
                    parm_DDETopic.Size = 50;
                    parm_DDETopic.Value = obj.DDETopic;

                    var parm_DDEItem = cmd.CreateParameter();
                    parm_DDEItem.DbType = DbType.String;
                    //parm_DDEItem.Direction = ParameterDirection.Input;
                    parm_DDEItem.IsNullable = false;
                    parm_DDEItem.ParameterName = "@DDEItem";
                    parm_DDEItem.Value = obj.DDEItem;

                    var parm_OPCAddress = cmd.CreateParameter();
                    parm_OPCAddress.DbType = DbType.String;
                    //parm_OPCAddress.Direction = ParameterDirection.Input;
                    parm_OPCAddress.IsNullable = false;
                    parm_OPCAddress.ParameterName = "@OPCAddress";
                    parm_OPCAddress.Size = 100;
                    parm_OPCAddress.Value = obj.OPCAddress;

                    var parm_Remark = cmd.CreateParameter();
                    parm_Remark.DbType = DbType.String;
                    //parm_Remark.Direction = ParameterDirection.Input;
                    parm_Remark.IsNullable = true;
                    parm_Remark.ParameterName = "@Remark";
                    parm_Remark.Size = 100;
                    parm_Remark.Value = obj.Remark;

                    cmd.Parameters.Add(parm_Id);
                    cmd.Parameters.Add(parm_DDETopic);
                    cmd.Parameters.Add(parm_DDEItem);
                    cmd.Parameters.Add(parm_OPCAddress);
                    cmd.Parameters.Add(parm_Remark);
                    
                    try
                    {
                        cmd.ExecuteNonQuery();
                        obj.Id = (int)cmd.Parameters[0].Value;
                        return true;
                    }
                    catch(Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        return false;
                    }
                }
                
            }
        }

        /// <summary>
        /// 更改DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="obj">DDE与OPC的映射关系实体。</param>
        /// <returns>bool</returns>
        public bool Update(MapInfo obj)
        {
            var sqlStatement = "Update Map Set DDETopic = @DDETopic, DDEItem = @DDEItem,OPCAddress=@OPCAddress,Remark=@Remark Where Id = @Id";
            using (var conn = provider.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStatement;
                    cmd.CommandType = CommandType.Text;

                    var parm_Id = cmd.CreateParameter();
                    parm_Id.DbType = DbType.Int32;
                    parm_Id.Direction = ParameterDirection.Input;
                    parm_Id.IsNullable = false;
                    parm_Id.ParameterName = "@Id";
                    parm_Id.Value = obj.Id;

                    var parm_DDETopic = cmd.CreateParameter();
                    parm_DDETopic.DbType = DbType.String;
                    parm_DDETopic.Direction = ParameterDirection.Input;
                    parm_DDETopic.IsNullable = false;
                    parm_DDETopic.ParameterName = "@DDETopic";
                    parm_DDETopic.Size = 50;
                    parm_DDETopic.Value = obj.DDETopic;

                    var parm_DDEITem = cmd.CreateParameter();
                    parm_DDEITem.DbType = DbType.String;
                    parm_DDEITem.Direction = ParameterDirection.Input;
                    parm_DDEITem.IsNullable = false;
                    parm_DDEITem.ParameterName = "@DDEItem";
                    parm_DDEITem.Value = obj.DDEItem;

                    var parm_OPCAddress = cmd.CreateParameter();
                    parm_OPCAddress.DbType = DbType.String;
                    parm_OPCAddress.Direction = ParameterDirection.Input;
                    parm_OPCAddress.IsNullable = false;
                    parm_OPCAddress.ParameterName = "@OPCAddress";
                    parm_OPCAddress.Size = 100;
                    parm_OPCAddress.Value = obj.OPCAddress;

                    var parm_Remark = cmd.CreateParameter();
                    parm_Remark.DbType = DbType.String;
                    parm_Remark.Direction = ParameterDirection.Input;
                    parm_Remark.IsNullable = true;
                    parm_Remark.ParameterName = "@Remark";
                    parm_Remark.Size = 100;
                    parm_Remark.Value = obj.Remark;

                    cmd.Parameters.Add(parm_Id);
                    cmd.Parameters.Add(parm_DDETopic);
                    cmd.Parameters.Add(parm_DDEITem);
                    cmd.Parameters.Add(parm_OPCAddress);
                    cmd.Parameters.Add(parm_Remark);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        return false;
                    }
                }

            }
        }

        /// <summary>
        /// 删除DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="obj">DDE与OPC的映射关系实体。</param>
        /// <returns>bool</returns>
        public bool Delete(MapInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="id">DDE与OPC的映射关系实体Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var sqlStatement = "Delete From Map Where Id = @Id";
            using (var conn = provider.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStatement;
                    cmd.CommandType = CommandType.Text;

                    var parm_Id = cmd.CreateParameter();
                    parm_Id.DbType = DbType.Int32;
                    parm_Id.Direction = ParameterDirection.Input;
                    parm_Id.IsNullable = false;
                    parm_Id.ParameterName = "@Id";
                    parm_Id.Value = id;

                    cmd.Parameters.Add(parm_Id);
                    
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        return false;
                    }
                }

            }
        }

        /// <summary>
        /// 获取所有DDE与OPC的映射关系实体。
        /// </summary>
        /// <returns>DDE与OPC的映射关系实体集合。</returns>
        public IList<MapInfo> GetAll()
        {
            var sqlStatement = "Select * From Map";
            using (var conn = provider.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStatement;
                    cmd.CommandType = CommandType.Text;

                    
                    var objs = new List<MapInfo>();
                    try
                    {
                        var dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            objs.Add(ConvertToMapInfo(dr));
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        
                    }
                    return objs;
                }

            }
        }

        /// <summary>
        /// 根据Id获取DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="id">DDE与OPC的映射关系实体Id。</param>
        /// <returns>DDE与OPC的映射关系实体。</returns>
        public MapInfo GetById(int id)
        {
            var sqlStatement = "Select * From Map Where Id = @Id";
            using (var conn = provider.CreateConnection())
            {
                conn.ConnectionString = this.connectionString;
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStatement;
                    cmd.CommandType = CommandType.Text;

                    var parm_Id = cmd.CreateParameter();
                    parm_Id.DbType = DbType.Int32;
                    parm_Id.Direction = ParameterDirection.Input;
                    parm_Id.IsNullable = false;
                    parm_Id.ParameterName = "@Id";
                    parm_Id.Value = id;

                    cmd.Parameters.Add(parm_Id);

                    MapInfo obj = null;
                    try
                    {
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            obj = ConvertToMapInfo(dr);
                            break;
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);

                    }
                    return obj;
                }

            }
        }

        #endregion


    }
}
