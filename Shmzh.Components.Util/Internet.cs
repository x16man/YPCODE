#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: 
**		����: 
**		����: 
**
**              
**		����: �ź�
**		����: 
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ


namespace Shmzh.Components.Util
{
	using System.Runtime.InteropServices;
	/// <summary>
	/// Internet ��ժҪ˵����
	/// </summary>
	public class Internet
	{
		[DllImport("wininet.dll")]
		#region ��Ա����
		//
		//
		//
		#endregion

		#region ����
		//
		//
		//
		#endregion
		
		#region ˽�з���
		private extern static bool InternetGetConnectedState( out int connectionDescription, int reservedValue ) ;
		#endregion

		#region ��������
		/// <summary>
		/// �����Ƿ���ã��������ڹ���������ͨҲ����true��
		/// </summary>
		/// <returns>bool:	���÷���true�������÷���false��</returns>
		public static bool IsConnected()

		{

			int I=0;

			bool state = InternetGetConnectedState(out I,0);

			return state;
		}
    	#endregion

		#region ���캯��
		/// <summary>
		/// �չ��캯����
		/// </summary>
		public Internet()
		{
			//
			// 
			//
		}
		#endregion
	}
}
