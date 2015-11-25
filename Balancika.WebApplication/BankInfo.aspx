<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BankInfo.aspx.cs" Inherits="Balancika.BankInfo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="telerikskin" Namespace="Telerik.Web.UI.Skins" Assembly="Telerik.Web.UI.Skins, Version=2015.1.225.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    <script>
        
        $(document).ready(function () {
            $('#bankTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "scrollX": true
            });
            $("#form1").validate({
                
                rules: {

                    '<%=txtBankCode.UniqueID%>': {
                        required: true,
                        minlength: 3

                    },
                    '<%=txtBankName.UniqueID%>': {
                        required: true
                    }
                },
                messages: {

                    '<%=txtBankCode.UniqueID%>': {
                        required: "Please Enter Code",
                    },
                    '<%=txtBankName.UniqueID%>': {
                        required: "Enter Bank Name"
                    },
                   
                    '<%=txtEmail.UniqueID%>': {
                        email: "Please enter valid email address"
                    }
                }
            });
         });
    </script>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <section class="form-horizontal">
            <div class="box">

                <div class="box-header with-border">
                    <h3 class="box-title">Add/Edit Bank Information</h3>
                    <asp:Label ID="lblId" runat="server" Visible="False" Text=""></asp:Label>
                </div>
                <div class="box-body">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtBankCode" class="col-sm-4 control-label">Bank Code</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" width="60px" name="txtBankInfoCode" id="txtBankCode" placeholder="Bank Code" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="txtBankName" class="col-sm-4 control-label">Bank Name</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtBankInfoName" id="txtBankName" placeholder="Bank Name" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>

                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtContactPerson" class="col-sm-4 control-label">Contact Person</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtContactPerson" id="txtContactPerson" placeholder="Contact Person" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtDesignation" class="col-sm-4 control-label">Contact Designation</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtDesignation" id="txtDesignation" placeholder="Designation" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtContactNo" class="col-sm-4 control-label">Contact No</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" width="60px" name="txtContactNo" id="txtContactNo" placeholder="Contact No" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group ">
                            <label for="txtEmail" class="col-sm-4 control-label">Email</label>
                            <div class="col-xs-8">
                                <input type="email" class="form-control" name="txtEmail" id="txtEmail" data-error=" that email address is invalid" placeholder="Email" runat="server" />
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>

                   
                   
                    
                    <div class="col-md-6">
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkIsActive" runat="server" value="true" />
                                        <strong>Is Active</strong>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>


                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button class="btn" ID="button1" runat="server" ClientIDMode="Static" CssClass="btn btn-success" Text="Save Bank Information" OnClick="btnSave_Click" />
                            <input class="btn btn-warning" runat="server" onserverclick="btnClear_Click" type="button" value="Clear Information" />
                        </div>
                    </div>
                </div>

            </div>
            
        </section>
    </form>
</asp:Content>
