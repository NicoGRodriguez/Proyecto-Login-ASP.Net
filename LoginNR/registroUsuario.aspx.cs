using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DLL;

namespace LoginNR
{
    public partial class registroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario();
                usu.Usuarios = txtUsuario.Text;
                usu.Contraseña = txtContraseña.Text;
                if (UsuarioAdm.Checked)
                {
                    usu.TipoAdm = true;
                }
                else
                {
                    usu.TipoAdm = false;
                }
                DLL.usuarioBLL.RegistrarUsuario(usu);
                LimpiarCampos();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Registrado();", true);
            }
            catch (Exception)
            {

                throw;
            }
               
        }
        public void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            UsuarioAdm.Checked = false;
            UsuarioNormal.Checked = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}