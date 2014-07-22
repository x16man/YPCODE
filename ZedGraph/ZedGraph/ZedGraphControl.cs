//============================================================================
//ZedGraph Class Library - A Flexible Line Graph/Bar Graph Library in C#
//Copyright ?2004  John Champion
//
//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.
//
//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public
//License along with this library; if not, write to the Free Software
//Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Collections.Generic;
using Shmzh.Components.Util;

namespace ZedGraph
{
/*
	/// <summary>
	/// 
	/// </summary>
	public struct DrawingThreadData
	{
		/// <summary>
		/// 
		/// </summary>
		public Graphics _g;
		/// <summary>
		/// 
		/// </summary>
		public MasterPane _masterPane;

//		public DrawingThread( Graphics g, MasterPane masterPane )
//		{
//			_g = g;
//			_masterPane = masterPane;
//		}
	}
*/

	/// <summary>
	/// The ZedGraphControl class provides a UserControl interface to the
	/// <see cref="ZedGraph"/> class library.  This allows ZedGraph to be installed
	/// as a control in the Visual Studio toolbox.  You can use the control by simply
	/// dragging it onto a form in the Visual Studio form editor.  All graph
	/// attributes are accessible via the <see cref="ZedGraphControl.GraphPane"/>
	/// property.
	/// </summary>
	/// <author> John Champion revised by Jerry Vos </author>
	/// <version> $Revision: 3.86 $ $Date: 2007-11-03 04:41:29 $ </version>
	public partial class ZedGraphControl : UserControl
	{

	#region Private Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		/// <summary>
		/// This private field contains the instance for the MasterPane object of this control.
		/// You can access the MasterPane object through the public property
		/// <see cref="ZedGraphControl.MasterPane"/>. This is nulled when this Control is
		/// disposed.
		/// </summary>
		private MasterPane _masterPane;

		/// <summary>
		/// private field that determines whether or not tooltips will be displayed
		/// when the mouse hovers over data values.  Use the public property
		/// <see cref="IsShowPointValues"/> to access this value.
		/// </summary>
		private bool _isShowPointValues = false;
		/// <summary>
		/// private field that determines whether or not tooltips will be displayed
		/// showing the scale values while the mouse is located within the ChartRect.
		/// Use the public property <see cref="IsShowCursorValues"/> to access this value.
		/// </summary>
		private bool _isShowCursorValues = false;
		/// <summary>
		/// private field that determines the format for displaying tooltip values.
		/// This format is passed to <see cref="PointPairBase.ToString(string)"/>.
		/// Use the public property <see cref="PointValueFormat"/> to access this
		/// value.
		/// </summary>
		private string _pointValueFormat = PointPair.DefaultFormat;

		/// <summary>
		/// private field that determines whether or not the context menu will be available.  Use the
		/// public property <see cref="IsShowContextMenu"/> to access this value.
		/// </summary>
		private bool _isShowContextMenu = true;

		/// <summary>
		/// private field that determines whether or not a message box will be shown in response to
		/// a context menu "Copy" command.  Use the
		/// public property <see cref="IsShowCopyMessage"/> to access this value.
		/// </summary>
		/// <remarks>
		/// Note that, if this value is set to false, the user will receive no indicative feedback
		/// in response to a Copy action.
		/// </remarks>
		private bool _isShowCopyMessage = true;

		private SaveFileDialog _saveFileDialog = new SaveFileDialog();

		/// <summary>
		/// private field that determines whether the settings of
		/// <see cref="ZedGraph.PaneBase.IsFontsScaled" /> and <see cref="PaneBase.IsPenWidthScaled" />
		/// will be overridden to true during printing operations.
		/// </summary>
		/// <remarks>
		/// Printing involves pixel maps that are typically of a dramatically different dimension
		/// than on-screen pixel maps.  Therefore, it becomes more important to scale the fonts and
		/// lines to give a printed image that looks like what is shown on-screen.  The default
		/// setting for <see cref="ZedGraph.PaneBase.IsFontsScaled" /> is true, but the default
		/// setting for <see cref="PaneBase.IsPenWidthScaled" /> is false.
		/// </remarks>
		/// <value>
		/// A value of true will cause both <see cref="ZedGraph.PaneBase.IsFontsScaled" /> and
		/// <see cref="PaneBase.IsPenWidthScaled" /> to be temporarily set to true during
		/// printing operations.
		/// </value>
		private bool _isPrintScaleAll = true;
		/// <summary>
		/// private field that determines whether or not the visible aspect ratio of the
		/// <see cref="MasterPane" /> <see cref="PaneBase.Rect" /> will be preserved
		/// when printing this <see cref="ZedGraphControl" />.
		/// </summary>
		private bool _isPrintKeepAspectRatio = true;
		/// <summary>
		/// private field that determines whether or not the <see cref="MasterPane" />
		/// <see cref="PaneBase.Rect" /> dimensions will be expanded to fill the
		/// available space when printing this <see cref="ZedGraphControl" />.
		/// </summary>
		/// <remarks>
		/// If <see cref="IsPrintKeepAspectRatio" /> is also true, then the <see cref="MasterPane" />
		/// <see cref="PaneBase.Rect" /> dimensions will be expanded to fit as large
		/// a space as possible while still honoring the visible aspect ratio.
		/// </remarks>
		private bool _isPrintFillPage = true;

		/// <summary>
		/// private field that determines the format for displaying tooltip date values.
		/// This format is passed to <see cref="XDate.ToString(string)"/>.
		/// Use the public property <see cref="PointDateFormat"/> to access this
		/// value.
		/// </summary>
		private string _pointDateFormat = XDate.DefaultFormatStr;

