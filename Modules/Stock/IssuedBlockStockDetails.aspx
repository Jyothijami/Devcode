<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IssuedBlockStockDetails.aspx.cs" Inherits="Modules_Stock_IssuedBlockStockDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Block Stock Issue Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="IssuedBlockStock.aspx">Block Stock Issue</a></li>
            <li class="active">Block Stock Issue Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Block Stock Issue No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Issue Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMrdate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtMrdate">
                        </cc1:CalendarExtender>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Request Type :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlrequesttype" CssClass="form-control" Width="100%" runat="server">
                            <asp:ListItem>Production</asp:ListItem>
                            <asp:ListItem>Project</asp:ListItem>
                            <asp:ListItem>Maintenace</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   
                </div>
                <div class="panel panel-danger">
                    <div class="panel-heading">
                         
                        <h5 class="panel-title">Get Items From Requested to Transfer</h5>

                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Request No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlRequestedNo" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlRequestedNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                          
                        </div>


                         <div class="form-group">
                            <label class="col-sm-2 control-label text-right">From Project :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlFromProject" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">To Project :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlToProject"  Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="RequestBlockRelase_Det_id" HeaderText="Sl.No" SortExpression="RequestBlockRelase_Det_id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ReqQty" HeaderText="Req Qty" SortExpression="ReqQty">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>


                                       <asp:TemplateField HeaderText="Release Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemRemarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ProjectCode" HeaderText="From Project" SortExpression="ProjectCode">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Expr1" HeaderText="To Project" SortExpression="Expr1">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>
                                   

                                       <asp:BoundField DataField="CustId" HeaderText="ToCustId" SortExpression="CustId">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CustSiteId" HeaderText="ToSiteId" SortExpression="CustSiteId">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BlockStockDetId" HeaderText="BlockStockDetId" SortExpression="BlockStockDetId">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                       <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" SortExpression="ItemCode">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                       <asp:BoundField DataField="ColorId" HeaderText="ColorId" SortExpression="ColorId">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>


                                      <asp:BoundField DataField="BlockedQty" HeaderText="BlockedQty" SortExpression="BlockedQty">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                  
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>


                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h5 class="panel-title">Issued Items</h5>
                    </div>

                    <div class="panel-body">
                        <div class="" style="padding-top: 10px">
                            

                             
                           <div class="form-group">
                            <asp:GridView ID="GridView2" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Issued_Block_Det_Id" HeaderText="Sl.No" SortExpression="Issued_Block_Det_Id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Reqested_Qty" HeaderText="Reqested_Qty" SortExpression="Reqested_Qty">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="Issued_Qty" HeaderText="Issued_Qty" SortExpression="Issued_Qty">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ProjectCode" HeaderText="From Project" SortExpression="ProjectCode">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Expr1" HeaderText="To Project" SortExpression="Expr1">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>
                                   

                                       <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                  
                                </Columns>
                            </asp:GridView>
                        </div>



                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Request By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlrequestedby" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Prepared By :</label>
                            <div class="col-sm-4">
                                   <asp:DropDownList ID="ddlapprovedby" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                       
                    </div>
                </div>

                <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

