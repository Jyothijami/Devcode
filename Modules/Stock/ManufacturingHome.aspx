<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ManufacturingHome.aspx.cs" Inherits="Modules_Stock_ManufacturingHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">
                    <h6><i class="icon-paragraph-justify"></i>Manufacturing </h6>
                </div>
            </div>

            <div class="panel-body">

                <div class="row">

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Production  </span>
                            <div class="well">
                                <div class="list-group">
                                   <%-- <a href="ProductionOrder.aspx" class="list-group-item">Production Order</a>--%>


                                     <a href="../Production/SOOpertions.aspx" class="list-group-item">Work Order</a>
                                    <a href="IssueRequest.aspx" class="list-group-item">Material Request(Issue Slip)</a>
                                    <a href="RGP_Request.aspx" class="list-group-item">Request RGP</a>
                                    <a href="NRGP_Request.aspx" class="list-group-item">Request NRGP</a>

                                      <a href="RequestPackingList.aspx" class="list-group-item">Request PackingList</a>
                                   <%--  <a href="MaterialTransferManufacture.aspx" class="list-group-item">Material Transfer Manufacture</a>--%>
                               
                                          <a href="BlukReturnRequest.aspx" class="list-group-item">Return Material Request</a>
                                          <a href="GlassRequestMast.aspx" class="list-group-item">Glass Request</a>

                                       <a href="RequestBlockStockL.aspx" class="list-group-item">Request Blocked Stock</a>
                                    
                                     </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Bill of Materials </span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="Bom.aspx" class="list-group-item">Bill of Materials  </a>
                                      <a href="../Masters/Operations.aspx" class="list-group-item">BOM Operations</a>
                                    <a href="../Masters/Item.aspx" class="list-group-item">Item  </a>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="block">
                            <span class="subtitle">Reports </span>
                            <div class="well">
                                <div class="list-group">
                                    <a href="CustomerBom_List.aspx" class="list-group-item">BOM Search </a>
                                    <a href="IssueSlipRequest_List.aspx" class="list-group-item">Material Request Slip Details </a>
                                    <a href="RGPRequest_List.aspx" class="list-group-item">RGP Request List </a>
                                    <a href="#" class="list-group-item">Issued Items Against Production Order </a>
                                    <a href="#" class="list-group-item">Completed Production Orders </a>
                                  
                                </div>
                            </div>
                        </div>
                    </div>


                    
                </div>



                  





            </div>
        </div>





</asp:Content>

