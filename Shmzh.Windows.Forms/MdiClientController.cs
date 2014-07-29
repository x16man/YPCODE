#region Using Directives

using System;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Runtime.InteropServices;

#endregion // Using Directives


namespace Shmzh.Windows.Forms
{
	/// <summary>
	/// �������͵� <see cref="System.Windows.Forms.MdiClient"/>
	/// �����Ϣ���ҿ�����������.
	/// </summary>
	[ToolboxBitmap(typeof(MdiClientController))]
	public class MdiClientController : NativeWindow, IComponent, IDisposable
	{
		#region ��Ա����
		private Form parentForm;
		private MdiClient mdiClient;
		private BorderStyle borderStyle;
		private Color backColor;
		private bool autoScroll;
		private Image image;
		private ContentAlignment imageAlign;
		private bool stretchImage;
		private bool tileImage;
		private ISite site;
		#endregion sysss

		#region �������캯��
		/// <summary>
		/// ��ʼ��<see cref="Shmzh.Components.WinForm.MdiClientController"/> �����ʵ��.
		/// </summary>
		public MdiClientController() : this(null)
		{
		}
		/// <summary>
		/// ��ʼ��<see cref="Slusser.Components.MdiClientController"/> �����ʵ��.
		/// </summary>
		/// <param name="parentForm">MDI����</param>
		public MdiClientController(Form parentForm)
		{
			// ������ʼ��
			this.site = null;
			this.parentForm = null;
			this.mdiClient = null;
			this.backColor = SystemColors.AppWorkspace;
			this.borderStyle = BorderStyle.Fixed3D;
			this.autoScroll = true;
			this.image = null;
			this.imageAlign = ContentAlignment.MiddleCenter;
			this.stretchImage = false;
			
			// ���ø���������.
			this.ParentForm = parentForm;
		}

		#endregion 

		#region �����¼�

		/// <summary>
		/// �ؼ����ػ��¼�.
		/// </summary>
		[Category("Appearance"), Description("Occurs when a control needs repainting.")]
		public event PaintEventHandler Paint;
		/// <summary>
		/// �ؼ�����Դ�ͷ��¼�.
		/// </summary>
		[Browsable(false)]
		public event EventHandler Disposed;
		/// <summary>
		/// ���ش���<see cref="System.Windows.Forms.NativeWindow"/>���ָ���¼�.
		/// </summary>
		[Browsable(false)]
		public event EventHandler HandleAssigned;
		#endregion 

		#region ��������
		/// <summary>
		/// ��ȡ������<see cref="System.ComponentModel.Component"/>��<see cref="System.ComponentModel.ISite"/> ���ԡ�
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ISite Site
		{
			get { return site; }
			set
			{
				site = value;

				if(site == null)
					return;

				// ����������ʱ�����õ�����ʱ���������ParentForm����.
				IDesignerHost host = (value.GetService(typeof(IDesignerHost)) as IDesignerHost);
				if(host != null)
				{
					Form parent = host.RootComponent as Form;
					if(parent != null)
						ParentForm = parent;
				}
			}
		}

		/// <summary>
		/// ��ȡ������<see cref="System.Windows.Forms.MdiClient"/>�ؼ���ParentForm���ԡ�
		/// </summary>
		[Browsable(false)]
		public Form ParentForm
		{
			get { return parentForm; }
			set
			{
				// ����������Ѿ���ǰ���趨,��ôȡ��ԭ����������¼���.
				if(parentForm != null)
					parentForm.HandleCreated -= new EventHandler(ParentFormHandleCreated);

				parentForm = value;

				if(parentForm == null)
					return;

				// If the parent form has not been created yet,
				// wait to initialize the MDI client until it is.
				if(parentForm.IsHandleCreated)
				{
					InitializeMdiClient();
					RefreshProperties();
				}
				else
					parentForm.HandleCreated += new EventHandler(ParentFormHandleCreated);
			}
		}
		/// <summary>
		/// ��ȡ�����Ƶ�<see cref="System.Windows.Forms.MdiClient"/> ����
		/// </summary>
		/// <remarks>��ΪMDI������԰�����ֹһ��MDIClient�ؼ���</remarks>
		[Browsable(false)]
		public MdiClient MdiClient
		{
			get { return mdiClient; }
		}

		/// <summary>
		/// ��ȡ�����ÿؼ��ı�����ɫ��
		/// </summary>
		[Category("Appearance"), DefaultValue(typeof(Color), "AppWorkspace")]
		[Description("������ʾ�ؼ����ı���ͼ�εı���ɫ��")]
		public Color BackColor
		{
			// Use the BackColor property of the MdiClient control. This is one of
			// the few properties in the MdiClient class that actually works.

			get
			{
				if(mdiClient != null)
                    return mdiClient.BackColor;

				return backColor;
			}
			set
			{
				backColor = value;
				if(mdiClient != null)
                    mdiClient.BackColor = value;
			}
		}


