using System;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
//using System.EnterpriseServices;
using System.Collections;
//using MZHCommon.SystemFrameWork;

namespace MZHCommon.Database
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class SQLServer
	{
		#region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		/// <summary>
		/// SQL Server数据库连接对象.
		/// </summary>
		private SqlConnection mobjConnection=null;
		/// <summary>
		/// 模块名称.
		/// </summary>
		private string mstrModuleName;
		/// <summary>
		/// 
		/// </summary>
		private bool mblnDisposed=false;
		/// <summary>
		/// 异常信息.
		/// </summary>
		private string mExceptionMessage = "";
		#endregion

		#region 构造函数.
		/// <summary>
		/// 缺省的构造函数。
		/// </summary>
		/// <remarks>
		/// 数据库连接串固定从Web.Config的ConnectionStrin节点去获取.
		/// </remarks>
		public SQLServer()
		{
			mstrModuleName=this.GetType().ToString();
			mobjConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
		}
		/// <summary>
		/// 重载的构造函数.
		/// </summary>
		/// <param name="ConnectionString">string:	数据库连接字符串.</param>
		/// <remarks>
		/// 指定数据库连接字符串.
		/// </remarks>
		public SQLServer(string ConnectionString)
		{
			mobjConnection=new SqlConnection(ConnectionString);
			mstrModuleName=this.GetType().ToString();
		}

		#endregion

		#region 属性
		/// <summary>
		/// 数据库连接字符串.
		/// </summary>
		public string DBConnection
		{
			get
			{
				try
				{
					return mobjConnection.ConnectionString;
				}
				catch
				{
					return "";
				}
			}
		//	set
		//	{
		//		 mobjConnection = new SqlConnection(value);
		//	}
		}

		/// <summary>
		/// 异常信息.
		/// </summary>
		public string ExceptionMessage
		{
			get {return this.mExceptionMessage;}
			set {this.mExceptionMessage +="\r\n"+ value;}
		}
		#endregion

		#region 公开方法.
		/// <summary>
		/// 返回Bool值的带参数的存储过程执行.
		/// </summary>
		/// <param name="SPName">string:	存储过程名称.</param>
		/// <param name="ParamValues">Hashtable:	参数列表.</param>
		/// <param name="dt">DataTable:	指定填充数据的数据表..</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		/// <remarks>这种方式,由外面指定了DataSet,然后再执行存储过程时再指定填充数据到该DataSet的DataTable中.
		/// 方法本身的返回值是bool类型,但是由于DataSet是引用类型,所以数据集,在方法执行完后直接使用.
		/// 本方法的缺点是一次执行职能填充一个DataTable.
		/// </remarks>
		public bool ExecSPReturnDS(string SPName,Hashtable ParamValues,DataTable dt)
		{
			DataSet objDS=new DataSet();
			SqlCommand objCommand=null;
			SqlDataAdapter objDA=null;
			bool ret=true;

			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}

				ValidateSPName(SPName);

				objCommand=new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType=CommandType.StoredProcedure;
			
				BuildParameters(objCommand,SPName,ParamValues);

				objDA=new SqlDataAdapter(objCommand);

				objDA.Fill(dt);
				//返回参数值。
				this.ReturnOutPutParameter(objCommand, ParamValues);

				return true;
			}
//			catch(Exception objException)
//			{
//				LogError(objException);
//				this.ExceptionMessage = objException.Message;
//				ret= false;
//			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
					ret = false;
				}
			}
			finally
			{
				objCommand.Connection.Close();
				objCommand.Dispose();
			}
			return ret;
		}		// End ExecSPReturnDS
		/// <summary>
		/// 返回DataSet的结果集的带参数的存储过程执行.
		/// </summary>
		/// <param name="SPName">string:	存储过程名.</param>
		/// <param name="ParamValues">Hashtable:	参数列表.</param>
		/// <returns>DataSet:	数据集.如果执行不成功返回null.</returns>
		public DataSet ExecSPReturnDS(string SPName,Hashtable ParamValues)
		{
			DataSet objDS=new DataSet();
			SqlCommand objCommand=null;
			SqlDataAdapter objDA=null;
			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}

				ValidateSPName(SPName);

				objCommand=new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType=CommandType.StoredProcedure;
			
				BuildParameters(objCommand,SPName,ParamValues);

				objDA=new SqlDataAdapter(objCommand);

				objDA.Fill(objDS);
				//返回参数值。
				this.ReturnOutPutParameter(objCommand, ParamValues);

				return objDS;
			}
