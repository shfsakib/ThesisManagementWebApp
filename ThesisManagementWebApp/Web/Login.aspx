<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="ThesisManagementWebApp.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TMS | Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="/DashboardFile/tmsfav.ico" type="image/x-icon" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../DashboardFile/plugins/fontawesome-free/css/all.min.css" />
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="../DashboardFile/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="../DashboardFile/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- JQVMap -->
    <link rel="stylesheet" href="../DashboardFile/plugins/jqvmap/jqvmap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../DashboardFile/dist/css/adminlte.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="../DashboardFile/plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
</head>
<body data-spy="scroll" data-target=".site-navbar-target" data-offset="300" style="background: #ededfb;">
    <form id="form1" runat="server">
        <div class="col-lg-12" style="padding-top: 100px;">
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-lg-6">
                    <div class="card card-body">
                        <div class="row">
                            <div class="col-lg-12 card-header text-center">
                                <h3>Log in</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 mt-3">
                                <label class="label">Email</label>
                                <asp:TextBox ID="txtEmail" TextMode="Email" autocomplete="off" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label class="label">Password</label>
                                <asp:TextBox ID="txtPass" class="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-12 pt-2 pb-2">
                                <asp:LinkButton ID="lnkForgot" runat="server" OnClick="lnkForgot_OnClick">Forgot Password?</asp:LinkButton>
                            </div>
                            <div class="col-lg-12">
                                <button class="btn btn-primary btn-block" runat="server" onserverclick="btnLogin_OnServerClick" id="btnLogin">
                                    Login
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3"></div>
                <div class="col-12 text-center">
                    <span class="txt1">Back to
                    </span>
                    <a class="txt1 bo1 hov1" href="/Web/Resources.aspx">Home
                    </a>
                    <br />
                    <span class="txt1">Don't have an account?
                    </span>
                    <a class="txt1 bo1 hov1" href="/Web/Signup.aspx">Sign up now
                    </a>
                </div>
            </div>
        </div>
    </form>
    <!-- jQuery -->
    <script src="../DashboardFile/plugins/jquery/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="../DashboardFile/plugins/jquery-ui/jquery-ui.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../DashboardFile/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- JQVMap -->
    <script src="../DashboardFile/plugins/jqvmap/jquery.vmap.min.js"></script>
    <script src="../DashboardFile/plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="../DashboardFile/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
    <!-- overlayScrollbars -->
    <script src="../DashboardFile/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../DashboardFile/dist/js/adminlte.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
</body>
</html>
