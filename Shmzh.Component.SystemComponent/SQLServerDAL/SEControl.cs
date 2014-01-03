using System;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// ��ѯ����Ŀؼ���SQLServer�����ݷ��ʲ㡣
    /// </summary>
    public class SEControl :IDAL.ISEControl
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT = @"
Insert Into SEControl ([ModuleId],[LabelName],[ControlTypeId],[DataTypeId],[DataTextField],[DataValueField],[Assembly],[ObjType],[Method],[TableName],[FieldName],[Operator],[IsValid],[SerialNo],[Remark]) 
Values (@ModuleId,@LabelName,@ControlTypeId,@DataTypeId,@DataTextField,@DataValueField,@Assembly,@ObjType,@Method,@TableName,@FieldName,@Operator,@IsValid,@SerialNo,@Remark)  SET @Id = SCOPE_IDENTITY()";

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
        /// ��ȡ��ѯ������������͵Ĳ�����
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetSEControlParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ModuleId", SqlDbType.NVarChar,10),
                                new SqlParameter("@LabelName", SqlDbType.NVarChar,20),
                                new SqlParameter("@ControlTypeId", SqlDbType.Int),
                                new SqlParameter("@DataTypeId", SqlDbType.Int), 
                                new SqlParameter("@DataTextField", SqlDbType.NVarChar,20),
                                new SqlParameter("@DataValueField", SqlDbType.NVarChar,20), 
                                new SqlParameter("@Assembly", SqlDbType.NVarChar,100),
                                new SqlParameter("@ObjType",SqlDbType.NVarChar,100), 
                                new SqlParameter("@Method",SqlDbType.NVarChar,100), 
                                new SqlParameter("@TableName", SqlDbType.NVarChar,50),
                                new SqlParameter("@FieldName", SqlDbType.NVarChar, 50), 
                                new SqlParameter("@Operator", SqlDbType.NVarChar, 20),
                                new SqlParameter("@IsValid", SqlDbType.Bit),
                                new SqlParameter("@SerialNo",SqlDbType.Int), 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// ��DataRowת����SEControlTypeInfo��
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>��ѯ����ؼ�����ʵ�塣</returns>
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

        #region ISEControl ��Ա

        /// <summary>
        /// ��ӿؼ���
        /// </summary>
        /// <param name="obj">�ؼ�ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Insert(SEControlInfo obj)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = 0;
            parms[1].Value = obj.ModuleId;
            parms[2].Value = obj.LabelName;
            parms[3].Value = obj.ControlTypeId;
            parms[4].Value = obj.DataTypeId;
            parms[5].Value = string.IsNullOrEmpty(obj.DataTextField) ? (object) DBNull.Value : obj.DataTextField;
            parms[6].Value = string.IsNullOrEmpty(obj.DataValueField) ? (object) DBNull.Value : obj.DataValueField;
            parms[7].Value = string.IsNullOrEmpty(obj.Assembly) ? (object) DBNull.Value : obj.Assembly;
            parms[8].Value = string.IsNullOrEmpty(obj.ObjType) ? (object) DBNull.Value : obj.ObjType;
            parms[9].Value = string.IsNullOrEmpty(obj.Method) ? (object) DBNull.Value : obj.Method;
            parms[10].Value = obj.TableName;
            parms[11].Value = obj.FieldName;
            parms[12].Value = obj.Operator;
            parms[13].Value = obj.IsValid;
            parms[14].Value = obj.SerialNo;
            parms[15].Value = string.IsNullOrEmpty(obj.Remark) ? (object) DBNull.Value : obj.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                obj.Id = (int) parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// �޸Ŀؼ���
        /// </summary>
        /// <param name="obj">�ؼ�ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Update(SEControlInfo obj)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.ModuleId;
            parms[2].Value = obj.LabelName;
            parms[3].Value = obj.ControlTypeId;
            parms[4].Value = obj.DataTypeId;
            parms[5].Value = string.IsNullOrEmpty(obj.DataTextField) ? (object)DBNull.Value : obj.DataTextField;
            parms[6].Value = string.IsNullOrEmpty(obj.DataValueField) ? (object)DBNull.Value : obj.DataValueField;
            parms[7].Value = string.IsNullOrEmpty(obj.Assembly) ? (object)DBNull.Value : obj.Assembly;
            parms[8].Value = string.IsNullOrEmpty(obj.ObjType) ? (object)DBNull.Value : obj.ObjType;
            parms[9].Value = string.IsNullOrEmpty(obj.Method) ? (object)DBNull.Value : obj.Method;
            parms[10].Value = obj.TableName;
            parms[11].Value = obj.FieldName;
            parms[12].Value = obj.Operator;
            parms[13].Value = obj.IsValid;
            parms[14].Value = obj.SerialNo;
            parms[15].Value = string.IsNullOrEmpty(obj.Remark) ? (object)DBNull.Value : obj.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ɾ���ؼ���
        /// </summary>
        /// <param name="obj">�ؼ�ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Delete(SEControlInfo obj)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = obj.Id;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ɾ���ؼ���
        /// </summary>
        /// <param name="id">�ؼ�Id��</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = id;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ���ݲ�ѯģ��Id��ȡ���пؼ����ϡ�
        /// </summary>
        /// <param name="moduleId">��ѯģ��id��</param>
        /// <returns>�ؼ����ϡ�</returns>
        public System.Collections.Generic.IList<SEControlInfo> GetAllByModuleId(string moduleId)
        {
            var parms = new[] {new SqlParameter("@ModuleId", SqlDbType.NVarChar, 10) {Value = moduleId}};
            var objs = new ListBase<SEControlInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// ���ݲ�ѯģ��Id��ȡ������Ч�ؼ����ϡ�
        /// </summary>
        /// <param name="moduleId">��ѯģ��id��</param>
        /// <returns>�ؼ����ϡ�</returns>
        public System.Collections.Generic.IList<SEControlInfo> GetAllAvalibleByModuleId(string moduleId)
        {
            var parms = new[] { new SqlParameter("@ModuleId", SqlDbType.NVarChar, 10) { Value = moduleId } };
            var objs = new ListBase<SEControlInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// ���ݿؼ�Id��ȡ�ؼ���
        /// </summary>
        /// <param name="id">�ؼ�id��</param>
        /// <returns>�ؼ�ʵ�塣</returns>
        public SEControlInfo GetById(int id)
        {
            var parms = GetSEControlParameters();
            parms[0].Value = id;
            SEControlInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text,SQL_SELECT_BY_ID,parms );
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