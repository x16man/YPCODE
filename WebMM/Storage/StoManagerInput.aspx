<%@ Page Language="c#" CodeBehind="StoManagerInput.aspx.cs" Title="�ֿ����Աά��" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.StoManagerInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ֿ����Աά��</title>
    <script language="javascript">
        function CancelGo() {
            
            var url = "StoManagerBrowser.aspx?StoCode=" + <%= StoCode%>;
          
            document.location =url;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
        <tr>
            <td colspan="2">
                 <mzh:MzhToolbar ID="MzhToolbar1" runat="server" onitempostback="MzhToolbar1_ItemPostBack" 
                   >
                     <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="����" id="toolbarButtonAdd" autopostback="True">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="����" id="toolbarButtonedit" autopostback="True">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="CancelGo()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr style="height: 25">
            <td style="width: 20%">
                �ֿ���
            </td>
            <td style="width: 80%" align="left">
                <uc1:StorageDropdownlist ID="ddlSto" runat="server">
                </uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr style="height: 25">
            <td>
                ����Ա���
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlUser" runat="server">
                </uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td class="td_Submit" colspan="4">
                
            </td>
        </tr>
        
    </table>
    <asp:HiddenField ID="txtPKID" runat="server" />
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" CssClass="button" onmouseover="this.className='buttonMouseOver'"
                    onmouseout="this.className='button'"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="False" CssClass="button"
                    onmouseover="this.className='buttonMouseOver'" onmouseout="this.className='button'"
                  ></asp:Button>
    </div>
</asp:Content>
