<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMaster.Master" AutoEventWireup="true" CodeBehind="RepeaterCustomers.aspx.cs" Inherits="Employees.RepeaterCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <asp:Repeater ID="repCustomers" runat="server" ItemType="Model.Customer">
                <HeaderTemplate>
                    <ul class="list-group">
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="list-group-item">
                        <span><%# Item.ContactName %> from <%# Item.CompanyName %> view
                            <a href="<%# GetUrl(Item.CustomerID) %>">details</a></span>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
