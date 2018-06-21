using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class ConsultaCalificaciones : System.Web.UI.Page
    {
        CalificacionesAlumnoBO datoCA = new CalificacionesAlumnoBO();
        CalificacionesAlumnoDAO ejecCA = new CalificacionesAlumnoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LlenarDDLCiclo(Convert.ToInt32(Session["IDUserLoged"]));
                ddlciclo.SelectedIndex = 0;
                LlenarDDLGrupoPeriodo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlciclo.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarGVCalif(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
            }

        }

        private void LlenarDDLCiclo(int IDAlumno)
        {
            ddlciclo.Items.Clear();
            ddlciclo.DataSource = ejecCA.LlenadDDLCicloAlumno(IDAlumno);
            ddlciclo.DataTextField = "Nombre";
            ddlciclo.DataValueField = "IDCicloEscolar";
            ddlciclo.DataBind();
            if (ddlciclo.Items.Count != 0)
            {
                LlenarDDLGrupoPeriodo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlciclo.SelectedValue));
            }
        }

        private void LlenarDDLGrupoPeriodo(int IDAlumno, int IDCiclo)
        {
            ddlGrupo.Items.Clear();
            ddlGrupo.DataSource = ejecCA.LlenadDDLGrupoPeriodo(IDAlumno, IDCiclo);
            ddlGrupo.DataTextField = "Grupo";
            ddlGrupo.DataValueField = "IDGrupo";
            ddlGrupo.DataBind();
            if (ddlGrupo.Items.Count != 0)
            {
                LlenarGVCalif(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
            }

        }
        protected void LlenarGVCalif(int IDAlumno, int IDGrupo)
        {
            gvConCalif.DataSource = ejecCA.LlenarGVCalifAlum(IDAlumno, IDGrupo);
            gvConCalif.DataBind();
        }

        protected void ddlciclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupoPeriodo(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlciclo.SelectedValue));
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVCalif(Convert.ToInt32(Session["IDUserLoged"]), Convert.ToInt32(ddlGrupo.SelectedValue));
        }
    }
}