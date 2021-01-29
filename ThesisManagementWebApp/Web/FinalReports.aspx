<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Dashboard.Master" AutoEventWireup="true" CodeBehind="FinalReports.aspx.cs" Inherits="ThesisManagementWebApp.Web.FinalReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1 class="m-0">Final Report List</h1>
                </div>
            </div>
        </div>
        <div class="card card-body m-3">
            <div class="row">
                <div class="col-4">
                    <asp:DropDownList ID="ddlType" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged" CssClass="form-control" runat="server">
                        <asp:ListItem>Project</asp:ListItem>
                        <asp:ListItem>Thesis</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-5 justify-content-center">
                    <asp:TextBox runat="server" AutoPostBack="True" OnTextChanged="txtSearch_OnTextChanged" autocomplete="off" ID="txtSearch" placeholder="Search by project/thesis title" class="form-control w-100"></asp:TextBox>
                </div>
            </div>
            <div class="col-3">
            </div>
            <div class="row pt-3">
                <div class="col-12  justify-content-center table-responsive">
                    <asp:GridView ID="gridReport" Width="100%" class="table table-hover table-bordered table-striped" OnPageIndexChanging="gridReport_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Report Found" AllowPaging="True" PageSize="30" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-9 text-left">
                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("FileName")%>'></asp:Label>
                                        </div>
                                        <div class="col-3">
                                            <a href='<%#Eval("Attachment") %>' title="Download" class="btn btn-primary w-100"><i class="fas fa-download"></i>&nbsp; Download</a>
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
        $(document).ready(function () {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/WebService.asmx/GetReport",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "','type':'" + $("#<%=ddlType.ClientID %>").val() + "'}",
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
                                title: 'Report not found',
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
                        url: "/WebService.asmx/GetReport",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "','type':'" + $("#<%=ddlType.ClientID %>").val() + "'}",
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
                                title: 'Report not found',
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
