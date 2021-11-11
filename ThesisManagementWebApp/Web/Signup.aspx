<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="ThesisManagementWebApp.Web.SignupOption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TMS | Sign up</title>
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
        <div class="col-lg-12" style="padding-top: 50px;">
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-lg-6">
                    <div class="card card-body">
                        <div class="row">
                            <div class="col-lg-12 card-header text-center">
                                <h3>Registration Form</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 mt-3">
                                <label class="label">Name</label>
                                <asp:TextBox ID="txtName" runat="server" autocomplete="off" class="form-control" placeholder="Mr. X,Mrs. Y"></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label class="label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" class="form-control w-100" placeholder="example@example.com"></asp:TextBox>
                            </div>
                            <div class="col-lg-12">
                                <label class="label">Mobile no.</label>
                                <asp:TextBox ID="txtMobile" runat="server" autocomplete="off" class="form-control w-100" placeholder="01XXXXXXXXX"></asp:TextBox>

                            </div>
                            <div class="col-lg-6">
                                <label class="label">Gender</label>
                                <asp:DropDownList ID="ddlGender" class="form-control" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <label class="label">Type</label>
                                <asp:DropDownList ID="ddlType" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" class="form-control w-100" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Teacher</asp:ListItem>
                                    <asp:ListItem>Coordinator</asp:ListItem>
                                    <asp:ListItem>Student</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="teacherPanel" Visible="False" runat="server">
                                    <div class="row row-space">

                                        <div class="col-lg-12">
                                            <div class="input-group">
                                                <label class="label">Designation</label>
                                                <asp:TextBox ID="txtDesignation" runat="server" autocomplete="off" class="form-control w-100" placeholder="Lecturer, Sr. Lecturer..."></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Department</label>
                                                <asp:DropDownList ID="ddlDepartment" class="form-control w-100" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Interested Topic</label>
                                                <asp:TextBox ID="txtTopic" runat="server" autocomplete="off" class="form-control w-100" placeholder="Machine Learning...."></asp:TextBox>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-space">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Free Schedule</label>
                                                <asp:TextBox ID="txtTimeFrom" runat="server" TextMode="Time" autocomplete="off" class="form-control w-100" placeholder="XXXXX"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">&nbsp;</label>
                                                <asp:TextBox ID="txtTimeTo" runat="server" TextMode="Time" autocomplete="off" class="form-control w-100" placeholder="XXXXX"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-space">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Id No.</label>
                                                <asp:TextBox ID="txtTeacherId" runat="server" autocomplete="off" class="form-control w-100" placeholder="XXX XXX XXX"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Preffer</label>
                                                <asp:DropDownList ID="ddlPreffer" class="form-control w-100" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Project</asp:ListItem>
                                                    <asp:ListItem>Thesis</asp:ListItem>
                                                    <asp:ListItem>Both</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="studentPanel" Visible="False" runat="server">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label class="label">Department</label>
                                            <asp:DropDownList ID="ddlStudentDepartment" class="form-control w-100" runat="server">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <label class="label">Batch No.</label>
                                            <asp:TextBox ID="txtBatch" runat="server" autocomplete="off" class="form-control w-100" placeholder="40th Batch,41st Batch..."></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <label class="label">Id No.</label>
                                            <asp:TextBox ID="txtStdntId" runat="server" autocomplete="off" class="form-control w-100" placeholder="XXX XXX XXX"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="coordinatePanel" Visible="False" runat="server">
                                    <div class="row row-space">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Id No.</label>
                                                <asp:TextBox ID="txtCOId" runat="server" autocomplete="off" class="form-control w-100" placeholder="XXX XXX XXX"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <label class="label">Designation</label>
                                                <asp:TextBox ID="txtCoDesignation" runat="server" autocomplete="off" class="form-control w-100" placeholder="Lecturer, Sr. Lecturer..."></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="col-lg-6">
                                <label class="label">Upload Picture.</label>
                                <asp:FileUpload ID="filePic" accept="image/*" runat="server" onchange="ImagePreview(this)" />
                            </div>
                            <div class="col-lg-6">
                                <label class="label">Password</label>
                                <asp:TextBox ID="txtPass" TextMode="Password" runat="server" autocomplete="off" class="form-control w-100 h-50" placeholder="*********" MaxLength="20"></asp:TextBox>

                            </div>
                            <div class="col-lg-6">
                                <label class="label"></label>
                                <asp:Image ID="imgPic" Style="border: 1px solid #d3d3d3; border-radius: 5px; width: 175px; height: 175px;" ImageUrl="../DashboardFile/DummyPic.png" runat="server" />
                            </div>
                            <div class="col-lg-12">
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-lg-12">
                                <button id="btnSave" class="btn btn-primary btn-block mt-2" runat="server" onserverclick="OnServerClick" type="submit">Sign up</button>
                            </div>
                            <div class="col-lg-12 pt-2">
                                <span>Already have an account?Back to <a href="/Web/Login.aspx">Login</a></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3"></div>
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
    <script src="../DashboardFile/dist/js/pages/dashboard.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgPic.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</body>
</html>
