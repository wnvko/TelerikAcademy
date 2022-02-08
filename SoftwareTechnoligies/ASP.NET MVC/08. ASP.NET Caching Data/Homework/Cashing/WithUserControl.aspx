<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WithUserControl.aspx.cs" Inherits="Cashing.WithUserControl" %>

<%@ Register Src="~/CashedUserControl.ascx" TagPrefix="uc" TagName="CashedUserControl" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2><%= Page.Title %></h2>
            <div class="row">
                <div class="col-md-6">
                    <h3>Not Cashed</h3>
                    <p>Not cashed time <%= DateTime.Now.ToString() %></p>
                </div>
            </div>
            <uc:CashedUserControl runat="server" />
        </div>
    </div>
</asp:Content>
