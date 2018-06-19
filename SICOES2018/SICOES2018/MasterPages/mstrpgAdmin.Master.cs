using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICOES2018.BO;
using SICOES2018.DAO;

namespace SICOES2018.MasterPages
{
    public partial class mstrpgAdmin : System.Web.UI.MasterPage
    {
        MaestrosBO datoMaestro = new MaestrosBO();
        MaestrosDAO ejecMaestro = new MaestrosDAO();
        TipoMaestroBO datoTipMae = new TipoMaestroBO();
        TipoMaestroDAO ejecTipMae = new TipoMaestroDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUserLoged"] != null)
            {
                datoMaestro.IDMaestro = Convert.ToInt32(Session["IDUserLoged"]);
                lbNombre.Text = ejecMaestro.buscarDatoAlumno("NomMaestro", datoMaestro);
                lbGradoAcademico.Text = ejecMaestro.buscarDatoAlumno("GradoAcademicoMaestro", datoMaestro);
                lbCorreoElec.Text = ejecMaestro.buscarDatoAlumno("CorreoMaestro", datoMaestro);
                lbTeléfono.Text = ejecMaestro.buscarDatoAlumno("TelMaestro", datoMaestro);
                Avatar.ImageUrl = ejecMaestro.buscarDatoAlumno("FotoMaestro", datoMaestro);
                datoTipMae.IDTipoMaestro = Convert.ToInt32(ejecMaestro.buscarDatoAlumno("IDTipoMaestro", datoMaestro));
                if (ejecTipMae.buscarDatoPermiso("Directivo", datoTipMae) == "0")
                { Directivo.Visible = false; iconoDirectivo.Visible = false; }
                if (ejecTipMae.buscarDatoPermiso("SecreAcade", datoTipMae) == "0")
                { Académica.Visible = false; iconoAcadémica.Visible = false; }
                if (ejecTipMae.buscarDatoPermiso("SecreAdmin", datoTipMae) == "0")
                { Administrativa.Visible = false; iconoAdministrativa.Visible = false; }
                if (ejecTipMae.buscarDatoPermiso("ControlEsc", datoTipMae) == "0")
                { Control.Visible = false; iconoControl.Visible = false; }
                if (ejecTipMae.buscarDatoPermiso("Docente", datoTipMae) == "0")
                { Docente.Visible = false; iconoDocente.Visible = false; }

                string CicloActivo = ejecMaestro.buscarCicloActivo();
                string Periodo1 = ejecMaestro.buscarPeriodoActivo1(CicloActivo);
                string Periodo2 = ejecMaestro.buscarPeriodoActivo2(CicloActivo);
                if (Convert.ToInt32(ejecMaestro.buscarGrupos(Periodo1, Session["IDUserLoged"].ToString())) != 0)
                {
                    botoncalif.Visible = true;
                    botonlista.Visible = true;
                    btnchat.Visible = true;
                }
                else if (Convert.ToInt32(ejecMaestro.buscarGrupos(Periodo2, Session["IDUserLoged"].ToString())) != 0)
                {
                    botoncalif.Visible = true;
                    botonlista.Visible = true;
                    btnchat.Visible = true;
                }
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