<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="Modules_Sales_CustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
  <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script> --%>

 <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=txtCustomerName.ClientID%>").keyup(function () {
                var username = $(this).val();
               
                if (username.length >= 3) {
                    $.ajax({
                        url: 'UserName.asmx/UserNameExists',
                        method: 'get',
                        data: { userName: username },
                       
                        dataType: 'json',
                      
                        success: function (data) {

                            var divElement = $('#divOutput');
                            if (data.UserNameInUse) {
                                divElement.text(data.CustName + ' already Exist');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.CustName + ' available');
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    })
                }


            })
        })


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
                  window.location = 'CustomerMaster.aspx';
              }).catch(function (reason) {
                  // The action was canceled by the user
              });

          }
    </script>
      


    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Customer Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="CustomerMaster.aspx">Customer</a></li>
            <li class="active">Customer Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-pencil"></i>Customer Details</h6>
        </div>
        <div class="panel-body">

            <div class="panel panel-info">
                <div class="panel-heading">
                    <h6 class="panel-title">Customer Basic Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Salutation : <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlTitle" TabIndex="2" Width="100%" CssClass="select-full" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <label>Customer Code : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustomerCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Name : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server"></asp:TextBox>
                                 <span id="divOutput"></span>
                                  <span id="CustomerDetails"></span>
                                </div>

                            <div class="col-md-6">
                                <label>Customer Company Name : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-3">
                                <label>Designation: <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlcustdesignation" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <label>Phone No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustPhone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Customer Mobile No : <span class="manda tory">*</span></label>
                                <asp:TextBox ID="txtCustMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Customer Fax No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustFaxNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Customer E-Mail : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Region : <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlregion" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <label>Address : <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtCustAddress" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-info">
                <div class="panel-heading">
                    <h6 class="panel-title">Referred By Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Person <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtrefbyname" CssClass="form-control" placeholder="Enter Referer Name" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Mobile No <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtrefbymobileno" CssClass="form-control" placeholder="Enter Referer Mobile" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <label>Address <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtrefbyaddress" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Address" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%-- <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Tax Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>GST No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtgstno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>PAN No: <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtpanno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>

            <div class="form-actions text-right">
                <input id="btnreset" type="reset" class="btn btn-danger" value="Reset" />
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
            </div>
        </div>
    </div>




</asp:Content>