<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Modules_HR_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Change Password</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li class="active">Change Password</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">User Name:</label>
                    <div class="col-sm-10">
                         <asp:TextBox ID="txtUsername" runat="server" Enabled="False" Width="139px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="User Name Should Not Be Empty" ControlToValidate="txtUsername">*</asp:RequiredFieldValidator>

                    </div>
                </div>



                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Old Password :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtOldpassword" runat="server" TextMode="Password" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Old PassWord Should Be Empty" ControlToValidate="txtOldpassword">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">New Password :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNewpassword" runat="server" TextMode="Password" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="New PassWord Should Not Be Empty" ControlToValidate="txtNewpassword">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                  <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Confirm Password :</label>
                    <div class="col-sm-10">
                       <asp:TextBox ID="txtConfirmpassword" runat="server" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmpassword" ErrorMessage="Confirm Password Shouls Non Be Empty" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewpassword" ControlToValidate="txtConfirmPassWord" ErrorMessage="Passwords Mismatch" Display="Dynamic">*</asp:CompareValidator>
                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>

