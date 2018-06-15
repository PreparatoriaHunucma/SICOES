using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SICOES2018.BO;
using SICOES2018.DAO;
using SICOES2018.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class ListaAsistenciaMaestro : System.Web.UI.Page
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
                LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodo.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarDDLAsignatura(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
                ddlAsig.SelectedIndex = 0;
                LlenarReporte();

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
                LlenarDDLAsignatura(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
            }
        }

        protected void LlenarDDLAsignatura(int IDMaestro, int IDGrupo)
        {
            ddlAsig.Items.Clear();
            ddlAsig.DataSource = ejecAsig.LlenarDDLMaestros(IDGrupo, IDMaestro);
            ddlAsig.DataTextField = "NomAsig";
            ddlAsig.DataValueField = "IDAsignatura";
            ddlAsig.DataBind();
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodo.SelectedValue));
            LlenarReporte();

        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLAsignatura(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
            LlenarReporte();

        }

        Reports.ListaAsistenciaMaestro rprt = new Reports.ListaAsistenciaMaestro();
        protected void ddlAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarReporte();
        }
        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }

        protected void LlenarReporte()
        {
            rprt.Load(Server.MapPath(@"~/Reports/ListaAsistenciaMaestro.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/ListaAsistenciaMaestro.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=sql5037.site4now.net;Initial Catalog=DB_A26FD9_SICOESHunucma;User Id= DB_A26FD9_SICOESHunucma_admin;Password=sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("ListaAsistenciaMaestro", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = 33;
            //cmd.Parameters.Add("@IDDOCS", SqlDbType.Int).Value = 35;
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "sql5037.site4now.net";
            connectionInfo.DatabaseName = "DB_A26FD9_SICOESHunucma";
            connectionInfo.UserID = "DB_A26FD9_SICOESHunucma_admin";
            connectionInfo.Password = "sicoeshunucma2018";
            SetDBLogonForReport(connectionInfo, rprt);
            rprt.SetParameterValue("@IDGrupo", Convert.ToInt32(ddlGrupo.SelectedValue));
            rprt.SetParameterValue("@IDAsignatura", Convert.ToInt32(ddlAsig.SelectedValue));
            crvFormatoPreinscripcion.ReportSource = rprt;
            crvFormatoPreinscripcion.DataBind();

        }
        protected void Generar_Click(object sender, EventArgs e)
        {

        }
    }
}