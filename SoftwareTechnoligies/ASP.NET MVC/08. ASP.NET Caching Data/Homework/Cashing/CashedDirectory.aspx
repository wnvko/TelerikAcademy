<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CashedDirectory.aspx.cs" Inherits="Cashing.CashedDirectory" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Directory: <span id="directorySpan" runat="server"></span></h3>
    <h2>Files</h2>
    <ul>
        <asp:Repeater ID="filesRepeater" runat="server" SelectMethod="filesRepeater_GetData" ItemType="System.string">
            <ItemTemplate>
                <li><%# Item %></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
