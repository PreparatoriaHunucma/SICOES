using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICOES2018.Reports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SICOES2018.GUI
{
    public partial class Prueba_de_carta : System.Web.UI.Page
    {
        FormatoCartaCompromiso rprt = new FormatoCartaCompromiso();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ButtonReporte_Click(object sender, EventArgs e)
        {
            
            rprt.Load(Server.MapPath(@"~/Reports/FormatoCartaCompromiso.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/FormatoCartaCompromiso.rpt");
            SqlConnection con = new SqlConnection(@"Data Source = sql7001.site4now.net; Initial Catalog = DB_A3AC6D_SICOES2018; User Id = DB_A3AC6D_SICOES2018_admin; Password = sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("CartaCompromiso", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd); 
            //cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = 33;
            //cmd.Parameters.Add("@IDDOCS", SqlDbType.Int).Value = 35;
            rprt.SetParameterValue("@IDAlumno", Convert.ToInt32(Alumno.Text));
            rprt.SetParameterValue("@IDDOCS", Convert.ToInt32(Documento.Text));
            CrystalReportViewer1.ReportSource = rprt;
            CrystalReportViewer1.DataBind();
        }
    }
}