using System;
using System.Collections;

namespace Shmzh.Components.Util
{
	/// <summary>
	/// �ں���ArrayList��Hashtable���Ե�һ���ϳɶ���
	/// ӵ����ArrayList�ĸ�������ȡ��Ԫ�أ��Լ�ӵ����
	/// Hashtabel�ĸ��ݼ�ȡ��Ԫ�صĹ��ܡ���������һ��
	/// �����List,�����ֲ���Ҫ��Ԫ�ؽ�������Ԫ�ص�
	/// ˳���ǰ��ղ����˳�����С�
	/// </summary>
	public abstract class Hashlist : IDictionary, IEnumerable
	{
		//ArrayList that contains all the keys 
		//as they are inserted, the index is associated with
		//a key so when pulling out values by index
		//we can get the key for the index, pull from the 
		//hashtable the proper value with the corresponding 
		//key
		//This is basically the same as a sorted list but
		//does not sort the items, rather it leaves them in the
		//order they were inserted - like a list

		/// <summary>
		/// ArrayList��Ա��
		/// �������м���
		/// </summary>
		protected ArrayList m_oKeys = new ArrayList();
		/// <summary>
		/// Hashtable��Ա��
		/// </summary>
		protected Hashtable m_oValues = new Hashtable();		

		#region ICollection implementation
		//ICollection implementation
		/// <summary>
		/// ��ȡ������Shmzh.Components.Util.Hashlist�м�ֵ�Ե���Ŀ��
		/// </summary>
		public int Count
		{
			get{return m_oValues.Count;}
		}
		/// <summary>
		/// ��ȡһ��ֵ����ֵָʾ�Ƿ�ͬ����Shmzh.Components.Util.Hashlist�ķ���(�̰߳�ȫ)��
		/// </summary>
		public bool IsSynchronized
		{
			get{return m_oValues.IsSynchronized;}
		}
		/// <summary>
		/// ��ȡ������ͬ����Shmzh.Components.Util.Hashlist�ķ��ʵĶ���
		/// </summary>
		public object SyncRoot
		{
			get{return m_oValues.SyncRoot;}
		}
		/// <summary>
		/// ��Shmzh.Components.Util.HashtableԪ�ظ��Ƶ�һάSystem.Arrayʵ���е�ָ������λ�á�
		/// </summary>
		/// <param name="oArray">System.Array����</param>
		/// <param name="iArrayIndex">int:	����λ�á�</param>
		public void CopyTo(System.Array oArray, int iArrayIndex)
		{
			m_oValues.CopyTo(oArray, iArrayIndex);
		}
		#endregion

		#region IDictionary implementation
		//IDictionary implementation
		/// <summary>
		/// ��������ӵ�Shmzh.Components.Util.Hashlist�С�
		/// </summary>
		/// <param name="oKey">object:	����</param>
		/// <param name="oValue">object:	ֵ��</param>
		public void Add(object oKey, object oValue)
		{
			m_oKeys.Add(oKey);
			m_oValues.Add(oKey, oValue);
		}
		/// <summary>
		/// ��ȡһ��ֵ����ֵָʾShmzh.Components.Util.Hashlist�Ƿ���й̶���С��
		/// </summary>
		public bool IsFixedSize
		{
			get{return m_oKeys.IsFixedSize;}
		}
		/// <summary>
		/// ��ȡһ��ֵ����ֵָʾShmzh.Components.Util.Hashlist�Ƿ�Ϊֻ����
		/// </summary>
		public bool IsReadOnly
		{
			get{return m_oKeys.IsReadOnly;}
		}
		/// <summary>
		/// ��ȡ����Shmzh.Components.Util.Hashlist�еļ���System.Collections.ICollection��
		/// </summary>
		public ICollection Keys
		{
			get{return m_oValues.Keys;}
		}
		/// <summary>
		/// ��Shmzh.Components.Util.Hashlist���Ƴ�����Ԫ�ء�
		/// </summary>
		public void Clear()
		{
			m_oValues.Clear();
			m_oKeys.Clear();
		}
		/// <summary>
		/// ȷ��Shmzh.Components.Util.Hashlist���Ƿ�����ض�����
		/// </summary>
		/// <param name="oKey">object:	�ض�����</param>
		/// <returns>bool:	��������ض�������true������������false��</returns>
		public bool Contains(object oKey)
		{
			return m_oValues.Contains(oKey);
		}
		/// <summary>
		/// ȷ��Shmzh.Components.Util.Hashlist���Ƿ�����ض�����  �˷�������Ϊ�� Contains ��ȫһ����
		/// </summary>
		/// <param name="oKey">object:	�ض�����</param>
		/// <returns>bool:	��������ض�������true������������false��</returns>
		public bool ContainsKey(object oKey)
		{
			return m_oValues.ContainsKey(oKey);
		}
		/// <summary>
		/// ���ؿ�ѭ������Shmzh.Components.Util.Hashlist��System.Collections.IDictionaryEnumerator��
		/// </summary>
		/// <returns>interface System.Collection.IDictionaryEnumerator ö���ֵ��Ԫ�ء�</returns>
		public IDictionaryEnumerator GetEnumerator()
		{
			return m_oValues.GetEnumerator();
		}	
		/// <summary>
		/// ��Shmzh.Components.Util.Hashlist���Ƴ�����ָ������Ԫ�ء�
		/// </summary>
		/// <param name="oKey">object:	ָ������</param>
		public void Remove(object oKey)
		{
			m_oValues.Remove(oKey);
			m_oKeys.Remove(oKey);
		}
		/// <summary>
		/// Shmzh.Components.Util.Hashlist��Ա��
		/// </summary>
		public object this[object oKey]
		{
			get{return m_oValues[oKey];}
			set{m_oValues[oKey] = value;}
		}
		/// <summary>
		///	 ��ȡ������Shmzh.Components.Util.Hashlist�е�ֵ��System.Collections.ICollection��
		/// </summary>
		public ICollection Values
		{
			get{return m_oValues.Values;}
		}
		#endregion

		#region IEnumerable implementation
		/// <summary>
		/// ���ؿ�ѭ������Shmzh.Components.Util.Hashlist��System.Collections.IEnumerator��
		/// </summary>
		/// <returns>interface System.Collections.IEnumerator ֧���ڼ����Ͻ��м򵥵�����</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_oValues.GetEnumerator();
		}
		#endregion
		
		#region Hashlist specialized implementation
		//�ض�����������
		/// <summary>
		/// ���ݼ�������Shmzh.Components.Util.Hashlist�е�Ԫ�ء�
		/// </summary>
		public object this[string Key]
		{
			get{return m_oValues[Key];}
		}
		/// <summary>
		/// ��������������Shmzh.Components.Util.Hashlist�е�Ԫ�ء�
		/// </summary>
		public object this[int Index]
		{
			get{return m_oValues[m_oKeys[Index]];}
		}
		#endregion
	
	}
}
