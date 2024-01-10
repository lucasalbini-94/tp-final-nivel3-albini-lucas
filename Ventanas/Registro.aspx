<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Ventanas.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Tienda online | Registrarse</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <div class="mb-5 mt-5">
                    <h2 class="text-center">Registrarse</h2>
                </div>
                <div class="mb-3">
                    <label for="tbxEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator ErrorMessage="El correo electrónico es requerido" ControlToValidate="tbxEmail" runat="server" 
                        CssClas="text-danger"/>
                    <asp:RegularExpressionValidator ErrorMessage="Formato de correo electrónico incorrecto"
                        ControlToValidate="tbxEmail" runat="server" CssClass="text-danger"
                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
                </div>
                <div class="mb-3">
                    <label for="tbxPass" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" ID="tbxPass" CssClass="form-control" TextMode="Password" />
                    <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida" ControlToValidate="tbxPass" runat="server"
                        CssClass="text-danger"/>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Registrarse" runat="server" ID="btnRegistrarse" CssClass="mt-4 btn btn-outline-success form-control" 
                        OnClick="btnRegistrarse_Click"/>
                </div>
                <div class="mb-3 text-center">
                    <label id="lblRegistrarse" class="form-label">¿Ya tienes una cuenta? ¡Ingresa <a href="Login.aspx" class="form-label">aquí!</a></label>
                </div>
            </div>
            <div class="col-4"></div>
        </div>
    </form>
</body>
</html>
