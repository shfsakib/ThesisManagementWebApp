<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="ResourceList.aspx.cs" Inherits="ThesisManagementWebApp.Web.ResourceList" %>

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
                <h3 class="m-0">Resource List</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 justify-content-center table-responsive">
                <asp:GridView ID="gridResource" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridResource_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Resouce Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Department_Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ResourceId")%>' />
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ResourceName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Resource_Type">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove" class="btn btn-danger mt-1" OnClick="lnkRemove_OnClick" runat="server" title="Remove"><i class="fas fa-trash-alt fa-lg"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
