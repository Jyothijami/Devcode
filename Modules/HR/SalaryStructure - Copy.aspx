<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalaryStructure.aspx.cs" Inherits="Modules_HR_SalaryStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <div class="panel panel-default">
			                <div class="panel-heading"><h6 class="panel-title"><i class="icon-file"></i> Salary Structure</h6> <span class="pull-right">
          <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span></div>
			         

                                <div class="datatable-tasks">

    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ALLOWANCE_SETUP_ID" HeaderText="Sl.No" SortExpression="ALLOWANCE_SETUP_ID" />
            <asp:BoundField DataField="DEPT_NAME" HeaderText="Department Name" SortExpression="DEPT_NAME" />
            <asp:BoundField DataField="SalaryComp_Name" HeaderText="Salary Component" SortExpression="SalaryComp_Name" />
              <asp:BoundField DataField="ALLOWANCE_SETUP_TYPE" HeaderText="Allowance Type" SortExpression="ALLOWANCE_SETUP_TYPE" />
            
            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center" >
                <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/HR/SalaryStructure_Details.aspx?Cid=" + Eval("ALLOWANCE_SETUP_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM Salary_Structure,[Department_Master],Salary_Component where Salary_Structure.Categoryid = Department_Master.DEPT_ID and Salary_Structure.ALLOWANCE_MASTER_ID = Salary_Component.SalaryComp_id order by ALLOWANCE_SETUP_ID desc"></asp:SqlDataSource>
                                    <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                            <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>

                                    </div>
  </div>





</asp:Content>

