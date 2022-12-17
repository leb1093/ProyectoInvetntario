using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ApliciacionInventario.ProxyModelo;
using ApliciacionInventario.Usuario;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ApliciacionInventario.Modelos
{
    public partial class ListaLuces : System.Web.UI.Page
    {
        ProxyModelo.ServiceModeloClient objModelo = new ProxyModelo.ServiceModeloClient();
        ProxyModelo.ModeloBE objModeloBE = new ProxyModelo.ModeloBE();
        DataView dtv;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                if (Page.IsPostBack == false)
                {

                    dtv = new DataView(ConvertToDataTable(objModelo.ListarModelos()));
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
            dtv.RowFilter = "marca like '%" + strFiltro + "%'";
            grvModelo.DataSource = dtv;
            grvModelo.DataBind();

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
                txtMarcaLuz.Text = "";
                txtModeloLuz.Text = "";
                CargarTipoLuz(0);

                PopMant.Show();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        private void CargarTipoLuz(Int16 IdCate)
        {

            cboTipo.SelectedValue = Convert.ToString(IdCate);



        }

        protected void btnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarDatos(txtFiltro.Text);

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
                if (txtMarcaLuz.Text == "")
                {
                    throw new Exception("La marca del equipo es obligatorio");
                }
                if (txtModeloLuz.Text == "")
                {
                    throw new Exception("Ingrese el modelo del equipo");
                }
                if (cboTipo.SelectedValue.ToString() == "0")
                {
                    throw new Exception("Seleccione el tipo de luz");
                }

                objModeloBE.marca = txtModeloLuz.Text;
                objModeloBE.modelo = txtMarcaLuz.Text;
                objModeloBE.tipo = cboTipo.SelectedValue.ToString();
                objModeloBE.usu_registro = clsCredenciales.Usuario;

                if (objModelo.InsertarModelo(objModeloBE) == true)
                {
                    dtv = new DataView(ConvertToDataTable(objModelo.ListarModelos()));
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
                if (txtMarca2.Text == "")
                {
                    throw new Exception("La marca del equipo es obligatorio");
                }
                if (txtModelo2.Text == "")
                {
                    throw new Exception("Ingrese el modelo del equipo");
                }
                if (cboTipo2.SelectedValue.ToString() == "0")
                {
                    throw new Exception("Seleccione el tipo de luz");
                }

                objModeloBE.id = Convert.ToInt16(txtId.Text);
                objModeloBE.marca = txtMarca2.Text;
                objModeloBE.modelo = txtModelo2.Text;
                objModeloBE.tipo = cboTipo2.SelectedValue.ToString();
                objModeloBE.usu_ult_modificacion = clsCredenciales.Usuario;

                if (objModelo.ActualizarModelo(objModeloBE) == true)
                {
                    dtv = new DataView(ConvertToDataTable(objModelo.ListarModelos()));
                    Session["Vista"] = dtv;
                    CargarDatos(txtFiltro.Text);
                }
                else
                {
                    throw new Exception("No se actualizo el registro. Contacte con IT.");
                }


            }
            catch (Exception ex)
            {

                lblMensajeAct.Text = ex.Message;
                PopMant2.Show();// para mantener el popup abierto tras el clic en Grabar

            }
        }

     

        protected void grvModelo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Int16 fila = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName == "Editar")
                {

                    //lblMensajeAct.Text = (objHangarBE.id).ToString();
                    String strCod = grvModelo.Rows[fila].Cells[1].Text;

                    objModeloBE = objModelo.ConsultarModelo(Convert.ToInt16(strCod));
                    txtId.Text = (objModeloBE.id).ToString();
                    txtMarca2.Text = Convert.ToString(objModeloBE.marca);
                    txtModelo2.Text = objModeloBE.modelo;
                                        
                    cboTipo2.SelectedValue = (objModeloBE.tipo).ToString();
                                 

                    PopMant2.Show();
                }

            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
                mpeMensaje.Show();
            }
        }

        protected void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMant.Show();
        }

        protected void cboTipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopMant2.Show();
        }

        protected void grvModelo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvModelo.PageIndex = e.NewPageIndex;
            dtv = new DataView(ConvertToDataTable(objModelo.ListarModelos()));
            Session["Vista"] = dtv;
            CargarDatos(txtFiltro.Text);
        }
    }
}