//			catch(Exception objException)
//			{
//				LogError(objException);
//				this.ExceptionMessage = objException.Message;
//			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
				}
			}
			finally
			{
				objCommand.Connection.Close();
				objCommand.Dispose();
			}
			return null;
		}		// End ExecSPReturnDS
	
		/// <summary>
		/// 返回DataSet的结果集的带参数的存储过程执行.
		/// </summary>
		/// <param name="SPName">string:	存储过程名.</param>
		/// <param name="ParamValues">Hashtable:	参数列表.</param>
		/// <param name="inDataSet">DataSet:	数据集.</param>
		/// <param name="TableName">string:	数据表名称.</param>
		/// <returns>DataSet:	数据集.如果执行不成功返回null.</returns>
		public DataSet ExecSPReturnDS(string SPName,Hashtable ParamValues,DataSet inDataSet, string TableName)
		{
			SqlCommand objCommand=null;
			SqlDataAdapter objDA=null;
			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}
				ValidateSPName(SPName);
				objCommand=new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType=CommandType.StoredProcedure;
				BuildParameters(objCommand,SPName,ParamValues);
				objDA=new SqlDataAdapter(objCommand);
				objDA.Fill(inDataSet, TableName);
				//返回参数值。
				this.ReturnOutPutParameter(objCommand, ParamValues);
				return inDataSet;
			}
//			catch(Exception objException)
//			{
//				LogError(objException);
//				this.ExceptionMessage = objException.Message;
//			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
				}
			}
			finally
			{
				objCommand.Connection.Close();
				objCommand.Dispose();
			}
			return null;
		}
		/// <summary>
		/// 执行无参数的存储过程
		/// </summary>
		/// <param name="SPName">存储过程名称</param>
		/// <param name="dt">表</param>
		/// <returns>true or false</returns>
		public bool ExecSPReturnDS(string SPName,DataTable dt)
		{
			DataSet objDS = new DataSet();
			SqlCommand objCommand = null;
			SqlDataAdapter objDA = null;
			bool ret = true;
			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}
				ValidateSPName(SPName);
				objCommand = new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDA = new SqlDataAdapter(objCommand);
				objDA.Fill(dt);
				return true;
			}
//			catch(Exception objException)
//			{
//				LogError(objException);
//				this.ExceptionMessage = objException.Message;
//				ret = false;
//			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
					ret = false;
				}
			}
			finally
			{
				objCommand.Connection.Close();
				objCommand.Dispose();
			}
			return ret;

		}		
		/// <summary>
		/// 返回DataSet的不带参数的存储过程执行.
		/// </summary>
		/// <param name="SPName">string:	存储过程名.</param>
		/// <returns>DataSet:	数据集.执行不成功返回null.</returns>
		public DataSet ExecSPReturnDS(string SPName)
		{
			DataSet objDS = new DataSet();
			SqlCommand objCommand = null;
			SqlDataAdapter objDA = null;
			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}
				ValidateSPName(SPName);
				objCommand = new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDA = new SqlDataAdapter(objCommand);
				objDA.Fill(objDS);
				return objDS;
			}
//			catch(Exception objException)
//			{
//				LogError(objException);
//				this.ExceptionMessage = objException.Message;
//			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
				}
			}
			finally
			{
				objCommand.Connection.Close();
				objCommand.Dispose();
			}
			return null;

		}
		/// <summary>
		/// 返回DataSet的不带参数的存储过程执行.
		/// </summary>
		/// <param name="SPName">string:	存储过程名.</param>
		/// <param name="inDataSet">DataSet:	数据集.</param>
		/// <param name="TableName">string:	DataTable名称.</param>
		/// <returns>DataSet:	数据集.执行不成功返回null.</returns>
		public DataSet ExecSPReturnDS(string SPName,DataSet inDataSet, string TableName)
		{
			SqlCommand objCommand = null;
			SqlDataAdapter objDA = null;
			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}

				ValidateSPName(SPName);
				objCommand = new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDA = new SqlDataAdapter(objCommand);
				objDA.Fill(inDataSet, TableName);
				return inDataSet;
			}
