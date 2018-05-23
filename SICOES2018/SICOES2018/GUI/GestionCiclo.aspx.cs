using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICOES2018.BO;
using SICOES2018.DAO;

namespace SICOES2018.GUI
{
    public partial class GestionCiclo : System.Web.UI.Page
    {
        CicloEscolarBO datoCiclo = new CicloEscolarBO();
        CicloEscolarDAO ejecCiclo = new CicloEscolarDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarGridViewCiclosEscolares();
            }
        }

        protected void LlenarGridViewCiclosEscolares()
        {
            gvCiclos.DataSource = ejecCiclo.LlenarGridView();
            gvCiclos.DataBind();

        }
        protected void LimpiarCampos()
        {
            txtNomCiclo.Text = string.Empty;
            txtFechaInicioCiclo.Text = string.Empty;
            txtFechaFinCiclo.Text = string.Empty;
            checkStatusCiclo.Checked = false;
            Session.Contents.Remove("CicloModif");
        }
        protected void gvCiclos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;

            if (currentCommand == "SelectCiclo")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                int IDCicloEscolar = Convert.ToInt32(gvCiclos.DataKeys[currentRowIndex].Value);
                Session["CicloModif"] = IDCicloEscolar;
                datoCiclo.IDCicloEscolar = IDCicloEscolar;
                txtNomCiclo.Text = ejecCiclo.buscarDatoCiclo("Nombre", datoCiclo);
                txtFechaInicioCiclo.Text = Convert.ToDateTime(ejecCiclo.buscarDatoCiclo("FechaInicio", datoCiclo)).ToString("yyyy-MM-dd");
                txtFechaFinCiclo.Text = Convert.ToDateTime(ejecCiclo.buscarDatoCiclo("FechaFin", datoCiclo)).ToString("yyyy-MM-dd");
                int Status = Convert.ToInt32(ejecCiclo.buscarDatoCiclo("Status", datoCiclo));
                if (Status == 1)
                    checkStatusCiclo.Checked = true;
                else
                    checkStatusCiclo.Checked = false;
                btnAddCiclo.Visible = false;
                btnModCiclo.Visible = true;
                upCiclos.Update();
            }

        }

        protected void gvCiclos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCiclos.PageIndex = e.NewPageIndex;
            LlenarGridViewCiclosEscolares();
            upCiclos.Update();
        }

        protected void btnAddCiclo_Click(object sender, EventArgs e)
        {
            if (txtNomCiclo.Text != "" && txtFechaInicioCiclo.Text != "" && txtFechaFinCiclo.Text != "")
            {
                datoCiclo.Nombre = txtNomCiclo.Text;
                datoCiclo.FechaInicio = DateTime.ParseExact(txtFechaInicioCiclo.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                datoCiclo.FechaFin = DateTime.ParseExact(txtFechaFinCiclo.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                if (checkStatusCiclo.Checked == true)
                    datoCiclo.Status = 1;
                else
                    datoCiclo.Status = 0;
                ejecCiclo.agregarCicloEscolar(datoCiclo);
                LimpiarCampos();
                LlenarGridViewCiclosEscolares();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }

        }

        protected void btnModCiclo_Click(object sender, EventArgs e)
        {
            if (txtNomCiclo.Text != "" && txtFechaInicioCiclo.Text != "" && txtFechaFinCiclo.Text != "")
            {
                datoCiclo.IDCicloEscolar = Convert.ToInt32(Session["CicloModif"]);
                datoCiclo.Nombre = txtNomCiclo.Text;
                datoCiclo.FechaInicio = DateTime.ParseExact(txtFechaInicioCiclo.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                datoCiclo.FechaFin = DateTime.ParseExact(txtFechaFinCiclo.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                if (checkStatusCiclo.Checked == true)
                    datoCiclo.Status = 1;
                else
                    datoCiclo.Status = 0;
                ejecCiclo.modificarInfoCicloEscolar(datoCiclo);
                ejecCiclo.modificarEstadoCicloEscolar(datoCiclo);
                LimpiarCampos();
                btnAddCiclo.Visible = true;
                btnModCiclo.Visible = false;
                LlenarGridViewCiclosEscolares();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }

        }

        protected void ddlCicloEscolarAddPeriodoA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}