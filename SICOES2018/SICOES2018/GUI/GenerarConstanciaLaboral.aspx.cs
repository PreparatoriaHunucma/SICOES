using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SICOES2018.BO;
using SICOES2018.DAO;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class GenerarConstanciaLaboral : System.Web.UI.Page
    {
        MaestrosBO datoEmp = new MaestrosBO();
        MaestrosDAO ejecEmp = new MaestrosDAO();
        TipoMaestroBO datoPermiso = new TipoMaestroBO();
        TipoMaestroDAO ejecPermiso = new TipoMaestroDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGVMaestros(Convert.ToInt32(ddlMaestrosReg.SelectedValue));
        }
        protected void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            int Grupos = Convert.ToInt32(ejecEmp.CuentaGrupos(Convert.ToString(Session["EmpModif"])));

            if (Grupos > 0)
            {
                if (Session["EmpModif"] != null)
                {
                    datoEmp.IDMaestro = Convert.ToInt32(Session["AlumModif"]);
                    Response.Redirect("../Reports/ConstanciaLaboral.aspx");
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }

            if (Grupos == 0)
            {
                if (Session["EmpModif"] != null)
                {
                    datoEmp.IDMaestro = Convert.ToInt32(Session["AlumModif"]);
                    Response.Redirect("../Reports/ConstanciaLaboralSinMaterias.aspx");
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }
        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            LimpiarCampos();

            if (currentCommand == "SelectAlum")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["EmpModif"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                datoEmp.IDMaestro = Convert.ToInt32(Session["EmpModif"]); ;


                txtNomEmp.Text = ejecEmp.buscarDatoAlumno("NomMaestro", datoEmp);
                txtNomEmp.ReadOnly = true;
                txtApePatEmp.Text = ejecEmp.buscarDatoAlumno("ApePatMaestro", datoEmp);
                txtApePatEmp.ReadOnly = true;
                txtApeMatEmp.Text = ejecEmp.buscarDatoAlumno("ApeMatMaestro", datoEmp);
                txtApeMatEmp.ReadOnly = true;


            }
            
            ActualizarDatos();

        }

        protected void LlenarGVMaestros(int StatusMaestro)
        {
            gvAlumnos.DataSource = ejecEmp.LlenarGridView(StatusMaestro);
            gvAlumnos.DataBind();
        }

        protected void ddlAlumnosReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVMaestros(Convert.ToInt32(ddlMaestrosReg.SelectedValue));
        }

        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            LlenarGVMaestros(Convert.ToInt32(ddlMaestrosReg.SelectedValue));

        }

        protected void LimpiarCampos()
        {
            txtNomEmp.Text = String.Empty;
            txtApePatEmp.Text = String.Empty;
            txtApeMatEmp.Text = String.Empty;
        }

        protected void ActualizarDatos()
        {
            upDatosGen.Update();
            
        }
    }
}