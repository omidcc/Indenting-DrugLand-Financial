<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Balancika.CustomerList" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" runat="server">
    <section class="form-horizontal">
        <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Customer Info List</h3>
                </div>
            <div class="box-body">
                <div id="divCompanyTable" class="dataTables_wrapper form-inline dt-bootstrap">
                    
                    <div class="row">
                            <div class="col-sm-12">
                                <asp:Button class="btn" ID="btnAddNew" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Add New Customer Information" OnClick="btnAddNew_OnClick" />        
                            </div>
                            
                        </div>
               
         <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        
        
        
        
         <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="False" 
                                    AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                                    CssClass="table table-bordered table-hover dataTable" Skin="Bootstrap" 
                                    OnItemCommand="RadGrid1_OnItemCommand">
                                    <clientsettings>
                                        <scrolling allowscroll="True" usestaticheaders="True" />
                                    </clientsettings>
                                    <mastertableview>
                                        <Columns>
                                            <telerik:GridBoundColumn  DataField="CustomerId"  HeaderText="ID" UniqueName="colId" Display="False">
                                                
                                            </telerik:GridBoundColumn>
                                            
                                            <telerik:GridBoundColumn  DataField="CustomerName" HeaderText="Customer Name" UniqueName="colCustomerName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="CustomerCatagoryId" HeaderText="Customer Catagory" UniqueName="colCustomerCatagory">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.AddressLine1" HeaderText="Address Line 1" UniqueName="colAddressLine1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.AddressLine2" HeaderText="Address Line 2" UniqueName="colAddressLine2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.City" HeaderText="City" UniqueName="colCity">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.Phone" HeaderText="Phone" UniqueName="colPhone">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.Mobile" HeaderText="Mobile" UniqueName="colMobile">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.Email" HeaderText="Email" UniqueName="Email">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="aAddress.Web" HeaderText="Web" UniqueName="colWeb">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn  DataField="CreditLimit" HeaderText="Credit Limit" UniqueName="colCreditLimit">
                                                
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
        </section>
     </form>
</asp:Content>
