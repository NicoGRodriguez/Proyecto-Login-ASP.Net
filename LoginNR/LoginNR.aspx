<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNR.aspx.cs" Inherits="LoginNR.LoginNR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleLogin.css" rel="stylesheet" type="text/css" />
    <title>Login</title>
</head>
<body>
    <div class="container mt-5">
        <div class="col p-5 rounded-end">
            <form id="Formulario_Login" runat="server">
                <!--Inicio UpdatePanel-->
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-control">
                                <div class="fw-bold text-center py-5 text-dark">
                                    <asp:Label ID="lblBienvenida" Text="Bienvenido" CssClass="h2" runat="server" />
                                </div>
                                <div class="mb-4">
                                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                                    <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" placeholder="Ingresa tu usuario."></asp:TextBox>
                                </div>
                                <div class="mb-4">
                                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
                                    <asp:TextBox ID="txtContraseña" TextMode="Password" CssClass="form-control" runat="server" placeholder="Ingresa tu contraseña."></asp:TextBox>
                                </div>
                                <hr />
                                <div class="row">
                                    <asp:Label ID="lblError" CssClass="alert-danger" runat="server" Text=""></asp:Label>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Button ID="btnIngresar" CssClass="btn btn-dark" runat="server" Text="Ingresar" OnClick="Ingresar_Click" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <!-- Fin de Update Panel-->
            </form>
        </div>
    </div>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" type="text/x-jquery-tmpl"></script>
</body>
</html>
