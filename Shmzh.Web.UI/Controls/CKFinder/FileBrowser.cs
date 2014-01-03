/*
 * CKFinder
 * ========
 * http://www.ckfinder.com
 * Copyright (C) 2007-2008 Frederico Caldeira Knabben (FredCK.com)
 *
 * The software, this file and its contents are subject to the CKFinder
 * License. Please read the license.txt file before using, installing, copying,
 * modifying or distribute this file or part of its contents. The contents of
 * this file is part of the Source Code of CKFinder.
 */

using System;
using System.Configuration;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shmzh.Web.UI.Controls.CKFinder
{
	[Designer( typeof( CKFinder.FileBrowserDesigner ) )]
	[ToolboxData( "<{0}:FileBrowser runat=server></{0}:FileBrowser>" )]
	public class FileBrowser : System.Web.UI.Control
	{
		private const string CKFINDER_DEFAULT_BASEPATH = "/ckfinder/";
		public FileBrowser()
		{ }

		#region Properties

		[DefaultValue( "/ckfinder/" )]
		public string BasePath
		{
			get
			{
				var o = ViewState[ "BasePath" ] ?? ConfigurationManager.AppSettings[ "CKFinder:BasePath" ];

			    return ( o == null ? "/ckfinder/" : (string)o );
			}
			set { ViewState[ "BasePath" ] = value; }
		}

		[Category( "Appearence" )]
		[DefaultValue( "100%" )]
		public Unit Width
		{
			get { var o = ViewState[ "Width" ]; return ( o == null ? Unit.Percentage( 100 ) : (Unit)o ); }
			set { ViewState[ "Width" ] = value; }
		}

		[Category( "Appearence" )]
		[DefaultValue( "400px" )]
		public Unit Height
		{
			get { var o = ViewState[ "Height" ]; return ( o == null ? Unit.Pixel( 400 ) : (Unit)o ); }
			set { ViewState[ "Height" ] = value; }
		}

		public string SelectFunction
		{
			get { return ViewState[ "SelectFunction" ] as string; }
			set { ViewState[ "SelectFunction" ] = value; }
		}

		public string SelectThumbnailFunction
		{
			get { return ViewState["SelectThumbnailFunction"] as string; }
			set { ViewState["SelectThumbnailFunction"] = value; }
		}

		public bool DisableThumbnailSelection
		{
			get { return ViewState["DisableThumbnailSelection"] == null ? false : (bool)ViewState["DisableThumbnailSelection"]; }
			set { ViewState["DisableThumbnailSelection"] = value; }
		}

		public string ClassName
		{
			get { return ViewState[ "ClassName" ] as string; }
			set { ViewState[ "ClassName" ] = value; }
		}

		public string StartupPath
		{
			get { return ViewState["StartupPath"] as string; }
			set { ViewState["StartupPath"] = value; }
		}

		public bool RememberLastFolder
		{
			get { return ViewState["RememberLastFolder"] == null ? true : (bool)ViewState["RememberLastFolder"]; }
			set { ViewState["RememberLastFolder"] = value; }
		}

		public bool StartupFolderExpanded
		{
			get { return ViewState["StartupFolderExpanded"] == null ? false : (bool)ViewState["StartupFolderExpanded"]; }
			set { ViewState["StartupFolderExpanded"] = value; }
		}

		public string CKFinderId
		{
			get { return ViewState["CKFinderId"] as string; }
			set { ViewState["CKFinderId"] = value; }
		}
		#endregion

		#region Rendering

		public string CreateHtml()
		{

			var _ClassName = this.ClassName;
			var _Id = this.CKFinderId;

			if ( !string.IsNullOrEmpty(_ClassName) )
				_ClassName = " class=\"" + _ClassName + "\"";

			if ( !string.IsNullOrEmpty(_Id) )
				_Id = " id=\"" + _Id + "\"";

			return "<iframe src=\"" + this.BuildUrl() + "\" width=\"" + this.Width + "\" " +
				"height=\"" + this.Height + "\"" + _ClassName + _Id + " frameborder=\"0\" scrolling=\"no\"></iframe>";
		}

		private string BuildCKFinderDirUrl()
		{
			var _Url = this.BasePath;

			if ( string.IsNullOrEmpty(_Url) )
				_Url = CKFINDER_DEFAULT_BASEPATH;

			if ( !_Url.EndsWith( "/" ) )
				_Url = _Url + "/";

			return _Url;
		}

		private string BuildUrl()
		{
			var _Url = this.BuildCKFinderDirUrl();
			var _Qs = "";

			_Url += "ckfinder.html";

			if ( !string.IsNullOrEmpty(this.SelectFunction) )
				_Qs += "?action=js&amp;func=" + this.SelectFunction;

			if ( !this.DisableThumbnailSelection )
			{
				if ( !string.IsNullOrEmpty(this.SelectThumbnailFunction) )
				{
					_Qs += ( _Qs.Length > 0 ? "&amp;" : "?" );
					_Qs += "thumbFunc=" + this.SelectThumbnailFunction;
				}
				else if ( !string.IsNullOrEmpty(this.SelectFunction) )
					_Qs += "&amp;thumbFunc=" + this.SelectFunction;
			}
			else
			{
				_Qs += ( _Qs.Length > 0 ? "&amp;" : "?" );
				_Qs += "dts=1";
			}

			if ( !string.IsNullOrEmpty(this.StartupPath) )
			{
				_Qs += ( _Qs.Length > 0 ? "&amp;" : "?" );
				_Qs += "start=" + System.Web.HttpContext.Current.Server.UrlPathEncode( 
						this.StartupPath + ( this.StartupFolderExpanded ? ":1" : ":0" ) );
			}

			if ( !this.RememberLastFolder )
			{
				_Qs += ( _Qs.Length > 0 ? "&amp;" : "?" );
				_Qs += "rlf=0";
			}

			if ( !string.IsNullOrEmpty(this.CKFinderId) )
			{
				_Qs += ( _Qs.Length > 0 ? "&amp;" : "?" );
				_Qs += "id=" + System.Web.HttpContext.Current.Server.UrlPathEncode( this.CKFinderId );
			}

			return _Url + _Qs;
		}

		protected override void Render( System.Web.UI.HtmlTextWriter writer )
		{
			writer.Write( this.CreateHtml() );
		}

		#endregion

		#region SetupFCKeditor

		public void SetupFCKeditor( object fckeditorInstance )
		{
		    // If it is a path relative to the current page.
			if ( !this.BasePath.StartsWith( "/" ) )
			{
				var _RequestUri = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
				this.BasePath = _RequestUri.Substring( 0, _RequestUri.LastIndexOf( "/" ) + 1 ) +
					this.BasePath;
			}

			var _QuickUploadUrl = this.BuildCKFinderDirUrl() + "core/connector/aspx/connector.aspx?command=QuickUpload";
			var _Url = this.BuildUrl();
			var _Qs = ( _Url.IndexOf( "?" ) == -1 ) ? "?" : "&amp;";

			// We are doing it through reflection to avoid creating a
			// dependency to the FCKeditor assembly.
			try
			{
				var _ConfigProp = fckeditorInstance.GetType().GetProperty( "Config" );

				var _Config = _ConfigProp.GetValue( fckeditorInstance, null );

				// Get the default property.
				var _DefaultProp = _Config.GetType().GetProperty(
					( (System.Reflection.DefaultMemberAttribute)_Config.GetType().GetCustomAttributes( typeof( System.Reflection.DefaultMemberAttribute ), true )[ 0 ] ).MemberName );

				_DefaultProp.SetValue( _Config, _Url, new object[] { "LinkBrowserURL" } );
				_DefaultProp.SetValue( _Config, _Url + _Qs + "type=Images", new object[] { "ImageBrowserURL" } );
				_DefaultProp.SetValue( _Config, _Url + _Qs + "type=Flash", new object[] { "FlashBrowserURL" } );

				_DefaultProp.SetValue( _Config, _QuickUploadUrl, new object[] { "LinkUploadURL" } );
				_DefaultProp.SetValue( _Config, _QuickUploadUrl + "&type=Images", new object[] { "ImageUploadURL" } );
				_DefaultProp.SetValue( _Config, _QuickUploadUrl + "&type=Flash", new object[] { "FlashUploadURL" } );
			}
			catch
			{
			    // If the above reflection procedure didn't work, we probably
			    // didn't received the apropriate FCKeditor type object.
			    throw ( new ApplicationException( "SetupFCKeditor expects an FCKeditor instance object." ) );
			}
		}

		#endregion
	}
}
