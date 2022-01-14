<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Architect_Details.aspx.cs" Inherits="Modules_Masters_Architect_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- <script type="text/javascript">
          function successalert() {
              swal({
                  title: 'Message!',
                  text: 'Your Data Saved Succesfully',
                  type: 'success'
              });
         }
     </script>--%>

    <%--  <script src="../../js/BlockUi.js"></script>

     <script type="text/javascript">

         $(document).ready(function () {
             $('#Button1').click(function () {
                 $.blockUI({ overlayCSS: { backgroundColor: '#00f' } });

                 setTimeout($.unblockUI, 2000);
             });
         });
       </script>--%>

    <script type="text/javascript">
        function DisableButton()
        {
            document.getElementById("<%=Button1.ClientID %>").disabled = true;
        }
            window.onbeforeunload = DisableButton;
    </script>

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
                window.location = 'Architect.aspx';
            }).catch(function (reason) {
                // The action was canceled by the user
            });

        }
    </script>

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Architect Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="Architect.aspx">Architect</a></li>
            <li class="active">Architect Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Architect Name :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtName" CssClass="validate[required] form-control" placeholder="Enter Architect Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter Architect Name"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Mobile :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtMoile" CssClass="form-control" placeholder="Enter Mobile No" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMoile" runat="server" ErrorMessage="Please Enter Mobile No"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Email :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter E-Mail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please Enter Email"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Address :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtAddress" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAddress" runat="server" ErrorMessage="Please Enter Address"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <asp:Button ID="Button1" runat="server" Text="Button" />

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>