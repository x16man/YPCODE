using System;
using System.Threading;

namespace Shmzh.Gather.Data.Bases
{
    /// <summary>
    /// Gather数据库依据配置文件以抽象工厂模式来创建数据访问层.
    /// </summary>
    public abstract class DataProvider : Shmzh.Components.SystemComponent.Provider
    {
        ///<summary>
        /// Current CategoryProvider instance.
        ///</summary>
        public virtual CategoryProvider CategoryProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current OperationProvider instance.
        ///</summary>
        public virtual OperationProvider OperationProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current RelationProvider instance.
        ///</summary>
        public virtual RelationProvider RelationProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current SchemaProvider instance.
        ///</summary>
        public virtual SchemaProvider SchemaProvider { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Current SchemaDataProvider instance.
        /// </summary>
        public virtual SchemaDataProvider SchemaDataProvider { get { throw new NotImplementedException(); } }

        ///<summary>
        /// Current TagProvider instance.
        ///</summary>
        public virtual TagProvider TagProvider { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Current TagCategoryProvider instance.
        /// </summary>
        public virtual TagCategoryProvider TagCategoryProvider { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Current TagCategoryDetailProvider instance.
        /// </summary>
        public virtual TagCategoryDetailProvider TagCategoryDetailProvider { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Current DateMsProvider instance.
        /// </summary>
        public virtual DateMsProvider DateMsProvider{get{throw new NotImplementedException();}}

        /// <summary>
        /// Current TagSqlMapProvider instance.
        /// </summary>
        public virtual TagSqlMapProvider TagSqlMapProvider { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Current AnalogProvider instance.
        /// </summary>
        public virtual AnalogProvider AnalogProvider{get{throw new NotImplementedException();}}

        /// <summary>
        /// Current DigitalProvider instance.
        /// </summary>
        public virtual DigitalProvider DigitalProvider{get { throw new NotImplementedException();}}

        /// <summary>
        /// Current EnergyProvider instance.
        /// </summary>
        public virtual EnergyProvider EnergyProvider{get { throw new NotImplementedException();}}


    }
}
