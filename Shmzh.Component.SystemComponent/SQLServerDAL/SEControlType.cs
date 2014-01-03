using System;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// ��ѯ����Ŀؼ����͵�SQLServer�����ݷ��ʲ㡣
    /// </summary>
    public class SEControlType :IDAL.ISEControlType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT = @"Insert Into SEControlType ([Id],[Name],[Remark]) Values (@Id,@Name,@Remark)";

        private const string SQL_UPDATE = @"Update SEControlType Set [Id]=@Id,[Name] = @Name, [Remark] = @Remark Where [Id] = @OldId";

        private const string SQL_DELETE = @"Delete From SEControlType Where [Id] = @Id";

        private const string SQL_SELECT_ALL = @"Select * From SEControlType";

        private const string SQL_SELECT_BY_ID = @"Select * From SEControlType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_ID = @"Select Count(*) From SEControlType Where [Id] = @Id";

        private const string SQL_SELECT_COUNT_BY_NAME = @"Select Count(*) From SEControlType Where [Name] = @Name";
        #endregion

        #region private method
        /// <summary>
        /// ��ȡ��ѯ������������͵Ĳ�����
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetSEControlTypeParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.NVarChar,20), 
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255),
                                new SqlParameter("@OldId", SqlDbType.Int), 
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
        private SEControlTypeInfo ConvertToSEControlTypeInfo(IDataRecord dr)
        {
            var obj = new SEControlTypeInfo
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion 

        #region ISEControlType ��Ա

        /// <summary>
        /// ��ӿؼ����͡�
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Insert(SEControlTypeInfo obj)
        {
            var parms = GetSEControlTypeParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.Name;
            parms[2].Value = string.IsNullOrEmpty(obj.Remark) ? (object) DBNull.Value : obj.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// �޸Ŀؼ����͡�
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Update(SEControlTypeInfo obj)
        {
            var parms = GetSEControlTypeParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.Name;
            parms[2].Value = string.IsNullOrEmpty(obj.Remark) ? (object)DBNull.Value : obj.Remark;
            parms[3].Value = obj.OldId;
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
        /// ɾ���ؼ�����ʵ�塣
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Delete(SEControlTypeInfo obj)
        {
            var parms = GetSEControlTypeParameters();
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
        /// ɾ���ؼ�����ʵ�塣
        /// </summary>
        /// <param name="id">�ؼ�����ʵ��id��</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetSEControlTypeParameters();
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
        /// ��ȡ���еĿؼ����͡�
        /// </summary>
        /// <returns>�ؼ����ͼ��ϡ�</returns>
        public System.Collections.Generic.IList<SEControlTypeInfo> GetAll()
        {
            var objs = new ListBase<SEControlTypeInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToSEControlTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// ����Id��ȡ�ؼ����͡�
        /// </summary>
        /// <param name="id">�ؼ�����id��</param>
        /// <returns>�ؼ�����ʵ�塣</returns>
        public SEControlTypeInfo GetById(int id)
        {
            var parms = GetSEControlTypeParameters();
            parms[0].Value = id;
            SEControlTypeInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text,SQL_SELECT_BY_ID,parms );
            while (dr.Read())
            {
                obj = ConvertToSEControlTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// �ж�id�Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="id">id��</param>
        /// <returns>bool</returns>
        public bool IsExist(int id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id},};
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// �ж������Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExist(string name)
        {
            var parms = new[] { new SqlParameter("@Name", SqlDbType.NVarChar,20) { Value = name }, };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }
        #endregion
    }
}