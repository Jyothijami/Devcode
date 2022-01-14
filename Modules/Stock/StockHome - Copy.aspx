<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="StockHome.aspx.cs" Inherits="Modules_Stock_StockHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-title">
                <h6><i class="icon-paragraph-justify"></i>Stock </h6>
            </div>
        </div>

        <div class="panel-body">

            <div class="row">

                <div class="col-md-6">
                    <div class="block">
                        <span class="subtitle">Stock Transactions</span>
                        <div class="well">
                            <div class="list-group">

                                <a href="IndentApproval.aspx" class="list-group-item">Indent Approval</a>
                                <a href="PO_Reserve.aspx" class="list-group-item">Reserved Stock</a>
                                <a href="PurchaseGoodsReceipt.aspx" class="list-group-item">Material Receipt Note(MRN)</a>
                                <a href="MaterialIssue.aspx" class="list-group-item">Material Issued to Production(Issue Slip)</a>
                                <a href="RGP.aspx" class="list-group-item">RGP</a>
                                <a href="NRGP.aspx" class="list-group-item">NRGP</a>
                                <a href="BulkProductionReturn.aspx" class="list-group-item">Production Return</a>
                                <a href="Packinglist.aspx" class="list-group-item">Packing List</a>

                                <a href="MRN.aspx" class="list-group-item">MRN</a>

                                <a href="ToolRequest.aspx" class="list-group-item">Tools Issue</a>

                                <a href="GlassPurchaseReceipt.aspx" class="list-group-item">Glass MRN</a>
                                <a href="GlassIssueMast.aspx" class="list-group-item">Glass Issue</a>

                                   <a href="IssuedBlockStock.aspx" class="list-group-item">Block Issue</a>


                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="block">
                        <span class="subtitle">Stock Returns  </span>
                        <div class="well">
                            <div class="list-group">
                                <a href="Stock.aspx" class="list-group-item">Stock </a>
                                <a href="GlassStockBySo.aspx" class="list-group-item">Glass Stock by Project</a>
                                <a href="ConsumptionReport.aspx" class="list-group-item">Material Consumption By Project</a>
                                <a href="Inventory_Search.aspx" class="list-group-item">Inventory </a>
                                <a href="MRN_Search.aspx" class="list-group-item">MRN Search </a>
                                <a href="ScarpStock.aspx" class="list-group-item">Rejected Stock From MRN </a>
                                <a href="ScrapGlassDetails.aspx" class="list-group-item">Rejected Glass From MRN</a>

                                <a href="Return_Rgp.aspx" class="list-group-item">Return RGP </a>
                                <a href="Return_Nrgp.aspx" class="list-group-item">Return NRGP </a>
                                <%--   <a href="ReturnIssue.aspx" class="list-group-item">Return Issues </a>--%>
                                <%--   <a href="ProductionReturn.aspx" class="list-group-item">Return CutPieces </a>--%>

                                <a href="MRN_RejecedtoStock.aspx" class="list-group-item">Rejected Qty to Stock </a>
                                <a href="PurchaseOrderStatusUpdate.aspx" class="list-group-item">Purchase Order Status Update </a>
                                <a href="GlassPurchaseOrderStatus.aspx" class="list-group-item">Glass Purchase Order Status Update </a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="block">
                        <span class="subtitle">Items Stock </span>
                        <div class="well">
                            <div class="list-group">
                                <div class="list-group">
                                    <a href="../Masters/Item.aspx" class="list-group-item">Item</a>
                                    <%--   <a href="IssuedMaterialList.aspx" class="list-group-item">Issued List</a>--%>
                                    <a href="BlockedList.aspx" class="list-group-item">Blocked List</a>
                                    <a href="BlockFree.aspx" class="list-group-item">Free Blocked</a>
                                    <a href="FreeBlockedStockBySo.aspx" class="list-group-item">Free Blocked Stock By So</a>
                                    <a href="IndentRemainder.aspx" class="list-group-item">Remainder Indent</a>
                                    <a href="DeadStockReport.aspx" class="list-group-item">Non Moving Stock</a>
                                    <a href="DailyReceipts.aspx" class="list-group-item">Daily Receipts</a>
                                    <a href="IssuedStocktoProject.aspx" class="list-group-item">Total Consumption on Project</a>

                                    <a href="DatewiseStock.aspx" class="list-group-item">Date Wise Consumption</a>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>






            </div>
        </div>
    </div>
</asp:Content>
