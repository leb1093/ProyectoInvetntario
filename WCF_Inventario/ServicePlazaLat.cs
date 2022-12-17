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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicePlazaLat" en el código y en el archivo de configuración a la vez.
    public class ServicePlazaLat : IServicePlazaLat
    {
        public PlazaLatBE ConsultarPlazaLat(Int16 id)
        {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            PlazaLatBE objPlazaLatBE = new PlazaLatBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarPlazaLat(id)).FirstOrDefault();

                objPlazaLatBE.id = Convert.ToInt16(resultado.id);
                objPlazaLatBE.piso = Convert.ToInt16(resultado.piso);
                objPlazaLatBE.area = resultado.area;
                objPlazaLatBE.equipo = Convert.ToInt16(resultado.equipo);
                objPlazaLatBE.estado = resultado.estado;
                objPlazaLatBE.obs = resultado.obs;
                objPlazaLatBE.imagen = resultado.imagen;
                objPlazaLatBE.activo = Convert.ToInt16(resultado.activo);
                objPlazaLatBE.usu_registro = resultado.usuario_registro;
                objPlazaLatBE.Fec_Registro = Convert.ToDateTime(resultado.fecha_registro);
                objPlazaLatBE.usu_ult_modificacion = resultado.usu_ult_modificacion;
                objPlazaLatBE.fec_ult_modificacion = Convert.ToDateTime(resultado.fecha_ult_modificacion);
                //Terminado el bucle devolvmemos la lista
                return objPlazaLatBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PlazaLatBE ConsultarPlazaLat2(Int16 id)
        {
            //Retornaremos las facturas de un cliente entre 2 fechas dadas...
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();
            PlazaLatBE objPlazaLatBE = new PlazaLatBE();
            try
            {
                //Creamos instancia del modelo...
                var resultado = (MisActivos.spu_ConsultarPlazaLat2(id)).FirstOrDefault();

                objPlazaLatBE.id = Convert.ToInt16(resultado.id);
                objPlazaLatBE.piso = Convert.ToInt16(resultado.piso);
                objPlazaLatBE.area = resultado.area;
                objPlazaLatBE.marca = resultado.marca;
                objPlazaLatBE.modelo = resultado.modelo;
                objPlazaLatBE.tipo = resultado.tipo;
                objPlazaLatBE.estado = resultado.estado;
                objPlazaLatBE.activo = Convert.ToInt16(resultado.activo);
                objPlazaLatBE.obs = resultado.obs;
                objPlazaLatBE.imagen = resultado.imagen;
                if (objPlazaLatBE.activo == 1)
                {
                    objPlazaLatBE.nom_activo = "Activo";
                }
                else
                {
                    objPlazaLatBE.nom_activo = "Inactivo";
                }

                //Terminado el bucle devolvmemos la lista
                return objPlazaLatBE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PlazaLatBE> ListarPlazaLat()
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<PlazaLatBE> objListaPlazaLat = new List<PlazaLatBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarPlazaLat();

                foreach (var objPlazaLat in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    PlazaLatBE objPlazaLatBE = new PlazaLatBE();

                    objPlazaLatBE.id = Convert.ToInt16(objPlazaLat.id);
                    objPlazaLatBE.piso = Convert.ToInt16(objPlazaLat.piso);
                    objPlazaLatBE.area = objPlazaLat.area;
                    objPlazaLatBE.equipo = Convert.ToInt16(objPlazaLat.equipo);
                    objPlazaLatBE.estado = objPlazaLat.estado;
                    objPlazaLatBE.obs = objPlazaLat.obs;
                    objPlazaLatBE.imagen = objPlazaLat.imagen;
                    objPlazaLatBE.activo = Convert.ToInt16(objPlazaLat.activo);
                    objPlazaLatBE.usu_registro = objPlazaLat.usuario_registro;
                    objPlazaLatBE.Fec_Registro = Convert.ToDateTime(objPlazaLat.fecha_registro);
                    objPlazaLatBE.usu_ult_modificacion = objPlazaLat.usu_ult_modificacion;
                    objPlazaLatBE.fec_ult_modificacion = Convert.ToDateTime(objPlazaLat.fecha_ult_modificacion);

                    //Agregar la instancia de datacontractual a la lista..
                    objListaPlazaLat.Add(objPlazaLatBE);
                }

                //Se retorna la lsita...
                return objListaPlazaLat;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PlazaLatBE> ListarPlazaLat2()
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Instanciamos una lista de vendedores...
                List<PlazaLatBE> objListaPlazaLat = new List<PlazaLatBE>();

                //Obtenemos todas las instancias de la clase TB_Vendedor
                var query = MisActivos.spu_ListarPlazaLat2();

                foreach (var objPlazaLat in query)
                {
                    //Declaramos una instancia de la datacontractual..
                    PlazaLatBE objPlazaLatBE = new PlazaLatBE();

                    objPlazaLatBE.id = Convert.ToInt16(objPlazaLat.id);
                    objPlazaLatBE.piso = Convert.ToInt16(objPlazaLat.piso);
                    objPlazaLatBE.area = objPlazaLat.area;
                    objPlazaLatBE.marca = objPlazaLat.marca;
                    objPlazaLatBE.modelo = objPlazaLat.modelo;
                    objPlazaLatBE.tipo = objPlazaLat.tipo;
                    objPlazaLatBE.estado = objPlazaLat.estado;
                    objPlazaLatBE.obs = objPlazaLat.obs;
                    objPlazaLatBE.activo = Convert.ToInt16(objPlazaLat.activo);
                    if (objPlazaLatBE.activo == 1)
                    {
                        objPlazaLatBE.nom_activo = "Activo";
                    }
                    else
                    {
                        objPlazaLatBE.nom_activo = "Inactivo";
                    }

                    //Agregar la instancia de datacontractual a la lista..
                    objListaPlazaLat.Add(objPlazaLatBE);
                }

                //Se retorna la lsita...
                return objListaPlazaLat;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarPlazaLat(PlazaLatBE objPlazaLatBE)
        {
            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {

                TB_PlazaLat objPlazaLat = new TB_PlazaLat();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                //objProducto.cod_prod = int.Empty;
                objPlazaLat.piso = Convert.ToInt16(objPlazaLatBE.piso);
                objPlazaLat.area = objPlazaLatBE.area;
                objPlazaLat.equipo = Convert.ToInt16(objPlazaLatBE.equipo);
                objPlazaLat.estado = objPlazaLatBE.estado;
                objPlazaLat.obs = objPlazaLatBE.obs;
                objPlazaLat.activo = Convert.ToInt16(objPlazaLatBE.activo);
                objPlazaLat.imagen = objPlazaLatBE.imagen;
                objPlazaLat.usuario_registro = objPlazaLatBE.usu_registro;





                //Agregamos la instancia de nuevo vendedor a su clase...
                MisActivos.TB_PlazaLat.Add(objPlazaLat);

                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean ActualizarPlazaLat(PlazaLatBE objPlazaLatBE)
        {

            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea actualizar
                TB_PlazaLat objPlazaLat = (
                                from oPlazaLat in MisActivos.TB_PlazaLat
                                where oPlazaLat.id == objPlazaLatBE.id
                                select oPlazaLat
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objPlazaLat.id = Convert.ToInt16(objPlazaLatBE.id);
                objPlazaLat.piso = Convert.ToInt16(objPlazaLatBE.piso);
                objPlazaLat.area = objPlazaLatBE.area;
                objPlazaLat.equipo = Convert.ToInt16(objPlazaLatBE.equipo);
                objPlazaLat.estado = objPlazaLatBE.estado;
                objPlazaLat.obs = objPlazaLatBE.obs;
                objPlazaLat.activo = Convert.ToInt16(objPlazaLatBE.activo);
                objPlazaLat.imagen = objPlazaLatBE.imagen;
                objPlazaLat.usu_ult_modificacion = objPlazaLatBE.usu_ult_modificacion;


                //Refrescar la BD...
                MisActivos.SaveChanges();

                return true;

            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarPlazaLat(Int16 id)
        {

            AltelizaActivosEntities MisActivos = new AltelizaActivosEntities();

            try
            {
                //Ubicamos al vendedor que se desea eliminar
                TB_PlazaLat objPlazaLat = (
                                from oPlazaLat in MisActivos.TB_PlazaLat
                                where oPlazaLat.id == id
                                select oPlazaLat
                    ).FirstOrDefault();

                //Removemos el vendedor identificado y se refresca la BD..
                MisActivos.TB_PlazaLat.Remove(objPlazaLat);
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
