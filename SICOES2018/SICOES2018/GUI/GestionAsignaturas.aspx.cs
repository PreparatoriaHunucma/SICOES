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
    public partial class GestionAsignaturas : System.Web.UI.Page
    {
        AsignaturasBO datoAsig = new AsignaturasBO();
        AsignaturasDAO ejecAsig = new AsignaturasDAO();
        SemestresBO datoSem = new SemestresBO();
        SemestresDAO ejecSem = new SemestresDAO();
        TipoAsignaturasBO datoTipAsig = new TipoAsignaturasBO();
        TipoAsignaturasDAO ejecTipAsig = new TipoAsignaturasDAO();
        ModalidadAsignaturasBO datoMod = new ModalidadAsignaturasBO();
        ModalidadAsignaturasDAO ejecMod = new ModalidadAsignaturasDAO();
        PlanesEstudioBO datoPlan = new PlanesEstudioBO();
        PlanesEstudioDAO ejecPlan = new PlanesEstudioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LLenarDDLModalidad();
                LlenarDDLPlanEstudios();
                LLenarDDLSemestre();
                LlenarDDLTipoAsig();
                LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));
            }

        }

        //Llenar gridviews y drop down lists
        protected void LlenarGVAsignaturas(int IDSemestre)
        {
            gvAsignaturas.DataSource = ejecAsig.LlenarGridView(IDSemestre);
            gvAsignaturas.DataBind();
        }
        protected void LLenarDDLSemestre()
        {
            ddlSemestre.Items.Clear();
            ddlSemestre.DataSource = ejecSem.llenarDDLTodos();
            ddlSemestre.DataTextField = "Nombre";
            ddlSemestre.DataValueField = "IDSemestre";
            ddlSemestre.DataBind();
            if (ddlSemestre.Items.Count != 0)
            {
                LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));
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
        protected void LlenarDDLTipoAsig()
        {
            ddlTipoAsig.Items.Clear();
            ddlTipoAsig.DataSource = ejecTipAsig.llenarDDL();
            ddlTipoAsig.DataTextField = "Nombre";
            ddlTipoAsig.DataValueField = "IDTipoAsig";
            ddlTipoAsig.DataBind();
        }
        protected void LLenarDDLModalidad()
        {
            ddlModalidad.Items.Clear();
            ddlModalidad.DataSource = ejecMod.llenarDDL();
            ddlModalidad.DataTextField = "Nombre";
            ddlModalidad.DataValueField = "IDModalidadAsig";
            ddlModalidad.DataBind();
        }


        protected void LimpiarCampos()
        {
            ddlSemestre.SelectedIndex = 0;
            ddlPlan.SelectedIndex = 0;
            ddlTipoAsig.SelectedIndex = 0;
            ddlModalidad.SelectedIndex = 0;
            txtNomAsig.Text = string.Empty;
            txtCreditosAsig.Text = string.Empty;
            txtRequisitos.Text = string.Empty;
            txtHorasPre.Text = string.Empty;
            txtHorasNoPre.Text = string.Empty;
            txtDuracion.Text = string.Empty;
        }


        protected void btnAddAsig_Click(object sender, EventArgs e)
        {
            if (txtNomAsig.Text != string.Empty)
            {
                datoAsig.NomAsig = txtNomAsig.Text;
                datoAsig.IDSemestreAsig = Convert.ToInt32(ddlSemestre.SelectedValue);
                datoAsig.IDTipoAsig = Convert.ToInt32(ddlTipoAsig.SelectedValue);
                datoAsig.IDModalidadAsig = Convert.ToInt32(ddlModalidad.SelectedValue);
                datoAsig.IDPlanEstudios = Convert.ToInt32(ddlPlan.SelectedValue);
                datoAsig.CreditosAsig = Convert.ToInt32(txtCreditosAsig.Text);
                datoAsig.Status = 1;
                datoAsig.RequisitosAsig = txtRequisitos.Text;
                datoAsig.HorasPre = Convert.ToInt32(txtHorasPre.Text);
                datoAsig.HorasNoPre = Convert.ToInt32(txtHorasNoPre.Text);
                datoAsig.Duracion = datoAsig.HorasPre + datoAsig.HorasNoPre;
                ejecAsig.agregarAsignatura(datoAsig);
                LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));
                LimpiarCampos();
                upAsignatura.Update();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }

        protected void btnModAsig_Click(object sender, EventArgs e)
        {
            if (txtNomAsig.Text != string.Empty)
            {
                datoAsig.IDAsignatura = Convert.ToInt32(Session["AsigModif"]);
                datoAsig.NomAsig = txtNomAsig.Text;
                datoAsig.IDSemestreAsig = Convert.ToInt32(ddlSemestre.SelectedValue);
                datoAsig.IDTipoAsig = Convert.ToInt32(ddlTipoAsig.SelectedValue);
                datoAsig.IDModalidadAsig = Convert.ToInt32(ddlModalidad.SelectedValue);
                datoAsig.IDPlanEstudios = Convert.ToInt32(ddlPlan.SelectedValue);
                datoAsig.CreditosAsig = Convert.ToInt32(txtCreditosAsig.Text);
                datoAsig.RequisitosAsig = txtRequisitos.Text;
                datoAsig.HorasPre = Convert.ToInt32(txtHorasPre.Text);
                datoAsig.HorasNoPre = Convert.ToInt32(txtHorasNoPre.Text);
                datoAsig.Duracion = datoAsig.HorasPre + datoAsig.HorasNoPre;
                ejecAsig.modificarInfoAsig(datoAsig);
                LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));
                btnAddAsig.Visible = true;
                btnModAsig.Visible = false;
                LimpiarCampos();
                upAsignatura.Update();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);

        }

        protected void gvAsignaturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsignaturas.PageIndex = e.NewPageIndex;
            LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));

        }

        protected void gvAsignaturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            if (currentCommand == "SelectAsig")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AsigModif"] = Convert.ToInt32(gvAsignaturas.DataKeys[currentRowIndex].Value);
                datoAsig.IDAsignatura = Convert.ToInt32(Session["AsigModif"]);
                txtNomAsig.Text = ejecAsig.buscarDatoAsig("NomAsig", datoAsig);
                ddlSemestre.SelectedValue = ejecAsig.buscarDatoAsig("IDSemestreAsig", datoAsig);
                ddlTipoAsig.SelectedValue = ejecAsig.buscarDatoAsig("IDTipoAsig", datoAsig);
                ddlModalidad.SelectedValue = ejecAsig.buscarDatoAsig("IDModalidadAsig", datoAsig);
                ddlPlan.SelectedValue = ejecAsig.buscarDatoAsig("IDPlanEstudios", datoAsig);
                txtCreditosAsig.Text = ejecAsig.buscarDatoAsig("CreditosAsig", datoAsig);
                txtRequisitos.Text = ejecAsig.buscarDatoAsig("RequisitosAsig", datoAsig);
                txtHorasPre.Text = ejecAsig.buscarDatoAsig("HorasPre", datoAsig);
                txtHorasNoPre.Text = ejecAsig.buscarDatoAsig("HorasNoPre", datoAsig);
                txtDuracion.Text = ejecAsig.buscarDatoAsig("Duracion", datoAsig);
                LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));
                btnAddAsig.Visible = false;
                btnModAsig.Visible = true;
                upAsignatura.Update();
            }
        }

        protected void ddlSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVAsignaturas(Convert.ToInt32(ddlSemestre.SelectedValue));
        }
    }
}