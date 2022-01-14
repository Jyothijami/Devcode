<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesHome.aspx.cs" Inherits="Modules_Sales_SalesHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="padding-top: 20px">

        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    <h6><i class="icon-paragraph-justify"></i>Sales</h6>
                </div>
            </div>

            <div class="panel-body">

                <div class="row">

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Sales</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="Lead.aspx" class="list-group-item">Lead</a>
                                    <a href="SalesEnquiry.aspx" class="list-group-item">Sales Inquiry<span class="label label-default text-right bg-danger"><asp:Label ID="lblSalesEnq" runat="server" Text=""></asp:Label></span></a>

                                     <a href="EnquiryAssignment.aspx" class="list-group-item">Inquiry Assignment<span class="label label-default text-right bg-danger"><asp:Label ID="lblinquiry" runat="server" Text=""></asp:Label></span></a>
                                    <a href="SalesQuotation.aspx" class="list-group-item">Sales Quotation</a>
                                    <a href="SalesOrder.aspx" class="list-group-item">Sales Order</a>

                                      <a href="BOM_Search.aspx" class="list-group-item">BOM Search</a>
                                    
                                      <a href="../Stock/MumbaiStock.aspx" class="list-group-item">Mumbai Stock - (Last Updated on:<asp:Label ID="lbllastupdatedon" runat="server" Text="" ForeColor="Red"></asp:Label>)</a>

                                       <a href="../Purchases/MaterialRequest.aspx" class="list-group-item">Indent Request</a>

                                       


                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Customers</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="CustomerMaster.aspx" class="list-group-item">Customers</a>
                                    <a href="../Masters/Architect.aspx" class="list-group-item">Architect</a>
                                    <a href="../Masters/Designation.aspx" class="list-group-item">Designation</a>
                                    <a href="../Masters/Region.aspx" class="list-group-item">Region</a>
                                    <a href="../Masters/Salutation.aspx" class="list-group-item">Salutation</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" id="tblitems" runat="server">
                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Items and Pricing</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="../Masters/Item.aspx" class="list-group-item">Item</a>
                                    <a href="../Masters/MaterialType.aspx" class="list-group-item">Item Group</a>
                                    <a href="../Masters/Category.aspx" class="list-group-item">Item Category</a>
                                    <a href="../Masters/UOM.aspx" class="list-group-item">Item UOM</a>
                                    <a href="../Masters/ItemSeries.aspx" class="list-group-item">Item Series</a>
                                    <a href="../Masters/ItemBrand.aspx" class="list-group-item">Item Brand</a>
                                    <a href="../Masters/ItemPrice.aspx" class="list-group-item">Item Price</a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Sales Partners</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="PurDashboard.aspx" class="list-group-item">Purchase Dashboard</a>
                                    <a href="#" class="list-group-item">Sales Person </a>
                                    <a href="../Masters/Quatation_Changeables.aspx" class="list-group-item">Quatation Changables</a>
                                    <a href="../Masters/Country.aspx" class="list-group-item">Country</a>
                                    <a href="../Masters/State.aspx" class="list-group-item">State</a>
                                    <a href="../Masters/City.aspx" class="list-group-item">City</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" id="tblsetup" runat="server">
                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Setup</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="../Masters/SalesTerms_Conditions.aspx" class="list-group-item">Terms and Conditions Template </a>
                                    <a href="../Masters/PaymentTerms.aspx" class="list-group-item">Payment Terms</a>
                                    <a href="../Masters/Storage_Template.aspx" class="list-group-item">Storage Terms and Conditions</a>
                                    <a href="../Masters/SalesDamage_Template.aspx" class="list-group-item">Damage Terms and Conditions</a>
                                    <a href="../Masters/Installation_Template.aspx" class="list-group-item">Installation Terms and Conditions</a>
                                    <a href="../Masters/Currency.aspx" class="list-group-item">Currency</a>
                                    <a href="../Masters/Incoterms.aspx" class="list-group-item">Incoterms</a>
                                    <a href="../Masters/IndustryType.aspx" class="list-group-item">Industry Type</a>
                                    <a href="../Masters/LeadSource.aspx" class="list-group-item">Lead Source </a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Other Reports</span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="#" class="list-group-item">Lead Details </a>
                                    <a href="#" class="list-group-item">Customer Addresses And Contacts  </a>
                                    <a href="#" class="list-group-item">Ordered Items To Be Delivered  </a>
                                    <a href="#" class="list-group-item">Sales Person-wise</a>
                                    <a href="#" class="list-group-item">Item-wise Sales History   </a>
                                    <a href="#" class="list-group-item">BOM Search </a>
                                    <a href="#" class="list-group-item">Available Stock for Packing Items    </a>
                                    <a href="#" class="list-group-item">Pending SO Items For Purchase Request  </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>