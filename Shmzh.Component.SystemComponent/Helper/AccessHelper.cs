using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// Access的数据访问帮助类。
    /// </summary>
    public sealed class AccessHelper
    {
        #region private method & constructor
        /// <summary>
        /// 
        /// </summary>
        private AccessHelper() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="mustCloseConnection"></param>
        private static void PrepareCommand(OleDbCommand command, OleDbConnection connection, OleDbTransaction transaction, string commandText, OleDbParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (null == command) throw new ArgumentNullException("command");
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException("commandText");

            if (ConnectionState.Closed == connection.State)
            {
                connection.Open();
                mustCloseConnection = true;
            }
            else
            {
                mustCloseConnection = false;
            }

            command.Connection = connection;

            command.CommandText = commandText;

            if (null != transaction)
            {
                if (null == transaction.Connection) throw new ArgumentException("transaction对象commited和rollbacked需要一个已打开的事务", "transaction");
                command.Transaction = transaction;
            }

            command.CommandType = CommandType.Text;

            if (null != commandParameters)
            {
                AttachParameters(command, commandParameters);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandParameters"></param>
        private static void AttachParameters(OleDbCommand command, OleDbParameter[] commandParameters)
        {
            if (null == command) throw new ArgumentNullException("command");

            if (null != commandParameters)
            {
                foreach (OleDbParameter p in commandParameters)
                {
                    if (null != p)
                    {
                        if ((ParameterDirection.Input == p.Direction || ParameterDirection.InputOutput == p.Direction) && (null == p.Value))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        #endregion private method & constructor

        #region ExecuteNonQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionstring, string commandText)
        {
            return ExecuteNonQuery(connectionstring, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connectionString || string.Empty == connectionString) throw new ArgumentNullException("connectionString");

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                return ExecuteNonQuery(connection, commandText, commandParameters);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbConnection connection, string commandText)
        {
            return ExecuteNonQuery(connection, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbConnection connection, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connection) throw new ArgumentNullException("connection");

            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;

            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandText, commandParameters, out mustCloseConnection);

            int retval = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            if (mustCloseConnection) connection.Close();

            return retval;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbTransaction transaction, string commandText)
        {
            return ExecuteNonQuery(transaction, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbTransaction transaction, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == transaction) throw new ArgumentNullException("transaction");
            if (null != transaction && null == transaction.Connection) throw new ArgumentException("transaction对象commited和rollbacked需要一个已打开的事务", "transaction");

            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandText, commandParameters, out mustCloseConnection);

            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            return retval;
        }

        #endregion ExecuteNonQuery

        #region ExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, string commandText)
        {
            return ExecuteScalar(connectionString, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connectionString && string.Empty == connectionString) throw new ArgumentNullException("connectionString");

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                return ExecuteScalar(connection, commandText, commandParameters);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(OleDbConnection connection, string commandText)
        {
            return ExecuteScalar(connection, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(OleDbConnection connection, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connection) throw new ArgumentNullException("connection");

            OleDbCommand cmd = new OleDbCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandText, commandParameters, out mustCloseConnection);

            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(OleDbTransaction transaction, string commandText)
        {
            return ExecuteScalar(transaction, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(OleDbTransaction transaction, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == transaction) throw new ArgumentNullException("transaction");
            if (null != transaction && null == transaction.Connection) throw new ArgumentException("transaction对象commited和rollbacked需要一个已打开的事务", "transaction");

            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandText, commandParameters, out mustCloseConnection);

            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();

            return retval;
        }

        #endregion ExecuteScalar

        #region ExecuteReader
        /// <summary>
        /// 
        /// </summary>
        private enum OleDbConnectionOwnership
        {
            /// <summary>
            /// 连接对象是由SqlHelper管理的
            /// </summary>
            Internal,
            /// <summary>
            /// 连接对象是由调用者管理的
            /// </summary>
            External
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="connectionOwnership"></param>
        /// <returns></returns>
        private static OleDbDataReader ExecuteReader(OleDbConnection connection, OleDbTransaction transaction, string commandText, OleDbParameter[] commandParameters, OleDbConnectionOwnership connectionOwnership)
        {
            if (null == connection) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;

            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandText, commandParameters, out mustCloseConnection);

                OleDbDataReader dataReader;

                if (OleDbConnectionOwnership.External == connectionOwnership)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                bool canClear = true;

                foreach (OleDbParameter commandParameter in cmd.Parameters)
                {
                    if (ParameterDirection.Input != commandParameter.Direction) canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                return dataReader;
            }
            catch
            {
                if (mustCloseConnection) connection.Close();
                throw;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="connection"></param>
        ///<param name="commandText"></param>
        ///<returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbConnection connection, string commandText)
        {
            return ExecuteReader(connection, commandText, (OleDbParameter[])null);
        }

        ///<summary>
        ///</summary>
        ///<param name="connection"></param>
        ///<param name="commandText"></param>
        ///<param name="commandParameters"></param>
        ///<returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbConnection connection, string commandText, params OleDbParameter[] commandParameters)
        {
            return ExecuteReader(connection, (OleDbTransaction)null, commandText, commandParameters, OleDbConnectionOwnership.External);
        }

        ///<summary>
        ///</summary>
        ///<param name="transaction"></param>
        ///<param name="commandText"></param>
        ///<returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, string commandText)
        {
            return ExecuteReader(transaction, commandText, (OleDbParameter[])null);
        }

        ///<summary>
        ///</summary>
        ///<param name="transaction"></param>
        ///<param name="commandText"></param>
        ///<param name="commandParameters"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        ///<exception cref="ArgumentException"></exception>
        public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == transaction) throw new ArgumentNullException("transaction");
            if (null != transaction && null == transaction.Connection) throw new ArgumentException("transaction对象commited和rollbacked需要一个已打开的事务", "transaction");

            return ExecuteReader(transaction.Connection, transaction, commandText, commandParameters, OleDbConnectionOwnership.External);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(string connectionString, string commandText)
        {
            return ExecuteReader(connectionString, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(string connectionString, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connectionString || string.Empty == connectionString) throw new ArgumentNullException("connectionString");
            OleDbConnection connection = null;
            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();

                return ExecuteReader(connection, (OleDbTransaction)null, commandText, commandParameters, OleDbConnectionOwnership.Internal);
            }
            catch
            {
                if (connection != null) connection.Close();
                throw;
            }
        }

        #endregion ExecuteReader

        #region ExecuteDataset
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText)
        {
            return ExecuteDataset(connectionString, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connectionString || string.Empty == connectionString) throw new ArgumentNullException("connectionString");

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                return ExecuteDataset(connection, commandText, commandParameters);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, string commandText)
        {
            return ExecuteDataset(connection, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == connection) throw new ArgumentNullException("connection");

            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandText, commandParameters, out mustCloseConnection);

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);

                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    connection.Close();

                return ds;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(OleDbTransaction transaction, string commandText)
        {
            return ExecuteDataset(transaction, commandText, (OleDbParameter[])null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(OleDbTransaction transaction, string commandText, params OleDbParameter[] commandParameters)
        {
            if (null == transaction) throw new ArgumentNullException("transaction");
            if (null != transaction && null == transaction.Connection) throw new ArgumentException("transaction对象commited和rollbacked需要一个已打开的事务", "transaction");

            OleDbCommand cmd = new OleDbCommand();
            bool mustCloseConnection = false;

            PrepareCommand(cmd, transaction.Connection, transaction, commandText, commandParameters, out mustCloseConnection);

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                da.Fill(ds);

                cmd.Parameters.Clear();

                return ds;
            }
        }

        #endregion ExecuteDataset
    }

    /// <summary>
    /// SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
    /// ability to discover parameters for stored procedures at run-time.
    /// </summary>
    public sealed class AccessHelperParameterCache
    {
        #region private methods, variables, and constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new SqlHelperParameterCache()"
        private AccessHelperParameterCache() { }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Resolve at run time the appropriate set of SqlParameters for a stored procedure
        /// </summary>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
        /// <returns>The parameter array discovered.</returns>
        private static OleDbParameter[] DiscoverSpParameterSet(OleDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            OleDbCommand cmd = new OleDbCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            OleDbCommandBuilder.DeriveParameters(cmd);
            connection.Close();

            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            OleDbParameter[] discoveredParameters = new OleDbParameter[cmd.Parameters.Count];

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            // Init the parameters with a DBNull value
            foreach (OleDbParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        /// <summary>
        /// Deep copy of cached SqlParameter array
        /// </summary>
        /// <param name="originalParameters">原始参数。</param>
        /// <returns>SqlParameter[]</returns>
        private static OleDbParameter[] CloneParameters(OleDbParameter[] originalParameters)
        {
            OleDbParameter[] clonedParameters = new OleDbParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (OleDbParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params OleDbParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static OleDbParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            OleDbParameter[] cachedParameters = paramCache[hashKey] as OleDbParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region Parameter Discovery Functions

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of SqlParameters</returns>
        public static OleDbParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        public static OleDbParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of SqlParameters</returns>
        internal static OleDbParameter[] GetSpParameterSet(OleDbConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        internal static OleDbParameter[] GetSpParameterSet(OleDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            using (OleDbConnection clonedConnection = (OleDbConnection)((ICloneable)connection).Clone())
            {
                return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        private static OleDbParameter[] GetSpParameterSetInternal(OleDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : string.Empty);

            OleDbParameter[] cachedParameters;

            cachedParameters = paramCache[hashKey] as OleDbParameter[];
            if (cachedParameters == null)
            {
                OleDbParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }

            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions
    }
}
