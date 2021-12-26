<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="send-documents.aspx.cs" Inherits="ThesisManagementWebApp.Web.send_documents" %>

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
                <h3 class="m-0">Documents Info</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Document Type</span>
                <asp:DropDownList ID="ddlType" class="form-control w-100" runat="server">
                    <asp:ListItem>Select Type</asp:ListItem>
                    <asp:ListItem>Proposal</asp:ListItem>
                    <asp:ListItem>Pre Defence</asp:ListItem>
                    <asp:ListItem>Final Defence</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Metric Id</span>
                <asp:TextBox ID="txtMetricId" class="form-control w-100 mt-1" placeholder="Metric Id" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Topic Name</span>
                <asp:TextBox ID="txtTopicName" class="form-control w-100 mt-1" placeholder="Topic Name" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Attachment</span><br />
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
                <asp:GridView ID="gridDoc" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridDoc_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Documents Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Metric_Id">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("MetricId")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Topic_Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="hiddenReportId" runat="server" Value='<%#Eval("DocId")%>' />
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("TopicName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="FileName">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Attachment")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:Label ID="LabelType" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SendTime">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("UploadTime")%>'></asp:Label>
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
