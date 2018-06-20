using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class FechaCalificacion : System.Web.UI.Page
    {
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        FechaCalificacionBO datoFC = new FechaCalificacionBO();
        FechaCalificacionDAO ejecFC = new FechaCalificacionDAO();
        MomentoCalificacionBO datoMom = new MomentoCalificacionBO();
        MomentoCalificacionDAO ejecMom = new MomentoCalificacionDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDDLPeriodo();
                ddlPeriodo.SelectedIndex = 0;
                LlenarCampos(Convert.ToInt32(ddlPeriodo.SelectedValue));
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
                LlenarCampos(Convert.ToInt32(ddlPeriodo.SelectedValue));
            }
        }

        protected void LlenarCampos(int IDPeriodo)
        {
            datoFC.IDPeriodo = IDPeriodo;
            txtFechaInicioMom1.Text = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaInicioCalif", datoFC, 1)).ToString("yyyy-MM-dd");
            txtFechaInicioMom2.Text = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaInicioCalif", datoFC, 2)).ToString("yyyy-MM-dd");
            txtFechaInicioMom3.Text = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaInicioCalif", datoFC, 3)).ToString("yyyy-MM-dd");
            txtFechaFinMom1.Text = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaFinCalif", datoFC, 1)).ToString("yyyy-MM-dd");
            txtFechaFinMom2.Text = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaFinCalif", datoFC, 2)).ToString("yyyy-MM-dd");
            txtFechaFinMom3.Text = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaFinCalif", datoFC, 3)).ToString("yyyy-MM-dd");

        }

        protected void ActualizarMomento1()
        {
            datoFC.IDPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
            datoFC.IDMomento = 1;
            datoFC.FechaInicioCalif = DateTime.ParseExact(txtFechaInicioMom1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoFC.FechaFinCalif = DateTime.ParseExact(txtFechaFinMom1.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            ejecFC.modificarInfoFechaCalif(datoFC);

        }
        protected void ActualizarMomento2()
        {
            datoFC.IDPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
            datoFC.IDMomento = 2;
            datoFC.FechaInicioCalif = DateTime.ParseExact(txtFechaInicioMom2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoFC.FechaFinCalif = DateTime.ParseExact(txtFechaFinMom2.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            ejecFC.modificarInfoFechaCalif(datoFC);

        }
        protected void ActualizarMomento3()
        {
            datoFC.IDPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
            datoFC.IDMomento = 3;
            datoFC.FechaInicioCalif = DateTime.ParseExact(txtFechaInicioMom3.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoFC.FechaFinCalif = DateTime.ParseExact(txtFechaFinMom3.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            ejecFC.modificarInfoFechaCalif(datoFC);

        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCampos(Convert.ToInt32(ddlPeriodo.SelectedValue));
        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            ActualizarMomento1();
            ActualizarMomento2();
            ActualizarMomento3();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);

        }
    }
}