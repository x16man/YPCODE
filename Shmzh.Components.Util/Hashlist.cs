using System;
using System.Collections;

namespace Shmzh.Components.Util
{
	/// <summary>
	/// 融合了ArrayList和Hashtable特性的一个合成对象。
	/// 拥有了ArrayList的根据索引取得元素，以及拥有了
	/// Hashtabel的根据键取得元素的功能。它就像是一个
	/// 排序的List,但是又不需要对元素进行排序，元素的
	/// 顺序还是按照插入的顺序排列。
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
		/// ArrayList成员。
		/// 包含所有键。
		/// </summary>
		protected ArrayList m_oKeys = new ArrayList();
		/// <summary>
		/// Hashtable成员。
		/// </summary>
		protected Hashtable m_oValues = new Hashtable();		

		#region ICollection implementation
		//ICollection implementation
		/// <summary>
		/// 获取包含在Shmzh.Components.Util.Hashlist中键值对的数目。
		/// </summary>
		public int Count
		{
			get{return m_oValues.Count;}
		}
		/// <summary>
		/// 获取一个值，该值指示是否同步对Shmzh.Components.Util.Hashlist的访问(线程安全)。
		/// </summary>
		public bool IsSynchronized
		{
			get{return m_oValues.IsSynchronized;}
		}
		/// <summary>
		/// 获取可用于同步对Shmzh.Components.Util.Hashlist的访问的对象。
		/// </summary>
		public object SyncRoot
		{
			get{return m_oValues.SyncRoot;}
		}
		/// <summary>
		/// 将Shmzh.Components.Util.Hashtable元素复制到一维System.Array实例中的指定索引位置。
		/// </summary>
		/// <param name="oArray">System.Array对象。</param>
		/// <param name="iArrayIndex">int:	索引位置。</param>
		public void CopyTo(System.Array oArray, int iArrayIndex)
		{
			m_oValues.CopyTo(oArray, iArrayIndex);
		}
		#endregion

		#region IDictionary implementation
		//IDictionary implementation
		/// <summary>
		/// 将对象添加到Shmzh.Components.Util.Hashlist中。
		/// </summary>
		/// <param name="oKey">object:	键。</param>
		/// <param name="oValue">object:	值。</param>
		public void Add(object oKey, object oValue)
		{
			m_oKeys.Add(oKey);
			m_oValues.Add(oKey, oValue);
		}
		/// <summary>
		/// 获取一个值，该值指示Shmzh.Components.Util.Hashlist是否具有固定大小。
		/// </summary>
		public bool IsFixedSize
		{
			get{return m_oKeys.IsFixedSize;}
		}
		/// <summary>
		/// 获取一个值，该值指示Shmzh.Components.Util.Hashlist是否为只读。
		/// </summary>
		public bool IsReadOnly
		{
			get{return m_oKeys.IsReadOnly;}
		}
		/// <summary>
		/// 获取包含Shmzh.Components.Util.Hashlist中的键的System.Collections.ICollection。
		/// </summary>
		public ICollection Keys
		{
			get{return m_oValues.Keys;}
		}
		/// <summary>
		/// 从Shmzh.Components.Util.Hashlist中移除所有元素。
		/// </summary>
		public void Clear()
		{
			m_oValues.Clear();
			m_oKeys.Clear();
		}
		/// <summary>
		/// 确定Shmzh.Components.Util.Hashlist中是否包含特定键。
		/// </summary>
		/// <param name="oKey">object:	特定键。</param>
		/// <returns>bool:	如果包含特定键返回true，不包含返回false。</returns>
		public bool Contains(object oKey)
		{
			return m_oValues.Contains(oKey);
		}
		/// <summary>
		/// 确定Shmzh.Components.Util.Hashlist中是否包含特定键。  此方法的行为与 Contains 完全一样。
		/// </summary>
		/// <param name="oKey">object:	特定键。</param>
		/// <returns>bool:	如果包含特定键返回true，不包含返回false。</returns>
		public bool ContainsKey(object oKey)
		{
			return m_oValues.ContainsKey(oKey);
		}
		/// <summary>
		/// 返回可循环访问Shmzh.Components.Util.Hashlist的System.Collections.IDictionaryEnumerator。
		/// </summary>
		/// <returns>interface System.Collection.IDictionaryEnumerator 枚举字典的元素。</returns>
		public IDictionaryEnumerator GetEnumerator()
		{
			return m_oValues.GetEnumerator();
		}	
		/// <summary>
		/// 从Shmzh.Components.Util.Hashlist中移除带有指定键的元素。
		/// </summary>
		/// <param name="oKey">object:	指定键。</param>
		public void Remove(object oKey)
		{
			m_oValues.Remove(oKey);
			m_oKeys.Remove(oKey);
		}
		/// <summary>
		/// Shmzh.Components.Util.Hashlist成员。
		/// </summary>
		public object this[object oKey]
		{
			get{return m_oValues[oKey];}
			set{m_oValues[oKey] = value;}
		}
		/// <summary>
		///	 获取包含在Shmzh.Components.Util.Hashlist中的值的System.Collections.ICollection。
		/// </summary>
		public ICollection Values
		{
			get{return m_oValues.Values;}
		}
		#endregion

		#region IEnumerable implementation
		/// <summary>
		/// 返回可循环访问Shmzh.Components.Util.Hashlist的System.Collections.IEnumerator。
		/// </summary>
		/// <returns>interface System.Collections.IEnumerator 支持在集合上进行简单迭代。</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_oValues.GetEnumerator();
		}
		#endregion
		
		#region Hashlist specialized implementation
		//特定索引器程序。
		/// <summary>
		/// 根据键来访问Shmzh.Components.Util.Hashlist中的元素。
		/// </summary>
		public object this[string Key]
		{
			get{return m_oValues[Key];}
		}
		/// <summary>
		/// 根据索引来访问Shmzh.Components.Util.Hashlist中的元素。
		/// </summary>
		public object this[int Index]
		{
			get{return m_oValues[m_oKeys[Index]];}
		}
		#endregion
	
	}
}
