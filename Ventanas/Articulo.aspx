<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="Ventanas.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-3">
        <div class="col-1"></div>
        <div class="col-md-3">
            <div class="mb-3">
                <label for="tbxCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="tbxCodigo" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El código es requerido" ControlToValidate="tbxCodigo" runat="server"
                    CssClass="text-danger"/>
            </div>
            <div class="mb-3">
                <label for="tbxNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="tbxNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" ControlToValidate="tbxNombre" runat="server"
                    CssClass="text-danger"/>
            </div>
            <div class="mb-3">
                <label for="tbxDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="tbxDescripcion" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="La descripción es requerida" ControlToValidate="tbxDescripcion" runat="server" 
                    CssClass="text-danger"/>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="tbxPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="tbxPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El precio es requerido" ControlToValidate="tbxPrecio" runat="server"
                    CssClass="text-danger"/>
                <asp:RegularExpressionValidator ErrorMessage="Solo números con dos decimales" ControlToValidate="tbxPrecio" runat="server" 
                    CssClass="text-danger" ValidationExpression="^\d+(\.\d{1,2})?$"/>
            </div>
        </div>
        <div class="col-md-3">
            <div class="mb-3">
                <label for="formFile" class="form-label">Agregar imagen local</label>
                <input class="form-control" type="file" id="tbxImagen" runat="server">
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Agregar imagen por URL</label>
                <asp:TextBox runat="server" ID="tbxImagenUrl" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Image runat="server" ID="imgArticulo" CssClass="img-fluid mb-3" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-secondary" OnClick="btnAgregar_Click" />
                <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="btn btn-secondary" OnClick="btnModificar_Click" />
                <asp:LinkButton Text="Eliminar" runat="server" ID="lbtEliminar" OnClientClick="return confirm('¿Seguro que deseas eliminar este archivo?');" CssClass="btn btn-danger" OnClick="lbtEliminar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
