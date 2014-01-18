<%@ Page Language="c#" CodeBehind="PurposeBrowser.aspx.cs" Title="��;ά��" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.PurposeBrowser"   %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>��;ά��</title>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" class="table_toolbar" cellspacing="0" width="100%">
        <tr>
            <td class="td_toolbar">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-018" SkinID="ABC"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click" OnItemPostBack="MzhToolbar1_OnItemPostBack" CheckBoxListRepeatColumns="5">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="�½�" id="toolbarButtonadd" onclick="addItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="�༭" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="icon" hasicon="True" text="����" id="toolbarButtoncopy" onclick="copyItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="delete" hasicon="True" text="ɾ��" id="toolbarButtondelete" onclick="deleteItems()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparato1" itemid="toolbarSeparator2"></mzh:toolbarseparator>
                    <mzh:toolbarcheckbox itemid="IncludeDisable" autopostback="True" cellpadding="0" checked="False"  CausesValidation="False"
                    cellspacing="0" tableclass="labelTable" text="������Ч��" id="tbiIncludeDisable">
                </mzh:toolbarcheckbox>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" IdCell="0" AllowSorting="True" SelectType="SingleSelect"
                    MultiPageShowMode="DropListMode" AllowPaging="true" AutoGenerateColumns="False" ShowPageSize="true"
                    PageSize="<%$ AppSettings:pageSize %>" name="MzhMultiSelectDataGrid" OnPageIndexChanged="DataGrid1_PageIndexChanged"
                    OnSortCommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Classify" HeaderText="��;���">
                            <ItemStyle Width="20%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="thisYear" HeaderText="���">
                            <ItemStyle Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Code" HeaderText="��;����">
                            <ItemStyle Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProjectCode" HeaderText="���̱��">
                            <ItemStyle Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="��;">
                            <ItemStyle Width="20%" CssClass="left" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TargetAcc" HeaderText="Ŀ���Ŀ">
                            <ItemStyle Width="10%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="�Ƿ�������">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkFlag" runat="server" Enabled="False" Checked='<%# (int)Eval("Flag")==1?true:false %>'>
                                </asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="�Ƿ���Ч">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEnable" runat="server" Enabled="False" Checked='<%# (int)Eval("Enable")==1?true:false %>'>
                                </asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="ɾ��" Width="0px" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:TextBox ID="tb_SelectedArray" runat="server" Width="0px"></asp:TextBox>
    </div>

    <script language="javascript" type="text/javascript">


       
        //�½�
		function addItem()
		{
		    
		        document.location="PurposeInput.aspx";	
		    				
		}
			
        //�༭
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "PurposeInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��б༭��");
            }
        }

        //ɾ��
        function deleteItems() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null && <%=DataGrid1.ClientID%>_obj.getSelectedArray() != "") {
                if (confirm("ȷ��Ҫɾ��ѡ�������ݣ�")) {
                    document.getElementById("<%=tb_SelectedArray.ClientID%>").value = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
                    document.getElementById("<%=btn_delete.ClientID%>").click();
                }
            }
            else {
                alert("����ѡ�м�¼���ٽ���ɾ����");
            }
        }

        //����
        function copyItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "PurposeInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��и��ƣ�");
            }
        }
    </script>

</asp:Content>
