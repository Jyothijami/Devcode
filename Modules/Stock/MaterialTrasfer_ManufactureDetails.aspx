<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MaterialTrasfer_ManufactureDetails.aspx.cs" Inherits="Modules_Stock_MaterialTrasfer_ManufactureDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <%--   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Material Transfer for Manufacture</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="ProductionOrder.aspx">Production Order</a></li>
                    <li class="active">Material Transfer for Manufacture</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            
            <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Production Order Details</h6>
        </div>
                <div class="panel-body">
                    <div class="panel-heading"><h5>Production Detials</h5></div>
        <div class="panel-body">


            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <label>Status : <span class="mandatory">*</span></label>
                        <asp:Button ID="btnstatus" OnClick="btnstatus_Click" CssClass="btn-danger" runat="server" Text="" />
                    </div>
                    </div>
            </div>



            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <label>Production Order No: <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlproductionNo" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Bom No: <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlbomno" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Item Name: <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlitem" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>For Quantity: <span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtforquantity" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>


            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <label>Work in Progress Warehouse : <span class="mandatory">*</span></label>
                         <asp:DropDownList ID="ddlworkinprogress" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Scarp Warehouse : <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlScarpwarehouse" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Target Warehouse : <span class="mandatory">*</span></label>
                          <asp:DropDownList ID="ddlTargetWarehouse" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>

                    </div>
                    
                </div>
            </div>
          
        </div>
                </div>

        


     
            <div class="panel-body">
            <div class="panel-heading"><h5>Items to Transfer</h5></div>
            <div class="datatable" style="padding-top: 0px">
                                <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                                    Width="100%">
                                    <Columns>
                                          <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" OnClick="lbtnEdit_Click"><i class="icon-wrench2"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" />
                                        <asp:BoundField DataField="Color" HeaderText="Color" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                          <asp:BoundField DataField="Barlength" HeaderText="Barlength" />
                                        <asp:BoundField DataField="Required" HeaderText="Required(Barlength)" />
                                        <asp:BoundField DataField="Transferqty" HeaderText="Transfered qty" />
                                        <asp:BoundField DataField="UOM" HeaderText="UOM" />


                                          <asp:BoundField DataField="Swarehouse" HeaderText="Source Warehouse" />
                                        <asp:BoundField DataField="Twarehouse" HeaderText="Target Warehouse" />
                                        <asp:BoundField DataField="Scrapwarehouse" HeaderText="Scarp Warehouse" />




                                        <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                        <asp:BoundField DataField="ColorId" HeaderText="ColorId" />

                                           <asp:BoundField DataField="SwarehouseId" HeaderText="Source Warehouse" />
                                        <asp:BoundField DataField="TwarehouseId" HeaderText="Target Warehouse" />
                                        <asp:BoundField DataField="ScrapwarehouseId" HeaderText="Scarp Warehouse" />

                                          <asp:BoundField DataField="PrdetId" HeaderText="PrdetId" />


                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="text-align: center">
                                            <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>

        </div>
       


           
            <div class="panel-body" id="tblDetails" runat="server" visible="true">
                    <div class="panel-heading"><h5>Production Detials</h5></div>
        <div class="panel-body">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-3">
                        <label>Item Code: <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlitemcode" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Color : <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Source Warehouse : <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlitemSourceWarehouse" OnSelectedIndexChanged="ddlitemSourceWarehouse_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <label>Target Warehouse: <span class="mandatory">*</span></label>
                        <asp:DropDownList ID="ddlitemTargetwarehouse" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>


                  

            </div>


            <div class="form-group">
                <div class="row">

                     <div class="col-md-3">
                        <label>UOM : <span class="mandatory">*</span></label>
                          <asp:TextBox ID="txtitemuom" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>

                    </div>

                     <div class="col-md-3">
                        <label>Actual Qty at Source warehouse:<span class="mandatory">*</span></label>
                        <asp:TextBox ID="txtItemqtyatsourcewarehouse" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Req Qty : <span class="mandatory">*</span></label>
                         <asp:TextBox ID="txtitemreqqty" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>
                    </div>
                   
                   

                     <div class="col-md-3">
                        <label>Transfer Qty : <span class="mandatory">*</span></label>
                          <asp:TextBox ID="txtitemtranserqty" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>

                    </div>
                    
                </div>
            </div>




            <div class="form-group">

                <div class="row">
                    <asp:Label ID="lblProddetid" runat="server" Text=""></asp:Label>
                </div>


            </div>

            <div class="form-actions text-right">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            </div>


          
        </div>
                </div>


        
    </div>

   





<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>



</asp:Content>

