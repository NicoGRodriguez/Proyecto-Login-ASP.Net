using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;


namespace LoginNR
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologeado"] != null && Session["TipoAdm"] != null)
            {
                bool TipoAdm = bool.Parse(Session["TipoAdm"].ToString());
                string usuariologeado = Session["usuariologeado"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + usuariologeado;

                if (TipoAdm)
                {
                    MenuListaDeUsu.Visible = true;
                    MenuRegistrar.Visible = true;
                }
                else
                {
                    MenuListaDeUsu.Visible = false;
                    MenuRegistrar.Visible = false;
                }
            }
            else
            {
                Response.Redirect("LoginNR.aspx");
            }

        }

    }
}