		/// <summary>
		/// ��ʾ�ؼ��ı߿���ʽ��
		/// </summary>
		/// <exception cref="System.ComponentModel.InvalidEnumArgumentException">
		/// ���õ�ֵ����<see cref="System.Windows.Forms.BorderStyle"/> ö�ٳ�Ա��</exception>
		[DefaultValue(BorderStyle.Fixed3D), Category("Appearance")]
		[Description("ָʾMDI�����Ƿ�ӵ��һ���߿�")]
		public BorderStyle BorderStyle
		{
			get { return borderStyle; }
			set
			{
				// Error-check the enum.
				if(!Enum.IsDefined(typeof(BorderStyle), value))
					throw new InvalidEnumArgumentException("value", (int)value, typeof(BorderStyle));

				borderStyle = value;

				if(mdiClient == null)
					return;

				// This property can actually be visible in design-mode,
				// but to keep it consistent with the others,
				// prevent this from being show at design-time.
				if(site != null && site.DesignMode)
					return;

				// There is no BorderStyle property exposed by the MdiClient class,
				// but this can be controlled by Win32 functions. A Win32 ExStyle
				// of WS_EX_CLIENTEDGE is equivalent to a Fixed3D border and a
				// Style of WS_BORDER is equivalent to a FixedSingle border.
				
				// This code is inspired Jason Dori's article:
				// "Adding designable borders to user controls".
				// http://www.codeproject.com/cs/miscctrl/CsAddingBorders.asp

				// Get styles using Win32 calls
				int style = GetWindowLong(mdiClient.Handle, GWL_STYLE);
				int exStyle = GetWindowLong(mdiClient.Handle, GWL_EXSTYLE);

				// Add or remove style flags as necessary.
				switch(borderStyle)
				{
					case BorderStyle.Fixed3D:
						exStyle |= WS_EX_CLIENTEDGE;
						style &= ~WS_BORDER;
						break;

					case BorderStyle.FixedSingle:
						exStyle &= ~WS_EX_CLIENTEDGE;
						style |= WS_BORDER;
						break;

					case BorderStyle.None:
						style &= ~WS_BORDER;
						exStyle &= ~WS_EX_CLIENTEDGE;
						break;
				}
					
				// Set the styles using Win32 calls
				SetWindowLong(mdiClient.Handle, GWL_STYLE, style);
				SetWindowLong(mdiClient.Handle, GWL_EXSTYLE, exStyle);

				// Cause an update of the non-client area.
				UpdateStyles();
			}
		}
		/// <summary>
		/// �Զ����ƹ�����.
		/// </summary>
		[DefaultValue(true), Category("Layout")]
		[Description("ȷ�����ؼ������õ��ؼ��Ĺ�����֮��ʱ���Ƿ��Զ���ʾ��������")]
		public bool AutoScroll
		{
			get { return autoScroll; }
			set
			{
				// By default the MdiClient control scrolls. It can appear though that
				// there are no scrollbars by turning them off when the non-client
				// area is calculated. I decided to expose this method following
				// the .NET vernacular of an AutoScroll property.

				autoScroll = value;
				if(mdiClient != null)
                    UpdateStyles();
			}
		}

		/// <summary>
		/// ��ȡ������<see cref="Shmzh.Components.WinForm.MdiClientController"/> ����ͼƬ.
		/// </summary>
		[DefaultValue(null), Category("Appearance")]
		[Description("��MDI�Ŀͻ�����ʾ��ͼƬ��")]
		public Image Image
		{
			get { return image; }
			set
			{
				image = value;
				if(mdiClient != null)
                    mdiClient.Invalidate();
			}
		}
		/// <summary>
		/// ��ȡ�����ÿؼ�����ͼƬ�Ķ��뷽ʽ.
		/// </summary>
		/// <exception cref="System.ComponentModel.InvalidEnumArgumentException">
		/// �趨��ֵ����<see cref="System.Drawing.ContentAlignment"/> ö�ٳ�Ա.</exception>
		[Category("Appearance"), DefaultValue(ContentAlignment.MiddleCenter)]
		[Description("ȷ��ͼƬ��MDI�Ŀͻ�����λ�á�")]
		public ContentAlignment ImageAlign
		{
			get { return imageAlign; }
			set
			{
				// Error-check the enum.
				if(!Enum.IsDefined(typeof(ContentAlignment), value))
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));