//			catch(Exception objException)
//			{
//				LogError(objException);
//				this.ExceptionMessage = objException.Message;
//			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
				}
			}
			finally
			{
				objCommand.Connection.Close();
				objCommand.Dispose();
			}
			return inDataSet;
		}
		/// <summary>
		/// 无返回值的执行存储过程
		/// </summary>
		/// <param name="SPName">存储过程名称</param>
		/// <param name="ParamValues">参数列表</param>
		/// <returns>true or false</returns>
		public bool ExecSP(string SPName, Hashtable ParamValues)
		{
			SqlCommand objCommand = null;
			bool ret = true;

			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}

				ValidateSPName(SPName);

				objCommand = new SqlCommand(SPName, mobjConnection);
				objCommand.CommandType = CommandType.StoredProcedure;
			
				BuildParameters(objCommand, SPName, ParamValues);

				mobjConnection.Open();

				objCommand.ExecuteNonQuery();
				
				//返回参数值。
				this.ReturnOutPutParameter(objCommand, ParamValues);
			}
			catch(SqlException sqlException)
			{
                Logger.Error(sqlException.Message,sqlException);
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
				}
				ret = false;
			}
			finally
			{
				mobjConnection.Close();
                if(objCommand != null)
				    objCommand.Dispose();
			}
			return ret;
		}		//End ExecSP

		/// <summary>
		/// 无参数、无结果集的存储过程调用
		/// </summary>
		/// <param name="SPName">存储过程名称</param>
		/// <returns>true or false</returns>
		public bool ExecSP(string SPName)
		{
			SqlCommand objCommand=null;
			bool ret=true;

			try
			{
				if(mblnDisposed)
				{
					throw new ObjectDisposedException(mstrModuleName,"This object has already been disposed.");
				}
				ValidateSPName(SPName);
				objCommand=new SqlCommand(SPName,mobjConnection);
				objCommand.CommandType=CommandType.StoredProcedure;
				mobjConnection.Open();
				objCommand.ExecuteNonQuery();
			}
			catch(SqlException sqlException)
			{
				for (int i=0;i<sqlException.Errors.Count; i++)
				{
					LogError(sqlException.Errors[i].Number.ToString());
					LogError(sqlException.Errors[i].Message);
					this.ExceptionMessage = sqlException.Errors[i].Message;
					ret = false;
				}
			}
			finally
			{
				mobjConnection.Close();
				objCommand.Dispose();
			}
			return ret;
		}		
