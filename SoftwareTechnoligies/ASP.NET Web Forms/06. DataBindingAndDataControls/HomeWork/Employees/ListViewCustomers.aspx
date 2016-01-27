<%@ Page Title="With ListView" Language="C#" MasterPageFile="~/GlobalMaster.Master" AutoEventWireup="true" CodeBehind="ListViewCustomers.aspx.cs" Inherits="Employees.ListViewCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lvCustomers" runat="server"
        ItemType="Model.Customer">
        <LayoutTemplate>
            <div class="row">
                <div class="col-md-6 text-center">
                    <h3>Customers</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <ul class="list-group">
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </ul>
                </div>
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <li class="list-group-item">
                        <span><%# Item.ContactName %> from <%# Item.CompanyName %> view
                            <a href="<%# GetUrl(Item.CustomerID) %>">details</a>
                        </span>
                    </li>

                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div class="row text-center">
        <div class="col-md-6">
            <asp:DataPager ID="dpCustomers" runat="server" PagedControlID="lvCustomers" PageSize="8" QueryStringField="Page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="btn btn-primary" />
                    <asp:NumericPagerField NumericButtonCssClass="btn btn-primary" />
                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" ButtonCssClass="btn btn-primary" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