		/// <summary>
		/// private value that determines whether or not zooming is enabled for the control in the
		/// vertical direction.  Use the public property <see cref="IsEnableVZoom"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableVZoom = true;
		/// <summary>
		/// private value that determines whether or not zooming is enabled for the control in the
		/// horizontal direction.  Use the public property <see cref="IsEnableHZoom"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableHZoom = true;

		/// <summary>
		/// private value that determines whether or not zooming is enabled with the mousewheel.
		/// Note that this property is used in combination with the <see cref="IsEnableHZoom"/> and
		/// <see cref="IsEnableVZoom" /> properties to control zoom options.
		/// </summary>
		private bool _isEnableWheelZoom = true;

		/// <summary>
		/// private value that determines whether or not point editing is enabled in the
		/// vertical direction.  Use the public property <see cref="IsEnableVEdit"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableVEdit = false;
		/// <summary>
		/// private value that determines whether or not point editing is enabled in the
		/// horizontal direction.  Use the public property <see cref="IsEnableHEdit"/> to access this
		/// value.
		/// </summary>
		private bool _isEnableHEdit = false;

		/// <summary>
		/// private value that determines whether or not panning is allowed for the control in the
		/// horizontal direction.  Use the
		/// public property <see cref="IsEnableHPan"/> to access this value.
		/// </summary>
		private bool _isEnableHPan = true;
		/// <summary>
		/// private value that determines whether or not panning is allowed for the control in the
		/// vertical direction.  Use the
		/// public property <see cref="IsEnableVPan"/> to access this value.
		/// </summary>
		private bool _isEnableVPan = true;

		// Revision: JCarpenter 10/06
		/// <summary>
		/// Internal variable that indicates if the control can manage selections. 
		/// </summary>
		private bool _isEnableSelection = false;

		private double _zoomStepFraction = 0.1;

		private ScrollRange _xScrollRange;

		private ScrollRangeList _yScrollRangeList;
		private ScrollRangeList _y2ScrollRangeList;

		private bool _isShowHScrollBar = false;
		private bool _isShowVScrollBar = false;
		//private bool		isScrollY2 = false;
		private bool _isAutoScrollRange = false;

		private double _scrollGrace = 0.00; //0.05;

		private bool _isSynchronizeXAxes = false;
		private bool _isSynchronizeYAxes = false;

		//private System.Windows.Forms.HScrollBar hScrollBar1;
		//private System.Windows.Forms.VScrollBar vScrollBar1;

		// The range of values to use the scroll control bars
		private const int _ScrollControlSpan = int.MaxValue;
		// The ratio of the largeChange to the smallChange for the scroll bars
		private const int _ScrollSmallRatio = 10;

		private bool _isZoomOnMouseCenter = false;

		private ResourceManager _resourceManager;

		/// <summary>
		/// private field that stores a <see cref="PrintDocument" /> instance, which maintains
		/// a persistent selection of printer options.
		/// </summary>
		/// <remarks>
		/// This is needed so that a "Print" action utilizes the settings from a prior
		/// "Page Setup" action.</remarks>
		private PrintDocument _pdSave = null;
		//private PrinterSettings printSave = null;
		//private PageSettings pageSave = null;

		/// <summary>
		/// This private field contains a list of selected CurveItems.
		/// </summary>
		//private List<CurveItem> _selection = new List<CurveItem>();
		private Selection _selection = new Selection();

        #region Add By Wang Junhui.
        /// <summary>
        /// ���ߡ�
        /// </summary>
        private LineObj _hGuideLine;
        /// <summary>
        /// ���ߡ�
        /// </summary>
        private LineObj _vGuideLine;
        /// <summary>
        /// ��ǰ��X���ֵ��
        /// </summary>
        private TextObj _xValueText;
        /// <summary>
        /// ��ǰ��Y���ֵ��
        /// </summary>
        private TextObj _yValueText;
        private List<FloatingBlock> _floatingBlocks = new List<FloatingBlock>();
        private Color _guideLineColor = Color.Black;
        private ToolTip _toolTip_W = null;
        #endregion

    #endregion

        #region Fields: Buttons & Keys Properties

        /// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to click on
		/// linkable objects
		/// </summary>
		/// <seealso cref="LinkModifierKeys" />
		private MouseButtons _linkButtons = MouseButtons.Left;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to click
		/// on linkable objects
		/// </summary>
		/// <seealso cref="LinkButtons" />
		private Keys _linkModifierKeys = Keys.Alt;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to edit point
		/// data values
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHEdit" /> and/or
		/// <see cref="IsEnableVEdit" /> are true.
		/// </remarks>
		/// <seealso cref="EditModifierKeys" />
		private MouseButtons _editButtons = MouseButtons.Right;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to edit point
		/// data values
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHEdit" /> and/or
		/// <see cref="IsEnableVEdit" /> are true.
		/// </remarks>
		/// <seealso cref="EditButtons" />
		private Keys _editModifierKeys = Keys.Alt;

		/// <summary>
		/// Gets or sets a value that determines which mouse button will be used to select
		/// <see cref="CurveItem" />'s.
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableSelection" /> is true.
		/// </remarks>
		/// <seealso cref="SelectModifierKeys" />
		private MouseButtons _selectButtons = MouseButtons.Left;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to select
		/// <see cref="CurveItem" />'s.
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableSelection" /> is true.
		/// </remarks>
		/// <seealso cref="SelectButtons" />
		private Keys _selectModifierKeys = Keys.Shift;

