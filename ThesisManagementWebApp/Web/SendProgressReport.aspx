﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="SendProgressReport.aspx.cs" Inherits="ThesisManagementWebApp.Web.SendProgressReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-body m-3">
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
                <asp:TextBox ID="txtSubject" class="form-control w-100 mt-1" placeholder="You request subject" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Description</span>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="150px" class="form-control w-100 mt-1" placeholder="Your request description" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnSave" OnClick="<div class="card card-body m-3">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Teacher's Name</span>
                <asp:TextBox ID="TextBox1" ReadOnly="True" class="form-control w-100 mt-1" placeholder="Mr. X, Mrs. Y" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Teacher's Email</span>
                <asp:TextBox ID="TextBox2" ReadOnly="True" class="form-control w-100 mt-1" placeholder="name@example.com" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Subject</span>
                <asp:TextBox ID="TextBox3" class="form-control w-100 mt-1" placeholder="You request subject" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Description</span>
                <asp:TextBox ID="TextBox4" TextMode="MultiLine" Height="150px" class="form-control w-100 mt-1" placeholder="Your request description" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <span>Attachment</span>
                <asp:FileUpload ID="FileUpload1" class="d-block" accept="/*" runat="server" />
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <asp:Label ID="Label1" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 justify-content-center">
                <asp:Button ID="Button1" OnClick="Button1_OnClick" runat="server" class="btn btn-primary mt-1 w-100" Text="Save" />
            </div>
            <div class="col-lg-3"></div>
        </div>

    </div>" runat="server" class="btn btn-primary mt-1 w-100" Text="Save" />
            </div>
            <div class="col-lg-3"></div>
        </div>

    </div>
</asp:Content>