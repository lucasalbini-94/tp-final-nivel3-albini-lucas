<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminArticulos.aspx.cs" Inherits="Ventanas.ListaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-3 row">
        <div class="col-1"></div>
        <div class="col-10">
            <h2 class="h2">Administración de artículos</h2>
            <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}"/>
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción"/>
                </Columns>
            </asp:GridView>
            <a href="Articulo.aspx" class="btn btn-primary">Agregar</a>
        </div>
    </div>
</asp:Content>
