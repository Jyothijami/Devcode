<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseHome.aspx.cs" Inherits="Modules_Purchases_PurchaseHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="padding-top: 20px">


        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    <h6><i class="icon-paragraph-justify"></i>Purchasing </h6>
                </div>
            </div>

            <div class="panel-body">

                <div class="row">

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Purchasing </span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="MaterialRequest.aspx" class="list-group-item">Indent Request</a>
                                     <a href="RequestSupplierQuatation.aspx" class="list-group-item">Request Quotation </a>
                                    <a href="Supplier_Quotation.aspx" class="list-group-item">Supplier Quotation </a>
                                     <a href="SupPo.aspx" class="list-group-item">Purchase Order </a>
                                      <a href="PoStatus.aspx" class="list-group-item">Purchase Order Status</a>
                                </div>
                            </div>

                             </div>

                               <div class="block">
                            <span class="subtitle">Glass Purchasing </span>
                            <div class="well">
                                <div class="list-group">
                                     <a href="../Sales/SalesOrder.aspx" class="list-group-item">So Glass Request</a>
                                     <a href="RequestGlassQuatation.aspx" class="list-group-item">Request Glass Quotation </a>
                                     <a href="SupplierGlassQuatation.aspx" class="list-group-item">Supplier Glass Quotation </a>
                                     <a href="GlassPo.aspx" class="list-group-item">Glass Purchase Order </a>
                                </div>
                            </div>
                                   </div>
                       
                    </div>

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Supplier</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="VendorMaster.aspx" class="list-group-item">Supplier </a>
                                    <a href="../Masters/SupplierType.aspx" class="list-group-item">Supplier Type </a>

                                      <a href="SupInvoice.aspx" class="list-group-item">Supplier Invoice </a>
                                   
                                </div>
                            </div>
                        </div>



                         <div class="block">
                            <span class="subtitle">Other Reports</span>
                            <div class="well">
                                <div class="list-group">
                                     <a href="PurchaseOrderList.aspx" class="list-group-item">Purchased Order List  </a>
                                    <a href="IndentList.aspx" class="list-group-item">Indent Requested</a>
                                    <a href="IndentApprovalList.aspx" class="list-group-item">Requested Items Approved   </a>
                                    <a href="SuplierAddress.aspx" class="list-group-item">Supplier Addresses And Contacts </a>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Items and Pricing  </span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="../Masters/Item.aspx" class="list-group-item">Item</a>
                                    <a href="../Masters/MaterialType.aspx" class="list-group-item">Item Group</a>
                                    <a href="../Masters/Category.aspx" class="list-group-item">Item Category</a>
                                    <a href="../Masters/UOM.aspx" class="list-group-item">Item UOM</a>
                                    <a href="#" class="list-group-item">Item Price</a>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Setup </span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="../Masters/Plant.aspx" class="list-group-item">Plant/Location</a>
                                    <a href="../Masters/SalesTerms_Conditions.aspx" class="list-group-item">Terms and Conditions Template </a>
                                    
                                  
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                  <div class="row">
                
                    <div class="col-md-6">
                       
                    </div>
                </div>





            </div>
        </div>










    </div>
</asp:Content>