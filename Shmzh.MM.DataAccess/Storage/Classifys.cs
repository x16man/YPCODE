//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Data.SqlClient;
	using System.Configuration ;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// ��;�����ݷ��ʲ㡣
	/// </summary>
	public class Classifys : Messages
	{
		public Classifys()
		{}
		/// <summary>
		/// ���������;���ࡣ
		/// </summary>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyAll()
		{
			ClassifyData myDS = new ClassifyData ();

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_ClassifyGetAll", myDS.Tables [ClassifyData.CLASSFIY_TABLE]))
			{
				this.Message = ClassifyData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ������Ч����;���ࡣ
		/// </summary>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyAvalible()
		{
			ClassifyData myDS = new ClassifyData();

			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Sto_ClassifyGetAvalible", myDS.Tables [ClassifyData.CLASSFIY_TABLE]))
			{
				this.Message = ClassifyData.QUERY_FAILED;
			}
			return myDS;
		}
        public ClassifyData GetClassifyAvalibleWithNull()
        {
            var ds = this.GetClassifyAvalible();
            var row = ds.Tables[0].NewRow();
            row[ClassifyData.OLDCODE_FIELD] = "-1";
            row[ClassifyData.CODE_FIELD] = "-1";
            row[ClassifyData.DESCRIPTION_FIELD] = "��";
            ds.Tables[0].Rows.InsertAt(row,0);
            return ds;

        }

        public ClassifyData GetClassifyQuery()
        {
            ClassifyData myDS = new ClassifyData();

            SQLServer mySP = new SQLServer();
            if (!mySP.ExecSPReturnDS("Sto_ClassifyQuery", myDS.Tables[ClassifyData.CLASSFIY_TABLE]))
            {
                this.Message = ClassifyData.QUERY_FAILED;
            }
            return myDS;
        }
		/// <summary>
		/// ��ȡ��������ʹ�õ���;���ࡣ
		/// ��ָ������������;���ݵġ�
		/// </summary>
		/// <returns>ClassifyData:	��;��������ʵ��.</returns>
		public ClassifyData GetClassifyInUsing()
		{
			ClassifyData myDS = new ClassifyData();
			SQLServer mySP = new SQLServer();
			if (!@mySP.ExecSPReturnDS("Sto_ClassifyGetInUsing", myDS.Tables[ClassifyData.CLASSFIY_TABLE]))
			{
				this.Message = ClassifyData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ������;��������;������Ϣ��
		/// </summary>
		/// <param name="Code">string:	��;���롣</param>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			ClassifyData myDS = new ClassifyData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_ClassifyGetByCode", myHT, myDS.Tables [ClassifyData.CLASSFIY_TABLE]))
			{
				this.Message = ClassifyData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ��;����ĸ�����;���ࡣ
		/// </summary>
		/// <param name="Code">string:	��;������롣</param>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetParentClassifyByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			ClassifyData myDS = new ClassifyData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_ClassifyGetParentByCode", myHT, myDS.Tables [ClassifyData.CLASSFIY_TABLE]))
			{
				this.Message = ClassifyData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ������;�������Ʋ�����;��Ϣ��
		/// </summary>
		/// <param name="Description">string:	��;�������ơ�</param>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			ClassifyData myDS = new ClassifyData ();

			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_ClassifyGetByDescription", myHT, myDS.Tables [ClassifyData.CLASSFIY_TABLE]))
			{
				this.Message = ClassifyData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��;�������ӡ�
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	��;��������ʵ�塣</param>
		/// <returns>bool:	���ӳɹ�����true,ʧ�ܷ���false.</returns>
		public bool Add(ClassifyData myClassifyData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@ParentID",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.PARENT_CODE_FIELD].ToString());
			myHT.Add ("@Enable",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.ENABLE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_ClassifyInsert",myHT))
			{
				this.Message = ClassifyData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = ClassifyData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// ��;�����޸ġ�
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	��;��������ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(ClassifyData myClassifyData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@OldCode",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.OLDCODE_FIELD].ToString());
			myHT.Add ("@Code",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@ParentID",myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.PARENT_CODE_FIELD].ToString());
			myHT.Add ("@Enable",int.Parse(myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.ENABLE_FIELD].ToString()));
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_ClassifyUpdate",myHT))
			{
				this.Message = ClassifyData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = ClassifyData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ��;����ɾ����
		/// </summary>
		/// <param name="myStoData">ClassifyData:	��;��������ʵ�塣</param>
		/// <returns>bool:	ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(ClassifyData myClassifyData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@Code", myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_ClassifyDelete",myHT))
			{
				this.Message = ClassifyData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = ClassifyData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ���ݴ������;������봮����ɾ����
		/// </summary>
		/// <param name="Codes">string:	��;��������ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable();
			myHT.Add("@Codes",Codes);
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_ClassifyDeleteByCodes",myHT))
			{
				this.Message = ClassifyData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = ClassifyData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
	}
}
