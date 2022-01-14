<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeMaster.aspx.cs" Inherits="Modules_HR_EmployeeMaster" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeMaster.aspx.cs" Inherits="Modules_HR_EmployeeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


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
                <h3>Employee Master</h3>
            </div>
        </div>

   
   <div class="panel">
       <div class="panel-body">
        <!-- /page header -->
         <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
        <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>

           <div class="row">
               <div class="btn-group">
				                        <span  class="btn btn-danger btn-icon"><i class="icon-user"></i></span>
			                                <asp:Button ID="btnAddnew" CssClass="btn btn-danger" runat="server" Text="Add New" OnClick="btnAddnew_Click" />
     </div>
           </div>




    <div class="">
    
        <asp:GridView ID="hai" runat="server" AutoGenerateColumns="False" CssClass ="table table-bordered"
             DataSourceID="SqlDataSource1"  OnRowDataBound="hai_RowDataBound">
           
            <Columns>
                <asp:BoundField DataField="EMP_ID" HeaderText="Sl.No">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Image">
             <ItemTemplate>
                    <asp:Image ID="Image" runat="server" ImageUrl="~/images/noname.jpg" Width="70px" />
             </ItemTemplate>
                   </asp:TemplateField>



                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <%# Eval("EMP_FIRST_NAME") + " " + Eval("EMP_LAST_NAME")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EMP_GENDER" HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>

                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EMP_PHONE" HeaderText="Phone Number"></asp:BoundField>
                <asp:BoundField DataField="EMP_MOBILE" HeaderText="Mobile Number" />
                <asp:BoundField DataField="EMP_EMAIL" HeaderText="E-Mail" />

                 <asp:BoundField DataField="Status" HeaderText="Status" />


                <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                     <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/HR/EmployeeDetails.aspx?Cid=" + Eval("EMP_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
               </span> </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Change Image" HeaderStyle-CssClass="text-center">
                     <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnImage" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/HR/AddEmpImage.aspx?Cid=" + Eval("EMP_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Employee_Master] ORDER BY EMP_ID DESC">
        </asp:SqlDataSource>
   </div>
           </div>
       </div>



    


</asp:Content>

