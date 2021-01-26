<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="ThesisManagementWebApp.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TMS | Login</title>
    <link rel="icon" href="/DashboardFile/tmsfav.ico" type="image/x-icon" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/vendor/bootstrap/css/bootstrap.min.css" />

    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />

    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css" />

    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/vendor/animate/animate.css" />

    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/vendor/css-hamburgers/hamburgers.min.css" />

    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/vendor/select2/select2.min.css" />

    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/css/util.css" />
    <link rel="stylesheet" type="text/css" href="../DashboardFile/Login/css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100 p-l-50 p-r-50 p-t-77 p-b-30">
                    <form class="login100-form validate-form">
                        <span class="login100-form-title p-b-55">Login
</span>
                        <div class="wrap-input100 validate-input m-b-16" data-validate="Valid email is required: ex@abc.xyz">
                            <asp:TextBox ID="txtEmail" TextMode="Email" autocomplete="off" class="input100" runat="server" placeholder="Email"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <span class="lnr lnr-envelope"></span>
                            </span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                            <asp:TextBox ID="txtPass" class="input100" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <span class="lnr lnr-lock"></span>
                            </span>
                        </div>
                        <div class="contact100-form-checkbox m-l-4">
                            <asp:LinkButton ID="lnkForgot" runat="server" OnClick="lnkForgot_OnClick">Forgot Password?</asp:LinkButton>
                        </div>
                        <div class="container-login100-form-btn p-t-25">
                            <button class="login100-form-btn" runat="server" OnServerClick="btnLogin_OnServerClick" id="btnLogin">
                                Login
                            </button>
                        </div>


                        <div class="text-center w-full p-t-115">
                            <span class="txt1">Don't have an account?
</span>
                            <a class="txt1 bo1 hov1" href="/Web/Signup.aspx">Sign up now
</a>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </form>
    <script src="../DashboardFile/Login/vendor/jquery/jquery-3.2.1.min.js"></script>

    <script src="../DashboardFile/Login/vendor/bootstrap/js/popper.js"></script>
    <script src="../DashboardFile/Login/vendor/bootstrap/js/bootstrap.min.js"></script>

    <script src="../DashboardFile/Login/vendor/select2/select2.min.js"></script>

    <script src="../DashboardFile/Login/js/main.js"></script>
</body>
</html>
