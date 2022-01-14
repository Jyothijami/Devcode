<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="CompanySetup.aspx.cs" Inherits="Modules_Masters_CompanySetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form1").validate();
        });
     </script>
   

   <%--  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>



    	<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Company Info </h3>
				</div>
				
			</div>
			<!-- /page header -->


    <div class="form-horizontal">

    <div class="panel panel-default">
	               
	                <div class="panel-body">

				        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Company Full Name :<span class="mandatory">*</span></label>
				            <div class="col-sm-4">
                             <asp:TextBox ID="txtCompanyfullName" CssClass="required form-control" ClientIDMode="Static"  runat="server"></asp:TextBox>
				            	 </div>
                                
                                <label class="col-sm-2 control-label text-right">Company Short Name :</label>
				            <div class="col-sm-4">
                             <asp:TextBox ID="txtcompnayshortname" CssClass="required form-control " runat="server"></asp:TextBox>
				            	
				            </div>
				        </div>
				          <div class="form-group">
				             <label class="col-sm-2 control-label text-right">Head of Company :</label>
				            <div class="col-sm-4">
				           <asp:TextBox ID="txtCEO" CssClass="form-control" runat="server"></asp:TextBox>
				            </div>
                              <label class="col-sm-2 control-label text-right">Foundation Date :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtFoundationDate" CssClass="form-control" name="trigger" runat="server" ></asp:TextBox>
                                <img id="Image1" class="ui-datepicker-trigger" src="images/interface/datepicker_trigger.png" alt="..." title="Pick Date">
				          <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                TargetControlID="txtFoundationDate">
                            </cc1:calendarextender>
                                  </div>

				            </div>
				     
				        <div class="form-group">
				          
                              <label class="col-sm-2 control-label text-right">Phone (Office) :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtphoneoffice" CssClass="form-control" runat="server" ></asp:TextBox>
				            </div>
                             <label class="col-sm-2 control-label text-right">E-Mail :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
				            </div>



				        </div>
				        
				        <div class="form-group">
				             <label class="col-sm-2 control-label text-right">Mobile :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtMobile" CssClass="form-control"  runat="server" ></asp:TextBox>
				            </div>
                             
                              <label class="col-sm-2 control-label text-right">FAX :</label>
				            <div class="col-sm-4">
				            	<asp:TextBox ID="txtfax" CssClass="form-control"  runat="server" ></asp:TextBox>
				            </div>

				        </div>

                         <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Address :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtaddress" CssClass="form-control"  runat="server" TextMode="MultiLine"></asp:TextBox>
				            </div>

                                <label class="col-sm-2 control-label text-right">GST Number :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtgst" CssClass="form-control"  runat="server"  ></asp:TextBox>
				            </div>

				        </div>
				      
                          <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Current Financial Year :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCurrentFinancialYear" CssClass="form-control"  runat="server"  ></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99-99" MaskType="Number"
                TargetControlID="txtCurrentFinancialYear" ClearMaskOnLostFocus="False">
                </cc1:MaskedEditExtender>
				            </div>
				        </div>

                       

                        <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	
                        </div>

				    </div>
				</div>

    </div>
  <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

