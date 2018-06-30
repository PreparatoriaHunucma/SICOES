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
        }
        protected void Generar_Click(object sender, EventArgs e)
        {
            datoAvi.Texto = txtAviso.Text;
            ejecAvi.agregarAviso(datoAvi);
            Session["AvisoReporteID"] = Convert.ToInt32(ejecAvi.buscarUltimoIDAviso());
            txtAviso.Text = String.Empty;
            Response.Redirect("~/Reports/Aviso");

        }
    }
}