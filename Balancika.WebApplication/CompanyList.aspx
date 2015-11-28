<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="Balancika.CompanyList" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI.Skins" Assembly="Telerik.Web.UI.Skins, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="telerik1" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">

        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title"><b>Company Information List</b></h3>
            </div>
            <div class="box-body">
                <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:Button class="btn" ID="btnAddNew" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Add New Company Information" OnClick="btnAddNew_OnClick" />
                        </div>
                        <div class="col-sm-6"></div>

                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <telerik1:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
                            </telerik1:RadStyleSheetManager>
                            <telerik1:RadAjaxManager ID="RadAjaxManager1" runat="server">
                            </telerik1:RadAjaxManager>
                            <telerik1:RadScriptManager ID="RadScriptManager1" runat="server"></telerik1:RadScriptManager>




                            <telerik1:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="False"
                                AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                                CssClass="table table-bordered table-hover dataTable" Skin="Bootstrap"
                                OnItemCommand="RadGrid1_OnItemCommand">
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <MasterTableView>
                                    <Columns>
                                        <telerik1:GridBoundColumn DataField="CompanyId" HeaderText="ID" UniqueName="colId" Display="False">
                                        </telerik1:GridBoundColumn>

                                        <telerik1:GridBoundColumn DataField="CompanyName" HeaderText="Company Name" UniqueName="colCompanyName">
                                        </telerik1:GridBoundColumn>

                                        <telerik1:GridBoundColumn DataField="CountryName" HeaderText="Country" UniqueName="colCountryName">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="AddressLine1" HeaderText="Address Line 1" UniqueName="colAddressLine1">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="AddressLine2" HeaderText="Address Line 2" UniqueName="colAddressLine2">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="City" HeaderText="City" UniqueName="colCity">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="Phone" HeaderText="Phone" UniqueName="colPhone">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="Mobile" HeaderText="Mobile" UniqueName="colMobile">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="Email" HeaderText="Email" UniqueName="colEmail">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="Web" HeaderText="Web" UniqueName="colWeb">
                                        </telerik1:GridBoundColumn>
                                        <telerik1:GridBoundColumn DataField="LogoPath" HeaderText="Logo Path" UniqueName="colLogoPath">
                                        </telerik1:GridBoundColumn>

                                        <telerik1:GridButtonColumn
                                            CommandName="btnSelect"
                                            HeaderText="Edit"
                                            SortExpression=""
                                            ButtonType="ImageButton"
                                            ImageUrl="Images/Edit.png"
                                            UniqueName="colEdit">
                                        </telerik1:GridButtonColumn>
                                        <telerik1:GridButtonColumn
                                            CommandName="btnDelete"
                                            ConfirmText="Are you sure you want to delete this record?"
                                            ConfirmDialogType="RadWindow"
                                            HeaderText="Delete"
                                            ConfirmTitle="Delete"
                                            ButtonType="ImageButton"
                                            ImageUrl="Images/delete.png"
                                            UniqueName="colDelete">
                                        </telerik1:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik1:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