#endregion

        #region Private/Protected Methods
		/// <summary>
		/// 根据存储过程名和Hashtable来构建存储过程的参数列表.
		/// </summary>
		/// <param name="Command">SqlCommand:	SqlCommand对象.</param>
		/// <param name="SPName">string:	存储过程名.</param>
		/// <param name="ParamValues">Hashtable:	参数表.</param>
		private void BuildParameters(SqlCommand Command,string SPName,Hashtable ParamValues)
		{
			//Clear the parameters collection for the SQLCommand
			Command.Parameters.Clear();

			string strSQL="select * from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_NAME='" +SPName+ "' order by ORDINAL_POSITION";

			DataTable dt=new DataTable();

			SqlDataAdapter ParameterDA=new SqlDataAdapter(strSQL,mobjConnection);

			ParameterDA.Fill(dt);

			ParameterDA.Dispose();

			SqlParameter myParameter=null;

			for(int i=0;i<dt.Rows.Count;i++)
			{
				myParameter = new SqlParameter();

				//Get the attribute values for the <Parameter> element.name
				//参数名称
				myParameter.ParameterName = dt.Rows[i]["PARAMETER_NAME"].ToString();
				//方向
				myParameter.Direction =GetParamDirection(dt.Rows[i]["PARAMETER_MODE"].ToString());
				//类型
				myParameter.SqlDbType=GetSQLDataType(dt.Rows[i]["DATA_TYPE"].ToString());
				//值
				myParameter.Value=ParamValues[dt.Rows[i]["PARAMETER_NAME"].ToString()];

				Command.Parameters.Add(myParameter);
			}
		}
		/// <summary>
		/// 返回存储过程中参数类型为Output,InputOutput,ReturnValue的参数值。
		/// </summary>
		/// <param name="SPName">string:	存储过程名称。</param>
		private void ReturnOutPutParameter(SqlCommand objCommand, Hashtable ParamValues)
		{
			for(int i = 0; i < objCommand.Parameters.Count; i++)
			{
				if ( objCommand.Parameters[i].Direction == ParameterDirection.Output ||
					objCommand.Parameters[i].Direction == ParameterDirection.InputOutput ||
					objCommand.Parameters[i].Direction == ParameterDirection.ReturnValue)
				{
					ParamValues[objCommand.Parameters[i].ParameterName] = objCommand.Parameters[i].Value;
				}
			}
		}
		/// <summary>
		/// 参数方向的数据类型转换.
		/// </summary>
		/// <param name="ParamDirection">string:	参数方向的字符串.</param>
		/// <returns></returns>
		private ParameterDirection  GetParamDirection(string ParamDirection)
		{
			switch(ParamDirection.ToUpper())
			{
				case "IN":
				{
					return System.Data.ParameterDirection.Input;
				}
				case "OUT":
				{
					return System.Data.ParameterDirection.Output;
				}
				case "RETURN":
				{
					return System.Data.ParameterDirection.ReturnValue;
				}
				case "INOUT":
				{
					return System.Data.ParameterDirection.InputOutput;
				}
				default:
				{
					//Default to Input if anything else is supplied
					return System.Data.ParameterDirection.Input;
				}
			 }
		}
		/// <summary>
		/// 数据库数据类型对应.
		/// </summary>
		/// <param name="SQLDataType">string:	数据类型字符串.</param>
		/// <returns>SqlDbType:	SQL Server 数据类型.</returns>
		private SqlDbType GetSQLDataType(string SQLDataType)
		{
			switch(SQLDataType.ToLower())
			{
				case "numeric":
					return SqlDbType.BigInt;
				case "bigint":
					return SqlDbType.BigInt;
				case "binary":
					return SqlDbType.Binary;
				case "bit":
					return SqlDbType.Bit;
				case "char":
					return SqlDbType.Char;
				case "datetime":
					return SqlDbType.DateTime;
				case "decimal":
					return SqlDbType.Decimal;
				case "float":
					return SqlDbType.Float;
				case "image":
					return SqlDbType.Image;
				case "int":
					return SqlDbType.Int;
				case "money":
					return SqlDbType.Money;
				case "nchar":
					return SqlDbType.NChar;
				case "ntext":
					return SqlDbType.NText;
				case "nvarchar":
					return SqlDbType.NVarChar;
				case "real":
					return SqlDbType.Real;
				case "smalldatetime":
					return SqlDbType.SmallDateTime;
				case "smallint":
					return SqlDbType.SmallInt;
				case "smallmoney":
					return SqlDbType.SmallMoney;
				case "text":
					return SqlDbType.Text;
				case "timestamp":
					return SqlDbType.Timestamp;
				case "tinyint":
					return SqlDbType.TinyInt;
				case "uniqueidentifier":
					return SqlDbType.UniqueIdentifier;
				case "varbinary":
					return SqlDbType.VarBinary;
				case "varchar":
					return SqlDbType.VarChar;
				case "variant":
					return SqlDbType.Variant;
				default:
					//'Default to Variant if anything else is supplied
					return SqlDbType.Variant;
			}
		}

		/// <summary>
		/// 校验存储过程名称的有效性.
		/// </summary>
		/// <param name="SPName">string:	存储过程名称.</param>
		private void ValidateSPName(string SPName)
		{
			if((SPName.Length<1)||(SPName.Length>128))
			{
				throw new Exception("A valid stored procedure name must be provided.");
			}
		}
		/// <summary>
		/// 记录错误日志.
		/// </summary>
		/// <param name="objException">Exception:	异常对象.</param>
		private void LogError(Exception objException)
		{
			string strLogMsg;
			try
			{
				strLogMsg="An error occurred in the following module:" + mstrModuleName + "\r\n" + "Source: " + objException.Source + "Message: "+ "Stack Trace:  " + objException.StackTrace + "Target Site:  " + objException.TargetSite.ToString();
                Logger.Error("存储过程： " + strLogMsg + " 执行出错！",objException);
			}
			catch
			{
			}
		}
		/// <summary>
		/// 记录错误日志.
		/// </summary>
		/// <param name="Message">string:	错误消息.</param>
		private void LogError(string Message)
		{
			try
			{
				Message +="\r\n";
                Logger.Error(Message);
			}
			catch
			{}
		}

		#endregion																																																				
	}
}

