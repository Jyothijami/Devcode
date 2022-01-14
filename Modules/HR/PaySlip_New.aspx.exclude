<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PaySlip_New.aspx.cs" Inherits="Modules_HR_PaySlip_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
              

     <div class="page-header">
                <div class="page-title">
                    <h3>PaySlip</h3>
                </div>
            </div>
    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Month :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlMonth" OnSelectedIndexChanged ="ddlMonth_SelectedIndexChanged" runat="server" CssClass ="select-full" Width="100%" AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="Month" DataValueField="ID">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                </asp:DropDownList> 
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [Month], [ID] FROM [Month_Calendar_tbl]"></asp:SqlDataSource>
				            </div>
                            <label class="col-sm-2 control-label text-right">Financial Year :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtYear" CssClass ="form-control" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                                <asp:DropDownList ID="ddlYear" CssClass ="select-full" runat="server" Width="100%" AutoPostBack="True" >
                            </asp:DropDownList>
                            </div>
                        </div>
                <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Department :</label>
				            <div class="col-sm-4">
                                <asp:DropDownlist ID="ddlDepartment" Enabled ="false"  CssClass="select-full" Width="100%" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack ="true"   runat="server"></asp:DropDownlist>    	
				            </div>
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlEmployee" runat="server" Enabled ="false"  CssClass ="select-full" Width="100%" AutoPostBack="True" >
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                    </div> 
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Toatl No.Of Days :</label>
				            <div class="col-sm-4">
                                 <asp:TextBox ID="txtNOD" CssClass ="form-control" runat="server" ReadOnly="True"></asp:TextBox>
				            </div>
				        <label class="col-sm-2 control-label text-right">W.Off / Holidays :</label>
				            <div class="col-sm-4">
                                 <asp:TextBox ID="txtHolidays" CssClass ="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                       
                        </div>
                <div class="form-actions col-sm-offset-2">                            
                            <asp:Button ID="btnGenerate" runat="server" Text="Generate PaySlip" OnClick="btnGenerate_Click" />
                    <asp:Label ID="lblWoff" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblHoli" runat="server" Visible="false"></asp:Label>
                  </div>
            </div>
        </div>
    </div>

         <asp:Label ID="lblDeptId" runat="server" Visible="false"></asp:Label>

      <asp:Label ID="lblEmpId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblGrossSalary" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblAge" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblDOB" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblAccNo" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblDOJ" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblSal" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblSal1" runat="server" Visible="false"></asp:Label>
</asp:Content>

