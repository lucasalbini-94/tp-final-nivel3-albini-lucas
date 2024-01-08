<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Ventanas.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1"></div>
        <div class="col-10">
            <h1 class="h1 mt-3 mb-3">Mi perfil</h1>
        </div>
        <div class="col-1"></div>
    </div>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-md-4">
            <div class="mb-3">
                <label for="tbxEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control" ReadOnly="true"/>
            </div>
            <div class="mb-3">
                <label for="tbxNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="tbxNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" ControlToValidate="tbxNombre" runat="server" CssClass="text-danger"/>
            </div>
            <div class="mb-3">
                <label for="tbxApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="tbxApellido" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido" ControlToValidate="tbxApellido" runat="server" CssClass="text-danger"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="tbxImagen" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Guardar cambios" runat="server" class="btn btn-primary" ID="btnModificar"
                    OnClick="btnModificar_Click" />
            </div>
        </div>
        <div class="col-md-4 mt-3">
            <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
</asp:Content>
