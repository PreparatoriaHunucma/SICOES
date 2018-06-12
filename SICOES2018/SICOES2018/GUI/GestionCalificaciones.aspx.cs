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
        protected void Page_Load(object sender, EventArgs e)
        {

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
                cmd = new SqlCommand("UPDATE Calificaciones SET Calificacion = @Calificacion, Inasistencias = @Inasistencias WHERE IDCalificacion = @IDCalificacion");

                cmd.Parameters.AddWithValue("@Calificacion", Elemento.Calificacion);
                cmd.Parameters.AddWithValue("@Inasistencias", Elemento.Calificacion);
                cmd.Parameters.AddWithValue("@IDCalificacion", 1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public class tblExcel
        {
            public tblExcel() { }
            public decimal Calificacion { get; set; }
            public int Inasistencias { get; set; }

        }


        protected string ObtenerRegistros()
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ejecCalif.ObtenerCalificaciones());
            return JSONString;
        }
        protected void ddlPeriodoCalif_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlGrupoAsig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMomento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}