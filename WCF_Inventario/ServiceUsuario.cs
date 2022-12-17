using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//Agregar..
using System.Data.Entity.Core;

namespace WCF_Inventario
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código y en el archivo de configuración a la vez.
    public class ServiceUsuario : IServiceUsuario
    {
        public Boolean InsertarUsuario(UsuarioBE objUsuarioBE)
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Creamos unas instancias de Tb_Vendedor
                Tb_Usuario objUsuario = new Tb_Usuario();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objUsuario.login_usuario = objUsuarioBE.login_usuario;
                objUsuario.pass_usuario = objUsuarioBE.pass_usuario;
                objUsuario.niv_usuario = objUsuarioBE.niv_usuario;
                objUsuario.est_usuario = objUsuarioBE.est_usuario;
                objUsuario.usuario_registro = "admin";// objProveedorBE.usuario_Registro
                objUsuario.fec_registro = objUsuarioBE.Fec_Registro;



                //Agregamos la instancia de nuevo vendedor a su clase...
                MisActivos.Tb_Usuario.Add(objUsuario);

                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarUsuario(UsuarioBE objUsuarioBE)
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea actualizar
                Tb_Usuario objUsuario = (
                                from oUsuario in MisActivos.Tb_Usuario
                                where oUsuario.login_usuario == objUsuarioBE.login_usuario
                                select oUsuario
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objUsuario.login_usuario = objUsuarioBE.login_usuario;
                objUsuario.pass_usuario = objUsuarioBE.pass_usuario;
                objUsuario.niv_usuario = objUsuarioBE.niv_usuario;
                objUsuario.est_usuario = objUsuarioBE.est_usuario;
                objUsuario.usuario_registro = objUsuarioBE.usu_registro;
                objUsuario.fec_registro = objUsuarioBE.Fec_Registro;


                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarUsuario(String login_usuario)
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea eliminar
                Tb_Usuario objUsuario = (
                                from oUsuario in MisActivos.Tb_Usuario
                                where oUsuario.login_usuario == login_usuario
                                select oUsuario
                    ).FirstOrDefault();

                //Removemos el vendedor identificado y se refresca la BD..
                MisActivos.Tb_Usuario.Remove(objUsuario);
                MisActivos.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioBE ConsultarUsuario(String login_usuario)
        {
            
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            UsuarioBE objUsuarioBE = new UsuarioBE();
            try
            {
                //Creamos instancia del modelo...
                Tb_Usuario objUsuario = (
                                from oUsuario in MisActivos.Tb_Usuario
                                where oUsuario.login_usuario == login_usuario
                                select oUsuario
                    ).FirstOrDefault();

                objUsuarioBE.login_usuario = objUsuario.login_usuario;
                objUsuarioBE.pass_usuario = objUsuario.pass_usuario;
                objUsuarioBE.niv_usuario = Convert.ToInt16(objUsuario.niv_usuario);
                objUsuarioBE.est_usuario = Convert.ToInt16(objUsuario.est_usuario);
                objUsuarioBE.usu_registro = objUsuario.usuario_registro;
                objUsuarioBE.Fec_Registro = Convert.ToDateTime(objUsuario.fec_registro);

                return objUsuarioBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
