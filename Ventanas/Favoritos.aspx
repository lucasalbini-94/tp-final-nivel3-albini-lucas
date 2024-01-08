<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Ventanas.Favoritos" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            height: 200px;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1"></div>
        <div class="col-10">
            <div class="h1">Lista de favoritos</div>
            <% if (!listaVacia)
                { %>
            <asp:Repeater ID="repFavoritos" runat="server">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="card-body row">
                            <div class="col-3">
                                <img src='<%#Eval("ImagenUrl") %>' alt="Imagen de artículo" class="card-img-top"/>
                            </div>
                            <div class="col-6">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <a href="Default.aspx" class="btn btn-primary">Agregar a carrito</a>
                                <asp:Button Text="Quitar de favoritos" CssClass="btn btn-primary" ID="btnQuitarFavoritos" runat="server"
                                    CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnQuitarFavoritos_Click"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <% }
               else
               { %>
            <asp:Label ID="lblMensaje" CssClass="h3 mb-3 mt-3" runat="server" />
            <% } %>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
