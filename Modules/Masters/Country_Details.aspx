<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Country_Details.aspx.cs" Inherits="Modules_Masters_Country_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

      <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Country Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="Country.aspx">Country</a></li>
            <li class="active">Country Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Country Name :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCountryName" CssClass="validate[required] form-control" placeholder="Enter Country Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCountryName" runat="server" ErrorMessage="Please Enter Country Name"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Currency :</label>
                    <div class="col-sm-10">
                       <asp:TextBox ID="txtCurrency" CssClass="validate[required] form-control" placeholder="Enter Currency Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCurrency" runat="server" ErrorMessage="Please Enter Currency Name"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>