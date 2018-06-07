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

namespace SICOES2018.GUI
{
    public partial class pruebasinmaster : System.Web.UI.Page
    {
        RepCartaCompromiso rprt = new RepCartaCompromiso();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonReporte_Click(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath("~/Reports/RepCartaCompromiso.rpt"));
            SqlConnection con = new SqlConnection(@"Data Source = sql7001.site4now.net; Initial Catalog = DB_A3AC6D_SICOES2018; User Id = DB_A3AC6D_SICOES2018_admin; Password = sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("SELECT Alumnos.NomAlumno, Alumnos.ApePatAlumno, Alumnos.ApeMatAlumno, NomTutorAlumno FROM Alumnos WHERE IDAlumno = 33", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rprt.SetDataSource(dt);
            rprt.SetParameterValue("IDAlumno", Alumno.Text);
            //rprt.SetParameterValue("IDDocumento", Documento.Text);
            CrystalReportViewer1.ReportSource = rprt;
            CrystalReportViewer1.DataBind();
        }
    }
}