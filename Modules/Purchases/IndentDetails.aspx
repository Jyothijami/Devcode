<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="IndentDetails.aspx.cs" Inherits="Modules_Purchases_IndentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
      <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
       <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>

    
     <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Indent Details</h3>

				</div>
				
			</div>
   <!-- /page header -->
               <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Indent.aspx">Indent</a></li>
                    <li class="active">Indent Details</li>
                </ul>
            </div>

   <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title"><i class="icon-pencil"></i>Indent Details</h6>
                </div>
                <div class="panel-body">


                       <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Basic Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Indent No:  </label>
                                        <asp:TextBox ID="txtIndentNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Indent Date:  </label>
                                        <asp:TextBox ID="txtindentdate" name="trigger" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtindentdate">
                                        </cc1:CalendarExtender>
                                    </div>

                                     <div class="col-md-3">
                                        <label>Department:  </label>
                                      <asp:DropDownList ID="ddlDepart"  Width="100%" CssClass="select-full" runat="server" ></asp:DropDownList>

                                    </div>
                                    <div class="col-md-3">
                                        <label>Follow Up Person:  </label>
                                          <asp:DropDownList ID="ddlFollowUp" Width="100%"  CssClass="select-full" runat="server" ></asp:DropDownList>
                                    </div>




                                </div>
                            </div>


                                
                        
                            
                            
                                </div>
                           </div>

                   

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Add Items</h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Material Code : </label>
                                        <asp:DropDownList ID="ddlMaterial" Width="100%" TabIndex="2" OnSelectedIndexChanged="ddlMaterial_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Length(MM) :  </label>
                                        <asp:TextBox ID="txtlength" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-md-2">
                                        <label>Color :  </label>

                                        <asp:DropDownList ID="txtColor" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Qty :  </label>
                                        <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-md-2">
                                        <label>Kg/Mtr :  </label>
                                        <asp:TextBox ID="txtkgpermtr" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-md-2">
                                        <label>Total Weight :  </label>
                                        <asp:TextBox ID="txttotalweight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>
                            </div>
                          
                            <div class="form-group">
                                <div class="row">
                                     <div class="col-md-3">
                                        <label>Customer Name :  </label>
                                        <asp:DropDownList ID="ddlCustomerName" TabIndex="2"  Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-5">
                                        <label>Descripiton :  </label>
                                        <asp:TextBox ID="txtDescription" Rows="2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Aluminium + Coating :  </label>
                                        <asp:TextBox ID="txtaluminumcoating" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="col-md-2">
                                        <label>Amount :  </label>
                                        <asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">

                                    <div class="text-center">

                                        <asp:Button ID="btnReset" CssClass="btn btn-danger " runat="server" Text="Reset" />
                                        <asp:Button ID="btnadditem" CssClass="btn btn-primary " runat="server" Text="Add Item" OnClick="btnadditem_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row " style="padding-top: 30px">
                                <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDeleting="gvitems_RowDeleting" OnRowDataBound="gvitems_RowDataBound" >
                                    <Columns>

                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="Series" HeaderText="Series" />
                                        <asp:BoundField DataField="Length" HeaderText="Length" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                        <asp:BoundField DataField="Color" HeaderText="Color" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                         <asp:BoundField DataField="Kgpermtr" HeaderText="Kg/Mtr" />
                                        <asp:BoundField DataField="TotalWeight" HeaderText="Total Weight" />
                                         <asp:BoundField DataField="AlumiumCoating" HeaderText="Aluminum + Coating" />
                                         <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                        <asp:BoundField DataField="CustId" HeaderText="CustId" />
                                        <asp:BoundField DataField="SeriesId" HeaderText="SeriesId" />
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
                        <div class="panel-heading">
                            <h6 class="panel-title">Office Details</h6>
                        </div>

                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Prepared By:  </label>
                                        <asp:DropDownList ID="ddlpreparedby" Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Approved By:  </label>
                                        <asp:DropDownList ID="ddlapprovedby" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions text-right">
                        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />
                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" />
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
                    </div>












                    </div>
       </div>
         </ContentTemplate>    
</asp:UpdatePanel>
              
</asp:Content>

