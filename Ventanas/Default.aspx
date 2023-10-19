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
            <% foreach (Dominio.Articulo articulo in ListaArticulos)
                { %>
            <div class="col">
                <div class="card">

                 <% if (articulo.ImagenUrl.ToLower().Contains("http"))
                    { %>
                        <%--Cargo imagen desde la web--%>
                        <img src="<%: articulo.ImagenUrl %>" class="card-img-top" alt="Imagen desde la web">
                 <% }
                    else
                    { %>
                        <%--Cargo imagen desde la carpeta local--%>
                        <img src="/Images/ImagesArt/<%: articulo.ImagenUrl %>" class="card-img-top" alt="Imagen desde carpeta">
                 <% } %>
                    <div class="card-body">
                        <h5 class="card-title"><%: articulo.Nombre %></h5>
                        <p class="card-text"><%: articulo.Descripcion %></p>
                        <h4 class="card-subtitle"><%: articulo.Precio.ToString("0.00") %></h4>
                        <div class="mt-3">
                            <a href="DescripcionArticulo.aspx?id=<%: articulo.Id %>" class="btn btn-secondary">Ver</a>
                        </div>
                    </div>
                        
                </div>
            </div>
            <% } %>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
