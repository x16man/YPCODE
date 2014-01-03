namespace Shmzh.Components.Util
{
	using System;
	/// <summary>
	/// Factor ��ժҪ˵����
	/// </summary>
	public class Factor
	{

		/// <summary>
		/// �չ��캯����
		/// </summary>
		public Factor()
		{
			//
			// 
			//
		}
		/// <summary>
		/// ȷ��һ�������Ƿ���һ��������
		/// </summary>
		/// <param name="n">int:	�ض�ֵ��</param>
		/// <returns>bool:	����������򷵻�true�����򷵻�false��</returns>
		public static bool IsPrime(int n)
		{
			for(int i=2; i<=Math.Sqrt(n); i++)
				if(n%i == 0)
					return false;

			return true;
		}
		/// <summary>
		/// �ݹ���׳�.
		/// </summary>
		/// <param name="n">long:	ָ����ֵ��</param>
		/// <returns>long:	�׳�ֵ��</returns>
		public static long Factorial(long n)
		{
			if(n == 1)
				return 1;
			else
				return n * Factorial(n-1);
		}
	}
}
