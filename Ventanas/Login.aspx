<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ventanas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Tienda online | Iniciar sesión</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <div class="mb-5 mt-5">
                <h2 class="text-center">Iniciar sesión</h2>
                </div>
                <div class="mb-3">
                    <label for="tbxEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control" TextMode="Email" />
                </div>
                <div class="mb-3">
                    <label for="tbxPass" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" ID="tbxPass" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" CssClass="mt-4 btn btn-outline-primary form-control"
                        OnClick="btnIngresar_Click"/>
                </div>
                <div class="mb-3 text-center">
                    <label id="lblRecPass" class="form-label">¿Olvidaste tu contraseña? ¡Recupérala <a href="#" class="form-label">aquí!</a></label>
                </div>
                <div class="mb-3 text-center">
                    <label id="lblRegistrarse" class="form-label">¿No tienes una cuenta? <a href="Registro.aspx" class="form-label">¡Regístrate!</a></label>
                </div>
            </div>
            <div class="col-4"></div>
        </div>
    </form>
</body>
</html>
