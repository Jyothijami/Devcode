<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="Modules_HR_EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script> 

 <script type="text/javascript">

     $(document).ready(function () {
         $("#<%=txtUserName.ClientID%>").keyup(function () {
                var username = $(this).val();

                if (username.length >= 3) {
                    $.ajax({
                        url: 'EmpUserName.asmx/UserNameExists',
                        method: 'get',
                        data: { userName: username },

                        dataType: 'json',

                        success: function (data) {

                            var divElement = $('#divOutput');
                            if (data.UserNameInUse) {
                                divElement.text(data.EMPUserName + ' already Exist');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.EMPUserName + ' available');
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





  <%--  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Employee Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="EmployeeMaster.aspx">Employee</a></li>
                    <li class="active">Employee Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-body">

                      <div class="col-md-1"></div>

                    <div class="col-md-10">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title">Employee</h5>
                            </div>
                            <div class="panel-body">



                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title">Professional Details</h5>
                            </div>
                            <div class="panel-body">


                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Series:</label>
                                            <asp:TextBox ID="txtEmpSeries" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Department:</label>
                                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>

                                        <div class="col-md-6">
                                            <label>Company:</label>
                                            <asp:DropDownList ID="ddlCompany" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Designation:</label>
                                            <asp:DropDownList ID="ddlDesignation" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                       
                                         <div class="col-md-6">
                                            <label>Employee Type:</label>
                                            <asp:DropDownList ID="ddlEmployeeType" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>

                                          
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Date Of Appointment :</label>
                                            <asp:TextBox ID="txtDateOfAppointment" CssClass="form-control" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server"
                                                TargetControlID="txtDateOfAppointment">
                                            </cc1:CalendarExtender>
                                        </div>

                                        <div class="col-md-6">
                                            <label>Date Of Termination :</label>
                                            <asp:TextBox ID="txtDateOfTermination" CssClass="form-control" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server"
                                                TargetControlID="txtDateOfTermination">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Grade:</label>
                                            <asp:DropDownList ID="ddlGrade" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>


                                         <div class="col-md-6">
                                        <label>Employee Supervisor:</label>
                                        <asp:DropDownList ID="ddlLeaveApprover" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    </div>
                                </div>


                                </div>
                                     </div>

                            <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title">Employee Details</h5>
                            </div>
                            <div class="panel-body">

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>First Name :</label>
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-6">
                                    <label>Last Name :</label>
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Gender:</label>

                                    <div>
                                        <label class="radio-inline">
                                            <asp:RadioButton ID="rbtMale" runat="server" GroupName="gender" CssClass="styled" Text="Male" Checked="True" />
                                        </label>

                                        <label class="radio-inline">
                                            <asp:RadioButton ID="rbtFemale" runat="server" CssClass="styled" GroupName="gender" Text="Female" />
                                        </label>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label>City :</label>
                                    <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Address: <span class="mandatory">*</span></label>
                            <asp:TextBox runat="server" Rows="5" Columns="5" TextMode="MultiLine" CssClass="form-control" placeholder="Your message..." ID="txtAddress"></asp:TextBox>
                        </div>

                                 </div>
                                     </div>


                            <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title"><a data-toggle="collapse" href="#collapse-group1">Personal Details<b class="caret"></b></a></h5>
                            </div>

                                  <div id="collapse-group1" class="panel-collapse">

                            <div class="panel-body">



                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Date Of Birth :</label>
                                    <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender3" runat="server"
                                        TargetControlID="txtDateOfBirth">
                                    </cc1:CalendarExtender>
                                </div>

                                <div class="col-md-6">
                                    <label>Phone No :</label>
                                    <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Email :</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-6">
                                    <label>Mobile No :  </label>
                                    <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                                </div>
                                      </div>
                                     </div>



                                  <div class="panel panel-default" id="tbluserdetails" runat="server">
                            <div class="panel-heading">
                                <h5 class="panel-title"><a data-toggle="collapse" href="#collapse-group2">User Details<b class="caret"></b></a></h5>
                            </div>
                                  <div id="collapse-group2" class="panel-collapse">
                            <div class="panel-body">


                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>User Name :</label>
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <span id="divOutput"></span>
                                </div>

                                <div class="col-md-6">
                                    <label>Password :  </label>
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                                  </div>
                                      </div>
                                     </div>


                                  <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title"><a data-toggle="collapse" href="#collapse-group3">Account Information<b class="caret"></b></a></h5>
                            </div>

  <div id="collapse-group3" class="panel-collapse">
                            <div class="panel-body">

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>CTS :</label>
                                    <asp:TextBox ID="txtsalary" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-6">
                                    <label>Bank Account No :  </label>
                                    <asp:TextBox ID="txtBankaccountNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>TDS :</label>
                                    <asp:TextBox ID="txttds" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                                   </div>

      </div>
                                     </div>



                                





                        <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>

                    <div class="col-md-1"></div>

                                </div>
                    </div>

                      <div class="col-md-1"></div>
                </div>
            </div>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>