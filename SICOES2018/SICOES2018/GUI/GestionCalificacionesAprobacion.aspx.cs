﻿using Newtonsoft.Json;
using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class GestionCalificacionesAprobacion : System.Web.UI.Page
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
        FechaCalificacionBO datoFC = new FechaCalificacionBO();
        FechaCalificacionDAO ejecFC = new FechaCalificacionDAO();

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
                ddlAsig.SelectedIndex = 0;
                Fechas();
                ddlMomento.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
                ModificarMaximo();
            }

        }
        protected void Fechas()
        {
            datoFC.IDPeriodo = Convert.ToInt32(ddlPeriodoCalif.SelectedValue);
            DateTime FechaInicioMomento1 = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaInicioCalif", datoFC, 1));
            DateTime FechaInicioMomento2 = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaInicioCalif", datoFC, 2));
            DateTime FechaInicioMomento3 = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaInicioCalif", datoFC, 3));
            DateTime FechaFinMomento1 = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaFinCalif", datoFC, 1));
            DateTime FechaFinMomento2 = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaFinCalif", datoFC, 2));
            DateTime FechaFinMomento3 = Convert.ToDateTime(ejecFC.buscarDatoFechaCalif("FechaFinCalif", datoFC, 3));
            DateTime Hoy = DateTime.Today;
            if (Hoy >= FechaInicioMomento1.Date && Hoy <= FechaFinMomento1.Date)
            {
                LlenarDDLMomento(1);
            }
            else if (Hoy >= FechaInicioMomento2.Date && Hoy <= FechaFinMomento2.Date)
            {
                LlenarDDLMomento(2);
            }
            else if (Hoy >= FechaInicioMomento3.Date && Hoy <= FechaFinMomento3.Date)
            {
                LlenarDDLMomento(3);
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
            ddlAsig.Items.Clear();
            ddlAsig.DataSource = ejecAsig.LlenarDDL(IDGrupo);
            ddlAsig.DataTextField = "NomAsig";
            ddlAsig.DataValueField = "IDAsignatura";
            ddlAsig.DataBind();
        }
        protected void LlenarDDLMomento(int IDMomento)
        {
            ddlMomento.Items.Clear();
            ddlMomento.DataSource = ejecMom.LlenarDDLMomentoEspecifico(IDMomento);
            ddlMomento.DataTextField = "Nombre";
            ddlMomento.DataValueField = "IDMomento";
            ddlMomento.DataBind();
        }


        protected void ModificarMaximo()
        {
            if (ddlMomento.Items.Count != 0)
            {

                int momento = Convert.ToInt32(ddlMomento.SelectedValue);
                if (momento < 3)
                    txtVal1.Value = "70";
                else
                    txtVal1.Value = "30";
            }
        }


        [WebMethod]
        public static bool ModificarRegistro(List<tblExcel> tblExcel)
        {
            string strconn = "Data Source=sql5037.site4now.net;Initial Catalog=DB_A26FD9_SICOESHunucma;User Id= DB_A26FD9_SICOESHunucma_admin;Password=sicoeshunucma2018;";
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(strconn);
            foreach (var Elemento in tblExcel)
            {
                cmd = new SqlCommand("UPDATE Calificaciones SET Calificacion = @Calificacion, Inasistencias = @Inasistencias WHERE IDCalificacion = @IDCalificacion", con);

                cmd.Parameters.AddWithValue("@Calificacion", Elemento.Calificacion);
                cmd.Parameters.AddWithValue("@Inasistencias", Elemento.Inasistencias);
                cmd.Parameters.AddWithValue("@IDCalificacion", Elemento.IDCalificacion);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        public class tblExcel
        {
            public tblExcel() { }
            public int IDCalificacion { get; set; }
            public Decimal Calificacion { get; set; }
            public int Inasistencias { get; set; }
        }
        protected string ObtenerRegistros()
        {
            int Momento = 0;
            int Grupo = Convert.ToInt32(ddlGrupo.SelectedValue);
            int Asig = Convert.ToInt32(ddlAsig.SelectedValue);
            if (ddlMomento.Items.Count != 0)
            {
                Momento = Int32.Parse(ddlMomento.SelectedValue);
            }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ejecCalif.ObtenerCalificaciones(Grupo, Asig, Momento));
            return JSONString;
        }


        protected void ddlPeriodoCalif_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupo(Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
            ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
            ModificarMaximo();

        }

        protected void ddlGrupoAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLAsignatura(Convert.ToInt32(ddlGrupo.SelectedValue));
            ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
            ModificarMaximo();

        }

        protected void ddlMomento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
            ModificarMaximo();

        }

        protected void ddlAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
            ModificarMaximo();

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

        }
    }
}