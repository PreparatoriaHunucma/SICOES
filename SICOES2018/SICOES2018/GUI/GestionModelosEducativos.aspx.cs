using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SICOES2018.BO;
using SICOES2018.DAO;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class GestionModelosEducativos : System.Web.UI.Page
    {
        PlanesEstudioBO datoPlan = new PlanesEstudioBO();
        PlanesEstudioDAO ejecPlan = new PlanesEstudioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDDLPlanEstudios();
            }
        }

        protected void LlenarDDLPlanEstudios()
        {
            ddlPlan.Items.Clear();
            ddlPlan.DataSource = ejecPlan.llenarDDL();
            ddlPlan.DataTextField = "Nombre";
            ddlPlan.DataValueField = "IDPlanEstudios";
            ddlPlan.DataBind();
        }

        protected void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            datoPlan.Nombre = txtNomPlan.Text;
            datoPlan.Status = 1;
            ejecPlan.agregarPlanEstudio(datoPlan);
            txtNomPlan.Text = String.Empty;
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            LlenarDDLPlanEstudios();
            upBotones.Update();
        }

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnModifPlan.Visible = true;
            //btnElimfPlan.Visible = true;
            txtNomPlan.Text = ddlPlan.SelectedItem.Text;
            
        }

        protected void btnModifPlan_Click(object sender, EventArgs e)
        {
            datoPlan.Nombre = txtNomPlan.Text;
            datoPlan.IDPlanEstudios = Convert.ToInt32(ddlPlan.SelectedValue);
            ejecPlan.modificarInfoPlanEstudio(datoPlan);
            txtNomPlan.Text = String.Empty;
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);
            LlenarDDLPlanEstudios();
            upBotones.Update();
        }

        protected void btnElimfPlan_Click(object sender, EventArgs e)
        {
            datoPlan.Nombre = txtNomPlan.Text;
            datoPlan.IDPlanEstudios = Convert.ToInt32(ddlPlan.SelectedValue);
            ejecPlan.eliminarPlanEstudio(datoPlan);
            txtNomPlan.Text = String.Empty;
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deletealert();", true);
            LlenarDDLPlanEstudios();
            upBotones.Update();
        }
    }
}