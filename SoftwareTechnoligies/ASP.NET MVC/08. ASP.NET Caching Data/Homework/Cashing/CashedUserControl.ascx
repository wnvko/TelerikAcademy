<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CashedUserControl.ascx.cs" Inherits="Cashing.CashedUserControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>
<div class="row">
    <div class="col-md-6">
        <h3>Cashed Control</h3>
        <p>Cashed time <%= DateTime.Now.ToString() %></p>
    </div>
</div>