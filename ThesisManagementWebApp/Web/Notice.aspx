<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="ThesisManagementWebApp.Web.Notice1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TMS</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Course Project" />
    <link rel="icon" href="/DashboardFile/Website/images/logo.png" type="image/x-icon" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Website/styles/bootstrap4/bootstrap.min.css" />
    <link href="/DashboardFile/Website/plugins/fontawesome-free-5.0.1/css/fontawesome-all.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Website/plugins/OwlCarousel2-2.2.1/owl.carousel.css" />
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Website/plugins/OwlCarousel2-2.2.1/owl.theme.default.css" />
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Website/plugins/OwlCarousel2-2.2.1/animate.css" />
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Website/styles/main_styles.css" />
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Website/styles/responsive.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="super_container">

                <!-- Header -->

                <header class="header d-flex flex-row">
                    <div class="header_content d-flex flex-row align-items-center">
                        <!-- Logo -->
                        <div class="logo_container">
                            <div class="logo">
                                <img src="/DashboardFile/Website/images/logo.png" alt="">
                                <span>TMS</span>
                            </div>
                        </div>

                        <!-- Main Navigation -->
                        <nav class="main_nav_container">
                            <div class="main_nav">
                                <ul class="main_nav_list">
                                    <li class="main_nav_item"><a href="/Web/Resources.aspx">home</a></li>
                                    <li class="main_nav_item"><a href="/Web/Notice.aspx">Notice</a></li>
                                    <li class="main_nav_item"><a href="/Web/Login.aspx">Log in</a></li>
                                    <li class="main_nav_item"><a href="/Web/Signup.aspx">Sign up</a></li>
                                </ul>
                            </div>
                        </nav>
                    </div>
                    <div class="header_side d-flex flex-row justify-content-center align-items-center">
                        <img src="/DashboardFile/Website/images/phone-call.svg" alt="">
                        <span>+880 1XXX XXXXXX</span>
                    </div>

                    <!-- Hamburger -->
                    <div class="hamburger_container">
                        <i class="fas fa-bars trans_200"></i>
                    </div>

                </header>

                <!-- Menu -->
                <div class="menu_container menu_mm">

                    <!-- Menu Close Button -->
                    <div class="menu_close_container">
                        <div class="menu_close"></div>
                    </div>

                    <!-- Menu Items -->
                    <div class="menu_inner menu_mm">
                        <div class="menu menu_mm">
                            <ul class="menu_list menu_mm">
                                <li class="menu_item menu_mm"><a href="/Web/Resources.aspx">home</a></li>
                                <li class="menu_item menu_mm"><a href="/Web/Notice.aspx">Notice</a></li>
                                <li class="menu_item menu_mm"><a href="/Web/Login.aspx">Log in</a></li>
                                <li class="menu_item menu_mm"><a href="/Web/Signup.aspx">Sign up</a></li>
                            </ul>
                        </div>
                    </div>
                </div>

                <!-- Home -->

                <div class="home">

                    <!-- Hero Slider -->
                    <div class="hero_slider_container">
                        <div class="hero_slider owl-carousel">

                            <!-- Hero Slide -->
                            <div class="hero_slide">
                                <div class="hero_slide_background" style="background-image: url(/DashboardFile/Website/images/slider_background.jpg)"></div>
                                <div class="hero_slide_container d-flex flex-column align-items-center justify-content-center">
                                    <div class="hero_slide_content text-center">
                                        <h1 data-animation-in="fadeInUp" data-animation-out="animate-out fadeOut">Thesis <span>Management</span> System</h1>
                                    </div>
                                </div>
                            </div>

                            <!-- Hero Slide -->
                            <div class="hero_slide">
                                <div class="hero_slide_background" style="background-image: url(/DashboardFile/Website/images/slider_background.jpg)"></div>
                                <div class="hero_slide_container d-flex flex-column align-items-center justify-content-center">
                                    <div class="hero_slide_content text-center">
                                        <h1 data-animation-in="fadeInUp" data-animation-out="animate-out fadeOut">Thesis <span>Management</span> System</h1>

                                    </div>
                                </div>
                            </div>

                            <!-- Hero Slide -->
                            <div class="hero_slide">
                                <div class="hero_slide_background" style="background-image: url(/DashboardFile/Website/images/slider_background.jpg)"></div>
                                <div class="hero_slide_container d-flex flex-column align-items-center justify-content-center">
                                    <div class="hero_slide_content text-center">
                                        <h1 data-animation-in="fadeInUp" data-animation-out="animate-out fadeOut">Thesis <span>Management</span> System</h1>

                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="hero_slider_left hero_slider_nav trans_200"><span class="trans_200"><i class="fas fa-chevron-left"></i></span></div>
                        <div class="hero_slider_right hero_slider_nav trans_200"><span class="trans_200"><i class="fas fa-chevron-right"></i></span></div>
                    </div>
                </div>
                <!-- Popular -->
                <div class="popular page_section">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <div class="section_title text-center">
                                    <h1>Notice</h1>
                                </div>
                            </div>
                        </div>
                        <div class="row course_boxes">
                            <div class="col-12 table-responsive">

                                <asp:GridView ID="gridNotice" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridNotice_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Notice Found" AllowPaging="True" PageSize="30" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Notice">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("NoticeId")%>' />
                                                <h3>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Notice")%>'></asp:Label></h3>
                                                <p>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("NoticeTime")%>'></asp:Label>
                                                </p>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>


                <!-- Footer -->

                <footer class="footer">
                    <div class="container">
                        <!-- Footer Copyright -->

                        <div class="footer_bar d-flex flex-column flex-sm-row align-items-center">
                            <div class="footer_copyright">
                                <span>
                                    <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                    Copyright &copy;<script>document.write(new Date().getFullYear());</script>
                                    All rights reserved.
                                    <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                </span>
                            </div>

                        </div>

                    </div>
                </footer>

            </div>
        </div>
    </form>
    <script src="/DashboardFile/Website/js/jquery-3.2.1.min.js"></script>
    <script src="/DashboardFile/Website/styles/bootstrap4/popper.js"></script>
    <script src="/DashboardFile/Website/styles/bootstrap4/bootstrap.min.js"></script>
    <script src="/DashboardFile/Website/plugins/greensock/TweenMax.min.js"></script>
    <script src="/DashboardFile/Website/plugins/greensock/TimelineMax.min.js"></script>
    <script src="/DashboardFile/Website/plugins/scrollmagic/ScrollMagic.min.js"></script>
    <script src="/DashboardFile/Website/plugins/greensock/animation.gsap.min.js"></script>
    <script src="/DashboardFile/Website/plugins/greensock/ScrollToPlugin.min.js"></script>
    <script src="/DashboardFile/Website/plugins/OwlCarousel2-2.2.1/owl.carousel.js"></script>
    <script src="/DashboardFile/Website/plugins/scrollTo/jquery.scrollTo.min.js"></script>
    <script src="/DashboardFile/Website/plugins/easing/easing.js"></script>
    <script src="/DashboardFile/Website/js/custom.js"></script>
</body>
</html>
