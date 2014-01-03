namespace Shmzh.Components.Util
{
	using System;
	/// <summary>
	/// Factor 的摘要说明。
	/// </summary>
	public class Factor
	{

		/// <summary>
		/// 空构造函数。
		/// </summary>
		public Factor()
		{
			//
			// 
			//
		}
		/// <summary>
		/// 确定一个整数是否是一个质数。
		/// </summary>
		/// <param name="n">int:	特定值。</param>
		/// <returns>bool:	如果是质数则返回true，否则返回false。</returns>
		public static bool IsPrime(int n)
		{
			for(int i=2; i<=Math.Sqrt(n); i++)
				if(n%i == 0)
					return false;

			return true;
		}
		/// <summary>
		/// 递归求阶乘.
		/// </summary>
		/// <param name="n">long:	指定的值。</param>
		/// <returns>long:	阶乘值。</returns>
		public static long Factorial(long n)
		{
			if(n == 1)
				return 1;
			else
				return n * Factorial(n-1);
		}
	}
}
