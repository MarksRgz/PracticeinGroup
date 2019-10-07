using Digipro.AspArquitectura.Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspArquitectura
{
    public partial class Proyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCombosProyectos();
            }
            gvProyectos.DataSource = new BusGlobal().GetProyectos();
            gvProyectos.DataBind();
        }
        private void LlenarCombosProyectos()
        {
            try
            {
                ddlProyectos.DataSource = new BusGlobal().GetProyectosCombo();
                ddlProyectos.DataTextField = "nombre_proyecto";
                ddlProyectos.DataValueField = "id_proyecto";
                ddlProyectos.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
        private void MostrarMensaje(string mensaje)
        {
            string alerta = $"{mensaje}";
            ScriptManager.RegisterStartupScript(this, GetType(), "error", alerta, true);
        }
        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlProyectos.SelectedValue != "" && ddlProyectos.SelectedValue != null)
                {
                    int idProyecto = Convert.ToInt32(ddlProyectos.SelectedValue);

                    Proyecto proye = new BusGlobal().GetProyecto(idProyecto);
                    proye.fecha_proyecto = DateTime.Now;
                    txtNombre.Text = proye.nombre_proyecto;
                    txtId.Value = proye.id_proyecto.ToString();
                    txtDescripcion.Text = proye.desc_proyecto;
                    txtImg.Text = proye.img_proyecto.ToString();
                    //txtDate.Text = proye.fecha_proyecto.ToDate.Now();
                    txtCosto.Text = proye.costo_proyecto.ToString();
                    BtnGuardar.Text = "Actualizar";
                    BtnDelete.Visible = true;
                }
                else
                {
                    txtNombre.Text = "";
                    txtId.Value = "";
                    txtDescripcion.Text = "";

                    //txtDate.Text = "";
                    txtCosto.Text = "";
                    BtnGuardar.Text = "Guardar";
                    BtnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //decimal costo = txtCosto.Text != "" && txtCosto != null ? Convert.ToDecimal(txtCosto.Text) : 0;
            try
            {
                if (FU.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FU.FileName);
                    ext = ext.ToLower();
                    FU.SaveAs(Server.MapPath("~/img/" + FU.FileName));
                    Response.Write("Se subió el archivo");
                }
                Proyecto proye = new Proyecto()
                {
                    //id_proyecto = Convert.ToInt32(txtId.Value),
                    nombre_proyecto = txtNombre.Text,
                    desc_proyecto = txtDescripcion.Text,
                    img_proyecto = FU.FileName,
                    fecha_proyecto = Convert.ToDateTime(txtDate.Text),
                    costo_proyecto = Convert.ToInt32(txtCosto.Text)
                };
                if (txtId.Value == "" || txtId.Value == null)
                {
                    new BusGlobal().CreateProyecto(proye);
                    Response.Redirect("Proyectos.aspx", false);
                }
                else
                {
                    proye.id_proyecto = Convert.ToInt32(txtId.Value);
                    new BusGlobal().UpdateProyecto(proye);
                    Response.Redirect("Proyectos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Proyecto proye = new Proyecto()
            {
                nombre_proyecto = txtNombre.Text,
                desc_proyecto = txtDescripcion.Text,
                img_proyecto = FU.FileName,
                fecha_proyecto = Convert.ToDateTime(txtDate.Text),
                costo_proyecto = Convert.ToDecimal(txtCosto.Text)
            };
            proye.id_proyecto = Convert.ToInt32(txtId.Value);
            new BusGlobal().DeleteProyecto(proye);
            Response.Redirect("Proyectos.aspx", false);
        }

    }
}