<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="JournalMasterList.aspx.cs" Inherits="Balancika.JournalMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $('#journalMasterTable').DataTable({
                "paging": true,
                "lengthChange": true,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "scrollX": true
            });
           
         
        });

    </script>

    <div class="box">
        <div class="box-header with-border">
            <h3 class="box-title">Journal List</h3>
        </div>
        <div class="box-body">
            <div id="divjournalTable" class="dataTables_wrapper form-inline dt-bootstrap">
                <div class="row">
                    <div class="col-sm-6"></div>
                    <div class="col-sm-6"></div>
                </div>
                <div class="box-body">
                    <div class="col-sm-12">
                        <table id="journalMasterTable" class="table table-bordered table-hover dataTable">
                            <thead>
                                <tr role="row">
                                    <th>Company Name</th>
                                    <th>Address</th>
                                    <th>Phone Number</th>
                                    <th>Email</th>
                                    <th>Web Address</th>
                                    <th>Logo Path</th>
                                    <th>Update By</th>
                                    <th>Update Date</th>
                                    <th>Is Active</th>
                                </tr>
                            </thead>
                            <tbody id="journalMasterTableBody" runat="server">
                            </tbody>
                            <tfoot>
                            </tfoot>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
