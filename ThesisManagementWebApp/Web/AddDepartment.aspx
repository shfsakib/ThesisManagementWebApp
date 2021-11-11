<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="ThesisManagementWebApp.Web.AddDepartment" %>

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
                <h3 class="m-0">Department Info</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Department Name</span>
                <asp:TextBox ID="txtDepartmentName" class="form-control" placeholder="CSE,EEE etc" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" class="btn btn-primary mt-1 w-100" autocomplete="off" Text="Save" />
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row pt-3">
            <div class="col-lg-2"></div>
            <div class="col-lg-8 justify-content-center table-responsive">
                <asp:GridView ID="gridDepartment" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridDepartment_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Department Found" AllowPaging="True" PageSize="30" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Department_Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("DepartmentId")%>' />
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate"  class="btn mt-1" OnClick="lnkUpdate_OnClick" runat="server" title="Update"><i class="fas fa-edit"></i></asp:LinkButton>
                           </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
