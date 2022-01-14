<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MastersHome.aspx.cs" Inherits="Modules_Masters_MastersHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


     <div style="padding-top: 20px">

        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    <h6><i class="icon-paragraph-justify"></i>Masters</h6>
                </div>
            </div>

             <div class="panel-body">

                <div class="row">

                    <div class="col-md-6">
                        <div class="block">
                           
                            <div class="well">
                                <div class="list-group">
                                    <a href="../Sales/CustomerMaster.aspx" class="list-group-item">Customers</a>
                                    <a href="../Masters/Architect.aspx" class="list-group-item">Architect</a>
                                    <a href="../Masters/Designation.aspx" class="list-group-item">Designation</a>
                                    <a href="../Masters/Region.aspx" class="list-group-item">Region</a>
                                    <a href="../Masters/Salutation.aspx" class="list-group-item">Salutation</a>
                                    <a href="Color.aspx" class="list-group-item">Colors</a>
                                      <a href="ProfileLength.aspx" class="list-group-item">Profile Length</a>
                                     <a href="../Masters/Item.aspx" class="list-group-item">Item</a>
                                    <a href="../Masters/MaterialType.aspx" class="list-group-item">Item Group</a>
                                    <a href="../Masters/Category.aspx" class="list-group-item">Item Category</a>
                                    <a href="../Masters/UOM.aspx" class="list-group-item">Item UOM</a>
                                    <a href="../Masters/ItemSeries.aspx" class="list-group-item">Item Series</a>
                                    <a href="../Masters/ItemBrand.aspx" class="list-group-item">Item Brand</a>
                                    <a href="../Masters/ItemPrice.aspx" class="list-group-item">Item Price</a>

                                            <a href="../Masters/Quatation_Changeables.aspx" class="list-group-item">Quatation Changables</a>
                                    <a href="../Masters/Country.aspx" class="list-group-item">Country</a>
                                    <a href="../Masters/State.aspx" class="list-group-item">State</a>
                                    <a href="../Masters/City.aspx" class="list-group-item">City</a>
                                      <a href="Plant.aspx" class="list-group-item">Plant</a>
                                      <a href="Table.aspx" class="list-group-item">Table</a>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="block">
                          
                            <div class="well">
                                <div class="list-group">
                    <asp:HyperLink runat="server" class="list-group-item" NavigateUrl="~/Modules/HR/Users.aspx" Text="Users"></asp:HyperLink>
                   <asp:HyperLink runat="server" class="list-group-item" NavigateUrl="~/Modules/Masters/Company.aspx" Text="Company"></asp:HyperLink>
                   <asp:HyperLink runat="server" class="list-group-item" NavigateUrl="~/Modules/Masters/Department.aspx" Text="Department"></asp:HyperLink>
                  <asp:HyperLink runat="server" class="list-group-item" NavigateUrl="~/Modules/Masters/Designation.aspx" Text="Designation / Job Title"></asp:HyperLink>
                   <asp:HyperLink runat="server" class="list-group-item" NavigateUrl="~/Modules/HR/GradeMaster.aspx" Text="Grade"></asp:HyperLink>
                   <asp:HyperLink runat="server" class="list-group-item" NavigateUrl="~/Modules/HR/OfferTerms.aspx" Text="Offer Terms Template"></asp:HyperLink>
   
                                      <a href="SalesTerms_Conditions.aspx" class="list-group-item">Terms and Conditions Template </a>
                                    <a href="PaymentTerms.aspx" class="list-group-item">Payment Terms</a>
                                    <a href="Storage_Template.aspx" class="list-group-item">Storage Terms and Conditions</a>
                                    <a href="SalesDamage_Template.aspx" class="list-group-item">Damage Terms and Conditions</a>
                                    <a href="Installation_Template.aspx" class="list-group-item">Installation Terms and Conditions</a>
                                    <a href="Currency.aspx" class="list-group-item">Currency</a>
                                    <a href="Incoterms.aspx" class="list-group-item">Incoterms</a>
                                    <a href="IndustryType.aspx" class="list-group-item">Industry Type</a>
                                    <a href="LeadSource.aspx" class="list-group-item">Lead Source </a>
                                      <a href="EmployeeType.aspx" class="list-group-item">Employee Type </a>

                                      <a href="StorageLocation.aspx" class="list-group-item">Storage Location </a>
                                       <a href="Operations.aspx" class="list-group-item">Production Operations </a>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                 </div>



            </div>
         </div>









    
</asp:Content>