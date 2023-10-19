<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminArticulos.aspx.cs" Inherits="Ventanas.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-3 row">
        <div class="col-1"></div>
        <div class="col-4">
            <div class="mb-3">
                <h2 class="h2">Administración de artículos</h2>
            </div>
        </div>
        <div class="col-3">
            <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Buscar por código" aria-label="Search" runat="server" />
            </div>
        </div>
        <div class="col-3">
            <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Buscar por artículo" aria-label="Search" runat="server" />
            </div>
        </div>
        <div class="col-1"></div>
    </div>
    <div class="mt-3 row">
        <div class="col-1"></div>
        <div class="col-10">
            <div class="mb-3">
                <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" CssClass="table table-bordered" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="Codigo" HeaderStyle-CssClass="table-dark"/>
                        <asp:BoundField HeaderText="Artículo" DataField="Nombre" HeaderStyle-CssClass="table-dark"/>
                        <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}" HeaderStyle-CssClass="table-dark"/>
                        <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Editar" HeaderStyle-CssClass="table-dark"/>
                    </Columns>
                </asp:GridView>
            </div>
            <a href="Articulo.aspx" class="btn btn-primary">Agregar</a>
            <a href="MarCat.aspx" class="btn btn-warning">Administrar marcas y categorías</a>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
