<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="registroUsuario.aspx.cs" Inherits="LoginNR.registroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro de usuarios nuevos</h2>
    <div class="input-group mb-3">
        <asp:Label Text="Usuario" runat="server" CssClass="input-group-text" />
        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" />
    </div>
    <div class="input-group mb-3">
        <asp:Label Text="Contraseña" runat="server" CssClass="input-group-text" />
        <asp:TextBox runat="server" CssClass="form-control" ID="txtContraseña" type="Password"/>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="radio" name="flexRadioDefault" id="UsuarioNormal" runat="server">
        <asp:Label Text="Usuario Normal" runat="server" class="form-check-label" for="flexRadioDefault1" />
    </div>
    <div class="form-check">
        <input class="form-check-input" type="radio" name="flexRadioDefault" id="UsuarioAdm" runat="server">
        <asp:Label Text="Usuario Adm" runat="server" class="form-check-label" for="flexRadioDefault2" />
    </div>
    <br />
    <asp:Button runat="server" type="button" class="btn btn-secundary" Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click"></asp:Button>
    <asp:Button runat="server" type="button" class="btn btn-primary" Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click"></asp:Button>

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        <script>
            function Registrado() {
                swal("Usuario Registrado Correctamente!");
            }

        </script>
</asp:Content>
