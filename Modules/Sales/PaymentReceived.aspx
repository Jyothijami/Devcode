<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="PaymentReceived.aspx.cs" Inherits="Modules_Sales_PaymentReceived" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Payment Received</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="SalesInvoice.aspx">Sales Invoice</a></li>
            <li class="active">Payment Received</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Sales Invoice Details</h6>
        </div>
        <div class="panel-body">

            <div class="form-group">
                <div class="row">
                    <div class="col-md-6">
                        <label>Invoice No: <span class="mandatory">*</span></label>
                       <%-- <asp:TextBox ID="txtInvoiceNo" CssClass="form-control" runat="server"></asp:TextBox>--%>
                           <asp:DropDownList ID="ddlInvoiceNo" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>

                    </div>
                    <div class="col-md-6">
                        <label>Invoice Date: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtInvoiceDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                   
                    <div class="col-md-3">
                        <label>Client Name: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Mobile No: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Site Name : <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtsitename" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Site Location : <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtSiteLocation" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            


        
        </div>
     
    </div>


    <div class="panel panel-default">

        <div class="panel-heading"> <h6 class="panel-title">Outstanding Transactions</h6></div>

        <div class="panel-body">

            <div class="form-group">
                <div class="row">
                    <div class="col-md-4">
                        <label>Payment Received No: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtPaymentrevicedNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Payment Received Date: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtPaymentReceivedDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Payment Method: <span class="mandatory">*</span></label>
                          <asp:DropDownList ID="ddlPaymentMethod" TabIndex="2" CssClass="select-full" runat="server" >
                              <asp:ListItem>Cash</asp:ListItem>
                              <asp:ListItem>Cheque</asp:ListItem>
                              <asp:ListItem>Wire Transfer</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <label>Due Date: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtDuedate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Original Amount : <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtOriginalAmount" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                      <div class="col-md-3">
                        <label>Open Balance : <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtOpenBalance" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Payment : <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtPaymentRecieved" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>


                </div>
            </div>

              <div class="form-actions text-right">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary"  Text="Save" OnClick="btnSave_Click"  />
        </div>

        </div>


        <div class="form-group">
         
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Payment Recieved Details</h6>
                </div>
                <div class="panel-body">
                    <div class="datatable-tasks">
                        <asp:GridView ID="hai" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowDataBound="hai_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="PR_Id" HeaderText="Sl.No" SortExpression="PR_Id" />
                                <asp:BoundField DataField="PR_No" HeaderText="Payment Received No" SortExpression="PR_No" />
                                <asp:BoundField DataField="PR_Date" HeaderText="Date" SortExpression="PR_Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="SI_Amount" HeaderText="Invoice Amount" SortExpression="SI_Amount" />
                                <asp:BoundField DataField="PR_Amt_Received" HeaderText="Amount Received" SortExpression="PR_Amt_Received" />
                                
                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Delete">
                                    <ItemTemplate>
                                        <span class="text-center">
                                        <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                                        </span>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
         
        </div>


    </div>









</asp:Content>

