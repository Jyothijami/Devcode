    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="Material_MrpData.aspx.cs" Inherits="Modules_Masters_Material_MrpData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Material Master</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="MaterialMaster.aspx">Material Master</a></li>
					<li class="active">MRP Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->







    <div class="panel panel-default">
	                <div class="panel-heading"><h6 class="panel-title"><i class="icon-pencil"></i> Material Purchase Data</h6></div>
	                <div class="panel-body">

						<div class="form-group">
							<div class="row">
								<div class="col-md-6">
									<label>Material Code: <span class="mandatory">*</span></label>
	                                <asp:TextBox ID="txtMaterialCode" CssClass="form-control"  runat="server"></asp:TextBox>
								</div>

								<div class="col-md-6">
									<label>Material Name: <span class="mandatory">*</span></label>
                                     <asp:TextBox ID="txtMaterialName" CssClass="form-control"  runat="server"></asp:TextBox>
								</div>
							</div>
						</div>
                        
                        <div class="form-group">
							<div class="row">
								<div class="col-md-6">
									<label>Company : <span class="mandatory">*</span></label>
	                               <asp:DropDownList ID="ddlCompany" TabIndex="2" CssClass="select-full" placeholder="Select Company"  runat="server"></asp:DropDownList>

								</div>

								<div class="col-md-6">
									<label>Plant Name: <span class="mandatory">*</span></label>
                                    <asp:DropDownList ID="ddlPlant" TabIndex="2" CssClass="select-full" placeholder="Select Plant"  runat="server"></asp:DropDownList>
								</div>
							</div>
						</div>

                        <div class="panel panel-default">
                            <div class="panel-heading"><h6 class="panel-title">General Data</h6></div>
                            <div class="panel-body">
                                <div class="form-group">
							<div class="row">
								<div class="col-md-6">
									<label>Basic Unit of Measure: <span class="mandatory">*</span></label>
                                    <asp:DropDownList ID="ddluom" TabIndex="2" CssClass="select-full" placeholder="Select Unit of Measure"  runat="server"></asp:DropDownList>
                                    
	                               								</div>
                                <div class="col-md-6">
									<label>MRP Group: <span class="mandatory">*</span></label>
                                       <asp:DropDownList ID="ddlMRPgroup" TabIndex="2" CssClass="select-full" placeholder="Select MRP Group"  runat="server"></asp:DropDownList>

	                               								</div>
                                </div>
                                    </div>
                                <div class="form-group">
                                    <div class="row">

								<div class="col-md-6">
									<label>Purchasing Group: <span class="mandatory">*</span></label>
                                     <asp:DropDownList ID="ddlPurchasingGroup" TabIndex="2" CssClass="select-full" placeholder="Select Purchase Group"  runat="server"></asp:DropDownList>
								</div>
                                       
                                        </div>
							</div>

                                 </div>

                                

                            </div>


                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h6 class="panel-title">MRP Procedure</h6></div>
                                <div class="panel-body">
                                    <div class="form-group">
                                    <div class="row">

								<div class="col-md-6">
									<label>MRP Type: <span class="mandatory">*</span></label>
                                      <asp:DropDownList ID="ddlMrptype" TabIndex="2" CssClass="select-full" placeholder="Select MRP Type"  runat="server"></asp:DropDownList>

								</div>

                                        	<div class="col-md-6">
									<label>ReOrder Point: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txtReorderPoint"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>




                                        </div>
                                        </div>
                                    <div class="form-group">


                                    <div class="row">

								<div class="col-md-6">
									<label>Lot Size: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txtlotsize"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>

                                        	<div class="col-md-6">
									<label>Minimum Lot Size: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txtminimumlotsize"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>




                                        </div>


							</div>


                                    <div class="form-group">


                                    <div class="row">

								<div class="col-md-6">
									<label>Procurement Type: <span class="mandatory">*</span></label>
                                     <asp:DropDownList ID="ddlProcurementtype" TabIndex="2" CssClass="select-full"   runat="server"></asp:DropDownList>

								</div>

                                        	<div class="col-md-6">
									<label>Store Location: <span class="mandatory">*</span></label>
                                   <asp:DropDownList ID="ddlStoreLoacation" TabIndex="2" CssClass="select-full" placeholder="Select StoreLocation"  runat="server"></asp:DropDownList>
								</div>




                                        </div>


							</div>

                                    <div class="form-group">


                                    <div class="row">

								<div class="col-md-6">
									<label>GR Processing Time: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txtgrprocessingtime" CssClass="form-control"  runat="server"></asp:TextBox>
								</div>

                                        




                                        </div>


							</div>
                                
                            </div>
                        </div>

                                





                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h6 class="panel-title">Current Valuation</h6></div>
                                <div class="panel-body">
                                    <div class="form-group">
                                    <div class="row">

								<div class="col-md-6">
									<label>Price Unit: <span class="mandatory">*</span></label>
                                     <asp:TextBox ID="txtPriceUnit"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>

                                    <div class="col-md-6">
									<label>Moving Price: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txtmovingprice"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>

                                  <div class="col-md-6">
									<label>Standard Price: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txtstandardPrice"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>


                                        </div>
                                        </div>
                                    


                                    <div class="form-group">


                                    <div class="row">

								<div class="col-md-6">
									<label>Total Stock: <span class="mandatory">*</span></label>
                                    <asp:TextBox ID="txttotalstock"  CssClass="form-control"  runat="server"></asp:TextBox>
								</div>

                                        	<div class="col-md-6">
									<label>Total Value: <span class="mandatory">*</span></label>
                                  <asp:TextBox ID="txttotalvalue"  CssClass="form-control"  runat="server"></asp:TextBox>								</div>




                                        </div>


							</div>

                                    
                                
                            </div>
                        </div>
                                
						
                               
                        </div>

                         

                          

						

                        <div class="form-actions text-right">
                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-danger" Text="Cancel" />
                        	 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" />
                        </div>

					</div>
    

</asp:Content>

