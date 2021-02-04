<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.Master" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="ThesisManagementWebApp.Web.Resources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="repeaterResource" runat="server" OnItemDataBound="repeaterResource_OnItemDataBound">
        <ItemTemplate>
            <div class="col-sm-3 col-md-6 col-lg-3 p-2" style="border: 1px solid #a5a3d1; text-align: center; border-radius: 10px;">
                <div class="wd-100">
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ResourceId") %>' />
                    <asp:HiddenField ID="Type" runat="server" Value='<%#Eval("Type") %>' />
                    <asp:Image ID="imgFile" ImageUrl="../DashboardFile/file.png" Style="width: 80%; height: 80%;" runat="server" />
                    <video id="videoResource" runat="server" Style="width: 80%; height:100%;" controls>
                        <source src='<%#Eval("Path") %>'/>
                    </video>
                </div>
                <h5 style="display: block; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;"><%#Eval("ResourceName") %></h5>
                <a class="btn btn-primary w-100 text-center pl-sm-3 pr-sm-3" runat="server" id="btnDownload" href='<%#Eval("Path") %>'>Download</a>

            </div>
        </ItemTemplate>
    </asp:Repeater> 
</asp:Content>
