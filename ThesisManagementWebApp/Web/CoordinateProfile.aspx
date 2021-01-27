<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="CoordinateProfile.aspx.cs" Inherits="ThesisManagementWebApp.Web.CoordinateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Profile</h1>
                </div>
            </div>
        </div>
    </div>
    <style>
        div {
            font-size: 17px;
        }
    </style>
    <div class="card card-body m-3">
        <div class="row">
            <div class="col-lg-12 p-3">
                <div class="row pb-4 text-center">
                    <div class="col-lg-12 mb-4 text-center">
                        <img src="/DashboardFile/DummyPic.png" runat="server" id="imgDiv" style="width: 200px; height: 200px; border-radius: 50%; border: 1px solid #d3d3d3" />
                    </div>

                    <a class="btn btn-primary m-auto btnEdit"><i class="fas fa-edit"></i>&nbsp;&nbsp;Edit</a>
                </div>
                <div class="row pt-4">
                    <div class="col-lg-6">
                        Name:
                        <asp:label id="lblName" style="font-size: 15px;" runat="server" text="Name"></asp:label>
                    </div>
                    <div class="col-lg-6">
                        Email:
                        <asp:label id="lblEmail" style="font-size: 15px;" runat="server" text="Email"></asp:label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        Id No:
                        <asp:label id="lblId" style="font-size: 15px;" runat="server" text="Id"></asp:label>
                    </div>
                    <div class="col-lg-6">
                        Contact no.:
                        <asp:label id="lblMobile" style="font-size: 15px;" runat="server" text="Mobile"></asp:label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        Date of Birth:
                        <asp:label id="lblDob" style="font-size: 15px;" runat="server" text="dob"></asp:label>
                    </div>
                    <div class="col-lg-6">
                        Gender:
                        <asp:label id="lblGender" style="font-size: 15px;" runat="server" text="lblGender"></asp:label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        Address:
                        <asp:label id="lblAddress" style="font-size: 15px;" runat="server" text="Address"></asp:label>
                    </div>
                    <div class="col-lg-6">
                        Designation:
                        <asp:label id="lblDesignation" style="font-size: 15px;" runat="server" text="Designation"></asp:label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>
        .ModalBg {
            position: absolute;
            height: calc(100%);
            width: calc(100%);
            background: rgba(0, 0, 0, 0.7);
            top: 0;
            left: 0;
            overflow-x: hidden;
            overflow-y: hidden;
            display: none;
        }

        .EditModel {
            position: relative;
            width: 500px;
            height: auto;
            max-height: 500px;
            border-radius: 10px;
            border-bottom: 10px solid lightgreen;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background: white;
            padding: 20px;
            font-family: comic sans ms;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .modelHead {
            width: calc(100%);
            height: 50px;
            border-bottom: 1px solid #d3d3d3;
            padding: 10px;
        }

        .closeModal {
            position: absolute;
            top: 30px;
            font-size: 25px;
            right: 25px;
            color: #495057;
            cursor: pointer;
        }
    </style>
    <div class="ModalBg">
        <div class="EditModel">
            <div class="modelHead">
                <h4>Edit Profile</h4>
                <span class="closeModal"><i class="fas fa-times fa-lg close"></i></span>
            </div>
            <div class="row modelBody pt-3">
                <div class="col-6">
                    <label class="label">Name</label>
                    <asp:textbox id="txtName" runat="server" autocomplete="off" class="form-control" placeholder="Mr. X,Mrs. Y"></asp:textbox>
                </div>
                <div class="col-6">
                    <label class="label">Email</label>
                    <asp:textbox id="txtEmail" runat="server" autocomplete="off" class="form-control w-100" placeholder="example@example.com"></asp:textbox>
                </div>
                <div class="col-6">
                    <label class="label">Mobile no.</label>
                    <asp:textbox id="txtMobile" runat="server" autocomplete="off" class="form-control w-100" placeholder="01XXXXXXXXX"></asp:textbox>
                </div>
                <div class="col-6">
                    <label class="label">Date of Birth</label>
                    <asp:textbox id="txtDob" runat="server" textmode="Date" autocomplete="off" class="form-control w-100" placeholder="mm/dd/yyyy"></asp:textbox>
                </div>
                <div class="col-12">
                    <label class="label">Gender</label>
                    <asp:dropdownlist id="ddlGender" class="form-control" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:dropdownlist>
                </div>
                <div class="col-12">
                    <label class="label">Address</label>
                    <asp:textbox id="txtAddress" textmode="MultiLine" height="80px" runat="server" autocomplete="off" class="form-control w-100 h-50" placeholder="House no, Area, District, Division"></asp:textbox>
                </div>
                <div class="col-6">
                    <label class="label">Designation</label>
                    <asp:textbox id="txtDesignation" runat="server" autocomplete="off" class="form-control w-100" placeholder="BSc.,MSc.,PhD."></asp:textbox>
                </div>
                <div class="col-6">
                    <label class="label">Id No.</label>
                    <asp:textbox id="txtTeacherId" runat="server" autocomplete="off" class="form-control w-100" placeholder="XXX XXX XXX"></asp:textbox>

                </div>
              <div class="col-12">
                    <label class="label">Password</label>
                    <asp:textbox id="txtPass" runat="server" autocomplete="off" class="form-control w-100 h-50" placeholder="*********" maxlength="20"></asp:textbox>
                </div>
                <div class="col-12">
                    <label class="label">Profile Picure</label>
                    <asp:fileupload id="filePic" accept="image/*" runat="server" onchange="ImagePreview(this)" />
                </div>
                <div class="col-6 mt-1">
                    <label class="label"></label>
                    <asp:image id="imgPic" style="border: 1px solid #d3d3d3; border-radius: 5px; width: 200px; height: 200px;" imageurl="../DashboardFile/DummyPic.png" runat="server" />
                </div>
                <div class="col-12 pt-2">
                    <asp:linkbutton id="btnUpdate" onclick="btnUpdate_OnClick" class="btn btn-primary" style="width: 100%;" runat="server">Update</asp:linkbutton>
                </div>
            </div>
        </div>
    </div>
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
</asp:Content>
