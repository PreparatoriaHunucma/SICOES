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
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarGridViewCiclosEscolares();
                LlenarDropDownListCiclosEscolaresPer1();
                LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));
                LlenarDropDownListCiclosEscolaresPer2();
                LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));
            }
        }
        protected void LlenarGridViewCiclosEscolares()
        {
            gvCiclos.DataSource = ejecCiclo.LlenarGridView();
            gvCiclos.DataBind();

        }
        protected void LlenarDropDownListCiclosEscolaresPer1()
        {
            ddlCicloEscolarAddPeriodoA.DataSource = ejecCiclo.llenarDDL();
            ddlCicloEscolarAddPeriodoA.DataTextField = "Nombre";
            ddlCicloEscolarAddPeriodoA.DataValueField = "IDCicloEscolar";
            ddlCicloEscolarAddPeriodoA.DataBind();
            if (ddlCicloEscolarAddPeriodoA.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue);
                LlenarGridViewPer1(PaisID);
            }
        }
        protected void LlenarGridViewPer1(int IDCiclo)
        {
            gvPer1.DataSource = ejecPer.LlenarGridViewPeriodo1(IDCiclo);
            gvPer1.DataBind();
            upPeriodo1.Update();
        }
        protected void LlenarDropDownListCiclosEscolaresPer2()
        {
            ddlCicloEscolarAddPeriodoB.DataSource = ejecCiclo.llenarDDL();
            ddlCicloEscolarAddPeriodoB.DataTextField = "Nombre";
            ddlCicloEscolarAddPeriodoB.DataValueField = "IDCicloEscolar";
            ddlCicloEscolarAddPeriodoB.DataBind();
            if (ddlCicloEscolarAddPeriodoB.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue);
                LlenarGridViewPer2(PaisID);
            }
        }
        protected void LlenarGridViewPer2(int IDCiclo)
        {
            gvPer2.DataSource = ejecPer.LlenarGridViewPeriodo2(IDCiclo);
            gvPer2.DataBind();
            upPeriodo2.Update();
        }

        protected void LimpiarCampos()
        {
            txtNomCiclo.Text = string.Empty;
            txtFechaInicioCiclo.Text = string.Empty;
            txtFechaFinCiclo.Text = string.Empty;
            checkStatusCiclo.Checked = false;
            Session.Contents.Remove("CicloModif");
        }
        protected void LimpiarCamposPer1()
        {
            txtFechaInicioPer1.Text = string.Empty;
            txtFechaFinPer1.Text = string.Empty;
            Session.Contents.Remove("Per1Modif");
        }
        protected void LimpiarCamposPer2()
        {
            txtFechaInicioPer2.Text = string.Empty;
            txtFechaFinPer2.Text = string.Empty;
            Session.Contents.Remove("Per2Modif");
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
                LlenarDropDownListCiclosEscolaresPer1();
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
                LlenarDropDownListCiclosEscolaresPer1();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }

        }



        protected void ddlCicloEscolarAddPeriodoA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDCiclo = Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue);
            LlenarGridViewPer1(IDCiclo);
            upPeriodo1.Update();
        }
        protected void btnAddPer1_Click(object sender, EventArgs e)
        {
            if (txtFechaInicioPer1.Text != "" && txtFechaFinPer1.Text != "")
            {
                DateTime FechaInicioPer1 = DateTime.ParseExact(txtFechaInicioPer1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                datoCiclo.IDCicloEscolar = Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue);
                string FechaInicioCicloTexto = Convert.ToDateTime(ejecCiclo.buscarDatoCiclo("FechaInicio", datoCiclo)).ToString("yyyy-MM-dd");
                DateTime FechaInicioCiclo = DateTime.ParseExact(FechaInicioCicloTexto, "yyyy-MM-dd", CultureInfo.CurrentUICulture);

                if (FechaInicioPer1.Date >= FechaInicioCiclo.Date)
                {
                    datoPer.Nombre = "Primer Periodo";
                    datoPer.FechaInicio = DateTime.ParseExact(txtFechaInicioPer1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    datoPer.FechaFin = DateTime.ParseExact(txtFechaFinPer1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    datoPer.IDCicloEscolar = Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue);
                    ejecPer.agregarPeriodo(datoPer);
                    LimpiarCamposPer1();
                    LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "per1successalert();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "dateper1erroralert();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
            LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));

        }
        protected void btnModPer1_Click(object sender, EventArgs e)
        {
            if (txtFechaInicioPer1.Text != "" && txtFechaFinPer1.Text != "")
            {
                DateTime FechaInicioPer1 = DateTime.ParseExact(txtFechaInicioPer1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                datoCiclo.IDCicloEscolar = Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue);
                string FechaInicioCicloTexto = Convert.ToDateTime(ejecCiclo.buscarDatoCiclo("FechaInicio", datoCiclo)).ToString("yyyy-MM-dd");
                DateTime FechaInicioCiclo = DateTime.ParseExact(FechaInicioCicloTexto, "yyyy-MM-dd", CultureInfo.CurrentUICulture);

                if (FechaInicioPer1.Date >= FechaInicioCiclo.Date)
                {
                    datoPer.IDPeriodo = Convert.ToInt32(Session["Per1Modif"]);
                    datoPer.FechaInicio = DateTime.ParseExact(txtFechaInicioPer1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    datoPer.FechaFin = DateTime.ParseExact(txtFechaFinPer1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    ejecPer.modificarInfoPeriodo(datoPer);
                    LimpiarCamposPer1();
                    LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));
                    btnModPer1.Visible = false;
                    btnAddPer1.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "per1successalert();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "dateper1erroralert();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
            LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));

        }
        protected void gvPer1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPer1.PageIndex = e.NewPageIndex;
            LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));
            upPeriodo1.Update();
        }
        protected void gvPer1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;

            if (currentCommand == "SelectPeriodo")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                int IDPerido1 = Convert.ToInt32(gvCiclos.DataKeys[currentRowIndex].Value);
                Session["Per1Modif"] = IDPerido1;
                datoPer.IDPeriodo = IDPerido1;
                txtFechaInicioPer1.Text = Convert.ToDateTime(ejecPer.buscarDatoPeriodo("FechaInicio", datoPer)).ToString("yyyy-MM-dd");
                txtFechaFinPer1.Text = Convert.ToDateTime(ejecPer.buscarDatoPeriodo("FechaFin", datoPer)).ToString("yyyy-MM-dd");
                btnAddPer1.Visible = false;
                btnModPer1.Visible = true;
                LlenarGridViewPer1(Convert.ToInt32(ddlCicloEscolarAddPeriodoA.SelectedValue));
                upPeriodo1.Update();
            }

        }



        protected void ddlCicloEscolarAddPeriodoB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDCiclo = Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue);
            LlenarGridViewPer2(IDCiclo);
            upPeriodo2.Update();
        }

        protected void btnModPer2_Click(object sender, EventArgs e)
        {
            if (txtFechaInicioPer2.Text != "" && txtFechaFinPer2.Text != "")
            {
                DateTime FechaFinPer2 = DateTime.ParseExact(txtFechaFinPer2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                datoCiclo.IDCicloEscolar = Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue);
                string FechaFinCicloTexto = Convert.ToDateTime(ejecCiclo.buscarDatoCiclo("FechaFin", datoCiclo)).ToString("yyyy-MM-dd");
                DateTime FechaFinCiclo = DateTime.ParseExact(FechaFinCicloTexto, "yyyy-MM-dd", CultureInfo.CurrentUICulture);

                if (FechaFinPer2.Date <= FechaFinCiclo.Date)
                {
                    datoPer.IDPeriodo = Convert.ToInt32(Session["Per2Modif"]);
                    datoPer.FechaInicio = DateTime.ParseExact(txtFechaInicioPer2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    datoPer.FechaFin = DateTime.ParseExact(txtFechaFinPer2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    ejecPer.modificarInfoPeriodo(datoPer);
                    LimpiarCamposPer2();
                    LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));
                    btnModPer2.Visible = false;
                    btnAddPer2.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "per1successalert();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "dateper1erroralert();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
            LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));
        }

        protected void btnAddPer2_Click(object sender, EventArgs e)
        {
            if (txtFechaInicioPer2.Text != "" && txtFechaFinPer2.Text != "")
            {
                DateTime FechaFinPer2 = DateTime.ParseExact(txtFechaFinPer2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                datoCiclo.IDCicloEscolar = Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue);
                string FechaFinCicloTexto = Convert.ToDateTime(ejecCiclo.buscarDatoCiclo("FechaFin", datoCiclo)).ToString("yyyy-MM-dd");
                DateTime FechaFinCiclo = DateTime.ParseExact(FechaFinCicloTexto, "yyyy-MM-dd", CultureInfo.CurrentUICulture);

                if (FechaFinPer2.Date <= FechaFinCiclo.Date)
                {
                    datoPer.Nombre = "Segundo Periodo";
                    datoPer.FechaInicio = DateTime.ParseExact(txtFechaInicioPer2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    datoPer.FechaFin = DateTime.ParseExact(txtFechaFinPer2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
                    datoPer.IDCicloEscolar = Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue);
                    ejecPer.agregarPeriodo(datoPer);
                    LimpiarCamposPer2();
                    LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "per1successalert();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "dateper1erroralert();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
            LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));

        }

        protected void gvPer2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPer2.PageIndex = e.NewPageIndex;
            LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));
            upPeriodo2.Update();
        }

        protected void gvPer2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;

            if (currentCommand == "SelectPeriodo")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                int IDPerido2 = Convert.ToInt32(gvCiclos.DataKeys[currentRowIndex].Value);
                Session["Per2Modif"] = IDPerido2;
                datoPer.IDPeriodo = IDPerido2;
                txtFechaInicioPer2.Text = Convert.ToDateTime(ejecPer.buscarDatoPeriodo("FechaInicio", datoPer)).ToString("yyyy-MM-dd");
                txtFechaFinPer2.Text = Convert.ToDateTime(ejecPer.buscarDatoPeriodo("FechaFin", datoPer)).ToString("yyyy-MM-dd");
                btnAddPer2.Visible = false;
                btnModPer2.Visible = true;
                LlenarGridViewPer2(Convert.ToInt32(ddlCicloEscolarAddPeriodoB.SelectedValue));
                upPeriodo2.Update();
            }

        }
    }
}