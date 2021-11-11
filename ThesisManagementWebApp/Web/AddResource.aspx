<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddResource.aspx.cs" Inherits="ThesisManagementWebApp.Web.AddResource" %>
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
                <h3 class="m-0">Add Resource</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Resource Name</span>
                <asp:TextBox ID="txtResourceName" class="form-control w-100 mt-1" placeholder="XYZ" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <label class="label">Resource Type</label>
                <asp:DropDownList ID="ddlType" class="form-control" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>File</asp:ListItem>
                    <asp:ListItem>Video</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <label class="label">Upload (.pdf*,.zip*,.videos*)</label><br/>
                <asp:FileUpload ID="filePic" accept=".pdf,.zip,video/*" runat="server" onchange="ImagePreview(this)" />
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
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" class="btn btn-primary mt-1 w-100" Text="Add" />
            </div>
            <div class="col-lg-3"></div>
        </div>

    </div>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     
</asp:Content>
