<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TeacherApproval.aspx.cs" Inherits="ThesisManagementWebApp.Web.TeacherApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Teacher's Approval</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="card card-body m-3">
        <div class="row pt-3"> 
            <div class="col-12  justify-content-center table-responsive">
                <asp:gridview id="gridTeacher" width="100%" class="table table-hover table-bordered table-striped" onpageindexchanging="gridTeacher_OnPageIndexChanging" autogeneratecolumns="False" showheader="True" showheaderwhenempty="True" emptydatatext="No Teacher Info Found" allowpaging="True" pagesize="30" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="University_Id">
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
                    <asp:TemplateField HeaderText="DOB">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("DOB")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
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
                     <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                          <asp:Image runat="server" style="width: 75px;height: 75px" ImageUrl='<%#Image(Eval("Picture").ToString())%>'></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAccpet"  class="btn btn-primary mt-1" OnClick="lnkAccpet_OnClick" runat="server" title="Accpet"><i class="fas fa-check fa-lg"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkReject"  class="btn btn-danger mt-1" OnClick="lnkReject_OnClick" runat="server" title="Reject"><i class="fas fa-times fa-lg"></i></asp:LinkButton>
                           </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:gridview>
            </div> 
        </div>
    </div>
</asp:Content>
