<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SearchSupervisor.aspx.cs" Inherits="ThesisManagementWebApp.Web.SearchSupervisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Supervisor List</h1>
                </div>
            </div>
        </div>
        <div class="card card-body m-3">
            <div class="row">
                <div class="col-lg-3">
                    <asp:DropDownList ID="ddlType" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" runat="server">
                        <asp:ListItem>Project</asp:ListItem>
                        <asp:ListItem>Thesis</asp:ListItem>
                        <asp:ListItem>Both</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="col-lg-3">
                    <asp:DropDownList ID="ddlInterest" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlInterest_OnSelectedIndexChanged" runat="server">
                        </asp:DropDownList>
                </div>
                <div class="col-lg-5 justify-content-center">
                    <asp:TextBox runat="server" AutoPostBack="True" OnTextChanged="txtSearch_OnTextChanged" autocomplete="off" ID="txtSearch" placeholder="Search by Teacher's name, mobile no, email" class="form-control w-100"></asp:TextBox>
                </div>
                <div class="col-lg-1"></div>
            </div>
            <div class="row pt-3">
                <div class="col-lg-12  justify-content-center table-responsive">
                    <asp:GridView ID="gridTeacher" Width="100%" class="table table-hover table-bordered table-striped" OnRowDataBound="gridTeacher_OnRowDataBound" OnPageIndexChanging="gridTeacher_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Supervisor Found" AllowPaging="True" PageSize="30" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-lg-3 text-center">
                                            <asp:Image runat="server" Style="width: 125px; height: 125px" ImageUrl='<%#Image(Eval("Picture").ToString())%>'></asp:Image>
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("RegistrationId")%>' />
                                            <asp:Label ID="Label1" runat="server" Style="font-size: 25px; font-weight: bold;" Text='<%#Eval("Name")%>'></asp:Label>
                                            <span class="d-block"><i class="fas fa-balance-scale"></i>&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="far fa-envelope"></i>&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-phone-alt"></i>&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                            </span>
                                            <span class="d-block"><i class="fas fa-building"></i>&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                                            </span>

                                            <span class="d-block" title="Free Schedule"><i class="far fa-clock"></i>&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" Text='<%#TimeC(Eval("FreeScheduleFrom").ToString())+ " - "+TimeC(Eval("FreeScheduleTo").ToString())%>'></asp:Label>
                                            </span>
                                            <span class="d-block">
                                                <asp:LinkButton ID="lnkReq" class="btn btn-primary mt-1" OnClick="lnkReq_OnClick" runat="server">Request for supervision</asp:LinkButton>
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

    <script>
        $(document).ready(function() {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetTeacher",
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
                        url: "/WebService.asmx/GetTeacher",
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
    </script>
</asp:Content>
