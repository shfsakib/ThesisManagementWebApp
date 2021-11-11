<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="ThesisManagementWebApp.Web.AdminProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
        </div>
    </div>
    <style>
        div {
            font-size: 17px;
        }
    </style>
    <div class="card card-body m-3">
        <div class="row card-header mb-2">
            <div class="col-sm-6">
                <h3 class="m-0">Profile</h3>
            </div>
        </div>
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
                        <asp:Label ID="lblName" Style="font-size: 15px;" runat="server" Text="Name"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        Email:
                        <asp:Label ID="lblEmail" Style="font-size: 15px;" runat="server" Text="Email"></asp:Label>
                    </div>
                </div>
                <div class="row">

                    <div class="col-lg-6">
                        Gender:
                        <asp:Label ID="lblGender" Style="font-size: 15px;" runat="server" Text="lblGender"></asp:Label>
                    </div>
                    <div class="col-lg-6">
                        Contact no.:
                        <asp:Label ID="lblMobile" Style="font-size: 15px;" runat="server" Text="Mobile"></asp:Label>
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

            .EditModel::-webkit-scrollbar-thumb {
                width: 3px !important;
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
                    <asp:TextBox ID="txtName" runat="server" autocomplete="off" class="form-control" placeholder="Mr. X,Mrs. Y"></asp:TextBox>
                </div>
                <div class="col-6">
                    <label class="label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" class="form-control w-100" placeholder="example@example.com"></asp:TextBox>
                </div>
                <div class="col-6">
                    <label class="label">Mobile no.</label>
                    <asp:TextBox ID="txtMobile" runat="server" autocomplete="off" class="form-control w-100" placeholder="01XXXXXXXXX"></asp:TextBox>
                </div>

                <div class="col-12">
                    <label class="label">Gender</label>
                    <asp:DropDownList ID="ddlGender" class="form-control" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-12">
                    <label class="label">Password</label>
                    <asp:TextBox ID="txtPass" runat="server" autocomplete="off" class="form-control w-100 h-50" placeholder="*********" MaxLength="20"></asp:TextBox>
                </div>
                <div class="col-12">
                    <label class="label">Profile Picure</label><br />
                    <asp:FileUpload ID="filePic" accept="image/*" runat="server" onchange="ImagePreview(this)" />
                </div>
                <div class="col-6 mt-1">
                    <label class="label"></label>
                    <asp:Image ID="imgPic" Style="border: 1px solid #d3d3d3; border-radius: 5px; width: 200px; height: 200px;" ImageUrl="../DashboardFile/DummyPic.png" runat="server" />
                </div>
                <div class="col-12 pt-2">
                    <asp:LinkButton ID="btnUpdate" OnClick="btnUpdate_Click" class="btn btn-primary" Style="width: 100%;" runat="server">Update</asp:LinkButton>
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
