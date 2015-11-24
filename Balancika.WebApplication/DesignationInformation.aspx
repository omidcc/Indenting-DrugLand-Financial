﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DesignationInformation.aspx.cs" Inherits="Balancika.DesignationInformation" enableEventValidation="false" %>
<%@ Register TagPrefix="telerik1" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI.Skins" Assembly="Telerik.Web.UI.Skins, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
     <h1>Employee Designation</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <script>
          $(document).ready(function () {
   

        });

    </script>
    
    <form id="form1" runat="server">

    <telerik1:RadScriptManager ID="RadScriptManager1" runat="server"></telerik1:RadScriptManager>
    <section class="form-horizontal">
        <div class="box">

            <div class="box-header with-border">
                <h3 class="box-title">Add /Edit Designation</h3>
            </div>
             <asp:Label ID="lblId" runat="server" Visible="False" Text=""></asp:Label>
            <div class="box-body">

                <div class="col-md-6">
                    <div class="form-group ">
                        <label for="txtDesignationName" class="col-sm-4 control-label">Designation</label>
                       <div class="col-xs-8">
                            <input type="text" class="form-control" id="txtDesignationName" name="txtDesignation" placeholder="Designation" runat="server" />

                        </div>

                    </div>
                </div>
                <%--<div class="clearfix"></div>--%>

                <div class="col-md-6">
                    <div class="form-group ">
                        <label for="departmentIdRadDropDownList" class="col-sm-4 control-label">Department</label>
                        <div class="col-xs-8">
                            <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true" address" runat="server" />
                            --%>
                           
                                <telerik1:RadDropDownList runat="server" ID="departmentIdRadDropDownList"
                                    name="departmentIdRadDropDownList"
                                    Skin="Bootstrap"
                                     padding-left="20px"
                                    Width="100%"
                                    CausesValidation="false"
                                    AutoPostBack="true" 
                                    OnSelectedIndexChanged="departmentIdRadDropDownList_SelectedIndexChanged">
                                </telerik1:RadDropDownList>

                           
                        </div>

                    </div>
                </div>
                <div class="clearfix"></div>

              <%--  <div class="col-md-6">
                    <div class="form-group ">
                        <label for="RadDatePicker1" class="col-sm-4 control-label">Update Date</label>
                        <div class="col-xs-8">
                            <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                       
                            <telerik1:RadDatePicker CssClass="form-control" ID="RadDatePicker1" runat="server" Width="100%"></telerik1:RadDatePicker>
                        </div>

                    </div>
                </div>--%>

                

              <%--  <div class="col-md-6">
                    <div class="form-group ">
                        <label for="txtUpdateBy" class="col-sm-4 control-label">Update By</label>
                        <div class="col-xs-8">
                            <input type="text" class="form-control" id="txtUpdateBy" name="txtUpdateBy" placeholder="Update By" runat="server" />

                        </div>

                    </div>
                </div>--%>

                <div class="col-md-6">
                    <div class="form-group">
                        <div class="col-sm-offset-4 col-sm-8">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="chkIsActive" runat="server" value="false" />
                                    <strong>Is Active ?</strong>
                                </label>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="clearfix"></div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                     <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Designation"  onclick="btnSave_Click" />
                        <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                    </div>
                </div>

            </div>
        </div>
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">Designation List</h3>
            </div>
            <div class="box-body">
                <telerik1:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="False" 
                                    AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                                    CssClass="table table-bordered table-hover dataTable" Skin="Bootstrap" 
             
                                    OnItemCommand="RadGrid1_OnItemCommand">
                                    <clientsettings>
                                        <scrolling allowscroll="True" usestaticheaders="True" />
                                    </clientsettings>
                                    <mastertableview>
                                        <Columns>
                                            <telerik1:GridBoundColumn  DataField="DesignationId"  HeaderText="ID" UniqueName="colId" Display="False">
                                                
                                            </telerik1:GridBoundColumn>
                                            
                                            <telerik1:GridBoundColumn  DataField="Designation" HeaderText="Designation" UniqueName="colCustomerName">
                                            </telerik1:GridBoundColumn>
                                            <telerik1:GridBoundColumn  DataField="DepartmentId" HeaderText="DepartmentId" UniqueName="colDepartmentId">
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
                                    </mastertableview>
                                </telerik1:RadGrid>
                
            </div>
            </div>
    </section>
        </form>
</asp:Content>
