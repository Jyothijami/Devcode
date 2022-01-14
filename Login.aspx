<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1, maximum-scale=1" />
    <title>Alumil :: Login </title>




   


    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/londinium-theme.css" rel="stylesheet" type="text/css" />
    <link href="css/styles.css" rel="stylesheet" type="text/css" />

  

</head>
<body class="full-width page-condensed">
    <form id="form1" runat="server">
        <!-- Navbar -->
        <div class="navbar navbar-inverse" role="navigation">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-right">
                    <span class="sr-only">Toggle navbar</span>
                    <i class="icon-grid3"></i>
                </button>
                <a class="navbar-brand" href="Index.aspx">
                    <img src="images/logo.png" alt="Alumil" /></a>
            </div>
        </div>
        <!-- /navbar -->

        <!-- Login wrapper -->
        <div class="login-wrapper">

            <div class="popup-header">
                <a href="#" class="pull-left"><i class="icon-user-plus"></i></a>
                <span class="text-semibold">User Login</span>
            </div>
            <div class="well">
                <div class="form-group has-feedback">
                    <label>Username</label>
                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Username" />
                    <i class="icon-users form-control-feedback"></i>
                </div>

                <div class="form-group has-feedback">
                    <label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" placeholder="Password" />
                    <i class="icon-lock form-control-feedback"></i>
                </div>

                <div class="row form-actions">
                    <div class="col-xs-6">
                        <li><a href="#">Forgot password?</a></li>
                    </div>

                    <div class="col-xs-6">

                        <asp:Button ID="btnsignin" CssClass="btn btn-danger pull-right" runat="server" Text="Sign in" OnClick="btnsignin_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- /login wrapper -->

        <!-- Footer -->
        <div class="footer clearfix">
            <div class="pull-left">&copy; 2018 Alumil. All Rights Reserved</div>
            <div class="pull-right icons-group">
                <a href="#">Design by Sigma Solutions</a>
            </div>
        </div>
        <!-- /footer -->
    </form>
</body>
</html>