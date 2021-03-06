﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="Balancika.EmployeeInfo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
          
            $("#form1").validate({
                rules: {
                    '<%=txtEmployeeName.UniqueID%>': {
                        required: true
                    },
                    '<%=txtEmail.UniqueID%>': {
                        required:true,
                        email: true
                    },

                    '<%=txtEmployeeCode.UniqueID%>': {
                        required: true
                    }
                },
                messages: {
                    '<%=txtEmployeeName.UniqueID%>': {
                        required: "Company Name is required"
                    },
                    '<%=txtEmail.UniqueID%>': {
                        required: "Please enter email address",
                        email: "Please enter valid email address"
                    }
                }

            });
        });

    </script>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <section class="form-horizontal">
            <div class="box">

                <div class="box-header with-border">
                    <h3 class="box-title">Add /Edit Employee Information</h3>
                </div>
                <asp:Label ID="lblId" runat="server" Visible="False" Text=""></asp:Label>
                     <asp:Label ID="addlblId" runat="server" Visible="False" Text=""></asp:Label>
                <asp:Label ID="depID" runat="server" Visible="False" Text=""></asp:Label>
                     <asp:Label ID="desID" runat="server" Visible="False" Text=""></asp:Label>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtEmployeeCode" class="col-sm-4 control-label">Employee Code</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" name="txtEmployeeCode" id="txtEmployeeCode" placeholder="Code" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtEmployeeName" class="col-sm-4 control-label">Employee Name</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtEmployeeName" id="txtEmployeeName" placeholder="Name" runat="server" />
                            </div>

                        </div>
                    </div>
                   <div class="col-md-6">
                        <div class="form-group ">
                            <label for="designationDropDownList" class="col-sm-4 control-label">Designation</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server">
                                    <telerik:RadDropDownList ID="designationDropDownList"
                                        Skin="Bootstrap"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                       
                                        DefaultMessage="Select Designation">
                                    </telerik:RadDropDownList>

                                </telerik:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                     <div class="col-md-6">
                        <div class="form-group ">
                            <label for="departmentDropDownList" class="col-sm-4 control-label">Department</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                
                                    <telerik:RadDropDownList ID="departmentDropDownList" OnSelectedIndexChanged="departmentDropDownList_IndexChanged"
                                        Skin="Bootstrap"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Department">
                                    </telerik:RadDropDownList>

                              
                            </div>

                        </div>
                    </div>

                    
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtPhoneNo" class="col-sm-4 control-label">Phone Number</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtPhoneNo" id="txtPhoneNo" placeholder="Phone Number" runat="server" />
                            </div>

                        </div>
                    </div>
                     <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtMobile" class="col-sm-4 control-label">Mobile</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtMobile" id="txtMobile" placeholder="Mobile Number" runat="server" />
                            </div>

                        </div>
                    </div>
                    
                  

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddressLine1" class="col-sm-4 control-label">Address Line 1</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddressLine1" id="txtAddressLine1" placeholder="Address Line 1" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddressLine2" class="col-sm-4 control-label">Address Line 2</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddressLine2" id="txtAddressLine2" placeholder="Address Line 2" runat="server" />
                            </div>

                        </div>
                    </div>
                   
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="countryDropDownList" class="col-sm-4 control-label">Country</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                    <telerik:RadDropDownList ID="countryDropDownList"
                                        Skin="Bootstrap"
                                        runat="server" padding-left="20px"
                                        Width="100%"
                                        AutoPostBack="true"
                                        DefaultMessage="Select Country">
                                    </telerik:RadDropDownList>

                                </telerik:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtCity" class="col-sm-4 control-label">City</label>
                         <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtCity" id="txtCity" placeholder="City" runat="server" />
                            </div>

                              
                            </div>

                        </div>
                    
                    <div class="clearfix"></div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtZipCode" class="col-sm-4 control-label">Zip Code</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtZipCode" id="txtZipCode" placeholder="Zip Code" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtEmail" class="col-sm-4 control-label">Email</label>
                            <div class="col-xs-8">
                                <input type="email" class="form-control" name="txtEmail" id="txtEmail" data-error=" that email address is invalid" placeholder="Enter a valid email address" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="RadDatePicker1" class="col-sm-4 control-label">Date Of Birth</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik:RadDatePicker Skin="Bootstrap"  ID="RadDatePicker1" runat="server" Width="100%" SelectedDate='<%# System.DateTime.Today %>'></telerik:RadDatePicker>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="JoinRadDatePicker" class="col-sm-4 control-label">Join Date</label>
                            <div class="col-xs-8">
                                <%--<input type="email" class="form-control" id="txtUpdate" name="email" placeholder="Enter a valid email address" runat="server" />
                                --%>
                                <telerik:RadDatePicker Skin="Bootstrap" ID="JoinRadDatePicker" runat="server" Width="100%" SelectedDate='<%# System.DateTime.Today %>'></telerik:RadDatePicker>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkIsActive" runat="server" value="false" />
                                        <strong>Is Active</strong>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>


                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Employee Information" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
           
        </section>
    </form>
</asp:Content>
