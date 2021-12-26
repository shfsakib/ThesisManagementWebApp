<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="document-list.aspx.cs" Inherits="ThesisManagementWebApp.Web.document_list" %>

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
            <div class="col-lg-3 justify-content-center"> 
                <asp:DropDownList ID="ddlType" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" class="form-control w-100" runat="server">
                   
                    <asp:ListItem>Proposal</asp:ListItem>
                    <asp:ListItem>Pre Defence</asp:ListItem>
                    <asp:ListItem>Final Defence</asp:ListItem>
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
                <asp:LinkButton ID="lnkSearch" class="btn btn-warning text-white" OnClick="lnkSearch_Click" runat="server">Search</asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class="col-12 table-responsive mt-3">
                <asp:GridView ID="gridDoc" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridDoc_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Documents Found" AllowPaging="True" PageSize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Matric_Id">
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
                        <asp:TemplateField HeaderText="SendTime">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("UploadTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                               
                                <a href='<%#Eval("Attachment") %>' class="btn btn-primary" title="Download"><i class="fas fa-download"></i> Download</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
