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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAto" en el código y en el archivo de configuración a la vez.
    public class ServiceAto : IServiceAto
    {
        public AtoBE ConsultarAto(Int16 id)
        {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            AtoBE objAtoBE = new AtoBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarATO(id)).FirstOrDefault();

                objAtoBE.id = Convert.ToInt16(resultado.id);
                objAtoBE.piso = Convert.ToInt16(resultado.piso);
                objAtoBE.area = resultado.area;
                objAtoBE.equipo = Convert.ToInt16(resultado.equipo);
                objAtoBE.estado = resultado.estado;
                objAtoBE.obs = resultado.obs;
                objAtoBE.imagen = resultado.imagen;
                objAtoBE.activo = Convert.ToInt16(resultado.activo);
                objAtoBE.usu_registro = resultado.usuario_registro;
                objAtoBE.Fec_Registro = Convert.ToDateTime(resultado.fecha_registro);
                objAtoBE.usu_ult_modificacion = resultado.usu_ult_modificacion;
                objAtoBE.fec_ult_modificacion = Convert.ToDateTime(resultado.fecha_ult_modificacion);
                //Terminado el bucle devolvmemos la lista
                return objAtoBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AtoBE ConsultarAto2(Int16 id)
        {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            AtoBE objAtoBE = new AtoBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarATO2(id)).FirstOrDefault();

                objAtoBE.id = Convert.ToInt16(resultado.id);
                objAtoBE.piso = Convert.ToInt16(resultado.piso);
                objAtoBE.area = resultado.area;
                objAtoBE.marca = resultado.marca;
                objAtoBE.modelo = resultado.modelo;
                objAtoBE.tipo = resultado.tipo;
                objAtoBE.estado = resultado.estado;
                objAtoBE.activo = Convert.ToInt16(resultado.activo);
                objAtoBE.obs = resultado.obs;
                objAtoBE.imagen = resultado.imagen;
                if (objAtoBE.activo == 1)
                {
                    objAtoBE.nom_activo = "Activo";
                }
                else
                {
                    objAtoBE.nom_activo = "Inactivo";
                }

                //Terminado el bucle devolvmemos la lista
                return objAtoBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AtoBE> ListarAto()
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<AtoBE> objListaAto = new List<AtoBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarATO();

                foreach (var objAto in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    AtoBE objAtoBE = new AtoBE();

                    objAtoBE.id = Convert.ToInt16(objAto.id);
                    objAtoBE.piso = Convert.ToInt16(objAto.piso);
                    objAtoBE.area = objAto.area;
                    objAtoBE.equipo = Convert.ToInt16(objAto.equipo);
                    objAtoBE.estado = objAto.estado;
                    objAtoBE.obs = objAto.obs;
                    objAtoBE.imagen = objAto.imagen;
                    objAtoBE.activo = Convert.ToInt16(objAto.activo);
                    objAtoBE.usu_registro = objAto.usuario_registro;
                    objAtoBE.Fec_Registro = Convert.ToDateTime(objAto.fecha_registro);
                    objAtoBE.usu_ult_modificacion = objAto.usu_ult_modificacion;
                    objAtoBE.fec_ult_modificacion = Convert.ToDateTime(objAto.fecha_ult_modificacion);

                    //Agregar la instancia de datacontractual a la lista..
                    objListaAto.Add(objAtoBE);
                }

                //Se retorna la lsita...
                return objListaAto;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AtoBE> ListarAto2()
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<AtoBE> objListaAto = new List<AtoBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarATO2();

                foreach (var objAto in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    AtoBE objAtoBE = new AtoBE();

                    objAtoBE.id = Convert.ToInt16(objAto.id);
                    objAtoBE.piso = Convert.ToInt16(objAto.piso);
                    objAtoBE.area = objAto.area;
                    objAtoBE.marca = objAto.marca;
                    objAtoBE.modelo = objAto.modelo;
                    objAtoBE.tipo = objAto.tipo;
                    objAtoBE.estado = objAto.estado;
                    objAtoBE.obs = objAto.obs;
                    objAtoBE.activo = Convert.ToInt16(objAto.activo);
                    if (objAtoBE.activo == 1)
                    {
                        objAtoBE.nom_activo = "Activo";
                    }
                    else
                    {
                        objAtoBE.nom_activo = "Inactivo";
                    }

                    //Agregar la instancia de datacontractual a la lista..
                    objListaAto.Add(objAtoBE);
                }

                //Se retorna la lsita...
                return objListaAto;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarAto(AtoBE objAtoBE)
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {

                TB_ATO objAto = new TB_ATO();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                //objProducto.cod_prod = int.Empty;
                objAto.piso = Convert.ToInt16(objAtoBE.piso);
                objAto.area = objAtoBE.area;
                objAto.equipo = Convert.ToInt16(objAtoBE.equipo);
                objAto.estado = objAtoBE.estado;
                objAto.obs = objAtoBE.obs;
                objAto.activo = Convert.ToInt16(objAtoBE.activo);
                objAto.imagen = objAtoBE.imagen;
                objAto.usuario_registro = objAtoBE.usu_registro;





                //Agregamos la instancia de nuevo vendedor a su clase...
                MisActivos.TB_ATO.Add(objAto);

                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarAto(AtoBE objAtoBE)
        {

            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea actualizar
                TB_ATO objAto = (
                                from oAto in MisActivos.TB_ATO
                                where oAto.id == objAtoBE.id
                                select oAto
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objAto.id = Convert.ToInt16(objAtoBE.id);
                objAto.piso = Convert.ToInt16(objAtoBE.piso);
                objAto.area = objAtoBE.area;
                objAto.equipo = Convert.ToInt16(objAtoBE.equipo);
                objAto.estado = objAtoBE.estado;
                objAto.obs = objAtoBE.obs;
                objAto.activo = Convert.ToInt16(objAtoBE.activo);
                objAto.imagen = objAtoBE.imagen;
                objAto.usu_ult_modificacion = objAtoBE.usu_ult_modificacion;


                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarAto(Int16 id)
        {

            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea eliminar
                TB_ATO objAto = (
                                from oAto in MisActivos.TB_ATO
                                where oAto.id == id
                                select oAto
                    ).FirstOrDefault();

                //Removemos el vendedor identificado y se refresca la BD..
                MisActivos.TB_ATO.Remove(objAto);
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