		private Keys _selectAppendModifierKeys = Keys.Shift | Keys.Control;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to perform
		/// zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHZoom" /> and/or
		/// <see cref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso cref="ZoomModifierKeys" />
		/// <seealso cref="ZoomButtons2" />
		/// <seealso cref="ZoomModifierKeys2" />
		private MouseButtons _zoomButtons = MouseButtons.Left;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to perform
		/// zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHZoom" /> and/or
		/// <see cref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso cref="ZoomButtons" />
		/// <seealso cref="ZoomButtons2" />
		/// <seealso cref="ZoomModifierKeys2" />
		private Keys _zoomModifierKeys = Keys.None;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used as a
		/// secondary option to perform zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHZoom" /> and/or
		/// <see cref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso cref="ZoomModifierKeys2" />
		/// <seealso cref="ZoomButtons" />
		/// <seealso cref="ZoomModifierKeys" />
		private MouseButtons _zoomButtons2 = MouseButtons.None;
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used as a
		/// secondary option to perform zoom operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHZoom" /> and/or
		/// <see cref="IsEnableVZoom" /> are true.
		/// </remarks>
		/// <seealso cref="ZoomButtons" />
		/// <seealso cref="ZoomButtons2" />
		/// <seealso cref="ZoomModifierKeys2" />
		private Keys _zoomModifierKeys2 = Keys.None;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used to perform
		/// panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHPan" /> and/or
		/// <see cref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso cref="PanModifierKeys" />
		/// <seealso cref="PanButtons2" />
		/// <seealso cref="PanModifierKeys2" />
		private MouseButtons _panButtons = MouseButtons.Left;

		// Setting this field to Keys.Shift here
		// causes an apparent bug to crop up in VS 2003, by which it will have the value:
		// "System.Windows.Forms.Keys.Shift+None", which won't compile
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used to perform
		/// panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHPan" /> and/or
		/// <see cref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso cref="PanButtons" />
		/// <seealso cref="PanButtons2" />
		/// <seealso cref="PanModifierKeys2" />
		private Keys _panModifierKeys = Keys.Control;

		/// <summary>
		/// Gets or sets a value that determines which Mouse button will be used as a
		/// secondary option to perform panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHPan" /> and/or
		/// <see cref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso cref="PanModifierKeys2" />
		/// <seealso cref="PanButtons" />
		/// <seealso cref="PanModifierKeys" />
		private MouseButtons _panButtons2 = MouseButtons.Middle;

		// Setting this field to Keys.Shift here
		// causes an apparent bug to crop up in VS 2003, by which it will have the value:
		// "System.Windows.Forms.Keys.Shift+None", which won't compile
		/// <summary>
		/// Gets or sets a value that determines which modifier keys will be used as a
		/// secondary option to perform panning operations
		/// </summary>
		/// <remarks>
		/// This setting only applies if <see cref="IsEnableHPan" /> and/or
		/// <see cref="IsEnableVPan" /> are true.  A Pan operation (dragging the graph with
		/// the mouse) should not be confused with a scroll operation (using a scroll bar to
		/// move the graph).
		/// </remarks>
		/// <seealso cref="PanButtons2" />
		/// <seealso cref="PanButtons" />
		/// <seealso cref="PanModifierKeys" />
		private Keys _panModifierKeys2 = Keys.None;

	#endregion

	#region Fields: Temporary state variables

		/// <summary>
		/// Internal variable that indicates the control is currently being zoomed. 
		/// </summary>
		private bool _isZooming = false;
		/// <summary>
		/// Internal variable that indicates the control is currently being panned.
		/// </summary>
		private bool _isPanning = false;
		/// <summary>
		/// Internal variable that indicates a point value is currently being edited.
		/// </summary>
		private bool _isEditing = false;

		// Revision: JCarpenter 10/06
		/// <summary>
		/// Internal variable that indicates the control is currently using selection. 
		/// </summary>
		private bool _isSelecting = false;

		/// <summary>
		/// Internal variable that stores the <see cref="GraphPane"/> reference for the Pane that is
		/// currently being zoomed or panned.
		/// </summary>
		private GraphPane _dragPane = null;
		/// <summary>
		/// Internal variable that stores a rectangle which is either the zoom rectangle, or the incremental
		/// pan amount since the last mousemove event.
		/// </summary>
		private Point _dragStartPt;
		private Point _dragEndPt;

		private int _dragIndex;
		private CurveItem _dragCurve;
		private PointPair _dragStartPair;
		/// <summary>
		/// private field that stores the state of the scale ranges prior to starting a panning action.
		/// </summary>
		private ZoomState _zoomState;
		private ZoomStateStack _zoomStateStack;

		//temporarily save the location of a context menu click so we can use it for reference
		// Note that Control.MousePosition ends up returning the position after the mouse has
		// moved to the menu item within the context menu.  Therefore, this point is saved so
		// that we have the point at which the context menu was first right-clicked
		internal Point _menuClickPt;

	#endregion

	#region Constructors

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ZedGraphControl()
		{
			InitializeComponent();

            _toolTip_W = new ToolTip(this.components);

			// These commands do nothing, but they get rid of the compiler warnings for
			// unused events
			bool b = MouseDown == null || MouseUp == null || MouseMove == null;

			// Link in these events from the base class, since we disable them from this class.
			base.MouseDown += new System.Windows.Forms.MouseEventHandler( this.ZedGraphControl_MouseDown );
			base.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ZedGraphControl_MouseUp );
			base.MouseMove += new System.Windows.Forms.MouseEventHandler( this.ZedGraphControl_MouseMove );

			//this.MouseWheel += new System.Windows.Forms.MouseEventHandler( this.ZedGraphControl_MouseWheel );

			// Use double-buffering for flicker-free updating:
			SetStyle( ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
				| ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );
			//isTransparentBackground = false;
			//SetStyle( ControlStyles.Opaque, false );
			SetStyle( ControlStyles.SupportsTransparentBackColor, true );
			//this.BackColor = Color.Transparent;

			_resourceManager = new ResourceManager( "ZedGraph.Resource.ZedGraphLocale",
				Assembly.GetExecutingAssembly() );

