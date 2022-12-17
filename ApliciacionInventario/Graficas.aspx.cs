using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApliciacionInventario
{
    public partial class Graficas : System.Web.UI.Page
    {
        ProxyHangar.ServiceHangarClient objHangar = new ProxyHangar.ServiceHangarClient();
        ProxyHangar.HangarBE objHangarBE = new ProxyHangar.HangarBE();
        ProxyModelo.ServiceModeloClient objModelo = new ProxyModelo.ServiceModeloClient();
        ProxyModelo.ModeloBE onjModeloBE = new ProxyModelo.ModeloBE();
        ProxyAto.ServiceAtoClient objAto = new ProxyAto.ServiceAtoClient();
        ProxyAto.AtoBE objAtoBE = new ProxyAto.AtoBE();
        ProxyPlazaLat.ServicePlazaLatClient objPlazaLat = new ProxyPlazaLat.ServicePlazaLatClient();
        ProxyPlazaLat.PlazaLatBE objPlazaLatBE = new ProxyPlazaLat.PlazaLatBE();

        DataView dtv;
        DataTable dt;
        DataTable dt2;
        DataTable dt3;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        protected string CargarGraficas1()
        {
            dt = ConvertToDataTable(objHangar.ListarHangar2());
            
            int nOperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "OPERATIVO").ToList().Count;
            int nInoperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "INOPERATIVO").ToList().Count;
            int nCAmbio = dt.AsEnumerable().Where(x => x["estado"].ToString() == "CAMBIO DE BATERIA").ToList().Count;

            List<string> listaEstados = new List<string>();
            //Le agrego elementos dinámicamente..
            listaEstados.Add("OPERATIVO");
            listaEstados.Add("INOPERATIVO");
            listaEstados.Add("CAMBIO DE BATERIA");
            //La convierto en un array
            string[] estados = listaEstados.ToArray();

            List<int> listaValEst = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValEst.Add(nOperativos);
            listaValEst.Add(nInoperativos);
            listaValEst.Add(nCAmbio);
            //La convierto en un array
            int[] cantidadEst = listaValEst.ToArray();

            string strDatos = "[";
            for (int i = 0; i < 3; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + estados[i] + "'" + "," + cantidadEst[i];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas2()
        {
            dt = ConvertToDataTable(objHangar.ListarHangar2());

            int nLed = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "LED").ToList().Count;
            int nHalogeno = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "HALOGENO").ToList().Count;

            List<string> listaTipo = new List<string>();
            //Le agrego elementos dinámicamente..
            listaTipo.Add("LED");
            listaTipo.Add("HALOGENO");
            //La convierto en un array
            string[] tipos = listaTipo.ToArray();

            List<int> listaValTipo = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValTipo.Add(nLed);
            listaValTipo.Add(nHalogeno);
            //La convierto en un array
            int[] cantidadTip = listaValTipo.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("red");
            listaValCol.Add("blue");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();



            string strDatos = "[[\"Tecnologia\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 2; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + tipos[i] + "'" + "," + cantidadTip[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas3()
        {
            dt = ConvertToDataTable(objHangar.ListarHangar2());

            int nOpalux = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Opalux").ToList().Count;
            int nPhilips = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Philips").ToList().Count;
            int nCoel = dt.AsEnumerable().Where(x => x["marca"].ToString() == "COEL").ToList().Count;
            int nHalux = dt.AsEnumerable().Where(x => x["marca"].ToString() == "HALUX").ToList().Count;

            List<string> listaMarca = new List<string>();
            //Le agrego elementos dinámicamente..
            listaMarca.Add("Opalux");
            listaMarca.Add("Philips");
            listaMarca.Add("COEL");
            listaMarca.Add("HALUX");
            //La convierto en un array
            string[] marcas = listaMarca.ToArray();

            List<int> listaValMarca = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValMarca.Add(nOpalux);
            listaValMarca.Add(nPhilips);
            listaValMarca.Add(nCoel);
            listaValMarca.Add(nHalux);
            //La convierto en un array
            int[] cantidadMarc = listaValMarca.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("green");
            listaValCol.Add("blue");
            listaValCol.Add("gary");
            listaValCol.Add("brown");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();

            string strDatos = "[[\"Marca\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 4; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + marcas[i] + "'" + "," + cantidadMarc[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }



        protected string CargarGraficas4()
        {
            dt = ConvertToDataTable(objAto.ListarAto2());

            int nOperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "OPERATIVO").ToList().Count;
            int nInoperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "INOPERATIVO").ToList().Count;
            int nCAmbio = dt.AsEnumerable().Where(x => x["estado"].ToString() == "CAMBIO DE BATERIA").ToList().Count;

            List<string> listaEstados = new List<string>();
            //Le agrego elementos dinámicamente..
            listaEstados.Add("OPERATIVO");
            listaEstados.Add("INOPERATIVO");
            listaEstados.Add("CAMBIO DE BATERIA");
            //La convierto en un array
            string[] estados = listaEstados.ToArray();

            List<int> listaValEst = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValEst.Add(nOperativos);
            listaValEst.Add(nInoperativos);
            listaValEst.Add(nCAmbio);
            //La convierto en un array
            int[] cantidadEst = listaValEst.ToArray();

            string strDatos = "[";
            for (int i = 0; i < 3; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + estados[i] + "'" + "," + cantidadEst[i];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas5()
        {
            dt = ConvertToDataTable(objAto.ListarAto2());

            int nLed = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "LED").ToList().Count;
            int nHalogeno = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "HALOGENO").ToList().Count;

            List<string> listaTipo = new List<string>();
            //Le agrego elementos dinámicamente..
            listaTipo.Add("LED");
            listaTipo.Add("HALOGENO");
            //La convierto en un array
            string[] tipos = listaTipo.ToArray();

            List<int> listaValTipo = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValTipo.Add(nLed);
            listaValTipo.Add(nHalogeno);
            //La convierto en un array
            int[] cantidadTip = listaValTipo.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("red");
            listaValCol.Add("blue");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();



            string strDatos = "[[\"Tecnologia\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 2; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + tipos[i] + "'" + "," + cantidadTip[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas6()
        {
            dt = ConvertToDataTable(objAto.ListarAto2());

            int nOpalux = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Opalux").ToList().Count;
            int nPhilips = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Philips").ToList().Count;
            int nCoel = dt.AsEnumerable().Where(x => x["marca"].ToString() == "COEL").ToList().Count;
            int nHalux = dt.AsEnumerable().Where(x => x["marca"].ToString() == "HALUX").ToList().Count;

            List<string> listaMarca = new List<string>();
            //Le agrego elementos dinámicamente..
            listaMarca.Add("Opalux");
            listaMarca.Add("Philips");
            listaMarca.Add("COEL");
            listaMarca.Add("HALUX");
            //La convierto en un array
            string[] marcas = listaMarca.ToArray();

            List<int> listaValMarca = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValMarca.Add(nOpalux);
            listaValMarca.Add(nPhilips);
            listaValMarca.Add(nCoel);
            listaValMarca.Add(nHalux);
            //La convierto en un array
            int[] cantidadMarc = listaValMarca.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("green");
            listaValCol.Add("blue");
            listaValCol.Add("gary");
            listaValCol.Add("brown");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();

            string strDatos = "[[\"Marca\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 4; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + marcas[i] + "'" + "," + cantidadMarc[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }



        protected string CargarGraficas7()
        {
            dt = ConvertToDataTable(objPlazaLat.ListarPlazaLat2());

            int nOperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "OPERATIVO").ToList().Count;
            int nInoperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "INOPERATIVO").ToList().Count;
            int nCAmbio = dt.AsEnumerable().Where(x => x["estado"].ToString() == "CAMBIO DE BATERIA").ToList().Count;

            List<string> listaEstados = new List<string>();
            //Le agrego elementos dinámicamente..
            listaEstados.Add("OPERATIVO");
            listaEstados.Add("INOPERATIVO");
            listaEstados.Add("CAMBIO DE BATERIA");
            //La convierto en un array
            string[] estados = listaEstados.ToArray();

            List<int> listaValEst = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValEst.Add(nOperativos);
            listaValEst.Add(nInoperativos);
            listaValEst.Add(nCAmbio);
            //La convierto en un array
            int[] cantidadEst = listaValEst.ToArray();

            string strDatos = "[";
            for (int i = 0; i < 3; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + estados[i] + "'" + "," + cantidadEst[i];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas8()
        {
            dt = ConvertToDataTable(objPlazaLat.ListarPlazaLat2());

            int nLed = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "LED").ToList().Count;
            int nHalogeno = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "HALOGENO").ToList().Count;

            List<string> listaTipo = new List<string>();
            //Le agrego elementos dinámicamente..
            listaTipo.Add("LED");
            listaTipo.Add("HALOGENO");
            //La convierto en un array
            string[] tipos = listaTipo.ToArray();

            List<int> listaValTipo = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValTipo.Add(nLed);
            listaValTipo.Add(nHalogeno);
            //La convierto en un array
            int[] cantidadTip = listaValTipo.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("red");
            listaValCol.Add("blue");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();



            string strDatos = "[[\"Tecnologia\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 2; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + tipos[i] + "'" + "," + cantidadTip[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas9()
        {
            dt = ConvertToDataTable(objPlazaLat.ListarPlazaLat2());

            int nOpalux = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Opalux").ToList().Count;
            int nPhilips = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Philips").ToList().Count;
            int nCoel = dt.AsEnumerable().Where(x => x["marca"].ToString() == "COEL").ToList().Count;
            int nHalux = dt.AsEnumerable().Where(x => x["marca"].ToString() == "HALUX").ToList().Count;

            List<string> listaMarca = new List<string>();
            //Le agrego elementos dinámicamente..
            listaMarca.Add("Opalux");
            listaMarca.Add("Philips");
            listaMarca.Add("COEL");
            listaMarca.Add("HALUX");
            //La convierto en un array
            string[] marcas = listaMarca.ToArray();

            List<int> listaValMarca = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValMarca.Add(nOpalux);
            listaValMarca.Add(nPhilips);
            listaValMarca.Add(nCoel);
            listaValMarca.Add(nHalux);
            //La convierto en un array
            int[] cantidadMarc = listaValMarca.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("green");
            listaValCol.Add("blue");
            listaValCol.Add("gary");
            listaValCol.Add("brown");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();

            string strDatos = "[[\"Marca\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 4; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + marcas[i] + "'" + "," + cantidadMarc[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }


        protected string CargarGraficas10()
        {
            dt = ConvertToDataTable(objPlazaLat.ListarPlazaLat2());
            dt2 = ConvertToDataTable(objHangar.ListarHangar2());
            dt3 = ConvertToDataTable(objAto.ListarAto2());

            int nOperativos =   dt.AsEnumerable().Where(x => x["estado"].ToString() == "OPERATIVO").ToList().Count+
                                dt2.AsEnumerable().Where(x => x["estado"].ToString() == "OPERATIVO").ToList().Count+
                                dt3.AsEnumerable().Where(x => x["estado"].ToString() == "OPERATIVO").ToList().Count;

            int nInoperativos = dt.AsEnumerable().Where(x => x["estado"].ToString() == "INOPERATIVO").ToList().Count+
                                dt2.AsEnumerable().Where(x => x["estado"].ToString() == "INOPERATIVO").ToList().Count +
                                dt3.AsEnumerable().Where(x => x["estado"].ToString() == "INOPERATIVO").ToList().Count ;

            int nCAmbio =   dt.AsEnumerable().Where(x => x["estado"].ToString() == "CAMBIO DE BATERIA").ToList().Count+
                            dt2.AsEnumerable().Where(x => x["estado"].ToString() == "CAMBIO DE BATERIA").ToList().Count +
                            dt3.AsEnumerable().Where(x => x["estado"].ToString() == "CAMBIO DE BATERIA").ToList().Count ;

            List<string> listaEstados = new List<string>();
            //Le agrego elementos dinámicamente..
            listaEstados.Add("OPERATIVO");
            listaEstados.Add("INOPERATIVO");
            listaEstados.Add("CAMBIO DE BATERIA");
            //La convierto en un array
            string[] estados = listaEstados.ToArray();

            List<int> listaValEst = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValEst.Add(nOperativos);
            listaValEst.Add(nInoperativos);
            listaValEst.Add(nCAmbio);
            //La convierto en un array
            int[] cantidadEst = listaValEst.ToArray();

            string strDatos = "[";
            for (int i = 0; i < 3; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + estados[i] + "'" + "," + cantidadEst[i];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas11()
        {
            dt = ConvertToDataTable(objPlazaLat.ListarPlazaLat2());
            dt2 = ConvertToDataTable(objHangar.ListarHangar2());
            dt3 = ConvertToDataTable(objAto.ListarAto2());

            int nLed =  dt.AsEnumerable().Where(x => x["tipo"].ToString() == "LED").ToList().Count+
                        dt2.AsEnumerable().Where(x => x["tipo"].ToString() == "LED").ToList().Count +
                        dt3.AsEnumerable().Where(x => x["tipo"].ToString() == "LED").ToList().Count ;

            int nHalogeno = dt.AsEnumerable().Where(x => x["tipo"].ToString() == "HALOGENO").ToList().Count+
                            dt2.AsEnumerable().Where(x => x["tipo"].ToString() == "HALOGENO").ToList().Count+
                            dt3.AsEnumerable().Where(x => x["tipo"].ToString() == "HALOGENO").ToList().Count;

            List<string> listaTipo = new List<string>();
            //Le agrego elementos dinámicamente..
            listaTipo.Add("LED");
            listaTipo.Add("HALOGENO");
            //La convierto en un array
            string[] tipos = listaTipo.ToArray();

            List<int> listaValTipo = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValTipo.Add(nLed);
            listaValTipo.Add(nHalogeno);
            //La convierto en un array
            int[] cantidadTip = listaValTipo.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("red");
            listaValCol.Add("blue");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();



            string strDatos = "[[\"Tecnologia\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 2; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + tipos[i] + "'" + "," + cantidadTip[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }

        protected string CargarGraficas12()
        {
            dt = ConvertToDataTable(objPlazaLat.ListarPlazaLat2());
            dt2 = ConvertToDataTable(objHangar.ListarHangar2());
            dt3 = ConvertToDataTable(objAto.ListarAto2());

            int nOpalux =   dt.AsEnumerable().Where(x => x["marca"].ToString() == "Opalux").ToList().Count+
                            dt2.AsEnumerable().Where(x => x["marca"].ToString() == "Opalux").ToList().Count+
                            dt3.AsEnumerable().Where(x => x["marca"].ToString() == "Opalux").ToList().Count ;

            int nPhilips = dt.AsEnumerable().Where(x => x["marca"].ToString() == "Philips").ToList().Count+
                            dt2.AsEnumerable().Where(x => x["marca"].ToString() == "Philips").ToList().Count+
                            dt3.AsEnumerable().Where(x => x["marca"].ToString() == "Philips").ToList().Count ;

            int nCoel = dt.AsEnumerable().Where(x => x["marca"].ToString() == "COEL").ToList().Count+
                        dt2.AsEnumerable().Where(x => x["marca"].ToString() == "COEL").ToList().Count +
                        dt3.AsEnumerable().Where(x => x["marca"].ToString() == "COEL").ToList().Count ;

            int nHalux =    dt.AsEnumerable().Where(x => x["marca"].ToString() == "HALUX").ToList().Count+
                            dt2.AsEnumerable().Where(x => x["marca"].ToString() == "HALUX").ToList().Count +
                            dt3.AsEnumerable().Where(x => x["marca"].ToString() == "HALUX").ToList().Count ;

            List<string> listaMarca = new List<string>();
            //Le agrego elementos dinámicamente..
            listaMarca.Add("Opalux");
            listaMarca.Add("Philips");
            listaMarca.Add("COEL");
            listaMarca.Add("HALUX");
            //La convierto en un array
            string[] marcas = listaMarca.ToArray();

            List<int> listaValMarca = new List<int>();
            //Le agrego elementos dinámicamente..
            listaValMarca.Add(nOpalux);
            listaValMarca.Add(nPhilips);
            listaValMarca.Add(nCoel);
            listaValMarca.Add(nHalux);
            //La convierto en un array
            int[] cantidadMarc = listaValMarca.ToArray();

            List<string> listaValCol = new List<string>();
            //Le agrego elementos dinámicamente..
            listaValCol.Add("green");
            listaValCol.Add("blue");
            listaValCol.Add("gary");
            listaValCol.Add("brown");
            //La convierto en un array
            string[] cantidadColor = listaValCol.ToArray();

            string strDatos = "[[\"Marca\", \"Cantidad\", { role: \"style\" }],";
            for (int i = 0; i < 4; i++)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + marcas[i] + "'" + "," + cantidadMarc[i] + "," + "'" + cantidadColor[i] + "'";
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";

            return strDatos;
        }


    }
}