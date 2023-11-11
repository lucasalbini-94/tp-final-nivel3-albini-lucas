<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Ventanas.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tienda online | Error</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <style>
        .img-fluid{
            max-width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-4">
                <div class="text-center">
                    <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/f0/Error.svg/1200px-Error.svg.png"
                        alt="Imágen de alerta" class="img-fluid mt-3"/>
                </div>
                <div class="mt-5 text-center mb-5">
                    <h2 class="h2">Ocurrió un error inesperado</h2>
                </div>
                <div class="mb-3 text-center">
                    <asp:Label CssClass="form-label" ID="lblError" runat="server" />
                </div>
                <div class="mb-3 text-center">
                    <asp:HyperLink CssClass="form-label" ID="hlkRedirect" runat="server" />
                </div>
            </div>
            <div class="col-4"></div>
        </div>
    </form>
</body>
</html>
