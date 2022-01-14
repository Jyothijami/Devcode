<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="RGP_Request_Details.aspx.cs" Inherits="Modules_Stock_RGP_Request_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="page-header">
        <div class="page-title">
            <h3>RGP Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="RGP_Request.aspx">RGP Request</a></li>
            <li class="active">RGP Request Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">RGP Request No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrgpno" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">RGP Request Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrgpDate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtrgpDate">
                        </cc1:CalendarExtender>
                    </div>
                </div>



                  <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Request For :</label>
                    <div class="col-sm-4"> 
                        <asp:DropDownList ID="ddlrequestfor" CssClass="form-control" Width="100%" runat="server">
                            <asp:ListItem>Self</asp:ListItem>
                            <asp:ListItem>Customer/Project</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                      <label class="col-sm-2 control-label text-right">Project :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlproject" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                    </div>
                 
                </div>


                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Sending Through :</label>
                    <div class="col-sm-4">
                          <asp:TextBox ID="txtreceiverName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <label class="col-sm-2 control-label text-right">Address :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtadress" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                

                <div class="panel panel-default">

                    <div class="panel-heading">
                        <h5 class="panel-title">Add Items</h5>
                    </div>

                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Item Code :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlitemCode" Width="100%" TabIndex="2" AutoPostBack="true" CssClass="select-full" runat="server" OnSelectedIndexChanged="ddlitemCode_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Color :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlColor" Width="100%" OnSelectedIndexChanged="ddlColor_SelectedIndexChanged" AutoPostBack="true"  CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>


                          <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Description :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtseries" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Uom :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtUom" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>



                        <div class="form-group">
                             <label class="col-sm-2 control-label text-right">Length :</label>
                            <div class="col-sm-4">
                            <asp:DropDownList ID="ddllength" OnSelectedIndexChanged="ddllength_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                  </div>

                            <label class="col-sm-2 control-label text-right">Total Stock :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtpu" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                           
                        </div>


                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Blocked Stock :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtpreviousBlockedStock" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Free Stock :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtAvailableStocktoBlock" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>










                        <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Qty :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Purpose :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtpurpose" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                         <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtremarks" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            
                        </div>




                        <div class="form-group">

                            <div class="form-actions col-sm-offset-6">
                                <asp:Button ID="btnadditem" CssClass="btn btn-primary" runat="server" OnClick="btnadditem_Click" Text="Add Item" />
                            </div>
                        </div>

                        <div class="datatable" style="padding-top: 10px">
                            <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                                Width="100%" OnRowDeleting="gvItems_RowDeleting">
                                <Columns>

                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="Length" HeaderText="Length" />


                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                     <asp:BoundField DataField="ReqQty" HeaderText="Qty" />
                                    
                                    <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                                   <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                     <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />

                                 


                                    
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
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txttermscondtionscontent" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender5" TargetControlID="txttermscondtionscontent" EnableSanitization="false" DisplaySourceTab="false"
                                    runat="server" />
                            </div>
                        </div>



                    


                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Prepared By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlPreparedBy" CssClass="select-full" Enabled="false" Width="100%" runat="server"></asp:DropDownList>
                            </div>


                            <label class="col-sm-2 control-label text-right">Approved By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlapprovedby" Enabled="false" CssClass="select-full"  Width="100%" runat="server"></asp:DropDownList>
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
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
        </div>




</asp:Content>

