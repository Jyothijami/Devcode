<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="Modules_Sales_CustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <li><a href="CustomerMaster.aspx">Customer</a></li>
            <li class="active">Customer Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-pencil"></i>Customer Details</h6>
        </div>
        <div class="panel-body">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Customer Basic Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Salutation : <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlTitle" TabIndex="2" Width="100%" CssClass="select-full" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <label>Customer Code : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustomerCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Name : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Customer Company Name : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-3">
                                <label>Designation: <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlcustdesignation" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <label>Phone No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustPhone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Customer Mobile No : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Customer Fax No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustFaxNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Customer E-Mail : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Region : <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlregion" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <label>Address : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustAddress" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%-- <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Project Incharge Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Person <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtContactPerson" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Designation: <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlDesignation" TabIndex="2" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Phone Number: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" placeholder="Enter Phone No" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Mobile Number: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtMobileNo" CssClass="form-control" placeholder="Enter Mobile No" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Fax No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtFaxNo" CssClass="form-control" placeholder="Enter Fax No" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Email: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtEmailId" CssClass="form-control" placeholder="Enter E-Mail Id" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Address : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCorporateAddress" Rows="3" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Corporate Address" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Site Incharge Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Person <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtsitecontactPerson" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Mobile No <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtsitemobileno" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <label>Address <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtsiteAddress" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Architect Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Person <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtarchiname" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Mobile No <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtarchimobileno" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <label>Address <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtarchiaddress" CssClass="form-control" placeholder="Enter Contact Person Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Referred By Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Person <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtrefbyname" CssClass="form-control" placeholder="Enter Referer Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Mobile No <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtrefbymobileno" CssClass="form-control" placeholder="Enter Referer Mobile" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <label>Address <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtrefbyaddress" CssClass="form-control" placeholder="Enter Address" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%-- <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Tax Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>GST No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtgstno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>PAN No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtpanno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>

            <div class="form-actions text-right">
                <input id="btnreset" type="reset" class="btn btn-danger" value="Reset" />
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
            </div>
        </div>
    </div>
</asp:Content>