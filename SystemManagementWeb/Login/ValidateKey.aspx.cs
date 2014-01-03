using System;
using System.Drawing;
using System.IO;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// ValidateKey 的摘要说明。
	/// </summary>
	public partial class ValidateKey : System.Web.UI.Page
	{		
		protected void Page_Load(object sender, System.EventArgs e)
		{
		    var randomkey = new Random();	
			var key = randomkey.Next(1000,9999).ToString();
			Session["LoginKey"]=key;
			var img = new Bitmap(32,16);
			var graobj = Graphics.FromImage(img);
			graobj.DrawString(key.Substring(0,1), (new Font("Arial", 9)), (new SolidBrush(RandomColor(unchecked((int)DateTime.Now.Ticks)))), 0, 0);
			graobj.DrawString(key.Substring(1,1), (new Font("Arial", 9)), (new SolidBrush(RandomColor(~unchecked((int)DateTime.Now.Ticks)))), 8, 0);
			graobj.DrawString(key.Substring(2,1), (new Font("Arial", 9)), (new SolidBrush(RandomColor(unchecked((int)DateTime.Now.Ticks+5)))), 16, 0);
			graobj.DrawString(key.Substring(3,1), (new Font("Arial", 9)), (new SolidBrush(RandomColor(~unchecked((int)DateTime.Now.Ticks+5)))), 24, 0);
			var ms = new MemoryStream();
			img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			Response.ClearContent();
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());
			Response.End();
		}

		private Color RandomColor(int seed)
		{
			var ran = new Random(seed);
			Color retColor;
			switch(ran.Next(10))
			{
				case 0:
					retColor = Color.Red;
					break;
				case 1:
					retColor = Color.Purple;
					break;
				case 2:
					retColor = Color.Violet;
					break;
				case 3:
					retColor = Color.SeaGreen;
					break;
				case 4:
					retColor = Color.Sienna;
					break;
				case 5:
					retColor = Color.Blue;
					break;
				case 6:
					retColor = Color.SkyBlue;
					break;
				case 7:
					retColor = Color.Turquoise;
					break;
				case 8:
					retColor = Color.Plum;
					break;
				case 9:
					retColor = Color.Tomato;
					break;				
				default:
					retColor = Color.Black;
					break;
			}
			return retColor;
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}
