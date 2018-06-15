using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SICOES2018.BO;
using SICOES2018.DAO;

namespace SICOES2018.GUI
{
    public partial class GestionCalificaciones : System.Web.UI.Page
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
                ddlPeriodoCalif.SelectedIndex = 0;
                LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarDDLAsignatura(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
                ddlAsig.SelectedIndex = 0;
                LlenarDDLMomento();
                ddlMomento.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
                ModificarMaximo();
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
                LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
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
        protected void LlenarDDLMomento()
        {
            ddlMomento.Items.Clear();
            ddlMomento.DataSource = ejecMom.LlenarDDL();
            ddlMomento.DataTextField = "Nombre";
            ddlMomento.DataValueField = "IDMomento";
            ddlMomento.DataBind();
        }


        protected void ModificarMaximo()
        {
            int momento = Convert.ToInt32(ddlMomento.SelectedValue);
            if (momento < 3)
                txtVal1.Value = "70";
            else
                txtVal1.Value = "30";

        }


        [WebMethod]
        public static bool ModificarRegistro(List<tblExcel> tblExcel)
        {
            string strconn = "Data Source=sql7001.site4now.net;Initial Catalog=DB_A3AC6D_SICOES2018;User Id=DB_A3AC6D_SICOES2018_admin;Password=sicoeshunucma2018;";
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
            int Grupo = Convert.ToInt32(ddlGrupo.SelectedValue);
            int Asig = Convert.ToInt32(ddlAsig.SelectedValue);
            int Momento = Int32.Parse(ddlMomento.SelectedValue);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ejecCalif.ObtenerCalificaciones(Grupo, Asig, Momento));
            return JSONString;
        }


        protected void ddlPeriodoCalif_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlPeriodoCalif.SelectedValue));
            ScriptManager.RegisterStartupScript(this, GetType(), "text", "tablacalificaciones();", true);
            ModificarMaximo();

        }

        protected void ddlGrupoAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLAsignatura(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
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
    }
}