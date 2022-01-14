<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurDashboard.aspx.cs" Inherits="Modules_Sales_PurDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Purchases Dashboard Details</h3>
                </div>
            </div>
    
  
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesOrder.aspx">Purchases Dashboard</a></li>
                    <li class="active">Purchases Dashboard Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->


       <div class="panel panel-default">

           <div class="panel-heading">
                    <h6 class="panel-title">Purchases Dashboard Details</h6>
                </div>


            <div class="panel-body">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Basic Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-horizontal">


                                 <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Sales Order No:</label>
                                    <div class="col-sm-4">
                                           <asp:DropDownList ID="ddlSalesOrderNo" CssClass="select-full" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlSalesOrderNo_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Sales Order Date:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtSalesOrderDate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtSalesOrderDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Customer :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlCustomer" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>

                                    </div>
                                    <label class="col-sm-2 control-label text-right">Project :</label>
                                    <div class="col-sm-4">
                                          <asp:DropDownList ID="ddlProject" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Confirmation Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtConfirmationDate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                          <asp:Image
                                            ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="Image2"
                                            TargetControlID="txtConfirmationDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                 
                                </div>


                                   <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Shop Drawing Actual :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtshopdrawingActutal"  CssClass="form-control" runat="server" ></asp:TextBox>
                                          <asp:Image
                                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image3"
                                            TargetControlID="txtshopdrawingActutal">
                                        </cc1:CalendarExtender>
                                    </div>

                                       <label class="col-sm-2 control-label text-right">Shop Drawing Received :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtShopdrawingReceived"  CssClass="form-control" runat="server" ></asp:TextBox>

                                         <asp:Image
                                            ID="Image4" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" PopupButtonID="Image4"
                                            TargetControlID="txtShopdrawingReceived">
                                        </cc1:CalendarExtender>


                                    </div>

                                    </div>

                                   <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Local Material Ordered :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtlocalmaterialOrdered"  CssClass="form-control" runat="server" ></asp:TextBox>

                                           <asp:Image
                                            ID="Image5" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender5" runat="server" PopupButtonID="Image5"
                                            TargetControlID="txtlocalmaterialOrdered">
                                        </cc1:CalendarExtender>



                                    </div>

                                       <label class="col-sm-2 control-label text-right">Local Material Received :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtlocalmaterialreceived"  CssClass="form-control" runat="server" ></asp:TextBox>

                                         <asp:Image
                                            ID="Image6" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender6" runat="server" PopupButtonID="Image6"
                                            TargetControlID="txtlocalmaterialreceived">
                                        </cc1:CalendarExtender>


                                    </div>

                                    </div>
                            


                                    <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Greece Material Ordered :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtgreecematerialordered"  CssClass="form-control" runat="server" ></asp:TextBox>

                                        
                                         <asp:Image
                                            ID="Image7" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender7" runat="server" PopupButtonID="Image7"
                                            TargetControlID="txtgreecematerialordered">
                                        </cc1:CalendarExtender>


                                    </div>

                                       <label class="col-sm-2 control-label text-right">Greece Material Received :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtgreeceMaterialReceived"  CssClass="form-control" runat="server" ></asp:TextBox>


                                         <asp:Image
                                            ID="Image8" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender8" runat="server" PopupButtonID="Image8"
                                            TargetControlID="txtgreeceMaterialReceived">
                                        </cc1:CalendarExtender>


                                    </div>

                                    </div>

                                    <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Glass Order :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtglassordered"  CssClass="form-control" runat="server" ></asp:TextBox>

                                           <asp:Image
                                            ID="Image13" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender13" runat="server" PopupButtonID="Image13"
                                            TargetControlID="txtglassordered">
                                        </cc1:CalendarExtender>


                                    </div>

                                       <label class="col-sm-2 control-label text-right">Glass Received :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtglassreceived"  CssClass="form-control" runat="server" ></asp:TextBox>
                                            <asp:Image
                                            ID="Image14" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender14" runat="server" PopupButtonID="Image14"
                                            TargetControlID="txtglassreceived">
                                        </cc1:CalendarExtender>



                                    </div>

                                    </div>

                                    <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Fabrication Start :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtfabricationactual"  CssClass="form-control" runat="server" ></asp:TextBox>

                                           <asp:Image
                                            ID="Image9" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender9" runat="server" PopupButtonID="Image9"
                                            TargetControlID="txtfabricationactual">
                                        </cc1:CalendarExtender>


                                    </div>

                                       <label class="col-sm-2 control-label text-right">Fabrication End :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtFabricationReceived"  CssClass="form-control" runat="server" ></asp:TextBox>
                                            <asp:Image
                                            ID="Image10" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender10" runat="server" PopupButtonID="Image10"
                                            TargetControlID="txtFabricationReceived">
                                        </cc1:CalendarExtender>



                                    </div>

                                    </div>
                                
                                    <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Installation Start :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtInstallationStart"  CssClass="form-control" runat="server" ></asp:TextBox>

                                         <asp:Image
                                            ID="Image11" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender11" runat="server" PopupButtonID="Image11"
                                            TargetControlID="txtInstallationStart">
                                        </cc1:CalendarExtender>



                                    </div>

                                       <label class="col-sm-2 control-label text-right">Installation End :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtInstallationEnd"  CssClass="form-control" runat="server" ></asp:TextBox>

                                                  <asp:Image
                                            ID="Image12" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender12" runat="server" PopupButtonID="Image12"
                                            TargetControlID="txtInstallationEnd">
                                        </cc1:CalendarExtender>


                                    </div>

                                    </div>


                                <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Remarks :</label>
                                    <div class="col-sm-10">
                                         <asp:TextBox ID="txtRemarks" TextMode ="MultiLine"  Rows="5" CssClass="form-control" runat="server" ></asp:TextBox>
                                   
                                         <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender1" TargetControlID="txtRemarks" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" /> 
                                    
                                    
                                    </div>

                                      

                                    </div>

                                  <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Status :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlStatus"  CssClass="form-control" Width="100%" runat="server" >   
                                             <asp:ListItem>Open</asp:ListItem>
                                             <asp:ListItem>Closed</asp:ListItem>
                                         </asp:DropDownList>
                                   
                                        
                                    
                                    </div>

                                      

                                    </div>


                                <div class="form-actions text-right">
                       
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"  />
                                  
                                </div>




                            </div>

                        </div>
                    </div>

             </div>




       </div>




</asp:Content>

