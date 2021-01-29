<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="UploadFinalReport.aspx.cs" Inherits="ThesisManagementWebApp.Web.UploadFinalReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Upload Final Report</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Title</span>
                <asp:TextBox ID="txtTitle" class="form-control w-100 mt-1" placeholder="Xyz" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Type</span>
                <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Project</asp:ListItem>
                    <asp:ListItem>Thesis</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Upload your report (.pdf*,.zip*)</span>
                <asp:FileUpload ID="fileReport" accept=".pdf,.zip" runat="server" />
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" class="btn btn-primary mt-1 w-100" Text="Upload" />
            </div>
            <div class="col-lg-3"></div>
        </div>

    </div>
</asp:Content>
