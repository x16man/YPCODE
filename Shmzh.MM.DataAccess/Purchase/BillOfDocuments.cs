using System;
using System.Data;
using MZHCommon.Database;
using System.Collections;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// 单据类型类的数据访问层。
	/// 单据类型实体提供了单据的一些公共信息。
	/// 包括：单据类型编号、单据类型名称、单据文档编号、单据的审批级数等。
	/// 详见 <see cref="Common.BillOfDocumentData"/>类。
	/// </summary>
	public class BillOfDocuments:Messages
	{
		/// <summary>
		/// BillOfDocuments的构造函数。
		/// </summary>
		public BillOfDocuments()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 获取指定类型单据的当前可用序列号。
		/// </summary>
		/// <param name="DocCode">int:	单据类型编号。</param>
		/// <returns>int:	下一个单据流水号。</returns>
		/// <remarks>未被引用过。</remarks>
		public int GetNextNoByCode(int DocCode)
		{
			int ret=0;

			BillOfDocumentData oEntry=GetDocByCode(DocCode);
			if (oEntry.Tables[BillOfDocumentData.SBOD_TABLE].Rows.Count>0)
			{
				ret= int.Parse(oEntry.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.NEXTNO_FIELD].ToString());
			}
			return ret;
		}

		/// <summary>
		/// 更新当前指定类型单据的可用序列号。
		/// </summary>
		/// <param name="DocCode">int:	单据类型编号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		/// <remarks>未被引用过。</remarks>
		public bool UpdateNextNoByCode(int DocCode)
		{
			bool ret=true;

			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@DocCode", DocCode);

			if ((new SQLServer()).ExecSP("Sys_DocUpdateNextNo",myHT)==false)
			{
				this.Message="Error,Sys_DocUpdateNextNo,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 获取指定类型单据的单据类型文档实体。
		/// </summary>
		/// <param name="DocCode">int:	单据类型编号。</param>
		/// <returns>BillOfDocumentData:	单据类型文档实体。</returns>
		public BillOfDocumentData GetDocByCode(int DocCode)
		{

			Hashtable myHT = new Hashtable();	//存储过程参数的哈希表。

			BillOfDocumentData oBOD=new BillOfDocumentData();

			myHT.Add ("@DocCode", DocCode);

			if ((new SQLServer()).ExecSPReturnDS("Sys_DocGetDocByCode",myHT,oBOD.Tables[BillOfDocumentData.SBOD_TABLE])==false)
			{
				this.Message="Error,Sys_DocGetDocByCode,Please look the log file!";
			}

			return oBOD;
		}		//End GetDocByCode

	}
}
