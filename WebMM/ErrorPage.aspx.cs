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

namespace MZHMM.WebMM
{
	/// <summary>
	/// ErrorPage ��ժҪ˵����
	/// </summary>
	public partial class ErrorPage : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Label1.Text=Request["ErrorInfo"];
		}
	}
}
