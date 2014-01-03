using System;
using System.Data;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// ��ѯ������������͵�SQLServer�����ݷ��ʲ㡣
    /// </summary>
    public class SEDataType :IDAL.ISEDataType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT = @"Insert Into SEDataType ([Id],[Name],[Remark]) Values (@Id,@Name,@Remark) ";

        private const string SQL_UPDATE = @"Update SEDataType Set [Id]=@Id,[Name] = @Name, [Remark] = @Remark Where [Id] = @OldId";

        private const string SQL_DELETE = @"Delete From SEDataType Where [Id] = @Id";

        private const string SQL_SELECT_ALL = @"Select * From SEDataType";

        private const string SQL_SELECT_BY_ID = @"Select * From SEDataType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_ID = @"Select count(*) From SEDataType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_NAME = @"Select count(*) From SEDataType Where [Name]=@Name";
        #endregion

        #region private method
        /// <summary>
        /// ��ȡ��ѯ������������͵Ĳ�����
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetSEDataTypeParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.Integer),
                                new OleDbParameter("@Name", OleDbType.VarChar,20), 
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                                new OleDbParameter("@OldId",OleDbType.Integer), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// ��DataRowת����SEDataTypeInfo��
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>��ѯ������������ʵ�塣</returns>
        private SEDataTypeInfo ConvertToSEDataTypeInfo(IDataRecord dr)
        {
            var obj = new SEDataTypeInfo
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion 

        #region ISEDataType ��Ա

        /// <summary>
        /// ����������͡�
        /// </summary>
        /// <param name="obj">��������ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Insert(SEDataTypeInfo obj)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.Integer),
                                new OleDbParameter("@Name", OleDbType.VarChar,20), 
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                            };
            parms[0].Value = obj.Id;
            parms[1].Value = obj.Name;
            parms[2].Value = string.IsNullOrEmpty(obj.Remark) ? (object) DBNull.Value : obj.Remark;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// �޸��������͡�
        /// </summary>
        /// <param name="obj">��������ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Update(SEDataTypeInfo obj)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.Name;
            parms[2].Value = string.IsNullOrEmpty(obj.Remark) ? (object)DBNull.Value : obj.Remark;
            parms[3].Value = obj.OldId;
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
        /// ɾ���������͡�
        /// </summary>
        /// <param name="obj">��������ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Delete(SEDataTypeInfo obj)
        {
            var parms = GetSEDataTypeParameters();
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
        /// ɾ���������͡�
        /// </summary>
        /// <param name="id">��������Id��</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetSEDataTypeParameters();
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

        /// <summary>
        /// ��ȡ�����������ͼ��ϡ�
        /// </summary>
        /// <returns>�������ͼ��ϡ�</returns>
        public System.Collections.Generic.IList<SEDataTypeInfo> GetAll()
        {
            var objs = new ListBase<SEDataTypeInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToSEDataTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// ����id��ȡ�������͡�
        /// </summary>
        /// <param name="id">��������Id</param>
        /// <returns>��������ʵ�塣</returns>
        public SEDataTypeInfo GetById(int id)
        {
            var parms = GetSEDataTypeParameters();
            parms[0].Value = id;
            SEDataTypeInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  SQL_SELECT_BY_ID,parms );
            while (dr.Read())
            {
                obj = ConvertToSEDataTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

        #region ISEDataType ��Ա

        /// <summary>
        /// �ж�ID�Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool IsExist(int id)
        {
            var parms = new[] {new OleDbParameter("@Id", OleDbType.Integer) {Value = id}};
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// �ж������Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="name">���ơ�</param>
        /// <returns>bool</returns>
        public bool IsExist(string name)
        {
            var parms = new[] { new OleDbParameter("@Name", OleDbType.VarChar,20) { Value = name } };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_COUNT_BY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }

        #endregion
    }
}