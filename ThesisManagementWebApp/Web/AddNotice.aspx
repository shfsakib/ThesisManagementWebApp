<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="ThesisManagementWebApp.Web.AddNotice" %>
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
                <h3 class="m-0">Add Notice</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Notice</span>
                <asp:TextBox ID="txtNotice" TextMode="MultiLine" Height="100px" class="form-control w-100 mt-1" placeholder="Notice Description" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" class="btn btn-primary mt-1 w-100" Text="Post Notice" />
            </div>
            <div class="col-lg-3"></div>
        </div>

    </div>
</asp:Content>