				imageAlign = value;
				if(mdiClient != null)
					mdiClient.Invalidate();
			}
		}
		/// <summary>
		/// ��ȡ������<see cref="Shmzh.Components.WinForm.MdiClientController.Image"/>�Ƿ���������.
		/// </summary>
		[Category("Appearance"), DefaultValue(false)]
		[Description("ȷ��ͼƬ�Ƿ����������������ͻ�����")]
		public bool StretchImage
		{
			get { return stretchImage; }
			set
			{
				stretchImage = value;
				if(mdiClient != null)
					mdiClient.Invalidate();
			}
		}
		/// <summary>
		/// ��ȡ������<see cref="Shmzh.Components.WinForm.MdiClientController.Image"/>�Ƿ�ƽ�����ԡ�
		/// </summary>
		[Category("Appearance"), DefaultValue(false)]
		[Description("ȷ��ͼƬ�Ƿ�ƽ�������������ͻ�����")]
		public bool TileImage
		{
			get {return tileImage;}
			set
			{
				tileImage = value;
				if(mdiClient != null)
					mdiClient.Invalidate();
			}
		}
		/// <summary>
		/// ��ȡ����ľ��.
		/// </summary>
		[Browsable(false)]
		public new IntPtr Handle
		{
			// Hide this from the property grid during design-time.
			get { return base.Handle; }
		}

		#endregion // Public Properties

		#region ��������
		/// <summary>
		/// �ͷ�<see cref="System.ComponentModel.Component"/>��ʹ�õ�������Դ.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Reestablishes a connection to the <see cref="System.Windows.Forms.MdiClient"/>
		/// control if the <see cref="Shmzh.Components.WinForm.MdiClientController.ParentForm"/>
		/// hasn't changed but its <see cref="System.Windows.Forms.Form.IsMdiContainer"/>
		/// property has.
		/// </summary>
		public void RenewMdiClient()
		{
			// Reinitialize the MdiClient and its properties.
			InitializeMdiClient();
			RefreshProperties();
		}

		#endregion

		#region �ܱ�������
		/// <summary>Releases the unmanaged resources used by the
		/// <see cref="System.ComponentModel.Component"/> and optionally releases the
		/// managed resources.</summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged
		/// resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if(disposing)
			{
				lock(this)
				{
					if(site != null && site.Container != null)
						site.Container.Remove(this);

					if(Disposed != null)
						Disposed(this, EventArgs.Empty);
				}
			}
		}
 

		/// <summary>
		/// Invokes the default window procedure associated with this window.
		/// </summary>
		/// <param name="m">A <see cref="System.Windows.Forms.Message"/> that is associated with the current Windows message. </param>
		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				//Do all painting in WM_PAINT to reduce flicker.
				case WM_ERASEBKGND:
					return;

				case WM_PAINT:

					// This code is influenced by Steve McMahon's article:
					// "Painting in the MDI Client Area".
					// http://vbaccelerator.com/article.asp?id=4306

					// Use Win32 to get a Graphics object.
					PAINTSTRUCT paintStruct = new PAINTSTRUCT();
					IntPtr screenHdc = BeginPaint(m.HWnd, ref paintStruct);

					using(Graphics screenGraphics = Graphics.FromHdc(screenHdc)) 
					{
						// Get the area to be updated.
						Rectangle clipRect = new Rectangle(
							paintStruct.rcPaint.left,
							paintStruct.rcPaint.top,
							paintStruct.rcPaint.right - paintStruct.rcPaint.left,
							paintStruct.rcPaint.bottom - paintStruct.rcPaint.top);

						// Double-buffer by painting everything to an image and
						// then drawing the image.
						int width = (mdiClient.ClientRectangle.Width > 0 ? mdiClient.ClientRectangle.Width : 0);
						int height = (mdiClient.ClientRectangle.Height > 0 ? mdiClient.ClientRectangle.Height : 0);
						using(Image i = new Bitmap(width, height))
						{
							using(Graphics g = Graphics.FromImage(i))
							{
								// This code comes from J Young's article:
								// "Generating missing Paint event for TreeView and ListView".
								// http://www.codeproject.com/cs/miscctrl/genmissingpaintevent.asp

								// Draw base graphics and raise the base Paint event.
								IntPtr hdc = g.GetHdc();
								Message printClientMessage =
									Message.Create(m.HWnd, WM_PRINTCLIENT, hdc, IntPtr.Zero);  
								DefWndProc(ref printClientMessage);
								g.ReleaseHdc(hdc);

								// Draw the image here.
								if(image != null)
									DrawImage(g, clipRect);

								// Call our OnPaint here to draw graphics over the
								// original and raise our Paint event.
								OnPaint(new PaintEventArgs(g, clipRect));
							}

							// Now draw all the graphics at once.
							screenGraphics.DrawImage(i, mdiClient.ClientRectangle);
						}
					}

					EndPaint(m.HWnd, ref paintStruct);
					return;
					
				case WM_SIZE:

					// Repaint on every resize.
					mdiClient.Invalidate();
					break;
					

				case WM_NCCALCSIZE:

					// If AutoScroll is set to false, hide the scrollbars when the control
					// calculates its non-client area.
					if(!autoScroll)
						ShowScrollBar(m.HWnd, SB_BOTH, 0 /*false*/);
					break;
			}
		
			base.WndProc(ref m);
		}
		/// <summary>
		/// ���� <see cref="Shmzh.Components.WinForm.MdiClientController.Paint"/> �¼�.
		/// </summary>
		/// <param name="e">Ϊ <see cref="System.Windows.Forms.PaintEventArgs"/> �¼��ṩ����.</param>
		protected virtual void OnPaint(PaintEventArgs e)
		{
			if(Paint != null) Paint(this, e);
		}
		/// <summary>
		/// ���� <see cref="Slusser.Components.MdiClientController.HandleAssigned"/> �¼�.
		/// </summary>
		/// <param name="e">Ϊ <see cref="System.EventArgs"/> �¼��ṩ����.</param>
		protected virtual void OnHandleAssigned(EventArgs e)
		{
			if(HandleAssigned != null) HandleAssigned(this, e);
		}

		#endregion
        
		#region ˽�з���

		private void InitializeMdiClient()
		{
			// If the mdiClient has previously been set, unwire events connected
			// to the old MDI.
			if(mdiClient != null)
				mdiClient.HandleDestroyed -= new EventHandler(MdiClientHandleDestroyed);

			if(parentForm == null)
				return;

			// Get the MdiClient from the parent form.
			for(int i = 0; i < parentForm.Controls.Count; i++)
			{
				// If the form is an MDI container, it will contain an MdiClient control
				// just as it would any other control.
				mdiClient = parentForm.Controls[i] as MdiClient;
				if(mdiClient != null)
				{
					// Assign the MdiClient Handle to the NativeWindow.
					ReleaseHandle();
					AssignHandle(mdiClient.Handle);

					// Raise the HandleAssigned event.
					OnHandleAssigned(EventArgs.Empty);

					// Monitor the MdiClient for when its handle is destroyed.
					mdiClient.HandleDestroyed += new EventHandler(MdiClientHandleDestroyed);
				}
			}
		}

		/// <summary>
		/// ���Ʊ���ͼ.
		/// </summary>
		/// <param name="g"></param>
		/// <param name="clipRect"></param>
		private void DrawImage(Graphics g, Rectangle clipRect)
		{
			Point pt = Point.Empty;

			if(stretchImage)
				g.DrawImage(image, mdiClient.ClientRectangle);
			else if(tileImage)
			{
				for(int j=0;j<mdiClient.ClientRectangle.Height;j+=image.Height)
				{
					for(int i=0;i<mdiClient.ClientRectangle.Width;i+=image.Width)
					{
						pt = new Point(i,j);
						g.DrawImage(image, new Rectangle(pt, image.Size));
					}
				}
			}
			else
			{
				// Calculate the location of the image. (Note: this logic could be calculated during sizing
				// instead of during painting to improve performance.)
				switch(imageAlign)
				{
					case ContentAlignment.TopLeft:
						pt = new Point(0, 0);
						break;
					case ContentAlignment.TopCenter:
						pt = new Point((mdiClient.ClientRectangle.Width / 2) - (image.Width / 2), 0);
						break;
					case ContentAlignment.TopRight:
						pt = new Point(mdiClient.ClientRectangle.Width - image.Width, 0);
						break;
					case ContentAlignment.MiddleLeft:
						pt = new Point(0,
							(mdiClient.ClientRectangle.Height / 2) - (image.Height / 2));
						break;
					case ContentAlignment.MiddleCenter:
						pt = new Point((mdiClient.ClientRectangle.Width / 2) - (image.Width / 2),
							(mdiClient.ClientRectangle.Height / 2) - (image.Height / 2));
						break;
					case ContentAlignment.MiddleRight:
						pt = new Point(mdiClient.ClientRectangle.Width - image.Width,
							(mdiClient.ClientRectangle.Height / 2) - (image.Height / 2));
						break;
					case ContentAlignment.BottomLeft:
						pt = new Point(0, mdiClient.ClientRectangle.Height - image.Height);
						break;
					case ContentAlignment.BottomCenter:
						pt = new Point((mdiClient.ClientRectangle.Width / 2) - (image.Width / 2),
							mdiClient.ClientRectangle.Height - image.Height);
						break;
					case ContentAlignment.BottomRight:
						pt = new Point(mdiClient.ClientRectangle.Width - image.Width,
							mdiClient.ClientRectangle.Height - image.Height);
						break;
				}

				// Paint the image with the calculated coordinates and image size.
				g.DrawImage(image, new Rectangle(pt, image.Size));
			}
		}


		private void UpdateStyles()
		{
			// To show style changes, the non-client area must be repainted. Using the
			// control's Invalidate method does not affect the non-client area.
			// Instead use a Win32 call to signal the style has changed.
			
			SetWindowPos(mdiClient.Handle, IntPtr.Zero, 0, 0, 0, 0,
				SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER |
				SWP_NOOWNERZORDER | SWP_FRAMECHANGED);
		}


		private void MdiClientHandleDestroyed(object sender, EventArgs e)
		{
			// If the MdiClient handle has been released, drop the reference and
			// release the handle.
			if(mdiClient != null)
			{
				mdiClient.HandleDestroyed -= new EventHandler(MdiClientHandleDestroyed);
				mdiClient = null;
			}

			ReleaseHandle();
		}


		private void ParentFormHandleCreated(object sender, EventArgs e)
		{
			// The form has been created, unwire the event, and initialize the MdiClient.
			parentForm.HandleCreated -= new EventHandler(ParentFormHandleCreated);
			InitializeMdiClient();
			RefreshProperties();
		}


		private void RefreshProperties()
		{
			// Refresh all the properties
			BackColor = backColor;
			BorderStyle = borderStyle;
			AutoScroll = autoScroll;
			Image = image;
			ImageAlign = imageAlign;
			StretchImage = stretchImage;
		}

		#endregion 
        
		#region Win32

		private const int WM_PAINT			= 0x000F;
		private const int WM_ERASEBKGND		= 0x0014;
		private const int WM_NCPAINT		= 0x0085;
		private const int WM_THEMECHANGED	= 0x031A;
		private const int WM_NCCALCSIZE		= 0x0083;
		private const int WM_SIZE			= 0x0005;
		private const int WM_PRINTCLIENT	= 0x0318;

		private const uint SWP_NOSIZE			= 0x0001;
		private const uint SWP_NOMOVE			= 0x0002;
		private const uint SWP_NOZORDER			= 0x0004;
		private const uint SWP_NOREDRAW			= 0x0008;
		private const uint SWP_NOACTIVATE		= 0x0010;
		private const uint SWP_FRAMECHANGED		= 0x0020;
		private const uint SWP_SHOWWINDOW		= 0x0040;
		private const uint SWP_HIDEWINDOW		= 0x0080;
		private const uint SWP_NOCOPYBITS		= 0x0100;
		private const uint SWP_NOOWNERZORDER	= 0x0200;
		private const uint SWP_NOSENDCHANGING	= 0x0400;

		private const int WS_BORDER			= 0x00800000;
		private const int WS_EX_CLIENTEDGE	= 0x00000200;
		private const int WS_DISABLED		= 0x08000000;

		private const int GWL_STYLE		= -16;
		private const int GWL_EXSTYLE	= -20;

		private const int SB_HORZ	= 0;
		private const int SB_VERT	= 1;
		private const int SB_CTL	= 2;
		private const int SB_BOTH	= 3;


		[StructLayout(LayoutKind.Sequential)]
		private struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
	  
			public RECT(Rectangle rect) 
			{
				this.left = rect.Left;
				this.top = rect.Top;
				this.right = rect.Right;
				this.bottom = rect.Bottom;
			}

			public RECT(int left, int top, int right, int bottom) 
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct PAINTSTRUCT
		{
			public IntPtr hdc;
			public int fErase;
			public RECT rcPaint;
			public int fRestore;
			public int fIncUpdate;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)] public byte[] rgbReserved;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct NCCALCSIZE_PARAMS
		{
			public RECT rgrc0, rgrc1, rgrc2;
			public IntPtr lppos;
		}


		[DllImport("user32.dll")]
		private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

		[DllImport("user32.dll")]
		private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);

		[DllImport("user32.dll")]
		private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowLong(IntPtr hWnd, int Index);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SetWindowLong(IntPtr hWnd, int Index, int Value);

		[DllImport("user32.dll", ExactSpelling = true)]
		private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		#endregion // Win32
	}
}
