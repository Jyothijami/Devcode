<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="JobApplicant.aspx.cs" Inherits="Modules_HR_JobApplicant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div class="panel panel-default">
			                <div class="panel-heading"><h6 class="panel-title"><i class="icon-file"></i> Job Applicant</h6> <span class="pull-right">
          <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span></div>
			         

                                <div class="datatable-tasks">

    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="JobApplicant_Id" HeaderText="Sl.No" SortExpression="JobApplicant_Id" />
            <asp:BoundField DataField="Applicant_Name" HeaderText="Applicant Name" SortExpression="Applicant_Name" />
            <asp:BoundField DataField="Job_Title" HeaderText="For Job" SortExpression="Job_Title" />
              <asp:BoundField DataField="Applicant_Email" HeaderText="E-mail" SortExpression="Applicant_Email" />
             <asp:BoundField DataField="jstatus" HeaderText="Status" SortExpression="jstatus" />
            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center" >
                <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/HR/Jobapplicant_Details.aspx?Cid=" + Eval("JobApplicant_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT *,JobApplicant.Status as jstatus FROM JobApplicant,[JobOpenings] where JobApplicant.JobOpening_Id = JobOpenings.JobOpening_id order by JobApplicant_Id desc"></asp:SqlDataSource>
                                    <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                            <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>

                                    </div>
  </div>





</asp:Content>

