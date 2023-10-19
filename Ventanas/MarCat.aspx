<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MarCat.aspx.cs" Inherits="Ventanas.AdminMarCat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1"></div>
        <div class="col-4">
            <div class="mb-3 mt-3">
                <h2 class="h2">Lista de categorías</h2>
            </div>
            <div class="mb-3">
                <asp:GridView runat="server" AutoGenerateColumns="false" ID="dgvCategorias" DataKeyNames="Id"
                    CssClass="table" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Categoría" DataField="Descripcion" HeaderStyle-CssClass="table-dark" />
                        <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Editar" HeaderStyle-CssClass="table-dark"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-4">
            <div class="mb-3 mt-3">
                <h2 class="h2">Lista de marcas</h2>
            </div>
            <div class="mb-3">
                <asp:GridView runat="server" AutoGenerateColumns="false" ID="dgvMarcas" DataKeyNames="Id"
                    CssClass="table" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Marca" DataField="Descripcion" HeaderStyle-CssClass="table-dark" />
                        <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Editar" HeaderStyle-CssClass="table-dark"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="col-1"></div>
    </div>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-4">
            <div class="mb-3">
                <label for="tbxNuevaCategoria" class="form-label">Nueva categoría</label>
                <asp:TextBox runat="server" ID="tbxNuevaCategoria" CssClass="form-control" />
                <asp:Button Text="Agregar" runat="server" ID="btnNuevaCategoria" CssClass="btn btn-success mt-2" OnClick="btnNuevaCategoria_Click" />
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-4">
            <div>
                <label for="tbxNuevaMarca" class="form-label">Nueva marca</label>
                <asp:TextBox runat="server" ID="tbxNuevaMarca" CssClass="form-control"/>
                <asp:Button Text="Agregar" runat="server" ID="btnNuevaMarca" CssClass="btn btn-success mt-2" OnClick="btnNuevaMarca_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
