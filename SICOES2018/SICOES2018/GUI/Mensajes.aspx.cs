using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class Mensajes : System.Web.UI.Page
    {
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();
        MensajesBO datoMsg = new MensajesBO();
        MensajesDAO ejecMsg = new MensajesDAO();
        AlumnosBO datoAlum = new AlumnosBO();
        AlumnosDAO ejecAlum = new AlumnosDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LlenarDDLPeriodo();
                ddlPeriodo.SelectedIndex = 0;
                LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodo.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarGVMensajes(Convert.ToInt32(Session["IDUserLoged"]));
            }

        }

        protected void LlenarDDLPeriodo()
        {
            ddlPeriodo.Items.Clear();
            ddlPeriodo.DataSource = ejecPer.llenarDDLCicloActivo();
            ddlPeriodo.DataTextField = "Nombre";
            ddlPeriodo.DataValueField = "IDPeriodo";
            ddlPeriodo.DataBind();
            if (ddlPeriodo.Items.Count != 0)
            {
                LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodo.SelectedValue));
            }
        }

        protected void LlenarDDLGrupo(int IDMaestro, int Periodo)
        {
            ddlGrupo.Items.Clear();
            ddlGrupo.DataSource = ejecGrupo.llenarDDLMaestros(Periodo, IDMaestro);
            ddlGrupo.DataTextField = "NombreGrupo";
            ddlGrupo.DataValueField = "IDGrupo";
            ddlGrupo.DataBind();
            if (ddlGrupo.Items.Count != 0)
            {
                LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));
            }
        }
        protected void LlenarGVAlum(int IDGrupo)
        {
            gvAlumnos.DataSource = ejecGrupo.LlenarGVAlumnosXGrupos(IDGrupo);
            gvAlumnos.DataBind();
        }

        protected void LlenarGVMensajes(int IDMaestro)
        {
            gvMensajes.DataSource = ejecMsg.LlenarGVMensajes(IDMaestro);
            gvMensajes.DataBind();
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodo.SelectedValue));

        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));

        }

        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));
            upGrupos.Update();
        }



        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            if (currentCommand == "SelectAlum1")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AlumnoMensajeID"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                upModal.Update();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OpenModalNewMsg()", true);
            }

        }

        protected void btnEnviarMsg_Click(object sender, EventArgs e)
        {
            datoMsg.IDRemitente = Convert.ToInt32(Session["IDUserLoged"]);
            datoMsg.IDDestinatario = Convert.ToInt32(Session["AlumnoMensajeID"]);
            datoMsg.Asunto = txtAsunto.Text;
            datoMsg.Mensaje = txtMensaje.Text;
            ejecMsg.agregarMensaje(datoMsg);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }

        protected void btnNewMsgTodos_Click(object sender, EventArgs e)
        {
            upModalGrupo.Update();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OpenModalNewMsgGrupo()", true);
        }

        protected void btnEnviarMsgGrupo_Click(object sender, EventArgs e)
        {
            DataTable tblAlumno = ejecAlum.ObtenerIDGrupo(Convert.ToInt32(ddlGrupo.SelectedValue));
            foreach (DataRow rowa in tblAlumno.Rows)
            {
                datoMsg.IDRemitente = Convert.ToInt32(Session["IDUserLoged"]);
                datoMsg.IDDestinatario = Convert.ToInt32(rowa.ItemArray.GetValue(0));
                datoMsg.Asunto = txtAsuntoGrupo.Text;
                datoMsg.Mensaje = txtMensajeGrupo.Text;
                ejecMsg.agregarMensaje(datoMsg);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }

        protected void gvMensajes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMensajes.PageIndex = e.NewPageIndex;
            LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));
            upGrupos.Update();

        }

        protected void gvMensajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            if (currentCommand == "SelectMsg")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["MensajeID"] = Convert.ToInt32(gvMensajes.DataKeys[currentRowIndex].Value);
                datoMsg.IDMensaje = Convert.ToInt32(Session["MensajeID"]);
                txtAsuntoVerMsg.Text = ejecMsg.buscarDatoMensaje("Asunto", datoMsg);
                txtMensajeVerMsg.Text = ejecMsg.buscarDatoMensaje("Mensaje", datoMsg);
                upModalVerMsg.Update();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OpenModalVerMsg()", true);
            }

        }
    }
}