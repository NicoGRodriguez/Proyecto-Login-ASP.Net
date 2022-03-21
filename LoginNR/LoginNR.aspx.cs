using DLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace LoginNR
{
    public partial class LoginNR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TipoAdm"] = null;
            Session["usuariologueado"] = null;
        }
        private Usuario Iniciar(string Usuario, string Contraseña)
        {
            return usuarioBLL.Ingresar(Usuario,Contraseña);
            
            
        }
        protected void Ingresar_Click(object sender, EventArgs e)
        {
            Usuario resultado = Iniciar(txtUsuario.Text,txtContraseña.Text);
            if (resultado.Id != 0)
            {
                Session["TipoAdm"] = resultado.TipoAdm;
                Session["usuariologeado"] = txtUsuario.Text;
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                lblError.Text = "Datos mal ingresados!!";
            }
            //string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            //SqlConnection sqlConectar = new SqlConnection(conectar);
            //SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlConectar)
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Connection.Open();
            //cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = txtUsuario.Text;
            //cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = txtContraseña.Text;
            //cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    Session["usuariologeado"] = txtUsuario.Text;
            //    Response.Redirect("Index.aspx");
            //}
            //else
            //{
            //    lblError.Text = "Datos mal ingresados!!";
            //}
            //cmd.Connection.Close();
        }
}
}