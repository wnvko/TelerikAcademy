<%@ Page Title="Details With Form View" Language="C#" MasterPageFile="~/GlobalMaster.Master" AutoEventWireup="true" CodeBehind="EmpDetailsWithFormView.aspx.cs" Inherits="Employees.EmpDetailsWithFormView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <asp:FormView ID="fvDetails" runat="server" ItemType="Model.Customer">
                <ItemTemplate>
                    <h3>Detailed information about <%# Item.ContactName %></h3>
                    <table class="table table-bordered">
                        <tr>
                            <td>Company Name</td>
                            <td><%# Item.CompanyName %></td>
                        </tr>
                        <tr>
                            <td>Contact Title</td>
                            <td><%# Item.ContactTitle %></td>
                        </tr>
                        <tr>
                            <td>Company Name</td>
                            <td><%# Item.CompanyName %></td>
                        </tr>
                        <tr>
                            <td>Country</td>
                            <td><%# Item.Country %></td>
                        </tr>
                        <tr>
                            <td>Region</td>
                            <td><%# Item.Region %></td>
                        </tr>
                        <tr>
                            <td>City</td>
                            <td><%# Item.City %></td>
                        </tr>
                        <tr>
                            <td>Address</td>
                            <td><%# Item.Address %></td>
                        </tr>
                        <tr>
                            <td>Postal Code</td>
                            <td><%# Item.PostalCode %></td>
                        </tr>
                        <tr>
                            <td>Phone</td>
                            <td><%# Item.Phone %></td>
                        </tr>
                        <tr>
                            <td>Fax</td>
                            <td><%# Item.Fax %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
    <div class="row">
        <a href="/ListViewCustomers.aspx" class="btn btn-primary col-md-4">Back</a>
    </div>
</asp:Content>
