<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="ThesisManagementWebApp.Web.Notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8">
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
                       </Columns>
            </asp:gridview>
    </div>
    <div class="col-lg-2"></div>

</asp:Content>
