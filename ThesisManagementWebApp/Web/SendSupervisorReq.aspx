<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="SendSupervisorReq.aspx.cs" Inherits="ThesisManagementWebApp.Web.SendSupervisorReq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Send Supervision Request</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Teacher's Name</span>
                <asp:TextBox ID="txtName" ReadOnly="True" class="form-control w-100 mt-1" placeholder="Mr. X, Mrs. Y" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Teacher's Email</span>
                <asp:TextBox ID="txtEmail" ReadOnly="True" class="form-control w-100 mt-1" placeholder="name@example.com" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Subject</span>
                <asp:TextBox ID="txtSubject" class="form-control w-100 mt-1" placeholder="You request subject" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Description</span>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="150px" class="form-control w-100 mt-1" placeholder="Your request description" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Attachment</span>
                <asp:FileUpload ID="fileAttach" class="d-block" accept="/*" runat="server" />
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <asp:Label ID="lblMessage" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <asp:Button ID="btnSave" OnClick="btnSave_OnClick" runat="server" class="btn btn-primary mt-1 w-100" Text="Save" />
            </div>
            <div class="col-lg-3"></div>
        </div>

    </div>
</asp:Content>
