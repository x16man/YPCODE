/**
 * AMS.Profile Class Library
 * 
 * Written by Alvaro Mendez
 * Copyright (c) 2004. All Rights Reserved.
 * 
 * The AMS.Profile namespace contains interfaces and classes that 
 * allow reading and writing of user-profile data.
 * This file contains the Xml class.
 * 
 * The code is thoroughly documented, however, if you have any questions, 
 * feel free to email me at alvaromendez@consultant.com.  Also, if you 
 * decide to this in a commercial application I would appreciate an email 
 * message letting me know.
 *
 * This code may be used in compiled form in any way you desire. This
 * file may be redistributed unmodified by any means providing it is 
 * not sold for profit without the authors written consent, and 
 * providing that this notice and the authors name and all copyright 
 * notices remains intact. This file and the accompanying source code 
 * may not be hosted on a website or bulletin board without the author's 
 * written permission.
 * 
 * This file is provided "as is" with no expressed or implied warranty.
 * The author accepts no liability for any damage/loss of business that
 * this product may cause.
 *
 * Last Updated: Mar. 15, 2004
 */


using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections;
using System.Reflection;


namespace MZHCommon.Profile
{
	/// <summary>
	///   Profile class that utilizes an XML file to retrieve and save its data. </summary>
	/// <remarks>
	///   This class works with XML files, which are text files that store their data using XML. 
	///   Since the format of XML is very flexible, I had to decide how to best organize the data
	///   using the section/entry paradigm.  After considering a couple of possibilities, 
	///   I decided that the format below would be preferrable, since it allows section and 
	///   entry names to contain spaces.  It also looks cleaner and more consistent than if I had
	///   used the section and entry names themselves to name the elements.
	///   <para>
	///   Here's an illustration of the format: </para>
	///   <code>
	///   &lt;?xml version="1.0" encoding="utf-8"?&gt;
	///   &lt;profile&gt;
	///     &lt;section name="A Section"&gt;
	///       &lt;entry name="An Entry"&gt;Some Value&lt;/entry&gt;
	///       &lt;entry name="Another Entry"&gt;Another Value&lt;/entry&gt;
	///     &lt;/section&gt;
	///     &lt;section name="Another Section"&gt;
	///       &lt;entry name="This is cool"&gt;True&lt;/entry&gt;
	///     &lt;/section&gt;
	///   &lt;/profile&gt;
	///   </code></remarks>
	public class Xml : Profile
	{
		// Fields
		private string m_rootName = "profile";
		private Encoding m_encoding = Encoding.UTF8;

		/// <summary>
		///   Initializes a new instance of the Xml class by setting the <see cref="Profile.Name" /> to <see cref="Profile.DefaultName" />. </summary>
		public Xml()
		{
		}

		/// <summary>
		///   Initializes a new instance of the Xml class by setting the <see cref="Profile.Name" /> to the given file name. </summary>
		/// <param name="fileName">
		///   The name of the XML file to initialize the <see cref="Profile.Name" /> property with. </param>
		public Xml(string fileName) :
			base(fileName)
		{
		}

		/// <summary>
		///   Initializes a new instance of the Xml class based on another Xml object. </summary>
		/// <param name="xml">
		///   The Xml object whose properties and events are used to initialize the object being constructed. </param>
		public Xml(Xml xml) :
			base(xml)
		{
			m_rootName = xml.m_rootName;
		}

		/// <summary>
		///   Gets the default name for the XML file. </summary>
		/// <remarks>
		///   This returns the name of the executable plus .xml ("program.exe.xml").
		///   This property is used to set the <see cref="Profile.Name" /> property inside the default constructor.</remarks>
		public override string DefaultName
		{
			get
			{
				return ProgramExe + ".xml";
			}
		}

		/// <summary>
		///   Retrieves a copy of itself. </summary>
		/// <returns>
		///   The return value is a copy of itself as an object. </returns>
		/// <seealso cref="Profile.CloneReadOnly" />
		public override object Clone()
		{
			return new Xml(this);
		}

		/// <summary>
		///   Retrieves an XMLDocument object based on the XML file (Name). </summary>
		/// <returns>
		///   The return value is the XMLDocument object based on the file, 
		///   or null if the file does not exist. </returns>
		private XmlDocument GetXmlDocument()
		{
			VerifyName();

			if (!File.Exists(Name))
				return null;

			XmlDocument doc = new XmlDocument();
    		doc.Load(Name);
						
			return doc;
		}

		/// <summary>
		///   Retrieves the XPath string used for retrieving a section from the XML file. </summary>
		/// <returns>
		///   An XPath string. </returns>
		/// <seealso cref="GetEntryPath" />
		private string GetSectionsPath(string section)
		{
			return "section[@name=\"" + section + "\"]";
		}
		                              
		/// <summary>
		///   Retrieves the XPath string used for retrieving an entry from the XML file. </summary>
		/// <returns>
		///   An XPath string. </returns>
		/// <seealso cref="GetSectionsPath" />
		private string GetEntryPath(string entry)
		{
			return "entry[@name=\"" + entry + "\"]";
		}