			Rectangle rect = new Rectangle( 0, 0, this.Size.Width, this.Size.Height );
			_masterPane = new MasterPane( "", rect );
			_masterPane.Margin.All = 0;
			_masterPane.Title.IsVisible = false;

			string titleStr = _resourceManager.GetString( "title_def" );
			string xStr = _resourceManager.GetString( "x_title_def" );
			string yStr = _resourceManager.GetString( "y_title_def" );

			//GraphPane graphPane = new GraphPane( rect, "Title", "X Axis", "Y Axis" );
			GraphPane graphPane = new GraphPane( rect, titleStr, xStr, yStr );
			using ( Graphics g = this.CreateGraphics() )
			{
				graphPane.AxisChange( g );
				//g.Dispose();
			}
			_masterPane.Add( graphPane );

			this.hScrollBar1.Minimum = 0;
			this.hScrollBar1.Maximum = 100;
			this.hScrollBar1.Value = 0;

			this.vScrollBar1.Minimum = 0;
			this.vScrollBar1.Maximum = 100;
			this.vScrollBar1.Value = 0;

			_xScrollRange = new ScrollRange( true );
			_yScrollRangeList = new ScrollRangeList();
			_y2ScrollRangeList = new ScrollRangeList();

			_yScrollRangeList.Add( new ScrollRange( true ) );
			_y2ScrollRangeList.Add( new ScrollRange( false ) );

			_zoomState = null;
			_zoomStateStack = new ZoomStateStack();

            //ͬZOrder�ģ��ȼ���ĸ���ǰ��ʾ��
            _hGuideLine = new LineObj();
            _hGuideLine.ZOrder = ZOrder.A_InFront;
            _hGuideLine.IsVisible = false;
            _hGuideLine.Location.CoordinateFrame = CoordType.PaneFraction;
            _hGuideLine.Location.AlignH = AlignH.Left;
            _hGuideLine.Location.AlignV = AlignV.Top;
            _vGuideLine = new LineObj();
            _vGuideLine.ZOrder = ZOrder.A_InFront;
            _vGuideLine.IsVisible = false;
            _vGuideLine.Location.CoordinateFrame = CoordType.PaneFraction;
            _vGuideLine.Location.AlignH = AlignH.Left;
            _vGuideLine.Location.AlignV = AlignV.Top;
            //_masterPane.GraphObjList.Add(_hGuideLine);
            //_masterPane.GraphObjList.Add(_vGuideLine);

            _xValueText = new TextObj("", 2.0D, 2.0D, CoordType.PaneFraction);
            _xValueText.Location.AlignH = AlignH.Center;
            _xValueText.Location.AlignV = AlignV.Top;
            _xValueText.FontSpec.Size = 12F;
            _xValueText.FontSpec.Border.IsVisible = true;
            _xValueText.FontSpec.Border.Color = Color.Black;
            _xValueText.FontSpec.Fill = new Fill(new SolidBrush(Color.FromArgb(180, Color.White)), AlignH.Center, AlignV.Center);
            _xValueText.FontSpec.StringAlignment = StringAlignment.Near;
            _xValueText.ZOrder = ZOrder.A_InFront;
            _xValueText.IsVisible = false;            
            _yValueText = new TextObj("", 2.0D, 2.0D, CoordType.PaneFraction);
            _yValueText.Location.AlignH = AlignH.Right;
            _yValueText.Location.AlignV = AlignV.Center;
            _yValueText.FontSpec.Size = 12F;
            _yValueText.FontSpec.Border.IsVisible = true;
            _yValueText.FontSpec.Border.Color = Color.Black;
            _yValueText.FontSpec.Fill = new Fill(new SolidBrush(Color.FromArgb(180, Color.White)), AlignH.Center, AlignV.Center);
            _yValueText.FontSpec.StringAlignment = StringAlignment.Near;
            _yValueText.ZOrder = ZOrder.A_InFront;
            _yValueText.IsVisible = false;
            _masterPane.GraphObjList.Add(_xValueText);
            _masterPane.GraphObjList.Add(_yValueText);

            
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if the components should be
		/// disposed, false otherwise</param>
		protected override void Dispose( bool disposing )
		{
			lock ( this )
			{
				if ( disposing )
				{
					if ( components != null )
						components.Dispose();
				}
				base.Dispose( disposing );

				_masterPane = null;
			}
		}
	
	#endregion

	#region Methods

		/// <summary>
		/// Called by the system to update the control on-screen
		/// </summary>
		/// <param name="e">
		/// A PaintEventArgs object containing the Graphics specifications
		/// for this Paint event.
		/// </param>
		protected override void OnPaint( PaintEventArgs e )
		{
			lock ( this )
			{
				if ( BeenDisposed || _masterPane == null || this.GraphPane == null )
					return;

				if ( hScrollBar1 != null && this.GraphPane != null &&
					vScrollBar1 != null && _yScrollRangeList != null )
				{
					SetScroll( hScrollBar1, this.GraphPane.XAxis, _xScrollRange.Min, _xScrollRange.Max );
					SetScroll( vScrollBar1, this.GraphPane.YAxis, _yScrollRangeList[0].Min,
						_yScrollRangeList[0].Max );
				}

				base.OnPaint( e );

                //����ƹ�ʱѡ�нڵ㡣Added By Wang Junhui.
                if (this.IsShowHorizontalGuideLine || this.IsShowVerticalGuideLine)
                {
                    try
                    {
                        DrawGuideLines(e.Graphics);
                    }
                    catch
                    { }
                }

                // Add a try/catch pair since the users of the control can't catch this one
                try { _masterPane.Draw(e.Graphics); }
                catch { }

                var scaleFctor = _masterPane.CalcScaleFactor();
                if (_hGuideLine.IsVisible && _hGuideLine.Location.X > 0)
                    _hGuideLine.Draw(e.Graphics, this._masterPane, scaleFctor);
                if (_vGuideLine.IsVisible && _vGuideLine.Location.X > 0)
                    _vGuideLine.Draw(e.Graphics, this._masterPane, scaleFctor);

                foreach (var block in _floatingBlocks)
                {
                    block.Draw(e.Graphics, this._masterPane, scaleFctor);
                }
			}

/*
			// first, see if an old thread is still running
			if ( t != null && t.IsAlive )
			{
				t.Abort();
			}

			//dt = new DrawingThread( e.Graphics, _masterPane );
			//g = e.Graphics;

			// Fire off the new thread
			t = new Thread( new ParameterizedThreadStart( DoDrawingThread ) );
			//ct.ApartmentState = ApartmentState.STA;
			//ct.SetApartmentState( ApartmentState.STA );
			DrawingThreadData dtd;
			dtd._g = e.Graphics;
			dtd._masterPane = _masterPane;

			t.Start( dtd );
			//ct.Join();
*/
        }

