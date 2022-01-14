<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesDamageTemplate_Details.aspx.cs" Inherits="Modules_Masters_SalesDamageTemplate_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page-header">
        <div class="page-title">
            <h3>Sales Damage Terms & Conditions</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="SalesDamage_Template.aspx">Sales Damage Terms & Conditions</a></li>
            <li class="active">Sales Damage Terms & Conditions Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Sales Damage Terms & Conditions :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtConditionsName" CssClass="validate[required] form-control" placeholder="Enter Conditions Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtConditionsName" runat="server" ErrorMessage="Please Enter Conditions Name"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Description :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" CssClass="editor" placeholder="Enter Description" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>
                   
                         <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender5" TargetControlID="txtDescription" EnableSanitization="false" DisplaySourceTab="false" 
                                                runat="server" />
                         </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

