<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Ventanas.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-1"></div>
            <div class="col-5">

                <div class="mb-3">
                    <label for="tbxCodigo" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="tbxCodigo" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="tbxNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="tbxNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="tbxDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox runat="server" ID="tbxDescripcion" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            <div class="col-5">
                <div class="mb-3">
                    <label for="formFile" class="form-label">Default file input example</label>
                    <input class="form-control" type="file" id="formFile" runat="server">
                </div>
                <div class="mb-3">
                    <asp:Image runat="server" ID="imgArticulo" />
                </div>
                <div class="mb-3">
                    <label for="tbxPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="tbxPrecio" CssClass="form-control" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
