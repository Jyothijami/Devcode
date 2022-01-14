<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="CustomerUnits.aspx.cs" Inherits="Modules_Sales_CustomerUnits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Customer Site Information</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="CustomerMaster.aspx">Customer Master</a></li>
            <li class="active">Customer Project Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title">Customer Basic Details</h6>
        </div>
        <div class="panel-body">
            <div class="form-group">

                <div class="col-md-3">
                    <label>Company Name: <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Customer Name: <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Mobile No: <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Phone No: <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtphoneno" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>





     <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Customer Project Details</h6>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False"  OnRowDataBound="hai_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="CUST_UNIT_ID" HeaderText="Sl.No" SortExpression="CUST_UNIT_ID" />
                        <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project Name" SortExpression="CUST_UNIT_NAME" />
                        <asp:BoundField DataField="CUST_UNIT_ADDRESS" HeaderText="Location" SortExpression="CUST_UNIT_ADDRESS" />
                        <asp:BoundField DataField="CUST_NO_FlOORS" HeaderText="No of Floors" SortExpression="CUST_NO_FlOORS" />
                        <asp:BoundField DataField="CUST_WINLOAD" HeaderText="Wind Load" SortExpression="CUST_WINLOAD" />
                        <asp:BoundField DataField="CUST_CONTACTPERSON" HeaderText="Contact Person" SortExpression="CUST_CONTACTPERSON" />
                        <asp:BoundField DataField="CUST_MOBILE" HeaderText="Mobile" SortExpression="CUST_MOBILE" />

                         <asp:BoundField DataField="Architect_Name" HeaderText="Architect Name" SortExpression="Architect_Name" />
                         <asp:BoundField DataField="Architect_Mobile" HeaderText="Architect Mobile" SortExpression="Architect_Mobile" />
                        


                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" OnClick="lbtnEdit_Click"><i class="icon-wrench2"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>

    
    <div class="form-horizontal">


    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6 class="panel-title">Project Information</h6>
        </div>
        <div class="panel-body">
           


                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Project Name :</label>
                    <div class="col-sm-4">
                          <asp:TextBox ID="txtCustomerUnitname" CssClass="form-control" placeholder="Enter Project Name" runat="server"></asp:TextBox>

                    </div>
                    <label class="col-sm-2 control-label text-right">Project Location :</label>
                    <div class="col-sm-4">
                            <asp:TextBox ID="txtunitaddress" CssClass="form-control" placeholder="Enter Project Location" TextMode="MultiLine" runat="server"></asp:TextBox>

                    </div>
                </div>



                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">No of Floors :</label>
                    <div class="col-sm-4">
                           <asp:TextBox ID="txtnooffloors" CssClass="form-control" placeholder="Enter No of Floors" runat="server"></asp:TextBox>

                    </div>
                    <label class="col-sm-2 control-label text-right">Wind Load :</label>
                    <div class="col-sm-4">
                            <asp:TextBox ID="txtwinload" CssClass="form-control" placeholder="Enter Wind Load" runat="server"></asp:TextBox>

                    </div>
                </div>




            
        </div>
    </div>





    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6 class="panel-title">Site Incharge Details</h6>
        </div>
        <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Site Contact Person 1:</label>
                    <div class="col-sm-4">
                       <asp:TextBox ID="txtsiteContactPerson" CssClass="form-control" placeholder="Enter Contact Person" runat="server"></asp:TextBox>    </div>
                    <label class="col-sm-2 control-label text-right">Site Contact Mobile No 1:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtSiteMobileNo" CssClass="form-control" placeholder="Enter Contact Mobile" runat="server"></asp:TextBox>     
                    </div>
                </div>
            
             <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Site Contact Person 2:</label>
                    <div class="col-sm-4">
                       <asp:TextBox ID="txtsitecontactperson2" CssClass="form-control" placeholder="Enter Contact Person" runat="server"></asp:TextBox>    </div>
                    <label class="col-sm-2 control-label text-right">Site Contact Mobile No 2:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtsitecontactmobile2" CssClass="form-control" placeholder="Enter Contact Mobile" runat="server"></asp:TextBox>     
                    </div>
                </div>

             <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Site Contact Person 3:</label>
                    <div class="col-sm-4">
                       <asp:TextBox ID="txtsitecontact3" CssClass="form-control" placeholder="Enter Contact Person" runat="server"></asp:TextBox>    </div>
                    <label class="col-sm-2 control-label text-right">Site Contact Mobile No 3:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtsitecontactmobile3" CssClass="form-control" placeholder="Enter Contact Mobile" runat="server"></asp:TextBox>     
                    </div>
                </div>
            


        </div>
    </div>
        <div class="panel panel-primary">
                <div class="panel-heading">
                    <h6 class="panel-title">Architect Details</h6>
                </div>
             <div class="panel-body">
                  <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Architect Name :</label>
                    <div class="col-sm-4">


                        <asp:DropDownList ID="ddlArchitect"  CssClass="select-full" Width="100%" OnSelectedIndexChanged="ddlArchitect_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                     <%--  <asp:TextBox ID="txtarchitectName" CssClass="form-control" placeholder="Enter Architect Name" runat="server"></asp:TextBox>   --%> </div>
                    <label class="col-sm-2 control-label text-right">Architect Mobile No:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtarchitectMobileNo" CssClass="form-control" placeholder="Enter Architect Mobile" runat="server"></asp:TextBox>     
                    </div>
                </div>



                  <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Architect Office Details :</label>
                    <div class="col-sm-4">
                       <asp:TextBox ID="txtarchitectofficedetails" CssClass="form-control" placeholder="Enter Architect Office Address" TextMode="MultiLine" runat="server"></asp:TextBox>    </div>
                    <label class="col-sm-2 control-label text-right">Architect E-Mail:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtarchitectemail" CssClass="form-control" placeholder="Enter Architect E-Mail" runat="server"></asp:TextBox>     
                    </div>
                </div>




                  </div>
            </div>


        <div class="panel panel-primary">
                <div class="panel-heading">
                    <h6 class="panel-title">Project Incharge Details</h6>
                </div>
            <div class="panel-body">
                  <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Project Incharge Person :</label>
                    <div class="col-sm-4">
                       <asp:TextBox ID="txtprojectincargeperson" CssClass="form-control" placeholder="Enter Project Incharge Name" runat="server"></asp:TextBox>    </div>
                    <label class="col-sm-2 control-label text-right">Project Incharge Mobile No:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtprojectincargemobile" CssClass="form-control" placeholder="Enter Project Incharge Mobile" runat="server"></asp:TextBox>     
                    </div>
                </div>


                   <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Project Incharge E-Mail :</label>
                    <div class="col-sm-4">
                       <asp:TextBox ID="txtProjectIncargeEmail" CssClass="form-control" placeholder="Enter Project Incharge E-mail" runat="server"></asp:TextBox>    </div>
                   
                </div>



                </div>
            </div>




    <div class="panel-body">
        <div class="form-actions text-right">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>


    </div>



   
</asp:Content>