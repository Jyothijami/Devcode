<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassRequest.aspx.cs" Inherits="Modules_Stock_GlassRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-horizontal">
     <div class="page-header">
        <div class="page-title">
            <h3>Glass Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

     <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="GlassRequestMast.aspx">Glass Request</a></li>
            <li class="active">Glass Request Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

      

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Glass Request Details</h6>
            </div>
            <div class="panel-body">



                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Glass Request No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Glass Request Date :</label>
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
                            <asp:ListItem>RGP</asp:ListItem>
                            <asp:ListItem>NRGP</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label class="col-sm-2 control-label text-right">Required Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrequireddate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                            TargetControlID="txtrequireddate">
                        </cc1:CalendarExtender>
                    </div>
                </div>


                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Project Code :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlPono" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPono_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </div>

               
                <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="WindowCode" HeaderText="Window Code" />
                                    <asp:BoundField DataField="Thickness" HeaderText="Thickness" />
                                      <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Width" HeaderText="Width" />
                                    <asp:BoundField DataField="Height" HeaderText="Height" />
                                      <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                    <asp:BoundField DataField="Area" HeaderText="Area" />
                                   <asp:BoundField DataField="Weight" HeaderText="Weight" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="PoDetId" HeaderText="Po Det Id" />

                                    <asp:TemplateField HeaderText="Request Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRequestqty" runat="server" Width="40px" Text='<%# Eval("Requestqty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);"
                                                AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"
                                                AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>




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
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Request By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlrequestedby" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Approved By :</label>
                            <div class="col-sm-4">
                                   <asp:DropDownList ID="ddlapprovedby" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                       
                    </div>
                </div>

                <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" OnClick="btnApprove_Click" />

                        
                        
                    </div>
                </div>




                 
            </div>
        </div>



    </div>







</asp:Content>

