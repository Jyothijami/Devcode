<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ReturnIssueSlip_Details.aspx.cs" Inherits="Modules_Stock_ReturnIssueSlip_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



     <div class="page-header">
        <div class="page-title">
            <h3>Issue Return Slip Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="ReturnIssue.aspx">Issue Return</a></li>
            <li class="active">Issue Return Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->
    <div class="form-horizontal">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Issue Return Details</h6>
            </div>
            <div class="panel-body">

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Issue Return Receipt No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtRgpreturnNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Issue Return Receipt Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtRgpreturnDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Material Issue No :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlRgpno" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRgpno_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2 control-label text-right">Material Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtRgpDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Receiver Name :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrecivername" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Address :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                   <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Series" HeaderText="Description" />
                                     <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                      <asp:BoundField DataField="Length" HeaderText="Length" />
                                     <asp:BoundField DataField="Color" HeaderText="Color" />
                                     <asp:BoundField DataField="IssuedQty" HeaderText="Issued Qty" />
                                     <asp:BoundField DataField="Receivedqty" HeaderText="Received Qty" />
                                     <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                     <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                     <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                     <asp:TemplateField HeaderText="Receive Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRECEIVEDQTY" runat="server" Width="40px" Text='<%# Eval("ReceiveQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Slno" HeaderText="Slno" />



                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center">
                                        <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title">Office Details</h6>
                    </div>

                    <div class="panel-body">


                            <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txttermscondtionscontent" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender5" TargetControlID="txttermscondtionscontent" EnableSanitization="false" DisplaySourceTab="false"
                                    runat="server" />
                            </div>
                        </div>



                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Received By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlReceivedby" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Status :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control" Width="100%" runat="server">
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Complete</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Prepared By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlPreparedBy" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>

                
            </div>
        </div>
    </div>







</asp:Content>

