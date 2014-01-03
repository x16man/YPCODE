<%@ Page Language="c#" CodeBehind="SYS_UserEdit.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>��Աά��</title>
    <link type="text/css" rel="Stylesheet" media="screen" href="../CSS/common.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/MZHUM/form2column.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/MZHUM/SYS_UserEdit.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    
<script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>
    <script src="../js/MZHUM/SYS_UserEdit.js" type="text/javascript"></script>
    <script src="/aspnet_client/Shmzh.Web.UI/css.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" Text="����" TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="False" IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" onclick="window.close();" Text="�ر�" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset id="userInfo" runat="server">
                <legend>��Ա��Ϣ</legend>
                <div class="leftColumn">
                    <label for="ddw_IsEmp">
                        ���ͣ�<span class="required">*</span></label>
                    <div>
                        <asp:DropDownList ID="ddw_IsEmp" runat="server">
                            <asp:ListItem Value="Y">�ڲ�Ա��</asp:ListItem>
                            <asp:ListItem Value="N">�ⲿ��Ա</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label for="tb_EmpCode">
                        ���ţ�<span class="required">*</span></label>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="CheckoutEmpCode"
                        Display="Dynamic">���ű���</asp:CustomValidator>
                    <div>
                        <asp:TextBox ID="tb_EmpCode" runat="server" AutoPostBack="True" 
                            OnTextChanged="tb_EmpCode_TextChanged" MaxLength="20"></asp:TextBox>
                    </div>
                    <label for="tb_EmpCnName">
                        ������<span class="required">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="" runat="server"
                        ControlToValidate="tb_EmpCnName" Display="Dynamic">��������</asp:RequiredFieldValidator>
                    <div>
                        <asp:TextBox ID="tb_EmpCnName" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <label for="tb_IDCard">
                        ���֤�ţ�</label>
                    <div>
                        <asp:TextBox ID="tb_IDCard" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                    <label for="ddw_Gender">
                        �Ա�<span class="required">*</span></label>
                    <div class="clear">
                        <asp:DropDownList ID="ddw_Gender" runat="server">
                            <asp:ListItem Value="M">��</asp:ListItem>
                            <asp:ListItem Value="F">Ů</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label for="tbiBirthday">
                        ���գ�</label>
                    <div class="clear">
                        <mzh:ToolbarCalendar ID="tbiBirthday" runat="server" ItemId="Birthday" ReadOnly="True" />
                    </div>
                </div>
                <div class="rightColumn">
                    <div class="content">
                        <label for="tb_LoginName">
                            ��¼����</label>
                        <div>
                            <asp:TextBox ID="tb_LoginName" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        
                        
                        <label for="tb_Mobile">
                            �ֻ���</label>
                        <div>
                            <asp:TextBox ID="tb_Mobile" runat="server"></asp:TextBox>
                        </div>
                        <label for="tb_OfficeFax">
                            ���棺</label>
                        <div>
                            <asp:TextBox ID="tb_OfficeFax" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <label for="tb_Email">
                            E-Mail��</label>
                        <div>
                            <asp:TextBox ID="tb_Email" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <label for="ddlUICultrue">���ԣ�</label>
                        <div><asp:DropDownList ID="ddlUICultrue" runat="server">
                            <asp:ListItem Value="zh-CN">����</asp:ListItem>
                            <asp:ListItem Value="en">English</asp:ListItem>
                        </asp:DropDownList></div>
                        <label for="tb_SerialNo">
                        ��ţ�</label>
                        <asp:RangeValidator ID="rvSerialNo" runat="server" 
                            ControlToValidate="tb_SerialNo" Display="Dynamic" MaximumValue="9999" 
                            MinimumValue="1" Type="Integer">1~9999</asp:RangeValidator>
                        <div><asp:TextBox ID="tb_SerialNo" runat="server" MaxLength="4"></asp:TextBox></div>
                    </div>
                </div>
            </fieldset>
            <fieldset id="empInfo" runat="server">
                <legend>Ա����Ϣ</legend>
                <div class="leftColumn">
                    <label for="tb_DeptCnName">
                        ���ţ�<span class="required">*</span></label>
                    <div>
                        <asp:TextBox ID="tb_DeptCnName" runat="server" 
                            ontextchanged="tb_DeptCnName_TextChanged"></asp:TextBox>
                        <input id="btn_ChooseDept" onclick="popupDeptChooser(this.id)" type="button" value="����" />
                    </div>
                    <label for="tb_SupervisorHrid">���ܹ���</label>
                    <div>
                        <asp:TextBox runat="server" ID="tb_SupervisorHrid"></asp:TextBox>
                    </div>
                    <label for="ddw_Duty">
                        ְλ��<span class="required">*</span></label>
                    <div>
                        <asp:DropDownList ID="ddw_Duty" runat="server" DataTextField="DutyCnName" DataValueField="DutyCode">
                        </asp:DropDownList>
                    </div>
                    <label for="ddw_EmpState">
                        Ա��״̬��</label>
                    <div>
                        <asp:DropDownList ID="ddw_EmpState" runat="server" DataTextField="Description" DataValueField="Code">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="rightColumn">
                    <div class="content">
                        <label for="tb_OfficeCall">
                            �칫�绰��</label>
                        <div>
                            <asp:TextBox ID="tb_OfficeCall" runat="server" MaxLength="20"></asp:TextBox>���ֻ�)
                            <asp:TextBox ID="tb_OfficeSubCall" runat="server" Columns="8" MaxLength="20"></asp:TextBox>
                        </div>
                        <label for="tbiInDate">
                            ��ְ���ڣ�</label>
                        <div class="clear">
                            <mzh:ToolbarCalendar ID="tbiInDate" ReadOnly="True" runat="server"></mzh:ToolbarCalendar>
                        </div>
                        <label for="chk_IsLeave">
                            �Ƿ���ְ��</label>
                        <div>
                            <asp:CheckBox ID="chk_IsLeave" runat="server" Text=""></asp:CheckBox>
                        </div>
                        <label for="tbiLeaveDate">
                            ��ְ���ڣ�</label>
                        <div class="clear">
                            <mzh:ToolbarCalendar ReadOnly="True" ID="tbiLeaveDate" runat="server" Width="120px">
                            </mzh:ToolbarCalendar>
                        </div>
                    </div>
                </div>
            </fieldset>
            <div class="hidden">
                <input id="tb_EmpDept" type="hidden" runat="server" />
                <label for="tb_EmpEnName">
                    Ӣ �� ����</label>
                <div>
                    <asp:TextBox ID="tb_EmpEnName" runat="server"></asp:TextBox>
                </div>
                <label for="ddw_UserState">
                    �û�״̬��</label>
                <div>
                    <asp:DropDownList ID="ddw_UserState" runat="server">
                        <asp:ListItem Value="A">����</asp:ListItem>
                        <asp:ListItem Value="U">����</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
    </form>
    <!--[if lt IE 7]>
    <script src="/aspnet_client/Shmzh.Web.UI/ie7.js" type="text/javascript"></script>
    <![endif]-->
</body>
</html>
