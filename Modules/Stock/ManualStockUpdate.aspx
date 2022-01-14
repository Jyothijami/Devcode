<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ManualStockUpdate.aspx.cs" Inherits="Modules_Stock_ManualStockUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                     window.location = 'Stock.aspx';
                 }).catch(function (reason) {
                     // The action was canceled by the user
                 });

             }
       </script>
      


         <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Manual Stock Update</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="Stock.aspx">Stock Information</a></li>
            <li class="active">Manual Stock Update</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->


     <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">


                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Plant :</label>
				            <div class="col-sm-4">
				            	<asp:DropDownList ID="ddlPlant" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlPlant_SelectedIndexChanged" class="select-full" runat="server"></asp:DropDownList>
				            </div>
				            <label class="col-sm-2 control-label text-right">Storage Location :</label>
				            <div class="col-sm-4">
				            	<asp:DropDownList ID="ddlStroageLoaction" Width="100%" AutoPostBack="true" class="select-full" runat="server"></asp:DropDownList>

				            </div>
                        
                        </div>


               <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Item Code :</label>
				            <div class="col-sm-4">
				            	<asp:DropDownList ID="ddlItemCode" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlItemCode_SelectedIndexChanged" class="select-full" runat="server"></asp:DropDownList>
				            </div>
				            <label class="col-sm-2 control-label text-right">Color Code :</label>
				            <div class="col-sm-4">
				            	<asp:DropDownList ID="ddlColor" Width="100%" AutoPostBack="true" class="select-full" runat="server"></asp:DropDownList>

				            </div>
                        
                        </div>
                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Uom :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtUom" class="form-control" runat="server"></asp:TextBox>
				            </div>
				            <label class="col-sm-2 control-label text-right">Category :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtCategory" class="form-control" runat="server"></asp:TextBox>
				            </div>
                        
                        </div>


                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Description :</label>
				            <div class="col-sm-10">
				            	<asp:TextBox ID="txtDescription" class="form-control" runat="server"></asp:TextBox>
				            </div>
                        </div>


                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Length :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtLength" class="form-control" runat="server"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="fte" TargetControlID="txtLength" ValidChars="0123456789" FilterType="Numbers" runat="server"></cc1:FilteredTextBoxExtender>


				            </div>
				            <label class="col-sm-2 control-label text-right">Qty to Update :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtQtytoUpdate" class="form-control" runat="server"></asp:TextBox>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtQtytoUpdate" ValidChars="0123456789.-" FilterType="Custom" runat="server"></cc1:FilteredTextBoxExtender>

				            </div>
                        
                        </div>


            </div>

            <div class="form-actions col-sm-offset-2">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"   CssClass="btn btn-primary" Text="Save" />

            </div>
        </div>
    </div>







</asp:Content>

