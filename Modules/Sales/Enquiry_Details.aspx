<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Enquiry_Details.aspx.cs" Inherits="Modules_Sales_Enquiry_Details" %>

<%--<%@ MasterType VirtualPath="~/NLMain.master" %>--%>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

    <script type="text/javascript">
        $(function () {
            $("#btnCustSave").click(function () {
                $("#myModal").modal("hide");
            });
        });
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=txtCustomerName.ClientID%>").keyup(function () {
                var username = $(this).val();

                if (username.length >= 3) {
                    $.ajax({
                        url: 'UserName.asmx/UserNameExists',
                        method: 'get',
                        data: { userName: username },

                        dataType: 'json',

                        success: function (data) {

                            var divElement = $('#divOutput');
                            if (data.UserNameInUse) {
                                divElement.text(data.CustName + ' already Exist');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.CustName + ' available');
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    })
                }

            })
        })
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=txtnewarchitectname.ClientID%>").keyup(function () {
                var username = $(this).val();

                if (username.length >= 3) {
                    $.ajax({
                        url: 'Architect.asmx/ArchNameExists',
                        method: 'get',
                        data: { userName: username },

                        dataType: 'json',

                        success: function (data) {

                            var divElement = $('#divOutput2');
                            if (data.UserNameInUse) {
                                divElement.text(data.Name + ' already Exist');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.Name + ' available');
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    })
                }

            })
        })
    </script>

    <script type="text/javascript">
        function hi() {
            // event.preventDefault();
            swal({
                title: 'System Meassage',
                text: "Data Submitted Sucessfully",
                type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
            })
            .then(function () {
                // Set data-confirmed attribute to indicate that the action was confirmed
                window.location = 'SalesEnquiry.aspx';
            }).catch(function (reason) {
                // The action was canceled by the user
            });

        }
    </script>
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Enquiry Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="SalesEnquiry.aspx">Enquiry</a></li>
            <li class="active">Enquiry Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h6 class="panel-title">Enquiry Details</h6>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Status :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtstatus" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Enquiry No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEnquiryno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Enquiry Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEnquirydate" name="trigger" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                <asp:Image
                                    ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                    TargetControlID="txtEnquirydate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">
                                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">New Customer</button><%--<asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="New" OnClick="btnAddnew_Click" />--%>
                            Customer :
                            </label>
                            <div class="col-sm-4">

                                <asp:DropDownList ID="ddlClinet" Width="100%" TabIndex="2" CssClass="select-full" runat="server" OnSelectedIndexChanged="ddlClinet_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Project :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlClinetSite" Width="100%" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlClinetSite_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <%-- <div class="col-sm-3">
                                     <asp:TextBox ID="lblCustomerName" runat="server" CssClass="form-control disabled"  Text=""></asp:TextBox>
                                     </div>
                                    <div class="col-sm-3">
                                         <asp:TextBox ID="lblCustomerMobile" runat="server" CssClass="form-control disabled"   Text=""></asp:TextBox>
                                    </div>
                                 </div>

                                <div class="form-group">

                                  <%--  <div class="col-sm-3">
                                     <asp:TextBox ID="lblUnitName" runat="server"  CssClass="form-control disabled"  Text=""></asp:TextBox>
                                     </div>
                                    <div class="col-sm-3">
                                       <asp:Label ID="lblUnitAddress" runat="server" CssClass="form-control disabled"   Text=""></asp:Label>
                                    </div>
                                 </div>--%>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">

                    <div class="panel-heading">
                        <div>
                            <h5 class="panel-title">Address & Contact</h5>
                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Client Information </label>
                            <div class="col-sm-4">
                            </div>
                            <label class="col-sm-2 control-label text-right">Client Site Information </label>
                            <div class="col-sm-4">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Contact Person :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Contact Person :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientSiteContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Mobile No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientMobilenO" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Mobile No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientSiteMobile" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Address :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientAddress" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Address :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientSiteAdress" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">

                    <div class="panel-heading">
                        <div>
                            <h5 class="panel-title">Architects Details</h5>
                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">
                                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal1">New Architect</button>Architect Name :
                            </label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlArchitectName" Width="100%" TabIndex="2" CssClass="select-full" runat="server" OnSelectedIndexChanged="ddlArchitectName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">Architect Mobile : </label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtarchitectmobile" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Architect Email :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtarchemail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Architect Address :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtarchitectaddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">

                    <div class="panel-heading">
                        <div>
                            <h5 class="panel-title">Product Required</h5>
                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Enquiry Source :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtenquirySource" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Segment :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlMarketSegment" CssClass="form-control" Width="100%" runat="server">
                                    <asp:ListItem>Lower</asp:ListItem>
                                    <asp:ListItem>Middle</asp:ListItem>
                                    <asp:ListItem>Upper</asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:TextBox ID="txtsegment" CssClass="form-control" runat="server"></asp:TextBox>--%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Product Required: </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtproductRequired" CssClass="form-control" TextMode="MultiLine" Columns="4" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Glass Specifications :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtglassspecifications" CssClass="form-control" TextMode="MultiLine" Columns="4" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Profile Finish :</label>
                            <div class="col-sm-10">
                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtpowercoating" runat="server" CssClass="styled" Text="Powder Coating" />
                                </label>

                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtanodizing" runat="server" CssClass="styled" Text="Anodizing" />
                                </label>

                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtwoodeffect" runat="server" CssClass="styled" Text="Wood Effect" />
                                </label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Flyscreen/Mesh :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtglasssthickness" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Architectural Drawings Attached :</label>
                            <div class="col-sm-4">
                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtardrawattachedyes" runat="server" GroupName="draw" CssClass="styled" Text="Yes" />
                                </label>

                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtardrawattachedNo" runat="server" CssClass="styled" GroupName="draw" Text="No" />
                                </label>
                            </div>

                            <label class="col-sm-2 control-label text-right">Site Photos Attached :</label>
                            <div class="col-sm-4">
                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtsitephotyes" runat="server" GroupName="photo" CssClass="styled" Text="Yes" />
                                </label>

                                <label class="radio-inline">
                                    <asp:RadioButton ID="rbtsitephotno" runat="server" CssClass="photo" GroupName="photo" Text="No" />
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default" runat="server" visible="false">

                    <div class="panel-heading">
                        <div>
                            <h5 class="panel-title">Follow Up</h5>
                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Next Contact By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlnextContactBy" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Next Contact Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtNextContactDate" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:Image
                                    ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                    TargetControlID="txtNextContactDate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">To Discuss</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txttodiscuss" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Glass Color/Code :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtglasscolorcode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-danger">

                    <div class="panel-heading">
                        <div>
                            <h5 class="panel-title">Incharge Details of Enquiry</h5>
                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Sales in Charge: </label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlsalesincharge" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <div runat="server" visible="false">
                                <label class="col-sm-2 control-label text-right">Design in Charge:  </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddldesignincharge" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Prepared By:</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlpreparedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <%-- <label class="col-sm-2 control-label text-right">Approved By:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlapprovedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>--%>
                        </div>
                    </div>
                </div>

                <div class="panel-body">

                    <div class="form-group">

                        <div class="form-actions text-right">
                            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />
                            <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" />
                            <asp:Button ID="btnRevise" runat="server" CssClass="btn btn-info" OnClick="btnRevise_Click" Text="Revise" />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>

                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-lg">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Add Customer Details</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Panel ID="QPanel" runat="server">

                                    <div class="form-horizontal">
                                        <div class="panel panel-default">
                                            <div class="panel-body">

                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h3 class="panel-title">Customer Details</h3>
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="form-group">

                                                            <label class="col-sm-2 control-label text-right">Customer No :</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtCustNo" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                            <label class="col-sm-2 control-label text-right">Customer Name :</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server"></asp:TextBox>
                                                                <span id="divOutput"></span>
                                                                <span id="CustomerDetails"></span>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="col-sm-2 control-label text-right">Customer Mobile :</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtcustmobile" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                            <label class="col-sm-2 control-label text-right">Customer Address:</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtCustaddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCustSave" class="btn btn-danger" runat="server" Text="Save" OnClick="btnCustSave_Click" />
                                <button type="button" id="btndiaclose" runat="server" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="myModal1" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-lg">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Add Architect Details</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Panel ID="Panel1" runat="server">

                                    <div class="form-horizontal">
                                        <div class="panel panel-default">
                                            <div class="panel-body">

                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h3 class="panel-title">Architect Details</h3>
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="form-group">

                                                            <label class="col-sm-2 control-label text-right">Architect Name:</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtnewarchitectname" CssClass="form-control" runat="server"></asp:TextBox>
                                                                <span id="divOutput2"></span>
                                                                <span id="CustomerDetails1"></span>
                                                            </div>

                                                            <label class="col-sm-2 control-label text-right">Mobile NO :</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtnewarchitectmobile" CssClass="form-control" runat="server"></asp:TextBox>
                                                                <span id="divOutput1"></span>
                                                                <span id="ArchitectDetails"></span>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="col-sm-2 control-label text-right">Email :</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtnewarchitectemail" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                            <label class="col-sm-2 control-label text-right">Address:</label>
                                                            <div class="col-sm-4">
                                                                <asp:TextBox ID="txtnewarchitectaddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnarchsave" class="btn btn-danger" runat="server" Text="Save" OnClick="btnarchsave_Click" />
                                <button type="button" id="Button2" runat="server" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>