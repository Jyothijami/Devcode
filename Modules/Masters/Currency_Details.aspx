<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Currency_Details.aspx.cs" Inherits="Modules_Masters_Currency_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Currency Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="Currency.aspx">Currency</a></li>
            <li class="active">Currency Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Currency Name :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtcurrencyName" CssClass="validate[required] form-control" placeholder="Enter Currency Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcurrencyName" runat="server" ErrorMessage="Please Enter Currency Name"></asp:RequiredFieldValidator>
                    </div>
                </div>


                 <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Currency Full Name :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtcurrencyfullname" CssClass="validate[required] form-control" placeholder="Enter Currency Full Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtcurrencyfullname" runat="server" ErrorMessage="Please Enter Currency full Name"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Description :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
