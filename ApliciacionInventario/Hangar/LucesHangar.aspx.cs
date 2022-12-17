using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ApliciacionInventario.ProxyHangar;
using ApliciacionInventario.ProxyModelo;
using ApliciacionInventario.Usuario;
using System.Data.SqlClient;
using OfficeOpenXml;
using System.IO;
using System.Threading;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Web.UI.DataVisualization.Charting;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ApliciacionInventario.Hangar
{
    
    public partial class LucesHangar : System.Web.UI.Page
    {
        ProxyHangar.ServiceHangarClient objHangar = new ProxyHangar.ServiceHangarClient();
        ProxyHangar.HangarBE objHangarBE = new ProxyHangar.HangarBE();
        ProxyModelo.ServiceModeloClient objModelo = new ProxyModelo.ServiceModeloClient();
        ProxyModelo.ModeloBE onjModeloBE = new ProxyModelo.ModeloBE();
        
        DataView dtv;
        DataTable dt;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.Enctype = "multipart/form-data";

            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnDescargar);

                if (Page.IsPostBack == false)
                {
                    
                    if (clsCredenciales.Nivel == 3)
                    {
                        btnNuevo.Visible = false;
                        btnGrabar.Visible = false;
                        btnEliminar.Visible = false;
                        btnGrabar2.Visible = false;

                        txtPiso2.Enabled = false;
                        txtid.Enabled = false;
                        txtArea2.Enabled = false;
                        cboEquipo2.Enabled = false;
                        cboEstado2.Enabled = false;
                        txtObs2.Enabled = false;
                        btnUpload2.Visible = false;
                        btnPrev2.Visible = false;
                        chkActivo2.Enabled = false;

                    }
                    else
                    {
                        btnNuevo.Visible = true;
                        btnGrabar.Visible = true;
                        btnEliminar.Visible = true;
                        btnGrabar2.Visible = true;
                    }


                    Session["extension"] = "";
                    Session["imageTemp"] = "";
                    Session["extension2"] = "";
                    Session["imageTemp2"] = "";
                    dtv = new DataView(ConvertToDataTable(objHangar.ListarHangar2()));
                    Session["Vista"] = dtv;
                    CargarDatos("");
                    CargarGraficas(); 

                    
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }

        }

        private void CargarDatos(String strFiltro)
        {
            dtv = (DataView)Session["Vista"];
            dtv.RowFilter = "area like '%" + strFiltro + "%'";
            grvLuces.DataSource = dtv;
            grvLuces.DataBind();

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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensajeIns.Text = "";
                txtPiso.Text = "";
                txtArea.Text = "";
                txtObs.Text = "";
                chkActivo.Checked = true;
                txtPiso.Focus();
                ImageUpload.ImageUrl = null;
                CargarListaModelos(1);

                PopMant.Show();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        private void CargarListaModelos(Int16 IdCate)
        {

            cboEquipo.DataSource = objModelo.ListarModelos2();
            cboEquipo.DataValueField = "id";
            cboEquipo.DataTextField = "nom_equipo";
            cboEquipo.DataBind();
            cboEquipo.SelectedValue = Convert.ToString(1);

        }

        protected void btnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarDatos(txtFiltro.Text);
                cboConsultaEst.SelectedValue = Convert.ToString(0);
                cboConsultaTipo.SelectedValue = Convert.ToString(0);
                CargarGraficas();

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var fullFilePath = Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"]));
                var copyToPath = Server.MapPath(@"~\Hangar\Fotos\" + (string)(Session["imageTemp"]));

                if (txtPiso.Text == "")
                {
                    throw new Exception("El Piso es obligartorio");
                }
                if (txtArea.Text == "")
                {
                    throw new Exception("Detalle el Area");
                }
                if (cboEstado.SelectedValue.ToString() == "0")
                {
                    throw new Exception("Seleccione el estado actual del equipo");
                }
                if (((string)(Session["extension"]))=="" || (string)(Session["imageTemp"])=="")
                {
                    copyToPath = "";
                }




                objHangarBE.piso = Convert.ToInt16(txtPiso.Text);
                objHangarBE.area = txtArea.Text;
                objHangarBE.equipo = Convert.ToInt16(cboEquipo.SelectedValue.ToString());
                objHangarBE.estado = cboEstado.SelectedValue.ToString();
                objHangarBE.obs = txtObs.Text;
                objHangarBE.activo = Convert.ToInt16(chkActivo.Checked);
                objHangarBE.imagen = "~\\Hangar\\Fotos\\" + (string)(Session["imageTemp"]);
                objHangarBE.usu_registro = clsCredenciales.Usuario;

                if (objHangar.InsertarHangar(objHangarBE) == true)
                {
                    if (copyToPath != "") {
                        // Copy the file
                        if (File.Exists(copyToPath)!= true)
                        {
                            File.Copy(fullFilePath, copyToPath);
                        }

                        if (File.Exists(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"]))))
                        {
                            File.Delete(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"])));
                            Session["extension"] = "";
                            Session["imageTemp"] = "";
                        }
                    }


                    dtv = new DataView(ConvertToDataTable(objHangar.ListarHangar2()));
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
                    CargarGraficas();
                }
                else
                {
                    throw new Exception("No se inserto el registro. COntacte con IT.");
                }


                



            }
            catch (Exception ex)
            {

                lblMensajeIns.Text = ex.Message;
                PopMant.Show();// para mantener el popup abierto tras el clic en Grabar

            }
        }

        protected void btnGrabar2_Click(object sender, EventArgs e)
        {
            try
            {
                var fullFilePath = Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"]));
                var copyToPath = Server.MapPath(@"~\Hangar\Fotos\" + (string)(Session["imageTemp2"]));

                if (txtPiso2.Text == "")
                {
                    throw new Exception("El Piso es obligartorio");
                }
                if (txtArea2.Text == "")
                {
                    throw new Exception("Detalle el Area");
                }
                if (cboEstado2.SelectedValue.ToString() == "0")
                {
                    throw new Exception("Seleccione el estado actual del equipo");
                }
                if (((string)(Session["extension2"])) == "" || (string)(Session["imageTemp2"]) == "")
                {
                    copyToPath = "";
                }

                if ((string)(Session["imageTemp2"]) != "")
                {

                    objHangarBE.imagen = "~\\Hangar\\Fotos\\" + (string)(Session["imageTemp2"]);
                }
                else
                {
                    objHangarBE = objHangar.ConsultarHangar(Convert.ToInt16(Convert.ToInt16(txtid.Text)));

                }

                objHangarBE.id = Convert.ToInt16(txtid.Text);
                objHangarBE.piso = Convert.ToInt16(txtPiso2.Text);
                objHangarBE.area = txtArea2.Text;
                objHangarBE.equipo = Convert.ToInt16(cboEquipo2.SelectedValue.ToString());
                objHangarBE.estado = cboEstado2.SelectedValue.ToString();
                objHangarBE.obs = txtObs2.Text;
                objHangarBE.activo = Convert.ToInt16(chkActivo2.Checked);
                objHangarBE.usu_ult_modificacion = clsCredenciales.Usuario;

                if (objHangar.ActualizarHangar(objHangarBE) == true)
                {
                    if (copyToPath != "")
                    {
                        // Copy the file
                        if (File.Exists(copyToPath) != true)
                        {
                            File.Copy(fullFilePath, copyToPath);
                        }

                        if (File.Exists(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"]))))
                        {
                            File.Delete(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"])));
                            Session["extension2"] = "";
                            Session["imageTemp2"] = "";
                        }
                    }

                    dtv = new DataView(ConvertToDataTable(objHangar.ListarHangar2()));
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
                    CargarGraficas();
                }
                else
                {
                    throw new Exception("No se actualizo el registro. COntacte con IT.");
                }


            }
            catch (Exception ex)
            {

                lblMensajeAct.Text = ex.Message;
                PopMant2.Show();// para mantener el popup abierto tras el clic en Grabar

            }
        }

        protected void grvLuces_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvLuces.PageIndex = e.NewPageIndex;
            dtv = new DataView(ConvertToDataTable(objHangar.ListarHangar2()));
            Session["Vista"] = dtv;
            CargarDatos(txtFiltro.Text);
            CargarGraficas();
        }

        protected void grvLuces_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Int16 fila = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName == "Editar")
                {

                    //lblMensajeAct.Text = (objHangarBE.id).ToString();
                    String strCod = grvLuces.Rows[fila].Cells[1].Text;

                    objHangarBE = objHangar.ConsultarHangar(Convert.ToInt16(strCod));
                    txtid.Text = (objHangarBE.id).ToString();
                    txtPiso2.Text = Convert.ToString(objHangarBE.piso);
                    txtObs2.Text = objHangarBE.obs;
                    txtArea2.Text = objHangarBE.area;
                    ImageUpload2.ImageUrl = objHangarBE.imagen;
                    chkActivo2.Checked = Convert.ToBoolean(objHangarBE.activo);


                    DataTable dt2 = ConvertToDataTable(objModelo.ListarModelos2());
                    cboEquipo2.DataSource = dt2;
                    cboEquipo2.DataValueField = "id";
                    cboEquipo2.DataTextField = "nom_equipo";
                    cboEquipo2.DataBind();
                    cboEquipo2.SelectedValue = (objHangarBE.equipo).ToString();

                    cboEstado2.SelectedValue = objHangarBE.estado;


                    PopMant2.Show();
                }

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        protected void cboEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMant.Show();
        }

        protected void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMant.Show();
        }

        protected void cboEquipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMant2.Show();
        }

        protected void cboEstado2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMant2.Show();
        }

     
        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                String rutaarchivo = Server.MapPath("/") + @"\Plantillas\ListadoLucesHangar.xlsx";
                DataTable dtProductos = new DataTable();
                dtProductos = ConvertToDataTable(objHangar.ListarHangar2());

                Int16 fila1 = 5;

                using (var pck = new OfficeOpenXml.ExcelPackage(new FileInfo(rutaarchivo)))
                {
                      
                    String filename = "ListaLucesHangar." + DateTime.Today.ToShortDateString();
                    ExcelWorksheet ws = pck.Workbook.Worksheets["Hoja1"];

                    foreach (DataRow drProducto in dtProductos.Rows)
                    {
                        ws.Cells[fila1, 1].Value = Convert.ToInt16(drProducto["id"]);
                        ws.Cells[fila1, 2].Value = Convert.ToInt16(drProducto["piso"]);
                        ws.Cells[fila1, 3].Value = drProducto["area"].ToString();
                        ws.Cells[fila1, 4].Value = drProducto["marca"].ToString();
                        ws.Cells[fila1, 5].Value = drProducto["modelo"].ToString();
                        ws.Cells[fila1, 6].Value = drProducto["tipo"].ToString();
                        ws.Cells[fila1, 7].Value = drProducto["estado"].ToString();
                        ws.Cells[fila1, 8].Value = drProducto["obs"].ToString();
                        if (Convert.ToInt16(drProducto["piso"]) == 1)
                        {
                            ws.Cells[fila1, 9].Value = "Activo";
                        }
                        else
                        {
                            ws.Cells[fila1, 9].Value = "Inactivo";
                        }
                        fila1 += 1;
                    }

                    ws.Column(1).Width = 8;
                    ws.Column(2).Width = 8;
                    ws.Column(3).Width = 60;
                    ws.Column(4).Width = 40;
                    ws.Column(5).Width = 40;
                    ws.Column(6).Width = 40;
                    ws.Column(7).Width = 50;
                    ws.Column(8).Width = 80;
                    ws.Column(9).Width = 40;

                    //Escribir de nuevo al cliente y descargar el archivo desde el navegador
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=" + filename + ".xlsx");
                    using (var memoryStream = new MemoryStream())
                    {
                        pck.SaveAs(memoryStream);
                        memoryStream.WriteTo(Response.OutputStream);
                    }
                    Response.End();

                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;

            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

            if (File.Exists(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"]))))
            {
                File.Delete(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"])));
                Session["extension"] = "";
                Session["imageTemp"] = "";
            }
            if (File.Exists(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"]))))
            {
                File.Delete(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"])));
                Session["extension2"] = "";
                Session["imageTemp2"] = "";
            }

            String savePath = Server.MapPath("/") + @"Temp\";

            if (btnUpload.HasFile)
            {
                // Get the name of the file to upload.
                Session["imageTemp"]  = btnUpload.FileName;
                Session["extension"] = System.IO.Path.GetExtension((string)(Session["imageTemp"]));
                savePath += "temp"+ (string)(Session["extension"]);

                if (((string)(Session["extension"]) == ".jpg") || ((string)(Session["extension"]) == ".jpeg") || ((string)(Session["extension"]) == ".png"))
                {
                    btnUpload.SaveAs(savePath);
                    ImageUpload.ImageUrl = "~/Temp/" + "temp" + (string)(Session["extension"]);
                    lblMensajeIns.Text = "Tu imagen " + (string)(Session["imageTemp"]) + " fue cargado";
                    PopMant.Show();
                }
                else {
                    lblMensajeIns.Text = "Formato no admitido";
                    PopMant.Show();
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                lblMensajeIns.Text = "Imagen no pudo ser cargada";
                PopMant.Show();
            }
        }

        protected void btnPrev2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"]))))
            {
                File.Delete(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension"])));
                Session["extension"] = "";
                Session["imageTemp"] = "";
            }
            if (File.Exists(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"]))))
            {
                File.Delete(Server.MapPath(@"~\temp\" + "temp" + (string)(Session["extension2"])));
                Session["extension2"] = "";
                Session["imageTemp2"] = "";
            }


            String savePath = Server.MapPath("/") + @"Temp\";

            if (btnUpload2.HasFile)
            {
                // Get the name of the file to upload.
                Session["imageTemp2"] = btnUpload2.FileName;
                Session["extension2"] = System.IO.Path.GetExtension((string)(Session["imageTemp2"]));
                savePath += "temp" + (string)(Session["extension2"]);

                if (((string)(Session["extension2"]) == ".jpg") || ((string)(Session["extension2"]) == ".jpeg") || ((string)(Session["extension2"]) == ".png"))
                {
                    btnUpload2.SaveAs(savePath);
                    ImageUpload2.ImageUrl = "~/Temp/" + "temp" + (string)(Session["extension2"]);
                    lblMensajeAct.Text = "Tu imagen " + (string)(Session["imageTemp2"]) + " fue cargado";
                    PopMant2.Show();
                }
                else
                {
                    lblMensajeAct.Text = "Formato no admitido";
                    PopMant2.Show();
                }
            }
            else
            {
                // lblMensajeAct the user that a file was not uploaded.
                lblMensajeIns.Text = "Imagen no pudo ser cargada";
                PopMant2.Show();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void cboConsultaEst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Text = "";
                cboConsultaTipo.SelectedValue = Convert.ToString(0);
                dtv = (DataView)Session["Vista"];
                if (cboConsultaEst.SelectedValue.ToString() != "0")
                {
                    dtv.RowFilter = "estado like '" + cboConsultaEst.SelectedValue.ToString() + "'";
                }
                else {
                    dtv.RowFilter = "estado like '%" + "" + "%'";
                }
                grvLuces.DataSource = dtv;
                grvLuces.DataBind();
                CargarGraficas();

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        protected void cboConsultaTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Text = "";
                cboConsultaEst.SelectedValue = Convert.ToString(0);
                dtv = (DataView)Session["Vista"];
                if (cboConsultaTipo.SelectedValue.ToString() != "0")
                {
                    dtv.RowFilter = "tipo like '%" + cboConsultaTipo.SelectedValue.ToString() + "%'";
                }
                else
                {
                    dtv.RowFilter = "tipo like '%" + "" + "%'";
                }
                grvLuces.DataSource = dtv;
                grvLuces.DataBind();
                CargarGraficas();
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        public void CargarGraficas()
        {
            dt = ConvertToDataTable(objHangar.ListarHangar2());
            #region Estados
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

            Chart1.Series.Add("Estados");
            Chart1.Series["Estados"].Points.DataBindXY(estados, cantidadEst);
            Chart1.Series["Estados"].BorderWidth = 10;
            //setting Chart type   
            Chart1.Series["Estados"].IsValueShownAsLabel = true;



            #endregion Estados
            #region Tecnologia

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

            Chart2.Series.Add("Tecnologia");
            Chart2.Series["Tecnologia"].Points.DataBindXY(tipos, cantidadTip);
            Chart2.Series["Tecnologia"].IsValueShownAsLabel = true;
            #endregion Tecnologia

            #region marca
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

            Chart3.Series.Add("Marca");
            Chart3.Series["Marca"].Points.DataBindXY(marcas, cantidadMarc);
            Chart3.Series["Marca"].IsValueShownAsLabel = true;
            #endregion marca


        }


    }
}