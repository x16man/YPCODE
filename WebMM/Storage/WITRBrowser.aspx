<%@ Page Language="c#" CodeBehind="WITRBrowser.aspx.cs" Title="������������" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="WebMM.Storage.WITRBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>������������</title>
    <link href="../CSS/Storage/WITRBrowser.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">    
   <table  class="mytable">
        <tr>
            <td>
                <table class="mytable">
                    <tr>
                        <td class="mytable_label">
                            ���벿�ţ�
                        </td>
                        <td class="mytable_content" align="left" >
                            <asp:TextBox ID="txtDeptName" runat="server" CssClass="input_txtDeptName input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                        <td class="mytable_label">
                            ���� �ˣ�
                        </td>
                        <td class="mytable_content" align="left">
                            <asp:TextBox ID="txtAuthorName" runat="server" CssClass="input_txtAuthorName input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="mytable_td">
                        <td nowrap>
                            ��;��
                        </td>
                        <td align="left">
                            <uc1:USWebControl ID="ddlUse" runat="server"></uc1:USWebControl>
                        </td>
                        <td>
                            Ҫ�����ڣ�
                        </td>
                        <td align="left">
                            <mzh:ToolbarCalendar ID="calcDate" ReadOnly="true" runat="server" SkinID="ABC" onserverchange="calcDate_ServerChange" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ���Ϸ��ࣺ
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlCategory" runat="server"></uc1:StorageDropdownlist>
                        </td>
                        <td>
                            ����״̬��
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlStatus" runat="server"></uc1:StorageDropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ��Ųֿ⣺
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlStorage" runat="server"></uc1:StorageDropdownlist>
                        </td>
                        <td>
                            ��ż�λ��
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlCon" runat="server"></uc1:StorageDropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ���ϱ�ţ�
                        </td>
                        <td align="left">
                            <table width="100%">
                                <tr>
                                    <td style="width:60%" > 
                                    <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" CssClass="input" SkinID="ABC"  Width="100%"></asp:TextBox>
                                    </td>
                                     <td style="width:40%">
                                        <asp:Button ID="btnCode" runat="server" Text="�Ƽ����" OnClick="btnCode_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                           
                            
                        </td>
                        <td class="mytable_td">
                            �������ƣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="input input_ItemName" SkinID="ABC"  Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV_ItemName" runat="server" Display="Dynamic" ErrorMessage="����ָ����������"
                                ControlToValidate="txtItemName">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ����ͺţ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemSpec" runat="server" CssClass="input_txtItemSpec input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                        <td class="mytable_td">
                            ��λ��
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlUnit" runat="server"></uc1:StorageDropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �ƹ����ԣ�
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlMB" runat="server"></uc1:StorageDropdownlist>
                        </td>
                        <td>
                            ABC���ࣺ
                        </td>
                        <td align="left">
                            <uc1:StorageDropdownlist ID="ddlABC" runat="server"></uc1:StorageDropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ���Ƽ۸�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemPrice" runat="server" CssClass="input_txtItemPrice input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                        <td class="mytable_td">
                            ����������
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemNum" runat="server" CssClass="input_txtItemNum input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ������
                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="input_txtRemark textarea" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ������Ϣ��
                        </td>
                        <td colspan="3" align="left">
                            <asp:TextBox ID="txtFeedBack" runat="server" TextMode="MultiLine" CssClass="input_txtFeedBack textarea" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="mytable_td_Submit" colspan="4">
                            <asp:HiddenField ID="txtDocCode" runat="server" />
                            <div class="hideen">
                            </div>
                            <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click"></asp:Button>
                            <asp:Button ID="btnClear" runat="server" Text="��������" OnClick="btnClear_Click"></asp:Button>
                            <asp:Button ID="btnRos" runat="server" Text="ת�ɽ����깺��" OnClick="btnRos_Click"></asp:Button>
                            <asp:Button ID="btnRefuse" runat="server" Text="�˻�" OnClick="btnRefuse_Click"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="false" OnClick="btnCancel_Click">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
                <table class="mytable">
                    <tr>
                        <td class="td_ItemLabel" style="width:20%">
                            <nobr>�������ƣ�</nobr>
                        </td>
                        <td style="width:25%">
                            <asp:TextBox ID="txtItemNameSearch" runat="server" CssClass="input_txtItemNameSearch input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                        <td class="td_ItemLabel" style="width:20%">
                            <nobr>����ͺţ�</nobr>
                        </td>
                        <td style="width:25%">
                            <asp:TextBox ID="txtItemSpecSearch" runat="server" CssClass="input_txtItemSpecSearch input" SkinID="ABC"  Width="100%"></asp:TextBox>
                        </td>
                        <td class="td_Search" style="width:10%">
                            <asp:Button ID="btnSearch" runat="server" Text="��ѯ������������" OnClick="btnSearch_Click">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="10%" highlightcolor="Gold"
                                selectedcolor="Blue" IdCell="0" selecttype="MultiSelect" AllowSorting="True"
                                PageSize="20" CssClass="datagrid" AutoGenerateColumns="False" BorderColor="#0099CC"
                                CellSpacing="1" BorderWidth="1px" CellPadding="3" name="MzhMultiSelectDataGrid">
                                <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                                <AlternatingItemStyle BackColor="#D8F4FF"></AlternatingItemStyle>
                                <ItemStyle BackColor="#F2F8FF"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" BackColor="#99CCFF"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="��������" SortExpression="Cat_Des">
                                        <ItemTemplate>
                                            <%#  Eval("Cat_Des") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���ϱ���" SortExpression="Code">
                                        <ItemTemplate>
                                            <%#  Eval("Code")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��������" SortExpression="CnName">
                                        <ItemTemplate>
                                            <%#  Eval("NewCnName")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����ͺ�" SortExpression="Special">
                                        <ItemTemplate>
                                            <%#  Eval("NewSpecial")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��λ" SortExpression="Unit_Des">
                                        <ItemTemplate>
                                            <%#  Eval("Unit_Des")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
