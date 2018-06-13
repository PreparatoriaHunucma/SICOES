using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using SICOES2018.Reports;

namespace SICOES2018.GUI
{
    public partial class GestionConcentradoCalificaciones : System.Web.UI.Page
    {
        CalificacionesBO datoCalif = new CalificacionesBO();
        CalificacionesDAO ejecCalif = new CalificacionesDAO();
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();
        AsignaturasBO datoAsig = new AsignaturasBO();
        AsignaturasDAO ejecAsig = new AsignaturasDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LlenarDDLPeriodo();
                ddlPeriodoCalif.SelectedIndex = 0;
                LlenarDDLGrupo(Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarDDLAsignatura(Convert.ToInt32(ddlGrupo.SelectedValue));
                ddlAsignatura.SelectedIndex = 0;
                LlenarGVCalif(Convert.ToInt32(ddlGrupo.SelectedValue), Convert.ToInt32(ddlAsignatura.SelectedValue));
            }

        }

        protected void LlenarDDLPeriodo()
        {
            ddlPeriodoCalif.Items.Clear();
            ddlPeriodoCalif.DataSource = ejecPer.llenarDDLCicloActivo();
            ddlPeriodoCalif.DataTextField = "Nombre";
            ddlPeriodoCalif.DataValueField = "IDPeriodo";
            ddlPeriodoCalif.DataBind();
            if (ddlPeriodoCalif.Items.Count != 0)
            {
                LlenarDDLGrupo(Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
            }
        }

        protected void LlenarDDLGrupo(int Periodo)
        {
            ddlGrupo.Items.Clear();
            ddlGrupo.DataSource = ejecGrupo.llenarDDL(Periodo);
            ddlGrupo.DataTextField = "NombreGrupo";
            ddlGrupo.DataValueField = "IDGrupo";
            ddlGrupo.DataBind();
            if (ddlGrupo.Items.Count != 0)
            {
                LlenarDDLAsignatura(Convert.ToInt32(ddlGrupo.SelectedValue));
            }
        }

        protected void LlenarDDLAsignatura(int IDGrupo)
        {
            ddlAsignatura.Items.Clear();
            ddlAsignatura.DataSource = ejecAsig.LlenarDDL(IDGrupo);
            ddlAsignatura.DataTextField = "NomAsig";
            ddlAsignatura.DataValueField = "IDAsignatura";
            ddlAsignatura.DataBind();
        }

        protected void LlenarGVCalif(int IDGrupo, int IDAsignatura)
        {
            gvConCalif.DataSource = ejecCalif.LlenarGVConcCalif(IDGrupo, IDAsignatura);
            gvConCalif.DataBind();
        }

        protected void ddlPeriodoCalif_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupo(Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLAsignatura(Convert.ToInt32(ddlGrupo.SelectedValue));
        }

        protected void ddlAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVCalif(Convert.ToInt32(ddlGrupo.SelectedValue), Convert.ToInt32(ddlAsignatura.SelectedValue));
        }

        protected void gvConCalif_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConCalif.PageIndex = e.NewPageIndex;
            LlenarGVCalif(Convert.ToInt32(ddlGrupo.SelectedValue), Convert.ToInt32(ddlAsignatura.SelectedValue));
            upConCalif.Update();

        }

        ConcentradoCalificaciones rprt = new ConcentradoCalificaciones();
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Session["GrupoReporteID"] = ddlGrupo.SelectedValue;
            Session["AsigReporteID"] = ddlAsignatura.SelectedValue;
            Response.Redirect("~/Reports/ConcentradoCalificaciones");

        }

    }
}