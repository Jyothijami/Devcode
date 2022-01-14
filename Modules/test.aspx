<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Modules_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

   
    <%-- <script type="text/javascript">
         $(document).ready(function () {
             $('#<%= hai1.ClientID %>').DataTable();
    });
</script>--%>


   


      <script type="text/javascript">
          function CallButtonEvent() {
              alert('Button clicked.');
          }
    </script>
     <%--   <script type="text/javascript">

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                createDataTable();
            });

            createDataTable();

            function createDataTable() {
                $('#<%= hai1.ClientID %>').DataTable();
       }
  </script>--%>


           <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
        <ContentTemplate>
              <%--<script type="text/javascript" lang="javascript">
                  var prm = Sys.WebForms.PageRequestManager.getInstance();
                  if (prm != null) {
                      prm.add_endRequest(function (sender, e) {
                          if (sender._postBackSettings.panelsToUpdate != null) {
                              $('#<%= hai1.ClientID %>').DataTable();
            }
        });
    };
            </script>--%>

   
       
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="CallButtonEvent()"  />


                <div class="hai">

              <asp:GridView ID="hai1" CssClass="table table-bordered" OnPreRender="hai1_PreRender" runat="server" OnRowDataBound="hai1_RowDataBound" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>

                    <asp:BoundField DataField="Architect_Id" HeaderText="Sl.No" SortExpression="Architect_Id" />
                    <asp:BoundField DataField="Architect_Name" HeaderText="Architect Name" SortExpression="Architect_Name" />
                    <asp:BoundField DataField="Architect_Mobile" HeaderText="Mobile" SortExpression="Architect_Mobile" />
                    <asp:BoundField DataField="Architect_Email" HeaderText="Email" SortExpression="Architect_Email" />
                    <asp:BoundField DataField="Architect_Address" HeaderText="Address" SortExpression="Architect_Address" />

                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Architect_Master]"></asp:SqlDataSource>

                </div>
               <script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>

             <script type="text/javascript">
                 $(document).ready(function () {
                    // fnPageLoad();
                 });
                 function fnPageLoad() {
                     $('#<%= hai1.ClientID %>').prepend($("<thead></thead>").append($('#<%= hai1.ClientID %>').find("tr:first"))).DataTable({
                bSort: true,
                dom: '<"html5buttons"B>lTfgitp',
                lengthChange: false,
                pageLength: 5,
                buttons: [],
                bStateSave: true
            });
        }
             </script>
       

      


    </div>



            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>

