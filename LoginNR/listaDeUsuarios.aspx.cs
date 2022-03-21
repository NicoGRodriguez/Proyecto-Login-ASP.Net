using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DLL;
using Entidades;


namespace LoginNR
{
    public partial class listaDeUsuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvListaDeUsu(usuarioBLL.ListaUsuario());
            }

            txtContra.Attributes["type"] = "password";

        }
        private void gvListaDeUsu(List<Usuario> usuarios)
        {
            gvListaDeUsuarios.DataSource = usuarios;
            gvListaDeUsuarios.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar();
            txtId.Enabled = false;
            btnBuscar.Enabled = false;
            btnEditar.Enabled = false;
            HabilitarInputs(false);

        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtId.Enabled = true;
            btnBuscar.Enabled = true;
            Desabilitar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            if (usuarioBLL.EliminarUsuario(int.Parse(txtId.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Alerta('El usuario se ha eliminado');", true);
                gvListaDeUsu(usuarioBLL.ListaUsuario());
                LimpiarCampos();
                txtId.Enabled = true;
                btnBuscar.Enabled = true;
                Desabilitar();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Alerta('El usuario no se ha eliminado');", true);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Usuario u = usuarioBLL.TraerUsuario(int.Parse(txtId.Text));

            if (u != null)
            {
                txtId.Text = Convert.ToString(u.Id);
                ValidarDatos();
                txtUsuario.Text = u.Usuarios;
                txtContra.Text = Encrypt.DesencriptarPassword(u.Contraseña, "Pass");
                if (u.TipoAdm == true)
                {
                    cbAdm.Checked = true;
                }
                else
                {
                    cbAdm.Checked = false;
                }
                txtId.Enabled = false;
                btnBuscar.Enabled = false;
                btnEditar.Enabled = true;
                btnLimpiar.Enabled = true;
                btnEliminarModal.Enabled = true;

            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario();
                usu.Id = Convert.ToInt32(txtId.Text);
                usu.Usuarios = txtUsuario.Text;
                usu.Contraseña = Encrypt.EncriptarPassword(txtContra.Text, "Pass");
                if (cbAdm.Checked)
                {
                    usu.TipoAdm = true;
                }
                else
                {
                    usu.TipoAdm = false;
                }
                if (DLL.usuarioBLL.EditarUsuario(usu))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Alerta('Editado con Exito');", true);
                    gvListaDeUsu(usuarioBLL.ListaUsuario());
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Alerta('No se a Editado');", true);
                }

                LimpiarCampos();
                txtId.Enabled = true;
                btnBuscar.Enabled = true;
                Desabilitar();


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtId.Enabled = true;
            btnBuscar.Enabled = true;
            Desabilitar();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Limpiar();", true);
        }
        public void Desabilitar()
        {
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminarModal.Enabled = false;
            btnGuardar.Enabled = false;
            btnLimpiar.Enabled = false;
            cbAdm.Enabled = false;
        }

        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtUsuario.Text = "";
            txtContra.Text = "";
        }
        public void Habilitar()
        {
            btnEditar.Enabled = true;
            btnGuardar.Enabled = true;
            btnEliminarModal.Enabled = true;
            btnLimpiar.Enabled = true;
        }
        public void HabilitarInputs(bool x)
        {
            txtUsuario.Enabled = !x;
            txtContra.Enabled = !x;
            cbAdm.Enabled = !x;
        }
        public bool ValidarDatos()
        {
            if (txtId.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Id();", true);
                return false;
            }
            if (txtUsuario.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Usuario();", true);
                return false;
            }
            if (txtContra.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Contra();", true);
                return false;
            }
            return true;
        }
    }
}