using System;
using System.Data;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// 查询引擎的控件的SQLServer的数据访问层。
    /// </summary>
    public class SEControl :IDAL.ISEControl
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT = @"
Insert Into SEControl ([ModuleId],[LabelName],[ControlTypeId],[DataTypeId],[DataTextField],[DataValueField],[Assembly],[ObjType],[Method],[TableName],[FieldName],[Operator],[IsValid],[SerialNo],[Remark]) 
Values (@ModuleId,@LabelName,@ControlTypeId,@DataTypeId,@DataTextField,@DataValueField,@Assembly,@ObjType,@Method,@TableName,@FieldName,@Operator,@IsValid,@SerialNo,@Remark)  ";

        private const string SQL_UPDATE = @"
Update  SEControl
Set     [ModuleId] = @ModuleId
,       [LabelName] = @LabelName
,       [ControlTypeId] = @ControlTypeId
,       [DataTypeId] = @DataTypeId
,       [DataTextField] = @DataTextField
,       [DataValueField] = @DataValueField
,       [Assembly] = @Assembly
,       [ObjType] = @ObjType
,       [Method] = @Method
,       [TableName] = @TableName
,       [FieldName] = @FieldName
,       [Operator] = @Operator
,       [IsValid] = @IsValid
,       [SerialNo] = @SerialNo
,       [Remark] = @Remark 
Where   [Id] = @Id";

        private const string SQL_DELETE = @"Delete From SEControl Where [Id] = @Id";

        private const string SQL_SELECT_ALL = @"Select * From SEControl Where [ModuleId] = @ModuleId";

        private const string SQL_SELECT_ALLAVALIBLE = @"Select * From SEControl Where [ModuleId] = @ModuleId And [IsValid] = 1";

        private const string SQL_SELECT_BY_ID = @"Select * From SEControl Where [Id] = @Id";
        #endregion

        #region private method
        /// <summary>
        /// 获取查询引擎的数据类型的参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetSEControlParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_UPDATE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar,10),
                                new OleDbParameter("@LabelName", OleDbType.VarChar,20),
                                new OleDbParameter("@ControlTypeId", OleDbType.Integer),
                                new OleDbParameter("@DataTypeId", OleDbType.Integer), 
                                new OleDbParameter("@DataTextField", OleDbType.VarChar,20),
                                new OleDbParameter("@DataValueField", OleDbType.VarChar,20), 
                                new OleDbParameter("@Assembly", OleDbType.VarChar,100),
                                new OleDbParameter("@ObjType",OleDbType.VarChar,100), 
                                new OleDbParameter("@Method",OleDbType.VarChar,100), 
                                new OleDbParameter("@TableName", OleDbType.VarChar,50),
                                new OleDbParameter("@FieldName", OleDbType.VarChar, 50), 
                                new OleDbParameter("@Operator", OleDbType.VarChar, 20),
                                new OleDbParameter("@IsValid", OleDbType.Boolean),
                                new OleDbParameter("@SerialNo",OleDbType.Integer), 
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                                new OleDbParameter("@Id", OleDbType.Integer),
                                
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }


        private static OleDbParameter[] GetSEInsertControlParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar,10),
                                new OleDbParameter("@LabelName", OleDbType.VarChar,20),
                                new OleDbParameter("@ControlTypeId", OleDbType.Integer),
                                new OleDbParameter("@DataTypeId", OleDbType.Integer), 
                                new OleDbParameter("@DataTextField", OleDbType.VarChar,20),
                                new OleDbParameter("@DataValueField", OleDbType.VarChar,20), 
                                new OleDbParameter("@Assembly", OleDbType.VarChar,100),
                                new OleDbParameter("@ObjType",OleDbType.VarChar,100), 
                                new OleDbParameter("@Method",OleDbType.VarChar,100), 
                                new OleDbParameter("@TableName", OleDbType.VarChar,50),
                                new OleDbParameter("@FieldName", OleDbType.VarChar, 50), 
                                new OleDbParameter("@Operator", OleDbType.VarChar, 20),
                                new OleDbParameter("@IsValid", OleDbType.Boolean),
                                new OleDbParameter("@SerialNo",OleDbType.Integer), 
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成SEControlTypeInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>查询引擎控件类型实体。</returns>
        private SEControlInfo ConvertToSEControlInfo(IDataRecord dr)
        {
            var obj = new SEControlInfo
            {
                Id = dr.GetInt32(0),
                ModuleId = dr.GetString(1),
                LabelName = dr.GetString(2),
                ControlTypeId = dr.GetInt32(3),
                DataTypeId = dr.GetInt32(4),
                DataTextField = dr["DataTextField"] == DBNull.Value? string.Empty: dr["DataTextField"].ToString(),
                DataValueField = dr["DataValueField"] == DBNull.Value?string.Empty:dr["DataValueField"].ToString(),
                Assembly = dr["Assembly"] == DBNull.Value?string.Empty:dr["Assembly"].ToString(),
                ObjType = dr["ObjType"] == DBNull.Value?string.Empty:dr["ObjType"].ToString(),
                Method = dr["Method"] == DBNull.Value?string.Empty:dr["Method"].ToString(),
                TableName = dr.GetString(10),
                FieldName = dr.GetString(11),
                Operator = dr.GetString(12),
                IsValid = dr.GetBoolean(13),
                SerialNo = dr.GetInt32(14),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion 

        #region ISEControl 成员

        /// <summary>
        /// 添加控件。
        /// </summary>
        /// <param name="obj">控件实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SEControlInfo obj)
        {
            var parms = GetSEInsertControlParameters();
            parms[0].Value = obj.ModuleId;
            parms[1].Value = obj.LabelName;
            parms[2].Value = obj.ControlTypeId;
            parms[3].Value = obj.DataTypeId;
            parms[4].Value = string.IsNullOrEmpty(obj.DataTextField) ? (object) DBNull.Value : obj.DataTextField;
            parms[5].Value = string.IsNullOrEmpty(obj.DataValueField) ? (object) DBNull.Value : obj.DataValueField;
            parms[6].Value = string.IsNullOrEmpty(obj.Assembly) ? (object) DBNull.Value : obj.Assembly;
            parms[7].Value = string.IsNullOrEmpty(obj.ObjType) ? (object) DBNull.Value : obj.ObjType;
            parms[8].Value = string.IsNullOrEmpty(obj.Method) ? (object) DBNull.Value : obj.Method;
            parms[9].Value = obj.TableName;
            parms[10].Value = obj.FieldName;
            parms[11].Value = obj.Operator;
            parms[12].Value = obj.IsValid;
            parms[13].Value = obj.SerialNo;
            parms[14].Value = string.IsNullOrEmpty(obj.Remark) ? (object) DBNull.Value : obj.Remark;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT, parms);
                obj.Id = GetMax();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改控件。
        /// </summary>
        /// <param name="obj">控件实体。</param>
        /// <returns>bool</returns>
        public bool Update(SEControlInfo obj)
        {
            var parms = GetSEControlParameters();
           
            parms[0].Value = obj.ModuleId;
            parms[1].Value = obj.LabelName;
            parms[2].Value = obj.ControlTypeId;
            parms[3].Value = obj.DataTypeId;
            parms[4].Value = string.IsNullOrEmpty(obj.DataTextField) ? (object)DBNull.Value : obj.DataTextField;
            parms[5].Value = string.IsNullOrEmpty(obj.DataValueField) ? (object)DBNull.Value : obj.DataValueField;
            parms[6].Value = string.IsNullOrEmpty(obj.Assembly) ? (object)DBNull.Value : obj.Assembly;
            parms[7].Value = string.IsNullOrEmpty(obj.ObjType) ? (object)DBNull.Value : obj.ObjType;
            parms[8].Value = string.IsNullOrEmpty(obj.Method) ? (object)DBNull.Value : obj.Method;
            parms[9].Value = obj.TableName;
            parms[10].Value = obj.FieldName;
            parms[11].Value = obj.Operator;
            parms[12].Value = obj.IsValid;
            parms[13].Value = obj.SerialNo;
            parms[14].Value = string.IsNullOrEmpty(obj.Remark) ? (object)DBNull.Value : obj.Remark;
            parms[15].Value = obj.Id;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除控件。
        /// </summary>
        /// <param name="obj">控件实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SEControlInfo obj)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = obj.Id;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除控件。
        /// </summary>
        /// <param name="id">控件Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = id;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        private short GetMax()
        {
            var oRet = AccessHelper.ExecuteScalar(ConnectionString.PubData, "Select max(Id) From [SEControl] ");
            return short.Parse(oRet.ToString());
        }

        /// <summary>
        /// 根据查询模块Id获取所有控件集合。
        /// </summary>
        /// <param name="moduleId">查询模块id。</param>
        /// <returns>控件集合。</returns>
        public System.Collections.Generic.IList<SEControlInfo> GetAllByModuleId(string moduleId)
        {
            var parms = new[] {new OleDbParameter("@ModuleId", OleDbType.VarChar, 10) {Value = moduleId}};
            var objs = new ListBase<SEControlInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据查询模块Id获取所有有效控件集合。
        /// </summary>
        /// <param name="moduleId">查询模块id。</param>
        /// <returns>控件集合。</returns>
        public System.Collections.Generic.IList<SEControlInfo> GetAllAvalibleByModuleId(string moduleId)
        {
            var parms = new[] { new OleDbParameter("@ModuleId", OleDbType.VarChar, 10) { Value = moduleId } };
            var objs = new ListBase<SEControlInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据控件Id获取控件。
        /// </summary>
        /// <param name="id">控件id。</param>
        /// <returns>控件实体。</returns>
        public SEControlInfo GetById(int id)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = id;
            SEControlInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  SQL_SELECT_BY_ID,parms );
            while (dr.Read())
            {
                obj = ConvertToSEControlInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}