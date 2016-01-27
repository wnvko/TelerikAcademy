<%@ Page Title="With GridView" Language="C#" MasterPageFile="~/GlobalMaster.Master" AutoEventWireup="true" CodeBehind="GridViewCustomers.aspx.cs" Inherits="Employees.GridViewCustomers1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class=" col-md-6">
            <asp:GridView CssClass="table table-striped table-hover"
                ID="gvCustomers" runat="server"
                AllowPaging="true"
                DataKeyNames="CustomerID"
                AutoGenerateColumns="false"
                UseAccessibleHeader="true">
                <Columns>
                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                    <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="CustomerID" DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
