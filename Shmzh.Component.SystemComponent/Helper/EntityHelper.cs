using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// This classes contains utilities functions for the instances and collections.
    /// </summary>
    /// <remarks>All methods static</remarks>
    public static class EntityHelper
    {
        #region GetByteLength

        /// <summary>
        /// Gets the byte length of the specified object.
        /// </summary>
        /// <param name="obj">The object we want the length.</param>
        /// <returns>The byte length of the object.</returns>
        public static long GetByteLength(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.Length;
        }

        #endregion

        #region Dynamic ToString Implementation through Reflection
        /// <summary>
        /// Give a string representation of a object, with use of reflection.
        /// </summary>
        /// <param name="o">O.</param>
        /// <returns></returns>
        public static string ToString(Object o)
        {
            StringBuilder sb = new StringBuilder();
            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties();

            sb.Append("Properties for: " + o.GetType().Name + System.Environment.NewLine);
            foreach (PropertyInfo i in pi)
            {
                try
                {
                    sb.Append("\t" + i.Name + "(" + i.PropertyType.ToString() + "): ");
                    if (null != i.GetValue(o, null))
                    {
                        sb.Append(i.GetValue(o, null).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            FieldInfo[] fi = t.GetFields();

            foreach (FieldInfo i in fi)
            {
                try
                {
                    sb.Append("\t" + i.Name + "(" + i.FieldType.ToString() + "): ");
                    if (null != i.GetValue(o))
                    {
                        sb.Append(i.GetValue(o).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            return sb.ToString();
        }
        #endregion

        #region Clone
        /// <summary>
        /// Generic method to perform a deep copy of an object
        /// </summary>
        /// <typeparam name="T">Type of object being cloned and returned</typeparam>
        /// <param name="sourceEntity">Source object to be cloned.</param>
        /// <returns>An object that is a deep copy of the sourceEntity object.</returns>
        public static T Clone<T>(T sourceEntity)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bFormatter.Serialize(stream, sourceEntity);
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            T clone = (T)bFormatter.Deserialize(stream);
            return clone;
        }
        #endregion

        #region GetBindableProperties
        /// <summary>
        /// Get the collection of properties that have been marked as Bindable
        /// </summary>
        /// <param name="type">The type of the object to get the properties for.</param>
        /// <returns><see cref="PropertyDescriptorCollection"/> of bindable properties.</returns>
        public static PropertyDescriptorCollection GetBindableProperties(Type type)
        {
            // create a filter so we only return the properties that have been designated as bindable
            Attribute[] attrs = new Attribute[] { new System.ComponentModel.BindableAttribute(true) };

            //If the type is a generic type (TList or VList), we need to get the properties of the inner type
            if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            // save the bindable properties in a local field
            return TypeDescriptor.GetProperties(type, attrs);
        }
        #endregion

        #region GetEnumTextValue
        ///<summary>
        /// Allows the discovery of an enumeration text value based on the <c>EnumTextValueAttribute</c>
        ///</summary>
        /// <param name="e">The enum to get the reader friendly text value for.</param>
        /// <returns><see cref="System.String"/> </returns>
        public static string GetEnumTextValue(System.Enum e)
        {
            string ret = "";
            Type t = e.GetType();
            MemberInfo[] members = t.GetMember(e.ToString());
            if (members != null && members.Length == 1)
            {
                object[] attrs = members[0].GetCustomAttributes(typeof(EnumTextValueAttribute), false);
                if (attrs.Length == 1)
                {
                    ret = ((EnumTextValueAttribute)attrs[0]).Text;
                }
            }
            return ret;
        }
        #endregion

        #region GetEnumValue
        ///<summary>
        /// Allows the discovery of an enumeration value based on the <c>EnumTextValueAttribute</c>
        ///</summary>
        /// <param name="text">The text of the <c>EnumTextValueAttribute</c>.</param>
        /// <param name="enumType">The type of the enum to get the value for.</param>
        /// <returns><see cref="System.Object"/> boxed representation of the enum value </returns>
        public static object GetEnumValue(string text, Type enumType)
        {
            MemberInfo[] members = enumType.GetMembers();
            foreach (MemberInfo mi in members)
            {
                object[] attrs = mi.GetCustomAttributes(typeof(EnumTextValueAttribute), false);
                if (attrs.Length == 1)
                {
                    if (((EnumTextValueAttribute)attrs[0]).Text == text)
                        return System.Enum.Parse(enumType, mi.Name);
                }
            }
            throw new ArgumentOutOfRangeException("text", text, "The text passed does not correspond to an attributed enum value");
        }
        #endregion

        #region GetAttribute

        /// <summary>
        /// Gets the first occurrence of the specified type of <see cref="System.Attribute"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(System.Enum e) where T : System.Attribute
        {
            T attribute = default(T);
            Type enumType = e.GetType();
            System.Reflection.MemberInfo[] members = enumType.GetMember(e.ToString());

            if (members != null && members.Length == 1)
            {
                object[] attrs = members[0].GetCustomAttributes(typeof(T), false);
                if (attrs.Length > 0)
                {
                    attribute = (T)attrs[0];
                }
            }

            return attribute;
        }

        #endregion GetAttribute

        #region Pascal to spaced helper
        /// <summary>
        /// Get the Pascal spaced version of a name.  
        /// </summary>
        /// <param name="name">Name to be changed</param>
        /// <returns>PascalSpaced version of the name</returns>
        public static string GetPascalSpacedName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            Regex regex = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
            return regex.Replace(name, " ${x}");

        }
        #endregion

    }

    #region EnumTextValue
    ///<summary>
    /// Attribute used to decorate enumerations with reader friendly names
    ///</summary>
    public sealed class EnumTextValueAttribute : System.Attribute
    {
        private readonly string enumTextValue;

        ///<summary>
        /// Returns the text representation of the value
        ///</summary>
        public string Text
        {
            get
            {
                return enumTextValue;
            }
        }

        ///<summary>
        /// Allows the creation of a friendly text representation of the enumeration.
        ///</summary>
        /// <param name="text">The reader friendly text to decorate the enum.</param>
        public EnumTextValueAttribute(string text)
        {
            enumTextValue = text;
        }
    }
    #endregion

    #region ColumnEnumAttribute

    /// <summary>
    /// Provides column metadata information for an entity column enumeration.
    /// </summary>
    public sealed class ColumnEnumAttribute : System.Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ColumnEnumAttribute class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="systemType"></param>
        /// <param name="dbType"></param>
        /// <param name="isPrimaryKey"></param>
        /// <param name="isIdentity"></param>
        /// <param name="allowDbNull"></param>
        /// <param name="length"></param>
        public ColumnEnumAttribute(String name, Type systemType, System.Data.DbType dbType, bool isPrimaryKey, bool isIdentity, bool allowDbNull, int length)
        {
            this.Name = name;
            this.SystemType = systemType;
            this.DbType = dbType;
            this.IsPrimaryKey = isPrimaryKey;
            this.IsIdentity = isIdentity;
            this.AllowDbNull = allowDbNull;
            this.Length = length;
        }

        /// <summary>
        /// Initializes a new instance of the ColumnEnumAttribute class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="systemType"></param>
        /// <param name="dbType"></param>
        /// <param name="isPrimaryKey"></param>
        /// <param name="isIdentity"></param>
        /// <param name="allowDbNull"></param>
        public ColumnEnumAttribute(String name, Type systemType, System.Data.DbType dbType, bool isPrimaryKey, bool isIdentity, bool allowDbNull)
            : this(name, systemType, dbType, isPrimaryKey, isIdentity, allowDbNull, -1)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The Name member variable.
        /// </summary>
        private String name;

        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// The SystemType member variable.
        /// </summary>
        private Type systemType;

        /// <summary>
        /// Gets or sets the SystemType property.
        /// </summary>
        public Type SystemType
        {
            get { return systemType; }
            set { systemType = value; }
        }

        /// <summary>
        /// The DbType member variable.
        /// </summary>
        private System.Data.DbType dbType;

        /// <summary>
        /// Gets or sets the DbType property.
        /// </summary>
        public System.Data.DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        /// <summary>
        /// The IsPrimaryKey member variable.
        /// </summary>
        private bool isPrimaryKey;

        /// <summary>
        /// Gets or sets the IsPrimaryKey property.
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return isPrimaryKey; }
            set { isPrimaryKey = value; }
        }

        /// <summary>
        /// The IsIdentity member variable.
        /// </summary>
        private bool isIdentity;

        /// <summary>
        /// Gets or sets the IsIdentity property.
        /// </summary>
        public bool IsIdentity
        {
            get { return isIdentity; }
            set { isIdentity = value; }
        }

        /// <summary>
        /// The AllowDbNull member variable.
        /// </summary>
        private bool allowDbNull;

        /// <summary>
        /// Gets or sets the AllowDbNull property.
        /// </summary>
        public bool AllowDbNull
        {
            get { return allowDbNull; }
            set { allowDbNull = value; }
        }

        /// <summary>
        /// The Length member variable.
        /// </summary>
        private int length;

        /// <summary>
        /// Gets or sets the Length property.
        /// </summary>
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        #endregion Properties
    }

    #endregion ColumnEnumAttribute

    #region GenericStateChangedEventArgs
    /// <summary>
    /// Provides a generic way to inform interested objects about state change
    /// Supplies the old value and the new value of the changed state.
    /// </summary>
    /// <typeparam name="T">State Object</typeparam>
    public class GenericStateChangedEventArgs<T> : EventArgs
    {
        private T oldValue;
        private T newValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericStateChangedEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public GenericStateChangedEventArgs(T oldValue, T newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        /// <summary>
        /// Gets the old value.
        /// </summary>
        /// <value>The old value.</value>
        public T OldValue { get { return oldValue; } }

        /// <summary>
        /// Gets the new value.
        /// </summary>
        /// <value>The new value.</value>
        public T NewValue { get { return newValue; } }
    }
    #endregion

}
