using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class Reinscripcion : System.Web.UI.Page
    {
        AlumnosBO datoAlum = new AlumnosBO();
        AlumnosDAO ejecAlum = new AlumnosDAO();
        CalificacionesBO datoCalif = new CalificacionesBO();
        CalificacionesDAO ejecCalif = new CalificacionesDAO();
        CalificacionesAlumnoBO datoCalifA = new CalificacionesAlumnoBO();
        CalificacionesAlumnoDAO ejecCalifA = new CalificacionesAlumnoDAO();
        MomentoCalificacionBO datoMomento = new MomentoCalificacionBO();
        MomentoCalificacionDAO ejecMomento = new MomentoCalificacionDAO();
        AsignaturasBO datoAsig = new AsignaturasBO();
        AsignaturasDAO ejecAsig = new AsignaturasDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();
        CicloEscolarBO datoCiclo = new CicloEscolarBO();
        CicloEscolarDAO ejecCiclo = new CicloEscolarDAO();
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDDLCiclo();
                ddlCicloEscolar.SelectedIndex = 0;
                LlenarDDLCicloRe();
                ddlCicloEscolarRe.SelectedIndex = 0;
                LlenarDDLPeriodo(Convert.ToInt32(ddlCicloEscolar.SelectedValue));
                ddlPeriodo.SelectedIndex = 0;
                LlenarDDLPeriodoRe(Convert.ToInt32(ddlCicloEscolarRe.SelectedValue));
                ddlPeriodoRe.SelectedIndex = 0;
                LlenarDDLGrupos(Convert.ToInt32(ddlPeriodo.SelectedValue));
                ddlGrupo.SelectedIndex = 0;
                LlenarDDLGruposRe(Convert.ToInt32(ddlPeriodoRe.SelectedValue));
                ddlGrupoRe.SelectedIndex = 0;
                LlenarGVAlumno(Convert.ToInt32(ddlGrupoRe.SelectedValue));
            }
        }
        protected void LlenarDDLCiclo()
        {
            ddlCicloEscolar.Items.Clear();
            ddlCicloEscolar.DataSource = ejecCiclo.llenarDDL();
            ddlCicloEscolar.DataTextField = "Nombre";
            ddlCicloEscolar.DataValueField = "IDCicloEscolar";
            ddlCicloEscolar.DataBind();
            if (ddlCicloEscolar.Items.Count != 0)
            {
                LlenarDDLPeriodo(Convert.ToInt32(ddlCicloEscolar.SelectedValue));
            }
        }
        protected void LlenarDDLCicloRe()
        {
            ddlCicloEscolarRe.Items.Clear();
            ddlCicloEscolarRe.DataSource = ejecCiclo.llenarDDL();
            ddlCicloEscolarRe.DataTextField = "Nombre";
            ddlCicloEscolarRe.DataValueField = "IDCicloEscolar";
            ddlCicloEscolarRe.DataBind();
            if (ddlCicloEscolarRe.Items.Count != 0)
            {
                LlenarDDLPeriodoRe(Convert.ToInt32(ddlCicloEscolarRe.SelectedValue));
            }
        }
        protected void LlenarDDLPeriodo(int IDCiclo)
        {
            ddlPeriodo.Items.Clear();
            ddlPeriodo.DataSource = ejecPer.llenarDDL(IDCiclo);
            ddlPeriodo.DataTextField = "Nombre";
            ddlPeriodo.DataValueField = "IDPeriodo";
            ddlPeriodo.DataBind();
            if (ddlPeriodo.Items.Count != 0)
            {
                LlenarDDLGrupos(Convert.ToInt32(ddlPeriodo.SelectedValue));
            }
        }
        protected void LlenarDDLPeriodoRe(int IDCiclo)
        {
            ddlPeriodoRe.Items.Clear();
            ddlPeriodoRe.DataSource = ejecPer.llenarDDL(IDCiclo);
            ddlPeriodoRe.DataTextField = "Nombre";
            ddlPeriodoRe.DataValueField = "IDPeriodo";
            ddlPeriodoRe.DataBind();
            if (ddlPeriodoRe.Items.Count != 0)
            {
                LlenarDDLGruposRe(Convert.ToInt32(ddlPeriodoRe.SelectedValue));
            }
        }
        protected void LlenarDDLGrupos(int IDPeriodo)
        {
            ddlGrupo.Items.Clear();
            ddlGrupo.DataSource = ejecGrupo.llenarDDL(IDPeriodo);
            ddlGrupo.DataTextField = "NombreGrupo";
            ddlGrupo.DataValueField = "IDGrupo";
            ddlGrupo.DataBind();
        }
        protected void LlenarDDLGruposRe(int IDPeriodo)
        {
            ddlGrupoRe.Items.Clear();
            ddlGrupoRe.DataSource = ejecGrupo.llenarDDL(IDPeriodo);
            ddlGrupoRe.DataTextField = "NombreGrupo";
            ddlGrupoRe.DataValueField = "IDGrupo";
            ddlGrupoRe.DataBind();
            if (ddlGrupo.Items.Count != 0)
            {
                LlenarGVAlumno(Convert.ToInt32(ddlGrupoRe.SelectedValue));
            }
        }
        protected void LlenarGVAlumno(int IDGrupo)
        {
            gvAlumnos.DataSource = ejecAlum.LlenarGridViewGrupos(IDGrupo);
            gvAlumnos.DataBind();
        }

        protected void ddlCicloEscolarRe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLPeriodoRe(Convert.ToInt32(ddlCicloEscolarRe.SelectedValue));
            //upGrupoRe.Update();
        }

        protected void ddlPeriodoRe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGruposRe(Convert.ToInt32(ddlPeriodoRe.SelectedValue));
            //upGrupoRe.Update();
        }

        protected void ddlGrupoRe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVAlumno(Convert.ToInt32(ddlGrupoRe.SelectedValue));
            UpdatePanel1.Update();
        }

        protected void ddlCicloEscolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLPeriodo(Convert.ToInt32(ddlCicloEscolar.SelectedValue));
            //upGrupo.Update();
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLGrupos(Convert.ToInt32(ddlPeriodo.SelectedValue));
            //upGrupo.Update();
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chckSeleccion_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnReinscribir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvAlumnos.Rows.Count; i++)
            {
                CheckBox chkUpdate = (CheckBox)gvAlumnos.Rows[i].Cells[0].FindControl("chckSeleccion");

                if (chkUpdate != null)
                {
                    if (chkUpdate.Checked)
                    {
                        // Get the values of textboxes using findControl
                        string strID = gvAlumnos.Rows[i].Cells[1].Text;
                        string IDAlumno = ((Label)gvAlumnos.Rows[i].FindControl("IDAlumno")).Text;
                        datoGrupo.IDGrupo = Convert.ToInt32(ddlGrupo.SelectedValue);
                        datoAlum.IDAlumno = Convert.ToInt32(IDAlumno);
                        datoAlum.IDGrupo = Convert.ToInt32(ddlGrupo.SelectedValue);
                        datoAlum.IDSemestrePreinscripcion = Convert.ToInt32(ejecGrupo.buscarDatoAlumno("IDSemestre", datoGrupo));
                        ejecAlum.ReinscribirAlumno(datoAlum);
                        CalificacionesInscripcion(Convert.ToInt32(IDAlumno));
                        CalificacionesAlumnoInscripcion(Convert.ToInt32(IDAlumno));
                    }
                }
            }
            LlenarGVAlumno(Convert.ToInt32(ddlGrupo.SelectedValue));
            UpdatePanel1.Update();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }
        protected void CalificacionesInscripcion(int IDAlumno)
        {
            datoAlum.IDAlumno = IDAlumno;
            datoCalif.IDAlumno = IDAlumno;
            DataTable tblMomento = ejecMomento.ObtenerTodosMomentosMomentos();
            DataTable tblAsignaturas = ejecAsig.ObtenerAsigOblig(Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDSemestrePreinscripcion", datoAlum)));
            foreach (DataRow rowm in tblMomento.Rows)
            {
                foreach (DataRow rowa in tblAsignaturas.Rows)
                {
                    datoCalif.IDAsignatura = Convert.ToInt32(rowa.ItemArray.GetValue(0));
                    datoCalif.IDMomento = Convert.ToInt32(rowm.ItemArray.GetValue(0));
                    datoCalif.Calificacion = 0;
                    datoCalif.IDGrupo = Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDGrupo", datoAlum));
                    datoCalif.Inasistencias = 0;
                    ejecCalif.agregarCalificacion(datoCalif);
                }
            }
        }

        protected void CalificacionesAlumnoInscripcion(int IDAlumno)
        {
            datoAlum.IDAlumno = IDAlumno;
            datoCalifA.IDAlumno = IDAlumno;
            DataTable tblMomento = ejecMomento.ObtenerTodosMomentosMomentos();
            DataTable tblAsignaturas = ejecAsig.ObtenerAsigOblig(Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDSemestrePreinscripcion", datoAlum)));
            foreach (DataRow rowm in tblMomento.Rows)
            {
                foreach (DataRow rowa in tblAsignaturas.Rows)
                {
                    datoCalifA.IDAsignatura = Convert.ToInt32(rowa.ItemArray.GetValue(0));
                    datoCalifA.IDMomento = Convert.ToInt32(rowm.ItemArray.GetValue(0));
                    datoCalifA.Calificacion = 0;
                    datoCalifA.IDGrupo = Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDGrupo", datoAlum));
                    datoCalifA.Inasistencias = 0;
                    ejecCalifA.agregarCalificacion(datoCalifA);
                }
            }
        }

    }
}