using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Text;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    public sealed partial class SqlDataProvider
    {
        #region Field
        private SqlCategoryProvider innerSqlCategoryProvider;
        private SqlOperationProvider innerSqlOperationProvider;
        private SqlRelationProvider innerSqlRelationProvider;
        private SqlSchemaProvider innerSqlSchemaProvider;
        private SqlSchemaDataProvider innerSqlSchemaDataProvider;
        private SqlTagProvider innerSqlTagProvider;
        private SqlDateMsProvider innerSqlDateMsProvider;
        private SqlTagSqlMapProvider innerSqlTagSqlMapProvider;
        private SqlAnalogProvider innerSqlAnalogProvider;
        private SqlDigitalProvider innerSqlDigitalProvider;
        private SqlEnergyProvider innerSqlEnergyProvider;
        #endregion

        #region Property

        ///<summary>
        /// 报表分类对象的数据访问对象。
        ///</summary>
        /// <value></value>
        public override CategoryProvider CategoryProvider
        {
            get
            {
                if (innerSqlCategoryProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlCategoryProvider == null)
                        {
                            this.innerSqlCategoryProvider = new SqlCategoryProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlCategoryProvider;
            }
        }
        ///<summary>
        /// 报表操作记录的数据访问对象。
        ///</summary>
        /// <value></value>
        public override OperationProvider OperationProvider
        {
            get
            {
                if (innerSqlOperationProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlOperationProvider == null)
                        {
                            this.innerSqlOperationProvider = new SqlOperationProvider(_connectionString, _providerInvariantName,_useGzip);
                        }
                    }
                }
                return innerSqlOperationProvider;
            }
        }
        ///<summary>
        /// 报表操作记录的数据访问对象。
        ///</summary>
        /// <value></value>
        public override RelationProvider RelationProvider
        {
            get
            {
                if (innerSqlRelationProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlRelationProvider == null)
                        {
                            this.innerSqlRelationProvider = new SqlRelationProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlRelationProvider;
            }
        }
        /// <summary>
        /// 报表模板的数据访问对象。
        /// </summary>
        public override SchemaProvider SchemaProvider
        {
            get
            {
                if (innerSqlSchemaProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlSchemaProvider == null)
                        {
                            this.innerSqlSchemaProvider = new SqlSchemaProvider(_connectionString, _providerInvariantName,_useGzip);
                        }
                    }
                }
                return innerSqlSchemaProvider;
            }
        }
        /// <summary>
        /// 报表数据的数据访问对象.
        /// </summary>
        public override SchemaDataProvider SchemaDataProvider
        {
            get
            {
                if(innerSqlSchemaDataProvider == null)
                {
                    lock (syncRoot)
                    {
                        if(innerSqlSchemaDataProvider == null)
                        {
                            this.innerSqlSchemaDataProvider = new SqlSchemaDataProvider(_connectionString, _providerInvariantName,_useGzip);
                        }
                    }
                }
                return innerSqlSchemaDataProvider;
            }
        }
        /// <summary>
        /// 指标对象的数据访问对象。
        /// </summary>
        public override TagProvider TagProvider
        {
            get
            {
                if(innerSqlTagProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlTagProvider == null)
                        {
                            this.innerSqlTagProvider = new SqlTagProvider(_connectionString,_providerInvariantName);
                        }
                    }
                }
                return innerSqlTagProvider;
            }
        }
        /// <summary>
        /// 时间特征的数据访问对象。
        /// </summary>
        public override DateMsProvider DateMsProvider
        {
            get
            {
                if (innerSqlDateMsProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlDateMsProvider == null)
                        {
                            this.innerSqlDateMsProvider = new SqlDateMsProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlDateMsProvider;
            }
        }
        /// <summary>
        /// 本地指标与第三方采集指标的对应关系的数据访问对象。
        /// </summary>
        public override TagSqlMapProvider TagSqlMapProvider
        {
            get
            {
                if (innerSqlTagSqlMapProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlTagSqlMapProvider == null)
                        {
                            this.innerSqlTagSqlMapProvider = new SqlTagSqlMapProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlTagSqlMapProvider;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override AnalogProvider AnalogProvider
        {
            get
            {
                if (innerSqlAnalogProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlAnalogProvider == null)
                        {
                            this.innerSqlAnalogProvider = new SqlAnalogProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlAnalogProvider;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override DigitalProvider DigitalProvider
        {
            get
            {
                if (innerSqlDigitalProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlDigitalProvider == null)
                        {
                            this.innerSqlDigitalProvider = new SqlDigitalProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlDigitalProvider;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override EnergyProvider EnergyProvider
        {
            get
            {
                if (innerSqlEnergyProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSqlEnergyProvider == null)
                        {
                            this.innerSqlEnergyProvider = new SqlEnergyProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return innerSqlEnergyProvider;
            }
        }
        #endregion
    }
}
