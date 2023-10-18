<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Ventanas.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <h1 class="h1 align-content-center">Ocurrió un error inesperado</h1>
            <div class="mt-4">
                <asp:Label ID="lblErrorText" runat="server" />
            </div>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
