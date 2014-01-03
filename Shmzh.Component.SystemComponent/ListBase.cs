using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 自定义集合类。
    /// </summary>
    /// <typeparam name="T">泛型类型。</typeparam>
    [Serializable]
    public class ListBase<T> : List<T>
    {
        #region Field

        // Sorting
        [NonSerialized]
        private PropertyDescriptor _sortProperty = null;
        private ListSortDirection _sortDirection = ListSortDirection.Descending;
        [NonSerialized]
        ListSortDescriptionCollection _sortDescriptions = new ListSortDescriptionCollection();
        /// <summary>
        /// 属性集合。
        /// </summary>
        [NonSerialized]
        private PropertyDescriptorCollection _propertyCollection;

        private string _listName;
        #endregion

        #region CTOR
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ListBase()
        {
            InitializeList();
        }

        /// <summary>
        /// Initialize any member variables when the list is created
        /// </summary>
        private void InitializeList()
        {
            // save the bindable properties in a local field
            _propertyCollection = EntityHelper.GetBindableProperties(typeof(T));

            // save the name of the type for use in the IDE GUI
            _listName = typeof(T).Name;
        }
        #endregion

        #region Find
        ///<summary>
        ///</summary>
        ///<param name="match"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public new ListBase<T> FindAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match");
            }

            var result = new ListBase<T>();
            foreach (T item in this)
            {
                if (match(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        #endregion

        #region Sorting
        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected  ListSortDirection SortDirectionCore
        {
            get
            {
                return _sortDirection;
            }
        }

        /// <summary>
        /// Gets the property descriptor that is used for sorting
        /// </summary>
        /// <returns>The <see cref="PropertyDescriptor"/> used for sorting the list.</returns>
        protected  PropertyDescriptor SortPropertyCore
        {
            get
            {
                return _sortProperty;
            }
        }

        ///<summary>
        /// Sorts the data source based on a <see cref="PropertyDescriptor">PropertyDescriptor</see> and a <see cref="ListSortDirection">ListSortDirection</see>.
        ///</summary>
        ///<param name="property">The <see cref="PropertyDescriptor"/> to sort the collection by.</param>
        ///<param name="direction">The <see cref="ListSortDirection"/> in which to sort the collection.</param>
        public void Sort(PropertyDescriptor property, ListSortDirection direction)
        {
            var comparer = new SortComparer<T>(property, direction);
            this.Sort(comparer);
        }
        /// <summary>
        /// 根据排序描述集合来进行排序。
        /// </summary>
        /// <param name="sorts">排序描述集合。</param>
        public void Sort(ListSortDescriptionCollection sorts)
        {
            var comparer = new SortComparer<T>(sorts);
            this.Sort(comparer);
        }
        /// <summary>
        /// Sorts the elements in the entire list using the specified Order By statement.
        /// </summary>
        /// <param name="orderBy">SQL-like string representing the properties to sort the list by.</param>
        /// <remarks><i>orderBy</i> should be in the following format: 
        /// <para>PropertyName[[ [[ASC]|DESC]][, PropertyName[ [[ASC]|DESC]][,...]]]</para></remarks>
        /// <example><c>list.Sort("Property1, Property2 DESC, Property3 ASC");</c></example>
        public void Sort(string orderBy)
        {
            var sortComparer = new SortComparer<T>(orderBy);
            this.Sort(sortComparer.Compare);
        }
        /// <summary>
        /// 自动排序方法。
        /// </summary>
        /// <param name="orderBy">排序语句。</param>
        public void AutoSort(string orderBy)
        {
            var sortComparer = new SortComparer<T>(orderBy);
            this.Sort(sortComparer.Compare);
        }
        #endregion

    }

    #region Sort Comparer
    /// <summary>
    /// Generic Sort comparer for the <see cref="ListBase{T}"/> class.
    /// </summary>
    /// <typeparam name="T">Type of object to sort.</typeparam>
    public class SortComparer<T> : IComparer<T>
    {
        /// <summary>
        /// Collection of properties to sort by.
        /// </summary>
        private ListSortDescriptionCollection m_SortCollection;

        /// <summary>
        /// Property to sort by.
        /// </summary>
        private PropertyDescriptor m_PropDesc;

        /// <summary>
        /// Direction to sort by
        /// </summary>
        private ListSortDirection m_Direction = ListSortDirection.Ascending;

        /// <summary>
        /// Collection of properties for T.
        /// </summary>
        private PropertyDescriptorCollection m_PropertyDescriptors;

        /// <summary>
        /// Create a new instance of the SortComparer class.
        /// </summary>
        /// <param name="propDesc">The <see cref="PropertyDescriptor"/> to sort by.</param>
        /// <param name="direction">The <see cref="ListSortDirection"/> to sort the list.</param>
        public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
        {
            Initialize();
            m_PropDesc = propDesc;
            m_Direction = direction;
        }

        /// <summary>
        /// Create a new instance of the SortComparer class.
        /// </summary>
        /// <param name="sortCollection">A <see cref="ListSortDescriptionCollection"/> containing the properties to sort the list by.</param>
        public SortComparer(ListSortDescriptionCollection sortCollection)
        {
            Initialize();
            m_SortCollection = sortCollection;
        }

        /// <summary>
        /// Create a new instance of the SortComparer class.
        /// </summary>
        /// <param name="orderBy">SQL-like string representing the properties to sort the list by.</param>
        /// <remarks><i>orderBy</i> should be in the following format: 
        /// <para>PropertyName[[ [[ASC]|DESC]][, PropertyName[ [[ASC]|DESC]][,...]]]</para></remarks>
        /// <example><c>list.Sort("Property1, Property2 DESC, Property3 ASC");</c></example>
        public SortComparer(string orderBy)
        {
            Initialize();
            m_SortCollection = ParseOrderBy(orderBy);
        }

        #region IComparer<T> Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>Value is less than zero: <c>x</c> is less than <c>y</c>
        /// <para>Value is equal to zero: <c>x</c> equals <c>y</c></para>
        /// <para>Value is greater than zero: <c>x</c> is greater than <c>y</c></para>
        /// </returns>
        public int Compare(T x, T y)
        {
            if (m_PropDesc != null) // Simple sort 
            {
                var xValue = m_PropDesc.GetValue(x);
                var yValue = m_PropDesc.GetValue(y);
                return CompareValues(xValue, yValue, m_Direction);
            }
            if (m_SortCollection != null && m_SortCollection.Count > 0)
            {
                return RecursiveCompareInternal(x, y, 0);
            }
            return 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Compare two objects
        /// </summary>
        /// <param name="xValue">The first object to compare</param>
        /// <param name="yValue">The second object to compare</param>
        /// <param name="direction">The direction to sort the objects in</param>
        /// <returns>Returns an integer representing the order of the objects</returns>
        private int CompareValues(object xValue, object yValue, ListSortDirection direction)
        {

            int retValue = 0;
            if (xValue != null && yValue == null)
            {
                retValue = 1;
            }
            else if (xValue == null && yValue != null)
            {
                retValue = -1;
            }
            else if (xValue == null && yValue == null)
            {
                retValue = 0;
            }
            else if (xValue is IComparable) // Can ask the x value
            {
                retValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (yValue is IComparable) //Can ask the y value
            {
                retValue = ((IComparable)yValue).CompareTo(xValue);
            }
            else if (!xValue.Equals(yValue)) // not comparable, compare String representations
            {
                retValue = xValue.ToString().CompareTo(yValue.ToString());
            }
            if (direction == ListSortDirection.Ascending)
            {
                return retValue;
            }
            return retValue * -1;
        }

        private int RecursiveCompareInternal(T x, T y, int index)
        {
            if (index >= m_SortCollection.Count)
                return 0; // termination condition

            ListSortDescription listSortDesc = m_SortCollection[index];
            object xValue = listSortDesc.PropertyDescriptor.GetValue(x);
            object yValue = listSortDesc.PropertyDescriptor.GetValue(y);

            int retValue = CompareValues(xValue, yValue, listSortDesc.SortDirection);
            if (retValue == 0)
            {
                return RecursiveCompareInternal(x, y, ++index);
            }
            return retValue;
        }

        /// <summary>
        /// Parses a string into a <see cref="ListSortDescriptionCollection"/>.
        /// </summary>
        /// <param name="orderBy">SQL-like string of sort properties</param>
        /// <returns></returns>
        private ListSortDescriptionCollection ParseOrderBy(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                throw new ArgumentNullException("orderBy");

            var props = orderBy.Split(',');
            var sortProps = new ListSortDescription[props.Length];
            string prop;
            var sortDirection = ListSortDirection.Ascending;

            for (var i = 0; i < props.Length; i++)
            {
                //Default to Ascending
                sortDirection = ListSortDirection.Ascending;
                prop = props[i].Trim();

                if (prop.ToUpper().EndsWith(" DESC"))
                {
                    sortDirection = ListSortDirection.Descending;
                    prop = prop.Substring(0, prop.ToUpper().LastIndexOf(" DESC"));
                }
                else if (prop.ToUpper().EndsWith(" ASC"))
                {
                    prop = prop.Substring(0, prop.ToUpper().LastIndexOf(" ASC"));
                }

                prop = prop.Trim();

                //Get the appropriate descriptor
                PropertyDescriptor propertyDescriptor = m_PropertyDescriptors[prop];

                if (propertyDescriptor == null)
                {
                    throw new ArgumentException(string.Format("The property \"{0}\" is not a valid property.", prop));
                }
                sortProps[i] = new ListSortDescription(propertyDescriptor, sortDirection);

            }

            return new ListSortDescriptionCollection(sortProps);
        }

        /// <summary>
        /// Initializes the SortComparer object
        /// </summary>
        private void Initialize()
        {
            Type instanceType = typeof(T);

            if (!instanceType.IsPublic)
                throw new ArgumentException(string.Format("Type \"{0}\" is not public.", typeof(T).FullName));

            m_PropertyDescriptors = TypeDescriptor.GetProperties(typeof(T));

        }

        #endregion
    }
    #endregion
}
