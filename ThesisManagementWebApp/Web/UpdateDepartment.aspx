<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="UpdateDepartment.aspx.cs" Inherits="ThesisManagementWebApp.Web.UpdateDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row card-header mb-2">
            <div class="col-sm-6">
                <h3 class="m-0">Update Department</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Department Name</span>
                <asp:TextBox ID="txtDepartmentName" class="form-control w-100 mt-1" placeholder="CSE,EEE etc" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_OnClick" class="btn btn-primary mt-1 w-100" autocomplete="off" Text="Update" />
            </div>
            <div class="col-lg-3"></div>
        </div>
        </div>
</asp:Content>
