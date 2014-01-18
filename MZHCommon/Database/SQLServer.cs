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
	/// Class1 ��ժҪ˵����
	/// </summary>
	public class SQLServer
	{
		#region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		/// <summary>
		/// SQL Server���ݿ����Ӷ���.
		/// </summary>
		private SqlConnection mobjConnection=null;
		/// <summary>
		/// ģ������.
		/// </summary>
		private string mstrModuleName;
		/// <summary>
		/// 
		/// </summary>
		private bool mblnDisposed=false;
		/// <summary>
		/// �쳣��Ϣ.
		/// </summary>
		private string mExceptionMessage = "";
		#endregion

		#region ���캯��.
		/// <summary>
		/// ȱʡ�Ĺ��캯����
		/// </summary>
		/// <remarks>
		/// ���ݿ����Ӵ��̶���Web.Config��ConnectionStrin�ڵ�ȥ��ȡ.
		/// </remarks>
		public SQLServer()
		{
			mstrModuleName=this.GetType().ToString();
			mobjConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
		}
		/// <summary>
		/// ���صĹ��캯��.
		/// </summary>
		/// <param name="ConnectionString">string:	���ݿ������ַ���.</param>
		/// <remarks>
		/// ָ�����ݿ������ַ���.
		/// </remarks>
		public SQLServer(string ConnectionString)
		{
			mobjConnection=new SqlConnection(ConnectionString);
			mstrModuleName=this.GetType().ToString();
		}

		#endregion

		#region ����
		/// <summary>
		/// ���ݿ������ַ���.
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
		/// �쳣��Ϣ.
		/// </summary>
		public string ExceptionMessage
		{
			get {return this.mExceptionMessage;}
			set {this.mExceptionMessage +="\r\n"+ value;}
		}
		#endregion

		#region ��������.
		/// <summary>
		/// ����Boolֵ�Ĵ������Ĵ洢����ִ��.
		/// </summary>
		/// <param name="SPName">string:	�洢��������.</param>
		/// <param name="ParamValues">Hashtable:	�����б�.</param>
		/// <param name="dt">DataTable:	ָ��������ݵ����ݱ�..</param>
		/// <returns>bool:	�ɹ�����true,ʧ�ܷ���false.</returns>
		/// <remarks>���ַ�ʽ,������ָ����DataSet,Ȼ����ִ�д洢����ʱ��ָ��������ݵ���DataSet��DataTable��.
		/// ��������ķ���ֵ��bool����,��������DataSet����������,�������ݼ�,�ڷ���ִ�����ֱ��ʹ��.
		/// ��������ȱ����һ��ִ��ְ�����һ��DataTable.
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
				//���ز���ֵ��
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
		/// ����DataSet�Ľ�����Ĵ������Ĵ洢����ִ��.
		/// </summary>
		/// <param name="SPName">string:	�洢������.</param>
		/// <param name="ParamValues">Hashtable:	�����б�.</param>
		/// <returns>DataSet:	���ݼ�.���ִ�в��ɹ�����null.</returns>
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
				//���ز���ֵ��
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
		/// ����DataSet�Ľ�����Ĵ������Ĵ洢����ִ��.
		/// </summary>
		/// <param name="SPName">string:	�洢������.</param>
		/// <param name="ParamValues">Hashtable:	�����б�.</param>
		/// <param name="inDataSet">DataSet:	���ݼ�.</param>
		/// <param name="TableName">string:	���ݱ�����.</param>
		/// <returns>DataSet:	���ݼ�.���ִ�в��ɹ�����null.</returns>
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
				//���ز���ֵ��
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
		/// ִ���޲����Ĵ洢����
		/// </summary>
		/// <param name="SPName">�洢��������</param>
		/// <param name="dt">��</param>
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
		/// ����DataSet�Ĳ��������Ĵ洢����ִ��.
		/// </summary>
		/// <param name="SPName">string:	�洢������.</param>
		/// <returns>DataSet:	���ݼ�.ִ�в��ɹ�����null.</returns>
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
		/// ����DataSet�Ĳ��������Ĵ洢����ִ��.
		/// </summary>
		/// <param name="SPName">string:	�洢������.</param>
		/// <param name="inDataSet">DataSet:	���ݼ�.</param>
		/// <param name="TableName">string:	DataTable����.</param>
		/// <returns>DataSet:	���ݼ�.ִ�в��ɹ�����null.</returns>
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
		/// �޷���ֵ��ִ�д洢����
		/// </summary>
		/// <param name="SPName">�洢��������</param>
		/// <param name="ParamValues">�����б�</param>
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
				
				//���ز���ֵ��
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
		/// �޲������޽�����Ĵ洢���̵���
		/// </summary>
		/// <param name="SPName">�洢��������</param>
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
		/// ���ݴ洢��������Hashtable�������洢���̵Ĳ����б�.
		/// </summary>
		/// <param name="Command">SqlCommand:	SqlCommand����.</param>
		/// <param name="SPName">string:	�洢������.</param>
		/// <param name="ParamValues">Hashtable:	������.</param>
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
				//��������
				myParameter.ParameterName = dt.Rows[i]["PARAMETER_NAME"].ToString();
				//����
				myParameter.Direction =GetParamDirection(dt.Rows[i]["PARAMETER_MODE"].ToString());
				//����
				myParameter.SqlDbType=GetSQLDataType(dt.Rows[i]["DATA_TYPE"].ToString());
				//ֵ
				myParameter.Value=ParamValues[dt.Rows[i]["PARAMETER_NAME"].ToString()];

				Command.Parameters.Add(myParameter);
			}
		}
		/// <summary>
		/// ���ش洢�����в�������ΪOutput,InputOutput,ReturnValue�Ĳ���ֵ��
		/// </summary>
		/// <param name="SPName">string:	�洢�������ơ�</param>
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
		/// �����������������ת��.
		/// </summary>
		/// <param name="ParamDirection">string:	����������ַ���.</param>
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
		/// ���ݿ��������Ͷ�Ӧ.
		/// </summary>
		/// <param name="SQLDataType">string:	���������ַ���.</param>
		/// <returns>SqlDbType:	SQL Server ��������.</returns>
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
		/// У��洢�������Ƶ���Ч��.
		/// </summary>
		/// <param name="SPName">string:	�洢��������.</param>
		private void ValidateSPName(string SPName)
		{
			if((SPName.Length<1)||(SPName.Length>128))
			{
				throw new Exception("A valid stored procedure name must be provided.");
			}
		}
		/// <summary>
		/// ��¼������־.
		/// </summary>
		/// <param name="objException">Exception:	�쳣����.</param>
		private void LogError(Exception objException)
		{
			string strLogMsg;
			try
			{
				strLogMsg="An error occurred in the following module:" + mstrModuleName + "\r\n" + "Source: " + objException.Source + "Message: "+ "Stack Trace:  " + objException.StackTrace + "Target Site:  " + objException.TargetSite.ToString();
                Logger.Error("�洢���̣� " + strLogMsg + " ִ�г���",objException);
			}
			catch
			{
			}
		}
		/// <summary>
		/// ��¼������־.
		/// </summary>
		/// <param name="Message">string:	������Ϣ.</param>
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