        #region ��λ����صġ�

        /// <summary>
        /// ��ȡ�����ö�λ����(���)λ�á������ZedGraphControl�����ꡣ
        /// </summary>
        private Point GuidePoint { get; set; }
	    private GraphPane _graphPane;
        private CurveItem _curveItem;

        private Pen _guideLinePen;
        private Pen GuideLinePen
        {
            get
            {
                if (_guideLinePen == null)
                {
                    _guideLinePen = new Pen(this.GuideLineColor);
                }
                return _guideLinePen;
            }
        }
        
        public void CurrentPointIndexAdd(CurveItem theCurveItem, Int32 added)
        {
            theCurveItem.CurrentPtIndex += added;
        }

        public Int32 GetCurrentPointIndex()
        {
            return _curveItem.CurrentPtIndex;
        }

        public Int32 GetCurveNPts()
        {
            return _curveItem.NPts;
        }

        /// <summary>
        /// ���ƶ�λ�ߡ�
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private void DrawGuideLines(Graphics g)
        {
            if (this._graphPane == null) return;
            //if (this.GuidePoint.IsEmpty)
            //{
            //    if (this._graphPane == null) return;
            //}
            //else
            //{
            //    this._graphPane = this._masterPane.FindChartRect(this.GuidePoint);
            //    //this._graphPane = this._masterPane.FindPane(this.GuidePoint);
            //    if (this._graphPane == null) return;
            //    if (this._graphPane.CurveList.IsPieOnly) return;
            //}

            var rectangle = Rectangle.Round(_graphPane.Chart.Rect);

            double scaleWidth = _graphPane.XAxis.Scale.Max - _graphPane.XAxis.Scale.Min;
            double pixelPerScale = _graphPane.Chart.Rect.Width / scaleWidth;
            if (!this.GuidePoint.IsEmpty)
            {
                Int32 currentPtIndex;
                var isFound = _graphPane.FindNearestPointByX(this.GuidePoint, out _curveItem, out currentPtIndex);
                //_graphPane.FindNearestPoint(this.GuidePoint, out _curveItem, out currentPtIndex);
                if (isFound) _curveItem.CurrentPtIndex = currentPtIndex;
            }
            
            if (_curveItem != null && _curveItem.CurrentPtIndex > -1 && _curveItem.CurrentPtIndex < _curveItem.NPts)
            {
                PointPair pointPair = _curveItem[_curveItem.CurrentPtIndex];
                this.CurrentPoint = pointPair;
                //X����ֵ��
                var realX = Convert.ToSingle(rectangle.Left + ((pointPair.X - _graphPane.XAxis.Scale.Min) * pixelPerScale));
                //------------------------------------------------
                Double yAxisMax = 0.0, yAxisMin = 0.0;
                if (_curveItem.IsY2Axis)
                {
                    yAxisMax = _graphPane.Y2AxisList[_curveItem.YAxisIndex].Scale.Max;
                    yAxisMin = _graphPane.Y2AxisList[_curveItem.YAxisIndex].Scale.Min;
                }
                else
                {
                    yAxisMax = _graphPane.YAxisList[_curveItem.YAxisIndex].Scale.Max;
                    yAxisMin = _graphPane.YAxisList[_curveItem.YAxisIndex].Scale.Min;
                }
                
                var pixelPerScaleY = _graphPane.Chart.Rect.Height / (yAxisMax - yAxisMin);
                //Y����ֵ��
                var realY = Convert.ToSingle(rectangle.Bottom - ((pointPair.Y - yAxisMin) * pixelPerScaleY));
                //System.Diagnostics.Debug.WriteLine("yAxisMax:" + yAxisMax + ",yAxisMin:" + yAxisMin + ", _curveItem:" + _curveItem.Label.Text
                //    + ", _curveItem.YAxisIndex:" + _curveItem.YAxisIndex);
                //-------------------------------------------------

                var xDateTime = MakeValueLabel(_graphPane.XAxis, pointPair.X, -1, true);
                this._xValueText.Text = xDateTime;
                
                //if (pointPair is StockPt)
                //{
                //    //StockPt pt = pointPair as StockPt;
                //    //_ptValueText.Text = String.Format("X:{0}\r\nH:{1}\r\nL:{2}\r\nO:{3}\r\nC:{4}", xDateTime.ToString(), pt.High, pt.Low, pt.Open, pt.Close);
                //}
                //else
                //{
                //    //string test = "";
                //    //foreach (CurveItem curveItem in _graphPane.CurveList)
                //    //{
                //    //    var ppList = curveItem.Points as PointPairList;
                //    //    if (ppList != null)
                //    //    {
                //    //        PointPair pointPairTest = ppList.Find(o => o.X == pointPair.X);
                //    //        if (pointPairTest != null)
                //    //        {
                //    //            test += String.Format("{0}:{1}\r\n", curveItem.Label.Text, pointPairTest.Y);
                //    //            curveItem.CurrentPtValue = pointPairTest.Y;
                //    //        }
                //    //    }
                //    //}
                //    //_ptValueText.Text = String.Format("X:{0}\r\n{1}", xDateTime.ToString(), test);
                //}
                
                foreach (GraphPane tmpPane in _masterPane.PaneList)
                {
                    foreach (CurveItem curveItem in tmpPane.CurveList)
                    {
                        if (curveItem.Points is StockPointList)
                        {
                            var spList = curveItem.Points as StockPointList;
                            StockPt pt = spList.Find(o => o.X == pointPair.X);
                            if (pt != null)
                            {
                                curveItem.CurrentPtValue = pt.Y;
                            }
                            else
                            {
                                curveItem.CurrentPtValue = 0.0;
                            }
                        }
                        else if (curveItem.Points is PointPairList)
                        {
                            var ppList = curveItem.Points as PointPairList;
                            PointPair pt = ppList.Find(o => o.X == pointPair.X);
                            if (pt != null)
                            {
                                curveItem.CurrentPtValue = pt.Y;
                            }
                            else
                            {
                                curveItem.CurrentPtValue = 0.0;
                            }
                        }
                    }
                }
                
                //_ptValueText.Location.X = realX / _masterPane.Rect.Width;
                //_ptValueText.Location.Y = realY / _masterPane.Rect.Height;

                //if (_ptValueText.LayoutArea.Width + realX > _masterPane.Rect.Width)
                //{
                //    _ptValueText.Location.X = (_masterPane.Rect.Width - _ptValueText.LayoutArea.Width - 2) / _masterPane.Rect.Width;
                //}
                //else
                //{
                //    _ptValueText.Location.X = realX / _masterPane.Rect.Width;
                //}
                //if (realY - _ptValueText.LayoutArea.Height < 1)
                //{
                //    _ptValueText.Location.Y = (_ptValueText.LayoutArea.Height + 2) / _masterPane.Rect.Height;
                //}
                //else
                //{
                //    _ptValueText.Location.Y = realY / _masterPane.Rect.Height;
                //}

                if (this.IsShowVerticalGuideLine)
                {
                    //g.DrawLine(GuideLinePen, new PointF(realX, rectangle.Top), new PointF(realX, rectangle.Bottom));
                    //2009-11-25���ġ�
                    float lineMinY = _masterPane.PaneList[0].Chart.Rect.Top;
                    float lineMaxY = _masterPane.PaneList[_masterPane.PaneList.Count - 1].Chart.Rect.Bottom;
                    
                    this._vGuideLine.Line.Color = this.GuideLineColor;
                    this._vGuideLine.Location.X1 = realX / _masterPane.Rect.Width;
                    this._vGuideLine.Location.Y1 = lineMinY / _masterPane.Rect.Height;
                    
                    this._vGuideLine.Location.Width = 0;
                    this._vGuideLine.Location.Height = (lineMaxY - lineMinY) / _masterPane.Rect.Height;
                    
                    float tmpX = realX;
                    var halfW = this._xValueText.LayoutArea.Width / 2;
                    if (tmpX < _masterPane.Rect.Left + halfW)
                        tmpX = _masterPane.Rect.Left + halfW;
                    else if (tmpX > _masterPane.Rect.Right - halfW)
                        tmpX = _masterPane.Rect.Right - halfW;
                    //���õ�ǰ��X���ı�λ�á�
                    this._xValueText.Location.X = tmpX / _masterPane.Rect.Width;
                    this._xValueText.Location.Y = lineMaxY / _masterPane.Rect.Height;
                }
                if (this.IsShowHorizontalGuideLine)
                {
                    //g.DrawLine(GuideLinePen, new Point(rectangle.Left, this.GuidePoint.Y), new Point(rectangle.Right, this.GuidePoint.Y));//���λ�ú��ߡ�
                    //g.DrawLine(GuideLinePen, new PointF(rectangle.Left, realY), new PointF(rectangle.Right, realY));//ʵ�����ߵ�λ�ú��ߡ�
                                        
                    this._hGuideLine.Line.Color = this.GuideLineColor;
                    this._hGuideLine.Location.X1 = rectangle.Left / _masterPane.Rect.Width;
                    if (this.GuidePoint.IsEmpty)
                    {
                        this._yValueText.Text = pointPair.Y.ToString();

                        this._yValueText.Location.Y = this._hGuideLine.Location.Y1 = realY / _masterPane.Rect.Height;
                    }
                    else
                    {
                        double tmpX, tmpY;
                        _graphPane.ReverseTransform(this.GuidePoint, out tmpX, out tmpY);
                        this._yValueText.Text = tmpY.ToString("F2");

                        this._yValueText.Location.Y = this._hGuideLine.Location.Y1 = this.GuidePoint.Y / _masterPane.Rect.Height;
                    }
                    this._hGuideLine.Location.Width = (rectangle.Right - rectangle.Left) / _masterPane.Rect.Width;
                    this._hGuideLine.Location.Height = 0;

                    //���õ�ǰ��Y���ı�λ�á�
                    this._yValueText.Location.X = rectangle.Left / _masterPane.Rect.Width;
                    
                }
                foreach (var block in _floatingBlocks)
                {
                    block.X = this.CurrentPoint.X;
                }
            }
        }

