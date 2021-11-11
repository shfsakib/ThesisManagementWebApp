<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="ViewStudentReq.aspx.cs" Inherits="ThesisManagementWebApp.Web.ViewStudentReq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
        </div>
        <div class="card card-body m-3">
            <div class="row card-header mb-2 pl-2">
                <div class="col-sm-6 pl-0">
                    <h3 class="m-0">Student Request List</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-5 justify-content-center">
                    <asp:DropDownList ID="ddlStudent" class="form-control select2" runat="server"></asp:DropDownList>
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
                    <asp:LinkButton ID="lnkSearch" class="btn btn-warning text-white" OnClick="lnkSearch_OnClick" runat="server">Search</asp:LinkButton>
                </div>
            </div>
            <div class="row pt-3">
                <div class="col-12  justify-content-center table-responsive">
                    <asp:GridView ID="gridStudent" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridStudent_OnPageIndexChanging" OnRowDataBound="gridStudent_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Request Found" AllowPaging="True" PageSize="30" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-3 text-center">
                                            <asp:Image runat="server" Style="width: 125px; height: 125px" ImageUrl='<%#Image(Eval("Picture").ToString())%>'></asp:Image>
                                        </div>
                                        <div class="col-9">
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("Status")%>' />
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("StudentId")%>' />
                                            <asp:Label ID="Label1" runat="server" Style="font-size: 25px; font-weight: bold;" Text='<%#Eval("Name")%>'></asp:Label>
                                            <span class="d-block"><i class="far fa-id-card"></i>&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text='<%#Eval("IdNo")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="far fa-envelope"></i>&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-phone-alt"></i>&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-building"></i>&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-book-reader"></i>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text='<%#Eval("Subject")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-clipboard-list"></i>&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Style="font-size: 15px;" Text='<%#Eval("Description")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-paperclip"></i>&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text='<%#Eval("FileName")%>'></asp:Label>
                                                <a href='<%#Eval("Attachment") %>' title="Download"><i class="fas fa-download"></i></a>
                                            </span>
                                            <span class="d-block">
                                                <asp:LinkButton ID="lnkAccept" class="btn btn-primary mt-1" OnClick="lnkAccept_OnClick" runat="server"><i class="fas fa-check"></i>&nbsp;Accept</asp:LinkButton>
                                                <asp:LinkButton ID="lnkReject" class="btn btn-danger mt-1" OnClick="lnkReject_OnClick" runat="server"><i class="fas fa-times"></i>&nbsp;Reject</asp:LinkButton>

                                            </span>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.min.js" integrity="sha512-TToQDr91fBeG4RE5RjMl/tqNAo35hSRR4cbIFasiV2AAMQ6yKXXYhdSdEpUcRE6bqsTiB+FPLPls4ZAFMoK5WA==" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.css" integrity="sha512-uq8QcHBpT8VQcWfwrVcH/n/B6ELDwKAdX4S/I3rYSwYldLVTs7iII2p6ieGCM13QTPEKZvItaNKBin9/3cjPAg==" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.min.css.map" integrity="sha512-uq8QcHBpT8VQcWfwrVcH/n/B6ELDwKAdX4S/I3rYSwYldLVTs7iII2p6ieGCM13QTPEKZvItaNKBin9/3cjPAg==" crossorigin="anonymous" />

    <%--<script>
        $(document).ready(function () {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetStudent",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    value: item
                                };
                            }));
                        },
                        error: function (result) {
                            Swal.fire({
                                position: 'center',
                                icon: 'warning',
                                title: 'Teacher not found',
                                showConfirmButton: true,
                                timer: 6000
                            });
                        }
                    });
                },
                minLength: 1,
            });
        });
        function pageLoad() {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetStudent",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    value: item
                                };
                            }));
                        },
                        error: function (result) {
                            Swal.fire({
                                position: 'center',
                                icon: 'warning',
                                title: 'Teacher not found',
                                showConfirmButton: true,
                                timer: 6000
                            });
                        }
                    });
                },
                minLength: 1,
            });
        };
    </script>--%>
</asp:Content>
