<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Temp.aspx.cs" Inherits="Balancika.Temp" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI.Skins" Assembly="Telerik.Web.UI.Skins, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="telerik1" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <telerik1:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik1:RadStyleSheetManager>
        <telerik1:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik1:RadAjaxManager>
        <telerik1:RadScriptManager ID="RadScriptManager1" runat="server"></telerik1:RadScriptManager>
        <telerik1:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0"
            GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource1" PageSize="10" Skin="Bootstrap">

            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView>
                <Columns>
                    <telerik1:GridBoundColumn DataField="Inner1.TestProp" HeaderText="Inner1.TestProp">
                    </telerik1:GridBoundColumn>
                    <telerik1:GridBoundColumn DataField="Inner1.Inner2.TestProp"
                        HeaderText="Inner1.Inner2.TestProp">
                    </telerik1:GridBoundColumn>
                    <telerik1:GridBoundColumn
                        DataField="Inner1.Inner2.Inner1.TestProp" HeaderText="Inner1.Inner2.Inner1.TestProp">
                    </telerik1:GridBoundColumn>
                    <telerik1:GridBoundColumn
                        DataField="Name" HeaderText="Name">
                    </telerik1:GridBoundColumn>

                </Columns>
            </MasterTableView>
        </telerik1:RadGrid>

    </form>
</asp:Content>
