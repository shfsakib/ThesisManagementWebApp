<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StudentList.aspx.cs" Inherits="ThesisManagementWebApp.Web.StudentList" %>

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
                <h3 class="m-0">Students List</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 justify-content-center">
                <asp:DropDownList ID="ddlStatus" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged" class="form-control w-100" runat="server">
                    <asp:ListItem Value="A">Active</asp:ListItem>
                    <asp:ListItem Value="I">Inactive</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 justify-content-center">
                <asp:DropDownList ID="ddlBatch" class="form-control w-100" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 justify-content-center">
                <asp:DropDownList ID="ddlSection" class="form-control" runat="server">
                    <asp:ListItem>Section</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 justify-content-center">
                <asp:LinkButton ID="lnkSearch" class="btn btn-warning text-white" OnClick="lnkSearch_OnClick" runat="server">Search</asp:LinkButton>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-lg-12 justify-content-center table-responsive">
                <asp:GridView ID="gridStudent" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridStudent_OnPageIndexChanging" OnRowDataBound="gridStudent_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Student Info Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Student_Id">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("IdNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student_Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("RegistrationId")%>' />
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MobileNo">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Batch">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Batch")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Picture">
                            <ItemTemplate>
                                <asp:Image runat="server" Style="width: 75px; height: 75px" ImageUrl='<%#Eval("Picture")%>'></asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnActive" class="btn btn-primary mt-1" OnClick="lnActive_OnClick" runat="server" title="Make Active"><i class="fas fa-check fa-lg"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkInactive" class="btn btn-danger mt-1" OnClick="lnkInactive_OnClick" runat="server" title="Make Inactive"><i class="fas fa-times fa-lg"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
