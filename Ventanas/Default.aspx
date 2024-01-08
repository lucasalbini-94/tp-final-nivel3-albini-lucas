<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Default" EnableEventValidation="false" %>


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
                <asp:TextBox runat="server" CssClass="form-control me-2" ID="tbxBuscar" />
                <asp:Button Text="Buscar" CssClass="btn btn-outline-success" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-4">
            <div class="form-check mt-4">
                <asp:CheckBox Text="Filtro avanzado" CssClass="form-check" AutoPostBack="true" runat="server" ID="cbxFiltroAvanzado" OnCheckedChanged="filtroAvanzado_SelectedIndexChange" />
            </div>
        </div>
    </div>

    <%--    Verificar si el filtro avanzado está activado--%>
    <% if (cbxFiltroAvanzado.Checked)
        { %>
    <div class="row mt-4">
        <div class="col-1"></div>
        <div class="col-3">
            <div class="mb-4">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="filtroAvanzado_SelectedIndexChange"></asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="filtroAvanzado_SelectedIndexChange"></asp:DropDownList>
            </div>
        </div>
    </div>
    <% } %>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-10 row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card mb-3">
                            <img src='<%# cargarImagen(Eval("ImagenUrl").ToString()) %>' alt="Imágen de artículo" class="card-img-top"/>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <h4 class="card-subtitle"><%#((decimal)Eval("Precio")).ToString("0.00") %></h4>
                                <div class="mt-3">
                                    <a href="DescripcionArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-outline-primary">Ver</a>
                                    <% if (Session["user"] != null)
                                       { %>
                                    <asp:Button Text="Favoritos" runat="server" CssClass="btn btn-outline-primary" ID="btnFavoritos"
                                        CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnFavoritos_Click"/>
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