		/// <summary>
		///   Gets or sets the name of the root element, to be used if the file is created. </summary>
		/// <exception cref="InvalidOperationException">Setting this property if <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <remarks>
		///   By default this property is set to "profile", but it is only used when the file 
		///   is not found and needs to be created to write the value. 
		///   If the file exists, the name of the root element inside the file is ignored. 
		///   The <see cref="Profile.Changing" /> event is raised before changing this property.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without changing this property.  After the property has been changed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		public string RootName
		{
			get 
			{ 
				return m_rootName; 
			}
			set 
			{ 
				VerifyNotReadOnly();
				if (m_rootName == value.Trim())
					return;
					
				if (!RaiseChangeEvent(true, ProfileChangeType.Other, null, "RootName", value))
					return;

				m_rootName = value.Trim(); 				
				RaiseChangeEvent(false, ProfileChangeType.Other, null, "RootName", value);				
			}
		}

		/// <summary>
		///   Gets or sets the encoding, to be used if the file is created. </summary>
		/// <exception cref="InvalidOperationException">Setting this property if <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <remarks>
		///   By default this property is set to <see cref="System.Text.Encoding.UTF8">UTF8</see>, but it is only 
		///   used when the file is not found and needs to be created to write the value. 
		///   If the file exists, the existing encoding is used and this value is ignored. 
		///   The <see cref="Profile.Changing" /> event is raised before changing this property.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without changing this property.  After the property has been changed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		public Encoding Encoding
		{
			get 
			{ 
				return m_encoding; 
			}
			set 
			{ 
				VerifyNotReadOnly();
				if (m_encoding == value)
					return;
					
				if (!RaiseChangeEvent(true, ProfileChangeType.Other, null, "Encoding", value))
					return;

				m_encoding = value; 				
				RaiseChangeEvent(false, ProfileChangeType.Other, null, "Encoding", value);				
			}
		}

		/// <summary>
		///   Sets the value for an entry inside a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry. </param>
		/// <param name="entry">
		///   The name of the entry where the value will be set. </param>
		/// <param name="value">
		///   The value to set. If it's null, the entry is removed. </param>
		/// <exception cref="InvalidOperationException"><see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="InvalidOperationException"><see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="ArgumentNullException">Either section or entry is null. </exception>
		/// <remarks>
		///   If the XML file does not exist, it is created.
		///   The <see cref="Profile.Changing" /> event is raised before setting the value.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without setting the value.  After the value has been set, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		/// <seealso cref="GetValue" />
		public override void SetValue(string section, string entry, object value)
		{
			// If the value is null, remove the entry
			if (value == null)
			{
				RemoveEntry(section, entry);
				return;
			}
			
			VerifyNotReadOnly();
			VerifyName();
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);

			if (!RaiseChangeEvent(true, ProfileChangeType.SetValue, section, entry, value))
				return;

			string valueString = value.ToString();

			// If the file does not exist, use the writer to quickly create it
			if (!File.Exists(Name))
			{	
				XmlTextWriter writer = new XmlTextWriter(Name, m_encoding);			
				writer.Formatting = Formatting.Indented;
	            
	            writer.WriteStartDocument();
				
	            writer.WriteStartElement(m_rootName);			
					writer.WriteStartElement("section");
					writer.WriteAttributeString("name", null, section);				
						writer.WriteStartElement("entry");
						writer.WriteAttributeString("name", null, entry);				
						if (valueString != "")
		            		writer.WriteString(valueString);
	            		writer.WriteEndElement();
	            	writer.WriteEndElement();
	            writer.WriteEndElement();
			
	           	writer.Close();            				
				RaiseChangeEvent(false, ProfileChangeType.SetValue, section, entry, value);
				return;
			}
			
			// The file exists, edit it
			
			XmlDocument doc = GetXmlDocument();
			XmlElement root = doc.DocumentElement;
			
			// Get the section element and add it if it's not there
			XmlNode sectionNode = root.SelectSingleNode(GetSectionsPath(section));
			if (sectionNode == null)
			{
				XmlElement element = doc.CreateElement("section");
				XmlAttribute attribute = doc.CreateAttribute("name");
				attribute.Value = section;
				element.Attributes.Append(attribute);			
				sectionNode = root.AppendChild(element);			
			}

			// Get the entry element and add it if it's not there
			XmlNode entryNode = sectionNode.SelectSingleNode(GetEntryPath(entry));
			if (entryNode == null)
			{
				XmlElement element = doc.CreateElement("entry");
				XmlAttribute attribute = doc.CreateAttribute("name");
				attribute.Value = entry;
				element.Attributes.Append(attribute);			
				entryNode = sectionNode.AppendChild(element);			
			}

			// Add the value and save the file
			if (valueString != "")
				entryNode.InnerText = valueString;
			doc.Save(Name);		
			RaiseChangeEvent(false, ProfileChangeType.SetValue, section, entry, value);
		}