        /// <summary>
        /// ����������ƶ� indexSkip ����λ�������緵��false;���򷵻�true.
        /// </summary>
        /// <param name="indexSkip">������</param>
        /// <returns>���緵��false;���򷵻�true.</returns>
        public Boolean GuideLineGoTo(Int32 indexSkip)
        {
            if (_graphPane == null) return true;
            var tempIdx = _curveItem.CurrentPtIndex + indexSkip;
            if (tempIdx < 0 || tempIdx > _curveItem.NPts - 1) return false;
            _curveItem.CurrentPtIndex = tempIdx;
            //System.Diagnostics.Debug.WriteLine("===============================Index:" + _currentPtIndex + "=============================Count:" + curveItem.NPts);
            this.GuidePoint = Point.Empty;
            //Invalidate();
            return true;
        }

        /// <summary>
        /// ����������ƶ�һ����λ�������緵��false;���򷵻�true.
        /// </summary>
        /// <param name="isToLeft">true:����;false:����.</param>
        /// <returns>���緵��false;���򷵻�true.</returns>
        public Boolean GuideLineGoTo(Boolean isToLeft)
        {
            return isToLeft ? GuideLineGoTo(-1) : GuideLineGoTo(1);
        }
        
        #endregion ��λ����صġ�

        public void InitFromConfig()
        {
            string xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ZedGraph.config");
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(xmlPath);
                if (doc.DocumentElement != null)
                {
                    XmlNode node;
                    XmlElement element = doc.DocumentElement;
                    //GraphPane
                    node = element.SelectSingleNode("GraphPane/FillColor");
                    this.GraphPane.Fill = new Fill(StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black));

                    node = element.SelectSingleNode("GraphPane/BorderColor");
                    this.GraphPane.Border.Color = StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black);

