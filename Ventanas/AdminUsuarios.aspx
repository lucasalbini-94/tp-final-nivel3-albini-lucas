<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="Ventanas.AdminUsuarios" %>

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
                        <h2 class="h2">Administación de Usuarios</h2>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:TextBox runat="server" CssClass="form-control me-2" PlaceHolder="Buscar email" ID="tbxFiltroEmail"
                            OnTextChanged="tbxFiltroEmail_TextChanged" AutoPostBack="true"/>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3 mt-3">
                        <p>Cantidad de usuarios = <%: CantUsuarios %></p>
                    </div>
                </div>
                <div class="col-1"></div>
            </div>
            <div class="row mt-3">
                <div class="col-1"></div>
                <div class="col-10">
                    <div class="mb-3">
                        <asp:GridView runat="server" ID="dgvUsuarios" DataKeyNames="Id" CssClass="table table-bordered" AutoGenerateColumns="false"
                            OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:BoundField HeaderText="Email" DataField="Email" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField HeaderText="Apellido" DataField="Apellido" HeaderStyle-CssClass="table-dark" />
                                <asp:CheckBoxField HeaderText="Administrador" DataField="Admin" HeaderStyle-CssClass="table-dark" />
                                <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="📝" HeaderStyle-CssClass="table-dark" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-1"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <% if (SeccionUsuario)
        { %>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-4">
            <div class="mb-3 mt-3">
                <label for="tbxEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control" Enabled="false" />
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3 mt-3">
                <asp:LinkButton runat="server" ID="lbtAdmin" CssClass="btn btn-primary"
                    OnClientClick="return confirm('¿Seguro que desea modificar el permiso de administración de este usuario?');"
                    OnClick="lbtAdmin_Click" />
            </div>
            <div class="mb-3">
                <asp:LinkButton runat="server" ID="lbtEliminar" CssClass="btn btn-danger" Text="Eliminar"
                    OnClientClick="return confirm('¿Seguro que desea eliminar a este usuario?');" OnClick="lbtEliminar_Click" />
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
