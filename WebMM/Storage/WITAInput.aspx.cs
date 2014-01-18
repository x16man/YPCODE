using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MZHCommon.Database;


namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// PCATBrowser 的摘要说明。
	/// </summary>
	public partial class WITAInput : System.Web.UI.Page
	{
	    private Hashtable oHT;

	    private HttpPostedFile myPostedFile;

	    private int FileSize;

	    private byte[] FileData;

	    private byte[] MicroImageData;

	    private DataSet oData;
		/// <summary>
		/// 物料编号。
		/// </summary>
		public string ItemCode
		{
			get 
			{
				if (this.Request["ItemCode"] != null && this.Request["ItemCode"].ToString() != "")
				{
					return this.Request["ItemCode"].ToString();
				}
				else
				{
					return null;
				}
			}
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if(!this.IsPostBack)
			    myDataBind();

		}

		protected void AttUpload_Click(object sender, System.EventArgs e)
		{
			if(ItemCode!= null)
			{
				myPostedFile = uploadFile.PostedFile;
				FileSize=myPostedFile.ContentLength;
				if (FileSize>0)
				{
					FileData=new byte[FileSize];
					MicroImageData = new byte[FileSize];

					myPostedFile.InputStream.Read(FileData,0,FileSize);//原始图。
					MicroImageData = FileData;

					oHT = new Hashtable();
					oHT.Add("@ItemCode", ItemCode);
					oHT.Add("@MicroImage", MicroImageData);
					oHT.Add("@OriginalImage", FileData);
					
					new SQLServer().ExecSP("Sto_ItemImageInsert",oHT);

					myDataBind();
				}	
			}
			else
			{
				//Response.Write("<script>alert('请先指定物料基本信息！')</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请先指定物料基本信息!');", true);
			}
		}

		private void myDataBind()
		{
			oHT = new Hashtable();
			oHT.Add("@ItemCode",this.ItemCode);
			oData = new SQLServer().ExecSPReturnDS("Sto_ItemGetMicroImageByCode",oHT);
			AttList.DataSource = oData;
			AttList.DataBind();
		}

	}
}
