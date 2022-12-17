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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceHangar" en el código y en el archivo de configuración a la vez.
    public class ServiceHangar : IServiceHangar
    {
        public HangarBE ConsultarHangar(Int16 id) {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            HangarBE objHangarBE = new HangarBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarHangar(id)).FirstOrDefault();

                objHangarBE.id = Convert.ToInt16(resultado.id);
                objHangarBE.piso = Convert.ToInt16(resultado.piso);
                objHangarBE.area = resultado.area;
                objHangarBE.equipo = Convert.ToInt16(resultado.equipo);
                objHangarBE.estado = resultado.estado;
                objHangarBE.obs = resultado.obs;
                objHangarBE.imagen = resultado.imagen;
                objHangarBE.activo = Convert.ToInt16(resultado.activo);
                objHangarBE.usu_registro = resultado.usuario_registro;
                objHangarBE.Fec_Registro = Convert.ToDateTime(resultado.fecha_registro);
                objHangarBE.usu_ult_modificacion = resultado.usu_ult_modificacion;
                objHangarBE.fec_ult_modificacion = Convert.ToDateTime(resultado.fecha_ult_modificacion);
                //Terminado el bucle devolvmemos la lista
                return objHangarBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public HangarBE ConsultarHangar2(Int16 id)
        {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            HangarBE objHangarBE = new HangarBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarHangar2(id)).FirstOrDefault();

                objHangarBE.id = Convert.ToInt16(resultado.id);
                objHangarBE.piso = Convert.ToInt16(resultado.piso);
                objHangarBE.area = resultado.area;
                objHangarBE.marca = resultado.marca;
                objHangarBE.modelo = resultado.modelo;
                objHangarBE.tipo = resultado.tipo;
                objHangarBE.estado = resultado.estado;
                objHangarBE.activo = Convert.ToInt16(resultado.activo);
                objHangarBE.obs = resultado.obs;
                objHangarBE.imagen = resultado.imagen;
                if (objHangarBE.activo == 1)
                {
                    objHangarBE.nom_activo = "Activo";
                }
                else
                {
                    objHangarBE.nom_activo = "Inactivo";
                }

                //Terminado el bucle devolvmemos la lista
                return objHangarBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
               
        public List<HangarBE> ListarHangar() {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<HangarBE> objListaHangar = new List<HangarBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarHangar();

                foreach (var objHangar in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    HangarBE objHangarBE = new HangarBE();

                    objHangarBE.id = Convert.ToInt16(objHangar.id);
                    objHangarBE.piso = Convert.ToInt16(objHangar.piso);
                    objHangarBE.area = objHangar.area;
                    objHangarBE.equipo = Convert.ToInt16(objHangar.equipo);
                    objHangarBE.estado = objHangar.estado;
                    objHangarBE.obs = objHangar.obs;
                    objHangarBE.imagen = objHangar.imagen;
                    objHangarBE.activo = Convert.ToInt16(objHangar.activo);
                    objHangarBE.usu_registro = objHangar.usuario_registro;
                    objHangarBE.Fec_Registro = Convert.ToDateTime(objHangar.fecha_registro);
                    objHangarBE.usu_ult_modificacion = objHangar.usu_ult_modificacion;
                    objHangarBE.fec_ult_modificacion = Convert.ToDateTime(objHangar.fecha_ult_modificacion);

                    //Agregar la instancia de datacontractual a la lista..
                    objListaHangar.Add(objHangarBE);
                }

                //Se retorna la lsita...
                return objListaHangar;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HangarBE> ListarHangar2() {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<HangarBE> objListaHangar = new List<HangarBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarHangar2();

                foreach (var objHangar in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    HangarBE objHangarBE = new HangarBE();

                    objHangarBE.id = Convert.ToInt16(objHangar.id);
                    objHangarBE.piso = Convert.ToInt16(objHangar.piso);
                    objHangarBE.area = objHangar.area;
                    objHangarBE.marca = objHangar.marca;
                    objHangarBE.modelo = objHangar.modelo;
                    objHangarBE.tipo = objHangar.tipo;
                    objHangarBE.estado = objHangar.estado;
                    objHangarBE.obs = objHangar.obs;
                    objHangarBE.activo = Convert.ToInt16(objHangar.activo);
                    if (objHangarBE.activo == 1)
                    {
                        objHangarBE.nom_activo = "Activo";
                    }
                    else
                    {
                        objHangarBE.nom_activo = "Inactivo";
                    }

                    //Agregar la instancia de datacontractual a la lista..
                    objListaHangar.Add(objHangarBE);
                }

                //Se retorna la lsita...
                return objListaHangar;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarHangar(HangarBE objHangarBE) {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {

                TB_Hangar objHangar = new TB_Hangar();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                //objProducto.cod_prod = int.Empty;
                objHangar.piso = Convert.ToInt16(objHangarBE.piso);
                objHangar.area = objHangarBE.area;
                objHangar.equipo = Convert.ToInt16(objHangarBE.equipo);
                objHangar.estado = objHangarBE.estado;
                objHangar.obs = objHangarBE.obs;
                objHangar.activo = Convert.ToInt16(objHangarBE.activo);
                objHangar.imagen = objHangarBE.imagen;
                objHangar.usuario_registro = objHangarBE.usu_registro;
                




                //Agregamos la instancia de nuevo vendedor a su clase...
                MisActivos.TB_Hangar.Add(objHangar);

                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarHangar(HangarBE objHangarBE) {

            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea actualizar
                TB_Hangar objHangar = (
                                from oHangar in MisActivos.TB_Hangar
                                where oHangar.id == objHangarBE.id
                                select oHangar
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objHangar.id = Convert.ToInt16(objHangarBE.id);
                objHangar.piso = Convert.ToInt16(objHangarBE.piso);
                objHangar.area = objHangarBE.area;
                objHangar.equipo = Convert.ToInt16(objHangarBE.equipo);
                objHangar.estado = objHangarBE.estado;
                objHangar.obs = objHangarBE.obs;
                objHangar.activo = Convert.ToInt16(objHangarBE.activo);
                objHangar.imagen = objHangarBE.imagen;
                objHangar.usu_ult_modificacion = objHangarBE.usu_ult_modificacion;


                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarHangar(Int16 id) {

            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea eliminar
                TB_Hangar objHangar = (
                                from oHangar in MisActivos.TB_Hangar
                                where oHangar.id == id
                                select oHangar
                    ).FirstOrDefault();

                //Removemos el vendedor identificado y se refresca la BD..
                MisActivos.TB_Hangar.Remove(objHangar);
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
