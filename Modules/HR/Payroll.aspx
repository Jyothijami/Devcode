<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Payroll.aspx.cs" Inherits="Modules_HR_Payroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header">
                <div class="page-title">
                    <h3>Payroll Statement</h3>
                </div>
            </div>
    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Month :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass ="select-full" Width="100%" AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="Month" DataValueField="ID">
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
                <div class="form-actions col-sm-offset-2">                            
                             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
                        	
                  </div>
                <div class ="form-group ">
                    <table id="tblpRint" runat="server" visible="false">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkSalaryPaySheet" runat="server" OnCheckedChanged="chkSalaryPaySheet_CheckedChanged"
                                                    Text="Salary PaySheet" AutoPostBack="True"></asp:CheckBox></td>
                                            <td>
                                                <asp:CheckBox ID="chkPFSheet" runat="server" Text="PF Sheet" AutoPostBack="True" OnCheckedChanged="chkPFSheet_CheckedChanged"></asp:CheckBox></td>
                                            <td>
                                                <asp:CheckBox ID="chkESISheet" runat="server" Text="ESI Sheet" AutoPostBack="True" OnCheckedChanged="chkESISheet_CheckedChanged"></asp:CheckBox></td>
                                            <%--<td><asp:CheckBox ID="chkBankStatement" runat ="server" Text="Bank Statement" AutoPostBack ="true" OnCheckedChanged ="chkBankStatement_CheckedChanged"/></td>--%>
                                        </tr>
                                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

