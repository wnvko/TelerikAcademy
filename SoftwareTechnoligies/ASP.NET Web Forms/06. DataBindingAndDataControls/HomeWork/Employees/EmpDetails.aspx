<%@ Page Title="Details" Language="C#" MasterPageFile="~/GlobalMaster.Master" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="Employees.EmpDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" row">
        <div class=" col-md-6">
            <asp:DetailsView
                CssClass="table table-striped table-hover"
                ID="dvDetails" runat="server"
                AutoGenerateRows="true">
            </asp:DetailsView>
        </div>
    </div>
    <div class="row">
        <a href="/GridViewCustomers.aspx" class="btn btn-primary col-md-6">Back</a>
    </div>
</asp:Content>