		/// <summary>
		///   Retrieves the value of an entry inside a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry with the value. </param>
		/// <param name="entry">
		///   The name of the entry where the value is stored. </param>
		/// <returns>
		///   The return value is the entry's value, or null if the entry does not exist. </returns>
		/// <exception cref="ArgumentNullException">Either section or entry is null. </exception>
		/// <seealso cref="SetValue" />
		/// <seealso cref="Profile.HasEntry" />
		public override object GetValue(string section, string entry)
		{
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);
			
			try
			{ 	
				XmlDocument doc = GetXmlDocument();
				XmlElement root = doc.DocumentElement;
				
				XmlNode entryNode = root.SelectSingleNode(GetSectionsPath(section) + "/" + GetEntryPath(entry));
				return entryNode.InnerText;
			}
			catch
			{	
				return null;
			}			
		}

		/// <summary>
		///   Removes an entry from a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry. </param>
		/// <param name="entry">
		///   The name of the entry to remove. </param>
		/// <exception cref="InvalidOperationException"><see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="ArgumentNullException">Either section or entry is null. </exception>
		/// <remarks>
		///   The <see cref="Profile.Changing" /> event is raised before removing the entry.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without removing the entry.  After the entry has been removed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		/// <seealso cref="RemoveSection" />
		public override void RemoveEntry(string section, string entry)
		{
			VerifyNotReadOnly();
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);

			// Verify the file exists
			XmlDocument doc = GetXmlDocument();
			if (doc == null)
				return;

			// Get the entry's node, if it exists
			XmlElement root = doc.DocumentElement;			
			XmlNode entryNode = root.SelectSingleNode(GetSectionsPath(section) + "/" + GetEntryPath(entry));
			if (entryNode == null)
				return;

			if (!RaiseChangeEvent(true, ProfileChangeType.RemoveEntry, section, entry, null))
				return;
			
			entryNode.ParentNode.RemoveChild(entryNode);			
			doc.Save(Name);
			RaiseChangeEvent(false, ProfileChangeType.RemoveEntry, section, entry, null);
		}

		/// <summary>
		///   Removes a section. </summary>
		/// <param name="section">
		///   The name of the section to remove. </param>
		/// <exception cref="InvalidOperationException"><see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="ArgumentNullException">section is null. </exception>
		/// <remarks>
		///   The <see cref="Profile.Changing" /> event is raised before removing the section.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without removing the section.  After the section has been removed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		/// <seealso cref="RemoveEntry" />
		public override void RemoveSection(string section)
		{
			VerifyNotReadOnly();
			VerifyAndAdjustSection(ref section);

			// Verify the file exists
			XmlDocument doc = GetXmlDocument();
			if (doc == null)
				return;
			
			// Get the section's node, if it exists
			XmlElement root = doc.DocumentElement;			
			XmlNode sectionNode = root.SelectSingleNode(GetSectionsPath(section));
			if (sectionNode == null)
				return;
			
			if (!RaiseChangeEvent(true, ProfileChangeType.RemoveSection, section, null, null))
				return;

			root.RemoveChild(sectionNode);
			doc.Save(Name);
			RaiseChangeEvent(false, ProfileChangeType.RemoveSection, section, null, null);
		}

		/// <summary>
		///   Retrieves the names of all the entries inside a section. </summary>
		/// <param name="section">
		///   The name of the section holding the entries. </param>
		/// <returns>
		///   If the section exists, the return value is an array with the names of its entries; 
		///   otherwise it's null. </returns>
		/// <seealso cref="Profile.HasEntry" />
		/// <seealso cref="GetSectionNames" />
		public override string[] GetEntryNames(string section)
		{
			// Verify the section exists
			if (!HasSection(section))
				return null;
			    			
			VerifyAndAdjustSection(ref section);
			
			XmlDocument doc = GetXmlDocument();
			XmlElement root = doc.DocumentElement;
			
			// Get the entry nodes
			XmlNodeList entryNodes = root.SelectNodes(GetSectionsPath(section) + "/entry[@name]");
			if (entryNodes == null)
				return null;

			// Add all entry names to the string array			
			string[] entries = new string[entryNodes.Count];
			int i = 0;

			foreach (XmlNode node in entryNodes)
				entries[i++] = node.Attributes["name"].Value;
			
			return entries;
		}
		
		/// <summary>
		///   Retrieves the names of all the sections. </summary>
		/// <returns>
		///   If the XML file exists, the return value is an array with the names of all the sections;
		///   otherwise it's null. </returns>
		/// <seealso cref="Profile.HasSection" />
		/// <seealso cref="GetEntryNames" />
		public override string[] GetSectionNames()
		{
			// Verify the file exists
			XmlDocument doc = GetXmlDocument();
			if (doc == null)
				return null;

			// Get the section nodes
			XmlElement root = doc.DocumentElement;
			XmlNodeList sectionNodes = root.SelectNodes("section[@name]");
			if (sectionNodes == null)
				return null;

			// Add all section names to the string array			
			string[] sections = new string[sectionNodes.Count];			
			int i = 0;

			foreach (XmlNode node in sectionNodes)
				sections[i++] = node.Attributes["name"].Value;
			
			return sections;
		}		
	}
}
