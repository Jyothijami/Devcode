<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Quatation_Changeables.aspx.cs" Inherits="Modules_Masters_Quatation_Changeables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>--%>

            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Quatation Changables</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li class="active">Quatation Changables</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Euro Price(In INR) :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEuroPrice" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Freight(%) :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtFreight" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Customs(%) :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtCustoms" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Insurance(%) :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtInsurance" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Clearance(%) :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClearance" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Wastage(%) :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtwastage" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="panel panel-default">

                            <div class="panel-heading">
                                <h6 class="panel-title"></h6>
                            </div>

                            <div class="panel-body">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Wall Plugs(Rs) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtWallplugs" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Silicon(Rs) :</label>
                                    <div class="col-sm-1">
                                        <asp:TextBox ID="txtSilicon" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <label class="col-sm-1 control-label text-right">Width*Depth:</label>
                                    <div class="col-sm-1">
                                        <asp:TextBox ID="txtSiliconWidth" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <asp:TextBox ID="txtSiliconDepth" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Masking Tape(Rs) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtmaskingpape" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">BackorRod(Rs) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtbackrod" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">

                            <div class="panel-heading">
                                <h6 class="panel-title"></h6>
                            </div>

                            <div class="panel-body">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Fabrication(Per Sq ft)(Rs) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFabricationPersqft" OnTextChanged="txtFabricationPersqft_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Fabrication(Per Sq Mt)(Rs) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtfabricationPersqmt" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Installation(Per Sq Ft)(Rs) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtinstallationpersqft" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtinstallationpersqft_TextChanged" runat="server"></asp:TextBox>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Installation(Per Sq Mt)(Rs):</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtInstallationpersqmt" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Margin(%) :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtmargin" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Submit" />
                        </div>
                    </div>
                </div>
            </div>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>