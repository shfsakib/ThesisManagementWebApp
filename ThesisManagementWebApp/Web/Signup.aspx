<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="ThesisManagementWebApp.Web.SignupOption" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TMS | Sign up</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="icon" href="/DashboardFile/tmsfav.ico" type="image/x-icon" />

    <link href="../DashboardFile/Signup/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all" />
    <link href="../DashboardFile/Signup/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all" />
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="../DashboardFile/Signup/vendor/select2/select2.min.css" rel="stylesheet" media="all" />
    <link href="../DashboardFile/Signup/vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all" />
    <link href="../DashboardFile/Signup/css/main.css" rel="stylesheet" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-wrapper bg-gra-02 p-t-130 p-b-100 font-poppins">
            <div class="wrapper wrapper--w680">
                <div class="card card-4">
                    <div class="card-body">
                        <h2 class="title">Registration Form</h2>

                        <div class="input-group">
                            <div class="col-12">
                                <div class="input-group">
                                    <label class="label">Name</label>
                                    <asp:TextBox ID="txtName" runat="server" autocomplete="off" class="input--style-4" placeholder="Mr. X,Mrs. Y"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                            <div class="col-12">
                                <div class="input-group">
                                    <label class="label">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="example@example.com"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                            <div class="col-12">
                                <div class="input-group">
                                    <label class="label">Mobile no.</label>
                                    <asp:TextBox ID="txtMobile" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="01XXXXXXXXX"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Date of Birth</label>
                                    <div class="input-group-icon">
                                        <asp:TextBox ID="txtDob" runat="server" TextMode="Date" autocomplete="off" class="input--style-4 w-100" placeholder="mm/dd/yyyy"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Gender</label>
                                    <asp:DropDownList ID="ddlGender" class="form-control" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                            <div class="col-12">
                                <div class="input-group">
                                    <label class="label">Address</label>
                                    <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" class="input--style-4 w-100 h-50" placeholder="House no, Area, District, Division"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                             <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Type</label>
                                    <asp:DropDownList ID="ddlType" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" class="form-control w-100" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Teacher</asp:ListItem>
                                        <asp:ListItem>Coordinator</asp:ListItem>
                                        <asp:ListItem>Student</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="teacherPanel" Visible="False" runat="server">
                            <div class="row row-space">
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Department</label>
                                        <asp:DropDownList ID="ddlDepartment" class="form-control w-100" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Designation</label>
                                        <asp:TextBox ID="txtDesignation" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="BSc.,MSc.,PhD."></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row row-space">
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Free Schedule</label>
                                        <asp:TextBox ID="txtTimeFrom" runat="server" TextMode="Time" autocomplete="off" class="input--style-4 w-100" placeholder="XXXXX"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">&nbsp;</label>
                                        <asp:TextBox ID="txtTimeTo" runat="server" TextMode="Time" autocomplete="off" class="input--style-4 w-100" placeholder="XXXXX"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row row-space">
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Id No.</label>
                                        <asp:TextBox ID="txtTeacherId" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="XXX XXX XXX"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Preffer</label>
                                        <asp:DropDownList ID="ddlPreffer" class="form-control w-100" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Project</asp:ListItem>
                                            <asp:ListItem>Thesis</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>

                        </asp:Panel>
                        <asp:Panel ID="studentPanel" Visible="False" runat="server">
                            <div class="row row-space">
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Department</label>
                                        <asp:DropDownList ID="ddlStudentDepartment" class="form-control w-100" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Id No.</label>
                                        <asp:TextBox ID="txtStdntId" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="XXX XXX XXX"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="coordinatePanel" Visible="False" runat="server">
                            <div class="row row-space">
                                <div class="col-12">
                                    <div class="input-group">
                                        <label class="label">Id No.</label>
                                        <asp:TextBox ID="txtCOId" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="XXX XXX XXX"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-2">
                                    <div class="input-group">
                                        <label class="label">Designation</label>
                                        <asp:TextBox ID="txtCoDesignation" runat="server" autocomplete="off" class="input--style-4 w-100" placeholder="BSc.,MSc.,PhD. etc"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="row row-space">
                            <div class="col-12">
                                <div class="input-group">
                                    <label class="label">Upload Picture.</label>
                                    <asp:FileUpload ID="filePic" accept="image/*" runat="server" onchange="ImagePreview(this)" />
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Password</label>
                                    <asp:TextBox ID="txtPass"  TextMode="Password" runat="server" autocomplete="off" class="input--style-4 w-100 h-50" placeholder="*********" MaxLength="20"></asp:TextBox>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label"></label>
                                    <asp:Image ID="imgPic" Style="border: 1px solid #d3d3d3; border-radius: 5px; width: 200px; height: 200px;" ImageUrl="../DashboardFile/DummyPic.png" runat="server" />
                                </div>
                            </div>

                        </div>
                        <div class="row row-space">
                            <div class="col-12">
                                <div class="input-group">
                                    <asp:Label ID="lblMessage" runat="server" Text="" Style="font-size: 16px;"></asp:Label>

                                </div>
                            </div>
                        </div>
                        <div class="p-t-15">
                            <button id="btnSave" class="btn btn--radius-2 btn--blue" runat="server" onserverclick="OnServerClick" type="submit">Submit</button>
                        </div>
                         <div class="row row-space">
                            <div class="col-12">
                                <div class="input-group pt-3"><br/>
                                   <span>Back to <a href="/Web/Login.aspx">Login</a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../DashboardFile/Signup/vendor/jquery/jquery.min.js"></script>
    <script src="../DashboardFile/Signup/vendor/select2/select2.min.js"></script>
    <script src="../DashboardFile/Signup/vendor/datepicker/moment.min.js"></script>
    <script src="../DashboardFile/Signup/vendor/datepicker/daterangepicker.js"></script>
    <script src="../DashboardFile/Signup/js/global.js"></script>
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
