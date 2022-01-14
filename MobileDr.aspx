<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="MobileDr.aspx.cs" Inherits="MobileDr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     
        <script lang="javascript" type="text/javascript">
            function check(e) {
                var keynum
                var keychar
                var numcheck
                // For Internet Explorer
                if (window.event) {
                    keynum = e.keyCode;
                }
                    // For Netscape/Firefox/Opera
                else if (e.which) {
                    keynum = e.which;
                }
                keychar = String.fromCharCode(keynum);
                //List of special characters you want to restrict
                if (keychar == "'" || keychar == "`" || keychar == "&" || keychar == "¬" || keychar == '"') {
                    return false;
                } else {
                    return true;
                }
            }
    </script>
   


    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
        <ContentTemplate>



            <div class="panel panel-default">

                <div class="panel-body">

               


            <div class="panel panel-danger">

                   <div class="panel-heading">
                        <h6 class="panel-title">Daily Report</h6>
                    </div>

         
            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title">Daily Report Details</h6>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Date & Time :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtDateTime" runat="server" CssClass="form-control" ></asp:TextBox>

                                    <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtDateTime">
                        </cc1:CalendarExtender>

                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">In Time :</label>
                            <div class="col-sm-4">
                                <table style="width: 64px">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:DropDownList
                                                ID="ddlHour" runat="server" CssClass="form-control" TabIndex="3" Width="60px" EnableTheming="False">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlMin" runat="server" CssClass="form-control" TabIndex="4" Width="60px" EnableTheming="False">
                                                <asp:ListItem>00</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlAMPM" runat="server" CssClass="form-control" TabIndex="5" Width="60px" EnableTheming="False">
                                                <asp:ListItem>AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </div>

                            <label class="col-sm-2 control-label text-right">Out Time :</label>
                            <div class="col-sm-4">
                                <table style="width: 64px; height: 32px;">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:DropDownList
                                                ID="ddlOutHour" runat="server" CssClass="form-control" TabIndex="3" Width="60px" EnableTheming="False">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlOutMin" runat="server" CssClass="form-control" TabIndex="4" Width="60px" EnableTheming="False">
                                                <asp:ListItem>00</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlOutAMPM" runat="server" CssClass="form-control" TabIndex="5" Width="60px" EnableTheming="False">
                                                <asp:ListItem>AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Client's Name :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientsName" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Mobile No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Reference :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList runat="server" ID="txtReference" CssClass="form-control">
                                    <asp:ListItem>Executive</asp:ListItem>
                                    <asp:ListItem>Walk-In</asp:ListItem>
                                    <asp:ListItem>Architect</asp:ListItem>
                                    <asp:ListItem>Web Site</asp:ListItem>
                                    <asp:ListItem>Exhibition</asp:ListItem>
                                    <asp:ListItem>Existing Customer</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Architect/Executive Name :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtArchitect" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Address :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Purpose :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtPurpose" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Attended By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlAttendedBy"  Enabled="false" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="form-actions col-sm-offset-10">

                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-danger " OnClick="btnSave_Click" Text="Save" />
                            </div>
                        </div>




                         
                 <div id="lables">
                <asp:Label ID="lblUserType" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblEmpIdHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblDeptId" runat ="server" Visible ="false" ></asp:Label>
                                    <asp:Label ID="lblDeptHead" runat ="server" Visible ="false"  ></asp:Label>
                                    <asp:Label ID="lblDeptHeadId" runat ="server" Visible ="false" ></asp:Label>


            </div>





                    </div>
                </div>
            </div>


            </div>


         </div>

            </div>
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>

