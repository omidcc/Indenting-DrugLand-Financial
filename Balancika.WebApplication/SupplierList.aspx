<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="Balancika.SupplierList" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <section class="form-horizontal">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title"><b>Supplier Information List</b></h3>
                </div>
                <div class="box-body">
                    <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">

                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Button class="btn" ID="btnAddNew" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Add New a Information" OnClick="btnAddNew_OnClick" />
                            </div>

                        </div>


                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            
                            <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
                            </telerik:RadStyleSheetManager>
                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                            </telerik:RadAjaxManager>
                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                
                            </telerik:RadScriptManager>




                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="False"
                                AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                                CssClass="table table-bordered table-hover dataTable" Skin="Bootstrap"
                                OnItemCommand="RadGrid1_OnItemCommand">
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="SupplierId" HeaderText="ID" UniqueName="colId" Display="False">
                                            
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="SupplierName" HeaderText="Supplier Name" UniqueName="colSupplierName">
                                            
                                        </telerik:GridBoundColumn>


                                        <telerik:GridBoundColumn DataField="AddressLine1" HeaderText="Address Line 1" UniqueName="colAddressLine1">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AddressLine2" HeaderText="Address Line 2" UniqueName="colAddressLine2">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="City" HeaderText="City" UniqueName="colCity">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CountryName" HeaderText="Country" UniqueName="colCountryName">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Phone" HeaderText="Phone" UniqueName="colPhone">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Mobile" HeaderText="Mobile" UniqueName="colMobile">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Email" HeaderText="Email" UniqueName="colEmail">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Web" HeaderText="Web" UniqueName="colWeb">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TotalDebit" HeaderText="Total Debit" UniqueName="colTotalDebit">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TotalCredit" HeaderText="TotalCredit" UniqueName="colTotalCredit">
                                            
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Balance" HeaderText="Balance" UniqueName="colBalanceName">
                                            
                                        </telerik:GridBoundColumn>

                                        <telerik:GridButtonColumn
                                            CommandName="btnSelect"
                                            HeaderText="Edit"
                                            SortExpression=""
                                            ButtonType="ImageButton"
                                            ImageUrl="Images/Edit.png"
                                            UniqueName="colEdit">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn
                                            CommandName="btnDelete"
                                            ConfirmText="Are you sure you want to delete this record?"
                                            ConfirmDialogType="RadWindow"
                                            HeaderText="Delete"
                                            ConfirmTitle="Delete"
                                            ButtonType="ImageButton"
                                            ImageUrl="Images/delete.png"
                                            UniqueName="colDelete">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                </div>
            
        </section>
    </form>
</asp:Content>