                    node = element.SelectSingleNode("GraphPane/BorderWidth");
                    this.GraphPane.Border.Width = int.Parse(node.Attributes["value"].Value);

                    //Chart
                    node = element.SelectSingleNode("Chart/FillColor");
                    this.GraphPane.Chart.Fill = new Fill(StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black));

                    node = element.SelectSingleNode("Chart/BorderColor");
                    this.GraphPane.Chart.Border.Color = StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black);

                    node = element.SelectSingleNode("Chart/BorderWidth");
                    this.GraphPane.Chart.Border.Width = int.Parse(node.Attributes["value"].Value);

                    //Axis
                    node = element.SelectSingleNode("Axis/BorderColor");
                    var axisColor = StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black);
                    this.GraphPane.XAxis.Color = axisColor;
                    this.GraphPane.XAxis.MajorTic.Color = axisColor;
                    this.GraphPane.XAxis.MinorTic.Color = axisColor;
                    this.GraphPane.XAxis.Title.FontSpec.FontColor = axisColor;
                    this.GraphPane.XAxis.Title.FontSpec.Fill.Color = Color.Black;
                    this.GraphPane.XAxis.Scale.FontSpec.FontColor = axisColor;

                    this.GraphPane.YAxis.Color = axisColor;
                    this.GraphPane.YAxis.MajorTic.Color = axisColor;
                    this.GraphPane.YAxis.MinorTic.Color = axisColor;
                    this.GraphPane.YAxis.Title.FontSpec.FontColor = axisColor;
                    this.GraphPane.YAxis.Title.FontSpec.Fill.Color = Color.Black;
                    this.GraphPane.YAxis.Scale.FontSpec.FontColor = axisColor;

                    this.GraphPane.X2Axis.Color = axisColor;
                    this.GraphPane.X2Axis.MajorTic.Color = axisColor;
                    this.GraphPane.X2Axis.MinorTic.Color = axisColor;
                    this.GraphPane.X2Axis.Title.FontSpec.FontColor = axisColor;
                    this.GraphPane.X2Axis.Title.FontSpec.Fill.Color = Color.Black;
                    this.GraphPane.X2Axis.Scale.FontSpec.FontColor = axisColor;

                    this.GraphPane.Y2Axis.Color = axisColor;
                    this.GraphPane.Y2Axis.MajorTic.Color = axisColor;
                    this.GraphPane.Y2Axis.MinorTic.Color = axisColor;
                    this.GraphPane.Y2Axis.Title.FontSpec.FontColor = axisColor;
                    this.GraphPane.Y2Axis.Title.FontSpec.Fill.Color = Color.Black;
                    this.GraphPane.Y2Axis.Scale.FontSpec.FontColor = axisColor;

                    node = element.SelectSingleNode("Axis/GridColor");
                    this.GraphPane.XAxis.MajorGrid.IsVisible = true;
                    this.GraphPane.YAxis.MajorGrid.IsVisible = true;
                    this.GraphPane.XAxis.MajorGrid.Color = StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black);
                    this.GraphPane.YAxis.MajorGrid.Color = StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black);
                    ;
                    //GuideLine
                    node = element.SelectSingleNode("GuideLine/Color");
                    this.GuideLineColor = StringUtil.StringToColor(node.Attributes["value"].Value, Color.Black);

                }

            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
//		Thread t = null;
		//DrawingThread dt = null;

