using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.Util;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;
using YPWater.Web;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlSchemaDataProvider:SchemaDataProvider
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
        /// <summary>
        /// 是否使用GZip.
        /// </summary>
        public string UseGZip
        {
            get { return _useGzip; }
            set { this._useGzip = value; }
        }
        /// <summary>
        /// 是否启用压缩.
        /// </summary>
        public bool IsZipped
        {
            get { return this._useGzip.ToUpper() == "TRUE"; }
        }
        /// <summary>
        /// Excel报表模板对象.
        /// </summary>
        public CSchema MySchema { get; set; }
        #endregion

        #region CTOR
        /// <summary>
		/// Creates a new <see cref="SqlCategoryProvider"/> instance.
		/// </summary>
		public SqlSchemaDataProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlCategoryProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    /// <param name="useGzip">是否使用GZip压缩.</param>
	    public SqlSchemaDataProvider(string connectionString, string providerInvariantName, string useGzip)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
            this._useGzip = useGzip;
            this.MySchema = new CSchema();
	    }
        #endregion

        #region private method
        
        #endregion

        #region Overrides of SchemaDataProvider

        /// <summary>
        /// 根据指定的报表模板和日期以及是否能够修改选项获取报表的数据内容
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <param name="currentDate">报表日期。</param>
        /// <param name="canModify">是否能够修改。</param>
        /// <returns>报表数据对象.</returns>
        public override SchemaDataInfo GetSchemaData(string id, DateTime currentDate, bool canModify)
        {
            var schemaDataString = new CSchema().GetSchema(id, currentDate, canModify);
            //Logger.Debug(schemaDataString);
            var semicolonIndex = schemaDataString.IndexOf(";");
            //Logger.Debug(semicolonIndex);
            if (semicolonIndex >= 0)
            {
                schemaDataString = schemaDataString.Substring(semicolonIndex + 1, schemaDataString.Length - semicolonIndex - 1);
            }
            else
            {
                schemaDataString = string.Empty;
            }

            if (this.IsZipped)
                schemaDataString = StringUtil.Zip(schemaDataString);
            var obj = new SchemaDataInfo
                          {
                              Id = id,
                              IsZipped = this.IsZipped,
                              NewXmlData = string.Empty,
                              OldXmlData = schemaDataString,
                              ReportDate = currentDate,
                              UserCode = string.Empty,
                              UserName = string.Empty,
                              UserIp = string.Empty
                          };
            return obj;
        }

        /// <summary>
        /// 保存报表数据。
        /// </summary>
        /// <param name="obj">报表数据对象。</param>
        /// <returns>bool</returns>
        public override bool SaveSchemaData(SchemaDataInfo obj)
        {
            if (obj.IsZipped)
            {
                obj.OldXmlData = StringUtil.UnZip(obj.OldXmlData);
                obj.NewXmlData = StringUtil.UnZip(obj.NewXmlData);
            }

            return new CSchema().SaveSchema(obj.Id, obj.ReportDate, obj.NewXmlData, obj.OldXmlData, obj.UserCode, obj.UserName, obj.UserIp);
        }

        /// <summary>
        /// 确认报表数据.
        /// </summary>
        /// <param name="obj">报表数据对象.</param>
        /// <returns>bool</returns>
        public override bool SureSchemaData(SchemaDataInfo obj)
        {
            return new CSchema().AddOperateInfo(obj.UserCode, obj.UserName, obj.UserIp, obj.Id, 2, obj.ReportDate, string.Empty, string.Empty);
        }

        /// <summary>
        /// 取消确认报表数据.
        /// </summary>
        /// <param name="obj">报表数据对象.</param>
        /// <returns>bool</returns>
        public override bool CancelSchemaData(SchemaDataInfo obj)
        {
            return new CSchema().AddOperateInfo(obj.UserCode, obj.UserName, obj.UserIp, obj.Id, 3, obj.ReportDate, string.Empty, string.Empty);
        }

        #endregion
    }
}
