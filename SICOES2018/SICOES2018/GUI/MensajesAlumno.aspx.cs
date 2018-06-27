using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class MensajesAlumno : System.Web.UI.Page
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
                datoAlum.IDAlumno = Convert.ToInt32(Session["IDUserLoged"]);
                LlenarGVMaestros(Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDGrupo", datoAlum)));
                LlenarGVMensajes(Convert.ToInt32(Session["IDUserLoged"]));
            }

        }
        protected void LlenarGVMaestros(int IDGrupo)
        {
            gvMaestros.DataSource = ejecMsg.LlenarGVMaestros(IDGrupo);
            gvMaestros.DataBind();
        }

        protected void LlenarGVMensajes(int IDAlumno)
        {
            gvMensajes.DataSource = ejecMsg.LlenarGVMensajesAlumno(IDAlumno);
            gvMensajes.DataBind();
        }

        protected void gvMaestros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMaestros.PageIndex = e.NewPageIndex;
            datoAlum.IDAlumno = Convert.ToInt32(Session["IDUserLoged"]);
            LlenarGVMaestros(Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDGrupo", datoAlum)));
            upGrupos.Update();

        }

        protected void gvMaestros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            if (currentCommand == "SelectMaestro")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["MaestroMensajeID"] = Convert.ToInt32(gvMaestros.DataKeys[currentRowIndex].Value);
                upModal.Update();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OpenModalNewMsg()", true);
            }
        }

        protected void gvMensajes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMaestros.PageIndex = e.NewPageIndex;
            LlenarGVMensajes(Convert.ToInt32(Session["IDUserLoged"]));
            upMensajes.Update();

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

        protected void btnEnviarMsg_Click(object sender, EventArgs e)
        {
            datoMsg.IDRemitente = Convert.ToInt32(Session["IDUserLoged"]);
            datoMsg.IDDestinatario = Convert.ToInt32(Session["MaestroMensajeID"]);
            datoMsg.Asunto = txtAsunto.Text;
            datoMsg.Mensaje = txtMensaje.Text;
            ejecMsg.agregarMensaje(datoMsg);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

        }
    }
}