using ApliciacionInventario.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApliciacionInventario
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {

                    lblUsuario.Text = clsCredenciales.Usuario;
                    if (clsCredenciales.Nivel == 1)
                    {
                        btnUsuarios.Visible = true;
                        lblUsuario2.Visible = true;
                        
                    }
                    else {
                        btnUsuarios.Visible = false;
                        lblUsuario2.Visible = false;
                    }

                }

            }
            catch (Exception ex)
            {
                ;
            }
        }

        protected void btnModelos_Click(object sender, EventArgs e)
        {           
             Response.Redirect("Modelos/ModeloLuces.aspx");
       
        }

        protected void btnHangar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hangar/MenuHangar.aspx");
        }

        protected void btnATO_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ato/MenuAto.aspx");
        }

        protected void btnPlazaLat_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlazaLatam/MenuPlazaLatam.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            clsCredenciales.Usuario = null;
            clsCredenciales.Password = null;
            clsCredenciales.Nivel = 0;
            Response.Redirect("WebLogout.aspx");
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void btnGraficas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Graficas.aspx");
        }
    }
}