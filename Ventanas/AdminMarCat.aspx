<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminMarCat.aspx.cs" Inherits="Ventanas.AdminMarCat1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <div class="mb-3 mt-3">
                <label for="tbxDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="tbxDescripcion" CssClass="form-control" />
                <div class="mt-3">
                    <asp:Button Text="Modificar" ID="btnModificar" runat="server" CssClass="btn btn-secondary" OnClick="btnModificar_Click"/>
                    <asp:LinkButton Text="Eliminar" runat="server" ID="lbtEliminar" OnClientClick="return confirm('¿Seguro que deseas eliminar este archivo?');" CssClass="btn btn-danger" OnClick="lbtEliminar_Click" />
                </div>
            </div>
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
