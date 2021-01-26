<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="ThesisManagementWebApp.Web.AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Create Admin</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <span>Name</span>
                <asp:TextBox ID="txtName" class="form-control w-100 mt-1" placeholder="Mr. X, Mrs. Y" runat="server"></asp:TextBox>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <span>Email</span>
                <asp:TextBox ID="txtEmail" TextMode="Email" class="form-control w-100 mt-1" placeholder="example@example.com" runat="server"></asp:TextBox>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <span>Mobile no.</span>
                <asp:TextBox ID="txtMobile" runat="server" autocomplete="off" class="form-control w-100" placeholder="01XXXXXXXXX"></asp:TextBox>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <span>Date of Birth</span>
                <asp:TextBox ID="txtDob" runat="server" TextMode="Date" autocomplete="off" class="form-control w-100" placeholder="mm/dd/yyyy"></asp:TextBox>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <label class="label">Gender</label>
                <asp:DropDownList ID="ddlGender" class="form-control" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <label class="label">Address</label>
                <asp:TextBox ID="txtAddress" Height="80" TextMode="MultiLine" runat="server" autocomplete="off" class="form-control w-100 h-50" placeholder="House no, Area, District, Division"></asp:TextBox>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <span>Password</span>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" autocomplete="off" class="form-control w-100" placeholder="********"></asp:TextBox>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <label class="label">Upload Picture.</label>
                <asp:FileUpload ID="filePic" accept="image/*" runat="server" onchange="ImagePreview(this)" />
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <label class="label"></label>
                <asp:Image ID="imgPic" Style="border: 1px solid #d3d3d3; border-radius: 5px;margin-top: 5px; width: 200px; height: 200px;" ImageUrl="../DashboardFile/DummyPic.png" runat="server" />
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <asp:Label ID="lblMessage" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
            </div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4 justify-content-center">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" class="btn btn-primary mt-1 w-100" Text="Save" />
            </div>
            <div class="col-4"></div>
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
