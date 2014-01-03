using System;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_UserDetail ��ժҪ˵����
	/// </summary>
	public partial class SYS_UserDetail : System.Web.UI.Page
	{

		private int PKID;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(Request["PKID"]))
			{
				PKID=int.Parse(Request["PKID"]);
			    var obj = DataProvider.UserProvider.GetById(PKID);

			    lb_EmpCnName.Text = obj.EmpName;
			    lb_EmpCode.Text = obj.EmpCode;
			    lb_EmpEnName.Text = obj.EmpEnName;
				lb_IsEmp.Text = obj.IsEmp == "Y"?"�ڲ�Ա��":"�ⲿ�û�";
			    lb_LoginName.Text = obj.LoginName;
				lb_UserState.Text = obj.IsUser == "Y"?"����":"����";
			    lb_OfficeCall.Text = string.Format("{0}-{1}", obj.OfficeCall, obj.OfficeSubCall);
			    lb_OfficeFax.Text = obj.OfficeFax;
			    lb_Mobile.Text = obj.Mobile;
			    lb_Email.Text = obj.EMail;
			    lb_Birthday.Text = obj.BirthDay == DateTime.MinValue ? string.Empty:obj.BirthDay.ToString("d");
				lb_Gender.Text = obj.Gender == "M"?"��":"Ů";
			    lb_DeptCnName.Text = obj.DeptName;
			    lb_IDCard.Text = obj.IDCard;
			    lb_DutyCnName.Text = obj.DutyName;
			    lb_DutyEnName.Text = obj.DutyEnName;
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
