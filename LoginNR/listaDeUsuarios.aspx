<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="listaDeUsuarios.aspx.cs" Inherits="LoginNR.listaDeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-auto">
        <!-- Inicio de Grid View-->
        <asp:GridView ID="gvListaDeUsuarios" runat="server" Width="518px" AutoGenerateColumns="False" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Usuarios" HeaderText="Usuarios" />
                <asp:BoundField DataFormatString="******" DataField="Contraseña" HeaderText="Contraseña" />
                <asp:BoundField DataField="TipoAdm" HeaderText="TipoAdm" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#05F45F" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
        <br />
        <header headertext="Var" visible="false" controlstyle-width="20px">
            <itemtemplate>
                <!-- Label y txtBox-->
                <div class="row">
                    <div class="col-1">
                        <asp:Label runat="server" Text="Id:"></asp:Label>
                    </div>
                    <div class="col-3">
                        <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:Button runat="server" type="button" class="btn btn-primary" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click"></asp:Button>
                    </div>
                </div>
                <br />
                <div class="row" typeof="*">
                    <div class="col-1">
                        <asp:Label runat="server" Text="Usuario:"></asp:Label>
                    </div>
                    <div class="col-3">
                        <asp:TextBox runat="server" ID="txtUsuario" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:Label runat="server" Text="Contraseña:"></asp:Label>
                    </div>
                    <div class="col-3">
                        <asp:TextBox ID="txtContra" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:Label ID="Label3" runat="server" Text="Admin:"></asp:Label>
                    </div>
                    <div class="col-1">
                        <asp:CheckBox ID="cbAdm" runat="server" Enabled="false" />
                    </div>
                </div>
                <!--Fin de los label y txtBox-->
                <br />
                <!--Botones-->
                <div class="row">
                    <div class="col-2">
                        <asp:Button runat="server" type="button" class="btn btn-warning" Text="Editar" ID="btnEditar" Enabled="false" OnClick="btnEditar_Click"></asp:Button>
                    </div>
                    <div class="col-2">
                        <asp:Button runat="server" type="button" class="btn btn-success" Text="Guardar" ID="btnGuardar" Enabled="false" OnClick="btnGuardar_Click"></asp:Button>
                    </div>
                    <div class="col-2">
                        <asp:Button runat="server" type="button" class="btn btn-primary" Text="Limpiar" ID="btnLimpiar" Enabled="false" OnClick="btnLimpiar_Click"></asp:Button>
                    </div>   
                    <!-- Boton con updatePanel, Conectado con modal-->
                    <div class="col-2">
                        <asp:ScriptManager runat="server" />
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button runat="server" type="button" class="btn btn-danger" ID="btnEliminarModal" Enabled="false" data-bs-toggle="modal" data-bs-target="#staticBackdrop" Text="Eliminar"></asp:Button>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Fin de Grid View-->
                <!-- Modal -->
                <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="staticBackdropLabel">Eliminar</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <p>Esta seguro que desea eliminar el usuario</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" type="button" class="btn btn-secondary" data-bs-dismiss="modal" Text="No" ID="btnNo" OnClick="btnNo_Click"></asp:Button>
                                <asp:Button runat="server" type="button" class="btn btn-primary" Text="Si" ID="btnEliminar" OnClick="btnEliminar_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Fin del Modal-->
            </itemtemplate>
        </header>
    </div>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
    <script>
        function Alerta(msj) {
            swal(msj);
        }
        </script>
    <script>
        $(function () {
            jQuery.validator.addMethod("lettersonly", function (value, element) {
                return this.optional(element) || /^[a-z]+$/i.test(value);
            }, "Solo letras");
            $("form[id='formulario']").validate({
                rules: {
                    txtId: {
                        required: true,
                        digits: true
                    },
                    txtUsuario: {
                        required: true
                    },
                    txtContra: {
                        required: true,
                        minlength: 5,
                        lettersonly: true
                    },
                },
                messages: {
                    txtId: "Ingrese un Id",
                    txtUsuario: "Ingrese un usuario",
                    txtContraseña: "Ingrese una contraseña valida",

                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });
        </script>
</asp:Content>
