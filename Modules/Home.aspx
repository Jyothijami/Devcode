<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Modules_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-lg-offset-1">
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Dashboard <small>Welcome
                <asp:Label ID="lblUserName" runat="server"></asp:Label></small></h3>
                </div>
            </div>
        </div>

         <div class="form-horizontal">

        <div class="panel panel-default">

            <div class="panel-body">

                
                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right"></label>
                            <div class="col-sm-4">
                            </div>


                            <label class="col-sm-2 control-label text-right"></label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="TextBox1" runat="server" Height="72px" Enabled="false" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>

                           
                        </div>

                  <div class="form-group">
                       <label class="col-sm-2 control-label text-right"></label>
                            <div class="col-sm-4">
                            </div>
                            <label class="col-sm-2 control-label text-right">Message:</label>
                            <div class="col-sm-4">
                              <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                           
                        </div>


                <div class="form-actions col-sm-offset-10">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Send Message" onclick="Button1_Click" />
                </div>



            </div>



        </div>


</div>










        <!-- /page header -->
    </div>
    <!-- Info blocks -->
   <%-- <ul class="info-blocks">
        <li class="bg-primary">
            <div class="top-info">
                <a href="Masters/MastersHome.aspx">Masters</a>
            </div>
            <a href="Masters/MastersHome.aspx"><i class="icon-wrench2"></i></a>
        </li>
        <li class="bg-success">
            <div class="top-info">
                <a href="Sales/SalesHome.aspx">Sales</a>
            </div>
            <a href="Sales/SalesHome.aspx"><i class="icon-stats-up"></i></a>
        </li>
        <li class="bg-danger">
            <div class="top-info">
                <a href="Purchases/PurchaseHome.aspx">Purchases</a>
            </div>
            <a href="Purchases/PurchaseHome.aspx"><i class="icon-tags"></i></a>
        </li>
        <li class="bg-info">
            <div class="top-info">
                <a href="#">Production</a>
            </div>
            <a href="#"><i class="icon-cube"></i></a>
        </li>
        <li class="bg-warning">
            <div class="top-info">
                <a href="#">Inventory</a>
            </div>
            <a href="#"><i class="icon-stack"></i></a>
        </li>
        <li class="bg-primary">
            <div class="top-info">
                <a href="#">Finance</a>
            </div>
            <a href="#"><i class="icon-coin"></i></a>
        </li>
        <li class="bg-success">
            <div class="top-info">
                <a href="HR/HrHome.aspx">HR</a>
            </div>
            <a href="HR/HrHome.aspx"><i class="icon-users"></i></a>
        </li>
    </ul>--%>
    <!-- /info blocks -->
</asp:Content>