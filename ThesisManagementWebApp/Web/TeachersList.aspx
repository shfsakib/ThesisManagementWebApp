<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TeachersList.aspx.cs" Inherits="ThesisManagementWebApp.Web.TeachersList" %>

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
                <h3 class="m-0">Teachers List</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-3 justify-content-center">
                <asp:DropDownList ID="ddlStatus" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged" class="form-control w-100" runat="server">
                    <asp:ListItem Value="A">Active</asp:ListItem>
                    <asp:ListItem Value="I">Inactive</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-12  justify-content-center table-responsive">
                <asp:GridView ID="gridTeacher" Width="100%" class="table table-hover table-bordered table-striped" OnRowDataBound="gridTeacher_OnRowDataBound" OnPageIndexChanging="gridTeacher_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Teacher Info Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Teacher_Id">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("IdNo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teacher_Name">
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

                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation">
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Free_Schedule">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("FreeScheduleFrom")+" - "+Eval("FreeScheduleTo")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preffer">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("Preffer")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Interest">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Interest")%>'></asp:Label>
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
