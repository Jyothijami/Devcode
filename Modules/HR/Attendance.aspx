<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Modules_HR_Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="panel panel-default">
			                <div class="panel-heading"><h6 class="panel-title"><i class="icon-file"></i> Attendance</h6> <span class="pull-right">
          <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span></div>
			         

                                <div class="datatable-tasks">

    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Attendance_Id" HeaderText="Sl.No" SortExpression="Attendance_Id" />
            <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Employee Name" SortExpression="EMP_FIRST_NAME" />
            <asp:BoundField DataField="Attendance_Date" HeaderText="Attendance Date" SortExpression="Attendance_Date" DataFormatString="{0:dd/MM/yyyy}"/>
              <asp:BoundField DataField="Status" HeaderText="Created On" SortExpression="Status"  />
            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center" >
                <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/HR/Attendance_Details.aspx?Cid=" + Eval("Attendance_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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
                                </asp:GridView>

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Employee_Attendance],Employee_Master where Employee_Attendance.Emp_Id = Employee_Master.EMP_ID   order by Attendance_Id desc"></asp:SqlDataSource>
                                    <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                            <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>

                                    </div>
  </div>




</asp:Content>

