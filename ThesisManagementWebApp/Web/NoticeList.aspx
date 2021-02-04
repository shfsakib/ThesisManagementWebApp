<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="ThesisManagementWebApp.Web.NoticeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Notice List</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8 justify-content-center table-responsive">
                <asp:gridview id="gridResource" width="100%" class="table table-hover table-bordered table-striped" onpageindexchanging="gridResource_OnPageIndexChanging" autogeneratecolumns="False" showheader="True" showheaderwhenempty="True" emptydatatext="No Notice Found" allowpaging="True" pagesize="30" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Notice">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("NoticeId")%>' />
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Notice")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Post_time">
                            <ItemTemplate> 
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("NoticeTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove"  class="btn btn-danger mt-1" OnClick="lnkRemove_OnClick" runat="server" title="Remove"><i class="fas fa-trash-alt fa-lg"></i></asp:LinkButton>
                               </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:gridview>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
