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
	/// 用途的数据访问层。
	/// </summary>
	public class Classifys : Messages
	{
		public Classifys()
		{}
		/// <summary>
		/// 获得所有用途分类。
		/// </summary>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
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
		/// 获取所有有效的用途分类。
		/// </summary>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
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
            row[ClassifyData.DESCRIPTION_FIELD] = "空";
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
		/// 获取所有正在使用的用途分类。
		/// 是指分类下面有用途数据的。
		/// </summary>
		/// <returns>ClassifyData:	用途分类数据实体.</returns>
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
		/// 根据用途代码获得用途分类信息。
		/// </summary>
		/// <param name="Code">string:	用途代码。</param>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
		public ClassifyData GetClassifyByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
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
		/// 获取用途分类的父级用途分类。
		/// </summary>
		/// <param name="Code">string:	用途分类代码。</param>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
		public ClassifyData GetParentClassifyByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
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
		/// 根据用途分类名称查找用途信息。
		/// </summary>
		/// <param name="Description">string:	用途分类名称。</param>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
		public ClassifyData GetClassifyByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
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
		/// 用途分类增加。
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	用途分类数据实体。</param>
		/// <returns>bool:	增加成功返回true,失败返回false.</returns>
		public bool Add(ClassifyData myClassifyData)
		{
			bool retValue;
			//存储过程参数的哈希表。
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
		/// 用途分类修改。
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	用途分类数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(ClassifyData myClassifyData)
		{
			bool retValue;
			//存储过程参数的哈希表。
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
		/// 用途分类删除。
		/// </summary>
		/// <param name="myStoData">ClassifyData:	用途分类数据实体。</param>
		/// <returns>bool:	删除成功返回true，失败返回false。</returns>
		public bool Delete(ClassifyData myClassifyData)
		{
			bool retValue;
			//存储过程参数的哈希表。
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
		/// 根据传入的用途分类代码串进行删除。
		/// </summary>
		/// <param name="Codes">string:	用途分类代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			//存储过程参数的哈希表。
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
