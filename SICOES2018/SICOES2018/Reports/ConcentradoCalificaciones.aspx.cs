﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.Reports
{
    public partial class ConcentradoCalificaciones1 : System.Web.UI.Page
    {
        ConcentradoCalificaciones rprt = new ConcentradoCalificaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath(@"~/Reports/ConcentradoCalificaciones.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/ConcentradoCalificaciones.rpt");
            SqlConnection con = new SqlConnection(@"Data Source = sql7001.site4now.net; Initial Catalog = DB_A3AC6D_SICOES2018; User Id = DB_A3AC6D_SICOES2018_admin; Password = sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("ConcentradoCalificaciones", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = 33;
            //cmd.Parameters.Add("@IDDOCS", SqlDbType.Int).Value = 35;
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "sql7001.site4now.net";
            connectionInfo.DatabaseName = "DB_A3AC6D_SICOES2018";
            connectionInfo.UserID = "DB_A3AC6D_SICOES2018_admin";
            connectionInfo.Password = "sicoeshunucma2018";
            SetDBLogonForReport(connectionInfo, rprt);
            rprt.SetParameterValue("@IDGrupo", Convert.ToInt32(Session["GrupoReporteID"]));
            rprt.SetParameterValue("@IDAsignatura", Convert.ToInt32(Session["AsigReporteID"]));
            cvrConcentradoCalif.ReportSource = rprt;
            cvrConcentradoCalif.DataBind();

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

    }
}