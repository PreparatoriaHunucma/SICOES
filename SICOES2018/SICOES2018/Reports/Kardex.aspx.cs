using CrystalDecisions.CrystalReports.Engine;
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
    public partial class Kardex1 : System.Web.UI.Page
    {
        Kardex rprt = new Kardex();
        protected void Page_Load(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath(@"~/Reports/Kardex.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/Kardex.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=sql5037.site4now.net;Initial Catalog=DB_A26FD9_SICOESHunucma;User Id= DB_A26FD9_SICOESHunucma_admin;Password=sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("Kardex", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = 33;
            //cmd.Parameters.Add("@IDDOCS", SqlDbType.Int).Value = 35;
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "sql5037.site4now.net";
            connectionInfo.DatabaseName = "DB_A26FD9_SICOESHunucma";
            connectionInfo.UserID = "DB_A26FD9_SICOESHunucma_admin";
            connectionInfo.Password = "sicoeshunucma2018";
            SetDBLogonForReport(connectionInfo, rprt);
            rprt.SetParameterValue("@IDAlumno", Convert.ToInt32(Session["AlumnoReporteID"]), rprt.Subreports[0].Name.ToString());
            rprt.SetParameterValue("@IDAlumno", Convert.ToInt32(Session["AlumnoReporteID"]), rprt.Subreports[1].Name.ToString());
            rprt.SetParameterValue("@IDAlumno", Convert.ToInt32(Session["AlumnoReporteID"]));
            Kardex.ReportSource = rprt;
            Kardex.DataBind();
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