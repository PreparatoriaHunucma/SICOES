using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using SICOES2018.Reports;
using SICOES2018.BO;
using SICOES2018.DAO;
using System.Web.UI.WebControls;

namespace SICOES2018.Reports
{
    public partial class CredencialMaestros1 : System.Web.UI.Page
    {
        CredencialMaestros rprt = new CredencialMaestros();
        MaestrosBO datoEmp = new MaestrosBO();
        MaestrosDAO ejecEmp = new MaestrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath(@"~/Reports/CredencialMaestros.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/CredencialMaestros.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=sql5037.site4now.net;Initial Catalog=DB_A26FD9_SICOESHunucma;User Id= DB_A26FD9_SICOESHunucma_admin;Password=sicoeshunucma2018;");
            SqlCommand cmd1 = new SqlCommand("CredencialMaestro", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "sql5037.site4now.net";
            connectionInfo.DatabaseName = "DB_A26FD9_SICOESHunucma";
            connectionInfo.UserID = "DB_A26FD9_SICOESHunucma_admin";
            connectionInfo.Password = "sicoeshunucma2018";
            SetDBLogonForReport(connectionInfo, rprt);
            datoEmp.IDMaestro = 15;
            string ParametroIDM = Convert.ToString(Session["Lparametro"]);
            rprt.SetParameterValue("@IDMaestro", ParametroIDM);
            //rprt.SetParameterValue("ProfilePicture", item);            
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