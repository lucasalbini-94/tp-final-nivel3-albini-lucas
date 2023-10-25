<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DescripcionArticulo.aspx.cs" Inherits="Ventanas.DescripcionArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1"></div>
        <div class="col-3">
            <div class="mb-3">
                <h2 class="mt-3"><%: seleccionado.Nombre %></h2>
            </div>
            <div class="mb-3">
                <h4><%: seleccionado.Marca %></h4>
            </div>
            <div class="mb-3">
                <h4><%: seleccionado.Categoria %></h4>
            </div>
            <hr />
            <div class="mb-3">
                <h3>Más detalles</h3>
            </div>
            <div class="mb-3">
                <h5>Código</h5>
                <p><%: seleccionado.Codigo %></p>
            </div>
            <div class="mb-3">
                <h5>Descripción</h5>
                <p><%: seleccionado.Descripcion %></p>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <img class="img-fluid mt-3" src="<%: seleccionado.ImagenUrl %>" alt="Imagen de artículo" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <h5 class="mt-3">Precio</h5>
                <h3>$<%: seleccionado.Precio.ToString("0.00") %></h3>
            </div>
            <div class="mb-3">
                <asp:Button Text="Comprar" ID="btnComprar" CssClass="btn btn-success form-control" OnClick="btnComprar_Click" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Carrito" ID="btnCarrito" CssClass="btn btn-secondary form-control" OnClick="btnCarrito_Click" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
