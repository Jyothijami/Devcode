<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="ProductionOperations.aspx.cs" Inherits="Modules_Stock_ProductionOperations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Production Operations</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="ProductionOrder.aspx">Production Order</a></li>
                    <li class="active">Operations Completed for Production</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

       <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">
                         


                           <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Production Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlproducionno" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                                <label class="col-sm-2 control-label text-right">Bom No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlBomno" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
                        </div>
                               </div>

                    
                      





                        </div>
                    
           </div>
    </div>
</asp:Content>

