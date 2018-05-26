using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICOES2018.BO;
using SICOES2018.DAO;

namespace SICOES2018.GUI
{
    public partial class GestionGrupos : System.Web.UI.Page
    {
        CicloEscolarBO datoCiclo = new CicloEscolarBO();
        CicloEscolarDAO ejecCiclo = new CicloEscolarDAO();
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        SemestresBO datoSem = new SemestresBO();
        SemestresDAO ejecSem = new SemestresDAO();
        PlanesEstudioBO datoPlan = new PlanesEstudioBO();
        PlanesEstudioDAO ejecPlan = new PlanesEstudioDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDownCicloAddGrupo();
                LlenarDropDownListPeriodoAddGrupo(Convert.ToInt32(ddlCicloGrupo.SelectedValue));
                LlenarDropDownListSemestreAddGrupo(ddlPeriodoGrupo.SelectedItem.ToString());
                LlenarDropDownListPlanEstudioAddGrupo();
                LlenarGridViewGrupos(Convert.ToInt32(ddlCicloGrupo.SelectedValue), Convert.ToInt32(ddlPeriodoGrupo.SelectedValue));
            }
        }

        protected void LlenarDropDownCicloAddGrupo()
        {
            ddlCicloGrupo.DataSource = ejecCiclo.llenarDDL();
            ddlCicloGrupo.DataTextField = "Nombre";
            ddlCicloGrupo.DataValueField = "IDCicloEscolar";
            ddlCicloGrupo.DataBind();
            if (ddlCicloGrupo.Items.Count != 0)
            {
                int IDCiclo = Convert.ToInt32(ddlCicloGrupo.SelectedValue);
                LlenarDropDownListPeriodoAddGrupo(IDCiclo);
            }
        }
        protected void LlenarDropDownListPeriodoAddGrupo(int IDCiclo)
        {
            ddlPeriodoGrupo.Items.Clear();
            ddlPeriodoGrupo.DataSource = ejecPer.llenarDDL(IDCiclo);
            ddlPeriodoGrupo.DataTextField = "Nombre";
            ddlPeriodoGrupo.DataValueField = "IDPeriodo";
            ddlPeriodoGrupo.DataBind();
            if (ddlPeriodoGrupo.Items.Count != 0)
            {
                string Periodo = ddlPeriodoGrupo.SelectedItem.ToString();
                LlenarDropDownListSemestreAddGrupo(Periodo);
            }
        }
        protected void LlenarDropDownListSemestreAddGrupo(string Periodo)
        {
            if (Periodo == "Primer Periodo")
            {
                ddlSemestreGrupo.Items.Clear();
                ddlSemestreGrupo.DataSource = ejecSem.llenarDDLImpar();
                ddlSemestreGrupo.DataTextField = "Nombre";
                ddlSemestreGrupo.DataValueField = "IDSemestre";
                ddlSemestreGrupo.DataBind();
            }
            else
            {
                ddlSemestreGrupo.Items.Clear();
                ddlSemestreGrupo.DataSource = ejecSem.llenarDDLPar();
                ddlSemestreGrupo.DataTextField = "Nombre";
                ddlSemestreGrupo.DataValueField = "IDSemestre";
                ddlSemestreGrupo.DataBind();

            }

        }
        protected void LlenarDropDownListPlanEstudioAddGrupo()
        {
            ddlPlanGrupo.DataSource = ejecPlan.llenarDDL();
            ddlPlanGrupo.DataTextField = "Nombre";
            ddlPlanGrupo.DataValueField = "IDPlanEstudios";
            ddlPlanGrupo.DataBind();
        }
        protected void LimpiarCamposAddGrupo()
        {
            txtNomGrupo.Text = string.Empty;
            //ddlCicloGrupo.SelectedIndex = 0;
            //ddlPlanGrupo.SelectedIndex = 0;
        }
        protected void LlenarGridViewGrupos(int IDCiclo, int IDPeriodo)
        {
            gvGrupos.DataSource = ejecGrupo.LlenarGridView(IDCiclo, IDPeriodo);
            gvGrupos.DataBind();
        }



        protected void ddlCicloGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDCiclo = Convert.ToInt32(ddlCicloGrupo.SelectedValue);
            LlenarDropDownListPeriodoAddGrupo(IDCiclo);
            LlenarGridViewGrupos(Convert.ToInt32(ddlCicloGrupo.SelectedValue), Convert.ToInt32(ddlPeriodoGrupo.SelectedValue));
        }

        protected void ddlPeriodoGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Periodo = ddlPeriodoGrupo.SelectedItem.ToString();
            LlenarDropDownListSemestreAddGrupo(Periodo);
            LlenarGridViewGrupos(Convert.ToInt32(ddlCicloGrupo.SelectedValue), Convert.ToInt32(ddlPeriodoGrupo.SelectedValue));
        }

        protected void btnAddGrupo_Click(object sender, EventArgs e)
        {
            if (txtNomGrupo.Text != string.Empty)
            {
                datoGrupo.NombreGrupo = txtNomGrupo.Text;
                datoGrupo.IDPeriodo = Convert.ToInt32(ddlPeriodoGrupo.SelectedValue);
                datoGrupo.IDPlanEstudio = Convert.ToInt32(ddlPlanGrupo.SelectedValue);
                datoGrupo.IDSemestre = Convert.ToInt32(ddlSemestreGrupo.SelectedValue);
                datoGrupo.Status = 1;
                ejecGrupo.agregarGrupo(datoGrupo);
                LimpiarCamposAddGrupo();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
            LlenarGridViewGrupos(Convert.ToInt32(ddlCicloGrupo.SelectedValue), Convert.ToInt32(ddlPeriodoGrupo.SelectedValue));
        }

        protected void btnModGrupo_Click(object sender, EventArgs e)
        {

        }

        protected void gvGrupos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGrupos.PageIndex = e.NewPageIndex;
            LlenarGridViewGrupos(Convert.ToInt32(ddlCicloGrupo.SelectedValue), Convert.ToInt32(ddlPeriodoGrupo.SelectedValue));
            upGrupos.Update();
        }

        protected void gvGrupos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}