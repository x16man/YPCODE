using System;
using System.Data;
using System.Data.SqlClient;

namespace MZHCommon.Database
{
	/// <summary>
	/// dbAccess ��ժҪ˵����
	/// </summary>
	public class dbAccess:IDisposable
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SqlDataAdapter dsCommand;
		private SqlCommand updateCommand;
        public string ConnectionString
        {
            get
            {
#pragma warning disable 618,612
                return System.Configuration.ConfigurationSettings.AppSettings["KMConnectionString"];
#pragma warning restore 618,612
            }
        }
        #endregion
        public dbAccess()
		{
			dsCommand=new SqlDataAdapter();
			updateCommand=new SqlCommand();
		}

		/// <summary>
		///     Dispose of this object's resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); // as a service to those who might inherit from us
		}

		/// <summary>
		///		Free the instance variables of this object.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; // we're being collected, so let the GC take care of this object

			if (dsCommand != null)
			{
				if(dsCommand.SelectCommand != null)
				{    
					if( dsCommand.SelectCommand.Connection != null )
						dsCommand.SelectCommand.Connection.Dispose();
					dsCommand.SelectCommand.Dispose();
				}    
				dsCommand.Dispose();
				dsCommand = null;
			}

			if(updateCommand!=null)
			{
				if (updateCommand.Connection!=null)
				{
					updateCommand.Connection.Dispose();
				}
				updateCommand.Dispose();
				updateCommand=null;
			}

		}


		/// <summary>
		/// ִ�в�ѯ���
		/// </summary>
		/// <param name="strSQL">Ҫִ�е�SQL���</param>
		/// <param name="data">�������DataSet</param>
		/// <returns>>0,��ȷ -100������</returns>
		public int ExecSelect(string strSQL, DataTable data)
		{
			if (dsCommand.SelectCommand==null)
			{
				dsCommand.SelectCommand=new SqlCommand {Connection = new SqlConnection(ConnectionString)};
			}

			try
			{
				dsCommand.SelectCommand.CommandText=strSQL;
				dsCommand.Fill(data);
				return 0;
			}
			catch(Exception ex)
			{
				Logger.Error("SQL��䣺 " + strSQL + " ִ�г���", ex);
				return -100;
			}
			finally
			{
				if (dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.Dispose();
				}
			}
		}

		/// <param name="strSQL">Ҫִ�е�SQL���</param>
		/// <param name="ParamArrary">�������飬��������Sql����еĲ�����</param>
		/// <param name="data">�������DataSet</param>
		public int ExecSelect(string strSQL,System.Data.SqlClient.SqlParameter[] ParamArrary,DataTable data)
		{
			if (dsCommand.SelectCommand==null)
			{
				dsCommand.SelectCommand=new SqlCommand {Connection = new SqlConnection(ConnectionString)};
			}

			try
			{
				dsCommand.SelectCommand.CommandText=strSQL;
				for (int i=0;i<ParamArrary.Length;i++)
				{
					dsCommand.SelectCommand.Parameters.Add(ParamArrary[i]);
				}
				dsCommand.Fill(data);
				return 0;
			}
			catch(Exception ex)
			{
				Logger.Warn("SQL��䣺 " + strSQL + " ִ�г���",ex);
				return -100;
			}
			finally
			{
				if (dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.Dispose();
				}
			}
		}

		/// <summary>
		/// ���ô洢����ִ�в�ѯ���
		/// </summary>
		/// <param name="commandText">�洢������</param>
		/// <param name="ParamArrary">��������</param>
		/// <param name="data">�������DataSet</param>
		/// <returns>>0,��ȷ -100������</returns>
		public int ExecSelectSP(String commandText,System.Data.SqlClient.SqlParameter[] ParamArrary,DataTable data)
		{
			if (dsCommand.SelectCommand==null)
			{
				dsCommand.SelectCommand=new SqlCommand {Connection = new SqlConnection(ConnectionString)};
			}
			try
			{
				dsCommand.SelectCommand.CommandText=commandText;
				dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
				for (var i=0;i<ParamArrary.Length;i++)
				{
					dsCommand.SelectCommand.Parameters.Add(ParamArrary[i]);
				}
				dsCommand.Fill(data);
				return 0;
			}
			catch(Exception ex)
			{
				Logger.Error("�洢���̣� " + commandText + " ִ�г���",ex);
				return -100;
			}
			finally
			{
				if (dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.Dispose();
				}
			}			
		}

		/// <summary>
		/// ���ô洢����ִ�в�ѯ���
		/// </summary>
		/// <param name="commandText">�洢������</param>
		/// <param name="data">�������DataSet</param>
		/// <returns>>0,��ȷ -100������</returns>
		public int ExecSelectSP(String commandText,DataTable data)
		{
			if (dsCommand.SelectCommand==null)
			{
				dsCommand.SelectCommand=new SqlCommand {Connection = new SqlConnection(ConnectionString)};
			}
			try
			{
				dsCommand.SelectCommand.CommandText=commandText;
				dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;				
				dsCommand.Fill(data);
				return 0;
			}
			catch(Exception ex)
			{
				Logger.Error("�洢���̣� " + commandText + " ִ�г���",ex);
				return -100;
			}
			finally
			{
				if (dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.Dispose();
				}
			}			
		}

	
		/// <summary>
		/// ִ�в��롢���¡�ɾ�����
		/// </summary>
		/// <param name="strSQL">Ҫִ�е�SQL���</param>
		/// <returns>>0,��ȷ -100������</returns>
		public int ExecUpdate(string strSQL)
		{
			try
			{
                updateCommand.Connection = new SqlConnection(ConnectionString);
				updateCommand.Connection.Open();
				updateCommand.CommandText=strSQL;
				return updateCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				Logger.Error("SQL��䣺 " + strSQL + " ִ�г���",ex);
				return -100;
			}
			finally
			{
				if (updateCommand.Connection!=null)
				{
					updateCommand.Connection.Dispose();
				}
			}

		}

		/// <param name="strSQL">Ҫִ�е�SQL���</param>
		///	<param name="ParamArrary">�������飬��������Sql����еĲ�����</param>
		/// <returns>>0,��ȷ -100������</returns>
		public int ExecUpdate(string strSQL,System.Data.SqlClient.SqlParameter[] ParamArrary)
		{
			try
			{
                updateCommand.Connection = new SqlConnection(ConnectionString);
				updateCommand.Connection.Open();
				updateCommand.CommandText=strSQL;
				for (int i=0;i<ParamArrary.Length;i++)
				{
					updateCommand.Parameters.Add(ParamArrary[i]);
				}
				return updateCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				Logger.Error("SQL��䣺 " + strSQL + " ִ�г���",ex);
				return -100;
			}
			finally
			{
				if (updateCommand.Connection!=null)
				{
					updateCommand.Connection.Dispose();
				}
			}

		}

		public int ExecUpdateSP(string commandText,System.Data.SqlClient.SqlParameter[] ParamArrary)
		{
			try
			{
                updateCommand.Connection = new SqlConnection(ConnectionString);
				updateCommand.Connection.Open();
				updateCommand.CommandText=commandText;
				updateCommand.CommandType=CommandType.StoredProcedure;
				for (int i=0;i<ParamArrary.Length;i++)
				{
					updateCommand.Parameters.Add(ParamArrary[i]);
				}
				return updateCommand.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Logger.Error("�洢���̣� " + commandText + " ִ�г���",ex);
				return -100;
			}
			finally
			{
				if (updateCommand.Connection!=null)
				{
					updateCommand.Connection.Dispose();
				}
			}
		}
	}
}
