﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.Reports
{
    public partial class FormatoPreinscripcion1 : System.Web.UI.Page
    {
        FormatoPreinscripcion rprt = new FormatoPreinscripcion();
        protected void Page_Load(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath(@"~/Reports/FormatoPreinscripcion.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/FormatoPreinscripcion.rpt");
            SqlConnection con = new SqlConnection(@"Data Source = sql7001.site4now.net; Initial Catalog = DB_A3AC6D_SICOES2018; User Id = DB_A3AC6D_SICOES2018_admin; Password = sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("ReporteFormatoPreinscripcion", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = 33;
            //cmd.Parameters.Add("@IDDOCS", SqlDbType.Int).Value = 35;
            rprt.SetParameterValue("@IDAlumno", Convert.ToInt32(Session["AlumnoReporteID"]));
            rprt.SetParameterValue("@IDMaestro", Convert.ToInt32(Session["IDUserLoged"]));
            crvFormatoPreinscripcion.ReportSource = rprt;
            crvFormatoPreinscripcion.DataBind();
        }
    }
}