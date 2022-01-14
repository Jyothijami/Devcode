<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="VendorMaster_Details.aspx.cs" Inherits="Modules_Purchases_VendorMaster_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
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
                 window.location = 'VendorMaster.aspx';
             }).catch(function (reason) {
                 // The action was canceled by the user
             });

         }


    </script>
   
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Supplier Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="VendorMaster.aspx">Supplier</a></li>
                    <li class="active">Supplier Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title"><i class="icon-pencil"></i>Supplier Details</h6>
                </div>
                <div class="panel-body">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Name and Type</h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">

                                    <div class="col-md-1"></div>

                                    <div class="col-md-2">
                                        <label>Title : <span class="mandatory">*</span></label>
                                        <asp:DropDownList ID="ddlTitle" TabIndex="2" CssClass="form-control" runat="server">
                                            <asp:ListItem>Select Title</asp:ListItem>
                                            <asp:ListItem>Mrs</asp:ListItem>
                                            <asp:ListItem>M/s</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3">
                                        <label>Supplier Type : <span class="mandatory">*</span></label>
                                        <asp:DropDownList ID="ddlSupplierType" TabIndex="2" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label>Supplier Name : <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtVendorName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-5">
                                        <label>Contact Person : <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>





                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <label>Supplier Address : <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtVendorAddress" Height="100px" CssClass="form-control" runat="server"></asp:TextBox>
                                          <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender1" TargetControlID="txtVendorAddress" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" />


                                    </div>

                                   <%-- <div class="col-md-5">
                                        <label>Contact Person Details : <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtContactPersondetails" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>--%>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label>Phone No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtphoneno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-5">
                                        <label>Mobile No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-1"></div>

                                    <div class="col-md-5">
                                        <label>E-Mail: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-5">
                                        <label>Fax No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtFaxno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label>Country : <span class="mandatory">*</span></label>
                                        <asp:DropDownList ID="ddlCountry" Width="100%" TabIndex="2" CssClass="select-full" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>

                                    <div class="col-md-5">
                                        <label>Billing Currency : <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtBillingCurrency" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title"><i class="icon-pencil"></i>Supplier Tax Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label>Pan No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtpanno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-5">
                                        <label>CST No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtCstno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">

                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label>VAT No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtvatno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-5">
                                        <label>GST No: <span class="mandatory">*</span></label>
                                        <asp:TextBox ID="txtgstno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions text-right">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>