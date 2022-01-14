<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesTermsCondtion_Details.aspx.cs" Inherits="Modules_Masters_SalesTermsCondtion_Details" %>
<%@ Register namespace="mycontrols" tagprefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%--   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>--%>
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Terms & Conditions</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="SalesTerms_Conditions.aspx">Terms & Conditions</a></li>
            <li class="active">Terms & Conditions Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Terms & Conditions Name :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtConditionsName" CssClass="validate[required] form-control" placeholder="Enter Conditions Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtConditionsName" runat="server" ErrorMessage="Please Enter Conditions Name"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Description :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Height="200" runat="server"></asp:TextBox>
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

           
       <%-- </ContentTemplate> </asp:UpdatePanel>--%>

</asp:Content>