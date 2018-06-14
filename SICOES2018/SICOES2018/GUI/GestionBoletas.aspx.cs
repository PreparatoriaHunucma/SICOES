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
    public partial class GestionBoletas : System.Web.UI.Page
    {
        CalificacionesBO datoCalif = new CalificacionesBO();
        CalificacionesDAO ejecCalif = new CalificacionesDAO();
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();
        AsignaturasBO datoAsig = new AsignaturasBO();
        AsignaturasDAO ejecAsig = new AsignaturasDAO();
        MomentoCalificacionBO datoMom = new MomentoCalificacionBO();
        MomentoCalificacionDAO ejecMom = new MomentoCalificacionDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LlenarDDLPeriodo();
                ddlPeriodo.SelectedIndex = 0;
                LlenarDDLGrupo(Convert.ToInt32(ddlPeriodo.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));
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
                LlenarDDLGrupo(Convert.ToInt32(ddlPeriodo.SelectedValue));
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
                LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));
            }
        }
        protected void LlenarGVAlum(int IDGrupo)
        {
            gvAlumnos.DataSource = ejecGrupo.LlenarGVAlumnosXGrupos(IDGrupo);
            gvAlumnos.DataBind();
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
                Session["AlumnoReporteID"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                Session["MomentoReporteID"] = 1;
                Session["GrupoReporteID"] = ddlGrupo.SelectedValue;
                Response.Redirect("~/Reports/BoletaParcial");
            }
            if (currentCommand == "SelectAlum2")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AlumnoReporteID"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                Session["MomentoReporteID"] = 2;
                Session["GrupoReporteID"] = ddlGrupo.SelectedValue;
                Response.Redirect("~/Reports/BoletaParcial");
            }
            if (currentCommand == "SelectAlum3")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AlumnoReporteID"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                Session["MomentoReporteID"] = 3;
                Session["GrupoReporteID"] = ddlGrupo.SelectedValue;
                Response.Redirect("~/Reports/BoletaParcial");
            }
            if (currentCommand == "SelectAlumTodos")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AlumnoReporteID"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                Session["GrupoReporteID"] = ddlGrupo.SelectedValue;
                Response.Redirect("~/Reports/BoletaTodos");
            }
            if (currentCommand == "SelectAlum3Semestre")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AlumnoReporteID"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);

            }


        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupo(Convert.ToInt32(ddlPeriodo.SelectedValue));

        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVAlum(Convert.ToInt32(ddlGrupo.SelectedValue));
        }
    }
}