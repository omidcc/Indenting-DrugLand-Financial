<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SupplierInfo.aspx.cs" Inherits="Balancika.SupplierInfo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script>
        $(document).ready(function () {

            $("#form1").validate({

                rules: {

                    '<%=txtSupplierName.UniqueID%>': {
                        required: true,
                    },
                    '<%=txtTotalCredit.UniqueID%>': {
                        required: true

                    },
                    '<%=txtTotalDebit.UniqueID%>': {
                        required: true

                    },
                    
                    '<%=txtEmail.UniqueID%>': {
                        required: true,
                        email: true

                    }
                    

                },
                messages: {


                    '<%=txtSupplierName.UniqueID%>': {
                        required: "Please enter supplier name",


                    },
                    '<%=txtEmail.UniqueID%>': {
                        required: "Please Enter Email Address",
                        email: "Valid Email Address Please"

                    },
                    '<%=txtTotalCredit.UniqueID%>': {
                        required: "Total Credit is Required"

                    },
                    '<%=txtTotalDebit.UniqueID%>': {
                        required: "Total Debit is Required"

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
                    <h3 class="box-title">Add Supplier Information</h3>
                     <asp:Label ID="lblId" runat="server" Visible="False" Text=""></asp:Label>
                    <asp:Label ID="addlblId" runat="server" Visible="False" Text=""></asp:Label>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtSupplierName" class="col-sm-4 control-label">Supplier Name</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" id="txtSupplierName" name="txtSupplierName" placeholder="Supplie Name" runat="server" clientidmode="Static" />
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
                    <div class="clearfix"></div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtAddressLine2" class="col-sm-4 control-label">Address Line 2</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtAddressLine2" id="txtAddressLine2" placeholder="Address Line 2" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
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
                                        DefaultMessage="Select Country"
                                        OnItemSelected="countryDropDownList_ItemSelected"
                                        OnSelectedIndexChanged="countryDropDownList_SelectedIndexChanged">
                                    </telerik:RadDropDownList>

                                </telerik:RadAjaxPanel>
                            </div>

                        </div>
                    </div>
                   
                    <div class="col-sm-6">
                        <div class="form-group">
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
                     <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtPhone" class="col-sm-4 control-label">Phone</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtPhone" id="txtPhone" placeholder="Phone" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtMobile" class="col-sm-4 control-label">Mobile</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtMobile" id="txtMobile" placeholder="Mobile" runat="server" />
                            </div>

                        </div>
                    </div>
                     <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtEmail" class="col-sm-4 control-label">Email</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtEmail" id="txtEmail" placeholder="Email" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtWeb" class="col-sm-4 control-label">Web</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtWeb" id="txtWeb" placeholder="Web Address" runat="server" />
                            </div>

                        </div>
                    </div>



                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtTotalDebit" class="col-sm-4 control-label">Total Debit</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtTotalDebit" id="txtTotalDebit" placeholder="Total Debit" runat="server" />
                            </div>

                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtTotalCredit" class="col-sm-4 control-label">Total Credit</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtTotalCredit" id="txtTotalCredit" placeholder="Total Credit" runat="server" />
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
                            <asp:Button ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Supplier Information" OnClientClick="return validate()" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" type="button" value="Clear Information" onserverclick="btnClear_Click" />

                        </div>
                    </div>
                </div>

            </div>

            
        </section>
    </form>

</asp:Content>
