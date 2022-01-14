<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassIssue.aspx.cs" Inherits="Modules_Stock_GlassIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
<!--
    function Check_Click(objRef) {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;

        //Get the reference of GridView
        var GridView = row.parentNode;

        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];

            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                if (!inputList[i].checked) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;

    }
    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    inputList[i].checked = true;
                }
                else {
                    if (row.rowIndex % 2 == 0) {
                        row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }
    //-->
    </script>


    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Glass Issue Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="GlassIssueMast.aspx">Glass Issue</a></li>
            <li class="active">Glass Issue Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Glass Issue No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Glass Issue Date :</label>
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
                         
                        <h5 class="panel-title">Get Items From Requested Glass</h5>

                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Request No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlRequestedNo" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlRequestedNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlSono"  Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                       

                        <div class="form-group">
                            <asp:GridView ID="gvmatana" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvmatana_RowDataBound" >
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);"
                                                AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"
                                                AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

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
                                    <asp:BoundField DataField ="Requestqty" HeaderText ="Requested Qty" />

                                     <asp:BoundField DataField ="GlassRequestDetId" HeaderText ="GlassDetId" />

                                       <asp:TemplateField HeaderText="Issuing Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Issued_Qty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemRemarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataTemplate>
                                    <span style="color: #CC0000">No Data Found</span>
                                </EmptyDataTemplate>
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
                            <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" 
                                Width="100%">
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
                                    <asp:BoundField DataField ="Requestqty" HeaderText ="Requested Qty" />

                                     <asp:TemplateField HeaderText="Issuing Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Issued_Qty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemRemarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                  <%--  <asp:BoundField DataField ="GlassRequestDetId" HeaderText ="GlassDetId" />--%>

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

