<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Default" EnableEventValidation="true"%>


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
        <div class="col-6">
            <div class="d-flex mt-3" role="search">
                <input class="form-control me-2" type="search" placeholder="Buscar artículos" aria-label="Search">
                <button class="btn btn-outline-success" type="submit" id="btnBuscar">Buscar</button>
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-4">
            <div class="form-check mt-4">
                <asp:CheckBox Text="Filtro avanzado" CssClass="form-check" AutoPostBack="true" runat="server" ID="cbxFiltroAvanzado" />
            </div>
        </div>
    </div>
    <% if (cbxFiltroAvanzado.Checked)
        { %>
    <div class="row mt-4">
        <div class="col-1"></div>
        <div class="col-3">
            <div class="mb-4">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>
    </div>
    <% } %>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-10 row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <h4 class="card-subtitle"><%#Eval("Precio") %></h4>
                                <div class="mt-3">
                                    <asp:Button Text="Ver" ID="btnVer" CssClass="btn btn-secondary" CommandArgument='<%#Eval("Id") %>' PostBackUrl='<%# "DescripcionArticulo.aspx?id=" + Eval("Id") %>' runat="server" />
                                    <% if (Session["sesionActiva"] != null)
                                        { %>
                                    <asp:Button runat="server" Text="Agregar al carrito" ID="btnAgregarCarrito" CommandArgument='<%#Eval("Id") %>' onClick="btnAgregarCarrito_Click" CssClass="btn btn-success"/>
                                    <% } %>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
