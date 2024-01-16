<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminArticulos.aspx.cs" Inherits="Ventanas.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="mt-3 row">
                <div class="col-1"></div>
                <div class="col-4">
                    <div class="mb-3">
                        <h2 class="h2">Administración de artículos</h2>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:TextBox runat="server" CssClass="form-control me-2" ID="tbxCodigo" placeholder="Buscar por código"
                            OnTextChanged="tbxCodigo_TextChanged" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="d-flex" role="search">
                        <asp:TextBox runat="server" CssClass="form-control me-2" ID="tbxArticulo" placeholder="Buscar por artículo"
                            OnTextChanged="tbxArticulo_TextChanged" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-1"></div>
            </div>
            <div class="mt-3 row">
                <div class="col-1"></div>
                <div class="col-10">
                    <div class="mb-3">
                        <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" CssClass="table table-bordered" AutoGenerateColumns="false"
                            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="Codigo" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField HeaderText="Artículo" DataField="Nombre" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}" HeaderStyle-CssClass="table-dark" />
                                <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Editar" HeaderStyle-CssClass="table-dark" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-1"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-5">
            <div class="mb-3">
                <a href="Articulo.aspx" class="btn btn-primary">Agregar</a>
                <a href="MarCat.aspx" class="btn btn-warning">Administrar marcas y categorías</a>
            </div>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
