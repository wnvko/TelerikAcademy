<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cashing._Default" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h2><%= Page.Title %></h2>
        <h3>Time: <%= DateTime.Now %></h3>
    </div>
</asp:Content>
