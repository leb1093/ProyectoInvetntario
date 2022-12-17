using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ApliciacionInventario.ProxyUsuario;
using ApliciacionInventario.Usuario;

namespace ApliciacionInventario
{
    public partial class WebLogin : System.Web.UI.Page
    {
        ProxyUsuario.ServiceUsuarioClient objUsuario = new ProxyUsuario.ServiceUsuarioClient();
        ProxyUsuario.UsuarioBE objUsuarioBE = new ProxyUsuario.UsuarioBE();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                // Usuario y password obligatorios
                if (txtUsuario.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar el usuario.");
                }

                if (txtPass.Text.Trim() == String.Empty)
                {
                    throw new Exception("Debe ingresar el password.");
                }


                // Validamos el usuario y contraseña

                // Obtenemos las credenciales de acuerdo al Login ingresado
                objUsuarioBE = objUsuario.ConsultarUsuario(txtUsuario.Text);

                if (txtUsuario.Text.Trim() == objUsuarioBE.login_usuario & txtPass.Text.Trim() == objUsuarioBE.pass_usuario)
                //txtUsuario.Text.Trim() == "ISIL" & txtPass.Text.Trim() == "12345"
                {
                    clsCredenciales.Usuario = objUsuarioBE.login_usuario;
                    clsCredenciales.Password = objUsuarioBE.pass_usuario;
                    clsCredenciales.Nivel = objUsuarioBE.niv_usuario;
                    Response.Redirect("MenuPrincipal.aspx");
                }
                else
                {
                    throw new Exception("Usuario o password errados.");
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}