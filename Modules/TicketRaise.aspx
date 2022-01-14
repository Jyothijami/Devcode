<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="TicketRaise.aspx.cs" Inherits="Modules_Reports_HR_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Tickets Raise</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="ViewTicketsRaised.aspx">Service Request</a></li>
                    <li class="active">Ticket Raise </li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title"><i class="icon-pencil"></i>Raise Tickets here</h6>
                </div>
                <div class="panel-body">
                    


                     <div class="form-group">

                    <label class="col-sm-2 control-label text-right">User Affected:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlUserAffctd" CssClass="select-full" Width ="100%" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Entire Office</asp:ListItem>
                    <asp:ListItem>One Department</asp:ListItem>
                    <asp:ListItem>Group of Users</asp:ListItem>
                    <asp:ListItem>Single User</asp:ListItem>
                    <asp:ListItem>Infirmational/Procurement</asp:ListItem>
                </asp:DropDownList>
                    </div>


                      <label class="col-sm-2 control-label text-right">Region:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlRegion" CssClass="select-full" Width ="100%" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Hyderabad</asp:ListItem>
                    <asp:ListItem>Shadnagar</asp:ListItem>
                </asp:DropDownList>
                    </div>

                   
                </div>





                </div> 
           </div> 
     <table class="table">

       
        <tr>
            <td style="text-align:right">Created By :</td>
            <td>
                <asp:TextBox ID="txtCreatedFor" placeholder="User Name" CssClass="form-control" Width="300px" runat="server"></asp:TextBox>

            </td>
        </tr>
        
        <tr>
            <td style="text-align:right">Process/Module :</td>
            <td>
                <asp:TextBox ID="txtModule" placeholder="SM/Purchases etc." CssClass="form-control" Width="300px" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align:right">Incident Type :</td>
            <td>
                <asp:DropDownList ID="ddlIncidentType" CssClass="select-full" Width="300px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIncidentType_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Application</asp:ListItem>
                    <asp:ListItem>Software</asp:ListItem>
                    <asp:ListItem>Hardware</asp:ListItem>
                    <asp:ListItem>Security</asp:ListItem>
                    <asp:ListItem>Any Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Urgency Level:</td>
            <td>
                <asp:DropDownList ID="ddlUrgencyLevel" CssClass="select-full" Width="300px" runat="server" OnSelectedIndexChanged="ddlIncidentType_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td style="text-align:right">Summary :</td>
            <td>
                <asp:TextBox ID="txtSummary" placeholder="Summay" CssClass="form-control" Width="300px"  runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align:right">Description :</td>
            <td>
                <asp:TextBox ID="txtDescription" placeholder="Description Of Request" CssClass="form-control" TextMode="MultiLine" Width="500px" Height="165px" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align:right">Attachments :</td>
            <td>
                <asp:FileUpload ID="requestAttachements" runat="server" AllowMultiple="true" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align: left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"  />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <br />
    <p style="color: brown; text-align: center;">
        *** Date Created and Date Worked will be by defaut "1/1/1900 12:00:00 AM" and will be updated as soon as the admin works on the Request.***
    </p>
    <br />
    <table>
        <tr>
            <td>
                <p>Total No Of Tickets Raised : <asp:Label ID="lblTotalTicketsRaised" Font-Bold="true" runat="server"></asp:Label></p>
            </td>
            <td>
                

            </td>
        </tr>
    </table>
    <br />





    <table style="width: 100%" class="table table-bordered">
        <tr><td><asp:Label ID="lblUserType" runat="server" meta:resourcekey="lblSearchValueHiddenResource1"
                                        Visible="False"></asp:Label><asp:Label ID="lblEmpIdHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchTypeHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchValueFromHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCPID" runat="server" meta:resourcekey="lblSearchValueHiddenResource1"
                                        Visible="False"></asp:Label></td></tr>
        <tr>
            <td style="height: 25px; text-align: right;">
                                                <asp:Label ID="Label112" CssClass="label" runat="server" EnableTheming="False" Font-Bold="True"
                                                    Text="Search By"></asp:Label>
                                                <asp:DropDownList ID="ddlSearchBy" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--</asp:ListItem>
                                                    <asp:ListItem Value="Ticket_ID">Ticket ID</asp:ListItem>
                                                    <asp:ListItem Value="Date_Created">Date Created</asp:ListItem>
                                                    <asp:ListItem Value="Status">Status</asp:ListItem>
                                                    <asp:ListItem Value="Created_For">Created For</asp:ListItem>
                                                    <asp:ListItem Value="Summary">Summary</asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlSymbols" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    EnableTheming="False" OnSelectedIndexChanged="ddlSymbols_SelectedIndexChanged"
                                                    Visible="False" Width="50px">
                                                    <asp:ListItem Selected="True">=</asp:ListItem>
                                                    <asp:ListItem>&lt;</asp:ListItem>
                                                    <asp:ListItem>&gt;</asp:ListItem>
                                                    <asp:ListItem>&lt;=</asp:ListItem>
                                                    <asp:ListItem>&gt;=</asp:ListItem>
                                                    <asp:ListItem>R</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblCurrentFromDate" runat="server" Font-Bold="True" Text="From" Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtSearchValueFromDate" runat="server" type="datepic" EnableTheming="True" Visible="False"
                                                    Width="106px"></asp:TextBox>
                <asp:Label ID="lblCurrentToDate" runat="server" Font-Bold="True" Text="To " Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtSearchValueToDate" runat="server" type="datepic" EnableTheming="True" Visible="False"
                                                    Width="106px"></asp:TextBox>
                                                <asp:TextBox ID="txtSearchText" runat="server" EnableTheming="True" Width="118px"></asp:TextBox>
                <asp:Button ID="btnSearchGo" runat="server" BorderStyle="None" CausesValidation="False"
                                                    CssClass="gobutton" EnableTheming="False" OnClick="btnSearchGo_Click" Text="Go" /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvServiceRequests" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Ticket_Id" DataSourceID="SqlDataSource1" OnRowDataBound="gvServiceRequests_RowDataBound" PageSize="100">
                    <Columns>
                        <asp:BoundField DataField="Ticket_Id" HeaderText="Ticket_Id" ReadOnly="True" SortExpression="Ticket_Id" />
                        <asp:BoundField DataField="Date_Created" HeaderText="Date_Created" SortExpression="Date_Created" />
                        <%--<asp:BoundField DataField="User_Affected" HeaderText="User_Affected" SortExpression="User_Affected" />
                        <asp:BoundField DataField="Created_For" HeaderText="Created_For" SortExpression="Created_For" />--%>
                        <%--<asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />--%>
                        <%--<asp:BoundField DataField="Process_Module" HeaderText="Module" SortExpression="Process_Module" />--%>
                        <%--<asp:BoundField DataField="Incident_Type" HeaderText="Incident_Type" SortExpression="Incident_Type" />--%>
                        
                        <asp:BoundField DataField="Summary" HeaderText="Summary" SortExpression="Summary" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <%--<asp:BoundField DataField="Date_Worked" HeaderText="Date_Worked" SortExpression="Date_Worked" />--%>
                        <asp:BoundField DataField="Date_Closed" HeaderText="Date_Closed" SortExpression="Date_Closed" />
                        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />

                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Service_Requests_tbl] order by date_created desc"></asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="[SP_Service_Request_Search]" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblSearchItemHidden" DefaultValue="0" Name="SearchItemName" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="lblSearchTypeHidden" DefaultValue="0" Name="SearchType" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="lblSearchValueHidden" DefaultValue="0" Name="SearchValue" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="lblSearchValueFromHidden" DefaultValue="0" Name="SearchValueFrom" PropertyName="Text" Type="String" />
                            <asp:ControlParameter PropertyName="Text" Type="Int64" DefaultValue="0" Name="UserType" ControlID="lblUserType"></asp:ControlParameter>
                                <asp:ControlParameter PropertyName="Text" Type="Int64" DefaultValue="0" Name="EmpId" ControlID="lblEmpIdHidden"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>

