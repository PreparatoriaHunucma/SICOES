using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.MasterPages
{
    public partial class mstrpgAlumno : System.Web.UI.MasterPage
    {
        AlumnosBO datoAlum = new AlumnosBO();
        AlumnosDAO ejecAlum = new AlumnosDAO();
        TipoMaestroBO datoTipMae = new TipoMaestroBO();
        TipoMaestroDAO ejecTipMae = new TipoMaestroDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUserLoged"] != null)
            {
                datoAlum.IDAlumno = Convert.ToInt32(Session["IDUserLoged"]);
                lbNombre.Text = ejecAlum.buscarDatoAlumno("NomAlumno", datoAlum);
                lbGradoAcademico.Text = ejecAlum.buscarDatoAlumno("Matricula", datoAlum);
                lbCorreoElec.Text = ejecAlum.buscarDatoAlumno("CurpAlumno", datoAlum);
                Avatar.ImageUrl = ejecAlum.buscarDatoAlumno("FotoAlumno", datoAlum);

            }
            else
            {
                Response.Redirect("~/GUI/Index");
            }

        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("~/GUI/Index");
        }

    }
}