<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Modules_HR_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
     <script type="text/javascript">
         $(document).ready(function () {
             //fnPageLoad();
         });
         function fnPageLoad() {
             $('#<%=hai.ClientID%>').prepend($("<thead></thead>").append($('#<%=hai.ClientID%>').find("tr:first"))).DataTable({

                bSort: true,
                dom: '<"html5buttons"B>lTfgitp',
                //lengthChange: false,
                pageLength: 10,

                bStateSave: true,
                order: [[0, 'desc']],
            });
        }
</script>
        <!-- Page header -->
        <div class="page-header">
            <div class="page-title">
                <h3>User Mangement</h3>
            </div>
        </div>

   <div class="clearfix">
     <div class="btn-group">
				                        <span  class="btn btn-danger btn-icon"><i class="icon-user"></i></span>
			                                <asp:Button ID="btnAddnew" CssClass="btn btn-danger" runat="server" Text="Add New" OnClick="btnAddnew_Click" />
     </div>

       <div class="btn-group">
				                        <span  class="btn btn-primary btn-icon"><i class="icon-settings"></i></span>
			                                <asp:Button ID="btnPermissions" CssClass="btn btn-primary" runat="server" Text="Permissions" OnClick="btnPermissions_Click"  />
     </div>



       </div>
       
   
   <div class="panel">
       <div class="panel-body">
        <!-- /page header -->
         <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
        <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>

    <div class="datatable-tasks">
    
        <asp:GridView ID="hai" runat="server" AutoGenerateColumns="False" CssClass ="table table-bordered"
             DataSourceID="SqlDataSource1" >
           
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="Id">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>

                    <HeaderStyle Width="100px" HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="User Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
              
                <asp:BoundField DataField="PassWord" HeaderText="Password"></asp:BoundField>
                <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                     <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/HR/UserDetails.aspx?Cid=" + Eval("UserId") %>'><i class="icon-wrench2"></i></asp:LinkButton>
               </span> </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>


                  <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center" >
                 <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
               </span> </ItemTemplate>

                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

            </asp:TemplateField>

            </Columns>
          
            <EmptyDataTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("UserName") %>'></asp:LinkButton>
                <br />
                No Data Exist!
            </EmptyDataTemplate>
          
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SP_UTY_USER_MASTER" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblSearchItemHidden" DefaultValue="0" Name="SearchItem" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblSearchValueHidden" DefaultValue="0" Name="SearchValue" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
   </div>
           </div>
       </div>



    


</asp:Content>


