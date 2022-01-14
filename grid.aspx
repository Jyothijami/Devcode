<%@ Page Language="C#" AutoEventWireup="true" CodeFile="grid.aspx.cs" Inherits="grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>

   

      <script type="text/ecmascript" src='<%= ResolveUrl("~/js/BlockUi.js") %>'></script>

    <%--<script type="text/javascript">
        $('#<%= btnSubmit.ClientID%>').click(function () {
            $.blockUI({
                message: "<h3>Processing, Please Wait...</h3>",
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });

        });
    </script>--%>
       <script type="text/javascript">
           $(document).ready(function () {
               $('#<%= btnSubmit.ClientID%>').click(function () {
                   $.blockUI({
                       message: '<h1>Auto-Unblock!</h1>',
                       timeout: 2000
                   });
               });
           });

    </script>


    
             <script type="text/javascript">
                 $(document).ready(function () {
                     $('#<%= btnSearch.ClientID %>').click(function () {
                         $.blockUI({ message: 'Just a momeqweqwent...' });

                         setTimeout(function () {
                             $.unblockUI({
                                 onUnblock: function () { alert('onUnblock'); }
                             });
                         }, 2000);
                     });
                 });
    </script>


   
     <%--  <script type="text/javascript">
                $(document).ready(function () {
                    $('#<%= GridView2.ClientID %>').DataTable();
                });
        </script>--%>
   <%-- <script type="text/javascript">
    // JavaScript function to call inside UpdatePanel
        function jScript() {
           $('#<%= GridView2.ClientID %>').DataTable();
        };
</script>--%>


   <%--  <script type="text/javascript">
    //On Page Load
    $(function () {
       $('#<%= GridView2.ClientID %>').DataTable();
   });
 
    //On UpdatePanel Refresh
   
</script>--%>



    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>



</head>
<body onload="javascript:max()">
    <form id="form1" runat="server">
    <div>
      
        <asp:ScriptManager runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
    <ContentTemplate>
       
        <div class="">
            <%--<script type="text/javascript">

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        createDataTable();
    });

   // createDataTable();

    function createDataTable() {
        $('#<%= GridView2.ClientID %>').DataTable();
    }
</script>--%>

         <%--   <script type="text/javascript" lang="javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
        prm.add_endRequest(function (sender, e) {
            if (sender._postBackSettings.panelsToUpdate != null) {
                $('#<%= GridView2.ClientID %>').DataTable();
            }
        });
    };
            </script>--%>




<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Rect" OnClick="btnSearch_Click">
                </asp:Button>


            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Block" />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="false">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Name") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Country") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No Record Available
            </EmptyDataTemplate>
        </asp:GridView>
            
            <table class="auto-style1">
                <tr>
                    <td>To</td>
                    <td>
                        <asp:TextBox ID="txtto" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Subject</td>
                    <td>
                        <asp:TextBox ID="txtsubject" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Message</td>
                    <td>
                        <asp:TextBox ID="txtmessage" runat="server"></asp:TextBox>
                        <asp:Button ID="btnsend" runat="server" OnClick="btnsend_Click" Text="Send" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
        <%--    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView2_RowDataBound" OnPreRender="GridView2_PreRender">
                <Columns>
                    <asp:BoundField DataField="Architect_Id" HeaderText="Architect_Id" SortExpression="Architect_Id" />
                    <asp:BoundField DataField="Architect_Name" HeaderText="Architect_Name" SortExpression="Architect_Name" />
                    <asp:BoundField DataField="Architect_Mobile" HeaderText="Architect_Mobile" SortExpression="Architect_Mobile" />
                    <asp:BoundField DataField="Architect_Email" HeaderText="Architect_Email" SortExpression="Architect_Email" />
                    <asp:BoundField DataField="Architect_Address" HeaderText="Architect_Address" SortExpression="Architect_Address" />

                       <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="dele"  OnClick="lbtnDelete_Click"></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=103.120.178.184;Initial Catalog=AlumilTesting;User ID=sa;Password=haiamma@1237;Max Pool Size=3000" ProviderName="System.Data.SqlClient" SelectCommand="archi" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

            --%>

        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />




        <asp:DropDownList ID="DDLPO" AutoPostBack="true" OnSelectedIndexChanged="DDLPO_SelectedIndexChanged" runat="server"></asp:DropDownList>


        <asp:CheckBoxList ID="cblpo" DataTextField="Quotation_No" DataValueField="Quotation_Id" RepeatDirection="Horizontal" RepeatColumns="10" runat="server" AutoPostBack="true"></asp:CheckBoxList>




        <asp:GridView ID="GridView3" AutoGenerateColumns="false" runat="server">


              <Columns>
        <asp:BoundField HeaderText="Contact Name" DataField="QuotationDet_Id" />
        <asp:BoundField HeaderText="Country" DataField="Quotation_Id" />
             </Columns>

        </asp:GridView>






























        

    </ContentTemplate>
</asp:UpdatePanel>

        

    




         <asp:GridView ID="gvmatana" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" >
                                <Columns>
                                 
                                    <asp:BoundField DataField="ITEMCODE" HeaderText="ItemCode" />
                                    <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:BoundField DataField="PlantId" HeaderText="Plant" />
                                    <asp:BoundField DataField="StoragelocId" HeaderText="Store" />
                                    <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                                    <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                                 
                                </Columns>
                                <EmptyDataTemplate>
                                    <span style="color: #CC0000">No Data Found</span>
                                </EmptyDataTemplate>
                            </asp:GridView>



        <asp:FileUpload ID="FileUpload1" type="file" CssClass="styled" runat="server" />
       <asp:Button ID="btnfileUpload" Text="Upload" CssClass="btn btn-danger" OnClick="btnfileUpload_Click" runat="server" />
 






    </div>
    </form>
</body>
</html>
