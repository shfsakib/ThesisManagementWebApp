<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="view-assigned-list.aspx.cs" Inherits="ThesisManagementWebApp.Web.view_assigned_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
        </div>
        <div class="card card-body m-3">
            <div class="row card-header mb-2">
                <div class="col-sm-6">
                    <h3 class="m-0">Assigned List</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 justify-content-center">
                    <asp:dropdownlist id="ddlBatch" class="form-control w-100" runat="server">
                    </asp:dropdownlist>
                </div>
                <div class="col-lg-2 justify-content-center">
                    <asp:dropdownlist id="ddlSection" class="form-control" runat="server">
                        <asp:ListItem>Section</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:dropdownlist>
                </div>
                <div class="col-lg-2 justify-content-center">
                    <asp:linkbutton id="lnkSearch" class="btn btn-warning text-white" onclick="lnkSearch_OnClick" runat="server">Search</asp:linkbutton>
                </div>
            </div>
            <div class="col-3">
            </div>
            <div class="row pt-3">
                <div class="col-12  justify-content-center table-responsive">
                    <asp:gridview id="gridStudent" width="100%" class="table table-hover table-bordered table-striped" onpageindexchanging="gridStudent_OnPageIndexChanging" autogeneratecolumns="False" showheader="False" showheaderwhenempty="True" emptydatatext="No Data Found" allowpaging="True" pagesize="30" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-12 p-2">
                                           <h4> <%#Eval("StudentName")+" is working under the supervision of "+Eval("TeacherName")%></h4>
                                        </div>
                                        <div class="col-lg-2 text-center">
                                            <asp:Image runat="server" Style="width: 100%; height: 125px" ImageUrl='<%#Image(Eval("StudentPicture").ToString())%>'></asp:Image>
                                        </div>
                                        <div class="col-lg-4"> 
                                            <asp:HiddenField ID="hiddenStudentId" runat="server" Value='<%#Eval("StudentId")%>' />
                                            <span>Student Name:<asp:Label ID="lblStuName" runat="server" Style="font-size: 25px; font-weight: bold;" Text='<%#Eval("StudentName")%>'></asp:Label></span>
                                            <span class="d-block"><i class="far fa-id-card"></i>&nbsp;&nbsp;<asp:Label ID="lblStuId" runat="server" Text='<%#Eval("StudentIdNo")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="far fa-envelope"></i>&nbsp;&nbsp;<asp:Label ID="lblStuEmail" runat="server" Text='<%#Eval("StudentEmail")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-phone-alt"></i>&nbsp;&nbsp;<asp:Label ID="lblStuMobile" runat="server" Text='<%#Eval("StudentMobileNo")%>'></asp:Label>
                                            </span>  
                                            <span class="d-block"><i class="fas fa-book-reader"></i>&nbsp;&nbsp;<asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-clipboard-list"></i>&nbsp;&nbsp;<asp:Label ID="lblDescription" runat="server" Style="font-size: 15px;" Text='<%#Eval("Description")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-paperclip"></i>&nbsp;&nbsp;<asp:Label ID="lblFile" runat="server" Text='<%#Eval("FileName")%>'></asp:Label>
                                                <a href='<%#Eval("Attachment") %>'  class="btn btn-primary" title="Download"><i class="fas fa-download"></i></a>
                                            </span>
                                        </div>
                                        <div class="col-lg-2 text-center">
                                            <asp:Image runat="server" Style="width: 100%; height: 125px" ImageUrl='<%#Image(Eval("TeacherPicture").ToString())%>'></asp:Image>
                                        </div>
                                        <div class="col-lg-4"> 
                                            <asp:HiddenField ID="hiddenTeacherId" runat="server" Value='<%#Eval("TeacherId")%>' />
                                             <span>Teacher Name:</span><asp:Label ID="lblTeacherName" runat="server" Style="font-size: 25px; font-weight: bold;" Text='<%#Eval("TeacherName")%>'></asp:Label>
                                            <span class="d-block"><i class="far fa-id-card"></i>&nbsp;&nbsp;<asp:Label ID="lblTeacherId" runat="server" Text='<%#Eval("TeacherIdNo")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="far fa-envelope"></i>&nbsp;&nbsp;<asp:Label ID="lblTeacherEmail" runat="server" Text='<%#Eval("TeacherEmail")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-phone-alt"></i>&nbsp;&nbsp;<asp:Label ID="lblTeacherMobile" runat="server" Text='<%#Eval("TeacherMobileNo")%>'></asp:Label>
                                            </span>
                                            
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:gridview>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
