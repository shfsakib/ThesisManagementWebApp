<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="SendProgressReport.aspx.cs" Inherits="ThesisManagementWebApp.Web.SendProgressReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row card-header mb-2 pl-2">
            <div class="col-sm-6 pl-0">
                <h3 class="m-0">Send Progress Report</h3>
            </div>
        </div>
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
                <asp:TextBox ID="txtSubject" class="form-control w-100 mt-1" placeholder="You report subject" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Description</span>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="150px" class="form-control w-100 mt-1" placeholder="Your report description" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnSave" OnClick="btnSave_OnClick" runat="server" class="btn btn-primary mt-1 w-100" Text="Send" />
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-12 table-responsive mt-3">
                <asp:GridView ID="gridReport" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridReport_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Report Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Subject">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("Subject")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:HiddenField ID="hiddenReportId" runat="server" Value='<%#Eval("ReportId")%>' />
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FileName">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("FileName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SendTime">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("SendTime")%>'></asp:Label>
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
