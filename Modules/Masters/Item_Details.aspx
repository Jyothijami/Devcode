<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Item_Details.aspx.cs" Inherits="Modules_Masters_Item_Details_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <script type="text/javascript">
        function hi() {
            // event.preventDefault();
            swal({
                title: 'System Meassage',
                text: "Data Submitted Sucessfully",
                type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
            })
            .then(function () {
                // Set data-confirmed attribute to indicate that the action was confirmed
                window.location = 'Item.aspx';
            }).catch(function (reason) {
                // The action was canceled by the user
            });

        }
    </script>
   <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Item Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Item.aspx">Item</a></li>
					<li class="active">Item Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Item Series :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlitemseries" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
				            
                     <label class="col-sm-2 control-label text-right">Brand :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlBrand" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
				            
                            
                       
                        </div>


                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Item Code :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtItemCode" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Category :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList  ID="ddlCategory" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>



                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Length(MM) :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtlength" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Description :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDescription" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>
              
                <%--<div class="form-group">
                   <label class="col-sm-2 control-label text-right">Color :</label>
                       
				            <div class="col-sm-10">
                                <div class="panel-body">
                                    <table runat="server" Width="100%" id="tblcolors">
                                        <thead></thead>
                                        <tbody>
                                           <tr> <td></td></tr>
                                            <tr>
                                            <td style="padding-right:10px">
                              <%-- <asp:CheckBoxList ID="chkItemColor" runat="server" CssClass="checkbox-info" CellPadding="2" CellSpacing="2"  RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="8"   DataTextField="Color_Name" DataValueField="Color_Id"  >
                                </asp:CheckBoxList>
                                                <asp:CheckBoxList ID="chkItemColor" runat="server" RepeatColumns="8" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                                                </td></tr>
                                            </tbody>	
                                        </table>
                                    </div>
				            </div>
                </div>--%>
               

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Box Size(PU) :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtboxsize" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">UOM :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlUom" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Weight(Kg/Mt) :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtWeight" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>

                     <label class="col-sm-2 control-label text-right">Item Group :</label>
				            <div class="col-sm-4">
                               <%-- <asp:DropDownList ID="ddlItemGroup" CssClass="form-control" AutoPostBack="true"  runat="server" >
                                    <asp:ListItem>Raw Material</asp:ListItem>
                                    <asp:ListItem>Product</asp:ListItem>
                                    <asp:ListItem>Services</asp:ListItem>
                                </asp:DropDownList>   --%> 	
                                     <asp:DropDownList ID="ddlItemGroup" CssClass="form-control"  runat="server"></asp:DropDownList>    	

				            </div>



				              </div>
                 
                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCompany" CssClass="form-control"   runat="server" ></asp:DropDownList>    	
				            </div>
				      
                       
                        </div>

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Plant :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlplant" CssClass="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlplant_SelectedIndexChanged"></asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Storage Loaction :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstoragelocation" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>




                   <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Standard Selling Rate :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtsellingprice" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>

                         <label class="col-sm-2 control-label text-right">Sellling Currency :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlsellingcurrency" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>


                    </div>

                  
                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Buying Price :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtBuyingPrice" CssClass="form-control" runat="server" ></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Buying Currency :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCurency" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>



            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>

 </ContentTemplate>
       
    </asp:UpdatePanel>


</asp:Content>

