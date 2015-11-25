<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BankAccoutsList.aspx.cs" Inherits="Balancika.BankAccoutsList" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <section class="form-horizontal">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Bank Account Lists</h3>
                </div>
                <div class="box-body">
                    <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button class="btn" ID="btnAddNew" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Add New Bank Account" OnClick="btnAddNew_OnClick" />        
                            </div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                            </div>
                            <div class="col-sm-6"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="False" 
                                    AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                                    CssClass="table table-bordered table-hover dataTable" Skin="Bootstrap" 
                                    OnItemCommand="RadGrid1_OnItemCommand">
                                    <clientsettings>
                                        <scrolling allowscroll="True" usestaticheaders="True" />
                                    </clientsettings>
                                    <mastertableview>
                                        <Columns>
                                            <telerik:GridBoundColumn  DataField="BankAccountId"  HeaderText="Bank Account ID" UniqueName="colId" Display="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="BranchName" HeaderText="Branch Name" UniqueName="colName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="AccountNo" HeaderText="Account No" UniqueName="colName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="AccountTitle" HeaderText="Account Title" UniqueName="colName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="AccountType" HeaderText="Account Type" UniqueName="colName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="OpeningDate" HeaderText="Opening Date" UniqueName="colName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="IsActive" HeaderText="Is Active" UniqueName="colName">
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
                                    </mastertableview>
                                </telerik:RadGrid>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
