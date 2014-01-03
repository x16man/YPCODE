using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlTagCategoryDetailProvider:TagCategoryDetailProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string _connectionString;
        string _providerInvariantName;
        string _useGzip;
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return this._connectionString; }
            set { this._connectionString = value; }
        }
        /// <summary>
        /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
        /// </summary>
        /// <value>The name of the provider invariant.</value>
        public string ProviderInvariantName
        {
            get { return this._providerInvariantName; }
            set { this._providerInvariantName = value; }
        }

        #endregion

        #region CTOR
        /// <summary>
		/// Creates a new <see cref="SqlTagCategoryDetailProvider"/> instance.
		/// </summary>
		public SqlTagCategoryDetailProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlTagCategoryDetailProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlTagCategoryDetailProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// ��drת�䵽ָ����ָ������ϵʵ�塣
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>ָ����ָ������ϵʵ�塣</returns>
        private static TagCategoryDetailInfo ConvertToTagCategoryDetailInfo(IDataRecord dr)
        {
            var obj = new TagCategoryDetailInfo();
            obj.CategoryId = dr.GetInt32(0);
            obj.TagId = dr.GetString(1);

            return obj;
        }
        #endregion

        #region Overrides of TagCategoryProvider

        /// <summary>
        /// ���ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>ָ�����Id��</returns>
        public override bool Insert(TagCategoryDetailInfo obj)
        {
            var sqlStatement = "Insert Into T_Tag_CategoryDetail (CategoryId,TagId) Values (@CategoryId,@TagId) ";
            var parms = new[]
                            {
                                new SqlParameter("@CategoryId", SqlDbType.Int) {Value = obj.CategoryId},
                                new SqlParameter("@TagId", SqlDbType.VarChar, 8) {Value = obj.TagId},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }

        /// <summary>
        /// ɾ��ָ����ָ������ϵ��
        /// </summary>
        /// <param name="obj">ָ����ָ������ϵʵ�塣</param>
        /// <returns>bool</returns>
        public override bool Delete(TagCategoryDetailInfo obj)
        {
            var sqlStatement = "Delete From T_Tag_CategoryDetail Where CategoryId = @CategoryId And TagId = @TagId";
            var parms = new[]
                            {
                                new SqlParameter("@CategoryId", SqlDbType.Int) {Value = obj.CategoryId},
                                new SqlParameter("@TagId", SqlDbType.VarChar, 8) {Value = obj.TagId},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// ��ȡ���е�ָ����ࡣ
        /// </summary>
        /// <returns>ָ�����ļ��ϡ�</returns>
        public override List<TagCategoryDetailInfo> GetAll()
        {
            var sqlStatement = "Select CategoryId,TagId From T_Tag_CategoryDetail";
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            var objs = new List<TagCategoryDetailInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToTagCategoryDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// �����ϼ�����Id��ȡָ����ࡣ
        /// </summary>
        /// <param name="categoryId">�ϼ�����Id��</param>
        /// <returns>ָ�����ļ��ϡ�</returns>
        public override List<TagCategoryDetailInfo> GetByCategoryId(int categoryId)
        {
            var sqlStatement = "Select CategoryId,TagId From T_Tag_CategoryDetail Where CategoryId = @CategoryId";
            var parms = new[] {new SqlParameter("@CategoryId", SqlDbType.Int) {Value = categoryId}};
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement,parms);
            var objs = new List<TagCategoryDetailInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToTagCategoryDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }

        

        #endregion
    }
}