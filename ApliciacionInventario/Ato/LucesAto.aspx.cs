using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ApliciacionInventario.ProxyAto;
using ApliciacionInventario.ProxyModelo;
using ApliciacionInventario.Usuario;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using System.IO;

namespace ApliciacionInventario.Ato
{
    public partial class LucesAto : System.Web.UI.Page
    {
        ProxyAto.ServiceAtoClient objAto = new ProxyAto.ServiceAtoClient();
        ProxyAto.AtoBE objAtoBE = new ProxyAto.AtoBE(); 
        ProxyModelo.ServiceModeloClient objModelo = new ProxyModelo.ServiceModeloClient();
        ProxyModelo.ModeloBE onjModeloBE = new ProxyModelo.ModeloBE();
        DataView dtv;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    dtv = new DataView(ConvertToDataTable(objAto.ListarAto2()));
                    Session["Vista"] = dtv;
                    CargarDatos("");

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
                ImageUpload.ImageUrl = null;
                txtPiso.Focus();
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
                var copyToPath = Server.MapPath(@"~\Ato\Fotos\" + (string)(Session["imageTemp"]));

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
                if (((string)(Session["extension"])) == "" || (string)(Session["imageTemp"]) == "")
                {
                    copyToPath = "";
                }

                objAtoBE.piso = Convert.ToInt16(txtPiso.Text);
                objAtoBE.area = txtArea.Text;
                objAtoBE.equipo = Convert.ToInt16(cboEquipo.SelectedValue.ToString());
                objAtoBE.estado = cboEstado.SelectedValue.ToString();
                objAtoBE.obs = txtObs.Text;
                objAtoBE.imagen = "~\\Ato\\Fotos\\" + (string)(Session["imageTemp"]);
                objAtoBE.activo = Convert.ToInt16(chkActivo.Checked);
                objAtoBE.usu_registro = clsCredenciales.Usuario;

                if (objAto.InsertarAto(objAtoBE) == true)
                {
                    if (copyToPath != "")
                    {
                        // Copy the file
                        if (File.Exists(copyToPath) != true)
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
                    dtv = new DataView(ConvertToDataTable(objAto.ListarAto2()));
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
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
                var copyToPath = Server.MapPath(@"~\Ato\Fotos\" + (string)(Session["imageTemp2"]));
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

                    objAtoBE.imagen = "~\\Ato\\Fotos\\" + (string)(Session["imageTemp2"]);
                }
                else
                {
                    objAtoBE = objAto.ConsultarAto(Convert.ToInt16(Convert.ToInt16(txtid.Text)));

                }

                objAtoBE.id = Convert.ToInt16(txtid.Text);
                objAtoBE.piso = Convert.ToInt16(txtPiso2.Text);
                objAtoBE.area = txtArea2.Text;
                objAtoBE.equipo = Convert.ToInt16(cboEquipo2.SelectedValue.ToString());
                objAtoBE.estado = cboEstado2.SelectedValue.ToString();
                objAtoBE.obs = txtObs2.Text;
                objAtoBE.activo = Convert.ToInt16(chkActivo2.Checked);
                objAtoBE.usu_ult_modificacion = clsCredenciales.Usuario;

                if (objAto.ActualizarAto(objAtoBE) == true)
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
                    dtv = new DataView(ConvertToDataTable(objAto.ListarAto2()));
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
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
            dtv = new DataView(ConvertToDataTable(objAto.ListarAto2()));
            Session["Vista"] = dtv;
            CargarDatos(txtFiltro.Text);
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

                    objAtoBE = objAto.ConsultarAto(Convert.ToInt16(strCod));
                    txtid.Text = (objAtoBE.id).ToString();
                    txtPiso2.Text = Convert.ToString(objAtoBE.piso);
                    txtObs2.Text = objAtoBE.obs;
                    txtArea2.Text = objAtoBE.area;
                    chkActivo2.Checked = Convert.ToBoolean(objAtoBE.activo);


                    DataTable dt2 = ConvertToDataTable(objModelo.ListarModelos2());
                    cboEquipo2.DataSource = dt2;
                    cboEquipo2.DataValueField = "id";
                    cboEquipo2.DataTextField = "nom_equipo";
                    cboEquipo2.DataBind();
                    cboEquipo2.SelectedValue = (objAtoBE.equipo).ToString();

                    cboEstado2.SelectedValue = objAtoBE.estado;


                    PopMant2.Show();
                }

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                String rutaarchivo = Server.MapPath("/") + @"\Plantillas\ListadoLucesAto.xlsx";
                DataTable dtProductos = new DataTable();
                dtProductos = ConvertToDataTable(objAto.ListarAto2());

                Int16 fila1 = 5;

                using (var pck = new OfficeOpenXml.ExcelPackage(new FileInfo(rutaarchivo)))
                {

                    String filename = "ListaLucesAto." + DateTime.Today.ToShortDateString();
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
                Session["imageTemp"] = btnUpload.FileName;
                Session["extension"] = System.IO.Path.GetExtension((string)(Session["imageTemp"]));
                savePath += "temp" + (string)(Session["extension"]);

                if (((string)(Session["extension"]) == ".jpg") || ((string)(Session["extension"]) == ".jpeg") || ((string)(Session["extension"]) == ".png"))
                {
                    btnUpload.SaveAs(savePath);
                    ImageUpload.ImageUrl = "~/Temp/" + "temp" + (string)(Session["extension"]);
                    lblMensajeIns.Text = "Tu imagen " + (string)(Session["imageTemp"]) + " fue cargado";
                    PopMant.Show();
                }
                else
                {
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
                else
                {
                    dtv.RowFilter = "estado like '%" + "" + "%'";
                }
                grvLuces.DataSource = dtv;
                grvLuces.DataBind();

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

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }


    }
}