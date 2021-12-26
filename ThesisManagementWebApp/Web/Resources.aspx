<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" EnableEventValidation="false" Inherits="ThesisManagementWebApp.Web.resources_list" %>

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
                       <%-- <img src="/DashboardFile/Website/images/phone-call.svg" alt="">
                        <span>+880 1XXX XXXXXX</span>--%>
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
                                        <h1 data-animation-in="fadeInUp" data-animation-out="animate-out fadeOut">Thesis & Project <span>Management</span> System</h1>
                                    </div>
                                </div>
                            </div>

                            <!-- Hero Slide -->
                            <div class="hero_slide">
                                <div class="hero_slide_background" style="background-image: url(/DashboardFile/Website/images/slider_background.jpg)"></div>
                                <div class="hero_slide_container d-flex flex-column align-items-center justify-content-center">
                                    <div class="hero_slide_content text-center">
                                        <h1 data-animation-in="fadeInUp" data-animation-out="animate-out fadeOut">Thesis & Project <span>Management</span> System</h1>

                                    </div>
                                </div>
                            </div>

                            <!-- Hero Slide -->
                            <div class="hero_slide">
                                <div class="hero_slide_background" style="background-image: url(/DashboardFile/Website/images/slider_background.jpg)"></div>
                                <div class="hero_slide_container d-flex flex-column align-items-center justify-content-center">
                                    <div class="hero_slide_content text-center">
                                        <h1 data-animation-in="fadeInUp" data-animation-out="animate-out fadeOut">Thesis & Project <span>Management</span> System</h1>

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
                                    <h1>Resources</h1>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:DropDownList ID="ddlType" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" class="form-control w-100" runat="server">
                                    <asp:ListItem>File</asp:ListItem>
                                    <asp:ListItem>Video</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row course_boxes">
                            <asp:Repeater ID="repeaterResource" runat="server" OnItemDataBound="repeaterResource_OnItemDataBound">
                                <ItemTemplate>
                                    <div class="col-lg-2 col-md-3 course_box">
                                        <div class="card">
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ResourceId") %>' />
                                            <asp:HiddenField ID="Type" runat="server" Value='<%#Eval("Type") %>' />
                                            <asp:Image ID="imgFile" class="card-img-top" ImageUrl="../DashboardFile/file.png" Style="max" runat="server" />
                                            <video id="videoResource" class="card-img-top" runat="server" controls>
                                                <source src='<%#Eval("Path") %>' />
                                            </video>
                                            <div class="card-body text-center">
                                                <div class="card-title">
                                                    <h3 style="display: block; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"><%#Eval("ResourceName") %></h3>
                                                </div>

                                            </div>
                                            <div class="price_box d-flex flex-row align-items-center">
                                                <a class="course_price w-100 text-center text-white" runat="server" style="font-size: 18px; padding-top: 20px;" id="btnDownload" href='<%#Eval("Path") %>'>Download</a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

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
                                    Copyright &copy;<script>document.write(new Date().getFullYear());</script> Department of CSE, IIUC
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
