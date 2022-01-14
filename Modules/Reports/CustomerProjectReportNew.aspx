<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="CustomerProjectReportNew.aspx.cs" Inherits="Modules_Reports_CustomerProjectReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script lang="javascript" type="text/javascript">
        function OpenPopupCenter(pageURL, title, w, h) {
            var left = (screen.width - w) / 2;
            var top = (screen.height - h) / 4;  // for 25% - devide by 4  |  for 33% - devide by 3
            var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }
    </script>

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

    <div class="form-horizontal">

        <div class="panel panel-info">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Customer Details</h6>
            </div>
            <div class="panel-body">




                <div class="form-group">


                    <label class="col-md-2 control-label text-right">Select Project : <span class="mandatory">*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlSoId" TabIndex="2" Width="100%" CssClass="select-full" OnSelectedIndexChanged="ddlSoId_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>


                </div>




                <div class="form-group">


                    <label class="col-md-2 control-label text-right">Customer : <span class="mandatory">*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlCustomer" TabIndex="2" Width="100%" CssClass="select-full" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>

                    <label class="col-md-2 control-label text-right">Project : <span class="mandatory">*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlproject" TabIndex="2" Width="100%" CssClass="select-full" OnSelectedIndexChanged="ddlproject_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                


                <div class="panel panel-danger">
                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil"></i>Customer Sales Information</h6>
                    </div>

                    <div class="panel-body">
                        <ul class="info-blocks">

                            <%-- Sales Enquiry Information --%>

                            <li class="bg-info">

                                <div class="top-info">

                                    <a href="#">Sales Enquiry</a><hr />

                                    <strong>No.Of Enquires :<asp:Label ID="lblEnquiryCount" runat="server" Text="0"></asp:Label>
                                    </strong>

                                </div>

                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalSalesEnq">View Details</span>
                            </li>


                            <%-- Sales Quatations --%>

                            <li class="bg-info">

                                <div class="top-info">

                                    <a href="#">Sales Quatation</a><hr />

                                    <strong>No.Of Quatations :<asp:Label ID="lblquationscount" runat="server" Text="0"></asp:Label>
                                    </strong>

                                </div>

                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModal">View Details</span>
                            </li>

                            <%-- Sales Order --%>

                            <li class="bg-info">

                                <div class="top-info">

                                    <a href="#">Sales Order</a><hr />

                                    <strong>Status :<asp:Label ID="lblsalesorderstatus" runat="server" Text="Not Prepared"></asp:Label>
                                    </strong>

                                </div>

                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalSales">View Details</span>
                            </li>



                            <%-- Bom  --%>

                              <li class="bg-info">

                                <div class="top-info">

                                    <a href="#">BOM(<asp:Label ID="lblbomstatus" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Items :<asp:Label ID="lblbomcount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>

                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalBOM">View Details</span>
                            </li>


                             <%-- Indents Raised --%>

                            <li class="bg-info">

                                <div class="top-info">

                                    <a href="#">Indents</a><hr />

                                    <strong>No.Of Indents Raised :<asp:Label ID="lblindentscount" runat="server" Text="0"></asp:Label>
                                    </strong>

                                </div>

                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalIndent">View Details</span>
                            </li>

                        </ul>

                    </div>


                </div>


                


                <div class="panel panel-danger">
                     <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil"></i>Purchases Information</h6>
                    </div>


                 <div class="panel-body">
                      <ul class="info-blocks">

                            <%-- Purchase Orders --%>

                            <li class="bg-info">

                                <div class="top-info">

                                    <a href="#">Purchase Orders</a><hr />

                                    <%--<strong>No.Of PO's :<asp:Label ID="lblnoofpos" runat="server" Text="0"></asp:Label>
                                    </strong>--%>

                                </div>

                              <%--  <span class="bottom-info bg-primary" >   <a runat="server" href='<%# "~/Modules/Reports/Details/POs.aspx?Cid=" + ddlSoId.SelectedItem.Value %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View Details</a>
</span>--%>


                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalPOs">View Details</span>


                            </li>
                          </ul>
                 </div>
                </div>

                

                <div class ="panel panel-danger">
                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil"></i>Manufacture Information</h6>
                    </div>

                    <div class="panel-body">
                        <ul class="info-blocks">
                            <%-- Issue Request --%>
                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">Issue Rqst(<asp:Label ID="lblNoOfIRs" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblNoOfIRscount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalIssReq">View Details</span>
                            </li>

                            <%-- NRGP --%>

                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">NRGP Rqst(<asp:Label ID="lblNRGP" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblNRGPcount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalNRGPRqst">View Details</span>
                            </li>

                            <%-- RGP --%>

                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">RGP Rqst(<asp:Label ID="lblRGPRqst" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblRGPRqstCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalRGPRqst">View Details</span>
                            </li>

                            <%-- Req Packing List --%>

                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">PackingList Rqst(<asp:Label ID="lblPLReq" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblPLReqCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalPLRqst">View Details</span>
                            </li>

                             <%-- Req Packing List --%>

                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">Glass Rqst(<asp:Label ID="lblGlassRqst" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblGlassRqstCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalGlassRqst">View Details</span>
                            </li>

                            <%-- SO Operations List --%>

                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">SO Operation(<asp:Label ID="lblSoOperations" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblSoOperationsCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalSOOperations">View Details</span>
                            </li>
                        </ul>
                    </div>
                </div>

                <div class ="panel panel-danger">
                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil"></i>Stores Information</h6>
                    </div>
                    <div class="panel-body">
                        <ul class="info-blocks">
                            <%-- Material Issue --%>
                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">Material Issue (<asp:Label ID="lblIssue" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblIssueCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalIssue">View Details</span>
                            </li>

                            <%-- NRGP Issue --%>
                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">NRGP Issue (<asp:Label ID="lblNRGPIssue" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblNRGPIssueCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalIssNRGP">View Details</span>
                            </li>

                            <%-- RGP Issue --%>
                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">RGP Issue (<asp:Label ID="lblRGPIssue" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblRGPIssueCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalIssRGP">View Details</span>
                            </li>

                            <%-- Packing List Issue --%>
                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">Placking List Issue (<asp:Label ID="lblPLIssue" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblPLIssueCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalPLIssue">View Details</span>
                            </li>

                             <%-- Glass Issue --%>
                            <li class="bg-info">
                                <div class="top-info">

                                    <a href="#">Glass Issue (<asp:Label ID="lblGlassIssue" runat="server" Text="Not Prepared"></asp:Label>)</a><hr />

                                    <strong>
                                       
                                        No of Requests :<asp:Label ID="lblGlassIssueCount" runat="server" Text="0"></asp:Label>

                                    </strong>

                                </div>
                                <span class="bottom-info bg-primary" data-toggle="modal" data-target="#myModalGlassIssue">View Details</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>










        

            



        </div>
    </div>

    <%-- NRGP Modal --%>
    <div id="myModalNRGPRqst" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Request NRGP Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel6" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">NRGP Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvNRGPRqst" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="NRGP_Request_Id" HeaderText="Sl.No" SortExpression="NRGP_Request_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NRgp_Request_No" HeaderText="NRGP Request No" SortExpression="NRgp_Request_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="NRgp_Request_Date" HeaderText="Date" SortExpression="NRgp_Request_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Receiver_Name" HeaderText="Receiver Name" SortExpression="Receiver_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Preparedb" HeaderText="Prepared By" SortExpression="Preparedb">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/NRGPRequestDetails.aspx?Cid=" + Eval("NRGP_Request_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

     <%-- RGP Modal --%>
    <div id="myModalRGPRqst" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Request RGP Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel7" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">RGP Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvRGPRqst" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="RGP_Request_Id" HeaderText="Sl.No" SortExpression="RGP_Request_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rgp_Request_No" HeaderText="RGP Request No" SortExpression="Rgp_Request_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Rgp_Request_Date" HeaderText="Date" SortExpression="Rgp_Request_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Receiver_Name" HeaderText="Receiver Name" SortExpression="Receiver_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                      <asp:BoundField DataField="Preparedb" HeaderText="Prepared By" SortExpression="Preparedb">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/RGPRequestDetails.aspx?Cid=" + Eval("RGP_Request_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Packing List Rqst Modal --%>
    <div id="myModalPLRqst" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Request Packing List Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel8" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Packing List Request Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvPLRqst" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="RPackingList_Id" HeaderText="Sl.No" SortExpression="RPackingList_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RPackingList_No" HeaderText="Request Packing No" SortExpression="RPackingList_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="RPackingList_Date" HeaderText="Date" SortExpression="RPackingList_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Cust_Address" HeaderText="Cust Address" SortExpression="Cust_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    
                    <asp:BoundField DataField="Delivery_Address" HeaderText="Delivery Address" SortExpression="Delivery_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                       <asp:BoundField DataField="PreparedBy" HeaderText="Prepared By" SortExpression="PreparedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Approvedby" HeaderText="Approved By" SortExpression="Approvedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/PLRequestDetails.aspx?Cid=" + Eval("RPackingList_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Packing List Rqst Modal --%>
    <div id="myModalPLIssue" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Issued Packing List Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel13" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Packing List Issue Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvPLIssue" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="PackingList_Id" HeaderText="Sl.No" SortExpression="PackingList_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PackingList_No" HeaderText="Packing list No" SortExpression="PackingList_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="PackingList_Date" HeaderText="Date" SortExpression="PackingList_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                  

                    <asp:BoundField DataField="Cust_Address" HeaderText="Cust Address" SortExpression="Cust_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    
                    <asp:BoundField DataField="Delivery_Address" HeaderText="Delivery Address" SortExpression="Delivery_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/PLIssueDetails.aspx?Cid=" + Eval("PackingList_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Glass Request Modal --%>
    <div id="myModalGlassRqst" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Glass Request Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel9" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Glass Request Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvGlassRqst" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="GlasslRequest_Id" HeaderText="Sl.No" SortExpression="GlasslRequest_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GlasslRequest_No" HeaderText="Glass Request No" SortExpression="GlasslRequest_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Required_Date" HeaderText="Date" SortExpression="Required_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Requested_For" HeaderText="Requested For" SortExpression="Requested_For" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <%--<asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>

                    


                      <asp:BoundField DataField="Prepared_By" HeaderText="Prepared By" SortExpression="Prepared_By">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Approved_by" HeaderText="Approved By" SortExpression="Approved_by">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/GlassRequestDetails.aspx?Cid=" + Eval("GlasslRequest_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Quatation Details Modal --%>
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Quatation Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="QPanel" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <h6 class="heading-hr">Total Quatations Prepared for the Project
                                    </h6>



                                    <div class="form-group">

                                        <asp:GridView ID="gvTotalQuatations" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="QUOTNO" HeaderText="Quotation No" SortExpression="QUOTNO"></asp:BoundField>
                                                <asp:BoundField DataField="OptionKey" HeaderText="Option" SortExpression="OptionKey"></asp:BoundField>
                                                <asp:BoundField DataField="Quotation_Date" HeaderText="Date" SortExpression="Quotation_Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                                                <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>

                                                <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME"></asp:BoundField>

                                                <asp:BoundField DataField="GrandTotal" HeaderText="Total Amount" SortExpression="GrandTotal"></asp:BoundField>

                                                <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">
                                                            <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/Quatation_Documents.aspx?Cid=" + Eval("Quotation_Id") %>'><i class="icon-attachment"></i></asp:LinkButton>
                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">



                                                            <%--  <a runat="server"  href='<%# "~/Modules/Reports/Details/QuatationDetails.aspx?Cid=" + Eval("Quotation_Id") %>'  onclick="window.open(this.href, 'newwindow', 'width=500, height=500'); return false;"> View</a>--%>


                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/QuatationDetails.aspx?Cid=" + Eval("Quotation_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>






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

     <%-- Issue Request Modal --%>
    <div id="myModalIssReq" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Issue Rqst Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="pnlIssReq" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Requests Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvIssReq" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="Req_Issue_Id" HeaderText="Sl.No" SortExpression="Req_Issue_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Req_Issue_No" HeaderText="Request Issue No" SortExpression="Req_Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Req_Issue_Date" HeaderText="Date" SortExpression="Req_Issue_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Req_Purpose" HeaderText="Purpose" SortExpression="Req_Purpose">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:BoundField DataField="PreparedBy" HeaderText="Prepared By" SortExpression="PreparedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/IssueRequestDetails.aspx?Cid=" + Eval("Req_Issue_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Sales Enquires Modal --%>
    <div id="myModalSalesEnq" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Enquiry Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel1" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <h6 class="heading-hr">Enquiries Prepared for the Project
                                    </h6>



                                    <div class="form-group">

                                        <asp:GridView ID="gvEnquires" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">


                                            <Columns>

                                                <asp:BoundField DataField="enno" HeaderText="Enquiry No" SortExpression="enno"></asp:BoundField>

                                                <asp:BoundField DataField="ENQ_DATE" HeaderText="Date" SortExpression="ENQ_DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                                                <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>
                                                <asp:BoundField DataField="CUST_ADDRESS" HeaderText="Address" SortExpression="CUST_ADDRESS"></asp:BoundField>

                                                <asp:BoundField DataField="PRODUCT_REQURIED" HeaderText="Required" SortExpression="PRODUCT_REQURIED"></asp:BoundField>


                                                <asp:BoundField DataField="EstimationStatus" HeaderText="Estimation" SortExpression="EstimationStatus"></asp:BoundField>
                                                <asp:BoundField DataField="DesignerStatus" HeaderText="Designer" SortExpression="DesignerStatus"></asp:BoundField>


                                                <asp:TemplateField HeaderText="Attachments" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">


                                                            <asp:HyperLink ID="lbtnfloorplans" runat="server" CssClass="btn btn-icon btn-primary" Target="_blank" NavigateUrl='<%# "~/Modules/Sales/BoQFloorPlans.aspx?Cid=" + Eval("ENQ_ID") %>'>
                                                                <i class="icon-attachment"></i><strong class="label label-danger">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Cou") %>'></asp:Label></strong>
                                                            </asp:HyperLink>
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
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

    <%-- Sales Order Modal --%>
    <div id="myModalSales" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Sales Order Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel2" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <div class="form-group">

                                        <asp:GridView ID="gvSalesorder" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                                            <Columns>

                                                <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                    <ItemStyle Font-Size="Smaller" />
                                                </asp:BoundField>


                                                <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                    <ItemStyle Font-Size="Smaller" />
                                                </asp:BoundField>



                                                <asp:BoundField DataField="SalesOrder_Date" HeaderText="Date" SortExpression="SalesOrder_Date" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Delivery_Date" HeaderText="Delivery Date" SortExpression="Delivery_Date" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                                                    <HeaderStyle Font-Size="Smaller" />
                                                </asp:BoundField>




                                                <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">
                                                            <asp:HyperLink ID="lbtnDocuments" Target="_blank" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/SalesOrderDocs.aspx?Cid=" + Eval("SalesOrder_Id") %>'><i class="icon-attachment"></i></asp:HyperLink>
                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>









                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/SalesOrderDetails.aspx?Cid=" + Eval("SalesOrder_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>






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

    <%-- Issue Modal --%>
    <div id="myModalIssue" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Material Issue Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel10" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Material Issue Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvIssue" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="Issue_Id" HeaderText="Sl.No" SortExpression="Issue_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Issue_No" HeaderText="Issue No" SortExpression="Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Issue_Date" HeaderText="Date" SortExpression="Issue_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Req_Issue_No" HeaderText="Request_No" SortExpression="Req_Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                       <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="For Project" SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                       <asp:BoundField DataField="RequestedBy" HeaderText="Requested By" SortExpression="RequestedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IssuedBy" HeaderText="Issued By" SortExpression="IssuedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/MaterialIssueDetails.aspx?Cid=" + Eval("Issue_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Sales BOM Modal --%>
    <div id="myModalBOM" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">BOM for Project</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel3" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <div class="form-group">

                                        <asp:GridView ID="gvbom" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False" Width="100%">


                                            <Columns>

                                               <asp:BoundField HeaderText="Item Code" DataField="Material_Code" />
                              <asp:BoundField HeaderText="Description" DataField="DESCRIPTION" />
                                 <asp:BoundField HeaderText="Color" DataField="Color_Name" />
                              <asp:BoundField HeaderText="Length" DataField="length" />
                                                
                                                 <asp:BoundField HeaderText="Unit" DataField="UNIT" />
                              <asp:BoundField HeaderText="BOM Qty" DataField="BOMQty" />
                              <asp:BoundField HeaderText="PU" DataField="PU" />
                                 <asp:BoundField HeaderText="Req Qty" DataField="REQUIRED_QTY" />
                              
                               <asp:BoundField HeaderText="Blocked" DataField="Blockedstock" />

                                <asp:BoundField HeaderText="FreeStock" DataField="FreeStock" />

                                

                             


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

    <%-- Material Indents --%>
    <div id="myModalIndent" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Indent Raised for Project</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel4" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <div class="form-group">

                                        <asp:GridView ID="gvIndent" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">


                                            <Columns>
  
                    <asp:BoundField DataField="MaterialRequest_No" HeaderText="Indent Request No" SortExpression="MaterialRequest_No">
                       
                    </asp:BoundField>

                    <asp:BoundField DataField="Requested_Date" HeaderText="Date" SortExpression="Requested_Date" DataFormatString="{0:dd/MM/yyyy}">
                       
                    </asp:BoundField>

                    <asp:BoundField DataField="Request_Type" HeaderText="Request Type" SortExpression="Request_Type">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="Required_Date" HeaderText="Required Date" SortExpression="Required_Date" DataFormatString="{0:dd/MM/yyyy}">
                    
                    </asp:BoundField>

                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                      
                    </asp:BoundField>

                    <asp:BoundField DataField="empname" HeaderText="Prepared By" SortExpression="empname">
                        
                    </asp:BoundField>

                 

                  
                                

                             


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

    <%-- Issue NRGP Modal --%>
    <div id="myModalIssNRGP" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">NRGP Issue Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel11" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Issue NRGP Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvIssNRGP" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="NRGP_Id" HeaderText="Sl.No" SortExpression="NRGP_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NRgp_No" HeaderText="NRGP No" SortExpression="NRgp_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="NRgp_Date" HeaderText="Date" SortExpression="NRgp_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Receiver_Name" HeaderText="Receiver Name" SortExpression="Receiver_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/NRGPIssueDetails.aspx?Cid=" + Eval("NRGP_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Issue RGP Modal --%>
    <div id="myModalIssRGP" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">RGP Issue Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel12" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Issue RGP Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvIssRGP" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="RGP_Id" HeaderText="Sl.No" SortExpression="RGP_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rgp_No" HeaderText="RGP No" SortExpression="Rgp_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Rgp_Date" HeaderText="Date" SortExpression="Rgp_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Receiver_Name" HeaderText="Receiver Name" SortExpression="Receiver_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/RGPIssueDetails.aspx?Cid=" + Eval("RGP_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Issue RGP Modal --%>
    <div id="myModalGlassIssue" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Glass Issue Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel14" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">Issue Glass Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvGlassIssue" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                                                <asp:BoundField DataField="Issue_Id" HeaderText="Sl.No" SortExpression="Issue_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Issue_No" HeaderText="Glass Request No" SortExpression="Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Issue_Date" HeaderText="Date" SortExpression="Issue_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Requested_For" HeaderText="Requested For" SortExpression="Requested_For" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="Req_Purpose" HeaderText="Request Type" SortExpression="Req_Purpose" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    


                      <asp:BoundField DataField="Reqested_By" HeaderText="Prepared By" SortExpression="Reqested_By">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Approved_by" HeaderText="Approved By" SortExpression="Approved_by">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">




                                                            <a runat="server" href='<%# "~/Modules/Reports/Details/GlassIssueDetails.aspx?Cid=" + Eval("Issue_Id") %>' onclick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</a>


                                                        </span>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <%-- Issue RGP Modal --%>
    <div id="myModalSOOperations" class ="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">SO Operations Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel15" runat="server">
                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h6 class="heading-hr">SO Operations Prepared for the Project
                                    </h6>


                                    <div class="form-group">
                                        <asp:GridView ID="gvSOOperations" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False">
                                            <Columns >
                           <asp:BoundField HeaderText ="Id" DataField ="Sow_OperationId" />
                           <asp:BoundField HeaderText ="Project Code" DataField ="ProjectCode" />
                           <asp:BoundField HeaderText="Window" DataField="Wincode" />

                           <%--  <asp:BoundField HeaderText="Strat Date" DataField="Start_Date" />--%>
                           <%--  <asp:BoundField HeaderText="End Date" DataField="End_Date" />--%>


                               <asp:TemplateField HeaderText="Start Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtstratdate" CssClass="form-control" ClientIDMode="AutoID" runat="server" Text='<%# Bind("Startdate") %>'></asp:TextBox>
                       
                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" 
                                TargetControlID="txtstratdate">
                            </cc1:CalendarExtender>
                        </ItemTemplate>
                    </asp:TemplateField>

                               <asp:TemplateField HeaderText="End Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtenddate" CssClass="form-control" runat="server" ClientIDMode="AutoID" Text='<%# Bind("EndDate") %>'></asp:TextBox>
                       
                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server"
                                TargetControlID="txtenddate">
                            </cc1:CalendarExtender>
                        </ItemTemplate>
                    </asp:TemplateField>



                             
                                <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                             <asp:Label ID="lblPriority" CssClass="" runat="server" Text='<%# Eval("priority") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlPriority" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="Low">Low</asp:ListItem>
                                                 <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                 <asp:ListItem Value="High">High</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                                <asp:TemplateField HeaderText="Cutting">
                                        <ItemTemplate>
                                             <asp:Label ID="lblCutting" CssClass="" runat="server" Text='<%# Eval("Cutting") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlcutting" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Floding">
                                        <ItemTemplate>
                                             <asp:Label ID="lblFloding" CssClass="" runat="server" Text='<%# Eval("Floding") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlFloding" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                              <asp:TemplateField HeaderText="Machining">
                                        <ItemTemplate>
                                             <asp:Label ID="lblMachining" CssClass="" runat="server" Text='<%# Eval("Machining") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlMachining" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Punching">
                                        <ItemTemplate>
                                             <asp:Label ID="lblPunching" CssClass="" runat="server" Text='<%# Eval("Punching") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlPunching" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                              <asp:TemplateField HeaderText="Shearing">
                                        <ItemTemplate>
                                             <asp:Label ID="lblShearing" CssClass="" runat="server" Text='<%# Eval("Shearing") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlShearing" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                                <asp:TemplateField HeaderText="Stamping">
                                        <ItemTemplate>
                                             <asp:Label ID="lblStamping" CssClass="" runat="server" Text='<%# Eval("Stamping") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlStamping" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                               <asp:TemplateField HeaderText="Casting">
                                        <ItemTemplate>
                                             <asp:Label ID="lblCasting" CssClass="" runat="server" Text='<%# Eval("Casting") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlCasting" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                               <asp:TemplateField HeaderText="Welding">
                                        <ItemTemplate>
                                             <asp:Label ID="lblWelding" CssClass="" runat="server" Text='<%# Eval("Welding") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlWelding" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                                <asp:TemplateField HeaderText="Finishing">
                                        <ItemTemplate>
                                             <asp:Label ID="lblFinishing" CssClass="" runat="server" Text='<%# Eval("Finishing") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlFinishing" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>




     <%-- Material POS --%>

    <div id="myModalPOs" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">PO's Raised for Project</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel5" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <div class="form-group">

                                        <asp:GridView ID="gvpo" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="Sup_PO_Id" HeaderText="Sl.No" SortExpression="Sup_PO_Id">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>
                <asp:BoundField DataField="Sup_PO_No" HeaderText="Sup PO No" SortExpression="Sup_PO_No">
                    <HeaderStyle Font-Size="Smaller" />
                    <ItemStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="Sup_PO_Date" HeaderText="Date" SortExpression="Sup_PO_Date" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="SUP_MOBILE" HeaderText="Mobile No" SortExpression="SUP_MOBILE">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>


                <asp:BoundField DataField="preparedby" HeaderText="Prepared By" SortExpression="preparedby">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>




                <asp:BoundField DataField="CustomerNo" HeaderText="CustomerNo" SortExpression="CustomerNo">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

             
                
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

