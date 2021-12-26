<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="ThesisManagementWebApp.Web.NoticeList" %>

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
                <h3 class="m-0">Notice List</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 justify-content-center table-responsive">
                <asp:GridView ID="gridResource" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridResource_OnPageIndexChanging" OnRowDataBound="gridResource_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Notice Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Notice">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("NoticeId")%>' />
                                <asp:Label ID="Label1" style="text-align: justify;" runat="server" Text='<%#Eval("Notice")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attachment">
                            <ItemTemplate>
                                <a href='<%#Eval("Attachment")%>' id="btnDownload" runat="server" target="_blank" class="btn btn-primary">Download Attached Fille</a>
                                <asp:Label ID="lblWarn" runat="server" Text="No Attachment Added"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Post_time">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("NoticeTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" class="btn btn-primary mt-1" href='<%#"/web/update-notice.aspx?id="+Eval("NoticeId") %>' runat="server" title="Update"><i class="fas fa-edit fa-lg"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkRemove" class="btn btn-danger mt-1" OnClick="lnkRemove_OnClick" runat="server" title="Remove"><i class="fas fa-trash-alt fa-lg"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
