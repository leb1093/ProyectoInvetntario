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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceModelo" en el código y en el archivo de configuración a la vez.
    public class ServiceModelo : IServiceModelo
    {

        public ModeloBE ConsultarModelo(Int16 id) {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            ModeloBE objModeloBE = new ModeloBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarModelo(id)).FirstOrDefault();

                objModeloBE.id = Convert.ToInt16(resultado.id);
                objModeloBE.marca = resultado.marca;
                objModeloBE.modelo = resultado.modelo;
                objModeloBE.tipo = resultado.tipo;
                objModeloBE.usu_registro = resultado.usuario_registro;
                objModeloBE.Fec_Registro = Convert.ToDateTime(resultado.fecha_registro);
                objModeloBE.usu_ult_modificacion = resultado.usu_ult_modificacion;
                objModeloBE.fec_ult_modificacion = Convert.ToDateTime(resultado.fecha_ult_modificacion);
                //Terminado el bucle devolvmemos la lista
                return objModeloBE;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<ModeloBE> ListarModelos() {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<ModeloBE> objListaModelo = new List<ModeloBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarModelo();

                foreach (var objModelo in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    ModeloBE objModeloBE = new ModeloBE();

                    objModeloBE.id = Convert.ToInt16(objModelo.id);
                    objModeloBE.marca = objModelo.marca;
                    objModeloBE.modelo = objModelo.modelo;
                    objModeloBE.tipo = objModelo.tipo;
                    objModeloBE.usu_registro = objModelo.usuario_registro;
                    objModeloBE.Fec_Registro = Convert.ToDateTime(objModelo.fecha_registro);
                    objModeloBE.usu_ult_modificacion = objModelo.usu_ult_modificacion;
                    objModeloBE.fec_ult_modificacion = Convert.ToDateTime(objModelo.fecha_ult_modificacion);

                    //Agregar la instancia de datacontractual a la lista..
                    objListaModelo.Add(objModeloBE);
                }

                //Se retorna la lsita...
                return objListaModelo;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModeloBE> ListarModelos2()
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<ModeloBE> objListaModelo = new List<ModeloBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarModelo2();

                foreach (var objModelo in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    ModeloBE objModeloBE = new ModeloBE();

                    objModeloBE.id = Convert.ToInt16(objModelo.id);
                    objModeloBE.nom_equipo = objModelo.nom_equipo;

                    //Agregar la instancia de datacontractual a la lista..
                    objListaModelo.Add(objModeloBE);
                }

                //Se retorna la lsita...
                return objListaModelo;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Boolean InsertarModelo(ModeloBE objModeloBE) {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {

                Tb_modelosLucesE objModelo = new Tb_modelosLucesE();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                //objProducto.cod_prod = int.Empty;
                objModelo.marca = objModeloBE.marca;
                objModelo.modelo = objModeloBE.modelo;
                objModelo.tipo = objModeloBE.tipo;
                objModelo.usuario_registro = objModeloBE.usu_registro;



                //Agregamos la instancia de nuevo vendedor a su clase...
                MisActivos.Tb_modelosLucesE.Add(objModelo);

                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarModelo(ModeloBE objModeloBE) {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea actualizar
                Tb_modelosLucesE objModelo = (
                                from oModelo in MisActivos.Tb_modelosLucesE
                                where oModelo.id == objModeloBE.id
                                select oModelo
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objModelo.id = objModeloBE.id;
                objModelo.marca = objModeloBE.marca;
                objModelo.modelo = objModeloBE.modelo;
                objModelo.tipo = objModeloBE.tipo;
                objModelo.usu_ult_modificacion = objModeloBE.usu_ult_modificacion;


                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarModelo(Int16 id) {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea eliminar
                Tb_modelosLucesE objModelo = (
                                from oModelo in MisActivos.Tb_modelosLucesE
                                where oModelo.id == id
                                select oModelo
                    ).FirstOrDefault();

                //Removemos el vendedor identificado y se refresca la BD..
                MisActivos.Tb_modelosLucesE.Remove(objModelo);
                MisActivos.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