/*
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dtdobj"></param>
		public void DoDrawingThread( object dtdobj )
		{
			try
			{
				DrawingThreadData dtd = (DrawingThreadData) dtdobj;

				if ( dtd._g != null && dtd._masterPane != null )
					dtd._masterPane.Draw( dtd._g );

				//				else
				//				{
				//					using ( Graphics g2 = CreateGraphics() )
				//						_masterPane.Draw( g2 );
				//				}
			}
			catch
			{

			}
		}
*/

		/// <summary>
		/// Called when the control has been resized.
		/// </summary>
		/// <param name="sender">
		/// A reference to the control that has been resized.
		/// </param>
		/// <param name="e">
		/// An EventArgs object.
		/// </param>
		protected void ZedGraphControl_ReSize( object sender, System.EventArgs e )
		{
			lock ( this )
			{
				if ( BeenDisposed || _masterPane == null )
					return;

				Size newSize = this.Size;

				if ( _isShowHScrollBar )
				{
					hScrollBar1.Visible = true;
					newSize.Height -= this.hScrollBar1.Size.Height;
					hScrollBar1.Location = new Point( 0, newSize.Height );
					hScrollBar1.Size = new Size( newSize.Width, hScrollBar1.Height );
				}
				else
					hScrollBar1.Visible = false;

				if ( _isShowVScrollBar )
				{
					vScrollBar1.Visible = true;
					newSize.Width -= this.vScrollBar1.Size.Width;
					vScrollBar1.Location = new Point( newSize.Width, 0 );
					vScrollBar1.Size = new Size( vScrollBar1.Width, newSize.Height );
				}
				else
					vScrollBar1.Visible = false;

				using ( Graphics g = this.CreateGraphics() )
				{
					_masterPane.ReSize( g, new RectangleF( 0, 0, newSize.Width, newSize.Height ) );
					//g.Dispose();
				}
				this.Invalidate();
			}
		}
		/// <summary>This performs an axis change command on the graphPane.
		/// </summary>
		/// <remarks>
		/// This is the same as
		/// <c>ZedGraphControl.GraphPane.AxisChange( ZedGraphControl.CreateGraphics() )</c>, however,
		/// this method also calls <see cref="SetScrollRangeFromData" /> if <see cref="IsAutoScrollRange" />
		/// is true.
		/// </remarks>
		public virtual void AxisChange()
		{
			lock ( this )
			{
				if ( BeenDisposed || _masterPane == null )
					return;

				using ( Graphics g = this.CreateGraphics() )
				{
					_masterPane.AxisChange( g );
					//g.Dispose();
				}

				if ( _isAutoScrollRange )
					SetScrollRangeFromData();
			}
		}
	#endregion

	#region Zoom States

		/// <summary>
		/// Save the current states of the GraphPanes to a separate collection.  Save a single
		/// (<see paramref="primaryPane" />) GraphPane if the panes are not synchronized
		/// (see <see cref="IsSynchronizeXAxes" /> and <see cref="IsSynchronizeYAxes" />),
		/// or save a list of states for all GraphPanes if the panes are synchronized.
		/// </summary>
		/// <param name="primaryPane">The primary GraphPane on which zoom/pan/scroll operations
		/// are taking place</param>
		/// <param name="type">The <see cref="ZoomState.StateType" /> that describes the
		/// current operation</param>
		/// <returns>The <see cref="ZoomState" /> that corresponds to the
		/// <see paramref="primaryPane" />.
		/// </returns>
		private ZoomState ZoomStateSave( GraphPane primaryPane, ZoomState.StateType type )
		{
			ZoomStateClear();

			if ( _isSynchronizeXAxes || _isSynchronizeYAxes )
			{
				foreach ( GraphPane pane in _masterPane._paneList )
				{
					ZoomState state = new ZoomState( pane, type );
					if ( pane == primaryPane )
						_zoomState = state;
					_zoomStateStack.Add( state );
				}
			}
			else
				_zoomState = new ZoomState( primaryPane, type );

			return _zoomState;
		}

		/// <summary>
		/// Restore the states of the GraphPanes to a previously saved condition (via
		/// <see cref="ZoomStateSave" />.  This is essentially an "undo" for live
		/// pan and scroll actions.  Restores a single
		/// (<see paramref="primaryPane" />) GraphPane if the panes are not synchronized
		/// (see <see cref="IsSynchronizeXAxes" /> and <see cref="IsSynchronizeYAxes" />),
		/// or save a list of states for all GraphPanes if the panes are synchronized.
		/// </summary>
		/// <param name="primaryPane">The primary GraphPane on which zoom/pan/scroll operations
		/// are taking place</param>
		private void ZoomStateRestore( GraphPane primaryPane )
		{
			if ( _isSynchronizeXAxes || _isSynchronizeYAxes )
			{
				for ( int i = 0; i < _masterPane._paneList.Count; i++ )
				{
					if ( i < _zoomStateStack.Count )
						_zoomStateStack[i].ApplyState( _masterPane._paneList[i] );
				}
			}
			else if ( _zoomState != null )
				_zoomState.ApplyState( primaryPane );

			ZoomStateClear();
		}

		/// <summary>
		/// Place the previously saved states of the GraphPanes on the individual GraphPane
		/// <see cref="ZedGraph.GraphPane.ZoomStack" /> collections.  This provides for an
		/// option to undo the state change at a later time.  Save a single
		/// (<see paramref="primaryPane" />) GraphPane if the panes are not synchronized
		/// (see <see cref="IsSynchronizeXAxes" /> and <see cref="IsSynchronizeYAxes" />),
		/// or save a list of states for all GraphPanes if the panes are synchronized.
		/// </summary>
		/// <param name="primaryPane">The primary GraphPane on which zoom/pan/scroll operations
		/// are taking place</param>
		/// <returns>The <see cref="ZoomState" /> that corresponds to the
		/// <see paramref="primaryPane" />.
		/// </returns>
		private void ZoomStatePush( GraphPane primaryPane )
		{
			if ( _isSynchronizeXAxes || _isSynchronizeYAxes )
			{
				for ( int i = 0; i < _masterPane._paneList.Count; i++ )
				{
					if ( i < _zoomStateStack.Count )
						_masterPane._paneList[i].ZoomStack.Add( _zoomStateStack[i] );
				}
			}
			else if ( _zoomState != null )
				primaryPane.ZoomStack.Add( _zoomState );

			ZoomStateClear();
		}

		/// <summary>
		/// Clear the collection of saved states.
		/// </summary>
		private void ZoomStateClear()
		{
			_zoomStateStack.Clear();
			_zoomState = null;
		}

		/// <summary>
		/// Clear all states from the undo stack for each GraphPane.
		/// </summary>
		private void ZoomStatePurge()
		{
			foreach ( GraphPane pane in _masterPane._paneList )
				pane.ZoomStack.Clear();
		}

	#endregion

	}
}
