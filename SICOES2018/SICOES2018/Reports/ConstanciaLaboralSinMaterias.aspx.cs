using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using SICOES2018.Reports;
using System.Web.UI.WebControls;

namespace SICOES2018.Reports
{
    public partial class ConstanciaLaboralSinMaterias1 : System.Web.UI.Page
    {
        ConstanciaLaboral rprt = new ConstanciaLaboral();
        protected void Page_Load(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath(@"~/Reports/ConstanciaLaboralSinMaterias.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/ConstanciaLaboralSinMaterias.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=sql5037.site4now.net;Initial Catalog=DB_A26FD9_SICOESHunucma;User Id= DB_A26FD9_SICOESHunucma_admin;Password=sicoeshunucma2018;");
            SqlCommand cmd1 = new SqlCommand("[ConstanciaLaboralDatosMaestroSinMaterias", con);
            SqlCommand cmd2 = new SqlCommand("[ConstanciaLaboralDatosSecAca", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "sql5037.site4now.net";
            connectionInfo.DatabaseName = "DB_A26FD9_SICOESHunucma";
            connectionInfo.UserID = "DB_A26FD9_SICOESHunucma_admin";
            connectionInfo.Password = "sicoeshunucma2018";
            SetDBLogonForReport(connectionInfo, rprt);
            rprt.SetParameterValue("@IDMaestro", Convert.ToInt32((Session["EmpModif"])));
            CrystalReportViewer1.ReportSource = rprt;
            CrystalReportViewer1.DataBind();
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