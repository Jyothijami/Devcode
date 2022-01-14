<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BoQSpecifications.aspx.cs" Inherits="Modules_Sales_BoQSpecifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                 window.location = 'SalesEnquiry.aspx';
             }).catch(function (reason) {
                 // The action was canceled by the user
             });

         }
    </script>

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Sales Enquiry Specifications</h3>
        </div>
    </div>

    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="SalesEnquiry.aspx">Sales Enquiry</a></li>
            <li class="active">Enquiry Specifications</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Enquiry Details</h6>
        </div>
        <div class="panel-body">

            <div class="form-group">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-5">
                        <label>Enquiry No:  </label>
                        <asp:DropDownList ID="ddlEnquiryNo" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlEnquiryNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-5">
                        <label>Enquiry Date:  </label>
                        <asp:TextBox ID="txtenquirydate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-1"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Specifications :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtSpecifications" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>

                        <cc1:HtmlEditorExtender
                            ID="HtmlEditorExtender1" TargetControlID="txtSpecifications" EnableSanitization="false" DisplaySourceTab="false"
                            runat="server" />
                    </div>
                </div>


                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" />
                </div>

            </div>
        </div>
    </div>












    </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>

