<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="CustomerProjectReport.aspx.cs" Inherits="Modules_Reports_CustomerProjectReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



     <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Customer Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="CustomerMaster.aspx">Home</a></li>
            <li class="active">Customer Detail Report</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->


    
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-pencil"></i>Customer Details</h6>
        </div>
        <div class="panel-body">

            <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Customer : <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlCustomer" TabIndex="2" Width="100%" CssClass="select-full" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <label>Project : <span class="mandatory">*</span></label>
                               <asp:DropDownList ID="ddlproject" TabIndex="2" Width="100%" CssClass="select-full" OnSelectedIndexChanged="ddlproject_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                </asp:DropDownList>                            </div>
                        </div>
              </div>


             <h6 class="heading-hr">Sales</h6> 
                        <div class="form-group">
              <ul class="info-blocks">
				
				<li class="bg-danger">
					<div class="top-info">
						<a href="#">Sales Enquiry</a>
                        <small>
                            <asp:Label ID="lblEnquiryStarted" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Enquiry No:<asp:Label ID="lblenquiryNo" runat="server" Text=""></asp:Label></small><br />
					<small>Enquiry Date:<asp:Label ID="lblenquiryDate" runat="server" Text=""></asp:Label></small>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				</li>


                  	<li class="bg-danger">
					<div class="top-info">
						<a href="#">Sales Quatation</a>
                        <small>
                            <asp:Label ID="lblQuatationStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Quatation No:<asp:Label ID="lblQuatationNo" runat="server" Text=""></asp:Label></small><br />
					<small>Quatation Date:<asp:Label ID="lblQuatationDate" runat="server" Text=""></asp:Label></small><br />
                          <asp:Label ID="lblQuatationID" Visible="false" runat="server" Text=""></asp:Label>
                    <span class="bottom-info bg-primary"><button type="button" data-toggle="modal" data-target="#myModal">View Details</button></span>
				</li>


                   	<li class="bg-danger">
					<div class="top-info">
						<a href="#">Sales Order</a>
                        <small>
                            <asp:Label ID="lblSalesorderStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>SO No:<asp:Label ID="lblSono" runat="server" Text=""></asp:Label></small><br />
					<small>SO Date:<asp:Label ID="lblSoDate" runat="server" Text=""></asp:Label></small><br />
                            <asp:Label ID="lblsoId" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				</li>



                   	<li class="bg-danger">
					<div class="top-info">
						<a href="#">BOM</a>
                        <small>
                            <asp:Label ID="lblBomStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Total No of Materials :<asp:Label ID="lblnoofmaterial" runat="server" Text=""></asp:Label></small><br />
					<small>Total Issued Materials:<asp:Label ID="lblissuedmaterial" runat="server" Text=""></asp:Label></small>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				</li>


                  
                   	<li class="bg-danger">
					<div class="top-info">
						<a href="#">Indent</a>
                        <small>
                            <asp:Label ID="lblIndentStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Indent No:<asp:Label ID="lblindentno" runat="server" Text=""></asp:Label></small><br />
					<small>Indent Date:<asp:Label ID="lblindentdate" runat="server" Text=""></asp:Label></small><br />
                            <asp:Label ID="lblindentid" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				</li>

			
			   </ul>
           </div>

            <h6 class="heading-hr">Purchases</h6> 

            <div class="form-group">
                  <ul class="info-blocks">
				
				<li class="bg-danger">
					<div class="top-info">
						<a href="#">Indent Approval</a>
                        <small>
                            <asp:Label ID="lblIndentapprovalStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Ind Approval No:<asp:Label ID="lblIndapprvalno" runat="server" Text=""></asp:Label></small><br />
					<small>Ind Approval Date:<asp:Label ID="lblIndapprvaldate" runat="server" Text=""></asp:Label></small>
                        <asp:Label ID="lblIndappId" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				</li>


                  <li class="bg-danger">
					<div class="top-info">
						<a href="#">Purchase Quatation</a>
                        <small>
                            <asp:Label ID="lblPurchaseQuatationStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Purchase Quatation No:<asp:Label ID="lblPurquatationno" runat="server" Text=""></asp:Label></small><br />
					<small>Purchase Quatation Date:<asp:Label ID="lblpurquatationdate" runat="server" Text=""></asp:Label></small>
                        <asp:Label ID="lblpurquatationid" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				 </li>


                       <li class="bg-danger">
					<div class="top-info">
						<a href="#">Purchase Order</a>
                        <small>
                            <asp:Label ID="lblpurchaseorderStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Purchase Order No:<asp:Label ID="lblPONo" runat="server" Text=""></asp:Label></small><br />
					<small>Purchase Order Date:<asp:Label ID="lblPOdate" runat="server" Text=""></asp:Label></small>
                        <asp:Label ID="lblPurchaseOrderid" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				 </li>





                        <li class="bg-danger">
					<div class="top-info">
						<a href="#">Purchase Receipt</a>
                        <small>
                            <asp:Label ID="lblPurchaseReceiptStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Purchase Receipt No:<asp:Label ID="lblPurchaseReceiptNo" runat="server" Text=""></asp:Label></small><br />
					<small>Purchase Receipt Date:<asp:Label ID="lblPurchaseReceiptdate" runat="server" Text=""></asp:Label></small>
                        <asp:Label ID="lblPurchasereceiptId" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				 </li>






                      </ul>


            </div>


           <h6 class="heading-hr">Material Issued for Project</h6> 


              <div class="form-group">
                  <ul class="info-blocks">
				
				<li class="bg-danger">
					<div class="top-info">
						<a href="#">Material Issued</a>
                        <small>
                            <asp:Label ID="lblMaterialIssuedStatus" runat="server" Text=""></asp:Label></small>
					</div>
					<small>Material Issue No:<asp:Label ID="lblMaterialissueno" runat="server" Text=""></asp:Label></small><br />
					<small>Material Issue Date:<asp:Label ID="lblMaterialissuedate" runat="server" Text=""></asp:Label></small>
                        <asp:Label ID="lblmaterialissueid" Visible="false" runat="server" Text=""></asp:Label>
                    
                    <span class="bottom-info bg-primary">View in Detail</span>
				</li>

                      </ul>
               </div>



            </div>
        </div>






    <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog modal-lg">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Quatation Details</h4>
      </div>
      <div class="modal-body">
       <asp:Panel ID="QPanel" runat="server" >

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                  <h6 class="heading-hr">Total Quatations Prepared for the Project <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label></h6> 



                                    <div class="form-group">

                                        <asp:GridView ID="gvTotalQuatations" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False"  >
                                              <Columns>
                                                   <asp:BoundField DataField="Quotation_Id" HeaderText="Sl.No" SortExpression="Quotation_Id"></asp:BoundField>
                                                   <asp:BoundField DataField="QUOTNO" HeaderText="Quotation No" SortExpression="QUOTNO"></asp:BoundField>
                                                   <asp:BoundField DataField="Quotation_Date" HeaderText="Date" SortExpression="Quotation_Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                                   <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal"></asp:BoundField>
                                                   <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                                             </Columns>
                                        </asp:GridView>




                                    </div>

                                     
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>





</asp:Content>

