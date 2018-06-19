using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class AvisosPadres : System.Web.UI.Page
    {
        AvisosPadresBO datoAvi = new AvisosPadresBO();
        AvisosPadresDAO ejecAvi = new AvisosPadresDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
            LlenarReporte(Convert.ToInt32(ejecAvi.buscarUltimoIDAviso()));

        }

        Reports.AvisosPadres rprt = new Reports.AvisosPadres();
        protected void LlenarReporte(int IDAviso)
        {
            rprt.Load(Server.MapPath(@"~/Reports/AvisosPadres.rpt"));
            rprt.FileName = Server.MapPath(@"~/Reports/AvisosPadres.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=sql5037.site4now.net;Initial Catalog=DB_A26FD9_SICOESHunucma;User Id= DB_A26FD9_SICOESHunucma_admin;Password=sicoeshunucma2018;");
            SqlCommand cmd = new SqlCommand("AvisoPadre", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "sql5037.site4now.net";
            connectionInfo.DatabaseName = "DB_A26FD9_SICOESHunucma";
            connectionInfo.UserID = "DB_A26FD9_SICOESHunucma_admin";
            connectionInfo.Password = "sicoeshunucma2018";
            SetDBLogonForReport(connectionInfo, rprt);
            rprt.SetParameterValue("@IDAviso", IDAviso);
            AvisoPadres.ReportSource = rprt;
            AvisoPadres.DataBind();
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

        protected void Generar_Click(object sender, EventArgs e)
        {
            datoAvi.Texto = txtAviso.Text;
            ejecAvi.agregarAviso(datoAvi);
            LlenarReporte(Convert.ToInt32(ejecAvi.buscarUltimoIDAviso()));
            txtAviso.Text = String.Empty;
        }

        protected void Ejemplo_Click(object sender, EventArgs e)
        {
            LlenarReporte(1);

        }
    }
}