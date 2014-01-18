<%@ Page Language="c#" CodeBehind="YCLGroupBrowser.aspx.cs" Title="原材料收发" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="WebMM.Storage.YCLGroupBrowser"  %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>原材料收发</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">

        //新建
        function AddItem() {
            document.getElementById("<%=btnAdd.ClientID%>").click();
        }
        //编辑
        function editItem() {
            document.getElementById("<%=btnEdit.ClientID%>").click();
        }

        //删除
        function deleteItems() {
            if (!confirm("真的删除吗?")) {
                return false;
            }
            else {
                document.getElementById("<%=btn_delete.ClientID%>").click();
            }
        }
        //确认删除对话框.
        function confirmDelete() {
            var result = window.confirm("在导入的时间范围内已经存在记录,请先删除以后再进行导入!是否要自动删除?");
            var resultNode = document.getElementById('txtConfirmResult');
            resultNode.value = result;
            if (result == 'true') {
                var upload = document.getElementById('btnUpload');
                alert(upload);
                upload.click();
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SkinID="ABC" OnItemPostBack="MzhToolbar1_ItemPostBack">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="AddItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="deleteItems()">
                    </mzh:toolbarbutton>
                    <mzh:ToolbarLabel cellpadding="0" labelclass="labelCell" cellspacing="0" itemid="toolbarLabel2"
                        tableclass="labelTable" text="开始日期：" id="toolbarLabel1">
                    </mzh:ToolbarLabel>
                    <mzh:ToolbarCalendar ID="txtStartDate" ReadOnly="true" runat="server" Skinid="test" />
                    <mzh:ToolbarLabel cellpadding="0" labelclass="labelCell" cellspacing="0" itemid="toolbarLabel2"
                        tableclass="labelTable" text="结束日期：" id="toolbarLabel2">
                    </mzh:ToolbarLabel>
                    <mzh:ToolbarCalendar ID="txtEndDate" ReadOnly="true" runat="server" Skinid="test" />
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="search" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                        isshowtext="True" IconClass="query" hasicon="True" text="查询" id="toolbarButton1">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="managertable">
                    <tr>
                        <td colspan="5" align="left">
                            <igtbl:UltraWebGrid ID="UG_YCLDetail" runat="server" Width="100%" imagedirectory="/ig_common/Images/"
                                OnDataBinding="UG_YCLDetail_DataBinding">
                                <DisplayLayout AllowDeleteDefault="Yes" AllowSortingDefault="OnClient" RowHeightDefault="20px"
                                    Version="4.00" SelectTypeRowDefault="Single" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
                                    HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
                                    RowSelectorsDefault="No" Name="UGxYCLDetail" CellClickActionDefault="RowSelect"
                                    AllowUpdateDefault="Yes">
                                    <AddNewBox Hidden="False">
                                        <Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                    </AddNewBox>
                                    <Pager>
                                        <Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                        </Style>
                                    </Pager>
                                    <HeaderStyleDefault BorderStyle="Solid" HorizontalAlign="Left" BackColor="LightGray">
                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                        </BorderDetails>
                                    </HeaderStyleDefault>
                                    <GroupByRowStyleDefault BorderColor="Window" BackColor="Control">
                                    </GroupByRowStyleDefault>
                                    <FrameStyle Width="100%" BorderWidth="1px" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif"
                                        BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
                                    </FrameStyle>
                                    <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                        <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                                        </BorderDetails>
                                    </FooterStyleDefault>
                                    <GroupByBox>
                                        <Style BorderColor="Window" BackColor="ActiveBorder">
                                            </Style>
                                    </GroupByBox>
                                    <EditCellStyleDefault BorderWidth="0px" BorderStyle="None">
                                    </EditCellStyleDefault>
                                    <RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
                                        <Padding Left="3px"></Padding>
                                        <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                                    </RowStyleDefault>
                                </DisplayLayout>
                                <Bands>
                                    <igtbl:UltraGridBand>
                                    </igtbl:UltraGridBand>
                                </Bands>
                            </igtbl:UltraWebGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            上传Excel:
                        </td>
                        <td colspan="4">
                            <table width="100%">
                                <tr>
                                    <td style="width:25%">
                                        <input id="uploadFile" type="file" size="50" runat="server" 
                                             />
                                    </td>
                                    <td style="width:20%">
                                        <asp:Button ID="btnUpload" runat="server" Text="上传"
                                             OnClick="btnUpload_Click"></asp:Button>
                                    </td>
                                    <td style="width:30%">
                                        <asp:CheckBox ID="CheckBox_IsOverWrite" runat="server" Text="覆盖原有时间段的记录"></asp:CheckBox>
                                    </td>
                                    <td style="width:25%" align="left">
                                        <div id="Action_Export" class="DivActive ButtonExport">
                                            <a href="../Templates/template.xls" title="EXCEL导入的模板">模板下载</a></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:DataGrid ID="DataGrid1" runat="server" CssClass="datagrid">
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:HiddenField ID="txtConfirmResult" runat="server" />
        <asp:HiddenField ID="tb_SelectedArray" runat="server" />
        <asp:Button ID="btnQuery" runat="server" Text="Button"></asp:Button>
        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btnEdit" runat="server" Text="Select" OnClick="btnEdit_Click"></asp:Button>
        <asp:Button ID="btnAdd" runat="server" Text="Button" OnClick="btnAdd_Click"></asp:Button>
    </div>
</asp:Content>
